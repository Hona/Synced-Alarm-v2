using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlarmLibrary;
using Newtonsoft.Json;

namespace ServerUI
{
    public class Settings
    {
        // TODO: Remove all traces of other settings saving
        private bool _isDefaultSoundSet;

        private bool _isIntervalSet;
        private bool _isMessageSet;
        private bool _isStartTimeSet;
        private bool _isStopTimeSet;

        public Settings()
        {
            AlarmList = new List<Alarm>();
        }

        public int MinutesInterval { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime StopTime { get; private set; }
        private Sounds DefaultSound { get; set; }
        public List<Alarm> AlarmList { get; set; }
        public bool AlarmAtStartTime { get; private set; }

        private int CurrentIntervalSetId
        {
            get { return AlarmList.Count != 0 ? AlarmList.Max(x => x.IntervalSetId + 1) : 1; }
        }

        private string DefaultTextToSpeechMessage { get; set; }

        public void JsonSerialize()
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($@"{Environment.CurrentDirectory}/settings.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static Settings JsonDeserialize()
        {
            var jsonText = File.ReadAllLines($@"{Environment.CurrentDirectory}/settings.json")[0];
            return JsonConvert.DeserializeObject<Settings>(jsonText);
        }

        public void SetAlarmAtStartTime(bool doAlarm)
        {
            AlarmAtStartTime = doAlarm;
        }

        public void SetMinutesInterval(int minutes)
        {
            MinutesInterval = minutes;
            _isIntervalSet = true;
        }

        public void SetStartTime(DateTime dateTime)
        {
            StartTime = dateTime;
            _isStartTimeSet = true;
        }

        public void SetStopTime(DateTime dateTime)
        {
            StopTime = dateTime;
            _isStopTimeSet = true;
        }

        public void SetDefaultSound(Sounds s)
        {
            DefaultSound = s;
            _isDefaultSoundSet = true;
        }

        internal void AddIntervalAlarms()
        {
            //Checks whether interval alarms are ready to add, and if so adds them
            var currentId = CurrentIntervalSetId;
            if (AlarmAtStartTime &&
                FindAlarm(StartTime, DefaultSound, DefaultTextToSpeechMessage, out Alarm _, currentId) ==
                false)
                AddAlarm(new Alarm(StartTime, true, DefaultSound, DefaultTextToSpeechMessage, currentId));
            if (_isStartTimeSet && _isStopTimeSet && _isIntervalSet && _isMessageSet && _isDefaultSoundSet &&
                GetIntervalAlarms(currentId).Count <= 1)
            {
                var tempTime = StartTime;
                while (tempTime.AddMinutes(MinutesInterval) <= StopTime)
                {
                    AddAlarm(new Alarm(tempTime.AddMinutes(MinutesInterval), true, DefaultSound,
                        DefaultTextToSpeechMessage, currentId));
                    tempTime = tempTime.AddMinutes(MinutesInterval);
                }
            }
            SortAlarms();
        }

        public void SetDefaultMessage(string message)
        {
            _isMessageSet = true;
            DefaultTextToSpeechMessage = message;
        }

        public bool FindAlarm(DateTime time, Sounds sound, string message, out Alarm outAlarm)
        {
            FindAlarm(time, sound, message, out outAlarm, 0);
            return false;
        }

        // Potentially refactor the if statement - is it required
        public bool FindAlarm(DateTime time, Sounds sound, string message, out Alarm outAlarm, int intervalSetId)
        {
            //Finds and alarm with the specified options and sets the outAlarm to it.
            foreach (var alarm in AlarmList)
                if (alarm.Message != null && message != null)
                {
                    if (alarm.AlarmTime.ToString(Constants.DateTime24HourFormat) !=
                        time.ToString(Constants.DateTime24HourFormat) ||
                        alarm.Sound != sound || alarm.Message != message ||
                        alarm.IntervalSetId != intervalSetId) continue;
                    outAlarm = alarm;
                    return true;
                }
                else
                {
                    if (alarm.AlarmTime.ToString(Constants.DateTime24HourFormat) !=
                        time.ToString(Constants.DateTime24HourFormat) ||
                        alarm.Sound != sound || alarm.IntervalSetId != intervalSetId) continue;
                    outAlarm = alarm;
                    return true;
                }
            outAlarm = new Alarm(DateTime.MinValue, false);
            return false;
        }

        public void AddAlarm(Alarm alarm)
        {
            AlarmList.Add(alarm);
            SortAlarms();
        }

        public void SortAlarms()
        {
            AlarmList = AlarmList.OrderBy(alarm => alarm.AlarmTime).ToList();
        }

        private List<Alarm> GetIntervalAlarms(int id)
        {
            //Returns a list of all alarms that are created as interval alarms
            SortAlarms();
            return AlarmList.Where(alarm => alarm.PartOfIntervalSet && alarm.IntervalSetId == id).ToList();
        }
    }
}
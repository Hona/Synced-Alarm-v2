using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AlarmLibrary;

namespace ServerUI
{
    public class Settings
    {
        private bool _isDefaultSoundSet;
        private bool _isIntervalSet;
        private bool _isMessageSet;
        private bool _isStartTimeSet;
        private bool _isStopTimeSet;

        public Settings() : this(null, null, null, null, null)
        {
        }

        private Settings(DateTime? startTime, DateTime? stopTime, int? minutesInterval, Sounds? defaultSound,
            bool? setAlarmAtStart)
        {
            InitializeLists();
            if (startTime != null)
                SetStartTime((DateTime) startTime);
            if (stopTime != null)
                SetStopTime((DateTime) stopTime);
            if (minutesInterval != null)
                SetMinutesInterval((int) minutesInterval);
            if (defaultSound != null)
                SetDefaultSound((Sounds) defaultSound);
            if (setAlarmAtStart != null)
                SetAlarmAtStartTime((bool) setAlarmAtStart);
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

        public void SaveSettingsToFile()
        {
            //Deletes the current settings file
            if (File.Exists(Environment.CurrentDirectory + "\\settings.txt"))
                File.Delete(Environment.CurrentDirectory + "\\settings.txt");
            using (var fs = new FileStream(Environment.CurrentDirectory + "\\settings.txt", FileMode.CreateNew))
            {
                //Writes all settings to the file

                var toWrite = Encoding.ASCII.GetBytes($"#MinutesInterval={MinutesInterval + Environment.NewLine}");
                fs.Write(toWrite, 0, toWrite.Length);

                toWrite = Encoding.ASCII.GetBytes(
                    $"#StartTime={StartTime.ToString(Constants.DateTime24HourFormat) + Environment.NewLine}");
                fs.Write(toWrite, 0, toWrite.Length);

                toWrite = Encoding.ASCII.GetBytes(
                    $"#StopTime={StopTime.ToString(Constants.DateTime24HourFormat) + Environment.NewLine}");
                fs.Write(toWrite, 0, toWrite.Length);

                toWrite = Encoding.ASCII.GetBytes($"#DefaultSound={DefaultSound + Environment.NewLine}");
                fs.Write(toWrite, 0, toWrite.Length);

                toWrite = Encoding.ASCII.GetBytes(
                    $"//Format: Enabled,AlarmTime,Message,Sound,PartOfIntervalSet,IntervalSetID{Environment.NewLine}");
                fs.Write(toWrite, 0, toWrite.Length);

                var tempAlarmsList = AlarmList.Aggregate("",
                    (current, alarm) => current + $"%{alarm.ToString() + Environment.NewLine}");

                toWrite = Encoding.ASCII.GetBytes(tempAlarmsList);
                fs.Write(toWrite, 0, toWrite.Length);

                toWrite = Encoding.ASCII.GetBytes($"#AlarmAtStartTime={AlarmAtStartTime + Environment.NewLine}");
                fs.Write(toWrite, 0, toWrite.Length);

                toWrite = Encoding.ASCII.GetBytes(
                    $"#DefaultTextToSpeechMessage={DefaultTextToSpeechMessage + Environment.NewLine}");
                fs.Write(toWrite, 0, toWrite.Length);
                //Closes filestream
            }
        }

        public void LoadSettingsFromFile()
        {
            //Opens the settings file as a string array
            var settingStrings = File.ReadAllLines(Environment.CurrentDirectory + "\\settings.txt");
            //Iterates through the array adding the settings
            if (settingStrings.Length < 1) return;
            foreach (var settingString in settingStrings)
                if (!string.IsNullOrEmpty(settingString))
                {
                    if (settingString[0] == '#')
                    {
                        if (settingString.Contains("#MinutesInterval"))
                            if (settingString.Split('=')[1] != string.Empty)
                                MinutesInterval = int.Parse(new string(settingString.Split('=')[1]
                                    .Where(char.IsNumber).ToArray()));
                        if (settingString.Contains("#StartTime"))
                            if (settingString.Split('=')[1] != string.Empty)
                                StartTime = DateTime.ParseExact(settingString.Split('=')[1],Constants.DateTime24HourFormat,CultureInfo.InvariantCulture);
                        if (settingString.Contains("#StopTime"))
                            if (settingString.Split('=')[1] != string.Empty)
                                StopTime = DateTime.ParseExact(settingString.Split('=')[1],Constants.DateTime24HourFormat, CultureInfo.InvariantCulture);
                        if (settingString.Contains("#DefaultSound"))
                            if (settingString.Split('=')[1] != string.Empty)
                                DefaultSound = settingString.Split('=')[1].GetSoundFromString();
                        if (settingString.Contains("#AlarmAtStartTime"))
                            if (settingString.Split('=')[1] != string.Empty)
                                AlarmAtStartTime =
                                    Convert.ToBoolean(Convert.ToString(new string(settingString.Split('=')[1]
                                        .Where(char.IsLetter).ToArray())));
                        if (settingString.Contains("#DefaultTextToSpeechMessage"))
                            if (settingString.Split('=')[1] != string.Empty)
                                DefaultTextToSpeechMessage = settingString.Split('=')[1];
                    }
                    if (settingString[0] != '%') continue;
                    if (!string.IsNullOrEmpty(settingString.Split('%')[1]))
                        AlarmList.Add(Alarm.Parse(settingString.Split('%')[1]));
                }
        }

        private void InitializeLists()
        {
            //Creates instance of the alarm list
            AlarmList = new List<Alarm>();
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
                    if (alarm.AlarmTime.ToString(Constants.DateTime24HourFormat) != time.ToString(Constants.DateTime24HourFormat) ||
                        alarm.Sound != sound || alarm.Message != message ||
                        alarm.IntervalSetId != intervalSetId) continue;
                    outAlarm = alarm;
                    return true;
                }
                else
                {
                    if (alarm.AlarmTime.ToString(Constants.DateTime24HourFormat) != time.ToString(Constants.DateTime24HourFormat) ||
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
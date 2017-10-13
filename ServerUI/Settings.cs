using AlarmLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ServerUI
{
    public class Settings
    {

        private bool _isDefaultSoundSet;
        private bool _isIntervalSet;
        private bool _isStartTimeSet;
        private bool _isStopTimeSet;
        private bool _isMessageSet;

        public Settings() : this(null, null, null, null, null)
        {
        }

        public Settings(DateTime startTime, DateTime stopTime, int minutesInterval) : this(startTime, stopTime,
            minutesInterval, null, null)
        {
        }

        public Settings(DateTime startTime, DateTime stopTime, int minutesInterval, bool setAlarmAtStart) : this(
            startTime, stopTime, minutesInterval, null, setAlarmAtStart)
        {
        }

        public Settings(DateTime startTime, DateTime stopTime, int minutesInterval, Sounds defaultSound) : this(
            startTime, stopTime, minutesInterval, defaultSound, null)
        {
        }

        public Settings(DateTime? startTime, DateTime? stopTime, int? minutesInterval, Sounds? defaultSound,
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
        public Sounds DefaultSound { get; private set; }
        public List<Alarm> AlarmList { get; set; }
        public bool AlarmAtStartTime { get; private set; }

        private int CurrentIntervalSetID
        {
            get { return AlarmList.Count != 0 ? AlarmList.Max(x => x.IntervalSetID + 1) : 1; }
        }

        public string DefaultTextToSpeechMessage { get; private set; }

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
                    $"#StartTime={StartTime.To24HourDateTimeString() + Environment.NewLine}");
                fs.Write(toWrite, 0, toWrite.Length);

                toWrite = Encoding.ASCII.GetBytes(
                    $"#StopTime={StopTime.To24HourDateTimeString() + Environment.NewLine}");
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
                                MinutesInterval = Convert.ToInt32(new string(settingString.Split('=')[1]
                                    .Where(char.IsNumber).ToArray()));
                        if (settingString.Contains("#StartTime"))
                            if (settingString.Split('=')[1] != string.Empty)
                                StartTime = settingString.Split('=')[1].ToDateTimeFrom24HourString();
                        if (settingString.Contains("#StopTime"))
                            if (settingString.Split('=')[1] != string.Empty)
                                StopTime = settingString.Split('=')[1].ToDateTimeFrom24HourString();
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
                        AlarmList.Add(settingString.Split('%')[1].GetAlarmFromString());
                }
        }

        private void InitializeLists()
        {
            //Creates instance of the alarm list
            AlarmList = new List<Alarm>();
        }

        public bool IsInitialized()
        {
            return _isDefaultSoundSet && _isIntervalSet && _isStartTimeSet && _isStopTimeSet &&
                   AlarmList.Count != 0;
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
            var currentID = CurrentIntervalSetID;
            if (AlarmAtStartTime &&
                FindAlarm(StartTime, DefaultSound, DefaultTextToSpeechMessage, out Alarm _, currentID) ==
                false)
                AddAlarm(new Alarm(StartTime, true, DefaultSound, DefaultTextToSpeechMessage, currentID));
            if (_isStartTimeSet && _isStopTimeSet && _isIntervalSet && GetIntervalAlarms(currentID).Count <= 1)
            {
                var tempTime = StartTime;
                while (tempTime.AddMinutes(MinutesInterval) <= StopTime)
                {
                    AddAlarm(new Alarm(tempTime.AddMinutes(MinutesInterval), true, DefaultSound,
                        DefaultTextToSpeechMessage, currentID));
                    tempTime = tempTime.AddMinutes(MinutesInterval);
                }
            }
            SortAlarms();
        }

        public void SetDefaultTTSMessage(string message)
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
        public bool FindAlarm(DateTime time, Sounds sound, string message, out Alarm outAlarm, int intervalSetID)
        {
            //Finds and alarm with the specified options and sets the outAlarm to it.
            foreach (var alarm in AlarmList)
                if (alarm.Message != null && message != null)
                {
                    if (alarm.AlarmTime.To24HourDateTimeString() != time.To24HourDateTimeString() ||
                        alarm.Sound != sound || alarm.Message != message ||
                        alarm.IntervalSetID != intervalSetID) continue;
                    outAlarm = alarm;
                    return true;
                }
                else
                {
                    if (alarm.AlarmTime.To24HourDateTimeString() != time.To24HourDateTimeString() ||
                        alarm.Sound != sound || alarm.IntervalSetID != intervalSetID) continue;
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

        public List<Alarm> GetIntervalAlarms(int id)
        {
            //Returns a list of all alarms that are created as interval alarms
            SortAlarms();
            return AlarmList.Where(alarm => alarm.PartOfIntervalSet && alarm.IntervalSetID == id).ToList();
        }

        public List<Alarm> GetSpecificAlarms()
        {
            //Returns a list of alarms created specifically
            SortAlarms();
            return AlarmList.Where(alarm => !alarm.PartOfIntervalSet && alarm.Sound != Sounds.TextToSpeech).ToList();
        }

        public List<Alarm> GetTextToSpeechAlarms()
        {
            //Returns a list of alarms created as text-to-speech
            SortAlarms();
            return AlarmList.Where(alarm => !alarm.PartOfIntervalSet && alarm.Sound == Sounds.TextToSpeech).ToList();
        }
    }
}
using System;

namespace AlarmLibrary
{
    public class Alarm
    {
        public Alarm(DateTime alarmTime, bool partOfSet, bool enabled, string message, Sounds sound)
        {
            AlarmTime = alarmTime;
            PartOfIntervalSet = partOfSet;
            Enabled = enabled;
            Message = message;
            Sound = sound;
        }
        public Alarm(DateTime alarmTime, bool partOfSet, bool enabled, string message, Sounds sound, int intervalSetId)
        {
            AlarmTime = alarmTime;
            PartOfIntervalSet = partOfSet;
            Enabled = enabled;
            Message = message;
            Sound = sound;
            IntervalSetID = intervalSetId;
        }

        public Alarm(DateTime alarmTime, bool partOfSet, Sounds sound)
        {
            AlarmTime = alarmTime;
            PartOfIntervalSet = partOfSet;
            Sound = sound;
        }

        public Alarm(DateTime alarmTime, bool partOfSet, Sounds sound, string message)
        {
            AlarmTime = alarmTime;
            PartOfIntervalSet = partOfSet;
            Message = message;
            Sound = sound;
        }

        public Alarm(DateTime alarmTime, bool partOfSet, Sounds sound, string message,int intervalSetID)
        {
            AlarmTime = alarmTime;
            PartOfIntervalSet = partOfSet;
            Message = message;
            Sound = sound;
            IntervalSetID = intervalSetID;
        }


        public Alarm(DateTime alarmTime, bool partOfSet)
        {
            AlarmTime = alarmTime;
            PartOfIntervalSet = partOfSet;
        }

        public bool Enabled { get; set; } = true;
        public DateTime AlarmTime { get; set; }
        public string Message { get; set; }
        public Sounds Sound { get; set; }
        public bool PartOfIntervalSet { get; set; }
        public bool AlarmTriggered { get; set; }
        public int IntervalSetID { get; set; }

        public string GetSoundString()
        {
            switch (Sound)
            {
                case Sounds.AnalogWatch:
                    return "Analog Watch";
                case Sounds.SchoolBell:
                    return "School Bell";
                case Sounds.AnnoyingAlarm:
                    return "Annoying Alarm";
                case Sounds.TextToSpeech:
                    return "Text-to-Speech";
                default:
                    return "Sound not implemented";
            }
        }

        public override string ToString()
        {
            return $"{Enabled},{AlarmTime.To24HourDateTimeString()},{Message},{Sound},{PartOfIntervalSet},{IntervalSetID}";
        }
    }
}
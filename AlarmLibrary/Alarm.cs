using System;
using System.Globalization;

namespace AlarmLibrary
{
    public class Alarm
    {
        public Alarm()
        {
        }

        private Alarm(DateTime alarmTime, bool partOfSet, bool enabled, string message, Sounds sound, int intervalSetId)
        {
            AlarmTime = alarmTime;
            PartOfIntervalSet = partOfSet;
            Enabled = enabled;
            Message = message;
            Sound = sound;
            IntervalSetId = intervalSetId;
        }

        public Alarm(DateTime alarmTime, bool partOfSet, Sounds sound, string message)
        {
            AlarmTime = alarmTime;
            PartOfIntervalSet = partOfSet;
            Message = message;
            Sound = sound;
        }

        public Alarm(DateTime alarmTime, bool partOfSet, Sounds sound, string message, int intervalSetId)
        {
            AlarmTime = alarmTime;
            PartOfIntervalSet = partOfSet;
            Message = message;
            Sound = sound;
            IntervalSetId = intervalSetId;
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
        public bool PartOfIntervalSet { get; }
        public bool AlarmTriggered { get; set; }
        public int IntervalSetId { get; set; }

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
            return
                $"{Enabled},{AlarmTime.ToString(Constants.DateTime24HourFormat)},{Message},{Sound},{PartOfIntervalSet},{IntervalSetId}";
        }

        public static Alarm Parse(string fromString)
        {
            //Format: Enabled,AlarmTime,Message,Sound,PartOfIntervalSet
            //AlarmMode,AlarmTime,PartOfIntervalSet
            var stringArray = fromString.Split(',');
            return new Alarm(
                DateTime.ParseExact(stringArray[1], Constants.DateTime24HourFormat, CultureInfo.InvariantCulture),
                Convert.ToBoolean(stringArray[4]),
                Convert.ToBoolean(stringArray[0]),
                stringArray[2],
                stringArray[3].GetSoundFromString(),
                int.Parse(stringArray[5]));
        }
    }
}
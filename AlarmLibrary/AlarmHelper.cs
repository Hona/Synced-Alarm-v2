using System;

namespace AlarmLibrary
{
    public static class AlarmHelper
    {
        public static Alarm GetAlarmFromString(this string fromString)
        {
            //Format: Enabled,AlarmTime,Message,Sound,PartOfIntervalSet
            //AlarmMode, AlarmTime,PartOfIntervalSet
            return new Alarm(fromString.Split(',')[1].ToDateTimeFrom24HourString(),
                Convert.ToBoolean(fromString.Split(',')[4]),
                Convert.ToBoolean(fromString.Split(',')[0]),
                fromString.Split(',')[2],
                fromString.Split(',')[3].GetSoundFromString(),
                Convert.ToInt32(fromString.Split(',')[5]));
        }
    }
}
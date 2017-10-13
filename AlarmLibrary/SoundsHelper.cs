using System;
using System.Media;
using System.Speech.Synthesis;
using AlarmLibrary.Properties;

namespace AlarmLibrary
{
    public static class SoundsHelper
    {
        public static SoundPlayer SoundPlayer;

        public static Sounds GetSoundFromString(this string soundText)
        {
            if (soundText == "Analog Watch" || soundText == "AnalogWatch")
                return Sounds.AnalogWatch;
            if (soundText == "Annoying Alarm" || soundText == "AnnoyingAlarm")
                return Sounds.AnnoyingAlarm;
            if (soundText == "School Bell" || soundText == "SchoolBell")
                return Sounds.SchoolBell;
            if (soundText == "Text-to-Speech" || soundText == "TextToSpeech")
                return Sounds.TextToSpeech;

            return Sounds.SchoolBell;
        }

        public static void SoundAlarm(object alarm)
        {
            if (!(alarm is Alarm || alarm is Sounds)) return;
            var soundSwitcher = Sounds.AnalogWatch;
            if (alarm is Alarm convertedAlarm)
                soundSwitcher = convertedAlarm.Sound;
            if (alarm is Sounds convertedSounds)
                soundSwitcher = convertedSounds;

            switch (soundSwitcher)
            {
                case Sounds.AnalogWatch:
                    SoundPlayer = new SoundPlayer(Resources.RoyaltyFreeAnalogWatch);
                    SoundPlayer.Play();
                    break;
                case Sounds.AnnoyingAlarm:
                    SoundPlayer = new SoundPlayer(Resources.RoyaltyFreeAlarmClock);
                    SoundPlayer.Play();
                    break;
                case Sounds.SchoolBell:
                    SoundPlayer = new SoundPlayer(Resources.RoyaltyFreeSchoolBell);
                    SoundPlayer.Play();
                    break;
                case Sounds.TextToSpeech:
                    var ss = new SpeechSynthesizer();
                    if (alarm is Alarm ttsConvertedAlarm)
                        ss.Speak(ttsConvertedAlarm.Message);
                    else
                        ss.Speak("Error. The object parsed to the sound player was of the sound class, not alarm.");
                    break;
                default:
                    if (alarm is Alarm errorConvertedAlarm)
                        throw new Exception("Sound enum not implemented: " + errorConvertedAlarm.Sound);
                    break;
            }
        }
    }
}
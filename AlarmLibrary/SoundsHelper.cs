using System;
using System.Media;
using System.Speech.Synthesis;
using AlarmLibrary.Properties;

namespace AlarmLibrary
{
    public static class SoundsHelper
    {
        private static SoundPlayer _soundPlayer;

        public static Sounds GetSoundFromString(this string soundText)
        {
            switch (soundText)
            {
                case "Analog Watch":
                case "AnalogWatch":
                    return Sounds.AnalogWatch;
                case "Annoying Alarm":
                case "AnnoyingAlarm":
                    return Sounds.AnnoyingAlarm;
                case "School Bell":
                case "SchoolBell":
                    return Sounds.SchoolBell;
                case "Text-to-Speech":
                case "TextToSpeech":
                    return Sounds.TextToSpeech;
            }

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
                    _soundPlayer = new SoundPlayer(Resources.RoyaltyFreeAnalogWatch);
                    _soundPlayer.Play();
                    break;
                case Sounds.AnnoyingAlarm:
                    _soundPlayer = new SoundPlayer(Resources.RoyaltyFreeAlarmClock);
                    _soundPlayer.Play();
                    break;
                case Sounds.SchoolBell:
                    _soundPlayer = new SoundPlayer(Resources.RoyaltyFreeSchoolBell);
                    _soundPlayer.Play();
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
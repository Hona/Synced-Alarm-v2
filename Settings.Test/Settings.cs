using System;
using AlarmLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Settings.Test
{
    [TestClass]
    public class Settings
    {
        [TestMethod]
        public void TestFindAlarms()
        {
            var settings = new ServerUI.Settings();
            var time = DateTime.Now;
            var alarm = new Alarm(time, true, Sounds.TextToSpeech, "asdfEFASDF");
            settings.AlarmList.Add(alarm);
            Assert.AreEqual(true, settings.TryFindAlarm(time, Sounds.TextToSpeech, "asdfEFASDF", out Alarm foundAlarm));
            Assert.AreEqual(alarm, foundAlarm);
        }

        [TestMethod]
        public void TestDeserialization()
        {
            var settings = new ServerUI.Settings();
            settings.AlarmList.Add(new Alarm(DateTime.Now, false, Sounds.AnnoyingAlarm, "asdf", 0));
            settings.AlarmList.Add(new Alarm(DateTime.Now.AddHours(2), true, Sounds.TextToSpeech, "asdasdgasdgf", 3));
            settings.AlarmList.Add(new Alarm(DateTime.Now.AddMinutes(36), true, Sounds.TextToSpeech, "asdfEFASDF"));

            settings.SetAlarmAtStartTime(false);
            settings.SetMinutesInterval(6);
            var serialized = JsonConvert.SerializeObject(settings);
            var loadedSettings = JsonConvert.DeserializeObject<ServerUI.Settings>(serialized);
            for (var i = 0; i < settings.AlarmList.Count; i++)
            {
                Assert.AreEqual(settings.AlarmList[i].Enabled, loadedSettings.AlarmList[i].Enabled);
                Assert.AreEqual(settings.AlarmList[i].AlarmTime, loadedSettings.AlarmList[i].AlarmTime);
                Assert.AreEqual(settings.AlarmList[i].AlarmTriggered, loadedSettings.AlarmList[i].AlarmTriggered);
                Assert.AreEqual(settings.AlarmList[i].IntervalSetId, loadedSettings.AlarmList[i].IntervalSetId);
                Assert.AreEqual(settings.AlarmList[i].Message, loadedSettings.AlarmList[i].Message);
                Assert.AreEqual(settings.AlarmList[i].PartOfIntervalSet, loadedSettings.AlarmList[i].PartOfIntervalSet);
                Assert.AreEqual(settings.AlarmList[i].Sound, loadedSettings.AlarmList[i].Sound);
            }
            Assert.AreEqual(settings.AlarmAtStartTime, loadedSettings.AlarmAtStartTime);
            Assert.AreEqual(settings.MinutesInterval, loadedSettings.MinutesInterval);
            Assert.AreEqual(settings.StartTime, loadedSettings.StartTime);
            Assert.AreEqual(settings.StopTime, loadedSettings.StopTime);
        }
    }
}
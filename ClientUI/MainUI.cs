using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using AlarmLibrary;

namespace ClientUI
{
    public partial class MainUi : Form
    {
        private List<Alarm> _alarmsList;

        public MainUi()
        {
            InitializeComponent();
            _alarmsList = new List<Alarm>();

            //Stops the panel flickering - Credit: https://stackoverflow.com/questions/8046560/how-to-stop-flickering-c-sharp-winforms
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, MainPanel, new object[] {true});

            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var alarmStrings = config.AppSettings.Settings["Alarms"].Value.Split(';');
                foreach (var alarmString in alarmStrings)
                    if (!string.IsNullOrWhiteSpace(alarmString))
                    {
                        var a = Alarm.Parse(alarmString);
                        _alarmsList.Add(a);
                    }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Error loading alarms from file");
            }
            UpdateTimer.Interval = 50;
            MainPanel.BackColor = Color.FromArgb(255, 0, 0);


            UpdateAlarmsList();
            UpdateTimer.Start();
        }

        private void UpdateAlarmsList()
        {
            var forAlarmsList = "Remaining Alarms:" + Environment.NewLine + Environment.NewLine;
            forAlarmsList = _alarmsList.Where(alarm => alarm.AlarmTriggered == false).Aggregate(forAlarmsList,
                (current, alarm) => current + alarm.AlarmTime.ToLongTimeString() + Environment.NewLine);
            if (forAlarmsList == "Remaining Alarms:" + Environment.NewLine + Environment.NewLine)
            {
                lblAlarmList.Text = "";
            }
            else
            {
                forAlarmsList = forAlarmsList.Trim();
                lblAlarmList.Text = forAlarmsList;
            }
        }

        private void TriggerAlarms()
        {
            foreach (var alarm in _alarmsList)
                if (DateTime.Now >= alarm.AlarmTime && alarm.AlarmTriggered == false)
                {
                    // Start a thread that calls a parameterized static method.
                    var soundThread = new Thread(SoundsHelper.SoundAlarm);
                    soundThread.Start(alarm);
                    alarm.AlarmTriggered = true;
                }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            TriggerAlarms();
            ChangeColor();
            UpdateTimeUntilNextAlarm();
            UpdateAlarmsList();
        }

        private void UpdateTimeUntilNextAlarm()
        {
            _alarmsList = _alarmsList.OrderBy(x => x.AlarmTime).ToList();
            try
            {
                var timeUntil = _alarmsList.Find(alarm => alarm.AlarmTriggered == false).AlarmTime - DateTime.Now;
                lblTimeUntilNextAlarm.Text =
                    $@"Next alarm in:{Environment.NewLine + timeUntil.Minutes}:{
                            timeUntil.Seconds.ToString().PadLeft(2, '0')
                        }";
            }
            catch (Exception)
            {
                lblTimeUntilNextAlarm.Text = @"No more alarms.";
            }
        }

        private void ChangeColor()
        {
            //Colour starts at 255 red

            //Add green
            if (MainPanel.BackColor.R == 255 && MainPanel.BackColor.G < 255 && MainPanel.BackColor.B == 0)
                MainPanel.BackColor = Color.FromArgb(MainPanel.BackColor.R, MainPanel.BackColor.G + 3,
                    MainPanel.BackColor.B);
            //When green is 255, remove red
            if (MainPanel.BackColor.R > 0 && MainPanel.BackColor.G == 255 && MainPanel.BackColor.B == 0)
                MainPanel.BackColor = Color.FromArgb(MainPanel.BackColor.R - 3, MainPanel.BackColor.G,
                    MainPanel.BackColor.B);
            //When red is 0, add blue
            if (MainPanel.BackColor.R == 0 && MainPanel.BackColor.G == 255 && MainPanel.BackColor.B < 255)
                MainPanel.BackColor = Color.FromArgb(MainPanel.BackColor.R, MainPanel.BackColor.G,
                    MainPanel.BackColor.B + 3);
            //When blue is 255, remove green
            if (MainPanel.BackColor.R == 0 && MainPanel.BackColor.G > 0 && MainPanel.BackColor.B == 255)
                MainPanel.BackColor = Color.FromArgb(MainPanel.BackColor.R, MainPanel.BackColor.G - 3,
                    MainPanel.BackColor.B);
            //When green is 0, add red
            if (MainPanel.BackColor.R < 255 && MainPanel.BackColor.G == 0 && MainPanel.BackColor.B == 255)
                MainPanel.BackColor = Color.FromArgb(MainPanel.BackColor.R + 3, MainPanel.BackColor.G,
                    MainPanel.BackColor.B);
            //When red is 255, remove blue
            if (MainPanel.BackColor.R == 255 && MainPanel.BackColor.G == 0 && MainPanel.BackColor.B > 0)
                MainPanel.BackColor = Color.FromArgb(MainPanel.BackColor.R, MainPanel.BackColor.G,
                    MainPanel.BackColor.B - 3);
        }

        private void MainUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F11) return;
            switch (WindowState)
            {
                case FormWindowState.Normal:
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    Bounds = Screen.PrimaryScreen.Bounds;
                    TopMost = true;
                    break;
                case FormWindowState.Maximized:
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    Bounds = new Rectangle(0, 0, 775, 434);
                    CenterToScreen();
                    TopMost = false;
                    break;
            }
        }
    }
}
using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AlarmLibrary;

namespace ServerUI
{
    public partial class MainUi : Form
    {
        private readonly bool _settingsSaveable;
        private Thread _intervalSoundThread;
        private Settings _settings;
        private Thread _specificSoundThread;

        public MainUi()
        {
            //Initializes variables
            InitializeComponent();
            _settings = new Settings();

            //Disables tabs and controls
            btnPostClient.Enabled = false;
            btnAddIntervalTimes.Enabled = false;
            btnEditAlarm.Enabled = false;
            btnDeleteAlarm.Enabled = false;
            btnDeleteIntervalSet.Enabled = false;
            txtSpecificMessage.Enabled = false;
            txtIntervalTTSMessage.Enabled = false;

            lvAlarmsList.FullRowSelect = true;
            lvAlarmsList.MultiSelect = false;
            lvAlarmsList.HideSelection = false;

            //Sets combobox data sources
            cbIntervalSound.DataSource = Enum.GetValues(typeof(Sounds));
            cbSpecificSound.DataSource = Enum.GetValues(typeof(Sounds));

            //Tries to load settings from the file
            try
            {
                if (File.Exists(Environment.CurrentDirectory + "\\settings.json"))
                    _settings = Settings.JsonDeserialize();
                _settingsSaveable = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                _settingsSaveable = false;
                var result =
                    MessageBox.Show(
                        $@"Settings file could not be loaded. Create a new configuration?{
                                Environment.NewLine
                            }(Corrupt settings file will be backed up.)",
                        @"Settings couldn't be loaded", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Abort:
                        Close();
                        break;
                    case DialogResult.Yes:
                        File.Copy(Environment.CurrentDirectory + "\\settings.json",
                            Environment.CurrentDirectory + "\\settings.json.backup", true);
                        _settings = new Settings();
                        break;
                    case DialogResult.No:
                        Close();
                        break;
                }
            }
            UpdateControlValues();
        }

        private void UpdateControlValues()
        {
            //Sets values of controls to setting values
            dtpStartTime.Value = _settings.StartTime == DateTime.MinValue ? DateTime.Now : _settings.StartTime;
            dtpStopTime.Value = _settings.StopTime == DateTime.MinValue ? DateTime.Now : _settings.StopTime;
            cbAddAlarmAtStartTime.Checked = _settings.AlarmAtStartTime;
            nudAlarmInterval.Value = _settings.MinutesInterval;
            btnPostClient.Enabled = _settings.AlarmList.Count != 0;
        }

        private void btnPostClient_Click(object sender, EventArgs e)
        {
            if (_settings.AlarmList.Count == 0)
            {
                btnPostClient.Enabled = false;
                return;
            }
            //Creates a config manager for the client program
            var config =
                ConfigurationManager.OpenExeConfiguration(Environment.CurrentDirectory + "\\ClientUI.exe");

            //If the Alarms key already exists delete it
            if (config.AppSettings.Settings.AllKeys.Contains("Alarms"))
                config.AppSettings.Settings.Remove("Alarms");

            //Creates and formats a string with the alarms, then writes it the the config file
            var alarmList = _settings.AlarmList.Aggregate("",
                (currentString, nextAlarm) => currentString + (nextAlarm + ";"));
            config.AppSettings.Settings.Add("Alarms", alarmList);
            config.Save(ConfigurationSaveMode.Modified);

            //User selects a folder for the client to be posted to, then copies the files there
            using (var folderSelectorDialog =
                new FolderBrowserDialog {Description = @"Select the destination folder for the client exe."})
            {
                var result = folderSelectorDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderSelectorDialog.SelectedPath))
                {
                    File.Copy(Environment.CurrentDirectory + "\\ClientUI.exe",
                        folderSelectorDialog.SelectedPath + "\\ClientUI.exe", true);
                    File.Copy(Environment.CurrentDirectory + "\\ClientUI.exe.config",
                        folderSelectorDialog.SelectedPath + "\\ClientUI.exe.config", true);
                    File.Copy(Environment.CurrentDirectory + "\\AlarmLibrary.dll",
                        folderSelectorDialog.SelectedPath + "\\AlarmLibrary.dll", true);
                    MessageBox.Show(@"The client app is now configured to use the set alarms.");
                }
                else
                {
                    if (result == DialogResult.Cancel || result == DialogResult.Abort)
                        MessageBox.Show(@"Files were not copied.");
                    if (result == DialogResult.OK)
                        MessageBox.Show(@"The selected path is invalid.");
                }
            }
        }

        private void btnAddIntervalTimes_Click(object sender, EventArgs e)
        {
            //Sets the variables to specified values - the settings class automatically adds the values when ready.
            _settings.SetAlarmAtStartTime(cbAddAlarmAtStartTime.Checked);
            _settings.SetDefaultSound((Sounds) cbIntervalSound.SelectedItem);
            _settings.SetStartTime(dtpStartTime.Value);
            _settings.SetStopTime(dtpStopTime.Value);
            _settings.SetDefaultMessage(txtIntervalTTSMessage.Text);
            _settings.SetMinutesInterval(int.Parse(nudAlarmInterval.Value.ToString(CultureInfo.InvariantCulture)));
            _settings.AddIntervalAlarms();
            if (_settings.AlarmList.Count != 0)
                btnPostClient.Enabled = true;
            UpdateControlValues();
            tabSettings.SelectedIndex = 2;
            tabSettings_Click(null, null);
        }

        internal void tabSettings_Click(object sender, EventArgs e)
        {
            btnEditAlarm.Enabled = lvAlarmsList.SelectedItems.Count != 0;
            btnDeleteIntervalSet.Enabled = lvAlarmsList.SelectedItems.Count != 0;
            btnDeleteAlarm.Enabled = lvAlarmsList.SelectedItems.Count != 0;

            //Clears the list
            lvAlarmsList.Items.Clear();


            if (tabSettings.SelectedIndex == 2)
            {
                _settings.SortAlarms();
                var timeClashes = _settings.AlarmList.GroupBy(x => x.AlarmTime)
                    .Where(g => g.Count() > 1)
                    .Select(y => y).ToList();
                if (timeClashes.Count != 0)
                    MessageBox.Show(timeClashes.Count + @" alarm time clashes!");
            }

            //Iterates through alarms
            foreach (var alarm in _settings.AlarmList)
            {
                //Creates a listview item with the values of the alarm
                var lvItem = new ListViewItem(new[]
                {
                    //Collumn string values
                    alarm.AlarmTime.ToString(Constants.DateTime24HourFormat), alarm.GetSoundString(),
                    alarm.Message, alarm.IntervalSetId.ToString()
                })
                {
                    //ListViewItem changes
                    //Checks if the alarm is enabled and sets the checkbox value accordingly
                    Checked = alarm.Enabled
                };

                //Adds the new list item to the listview
                lvAlarmsList.Items.Add(lvItem);
            }
        }

        private void nudIntervalBasedAlarm_ValueChanged(object sender, EventArgs e)
        {
            UpdateAddIntervalAlarmsState();
        }

        private void UpdateAddIntervalAlarmsState()
        {
            //Checks whether the interval times are valid
            if (nudAlarmInterval.Value != 0 && dtpStopTime.Value > dtpStartTime.Value)
                btnAddIntervalTimes.Enabled = true;
            else
                btnAddIntervalTimes.Enabled = false;
        }

        private void lvAlarmsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Finds the alarm selected from the listview and sets the enabled boolean to the checkbox value
            if (_settings.TryFindAlarm(
                DateTime.ParseExact(lvAlarmsList.Items[e.Index].SubItems[0].Text, Constants.DateTime24HourFormat,
                    CultureInfo.InvariantCulture),
                lvAlarmsList.Items[e.Index].SubItems[1].Text.GetSoundFromString(),
                lvAlarmsList.Items[e.Index].SubItems[2].Text, out Alarm selectedAlarm))
                selectedAlarm.Enabled = e.NewValue == CheckState.Checked;
        }

        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Checks if the settings are fine to be saved, then saves them to a file
            if (_settingsSaveable)
                _settings.JsonSerialize();
        }

        private void btnAddSpecificAlarm_Click(object sender, EventArgs e)
        {
            //Creates and adds the specific alarm to the alarm list
            _settings.AddAlarm(new Alarm(dtpSpecificAlarm.Value, false, (Sounds) cbSpecificSound.SelectedItem,
                txtSpecificMessage.Text));
            UpdateControlValues();
            tabSettings.SelectedIndex = 2;
            tabSettings_Click(null, null);
        }

        private void btnDeleteSettings_Click(object sender, EventArgs e)
        {
            _settings = new Settings();
            tabSettings.SelectedIndex = 0;
            UpdateControlValues();
        }

        private void btnPlaySoundIntervalTab_Click(object sender, EventArgs e)
        {
            _intervalSoundThread = new Thread(SoundsHelper.SoundAlarm);
            if ((Sounds) cbIntervalSound.SelectedItem == Sounds.TextToSpeech)
                if (txtIntervalTTSMessage.Text != string.Empty)
                    _intervalSoundThread.Start(new Alarm(DateTime.Now, false, Sounds.TextToSpeech,
                        txtIntervalTTSMessage.Text));
                else
                    _intervalSoundThread.Start(new Alarm(DateTime.Now, false, Sounds.TextToSpeech,
                        "This is an example of speech synthesis"));
            else
                _intervalSoundThread.Start((Sounds) cbIntervalSound.SelectedItem);
        }

        private void btnPlaySoundSpecificTab_Click(object sender, EventArgs e)
        {
            _specificSoundThread = new Thread(SoundsHelper.SoundAlarm);
            if ((Sounds) cbSpecificSound.SelectedItem == Sounds.TextToSpeech)
                if (txtSpecificMessage.Text != string.Empty)
                    _specificSoundThread.Start(new Alarm(DateTime.Now, false, Sounds.TextToSpeech,
                        txtSpecificMessage.Text));
                else
                    _specificSoundThread.Start(new Alarm(DateTime.Now, false, Sounds.TextToSpeech,
                        "This is an example of speech synthesis"));
            else
                _specificSoundThread.Start((Sounds) cbSpecificSound.SelectedItem);
        }

        private void schoolBellLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=3WYOdWQlXFA");
        }

        private void alarmBellLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=JtKO172fB08");
        }

        private void alarmLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=oHwaoToqyVs");
        }

        private void cbSpecificSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSpecificMessage.Enabled = (Sounds) cbSpecificSound.SelectedItem == Sounds.TextToSpeech;
        }

        private void cbIntervalSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIntervalTTSMessage.Enabled = (Sounds) cbIntervalSound.SelectedItem == Sounds.TextToSpeech;
        }

        private void btnEditAlarm_Click(object sender, EventArgs e)
        {
            _settings.TryFindAlarm(
                DateTime.ParseExact(lvAlarmsList.SelectedItems[0].SubItems[0].Text, Constants.DateTime24HourFormat,
                    CultureInfo.InvariantCulture),
                lvAlarmsList.SelectedItems[0].SubItems[1].Text.GetSoundFromString(),
                lvAlarmsList.SelectedItems[0].SubItems[2].Text, out Alarm selectedAlarm,
                int.Parse(lvAlarmsList.SelectedItems[0].SubItems[3].Text));
            var editAlarmForm = new EditAlarmForm(selectedAlarm, this);
            editAlarmForm.Show();
        }

        private void lvAlarmsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditAlarm.Enabled = lvAlarmsList.SelectedItems.Count != 0;
            btnDeleteAlarm.Enabled = lvAlarmsList.SelectedItems.Count != 0;
            btnDeleteIntervalSet.Enabled = lvAlarmsList.SelectedItems.Count != 0;
        }

        private void nudAlarmInterval_Leave(object sender, EventArgs e)
        {
            UpdateAddIntervalAlarmsState();
        }

        private void nudAlarmInterval_Leave(object sender, KeyEventArgs e)
        {
            UpdateAddIntervalAlarmsState();
        }

        private void btnAddIntervalTimes_MouseEnter(object sender, EventArgs e)
        {
            btnAddIntervalTimes.Select();
            UpdateAddIntervalAlarmsState();
        }

        private void btnDeleteAlarm_Click(object sender, EventArgs e)
        {
            var oldIndex = lvAlarmsList.SelectedItems[0].Index;
            _settings.TryFindAlarm(
                DateTime.ParseExact(lvAlarmsList.SelectedItems[0].SubItems[0].Text, Constants.DateTime24HourFormat,
                    CultureInfo.InvariantCulture),
                lvAlarmsList.SelectedItems[0].SubItems[1].Text.GetSoundFromString(),
                lvAlarmsList.SelectedItems[0].SubItems[2].Text, out Alarm selectedAlarm,
                int.Parse(lvAlarmsList.SelectedItems[0].SubItems[3].Text));
            _settings.AlarmList.Remove(selectedAlarm);
            tabSettings_Click(null, null);
            if (lvAlarmsList.Items.Count >= oldIndex)
                lvAlarmsList.Items[oldIndex].Selected = true;
            lvAlarmsList.Select();
        }

        private void btnDeleteIntervalSet_Click(object sender, EventArgs e)
        {
            var oldIndex = lvAlarmsList.SelectedItems[0].Index;
            var idToDelete = int.Parse(lvAlarmsList.SelectedItems[0].SubItems[3].Text);
            var newAlarmList = _settings.AlarmList.Where(x => x.IntervalSetId != idToDelete).ToList();
            _settings.AlarmList = newAlarmList;
            tabSettings_Click(null, null);
            if (lvAlarmsList.Items.Count >= oldIndex)
                lvAlarmsList.Items[oldIndex].Selected = true;
            lvAlarmsList.Select();
        }

        private void txtSpecificMessage_TextChanged(object sender, EventArgs e)
        {
        }

        private void dtpSpecificAlarm_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
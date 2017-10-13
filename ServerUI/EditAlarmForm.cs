using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlarmLibrary;

namespace ServerUI
{
    public partial class EditAlarmForm : Form
    {
        private MainUI _parentForm;
        private Alarm _openAlarm;
        private bool _changed;
        public EditAlarmForm(Alarm alarm, MainUI parentForm)
        {
            _openAlarm = alarm;
            _parentForm = parentForm;
            InitializeComponent();
            cbAlarmSound.DataSource = Enum.GetValues(typeof(Sounds));
            
            //Set the values to alarms current values
            cbAlarmSound.SelectedItem = alarm.Sound;
            txtTTSMessage.Text = alarm.Message;
            dtpAlarmTime.Value = alarm.AlarmTime;

            UpdateButtonStates();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(dtpAlarmTime.Value != DateTime.MinValue && cbAlarmSound.SelectedItem != null)) return;
            _openAlarm.Sound = (Sounds) cbAlarmSound.SelectedItem;
            _openAlarm.AlarmTime = dtpAlarmTime.Value;
            _openAlarm.Message = txtTTSMessage.Text;
            _parentForm.tabSettings_Click(null,null);
            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtpAlarmTime_ValueChanged(object sender, EventArgs e)
        {
            _changed = _openAlarm.AlarmTime != dtpAlarmTime.Value;
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            if (!_changed)
            {
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = btnCancel.Enabled = dtpAlarmTime.Value != DateTime.MinValue && cbAlarmSound.SelectedItem != null;
        }

        private void cbAlarmSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            _changed = _openAlarm.Sound != (Sounds)cbAlarmSound.SelectedItem;

            UpdateButtonStates();
            txtTTSMessage.Enabled = (Sounds)cbAlarmSound.SelectedItem == Sounds.TextToSpeech;
        }

        private void txtTTSMessage_TextChanged(object sender, EventArgs e)
        {
            _changed = _openAlarm.Message != txtTTSMessage.Text;
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            var soundThread = new Thread(SoundsHelper.SoundAlarm);
            if ((Sounds)cbAlarmSound.SelectedItem == Sounds.TextToSpeech)
            {
                if (txtTTSMessage.Text != string.Empty)
                {
                    soundThread.Start(new Alarm(DateTime.Now, false, Sounds.TextToSpeech,
                        txtTTSMessage.Text));
                }
                else
                    soundThread.Start(new Alarm(DateTime.Now, false, Sounds.TextToSpeech,
                        "This is an example of speech synthesis"));
            }
            else
                soundThread.Start((Sounds)cbAlarmSound.SelectedItem);
        }
    }
}

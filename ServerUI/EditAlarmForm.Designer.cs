namespace ServerUI
{
    partial class EditAlarmForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAlarmTime = new System.Windows.Forms.DateTimePicker();
            this.cbAlarmSound = new System.Windows.Forms.ComboBox();
            this.txtTTSMessage = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(12, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Alarm Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(42, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Sound:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(24, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Message:";
            // 
            // dtpAlarmTime
            // 
            this.dtpAlarmTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpAlarmTime.Location = new System.Drawing.Point(98, 9);
            this.dtpAlarmTime.Name = "dtpAlarmTime";
            this.dtpAlarmTime.Size = new System.Drawing.Size(119, 20);
            this.dtpAlarmTime.TabIndex = 15;
            this.dtpAlarmTime.ValueChanged += new System.EventHandler(this.dtpAlarmTime_ValueChanged);
            // 
            // cbAlarmSound
            // 
            this.cbAlarmSound.FormattingEnabled = true;
            this.cbAlarmSound.Location = new System.Drawing.Point(98, 35);
            this.cbAlarmSound.Name = "cbAlarmSound";
            this.cbAlarmSound.Size = new System.Drawing.Size(119, 21);
            this.cbAlarmSound.TabIndex = 32;
            this.cbAlarmSound.SelectedIndexChanged += new System.EventHandler(this.cbAlarmSound_SelectedIndexChanged);
            // 
            // txtTTSMessage
            // 
            this.txtTTSMessage.Location = new System.Drawing.Point(98, 63);
            this.txtTTSMessage.Multiline = true;
            this.txtTTSMessage.Name = "txtTTSMessage";
            this.txtTTSMessage.Size = new System.Drawing.Size(198, 82);
            this.txtTTSMessage.TabIndex = 33;
            this.txtTTSMessage.TextChanged += new System.EventHandler(this.txtTTSMessage_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancel.Location = new System.Drawing.Point(165, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.Location = new System.Drawing.Point(45, 151);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaySound.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPlaySound.Location = new System.Drawing.Point(223, 35);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(73, 23);
            this.btnPlaySound.TabIndex = 36;
            this.btnPlaySound.Text = "Play";
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // EditAlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 180);
            this.Controls.Add(this.btnPlaySound);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtTTSMessage);
            this.Controls.Add(this.cbAlarmSound);
            this.Controls.Add(this.dtpAlarmTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditAlarmForm";
            this.Text = "Edit Alarm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpAlarmTime;
        private System.Windows.Forms.ComboBox cbAlarmSound;
        private System.Windows.Forms.TextBox txtTTSMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPlaySound;
    }
}
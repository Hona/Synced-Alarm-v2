namespace ServerUI
{
    partial class MainUi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUi));
            this.lowerPanel = new System.Windows.Forms.Panel();
            this.btnPostClient = new System.Windows.Forms.Button();
            this.btnDeleteSettings = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.txtIntervalTTSMessage = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnPlaySoundIntervalTab = new System.Windows.Forms.Button();
            this.cbIntervalSound = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbAddAlarmAtStartTime = new System.Windows.Forms.CheckBox();
            this.btnAddIntervalTimes = new System.Windows.Forms.Button();
            this.dtpStopTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudAlarmInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SpecificTab = new System.Windows.Forms.TabPage();
            this.btnPlaySoundSpecificTab = new System.Windows.Forms.Button();
            this.cbSpecificSound = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSpecificMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddSpecificAlarm = new System.Windows.Forms.Button();
            this.dtpSpecificAlarm = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.AlarmsListTab = new System.Windows.Forms.TabPage();
            this.lvAlarmsList = new System.Windows.Forms.ListView();
            this.chAlarmTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIntervalId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.btnDeleteIntervalSet = new System.Windows.Forms.Button();
            this.btnDeleteAlarm = new System.Windows.Forms.Button();
            this.btnEditAlarm = new System.Windows.Forms.Button();
            this.CreditsTab = new System.Windows.Forms.TabPage();
            this.alarmLabel = new System.Windows.Forms.LinkLabel();
            this.schoolBellLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.alarmBellLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lowerPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmInterval)).BeginInit();
            this.SpecificTab.SuspendLayout();
            this.AlarmsListTab.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.CreditsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // lowerPanel
            // 
            this.lowerPanel.Controls.Add(this.btnPostClient);
            this.lowerPanel.Controls.Add(this.btnDeleteSettings);
            this.lowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lowerPanel.Location = new System.Drawing.Point(0, 276);
            this.lowerPanel.Name = "lowerPanel";
            this.lowerPanel.Size = new System.Drawing.Size(584, 44);
            this.lowerPanel.TabIndex = 0;
            // 
            // btnPostClient
            // 
            this.btnPostClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPostClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostClient.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPostClient.Location = new System.Drawing.Point(0, 0);
            this.btnPostClient.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnPostClient.Name = "btnPostClient";
            this.btnPostClient.Size = new System.Drawing.Size(451, 44);
            this.btnPostClient.TabIndex = 0;
            this.btnPostClient.Text = "Post Client";
            this.btnPostClient.UseVisualStyleBackColor = true;
            this.btnPostClient.Click += new System.EventHandler(this.btnPostClient_Click);
            // 
            // btnDeleteSettings
            // 
            this.btnDeleteSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSettings.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteSettings.Location = new System.Drawing.Point(451, 0);
            this.btnDeleteSettings.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnDeleteSettings.Name = "btnDeleteSettings";
            this.btnDeleteSettings.Size = new System.Drawing.Size(133, 44);
            this.btnDeleteSettings.TabIndex = 34;
            this.btnDeleteSettings.Text = "Delete Settings";
            this.btnDeleteSettings.UseVisualStyleBackColor = true;
            this.btnDeleteSettings.Click += new System.EventHandler(this.btnDeleteSettings_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tabSettings);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(584, 276);
            this.mainPanel.TabIndex = 1;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.GeneralTab);
            this.tabSettings.Controls.Add(this.SpecificTab);
            this.tabSettings.Controls.Add(this.AlarmsListTab);
            this.tabSettings.Controls.Add(this.CreditsTab);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(584, 276);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Click += new System.EventHandler(this.tabSettings_Click);
            // 
            // GeneralTab
            // 
            this.GeneralTab.Controls.Add(this.txtIntervalTTSMessage);
            this.GeneralTab.Controls.Add(this.label16);
            this.GeneralTab.Controls.Add(this.btnPlaySoundIntervalTab);
            this.GeneralTab.Controls.Add(this.cbIntervalSound);
            this.GeneralTab.Controls.Add(this.label12);
            this.GeneralTab.Controls.Add(this.label9);
            this.GeneralTab.Controls.Add(this.cbAddAlarmAtStartTime);
            this.GeneralTab.Controls.Add(this.btnAddIntervalTimes);
            this.GeneralTab.Controls.Add(this.dtpStopTime);
            this.GeneralTab.Controls.Add(this.dtpStartTime);
            this.GeneralTab.Controls.Add(this.label8);
            this.GeneralTab.Controls.Add(this.label7);
            this.GeneralTab.Controls.Add(this.nudAlarmInterval);
            this.GeneralTab.Controls.Add(this.label6);
            this.GeneralTab.Controls.Add(this.label5);
            this.GeneralTab.Location = new System.Drawing.Point(4, 22);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Size = new System.Drawing.Size(576, 250);
            this.GeneralTab.TabIndex = 0;
            this.GeneralTab.Text = "Intervals";
            this.GeneralTab.UseVisualStyleBackColor = true;
            // 
            // txtIntervalTTSMessage
            // 
            this.txtIntervalTTSMessage.Location = new System.Drawing.Point(160, 163);
            this.txtIntervalTTSMessage.Multiline = true;
            this.txtIntervalTTSMessage.Name = "txtIntervalTTSMessage";
            this.txtIntervalTTSMessage.Size = new System.Drawing.Size(230, 46);
            this.txtIntervalTTSMessage.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label16.Location = new System.Drawing.Point(50, 163);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 16);
            this.label16.TabIndex = 33;
            this.label16.Text = "Text-to-Speech:";
            // 
            // btnPlaySoundIntervalTab
            // 
            this.btnPlaySoundIntervalTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaySoundIntervalTab.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPlaySoundIntervalTab.Location = new System.Drawing.Point(296, 129);
            this.btnPlaySoundIntervalTab.Name = "btnPlaySoundIntervalTab";
            this.btnPlaySoundIntervalTab.Size = new System.Drawing.Size(94, 23);
            this.btnPlaySoundIntervalTab.TabIndex = 32;
            this.btnPlaySoundIntervalTab.Text = "Play Sound";
            this.btnPlaySoundIntervalTab.UseVisualStyleBackColor = true;
            this.btnPlaySoundIntervalTab.Click += new System.EventHandler(this.btnPlaySoundIntervalTab_Click);
            // 
            // cbIntervalSound
            // 
            this.cbIntervalSound.FormattingEnabled = true;
            this.cbIntervalSound.Location = new System.Drawing.Point(159, 130);
            this.cbIntervalSound.Name = "cbIntervalSound";
            this.cbIntervalSound.Size = new System.Drawing.Size(119, 21);
            this.cbIntervalSound.TabIndex = 31;
            this.cbIntervalSound.SelectedIndexChanged += new System.EventHandler(this.cbIntervalSound_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(103, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 16);
            this.label12.TabIndex = 30;
            this.label12.Text = "Sound:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(7, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Add Alarm at Start time:";
            // 
            // cbAddAlarmAtStartTime
            // 
            this.cbAddAlarmAtStartTime.AutoSize = true;
            this.cbAddAlarmAtStartTime.Location = new System.Drawing.Point(159, 107);
            this.cbAddAlarmAtStartTime.Name = "cbAddAlarmAtStartTime";
            this.cbAddAlarmAtStartTime.Size = new System.Drawing.Size(15, 14);
            this.cbAddAlarmAtStartTime.TabIndex = 16;
            this.cbAddAlarmAtStartTime.UseVisualStyleBackColor = true;
            // 
            // btnAddIntervalTimes
            // 
            this.btnAddIntervalTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIntervalTimes.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddIntervalTimes.Location = new System.Drawing.Point(159, 215);
            this.btnAddIntervalTimes.Name = "btnAddIntervalTimes";
            this.btnAddIntervalTimes.Size = new System.Drawing.Size(94, 23);
            this.btnAddIntervalTimes.TabIndex = 15;
            this.btnAddIntervalTimes.Text = "Add Alarms";
            this.btnAddIntervalTimes.UseVisualStyleBackColor = true;
            this.btnAddIntervalTimes.Click += new System.EventHandler(this.btnAddIntervalTimes_Click);
            this.btnAddIntervalTimes.MouseEnter += new System.EventHandler(this.btnAddIntervalTimes_MouseEnter);
            // 
            // dtpStopTime
            // 
            this.dtpStopTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStopTime.Location = new System.Drawing.Point(159, 80);
            this.dtpStopTime.Name = "dtpStopTime";
            this.dtpStopTime.Size = new System.Drawing.Size(119, 20);
            this.dtpStopTime.TabIndex = 14;
            this.dtpStopTime.ValueChanged += new System.EventHandler(this.nudIntervalBasedAlarm_ValueChanged);
            this.dtpStopTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudAlarmInterval_Leave);
            this.dtpStopTime.Leave += new System.EventHandler(this.nudAlarmInterval_Leave);
            this.dtpStopTime.MouseLeave += new System.EventHandler(this.nudAlarmInterval_Leave);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(159, 56);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(119, 20);
            this.dtpStartTime.TabIndex = 13;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.nudIntervalBasedAlarm_ValueChanged);
            this.dtpStartTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudAlarmInterval_Leave);
            this.dtpStartTime.Leave += new System.EventHandler(this.nudAlarmInterval_Leave);
            this.dtpStartTime.MouseLeave += new System.EventHandler(this.nudAlarmInterval_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(80, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Stop Time:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(81, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Start Time:";
            // 
            // nudAlarmInterval
            // 
            this.nudAlarmInterval.Location = new System.Drawing.Point(159, 32);
            this.nudAlarmInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAlarmInterval.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudAlarmInterval.Name = "nudAlarmInterval";
            this.nudAlarmInterval.Size = new System.Drawing.Size(120, 20);
            this.nudAlarmInterval.TabIndex = 9;
            this.nudAlarmInterval.ValueChanged += new System.EventHandler(this.nudIntervalBasedAlarm_ValueChanged);
            this.nudAlarmInterval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudAlarmInterval_Leave);
            this.nudAlarmInterval.Leave += new System.EventHandler(this.nudAlarmInterval_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(42, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Interval (Minutes):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(8, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Add Interval-based Alarms:";
            // 
            // SpecificTab
            // 
            this.SpecificTab.Controls.Add(this.btnPlaySoundSpecificTab);
            this.SpecificTab.Controls.Add(this.cbSpecificSound);
            this.SpecificTab.Controls.Add(this.label11);
            this.SpecificTab.Controls.Add(this.label10);
            this.SpecificTab.Controls.Add(this.txtSpecificMessage);
            this.SpecificTab.Controls.Add(this.label3);
            this.SpecificTab.Controls.Add(this.btnAddSpecificAlarm);
            this.SpecificTab.Controls.Add(this.dtpSpecificAlarm);
            this.SpecificTab.Controls.Add(this.label2);
            this.SpecificTab.Location = new System.Drawing.Point(4, 22);
            this.SpecificTab.Name = "SpecificTab";
            this.SpecificTab.Size = new System.Drawing.Size(576, 250);
            this.SpecificTab.TabIndex = 4;
            this.SpecificTab.Text = "Specific";
            this.SpecificTab.UseVisualStyleBackColor = true;
            // 
            // btnPlaySoundSpecificTab
            // 
            this.btnPlaySoundSpecificTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaySoundSpecificTab.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPlaySoundSpecificTab.Location = new System.Drawing.Point(232, 111);
            this.btnPlaySoundSpecificTab.Name = "btnPlaySoundSpecificTab";
            this.btnPlaySoundSpecificTab.Size = new System.Drawing.Size(94, 23);
            this.btnPlaySoundSpecificTab.TabIndex = 44;
            this.btnPlaySoundSpecificTab.Text = "Play Sound";
            this.btnPlaySoundSpecificTab.UseVisualStyleBackColor = true;
            this.btnPlaySoundSpecificTab.Click += new System.EventHandler(this.btnPlaySoundSpecificTab_Click);
            // 
            // cbSpecificSound
            // 
            this.cbSpecificSound.FormattingEnabled = true;
            this.cbSpecificSound.Location = new System.Drawing.Point(107, 112);
            this.cbSpecificSound.Name = "cbSpecificSound";
            this.cbSpecificSound.Size = new System.Drawing.Size(119, 21);
            this.cbSpecificSound.TabIndex = 43;
            this.cbSpecificSound.SelectedIndexChanged += new System.EventHandler(this.cbSpecificSound_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(51, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 16);
            this.label11.TabIndex = 42;
            this.label11.Text = "Sound:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(8, 39);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(98, 40);
            this.label10.TabIndex = 41;
            this.label10.Text = "Text to Speech :Message";
            // 
            // txtSpecificMessage
            // 
            this.txtSpecificMessage.Location = new System.Drawing.Point(107, 39);
            this.txtSpecificMessage.Multiline = true;
            this.txtSpecificMessage.Name = "txtSpecificMessage";
            this.txtSpecificMessage.Size = new System.Drawing.Size(206, 41);
            this.txtSpecificMessage.TabIndex = 39;
            this.txtSpecificMessage.TextChanged += new System.EventHandler(this.txtSpecificMessage_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(18, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Alarm Time: ";
            // 
            // btnAddSpecificAlarm
            // 
            this.btnAddSpecificAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSpecificAlarm.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddSpecificAlarm.Location = new System.Drawing.Point(107, 139);
            this.btnAddSpecificAlarm.Name = "btnAddSpecificAlarm";
            this.btnAddSpecificAlarm.Size = new System.Drawing.Size(85, 23);
            this.btnAddSpecificAlarm.TabIndex = 35;
            this.btnAddSpecificAlarm.Text = "Add Alarm";
            this.btnAddSpecificAlarm.UseVisualStyleBackColor = true;
            this.btnAddSpecificAlarm.Click += new System.EventHandler(this.btnAddSpecificAlarm_Click);
            // 
            // dtpSpecificAlarm
            // 
            this.dtpSpecificAlarm.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSpecificAlarm.Location = new System.Drawing.Point(107, 86);
            this.dtpSpecificAlarm.Name = "dtpSpecificAlarm";
            this.dtpSpecificAlarm.Size = new System.Drawing.Size(119, 20);
            this.dtpSpecificAlarm.TabIndex = 34;
            this.dtpSpecificAlarm.ValueChanged += new System.EventHandler(this.dtpSpecificAlarm_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Add Alarm:";
            // 
            // AlarmsListTab
            // 
            this.AlarmsListTab.Controls.Add(this.lvAlarmsList);
            this.AlarmsListTab.Controls.Add(this.ButtonsPanel);
            this.AlarmsListTab.Location = new System.Drawing.Point(4, 22);
            this.AlarmsListTab.Name = "AlarmsListTab";
            this.AlarmsListTab.Size = new System.Drawing.Size(576, 250);
            this.AlarmsListTab.TabIndex = 3;
            this.AlarmsListTab.Text = "Alarms List";
            this.AlarmsListTab.UseVisualStyleBackColor = true;
            // 
            // lvAlarmsList
            // 
            this.lvAlarmsList.CheckBoxes = true;
            this.lvAlarmsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAlarmTime,
            this.chSound,
            this.chMessage,
            this.chIntervalId});
            this.lvAlarmsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAlarmsList.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lvAlarmsList.Location = new System.Drawing.Point(0, 0);
            this.lvAlarmsList.Name = "lvAlarmsList";
            this.lvAlarmsList.Size = new System.Drawing.Size(576, 216);
            this.lvAlarmsList.TabIndex = 0;
            this.lvAlarmsList.UseCompatibleStateImageBehavior = false;
            this.lvAlarmsList.View = System.Windows.Forms.View.Details;
            this.lvAlarmsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvAlarmsList_ItemCheck);
            this.lvAlarmsList.SelectedIndexChanged += new System.EventHandler(this.lvAlarmsList_SelectedIndexChanged);
            // 
            // chAlarmTime
            // 
            this.chAlarmTime.Text = "Alarm Time";
            this.chAlarmTime.Width = 142;
            // 
            // chSound
            // 
            this.chSound.Text = "Sound";
            this.chSound.Width = 95;
            // 
            // chMessage
            // 
            this.chMessage.Text = "Message (If any)";
            this.chMessage.Width = 253;
            // 
            // chIntervalId
            // 
            this.chIntervalId.Text = "Interval ID";
            this.chIntervalId.Width = 61;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.btnDeleteIntervalSet);
            this.ButtonsPanel.Controls.Add(this.btnDeleteAlarm);
            this.ButtonsPanel.Controls.Add(this.btnEditAlarm);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 216);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(576, 34);
            this.ButtonsPanel.TabIndex = 1;
            // 
            // btnDeleteIntervalSet
            // 
            this.btnDeleteIntervalSet.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteIntervalSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteIntervalSet.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteIntervalSet.Location = new System.Drawing.Point(0, 0);
            this.btnDeleteIntervalSet.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnDeleteIntervalSet.Name = "btnDeleteIntervalSet";
            this.btnDeleteIntervalSet.Size = new System.Drawing.Size(192, 34);
            this.btnDeleteIntervalSet.TabIndex = 4;
            this.btnDeleteIntervalSet.Text = "Delete Alarm Set";
            this.btnDeleteIntervalSet.UseVisualStyleBackColor = true;
            this.btnDeleteIntervalSet.Click += new System.EventHandler(this.btnDeleteIntervalSet_Click);
            // 
            // btnDeleteAlarm
            // 
            this.btnDeleteAlarm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAlarm.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteAlarm.Location = new System.Drawing.Point(192, 0);
            this.btnDeleteAlarm.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnDeleteAlarm.Name = "btnDeleteAlarm";
            this.btnDeleteAlarm.Size = new System.Drawing.Size(192, 34);
            this.btnDeleteAlarm.TabIndex = 3;
            this.btnDeleteAlarm.Text = "Delete Alarm";
            this.btnDeleteAlarm.UseVisualStyleBackColor = true;
            this.btnDeleteAlarm.Click += new System.EventHandler(this.btnDeleteAlarm_Click);
            // 
            // btnEditAlarm
            // 
            this.btnEditAlarm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAlarm.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEditAlarm.Location = new System.Drawing.Point(384, 0);
            this.btnEditAlarm.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnEditAlarm.Name = "btnEditAlarm";
            this.btnEditAlarm.Size = new System.Drawing.Size(192, 34);
            this.btnEditAlarm.TabIndex = 2;
            this.btnEditAlarm.Text = "Edit Alarm";
            this.btnEditAlarm.UseVisualStyleBackColor = true;
            this.btnEditAlarm.Click += new System.EventHandler(this.btnEditAlarm_Click);
            // 
            // CreditsTab
            // 
            this.CreditsTab.Controls.Add(this.alarmLabel);
            this.CreditsTab.Controls.Add(this.schoolBellLinkLabel);
            this.CreditsTab.Controls.Add(this.label15);
            this.CreditsTab.Controls.Add(this.label14);
            this.CreditsTab.Controls.Add(this.label13);
            this.CreditsTab.Controls.Add(this.alarmBellLinkLabel);
            this.CreditsTab.Controls.Add(this.label1);
            this.CreditsTab.Location = new System.Drawing.Point(4, 22);
            this.CreditsTab.Name = "CreditsTab";
            this.CreditsTab.Size = new System.Drawing.Size(576, 250);
            this.CreditsTab.TabIndex = 5;
            this.CreditsTab.Text = "Credits";
            this.CreditsTab.UseVisualStyleBackColor = true;
            // 
            // alarmLabel
            // 
            this.alarmLabel.AutoSize = true;
            this.alarmLabel.Location = new System.Drawing.Point(243, 21);
            this.alarmLabel.Name = "alarmLabel";
            this.alarmLabel.Size = new System.Drawing.Size(253, 13);
            this.alarmLabel.TabIndex = 6;
            this.alarmLabel.TabStop = true;
            this.alarmLabel.Text = "https://www.youtube.com/watch?v=oHwaoToqyVs";
            this.alarmLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.alarmLabel_LinkClicked);
            // 
            // schoolBellLinkLabel
            // 
            this.schoolBellLinkLabel.AutoSize = true;
            this.schoolBellLinkLabel.Location = new System.Drawing.Point(243, 47);
            this.schoolBellLinkLabel.Name = "schoolBellLinkLabel";
            this.schoolBellLinkLabel.Size = new System.Drawing.Size(262, 13);
            this.schoolBellLinkLabel.TabIndex = 5;
            this.schoolBellLinkLabel.TabStop = true;
            this.schoolBellLinkLabel.Text = "https://www.youtube.com/watch?v=3WYOdWQlXFA";
            this.schoolBellLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.schoolBellLinkLabel_LinkClicked);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "School bell sound taken from: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(240, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Analog sound taken from Daniel Simion";
            // 
            // alarmBellLinkLabel
            // 
            this.alarmBellLinkLabel.AutoSize = true;
            this.alarmBellLinkLabel.Location = new System.Drawing.Point(243, 34);
            this.alarmBellLinkLabel.Name = "alarmBellLinkLabel";
            this.alarmBellLinkLabel.Size = new System.Drawing.Size(246, 13);
            this.alarmBellLinkLabel.TabIndex = 1;
            this.alarmBellLinkLabel.TabStop = true;
            this.alarmBellLinkLabel.Text = "https://www.youtube.com/watch?v=JtKO172fB08";
            this.alarmBellLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.alarmBellLinkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alarm clock sound taken from:\r\n(Peder B. Helland) - pederbhelland.com";
            // 
            // chTime
            // 
            this.chTime.Text = "";
            // 
            // MainUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 320);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.lowerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainUi";
            this.Text = "Alarm Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.lowerPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.GeneralTab.ResumeLayout(false);
            this.GeneralTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmInterval)).EndInit();
            this.SpecificTab.ResumeLayout(false);
            this.SpecificTab.PerformLayout();
            this.AlarmsListTab.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.CreditsTab.ResumeLayout(false);
            this.CreditsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lowerPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnPostClient;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage GeneralTab;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbAddAlarmAtStartTime;
        private System.Windows.Forms.Button btnAddIntervalTimes;
        private System.Windows.Forms.DateTimePicker dtpStopTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudAlarmInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage AlarmsListTab;
        private System.Windows.Forms.ListView lvAlarmsList;
        private System.Windows.Forms.ColumnHeader chAlarmTime;
        private System.Windows.Forms.ColumnHeader chSound;
        private System.Windows.Forms.ColumnHeader chMessage;
        private System.Windows.Forms.ComboBox cbIntervalSound;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDeleteSettings;
        private System.Windows.Forms.TabPage SpecificTab;
        private System.Windows.Forms.ComboBox cbSpecificSound;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSpecificMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddSpecificAlarm;
        private System.Windows.Forms.DateTimePicker dtpSpecificAlarm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPlaySoundIntervalTab;
        private System.Windows.Forms.Button btnPlaySoundSpecificTab;
        private System.Windows.Forms.TabPage CreditsTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel alarmBellLinkLabel;
        private System.Windows.Forms.LinkLabel schoolBellLinkLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel alarmLabel;
        private System.Windows.Forms.TextBox txtIntervalTTSMessage;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ColumnHeader chIntervalId;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button btnEditAlarm;
        private System.Windows.Forms.Button btnDeleteIntervalSet;
        private System.Windows.Forms.Button btnDeleteAlarm;
    }
}
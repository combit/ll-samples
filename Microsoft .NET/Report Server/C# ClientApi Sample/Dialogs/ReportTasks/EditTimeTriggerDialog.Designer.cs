namespace ClientApiExample.Dialogs
{
    partial class EditTimeTriggerDialog
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNoInterval = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tabMinuteInterval = new System.Windows.Forms.TabPage();
            this.txtMinuteInterval = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabHourlyInterval = new System.Windows.Forms.TabPage();
            this.txtHourInterval = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabDailyInterval = new System.Windows.Forms.TabPage();
            this.txtDayInverval = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabWeeklyInterval = new System.Windows.Forms.TabPage();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWeekInterval = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabMonthlyDays = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabMonthlyDaysOfWeek = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.tabQuarterlyInterval = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabNoInterval.SuspendLayout();
            this.tabMinuteInterval.SuspendLayout();
            this.tabHourlyInterval.SuspendLayout();
            this.tabDailyInterval.SuspendLayout();
            this.tabWeeklyInterval.SuspendLayout();
            this.tabMonthlyDays.SuspendLayout();
            this.tabMonthlyDaysOfWeek.SuspendLayout();
            this.tabQuarterlyInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Name";
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(15, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(705, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartTime.Location = new System.Drawing.Point(15, 74);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(705, 22);
            this.txtStartTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Tag = "StartBoundary";
            this.label2.Text = "Start time:";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndTime.Location = new System.Drawing.Point(15, 123);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(705, 22);
            this.txtEndTime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 4;
            this.label3.Tag = "EndBoundary";
            this.label3.Text = "End time (optional):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Tag = "IntervalType";
            this.label4.Text = "Type of repetition:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNoInterval);
            this.tabControl1.Controls.Add(this.tabMinuteInterval);
            this.tabControl1.Controls.Add(this.tabHourlyInterval);
            this.tabControl1.Controls.Add(this.tabDailyInterval);
            this.tabControl1.Controls.Add(this.tabWeeklyInterval);
            this.tabControl1.Controls.Add(this.tabMonthlyDays);
            this.tabControl1.Controls.Add(this.tabMonthlyDaysOfWeek);
            this.tabControl1.Controls.Add(this.tabQuarterlyInterval);
            this.tabControl1.Location = new System.Drawing.Point(15, 184);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(705, 158);
            this.tabControl1.TabIndex = 7;
            // 
            // tabNoInterval
            // 
            this.tabNoInterval.Controls.Add(this.label5);
            this.tabNoInterval.Location = new System.Drawing.Point(4, 22);
            this.tabNoInterval.Name = "tabNoInterval";
            this.tabNoInterval.Padding = new System.Windows.Forms.Padding(3);
            this.tabNoInterval.Size = new System.Drawing.Size(697, 116);
            this.tabNoInterval.TabIndex = 0;
            this.tabNoInterval.Text = "Once";
            this.tabNoInterval.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(685, 78);
            this.label5.TabIndex = 0;
            this.label5.Text = "The scheduled report is executed once at the start time and will not be repeated." +
    " \r\nThere are no further settings to adjust.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabMinuteInterval
            // 
            this.tabMinuteInterval.Controls.Add(this.txtMinuteInterval);
            this.tabMinuteInterval.Controls.Add(this.label11);
            this.tabMinuteInterval.Location = new System.Drawing.Point(4, 22);
            this.tabMinuteInterval.Name = "tabMinuteInterval";
            this.tabMinuteInterval.Padding = new System.Windows.Forms.Padding(3);
            this.tabMinuteInterval.Size = new System.Drawing.Size(697, 116);
            this.tabMinuteInterval.TabIndex = 4;
            this.tabMinuteInterval.Text = "Every minute";
            this.tabMinuteInterval.UseVisualStyleBackColor = true;
            // 
            // txtMinuteInterval
            // 
            this.txtMinuteInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinuteInterval.Location = new System.Drawing.Point(9, 28);
            this.txtMinuteInterval.Name = "txtMinuteInterval";
            this.txtMinuteInterval.Size = new System.Drawing.Size(682, 22);
            this.txtMinuteInterval.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 13);
            this.label11.TabIndex = 6;
            this.label11.Tag = "MinuteInterval";
            this.label11.Text = "Repetition interval (minutes)";
            // 
            // tabHourlyInterval
            // 
            this.tabHourlyInterval.Controls.Add(this.txtHourInterval);
            this.tabHourlyInterval.Controls.Add(this.label10);
            this.tabHourlyInterval.Location = new System.Drawing.Point(4, 22);
            this.tabHourlyInterval.Name = "tabHourlyInterval";
            this.tabHourlyInterval.Padding = new System.Windows.Forms.Padding(3);
            this.tabHourlyInterval.Size = new System.Drawing.Size(697, 116);
            this.tabHourlyInterval.TabIndex = 5;
            this.tabHourlyInterval.Text = "Hourly";
            this.tabHourlyInterval.UseVisualStyleBackColor = true;
            // 
            // txtHourInterval
            // 
            this.txtHourInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHourInterval.Location = new System.Drawing.Point(9, 28);
            this.txtHourInterval.Name = "txtHourInterval";
            this.txtHourInterval.Size = new System.Drawing.Size(682, 22);
            this.txtHourInterval.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 13);
            this.label10.TabIndex = 6;
            this.label10.Tag = "HourInterval";
            this.label10.Text = "Repetition interval (hours):";
            // 
            // tabDailyInterval
            // 
            this.tabDailyInterval.Controls.Add(this.txtDayInverval);
            this.tabDailyInterval.Controls.Add(this.label9);
            this.tabDailyInterval.Location = new System.Drawing.Point(4, 22);
            this.tabDailyInterval.Name = "tabDailyInterval";
            this.tabDailyInterval.Padding = new System.Windows.Forms.Padding(3);
            this.tabDailyInterval.Size = new System.Drawing.Size(697, 116);
            this.tabDailyInterval.TabIndex = 1;
            this.tabDailyInterval.Text = "Daily";
            this.tabDailyInterval.UseVisualStyleBackColor = true;
            // 
            // txtDayInverval
            // 
            this.txtDayInverval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDayInverval.Location = new System.Drawing.Point(9, 28);
            this.txtDayInverval.Name = "txtDayInverval";
            this.txtDayInverval.Size = new System.Drawing.Size(682, 22);
            this.txtDayInverval.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 13);
            this.label9.TabIndex = 4;
            this.label9.Tag = "DayInterval";
            this.label9.Text = "Repetition interval (days):";
            // 
            // tabWeeklyInterval
            // 
            this.tabWeeklyInterval.Controls.Add(this.chkSunday);
            this.tabWeeklyInterval.Controls.Add(this.chkSaturday);
            this.tabWeeklyInterval.Controls.Add(this.chkFriday);
            this.tabWeeklyInterval.Controls.Add(this.chkThursday);
            this.tabWeeklyInterval.Controls.Add(this.chkWednesday);
            this.tabWeeklyInterval.Controls.Add(this.chkTuesday);
            this.tabWeeklyInterval.Controls.Add(this.chkMonday);
            this.tabWeeklyInterval.Controls.Add(this.label8);
            this.tabWeeklyInterval.Controls.Add(this.txtWeekInterval);
            this.tabWeeklyInterval.Controls.Add(this.label7);
            this.tabWeeklyInterval.Location = new System.Drawing.Point(4, 22);
            this.tabWeeklyInterval.Name = "tabWeeklyInterval";
            this.tabWeeklyInterval.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeeklyInterval.Size = new System.Drawing.Size(697, 132);
            this.tabWeeklyInterval.TabIndex = 2;
            this.tabWeeklyInterval.Text = "Weekly";
            this.tabWeeklyInterval.UseVisualStyleBackColor = true;
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Location = new System.Drawing.Point(566, 79);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(64, 17);
            this.chkSunday.TabIndex = 11;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Location = new System.Drawing.Point(472, 79);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(71, 17);
            this.chkSaturday.TabIndex = 10;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(394, 79);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(57, 17);
            this.chkFriday.TabIndex = 9;
            this.chkFriday.Text = "Friday";
            this.chkFriday.UseVisualStyleBackColor = true;
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(296, 79);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(72, 17);
            this.chkThursday.TabIndex = 8;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(191, 79);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(86, 17);
            this.chkWednesday.TabIndex = 7;
            this.chkWednesday.Text = "Wednesday";
            this.chkWednesday.UseVisualStyleBackColor = true;
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(103, 79);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(67, 17);
            this.chkTuesday.TabIndex = 6;
            this.chkTuesday.Text = "Tuesday";
            this.chkTuesday.UseVisualStyleBackColor = true;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(10, 79);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(68, 17);
            this.chkMonday.TabIndex = 5;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Only on these days of a week:";
            // 
            // txtWeekInterval
            // 
            this.txtWeekInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeekInterval.Location = new System.Drawing.Point(9, 28);
            this.txtWeekInterval.Name = "txtWeekInterval";
            this.txtWeekInterval.Size = new System.Drawing.Size(682, 22);
            this.txtWeekInterval.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 2;
            this.label7.Tag = "WeekInterval";
            this.label7.Text = "Repetition interval (weeks):";
            // 
            // tabMonthlyDays
            // 
            this.tabMonthlyDays.Controls.Add(this.label6);
            this.tabMonthlyDays.Location = new System.Drawing.Point(4, 22);
            this.tabMonthlyDays.Name = "tabMonthlyDays";
            this.tabMonthlyDays.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonthlyDays.Size = new System.Drawing.Size(697, 116);
            this.tabMonthlyDays.TabIndex = 3;
            this.tabMonthlyDays.Text = "Monthly (Days of Month)";
            this.tabMonthlyDays.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(685, 52);
            this.label6.TabIndex = 1;
            this.label6.Text = "This is not implemented in this example.\r\nSee the \'MonthlyDaysTrigger\' class. ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabMonthlyDaysOfWeek
            // 
            this.tabMonthlyDaysOfWeek.Controls.Add(this.label13);
            this.tabMonthlyDaysOfWeek.Location = new System.Drawing.Point(4, 22);
            this.tabMonthlyDaysOfWeek.Name = "tabMonthlyDaysOfWeek";
            this.tabMonthlyDaysOfWeek.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonthlyDaysOfWeek.Size = new System.Drawing.Size(697, 116);
            this.tabMonthlyDaysOfWeek.TabIndex = 7;
            this.tabMonthlyDaysOfWeek.Text = "Monthly (Weeks & Week Days)";
            this.tabMonthlyDaysOfWeek.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(685, 52);
            this.label13.TabIndex = 2;
            this.label13.Text = "This is not implemented in this example.\r\nSee the \'MonthlyWeeksAndWeekDaysTrigger" +
    "\' class. ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabQuarterlyInterval
            // 
            this.tabQuarterlyInterval.Controls.Add(this.label12);
            this.tabQuarterlyInterval.Location = new System.Drawing.Point(4, 22);
            this.tabQuarterlyInterval.Name = "tabQuarterlyInterval";
            this.tabQuarterlyInterval.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuarterlyInterval.Size = new System.Drawing.Size(697, 116);
            this.tabQuarterlyInterval.TabIndex = 6;
            this.tabQuarterlyInterval.Text = "Quarterly";
            this.tabQuarterlyInterval.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(685, 52);
            this.label12.TabIndex = 2;
            this.label12.Text = "This is not implemented in this example.\r\nSee the \'QuarterlyTrigger\' class.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(564, 366);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(645, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditTimeTriggerDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(732, 410);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTimeTriggerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Time Trigger";
            this.tabControl1.ResumeLayout(false);
            this.tabNoInterval.ResumeLayout(false);
            this.tabMinuteInterval.ResumeLayout(false);
            this.tabMinuteInterval.PerformLayout();
            this.tabHourlyInterval.ResumeLayout(false);
            this.tabHourlyInterval.PerformLayout();
            this.tabDailyInterval.ResumeLayout(false);
            this.tabDailyInterval.PerformLayout();
            this.tabWeeklyInterval.ResumeLayout(false);
            this.tabWeeklyInterval.PerformLayout();
            this.tabMonthlyDays.ResumeLayout(false);
            this.tabMonthlyDaysOfWeek.ResumeLayout(false);
            this.tabQuarterlyInterval.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNoInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabDailyInterval;
        private System.Windows.Forms.TabPage tabWeeklyInterval;
        private System.Windows.Forms.TextBox txtWeekInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDayInverval;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabMonthlyDays;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabMinuteInterval;
        private System.Windows.Forms.TabPage tabHourlyInterval;
        private System.Windows.Forms.TextBox txtMinuteInterval;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHourInterval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabQuarterlyInterval;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabMonthlyDaysOfWeek;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
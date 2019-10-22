namespace Custom_Logger_Sample
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabsLogType = new System.Windows.Forms.TabControl();
            this.tabPageListView = new System.Windows.Forms.TabPage();
            this.btnExport_LogToListView = new System.Windows.Forms.Button();
            this.chkIncludeDebugLevel = new System.Windows.Forms.CheckBox();
            this.listviewMessages = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPageNLog = new System.Windows.Forms.TabPage();
            this.btnExport_NLog = new System.Windows.Forms.Button();
            this.btnOpenLogFile_NLog = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPageLog4Net = new System.Windows.Forms.TabPage();
            this.btnOpenLogFile_Log4Net = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnExport_Log4Net = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkPrinterInfo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDataProvider = new System.Windows.Forms.CheckBox();
            this.chkLicensing = new System.Windows.Forms.CheckBox();
            this.chkNetFx = new System.Windows.Forms.CheckBox();
            this.chkNativeAPI = new System.Windows.Forms.CheckBox();
            this.chkOther = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabsLogType.SuspendLayout();
            this.tabPageListView.SuspendLayout();
            this.tabPageNLog.SuspendLayout();
            this.tabPageLog4Net.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "D:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "US:";
            // 
            // tabsLogType
            // 
            this.tabsLogType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsLogType.Controls.Add(this.tabPageListView);
            this.tabsLogType.Controls.Add(this.tabPageNLog);
            this.tabsLogType.Controls.Add(this.tabPageLog4Net);
            this.tabsLogType.Location = new System.Drawing.Point(23, 261);
            this.tabsLogType.Margin = new System.Windows.Forms.Padding(0);
            this.tabsLogType.Name = "tabsLogType";
            this.tabsLogType.SelectedIndex = 0;
            this.tabsLogType.Size = new System.Drawing.Size(875, 232);
            this.tabsLogType.TabIndex = 5;
            // 
            // tabPageListView
            // 
            this.tabPageListView.Controls.Add(this.btnExport_LogToListView);
            this.tabPageListView.Controls.Add(this.chkIncludeDebugLevel);
            this.tabPageListView.Controls.Add(this.listviewMessages);
            this.tabPageListView.Location = new System.Drawing.Point(4, 22);
            this.tabPageListView.Name = "tabPageListView";
            this.tabPageListView.Size = new System.Drawing.Size(867, 206);
            this.tabPageListView.TabIndex = 2;
            this.tabPageListView.Text = "   LogToListView   ";
            // 
            // btnExport_LogToListView
            // 
            this.btnExport_LogToListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport_LogToListView.Location = new System.Drawing.Point(6, 170);
            this.btnExport_LogToListView.Name = "btnExport_LogToListView";
            this.btnExport_LogToListView.Size = new System.Drawing.Size(95, 29);
            this.btnExport_LogToListView.TabIndex = 19;
            this.btnExport_LogToListView.Text = "Export...";
            this.btnExport_LogToListView.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // chkIncludeDebugLevel
            // 
            this.chkIncludeDebugLevel.AutoSize = true;
            this.chkIncludeDebugLevel.Checked = true;
            this.chkIncludeDebugLevel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeDebugLevel.Location = new System.Drawing.Point(0, 11);
            this.chkIncludeDebugLevel.Name = "chkIncludeDebugLevel";
            this.chkIncludeDebugLevel.Size = new System.Drawing.Size(190, 17);
            this.chkIncludeDebugLevel.TabIndex = 3;
            this.chkIncludeDebugLevel.Text = "Include messages of level \'Debug\' ";
            // 
            // listviewMessages
            // 
            this.listviewMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listviewMessages.Enabled = false;
            this.listviewMessages.FullRowSelect = true;
            this.listviewMessages.GridLines = true;
            this.listviewMessages.HideSelection = false;
            this.listviewMessages.Location = new System.Drawing.Point(0, 35);
            this.listviewMessages.Name = "listviewMessages";
            this.listviewMessages.Size = new System.Drawing.Size(864, 129);
            this.listviewMessages.SmallImageList = this.imageList1;
            this.listviewMessages.TabIndex = 2;
            this.listviewMessages.UseCompatibleStateImageBehavior = false;
            this.listviewMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Level";
            this.columnHeader1.Width = 62;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Message";
            this.columnHeader3.Width = 657;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "About.png");
            this.imageList1.Images.SetKeyName(1, "Information.png");
            this.imageList1.Images.SetKeyName(2, "Warning.png");
            this.imageList1.Images.SetKeyName(3, "Error.png");
            // 
            // tabPageNLog
            // 
            this.tabPageNLog.Controls.Add(this.btnExport_NLog);
            this.tabPageNLog.Controls.Add(this.btnOpenLogFile_NLog);
            this.tabPageNLog.Controls.Add(this.label12);
            this.tabPageNLog.Controls.Add(this.label11);
            this.tabPageNLog.Controls.Add(this.label9);
            this.tabPageNLog.Controls.Add(this.label10);
            this.tabPageNLog.Controls.Add(this.label8);
            this.tabPageNLog.Controls.Add(this.label7);
            this.tabPageNLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageNLog.Name = "tabPageNLog";
            this.tabPageNLog.Size = new System.Drawing.Size(867, 206);
            this.tabPageNLog.TabIndex = 0;
            this.tabPageNLog.Text = "   NLog Framework   ";
            // 
            // btnExport_NLog
            // 
            this.btnExport_NLog.Location = new System.Drawing.Point(6, 155);
            this.btnExport_NLog.Name = "btnExport_NLog";
            this.btnExport_NLog.Size = new System.Drawing.Size(95, 29);
            this.btnExport_NLog.TabIndex = 18;
            this.btnExport_NLog.Text = "Export...";
            this.btnExport_NLog.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnOpenLogFile_NLog
            // 
            this.btnOpenLogFile_NLog.Enabled = false;
            this.btnOpenLogFile_NLog.Location = new System.Drawing.Point(107, 155);
            this.btnOpenLogFile_NLog.Name = "btnOpenLogFile_NLog";
            this.btnOpenLogFile_NLog.Size = new System.Drawing.Size(140, 29);
            this.btnOpenLogFile_NLog.TabIndex = 17;
            this.btnOpenLogFile_NLog.Text = "Open Log File";
            this.btnOpenLogFile_NLog.Click += new System.EventHandler(this.BtnOpenLogFile_Click);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(47, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(824, 40);
            this.label12.TabIndex = 7;
            this.label12.Text = "Default: Write log messages to \'llsample_nlog.log\', begin a new log file when a s" +
    "ize of 10 MB is reached and keep the last five log files.";
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(47, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(820, 38);
            this.label11.TabIndex = 6;
            this.label11.Text = "Standard: Schreibe in die Datei \'llsample_nlog.log\', beginne bei jeweils 10 MB Da" +
    "teigröße eine neue Logdatei und behalte die jeweils letzten fünf Logdateien.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "The logging is configured in the file \'NLog.config\'.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "US:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(43, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(824, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "Das Logging erfolgt anhand der Konfiguration in der Datei \'NLog.config\'.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "D:";
            // 
            // tabPageLog4Net
            // 
            this.tabPageLog4Net.Controls.Add(this.btnOpenLogFile_Log4Net);
            this.tabPageLog4Net.Controls.Add(this.label17);
            this.tabPageLog4Net.Controls.Add(this.label18);
            this.tabPageLog4Net.Controls.Add(this.label13);
            this.tabPageLog4Net.Controls.Add(this.label14);
            this.tabPageLog4Net.Controls.Add(this.label15);
            this.tabPageLog4Net.Controls.Add(this.label16);
            this.tabPageLog4Net.Controls.Add(this.btnExport_Log4Net);
            this.tabPageLog4Net.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog4Net.Name = "tabPageLog4Net";
            this.tabPageLog4Net.Size = new System.Drawing.Size(867, 206);
            this.tabPageLog4Net.TabIndex = 1;
            this.tabPageLog4Net.Text = "   log4net Framework   ";
            // 
            // btnOpenLogFile_Log4Net
            // 
            this.btnOpenLogFile_Log4Net.Enabled = false;
            this.btnOpenLogFile_Log4Net.Location = new System.Drawing.Point(107, 155);
            this.btnOpenLogFile_Log4Net.Name = "btnOpenLogFile_Log4Net";
            this.btnOpenLogFile_Log4Net.Size = new System.Drawing.Size(140, 29);
            this.btnOpenLogFile_Log4Net.TabIndex = 22;
            this.btnOpenLogFile_Log4Net.Text = "Open Log File";
            this.btnOpenLogFile_Log4Net.Click += new System.EventHandler(this.BtnOpenLogFile_Click);
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(47, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(820, 30);
            this.label17.TabIndex = 24;
            this.label17.Text = "Default: Write log messages to \'llsample_log4net.log\', begin a new log file when " +
    "a size of 10 MB is reached and keep the last five log files.";
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(47, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(824, 38);
            this.label18.TabIndex = 23;
            this.label18.Text = "Standard: Schreibe in die Datei \'llsample_log4net.log\', beginne bei jeweils 10 MB" +
    " Dateigröße eine neue Logdatei und behalte die jeweils letzten fünf Logdateien.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(43, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(248, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "The logging is configured in the file \'log4net.config\'.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "US:";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(43, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(821, 19);
            this.label15.TabIndex = 19;
            this.label15.Text = "Das Logging erfolgt anhand der Konfiguration in der Datei \'log4net.config\'.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "D:";
            // 
            // btnExport_Log4Net
            // 
            this.btnExport_Log4Net.Location = new System.Drawing.Point(6, 155);
            this.btnExport_Log4Net.Name = "btnExport_Log4Net";
            this.btnExport_Log4Net.Size = new System.Drawing.Size(95, 29);
            this.btnExport_Log4Net.TabIndex = 8;
            this.btnExport_Log4Net.Text = "Export...";
            this.btnExport_Log4Net.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log Categories:";
            // 
            // chkPrinterInfo
            // 
            this.chkPrinterInfo.AutoSize = true;
            this.chkPrinterInfo.Location = new System.Drawing.Point(611, 182);
            this.chkPrinterInfo.Name = "chkPrinterInfo";
            this.chkPrinterInfo.Size = new System.Drawing.Size(111, 17);
            this.chkPrinterInfo.TabIndex = 7;
            this.chkPrinterInfo.Text = "Printer Information";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(70, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(828, 41);
            this.label4.TabIndex = 9;
            this.label4.Text = "Dieses Beispiel zeigt die Verwendung eines benutzerdefinierten Logging-Mechanismu" +
    "s für die Debugausgaben von List && Label mit den Frameworks NLog, log4net oder " +
    "der Ausgabe in ein ListView.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(70, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(828, 54);
            this.label5.TabIndex = 10;
            this.label5.Text = "This sample shows the usage of a user-defined logging mechanism for the debug out" +
    "puts of List && Label with the logging frameworks NLog, log4net or the logging t" +
    "o a ListView.";
            // 
            // chkDataProvider
            // 
            this.chkDataProvider.AutoSize = true;
            this.chkDataProvider.Checked = true;
            this.chkDataProvider.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataProvider.Location = new System.Drawing.Point(23, 182);
            this.chkDataProvider.Name = "chkDataProvider";
            this.chkDataProvider.Size = new System.Drawing.Size(91, 17);
            this.chkDataProvider.TabIndex = 11;
            this.chkDataProvider.Text = "Data Provider";
            // 
            // chkLicensing
            // 
            this.chkLicensing.AutoSize = true;
            this.chkLicensing.Checked = true;
            this.chkLicensing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLicensing.Location = new System.Drawing.Point(470, 182);
            this.chkLicensing.Name = "chkLicensing";
            this.chkLicensing.Size = new System.Drawing.Size(71, 17);
            this.chkLicensing.TabIndex = 12;
            this.chkLicensing.Text = "Licensing";
            // 
            // chkNetFx
            // 
            this.chkNetFx.AutoSize = true;
            this.chkNetFx.Checked = true;
            this.chkNetFx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNetFx.Location = new System.Drawing.Point(168, 182);
            this.chkNetFx.Name = "chkNetFx";
            this.chkNetFx.Size = new System.Drawing.Size(108, 17);
            this.chkNetFx.TabIndex = 13;
            this.chkNetFx.Text = ".NET Component";
            // 
            // chkNativeAPI
            // 
            this.chkNativeAPI.AutoSize = true;
            this.chkNativeAPI.Checked = true;
            this.chkNativeAPI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNativeAPI.Location = new System.Drawing.Point(343, 182);
            this.chkNativeAPI.Name = "chkNativeAPI";
            this.chkNativeAPI.Size = new System.Drawing.Size(68, 17);
            this.chkNativeAPI.TabIndex = 14;
            this.chkNativeAPI.Text = "API Calls";
            // 
            // chkOther
            // 
            this.chkOther.AutoSize = true;
            this.chkOther.Location = new System.Drawing.Point(799, 182);
            this.chkOther.Name = "chkOther";
            this.chkOther.Size = new System.Drawing.Size(52, 17);
            this.chkOther.TabIndex = 15;
            this.chkOther.Text = "Other";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Logger Type:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(914, 521);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkOther);
            this.Controls.Add(this.chkNativeAPI);
            this.Controls.Add(this.chkNetFx);
            this.Controls.Add(this.chkLicensing);
            this.Controls.Add(this.chkDataProvider);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkPrinterInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabsLogType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(930, 560);
            this.Name = "Form1";
            this.Text = "List & Label C# Custom Logger Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabsLogType.ResumeLayout(false);
            this.tabPageListView.ResumeLayout(false);
            this.tabPageListView.PerformLayout();
            this.tabPageNLog.ResumeLayout(false);
            this.tabPageNLog.PerformLayout();
            this.tabPageLog4Net.ResumeLayout(false);
            this.tabPageLog4Net.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabsLogType;
        private System.Windows.Forms.TabPage tabPageNLog;
        private System.Windows.Forms.TabPage tabPageLog4Net;
        private System.Windows.Forms.TabPage tabPageListView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkPrinterInfo;
        private System.Windows.Forms.Button btnExport_Log4Net;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDataProvider;
        private System.Windows.Forms.CheckBox chkLicensing;
        private System.Windows.Forms.CheckBox chkNetFx;
        private System.Windows.Forms.CheckBox chkNativeAPI;
        private System.Windows.Forms.CheckBox chkOther;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listviewMessages;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkIncludeDebugLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOpenLogFile_NLog;
        private System.Windows.Forms.Button btnOpenLogFile_Log4Net;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnExport_NLog;
        private System.Windows.Forms.Button btnExport_LogToListView;
    }
}

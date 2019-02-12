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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.tabsLogType = new MetroFramework.Controls.MetroTabControl();
            this.tabPageListView = new MetroFramework.Controls.MetroTabPage();
            this.chkIncludeDebugLevel = new MetroFramework.Controls.MetroCheckBox();
            this.listviewMessages = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPageNLog = new MetroFramework.Controls.MetroTabPage();
            this.btnOpenLogFile_NLog = new MetroFramework.Controls.MetroButton();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.tabPageLog4Net = new MetroFramework.Controls.MetroTabPage();
            this.btnOpenLogFile_Log4Net = new MetroFramework.Controls.MetroButton();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.chkPrinterInfo = new MetroFramework.Controls.MetroCheckBox();
            this.btnExport = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.chkDataProvider = new MetroFramework.Controls.MetroCheckBox();
            this.chkLicensing = new MetroFramework.Controls.MetroCheckBox();
            this.chkNetFx = new MetroFramework.Controls.MetroCheckBox();
            this.chkNativeAPI = new MetroFramework.Controls.MetroCheckBox();
            this.chkOther = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.tabsLogType.SuspendLayout();
            this.tabPageListView.SuspendLayout();
            this.tabPageNLog.SuspendLayout();
            this.tabPageLog4Net.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 69);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(21, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "D:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 120);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(28, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "US:";
            // 
            // tabsLogType
            // 
            this.tabsLogType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsLogType.Controls.Add(this.tabPageListView);
            this.tabsLogType.Controls.Add(this.tabPageNLog);
            this.tabsLogType.Controls.Add(this.tabPageLog4Net);
            this.tabsLogType.Location = new System.Drawing.Point(23, 299);
            this.tabsLogType.Name = "tabsLogType";
            this.tabsLogType.SelectedIndex = 0;
            this.tabsLogType.Size = new System.Drawing.Size(875, 221);
            this.tabsLogType.TabIndex = 5;
            this.tabsLogType.UseSelectable = true;
            // 
            // tabPageListView
            // 
            this.tabPageListView.Controls.Add(this.chkIncludeDebugLevel);
            this.tabPageListView.Controls.Add(this.listviewMessages);
            this.tabPageListView.HorizontalScrollbarBarColor = true;
            this.tabPageListView.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPageListView.HorizontalScrollbarSize = 10;
            this.tabPageListView.Location = new System.Drawing.Point(4, 38);
            this.tabPageListView.Name = "tabPageListView";
            this.tabPageListView.Size = new System.Drawing.Size(867, 179);
            this.tabPageListView.TabIndex = 2;
            this.tabPageListView.Text = "   LogToListView   ";
            this.tabPageListView.VerticalScrollbarBarColor = true;
            this.tabPageListView.VerticalScrollbarHighlightOnWheel = false;
            this.tabPageListView.VerticalScrollbarSize = 10;
            // 
            // chkIncludeDebugLevel
            // 
            this.chkIncludeDebugLevel.AutoSize = true;
            this.chkIncludeDebugLevel.Checked = true;
            this.chkIncludeDebugLevel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeDebugLevel.Location = new System.Drawing.Point(0, 11);
            this.chkIncludeDebugLevel.Name = "chkIncludeDebugLevel";
            this.chkIncludeDebugLevel.Size = new System.Drawing.Size(204, 15);
            this.chkIncludeDebugLevel.TabIndex = 3;
            this.chkIncludeDebugLevel.Text = "Include messages of level \'Debug\' ";
            this.chkIncludeDebugLevel.UseSelectable = true;
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
            this.listviewMessages.FullRowSelect = true;
            this.listviewMessages.GridLines = true;
            this.listviewMessages.Location = new System.Drawing.Point(0, 35);
            this.listviewMessages.Name = "listviewMessages";
            this.listviewMessages.Size = new System.Drawing.Size(864, 144);
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
            this.tabPageNLog.Controls.Add(this.btnOpenLogFile_NLog);
            this.tabPageNLog.Controls.Add(this.metroLabel12);
            this.tabPageNLog.Controls.Add(this.metroLabel11);
            this.tabPageNLog.Controls.Add(this.metroLabel9);
            this.tabPageNLog.Controls.Add(this.metroLabel10);
            this.tabPageNLog.Controls.Add(this.metroLabel8);
            this.tabPageNLog.Controls.Add(this.metroLabel7);
            this.tabPageNLog.HorizontalScrollbarBarColor = true;
            this.tabPageNLog.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPageNLog.HorizontalScrollbarSize = 10;
            this.tabPageNLog.Location = new System.Drawing.Point(4, 38);
            this.tabPageNLog.Name = "tabPageNLog";
            this.tabPageNLog.Size = new System.Drawing.Size(867, 179);
            this.tabPageNLog.TabIndex = 0;
            this.tabPageNLog.Text = "   NLog Framework   ";
            this.tabPageNLog.VerticalScrollbarBarColor = true;
            this.tabPageNLog.VerticalScrollbarHighlightOnWheel = false;
            this.tabPageNLog.VerticalScrollbarSize = 10;
            // 
            // btnOpenLogFile_NLog
            // 
            this.btnOpenLogFile_NLog.Location = new System.Drawing.Point(47, 145);
            this.btnOpenLogFile_NLog.Name = "btnOpenLogFile_NLog";
            this.btnOpenLogFile_NLog.Size = new System.Drawing.Size(140, 29);
            this.btnOpenLogFile_NLog.TabIndex = 17;
            this.btnOpenLogFile_NLog.Text = "Open Log File";
            this.btnOpenLogFile_NLog.UseSelectable = true;
            this.btnOpenLogFile_NLog.Click += new System.EventHandler(this.BtnOpenLogFile_Click);
            // 
            // metroLabel12
            // 
            this.metroLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel12.Location = new System.Drawing.Point(47, 112);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(824, 40);
            this.metroLabel12.TabIndex = 7;
            this.metroLabel12.Text = "Default: Write log messages to \'llsample_nlog.log\', begin a new log file when a s" +
    "ize of 10 MB is reached and keep the last five log files.";
            this.metroLabel12.WrapToLine = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel11.Location = new System.Drawing.Point(47, 46);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(820, 38);
            this.metroLabel11.TabIndex = 6;
            this.metroLabel11.Text = "Standard: Schreibe in die Datei \'llsample_nlog.log\', beginne bei jeweils 10 MB Da" +
    "teigröße eine neue Logdatei und behalte die jeweils letzten fünf Logdateien.";
            this.metroLabel11.WrapToLine = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(43, 84);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(299, 19);
            this.metroLabel9.TabIndex = 5;
            this.metroLabel9.Text = "The logging is configured in the file \'NLog.config\'.";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(3, 84);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(28, 19);
            this.metroLabel10.TabIndex = 4;
            this.metroLabel10.Text = "US:";
            // 
            // metroLabel8
            // 
            this.metroLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel8.Location = new System.Drawing.Point(43, 18);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(824, 19);
            this.metroLabel8.TabIndex = 3;
            this.metroLabel8.Text = "Das Logging erfolgt anhand der Konfiguration in der Datei \'NLog.config\'.";
            this.metroLabel8.WrapToLine = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(3, 18);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(21, 19);
            this.metroLabel7.TabIndex = 2;
            this.metroLabel7.Text = "D:";
            // 
            // tabPageLog4Net
            // 
            this.tabPageLog4Net.Controls.Add(this.btnOpenLogFile_Log4Net);
            this.tabPageLog4Net.Controls.Add(this.metroLabel17);
            this.tabPageLog4Net.Controls.Add(this.metroLabel18);
            this.tabPageLog4Net.Controls.Add(this.metroLabel13);
            this.tabPageLog4Net.Controls.Add(this.metroLabel14);
            this.tabPageLog4Net.Controls.Add(this.metroLabel15);
            this.tabPageLog4Net.Controls.Add(this.metroLabel16);
            this.tabPageLog4Net.HorizontalScrollbarBarColor = true;
            this.tabPageLog4Net.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPageLog4Net.HorizontalScrollbarSize = 10;
            this.tabPageLog4Net.Location = new System.Drawing.Point(4, 38);
            this.tabPageLog4Net.Name = "tabPageLog4Net";
            this.tabPageLog4Net.Size = new System.Drawing.Size(867, 179);
            this.tabPageLog4Net.TabIndex = 1;
            this.tabPageLog4Net.Text = "   log4net Framework   ";
            this.tabPageLog4Net.VerticalScrollbarBarColor = true;
            this.tabPageLog4Net.VerticalScrollbarHighlightOnWheel = false;
            this.tabPageLog4Net.VerticalScrollbarSize = 10;
            // 
            // btnOpenLogFile_Log4Net
            // 
            this.btnOpenLogFile_Log4Net.Location = new System.Drawing.Point(47, 145);
            this.btnOpenLogFile_Log4Net.Name = "btnOpenLogFile_Log4Net";
            this.btnOpenLogFile_Log4Net.Size = new System.Drawing.Size(140, 29);
            this.btnOpenLogFile_Log4Net.TabIndex = 22;
            this.btnOpenLogFile_Log4Net.Text = "Open Log File";
            this.btnOpenLogFile_Log4Net.UseSelectable = true;
            this.btnOpenLogFile_Log4Net.Click += new System.EventHandler(this.BtnOpenLogFile_Click);
            // 
            // metroLabel17
            // 
            this.metroLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel17.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel17.Location = new System.Drawing.Point(47, 112);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(820, 40);
            this.metroLabel17.TabIndex = 24;
            this.metroLabel17.Text = "Default: Write log messages to \'llsample_log4net.log\', begin a new log file when " +
    "a size of 10 MB is reached and keep the last five log files.";
            this.metroLabel17.WrapToLine = true;
            // 
            // metroLabel18
            // 
            this.metroLabel18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel18.Location = new System.Drawing.Point(47, 46);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(824, 38);
            this.metroLabel18.TabIndex = 23;
            this.metroLabel18.Text = "Standard: Schreibe in die Datei \'llsample_log4net.log\', beginne bei jeweils 10 MB" +
    " Dateigröße eine neue Logdatei und behalte die jeweils letzten fünf Logdateien.";
            this.metroLabel18.WrapToLine = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(43, 84);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(311, 19);
            this.metroLabel13.TabIndex = 21;
            this.metroLabel13.Text = "The logging is configured in the file \'log4net.config\'.";
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(3, 84);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(28, 19);
            this.metroLabel14.TabIndex = 20;
            this.metroLabel14.Text = "US:";
            // 
            // metroLabel15
            // 
            this.metroLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel15.Location = new System.Drawing.Point(43, 18);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(821, 19);
            this.metroLabel15.TabIndex = 19;
            this.metroLabel15.Text = "Das Logging erfolgt anhand der Konfiguration in der Datei \'log4net.config\'.";
            this.metroLabel15.WrapToLine = true;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.Location = new System.Drawing.Point(3, 18);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(21, 19);
            this.metroLabel16.TabIndex = 18;
            this.metroLabel16.Text = "D:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(19, 190);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(129, 25);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Log Categories:";
            // 
            // chkPrinterInfo
            // 
            this.chkPrinterInfo.AutoSize = true;
            this.chkPrinterInfo.Location = new System.Drawing.Point(611, 226);
            this.chkPrinterInfo.Name = "chkPrinterInfo";
            this.chkPrinterInfo.Size = new System.Drawing.Size(124, 15);
            this.chkPrinterInfo.TabIndex = 7;
            this.chkPrinterInfo.Text = "Printer Information";
            this.chkPrinterInfo.UseSelectable = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(799, 526);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 29);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export...";
            this.btnExport.UseSelectable = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel4.Location = new System.Drawing.Point(70, 69);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(828, 41);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Dieses Beispiel zeigt die Verwendung eines benutzerdefinierten Logging-Mechanismu" +
    "s für die Debugausgaben von List && Label mit den Frameworks NLog, log4net oder " +
    "der Ausgabe in ein ListView.";
            this.metroLabel4.WrapToLine = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel5.Location = new System.Drawing.Point(70, 120);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(828, 54);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "This sample shows the usage of a user-defined logging mechanism for the debug out" +
    "puts of List && Label with the logging frameworks NLog, log4net or the logging t" +
    "o a ListView.";
            this.metroLabel5.WrapToLine = true;
            // 
            // chkDataProvider
            // 
            this.chkDataProvider.AutoSize = true;
            this.chkDataProvider.Checked = true;
            this.chkDataProvider.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataProvider.Location = new System.Drawing.Point(23, 226);
            this.chkDataProvider.Name = "chkDataProvider";
            this.chkDataProvider.Size = new System.Drawing.Size(94, 15);
            this.chkDataProvider.TabIndex = 11;
            this.chkDataProvider.Text = "Data Provider";
            this.chkDataProvider.UseSelectable = true;
            // 
            // chkLicensing
            // 
            this.chkLicensing.AutoSize = true;
            this.chkLicensing.Checked = true;
            this.chkLicensing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLicensing.Location = new System.Drawing.Point(470, 226);
            this.chkLicensing.Name = "chkLicensing";
            this.chkLicensing.Size = new System.Drawing.Size(73, 15);
            this.chkLicensing.TabIndex = 12;
            this.chkLicensing.Text = "Licensing";
            this.chkLicensing.UseSelectable = true;
            // 
            // chkNetFx
            // 
            this.chkNetFx.AutoSize = true;
            this.chkNetFx.Checked = true;
            this.chkNetFx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNetFx.Location = new System.Drawing.Point(168, 226);
            this.chkNetFx.Name = "chkNetFx";
            this.chkNetFx.Size = new System.Drawing.Size(115, 15);
            this.chkNetFx.TabIndex = 13;
            this.chkNetFx.Text = ".NET Component";
            this.chkNetFx.UseSelectable = true;
            // 
            // chkNativeAPI
            // 
            this.chkNativeAPI.AutoSize = true;
            this.chkNativeAPI.Checked = true;
            this.chkNativeAPI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNativeAPI.Location = new System.Drawing.Point(343, 226);
            this.chkNativeAPI.Name = "chkNativeAPI";
            this.chkNativeAPI.Size = new System.Drawing.Size(69, 15);
            this.chkNativeAPI.TabIndex = 14;
            this.chkNativeAPI.Text = "API Calls";
            this.chkNativeAPI.UseSelectable = true;
            // 
            // chkOther
            // 
            this.chkOther.AutoSize = true;
            this.chkOther.Location = new System.Drawing.Point(799, 226);
            this.chkOther.Name = "chkOther";
            this.chkOther.Size = new System.Drawing.Size(53, 15);
            this.chkOther.TabIndex = 15;
            this.chkOther.Text = "Other";
            this.chkOther.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(19, 271);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(108, 25);
            this.metroLabel6.TabIndex = 16;
            this.metroLabel6.Text = "Logger Type:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 578);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.chkOther);
            this.Controls.Add(this.chkNativeAPI);
            this.Controls.Add(this.chkNetFx);
            this.Controls.Add(this.chkLicensing);
            this.Controls.Add(this.chkDataProvider);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.chkPrinterInfo);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.tabsLogType);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MinimumSize = new System.Drawing.Size(921, 578);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Blue;
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

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTabControl tabsLogType;
        private MetroFramework.Controls.MetroTabPage tabPageNLog;
        private MetroFramework.Controls.MetroTabPage tabPageLog4Net;
        private MetroFramework.Controls.MetroTabPage tabPageListView;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox chkPrinterInfo;
        private MetroFramework.Controls.MetroButton btnExport;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroCheckBox chkDataProvider;
        private MetroFramework.Controls.MetroCheckBox chkLicensing;
        private MetroFramework.Controls.MetroCheckBox chkNetFx;
        private MetroFramework.Controls.MetroCheckBox chkNativeAPI;
        private MetroFramework.Controls.MetroCheckBox chkOther;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.ListView listviewMessages;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private MetroFramework.Controls.MetroCheckBox chkIncludeDebugLevel;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroButton btnOpenLogFile_NLog;
        private MetroFramework.Controls.MetroButton btnOpenLogFile_Log4Net;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroLabel metroLabel18;
    }
}


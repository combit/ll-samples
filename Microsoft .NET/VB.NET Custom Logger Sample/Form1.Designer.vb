'<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Namespace Custom_Logger_Sample
Partial Class Form1

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.metroLabel17 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel13 = New MetroFramework.Controls.MetroLabel()
        Me.btnOpenLogFile_NLog = New MetroFramework.Controls.MetroButton()
        Me.metroLabel12 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel11 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel9 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel10 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel8 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel18 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel14 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel15 = New MetroFramework.Controls.MetroLabel()
        Me.chkNativeAPI = New MetroFramework.Controls.MetroCheckBox()
        Me.chkNetFx = New MetroFramework.Controls.MetroCheckBox()
        Me.chkLicensing = New MetroFramework.Controls.MetroCheckBox()
        Me.chkDataProvider = New MetroFramework.Controls.MetroCheckBox()
        Me.metroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.btnExport = New MetroFramework.Controls.MetroButton()
        Me.chkPrinterInfo = New MetroFramework.Controls.MetroCheckBox()
        Me.metroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel16 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel6 = New MetroFramework.Controls.MetroLabel()
        Me.metroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.tabPageLog4Net = New MetroFramework.Controls.MetroTabPage()
        Me.btnOpenLogFile_Log4Net = New MetroFramework.Controls.MetroButton()
        Me.chkOther = New MetroFramework.Controls.MetroCheckBox()
        Me.tabPageNLog = New MetroFramework.Controls.MetroTabPage()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.chkIncludeDebugLevel = New MetroFramework.Controls.MetroCheckBox()
            Me.listviewMessages = New System.Windows.Forms.ListView()
            Me.tabPageListView = New MetroFramework.Controls.MetroTabPage()
            Me.tabsLogType = New MetroFramework.Controls.MetroTabControl()
            Me.metroLabel2 = New MetroFramework.Controls.MetroLabel()
            Me.metroLabel1 = New MetroFramework.Controls.MetroLabel()
            Me.metroLabel5 = New MetroFramework.Controls.MetroLabel()
            Me.tabPageLog4Net.SuspendLayout()
            Me.tabPageNLog.SuspendLayout()
            Me.tabPageListView.SuspendLayout()
            Me.tabsLogType.SuspendLayout()
            Me.SuspendLayout()
            '
            'metroLabel17
            '
            Me.metroLabel17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.metroLabel17.FontSize = MetroFramework.MetroLabelSize.Small
            Me.metroLabel17.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.metroLabel17.Location = New System.Drawing.Point(47, 112)
            Me.metroLabel17.Name = "metroLabel17"
            Me.metroLabel17.Size = New System.Drawing.Size(820, 40)
            Me.metroLabel17.TabIndex = 24
            Me.metroLabel17.Text = "Default: Write log messages to 'llsample_log4net.log', begin a new log file when " & _
        "a size of 10 MB is reached and keep the last five log files."
            Me.metroLabel17.WrapToLine = True
            '
            'metroLabel13
            '
            Me.metroLabel13.AutoSize = True
            Me.metroLabel13.Location = New System.Drawing.Point(43, 84)
            Me.metroLabel13.Name = "metroLabel13"
            Me.metroLabel13.Size = New System.Drawing.Size(311, 19)
            Me.metroLabel13.TabIndex = 21
            Me.metroLabel13.Text = "The logging is configured in the file 'log4net.config'."
            '
            'btnOpenLogFile_NLog
            '
            Me.btnOpenLogFile_NLog.Location = New System.Drawing.Point(47, 145)
            Me.btnOpenLogFile_NLog.Name = "btnOpenLogFile_NLog"
            Me.btnOpenLogFile_NLog.Size = New System.Drawing.Size(140, 29)
            Me.btnOpenLogFile_NLog.TabIndex = 17
            Me.btnOpenLogFile_NLog.Text = "Open Log File"
            Me.btnOpenLogFile_NLog.UseSelectable = True
            '
            'metroLabel12
            '
            Me.metroLabel12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Small
            Me.metroLabel12.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.metroLabel12.Location = New System.Drawing.Point(47, 112)
            Me.metroLabel12.Name = "metroLabel12"
            Me.metroLabel12.Size = New System.Drawing.Size(824, 40)
            Me.metroLabel12.TabIndex = 7
            Me.metroLabel12.Text = "Default: Write log messages to 'llsample_nlog.log', begin a new log file when a s" & _
        "ize of 10 MB is reached and keep the last five log files."
            Me.metroLabel12.WrapToLine = True
            '
            'metroLabel11
            '
            Me.metroLabel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Small
            Me.metroLabel11.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.metroLabel11.Location = New System.Drawing.Point(47, 46)
            Me.metroLabel11.Name = "metroLabel11"
            Me.metroLabel11.Size = New System.Drawing.Size(820, 38)
            Me.metroLabel11.TabIndex = 6
            Me.metroLabel11.Text = "Standard: Schreibe in die Datei 'llsample_nlog.log', beginne bei jeweils 10 MB Da" & _
        "teigröße eine neue Logdatei und behalte die jeweils letzten fünf Logdateien."
            Me.metroLabel11.WrapToLine = True
            '
            'metroLabel9
            '
            Me.metroLabel9.AutoSize = True
            Me.metroLabel9.Location = New System.Drawing.Point(43, 84)
            Me.metroLabel9.Name = "metroLabel9"
            Me.metroLabel9.Size = New System.Drawing.Size(299, 19)
            Me.metroLabel9.TabIndex = 5
            Me.metroLabel9.Text = "The logging is configured in the file 'NLog.config'."
            '
            'metroLabel10
            '
            Me.metroLabel10.AutoSize = True
            Me.metroLabel10.Location = New System.Drawing.Point(3, 84)
            Me.metroLabel10.Name = "metroLabel10"
            Me.metroLabel10.Size = New System.Drawing.Size(28, 19)
            Me.metroLabel10.TabIndex = 4
            Me.metroLabel10.Text = "US:"
            '
            'metroLabel8
            '
            Me.metroLabel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.metroLabel8.Location = New System.Drawing.Point(43, 18)
            Me.metroLabel8.Name = "metroLabel8"
            Me.metroLabel8.Size = New System.Drawing.Size(824, 19)
            Me.metroLabel8.TabIndex = 3
            Me.metroLabel8.Text = "Das Logging erfolgt anhand der Konfiguration in der Datei 'NLog.config'."
            Me.metroLabel8.WrapToLine = True
            '
            'metroLabel18
            '
            Me.metroLabel18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Small
            Me.metroLabel18.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.metroLabel18.Location = New System.Drawing.Point(47, 46)
            Me.metroLabel18.Name = "metroLabel18"
            Me.metroLabel18.Size = New System.Drawing.Size(824, 38)
            Me.metroLabel18.TabIndex = 23
            Me.metroLabel18.Text = "Standard: Schreibe in die Datei 'llsample_log4net.log', beginne bei jeweils 10 MB" & _
        " Dateigröße eine neue Logdatei und behalte die jeweils letzten fünf Logdateien."
            Me.metroLabel18.WrapToLine = True
            '
            'metroLabel14
            '
            Me.metroLabel14.AutoSize = True
            Me.metroLabel14.Location = New System.Drawing.Point(3, 84)
            Me.metroLabel14.Name = "metroLabel14"
            Me.metroLabel14.Size = New System.Drawing.Size(28, 19)
            Me.metroLabel14.TabIndex = 20
            Me.metroLabel14.Text = "US:"
            '
            'metroLabel15
            '
            Me.metroLabel15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.metroLabel15.Location = New System.Drawing.Point(43, 18)
            Me.metroLabel15.Name = "metroLabel15"
            Me.metroLabel15.Size = New System.Drawing.Size(821, 19)
            Me.metroLabel15.TabIndex = 19
            Me.metroLabel15.Text = "Das Logging erfolgt anhand der Konfiguration in der Datei 'log4net.config'."
            Me.metroLabel15.WrapToLine = True
            '
            'chkNativeAPI
            '
            Me.chkNativeAPI.AutoSize = True
            Me.chkNativeAPI.Checked = True
            Me.chkNativeAPI.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkNativeAPI.Location = New System.Drawing.Point(345, 203)
            Me.chkNativeAPI.Name = "chkNativeAPI"
            Me.chkNativeAPI.Size = New System.Drawing.Size(69, 15)
            Me.chkNativeAPI.TabIndex = 28
            Me.chkNativeAPI.Text = "API Calls"
            Me.chkNativeAPI.UseSelectable = True
            '
            'chkNetFx
            '
            Me.chkNetFx.AutoSize = True
            Me.chkNetFx.Checked = True
            Me.chkNetFx.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkNetFx.Location = New System.Drawing.Point(170, 203)
            Me.chkNetFx.Name = "chkNetFx"
            Me.chkNetFx.Size = New System.Drawing.Size(115, 15)
            Me.chkNetFx.TabIndex = 27
            Me.chkNetFx.Text = ".NET Component"
            Me.chkNetFx.UseSelectable = True
            '
            'chkLicensing
            '
            Me.chkLicensing.AutoSize = True
            Me.chkLicensing.Checked = True
            Me.chkLicensing.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkLicensing.Location = New System.Drawing.Point(472, 203)
            Me.chkLicensing.Name = "chkLicensing"
            Me.chkLicensing.Size = New System.Drawing.Size(73, 15)
            Me.chkLicensing.TabIndex = 26
            Me.chkLicensing.Text = "Licensing"
            Me.chkLicensing.UseSelectable = True
            '
            'chkDataProvider
            '
            Me.chkDataProvider.AutoSize = True
            Me.chkDataProvider.Checked = True
            Me.chkDataProvider.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkDataProvider.Location = New System.Drawing.Point(25, 203)
            Me.chkDataProvider.Name = "chkDataProvider"
            Me.chkDataProvider.Size = New System.Drawing.Size(94, 15)
            Me.chkDataProvider.TabIndex = 25
            Me.chkDataProvider.Text = "Data Provider"
            Me.chkDataProvider.UseSelectable = True
            '
            'metroLabel4
            '
            Me.metroLabel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.metroLabel4.Location = New System.Drawing.Point(72, 62)
            Me.metroLabel4.Name = "metroLabel4"
            Me.metroLabel4.Size = New System.Drawing.Size(828, 41)
            Me.metroLabel4.TabIndex = 23
            Me.metroLabel4.Text = "Dieses Beispiel zeigt die Verwendung eines benutzerdefinierten Logging-Mechanismu" & _
        "s für die Debugausgaben von List && Label mit den Frameworks NLog, log4net oder " & _
        "der Ausgabe in ein ListView."
            Me.metroLabel4.WrapToLine = True
            '
            'btnExport
            '
            Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnExport.Location = New System.Drawing.Point(801, 503)
            Me.btnExport.Name = "btnExport"
            Me.btnExport.Size = New System.Drawing.Size(95, 29)
            Me.btnExport.TabIndex = 22
            Me.btnExport.Text = "Export..."
            Me.btnExport.UseSelectable = True
            '
            'chkPrinterInfo
            '
            Me.chkPrinterInfo.AutoSize = True
            Me.chkPrinterInfo.Location = New System.Drawing.Point(613, 203)
            Me.chkPrinterInfo.Name = "chkPrinterInfo"
            Me.chkPrinterInfo.Size = New System.Drawing.Size(124, 15)
            Me.chkPrinterInfo.TabIndex = 21
            Me.chkPrinterInfo.Text = "Printer Information"
            Me.chkPrinterInfo.UseSelectable = True
            '
            'metroLabel3
            '
            Me.metroLabel3.AutoSize = True
            Me.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall
            Me.metroLabel3.Location = New System.Drawing.Point(21, 167)
            Me.metroLabel3.Name = "metroLabel3"
            Me.metroLabel3.Size = New System.Drawing.Size(129, 25)
            Me.metroLabel3.TabIndex = 20
            Me.metroLabel3.Text = "Log Categories:"
            '
            'metroLabel16
            '
            Me.metroLabel16.AutoSize = True
            Me.metroLabel16.Location = New System.Drawing.Point(3, 18)
            Me.metroLabel16.Name = "metroLabel16"
            Me.metroLabel16.Size = New System.Drawing.Size(21, 19)
            Me.metroLabel16.TabIndex = 18
            Me.metroLabel16.Text = "D:"
            '
            'metroLabel6
            '
            Me.metroLabel6.AutoSize = True
            Me.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall
            Me.metroLabel6.Location = New System.Drawing.Point(21, 248)
            Me.metroLabel6.Name = "metroLabel6"
            Me.metroLabel6.Size = New System.Drawing.Size(108, 25)
            Me.metroLabel6.TabIndex = 30
            Me.metroLabel6.Text = "Logger Type:"
            '
            'metroLabel7
            '
            Me.metroLabel7.AutoSize = True
            Me.metroLabel7.Location = New System.Drawing.Point(3, 18)
            Me.metroLabel7.Name = "metroLabel7"
            Me.metroLabel7.Size = New System.Drawing.Size(21, 19)
            Me.metroLabel7.TabIndex = 2
            Me.metroLabel7.Text = "D:"
            '
            'tabPageLog4Net
            '
            Me.tabPageLog4Net.Controls.Add(Me.btnOpenLogFile_Log4Net)
            Me.tabPageLog4Net.Controls.Add(Me.metroLabel17)
            Me.tabPageLog4Net.Controls.Add(Me.metroLabel18)
            Me.tabPageLog4Net.Controls.Add(Me.metroLabel13)
            Me.tabPageLog4Net.Controls.Add(Me.metroLabel14)
            Me.tabPageLog4Net.Controls.Add(Me.metroLabel15)
            Me.tabPageLog4Net.Controls.Add(Me.metroLabel16)
            Me.tabPageLog4Net.HorizontalScrollbarBarColor = True
            Me.tabPageLog4Net.HorizontalScrollbarHighlightOnWheel = False
            Me.tabPageLog4Net.HorizontalScrollbarSize = 10
            Me.tabPageLog4Net.Location = New System.Drawing.Point(4, 38)
            Me.tabPageLog4Net.Name = "tabPageLog4Net"
            Me.tabPageLog4Net.Size = New System.Drawing.Size(867, 179)
            Me.tabPageLog4Net.TabIndex = 1
            Me.tabPageLog4Net.Text = "   log4net Framework   "
            Me.tabPageLog4Net.VerticalScrollbarBarColor = True
            Me.tabPageLog4Net.VerticalScrollbarHighlightOnWheel = False
            Me.tabPageLog4Net.VerticalScrollbarSize = 10
            '
            'btnOpenLogFile_Log4Net
            '
            Me.btnOpenLogFile_Log4Net.Location = New System.Drawing.Point(47, 145)
            Me.btnOpenLogFile_Log4Net.Name = "btnOpenLogFile_Log4Net"
            Me.btnOpenLogFile_Log4Net.Size = New System.Drawing.Size(140, 29)
            Me.btnOpenLogFile_Log4Net.TabIndex = 22
            Me.btnOpenLogFile_Log4Net.Text = "Open Log File"
            Me.btnOpenLogFile_Log4Net.UseSelectable = True
            '
            'chkOther
            '
            Me.chkOther.AutoSize = True
            Me.chkOther.Location = New System.Drawing.Point(801, 203)
            Me.chkOther.Name = "chkOther"
            Me.chkOther.Size = New System.Drawing.Size(53, 15)
            Me.chkOther.TabIndex = 29
            Me.chkOther.Text = "Other"
            Me.chkOther.UseSelectable = True
            '
            'tabPageNLog
            '
            Me.tabPageNLog.Controls.Add(Me.btnOpenLogFile_NLog)
            Me.tabPageNLog.Controls.Add(Me.metroLabel12)
            Me.tabPageNLog.Controls.Add(Me.metroLabel11)
            Me.tabPageNLog.Controls.Add(Me.metroLabel9)
            Me.tabPageNLog.Controls.Add(Me.metroLabel10)
            Me.tabPageNLog.Controls.Add(Me.metroLabel8)
            Me.tabPageNLog.Controls.Add(Me.metroLabel7)
            Me.tabPageNLog.HorizontalScrollbarBarColor = True
            Me.tabPageNLog.HorizontalScrollbarHighlightOnWheel = False
            Me.tabPageNLog.HorizontalScrollbarSize = 10
            Me.tabPageNLog.Location = New System.Drawing.Point(4, 38)
            Me.tabPageNLog.Name = "tabPageNLog"
            Me.tabPageNLog.Size = New System.Drawing.Size(867, 179)
            Me.tabPageNLog.TabIndex = 0
            Me.tabPageNLog.Text = "   NLog Framework   "
            Me.tabPageNLog.VerticalScrollbarBarColor = True
            Me.tabPageNLog.VerticalScrollbarHighlightOnWheel = False
            Me.tabPageNLog.VerticalScrollbarSize = 10
            '
            'imageList1
            '
            Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
            Me.imageList1.Images.SetKeyName(0, "About.png")
            Me.imageList1.Images.SetKeyName(1, "Information.png")
            Me.imageList1.Images.SetKeyName(2, "Warning.png")
            Me.imageList1.Images.SetKeyName(3, "Error.png")
            '
            'columnHeader3
            '
            Me.columnHeader3.Text = "Message"
            Me.columnHeader3.Width = 657
            '
            'columnHeader2
            '
            Me.columnHeader2.Text = "Category"
            Me.columnHeader2.Width = 96
            '
            'columnHeader1
            '
            Me.columnHeader1.Text = "Level"
            Me.columnHeader1.Width = 62
            '
            'chkIncludeDebugLevel
            '
            Me.chkIncludeDebugLevel.AutoSize = True
            Me.chkIncludeDebugLevel.Checked = True
            Me.chkIncludeDebugLevel.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkIncludeDebugLevel.Location = New System.Drawing.Point(0, 11)
            Me.chkIncludeDebugLevel.Name = "chkIncludeDebugLevel"
            Me.chkIncludeDebugLevel.Size = New System.Drawing.Size(204, 15)
            Me.chkIncludeDebugLevel.TabIndex = 3
            Me.chkIncludeDebugLevel.Text = "Include messages of level 'Debug' "
            Me.chkIncludeDebugLevel.UseSelectable = True
            '
            'listviewMessages
            '
            Me.listviewMessages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.listviewMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3})
            Me.listviewMessages.FullRowSelect = True
            Me.listviewMessages.GridLines = True
            Me.listviewMessages.Location = New System.Drawing.Point(0, 35)
            Me.listviewMessages.Name = "listviewMessages"
            Me.listviewMessages.Size = New System.Drawing.Size(864, 144)
            Me.listviewMessages.SmallImageList = Me.imageList1
            Me.listviewMessages.TabIndex = 2
            Me.listviewMessages.UseCompatibleStateImageBehavior = False
            Me.listviewMessages.View = System.Windows.Forms.View.Details
            '
            'tabPageListView
            '
            Me.tabPageListView.Controls.Add(Me.chkIncludeDebugLevel)
            Me.tabPageListView.Controls.Add(Me.listviewMessages)
            Me.tabPageListView.HorizontalScrollbarBarColor = True
            Me.tabPageListView.HorizontalScrollbarHighlightOnWheel = False
            Me.tabPageListView.HorizontalScrollbarSize = 10
            Me.tabPageListView.Location = New System.Drawing.Point(4, 38)
            Me.tabPageListView.Name = "tabPageListView"
            Me.tabPageListView.Size = New System.Drawing.Size(867, 179)
            Me.tabPageListView.TabIndex = 2
            Me.tabPageListView.Text = "   LogToListView   "
            Me.tabPageListView.VerticalScrollbarBarColor = True
            Me.tabPageListView.VerticalScrollbarHighlightOnWheel = False
            Me.tabPageListView.VerticalScrollbarSize = 10
            '
            'tabsLogType
            '
            Me.tabsLogType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tabsLogType.Controls.Add(Me.tabPageListView)
            Me.tabsLogType.Controls.Add(Me.tabPageNLog)
            Me.tabsLogType.Controls.Add(Me.tabPageLog4Net)
            Me.tabsLogType.Location = New System.Drawing.Point(25, 276)
            Me.tabsLogType.Name = "tabsLogType"
            Me.tabsLogType.SelectedIndex = 0
            Me.tabsLogType.Size = New System.Drawing.Size(875, 221)
            Me.tabsLogType.TabIndex = 19
            Me.tabsLogType.UseSelectable = True
            '
            'metroLabel2
            '
            Me.metroLabel2.AutoSize = True
            Me.metroLabel2.Location = New System.Drawing.Point(25, 113)
            Me.metroLabel2.Name = "metroLabel2"
            Me.metroLabel2.Size = New System.Drawing.Size(28, 19)
            Me.metroLabel2.TabIndex = 18
            Me.metroLabel2.Text = "US:"
            '
            'metroLabel1
            '
            Me.metroLabel1.AutoSize = True
            Me.metroLabel1.Location = New System.Drawing.Point(25, 62)
            Me.metroLabel1.Name = "metroLabel1"
            Me.metroLabel1.Size = New System.Drawing.Size(21, 19)
            Me.metroLabel1.TabIndex = 17
            Me.metroLabel1.Text = "D:"
            '
            'metroLabel5
            '
            Me.metroLabel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.metroLabel5.Location = New System.Drawing.Point(72, 113)
            Me.metroLabel5.Name = "metroLabel5"
            Me.metroLabel5.Size = New System.Drawing.Size(828, 54)
            Me.metroLabel5.TabIndex = 24
            Me.metroLabel5.Text = "This sample shows the usage of a user-defined logging mechanism for the debug out" & _
        "puts of List && Label with the logging frameworks NLog, log4net or the logging t" & _
        "o a ListView."
            Me.metroLabel5.WrapToLine = True
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(921, 578)
            Me.Controls.Add(Me.chkNativeAPI)
            Me.Controls.Add(Me.chkNetFx)
            Me.Controls.Add(Me.chkLicensing)
            Me.Controls.Add(Me.chkDataProvider)
            Me.Controls.Add(Me.metroLabel4)
            Me.Controls.Add(Me.btnExport)
            Me.Controls.Add(Me.chkPrinterInfo)
            Me.Controls.Add(Me.metroLabel3)
            Me.Controls.Add(Me.metroLabel6)
            Me.Controls.Add(Me.chkOther)
            Me.Controls.Add(Me.tabsLogType)
            Me.Controls.Add(Me.metroLabel2)
            Me.Controls.Add(Me.metroLabel1)
            Me.Controls.Add(Me.metroLabel5)
            Me.MinimumSize = New System.Drawing.Size(921, 578)
            Me.Name = "Form1"
            Me.Text = "List & Label VB.NET Custom Logger Sample"
            Me.tabPageLog4Net.ResumeLayout(False)
            Me.tabPageLog4Net.PerformLayout()
            Me.tabPageNLog.ResumeLayout(False)
            Me.tabPageNLog.PerformLayout()
            Me.tabPageListView.ResumeLayout(False)
            Me.tabPageListView.PerformLayout()
            Me.tabsLogType.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    Private WithEvents metroLabel17 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel13 As MetroFramework.Controls.MetroLabel
    Private WithEvents btnOpenLogFile_NLog As MetroFramework.Controls.MetroButton
    Private WithEvents metroLabel12 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel11 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel9 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel10 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel8 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel18 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel14 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel15 As MetroFramework.Controls.MetroLabel
    Private WithEvents chkNativeAPI As MetroFramework.Controls.MetroCheckBox
    Private WithEvents chkNetFx As MetroFramework.Controls.MetroCheckBox
    Private WithEvents chkLicensing As MetroFramework.Controls.MetroCheckBox
    Private WithEvents chkDataProvider As MetroFramework.Controls.MetroCheckBox
    Private WithEvents metroLabel4 As MetroFramework.Controls.MetroLabel
    Private WithEvents btnExport As MetroFramework.Controls.MetroButton
    Private WithEvents chkPrinterInfo As MetroFramework.Controls.MetroCheckBox
    Private WithEvents metroLabel3 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel16 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel6 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel7 As MetroFramework.Controls.MetroLabel
    Private WithEvents tabPageLog4Net As MetroFramework.Controls.MetroTabPage
    Private WithEvents btnOpenLogFile_Log4Net As MetroFramework.Controls.MetroButton
    Private WithEvents chkOther As MetroFramework.Controls.MetroCheckBox
    Private WithEvents tabPageNLog As MetroFramework.Controls.MetroTabPage
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents chkIncludeDebugLevel As MetroFramework.Controls.MetroCheckBox
    Private WithEvents listviewMessages As System.Windows.Forms.ListView
    Private WithEvents tabPageListView As MetroFramework.Controls.MetroTabPage
    Private WithEvents tabsLogType As MetroFramework.Controls.MetroTabControl
    Private WithEvents metroLabel2 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel1 As MetroFramework.Controls.MetroLabel
    Private WithEvents metroLabel5 As MetroFramework.Controls.MetroLabel

    End Class
End Namespace

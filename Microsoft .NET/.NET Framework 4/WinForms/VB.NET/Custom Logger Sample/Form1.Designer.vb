'<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Namespace Custom_Logger_Sample
    Partial Class Form1
        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
            Me.label17 = New System.Windows.Forms.Label()
            Me.label13 = New System.Windows.Forms.Label()
            Me.btnOpenLogFile_NLog = New System.Windows.Forms.Button()
            Me.label12 = New System.Windows.Forms.Label()
            Me.label11 = New System.Windows.Forms.Label()
            Me.label9 = New System.Windows.Forms.Label()
            Me.label10 = New System.Windows.Forms.Label()
            Me.label8 = New System.Windows.Forms.Label()
            Me.label18 = New System.Windows.Forms.Label()
            Me.label14 = New System.Windows.Forms.Label()
            Me.label15 = New System.Windows.Forms.Label()
            Me.chkNativeAPI = New System.Windows.Forms.CheckBox()
            Me.chkNetFx = New System.Windows.Forms.CheckBox()
            Me.chkLicensing = New System.Windows.Forms.CheckBox()
            Me.chkDataProvider = New System.Windows.Forms.CheckBox()
            Me.label4 = New System.Windows.Forms.Label()
            Me.btnExport_NLog = New System.Windows.Forms.Button()
            Me.chkPrinterInfo = New System.Windows.Forms.CheckBox()
            Me.label3 = New System.Windows.Forms.Label()
            Me.label16 = New System.Windows.Forms.Label()
            Me.label6 = New System.Windows.Forms.Label()
            Me.label7 = New System.Windows.Forms.Label()
            Me.tabPageLog4Net = New System.Windows.Forms.TabPage()
            Me.btnExport_Log4Net = New System.Windows.Forms.Button()
            Me.btnOpenLogFile_Log4Net = New System.Windows.Forms.Button()
            Me.chkOther = New System.Windows.Forms.CheckBox()
            Me.tabPageNLog = New System.Windows.Forms.TabPage()
            Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.chkIncludeDebugLevel = New System.Windows.Forms.CheckBox()
            Me.listviewMessages = New System.Windows.Forms.ListView()
            Me.tabPageListView = New System.Windows.Forms.TabPage()
            Me.btnExport_LogToListView = New System.Windows.Forms.Button()
            Me.tabsLogType = New System.Windows.Forms.TabControl()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label5 = New System.Windows.Forms.Label()
            Me.tabPageLog4Net.SuspendLayout()
            Me.tabPageNLog.SuspendLayout()
            Me.tabPageListView.SuspendLayout()
            Me.tabsLogType.SuspendLayout()
            Me.SuspendLayout()
            '
            'label17
            '
            Me.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.label17.Location = New System.Drawing.Point(47, 112)
            Me.label17.Name = "label17"
            Me.label17.Size = New System.Drawing.Size(820, 40)
            Me.label17.TabIndex = 24
            Me.label17.Text = "Default: Write log messages to 'llsample_log4net.log', begin a new log file when " &
    "a size of 10 MB is reached and keep the last five log files."
            '
            'label13
            '
            Me.label13.AutoSize = True
            Me.label13.Location = New System.Drawing.Point(43, 84)
            Me.label13.Name = "label13"
            Me.label13.Size = New System.Drawing.Size(248, 13)
            Me.label13.TabIndex = 21
            Me.label13.Text = "The logging is configured in the file 'log4net.config'."
            '
            'btnOpenLogFile_NLog
            '
            Me.btnOpenLogFile_NLog.Enabled = False
            Me.btnOpenLogFile_NLog.Location = New System.Drawing.Point(107, 155)
            Me.btnOpenLogFile_NLog.Name = "btnOpenLogFile_NLog"
            Me.btnOpenLogFile_NLog.Size = New System.Drawing.Size(140, 29)
            Me.btnOpenLogFile_NLog.TabIndex = 17
            Me.btnOpenLogFile_NLog.Text = "Open Log File"
            '
            'label12
            '
            Me.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.label12.Location = New System.Drawing.Point(47, 112)
            Me.label12.Name = "label12"
            Me.label12.Size = New System.Drawing.Size(824, 30)
            Me.label12.TabIndex = 7
            Me.label12.Text = "Default: Write log messages to 'llsample_nlog.log', begin a new log file when a s" &
    "ize of 10 MB is reached and keep the last five log files."
            '
            'label11
            '
            Me.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.label11.Location = New System.Drawing.Point(47, 46)
            Me.label11.Name = "label11"
            Me.label11.Size = New System.Drawing.Size(820, 38)
            Me.label11.TabIndex = 6
            Me.label11.Text = "Standard: Schreibe in die Datei 'llsample_nlog.log', beginne bei jeweils 10 MB Da" &
    "teigröße eine neue Logdatei und behalte die jeweils letzten fünf Logdateien."
            '
            'label9
            '
            Me.label9.AutoSize = True
            Me.label9.Location = New System.Drawing.Point(43, 84)
            Me.label9.Name = "label9"
            Me.label9.Size = New System.Drawing.Size(239, 13)
            Me.label9.TabIndex = 5
            Me.label9.Text = "The logging is configured in the file 'NLog.config'."
            '
            'label10
            '
            Me.label10.AutoSize = True
            Me.label10.Location = New System.Drawing.Point(3, 84)
            Me.label10.Name = "label10"
            Me.label10.Size = New System.Drawing.Size(25, 13)
            Me.label10.TabIndex = 4
            Me.label10.Text = "US:"
            '
            'label8
            '
            Me.label8.Location = New System.Drawing.Point(43, 18)
            Me.label8.Name = "label8"
            Me.label8.Size = New System.Drawing.Size(824, 19)
            Me.label8.TabIndex = 3
            Me.label8.Text = "Das Logging erfolgt anhand der Konfiguration in der Datei 'NLog.config'."
            '
            'label18
            '
            Me.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.label18.Location = New System.Drawing.Point(47, 46)
            Me.label18.Name = "label18"
            Me.label18.Size = New System.Drawing.Size(824, 38)
            Me.label18.TabIndex = 23
            Me.label18.Text = "Standard: Schreibe in die Datei 'llsample_log4net.log', beginne bei jeweils 10 MB" &
    " Dateigröße eine neue Logdatei und behalte die jeweils letzten fünf Logdateien."
            '
            'label14
            '
            Me.label14.AutoSize = True
            Me.label14.Location = New System.Drawing.Point(3, 84)
            Me.label14.Name = "label14"
            Me.label14.Size = New System.Drawing.Size(25, 13)
            Me.label14.TabIndex = 20
            Me.label14.Text = "US:"
            '
            'label15
            '
            Me.label15.Location = New System.Drawing.Point(43, 18)
            Me.label15.Name = "label15"
            Me.label15.Size = New System.Drawing.Size(821, 19)
            Me.label15.TabIndex = 19
            Me.label15.Text = "Das Logging erfolgt anhand der Konfiguration in der Datei 'log4net.config'."
            '
            'chkNativeAPI
            '
            Me.chkNativeAPI.AutoSize = True
            Me.chkNativeAPI.Checked = True
            Me.chkNativeAPI.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkNativeAPI.Location = New System.Drawing.Point(343, 182)
            Me.chkNativeAPI.Name = "chkNativeAPI"
            Me.chkNativeAPI.Size = New System.Drawing.Size(68, 17)
            Me.chkNativeAPI.TabIndex = 28
            Me.chkNativeAPI.Text = "API Calls"
            '
            'chkNetFx
            '
            Me.chkNetFx.AutoSize = True
            Me.chkNetFx.Checked = True
            Me.chkNetFx.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkNetFx.Location = New System.Drawing.Point(168, 182)
            Me.chkNetFx.Name = "chkNetFx"
            Me.chkNetFx.Size = New System.Drawing.Size(108, 17)
            Me.chkNetFx.TabIndex = 27
            Me.chkNetFx.Text = ".NET Component"
            '
            'chkLicensing
            '
            Me.chkLicensing.AutoSize = True
            Me.chkLicensing.Checked = True
            Me.chkLicensing.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkLicensing.Location = New System.Drawing.Point(470, 182)
            Me.chkLicensing.Name = "chkLicensing"
            Me.chkLicensing.Size = New System.Drawing.Size(71, 17)
            Me.chkLicensing.TabIndex = 26
            Me.chkLicensing.Text = "Licensing"
            '
            'chkDataProvider
            '
            Me.chkDataProvider.AutoSize = True
            Me.chkDataProvider.Checked = True
            Me.chkDataProvider.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkDataProvider.Location = New System.Drawing.Point(23, 182)
            Me.chkDataProvider.Name = "chkDataProvider"
            Me.chkDataProvider.Size = New System.Drawing.Size(91, 17)
            Me.chkDataProvider.TabIndex = 25
            Me.chkDataProvider.Text = "Data Provider"
            '
            'label4
            '
            Me.label4.Location = New System.Drawing.Point(70, 25)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(828, 41)
            Me.label4.TabIndex = 23
            Me.label4.Text = "Dieses Beispiel zeigt die Verwendung eines benutzerdefinierten Logging-Mechanismu" &
    "s für die Debugausgaben von List && Label mit den Frameworks NLog, log4net oder " &
    "der Ausgabe in ein ListView."
            '
            'btnExport_NLog
            '
            Me.btnExport_NLog.Location = New System.Drawing.Point(6, 155)
            Me.btnExport_NLog.Name = "btnExport_NLog"
            Me.btnExport_NLog.Size = New System.Drawing.Size(95, 29)
            Me.btnExport_NLog.TabIndex = 22
            Me.btnExport_NLog.Text = "Export..."
            '
            'chkPrinterInfo
            '
            Me.chkPrinterInfo.AutoSize = True
            Me.chkPrinterInfo.Location = New System.Drawing.Point(611, 182)
            Me.chkPrinterInfo.Name = "chkPrinterInfo"
            Me.chkPrinterInfo.Size = New System.Drawing.Size(111, 17)
            Me.chkPrinterInfo.TabIndex = 21
            Me.chkPrinterInfo.Text = "Printer Information"
            '
            'label3
            '
            Me.label3.AutoSize = True
            Me.label3.Location = New System.Drawing.Point(19, 146)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(81, 13)
            Me.label3.TabIndex = 20
            Me.label3.Text = "Log Categories:"
            '
            'label16
            '
            Me.label16.AutoSize = True
            Me.label16.Location = New System.Drawing.Point(3, 18)
            Me.label16.Name = "label16"
            Me.label16.Size = New System.Drawing.Size(18, 13)
            Me.label16.TabIndex = 18
            Me.label16.Text = "D:"
            '
            'label6
            '
            Me.label6.AutoSize = True
            Me.label6.Location = New System.Drawing.Point(19, 233)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(70, 13)
            Me.label6.TabIndex = 30
            Me.label6.Text = "Logger Type:"
            '
            'label7
            '
            Me.label7.AutoSize = True
            Me.label7.Location = New System.Drawing.Point(3, 18)
            Me.label7.Name = "label7"
            Me.label7.Size = New System.Drawing.Size(18, 13)
            Me.label7.TabIndex = 2
            Me.label7.Text = "D:"
            '
            'tabPageLog4Net
            '
            Me.tabPageLog4Net.Controls.Add(Me.btnExport_Log4Net)
            Me.tabPageLog4Net.Controls.Add(Me.btnOpenLogFile_Log4Net)
            Me.tabPageLog4Net.Controls.Add(Me.label17)
            Me.tabPageLog4Net.Controls.Add(Me.label18)
            Me.tabPageLog4Net.Controls.Add(Me.label13)
            Me.tabPageLog4Net.Controls.Add(Me.label14)
            Me.tabPageLog4Net.Controls.Add(Me.label15)
            Me.tabPageLog4Net.Controls.Add(Me.label16)
            Me.tabPageLog4Net.Location = New System.Drawing.Point(4, 22)
            Me.tabPageLog4Net.Name = "tabPageLog4Net"
            Me.tabPageLog4Net.Size = New System.Drawing.Size(867, 206)
            Me.tabPageLog4Net.TabIndex = 1
            Me.tabPageLog4Net.Text = "   log4net Framework   "
            '
            'btnExport_Log4Net
            '
            Me.btnExport_Log4Net.Location = New System.Drawing.Point(6, 155)
            Me.btnExport_Log4Net.Name = "btnExport_Log4Net"
            Me.btnExport_Log4Net.Size = New System.Drawing.Size(95, 29)
            Me.btnExport_Log4Net.TabIndex = 25
            Me.btnExport_Log4Net.Text = "Export..."
            '
            'btnOpenLogFile_Log4Net
            '
            Me.btnOpenLogFile_Log4Net.Enabled = False
            Me.btnOpenLogFile_Log4Net.Location = New System.Drawing.Point(107, 155)
            Me.btnOpenLogFile_Log4Net.Name = "btnOpenLogFile_Log4Net"
            Me.btnOpenLogFile_Log4Net.Size = New System.Drawing.Size(140, 29)
            Me.btnOpenLogFile_Log4Net.TabIndex = 22
            Me.btnOpenLogFile_Log4Net.Text = "Open Log File"
            '
            'chkOther
            '
            Me.chkOther.AutoSize = True
            Me.chkOther.Location = New System.Drawing.Point(799, 182)
            Me.chkOther.Name = "chkOther"
            Me.chkOther.Size = New System.Drawing.Size(52, 17)
            Me.chkOther.TabIndex = 29
            Me.chkOther.Text = "Other"
            '
            'tabPageNLog
            '
            Me.tabPageNLog.Controls.Add(Me.btnOpenLogFile_NLog)
            Me.tabPageNLog.Controls.Add(Me.label12)
            Me.tabPageNLog.Controls.Add(Me.label11)
            Me.tabPageNLog.Controls.Add(Me.label9)
            Me.tabPageNLog.Controls.Add(Me.label10)
            Me.tabPageNLog.Controls.Add(Me.btnExport_NLog)
            Me.tabPageNLog.Controls.Add(Me.label8)
            Me.tabPageNLog.Controls.Add(Me.label7)
            Me.tabPageNLog.Location = New System.Drawing.Point(4, 22)
            Me.tabPageNLog.Name = "tabPageNLog"
            Me.tabPageNLog.Size = New System.Drawing.Size(867, 206)
            Me.tabPageNLog.TabIndex = 0
            Me.tabPageNLog.Text = "   NLog Framework   "
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
            Me.chkIncludeDebugLevel.Size = New System.Drawing.Size(190, 17)
            Me.chkIncludeDebugLevel.TabIndex = 3
            Me.chkIncludeDebugLevel.Text = "Include messages of level 'Debug' "
            '
            'listviewMessages
            '
            Me.listviewMessages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.listviewMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3})
            Me.listviewMessages.Enabled = False
            Me.listviewMessages.FullRowSelect = True
            Me.listviewMessages.GridLines = True
            Me.listviewMessages.HideSelection = False
            Me.listviewMessages.Location = New System.Drawing.Point(0, 35)
            Me.listviewMessages.Name = "listviewMessages"
            Me.listviewMessages.Size = New System.Drawing.Size(864, 129)
            Me.listviewMessages.SmallImageList = Me.imageList1
            Me.listviewMessages.TabIndex = 2
            Me.listviewMessages.UseCompatibleStateImageBehavior = False
            Me.listviewMessages.View = System.Windows.Forms.View.Details
            '
            'tabPageListView
            '
            Me.tabPageListView.Controls.Add(Me.btnExport_LogToListView)
            Me.tabPageListView.Controls.Add(Me.chkIncludeDebugLevel)
            Me.tabPageListView.Controls.Add(Me.listviewMessages)
            Me.tabPageListView.Location = New System.Drawing.Point(4, 22)
            Me.tabPageListView.Name = "tabPageListView"
            Me.tabPageListView.Size = New System.Drawing.Size(867, 206)
            Me.tabPageListView.TabIndex = 2
            Me.tabPageListView.Text = "   LogToListView   "
            '
            'btnExport_LogToListView
            '
            Me.btnExport_LogToListView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnExport_LogToListView.Location = New System.Drawing.Point(6, 170)
            Me.btnExport_LogToListView.Name = "btnExport_LogToListView"
            Me.btnExport_LogToListView.Size = New System.Drawing.Size(95, 29)
            Me.btnExport_LogToListView.TabIndex = 23
            Me.btnExport_LogToListView.Text = "Export..."
            '
            'tabsLogType
            '
            Me.tabsLogType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tabsLogType.Controls.Add(Me.tabPageListView)
            Me.tabsLogType.Controls.Add(Me.tabPageNLog)
            Me.tabsLogType.Controls.Add(Me.tabPageLog4Net)
            Me.tabsLogType.Location = New System.Drawing.Point(23, 261)
            Me.tabsLogType.Name = "tabsLogType"
            Me.tabsLogType.SelectedIndex = 0
            Me.tabsLogType.Size = New System.Drawing.Size(875, 232)
            Me.tabsLogType.TabIndex = 19
            '
            'label2
            '
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(23, 76)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(25, 13)
            Me.label2.TabIndex = 18
            Me.label2.Text = "US:"
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(23, 25)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(18, 13)
            Me.label1.TabIndex = 17
            Me.label1.Text = "D:"
            '
            'label5
            '
            Me.label5.Location = New System.Drawing.Point(70, 76)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(828, 54)
            Me.label5.TabIndex = 24
            Me.label5.Text = "This sample shows the usage of a user-defined logging mechanism for the debug out" &
    "puts of List && Label with the logging frameworks NLog, log4net or the logging t" &
    "o a ListView."
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(914, 521)
            Me.Controls.Add(Me.chkNativeAPI)
            Me.Controls.Add(Me.chkNetFx)
            Me.Controls.Add(Me.chkLicensing)
            Me.Controls.Add(Me.chkDataProvider)
            Me.Controls.Add(Me.label4)
            Me.Controls.Add(Me.chkPrinterInfo)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.label6)
            Me.Controls.Add(Me.chkOther)
            Me.Controls.Add(Me.tabsLogType)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.label5)
            Me.MinimumSize = New System.Drawing.Size(900, 560)
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
        Private WithEvents label17 As System.Windows.Forms.Label
        Private WithEvents label13 As System.Windows.Forms.Label
        Private WithEvents btnOpenLogFile_NLog As System.Windows.Forms.Button
        Private WithEvents label12 As System.Windows.Forms.Label
        Private WithEvents label11 As System.Windows.Forms.Label
        Private WithEvents label9 As System.Windows.Forms.Label
        Private WithEvents label10 As System.Windows.Forms.Label
        Private WithEvents label8 As System.Windows.Forms.Label
        Private WithEvents label18 As System.Windows.Forms.Label
        Private WithEvents label14 As System.Windows.Forms.Label
        Private WithEvents label15 As System.Windows.Forms.Label
        Private WithEvents chkNativeAPI As System.Windows.Forms.CheckBox
        Private WithEvents chkNetFx As System.Windows.Forms.CheckBox
        Private WithEvents chkLicensing As System.Windows.Forms.CheckBox
        Private WithEvents chkDataProvider As System.Windows.Forms.CheckBox
        Private WithEvents label4 As System.Windows.Forms.Label
        Private WithEvents btnExport_NLog As System.Windows.Forms.Button
        Private WithEvents chkPrinterInfo As System.Windows.Forms.CheckBox
        Private WithEvents label3 As System.Windows.Forms.Label
        Private WithEvents label16 As System.Windows.Forms.Label
        Private WithEvents label6 As System.Windows.Forms.Label
        Private WithEvents label7 As System.Windows.Forms.Label
        Private WithEvents tabPageLog4Net As System.Windows.Forms.TabPage
        Private WithEvents btnOpenLogFile_Log4Net As System.Windows.Forms.Button
        Private WithEvents chkOther As System.Windows.Forms.CheckBox
        Private WithEvents tabPageNLog As System.Windows.Forms.TabPage
        Private WithEvents imageList1 As System.Windows.Forms.ImageList
        Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
        Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
        Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
        Private WithEvents chkIncludeDebugLevel As System.Windows.Forms.CheckBox
        Private WithEvents listviewMessages As System.Windows.Forms.ListView
        Private WithEvents tabPageListView As System.Windows.Forms.TabPage
        Private WithEvents tabsLogType As System.Windows.Forms.TabControl
        Private WithEvents label2 As System.Windows.Forms.Label
        Private WithEvents label1 As System.Windows.Forms.Label
        Private WithEvents label5 As System.Windows.Forms.Label
        Private WithEvents btnExport_Log4Net As Button
        Private WithEvents btnExport_LogToListView As Button
    End Class
End Namespace

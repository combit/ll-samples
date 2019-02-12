Imports combit.ListLabel24
Imports System.Globalization
Partial Class Form1
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Windows Form Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LL = New combit.ListLabel24.ListLabel(Me.components)
        Me.statusBar1 = New System.Windows.Forms.StatusBar()
        Me.LLPreviewControl = New combit.ListLabel24.ListLabelPreviewControl(Me.components)
        Me.progressBar1 = New System.Windows.Forms.ProgressBar()
        Me.tabControl = New MetroFramework.Controls.MetroTabControl()
        Me.tpDataSet = New System.Windows.Forms.TabPage()
        Me.metroPanel2 = New MetroFramework.Controls.MetroPanel()
        Me.design_DataSet = New MetroFramework.Controls.MetroButton()
        Me.print_DataSet = New MetroFramework.Controls.MetroButton()
        Me.label8 = New MetroFramework.Controls.MetroLabel()
        Me.label7 = New MetroFramework.Controls.MetroLabel()
        Me.label2 = New MetroFramework.Controls.MetroLabel()
        Me.label6 = New MetroFramework.Controls.MetroLabel()
        Me.tpXML = New System.Windows.Forms.TabPage()
        Me.metroPanel5 = New MetroFramework.Controls.MetroPanel()
        Me.print_XML = New MetroFramework.Controls.MetroButton()
        Me.design_XML = New MetroFramework.Controls.MetroButton()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.label5 = New MetroFramework.Controls.MetroLabel()
        Me.label4 = New MetroFramework.Controls.MetroLabel()
        Me.tpDataViewManager = New System.Windows.Forms.TabPage()
        Me.metroPanel3 = New MetroFramework.Controls.MetroPanel()
        Me.cbCustomerNames = New MetroFramework.Controls.MetroComboBox()
        Me.print_DataViewManager = New MetroFramework.Controls.MetroButton()
        Me.label21 = New MetroFramework.Controls.MetroLabel()
        Me.design_DataViewManager = New MetroFramework.Controls.MetroButton()
        Me.label23 = New MetroFramework.Controls.MetroLabel()
        Me.label22 = New MetroFramework.Controls.MetroLabel()
        Me.label24 = New MetroFramework.Controls.MetroLabel()
        Me.tpDataView = New System.Windows.Forms.TabPage()
        Me.metroPanel4 = New MetroFramework.Controls.MetroPanel()
        Me.design_DataView = New MetroFramework.Controls.MetroButton()
        Me.print_DataView = New MetroFramework.Controls.MetroButton()
        Me.label20 = New MetroFramework.Controls.MetroLabel()
        Me.label17 = New MetroFramework.Controls.MetroLabel()
        Me.label18 = New MetroFramework.Controls.MetroLabel()
        Me.label19 = New MetroFramework.Controls.MetroLabel()
        Me.tpDbCommand = New System.Windows.Forms.TabPage()
        Me.metroPanel6 = New MetroFramework.Controls.MetroPanel()
        Me.print_Reader = New MetroFramework.Controls.MetroButton()
        Me.design_Reader = New MetroFramework.Controls.MetroButton()
        Me.label12 = New MetroFramework.Controls.MetroLabel()
        Me.label9 = New MetroFramework.Controls.MetroLabel()
        Me.label10 = New MetroFramework.Controls.MetroLabel()
        Me.label11 = New MetroFramework.Controls.MetroLabel()
        Me.tpDataTable = New System.Windows.Forms.TabPage()
        Me.metroPanel7 = New MetroFramework.Controls.MetroPanel()
        Me.design_DataTable = New MetroFramework.Controls.MetroButton()
        Me.print_DataTable = New MetroFramework.Controls.MetroButton()
        Me.label16 = New MetroFramework.Controls.MetroLabel()
        Me.label13 = New MetroFramework.Controls.MetroLabel()
        Me.label99 = New MetroFramework.Controls.MetroLabel()
        Me.label15 = New MetroFramework.Controls.MetroLabel()
        Me.tpGenericList = New System.Windows.Forms.TabPage()
        Me.metroPanel8 = New MetroFramework.Controls.MetroPanel()
        Me.print_GenericList = New MetroFramework.Controls.MetroButton()
        Me.design_GenericList = New MetroFramework.Controls.MetroButton()
        Me.label79 = New MetroFramework.Controls.MetroLabel()
        Me.label77 = New MetroFramework.Controls.MetroLabel()
        Me.label76 = New MetroFramework.Controls.MetroLabel()
        Me.label78 = New MetroFramework.Controls.MetroLabel()
        Me.tabSQLServer = New System.Windows.Forms.TabPage()
        Me.metroPanel9 = New MetroFramework.Controls.MetroPanel()
        Me.label115 = New MetroFramework.Controls.MetroLabel()
        Me.print_SQL = New MetroFramework.Controls.MetroButton()
        Me.design_SQL = New MetroFramework.Controls.MetroButton()
        Me.label111 = New MetroFramework.Controls.MetroLabel()
        Me.label114 = New MetroFramework.Controls.MetroLabel()
        Me.label113 = New MetroFramework.Controls.MetroLabel()
        Me.label112 = New MetroFramework.Controls.MetroLabel()
        Me.tbConnectionString = New MetroFramework.Controls.MetroTextBox()
        Me.tabOdata = New System.Windows.Forms.TabPage()
        Me.metroPanel10 = New MetroFramework.Controls.MetroPanel()
        Me.label116 = New MetroFramework.Controls.MetroLabel()
        Me.printOdataBtn = New MetroFramework.Controls.MetroButton()
        Me.label117 = New MetroFramework.Controls.MetroLabel()
        Me.designOdataBtn = New MetroFramework.Controls.MetroButton()
        Me.odataUrlTb = New MetroFramework.Controls.MetroTextBox()
        Me.label119 = New MetroFramework.Controls.MetroLabel()
        Me.label120 = New MetroFramework.Controls.MetroLabel()
        Me.label118 = New MetroFramework.Controls.MetroLabel()
        Me.metroPanel11 = New MetroFramework.Controls.MetroPanel()
        Me.restUrlTb = New MetroFramework.Controls.MetroTextBox()
        Me.label203 = New MetroFramework.Controls.MetroLabel()
        Me.label204 = New MetroFramework.Controls.MetroLabel()
        Me.label205 = New MetroFramework.Controls.MetroLabel()
        Me.label202 = New MetroFramework.Controls.MetroLabel()
        Me.restDesignBtn = New MetroFramework.Controls.MetroButton()
        Me.restPrintBtn = New MetroFramework.Controls.MetroButton()
        Me.metroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.tabRest = New System.Windows.Forms.TabPage()
        Me.tabControl.SuspendLayout()
        Me.tpDataSet.SuspendLayout()
        Me.metroPanel2.SuspendLayout()
        Me.tpXML.SuspendLayout()
        Me.metroPanel5.SuspendLayout()
        Me.tpDataViewManager.SuspendLayout()
        Me.metroPanel3.SuspendLayout()
        Me.tpDataView.SuspendLayout()
        Me.metroPanel4.SuspendLayout()
        Me.tpDbCommand.SuspendLayout()
        Me.metroPanel6.SuspendLayout()
        Me.tpDataTable.SuspendLayout()
        Me.metroPanel7.SuspendLayout()
        Me.tpGenericList.SuspendLayout()
        Me.metroPanel8.SuspendLayout()
        Me.tabSQLServer.SuspendLayout()
        Me.metroPanel9.SuspendLayout()
        Me.tabOdata.SuspendLayout()
        Me.metroPanel10.SuspendLayout()
        Me.metroPanel11.SuspendLayout()
        Me.tabRest.SuspendLayout()
        Me.SuspendLayout()
        '
        'LL
        '
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_100
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'statusBar1
        '
        Me.statusBar1.Location = New System.Drawing.Point(20, 708)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Size = New System.Drawing.Size(763, 22)
        Me.statusBar1.TabIndex = 13
        '
        'LLPreviewControl
        '
        Me.LLPreviewControl.AllowRbuttonUsage = True
        Me.LLPreviewControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LLPreviewControl.BackColor = System.Drawing.SystemColors.Window
        Me.LLPreviewControl.CloseMode = combit.ListLabel24.LlPreviewControlCloseMode.DeleteFile
        Me.LLPreviewControl.CurrentPage = 0
        Me.LLPreviewControl.ForceReadOnly = False
        Me.LLPreviewControl.Location = New System.Drawing.Point(20, 200)
        Me.LLPreviewControl.Name = "LLPreviewControl"
        Me.LLPreviewControl.Size = New System.Drawing.Size(763, 508)
        Me.LLPreviewControl.SlideshowMode = False
        Me.LLPreviewControl.TabIndex = 14
        Me.LLPreviewControl.Text = "listLabelPreviewControl1"
        Me.LLPreviewControl.ToolbarButtons.Exit = combit.ListLabel24.LlButtonState.Invisible
        Me.LLPreviewControl.ToolbarButtons.GotoFirst = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.GotoLast = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.GotoNext = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.GotoPrev = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.NextFile = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.PageRange = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.PreviousFile = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.PrintAllPages = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.PrintCurrentPage = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.PrintToFax = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.SaveAs = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.SearchNext = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.SearchOptions = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.SearchStart = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.SearchText = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.SendTo = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.SlideshowMode = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.ZoomCombo = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.ZoomReset = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.ZoomRevert = combit.ListLabel24.LlButtonState.[Default]
        Me.LLPreviewControl.ToolbarButtons.ZoomTimes2 = combit.ListLabel24.LlButtonState.[Default]
        '
        'progressBar1
        '
        Me.progressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.progressBar1.Location = New System.Drawing.Point(1, 732)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(144, 16)
        Me.progressBar1.TabIndex = 16
        Me.progressBar1.Visible = False
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tpDataSet)
        Me.tabControl.Controls.Add(Me.tpXML)
        Me.tabControl.Controls.Add(Me.tpDataViewManager)
        Me.tabControl.Controls.Add(Me.tpDataView)
        Me.tabControl.Controls.Add(Me.tpDbCommand)
        Me.tabControl.Controls.Add(Me.tpDataTable)
        Me.tabControl.Controls.Add(Me.tpGenericList)
        Me.tabControl.Controls.Add(Me.tabSQLServer)
        Me.tabControl.Controls.Add(Me.tabOdata)
        Me.tabControl.Controls.Add(Me.tabRest)
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabControl.Location = New System.Drawing.Point(20, 60)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(763, 140)
        Me.tabControl.Style = MetroFramework.MetroColorStyle.Blue
        Me.tabControl.TabIndex = 17
        Me.tabControl.UseSelectable = True
        '
        'tpDataSet
        '
        Me.tpDataSet.Controls.Add(Me.metroPanel2)
        Me.tpDataSet.Location = New System.Drawing.Point(4, 38)
        Me.tpDataSet.Name = "tpDataSet"
        Me.tpDataSet.Size = New System.Drawing.Size(755, 98)
        Me.tpDataSet.TabIndex = 0
        Me.tpDataSet.Text = "DataSet"
        Me.tpDataSet.UseVisualStyleBackColor = True
        '
        'metroPanel2
        '
        Me.metroPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel2.Controls.Add(Me.design_DataSet)
        Me.metroPanel2.Controls.Add(Me.print_DataSet)
        Me.metroPanel2.Controls.Add(Me.label8)
        Me.metroPanel2.Controls.Add(Me.label7)
        Me.metroPanel2.Controls.Add(Me.label2)
        Me.metroPanel2.Controls.Add(Me.label6)
        Me.metroPanel2.HorizontalScrollbarBarColor = True
        Me.metroPanel2.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel2.HorizontalScrollbarSize = 10
        Me.metroPanel2.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel2.Name = "metroPanel2"
        Me.metroPanel2.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel2.TabIndex = 18
        Me.metroPanel2.VerticalScrollbarBarColor = True
        Me.metroPanel2.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel2.VerticalScrollbarSize = 10
        '
        'design_DataSet
        '
        Me.design_DataSet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.design_DataSet.Location = New System.Drawing.Point(512, 59)
        Me.design_DataSet.Name = "design_DataSet"
        Me.design_DataSet.Size = New System.Drawing.Size(112, 24)
        Me.design_DataSet.TabIndex = 16
        Me.design_DataSet.Text = "&Design"
        Me.design_DataSet.UseSelectable = True
        '
        'print_DataSet
        '
        Me.print_DataSet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.print_DataSet.Location = New System.Drawing.Point(641, 59)
        Me.print_DataSet.Name = "print_DataSet"
        Me.print_DataSet.Size = New System.Drawing.Size(112, 24)
        Me.print_DataSet.TabIndex = 17
        Me.print_DataSet.Text = "&Print"
        Me.print_DataSet.UseSelectable = True
        '
        'label8
        '
        Me.label8.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label8.Location = New System.Drawing.Point(33, 15)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(272, 32)
        Me.label8.TabIndex = 12
        Me.label8.Text = "Bindet die Komponente an ein dynamisch erstelltes DataSet-Objekt mit DataRelation" & _
    "s."
        Me.label8.WrapToLine = True
        '
        'label7
        '
        Me.label7.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label7.Location = New System.Drawing.Point(376, 15)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(272, 32)
        Me.label7.TabIndex = 13
        Me.label7.Text = "Binds the component to a dynamically created DataSet containing DataRelations."
        Me.label7.WrapToLine = True
        '
        'label2
        '
        Me.label2.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label2.Location = New System.Drawing.Point(346, 15)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(24, 24)
        Me.label2.TabIndex = 14
        Me.label2.Text = "US:"
        '
        'label6
        '
        Me.label6.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label6.Location = New System.Drawing.Point(3, 15)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(24, 16)
        Me.label6.TabIndex = 15
        Me.label6.Text = "D:"
        '
        'tpXML
        '
        Me.tpXML.Controls.Add(Me.metroPanel5)
        Me.tpXML.Location = New System.Drawing.Point(4, 38)
        Me.tpXML.Name = "tpXML"
        Me.tpXML.Size = New System.Drawing.Size(755, 98)
        Me.tpXML.TabIndex = 5
        Me.tpXML.Text = "XML"
        Me.tpXML.UseVisualStyleBackColor = True
        Me.tpXML.Visible = False
        '
        'metroPanel5
        '
        Me.metroPanel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel5.Controls.Add(Me.print_XML)
        Me.metroPanel5.Controls.Add(Me.design_XML)
        Me.metroPanel5.Controls.Add(Me.label3)
        Me.metroPanel5.Controls.Add(Me.label1)
        Me.metroPanel5.Controls.Add(Me.label5)
        Me.metroPanel5.Controls.Add(Me.label4)
        Me.metroPanel5.HorizontalScrollbarBarColor = True
        Me.metroPanel5.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel5.HorizontalScrollbarSize = 10
        Me.metroPanel5.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel5.Name = "metroPanel5"
        Me.metroPanel5.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel5.TabIndex = 22
        Me.metroPanel5.VerticalScrollbarBarColor = True
        Me.metroPanel5.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel5.VerticalScrollbarSize = 10
        '
        'print_XML
        '
        Me.print_XML.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.print_XML.Location = New System.Drawing.Point(641, 59)
        Me.print_XML.Name = "print_XML"
        Me.print_XML.Size = New System.Drawing.Size(112, 24)
        Me.print_XML.TabIndex = 21
        Me.print_XML.Text = "&Print"
        Me.print_XML.UseSelectable = True
        '
        'design_XML
        '
        Me.design_XML.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.design_XML.Location = New System.Drawing.Point(512, 59)
        Me.design_XML.Name = "design_XML"
        Me.design_XML.Size = New System.Drawing.Size(112, 24)
        Me.design_XML.TabIndex = 20
        Me.design_XML.Text = "&Design"
        Me.design_XML.UseSelectable = True
        '
        'label3
        '
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(3, 15)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(24, 16)
        Me.label3.TabIndex = 19
        Me.label3.Text = "D:"
        Me.label3.WrapToLine = True
        '
        'label1
        '
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(346, 15)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(24, 16)
        Me.label1.TabIndex = 18
        Me.label1.Text = "US:"
        Me.label1.WrapToLine = True
        '
        'label5
        '
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(33, 15)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(256, 32)
        Me.label5.TabIndex = 16
        Me.label5.Text = "Bindet die Komponente an die Beispiel XML-Datei."
        Me.label5.WrapToLine = True
        '
        'label4
        '
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(376, 15)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(272, 32)
        Me.label4.TabIndex = 17
        Me.label4.Text = "Binds the component to the sample XML file."
        Me.label4.WrapToLine = True
        '
        'tpDataViewManager
        '
        Me.tpDataViewManager.Controls.Add(Me.metroPanel3)
        Me.tpDataViewManager.Location = New System.Drawing.Point(4, 38)
        Me.tpDataViewManager.Name = "tpDataViewManager"
        Me.tpDataViewManager.Size = New System.Drawing.Size(755, 98)
        Me.tpDataViewManager.TabIndex = 6
        Me.tpDataViewManager.Text = "DataViewManager"
        Me.tpDataViewManager.UseVisualStyleBackColor = True
        Me.tpDataViewManager.Visible = False
        '
        'metroPanel3
        '
        Me.metroPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel3.Controls.Add(Me.cbCustomerNames)
        Me.metroPanel3.Controls.Add(Me.print_DataViewManager)
        Me.metroPanel3.Controls.Add(Me.label21)
        Me.metroPanel3.Controls.Add(Me.design_DataViewManager)
        Me.metroPanel3.Controls.Add(Me.label23)
        Me.metroPanel3.Controls.Add(Me.label22)
        Me.metroPanel3.Controls.Add(Me.label24)
        Me.metroPanel3.HorizontalScrollbarBarColor = True
        Me.metroPanel3.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel3.HorizontalScrollbarSize = 10
        Me.metroPanel3.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel3.Name = "metroPanel3"
        Me.metroPanel3.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel3.TabIndex = 33
        Me.metroPanel3.VerticalScrollbarBarColor = True
        Me.metroPanel3.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel3.VerticalScrollbarSize = 10
        '
        'cbCustomerNames
        '
        Me.cbCustomerNames.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cbCustomerNames.ItemHeight = 19
        Me.cbCustomerNames.Location = New System.Drawing.Point(33, 60)
        Me.cbCustomerNames.Name = "cbCustomerNames"
        Me.cbCustomerNames.Size = New System.Drawing.Size(296, 25)
        Me.cbCustomerNames.Style = MetroFramework.MetroColorStyle.Blue
        Me.cbCustomerNames.TabIndex = 32
        Me.cbCustomerNames.UseSelectable = True
        '
        'print_DataViewManager
        '
        Me.print_DataViewManager.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.print_DataViewManager.Location = New System.Drawing.Point(641, 59)
        Me.print_DataViewManager.Name = "print_DataViewManager"
        Me.print_DataViewManager.Size = New System.Drawing.Size(112, 24)
        Me.print_DataViewManager.TabIndex = 31
        Me.print_DataViewManager.Text = "&Print"
        Me.print_DataViewManager.UseSelectable = True
        '
        'label21
        '
        Me.label21.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label21.Location = New System.Drawing.Point(346, 15)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(24, 24)
        Me.label21.TabIndex = 28
        Me.label21.Text = "US:"
        Me.label21.WrapToLine = True
        '
        'design_DataViewManager
        '
        Me.design_DataViewManager.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.design_DataViewManager.Location = New System.Drawing.Point(512, 59)
        Me.design_DataViewManager.Name = "design_DataViewManager"
        Me.design_DataViewManager.Size = New System.Drawing.Size(112, 24)
        Me.design_DataViewManager.TabIndex = 30
        Me.design_DataViewManager.Text = "&Design"
        Me.design_DataViewManager.UseSelectable = True
        '
        'label23
        '
        Me.label23.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label23.Location = New System.Drawing.Point(376, 15)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(272, 32)
        Me.label23.TabIndex = 27
        Me.label23.Text = "Binds the component to a DataView object. Choose a filter for the company name."
        Me.label23.WrapToLine = True
        '
        'label22
        '
        Me.label22.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label22.Location = New System.Drawing.Point(3, 15)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(24, 24)
        Me.label22.TabIndex = 29
        Me.label22.Text = "D:"
        Me.label22.WrapToLine = True
        '
        'label24
        '
        Me.label24.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label24.Location = New System.Drawing.Point(33, 15)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(292, 40)
        Me.label24.TabIndex = 26
        Me.label24.Text = "Bindet die Komponente an ein DataViewManager-Objekt. Sie können einen Filter für " & _
    "den Firmennamen wählen."
        Me.label24.WrapToLine = True
        '
        'tpDataView
        '
        Me.tpDataView.Controls.Add(Me.metroPanel4)
        Me.tpDataView.Location = New System.Drawing.Point(4, 38)
        Me.tpDataView.Name = "tpDataView"
        Me.tpDataView.Size = New System.Drawing.Size(755, 98)
        Me.tpDataView.TabIndex = 3
        Me.tpDataView.Text = "DataView"
        Me.tpDataView.UseVisualStyleBackColor = True
        Me.tpDataView.Visible = False
        '
        'metroPanel4
        '
        Me.metroPanel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel4.Controls.Add(Me.design_DataView)
        Me.metroPanel4.Controls.Add(Me.print_DataView)
        Me.metroPanel4.Controls.Add(Me.label20)
        Me.metroPanel4.Controls.Add(Me.label17)
        Me.metroPanel4.Controls.Add(Me.label18)
        Me.metroPanel4.Controls.Add(Me.label19)
        Me.metroPanel4.HorizontalScrollbarBarColor = True
        Me.metroPanel4.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel4.HorizontalScrollbarSize = 10
        Me.metroPanel4.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel4.Name = "metroPanel4"
        Me.metroPanel4.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel4.TabIndex = 26
        Me.metroPanel4.VerticalScrollbarBarColor = True
        Me.metroPanel4.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel4.VerticalScrollbarSize = 10
        '
        'design_DataView
        '
        Me.design_DataView.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.design_DataView.Location = New System.Drawing.Point(512, 59)
        Me.design_DataView.Name = "design_DataView"
        Me.design_DataView.Size = New System.Drawing.Size(112, 24)
        Me.design_DataView.TabIndex = 24
        Me.design_DataView.Text = "&Design"
        Me.design_DataView.UseSelectable = True
        '
        'print_DataView
        '
        Me.print_DataView.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.print_DataView.Location = New System.Drawing.Point(641, 59)
        Me.print_DataView.Name = "print_DataView"
        Me.print_DataView.Size = New System.Drawing.Size(112, 24)
        Me.print_DataView.TabIndex = 25
        Me.print_DataView.Text = "&Print"
        Me.print_DataView.UseSelectable = True
        '
        'label20
        '
        Me.label20.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label20.Location = New System.Drawing.Point(33, 15)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(256, 32)
        Me.label20.TabIndex = 16
        Me.label20.Text = "Bindet die Komponente an ein DataView-Objekt."
        Me.label20.WrapToLine = True
        '
        'label17
        '
        Me.label17.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label17.Location = New System.Drawing.Point(346, 15)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(24, 16)
        Me.label17.TabIndex = 18
        Me.label17.Text = "US:"
        Me.label17.WrapToLine = True
        '
        'label18
        '
        Me.label18.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label18.Location = New System.Drawing.Point(3, 15)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(24, 16)
        Me.label18.TabIndex = 19
        Me.label18.Text = "D:"
        Me.label18.WrapToLine = True
        '
        'label19
        '
        Me.label19.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label19.Location = New System.Drawing.Point(376, 15)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(272, 32)
        Me.label19.TabIndex = 17
        Me.label19.Text = "Binds the component to a DataView object."
        Me.label19.WrapToLine = True
        '
        'tpDbCommand
        '
        Me.tpDbCommand.Controls.Add(Me.metroPanel6)
        Me.tpDbCommand.Location = New System.Drawing.Point(4, 38)
        Me.tpDbCommand.Name = "tpDbCommand"
        Me.tpDbCommand.Size = New System.Drawing.Size(755, 98)
        Me.tpDbCommand.TabIndex = 1
        Me.tpDbCommand.Text = "DbCommand"
        Me.tpDbCommand.UseVisualStyleBackColor = True
        Me.tpDbCommand.Visible = False
        '
        'metroPanel6
        '
        Me.metroPanel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel6.Controls.Add(Me.print_Reader)
        Me.metroPanel6.Controls.Add(Me.design_Reader)
        Me.metroPanel6.Controls.Add(Me.label12)
        Me.metroPanel6.Controls.Add(Me.label9)
        Me.metroPanel6.Controls.Add(Me.label10)
        Me.metroPanel6.Controls.Add(Me.label11)
        Me.metroPanel6.HorizontalScrollbarBarColor = True
        Me.metroPanel6.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel6.HorizontalScrollbarSize = 10
        Me.metroPanel6.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel6.Name = "metroPanel6"
        Me.metroPanel6.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel6.TabIndex = 25
        Me.metroPanel6.VerticalScrollbarBarColor = True
        Me.metroPanel6.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel6.VerticalScrollbarSize = 10
        '
        'print_Reader
        '
        Me.print_Reader.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.print_Reader.Location = New System.Drawing.Point(641, 59)
        Me.print_Reader.Name = "print_Reader"
        Me.print_Reader.Size = New System.Drawing.Size(112, 24)
        Me.print_Reader.TabIndex = 23
        Me.print_Reader.Text = "&Print"
        Me.print_Reader.UseSelectable = True
        '
        'design_Reader
        '
        Me.design_Reader.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.design_Reader.Location = New System.Drawing.Point(512, 59)
        Me.design_Reader.Name = "design_Reader"
        Me.design_Reader.Size = New System.Drawing.Size(112, 24)
        Me.design_Reader.TabIndex = 22
        Me.design_Reader.Text = "&Design"
        Me.design_Reader.UseSelectable = True
        '
        'label12
        '
        Me.label12.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label12.Location = New System.Drawing.Point(33, 15)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(287, 32)
        Me.label12.TabIndex = 24
        Me.label12.Text = "Bindet die Komponente an ein OleDbCommand-Objekt."
        Me.label12.WrapToLine = True
        '
        'label9
        '
        Me.label9.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label9.Location = New System.Drawing.Point(346, 15)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(24, 16)
        Me.label9.TabIndex = 18
        Me.label9.Text = "US:"
        Me.label9.WrapToLine = True
        '
        'label10
        '
        Me.label10.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label10.Location = New System.Drawing.Point(3, 15)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(24, 16)
        Me.label10.TabIndex = 19
        Me.label10.Text = "D:"
        Me.label10.WrapToLine = True
        '
        'label11
        '
        Me.label11.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label11.Location = New System.Drawing.Point(376, 15)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(272, 32)
        Me.label11.TabIndex = 17
        Me.label11.Text = "Binds the component to an OleDbCommand object."
        Me.label11.WrapToLine = True
        '
        'tpDataTable
        '
        Me.tpDataTable.Controls.Add(Me.metroPanel7)
        Me.tpDataTable.Location = New System.Drawing.Point(4, 38)
        Me.tpDataTable.Name = "tpDataTable"
        Me.tpDataTable.Size = New System.Drawing.Size(755, 98)
        Me.tpDataTable.TabIndex = 2
        Me.tpDataTable.Text = "DataTable"
        Me.tpDataTable.UseVisualStyleBackColor = True
        Me.tpDataTable.Visible = False
        '
        'metroPanel7
        '
        Me.metroPanel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel7.Controls.Add(Me.design_DataTable)
        Me.metroPanel7.Controls.Add(Me.print_DataTable)
        Me.metroPanel7.Controls.Add(Me.label16)
        Me.metroPanel7.Controls.Add(Me.label13)
        Me.metroPanel7.Controls.Add(Me.label99)
        Me.metroPanel7.Controls.Add(Me.label15)
        Me.metroPanel7.HorizontalScrollbarBarColor = True
        Me.metroPanel7.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel7.HorizontalScrollbarSize = 10
        Me.metroPanel7.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel7.Name = "metroPanel7"
        Me.metroPanel7.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel7.TabIndex = 28
        Me.metroPanel7.VerticalScrollbarBarColor = True
        Me.metroPanel7.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel7.VerticalScrollbarSize = 10
        '
        'design_DataTable
        '
        Me.design_DataTable.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.design_DataTable.Location = New System.Drawing.Point(512, 59)
        Me.design_DataTable.Name = "design_DataTable"
        Me.design_DataTable.Size = New System.Drawing.Size(112, 24)
        Me.design_DataTable.TabIndex = 26
        Me.design_DataTable.Text = "&Design"
        Me.design_DataTable.UseSelectable = True
        '
        'print_DataTable
        '
        Me.print_DataTable.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.print_DataTable.Location = New System.Drawing.Point(641, 59)
        Me.print_DataTable.Name = "print_DataTable"
        Me.print_DataTable.Size = New System.Drawing.Size(112, 24)
        Me.print_DataTable.TabIndex = 27
        Me.print_DataTable.Text = "&Print"
        Me.print_DataTable.UseSelectable = True
        '
        'label16
        '
        Me.label16.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label16.Location = New System.Drawing.Point(33, 15)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(256, 32)
        Me.label16.TabIndex = 16
        Me.label16.Text = "Bindet die Komponente an ein DataTable-Objekt."
        Me.label16.WrapToLine = True
        '
        'label13
        '
        Me.label13.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label13.Location = New System.Drawing.Point(346, 15)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(24, 16)
        Me.label13.TabIndex = 18
        Me.label13.Text = "US:"
        Me.label13.WrapToLine = True
        '
        'label99
        '
        Me.label99.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label99.Location = New System.Drawing.Point(3, 15)
        Me.label99.Name = "label99"
        Me.label99.Size = New System.Drawing.Size(24, 16)
        Me.label99.TabIndex = 19
        Me.label99.Text = "D:"
        Me.label99.WrapToLine = True
        '
        'label15
        '
        Me.label15.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label15.Location = New System.Drawing.Point(376, 15)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(272, 32)
        Me.label15.TabIndex = 17
        Me.label15.Text = "Binds the component to a DataTable object."
        Me.label15.WrapToLine = True
        '
        'tpGenericList
        '
        Me.tpGenericList.Controls.Add(Me.metroPanel8)
        Me.tpGenericList.Location = New System.Drawing.Point(4, 38)
        Me.tpGenericList.Name = "tpGenericList"
        Me.tpGenericList.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGenericList.Size = New System.Drawing.Size(755, 98)
        Me.tpGenericList.TabIndex = 7
        Me.tpGenericList.Text = "Generic List"
        Me.tpGenericList.UseVisualStyleBackColor = True
        Me.tpGenericList.Visible = False
        '
        'metroPanel8
        '
        Me.metroPanel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel8.Controls.Add(Me.print_GenericList)
        Me.metroPanel8.Controls.Add(Me.design_GenericList)
        Me.metroPanel8.Controls.Add(Me.label79)
        Me.metroPanel8.Controls.Add(Me.label77)
        Me.metroPanel8.Controls.Add(Me.label76)
        Me.metroPanel8.Controls.Add(Me.label78)
        Me.metroPanel8.HorizontalScrollbarBarColor = True
        Me.metroPanel8.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel8.HorizontalScrollbarSize = 10
        Me.metroPanel8.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel8.Name = "metroPanel8"
        Me.metroPanel8.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel8.TabIndex = 30
        Me.metroPanel8.VerticalScrollbarBarColor = True
        Me.metroPanel8.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel8.VerticalScrollbarSize = 10
        '
        'print_GenericList
        '
        Me.print_GenericList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.print_GenericList.Location = New System.Drawing.Point(641, 59)
        Me.print_GenericList.Name = "print_GenericList"
        Me.print_GenericList.Size = New System.Drawing.Size(112, 24)
        Me.print_GenericList.TabIndex = 29
        Me.print_GenericList.Text = "&Print"
        Me.print_GenericList.UseSelectable = True
        '
        'design_GenericList
        '
        Me.design_GenericList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.design_GenericList.Location = New System.Drawing.Point(512, 59)
        Me.design_GenericList.Name = "design_GenericList"
        Me.design_GenericList.Size = New System.Drawing.Size(112, 24)
        Me.design_GenericList.TabIndex = 28
        Me.design_GenericList.Text = "&Design"
        Me.design_GenericList.UseSelectable = True
        '
        'label79
        '
        Me.label79.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label79.Location = New System.Drawing.Point(33, 15)
        Me.label79.Name = "label79"
        Me.label79.Size = New System.Drawing.Size(256, 32)
        Me.label79.TabIndex = 20
        Me.label79.Text = "Bindet die Komponente an eine generische Liste."
        Me.label79.WrapToLine = True
        '
        'label77
        '
        Me.label77.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label77.Location = New System.Drawing.Point(3, 15)
        Me.label77.Name = "label77"
        Me.label77.Size = New System.Drawing.Size(24, 16)
        Me.label77.TabIndex = 24
        Me.label77.Text = "D:"
        Me.label77.WrapToLine = True
        '
        'label76
        '
        Me.label76.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label76.Location = New System.Drawing.Point(346, 15)
        Me.label76.Name = "label76"
        Me.label76.Size = New System.Drawing.Size(24, 16)
        Me.label76.TabIndex = 23
        Me.label76.Text = "US:"
        '
        'label78
        '
        Me.label78.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label78.Location = New System.Drawing.Point(376, 15)
        Me.label78.Name = "label78"
        Me.label78.Size = New System.Drawing.Size(282, 32)
        Me.label78.TabIndex = 21
        Me.label78.Text = "Binds the component to a generic list."
        Me.label78.WrapToLine = True
        '
        'tabSQLServer
        '
        Me.tabSQLServer.Controls.Add(Me.metroPanel9)
        Me.tabSQLServer.Location = New System.Drawing.Point(4, 38)
        Me.tabSQLServer.Name = "tabSQLServer"
        Me.tabSQLServer.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSQLServer.Size = New System.Drawing.Size(755, 98)
        Me.tabSQLServer.TabIndex = 8
        Me.tabSQLServer.Text = "SQL Server"
        Me.tabSQLServer.UseVisualStyleBackColor = True
        Me.tabSQLServer.Visible = False
        '
        'metroPanel9
        '
        Me.metroPanel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel9.Controls.Add(Me.label115)
        Me.metroPanel9.Controls.Add(Me.print_SQL)
        Me.metroPanel9.Controls.Add(Me.design_SQL)
        Me.metroPanel9.Controls.Add(Me.label111)
        Me.metroPanel9.Controls.Add(Me.label114)
        Me.metroPanel9.Controls.Add(Me.label113)
        Me.metroPanel9.Controls.Add(Me.label112)
        Me.metroPanel9.Controls.Add(Me.tbConnectionString)
        Me.metroPanel9.HorizontalScrollbarBarColor = True
        Me.metroPanel9.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel9.HorizontalScrollbarSize = 10
        Me.metroPanel9.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel9.Name = "metroPanel9"
        Me.metroPanel9.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel9.TabIndex = 35
        Me.metroPanel9.VerticalScrollbarBarColor = True
        Me.metroPanel9.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel9.VerticalScrollbarSize = 10
        '
        'label115
        '
        Me.label115.AutoSize = True
        Me.label115.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label115.Location = New System.Drawing.Point(1, 64)
        Me.label115.Name = "label115"
        Me.label115.Size = New System.Drawing.Size(103, 15)
        Me.label115.TabIndex = 34
        Me.label115.Text = "Connection-String: "
        Me.label115.WrapToLine = True
        '
        'print_SQL
        '
        Me.print_SQL.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.print_SQL.Location = New System.Drawing.Point(641, 59)
        Me.print_SQL.Name = "print_SQL"
        Me.print_SQL.Size = New System.Drawing.Size(112, 24)
        Me.print_SQL.TabIndex = 33
        Me.print_SQL.Text = "&Print"
        Me.print_SQL.UseSelectable = True
        '
        'design_SQL
        '
        Me.design_SQL.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.design_SQL.Location = New System.Drawing.Point(512, 59)
        Me.design_SQL.Name = "design_SQL"
        Me.design_SQL.Size = New System.Drawing.Size(112, 24)
        Me.design_SQL.TabIndex = 32
        Me.design_SQL.Text = "&Design"
        Me.design_SQL.UseSelectable = True
        '
        'label111
        '
        Me.label111.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label111.Location = New System.Drawing.Point(346, 15)
        Me.label111.Name = "label111"
        Me.label111.Size = New System.Drawing.Size(24, 16)
        Me.label111.TabIndex = 27
        Me.label111.Text = "US:"
        Me.label111.WrapToLine = True
        '
        'label114
        '
        Me.label114.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label114.Location = New System.Drawing.Point(33, 15)
        Me.label114.Name = "label114"
        Me.label114.Size = New System.Drawing.Size(315, 32)
        Me.label114.TabIndex = 25
        Me.label114.Text = "Bindet die Komponente an einen SqlConnectionDataProvider."
        Me.label114.WrapToLine = True
        '
        'label113
        '
        Me.label113.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label113.Location = New System.Drawing.Point(376, 15)
        Me.label113.Name = "label113"
        Me.label113.Size = New System.Drawing.Size(298, 32)
        Me.label113.TabIndex = 26
        Me.label113.Text = "Binds the component to a SqlConnectionDataProvider."
        Me.label113.WrapToLine = True
        '
        'label112
        '
        Me.label112.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label112.Location = New System.Drawing.Point(3, 15)
        Me.label112.Name = "label112"
        Me.label112.Size = New System.Drawing.Size(24, 16)
        Me.label112.TabIndex = 28
        Me.label112.Text = "D:"
        Me.label112.WrapToLine = True
        '
        'tbConnectionString
        '
        Me.tbConnectionString.BackColor = System.Drawing.SystemColors.Window
        Me.tbConnectionString.Lines = New String() {"Data Source=<ComputerName>\SQLEXPRESS;Initial Catalog=<DatabaseName>;Integrated S" & _
            "ecurity=True"}
        Me.tbConnectionString.Location = New System.Drawing.Point(104, 61)
        Me.tbConnectionString.MaxLength = 32767
        Me.tbConnectionString.Name = "tbConnectionString"
        Me.tbConnectionString.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tbConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.tbConnectionString.SelectedText = ""
        Me.tbConnectionString.Size = New System.Drawing.Size(374, 20)
        Me.tbConnectionString.Style = MetroFramework.MetroColorStyle.Blue
        Me.tbConnectionString.TabIndex = 29
        Me.tbConnectionString.Text = "Data Source=<ComputerName>\SQLEXPRESS;Initial Catalog=<DatabaseName>;Integrated S" & _
    "ecurity=True"
        Me.tbConnectionString.UseCustomBackColor = True
        Me.tbConnectionString.UseSelectable = True
        Me.tbConnectionString.WordWrap = False
        '
        'tabOdata
        '
        Me.tabOdata.Controls.Add(Me.metroPanel10)
        Me.tabOdata.Location = New System.Drawing.Point(4, 38)
        Me.tabOdata.Name = "tabOdata"
        Me.tabOdata.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOdata.Size = New System.Drawing.Size(755, 98)
        Me.tabOdata.TabIndex = 9
        Me.tabOdata.Text = "OData"
        Me.tabOdata.UseVisualStyleBackColor = True
        Me.tabOdata.Visible = False
        '
        'metroPanel10
        '
        Me.metroPanel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel10.Controls.Add(Me.label116)
        Me.metroPanel10.Controls.Add(Me.printOdataBtn)
        Me.metroPanel10.Controls.Add(Me.label117)
        Me.metroPanel10.Controls.Add(Me.designOdataBtn)
        Me.metroPanel10.Controls.Add(Me.odataUrlTb)
        Me.metroPanel10.Controls.Add(Me.label119)
        Me.metroPanel10.Controls.Add(Me.label120)
        Me.metroPanel10.Controls.Add(Me.label118)
        Me.metroPanel10.HorizontalScrollbarBarColor = True
        Me.metroPanel10.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel10.HorizontalScrollbarSize = 10
        Me.metroPanel10.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel10.Name = "metroPanel10"
        Me.metroPanel10.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel10.TabIndex = 35
        Me.metroPanel10.VerticalScrollbarBarColor = True
        Me.metroPanel10.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel10.VerticalScrollbarSize = 10
        '
        'label116
        '
        Me.label116.AutoSize = True
        Me.label116.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label116.Location = New System.Drawing.Point(1, 64)
        Me.label116.Name = "label116"
        Me.label116.Size = New System.Drawing.Size(27, 15)
        Me.label116.TabIndex = 34
        Me.label116.Text = "Url: "
        Me.label116.WrapToLine = True
        '
        'printOdataBtn
        '
        Me.printOdataBtn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.printOdataBtn.Location = New System.Drawing.Point(641, 59)
        Me.printOdataBtn.Name = "printOdataBtn"
        Me.printOdataBtn.Size = New System.Drawing.Size(112, 24)
        Me.printOdataBtn.TabIndex = 33
        Me.printOdataBtn.Text = "&Print"
        Me.printOdataBtn.UseSelectable = True
        '
        'label117
        '
        Me.label117.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label117.Location = New System.Drawing.Point(346, 15)
        Me.label117.Name = "label117"
        Me.label117.Size = New System.Drawing.Size(24, 16)
        Me.label117.TabIndex = 27
        Me.label117.Text = "US:"
        Me.label117.WrapToLine = True
        '
        'designOdataBtn
        '
        Me.designOdataBtn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.designOdataBtn.Location = New System.Drawing.Point(512, 59)
        Me.designOdataBtn.Name = "designOdataBtn"
        Me.designOdataBtn.Size = New System.Drawing.Size(112, 24)
        Me.designOdataBtn.TabIndex = 32
        Me.designOdataBtn.Text = "&Design"
        Me.designOdataBtn.UseSelectable = True
        '
        'odataUrlTb
        '
        Me.odataUrlTb.BackColor = System.Drawing.SystemColors.Window
        Me.odataUrlTb.Lines = New String() {"http://services.odata.org/V3/Northwind/Northwind.svc/"}
        Me.odataUrlTb.Location = New System.Drawing.Point(31, 61)
        Me.odataUrlTb.MaxLength = 32767
        Me.odataUrlTb.Name = "odataUrlTb"
        Me.odataUrlTb.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.odataUrlTb.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.odataUrlTb.SelectedText = ""
        Me.odataUrlTb.Size = New System.Drawing.Size(447, 20)
        Me.odataUrlTb.Style = MetroFramework.MetroColorStyle.Blue
        Me.odataUrlTb.TabIndex = 29
        Me.odataUrlTb.Text = "http://services.odata.org/V3/Northwind/Northwind.svc/"
        Me.odataUrlTb.UseCustomBackColor = True
        Me.odataUrlTb.UseSelectable = True
        '
        'label119
        '
        Me.label119.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label119.Location = New System.Drawing.Point(376, 15)
        Me.label119.Name = "label119"
        Me.label119.Size = New System.Drawing.Size(272, 32)
        Me.label119.TabIndex = 26
        Me.label119.Text = "Binds the component to an ODataDataProvider."
        Me.label119.WrapToLine = True
        '
        'label120
        '
        Me.label120.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label120.Location = New System.Drawing.Point(33, 15)
        Me.label120.Name = "label120"
        Me.label120.Size = New System.Drawing.Size(272, 32)
        Me.label120.TabIndex = 25
        Me.label120.Text = "Bindet die Komponente an einen ODataDataProvider."
        Me.label120.WrapToLine = True
        '
        'label118
        '
        Me.label118.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label118.Location = New System.Drawing.Point(3, 15)
        Me.label118.Name = "label118"
        Me.label118.Size = New System.Drawing.Size(24, 16)
        Me.label118.TabIndex = 28
        Me.label118.Text = "D:"
        Me.label118.WrapToLine = True
        '
        'metroPanel11
        '
        Me.metroPanel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroPanel11.Controls.Add(Me.metroLabel1)
        Me.metroPanel11.Controls.Add(Me.restPrintBtn)
        Me.metroPanel11.Controls.Add(Me.restDesignBtn)
        Me.metroPanel11.Controls.Add(Me.label202)
        Me.metroPanel11.Controls.Add(Me.label205)
        Me.metroPanel11.Controls.Add(Me.label204)
        Me.metroPanel11.Controls.Add(Me.label203)
        Me.metroPanel11.Controls.Add(Me.restUrlTb)
        Me.metroPanel11.HorizontalScrollbarBarColor = True
        Me.metroPanel11.HorizontalScrollbarHighlightOnWheel = False
        Me.metroPanel11.HorizontalScrollbarSize = 10
        Me.metroPanel11.Location = New System.Drawing.Point(0, 0)
        Me.metroPanel11.Name = "metroPanel11"
        Me.metroPanel11.Size = New System.Drawing.Size(753, 98)
        Me.metroPanel11.TabIndex = 35
        Me.metroPanel11.VerticalScrollbarBarColor = True
        Me.metroPanel11.VerticalScrollbarHighlightOnWheel = False
        Me.metroPanel11.VerticalScrollbarSize = 10
        '
        'restUrlTb
        '
        Me.restUrlTb.BackColor = System.Drawing.SystemColors.Window
        Me.restUrlTb.Lines = New String() {"http://www.pegelonline.wsv.de/webservices/rest-api/v2/stations/KONSTANZ/W/measurements.json?start=P30D"}
        Me.restUrlTb.Location = New System.Drawing.Point(31, 61)
        Me.restUrlTb.MaxLength = 32767
        Me.restUrlTb.Name = "restUrlTb"
        Me.restUrlTb.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.restUrlTb.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.restUrlTb.SelectedText = ""
        Me.restUrlTb.Size = New System.Drawing.Size(447, 20)
        Me.restUrlTb.Style = MetroFramework.MetroColorStyle.Blue
        Me.restUrlTb.TabIndex = 29
        Me.restUrlTb.Text = "http://www.pegelonline.wsv.de/webservices/rest-api/v2/stations/KONSTANZ/W/measurements.json?start=P30D"
        Me.restUrlTb.UseCustomBackColor = True
        Me.restUrlTb.UseSelectable = True
        '
        'label203
        '
        Me.label203.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label203.Location = New System.Drawing.Point(3, 15)
        Me.label203.Name = "label203"
        Me.label203.Size = New System.Drawing.Size(24, 16)
        Me.label203.TabIndex = 28
        Me.label203.Text = "D:"
        Me.label203.WrapToLine = True
        '
        'label204
        '
        Me.label204.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label204.Location = New System.Drawing.Point(376, 15)
        Me.label204.Name = "label204"
        Me.label204.Size = New System.Drawing.Size(272, 32)
        Me.label204.TabIndex = 26
        Me.label204.Text = "Binds the component to a RestDataProvider."
        Me.label204.WrapToLine = True
        '
        'label205
        '
        Me.label205.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label205.Location = New System.Drawing.Point(33, 15)
        Me.label205.Name = "label205"
        Me.label205.Size = New System.Drawing.Size(269, 32)
        Me.label205.TabIndex = 25
        Me.label205.Text = "Bindet die Komponente an einen RestDataProvider."
        Me.label205.WrapToLine = True
        '
        'label202
        '
        Me.label202.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label202.Location = New System.Drawing.Point(346, 15)
        Me.label202.Name = "label202"
        Me.label202.Size = New System.Drawing.Size(24, 16)
        Me.label202.TabIndex = 27
        Me.label202.Text = "US:"
        Me.label202.WrapToLine = True
        '
        'restDesignBtn
        '
        Me.restDesignBtn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.restDesignBtn.Location = New System.Drawing.Point(512, 59)
        Me.restDesignBtn.Name = "restDesignBtn"
        Me.restDesignBtn.Size = New System.Drawing.Size(112, 24)
        Me.restDesignBtn.TabIndex = 32
        Me.restDesignBtn.Text = "&Design"
        Me.restDesignBtn.UseSelectable = True
        '
        'restPrintBtn
        '
        Me.restPrintBtn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.restPrintBtn.Location = New System.Drawing.Point(641, 59)
        Me.restPrintBtn.Name = "restPrintBtn"
        Me.restPrintBtn.Size = New System.Drawing.Size(112, 24)
        Me.restPrintBtn.TabIndex = 33
        Me.restPrintBtn.Text = "&Print"
        Me.restPrintBtn.UseSelectable = True
        '
        'metroLabel1
        '
        Me.metroLabel1.AutoSize = True
        Me.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.metroLabel1.Location = New System.Drawing.Point(1, 64)
        Me.metroLabel1.Name = "metroLabel1"
        Me.metroLabel1.Size = New System.Drawing.Size(27, 15)
        Me.metroLabel1.TabIndex = 35
        Me.metroLabel1.Text = "Url: "
        Me.metroLabel1.WrapToLine = True
        '
        'tabRest
        '
        Me.tabRest.Controls.Add(Me.metroPanel11)
        Me.tabRest.Location = New System.Drawing.Point(4, 38)
        Me.tabRest.Name = "tabRest"
        Me.tabRest.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRest.Size = New System.Drawing.Size(755, 98)
        Me.tabRest.TabIndex = 10
        Me.tabRest.Text = "REST"
        Me.tabRest.UseVisualStyleBackColor = True
        Me.tabRest.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(803, 750)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.LLPreviewControl)
        Me.Controls.Add(Me.statusBar1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(803, 750)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label Databinding VB.NET Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tabControl.ResumeLayout(False)
        Me.tpDataSet.ResumeLayout(False)
        Me.metroPanel2.ResumeLayout(False)
        Me.tpXML.ResumeLayout(False)
        Me.metroPanel5.ResumeLayout(False)
        Me.tpDataViewManager.ResumeLayout(False)
        Me.metroPanel3.ResumeLayout(False)
        Me.tpDataView.ResumeLayout(False)
        Me.metroPanel4.ResumeLayout(False)
        Me.tpDbCommand.ResumeLayout(False)
        Me.metroPanel6.ResumeLayout(False)
        Me.tpDataTable.ResumeLayout(False)
        Me.metroPanel7.ResumeLayout(False)
        Me.tpGenericList.ResumeLayout(False)
        Me.metroPanel8.ResumeLayout(False)
        Me.tabSQLServer.ResumeLayout(False)
        Me.metroPanel9.ResumeLayout(False)
        Me.metroPanel9.PerformLayout()
        Me.tabOdata.ResumeLayout(False)
        Me.metroPanel10.ResumeLayout(False)
        Me.metroPanel10.PerformLayout()
        Me.metroPanel11.ResumeLayout(False)
        Me.metroPanel11.PerformLayout()
        Me.tabRest.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

	#End Region

	Friend WithEvents LL As ListLabel
	Private WithEvents statusBar1 As System.Windows.Forms.StatusBar
	Friend WithEvents LLPreviewControl As ListLabelPreviewControl
	Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents tabControl As MetroFramework.Controls.MetroTabControl
    Private WithEvents tabOdata As System.Windows.Forms.TabPage
    Private WithEvents metroPanel10 As MetroFramework.Controls.MetroPanel
    Private WithEvents label116 As MetroFramework.Controls.MetroLabel
    Private WithEvents printOdataBtn As MetroFramework.Controls.MetroButton
    Private WithEvents label117 As MetroFramework.Controls.MetroLabel
    Private WithEvents designOdataBtn As MetroFramework.Controls.MetroButton
    Private WithEvents odataUrlTb As MetroFramework.Controls.MetroTextBox
    Private WithEvents label119 As MetroFramework.Controls.MetroLabel
    Private WithEvents label120 As MetroFramework.Controls.MetroLabel
    Private WithEvents label118 As MetroFramework.Controls.MetroLabel
    Private WithEvents tpDataSet As System.Windows.Forms.TabPage
    Private WithEvents metroPanel2 As MetroFramework.Controls.MetroPanel
    Private WithEvents design_DataSet As MetroFramework.Controls.MetroButton
    Private WithEvents print_DataSet As MetroFramework.Controls.MetroButton
    Private WithEvents label8 As MetroFramework.Controls.MetroLabel
    Private WithEvents label7 As MetroFramework.Controls.MetroLabel
    Private WithEvents label2 As MetroFramework.Controls.MetroLabel
    Private WithEvents label6 As MetroFramework.Controls.MetroLabel
    Private WithEvents tpXML As System.Windows.Forms.TabPage
    Private WithEvents metroPanel5 As MetroFramework.Controls.MetroPanel
    Private WithEvents print_XML As MetroFramework.Controls.MetroButton
    Private WithEvents design_XML As MetroFramework.Controls.MetroButton
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents tpDataViewManager As System.Windows.Forms.TabPage
    Private WithEvents metroPanel3 As MetroFramework.Controls.MetroPanel
    Private WithEvents cbCustomerNames As MetroFramework.Controls.MetroComboBox
    Private WithEvents print_DataViewManager As MetroFramework.Controls.MetroButton
    Private WithEvents label21 As MetroFramework.Controls.MetroLabel
    Private WithEvents design_DataViewManager As MetroFramework.Controls.MetroButton
    Private WithEvents label23 As MetroFramework.Controls.MetroLabel
    Private WithEvents label22 As MetroFramework.Controls.MetroLabel
    Private WithEvents label24 As MetroFramework.Controls.MetroLabel
    Private WithEvents tpDataView As System.Windows.Forms.TabPage
    Private WithEvents metroPanel4 As MetroFramework.Controls.MetroPanel
    Private WithEvents design_DataView As MetroFramework.Controls.MetroButton
    Private WithEvents print_DataView As MetroFramework.Controls.MetroButton
    Private WithEvents label20 As MetroFramework.Controls.MetroLabel
    Private WithEvents label17 As MetroFramework.Controls.MetroLabel
    Private WithEvents label18 As MetroFramework.Controls.MetroLabel
    Private WithEvents label19 As MetroFramework.Controls.MetroLabel
    Private WithEvents tpDbCommand As System.Windows.Forms.TabPage
    Private WithEvents metroPanel6 As MetroFramework.Controls.MetroPanel
    Private WithEvents print_Reader As MetroFramework.Controls.MetroButton
    Private WithEvents design_Reader As MetroFramework.Controls.MetroButton
    Private WithEvents label12 As MetroFramework.Controls.MetroLabel
    Private WithEvents label9 As MetroFramework.Controls.MetroLabel
    Private WithEvents label10 As MetroFramework.Controls.MetroLabel
    Private WithEvents label11 As MetroFramework.Controls.MetroLabel
    Private WithEvents tpDataTable As System.Windows.Forms.TabPage
    Private WithEvents metroPanel7 As MetroFramework.Controls.MetroPanel
    Private WithEvents design_DataTable As MetroFramework.Controls.MetroButton
    Private WithEvents print_DataTable As MetroFramework.Controls.MetroButton
    Private WithEvents label16 As MetroFramework.Controls.MetroLabel
    Private WithEvents label13 As MetroFramework.Controls.MetroLabel
    Private WithEvents label99 As MetroFramework.Controls.MetroLabel
    Private WithEvents label15 As MetroFramework.Controls.MetroLabel
    Private WithEvents tpGenericList As System.Windows.Forms.TabPage
    Private WithEvents metroPanel8 As MetroFramework.Controls.MetroPanel
    Private WithEvents print_GenericList As MetroFramework.Controls.MetroButton
    Private WithEvents design_GenericList As MetroFramework.Controls.MetroButton
    Private WithEvents label79 As MetroFramework.Controls.MetroLabel
    Private WithEvents label77 As MetroFramework.Controls.MetroLabel
    Private WithEvents label76 As MetroFramework.Controls.MetroLabel
    Private WithEvents label78 As MetroFramework.Controls.MetroLabel
    Private WithEvents tabSQLServer As System.Windows.Forms.TabPage
    Private WithEvents metroPanel9 As MetroFramework.Controls.MetroPanel
    Private WithEvents label115 As MetroFramework.Controls.MetroLabel
    Private WithEvents print_SQL As MetroFramework.Controls.MetroButton
    Private WithEvents design_SQL As MetroFramework.Controls.MetroButton
    Private WithEvents label111 As MetroFramework.Controls.MetroLabel
    Private WithEvents label114 As MetroFramework.Controls.MetroLabel
    Private WithEvents label113 As MetroFramework.Controls.MetroLabel
    Private WithEvents label112 As MetroFramework.Controls.MetroLabel
    Private WithEvents tbConnectionString As MetroFramework.Controls.MetroTextBox
    Private WithEvents tabRest As System.Windows.Forms.TabPage
    Private WithEvents metroPanel11 As MetroFramework.Controls.MetroPanel
    Private WithEvents metroLabel1 As MetroFramework.Controls.MetroLabel
    Private WithEvents restPrintBtn As MetroFramework.Controls.MetroButton
    Private WithEvents restDesignBtn As MetroFramework.Controls.MetroButton
    Private WithEvents label202 As MetroFramework.Controls.MetroLabel
    Private WithEvents label205 As MetroFramework.Controls.MetroLabel
    Private WithEvents label204 As MetroFramework.Controls.MetroLabel
    Private WithEvents label203 As MetroFramework.Controls.MetroLabel
    Private WithEvents restUrlTb As MetroFramework.Controls.MetroTextBox
End Class

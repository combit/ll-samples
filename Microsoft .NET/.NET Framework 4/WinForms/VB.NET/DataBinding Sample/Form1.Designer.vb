Imports combit.Reporting
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
		Me.LL = new combit.Reporting.ListLabel(Me.components)
		Me.statusBar1 = New System.Windows.Forms.StatusBar()
		Me.LLPreviewControl = new combit.Reporting.ListLabelPreviewControl(Me.components)
		Me.progressBar1 = New System.Windows.Forms.ProgressBar()
		Me.tabControl = New System.Windows.Forms.TabControl()
		Me.tpDataSet = New System.Windows.Forms.TabPage()
		Me.panel2 = New System.Windows.Forms.Panel()
		Me.design_DataSet = New System.Windows.Forms.Button()
		Me.print_DataSet = New System.Windows.Forms.Button()
		Me.label8 = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
		Me.tpXML = New System.Windows.Forms.TabPage()
		Me.panel5 = New System.Windows.Forms.Panel()
		Me.print_XML = New System.Windows.Forms.Button()
		Me.design_XML = New System.Windows.Forms.Button()
		Me.label3 = New System.Windows.Forms.Label()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.tpDataViewManager = New System.Windows.Forms.TabPage()
		Me.panel3 = New System.Windows.Forms.Panel()
		Me.cbCustomerNames = New System.Windows.Forms.ComboBox()
		Me.print_DataViewManager = New System.Windows.Forms.Button()
		Me.label21 = New System.Windows.Forms.Label()
		Me.design_DataViewManager = New System.Windows.Forms.Button()
		Me.label23 = New System.Windows.Forms.Label()
		Me.label22 = New System.Windows.Forms.Label()
		Me.label24 = New System.Windows.Forms.Label()
		Me.tpDataView = New System.Windows.Forms.TabPage()
		Me.panel4 = New System.Windows.Forms.Panel()
		Me.design_DataView = New System.Windows.Forms.Button()
		Me.print_DataView = New System.Windows.Forms.Button()
		Me.label20 = New System.Windows.Forms.Label()
		Me.label17 = New System.Windows.Forms.Label()
		Me.label18 = New System.Windows.Forms.Label()
		Me.label19 = New System.Windows.Forms.Label()
		Me.tpDbCommand = New System.Windows.Forms.TabPage()
		Me.panel6 = New System.Windows.Forms.Panel()
		Me.print_Reader = New System.Windows.Forms.Button()
		Me.design_Reader = New System.Windows.Forms.Button()
		Me.label12 = New System.Windows.Forms.Label()
		Me.label9 = New System.Windows.Forms.Label()
		Me.label10 = New System.Windows.Forms.Label()
		Me.label11 = New System.Windows.Forms.Label()
		Me.tpDataTable = New System.Windows.Forms.TabPage()
		Me.panel7 = New System.Windows.Forms.Panel()
		Me.design_DataTable = New System.Windows.Forms.Button()
		Me.print_DataTable = New System.Windows.Forms.Button()
		Me.label16 = New System.Windows.Forms.Label()
		Me.label13 = New System.Windows.Forms.Label()
		Me.label99 = New System.Windows.Forms.Label()
		Me.label15 = New System.Windows.Forms.Label()
		Me.tpGenericList = New System.Windows.Forms.TabPage()
		Me.panel8 = New System.Windows.Forms.Panel()
		Me.print_GenericList = New System.Windows.Forms.Button()
		Me.design_GenericList = New System.Windows.Forms.Button()
		Me.label79 = New System.Windows.Forms.Label()
		Me.label77 = New System.Windows.Forms.Label()
		Me.label76 = New System.Windows.Forms.Label()
		Me.label78 = New System.Windows.Forms.Label()
		Me.tabSQLServer = New System.Windows.Forms.TabPage()
		Me.panel9 = New System.Windows.Forms.Panel()
		Me.label115 = New System.Windows.Forms.Label()
		Me.print_SQL = New System.Windows.Forms.Button()
		Me.design_SQL = New System.Windows.Forms.Button()
		Me.label111 = New System.Windows.Forms.Label()
		Me.label114 = New System.Windows.Forms.Label()
		Me.label113 = New System.Windows.Forms.Label()
		Me.label112 = New System.Windows.Forms.Label()
		Me.tbConnectionString = New System.Windows.Forms.TextBox()
		Me.tabOdata = New System.Windows.Forms.TabPage()
		Me.panel10 = New System.Windows.Forms.Panel()
		Me.label116 = New System.Windows.Forms.Label()
		Me.printOdataBtn = New System.Windows.Forms.Button()
		Me.label117 = New System.Windows.Forms.Label()
		Me.designOdataBtn = New System.Windows.Forms.Button()
		Me.odataUrlTb = New System.Windows.Forms.TextBox()
		Me.label119 = New System.Windows.Forms.Label()
		Me.label120 = New System.Windows.Forms.Label()
		Me.label118 = New System.Windows.Forms.Label()
		Me.tabRest = New System.Windows.Forms.TabPage()
		Me.panel11 = New System.Windows.Forms.Panel()
		Me.label206 = New System.Windows.Forms.Label()
		Me.restPrintBtn = New System.Windows.Forms.Button()
		Me.restDesignBtn = New System.Windows.Forms.Button()
		Me.label202 = New System.Windows.Forms.Label()
		Me.label205 = New System.Windows.Forms.Label()
		Me.label204 = New System.Windows.Forms.Label()
		Me.label203 = New System.Windows.Forms.Label()
		Me.restUrlTb = New System.Windows.Forms.TextBox()
		Me.tabControl.SuspendLayout()
		Me.tpDataSet.SuspendLayout()
		Me.panel2.SuspendLayout()
		Me.tpXML.SuspendLayout()
		Me.panel5.SuspendLayout()
		Me.tpDataViewManager.SuspendLayout()
		Me.panel3.SuspendLayout()
		Me.tpDataView.SuspendLayout()
		Me.panel4.SuspendLayout()
		Me.tpDbCommand.SuspendLayout()
		Me.panel6.SuspendLayout()
		Me.tpDataTable.SuspendLayout()
		Me.panel7.SuspendLayout()
		Me.tpGenericList.SuspendLayout()
		Me.panel8.SuspendLayout()
		Me.tabSQLServer.SuspendLayout()
		Me.panel9.SuspendLayout()
		Me.tabOdata.SuspendLayout()
		Me.panel10.SuspendLayout()
		Me.tabRest.SuspendLayout()
		Me.panel11.SuspendLayout()
		Me.SuspendLayout()
		'
		'LL
		'
		Me.LL.AutoPrinterSettingsStream = Nothing
		Me.LL.AutoProjectStream = Nothing
		Me.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad
		Me.LL.DrilldownAvailable = True
		Me.LL.EMFResolution = 100
		Me.LL.FileRepository = Nothing
		Me.LL.GenericMaximumRecordCount = -1
		Me.LL.LockNextChar = 8288
		Me.LL.MaxRTFVersion = 65280
		Me.LL.PhantomSpace = 8203
		Me.LL.PreviewControl = Nothing
		Me.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_100
		Me.LL.UseHardwareCopiesForLabels = False
		Me.LL.UseTableSchemaForDesignMode = False
		'
		'statusBar1
		'
		Me.statusBar1.Location = New System.Drawing.Point(0, 539)
		Me.statusBar1.Name = "statusBar1"
		Me.statusBar1.Size = New System.Drawing.Size(784, 22)
		Me.statusBar1.TabIndex = 13
		'
		'LLPreviewControl
		'
		Me.LLPreviewControl.AllowRbuttonUsage = True
		Me.LLPreviewControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LLPreviewControl.BackColor = System.Drawing.SystemColors.Window
		Me.LLPreviewControl.CloseMode = combit.Reporting.LlPreviewControlCloseMode.DeleteFile
		Me.LLPreviewControl.CurrentPage = 0
		Me.LLPreviewControl.ForceReadOnly = False
		Me.LLPreviewControl.Location = New System.Drawing.Point(10, 134)
		Me.LLPreviewControl.Name = "LLPreviewControl"
		Me.LLPreviewControl.Size = New System.Drawing.Size(767, 404)
		Me.LLPreviewControl.SlideshowMode = False
		Me.LLPreviewControl.TabIndex = 14
		Me.LLPreviewControl.Text = "listLabelPreviewControl1"
		Me.LLPreviewControl.ToolbarButtons.Exit = combit.Reporting.LlButtonState.Invisible
		Me.LLPreviewControl.ToolbarButtons.GotoFirst = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.GotoLast = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.GotoNext = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.GotoPrev = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.MouseModeMove = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.MouseModeZoom = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.NextFile = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.PageRange = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.PreviousFile = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.PrintAllPages = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.PrintCurrentPage = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.PrintToFax = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.SaveAs = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.SearchNext = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.SearchOptions = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.SearchStart = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.SearchText = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.SendTo = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.SlideshowMode = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.ZoomCombo = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.ZoomReset = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.ZoomRevert = combit.Reporting.LlButtonState.[Default]
		Me.LLPreviewControl.ToolbarButtons.ZoomTimes2 = combit.Reporting.LlButtonState.[Default]
		'
		'progressBar1
		'
		Me.progressBar1.Location = New System.Drawing.Point(1, 732)
		Me.progressBar1.Name = "progressBar1"
		Me.progressBar1.Size = New System.Drawing.Size(144, 16)
		Me.progressBar1.TabIndex = 16
		Me.progressBar1.Visible = False
		'
		'tabControl
		'
		Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
		Me.tabControl.Location = New System.Drawing.Point(0, 0)
		Me.tabControl.Name = "tabControl"
		Me.tabControl.SelectedIndex = 0
		Me.tabControl.Size = New System.Drawing.Size(784, 124)
		Me.tabControl.TabIndex = 17
		'
		'tpDataSet
		'
		Me.tpDataSet.Controls.Add(Me.panel2)
		Me.tpDataSet.Location = New System.Drawing.Point(4, 22)
		Me.tpDataSet.Name = "tpDataSet"
		Me.tpDataSet.Size = New System.Drawing.Size(776, 98)
		Me.tpDataSet.TabIndex = 0
		Me.tpDataSet.Text = "DataSet"
		'
		'panel2
		'
		Me.panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel2.Controls.Add(Me.design_DataSet)
		Me.panel2.Controls.Add(Me.print_DataSet)
		Me.panel2.Controls.Add(Me.label8)
		Me.panel2.Controls.Add(Me.label7)
		Me.panel2.Controls.Add(Me.label2)
		Me.panel2.Controls.Add(Me.label6)
		Me.panel2.Location = New System.Drawing.Point(0, 0)
		Me.panel2.Name = "panel2"
		Me.panel2.Size = New System.Drawing.Size(774, 98)
		Me.panel2.TabIndex = 18
		'
		'design_DataSet
		'
		Me.design_DataSet.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.design_DataSet.Location = New System.Drawing.Point(533, 59)
		Me.design_DataSet.Name = "design_DataSet"
		Me.design_DataSet.Size = New System.Drawing.Size(112, 24)
		Me.design_DataSet.TabIndex = 16
		Me.design_DataSet.Text = "&Design"
		'
		'print_DataSet
		'
		Me.print_DataSet.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.print_DataSet.Location = New System.Drawing.Point(662, 59)
		Me.print_DataSet.Name = "print_DataSet"
		Me.print_DataSet.Size = New System.Drawing.Size(112, 24)
		Me.print_DataSet.TabIndex = 17
		Me.print_DataSet.Text = "&Print"
		'
		'label8
		'
		Me.label8.Location = New System.Drawing.Point(33, 15)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(272, 32)
		Me.label8.TabIndex = 12
		Me.label8.Text = "Bindet die Komponente an ein dynamisch erstelltes DataSet-Objekt mit DataRelation" &
	"s."
		'
		'label7
		'
		Me.label7.Location = New System.Drawing.Point(376, 15)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(272, 32)
		Me.label7.TabIndex = 13
		Me.label7.Text = "Binds the component to a dynamically created DataSet containing DataRelations."
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(346, 15)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(24, 24)
		Me.label2.TabIndex = 14
		Me.label2.Text = "US:"
		'
		'label6
		'
		Me.label6.Location = New System.Drawing.Point(3, 15)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(24, 16)
		Me.label6.TabIndex = 15
		Me.label6.Text = "D:"
		'
		'tpXML
		'
		Me.tpXML.Controls.Add(Me.panel5)
		Me.tpXML.Location = New System.Drawing.Point(4, 22)
		Me.tpXML.Name = "tpXML"
		Me.tpXML.Size = New System.Drawing.Size(776, 98)
		Me.tpXML.TabIndex = 5
		Me.tpXML.Text = "XML"
		Me.tpXML.Visible = False
		'
		'panel5
		'
		Me.panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel5.Controls.Add(Me.print_XML)
		Me.panel5.Controls.Add(Me.design_XML)
		Me.panel5.Controls.Add(Me.label3)
		Me.panel5.Controls.Add(Me.label1)
		Me.panel5.Controls.Add(Me.label5)
		Me.panel5.Controls.Add(Me.label4)
		Me.panel5.Location = New System.Drawing.Point(0, 0)
		Me.panel5.Name = "panel5"
		Me.panel5.Size = New System.Drawing.Size(774, 98)
		Me.panel5.TabIndex = 22
		'
		'print_XML
		'
		Me.print_XML.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.print_XML.Location = New System.Drawing.Point(662, 59)
		Me.print_XML.Name = "print_XML"
		Me.print_XML.Size = New System.Drawing.Size(112, 24)
		Me.print_XML.TabIndex = 21
		Me.print_XML.Text = "&Print"
		'
		'design_XML
		'
		Me.design_XML.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.design_XML.Location = New System.Drawing.Point(533, 59)
		Me.design_XML.Name = "design_XML"
		Me.design_XML.Size = New System.Drawing.Size(112, 24)
		Me.design_XML.TabIndex = 20
		Me.design_XML.Text = "&Design"
		'
		'label3
		'
		Me.label3.Location = New System.Drawing.Point(3, 15)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(24, 16)
		Me.label3.TabIndex = 19
		Me.label3.Text = "D:"
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(346, 15)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(24, 16)
		Me.label1.TabIndex = 18
		Me.label1.Text = "US:"
		'
		'label5
		'
		Me.label5.Location = New System.Drawing.Point(33, 15)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(256, 32)
		Me.label5.TabIndex = 16
		Me.label5.Text = "Bindet die Komponente an die Beispiel XML-Datei."
		'
		'label4
		'
		Me.label4.Location = New System.Drawing.Point(376, 15)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(272, 32)
		Me.label4.TabIndex = 17
		Me.label4.Text = "Binds the component to the sample XML file."
		'
		'tpDataViewManager
		'
		Me.tpDataViewManager.Controls.Add(Me.panel3)
		Me.tpDataViewManager.Location = New System.Drawing.Point(4, 22)
		Me.tpDataViewManager.Name = "tpDataViewManager"
		Me.tpDataViewManager.Size = New System.Drawing.Size(776, 98)
		Me.tpDataViewManager.TabIndex = 6
		Me.tpDataViewManager.Text = "DataViewManager"
		Me.tpDataViewManager.Visible = False
		'
		'panel3
		'
		Me.panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel3.Controls.Add(Me.cbCustomerNames)
		Me.panel3.Controls.Add(Me.print_DataViewManager)
		Me.panel3.Controls.Add(Me.label21)
		Me.panel3.Controls.Add(Me.design_DataViewManager)
		Me.panel3.Controls.Add(Me.label23)
		Me.panel3.Controls.Add(Me.label22)
		Me.panel3.Controls.Add(Me.label24)
		Me.panel3.Location = New System.Drawing.Point(0, 0)
		Me.panel3.Name = "panel3"
		Me.panel3.Size = New System.Drawing.Size(774, 98)
		Me.panel3.TabIndex = 33
		'
		'cbCustomerNames
		'
		Me.cbCustomerNames.ItemHeight = 13
		Me.cbCustomerNames.Location = New System.Drawing.Point(33, 60)
		Me.cbCustomerNames.Name = "cbCustomerNames"
		Me.cbCustomerNames.Size = New System.Drawing.Size(296, 21)
		Me.cbCustomerNames.TabIndex = 32
		'
		'print_DataViewManager
		'
		Me.print_DataViewManager.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.print_DataViewManager.Location = New System.Drawing.Point(662, 59)
		Me.print_DataViewManager.Name = "print_DataViewManager"
		Me.print_DataViewManager.Size = New System.Drawing.Size(112, 24)
		Me.print_DataViewManager.TabIndex = 31
		Me.print_DataViewManager.Text = "&Print"
		'
		'label21
		'
		Me.label21.Location = New System.Drawing.Point(346, 15)
		Me.label21.Name = "label21"
		Me.label21.Size = New System.Drawing.Size(24, 24)
		Me.label21.TabIndex = 28
		Me.label21.Text = "US:"
		'
		'design_DataViewManager
		'
		Me.design_DataViewManager.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.design_DataViewManager.Location = New System.Drawing.Point(533, 59)
		Me.design_DataViewManager.Name = "design_DataViewManager"
		Me.design_DataViewManager.Size = New System.Drawing.Size(112, 24)
		Me.design_DataViewManager.TabIndex = 30
		Me.design_DataViewManager.Text = "&Design"
		'
		'label23
		'
		Me.label23.Location = New System.Drawing.Point(376, 15)
		Me.label23.Name = "label23"
		Me.label23.Size = New System.Drawing.Size(272, 32)
		Me.label23.TabIndex = 27
		Me.label23.Text = "Binds the component to a DataView object. Choose a filter for the company name."
		'
		'label22
		'
		Me.label22.Location = New System.Drawing.Point(3, 15)
		Me.label22.Name = "label22"
		Me.label22.Size = New System.Drawing.Size(24, 24)
		Me.label22.TabIndex = 29
		Me.label22.Text = "D:"
		'
		'label24
		'
		Me.label24.Location = New System.Drawing.Point(33, 15)
		Me.label24.Name = "label24"
		Me.label24.Size = New System.Drawing.Size(292, 40)
		Me.label24.TabIndex = 26
		Me.label24.Text = "Bindet die Komponente an ein DataViewManager-Objekt. Sie können einen Filter für " &
	"den Firmennamen wählen."
		'
		'tpDataView
		'
		Me.tpDataView.Controls.Add(Me.panel4)
		Me.tpDataView.Location = New System.Drawing.Point(4, 22)
		Me.tpDataView.Name = "tpDataView"
		Me.tpDataView.Size = New System.Drawing.Size(776, 98)
		Me.tpDataView.TabIndex = 3
		Me.tpDataView.Text = "DataView"
		Me.tpDataView.Visible = False
		'
		'panel4
		'
		Me.panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel4.Controls.Add(Me.design_DataView)
		Me.panel4.Controls.Add(Me.print_DataView)
		Me.panel4.Controls.Add(Me.label20)
		Me.panel4.Controls.Add(Me.label17)
		Me.panel4.Controls.Add(Me.label18)
		Me.panel4.Controls.Add(Me.label19)
		Me.panel4.Location = New System.Drawing.Point(0, 0)
		Me.panel4.Name = "panel4"
		Me.panel4.Size = New System.Drawing.Size(774, 98)
		Me.panel4.TabIndex = 26
		'
		'design_DataView
		'
		Me.design_DataView.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.design_DataView.Location = New System.Drawing.Point(533, 59)
		Me.design_DataView.Name = "design_DataView"
		Me.design_DataView.Size = New System.Drawing.Size(112, 24)
		Me.design_DataView.TabIndex = 24
		Me.design_DataView.Text = "&Design"
		'
		'print_DataView
		'
		Me.print_DataView.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.print_DataView.Location = New System.Drawing.Point(662, 59)
		Me.print_DataView.Name = "print_DataView"
		Me.print_DataView.Size = New System.Drawing.Size(112, 24)
		Me.print_DataView.TabIndex = 25
		Me.print_DataView.Text = "&Print"
		'
		'label20
		'
		Me.label20.Location = New System.Drawing.Point(33, 15)
		Me.label20.Name = "label20"
		Me.label20.Size = New System.Drawing.Size(256, 32)
		Me.label20.TabIndex = 16
		Me.label20.Text = "Bindet die Komponente an ein DataView-Objekt."
		'
		'label17
		'
		Me.label17.Location = New System.Drawing.Point(346, 15)
		Me.label17.Name = "label17"
		Me.label17.Size = New System.Drawing.Size(24, 16)
		Me.label17.TabIndex = 18
		Me.label17.Text = "US:"
		'
		'label18
		'
		Me.label18.Location = New System.Drawing.Point(3, 15)
		Me.label18.Name = "label18"
		Me.label18.Size = New System.Drawing.Size(24, 16)
		Me.label18.TabIndex = 19
		Me.label18.Text = "D:"
		'
		'label19
		'
		Me.label19.Location = New System.Drawing.Point(376, 15)
		Me.label19.Name = "label19"
		Me.label19.Size = New System.Drawing.Size(272, 32)
		Me.label19.TabIndex = 17
		Me.label19.Text = "Binds the component to a DataView object."
		'
		'tpDbCommand
		'
		Me.tpDbCommand.Controls.Add(Me.panel6)
		Me.tpDbCommand.Location = New System.Drawing.Point(4, 22)
		Me.tpDbCommand.Name = "tpDbCommand"
		Me.tpDbCommand.Size = New System.Drawing.Size(776, 98)
		Me.tpDbCommand.TabIndex = 1
		Me.tpDbCommand.Text = "DbCommand"
		Me.tpDbCommand.Visible = False
		'
		'panel6
		'
		Me.panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel6.Controls.Add(Me.print_Reader)
		Me.panel6.Controls.Add(Me.design_Reader)
		Me.panel6.Controls.Add(Me.label12)
		Me.panel6.Controls.Add(Me.label9)
		Me.panel6.Controls.Add(Me.label10)
		Me.panel6.Controls.Add(Me.label11)
		Me.panel6.Location = New System.Drawing.Point(0, 0)
		Me.panel6.Name = "panel6"
		Me.panel6.Size = New System.Drawing.Size(774, 98)
		Me.panel6.TabIndex = 25
		'
		'print_Reader
		'
		Me.print_Reader.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.print_Reader.Location = New System.Drawing.Point(662, 59)
		Me.print_Reader.Name = "print_Reader"
		Me.print_Reader.Size = New System.Drawing.Size(112, 24)
		Me.print_Reader.TabIndex = 23
		Me.print_Reader.Text = "&Print"
		'
		'design_Reader
		'
		Me.design_Reader.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.design_Reader.Location = New System.Drawing.Point(533, 59)
		Me.design_Reader.Name = "design_Reader"
		Me.design_Reader.Size = New System.Drawing.Size(112, 24)
		Me.design_Reader.TabIndex = 22
		Me.design_Reader.Text = "&Design"
		'
		'label12
		'
		Me.label12.Location = New System.Drawing.Point(33, 15)
		Me.label12.Name = "label12"
		Me.label12.Size = New System.Drawing.Size(287, 32)
		Me.label12.TabIndex = 24
		Me.label12.Text = "Bindet die Komponente an ein OleDbCommand-Objekt."
		'
		'label9
		'
		Me.label9.Location = New System.Drawing.Point(346, 15)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(24, 16)
		Me.label9.TabIndex = 18
		Me.label9.Text = "US:"
		'
		'label10
		'
		Me.label10.Location = New System.Drawing.Point(3, 15)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(24, 16)
		Me.label10.TabIndex = 19
		Me.label10.Text = "D:"
		'
		'label11
		'
		Me.label11.Location = New System.Drawing.Point(376, 15)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(272, 32)
		Me.label11.TabIndex = 17
		Me.label11.Text = "Binds the component to an OleDbCommand object."
		'
		'tpDataTable
		'
		Me.tpDataTable.Controls.Add(Me.panel7)
		Me.tpDataTable.Location = New System.Drawing.Point(4, 22)
		Me.tpDataTable.Name = "tpDataTable"
		Me.tpDataTable.Size = New System.Drawing.Size(776, 98)
		Me.tpDataTable.TabIndex = 2
		Me.tpDataTable.Text = "DataTable"
		Me.tpDataTable.Visible = False
		'
		'panel7
		'
		Me.panel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel7.Controls.Add(Me.design_DataTable)
		Me.panel7.Controls.Add(Me.print_DataTable)
		Me.panel7.Controls.Add(Me.label16)
		Me.panel7.Controls.Add(Me.label13)
		Me.panel7.Controls.Add(Me.label99)
		Me.panel7.Controls.Add(Me.label15)
		Me.panel7.Location = New System.Drawing.Point(0, 0)
		Me.panel7.Name = "panel7"
		Me.panel7.Size = New System.Drawing.Size(774, 98)
		Me.panel7.TabIndex = 28
		'
		'design_DataTable
		'
		Me.design_DataTable.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.design_DataTable.Location = New System.Drawing.Point(533, 59)
		Me.design_DataTable.Name = "design_DataTable"
		Me.design_DataTable.Size = New System.Drawing.Size(112, 24)
		Me.design_DataTable.TabIndex = 26
		Me.design_DataTable.Text = "&Design"
		'
		'print_DataTable
		'
		Me.print_DataTable.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.print_DataTable.Location = New System.Drawing.Point(662, 59)
		Me.print_DataTable.Name = "print_DataTable"
		Me.print_DataTable.Size = New System.Drawing.Size(112, 24)
		Me.print_DataTable.TabIndex = 27
		Me.print_DataTable.Text = "&Print"
		'
		'label16
		'
		Me.label16.Location = New System.Drawing.Point(33, 15)
		Me.label16.Name = "label16"
		Me.label16.Size = New System.Drawing.Size(256, 32)
		Me.label16.TabIndex = 16
		Me.label16.Text = "Bindet die Komponente an ein DataTable-Objekt."
		'
		'label13
		'
		Me.label13.Location = New System.Drawing.Point(346, 15)
		Me.label13.Name = "label13"
		Me.label13.Size = New System.Drawing.Size(24, 16)
		Me.label13.TabIndex = 18
		Me.label13.Text = "US:"
		'
		'label99
		'
		Me.label99.Location = New System.Drawing.Point(3, 15)
		Me.label99.Name = "label99"
		Me.label99.Size = New System.Drawing.Size(24, 16)
		Me.label99.TabIndex = 19
		Me.label99.Text = "D:"
		'
		'label15
		'
		Me.label15.Location = New System.Drawing.Point(376, 15)
		Me.label15.Name = "label15"
		Me.label15.Size = New System.Drawing.Size(272, 32)
		Me.label15.TabIndex = 17
		Me.label15.Text = "Binds the component to a DataTable object."
		'
		'tpGenericList
		'
		Me.tpGenericList.Controls.Add(Me.panel8)
		Me.tpGenericList.Location = New System.Drawing.Point(4, 22)
		Me.tpGenericList.Name = "tpGenericList"
		Me.tpGenericList.Padding = New System.Windows.Forms.Padding(3)
		Me.tpGenericList.Size = New System.Drawing.Size(776, 98)
		Me.tpGenericList.TabIndex = 7
		Me.tpGenericList.Text = "Generic List"
		Me.tpGenericList.Visible = False
		'
		'panel8
		'
		Me.panel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel8.Controls.Add(Me.print_GenericList)
		Me.panel8.Controls.Add(Me.design_GenericList)
		Me.panel8.Controls.Add(Me.label79)
		Me.panel8.Controls.Add(Me.label77)
		Me.panel8.Controls.Add(Me.label76)
		Me.panel8.Controls.Add(Me.label78)
		Me.panel8.Location = New System.Drawing.Point(0, 0)
		Me.panel8.Name = "panel8"
		Me.panel8.Size = New System.Drawing.Size(774, 98)
		Me.panel8.TabIndex = 30
		'
		'print_GenericList
		'
		Me.print_GenericList.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.print_GenericList.Location = New System.Drawing.Point(662, 59)
		Me.print_GenericList.Name = "print_GenericList"
		Me.print_GenericList.Size = New System.Drawing.Size(112, 24)
		Me.print_GenericList.TabIndex = 29
		Me.print_GenericList.Text = "&Print"
		'
		'design_GenericList
		'
		Me.design_GenericList.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.design_GenericList.Location = New System.Drawing.Point(533, 59)
		Me.design_GenericList.Name = "design_GenericList"
		Me.design_GenericList.Size = New System.Drawing.Size(112, 24)
		Me.design_GenericList.TabIndex = 28
		Me.design_GenericList.Text = "&Design"
		'
		'label79
		'
		Me.label79.Location = New System.Drawing.Point(33, 15)
		Me.label79.Name = "label79"
		Me.label79.Size = New System.Drawing.Size(256, 32)
		Me.label79.TabIndex = 20
		Me.label79.Text = "Bindet die Komponente an eine generische Liste."
		'
		'label77
		'
		Me.label77.Location = New System.Drawing.Point(3, 15)
		Me.label77.Name = "label77"
		Me.label77.Size = New System.Drawing.Size(24, 16)
		Me.label77.TabIndex = 24
		Me.label77.Text = "D:"
		'
		'label76
		'
		Me.label76.Location = New System.Drawing.Point(346, 15)
		Me.label76.Name = "label76"
		Me.label76.Size = New System.Drawing.Size(24, 16)
		Me.label76.TabIndex = 23
		Me.label76.Text = "US:"
		'
		'label78
		'
		Me.label78.Location = New System.Drawing.Point(376, 15)
		Me.label78.Name = "label78"
		Me.label78.Size = New System.Drawing.Size(282, 32)
		Me.label78.TabIndex = 21
		Me.label78.Text = "Binds the component to a generic list."
		'
		'tabSQLServer
		'
		Me.tabSQLServer.Controls.Add(Me.panel9)
		Me.tabSQLServer.Location = New System.Drawing.Point(4, 22)
		Me.tabSQLServer.Name = "tabSQLServer"
		Me.tabSQLServer.Padding = New System.Windows.Forms.Padding(3)
		Me.tabSQLServer.Size = New System.Drawing.Size(776, 98)
		Me.tabSQLServer.TabIndex = 8
		Me.tabSQLServer.Text = "SQL Server"
		Me.tabSQLServer.Visible = False
		'
		'panel9
		'
		Me.panel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel9.Controls.Add(Me.label115)
		Me.panel9.Controls.Add(Me.print_SQL)
		Me.panel9.Controls.Add(Me.design_SQL)
		Me.panel9.Controls.Add(Me.label111)
		Me.panel9.Controls.Add(Me.label114)
		Me.panel9.Controls.Add(Me.label113)
		Me.panel9.Controls.Add(Me.label112)
		Me.panel9.Controls.Add(Me.tbConnectionString)
		Me.panel9.Location = New System.Drawing.Point(0, 0)
		Me.panel9.Name = "panel9"
		Me.panel9.Size = New System.Drawing.Size(774, 98)
		Me.panel9.TabIndex = 35
		'
		'label115
		'
		Me.label115.AutoSize = True
		Me.label115.Location = New System.Drawing.Point(1, 64)
		Me.label115.Name = "label115"
		Me.label115.Size = New System.Drawing.Size(97, 13)
		Me.label115.TabIndex = 34
		Me.label115.Text = "Connection-String: "
		'
		'print_SQL
		'
		Me.print_SQL.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.print_SQL.Location = New System.Drawing.Point(662, 59)
		Me.print_SQL.Name = "print_SQL"
		Me.print_SQL.Size = New System.Drawing.Size(112, 24)
		Me.print_SQL.TabIndex = 33
		Me.print_SQL.Text = "&Print"
		'
		'design_SQL
		'
		Me.design_SQL.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.design_SQL.Location = New System.Drawing.Point(533, 59)
		Me.design_SQL.Name = "design_SQL"
		Me.design_SQL.Size = New System.Drawing.Size(112, 24)
		Me.design_SQL.TabIndex = 32
		Me.design_SQL.Text = "&Design"
		'
		'label111
		'
		Me.label111.Location = New System.Drawing.Point(346, 15)
		Me.label111.Name = "label111"
		Me.label111.Size = New System.Drawing.Size(24, 16)
		Me.label111.TabIndex = 27
		Me.label111.Text = "US:"
		'
		'label114
		'
		Me.label114.Location = New System.Drawing.Point(33, 15)
		Me.label114.Name = "label114"
		Me.label114.Size = New System.Drawing.Size(315, 32)
		Me.label114.TabIndex = 25
		Me.label114.Text = "Bindet die Komponente an einen SqlConnectionDataProvider."
		'
		'label113
		'
		Me.label113.Location = New System.Drawing.Point(376, 15)
		Me.label113.Name = "label113"
		Me.label113.Size = New System.Drawing.Size(298, 32)
		Me.label113.TabIndex = 26
		Me.label113.Text = "Binds the component to a SqlConnectionDataProvider."
		'
		'label112
		'
		Me.label112.Location = New System.Drawing.Point(3, 15)
		Me.label112.Name = "label112"
		Me.label112.Size = New System.Drawing.Size(24, 16)
		Me.label112.TabIndex = 28
		Me.label112.Text = "D:"
		'
		'tbConnectionString
		'
		Me.tbConnectionString.BackColor = System.Drawing.SystemColors.Window
		Me.tbConnectionString.Location = New System.Drawing.Point(104, 61)
		Me.tbConnectionString.Name = "tbConnectionString"
		Me.tbConnectionString.Size = New System.Drawing.Size(374, 20)
		Me.tbConnectionString.TabIndex = 29
		Me.tbConnectionString.Text = "Data Source=<ComputerName>\SQLEXPRESS;Initial Catalog=<DatabaseName>;Integrated S" &
	"ecurity=True"
		Me.tbConnectionString.WordWrap = False
		'
		'tabOdata
		'
		Me.tabOdata.Controls.Add(Me.panel10)
		Me.tabOdata.Location = New System.Drawing.Point(4, 22)
		Me.tabOdata.Name = "tabOdata"
		Me.tabOdata.Padding = New System.Windows.Forms.Padding(3)
		Me.tabOdata.Size = New System.Drawing.Size(776, 98)
		Me.tabOdata.TabIndex = 9
		Me.tabOdata.Text = "OData"
		Me.tabOdata.Visible = False
		'
		'panel10
		'
		Me.panel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel10.Controls.Add(Me.label116)
		Me.panel10.Controls.Add(Me.printOdataBtn)
		Me.panel10.Controls.Add(Me.label117)
		Me.panel10.Controls.Add(Me.designOdataBtn)
		Me.panel10.Controls.Add(Me.odataUrlTb)
		Me.panel10.Controls.Add(Me.label119)
		Me.panel10.Controls.Add(Me.label120)
		Me.panel10.Controls.Add(Me.label118)
		Me.panel10.Location = New System.Drawing.Point(0, 0)
		Me.panel10.Name = "panel10"
		Me.panel10.Size = New System.Drawing.Size(774, 98)
		Me.panel10.TabIndex = 35
		'
		'label116
		'
		Me.label116.AutoSize = True
		Me.label116.Location = New System.Drawing.Point(1, 64)
		Me.label116.Name = "label116"
		Me.label116.Size = New System.Drawing.Size(26, 13)
		Me.label116.TabIndex = 34
		Me.label116.Text = "Url: "
		'
		'printOdataBtn
		'
		Me.printOdataBtn.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.printOdataBtn.Location = New System.Drawing.Point(662, 59)
		Me.printOdataBtn.Name = "printOdataBtn"
		Me.printOdataBtn.Size = New System.Drawing.Size(112, 24)
		Me.printOdataBtn.TabIndex = 33
		Me.printOdataBtn.Text = "&Print"
		'
		'label117
		'
		Me.label117.Location = New System.Drawing.Point(346, 15)
		Me.label117.Name = "label117"
		Me.label117.Size = New System.Drawing.Size(24, 16)
		Me.label117.TabIndex = 27
		Me.label117.Text = "US:"
		'
		'designOdataBtn
		'
		Me.designOdataBtn.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.designOdataBtn.Location = New System.Drawing.Point(533, 59)
		Me.designOdataBtn.Name = "designOdataBtn"
		Me.designOdataBtn.Size = New System.Drawing.Size(112, 24)
		Me.designOdataBtn.TabIndex = 32
		Me.designOdataBtn.Text = "&Design"
		'
		'odataUrlTb
		'
		Me.odataUrlTb.BackColor = System.Drawing.SystemColors.Window
		Me.odataUrlTb.Location = New System.Drawing.Point(31, 61)
		Me.odataUrlTb.Name = "odataUrlTb"
		Me.odataUrlTb.Size = New System.Drawing.Size(447, 20)
		Me.odataUrlTb.TabIndex = 29
		Me.odataUrlTb.Text = "http://services.odata.org/V3/Northwind/Northwind.svc/"
		'
		'label119
		'
		Me.label119.Location = New System.Drawing.Point(376, 15)
		Me.label119.Name = "label119"
		Me.label119.Size = New System.Drawing.Size(272, 32)
		Me.label119.TabIndex = 26
		Me.label119.Text = "Binds the component to an ODataDataProvider."
		'
		'label120
		'
		Me.label120.Location = New System.Drawing.Point(33, 15)
		Me.label120.Name = "label120"
		Me.label120.Size = New System.Drawing.Size(272, 32)
		Me.label120.TabIndex = 25
		Me.label120.Text = "Bindet die Komponente an einen ODataDataProvider."
		'
		'label118
		'
		Me.label118.Location = New System.Drawing.Point(3, 15)
		Me.label118.Name = "label118"
		Me.label118.Size = New System.Drawing.Size(24, 16)
		Me.label118.TabIndex = 28
		Me.label118.Text = "D:"
		'
		'tabRest
		'
		Me.tabRest.Controls.Add(Me.panel11)
		Me.tabRest.Location = New System.Drawing.Point(4, 22)
		Me.tabRest.Name = "tabRest"
		Me.tabRest.Padding = New System.Windows.Forms.Padding(3)
		Me.tabRest.Size = New System.Drawing.Size(776, 98)
		Me.tabRest.TabIndex = 10
		Me.tabRest.Text = "REST"
		Me.tabRest.Visible = False
		'
		'panel11
		'
		Me.panel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.panel11.Controls.Add(Me.label206)
		Me.panel11.Controls.Add(Me.restPrintBtn)
		Me.panel11.Controls.Add(Me.restDesignBtn)
		Me.panel11.Controls.Add(Me.label202)
		Me.panel11.Controls.Add(Me.label205)
		Me.panel11.Controls.Add(Me.label204)
		Me.panel11.Controls.Add(Me.label203)
		Me.panel11.Controls.Add(Me.restUrlTb)
		Me.panel11.Location = New System.Drawing.Point(0, 0)
		Me.panel11.Name = "panel11"
		Me.panel11.Size = New System.Drawing.Size(774, 98)
		Me.panel11.TabIndex = 35
		'
		'label206
		'
		Me.label206.AutoSize = True
		Me.label206.Location = New System.Drawing.Point(1, 64)
		Me.label206.Name = "label206"
		Me.label206.Size = New System.Drawing.Size(26, 13)
		Me.label206.TabIndex = 35
		Me.label206.Text = "Url: "
		'
		'restPrintBtn
		'
		Me.restPrintBtn.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.restPrintBtn.Location = New System.Drawing.Point(662, 59)
		Me.restPrintBtn.Name = "restPrintBtn"
		Me.restPrintBtn.Size = New System.Drawing.Size(112, 24)
		Me.restPrintBtn.TabIndex = 33
		Me.restPrintBtn.Text = "&Print"
		'
		'restDesignBtn
		'
		Me.restDesignBtn.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.restDesignBtn.Location = New System.Drawing.Point(533, 59)
		Me.restDesignBtn.Name = "restDesignBtn"
		Me.restDesignBtn.Size = New System.Drawing.Size(112, 24)
		Me.restDesignBtn.TabIndex = 32
		Me.restDesignBtn.Text = "&Design"
		'
		'label202
		'
		Me.label202.Location = New System.Drawing.Point(346, 15)
		Me.label202.Name = "label202"
		Me.label202.Size = New System.Drawing.Size(24, 16)
		Me.label202.TabIndex = 27
		Me.label202.Text = "US:"
		'
		'label205
		'
		Me.label205.Location = New System.Drawing.Point(33, 15)
		Me.label205.Name = "label205"
		Me.label205.Size = New System.Drawing.Size(269, 32)
		Me.label205.TabIndex = 25
		Me.label205.Text = "Bindet die Komponente an einen RestDataProvider."
		'
		'label204
		'
		Me.label204.Location = New System.Drawing.Point(376, 15)
		Me.label204.Name = "label204"
		Me.label204.Size = New System.Drawing.Size(272, 32)
		Me.label204.TabIndex = 26
		Me.label204.Text = "Binds the component to a RestDataProvider."
		'
		'label203
		'
		Me.label203.Location = New System.Drawing.Point(3, 15)
		Me.label203.Name = "label203"
		Me.label203.Size = New System.Drawing.Size(24, 16)
		Me.label203.TabIndex = 28
		Me.label203.Text = "D:"
		'
		'restUrlTb
		'
		Me.restUrlTb.BackColor = System.Drawing.SystemColors.Window
		Me.restUrlTb.Location = New System.Drawing.Point(31, 61)
		Me.restUrlTb.Name = "restUrlTb"
		Me.restUrlTb.Size = New System.Drawing.Size(447, 20)
		Me.restUrlTb.TabIndex = 29
		Me.restUrlTb.Text = "http://www.pegelonline.wsv.de/webservices/rest-api/v2/stations/KONSTANZ/W/measure" &
	"ments.json?start=P30D"
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(784, 561)
		Me.Controls.Add(Me.tabControl)
		Me.Controls.Add(Me.progressBar1)
		Me.Controls.Add(Me.LLPreviewControl)
		Me.Controls.Add(Me.statusBar1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(800, 600)
		Me.Name = "Form1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "List & Label Databinding VB.NET Sample"
		Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.tabControl.ResumeLayout(False)
		Me.tpDataSet.ResumeLayout(False)
		Me.panel2.ResumeLayout(False)
		Me.tpXML.ResumeLayout(False)
		Me.panel5.ResumeLayout(False)
		Me.tpDataViewManager.ResumeLayout(False)
		Me.panel3.ResumeLayout(False)
		Me.tpDataView.ResumeLayout(False)
		Me.panel4.ResumeLayout(False)
		Me.tpDbCommand.ResumeLayout(False)
		Me.panel6.ResumeLayout(False)
		Me.tpDataTable.ResumeLayout(False)
		Me.panel7.ResumeLayout(False)
		Me.tpGenericList.ResumeLayout(False)
		Me.panel8.ResumeLayout(False)
		Me.tabSQLServer.ResumeLayout(False)
		Me.panel9.ResumeLayout(False)
		Me.panel9.PerformLayout()
		Me.tabOdata.ResumeLayout(False)
		Me.panel10.ResumeLayout(False)
		Me.panel10.PerformLayout()
		Me.tabRest.ResumeLayout(False)
		Me.panel11.ResumeLayout(False)
		Me.panel11.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
#End Region
	Friend WithEvents LL As ListLabel
    Private WithEvents statusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents LLPreviewControl As ListLabelPreviewControl
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents tabControl As System.Windows.Forms.TabControl
    Private WithEvents tabOdata As System.Windows.Forms.TabPage
    Private WithEvents panel10 As System.Windows.Forms.Panel
    Private WithEvents label116 As System.Windows.Forms.Label
    Private WithEvents printOdataBtn As System.Windows.Forms.Button
    Private WithEvents label117 As System.Windows.Forms.Label
    Private WithEvents designOdataBtn As System.Windows.Forms.Button
    Private WithEvents odataUrlTb As System.Windows.Forms.TextBox
    Private WithEvents label119 As System.Windows.Forms.Label
    Private WithEvents label120 As System.Windows.Forms.Label
    Private WithEvents label118 As System.Windows.Forms.Label
    Private WithEvents tpDataSet As System.Windows.Forms.TabPage
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents design_DataSet As System.Windows.Forms.Button
    Private WithEvents print_DataSet As System.Windows.Forms.Button
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents tpXML As System.Windows.Forms.TabPage
    Private WithEvents panel5 As System.Windows.Forms.Panel
    Private WithEvents print_XML As System.Windows.Forms.Button
    Private WithEvents design_XML As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents tpDataViewManager As System.Windows.Forms.TabPage
    Private WithEvents panel3 As System.Windows.Forms.Panel
    Private WithEvents cbCustomerNames As System.Windows.Forms.ComboBox
    Private WithEvents print_DataViewManager As System.Windows.Forms.Button
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents design_DataViewManager As System.Windows.Forms.Button
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents tpDataView As System.Windows.Forms.TabPage
    Private WithEvents panel4 As System.Windows.Forms.Panel
    Private WithEvents design_DataView As System.Windows.Forms.Button
    Private WithEvents print_DataView As System.Windows.Forms.Button
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents label19 As System.Windows.Forms.Label
    Private WithEvents tpDbCommand As System.Windows.Forms.TabPage
    Private WithEvents panel6 As System.Windows.Forms.Panel
    Private WithEvents print_Reader As System.Windows.Forms.Button
    Private WithEvents design_Reader As System.Windows.Forms.Button
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents tpDataTable As System.Windows.Forms.TabPage
    Private WithEvents panel7 As System.Windows.Forms.Panel
    Private WithEvents design_DataTable As System.Windows.Forms.Button
    Private WithEvents print_DataTable As System.Windows.Forms.Button
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents label99 As System.Windows.Forms.Label
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents tpGenericList As System.Windows.Forms.TabPage
    Private WithEvents panel8 As System.Windows.Forms.Panel
    Private WithEvents print_GenericList As System.Windows.Forms.Button
    Private WithEvents design_GenericList As System.Windows.Forms.Button
    Private WithEvents label79 As System.Windows.Forms.Label
    Private WithEvents label77 As System.Windows.Forms.Label
    Private WithEvents label76 As System.Windows.Forms.Label
    Private WithEvents label78 As System.Windows.Forms.Label
    Private WithEvents tabSQLServer As System.Windows.Forms.TabPage
    Private WithEvents panel9 As System.Windows.Forms.Panel
    Private WithEvents label115 As System.Windows.Forms.Label
    Private WithEvents print_SQL As System.Windows.Forms.Button
    Private WithEvents design_SQL As System.Windows.Forms.Button
    Private WithEvents label111 As System.Windows.Forms.Label
    Private WithEvents label114 As System.Windows.Forms.Label
    Private WithEvents label113 As System.Windows.Forms.Label
    Private WithEvents label112 As System.Windows.Forms.Label
    Private WithEvents tbConnectionString As System.Windows.Forms.TextBox
    Private WithEvents tabRest As System.Windows.Forms.TabPage
    Private WithEvents panel11 As System.Windows.Forms.Panel
    Private WithEvents label206 As System.Windows.Forms.Label
    Private WithEvents restPrintBtn As System.Windows.Forms.Button
    Private WithEvents restDesignBtn As System.Windows.Forms.Button
    Private WithEvents label202 As System.Windows.Forms.Label
    Private WithEvents label205 As System.Windows.Forms.Label
    Private WithEvents label204 As System.Windows.Forms.Label
    Private WithEvents label203 As System.Windows.Forms.Label
    Private WithEvents restUrlTb As System.Windows.Forms.TextBox
End Class

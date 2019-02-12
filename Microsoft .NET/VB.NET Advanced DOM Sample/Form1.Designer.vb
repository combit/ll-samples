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
        Me.label13 = New System.Windows.Forms.Label()
        Me.fontDialog1 = New System.Windows.Forms.FontDialog()
        Me.LL = New combit.ListLabel24.ListLabel(Me.components)
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.label5 = New MetroFramework.Controls.MetroLabel()
        Me.label4 = New MetroFramework.Controls.MetroLabel()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
        Me.tabControl1 = New MetroFramework.Controls.MetroTabControl()
        Me.tabPage1 = New MetroFramework.Controls.MetroTabPage()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.textBox3 = New MetroFramework.Controls.MetroTextBox()
        Me.optModeCustomer = New MetroFramework.Controls.MetroRadioButton()
        Me.label31 = New MetroFramework.Controls.MetroLabel()
        Me.label2 = New MetroFramework.Controls.MetroLabel()
        Me.label6 = New MetroFramework.Controls.MetroLabel()
        Me.label32 = New MetroFramework.Controls.MetroLabel()
        Me.label7 = New MetroFramework.Controls.MetroLabel()
        Me.label33 = New MetroFramework.Controls.MetroLabel()
        Me.label8 = New MetroFramework.Controls.MetroLabel()
        Me.label34 = New MetroFramework.Controls.MetroLabel()
        Me.optModeTimePeriod = New MetroFramework.Controls.MetroRadioButton()
        Me.label39 = New MetroFramework.Controls.MetroLabel()
        Me.label12 = New MetroFramework.Controls.MetroLabel()
        Me.optModeChart = New MetroFramework.Controls.MetroRadioButton()
        Me.label11 = New MetroFramework.Controls.MetroLabel()
        Me.label10 = New MetroFramework.Controls.MetroLabel()
        Me.label9 = New MetroFramework.Controls.MetroLabel()
        Me.btnNext1 = New MetroFramework.Controls.MetroButton()
        Me.tabPage2 = New MetroFramework.Controls.MetroTabPage()
        Me.btnPrev2 = New MetroFramework.Controls.MetroButton()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.label16 = New MetroFramework.Controls.MetroLabel()
        Me.cmbSortRow = New MetroFramework.Controls.MetroComboBox()
        Me.button9 = New MetroFramework.Controls.MetroButton()
        Me.label25 = New MetroFramework.Controls.MetroLabel()
        Me.label26 = New MetroFramework.Controls.MetroLabel()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label40 = New MetroFramework.Controls.MetroLabel()
        Me.label15 = New MetroFramework.Controls.MetroLabel()
        Me.cmbSortCell = New MetroFramework.Controls.MetroComboBox()
        Me.button1 = New MetroFramework.Controls.MetroButton()
        Me.label14 = New MetroFramework.Controls.MetroLabel()
        Me.btnNext2 = New MetroFramework.Controls.MetroButton()
        Me.tabPage3 = New MetroFramework.Controls.MetroTabPage()
        Me.btnPrev3 = New MetroFramework.Controls.MetroButton()
        Me.btnNext3 = New MetroFramework.Controls.MetroButton()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbPageFormat = New MetroFramework.Controls.MetroComboBox()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.label38 = New System.Windows.Forms.Label()
        Me.button5 = New MetroFramework.Controls.MetroButton()
        Me.button6 = New MetroFramework.Controls.MetroButton()
        Me.textProjectTitle = New MetroFramework.Controls.MetroTextBox()
        Me.label35 = New MetroFramework.Controls.MetroLabel()
        Me.tabPage4 = New MetroFramework.Controls.MetroTabPage()
        Me.groupBox6 = New System.Windows.Forms.GroupBox()
        Me.label37 = New MetroFramework.Controls.MetroLabel()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.label24 = New MetroFramework.Controls.MetroLabel()
        Me.label_DefFont = New MetroFramework.Controls.MetroLabel()
        Me.label27 = New MetroFramework.Controls.MetroLabel()
        Me.label_ProjectTitle = New MetroFramework.Controls.MetroLabel()
        Me.label28 = New MetroFramework.Controls.MetroLabel()
        Me.label29 = New MetroFramework.Controls.MetroLabel()
        Me.label36 = New MetroFramework.Controls.MetroLabel()
        Me.label30 = New MetroFramework.Controls.MetroLabel()
        Me.label_Row = New MetroFramework.Controls.MetroLabel()
        Me.label_Schema = New MetroFramework.Controls.MetroLabel()
        Me.label_Cell = New MetroFramework.Controls.MetroLabel()
        Me.label_Title = New MetroFramework.Controls.MetroLabel()
        Me.button2 = New MetroFramework.Controls.MetroButton()
        Me.button4 = New MetroFramework.Controls.MetroButton()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.tabPage4.SuspendLayout()
        Me.groupBox6.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label13
        '
        Me.label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label13.Location = New System.Drawing.Point(107, 28)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(57, 21)
        Me.label13.TabIndex = 7
        '
        'LL
        '
        Me.LL.AutoBoxType = combit.ListLabel24.LlBoxType.Normalwait
        Me.LL.AutoDestination = combit.ListLabel24.LlPrintMode.Preview
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.AutoShowPrintOptions = False
        Me.LL.AutoShowSelectFile = False
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_10
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.SystemColors.Control
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(28, 94)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(28, 19)
        Me.label1.TabIndex = 11
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.BackColor = System.Drawing.SystemColors.Control
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(28, 74)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(28, 20)
        Me.label5.TabIndex = 12
        Me.label5.Text = "D:  "
        '
        'label4
        '
        Me.label4.BackColor = System.Drawing.SystemColors.Control
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(56, 94)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(449, 19)
        Me.label4.TabIndex = 10
        Me.label4.Text = "This sample shows the dynamic creation of List && Label projects."
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.SystemColors.Control
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(56, 74)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(449, 20)
        Me.label3.TabIndex = 9
        Me.label3.Text = "Dieses Beispiel zeigt die dynamische Erstellung von List && Label Projekten."
        '
        'tabControl1
        '
        Me.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Controls.Add(Me.tabPage4)
        Me.tabControl1.Location = New System.Drawing.Point(22, 117)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(554, 400)
        Me.tabControl1.Style = MetroFramework.MetroColorStyle.Blue
        Me.tabControl1.TabIndex = 13
        Me.tabControl1.UseSelectable = True
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.groupBox5)
        Me.tabPage1.Controls.Add(Me.btnNext1)
        Me.tabPage1.HorizontalScrollbarBarColor = True
        Me.tabPage1.HorizontalScrollbarHighlightOnWheel = False
        Me.tabPage1.HorizontalScrollbarSize = 12
        Me.tabPage1.Location = New System.Drawing.Point(4, 41)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Size = New System.Drawing.Size(551, 355)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "1. Data"
        Me.tabPage1.VerticalScrollbarBarColor = True
        Me.tabPage1.VerticalScrollbarHighlightOnWheel = False
        Me.tabPage1.VerticalScrollbarSize = 12
        '
        'groupBox5
        '
        Me.groupBox5.BackColor = System.Drawing.SystemColors.Window
        Me.groupBox5.Controls.Add(Me.textBox3)
        Me.groupBox5.Controls.Add(Me.optModeCustomer)
        Me.groupBox5.Controls.Add(Me.label31)
        Me.groupBox5.Controls.Add(Me.label2)
        Me.groupBox5.Controls.Add(Me.label6)
        Me.groupBox5.Controls.Add(Me.label32)
        Me.groupBox5.Controls.Add(Me.label7)
        Me.groupBox5.Controls.Add(Me.label33)
        Me.groupBox5.Controls.Add(Me.label8)
        Me.groupBox5.Controls.Add(Me.label34)
        Me.groupBox5.Controls.Add(Me.optModeTimePeriod)
        Me.groupBox5.Controls.Add(Me.label39)
        Me.groupBox5.Controls.Add(Me.label12)
        Me.groupBox5.Controls.Add(Me.optModeChart)
        Me.groupBox5.Controls.Add(Me.label11)
        Me.groupBox5.Controls.Add(Me.label10)
        Me.groupBox5.Controls.Add(Me.label9)
        Me.groupBox5.Location = New System.Drawing.Point(0, 4)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(533, 236)
        Me.groupBox5.TabIndex = 24
        Me.groupBox5.TabStop = False
        '
        'textBox3
        '
        Me.textBox3.Enabled = False
        Me.textBox3.Lines = New String() {"Total employees turnover"}
        Me.textBox3.Location = New System.Drawing.Point(142, 194)
        Me.textBox3.MaxLength = 32767
        Me.textBox3.Name = "textBox3"
        Me.textBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.textBox3.SelectedText = ""
        Me.textBox3.Size = New System.Drawing.Size(369, 25)
        Me.textBox3.TabIndex = 22
        Me.textBox3.Text = "Total employees turnover"
        Me.textBox3.UseSelectable = True
        '
        'optModeCustomer
        '
        Me.optModeCustomer.Checked = True
        Me.optModeCustomer.Location = New System.Drawing.Point(11, 30)
        Me.optModeCustomer.Name = "optModeCustomer"
        Me.optModeCustomer.Size = New System.Drawing.Size(17, 16)
        Me.optModeCustomer.TabIndex = 0
        Me.optModeCustomer.TabStop = True
        Me.optModeCustomer.UseSelectable = True
        '
        'label31
        '
        Me.label31.AutoSize = True
        Me.label31.Enabled = False
        Me.label31.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label31.Location = New System.Drawing.Point(98, 198)
        Me.label31.Name = "label31"
        Me.label31.Size = New System.Drawing.Size(30, 15)
        Me.label31.TabIndex = 23
        Me.label31.Text = "Title:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label2.Location = New System.Drawing.Point(37, 28)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(18, 15)
        Me.label2.TabIndex = 1
        Me.label2.Text = "D:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label6.Location = New System.Drawing.Point(37, 53)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(24, 15)
        Me.label6.TabIndex = 2
        Me.label6.Text = "US:"
        '
        'label32
        '
        Me.label32.AutoSize = True
        Me.label32.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label32.Location = New System.Drawing.Point(96, 166)
        Me.label32.Name = "label32"
        Me.label32.Size = New System.Drawing.Size(214, 15)
        Me.label32.TabIndex = 21
        Me.label32.Text = "Report employees turnover within a chart"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label7.Location = New System.Drawing.Point(96, 28)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(325, 15)
        Me.label7.TabIndex = 3
        Me.label7.Text = "Auswertung der Verkäufe nach Land innerhalb einer Kreuztabelle"
        '
        'label33
        '
        Me.label33.AutoSize = True
        Me.label33.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label33.Location = New System.Drawing.Point(96, 140)
        Me.label33.Name = "label33"
        Me.label33.Size = New System.Drawing.Size(224, 15)
        Me.label33.TabIndex = 20
        Me.label33.Text = "Übersicht der einzelnen Mitarbeiterumsätze"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label8.Location = New System.Drawing.Point(96, 53)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(287, 15)
        Me.label8.TabIndex = 4
        Me.label8.Text = "Report employee turnover per country within a crosstab"
        '
        'label34
        '
        Me.label34.AutoSize = True
        Me.label34.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label34.Location = New System.Drawing.Point(37, 166)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(24, 15)
        Me.label34.TabIndex = 19
        Me.label34.Text = "US:"
        '
        'optModeTimePeriod
        '
        Me.optModeTimePeriod.Location = New System.Drawing.Point(11, 86)
        Me.optModeTimePeriod.Name = "optModeTimePeriod"
        Me.optModeTimePeriod.Size = New System.Drawing.Size(17, 16)
        Me.optModeTimePeriod.TabIndex = 5
        Me.optModeTimePeriod.UseSelectable = True
        '
        'label39
        '
        Me.label39.AutoSize = True
        Me.label39.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label39.Location = New System.Drawing.Point(37, 140)
        Me.label39.Name = "label39"
        Me.label39.Size = New System.Drawing.Size(18, 15)
        Me.label39.TabIndex = 18
        Me.label39.Text = "D:"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label12.Location = New System.Drawing.Point(37, 86)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(18, 15)
        Me.label12.TabIndex = 6
        Me.label12.Text = "D:"
        '
        'optModeChart
        '
        Me.optModeChart.Location = New System.Drawing.Point(11, 140)
        Me.optModeChart.Name = "optModeChart"
        Me.optModeChart.Size = New System.Drawing.Size(17, 16)
        Me.optModeChart.TabIndex = 17
        Me.optModeChart.UseSelectable = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label11.Location = New System.Drawing.Point(37, 111)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(24, 15)
        Me.label11.TabIndex = 7
        Me.label11.Text = "US:"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label10.Location = New System.Drawing.Point(96, 86)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(346, 15)
        Me.label10.TabIndex = 8
        Me.label10.Text = "Auswertung der Verkäufe nach Zeitraum innerhalb einer Kreuztabelle"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label9.Location = New System.Drawing.Point(96, 111)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(255, 15)
        Me.label9.TabIndex = 9
        Me.label9.Text = "Report turnover per time period within a crosstab"
        '
        'btnNext1
        '
        Me.btnNext1.Location = New System.Drawing.Point(416, 308)
        Me.btnNext1.Name = "btnNext1"
        Me.btnNext1.Size = New System.Drawing.Size(112, 29)
        Me.btnNext1.TabIndex = 15
        Me.btnNext1.Text = "Next >"
        Me.btnNext1.UseSelectable = True
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.btnPrev2)
        Me.tabPage2.Controls.Add(Me.groupBox2)
        Me.tabPage2.Controls.Add(Me.groupBox1)
        Me.tabPage2.Controls.Add(Me.btnNext2)
        Me.tabPage2.HorizontalScrollbarBarColor = True
        Me.tabPage2.HorizontalScrollbarHighlightOnWheel = False
        Me.tabPage2.HorizontalScrollbarSize = 12
        Me.tabPage2.Location = New System.Drawing.Point(4, 41)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Size = New System.Drawing.Size(546, 355)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "2. Crosstab properties"
        Me.tabPage2.VerticalScrollbarBarColor = True
        Me.tabPage2.VerticalScrollbarHighlightOnWheel = False
        Me.tabPage2.VerticalScrollbarSize = 12
        '
        'btnPrev2
        '
        Me.btnPrev2.Location = New System.Drawing.Point(301, 308)
        Me.btnPrev2.Name = "btnPrev2"
        Me.btnPrev2.Size = New System.Drawing.Size(112, 29)
        Me.btnPrev2.TabIndex = 20
        Me.btnPrev2.Text = "< Previous"
        Me.btnPrev2.UseSelectable = True
        '
        'groupBox2
        '
        Me.groupBox2.BackColor = System.Drawing.SystemColors.Window
        Me.groupBox2.Controls.Add(Me.label16)
        Me.groupBox2.Controls.Add(Me.cmbSortRow)
        Me.groupBox2.Controls.Add(Me.button9)
        Me.groupBox2.Controls.Add(Me.label25)
        Me.groupBox2.Controls.Add(Me.label26)
        Me.groupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(0, 113)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(528, 91)
        Me.groupBox2.TabIndex = 18
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Row-Properties"
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label16.Location = New System.Drawing.Point(256, 25)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(64, 15)
        Me.label16.TabIndex = 19
        Me.label16.Text = "Sort order:"
        '
        'cmbSortRow
        '
        Me.cmbSortRow.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cmbSortRow.ItemHeight = 19
        Me.cmbSortRow.Items.AddRange(New Object() {"Ascending (A > Z)", "Descending (Z > A)"})
        Me.cmbSortRow.Location = New System.Drawing.Point(340, 25)
        Me.cmbSortRow.Name = "cmbSortRow"
        Me.cmbSortRow.Size = New System.Drawing.Size(176, 25)
        Me.cmbSortRow.TabIndex = 18
        Me.cmbSortRow.UseSelectable = True
        '
        'button9
        '
        Me.button9.Location = New System.Drawing.Point(216, 25)
        Me.button9.Name = "button9"
        Me.button9.Size = New System.Drawing.Size(32, 25)
        Me.button9.TabIndex = 11
        Me.button9.Text = "..."
        Me.button9.UseSelectable = True
        '
        'label25
        '
        Me.label25.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label25.Location = New System.Drawing.Point(146, 25)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(69, 25)
        Me.label25.TabIndex = 10
        Me.label25.UseCustomBackColor = True
        '
        'label26
        '
        Me.label26.AutoSize = True
        Me.label26.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label26.Location = New System.Drawing.Point(7, 25)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(88, 15)
        Me.label26.TabIndex = 9
        Me.label26.Text = "Row-BackColor:"
        '
        'groupBox1
        '
        Me.groupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.groupBox1.Controls.Add(Me.label40)
        Me.groupBox1.Controls.Add(Me.label15)
        Me.groupBox1.Controls.Add(Me.cmbSortCell)
        Me.groupBox1.Controls.Add(Me.button1)
        Me.groupBox1.Controls.Add(Me.label14)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(0, 7)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(528, 99)
        Me.groupBox1.TabIndex = 6
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Column-Properties"
        '
        'label40
        '
        Me.label40.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label40.Location = New System.Drawing.Point(146, 25)
        Me.label40.Name = "label40"
        Me.label40.Size = New System.Drawing.Size(69, 25)
        Me.label40.TabIndex = 17
        Me.label40.UseCustomBackColor = True
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label15.Location = New System.Drawing.Point(256, 25)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(64, 15)
        Me.label15.TabIndex = 16
        Me.label15.Text = "Sort order:"
        '
        'cmbSortCell
        '
        Me.cmbSortCell.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cmbSortCell.ItemHeight = 19
        Me.cmbSortCell.Items.AddRange(New Object() {"Ascending (A > Z)", "Descending (Z > A)"})
        Me.cmbSortCell.Location = New System.Drawing.Point(340, 25)
        Me.cmbSortCell.Name = "cmbSortCell"
        Me.cmbSortCell.Size = New System.Drawing.Size(176, 25)
        Me.cmbSortCell.TabIndex = 15
        Me.cmbSortCell.UseSelectable = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(216, 25)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(32, 25)
        Me.button1.TabIndex = 8
        Me.button1.Text = "..."
        Me.button1.UseSelectable = True
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label14.Location = New System.Drawing.Point(7, 25)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(104, 15)
        Me.label14.TabIndex = 6
        Me.label14.Text = "Column-BackColor:"
        '
        'btnNext2
        '
        Me.btnNext2.Location = New System.Drawing.Point(416, 308)
        Me.btnNext2.Name = "btnNext2"
        Me.btnNext2.Size = New System.Drawing.Size(112, 29)
        Me.btnNext2.TabIndex = 19
        Me.btnNext2.Text = "Next >"
        Me.btnNext2.UseSelectable = True
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.btnPrev3)
        Me.tabPage3.Controls.Add(Me.btnNext3)
        Me.tabPage3.Controls.Add(Me.groupBox4)
        Me.tabPage3.Controls.Add(Me.groupBox3)
        Me.tabPage3.Controls.Add(Me.textProjectTitle)
        Me.tabPage3.Controls.Add(Me.label35)
        Me.tabPage3.HorizontalScrollbarBarColor = True
        Me.tabPage3.HorizontalScrollbarHighlightOnWheel = False
        Me.tabPage3.HorizontalScrollbarSize = 12
        Me.tabPage3.Location = New System.Drawing.Point(4, 41)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(551, 355)
        Me.tabPage3.TabIndex = 4
        Me.tabPage3.Text = "3. General settings"
        Me.tabPage3.VerticalScrollbarBarColor = True
        Me.tabPage3.VerticalScrollbarHighlightOnWheel = False
        Me.tabPage3.VerticalScrollbarSize = 12
        '
        'btnPrev3
        '
        Me.btnPrev3.Location = New System.Drawing.Point(301, 308)
        Me.btnPrev3.Name = "btnPrev3"
        Me.btnPrev3.Size = New System.Drawing.Size(112, 29)
        Me.btnPrev3.TabIndex = 19
        Me.btnPrev3.Text = "< Previous"
        Me.btnPrev3.UseSelectable = True
        '
        'btnNext3
        '
        Me.btnNext3.Location = New System.Drawing.Point(416, 308)
        Me.btnNext3.Name = "btnNext3"
        Me.btnNext3.Size = New System.Drawing.Size(112, 29)
        Me.btnNext3.TabIndex = 18
        Me.btnNext3.Text = "Finish"
        Me.btnNext3.UseSelectable = True
        '
        'groupBox4
        '
        Me.groupBox4.BackColor = System.Drawing.SystemColors.Window
        Me.groupBox4.Controls.Add(Me.cmbPageFormat)
        Me.groupBox4.Location = New System.Drawing.Point(0, 170)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(528, 70)
        Me.groupBox4.TabIndex = 17
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Page format"
        '
        'cmbPageFormat
        '
        Me.cmbPageFormat.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cmbPageFormat.ItemHeight = 19
        Me.cmbPageFormat.Items.AddRange(New Object() {"Portrait", "Landscape"})
        Me.cmbPageFormat.Location = New System.Drawing.Point(7, 23)
        Me.cmbPageFormat.Name = "cmbPageFormat"
        Me.cmbPageFormat.Size = New System.Drawing.Size(514, 25)
        Me.cmbPageFormat.Style = MetroFramework.MetroColorStyle.Blue
        Me.cmbPageFormat.TabIndex = 1
        Me.cmbPageFormat.UseSelectable = True
        '
        'groupBox3
        '
        Me.groupBox3.BackColor = System.Drawing.SystemColors.Window
        Me.groupBox3.Controls.Add(Me.label38)
        Me.groupBox3.Controls.Add(Me.button5)
        Me.groupBox3.Controls.Add(Me.button6)
        Me.groupBox3.Location = New System.Drawing.Point(0, 71)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(528, 91)
        Me.groupBox3.TabIndex = 16
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Default Font"
        '
        'label38
        '
        Me.label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.label38.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label38.Location = New System.Drawing.Point(7, 28)
        Me.label38.Name = "label38"
        Me.label38.Size = New System.Drawing.Size(388, 48)
        Me.label38.TabIndex = 18
        Me.label38.Text = "Sample text"
        Me.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'button5
        '
        Me.button5.Location = New System.Drawing.Point(395, 38)
        Me.button5.Name = "button5"
        Me.button5.Size = New System.Drawing.Size(32, 26)
        Me.button5.TabIndex = 17
        Me.button5.Text = "..."
        Me.button5.UseSelectable = True
        '
        'button6
        '
        Me.button6.Location = New System.Drawing.Point(434, 38)
        Me.button6.Name = "button6"
        Me.button6.Size = New System.Drawing.Size(71, 26)
        Me.button6.TabIndex = 16
        Me.button6.Text = "Color..."
        Me.button6.UseSelectable = True
        '
        'textProjectTitle
        '
        Me.textProjectTitle.BackColor = System.Drawing.SystemColors.Window
        Me.textProjectTitle.Lines = New String() {"This sample shows advanced dynamic project creation."}
        Me.textProjectTitle.Location = New System.Drawing.Point(0, 26)
        Me.textProjectTitle.MaxLength = 32767
        Me.textProjectTitle.Name = "textProjectTitle"
        Me.textProjectTitle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textProjectTitle.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.textProjectTitle.SelectedText = ""
        Me.textProjectTitle.Size = New System.Drawing.Size(528, 24)
        Me.textProjectTitle.TabIndex = 13
        Me.textProjectTitle.Text = "This sample shows advanced dynamic project creation."
        Me.textProjectTitle.UseCustomBackColor = True
        Me.textProjectTitle.UseSelectable = True
        '
        'label35
        '
        Me.label35.AutoSize = True
        Me.label35.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label35.Location = New System.Drawing.Point(0, 4)
        Me.label35.Name = "label35"
        Me.label35.Size = New System.Drawing.Size(67, 15)
        Me.label35.TabIndex = 12
        Me.label35.Text = "Report title:"
        '
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.groupBox6)
        Me.tabPage4.Controls.Add(Me.button2)
        Me.tabPage4.Controls.Add(Me.button4)
        Me.tabPage4.HorizontalScrollbarBarColor = True
        Me.tabPage4.HorizontalScrollbarHighlightOnWheel = False
        Me.tabPage4.HorizontalScrollbarSize = 12
        Me.tabPage4.Location = New System.Drawing.Point(4, 41)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Size = New System.Drawing.Size(551, 355)
        Me.tabPage4.TabIndex = 3
        Me.tabPage4.Text = "4. Finish"
        Me.tabPage4.VerticalScrollbarBarColor = True
        Me.tabPage4.VerticalScrollbarHighlightOnWheel = False
        Me.tabPage4.VerticalScrollbarSize = 12
        '
        'groupBox6
        '
        Me.groupBox6.BackColor = System.Drawing.SystemColors.Window
        Me.groupBox6.Controls.Add(Me.label37)
        Me.groupBox6.Controls.Add(Me.pictureBox1)
        Me.groupBox6.Controls.Add(Me.label24)
        Me.groupBox6.Controls.Add(Me.label_DefFont)
        Me.groupBox6.Controls.Add(Me.label27)
        Me.groupBox6.Controls.Add(Me.label_ProjectTitle)
        Me.groupBox6.Controls.Add(Me.label28)
        Me.groupBox6.Controls.Add(Me.label29)
        Me.groupBox6.Controls.Add(Me.label36)
        Me.groupBox6.Controls.Add(Me.label30)
        Me.groupBox6.Controls.Add(Me.label_Row)
        Me.groupBox6.Controls.Add(Me.label_Schema)
        Me.groupBox6.Controls.Add(Me.label_Cell)
        Me.groupBox6.Controls.Add(Me.label_Title)
        Me.groupBox6.Location = New System.Drawing.Point(0, 4)
        Me.groupBox6.Name = "groupBox6"
        Me.groupBox6.Size = New System.Drawing.Size(528, 296)
        Me.groupBox6.TabIndex = 32
        Me.groupBox6.TabStop = False
        '
        'label37
        '
        Me.label37.AutoSize = True
        Me.label37.BackColor = System.Drawing.SystemColors.Info
        Me.label37.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label37.Location = New System.Drawing.Point(4, 250)
        Me.label37.Name = "label37"
        Me.label37.Size = New System.Drawing.Size(76, 15)
        Me.label37.TabIndex = 29
        Me.label37.Text = "- Default font:"
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.SystemColors.Window
        Me.pictureBox1.Location = New System.Drawing.Point(7, 23)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(60, 46)
        Me.pictureBox1.TabIndex = 18
        Me.pictureBox1.TabStop = False
        '
        'label24
        '
        Me.label24.BackColor = System.Drawing.SystemColors.Info
        Me.label24.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label24.Location = New System.Drawing.Point(74, 23)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(447, 46)
        Me.label24.TabIndex = 19
        Me.label24.Text = "The List && Label project will be created with the following options:"
        '
        'label_DefFont
        '
        Me.label_DefFont.BackColor = System.Drawing.SystemColors.Info
        Me.label_DefFont.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label_DefFont.Location = New System.Drawing.Point(102, 250)
        Me.label_DefFont.Name = "label_DefFont"
        Me.label_DefFont.Size = New System.Drawing.Size(419, 18)
        Me.label_DefFont.TabIndex = 31
        '
        'label27
        '
        Me.label27.AutoSize = True
        Me.label27.BackColor = System.Drawing.SystemColors.Info
        Me.label27.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label27.Location = New System.Drawing.Point(4, 90)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(57, 15)
        Me.label27.TabIndex = 20
        Me.label27.Text = "- Schema:"
        '
        'label_ProjectTitle
        '
        Me.label_ProjectTitle.BackColor = System.Drawing.SystemColors.Info
        Me.label_ProjectTitle.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label_ProjectTitle.Location = New System.Drawing.Point(102, 218)
        Me.label_ProjectTitle.Name = "label_ProjectTitle"
        Me.label_ProjectTitle.Size = New System.Drawing.Size(419, 18)
        Me.label_ProjectTitle.TabIndex = 30
        '
        'label28
        '
        Me.label28.AutoSize = True
        Me.label28.BackColor = System.Drawing.SystemColors.Info
        Me.label28.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label28.Location = New System.Drawing.Point(4, 121)
        Me.label28.Name = "label28"
        Me.label28.Size = New System.Drawing.Size(67, 15)
        Me.label28.TabIndex = 21
        Me.label28.Text = "- Chart title:"
        '
        'label29
        '
        Me.label29.AutoSize = True
        Me.label29.BackColor = System.Drawing.SystemColors.Info
        Me.label29.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label29.Location = New System.Drawing.Point(4, 153)
        Me.label29.Name = "label29"
        Me.label29.Size = New System.Drawing.Size(56, 15)
        Me.label29.TabIndex = 22
        Me.label29.Text = "- Column:"
        '
        'label36
        '
        Me.label36.AutoSize = True
        Me.label36.BackColor = System.Drawing.SystemColors.Info
        Me.label36.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label36.Location = New System.Drawing.Point(4, 218)
        Me.label36.Name = "label36"
        Me.label36.Size = New System.Drawing.Size(74, 15)
        Me.label36.TabIndex = 28
        Me.label36.Text = "- Project title:"
        '
        'label30
        '
        Me.label30.AutoSize = True
        Me.label30.BackColor = System.Drawing.SystemColors.Info
        Me.label30.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label30.Location = New System.Drawing.Point(4, 185)
        Me.label30.Name = "label30"
        Me.label30.Size = New System.Drawing.Size(40, 15)
        Me.label30.TabIndex = 23
        Me.label30.Text = "- Row:"
        '
        'label_Row
        '
        Me.label_Row.BackColor = System.Drawing.SystemColors.Info
        Me.label_Row.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label_Row.Location = New System.Drawing.Point(102, 185)
        Me.label_Row.Name = "label_Row"
        Me.label_Row.Size = New System.Drawing.Size(419, 18)
        Me.label_Row.TabIndex = 27
        '
        'label_Schema
        '
        Me.label_Schema.BackColor = System.Drawing.SystemColors.Info
        Me.label_Schema.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label_Schema.Location = New System.Drawing.Point(102, 90)
        Me.label_Schema.Name = "label_Schema"
        Me.label_Schema.Size = New System.Drawing.Size(419, 18)
        Me.label_Schema.TabIndex = 24
        '
        'label_Cell
        '
        Me.label_Cell.BackColor = System.Drawing.SystemColors.Info
        Me.label_Cell.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label_Cell.Location = New System.Drawing.Point(102, 153)
        Me.label_Cell.Name = "label_Cell"
        Me.label_Cell.Size = New System.Drawing.Size(419, 18)
        Me.label_Cell.TabIndex = 26
        '
        'label_Title
        '
        Me.label_Title.BackColor = System.Drawing.SystemColors.Info
        Me.label_Title.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label_Title.Location = New System.Drawing.Point(102, 121)
        Me.label_Title.Name = "label_Title"
        Me.label_Title.Size = New System.Drawing.Size(419, 18)
        Me.label_Title.TabIndex = 25
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(300, 308)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(112, 29)
        Me.button2.TabIndex = 17
        Me.button2.Text = "Design..."
        Me.button2.UseSelectable = True
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(416, 308)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(112, 29)
        Me.button4.TabIndex = 14
        Me.button4.Text = "Preview..."
        Me.button4.UseSelectable = True
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(604, 528)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(604, 528)
        Me.Name = "Form1"
        Me.Resizable = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List & Label DOM Advanced VB.NET Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage3.PerformLayout()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox3.ResumeLayout(False)
        Me.tabPage4.ResumeLayout(False)
        Me.groupBox6.ResumeLayout(False)
        Me.groupBox6.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents fontDialog1 As System.Windows.Forms.FontDialog
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel
    Private WithEvents tabControl1 As MetroFramework.Controls.MetroTabControl
    Private WithEvents tabPage1 As MetroFramework.Controls.MetroTabPage
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents textBox3 As MetroFramework.Controls.MetroTextBox
    Private WithEvents optModeCustomer As MetroFramework.Controls.MetroRadioButton
    Private WithEvents label31 As MetroFramework.Controls.MetroLabel
    Private WithEvents label2 As MetroFramework.Controls.MetroLabel
    Private WithEvents label6 As MetroFramework.Controls.MetroLabel
    Private WithEvents label32 As MetroFramework.Controls.MetroLabel
    Private WithEvents label7 As MetroFramework.Controls.MetroLabel
    Private WithEvents label33 As MetroFramework.Controls.MetroLabel
    Private WithEvents label8 As MetroFramework.Controls.MetroLabel
    Private WithEvents label34 As MetroFramework.Controls.MetroLabel
    Private WithEvents optModeTimePeriod As MetroFramework.Controls.MetroRadioButton
    Private WithEvents label39 As MetroFramework.Controls.MetroLabel
    Private WithEvents label12 As MetroFramework.Controls.MetroLabel
    Private WithEvents optModeChart As MetroFramework.Controls.MetroRadioButton
    Private WithEvents label11 As MetroFramework.Controls.MetroLabel
    Private WithEvents label10 As MetroFramework.Controls.MetroLabel
    Private WithEvents label9 As MetroFramework.Controls.MetroLabel
    Private WithEvents btnNext1 As MetroFramework.Controls.MetroButton
    Private WithEvents tabPage2 As MetroFramework.Controls.MetroTabPage
    Private WithEvents btnPrev2 As MetroFramework.Controls.MetroButton
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label16 As MetroFramework.Controls.MetroLabel
    Private WithEvents cmbSortRow As MetroFramework.Controls.MetroComboBox
    Private WithEvents button9 As MetroFramework.Controls.MetroButton
    Private WithEvents label25 As MetroFramework.Controls.MetroLabel
    Private WithEvents label26 As MetroFramework.Controls.MetroLabel
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label40 As MetroFramework.Controls.MetroLabel
    Private WithEvents label15 As MetroFramework.Controls.MetroLabel
    Private WithEvents cmbSortCell As MetroFramework.Controls.MetroComboBox
    Private WithEvents button1 As MetroFramework.Controls.MetroButton
    Private WithEvents label14 As MetroFramework.Controls.MetroLabel
    Private WithEvents btnNext2 As MetroFramework.Controls.MetroButton
    Private WithEvents tabPage3 As MetroFramework.Controls.MetroTabPage
    Private WithEvents btnPrev3 As MetroFramework.Controls.MetroButton
    Private WithEvents btnNext3 As MetroFramework.Controls.MetroButton
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents cmbPageFormat As MetroFramework.Controls.MetroComboBox
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents label38 As System.Windows.Forms.Label
    Private WithEvents button5 As MetroFramework.Controls.MetroButton
    Private WithEvents button6 As MetroFramework.Controls.MetroButton
    Private WithEvents textProjectTitle As MetroFramework.Controls.MetroTextBox
    Private WithEvents label35 As MetroFramework.Controls.MetroLabel
    Private WithEvents tabPage4 As MetroFramework.Controls.MetroTabPage
    Private WithEvents groupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents label37 As MetroFramework.Controls.MetroLabel
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents label24 As MetroFramework.Controls.MetroLabel
    Private WithEvents label_DefFont As MetroFramework.Controls.MetroLabel
    Private WithEvents label27 As MetroFramework.Controls.MetroLabel
    Private WithEvents label_ProjectTitle As MetroFramework.Controls.MetroLabel
    Private WithEvents label28 As MetroFramework.Controls.MetroLabel
    Private WithEvents label29 As MetroFramework.Controls.MetroLabel
    Private WithEvents label36 As MetroFramework.Controls.MetroLabel
    Private WithEvents label30 As MetroFramework.Controls.MetroLabel
    Private WithEvents label_Row As MetroFramework.Controls.MetroLabel
    Private WithEvents label_Schema As MetroFramework.Controls.MetroLabel
    Private WithEvents label_Cell As MetroFramework.Controls.MetroLabel
    Private WithEvents label_Title As MetroFramework.Controls.MetroLabel
    Private WithEvents button2 As MetroFramework.Controls.MetroButton
    Private WithEvents button4 As MetroFramework.Controls.MetroButton

	#End Region
End Class

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
		Me.LL = New combit.ListLabel25.ListLabel(Me.components)
		Me.label1 = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.tabControl1 = New System.Windows.Forms.TabControl()
		Me.tabPage1 = New System.Windows.Forms.TabPage()
		Me.groupBox5 = New System.Windows.Forms.GroupBox()
		Me.textBox3 = New System.Windows.Forms.TextBox()
		Me.optModeCustomer = New System.Windows.Forms.RadioButton()
		Me.label31 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
		Me.label32 = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.label33 = New System.Windows.Forms.Label()
		Me.label8 = New System.Windows.Forms.Label()
		Me.label34 = New System.Windows.Forms.Label()
		Me.optModeTimePeriod = New System.Windows.Forms.RadioButton()
		Me.label39 = New System.Windows.Forms.Label()
		Me.label12 = New System.Windows.Forms.Label()
		Me.optModeChart = New System.Windows.Forms.RadioButton()
		Me.label11 = New System.Windows.Forms.Label()
		Me.label10 = New System.Windows.Forms.Label()
		Me.label9 = New System.Windows.Forms.Label()
		Me.btnNext1 = New System.Windows.Forms.Button()
		Me.tabPage2 = New System.Windows.Forms.TabPage()
		Me.btnPrev2 = New System.Windows.Forms.Button()
		Me.groupBox2 = New System.Windows.Forms.GroupBox()
		Me.label16 = New System.Windows.Forms.Label()
		Me.cmbSortRow = New System.Windows.Forms.ComboBox()
		Me.button9 = New System.Windows.Forms.Button()
		Me.label25 = New System.Windows.Forms.Label()
		Me.label26 = New System.Windows.Forms.Label()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.label40 = New System.Windows.Forms.Label()
		Me.label15 = New System.Windows.Forms.Label()
		Me.cmbSortCell = New System.Windows.Forms.ComboBox()
		Me.button1 = New System.Windows.Forms.Button()
		Me.label14 = New System.Windows.Forms.Label()
		Me.btnNext2 = New System.Windows.Forms.Button()
		Me.tabPage3 = New System.Windows.Forms.TabPage()
		Me.btnPrev3 = New System.Windows.Forms.Button()
		Me.btnNext3 = New System.Windows.Forms.Button()
		Me.groupBox4 = New System.Windows.Forms.GroupBox()
		Me.cmbPageFormat = New System.Windows.Forms.ComboBox()
		Me.groupBox3 = New System.Windows.Forms.GroupBox()
		Me.label38 = New System.Windows.Forms.Label()
		Me.button5 = New System.Windows.Forms.Button()
		Me.button6 = New System.Windows.Forms.Button()
		Me.textProjectTitle = New System.Windows.Forms.TextBox()
		Me.label35 = New System.Windows.Forms.Label()
		Me.tabPage4 = New System.Windows.Forms.TabPage()
		Me.groupBox6 = New System.Windows.Forms.GroupBox()
		Me.label37 = New System.Windows.Forms.Label()
		Me.pictureBox1 = New System.Windows.Forms.PictureBox()
		Me.label24 = New System.Windows.Forms.Label()
		Me.label_DefFont = New System.Windows.Forms.Label()
		Me.label27 = New System.Windows.Forms.Label()
		Me.label_ProjectTitle = New System.Windows.Forms.Label()
		Me.label28 = New System.Windows.Forms.Label()
		Me.label29 = New System.Windows.Forms.Label()
		Me.label36 = New System.Windows.Forms.Label()
		Me.label30 = New System.Windows.Forms.Label()
		Me.label_Row = New System.Windows.Forms.Label()
		Me.label_Schema = New System.Windows.Forms.Label()
		Me.label_Cell = New System.Windows.Forms.Label()
		Me.label_Title = New System.Windows.Forms.Label()
		Me.button2 = New System.Windows.Forms.Button()
		Me.button4 = New System.Windows.Forms.Button()
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
		Me.label13.Location = New System.Drawing.Point(107, 28)
		Me.label13.Name = "label13"
		Me.label13.Size = New System.Drawing.Size(57, 21)
		Me.label13.TabIndex = 7
		'
		'LL
		'
		Me.LL.AutoBoxType = combit.ListLabel25.LlBoxType.Normalwait
		Me.LL.AutoDestination = combit.ListLabel25.LlPrintMode.Preview
		Me.LL.AutoPrinterSettingsStream = Nothing
		Me.LL.AutoProjectStream = Nothing
		Me.LL.AutoShowPrintOptions = False
		Me.LL.AutoShowSelectFile = False
		Me.LL.DataBindingMode = combit.ListLabel25.DataBindingMode.DelayLoad
		Me.LL.DrilldownAvailable = True
		Me.LL.EMFResolution = 100
		Me.LL.FileRepository = Nothing
		Me.LL.GenericMaximumRecordCount = -1
		Me.LL.LockNextChar = 8288
		Me.LL.MaxRTFVersion = 65280
		Me.LL.PhantomSpace = 8203
		Me.LL.PreviewControl = Nothing
		Me.LL.Unit = combit.ListLabel25.LlUnits.Millimeter_1_10
		Me.LL.UseHardwareCopiesForLabels = False
		Me.LL.UseTableSchemaForDesignMode = False
		'
		'label1
		'
		Me.label1.BackColor = System.Drawing.SystemColors.Control
		Me.label1.Location = New System.Drawing.Point(10, 34)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(24, 16)
		Me.label1.TabIndex = 11
		Me.label1.Text = "US:"
		'
		'label5
		'
		Me.label5.BackColor = System.Drawing.SystemColors.Control
		Me.label5.Location = New System.Drawing.Point(10, 10)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(24, 16)
		Me.label5.TabIndex = 12
		Me.label5.Text = "D:  "
		'
		'label4
		'
		Me.label4.BackColor = System.Drawing.SystemColors.Control
		Me.label4.Location = New System.Drawing.Point(46, 34)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(374, 16)
		Me.label4.TabIndex = 10
		Me.label4.Text = "This sample shows the dynamic creation of List && Label projects."
		'
		'label3
		'
		Me.label3.BackColor = System.Drawing.SystemColors.Control
		Me.label3.Location = New System.Drawing.Point(46, 10)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(429, 16)
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
		Me.tabControl1.Location = New System.Drawing.Point(10, 58)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(462, 300)
		Me.tabControl1.TabIndex = 13
		'
		'tabPage1
		'
		Me.tabPage1.Controls.Add(Me.groupBox5)
		Me.tabPage1.Controls.Add(Me.btnNext1)
		Me.tabPage1.Location = New System.Drawing.Point(4, 25)
		Me.tabPage1.Name = "tabPage1"
		Me.tabPage1.Size = New System.Drawing.Size(454, 271)
		Me.tabPage1.TabIndex = 0
		Me.tabPage1.Text = "1. Data"
		'
		'groupBox5
		'
		Me.groupBox5.BackColor = System.Drawing.SystemColors.Control
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
		Me.groupBox5.Location = New System.Drawing.Point(0, 3)
		Me.groupBox5.Name = "groupBox5"
		Me.groupBox5.Size = New System.Drawing.Size(444, 192)
		Me.groupBox5.TabIndex = 24
		Me.groupBox5.TabStop = False
		'
		'textBox3
		'
		Me.textBox3.Enabled = False
		Me.textBox3.Location = New System.Drawing.Point(118, 158)
		Me.textBox3.Name = "textBox3"
		Me.textBox3.Size = New System.Drawing.Size(308, 20)
		Me.textBox3.TabIndex = 22
		Me.textBox3.Text = "Total employees turnover"
		'
		'optModeCustomer
		'
		Me.optModeCustomer.Checked = True
		Me.optModeCustomer.Location = New System.Drawing.Point(9, 24)
		Me.optModeCustomer.Name = "optModeCustomer"
		Me.optModeCustomer.Size = New System.Drawing.Size(14, 13)
		Me.optModeCustomer.TabIndex = 0
		Me.optModeCustomer.TabStop = True
		'
		'label31
		'
		Me.label31.AutoSize = True
		Me.label31.Enabled = False
		Me.label31.Location = New System.Drawing.Point(82, 161)
		Me.label31.Name = "label31"
		Me.label31.Size = New System.Drawing.Size(30, 13)
		Me.label31.TabIndex = 23
		Me.label31.Text = "Title:"
		'
		'label2
		'
		Me.label2.AutoSize = True
		Me.label2.Location = New System.Drawing.Point(31, 23)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(18, 13)
		Me.label2.TabIndex = 1
		Me.label2.Text = "D:"
		'
		'label6
		'
		Me.label6.AutoSize = True
		Me.label6.Location = New System.Drawing.Point(31, 43)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(25, 13)
		Me.label6.TabIndex = 2
		Me.label6.Text = "US:"
		'
		'label32
		'
		Me.label32.AutoSize = True
		Me.label32.Location = New System.Drawing.Point(80, 135)
		Me.label32.Name = "label32"
		Me.label32.Size = New System.Drawing.Size(200, 13)
		Me.label32.TabIndex = 21
		Me.label32.Text = "Report employees turnover within a chart"
		'
		'label7
		'
		Me.label7.AutoSize = True
		Me.label7.Location = New System.Drawing.Point(80, 23)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(314, 13)
		Me.label7.TabIndex = 3
		Me.label7.Text = "Auswertung der Verkäufe nach Land innerhalb einer Kreuztabelle"
		'
		'label33
		'
		Me.label33.AutoSize = True
		Me.label33.Location = New System.Drawing.Point(80, 114)
		Me.label33.Name = "label33"
		Me.label33.Size = New System.Drawing.Size(209, 13)
		Me.label33.TabIndex = 20
		Me.label33.Text = "Übersicht der einzelnen Mitarbeiterumsätze"
		'
		'label8
		'
		Me.label8.AutoSize = True
		Me.label8.Location = New System.Drawing.Point(80, 43)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(267, 13)
		Me.label8.TabIndex = 4
		Me.label8.Text = "Report employee turnover per country within a crosstab"
		'
		'label34
		'
		Me.label34.AutoSize = True
		Me.label34.Location = New System.Drawing.Point(31, 135)
		Me.label34.Name = "label34"
		Me.label34.Size = New System.Drawing.Size(25, 13)
		Me.label34.TabIndex = 19
		Me.label34.Text = "US:"
		'
		'optModeTimePeriod
		'
		Me.optModeTimePeriod.Location = New System.Drawing.Point(9, 70)
		Me.optModeTimePeriod.Name = "optModeTimePeriod"
		Me.optModeTimePeriod.Size = New System.Drawing.Size(14, 13)
		Me.optModeTimePeriod.TabIndex = 5
		'
		'label39
		'
		Me.label39.AutoSize = True
		Me.label39.Location = New System.Drawing.Point(31, 114)
		Me.label39.Name = "label39"
		Me.label39.Size = New System.Drawing.Size(18, 13)
		Me.label39.TabIndex = 18
		Me.label39.Text = "D:"
		'
		'label12
		'
		Me.label12.AutoSize = True
		Me.label12.Location = New System.Drawing.Point(31, 70)
		Me.label12.Name = "label12"
		Me.label12.Size = New System.Drawing.Size(18, 13)
		Me.label12.TabIndex = 6
		Me.label12.Text = "D:"
		'
		'optModeChart
		'
		Me.optModeChart.Location = New System.Drawing.Point(9, 114)
		Me.optModeChart.Name = "optModeChart"
		Me.optModeChart.Size = New System.Drawing.Size(14, 13)
		Me.optModeChart.TabIndex = 17
		'
		'label11
		'
		Me.label11.AutoSize = True
		Me.label11.Location = New System.Drawing.Point(31, 90)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(25, 13)
		Me.label11.TabIndex = 7
		Me.label11.Text = "US:"
		'
		'label10
		'
		Me.label10.AutoSize = True
		Me.label10.Location = New System.Drawing.Point(80, 70)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(331, 13)
		Me.label10.TabIndex = 8
		Me.label10.Text = "Auswertung der Verkäufe nach Zeitraum innerhalb einer Kreuztabelle"
		'
		'label9
		'
		Me.label9.AutoSize = True
		Me.label9.Location = New System.Drawing.Point(80, 90)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(235, 13)
		Me.label9.TabIndex = 9
		Me.label9.Text = "Report turnover per time period within a crosstab"
		'
		'btnNext1
		'
		Me.btnNext1.Location = New System.Drawing.Point(347, 239)
		Me.btnNext1.Name = "btnNext1"
		Me.btnNext1.Size = New System.Drawing.Size(93, 24)
		Me.btnNext1.TabIndex = 15
		Me.btnNext1.Text = "Next >"
		'
		'tabPage2
		'
		Me.tabPage2.Controls.Add(Me.btnPrev2)
		Me.tabPage2.Controls.Add(Me.groupBox2)
		Me.tabPage2.Controls.Add(Me.groupBox1)
		Me.tabPage2.Controls.Add(Me.btnNext2)
		Me.tabPage2.Location = New System.Drawing.Point(4, 25)
		Me.tabPage2.Name = "tabPage2"
		Me.tabPage2.Size = New System.Drawing.Size(454, 271)
		Me.tabPage2.TabIndex = 1
		Me.tabPage2.Text = "2. Crosstab properties"
		'
		'btnPrev2
		'
		Me.btnPrev2.Location = New System.Drawing.Point(251, 239)
		Me.btnPrev2.Name = "btnPrev2"
		Me.btnPrev2.Size = New System.Drawing.Size(93, 24)
		Me.btnPrev2.TabIndex = 20
		Me.btnPrev2.Text = "< Previous"
		'
		'groupBox2
		'
		Me.groupBox2.BackColor = System.Drawing.SystemColors.Control
		Me.groupBox2.Controls.Add(Me.label16)
		Me.groupBox2.Controls.Add(Me.cmbSortRow)
		Me.groupBox2.Controls.Add(Me.button9)
		Me.groupBox2.Controls.Add(Me.label25)
		Me.groupBox2.Controls.Add(Me.label26)
		Me.groupBox2.Location = New System.Drawing.Point(0, 60)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(440, 55)
		Me.groupBox2.TabIndex = 18
		Me.groupBox2.TabStop = False
		Me.groupBox2.Text = "Row-Properties"
		'
		'label16
		'
		Me.label16.AutoSize = True
		Me.label16.Location = New System.Drawing.Point(213, 20)
		Me.label16.Name = "label16"
		Me.label16.Size = New System.Drawing.Size(56, 13)
		Me.label16.TabIndex = 19
		Me.label16.Text = "Sort order:"
		'
		'cmbSortRow
		'
		Me.cmbSortRow.ItemHeight = 13
		Me.cmbSortRow.Items.AddRange(New Object() {"Ascending (A > Z)", "Descending (Z > A)"})
		Me.cmbSortRow.Location = New System.Drawing.Point(283, 20)
		Me.cmbSortRow.Name = "cmbSortRow"
		Me.cmbSortRow.Size = New System.Drawing.Size(147, 21)
		Me.cmbSortRow.TabIndex = 18
		'
		'button9
		'
		Me.button9.Location = New System.Drawing.Point(180, 20)
		Me.button9.Name = "button9"
		Me.button9.Size = New System.Drawing.Size(27, 21)
		Me.button9.TabIndex = 11
		Me.button9.Text = "..."
		'
		'label25
		'
		Me.label25.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(42, Byte), Integer))
		Me.label25.Location = New System.Drawing.Point(122, 20)
		Me.label25.Name = "label25"
		Me.label25.Size = New System.Drawing.Size(57, 21)
		Me.label25.TabIndex = 10
		'
		'label26
		'
		Me.label26.AutoSize = True
		Me.label26.Location = New System.Drawing.Point(6, 20)
		Me.label26.Name = "label26"
		Me.label26.Size = New System.Drawing.Size(84, 13)
		Me.label26.TabIndex = 9
		Me.label26.Text = "Row-BackColor:"
		'
		'groupBox1
		'
		Me.groupBox1.BackColor = System.Drawing.SystemColors.Control
		Me.groupBox1.Controls.Add(Me.label40)
		Me.groupBox1.Controls.Add(Me.label15)
		Me.groupBox1.Controls.Add(Me.cmbSortCell)
		Me.groupBox1.Controls.Add(Me.button1)
		Me.groupBox1.Controls.Add(Me.label14)
		Me.groupBox1.Location = New System.Drawing.Point(0, 6)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(440, 55)
		Me.groupBox1.TabIndex = 6
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "Column-Properties"
		'
		'label40
		'
		Me.label40.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(88, Byte), Integer))
		Me.label40.Location = New System.Drawing.Point(122, 20)
		Me.label40.Name = "label40"
		Me.label40.Size = New System.Drawing.Size(57, 21)
		Me.label40.TabIndex = 17
		'
		'label15
		'
		Me.label15.AutoSize = True
		Me.label15.Location = New System.Drawing.Point(213, 20)
		Me.label15.Name = "label15"
		Me.label15.Size = New System.Drawing.Size(56, 13)
		Me.label15.TabIndex = 16
		Me.label15.Text = "Sort order:"
		'
		'cmbSortCell
		'
		Me.cmbSortCell.ItemHeight = 13
		Me.cmbSortCell.Items.AddRange(New Object() {"Ascending (A > Z)", "Descending (Z > A)"})
		Me.cmbSortCell.Location = New System.Drawing.Point(283, 20)
		Me.cmbSortCell.Name = "cmbSortCell"
		Me.cmbSortCell.Size = New System.Drawing.Size(147, 21)
		Me.cmbSortCell.TabIndex = 15
		'
		'button1
		'
		Me.button1.Location = New System.Drawing.Point(180, 20)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(27, 21)
		Me.button1.TabIndex = 8
		Me.button1.Text = "..."
		'
		'label14
		'
		Me.label14.AutoSize = True
		Me.label14.Location = New System.Drawing.Point(6, 20)
		Me.label14.Name = "label14"
		Me.label14.Size = New System.Drawing.Size(97, 13)
		Me.label14.TabIndex = 6
		Me.label14.Text = "Column-BackColor:"
		'
		'btnNext2
		'
		Me.btnNext2.Location = New System.Drawing.Point(347, 239)
		Me.btnNext2.Name = "btnNext2"
		Me.btnNext2.Size = New System.Drawing.Size(93, 24)
		Me.btnNext2.TabIndex = 19
		Me.btnNext2.Text = "Next >"
		'
		'tabPage3
		'
		Me.tabPage3.Controls.Add(Me.btnPrev3)
		Me.tabPage3.Controls.Add(Me.btnNext3)
		Me.tabPage3.Controls.Add(Me.groupBox4)
		Me.tabPage3.Controls.Add(Me.groupBox3)
		Me.tabPage3.Controls.Add(Me.textProjectTitle)
		Me.tabPage3.Controls.Add(Me.label35)
		Me.tabPage3.Location = New System.Drawing.Point(4, 25)
		Me.tabPage3.Name = "tabPage3"
		Me.tabPage3.Size = New System.Drawing.Size(454, 271)
		Me.tabPage3.TabIndex = 4
		Me.tabPage3.Text = "3. General settings"
		'
		'btnPrev3
		'
		Me.btnPrev3.Location = New System.Drawing.Point(251, 239)
		Me.btnPrev3.Name = "btnPrev3"
		Me.btnPrev3.Size = New System.Drawing.Size(93, 24)
		Me.btnPrev3.TabIndex = 19
		Me.btnPrev3.Text = "< Previous"
		'
		'btnNext3
		'
		Me.btnNext3.Location = New System.Drawing.Point(347, 239)
		Me.btnNext3.Name = "btnNext3"
		Me.btnNext3.Size = New System.Drawing.Size(93, 24)
		Me.btnNext3.TabIndex = 18
		Me.btnNext3.Text = "Finish"
		'
		'groupBox4
		'
		Me.groupBox4.BackColor = System.Drawing.SystemColors.Control
		Me.groupBox4.Controls.Add(Me.cmbPageFormat)
		Me.groupBox4.Location = New System.Drawing.Point(0, 138)
		Me.groupBox4.Name = "groupBox4"
		Me.groupBox4.Size = New System.Drawing.Size(440, 57)
		Me.groupBox4.TabIndex = 17
		Me.groupBox4.TabStop = False
		Me.groupBox4.Text = "Page format"
		'
		'cmbPageFormat
		'
		Me.cmbPageFormat.ItemHeight = 13
		Me.cmbPageFormat.Items.AddRange(New Object() {"Portrait", "Landscape"})
		Me.cmbPageFormat.Location = New System.Drawing.Point(6, 19)
		Me.cmbPageFormat.Name = "cmbPageFormat"
		Me.cmbPageFormat.Size = New System.Drawing.Size(147, 21)
		Me.cmbPageFormat.TabIndex = 1
		'
		'groupBox3
		'
		Me.groupBox3.BackColor = System.Drawing.SystemColors.Control
		Me.groupBox3.Controls.Add(Me.label38)
		Me.groupBox3.Controls.Add(Me.button5)
		Me.groupBox3.Controls.Add(Me.button6)
		Me.groupBox3.Location = New System.Drawing.Point(0, 58)
		Me.groupBox3.Name = "groupBox3"
		Me.groupBox3.Size = New System.Drawing.Size(440, 74)
		Me.groupBox3.TabIndex = 16
		Me.groupBox3.TabStop = False
		Me.groupBox3.Text = "Default Font"
		'
		'label38
		'
		Me.label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.label38.Location = New System.Drawing.Point(6, 23)
		Me.label38.Name = "label38"
		Me.label38.Size = New System.Drawing.Size(323, 39)
		Me.label38.TabIndex = 18
		Me.label38.Text = "Sample text"
		Me.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'button5
		'
		Me.button5.Location = New System.Drawing.Point(335, 31)
		Me.button5.Name = "button5"
		Me.button5.Size = New System.Drawing.Size(27, 21)
		Me.button5.TabIndex = 17
		Me.button5.Text = "..."
		'
		'button6
		'
		Me.button6.Location = New System.Drawing.Point(368, 31)
		Me.button6.Name = "button6"
		Me.button6.Size = New System.Drawing.Size(59, 21)
		Me.button6.TabIndex = 16
		Me.button6.Text = "Color..."
		'
		'textProjectTitle
		'
		Me.textProjectTitle.BackColor = System.Drawing.SystemColors.Window
		Me.textProjectTitle.Location = New System.Drawing.Point(0, 21)
		Me.textProjectTitle.Name = "textProjectTitle"
		Me.textProjectTitle.Size = New System.Drawing.Size(440, 20)
		Me.textProjectTitle.TabIndex = 13
		Me.textProjectTitle.Text = "This sample shows advanced dynamic project creation."
		'
		'label35
		'
		Me.label35.AutoSize = True
		Me.label35.Location = New System.Drawing.Point(0, 3)
		Me.label35.Name = "label35"
		Me.label35.Size = New System.Drawing.Size(61, 13)
		Me.label35.TabIndex = 12
		Me.label35.Text = "Report title:"
		'
		'tabPage4
		'
		Me.tabPage4.Controls.Add(Me.groupBox6)
		Me.tabPage4.Controls.Add(Me.button2)
		Me.tabPage4.Controls.Add(Me.button4)
		Me.tabPage4.Location = New System.Drawing.Point(4, 25)
		Me.tabPage4.Name = "tabPage4"
		Me.tabPage4.Size = New System.Drawing.Size(454, 271)
		Me.tabPage4.TabIndex = 3
		Me.tabPage4.Text = "4. Finish"
		'
		'groupBox6
		'
		Me.groupBox6.BackColor = System.Drawing.SystemColors.Control
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
		Me.groupBox6.Location = New System.Drawing.Point(0, 3)
		Me.groupBox6.Name = "groupBox6"
		Me.groupBox6.Size = New System.Drawing.Size(440, 228)
		Me.groupBox6.TabIndex = 32
		Me.groupBox6.TabStop = False
		'
		'label37
		'
		Me.label37.AutoSize = True
		Me.label37.BackColor = System.Drawing.SystemColors.Control
		Me.label37.Location = New System.Drawing.Point(3, 203)
		Me.label37.Name = "label37"
		Me.label37.Size = New System.Drawing.Size(71, 13)
		Me.label37.TabIndex = 29
		Me.label37.Text = "- Default font:"
		'
		'pictureBox1
		'
		Me.pictureBox1.BackColor = System.Drawing.SystemColors.Control
		Me.pictureBox1.Location = New System.Drawing.Point(6, 19)
		Me.pictureBox1.Name = "pictureBox1"
		Me.pictureBox1.Size = New System.Drawing.Size(50, 37)
		Me.pictureBox1.TabIndex = 18
		Me.pictureBox1.TabStop = False
		'
		'label24
		'
		Me.label24.BackColor = System.Drawing.SystemColors.Control
		Me.label24.Location = New System.Drawing.Point(62, 19)
		Me.label24.Name = "label24"
		Me.label24.Size = New System.Drawing.Size(372, 37)
		Me.label24.TabIndex = 19
		Me.label24.Text = "The List && Label project will be created with the following options:"
		'
		'label_DefFont
		'
		Me.label_DefFont.BackColor = System.Drawing.SystemColors.Control
		Me.label_DefFont.Location = New System.Drawing.Point(85, 203)
		Me.label_DefFont.Name = "label_DefFont"
		Me.label_DefFont.Size = New System.Drawing.Size(349, 15)
		Me.label_DefFont.TabIndex = 31
		'
		'label27
		'
		Me.label27.AutoSize = True
		Me.label27.BackColor = System.Drawing.SystemColors.Control
		Me.label27.Location = New System.Drawing.Point(3, 73)
		Me.label27.Name = "label27"
		Me.label27.Size = New System.Drawing.Size(55, 13)
		Me.label27.TabIndex = 20
		Me.label27.Text = "- Schema:"
		'
		'label_ProjectTitle
		'
		Me.label_ProjectTitle.BackColor = System.Drawing.SystemColors.Control
		Me.label_ProjectTitle.Location = New System.Drawing.Point(85, 177)
		Me.label_ProjectTitle.Name = "label_ProjectTitle"
		Me.label_ProjectTitle.Size = New System.Drawing.Size(349, 15)
		Me.label_ProjectTitle.TabIndex = 30
		'
		'label28
		'
		Me.label28.AutoSize = True
		Me.label28.BackColor = System.Drawing.SystemColors.Control
		Me.label28.Location = New System.Drawing.Point(3, 98)
		Me.label28.Name = "label28"
		Me.label28.Size = New System.Drawing.Size(60, 13)
		Me.label28.TabIndex = 21
		Me.label28.Text = "- Chart title:"
		'
		'label29
		'
		Me.label29.AutoSize = True
		Me.label29.BackColor = System.Drawing.SystemColors.Control
		Me.label29.Location = New System.Drawing.Point(3, 124)
		Me.label29.Name = "label29"
		Me.label29.Size = New System.Drawing.Size(51, 13)
		Me.label29.TabIndex = 22
		Me.label29.Text = "- Column:"
		'
		'label36
		'
		Me.label36.AutoSize = True
		Me.label36.BackColor = System.Drawing.SystemColors.Control
		Me.label36.Location = New System.Drawing.Point(3, 177)
		Me.label36.Name = "label36"
		Me.label36.Size = New System.Drawing.Size(68, 13)
		Me.label36.TabIndex = 28
		Me.label36.Text = "- Project title:"
		'
		'label30
		'
		Me.label30.AutoSize = True
		Me.label30.BackColor = System.Drawing.SystemColors.Control
		Me.label30.Location = New System.Drawing.Point(3, 150)
		Me.label30.Name = "label30"
		Me.label30.Size = New System.Drawing.Size(38, 13)
		Me.label30.TabIndex = 23
		Me.label30.Text = "- Row:"
		'
		'label_Row
		'
		Me.label_Row.BackColor = System.Drawing.SystemColors.Control
		Me.label_Row.Location = New System.Drawing.Point(85, 150)
		Me.label_Row.Name = "label_Row"
		Me.label_Row.Size = New System.Drawing.Size(349, 15)
		Me.label_Row.TabIndex = 27
		'
		'label_Schema
		'
		Me.label_Schema.BackColor = System.Drawing.SystemColors.Control
		Me.label_Schema.Location = New System.Drawing.Point(85, 73)
		Me.label_Schema.Name = "label_Schema"
		Me.label_Schema.Size = New System.Drawing.Size(349, 15)
		Me.label_Schema.TabIndex = 24
		'
		'label_Cell
		'
		Me.label_Cell.BackColor = System.Drawing.SystemColors.Control
		Me.label_Cell.Location = New System.Drawing.Point(85, 124)
		Me.label_Cell.Name = "label_Cell"
		Me.label_Cell.Size = New System.Drawing.Size(349, 15)
		Me.label_Cell.TabIndex = 26
		'
		'label_Title
		'
		Me.label_Title.BackColor = System.Drawing.SystemColors.Control
		Me.label_Title.Location = New System.Drawing.Point(85, 98)
		Me.label_Title.Name = "label_Title"
		Me.label_Title.Size = New System.Drawing.Size(349, 15)
		Me.label_Title.TabIndex = 25
		'
		'button2
		'
		Me.button2.Location = New System.Drawing.Point(250, 239)
		Me.button2.Name = "button2"
		Me.button2.Size = New System.Drawing.Size(93, 24)
		Me.button2.TabIndex = 17
		Me.button2.Text = "Design..."
		'
		'button4
		'
		Me.button4.Location = New System.Drawing.Point(347, 239)
		Me.button4.Name = "button4"
		Me.button4.Size = New System.Drawing.Size(93, 24)
		Me.button4.TabIndex = 14
		Me.button4.Text = "Preview..."
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(472, 354)
		Me.Controls.Add(Me.tabControl1)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.label5)
		Me.Controls.Add(Me.label4)
		Me.Controls.Add(Me.label3)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Form1"
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
	Private WithEvents LL As combit.ListLabel25.ListLabel
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents fontDialog1 As System.Windows.Forms.FontDialog
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents textBox3 As System.Windows.Forms.TextBox
    Private WithEvents optModeCustomer As System.Windows.Forms.RadioButton
    Private WithEvents label31 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label32 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label33 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label34 As System.Windows.Forms.Label
    Private WithEvents optModeTimePeriod As System.Windows.Forms.RadioButton
    Private WithEvents label39 As System.Windows.Forms.Label
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents optModeChart As System.Windows.Forms.RadioButton
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents btnNext1 As System.Windows.Forms.Button
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents btnPrev2 As System.Windows.Forms.Button
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents cmbSortRow As System.Windows.Forms.ComboBox
    Private WithEvents button9 As System.Windows.Forms.Button
    Private WithEvents label25 As System.Windows.Forms.Label
    Private WithEvents label26 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label40 As System.Windows.Forms.Label
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents cmbSortCell As System.Windows.Forms.ComboBox
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents btnNext2 As System.Windows.Forms.Button
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents btnPrev3 As System.Windows.Forms.Button
    Private WithEvents btnNext3 As System.Windows.Forms.Button
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents cmbPageFormat As System.Windows.Forms.ComboBox
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents label38 As System.Windows.Forms.Label
    Private WithEvents button5 As System.Windows.Forms.Button
    Private WithEvents button6 As System.Windows.Forms.Button
    Private WithEvents textProjectTitle As System.Windows.Forms.TextBox
    Private WithEvents label35 As System.Windows.Forms.Label
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents groupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents label37 As System.Windows.Forms.Label
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents label_DefFont As System.Windows.Forms.Label
    Private WithEvents label27 As System.Windows.Forms.Label
    Private WithEvents label_ProjectTitle As System.Windows.Forms.Label
    Private WithEvents label28 As System.Windows.Forms.Label
    Private WithEvents label29 As System.Windows.Forms.Label
    Private WithEvents label36 As System.Windows.Forms.Label
    Private WithEvents label30 As System.Windows.Forms.Label
    Private WithEvents label_Row As System.Windows.Forms.Label
    Private WithEvents label_Schema As System.Windows.Forms.Label
    Private WithEvents label_Cell As System.Windows.Forms.Label
    Private WithEvents label_Title As System.Windows.Forms.Label
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button4 As System.Windows.Forms.Button
#End Region
End Class

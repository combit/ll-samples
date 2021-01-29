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
		Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.button5 = New System.Windows.Forms.Button()
		Me.button4 = New System.Windows.Forms.Button()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.button3 = New System.Windows.Forms.Button()
		Me.textBox2 = New System.Windows.Forms.TextBox()
		Me.label10 = New System.Windows.Forms.Label()
		Me.textBox1 = New System.Windows.Forms.TextBox()
		Me.label9 = New System.Windows.Forms.Label()
		Me.button2 = New System.Windows.Forms.Button()
		Me.button1 = New System.Windows.Forms.Button()
		Me.listBox2 = New System.Windows.Forms.ListBox()
		Me.listBox1 = New System.Windows.Forms.ListBox()
		Me.label7 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
		Me.comboBoxTable = New System.Windows.Forms.ComboBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.groupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'LL
		'
		Me.LL.AutoDestination = combit.Reporting.LlPrintMode.Preview
		Me.LL.AutoPrinterSettingsStream = Nothing
		Me.LL.AutoProjectStream = Nothing
		Me.LL.AutoShowPrintOptions = False
		Me.LL.AutoShowSelectFile = False
		Me.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad
		Me.LL.DrilldownAvailable = True
		Me.LL.EMFResolution = 100
		Me.LL.FileRepository = Nothing
		Me.LL.GenericMaximumRecordCount = -1
		Me.LL.LockNextChar = 8288
		Me.LL.MaxRTFVersion = 65280
		Me.LL.PhantomSpace = 8203
		Me.LL.PreviewControl = Nothing
		Me.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_10
		Me.LL.UseHardwareCopiesForLabels = False
		Me.LL.UseTableSchemaForDesignMode = False
		'
		'openFileDialog1
		'
		Me.openFileDialog1.FileName = "sunshine.gif"
		Me.openFileDialog1.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|A" &
	"ll Files (*.*)|*.*"
		'
		'button5
		'
		Me.button5.Location = New System.Drawing.Point(289, 380)
		Me.button5.Name = "button5"
		Me.button5.Size = New System.Drawing.Size(106, 26)
		Me.button5.TabIndex = 20
		Me.button5.Text = "Design..."
		'
		'button4
		'
		Me.button4.Location = New System.Drawing.Point(401, 380)
		Me.button4.Name = "button4"
		Me.button4.Size = New System.Drawing.Size(106, 26)
		Me.button4.TabIndex = 19
		Me.button4.Text = "Preview..."
		'
		'groupBox1
		'
		Me.groupBox1.Controls.Add(Me.label2)
		Me.groupBox1.Controls.Add(Me.button3)
		Me.groupBox1.Controls.Add(Me.textBox2)
		Me.groupBox1.Controls.Add(Me.label10)
		Me.groupBox1.Controls.Add(Me.textBox1)
		Me.groupBox1.Controls.Add(Me.label9)
		Me.groupBox1.Controls.Add(Me.button2)
		Me.groupBox1.Controls.Add(Me.button1)
		Me.groupBox1.Controls.Add(Me.listBox2)
		Me.groupBox1.Controls.Add(Me.listBox1)
		Me.groupBox1.Controls.Add(Me.label7)
		Me.groupBox1.Controls.Add(Me.label6)
		Me.groupBox1.Controls.Add(Me.comboBoxTable)
		Me.groupBox1.Location = New System.Drawing.Point(10, 53)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(497, 318)
		Me.groupBox1.TabIndex = 18
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "Project Layout"
		'
		'label2
		'
		Me.label2.AutoSize = True
		Me.label2.Location = New System.Drawing.Point(6, 23)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(37, 13)
		Me.label2.TabIndex = 21
		Me.label2.Text = "Table:"
		'
		'button3
		'
		Me.button3.Location = New System.Drawing.Point(457, 285)
		Me.button3.Name = "button3"
		Me.button3.Size = New System.Drawing.Size(27, 19)
		Me.button3.TabIndex = 20
		Me.button3.Text = "..."
		'
		'textBox2
		'
		Me.textBox2.BackColor = System.Drawing.SystemColors.Window
		Me.textBox2.Location = New System.Drawing.Point(6, 285)
		Me.textBox2.Name = "textBox2"
		Me.textBox2.Size = New System.Drawing.Size(445, 20)
		Me.textBox2.TabIndex = 19
		'
		'label10
		'
		Me.label10.AutoSize = True
		Me.label10.Location = New System.Drawing.Point(6, 269)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(34, 13)
		Me.label10.TabIndex = 18
		Me.label10.Text = "Logo:"
		'
		'textBox1
		'
		Me.textBox1.BackColor = System.Drawing.SystemColors.Window
		Me.textBox1.Location = New System.Drawing.Point(6, 236)
		Me.textBox1.Name = "textBox1"
		Me.textBox1.Size = New System.Drawing.Size(478, 20)
		Me.textBox1.TabIndex = 17
		Me.textBox1.Text = "Dynamically created project"
		'
		'label9
		'
		Me.label9.AutoSize = True
		Me.label9.Location = New System.Drawing.Point(6, 220)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(30, 13)
		Me.label9.TabIndex = 16
		Me.label9.Text = "Title:"
		'
		'button2
		'
		Me.button2.Location = New System.Drawing.Point(226, 156)
		Me.button2.Name = "button2"
		Me.button2.Size = New System.Drawing.Size(35, 30)
		Me.button2.TabIndex = 15
		Me.button2.Text = "<"
		'
		'button1
		'
		Me.button1.Location = New System.Drawing.Point(226, 120)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(35, 30)
		Me.button1.TabIndex = 14
		Me.button1.Text = ">"
		'
		'listBox2
		'
		Me.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.listBox2.Location = New System.Drawing.Point(267, 88)
		Me.listBox2.Name = "listBox2"
		Me.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
		Me.listBox2.Size = New System.Drawing.Size(217, 121)
		Me.listBox2.Sorted = True
		Me.listBox2.TabIndex = 13
		'
		'listBox1
		'
		Me.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.listBox1.Location = New System.Drawing.Point(6, 88)
		Me.listBox1.Name = "listBox1"
		Me.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
		Me.listBox1.Size = New System.Drawing.Size(214, 121)
		Me.listBox1.Sorted = True
		Me.listBox1.TabIndex = 12
		'
		'label7
		'
		Me.label7.AutoSize = True
		Me.label7.Location = New System.Drawing.Point(264, 72)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(82, 13)
		Me.label7.TabIndex = 11
		Me.label7.Text = "Selected Fields:"
		'
		'label6
		'
		Me.label6.AutoSize = True
		Me.label6.Location = New System.Drawing.Point(6, 72)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(83, 13)
		Me.label6.TabIndex = 10
		Me.label6.Text = "Available Fields:"
		'
		'comboBoxTable
		'
		Me.comboBoxTable.ItemHeight = 13
		Me.comboBoxTable.Location = New System.Drawing.Point(6, 40)
		Me.comboBoxTable.Name = "comboBoxTable"
		Me.comboBoxTable.Size = New System.Drawing.Size(478, 21)
		Me.comboBoxTable.TabIndex = 9
		'
		'label1
		'
		Me.label1.BackColor = System.Drawing.SystemColors.Control
		Me.label1.Location = New System.Drawing.Point(20, 32)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(24, 16)
		Me.label1.TabIndex = 16
		Me.label1.Text = "US:"
		'
		'label5
		'
		Me.label5.BackColor = System.Drawing.SystemColors.Control
		Me.label5.Location = New System.Drawing.Point(20, 10)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(24, 16)
		Me.label5.TabIndex = 17
		Me.label5.Text = "D:  "
		'
		'label4
		'
		Me.label4.BackColor = System.Drawing.SystemColors.Control
		Me.label4.Location = New System.Drawing.Point(44, 32)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(450, 16)
		Me.label4.TabIndex = 15
		Me.label4.Text = "This sample shows the dynamic creation of List && Label projects."
		'
		'label3
		'
		Me.label3.BackColor = System.Drawing.SystemColors.Control
		Me.label3.Location = New System.Drawing.Point(44, 10)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(450, 16)
		Me.label3.TabIndex = 14
		Me.label3.Text = "Dieses Beispiel zeigt die dynamische Erstellung von List && Label Projekten."
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(516, 416)
		Me.Controls.Add(Me.button5)
		Me.Controls.Add(Me.button4)
		Me.Controls.Add(Me.groupBox1)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.label5)
		Me.Controls.Add(Me.label4)
		Me.Controls.Add(Me.label3)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Form1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "List & Label DOM Simple VB.NET Sample"
		Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Private WithEvents LL As combit.Reporting.ListLabel
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents button5 As System.Windows.Forms.Button
    Private WithEvents button4 As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents textBox2 As System.Windows.Forms.TextBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents listBox2 As System.Windows.Forms.ListBox
    Private WithEvents listBox1 As System.Windows.Forms.ListBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents comboBoxTable As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
#End Region
End Class

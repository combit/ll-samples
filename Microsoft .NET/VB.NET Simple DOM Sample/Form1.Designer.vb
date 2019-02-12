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
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.button5 = New MetroFramework.Controls.MetroButton()
        Me.button4 = New MetroFramework.Controls.MetroButton()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label2 = New MetroFramework.Controls.MetroLabel()
        Me.button3 = New MetroFramework.Controls.MetroButton()
        Me.textBox2 = New MetroFramework.Controls.MetroTextBox()
        Me.label10 = New MetroFramework.Controls.MetroLabel()
        Me.textBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.label9 = New MetroFramework.Controls.MetroLabel()
        Me.button2 = New MetroFramework.Controls.MetroButton()
        Me.button1 = New MetroFramework.Controls.MetroButton()
        Me.listBox2 = New System.Windows.Forms.ListBox()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.label7 = New MetroFramework.Controls.MetroLabel()
        Me.label6 = New MetroFramework.Controls.MetroLabel()
        Me.comboBoxTable = New MetroFramework.Controls.MetroComboBox()
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.label5 = New MetroFramework.Controls.MetroLabel()
        Me.label4 = New MetroFramework.Controls.MetroLabel()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LL
        '
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
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "sunshine.gif"
        Me.openFileDialog1.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|A" & _
    "ll Files (*.*)|*.*"
        '
        'button5
        '
        Me.button5.Location = New System.Drawing.Point(292, 444)
        Me.button5.Name = "button5"
        Me.button5.Size = New System.Drawing.Size(106, 26)
        Me.button5.TabIndex = 20
        Me.button5.Text = "Design..."
        Me.button5.UseSelectable = True
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(404, 444)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(106, 26)
        Me.button4.TabIndex = 19
        Me.button4.Text = "Preview..."
        Me.button4.UseSelectable = True
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
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(13, 103)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(497, 335)
        Me.groupBox1.TabIndex = 18
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Project Layout"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label2.Location = New System.Drawing.Point(6, 23)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(35, 15)
        Me.label2.TabIndex = 21
        Me.label2.Text = "Table:"
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(457, 299)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(27, 19)
        Me.button3.TabIndex = 20
        Me.button3.Text = "..."
        Me.button3.UseSelectable = True
        '
        'textBox2
        '
        Me.textBox2.BackColor = System.Drawing.SystemColors.Window
        Me.textBox2.Lines = New String(-1) {}
        Me.textBox2.Location = New System.Drawing.Point(6, 299)
        Me.textBox2.MaxLength = 32767
        Me.textBox2.Name = "textBox2"
        Me.textBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.textBox2.SelectedText = ""
        Me.textBox2.Size = New System.Drawing.Size(445, 20)
        Me.textBox2.TabIndex = 19
        Me.textBox2.UseCustomBackColor = True
        Me.textBox2.UseSelectable = True
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label10.Location = New System.Drawing.Point(6, 283)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(36, 15)
        Me.label10.TabIndex = 18
        Me.label10.Text = "Logo:"
        '
        'textBox1
        '
        Me.textBox1.BackColor = System.Drawing.SystemColors.Window
        Me.textBox1.Lines = New String() {"Dynamically created project"}
        Me.textBox1.Location = New System.Drawing.Point(6, 250)
        Me.textBox1.MaxLength = 32767
        Me.textBox1.Name = "textBox1"
        Me.textBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.textBox1.SelectedText = ""
        Me.textBox1.Size = New System.Drawing.Size(478, 20)
        Me.textBox1.TabIndex = 17
        Me.textBox1.Text = "Dynamically created project"
        Me.textBox1.UseCustomBackColor = True
        Me.textBox1.UseSelectable = True
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label9.Location = New System.Drawing.Point(6, 234)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(30, 15)
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
        Me.button2.UseSelectable = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(226, 120)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(35, 30)
        Me.button1.TabIndex = 14
        Me.button1.Text = ">"
        Me.button1.UseSelectable = True
        '
        'listBox2
        '
        Me.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listBox2.Location = New System.Drawing.Point(267, 88)
        Me.listBox2.Name = "listBox2"
        Me.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.listBox2.Size = New System.Drawing.Size(217, 132)
        Me.listBox2.Sorted = True
        Me.listBox2.TabIndex = 13
        '
        'listBox1
        '
        Me.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listBox1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listBox1.Location = New System.Drawing.Point(6, 88)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.listBox1.Size = New System.Drawing.Size(214, 132)
        Me.listBox1.Sorted = True
        Me.listBox1.TabIndex = 12
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label7.Location = New System.Drawing.Point(264, 72)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(83, 15)
        Me.label7.TabIndex = 11
        Me.label7.Text = "Selected Fields:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label6.Location = New System.Drawing.Point(6, 72)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(85, 15)
        Me.label6.TabIndex = 10
        Me.label6.Text = "Available Fields:"
        '
        'comboBoxTable
        '
        Me.comboBoxTable.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.comboBoxTable.ItemHeight = 19
        Me.comboBoxTable.Location = New System.Drawing.Point(6, 40)
        Me.comboBoxTable.Name = "comboBoxTable"
        Me.comboBoxTable.Size = New System.Drawing.Size(478, 25)
        Me.comboBoxTable.Style = MetroFramework.MetroColorStyle.Blue
        Me.comboBoxTable.TabIndex = 9
        Me.comboBoxTable.UseSelectable = True
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.SystemColors.Control
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(23, 82)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(24, 16)
        Me.label1.TabIndex = 16
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.BackColor = System.Drawing.SystemColors.Control
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(23, 60)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 16)
        Me.label5.TabIndex = 17
        Me.label5.Text = "D:  "
        '
        'label4
        '
        Me.label4.BackColor = System.Drawing.SystemColors.Control
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(47, 82)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(379, 16)
        Me.label4.TabIndex = 15
        Me.label4.Text = "This sample shows the dynamic creation of List && Label projects."
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.SystemColors.Control
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(47, 60)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(379, 16)
        Me.label3.TabIndex = 14
        Me.label3.Text = "Dieses Beispiel zeigt die dynamische Erstellung von List && Label Projekten."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(524, 488)
        Me.Controls.Add(Me.button5)
        Me.Controls.Add(Me.button4)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(524, 488)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label DOM Simple VB.NET Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents button5 As MetroFramework.Controls.MetroButton
    Private WithEvents button4 As MetroFramework.Controls.MetroButton
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label2 As MetroFramework.Controls.MetroLabel
    Private WithEvents button3 As MetroFramework.Controls.MetroButton
    Private WithEvents textBox2 As MetroFramework.Controls.MetroTextBox
    Private WithEvents label10 As MetroFramework.Controls.MetroLabel
    Private WithEvents textBox1 As MetroFramework.Controls.MetroTextBox
    Private WithEvents label9 As MetroFramework.Controls.MetroLabel
    Private WithEvents button2 As MetroFramework.Controls.MetroButton
    Private WithEvents button1 As MetroFramework.Controls.MetroButton
    Private WithEvents listBox2 As System.Windows.Forms.ListBox
    Private WithEvents listBox1 As System.Windows.Forms.ListBox
    Private WithEvents label7 As MetroFramework.Controls.MetroLabel
    Private WithEvents label6 As MetroFramework.Controls.MetroLabel
    Private WithEvents comboBoxTable As MetroFramework.Controls.MetroComboBox
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel

	#End Region
End Class

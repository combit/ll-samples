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
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.metroButton4 = New MetroFramework.Controls.MetroButton()
        Me.metroButton3 = New MetroFramework.Controls.MetroButton()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.metroButton2 = New MetroFramework.Controls.MetroButton()
        Me.metroButton1 = New MetroFramework.Controls.MetroButton()
        Me.checkBox1 = New MetroFramework.Controls.MetroCheckBox()
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.label5 = New MetroFramework.Controls.MetroLabel()
        Me.label4 = New MetroFramework.Controls.MetroLabel()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LL
        '
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.CompressStorage = True
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
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.metroButton4)
        Me.groupBox2.Controls.Add(Me.metroButton3)
        Me.groupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(288, 114)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(256, 64)
        Me.groupBox2.TabIndex = 12
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Report"
        '
        'metroButton4
        '
        Me.metroButton4.Location = New System.Drawing.Point(102, 25)
        Me.metroButton4.Name = "metroButton4"
        Me.metroButton4.Size = New System.Drawing.Size(136, 23)
        Me.metroButton4.TabIndex = 1
        Me.metroButton4.Text = "Print/Preview/Export..."
        Me.metroButton4.UseSelectable = True
        '
        'metroButton3
        '
        Me.metroButton3.Location = New System.Drawing.Point(21, 25)
        Me.metroButton3.Name = "metroButton3"
        Me.metroButton3.Size = New System.Drawing.Size(75, 23)
        Me.metroButton3.TabIndex = 0
        Me.metroButton3.Text = "Design..."
        Me.metroButton3.UseSelectable = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.metroButton2)
        Me.groupBox1.Controls.Add(Me.metroButton1)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(23, 114)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(256, 64)
        Me.groupBox1.TabIndex = 11
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Label"
        '
        'metroButton2
        '
        Me.metroButton2.Location = New System.Drawing.Point(101, 25)
        Me.metroButton2.Name = "metroButton2"
        Me.metroButton2.Size = New System.Drawing.Size(136, 23)
        Me.metroButton2.TabIndex = 1
        Me.metroButton2.Text = "Print/Preview/Export..."
        Me.metroButton2.UseSelectable = True
        '
        'metroButton1
        '
        Me.metroButton1.Location = New System.Drawing.Point(20, 25)
        Me.metroButton1.Name = "metroButton1"
        Me.metroButton1.Size = New System.Drawing.Size(75, 23)
        Me.metroButton1.TabIndex = 0
        Me.metroButton1.Text = "Design..."
        Me.metroButton1.UseSelectable = True
        '
        'checkBox1
        '
        Me.checkBox1.Location = New System.Drawing.Point(405, 79)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(139, 24)
        Me.checkBox1.Style = MetroFramework.MetroColorStyle.Blue
        Me.checkBox1.TabIndex = 17
        Me.checkBox1.Text = "Enable Debug Output"
        Me.checkBox1.UseSelectable = True
        '
        'label1
        '
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(23, 85)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(24, 16)
        Me.label1.TabIndex = 15
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(23, 60)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 16)
        Me.label5.TabIndex = 16
        Me.label5.Text = "D:"
        '
        'label4
        '
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(53, 85)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(314, 26)
        Me.label4.TabIndex = 14
        Me.label4.Text = "This sample shows how to use Unicode."
        '
        'label3
        '
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(53, 60)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(314, 25)
        Me.label3.TabIndex = 13
        Me.label3.Text = "Dieses Beispiel zeigt die Verwendung von Unicode."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(567, 196)
        Me.Controls.Add(Me.checkBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
		Me.Resizable = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET Unicode Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents metroButton4 As MetroFramework.Controls.MetroButton
    Private WithEvents metroButton3 As MetroFramework.Controls.MetroButton
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents metroButton2 As MetroFramework.Controls.MetroButton
    Private WithEvents metroButton1 As MetroFramework.Controls.MetroButton
    Private WithEvents checkBox1 As MetroFramework.Controls.MetroCheckBox
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel

	#End Region
End Class

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
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.label5 = New MetroFramework.Controls.MetroLabel()
        Me.label4 = New MetroFramework.Controls.MetroLabel()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.button3 = New MetroFramework.Controls.MetroButton()
        Me.button4 = New MetroFramework.Controls.MetroButton()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.button2 = New MetroFramework.Controls.MetroButton()
        Me.button1 = New MetroFramework.Controls.MetroButton()
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
        'label1
        '
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(23, 100)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(26, 16)
        Me.label1.TabIndex = 10
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(23, 60)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(26, 16)
        Me.label5.TabIndex = 11
        Me.label5.Text = "D:  "
        '
        'label4
        '
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(55, 100)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(486, 29)
        Me.label4.TabIndex = 9
        Me.label4.Text = "This sample shows the usage of databinding for the methods Print and Design in th" & _
    "e databind mode."
        Me.label4.WrapToLine = True
        '
        'label3
        '
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(55, 60)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(486, 40)
        Me.label3.TabIndex = 8
        Me.label3.Text = "Dieses Beispiel zeigt die Verwendung der Datenübergabe für die Methoden Print und" & _
    " Design im datengebundenen Modus."
        Me.label3.WrapToLine = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.button3)
        Me.groupBox2.Controls.Add(Me.button4)
        Me.groupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(23, 136)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(256, 64)
        Me.groupBox2.TabIndex = 12
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Invoice && Items List"
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(104, 24)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(136, 23)
        Me.button3.TabIndex = 2
        Me.button3.Text = "Print/Preview/Export..."
        Me.button3.UseSelectable = True
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(16, 24)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(75, 23)
        Me.button4.TabIndex = 1
        Me.button4.Text = "Design..."
        Me.button4.UseSelectable = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.button2)
        Me.groupBox1.Controls.Add(Me.button1)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(285, 136)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(256, 64)
        Me.groupBox1.TabIndex = 13
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Invoice Merge"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(104, 24)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(136, 23)
        Me.button2.TabIndex = 4
        Me.button2.Text = "Print/Preview/Export..."
        Me.button2.UseSelectable = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(16, 24)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 3
        Me.button1.Text = "Design..."
        Me.button1.UseSelectable = True
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(567, 217)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(567, 217)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label Databinding2 VB.NET Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents button3 As MetroFramework.Controls.MetroButton
    Private WithEvents button4 As MetroFramework.Controls.MetroButton
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents button2 As MetroFramework.Controls.MetroButton
    Private WithEvents button1 As MetroFramework.Controls.MetroButton

	#End Region
End Class

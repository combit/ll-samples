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
        Me.button2 = New MetroFramework.Controls.MetroButton()
        Me.button1 = New MetroFramework.Controls.MetroButton()
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.label5 = New MetroFramework.Controls.MetroLabel()
        Me.label4 = New MetroFramework.Controls.MetroLabel()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
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
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(203, 111)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(164, 27)
        Me.button2.TabIndex = 15
        Me.button2.Text = "Print"
        Me.button2.UseSelectable = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(33, 111)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(164, 27)
        Me.button1.TabIndex = 14
        Me.button1.Text = "Design"
        Me.button1.UseSelectable = True
        '
        'label1
        '
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(23, 80)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(24, 16)
        Me.label1.TabIndex = 12
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(23, 60)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 16)
        Me.label5.TabIndex = 13
        Me.label5.Text = "D:"
        '
        'label4
        '
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(53, 80)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(304, 17)
        Me.label4.TabIndex = 11
        Me.label4.Text = "This sample shows how to design and print labels."
        '
        'label3
        '
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(53, 60)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(304, 16)
        Me.label3.TabIndex = 10
        Me.label3.Text = "Dieses Beispiel zeigt den Druck und Design von Etiketten."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(398, 156)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(398, 156)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET Label Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents button2 As MetroFramework.Controls.MetroButton
    Private WithEvents button1 As MetroFramework.Controls.MetroButton
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel

	#End Region
End Class

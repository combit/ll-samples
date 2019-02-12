Partial Class LocalizationForm
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
        Me.printButton = New MetroFramework.Controls.MetroButton()
        Me.designButton = New MetroFramework.Controls.MetroButton()
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
        'printButton
        '
        Me.printButton.Location = New System.Drawing.Point(339, 171)
        Me.printButton.Name = "printButton"
        Me.printButton.Size = New System.Drawing.Size(88, 24)
        Me.printButton.TabIndex = 21
        Me.printButton.Text = "&Print..."
        Me.printButton.UseSelectable = True
        '
        'designButton
        '
        Me.designButton.Location = New System.Drawing.Point(245, 171)
        Me.designButton.Name = "designButton"
        Me.designButton.Size = New System.Drawing.Size(88, 24)
        Me.designButton.TabIndex = 20
        Me.designButton.Text = "&Design..."
        Me.designButton.UseSelectable = True
        '
        'label1
        '
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(24, 113)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(23, 16)
        Me.label1.TabIndex = 18
        Me.label1.Text = "US:"
        Me.label1.WrapToLine = True
        '
        'label5
        '
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(24, 60)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(23, 16)
        Me.label5.TabIndex = 19
        Me.label5.Text = "D:  "
        Me.label5.WrapToLine = True
        '
        'label4
        '
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(47, 113)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(385, 48)
        Me.label4.TabIndex = 17
        Me.label4.Text = "This sample shows how to design multi language reports. The report template is th" & _
    "e same for all languages - the localization is done with the Dictionary object."
        Me.label4.WrapToLine = True
        '
        'label3
        '
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(47, 60)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(385, 48)
        Me.label3.TabIndex = 16
        Me.label3.Text = "Dieses Beispiel zeigt das Designen von mehrsprachigen Reports. Die Reportvorlage " & _
    "ist für alle Sprachen die Gleiche, die Lokalisierung wird über das Dictionary-Ob" & _
    "jekt erreicht."
        Me.label3.WrapToLine = True
        '
        'LocalizationForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(458, 218)
        Me.Controls.Add(Me.printButton)
        Me.Controls.Add(Me.designButton)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(458, 218)
        Me.Name = "LocalizationForm"
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET Localization Sample"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents printButton As MetroFramework.Controls.MetroButton
    Private WithEvents designButton As MetroFramework.Controls.MetroButton
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel

	#End Region
End Class

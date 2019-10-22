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
        Me.LL = New combit.ListLabel25.ListLabel(Me.components)
        Me.printButton = New System.Windows.Forms.Button()
        Me.designButton = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LL
        '
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.CompressStorage = True
        Me.LL.DataBindingMode = combit.ListLabel25.DataBindingMode.DelayLoad
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.FileRepository = Nothing
        Me.LL.GenericMaximumRecordCount = -1
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.ListLabel25.LlUnits.Millimeter_1_100
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'printButton
        '
        Me.printButton.Location = New System.Drawing.Point(325, 121)
        Me.printButton.Name = "printButton"
        Me.printButton.Size = New System.Drawing.Size(88, 24)
        Me.printButton.TabIndex = 21
        Me.printButton.Text = "&Print..."
        '
        'designButton
        '
        Me.designButton.Location = New System.Drawing.Point(231, 121)
        Me.designButton.Name = "designButton"
        Me.designButton.Size = New System.Drawing.Size(88, 24)
        Me.designButton.TabIndex = 20
        Me.designButton.Text = "&Design..."
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(10, 63)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(23, 16)
        Me.label1.TabIndex = 18
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(10, 10)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(23, 16)
        Me.label5.TabIndex = 19
        Me.label5.Text = "D:  "
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(33, 63)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(385, 48)
        Me.label4.TabIndex = 17
        Me.label4.Text = "This sample shows how to design multi language reports. The report template is th" &
    "e same for all languages - the localization is done with the Dictionary object."
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(33, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(385, 48)
        Me.label3.TabIndex = 16
        Me.label3.Text = "Dieses Beispiel zeigt das Designen von mehrsprachigen Reports. Die Reportvorlage " &
    "ist für alle Sprachen die Gleiche, die Lokalisierung wird über das Dictionary-Ob" &
    "jekt erreicht."
        '
        'LocalizationForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(423, 152)
        Me.Controls.Add(Me.printButton)
        Me.Controls.Add(Me.designButton)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LocalizationForm"
        Me.Text = "List & Label VB.NET Localization Sample"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents LL As combit.ListLabel25.ListLabel
    Private WithEvents printButton As System.Windows.Forms.Button
    Private WithEvents designButton As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
#End Region
End Class

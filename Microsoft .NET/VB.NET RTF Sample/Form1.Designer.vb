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
        Me.listLabel1 = New combit.ListLabel24.ListLabel(Me.components)
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.listLabelRTFControl1 = New combit.ListLabel24.ListLabelRTFControl(Me.components)
        Me.metroButton1 = New MetroFramework.Controls.MetroButton()
        Me.metroButton3 = New MetroFramework.Controls.MetroButton()
        Me.metroButton2 = New MetroFramework.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'listLabel1
        '
        Me.listLabel1.AutoPrinterSettingsStream = Nothing
        Me.listLabel1.AutoProjectStream = Nothing
        Me.listLabel1.DrilldownAvailable = True
        Me.listLabel1.EMFResolution = 100
        Me.listLabel1.LockNextChar = 8288
        Me.listLabel1.MaxRTFVersion = 1280
        Me.listLabel1.PhantomSpace = 8203
        Me.listLabel1.PreviewControl = Nothing
        Me.listLabel1.Unit = combit.ListLabel24.LlUnits.Millimeter_1_100
        Me.listLabel1.UseHardwareCopiesForLabels = False
        Me.listLabel1.UseTableSchemaForDesignMode = False
        '
        'ofd
        '
        Me.ofd.DefaultExt = "*.RTF"
        Me.ofd.Filter = "RTF Files|*.RTF"
        Me.ofd.Title = "Select RTF File"
        '
        'listLabelRTFControl1
        '
        Me.listLabelRTFControl1.Anchor = System.Windows.Forms.AnchorStyles.None        
		Me.listLabelRTFControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listLabelRTFControl1.Location = New System.Drawing.Point(32, 102)
        Me.listLabelRTFControl1.Name = "listLabelRTFControl1"
        Me.listLabelRTFControl1.ParentComponent = Me.listLabel1
        Me.listLabelRTFControl1.Size = New System.Drawing.Size(655, 274)
        Me.listLabelRTFControl1.TabIndex = 1
        Me.listLabelRTFControl1.Text = "listLabelRTFControl1"
        '
        'metroButton1
        '
        Me.metroButton1.Location = New System.Drawing.Point(32, 73)
        Me.metroButton1.Name = "metroButton1"
        Me.metroButton1.Size = New System.Drawing.Size(110, 23)
        Me.metroButton1.TabIndex = 3
        Me.metroButton1.Text = "Open RTF File..."
        Me.metroButton1.UseSelectable = True
        '
        'metroButton3
        '
        Me.metroButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroButton3.Location = New System.Drawing.Point(577, 382)
        Me.metroButton3.Name = "metroButton3"
        Me.metroButton3.Size = New System.Drawing.Size(110, 23)
        Me.metroButton3.TabIndex = 5
        Me.metroButton3.Text = "Print..."
        Me.metroButton3.UseSelectable = True
        '
        'metroButton2
        '
        Me.metroButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metroButton2.Location = New System.Drawing.Point(461, 382)
        Me.metroButton2.Name = "metroButton2"
        Me.metroButton2.Size = New System.Drawing.Size(110, 23)
        Me.metroButton2.TabIndex = 6
        Me.metroButton2.Text = "Design..."
        Me.metroButton2.UseSelectable = True
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(710, 440)
        Me.Controls.Add(Me.metroButton2)
        Me.Controls.Add(Me.metroButton3)
        Me.Controls.Add(Me.metroButton1)
        Me.Controls.Add(Me.listLabelRTFControl1)
		Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(710, 440)
        Me.Name = "Form1"
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET RTF Control Sample"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Private WithEvents listLabelRTFControl1 As combit.ListLabel24.ListLabelRTFControl
    Private WithEvents listLabel1 As combit.ListLabel24.ListLabel
    Private WithEvents metroButton1 As MetroFramework.Controls.MetroButton
    Private WithEvents metroButton3 As MetroFramework.Controls.MetroButton
    Private WithEvents metroButton2 As MetroFramework.Controls.MetroButton

	#End Region
End Class

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
        Me.listLabel1 = New combit.Reporting.ListLabel(Me.components)
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.listLabelRTFControl1 = New combit.Reporting.ListLabelRTFControl(Me.components)
        Me.button1 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'listLabel1
        '
        Me.listLabel1.AutoPrinterSettingsStream = Nothing
        Me.listLabel1.AutoProjectStream = Nothing
        Me.listLabel1.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad
        Me.listLabel1.DrilldownAvailable = True
        Me.listLabel1.EMFResolution = 100
        Me.listLabel1.FileRepository = Nothing
        Me.listLabel1.GenericMaximumRecordCount = -1
        Me.listLabel1.LockNextChar = 8288
        Me.listLabel1.MaxRTFVersion = 1280
        Me.listLabel1.PhantomSpace = 8203
        Me.listLabel1.PreviewControl = Nothing
        Me.listLabel1.Printerless = False
        Me.listLabel1.Unit = combit.Reporting.LlUnits.Millimeter_1_100
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
        Me.listLabelRTFControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listLabelRTFControl1.Location = New System.Drawing.Point(37, 54)
        Me.listLabelRTFControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.listLabelRTFControl1.Name = "listLabelRTFControl1"
        Me.listLabelRTFControl1.ParentComponent = Me.listLabel1
        Me.listLabelRTFControl1.Size = New System.Drawing.Size(741, 354)
        Me.listLabelRTFControl1.TabIndex = 1
        Me.listLabelRTFControl1.Text = "listLabelRTFControl1"
        '
        'button1
        '
        Me.button1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.Location = New System.Drawing.Point(37, 21)
        Me.button1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(128, 27)
        Me.button1.TabIndex = 3
        Me.button1.Text = "Open RTF File..."
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button3.Location = New System.Drawing.Point(650, 415)
        Me.button3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(128, 27)
        Me.button3.TabIndex = 5
        Me.button3.Text = "Print..."
        '
        'button2
        '
        Me.button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button2.Location = New System.Drawing.Point(514, 415)
        Me.button2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(128, 27)
        Me.button2.TabIndex = 6
        Me.button2.Text = "Design..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 463)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.listLabelRTFControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(826, 502)
        Me.Name = "Form1"
        Me.Text = "List & Label VB.NET RTF Control Sample"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Private WithEvents listLabelRTFControl1 As combit.Reporting.ListLabelRTFControl
    Private WithEvents listLabel1 As combit.Reporting.ListLabel
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
#End Region
End Class
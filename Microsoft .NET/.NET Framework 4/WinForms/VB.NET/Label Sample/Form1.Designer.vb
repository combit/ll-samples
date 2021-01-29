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
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
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
        Me.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.FileRepository = Nothing
        Me.LL.GenericMaximumRecordCount = -1
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_100
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(190, 61)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(164, 27)
        Me.button2.TabIndex = 15
        Me.button2.Text = "Print"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(20, 61)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(164, 27)
        Me.button1.TabIndex = 14
        Me.button1.Text = "Design"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(10, 30)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(24, 16)
        Me.label1.TabIndex = 12
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(10, 10)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 16)
        Me.label5.TabIndex = 13
        Me.label5.Text = "D:"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(40, 30)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(304, 17)
        Me.label4.TabIndex = 11
        Me.label4.Text = "This sample shows how to design and print labels."
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(40, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(304, 16)
        Me.label3.TabIndex = 10
        Me.label3.Text = "Dieses Beispiel zeigt den Druck und Design von Etiketten."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 95)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List & Label VB.NET Label Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents LL As combit.Reporting.ListLabel
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
#End Region
End Class

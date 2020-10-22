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
        Me.label1 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.button3 = New System.Windows.Forms.Button()
        Me.button4 = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
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
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(10, 50)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(26, 16)
        Me.label1.TabIndex = 10
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(10, 10)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(26, 16)
        Me.label5.TabIndex = 11
        Me.label5.Text = "D:  "
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(42, 50)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(486, 29)
        Me.label4.TabIndex = 9
        Me.label4.Text = "This sample shows the usage of databinding for the methods Print and Design in th" &
    "e databind mode."
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(42, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(486, 40)
        Me.label3.TabIndex = 8
        Me.label3.Text = "Dieses Beispiel zeigt die Verwendung der Datenübergabe für die Methoden Print und" &
    " Design im datengebundenen Modus."
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.button3)
        Me.groupBox2.Controls.Add(Me.button4)
        Me.groupBox2.Location = New System.Drawing.Point(10, 86)
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
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(16, 24)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(75, 23)
        Me.button4.TabIndex = 1
        Me.button4.Text = "Design..."
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.button2)
        Me.groupBox1.Controls.Add(Me.button1)
        Me.groupBox1.Location = New System.Drawing.Point(272, 86)
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
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(16, 24)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 3
        Me.button1.Text = "Design..."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(540, 160)
        Me.Controls.Add(Me.groupBox2)
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
        Me.Text = "List & Label Databinding2 VB.NET Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents LL As combit.Reporting.ListLabel
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button4 As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
#End Region
End Class

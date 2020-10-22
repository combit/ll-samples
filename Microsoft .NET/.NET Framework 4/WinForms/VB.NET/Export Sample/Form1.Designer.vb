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
        Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.LL = new combit.Reporting.ListLabel(Me.components)
        Me.label5 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.formatCb = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.createButton = New System.Windows.Forms.Button()
        Me._showFileCheck = New System.Windows.Forms.CheckBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.selectButton = New System.Windows.Forms.Button()
        Me.fileNameTb = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'saveFileDialog
        '
        Me.saveFileDialog.FileName = "doc1"
        '
        'LL
        '
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.AutoShowSelectFile = False
        Me.LL.CompressStorage = True
        Me.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.FileRepository = Nothing
        Me.LL.GenericMaximumRecordCount = -1
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 256
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.Reporting.LlUnits.Inch_1_1000
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(10, 10)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 16)
        Me.label5.TabIndex = 12
        Me.label5.Text = "D:"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.formatCb)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.createButton)
        Me.groupBox1.Controls.Add(Me._showFileCheck)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.selectButton)
        Me.groupBox1.Controls.Add(Me.fileNameTb)
        Me.groupBox1.Location = New System.Drawing.Point(10, 61)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(488, 117)
        Me.groupBox1.TabIndex = 16
        Me.groupBox1.TabStop = False
        '
        'formatCb
        '
        Me.formatCb.DropDownHeight = 160
        Me.formatCb.IntegralHeight = False
        Me.formatCb.ItemHeight = 13
        Me.formatCb.Items.AddRange(New Object() {"PDF", "MHTML", "RTF", "XML", "Multi-TIFF", "Text", "XLS", "XLSX", "XHTML", "Preview", "DOCX"})
        Me.formatCb.Location = New System.Drawing.Point(69, 19)
        Me.formatCb.Name = "formatCb"
        Me.formatCb.Size = New System.Drawing.Size(327, 21)
        Me.formatCb.TabIndex = 5
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(6, 23)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(48, 16)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Format:"
        '
        'createButton
        '
        Me.createButton.Location = New System.Drawing.Point(402, 80)
        Me.createButton.Name = "createButton"
        Me.createButton.Size = New System.Drawing.Size(80, 24)
        Me.createButton.TabIndex = 9
        Me.createButton.Text = "Create..."
        '
        '_showFileCheck
        '
        Me._showFileCheck.Location = New System.Drawing.Point(258, 80)
        Me._showFileCheck.Name = "_showFileCheck"
        Me._showFileCheck.Size = New System.Drawing.Size(138, 24)
        Me._showFileCheck.TabIndex = 10
        Me._showFileCheck.Text = "Show file after creation"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(6, 52)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(57, 16)
        Me.label6.TabIndex = 6
        Me.label6.Text = "Filename:"
        '
        'selectButton
        '
        Me.selectButton.Location = New System.Drawing.Point(402, 50)
        Me.selectButton.Name = "selectButton"
        Me.selectButton.Size = New System.Drawing.Size(80, 24)
        Me.selectButton.TabIndex = 8
        Me.selectButton.Text = "Select..."
        '
        'fileNameTb
        '
        Me.fileNameTb.BackColor = System.Drawing.SystemColors.Window
        Me.fileNameTb.Location = New System.Drawing.Point(69, 50)
        Me.fileNameTb.Name = "fileNameTb"
        Me.fileNameTb.Size = New System.Drawing.Size(327, 20)
        Me.fileNameTb.TabIndex = 7
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(34, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(458, 24)
        Me.label3.TabIndex = 13
        Me.label3.Text = "Dieses Beispiel zeigt den Export ohne weitere Benutzerinteraktion."
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(10, 34)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(24, 16)
        Me.label1.TabIndex = 14
        Me.label1.Text = "US:"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(34, 34)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(464, 24)
        Me.label4.TabIndex = 15
        Me.label4.Text = "This sample shows an export without user interaction."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(508, 190)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "List & Label VB.NET Export Sample"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents saveFileDialog As System.Windows.Forms.SaveFileDialog
    Private WithEvents LL As combit.Reporting.ListLabel
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents formatCb As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents createButton As System.Windows.Forms.Button
    Private WithEvents _showFileCheck As System.Windows.Forms.CheckBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents selectButton As System.Windows.Forms.Button
    Private WithEvents fileNameTb As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
#End Region
End Class

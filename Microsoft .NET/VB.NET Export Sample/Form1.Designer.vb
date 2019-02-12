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
        Me.LL = New combit.ListLabel24.ListLabel(Me.components)
        Me.label5 = New MetroFramework.Controls.MetroLabel()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.formatCb = New MetroFramework.Controls.MetroComboBox()
        Me.label2 = New MetroFramework.Controls.MetroLabel()
        Me.createButton = New MetroFramework.Controls.MetroButton()
        Me._showFileCheck = New System.Windows.Forms.CheckBox()
        Me.label6 = New MetroFramework.Controls.MetroLabel()
        Me.selectButton = New MetroFramework.Controls.MetroButton()
        Me.fileNameTb = New MetroFramework.Controls.MetroTextBox()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.label4 = New MetroFramework.Controls.MetroLabel()
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
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 256
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.ListLabel24.LlUnits.Inch_1_1000
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'label5
        '
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(23, 60)
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
        Me.groupBox1.Location = New System.Drawing.Point(11, 111)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(488, 117)
        Me.groupBox1.TabIndex = 16
        Me.groupBox1.TabStop = False
        '
        'formatCb
        '
        Me.formatCb.DropDownHeight = 160
        Me.formatCb.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.formatCb.IntegralHeight = False
        Me.formatCb.ItemHeight = 19
        Me.formatCb.Items.AddRange(New Object() {"PDF", "MHTML", "HTML", "RTF", "XML", "Multi-TIFF", "Text", "XLS", "XLSX", "XHTML", "Preview", "DOCX"})
        Me.formatCb.Location = New System.Drawing.Point(69, 19)
        Me.formatCb.Name = "formatCb"
        Me.formatCb.Size = New System.Drawing.Size(327, 25)
        Me.formatCb.Style = MetroFramework.MetroColorStyle.Blue
        Me.formatCb.TabIndex = 5
        Me.formatCb.UseSelectable = True
        '
        'label2
        '
        Me.label2.FontSize = MetroFramework.MetroLabelSize.Small
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
        Me.createButton.UseSelectable = True
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
        Me.label6.FontSize = MetroFramework.MetroLabelSize.Small
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
        Me.selectButton.UseSelectable = True
        '
        'fileNameTb
        '
        Me.fileNameTb.BackColor = System.Drawing.SystemColors.Window
        Me.fileNameTb.Lines = New String(-1) {}
        Me.fileNameTb.Location = New System.Drawing.Point(69, 50)
        Me.fileNameTb.MaxLength = 32767
        Me.fileNameTb.Name = "fileNameTb"
        Me.fileNameTb.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.fileNameTb.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.fileNameTb.SelectedText = ""
        Me.fileNameTb.Size = New System.Drawing.Size(327, 24)
        Me.fileNameTb.TabIndex = 7
        Me.fileNameTb.UseCustomBackColor = True
        Me.fileNameTb.UseSelectable = True
        '
        'label3
        '
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(47, 60)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(336, 24)
        Me.label3.TabIndex = 13
        Me.label3.Text = "Dieses Beispiel zeigt den Export ohne weitere Benutzerinteraktion."
        '
        'label1
        '
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(23, 84)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(24, 16)
        Me.label1.TabIndex = 14
        Me.label1.Text = "US:"
        '
        'label4
        '
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(47, 84)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(288, 24)
        Me.label4.TabIndex = 15
        Me.label4.Text = "This sample shows an export without user interaction."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(522, 243)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Resizable = False
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET Export Sample"
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents saveFileDialog As System.Windows.Forms.SaveFileDialog
    Private WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents formatCb As MetroFramework.Controls.MetroComboBox
    Private WithEvents label2 As MetroFramework.Controls.MetroLabel
    Private WithEvents createButton As MetroFramework.Controls.MetroButton
    Private WithEvents _showFileCheck As System.Windows.Forms.CheckBox
    Private WithEvents label6 As MetroFramework.Controls.MetroLabel
    Private WithEvents selectButton As MetroFramework.Controls.MetroButton
    Private WithEvents fileNameTb As MetroFramework.Controls.MetroTextBox
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel

	#End Region
End Class

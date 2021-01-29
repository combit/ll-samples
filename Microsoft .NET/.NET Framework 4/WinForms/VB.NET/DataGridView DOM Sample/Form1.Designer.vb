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
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.LL = new combit.Reporting.ListLabel(Me.components)
        Me.cmsRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.label5 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.cbTable = New System.Windows.Forms.ComboBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.tbDescription = New System.Windows.Forms.TextBox()
        Me.cbOnlyDisplayableColumns = New System.Windows.Forms.CheckBox()
        Me.btnDesign = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.AllowUserToOrderColumns = True
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(10, 98)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(915, 420)
        Me.dgvData.TabIndex = 4
        '
        'LL
        '
        Me.LL.AutoDestination = combit.Reporting.LlPrintMode.MultipleJobs
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.AutoShowPrintOptions = False
        Me.LL.AutoShowSelectFile = False
        Me.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.FileRepository = Nothing
        Me.LL.GenericMaximumRecordCount = -1
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_10
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'cmsRightClick
        '
        Me.cmsRightClick.Name = "cmsRightClick"
        Me.cmsRightClick.Size = New System.Drawing.Size(61, 4)
        '
        'label5
        '
        Me.label5.BackColor = System.Drawing.SystemColors.Control
        Me.label5.Location = New System.Drawing.Point(10, 10)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 16)
        Me.label5.TabIndex = 11
        Me.label5.Text = "D:  "
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.SystemColors.Control
        Me.label3.Location = New System.Drawing.Point(34, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(554, 16)
        Me.label3.TabIndex = 10
        Me.label3.Text = "Dieses Beispiel zeigt die dynamische Erstellung von List && Label Projekten mit A" &
    "uslesen eines Datagridviews."
        '
        'label4
        '
        Me.label4.BackColor = System.Drawing.SystemColors.Control
        Me.label4.Location = New System.Drawing.Point(10, 30)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(24, 16)
        Me.label4.TabIndex = 13
        Me.label4.Text = "US:"
        '
        'label6
        '
        Me.label6.BackColor = System.Drawing.SystemColors.Control
        Me.label6.Location = New System.Drawing.Point(34, 30)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(554, 16)
        Me.label6.TabIndex = 12
        Me.label6.Text = "This sample shows the dynamic creation of List && Label projects with reading a d" &
    "atagridview."
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(10, 63)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(37, 13)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Table:"
        '
        'cbTable
        '
        Me.cbTable.ItemHeight = 13
        Me.cbTable.Location = New System.Drawing.Point(49, 58)
        Me.cbTable.Name = "cbTable"
        Me.cbTable.Size = New System.Drawing.Size(360, 21)
        Me.cbTable.TabIndex = 15
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(473, 63)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(333, 13)
        Me.label7.TabIndex = 16
        Me.label7.Text = "Information: right click on the columnname to enable/disable columns"
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(10, 535)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(97, 13)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Project description:"
        '
        'tbDescription
        '
        Me.tbDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbDescription.BackColor = System.Drawing.SystemColors.Window
        Me.tbDescription.Location = New System.Drawing.Point(119, 533)
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Size = New System.Drawing.Size(195, 20)
        Me.tbDescription.TabIndex = 18
        Me.tbDescription.Text = "Dynamically created project"
        '
        'cbOnlyDisplayableColumns
        '
        Me.cbOnlyDisplayableColumns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOnlyDisplayableColumns.AutoSize = True
        Me.cbOnlyDisplayableColumns.Location = New System.Drawing.Point(572, 535)
        Me.cbOnlyDisplayableColumns.Name = "cbOnlyDisplayableColumns"
        Me.cbOnlyDisplayableColumns.Size = New System.Drawing.Size(172, 17)
        Me.cbOnlyDisplayableColumns.TabIndex = 19
        Me.cbOnlyDisplayableColumns.Text = "Only show displayable columns"
        '
        'btnDesign
        '
        Me.btnDesign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDesign.Location = New System.Drawing.Point(769, 530)
        Me.btnDesign.Name = "btnDesign"
        Me.btnDesign.Size = New System.Drawing.Size(75, 23)
        Me.btnDesign.TabIndex = 20
        Me.btnDesign.Text = "Design..."
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(850, 530)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 21
        Me.btnPrint.Text = "Print..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 561)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDesign)
        Me.Controls.Add(Me.cbOnlyDisplayableColumns)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.cbTable)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.dgvData)
        Me.MinimumSize = New System.Drawing.Size(850, 600)
        Me.Name = "Form1"
        Me.Text = "List & Label VB.NET Data Grid View Sample"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
    Private WithEvents dgvData As System.Windows.Forms.DataGridView
    Private WithEvents LL As combit.Reporting.ListLabel
    Private WithEvents cmsRightClick As System.Windows.Forms.ContextMenuStrip
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cbTable As System.Windows.Forms.ComboBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tbDescription As System.Windows.Forms.TextBox
    Private WithEvents cbOnlyDisplayableColumns As System.Windows.Forms.CheckBox
    Private WithEvents btnDesign As System.Windows.Forms.Button
    Private WithEvents btnPrint As System.Windows.Forms.Button
End Class

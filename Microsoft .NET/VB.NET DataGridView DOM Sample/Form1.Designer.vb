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
        Me.LL = New combit.ListLabel24.ListLabel(Me.components)
        Me.cmsRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.label5 = New MetroFramework.Controls.MetroLabel()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
        Me.label4 = New MetroFramework.Controls.MetroLabel()
        Me.label6 = New MetroFramework.Controls.MetroLabel()
        Me.label2 = New MetroFramework.Controls.MetroLabel()
        Me.cbTable = New MetroFramework.Controls.MetroComboBox()
        Me.label7 = New MetroFramework.Controls.MetroLabel()
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.tbDescription = New MetroFramework.Controls.MetroTextBox()
        Me.cbOnlyDisplayableColumns = New MetroFramework.Controls.MetroCheckBox()
        Me.btnDesign = New MetroFramework.Controls.MetroButton()
        Me.btnPrint = New MetroFramework.Controls.MetroButton()
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
        Me.dgvData.Location = New System.Drawing.Point(13, 148)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(822, 419)
        Me.dgvData.TabIndex = 4
        '
        'LL
        '
        Me.LL.AutoDestination = combit.ListLabel24.LlPrintMode.MultipleJobs
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.AutoShowPrintOptions = False
        Me.LL.AutoShowSelectFile = False
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_10
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
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(23, 60)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 16)
        Me.label5.TabIndex = 11
        Me.label5.Text = "D:  "
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.SystemColors.Control
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(47, 60)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(554, 16)
        Me.label3.TabIndex = 10
        Me.label3.Text = "Dieses Beispiel zeigt die dynamische Erstellung von List && Label Projekten mit A" & _
    "uslesen eines Datagridviews."
        Me.label3.WrapToLine = True
        '
        'label4
        '
        Me.label4.BackColor = System.Drawing.SystemColors.Control
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(23, 80)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(24, 16)
        Me.label4.TabIndex = 13
        Me.label4.Text = "US:"
        '
        'label6
        '
        Me.label6.BackColor = System.Drawing.SystemColors.Control
        Me.label6.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label6.Location = New System.Drawing.Point(47, 80)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(554, 16)
        Me.label6.TabIndex = 12
        Me.label6.Text = "This sample shows the dynamic creation of List && Label projects with reading a d" & _
    "atagridview."
        Me.label6.WrapToLine = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label2.Location = New System.Drawing.Point(23, 113)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(35, 15)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Table:"
        '
        'cbTable
        '
        Me.cbTable.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cbTable.ItemHeight = 19
        Me.cbTable.Location = New System.Drawing.Point(62, 108)
        Me.cbTable.Name = "cbTable"
        Me.cbTable.Size = New System.Drawing.Size(360, 25)
        Me.cbTable.Style = MetroFramework.MetroColorStyle.Blue
        Me.cbTable.TabIndex = 15
        Me.cbTable.UseSelectable = True
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label7.Location = New System.Drawing.Point(486, 113)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(351, 15)
        Me.label7.TabIndex = 16
        Me.label7.Text = "Information: right click on the columnname to enable/disable columns"
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(25, 584)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(103, 15)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Project description:"
        '
        'tbDescription
        '
        Me.tbDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbDescription.BackColor = System.Drawing.SystemColors.Window
        Me.tbDescription.Lines = New String() {"Dynamically created project"}
        Me.tbDescription.Location = New System.Drawing.Point(134, 582)
        Me.tbDescription.MaxLength = 32767
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.tbDescription.SelectedText = ""
        Me.tbDescription.Size = New System.Drawing.Size(195, 20)
        Me.tbDescription.TabIndex = 18
        Me.tbDescription.Text = "Dynamically created project"
        Me.tbDescription.UseCustomBackColor = True
        Me.tbDescription.UseSelectable = True
        '
        'cbOnlyDisplayableColumns
        '
        Me.cbOnlyDisplayableColumns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOnlyDisplayableColumns.AutoSize = True
        Me.cbOnlyDisplayableColumns.Location = New System.Drawing.Point(492, 584)
        Me.cbOnlyDisplayableColumns.Name = "cbOnlyDisplayableColumns"
        Me.cbOnlyDisplayableColumns.Size = New System.Drawing.Size(190, 15)
        Me.cbOnlyDisplayableColumns.Style = MetroFramework.MetroColorStyle.Blue
        Me.cbOnlyDisplayableColumns.TabIndex = 19
        Me.cbOnlyDisplayableColumns.Text = "Only show displayable columns"
        Me.cbOnlyDisplayableColumns.UseSelectable = True
        '
        'btnDesign
        '
        Me.btnDesign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDesign.Location = New System.Drawing.Point(689, 579)
        Me.btnDesign.Name = "btnDesign"
        Me.btnDesign.Size = New System.Drawing.Size(75, 23)
        Me.btnDesign.TabIndex = 20
        Me.btnDesign.Text = "Design..."
        Me.btnDesign.UseSelectable = True
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(770, 579)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 21
        Me.btnPrint.Text = "Print..."
        Me.btnPrint.UseSelectable = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 625)
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
        Me.MinimumSize = New System.Drawing.Size(870, 625)
        Me.Name = "Form1"
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET Data Grid View Sample"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

    Private WithEvents dgvData As System.Windows.Forms.DataGridView
    Private WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents cmsRightClick As System.Windows.Forms.ContextMenuStrip
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents label6 As MetroFramework.Controls.MetroLabel
    Private WithEvents label2 As MetroFramework.Controls.MetroLabel
    Private WithEvents cbTable As MetroFramework.Controls.MetroComboBox
    Private WithEvents label7 As MetroFramework.Controls.MetroLabel
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents tbDescription As MetroFramework.Controls.MetroTextBox
    Private WithEvents cbOnlyDisplayableColumns As MetroFramework.Controls.MetroCheckBox
    Private WithEvents btnDesign As MetroFramework.Controls.MetroButton
    Private WithEvents btnPrint As MetroFramework.Controls.MetroButton
End Class


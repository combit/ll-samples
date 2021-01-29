Partial Class Form1
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer = Nothing
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LL = new combit.Reporting.ListLabel(Me.components)
        Me.label6 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.selectTargetFile = New System.Windows.Forms.Button()
        Me.selectSourceFile = New System.Windows.Forms.Button()
        Me.textTargetFile = New System.Windows.Forms.TextBox()
        Me.textSourceFile = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.button1 = New System.Windows.Forms.Button()
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'LL
        '
        Me.LL.AutoDestination = combit.Reporting.LlPrintMode.Preview
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
        Me.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_100
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(10, 90)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(107, 20)
        Me.label6.TabIndex = 28
        Me.label6.Text = "Converted report:"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(10, 61)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(107, 13)
        Me.label2.TabIndex = 27
        Me.label2.Text = "Report to convert:"
        '
        'selectTargetFile
        '
        Me.selectTargetFile.Location = New System.Drawing.Point(443, 89)
        Me.selectTargetFile.Name = "selectTargetFile"
        Me.selectTargetFile.Size = New System.Drawing.Size(75, 24)
        Me.selectTargetFile.TabIndex = 26
        Me.selectTargetFile.Text = "Select File..."
        '
        'selectSourceFile
        '
        Me.selectSourceFile.Location = New System.Drawing.Point(443, 59)
        Me.selectSourceFile.Name = "selectSourceFile"
        Me.selectSourceFile.Size = New System.Drawing.Size(75, 23)
        Me.selectSourceFile.TabIndex = 25
        Me.selectSourceFile.Text = "Select File..."
        '
        'textTargetFile
        '
        Me.textTargetFile.BackColor = System.Drawing.SystemColors.Window
        Me.textTargetFile.Location = New System.Drawing.Point(123, 90)
        Me.textTargetFile.Name = "textTargetFile"
        Me.textTargetFile.Size = New System.Drawing.Size(314, 20)
        Me.textTargetFile.TabIndex = 24
        '
        'textSourceFile
        '
        Me.textSourceFile.BackColor = System.Drawing.SystemColors.Window
        Me.textSourceFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.textSourceFile.Location = New System.Drawing.Point(123, 60)
        Me.textSourceFile.Name = "textSourceFile"
        Me.textSourceFile.Size = New System.Drawing.Size(314, 20)
        Me.textSourceFile.TabIndex = 23
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(10, 31)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(30, 21)
        Me.label1.TabIndex = 21
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(10, 10)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(30, 21)
        Me.label5.TabIndex = 22
        Me.label5.Text = "D:  "
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(40, 31)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(421, 16)
        Me.label4.TabIndex = 20
        Me.label4.Text = "This sample shows the usage of the RDL Reports converter class."
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(40, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(421, 16)
        Me.label3.TabIndex = 19
        Me.label3.Text = "Dieses Beispiel zeigt die Verwendung der RDL Reports Konverter Klasse."
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(403, 119)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(115, 24)
        Me.button1.TabIndex = 18
        Me.button1.Text = "Convert Report"
        '
        'toolTip1
        '
        Me.toolTip1.AutoPopDelay = 5000
        Me.toolTip1.InitialDelay = 100
        Me.toolTip1.ReshowDelay = 100
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 152)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.selectTargetFile)
        Me.Controls.Add(Me.selectSourceFile)
        Me.Controls.Add(Me.textTargetFile)
        Me.Controls.Add(Me.textSourceFile)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "List & Label VB.NET RDL Converter Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LL As combit.Reporting.ListLabel
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents selectTargetFile As System.Windows.Forms.Button
    Private WithEvents selectSourceFile As System.Windows.Forms.Button
    Private WithEvents textTargetFile As System.Windows.Forms.TextBox
    Private WithEvents textSourceFile As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents toolTip1 As ToolTip
End Class

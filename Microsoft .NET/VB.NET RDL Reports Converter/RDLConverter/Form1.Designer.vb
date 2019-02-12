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
        Me.LL = New combit.ListLabel24.ListLabel(Me.components)
        Me.label6 = New MetroFramework.Controls.MetroLabel()
        Me.label2 = New MetroFramework.Controls.MetroLabel()
        Me.selectTargetFile = New MetroFramework.Controls.MetroButton()
        Me.selectSourceFile = New MetroFramework.Controls.MetroButton()
        Me.textTargetFile = New MetroFramework.Controls.MetroTextBox()
        Me.textSourceFile = New MetroFramework.Controls.MetroTextBox()
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.label5 = New MetroFramework.Controls.MetroLabel()
        Me.label4 = New MetroFramework.Controls.MetroLabel()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
        Me.button1 = New MetroFramework.Controls.MetroButton()
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'LL
        '
        Me.LL.AutoDestination = combit.ListLabel24.LlPrintMode.Preview
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.AutoShowPrintOptions = False
        Me.LL.AutoShowSelectFile = False
        Me.LL.DataBindingMode = combit.ListLabel24.DataBindingMode.DelayLoad
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.FileRepository = Nothing
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_100
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'label6
        '
        Me.label6.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label6.Location = New System.Drawing.Point(22, 144)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(107, 20)
        Me.label6.TabIndex = 28
        Me.label6.Text = "Converted report:"
        '
        'label2
        '
        Me.label2.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label2.Location = New System.Drawing.Point(22, 115)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(107, 13)
        Me.label2.TabIndex = 27
        Me.label2.Text = "Report to convert:"
        '
        'selectTargetFile
        '
        Me.selectTargetFile.Location = New System.Drawing.Point(455, 143)
        Me.selectTargetFile.Name = "selectTargetFile"
        Me.selectTargetFile.Size = New System.Drawing.Size(75, 24)
        Me.selectTargetFile.TabIndex = 26
        Me.selectTargetFile.Text = "Select File..."
        Me.selectTargetFile.UseSelectable = True
        '
        'selectSourceFile
        '
        Me.selectSourceFile.Location = New System.Drawing.Point(455, 113)
        Me.selectSourceFile.Name = "selectSourceFile"
        Me.selectSourceFile.Size = New System.Drawing.Size(75, 23)
        Me.selectSourceFile.TabIndex = 25
        Me.selectSourceFile.Text = "Select File..."
        Me.selectSourceFile.UseSelectable = True
        '
        'textTargetFile
        '
        Me.textTargetFile.BackColor = System.Drawing.SystemColors.Window
        Me.textTargetFile.Lines = New String(-1) {}
        Me.textTargetFile.Location = New System.Drawing.Point(135, 144)
        Me.textTargetFile.MaxLength = 32767
        Me.textTargetFile.Name = "textTargetFile"
        Me.textTargetFile.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textTargetFile.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.textTargetFile.SelectedText = ""
        Me.textTargetFile.Size = New System.Drawing.Size(314, 20)
        Me.textTargetFile.TabIndex = 24
        Me.textTargetFile.UseCustomBackColor = True
        Me.textTargetFile.UseSelectable = True
        '
        'textSourceFile
        '
        Me.textSourceFile.BackColor = System.Drawing.SystemColors.Window
        Me.textSourceFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.textSourceFile.Lines = New String(-1) {}
        Me.textSourceFile.Location = New System.Drawing.Point(135, 114)
        Me.textSourceFile.MaxLength = 32767
        Me.textSourceFile.Name = "textSourceFile"
        Me.textSourceFile.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textSourceFile.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.textSourceFile.SelectedText = ""
        Me.textSourceFile.Size = New System.Drawing.Size(314, 20)
        Me.textSourceFile.TabIndex = 23
        Me.textSourceFile.UseCustomBackColor = True
        Me.textSourceFile.UseSelectable = True
        '
        'label1
        '
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(22, 85)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(30, 21)
        Me.label1.TabIndex = 21
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label5.Location = New System.Drawing.Point(22, 64)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(30, 21)
        Me.label5.TabIndex = 22
        Me.label5.Text = "D:  "
        '
        'label4
        '
        Me.label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label4.Location = New System.Drawing.Point(52, 85)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(421, 16)
        Me.label4.TabIndex = 20
        Me.label4.Text = "This sample shows the usage of the RDL Reports converter class."
        '
        'label3
        '
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(52, 64)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(421, 16)
        Me.label3.TabIndex = 19
        Me.label3.Text = "Dieses Beispiel zeigt die Verwendung der RDL Reports Konverter Klasse."
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(415, 173)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(115, 24)
        Me.button1.TabIndex = 18
        Me.button1.Text = "Convert Report"
        Me.button1.UseSelectable = True
        '
        'toolTip1
        '
        Me.toolTip1.AutoPopDelay = 5000
        Me.toolTip1.InitialDelay = 100
        Me.toolTip1.ReshowDelay = 100
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 212)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Resizable = False
        Me.Text = "List & Label VB.NET RDL Converter Sample"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents label6 As MetroFramework.Controls.MetroLabel
    Private WithEvents label2 As MetroFramework.Controls.MetroLabel
    Private WithEvents selectTargetFile As MetroFramework.Controls.MetroButton
    Private WithEvents selectSourceFile As MetroFramework.Controls.MetroButton
    Private WithEvents textTargetFile As MetroFramework.Controls.MetroTextBox
    Private WithEvents textSourceFile As MetroFramework.Controls.MetroTextBox
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel
    Private WithEvents button1 As MetroFramework.Controls.MetroButton
    Private WithEvents toolTip1 As ToolTip
End Class

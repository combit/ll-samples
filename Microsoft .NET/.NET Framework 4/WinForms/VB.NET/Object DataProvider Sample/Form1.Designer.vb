<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits Form
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
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.comboSelection = New System.Windows.Forms.ComboBox()
        Me.buttonPrint = New System.Windows.Forms.Button()
        Me.label_US = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label_DE = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.buttonDesign = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'comboSelection
        '
        Me.comboSelection.FormattingEnabled = True
        Me.comboSelection.ItemHeight = 13
        Me.comboSelection.Location = New System.Drawing.Point(10, 90)
        Me.comboSelection.Name = "comboSelection"
        Me.comboSelection.Size = New System.Drawing.Size(222, 21)
        Me.comboSelection.TabIndex = 16
        '
        'buttonPrint
        '
        Me.buttonPrint.Location = New System.Drawing.Point(319, 90)
        Me.buttonPrint.Name = "buttonPrint"
        Me.buttonPrint.Size = New System.Drawing.Size(136, 21)
        Me.buttonPrint.TabIndex = 15
        Me.buttonPrint.Text = "Print/Preview/Export..."
        '
        'label_US
        '
        Me.label_US.Location = New System.Drawing.Point(51, 44)
        Me.label_US.Name = "label_US"
        Me.label_US.Size = New System.Drawing.Size(404, 30)
        Me.label_US.TabIndex = 14
        Me.label_US.Text = "This sample shows the usage of the ObjectDataProvider with List && Label."
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(10, 44)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(25, 13)
        Me.label3.TabIndex = 13
        Me.label3.Text = "US:"
        '
        'label_DE
        '
        Me.label_DE.Location = New System.Drawing.Point(51, 10)
        Me.label_DE.Name = "label_DE"
        Me.label_DE.Size = New System.Drawing.Size(404, 30)
        Me.label_DE.TabIndex = 12
        Me.label_DE.Text = "Dieses Beispiel zeigt die Verwendung des ObjectDataProvider mit List && Label."
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(10, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(18, 13)
        Me.label1.TabIndex = 11
        Me.label1.Text = "D:"
        '
        'buttonDesign
        '
        Me.buttonDesign.Location = New System.Drawing.Point(238, 90)
        Me.buttonDesign.Name = "buttonDesign"
        Me.buttonDesign.Size = New System.Drawing.Size(75, 21)
        Me.buttonDesign.TabIndex = 10
        Me.buttonDesign.Text = "&Design..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 121)
        Me.Controls.Add(Me.comboSelection)
        Me.Controls.Add(Me.buttonPrint)
        Me.Controls.Add(Me.label_US)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label_DE)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.buttonDesign)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "List & Label VB.NET ObjectDataProviderSample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents comboSelection As System.Windows.Forms.ComboBox
    Private WithEvents buttonPrint As System.Windows.Forms.Button
    Private WithEvents label_US As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label_DE As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents buttonDesign As System.Windows.Forms.Button
End Class

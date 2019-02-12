<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.comboSelection = New MetroFramework.Controls.MetroComboBox()
        Me.buttonPrint = New MetroFramework.Controls.MetroButton()
        Me.label_US = New MetroFramework.Controls.MetroLabel()
        Me.label3 = New MetroFramework.Controls.MetroLabel()
        Me.label_DE = New MetroFramework.Controls.MetroLabel()
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.buttonDesign = New MetroFramework.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'comboSelection
        '
        Me.comboSelection.FormattingEnabled = True
        Me.comboSelection.ItemHeight = 23
        Me.comboSelection.Location = New System.Drawing.Point(23, 140)
        Me.comboSelection.Name = "comboSelection"
        Me.comboSelection.Size = New System.Drawing.Size(222, 29)
        Me.comboSelection.Style = MetroFramework.MetroColorStyle.Blue
        Me.comboSelection.TabIndex = 16
        Me.comboSelection.UseSelectable = True
        '
        'buttonPrint
        '
        Me.buttonPrint.Location = New System.Drawing.Point(332, 140)
        Me.buttonPrint.Name = "buttonPrint"
        Me.buttonPrint.Size = New System.Drawing.Size(136, 29)
        Me.buttonPrint.TabIndex = 15
        Me.buttonPrint.Text = "Print/Preview/Export..."
        Me.buttonPrint.UseSelectable = True
        '
        'label_US
        '
        Me.label_US.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label_US.Location = New System.Drawing.Point(64, 94)
        Me.label_US.Name = "label_US"
        Me.label_US.Size = New System.Drawing.Size(404, 30)
        Me.label_US.TabIndex = 14
        Me.label_US.Text = "This sample shows the usage of the ObjectDataProvider with List && Label."
        Me.label_US.WrapToLine = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label3.Location = New System.Drawing.Point(23, 94)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(24, 15)
        Me.label3.TabIndex = 13
        Me.label3.Text = "US:"
        '
        'label_DE
        '
        Me.label_DE.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label_DE.Location = New System.Drawing.Point(64, 60)
        Me.label_DE.Name = "label_DE"
        Me.label_DE.Size = New System.Drawing.Size(404, 30)
        Me.label_DE.TabIndex = 12
        Me.label_DE.Text = "Dieses Beispiel zeigt die Verwendung des ObjectDataProvider mit List && Label."
        Me.label_DE.WrapToLine = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.label1.Location = New System.Drawing.Point(23, 60)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(18, 15)
        Me.label1.TabIndex = 11
        Me.label1.Text = "D:"
        '
        'buttonDesign
        '
        Me.buttonDesign.Location = New System.Drawing.Point(251, 140)
        Me.buttonDesign.Name = "buttonDesign"
        Me.buttonDesign.Size = New System.Drawing.Size(75, 29)
        Me.buttonDesign.TabIndex = 10
        Me.buttonDesign.Text = "&Design..."
        Me.buttonDesign.UseSelectable = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 192)
        Me.Controls.Add(Me.comboSelection)
        Me.Controls.Add(Me.buttonPrint)
        Me.Controls.Add(Me.label_US)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label_DE)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.buttonDesign)
        Me.MinimumSize = New System.Drawing.Size(528, 192)
        Me.Name = "Form1"
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET ObjectDataProviderSample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents comboSelection As MetroFramework.Controls.MetroComboBox
    Private WithEvents buttonPrint As MetroFramework.Controls.MetroButton
    Private WithEvents label_US As MetroFramework.Controls.MetroLabel
    Private WithEvents label3 As MetroFramework.Controls.MetroLabel
    Private WithEvents label_DE As MetroFramework.Controls.MetroLabel
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents buttonDesign As MetroFramework.Controls.MetroButton

End Class

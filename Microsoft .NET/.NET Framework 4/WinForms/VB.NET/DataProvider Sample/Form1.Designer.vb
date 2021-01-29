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
        Me.printBtn = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.designBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'printBtn
        '
        Me.printBtn.Location = New System.Drawing.Point(419, 90)
        Me.printBtn.Name = "printBtn"
        Me.printBtn.Size = New System.Drawing.Size(75, 23)
        Me.printBtn.TabIndex = 22
        Me.printBtn.Text = "Print..."
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(10, 49)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(24, 16)
        Me.label1.TabIndex = 20
        Me.label1.Text = "US:"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(10, 10)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 16)
        Me.label5.TabIndex = 21
        Me.label5.Text = "D:  "
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(40, 49)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(464, 38)
        Me.label4.TabIndex = 19
        Me.label4.Text = "This sample shows how to implement the IDataProvider interface. By implementing t" &
    "his interface you can bind to arbitrary data sources."
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(40, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(464, 41)
        Me.label3.TabIndex = 18
        Me.label3.Text = "Dieses Beispiel demonstriert die Implementierung des IDataProvider-Interfaces. Üb" &
    "er dieses Interface können eigene Datenquellen angebunden werden."
        '
        'designBtn
        '
        Me.designBtn.Location = New System.Drawing.Point(338, 90)
        Me.designBtn.Name = "designBtn"
        Me.designBtn.Size = New System.Drawing.Size(75, 23)
        Me.designBtn.TabIndex = 17
        Me.designBtn.Text = "Design..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 124)
        Me.Controls.Add(Me.printBtn)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.designBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "List & Label VB.NET Custom Data Provider Sample"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents printBtn As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents designBtn As System.Windows.Forms.Button
#End Region
End Class

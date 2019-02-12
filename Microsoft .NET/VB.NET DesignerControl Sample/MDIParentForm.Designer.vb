Partial Class MdiParentForm
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
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_itm_proj1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_itm_proj2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(20, 60)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1002, 24)
        Me.menuStrip1.TabIndex = 1
        Me.menuStrip1.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_itm_proj1, Me.menu_itm_proj2, Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileToolStripMenuItem.Text = "File"
        '
        'menu_itm_proj1
        '
        Me.menu_itm_proj1.Name = "menu_itm_proj1"
        Me.menu_itm_proj1.Size = New System.Drawing.Size(149, 22)
        Me.menu_itm_proj1.Text = "Load Project 1"
        '
        'menu_itm_proj2
        '
        Me.menu_itm_proj2.Name = "menu_itm_proj2"
        Me.menu_itm_proj2.Size = New System.Drawing.Size(149, 22)
        Me.menu_itm_proj2.Text = "Load Project 2"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.exitToolStripMenuItem.Text = "Exit"
        '
        'MdiParentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1042, 741)
        Me.Controls.Add(Me.menuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.menuStrip1
		Me.MinimumSize = New System.Drawing.Size(1042, 741)
        Me.Name = "MdiParentForm"
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET Designer Control Sample"
        Me.TransparencyKey = System.Drawing.Color.Empty
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

	Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private WithEvents menu_itm_proj1 As System.Windows.Forms.ToolStripMenuItem
	Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
	Private WithEvents menu_itm_proj2 As System.Windows.Forms.ToolStripMenuItem
	Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class


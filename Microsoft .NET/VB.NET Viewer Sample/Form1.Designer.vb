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
        Me.PreviewControl = New combit.ListLabel24.ListLabelPreviewControl(Me.components)
        Me.statusBar = New System.Windows.Forms.StatusBar()
        Me.statusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.statusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
        CType(Me.statusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.statusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PreviewControl
        '
        Me.PreviewControl.AllowRbuttonUsage = True
        Me.PreviewControl.BackColor = System.Drawing.SystemColors.Control
        Me.PreviewControl.CurrentPage = 0
        Me.PreviewControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl.ForceReadOnly = False
        Me.PreviewControl.Location = New System.Drawing.Point(20, 60)
        Me.PreviewControl.Name = "PreviewControl"
        Me.PreviewControl.Size = New System.Drawing.Size(752, 649)
        Me.PreviewControl.SlideshowMode = False
        Me.PreviewControl.TabIndex = 0
        Me.PreviewControl.ToolbarButtons.Exit = combit.ListLabel24.LlButtonState.Invisible
        Me.PreviewControl.ToolbarButtons.GotoFirst = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.GotoLast = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.GotoNext = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.GotoPrev = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.NextFile = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PageRange = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PreviousFile = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PrintAllPages = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PrintCurrentPage = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PrintToFax = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SaveAs = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SearchNext = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SearchOptions = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SearchStart = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SearchText = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SendTo = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SlideshowMode = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.ZoomCombo = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.ZoomReset = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.ZoomRevert = combit.ListLabel24.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.ZoomTimes2 = combit.ListLabel24.LlButtonState.[Default]
        '
        'statusBar
        '
        Me.statusBar.Location = New System.Drawing.Point(20, 709)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusBarPanel1, Me.statusBarPanel2})
        Me.statusBar.ShowPanels = True
        Me.statusBar.Size = New System.Drawing.Size(752, 16)
        Me.statusBar.TabIndex = 1
        '
        'statusBarPanel1
        '
        Me.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.statusBarPanel1.Name = "statusBarPanel1"
        Me.statusBarPanel1.ToolTipText = "Displayed File"
        Me.statusBarPanel1.Width = 635
        '
        'statusBarPanel2
        '
        Me.statusBarPanel2.Name = "statusBarPanel2"
        Me.statusBarPanel2.ToolTipText = "Page index"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 745)
        Me.Controls.Add(Me.PreviewControl)
        Me.Controls.Add(Me.statusBar)
        Me.MinimumSize = New System.Drawing.Size(792, 745)
        Me.Name = "Form1"
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET Viewer Sample"
        CType(Me.statusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents PreviewControl As combit.ListLabel24.ListLabelPreviewControl
	Private WithEvents statusBarPanel1 As System.Windows.Forms.StatusBarPanel
	Private WithEvents statusBarPanel2 As System.Windows.Forms.StatusBarPanel
	Private WithEvents statusBar As System.Windows.Forms.StatusBar

	#End Region
End Class

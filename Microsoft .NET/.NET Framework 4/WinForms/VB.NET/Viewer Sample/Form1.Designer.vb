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
        Me.PreviewControl = new combit.Reporting.ListLabelPreviewControl(Me.components)
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
        Me.PreviewControl.Location = New System.Drawing.Point(0, 0)
        Me.PreviewControl.Name = "PreviewControl"
        Me.PreviewControl.Size = New System.Drawing.Size(768, 554)
        Me.PreviewControl.SlideshowMode = False
        Me.PreviewControl.TabIndex = 0
        Me.PreviewControl.ToolbarBackColor = System.Drawing.Color.Empty
        Me.PreviewControl.ToolbarButtons.Exit = combit.Reporting.LlButtonState.Invisible
        Me.PreviewControl.ToolbarButtons.GotoFirst = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.GotoLast = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.GotoNext = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.GotoPrev = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.MouseModeMove = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.MouseModeZoom = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.NextFile = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PageRange = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PreviousFile = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PrintAllPages = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PrintCurrentPage = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.PrintToFax = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SaveAs = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SearchNext = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SearchOptions = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SearchStart = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SearchText = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SendTo = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.SlideshowMode = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.ZoomCombo = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.ZoomReset = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.ZoomRevert = combit.Reporting.LlButtonState.[Default]
        Me.PreviewControl.ToolbarButtons.ZoomTimes2 = combit.Reporting.LlButtonState.[Default]
        '
        'statusBar
        '
        Me.statusBar.Location = New System.Drawing.Point(0, 554)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusBarPanel1, Me.statusBarPanel2})
        Me.statusBar.ShowPanels = True
        Me.statusBar.Size = New System.Drawing.Size(768, 16)
        Me.statusBar.TabIndex = 1
        '
        'statusBarPanel1
        '
        Me.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.statusBarPanel1.Name = "statusBarPanel1"
        Me.statusBarPanel1.ToolTipText = "Displayed File"
        Me.statusBarPanel1.Width = 659
        '
        'statusBarPanel2
        '
        Me.statusBarPanel2.Name = "statusBarPanel2"
        Me.statusBarPanel2.ToolTipText = "Page index"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 570)
        Me.Controls.Add(Me.PreviewControl)
        Me.Controls.Add(Me.statusBar)
        Me.Name = "Form1"
        Me.Text = "List & Label VB.NET Viewer Sample"
        CType(Me.statusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents PreviewControl As combit.Reporting.ListLabelPreviewControl
    Private WithEvents statusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Private WithEvents statusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Private WithEvents statusBar As System.Windows.Forms.StatusBar
#End Region
End Class

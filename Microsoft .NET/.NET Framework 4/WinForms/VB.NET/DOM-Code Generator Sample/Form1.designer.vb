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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenProjectFileToolStrip = New System.Windows.Forms.ToolStripButton()
        Me.SaveCodeToolStrip = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStrip = New System.Windows.Forms.ToolStripButton()
        Me.CutToolStrip = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ListLabelToolStrip = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.CodeLanguageToolStripCombo = New System.Windows.Forms.ToolStripComboBox()
        Me.GenerateCodeToolStrip = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.rtbCode = New System.Windows.Forms.RichTextBox()
        Me.rtfContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New CodeDomSample.ListLabelDomTreeView()
        Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GenerateCodeToolStrip2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.label1 = New System.Windows.Forms.Label()
        Me.toolStrip1.SuspendLayout()
        Me.rtfContextMenu.SuspendLayout()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.contextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "Line.bmp")
        Me.imageList1.Images.SetKeyName(1, "Mail_Front.bmp")
        Me.imageList1.Images.SetKeyName(2, "Picture2.bmp")
        Me.imageList1.Images.SetKeyName(3, "Chart.bmp")
        Me.imageList1.Images.SetKeyName(4, "Doc_OK2.bmp")
        Me.imageList1.Images.SetKeyName(5, "Doc_OK.bmp")
        Me.imageList1.Images.SetKeyName(6, "Folder.bmp")
        Me.imageList1.Images.SetKeyName(7, "Folder_Open.bmp")
        Me.imageList1.Images.SetKeyName(8, "Insert_Text.bmp")
        Me.imageList1.Images.SetKeyName(9, "RichTextBox.bmp")
        Me.imageList1.Images.SetKeyName(10, "ShowGridlines.bmp")
        Me.imageList1.Images.SetKeyName(11, "ShowRulelines.bmp")
        Me.imageList1.Images.SetKeyName(12, "ShowRuler.bmp")
        Me.imageList1.Images.SetKeyName(13, "Button.bmp")
        Me.imageList1.Images.SetKeyName(14, "Checkbox.bmp")
        Me.imageList1.Images.SetKeyName(15, "Combobox.bmp")
        Me.imageList1.Images.SetKeyName(16, "Groupbox.bmp")
        Me.imageList1.Images.SetKeyName(17, "Report.bmp")
        Me.imageList1.Images.SetKeyName(18, "Properties.bmp")
        Me.imageList1.Images.SetKeyName(19, "gauge.bmp")
        '
        'toolStrip1
        '
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenProjectFileToolStrip, Me.SaveCodeToolStrip, Me.toolStripSeparator1, Me.CopyToolStrip, Me.CutToolStrip, Me.toolStripSeparator3, Me.ListLabelToolStrip, Me.toolStripSeparator4, Me.toolStripLabel1, Me.CodeLanguageToolStripCombo, Me.GenerateCodeToolStrip, Me.toolStripSeparator2})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(871, 25)
        Me.toolStrip1.TabIndex = 4
        Me.toolStrip1.Text = "toolStrip1"
        '
        'OpenProjectFileToolStrip
        '
        Me.OpenProjectFileToolStrip.Image = CType(resources.GetObject("OpenProjectFileToolStrip.Image"), System.Drawing.Image)
        Me.OpenProjectFileToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenProjectFileToolStrip.Name = "OpenProjectFileToolStrip"
        Me.OpenProjectFileToolStrip.Size = New System.Drawing.Size(124, 22)
        Me.OpenProjectFileToolStrip.Text = "Open project file..."
        '
        'SaveCodeToolStrip
        '
        Me.SaveCodeToolStrip.Image = CType(resources.GetObject("SaveCodeToolStrip.Image"), System.Drawing.Image)
        Me.SaveCodeToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveCodeToolStrip.Name = "SaveCodeToolStrip"
        Me.SaveCodeToolStrip.Size = New System.Drawing.Size(92, 22)
        Me.SaveCodeToolStrip.Text = "Save code ..."
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'CopyToolStrip
        '
        Me.CopyToolStrip.Image = CType(resources.GetObject("CopyToolStrip.Image"), System.Drawing.Image)
        Me.CopyToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStrip.Name = "CopyToolStrip"
        Me.CopyToolStrip.Size = New System.Drawing.Size(55, 22)
        Me.CopyToolStrip.Text = "Copy"
        '
        'CutToolStrip
        '
        Me.CutToolStrip.Image = CType(resources.GetObject("CutToolStrip.Image"), System.Drawing.Image)
        Me.CutToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStrip.Name = "CutToolStrip"
        Me.CutToolStrip.Size = New System.Drawing.Size(46, 22)
        Me.CutToolStrip.Text = "Cut"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ListLabelToolStrip
        '
        Me.ListLabelToolStrip.Image = CType(resources.GetObject("ListLabelToolStrip.Image"), System.Drawing.Image)
        Me.ListLabelToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListLabelToolStrip.Name = "ListLabelToolStrip"
        Me.ListLabelToolStrip.Size = New System.Drawing.Size(100, 22)
        Me.ListLabelToolStrip.Text = "Start Designer"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripLabel1
        '
        Me.toolStripLabel1.Name = "toolStripLabel1"
        Me.toolStripLabel1.Size = New System.Drawing.Size(90, 22)
        Me.toolStripLabel1.Text = "Code language:"
        '
        'CodeLanguageToolStripCombo
        '
        Me.CodeLanguageToolStripCombo.Items.AddRange(New Object() {"C#", "VB.Net"})
        Me.CodeLanguageToolStripCombo.Name = "CodeLanguageToolStripCombo"
        Me.CodeLanguageToolStripCombo.Size = New System.Drawing.Size(75, 25)
        '
        'GenerateCodeToolStrip
        '
        Me.GenerateCodeToolStrip.Image = CType(resources.GetObject("GenerateCodeToolStrip.Image"), System.Drawing.Image)
        Me.GenerateCodeToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GenerateCodeToolStrip.Name = "GenerateCodeToolStrip"
        Me.GenerateCodeToolStrip.Size = New System.Drawing.Size(112, 22)
        Me.GenerateCodeToolStrip.Text = "Generate code..."
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'rtbCode
        '
        Me.rtbCode.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbCode.ContextMenuStrip = Me.rtfContextMenu
        Me.rtbCode.Location = New System.Drawing.Point(0, 0)
        Me.rtbCode.Name = "rtbCode"
        Me.rtbCode.Size = New System.Drawing.Size(556, 518)
        Me.rtbCode.TabIndex = 5
        Me.rtbCode.Text = ""
        Me.rtbCode.WordWrap = False
        '
        'rtfContextMenu
        '
        Me.rtfContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenu, Me.CutToolStripMenu})
        Me.rtfContextMenu.Name = "rtfContextMenu"
        Me.rtfContextMenu.Size = New System.Drawing.Size(103, 48)
        '
        'CopyToolStripMenu
        '
        Me.CopyToolStripMenu.Name = "CopyToolStripMenu"
        Me.CopyToolStripMenu.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenu.Text = "Copy"
        '
        'CutToolStripMenu
        '
        Me.CutToolStripMenu.Name = "CutToolStripMenu"
        Me.CutToolStripMenu.Size = New System.Drawing.Size(102, 22)
        Me.CutToolStripMenu.Text = "Cut"
        '
        'splitContainer1
        '
        Me.splitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitContainer1.Location = New System.Drawing.Point(10, 34)
        Me.splitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.rtbCode)
        Me.splitContainer1.Size = New System.Drawing.Size(852, 518)
        Me.splitContainer1.SplitterDistance = 292
        Me.splitContainer1.TabIndex = 6
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.ContextMenuStrip = Me.contextMenuStrip1
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.imageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(290, 518)
        Me.TreeView1.TabIndex = 1
        '
        'contextMenuStrip1
        '
        Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateCodeToolStrip2})
        Me.contextMenuStrip1.Name = "contextMenuStrip1"
        Me.contextMenuStrip1.Size = New System.Drawing.Size(151, 26)
        '
        'GenerateCodeToolStrip2
        '
        Me.GenerateCodeToolStrip2.Image = CType(resources.GetObject("GenerateCodeToolStrip2.Image"), System.Drawing.Image)
        Me.GenerateCodeToolStrip2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GenerateCodeToolStrip2.Name = "GenerateCodeToolStrip2"
        Me.GenerateCodeToolStrip2.Size = New System.Drawing.Size(150, 22)
        Me.GenerateCodeToolStrip2.Text = "Generate code"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(20, 491)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(831, 132)
        Me.label1.TabIndex = 8
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(871, 561)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.toolStrip1)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "Form1"
        Me.Text = "List & Label VB.NET DOM-Code Generator Sample"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.rtfContextMenu.ResumeLayout(False)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.contextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
    Private WithEvents TreeView1 As ListLabelDomTreeView
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents OpenProjectFileToolStrip As System.Windows.Forms.ToolStripButton
    Private WithEvents rtbCode As System.Windows.Forms.RichTextBox
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents ListLabelToolStrip As System.Windows.Forms.ToolStripButton
    Private WithEvents GenerateCodeToolStrip As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Private WithEvents CodeLanguageToolStripCombo As System.Windows.Forms.ToolStripComboBox
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents CopyToolStrip As System.Windows.Forms.ToolStripButton
    Private WithEvents CutToolStrip As System.Windows.Forms.ToolStripButton
    Private WithEvents SaveCodeToolStrip As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents GenerateCodeToolStrip2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents rtfContextMenu As System.Windows.Forms.ContextMenuStrip
    Private WithEvents CopyToolStripMenu As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents CutToolStripMenu As System.Windows.Forms.ToolStripMenuItem
End Class

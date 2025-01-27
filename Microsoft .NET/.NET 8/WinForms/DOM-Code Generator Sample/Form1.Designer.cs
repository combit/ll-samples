namespace CodeDomSample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenProjectFileToolStrip = new System.Windows.Forms.ToolStripButton();
            this.SaveCodeToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyToolStrip = new System.Windows.Forms.ToolStripButton();
            this.CutToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ListLabelToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.CodeLanguageToolStripCombo = new System.Windows.Forms.ToolStripComboBox();
            this.GenerateCodeToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.searchToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.rtfContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.llDomTreeView = new CodeDomSample.ListLabelDomTreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GenerateCodeToolStrip2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.rtfContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "Line.bmp");
            this.imageList1.Images.SetKeyName(1, "Mail_Front.bmp");
            this.imageList1.Images.SetKeyName(2, "Picture2.bmp");
            this.imageList1.Images.SetKeyName(3, "Chart.bmp");
            this.imageList1.Images.SetKeyName(4, "Doc_OK2.bmp");
            this.imageList1.Images.SetKeyName(5, "Doc_OK.bmp");
            this.imageList1.Images.SetKeyName(6, "Folder.bmp");
            this.imageList1.Images.SetKeyName(7, "Folder_Open.bmp");
            this.imageList1.Images.SetKeyName(8, "Insert_Text.bmp");
            this.imageList1.Images.SetKeyName(9, "RichTextBox.bmp");
            this.imageList1.Images.SetKeyName(10, "ShowGridlines.bmp");
            this.imageList1.Images.SetKeyName(11, "ShowRulelines.bmp");
            this.imageList1.Images.SetKeyName(12, "ShowRuler.bmp");
            this.imageList1.Images.SetKeyName(13, "Button.bmp");
            this.imageList1.Images.SetKeyName(14, "Checkbox.bmp");
            this.imageList1.Images.SetKeyName(15, "Combobox.bmp");
            this.imageList1.Images.SetKeyName(16, "Groupbox.bmp");
            this.imageList1.Images.SetKeyName(17, "Report.bmp");
            this.imageList1.Images.SetKeyName(18, "Properties.bmp");
            this.imageList1.Images.SetKeyName(19, "gauge.bmp");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenProjectFileToolStrip,
            this.SaveCodeToolStrip,
            this.toolStripSeparator1,
            this.CopyToolStrip,
            this.CutToolStrip,
            this.toolStripSeparator3,
            this.ListLabelToolStrip,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.CodeLanguageToolStripCombo,
            this.GenerateCodeToolStrip,
            this.toolStripSeparator2,
            this.searchToolStripTextBox,
            this.searchToolStripButton,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(896, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenProjectFileToolStrip
            // 
            this.OpenProjectFileToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("OpenProjectFileToolStrip.Image")));
            this.OpenProjectFileToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenProjectFileToolStrip.Name = "OpenProjectFileToolStrip";
            this.OpenProjectFileToolStrip.Size = new System.Drawing.Size(124, 22);
            this.OpenProjectFileToolStrip.Text = "Open project file...";
            this.OpenProjectFileToolStrip.Click += new System.EventHandler(this.OpenProjectFileToolStrip_Click);
            // 
            // SaveCodeToolStrip
            // 
            this.SaveCodeToolStrip.Enabled = false;
            this.SaveCodeToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("SaveCodeToolStrip.Image")));
            this.SaveCodeToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveCodeToolStrip.Name = "SaveCodeToolStrip";
            this.SaveCodeToolStrip.Size = new System.Drawing.Size(92, 22);
            this.SaveCodeToolStrip.Text = "Save code ...";
            this.SaveCodeToolStrip.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // CopyToolStrip
            // 
            this.CopyToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("CopyToolStrip.Image")));
            this.CopyToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyToolStrip.Name = "CopyToolStrip";
            this.CopyToolStrip.Size = new System.Drawing.Size(55, 22);
            this.CopyToolStrip.Text = "Copy";
            this.CopyToolStrip.Click += new System.EventHandler(this.CopyToolStrip_Click);
            // 
            // CutToolStrip
            // 
            this.CutToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("CutToolStrip.Image")));
            this.CutToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutToolStrip.Name = "CutToolStrip";
            this.CutToolStrip.Size = new System.Drawing.Size(46, 22);
            this.CutToolStrip.Text = "Cut";
            this.CutToolStrip.Click += new System.EventHandler(this.CutToolStrip_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ListLabelToolStrip
            // 
            this.ListLabelToolStrip.Enabled = false;
            this.ListLabelToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("ListLabelToolStrip.Image")));
            this.ListLabelToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ListLabelToolStrip.Name = "ListLabelToolStrip";
            this.ListLabelToolStrip.Size = new System.Drawing.Size(100, 22);
            this.ListLabelToolStrip.Text = "Start Designer";
            this.ListLabelToolStrip.Click += new System.EventHandler(this.ListLabelToolStrip_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel1.Text = "Code language:";
            // 
            // CodeLanguageToolStripCombo
            // 
            this.CodeLanguageToolStripCombo.Items.AddRange(new object[] {
            "C#",
            "VB.Net"});
            this.CodeLanguageToolStripCombo.Name = "CodeLanguageToolStripCombo";
            this.CodeLanguageToolStripCombo.Size = new System.Drawing.Size(75, 25);
            // 
            // GenerateCodeToolStrip
            // 
            this.GenerateCodeToolStrip.Enabled = false;
            this.GenerateCodeToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("GenerateCodeToolStrip.Image")));
            this.GenerateCodeToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GenerateCodeToolStrip.Name = "GenerateCodeToolStrip";
            this.GenerateCodeToolStrip.Size = new System.Drawing.Size(112, 22);
            this.GenerateCodeToolStrip.Text = "Generate code...";
            this.GenerateCodeToolStrip.Click += new System.EventHandler(this.GenerateCodeTooStrip_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // searchToolStripTextBox
            // 
            this.searchToolStripTextBox.Name = "searchToolStripTextBox";
            this.searchToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            this.searchToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchToolStripTextBox_KeyPress);
            // 
            // searchToolStripButton
            // 
            this.searchToolStripButton.Enabled = false;
            this.searchToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripButton.Image")));
            this.searchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchToolStripButton.Name = "searchToolStripButton";
            this.searchToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.searchToolStripButton.Text = "Find";
            this.searchToolStripButton.Click += new System.EventHandler(this.SearchToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // rtbCode
            // 
            this.rtbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCode.ContextMenuStrip = this.rtfContextMenu;
            this.rtbCode.Location = new System.Drawing.Point(0, 0);
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.Size = new System.Drawing.Size(560, 406);
            this.rtbCode.TabIndex = 5;
            this.rtbCode.Text = "";
            this.rtbCode.WordWrap = false;
            // 
            // rtfContextMenu
            // 
            this.rtfContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripMenu,
            this.CutToolStripMenu});
            this.rtfContextMenu.Name = "rtfContextMenu";
            this.rtfContextMenu.Size = new System.Drawing.Size(103, 48);
            // 
            // CopyToolStripMenu
            // 
            this.CopyToolStripMenu.Name = "CopyToolStripMenu";
            this.CopyToolStripMenu.Size = new System.Drawing.Size(102, 22);
            this.CopyToolStripMenu.Text = "Copy";
            this.CopyToolStripMenu.Click += new System.EventHandler(this.CopyToolStripMenu_Click);
            // 
            // CutToolStripMenu
            // 
            this.CutToolStripMenu.Name = "CutToolStripMenu";
            this.CutToolStripMenu.Size = new System.Drawing.Size(102, 22);
            this.CutToolStripMenu.Text = "Cut";
            this.CutToolStripMenu.Click += new System.EventHandler(this.CutToolStripMenu_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(20, 39);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.llDomTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbCode);
            this.splitContainer1.Size = new System.Drawing.Size(853, 406);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 6;
            // 
            // llDomTreeView
            // 
            this.llDomTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.llDomTreeView.ContextMenuStrip = this.contextMenuStrip1;
            this.llDomTreeView.ImageIndex = 0;
            this.llDomTreeView.ImageList = this.imageList1;
            this.llDomTreeView.Location = new System.Drawing.Point(0, 0);
            this.llDomTreeView.Name = "llDomTreeView";
            this.llDomTreeView.SelectedImageIndex = 0;
            this.llDomTreeView.Size = new System.Drawing.Size(292, 406);
            this.llDomTreeView.TabIndex = 1;
            this.llDomTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GenerateCodeToolStrip2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // GenerateCodeToolStrip2
            // 
            this.GenerateCodeToolStrip2.Image = ((System.Drawing.Image)(resources.GetObject("GenerateCodeToolStrip2.Image")));
            this.GenerateCodeToolStrip2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GenerateCodeToolStrip2.Name = "GenerateCodeToolStrip2";
            this.GenerateCodeToolStrip2.Size = new System.Drawing.Size(150, 22);
            this.GenerateCodeToolStrip2.Text = "Generate code";
            this.GenerateCodeToolStrip2.Click += new System.EventHandler(this.GenerateCodeToolStrip2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 491);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(831, 132);
            this.label1.TabIndex = 8;
            // 
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 464);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Form1";
            this.Text = "List & Label DOM-Code Generator Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.rtfContextMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private ListLabelDomTreeView llDomTreeView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton OpenProjectFileToolStrip;
        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton ListLabelToolStrip;
        private System.Windows.Forms.ToolStripButton GenerateCodeToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox CodeLanguageToolStripCombo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton CopyToolStrip;
        private System.Windows.Forms.ToolStripButton CutToolStrip;
        private System.Windows.Forms.ToolStripButton SaveCodeToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GenerateCodeToolStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip rtfContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem CutToolStripMenu;
        private System.Windows.Forms.ToolStripTextBox searchToolStripTextBox;
        private System.Windows.Forms.ToolStripButton searchToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}

namespace TXTextControlSample
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileLoadDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOptionsRecalcTableLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDesignDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrintPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.listLabel = new combit.Reporting.ListLabel(this.components);
            this.listLabelRTFControl = new combit.Reporting.ListLabelRTFControl(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.AutoSize = false;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuDesign,
            this.menuPrint});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(787, 24);
            this.mainMenu.TabIndex = 0;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileLoadDocument,
            this.toolStripSeparator2,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileLoadDocument
            // 
            this.menuFileLoadDocument.Name = "menuFileLoadDocument";
            this.menuFileLoadDocument.Size = new System.Drawing.Size(191, 22);
            this.menuFileLoadDocument.Text = "Load RTF Document...";
            this.menuFileLoadDocument.Click += new System.EventHandler(this.MenuFileLoadDocument_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOptionsRecalcTableLayout});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // menuFileOptionsRecalcTableLayout
            // 
            this.menuFileOptionsRecalcTableLayout.CheckOnClick = true;
            this.menuFileOptionsRecalcTableLayout.Name = "menuFileOptionsRecalcTableLayout";
            this.menuFileOptionsRecalcTableLayout.Size = new System.Drawing.Size(173, 22);
            this.menuFileOptionsRecalcTableLayout.Text = "RecalcTableLayout";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(191, 22);
            this.menuFileExit.Text = "Exit";
            this.menuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // menuDesign
            // 
            this.menuDesign.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDesignDesign});
            this.menuDesign.Name = "menuDesign";
            this.menuDesign.Size = new System.Drawing.Size(55, 20);
            this.menuDesign.Text = "Design";
            // 
            // menuDesignDesign
            // 
            this.menuDesignDesign.Name = "menuDesignDesign";
            this.menuDesignDesign.Size = new System.Drawing.Size(119, 22);
            this.menuDesignDesign.Text = "Design...";
            this.menuDesignDesign.Click += new System.EventHandler(this.MenuDesignDesign_Click);
            // 
            // menuPrint
            // 
            this.menuPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrintPrint});
            this.menuPrint.Name = "menuPrint";
            this.menuPrint.Size = new System.Drawing.Size(44, 20);
            this.menuPrint.Text = "Print";
            // 
            // menuPrintPrint
            // 
            this.menuPrintPrint.Name = "menuPrintPrint";
            this.menuPrintPrint.Size = new System.Drawing.Size(108, 22);
            this.menuPrintPrint.Text = "Print...";
            this.menuPrintPrint.Click += new System.EventHandler(this.MenuPrintPrint_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "RTF Files|*.rtf";
            this.openFileDialog.Title = "Open RTF File";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "rtf";
            this.saveFileDialog.FileName = "newDocument.rtf";
            this.saveFileDialog.Filter = "RTF Files|*.rtf";
            this.saveFileDialog.Title = "Save RTF File";
            // 
            // listLabel
            // 
            this.listLabel.AutoPrinterSettingsStream = null;
            this.listLabel.AutoProjectStream = null;
            this.listLabel.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad;
            this.listLabel.DrilldownAvailable = true;
            this.listLabel.EMFResolution = 100;
            this.listLabel.FileRepository = null;
            this.listLabel.GenericMaximumRecordCount = -1;
            this.listLabel.LockNextChar = 8288;
            this.listLabel.MaxRTFVersion = 65280;
            this.listLabel.PhantomSpace = 8203;
            this.listLabel.PreviewControl = null;
            this.listLabel.Unit = combit.Reporting.LlUnits.Millimeter_1_1000;
            this.listLabel.UseHardwareCopiesForLabels = false;
            this.listLabel.UseTableSchemaForDesignMode = false;
            // 
            // listLabelRTFControl
            // 
            this.listLabelRTFControl.Enabled = false;
            this.listLabelRTFControl.Location = new System.Drawing.Point(20, 90);
            this.listLabelRTFControl.Name = "listLabelRTFControl";
            this.listLabelRTFControl.ParentComponent = this.listLabel;
            this.listLabelRTFControl.Size = new System.Drawing.Size(751, 611);
            this.listLabelRTFControl.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(20, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(751, 47);
            this.label1.TabIndex = 4;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(787, 703);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listLabelRTFControl);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List & Label and TX Text Control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuDesign;
        private System.Windows.Forms.ToolStripMenuItem menuDesignDesign;
        private System.Windows.Forms.ToolStripMenuItem menuPrint;
        private System.Windows.Forms.ToolStripMenuItem menuPrintPrint;
        private System.Windows.Forms.ToolStripMenuItem menuFileLoadDocument;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private combit.Reporting.ListLabel listLabel;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileOptionsRecalcTableLayout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private combit.Reporting.ListLabelRTFControl listLabelRTFControl;
        private System.Windows.Forms.Label label1;
    }
}

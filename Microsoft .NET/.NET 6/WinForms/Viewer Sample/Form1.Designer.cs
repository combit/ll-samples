namespace csharpviewer
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
            this.PreviewControl = new combit.Reporting.ListLabelPreviewControl(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarPanel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarPanel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SuspendLayout();
            // 
            // PreviewControl
            // 
            this.PreviewControl.AllowRbuttonUsage = true;
            this.PreviewControl.BackColor = System.Drawing.SystemColors.Control;
            this.PreviewControl.CurrentPage = 0;
            this.PreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewControl.ForceReadOnly = false;
            this.PreviewControl.Location = new System.Drawing.Point(20, 60);
            this.PreviewControl.Name = "PreviewControl";
            this.PreviewControl.Size = new System.Drawing.Size(760, 654);
            this.PreviewControl.SlideshowMode = false;
            this.PreviewControl.TabIndex = 0;
            this.PreviewControl.ToolbarButtons.Exit = combit.Reporting.LlButtonState.Invisible;
            this.PreviewControl.ToolbarButtons.GotoFirst = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.GotoLast = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.GotoNext = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.GotoPrev = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.NextFile = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PageRange = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PreviousFile = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PrintAllPages = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PrintCurrentPage = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PrintToFax = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SaveAs = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SearchNext = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SearchOptions = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SearchStart = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SearchText = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SendTo = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SlideshowMode = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.ZoomCombo = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.ZoomReset = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.ZoomRevert = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.ZoomTimes2 = combit.Reporting.LlButtonState.Default;
            this.PreviewControl.PageChanged += new combit.Reporting.ListLabelPreviewControl.PageChangedHandler(this.PreviewControl_PageChanged);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(20, 714);
            this.statusBar.Name = "statusBar";
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar.Size = new System.Drawing.Size(760, 16);
            this.statusBar.ShowItemToolTips = true;
            this.statusBar.TabIndex = 1;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.ToolTipText = "Displayed File";
            this.statusBarPanel1.Width = 635;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.ToolTipText = "Page index";
            this.statusBarPanel2.Spring = true;
            this.statusBarPanel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 750);
            this.Controls.Add(this.PreviewControl);
            this.Controls.Add(this.statusBar);
            this.MinimumSize = new System.Drawing.Size(800, 750);
            this.Name = "Form1";
            this.Text = "List & Label Viewer Sample";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);

        }
        private combit.Reporting.ListLabelPreviewControl PreviewControl;
        private System.Windows.Forms.ToolStripStatusLabel statusBarPanel1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarPanel2;
        private System.Windows.Forms.StatusStrip statusBar;

        #endregion
    }
}

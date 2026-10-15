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
            components = new System.ComponentModel.Container();
            PreviewControl = new combit.Reporting.ListLabelPreviewControl(components);
            statusBar = new System.Windows.Forms.StatusStrip();
            statusBarPanel1 = new System.Windows.Forms.ToolStripStatusLabel();
            statusBarPanel2 = new System.Windows.Forms.ToolStripStatusLabel();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // PreviewControl
            // 
            PreviewControl.AllowRbuttonUsage = true;
            PreviewControl.BackColor = System.Drawing.SystemColors.Control;
            PreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            PreviewControl.Location = new System.Drawing.Point(0, 0);
            PreviewControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PreviewControl.Name = "PreviewControl";
            PreviewControl.Size = new System.Drawing.Size(933, 843);
            PreviewControl.SlideshowMode = false;
            PreviewControl.TabIndex = 0;
            PreviewControl.ToolbarButtons.Exit = combit.Reporting.LlButtonState.Invisible;
            PreviewControl.ToolbarButtons.GotoFirst = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.GotoLast = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.GotoNext = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.GotoPrev = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.MouseModeMove = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.MouseModeSelect = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.MouseModeZoom = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.NextFile = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.PageRange = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.PreviousFile = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.PrintAllPages = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.PrintCurrentPage = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.PrintToFax = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.SaveAs = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.SearchNext = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.SearchOptions = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.SearchStart = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.SearchText = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.SendTo = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.SlideshowMode = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.ZoomCombo = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.ZoomReset = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.ZoomRevert = combit.Reporting.LlButtonState.Default;
            PreviewControl.ToolbarButtons.ZoomTimes2 = combit.Reporting.LlButtonState.Default;
            PreviewControl.PageChanged += PreviewControl_PageChanged;
            // 
            // statusBar
            // 
            statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusBarPanel1, statusBarPanel2 });
            statusBar.Location = new System.Drawing.Point(0, 843);
            statusBar.Name = "statusBar";
            statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusBar.ShowItemToolTips = true;
            statusBar.Size = new System.Drawing.Size(933, 22);
            statusBar.TabIndex = 1;
            // 
            // statusBarPanel1
            // 
            statusBarPanel1.Name = "statusBarPanel1";
            statusBarPanel1.Size = new System.Drawing.Size(0, 17);
            statusBarPanel1.ToolTipText = "Displayed File";
            // 
            // statusBarPanel2
            // 
            statusBarPanel2.Name = "statusBarPanel2";
            statusBarPanel2.Size = new System.Drawing.Size(916, 17);
            statusBarPanel2.Spring = true;
            statusBarPanel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            statusBarPanel2.ToolTipText = "Page index";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 865);
            Controls.Add(PreviewControl);
            Controls.Add(statusBar);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(931, 859);
            Name = "Form1";
            Text = "List & Label Viewer Sample";
            FormClosing += Form1_FormClosing;
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        private combit.Reporting.ListLabelPreviewControl PreviewControl;
        private System.Windows.Forms.ToolStripStatusLabel statusBarPanel1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarPanel2;
        private System.Windows.Forms.StatusStrip statusBar;

        #endregion
    }
}

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
            this.PreviewControl = new combit.ListLabel25.ListLabelPreviewControl(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
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
            this.PreviewControl.ToolbarButtons.Exit = combit.ListLabel25.LlButtonState.Invisible;
            this.PreviewControl.ToolbarButtons.GotoFirst = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.GotoLast = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.GotoNext = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.GotoPrev = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.NextFile = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PageRange = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PreviousFile = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PrintAllPages = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PrintCurrentPage = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.PrintToFax = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SaveAs = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SearchNext = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SearchOptions = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SearchStart = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SearchText = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SendTo = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.SlideshowMode = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.ZoomCombo = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.ZoomReset = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.ZoomRevert = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.ToolbarButtons.ZoomTimes2 = combit.ListLabel25.LlButtonState.Default;
            this.PreviewControl.PageChanged += new combit.ListLabel25.ListLabelPreviewControl.PageChangedHandler(this.PreviewControl_PageChanged);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(20, 714);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(760, 16);
            this.statusBar.TabIndex = 1;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.ToolTipText = "Displayed File";
            this.statusBarPanel1.Width = 635;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.ToolTipText = "Page index";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(800, 750);
            this.Controls.Add(this.PreviewControl);
            this.Controls.Add(this.statusBar);
            this.MinimumSize = new System.Drawing.Size(800, 750);
            this.Name = "Form1";
            this.Text = "List & Label C# Viewer Sample";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.ResumeLayout(false);

        }
        private combit.ListLabel25.ListLabelPreviewControl PreviewControl;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBar statusBar;

        #endregion
    }
}

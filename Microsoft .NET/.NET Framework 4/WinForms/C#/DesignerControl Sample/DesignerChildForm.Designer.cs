namespace DesignerControl
{
    partial class DesignerChildForm
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
        /// 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LL = new combit.ListLabel25.ListLabel(this.components);
            this.designerControl1 = new combit.ListLabel25.DesignerControl();
            this.SuspendLayout();
            // 
            // LL
            // 
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.ListLabel25.LlUnits.Millimeter_1_100;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            // 
            // designerControl1
            // 
            this.designerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designerControl1.Location = new System.Drawing.Point(20, 60);
            this.designerControl1.Name = "designerControl1";
            this.designerControl1.ParentComponent = this.LL;
            this.designerControl1.Size = new System.Drawing.Size(837, 656);
            this.designerControl1.TabIndex = 0;
            this.designerControl1.Text = "designerControl1";
            // 
            // DesignerChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 736);
            this.Controls.Add(this.designerControl1);
			this.MinimumSize = new System.Drawing.Size(877, 736);
            this.Name = "DesignerChildForm";
            this.Text = "Designer Control Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DesignerChildForm_FormClosing);
            this.Shown += new System.EventHandler(this.DesignerChildForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private combit.ListLabel25.ListLabel LL;
        private combit.ListLabel25.DesignerControl designerControl1;       
    }
}

namespace Data_Binding_2
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonInvoiceMergePrint = new System.Windows.Forms.Button();
            this.buttonInvoiceMergeDesign = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonInvoiceItemsPrint = new System.Windows.Forms.Button();
            this.buttonInvoiceItemsDesign = new System.Windows.Forms.Button();
            this.LL = new combit.Reporting.ListLabel(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(55, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(486, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dieses Beispiel zeigt die Verwendung der Datenübergabe für die Methoden Print und" +
    " Design im datengebundenen Modus.";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "US:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(55, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(486, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "This sample shows the usage of databinding for the methods Print and Design in th" +
    "e databind mode.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "D:  ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonInvoiceMergePrint);
            this.groupBox1.Controls.Add(this.buttonInvoiceMergeDesign);
            this.groupBox1.Location = new System.Drawing.Point(285, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Merge";
            // 
            // buttonInvoiceMergePrint
            // 
            this.buttonInvoiceMergePrint.Location = new System.Drawing.Point(104, 24);
            this.buttonInvoiceMergePrint.Name = "buttonInvoiceMergePrint";
            this.buttonInvoiceMergePrint.Size = new System.Drawing.Size(136, 23);
            this.buttonInvoiceMergePrint.TabIndex = 4;
            this.buttonInvoiceMergePrint.Text = "Print/Preview/Export...";
            this.buttonInvoiceMergePrint.Click += new System.EventHandler(this.ButtonInvoiceMergePrint_Click);
            // 
            // buttonInvoiceMergeDesign
            // 
            this.buttonInvoiceMergeDesign.Location = new System.Drawing.Point(16, 24);
            this.buttonInvoiceMergeDesign.Name = "buttonInvoiceMergeDesign";
            this.buttonInvoiceMergeDesign.Size = new System.Drawing.Size(75, 23);
            this.buttonInvoiceMergeDesign.TabIndex = 3;
            this.buttonInvoiceMergeDesign.Text = "Design...";
            this.buttonInvoiceMergeDesign.Click += new System.EventHandler(this.ButtonInvoiceMergeDesign_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonInvoiceItemsPrint);
            this.groupBox2.Controls.Add(this.buttonInvoiceItemsDesign);
            this.groupBox2.Location = new System.Drawing.Point(23, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Invoice && Items List";
            // 
            // buttonInvoiceItemsPrint
            // 
            this.buttonInvoiceItemsPrint.Location = new System.Drawing.Point(104, 24);
            this.buttonInvoiceItemsPrint.Name = "buttonInvoiceItemsPrint";
            this.buttonInvoiceItemsPrint.Size = new System.Drawing.Size(136, 23);
            this.buttonInvoiceItemsPrint.TabIndex = 2;
            this.buttonInvoiceItemsPrint.Text = "Print/Preview/Export...";
            this.buttonInvoiceItemsPrint.Click += new System.EventHandler(this.ButtonInvoiceItemsPrint_Click);
            // 
            // buttonInvoiceItemsDesign
            // 
            this.buttonInvoiceItemsDesign.Location = new System.Drawing.Point(16, 24);
            this.buttonInvoiceItemsDesign.Name = "buttonInvoiceItemsDesign";
            this.buttonInvoiceItemsDesign.Size = new System.Drawing.Size(75, 23);
            this.buttonInvoiceItemsDesign.TabIndex = 1;
            this.buttonInvoiceItemsDesign.Text = "Design...";
            this.buttonInvoiceItemsDesign.Click += new System.EventHandler(this.ButtonInvoiceItemsDesign_Click);
            // 
            // LL
            // 
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.CompressStorage = true;
            this.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad;
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.FileRepository = null;
            this.LL.GenericMaximumRecordCount = -1;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_100;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 183);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List & Label Databinding2 Sample";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonInvoiceMergeDesign;
        private System.Windows.Forms.Button buttonInvoiceMergePrint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonInvoiceItemsPrint;
        private System.Windows.Forms.Button buttonInvoiceItemsDesign;
        private combit.Reporting.ListLabel LL;
        #endregion
    }
}

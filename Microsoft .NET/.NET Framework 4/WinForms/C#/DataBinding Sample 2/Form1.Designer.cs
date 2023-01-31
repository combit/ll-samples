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
            this.invoiceMergePrintButton = new System.Windows.Forms.Button();
            this.invoiceMergeDesignButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.invoiceItemsPrintButton = new System.Windows.Forms.Button();
            this.invoiceItemsDesignButton = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.invoiceMergePrintButton);
            this.groupBox1.Controls.Add(this.invoiceMergeDesignButton);
            this.groupBox1.Location = new System.Drawing.Point(285, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Merge";
            // 
            // invoiceMergePrintButton
            // 
            this.invoiceMergePrintButton.Location = new System.Drawing.Point(104, 24);
            this.invoiceMergePrintButton.Name = "invoiceMergePrintButton";
            this.invoiceMergePrintButton.Size = new System.Drawing.Size(136, 23);
            this.invoiceMergePrintButton.TabIndex = 4;
            this.invoiceMergePrintButton.Text = "Print/Preview/Export...";
            this.invoiceMergePrintButton.Click += new System.EventHandler(this.InvoiceMergePrintButton_Click);
            // 
            // invoiceMergeDesignButton
            // 
            this.invoiceMergeDesignButton.Location = new System.Drawing.Point(16, 24);
            this.invoiceMergeDesignButton.Name = "invoiceMergeDesignButton";
            this.invoiceMergeDesignButton.Size = new System.Drawing.Size(75, 23);
            this.invoiceMergeDesignButton.TabIndex = 3;
            this.invoiceMergeDesignButton.Text = "Design...";
            this.invoiceMergeDesignButton.Click += new System.EventHandler(this.InvoiceMergeDesignButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.invoiceItemsPrintButton);
            this.groupBox2.Controls.Add(this.invoiceItemsDesignButton);
            this.groupBox2.Location = new System.Drawing.Point(23, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Invoice && Items List";
            // 
            // invoiceItemsPrintButton
            // 
            this.invoiceItemsPrintButton.Location = new System.Drawing.Point(104, 24);
            this.invoiceItemsPrintButton.Name = "invoiceItemsPrintButton";
            this.invoiceItemsPrintButton.Size = new System.Drawing.Size(136, 23);
            this.invoiceItemsPrintButton.TabIndex = 2;
            this.invoiceItemsPrintButton.Text = "Print/Preview/Export...";
            this.invoiceItemsPrintButton.Click += new System.EventHandler(this.InvoiceItemsPrintButton_Click);
            // 
            // invoiceItemsDesignButton
            // 
            this.invoiceItemsDesignButton.Location = new System.Drawing.Point(16, 24);
            this.invoiceItemsDesignButton.Name = "invoiceItemsDesignButton";
            this.invoiceItemsDesignButton.Size = new System.Drawing.Size(75, 23);
            this.invoiceItemsDesignButton.TabIndex = 1;
            this.invoiceItemsDesignButton.Text = "Design...";
            this.invoiceItemsDesignButton.Click += new System.EventHandler(this.InvoiceItemsDesignButton_Click);
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
            this.Text = "List & Label C# Databinding2 Sample";
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
        private System.Windows.Forms.Button invoiceMergeDesignButton;
        private System.Windows.Forms.Button invoiceMergePrintButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button invoiceItemsPrintButton;
        private System.Windows.Forms.Button invoiceItemsDesignButton;
        private combit.Reporting.ListLabel LL;
        #endregion
    }
}

namespace TXTextDesignerObject
{
	partial class FormEditTXTextControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditTXTextControl));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxIdentifiers = new System.Windows.Forms.ComboBox();
            this.listLabelEditRTFControl = new combit.ListLabel24.ListLabelRTFControl(this.components);
            this.serverTextControl1 = new TXTextControl.ServerTextControl();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(818, 471);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(714, 471);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 24);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Quelle: ";
            // 
            // comboBoxIdentifiers
            // 
            this.comboBoxIdentifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdentifiers.FormattingEnabled = true;
            this.comboBoxIdentifiers.Location = new System.Drawing.Point(94, 66);
            this.comboBoxIdentifiers.Name = "comboBoxIdentifiers";
            this.comboBoxIdentifiers.Size = new System.Drawing.Size(819, 21);
            this.comboBoxIdentifiers.Sorted = true;
            this.comboBoxIdentifiers.TabIndex = 8;
            this.comboBoxIdentifiers.SelectedIndexChanged += new System.EventHandler(this.ComboBoxIdentifiers_SelectedIndexChanged);
            // 
            // listLabelEditRTFControl
            // 
            this.listLabelEditRTFControl.Location = new System.Drawing.Point(15, 93);
            this.listLabelEditRTFControl.Name = "listLabelEditRTFControl";
            this.listLabelEditRTFControl.ParentComponent = null;
            this.listLabelEditRTFControl.Size = new System.Drawing.Size(898, 370);
            this.listLabelEditRTFControl.TabIndex = 0;
            // 
            // serverTextControl1
            // 
            this.serverTextControl1.SpellChecker = null;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(903, 54);
            this.label2.TabIndex = 10;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // FormEditTXTextControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 507);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxIdentifiers);
            this.Controls.Add(this.listLabelEditRTFControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditTXTextControl";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit TXTextControl content";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditTXTextControl_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditTXTextControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private combit.ListLabel24.ListLabelRTFControl listLabelEditRTFControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxIdentifiers;

        #endregion

        private TXTextControl.ServerTextControl serverTextControl1;
        private System.Windows.Forms.Label label2;
    }
}

namespace C_
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.LL = new combit.Reporting.ListLabel(this.components);
            this.designerAction1 = new combit.Reporting.DesignerAction();
            this.designerFunction1 = new combit.Reporting.DesignerFunction();
            this.designerObject1 = new combit.Reporting.DesignerObject();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(53, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(410, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dieses Beispiel zeigt die Erweiterung des Designers mit C#.";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "US:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(53, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(410, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "This sample shows the extension of the designer with C#.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "D:  ";
            // 
            // listBox1
            // 
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(23, 73);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(440, 303);
            this.listBox1.TabIndex = 9;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1_DrawItem);
            this.listBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListBox1_MeasureItem);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(388, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Design...";
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // LL
            // 
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad;
            this.LL.DesignerActions.AddRange(new combit.Reporting.DesignerAction[] {
            this.designerAction1});
            this.LL.DesignerFunctions.AddRange(new combit.Reporting.DesignerExtensions.IDesignerFunction[] {
            this.designerFunction1});
            this.LL.DesignerObjects.AddRange(new combit.Reporting.DesignerObject[] {
            this.designerObject1});
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.FileRepository = null;
            this.LL.GenericMaximumRecordCount = -1;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.Reporting.LlUnits.Inch_1_100;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            // 
            // designerAction1
            // 
            this.designerAction1.IconId = 642;
            this.designerAction1.MenuHierarchy = "1.1";
            this.designerAction1.MenuText = "Find object";
            this.designerAction1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.designerAction1.TooltipText = "Find object";
            this.designerAction1.ExecuteAction += new combit.Reporting.DesignerAction.ExecuteActionHandler(this.DesignerAction1_ExecuteAction);
            // 
            // designerFunction1
            // 
            this.designerFunction1.Description = "Add two numeric values";
            this.designerFunction1.FunctionName = "Add";
            this.designerFunction1.GroupName = "Operators";
            this.designerFunction1.MaximumParameters = 2;
            this.designerFunction1.MinimalParameters = 2;
            this.designerFunction1.Parameter1.Description = "First Value";
            this.designerFunction1.Parameter1.Type = combit.Reporting.LlParamType.Double;
            this.designerFunction1.Parameter2.Description = "Second Value";
            this.designerFunction1.Parameter2.Type = combit.Reporting.LlParamType.Double;
            this.designerFunction1.Parameter3.Description = "Parameter 3";
            this.designerFunction1.Parameter4.Description = "Parameter 4";
            this.designerFunction1.ResultType = combit.Reporting.LlParamType.Double;
            this.designerFunction1.EvaluateFunction += new combit.Reporting.EvaluateFunctionHandler(this.DesignerFunction1_EvaluateFunction);
            this.designerFunction1.ParameterAutoComplete += new combit.Reporting.ParameterAutoCompleteHandler(this.DesignerFunction1_ParameterAutoComplete);
            // 
            // designerObject1
            // 
            this.designerObject1.Description = "Sample Object";
            this.designerObject1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.designerObject1.Icon = ((System.Drawing.Icon)(resources.GetObject("designerObject1.Icon")));
            this.designerObject1.ObjectName = "SampleObject";
            this.designerObject1.SupportsContentDialog = true;
            this.designerObject1.TooltipDescription = null;
            this.designerObject1.DrawDesignerObject += new combit.Reporting.DrawDesignerObjectHandler(this.DesignerObject1_DrawDesignerObject);
            this.designerObject1.EditDesignerObject += new combit.Reporting.EditDesignerObjectHandler(this.DesignerObject1_EditDesignerObject);
            this.designerObject1.CreateDesignerObject += new combit.Reporting.CreateDesignerObjectHandler(this.DesignerObject1_CreateDesignerObject);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(483, 414);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List & Label C# Designer Extension Sample";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private combit.Reporting.ListLabel LL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private combit.Reporting.DesignerFunction designerFunction1;
        private combit.Reporting.DesignerObject designerObject1;
        private combit.Reporting.DesignerAction designerAction1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        #endregion
    }
}

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
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.LL = new combit.ListLabel24.ListLabel(this.components);
            this.designerAction1 = new combit.ListLabel24.DesignerAction();
            this.designerFunction1 = new combit.ListLabel24.DesignerFunction();
            this.designerObject1 = new combit.ListLabel24.DesignerObject();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(53, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(410, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dieses Beispiel zeigt die Erweiterung des Designers mit C#.";
            this.label3.WrapToLine = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(23, 429);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(144, 24);
            this.checkBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Enable Debug Output";
            this.checkBox1.UseSelectable = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(23, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "US:";
            // 
            // label4
            // 
            this.label4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(53, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(410, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "This sample shows the extension of the designer with C#.";
            this.label4.WrapToLine = true;
            // 
            // label5
            // 
            this.label5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(23, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "D:  ";
            // 
            // listBox1
            // 
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(23, 120);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(440, 303);
            this.listBox1.TabIndex = 9;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1_DrawItem);
            this.listBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListBox1_MeasureItem);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(388, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Design...";
            this.button2.UseSelectable = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // LL
            // 
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.DesignerActions.AddRange(new combit.ListLabel24.DesignerAction[] {
            this.designerAction1});
            this.LL.DesignerFunctions.AddRange(new combit.ListLabel24.DesignerFunction[] {
            this.designerFunction1});
            this.LL.DesignerObjects.AddRange(new combit.ListLabel24.DesignerObject[] {
            this.designerObject1});
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.ListLabel24.LlUnits.Inch_1_100;
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
            this.designerAction1.ExecuteAction += new combit.ListLabel24.DesignerAction.ExecuteActionHandler(this.DesignerAction1_ExecuteAction);
            // 
            // designerFunction1
            // 
            this.designerFunction1.Description = "Add two numeric values";
            this.designerFunction1.FunctionName = "Add";
            this.designerFunction1.GroupName = "Operators";
            this.designerFunction1.MaximumParameters = 2;
            this.designerFunction1.MinimalParameters = 2;
            this.designerFunction1.Parameter1.Description = "First Value";
            this.designerFunction1.Parameter1.Type = combit.ListLabel24.LlParamType.Double;
            this.designerFunction1.Parameter2.Description = "Second Value";
            this.designerFunction1.Parameter2.Type = combit.ListLabel24.LlParamType.Double;
            this.designerFunction1.Parameter3.Description = "Parameter 3";
            this.designerFunction1.Parameter4.Description = "Parameter 4";
            this.designerFunction1.ResultType = combit.ListLabel24.LlParamType.Double;
            this.designerFunction1.EvaluateFunction += new combit.ListLabel24.EvaluateFunctionHandler(this.DesignerFunction1_EvaluateFunction);
            this.designerFunction1.ParameterAutoComplete += new combit.ListLabel24.ParameterAutoCompleteHandler(this.DesignerFunction1_ParameterAutoComplete);
            // 
            // designerObject1
            // 
            this.designerObject1.Description = "Sample Object";
            this.designerObject1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designerObject1.Icon = ((System.Drawing.Icon)(resources.GetObject("designerObject1.Icon")));
            this.designerObject1.ObjectName = "SampleObject";
            this.designerObject1.SupportsContentDialog = true;
            this.designerObject1.TooltipDescription = null;
            this.designerObject1.DrawDesignerObject += new combit.ListLabel24.DrawDesignerObjectHandler(this.DesignerObject1_DrawDesignerObject);
            this.designerObject1.EditDesignerObject += new combit.ListLabel24.EditDesignerObjectHandler(this.DesignerObject1_EditDesignerObject);
            this.designerObject1.CreateDesignerObject += new combit.ListLabel24.CreateDesignerObjectHandler(this.DesignerObject1_CreateDesignerObject);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(486, 470);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "List & Label C# Designer Extension Sample";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ResumeLayout(false);

        }

        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label3;
        private combit.ListLabel24.ListLabel LL;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroCheckBox checkBox1;
        private combit.ListLabel24.DesignerFunction designerFunction1;
        private combit.ListLabel24.DesignerObject designerObject1;
        private combit.ListLabel24.DesignerAction designerAction1;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroButton button2;

        #endregion
    }
}

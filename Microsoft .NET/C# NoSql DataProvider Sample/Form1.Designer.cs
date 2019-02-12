namespace DataProvidersWithoutSolidStructure
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
			this.label3 = new MetroFramework.Controls.MetroLabel();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.label4 = new MetroFramework.Controls.MetroLabel();
			this.label5 = new MetroFramework.Controls.MetroLabel();
			this.LL = new combit.ListLabel24.ListLabel(this.components);
			this.comboBoxTable = new MetroFramework.Controls.MetroComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelTable = new MetroFramework.Controls.MetroLabel();
			this.buttonLogo = new MetroFramework.Controls.MetroButton();
			this.textBoxLogo = new MetroFramework.Controls.MetroTextBox();
			this.labelLogo = new MetroFramework.Controls.MetroLabel();
			this.textBoxTitle = new MetroFramework.Controls.MetroTextBox();
			this.labelTitle = new MetroFramework.Controls.MetroLabel();
			this.buttonToAvailableFields = new MetroFramework.Controls.MetroButton();
			this.buttonToSelectedFields = new MetroFramework.Controls.MetroButton();
			this.listBoxSelectedFields = new System.Windows.Forms.ListBox();
			this.listBoxAvailableFields = new System.Windows.Forms.ListBox();
			this.labelSelectedFields = new MetroFramework.Controls.MetroLabel();
			this.labelAvailableFields = new MetroFramework.Controls.MetroLabel();
			this.buttonDesign = new MetroFramework.Controls.MetroButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.buttonPreview = new MetroFramework.Controls.MetroButton();
			this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
			this.tabPage1 = new MetroFramework.Controls.MetroTabPage();
			this.buttonDataProviderTest = new MetroFramework.Controls.MetroButton();
			this.buttonNextTabpage1 = new MetroFramework.Controls.MetroButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.labelAddress = new MetroFramework.Controls.MetroLabel();
			this.textBoxAddress = new MetroFramework.Controls.MetroTextBox();
			this.labelUsername = new MetroFramework.Controls.MetroLabel();
			this.textBoxUsername = new MetroFramework.Controls.MetroTextBox();
			this.labelPassword = new MetroFramework.Controls.MetroLabel();
			this.textBoxPassword = new MetroFramework.Controls.MetroTextBox();
			this.labelDBName = new MetroFramework.Controls.MetroLabel();
			this.textBoxDBName = new MetroFramework.Controls.MetroTextBox();
			this.labelPort = new MetroFramework.Controls.MetroLabel();
			this.textBoxPort = new MetroFramework.Controls.MetroTextBox();
			this.labelKeyspace = new MetroFramework.Controls.MetroLabel();
			this.textBoxKeyspace = new MetroFramework.Controls.MetroTextBox();
			this.labelObjects = new MetroFramework.Controls.MetroLabel();
			this.textBoxObjects = new MetroFramework.Controls.MetroTextBox();
			this.labelDomain = new MetroFramework.Controls.MetroLabel();
			this.textBoxDomain = new MetroFramework.Controls.MetroTextBox();
			this.labelTableID = new MetroFramework.Controls.MetroLabel();
			this.textBoxTableID = new MetroFramework.Controls.MetroTextBox();
			this.checkBoxFirstRowAreColumnNames = new MetroFramework.Controls.MetroCheckBox();
			this.labelRefreshToken = new MetroFramework.Controls.MetroLabel();
			this.textBoxRefreshToken = new MetroFramework.Controls.MetroTextBox();
			this.textBoxClientID = new MetroFramework.Controls.MetroTextBox();
			this.labelClientSecret = new MetroFramework.Controls.MetroLabel();
			this.textBoxClientSecret = new MetroFramework.Controls.MetroTextBox();
			this.labelClientID = new MetroFramework.Controls.MetroLabel();
			this.labelProvider = new MetroFramework.Controls.MetroLabel();
			this.comboBoxDataProvider = new MetroFramework.Controls.MetroComboBox();
			this.tabPage2 = new MetroFramework.Controls.MetroTabPage();
			this.buttonBackTabpage2 = new MetroFramework.Controls.MetroButton();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.Control;
			this.label3.FontSize = MetroFramework.MetroLabelSize.Small;
			this.label3.Location = new System.Drawing.Point(52, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(422, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Dieses Beispiel zeigt die Verwendung von NoSql Datenprovidern.";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
			this.label1.Location = new System.Drawing.Point(23, 82);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "US:";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.Control;
			this.label4.FontSize = MetroFramework.MetroLabelSize.Small;
			this.label4.Location = new System.Drawing.Point(52, 82);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(422, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "This sample shows the usage of NoSql data providers.";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.Control;
			this.label5.FontSize = MetroFramework.MetroLabelSize.Small;
			this.label5.Location = new System.Drawing.Point(23, 60);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "D:  ";
			// 
			// LL
			// 
			this.LL.AutoDestination = combit.ListLabel24.LlPrintMode.Preview;
			this.LL.AutoPrinterSettingsStream = null;
			this.LL.AutoProjectStream = null;
			this.LL.AutoShowPrintOptions = false;
			this.LL.AutoShowSelectFile = false;
			this.LL.DataBindingMode = combit.ListLabel24.DataBindingMode.DelayLoad;
			this.LL.Debug = combit.ListLabel24.LlDebug.Enabled;
			this.LL.DrilldownAvailable = true;
			this.LL.EMFResolution = 100;
			this.LL.FileRepository = null;
			this.LL.LockNextChar = 8288;
			this.LL.MaxRTFVersion = 65280;
			this.LL.PhantomSpace = 8203;
			this.LL.PreviewControl = null;
			this.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_10;
			this.LL.UseHardwareCopiesForLabels = false;
			this.LL.UseTableSchemaForDesignMode = false;
			// 
			// comboBoxTable
			// 
			this.comboBoxTable.FontSize = MetroFramework.MetroComboBoxSize.Small;
			this.comboBoxTable.ItemHeight = 19;
			this.comboBoxTable.Location = new System.Drawing.Point(6, 43);
			this.comboBoxTable.Name = "comboBoxTable";
			this.comboBoxTable.Size = new System.Drawing.Size(602, 25);
			this.comboBoxTable.Style = MetroFramework.MetroColorStyle.Blue;
			this.comboBoxTable.TabIndex = 11;
			this.comboBoxTable.UseSelectable = true;
			this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTable_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
			this.groupBox1.Controls.Add(this.labelTable);
			this.groupBox1.Controls.Add(this.buttonLogo);
			this.groupBox1.Controls.Add(this.textBoxLogo);
			this.groupBox1.Controls.Add(this.labelLogo);
			this.groupBox1.Controls.Add(this.textBoxTitle);
			this.groupBox1.Controls.Add(this.labelTitle);
			this.groupBox1.Controls.Add(this.buttonToAvailableFields);
			this.groupBox1.Controls.Add(this.buttonToSelectedFields);
			this.groupBox1.Controls.Add(this.listBoxSelectedFields);
			this.groupBox1.Controls.Add(this.listBoxAvailableFields);
			this.groupBox1.Controls.Add(this.labelSelectedFields);
			this.groupBox1.Controls.Add(this.labelAvailableFields);
			this.groupBox1.Controls.Add(this.comboBoxTable);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(3, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(617, 337);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Project Layout";
			// 
			// labelTable
			// 
			this.labelTable.AutoSize = true;
			this.labelTable.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelTable.Location = new System.Drawing.Point(7, 22);
			this.labelTable.Name = "labelTable";
			this.labelTable.Size = new System.Drawing.Size(35, 15);
			this.labelTable.TabIndex = 21;
			this.labelTable.Text = "Table:";
			// 
			// buttonLogo
			// 
			this.buttonLogo.Location = new System.Drawing.Point(581, 305);
			this.buttonLogo.Name = "buttonLogo";
			this.buttonLogo.Size = new System.Drawing.Size(27, 19);
			this.buttonLogo.TabIndex = 18;
			this.buttonLogo.Text = "...";
			this.buttonLogo.UseSelectable = true;
			this.buttonLogo.Click += new System.EventHandler(this.ButtonLogo_Click);
			// 
			// textBoxLogo
			// 
			this.textBoxLogo.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxLogo.Lines = new string[0];
			this.textBoxLogo.Location = new System.Drawing.Point(6, 304);
			this.textBoxLogo.MaxLength = 32767;
			this.textBoxLogo.Name = "textBoxLogo";
			this.textBoxLogo.PasswordChar = '\0';
			this.textBoxLogo.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxLogo.SelectedText = "";
			this.textBoxLogo.Size = new System.Drawing.Size(569, 20);
			this.textBoxLogo.TabIndex = 17;
			this.textBoxLogo.UseCustomBackColor = true;
			this.textBoxLogo.UseSelectable = true;
			// 
			// labelLogo
			// 
			this.labelLogo.AutoSize = true;
			this.labelLogo.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelLogo.Location = new System.Drawing.Point(6, 283);
			this.labelLogo.Name = "labelLogo";
			this.labelLogo.Size = new System.Drawing.Size(36, 15);
			this.labelLogo.TabIndex = 18;
			this.labelLogo.Text = "Logo:";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxTitle.Lines = new string[] {
        "Dynamically created project"};
			this.textBoxTitle.Location = new System.Drawing.Point(6, 256);
			this.textBoxTitle.MaxLength = 32767;
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.PasswordChar = '\0';
			this.textBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTitle.SelectedText = "";
			this.textBoxTitle.Size = new System.Drawing.Size(602, 20);
			this.textBoxTitle.TabIndex = 16;
			this.textBoxTitle.Text = "Dynamically created project";
			this.textBoxTitle.UseCustomBackColor = true;
			this.textBoxTitle.UseSelectable = true;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelTitle.Location = new System.Drawing.Point(7, 235);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(30, 15);
			this.labelTitle.TabIndex = 16;
			this.labelTitle.Text = "Title:";
			// 
			// buttonToAvailableFields
			// 
			this.buttonToAvailableFields.Location = new System.Drawing.Point(290, 163);
			this.buttonToAvailableFields.Name = "buttonToAvailableFields";
			this.buttonToAvailableFields.Size = new System.Drawing.Size(35, 30);
			this.buttonToAvailableFields.TabIndex = 15;
			this.buttonToAvailableFields.Text = "<";
			this.buttonToAvailableFields.UseSelectable = true;
			this.buttonToAvailableFields.Click += new System.EventHandler(this.SelectField_Click);
			// 
			// buttonToSelectedFields
			// 
			this.buttonToSelectedFields.Location = new System.Drawing.Point(290, 127);
			this.buttonToSelectedFields.Name = "buttonToSelectedFields";
			this.buttonToSelectedFields.Size = new System.Drawing.Size(35, 30);
			this.buttonToSelectedFields.TabIndex = 13;
			this.buttonToSelectedFields.Text = ">";
			this.buttonToSelectedFields.UseSelectable = true;
			this.buttonToSelectedFields.Click += new System.EventHandler(this.SelectField_Click);
			// 
			// listBoxSelectedFields
			// 
			this.listBoxSelectedFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBoxSelectedFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBoxSelectedFields.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxSelectedFields.Location = new System.Drawing.Point(331, 96);
			this.listBoxSelectedFields.Name = "listBoxSelectedFields";
			this.listBoxSelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBoxSelectedFields.Size = new System.Drawing.Size(277, 132);
			this.listBoxSelectedFields.Sorted = true;
			this.listBoxSelectedFields.TabIndex = 14;
			this.listBoxSelectedFields.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxSelectedFields_DrawItem);
			this.listBoxSelectedFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxSelectedFields_MouseDoubleClick);
			// 
			// listBoxAvailableFields
			// 
			this.listBoxAvailableFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBoxAvailableFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBoxAvailableFields.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxAvailableFields.Location = new System.Drawing.Point(6, 96);
			this.listBoxAvailableFields.Name = "listBoxAvailableFields";
			this.listBoxAvailableFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listBoxAvailableFields.Size = new System.Drawing.Size(278, 132);
			this.listBoxAvailableFields.Sorted = true;
			this.listBoxAvailableFields.TabIndex = 12;
			this.listBoxAvailableFields.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxAvailableFields_DrawItem);
			this.listBoxAvailableFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxAvailableFields_MouseDoubleClick);
			// 
			// labelSelectedFields
			// 
			this.labelSelectedFields.AutoSize = true;
			this.labelSelectedFields.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelSelectedFields.Location = new System.Drawing.Point(331, 75);
			this.labelSelectedFields.Name = "labelSelectedFields";
			this.labelSelectedFields.Size = new System.Drawing.Size(83, 15);
			this.labelSelectedFields.TabIndex = 11;
			this.labelSelectedFields.Text = "Selected Fields:";
			// 
			// labelAvailableFields
			// 
			this.labelAvailableFields.AutoSize = true;
			this.labelAvailableFields.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelAvailableFields.Location = new System.Drawing.Point(7, 75);
			this.labelAvailableFields.Name = "labelAvailableFields";
			this.labelAvailableFields.Size = new System.Drawing.Size(85, 15);
			this.labelAvailableFields.TabIndex = 10;
			this.labelAvailableFields.Text = "Available Fields:";
			// 
			// buttonDesign
			// 
			this.buttonDesign.Location = new System.Drawing.Point(402, 353);
			this.buttonDesign.Name = "buttonDesign";
			this.buttonDesign.Size = new System.Drawing.Size(106, 26);
			this.buttonDesign.TabIndex = 19;
			this.buttonDesign.Text = "Design...";
			this.buttonDesign.UseSelectable = true;
			this.buttonDesign.Click += new System.EventHandler(this.DesignProject_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "sunshine.gif";
			this.openFileDialog1.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|A" +
    "ll Files (*.*)|*.*";
			// 
			// buttonPreview
			// 
			this.buttonPreview.Location = new System.Drawing.Point(514, 353);
			this.buttonPreview.Name = "buttonPreview";
			this.buttonPreview.Size = new System.Drawing.Size(106, 26);
			this.buttonPreview.TabIndex = 20;
			this.buttonPreview.Text = "Preview...";
			this.buttonPreview.UseSelectable = true;
			this.buttonPreview.Click += new System.EventHandler(this.PrintProject_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(23, 105);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(631, 427);
			this.tabControl1.Style = MetroFramework.MetroColorStyle.Blue;
			this.tabControl1.TabIndex = 15;
			this.tabControl1.UseSelectable = true;
			this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.buttonDataProviderTest);
			this.tabPage1.Controls.Add(this.buttonNextTabpage1);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.labelProvider);
			this.tabPage1.Controls.Add(this.comboBoxDataProvider);
			this.tabPage1.HorizontalScrollbarBarColor = true;
			this.tabPage1.HorizontalScrollbarHighlightOnWheel = false;
			this.tabPage1.HorizontalScrollbarSize = 10;
			this.tabPage1.Location = new System.Drawing.Point(4, 41);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(623, 382);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "1. Data provider settings";
			this.tabPage1.VerticalScrollbarBarColor = true;
			this.tabPage1.VerticalScrollbarHighlightOnWheel = false;
			this.tabPage1.VerticalScrollbarSize = 10;
			// 
			// buttonDataProviderTest
			// 
			this.buttonDataProviderTest.Location = new System.Drawing.Point(402, 353);
			this.buttonDataProviderTest.Name = "buttonDataProviderTest";
			this.buttonDataProviderTest.Size = new System.Drawing.Size(106, 26);
			this.buttonDataProviderTest.TabIndex = 9;
			this.buttonDataProviderTest.Text = "Test";
			this.buttonDataProviderTest.UseSelectable = true;
			this.buttonDataProviderTest.Click += new System.EventHandler(this.ButtonDataProviderTest_Click);
			// 
			// buttonNextTabpage1
			// 
			this.buttonNextTabpage1.Enabled = false;
			this.buttonNextTabpage1.Location = new System.Drawing.Point(514, 353);
			this.buttonNextTabpage1.Name = "buttonNextTabpage1";
			this.buttonNextTabpage1.Size = new System.Drawing.Size(106, 26);
			this.buttonNextTabpage1.TabIndex = 10;
			this.buttonNextTabpage1.Text = "Next >";
			this.buttonNextTabpage1.UseSelectable = true;
			this.buttonNextTabpage1.Click += new System.EventHandler(this.ButtonNavigate);
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.Window;
			this.groupBox2.Controls.Add(this.flowLayoutPanel1);
			this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(3, 49);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(617, 298);
			this.groupBox2.TabIndex = 27;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Provider Parameter";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.labelAddress);
			this.flowLayoutPanel1.Controls.Add(this.textBoxAddress);
			this.flowLayoutPanel1.Controls.Add(this.labelUsername);
			this.flowLayoutPanel1.Controls.Add(this.textBoxUsername);
			this.flowLayoutPanel1.Controls.Add(this.labelPassword);
			this.flowLayoutPanel1.Controls.Add(this.textBoxPassword);
			this.flowLayoutPanel1.Controls.Add(this.labelDBName);
			this.flowLayoutPanel1.Controls.Add(this.textBoxDBName);
			this.flowLayoutPanel1.Controls.Add(this.labelPort);
			this.flowLayoutPanel1.Controls.Add(this.textBoxPort);
			this.flowLayoutPanel1.Controls.Add(this.labelKeyspace);
			this.flowLayoutPanel1.Controls.Add(this.textBoxKeyspace);
			this.flowLayoutPanel1.Controls.Add(this.labelObjects);
			this.flowLayoutPanel1.Controls.Add(this.textBoxObjects);
			this.flowLayoutPanel1.Controls.Add(this.labelDomain);
			this.flowLayoutPanel1.Controls.Add(this.textBoxDomain);
			this.flowLayoutPanel1.Controls.Add(this.labelTableID);
			this.flowLayoutPanel1.Controls.Add(this.textBoxTableID);
			this.flowLayoutPanel1.Controls.Add(this.checkBoxFirstRowAreColumnNames);
			this.flowLayoutPanel1.Controls.Add(this.labelRefreshToken);
			this.flowLayoutPanel1.Controls.Add(this.textBoxRefreshToken);
			this.flowLayoutPanel1.Controls.Add(this.textBoxClientID);
			this.flowLayoutPanel1.Controls.Add(this.labelClientSecret);
			this.flowLayoutPanel1.Controls.Add(this.textBoxClientSecret);
			this.flowLayoutPanel1.Controls.Add(this.labelClientID);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(605, 273);
			this.flowLayoutPanel1.TabIndex = 23;
			// 
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelAddress.Location = new System.Drawing.Point(3, 5);
			this.labelAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(52, 15);
			this.labelAddress.TabIndex = 22;
			this.labelAddress.Text = "Address:";
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxAddress.Lines = new string[0];
			this.textBoxAddress.Location = new System.Drawing.Point(3, 28);
			this.textBoxAddress.MaxLength = 32767;
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.PasswordChar = '\0';
			this.textBoxAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxAddress.SelectedText = "";
			this.textBoxAddress.Size = new System.Drawing.Size(599, 20);
			this.textBoxAddress.TabIndex = 2;
			this.textBoxAddress.UseCustomBackColor = true;
			this.textBoxAddress.UseSelectable = true;
			this.textBoxAddress.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelUsername
			// 
			this.labelUsername.AutoSize = true;
			this.labelUsername.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelUsername.Location = new System.Drawing.Point(3, 56);
			this.labelUsername.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(61, 15);
			this.labelUsername.TabIndex = 24;
			this.labelUsername.Text = "Username:";
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxUsername.Lines = new string[0];
			this.textBoxUsername.Location = new System.Drawing.Point(3, 79);
			this.textBoxUsername.MaxLength = 32767;
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.PasswordChar = '\0';
			this.textBoxUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxUsername.SelectedText = "";
			this.textBoxUsername.Size = new System.Drawing.Size(599, 20);
			this.textBoxUsername.TabIndex = 3;
			this.textBoxUsername.UseCustomBackColor = true;
			this.textBoxUsername.UseSelectable = true;
			this.textBoxUsername.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelPassword.Location = new System.Drawing.Point(3, 107);
			this.labelPassword.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(58, 15);
			this.labelPassword.TabIndex = 26;
			this.labelPassword.Text = "Password:";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxPassword.Lines = new string[0];
			this.textBoxPassword.Location = new System.Drawing.Point(3, 130);
			this.textBoxPassword.MaxLength = 32767;
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPassword.SelectedText = "";
			this.textBoxPassword.Size = new System.Drawing.Size(599, 20);
			this.textBoxPassword.TabIndex = 4;
			this.textBoxPassword.UseCustomBackColor = true;
			this.textBoxPassword.UseSelectable = true;
			this.textBoxPassword.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelDBName
			// 
			this.labelDBName.AutoSize = true;
			this.labelDBName.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelDBName.Location = new System.Drawing.Point(3, 158);
			this.labelDBName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelDBName.Name = "labelDBName";
			this.labelDBName.Size = new System.Drawing.Size(89, 15);
			this.labelDBName.TabIndex = 31;
			this.labelDBName.Text = "Database name:";
			// 
			// textBoxDBName
			// 
			this.textBoxDBName.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxDBName.Lines = new string[0];
			this.textBoxDBName.Location = new System.Drawing.Point(3, 181);
			this.textBoxDBName.MaxLength = 32767;
			this.textBoxDBName.Name = "textBoxDBName";
			this.textBoxDBName.PasswordChar = '\0';
			this.textBoxDBName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDBName.SelectedText = "";
			this.textBoxDBName.Size = new System.Drawing.Size(599, 20);
			this.textBoxDBName.TabIndex = 5;
			this.textBoxDBName.UseCustomBackColor = true;
			this.textBoxDBName.UseSelectable = true;
			this.textBoxDBName.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelPort
			// 
			this.labelPort.AutoSize = true;
			this.labelPort.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelPort.Location = new System.Drawing.Point(3, 209);
			this.labelPort.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new System.Drawing.Size(32, 15);
			this.labelPort.TabIndex = 33;
			this.labelPort.Text = "Port:";
			// 
			// textBoxPort
			// 
			this.textBoxPort.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxPort.Lines = new string[0];
			this.textBoxPort.Location = new System.Drawing.Point(3, 232);
			this.textBoxPort.MaxLength = 32767;
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.PasswordChar = '\0';
			this.textBoxPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPort.SelectedText = "";
			this.textBoxPort.Size = new System.Drawing.Size(599, 20);
			this.textBoxPort.TabIndex = 6;
			this.textBoxPort.UseCustomBackColor = true;
			this.textBoxPort.UseSelectable = true;
			this.textBoxPort.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelKeyspace
			// 
			this.labelKeyspace.AutoSize = true;
			this.labelKeyspace.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelKeyspace.Location = new System.Drawing.Point(608, 5);
			this.labelKeyspace.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelKeyspace.Name = "labelKeyspace";
			this.labelKeyspace.Size = new System.Drawing.Size(56, 15);
			this.labelKeyspace.TabIndex = 36;
			this.labelKeyspace.Text = "Keyspace:";
			// 
			// textBoxKeyspace
			// 
			this.textBoxKeyspace.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxKeyspace.Lines = new string[0];
			this.textBoxKeyspace.Location = new System.Drawing.Point(608, 28);
			this.textBoxKeyspace.MaxLength = 32767;
			this.textBoxKeyspace.Name = "textBoxKeyspace";
			this.textBoxKeyspace.PasswordChar = '\0';
			this.textBoxKeyspace.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxKeyspace.SelectedText = "";
			this.textBoxKeyspace.Size = new System.Drawing.Size(599, 20);
			this.textBoxKeyspace.TabIndex = 7;
			this.textBoxKeyspace.UseCustomBackColor = true;
			this.textBoxKeyspace.UseSelectable = true;
			this.textBoxKeyspace.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelObjects
			// 
			this.labelObjects.AutoSize = true;
			this.labelObjects.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelObjects.Location = new System.Drawing.Point(608, 56);
			this.labelObjects.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelObjects.Name = "labelObjects";
			this.labelObjects.Size = new System.Drawing.Size(143, 15);
			this.labelObjects.TabIndex = 35;
			this.labelObjects.Text = "Tables (comma-separated) optional:";
			// 
			// textBoxObjects
			// 
			this.textBoxObjects.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxObjects.Lines = new string[0];
			this.textBoxObjects.Location = new System.Drawing.Point(608, 79);
			this.textBoxObjects.MaxLength = 32767;
			this.textBoxObjects.Name = "textBoxObjects";
			this.textBoxObjects.PasswordChar = '\0';
			this.textBoxObjects.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxObjects.SelectedText = "";
			this.textBoxObjects.Size = new System.Drawing.Size(599, 20);
			this.textBoxObjects.TabIndex = 8;
			this.textBoxObjects.UseCustomBackColor = true;
			this.textBoxObjects.UseSelectable = true;
			this.textBoxObjects.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelDomain
			// 
			this.labelDomain.AutoSize = true;
			this.labelDomain.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelDomain.Location = new System.Drawing.Point(608, 107);
			this.labelDomain.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelDomain.Name = "labelDomain";
			this.labelDomain.Size = new System.Drawing.Size(49, 15);
			this.labelDomain.TabIndex = 24;
			this.labelDomain.Text = "Domain:";
			// 
			// textBoxDomain
			// 
			this.textBoxDomain.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxDomain.Lines = new string[0];
			this.textBoxDomain.Location = new System.Drawing.Point(608, 130);
			this.textBoxDomain.MaxLength = 32767;
			this.textBoxDomain.Name = "textBoxDomain";
			this.textBoxDomain.PasswordChar = '\0';
			this.textBoxDomain.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDomain.SelectedText = "";
			this.textBoxDomain.Size = new System.Drawing.Size(599, 20);
			this.textBoxDomain.TabIndex = 23;
			this.textBoxDomain.UseCustomBackColor = true;
			this.textBoxDomain.UseSelectable = true;
			this.textBoxDomain.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelTableID
			// 
			this.labelTableID.AutoSize = true;
			this.labelTableID.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelTableID.Location = new System.Drawing.Point(608, 158);
			this.labelTableID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelTableID.Name = "labelTableID";
			this.labelTableID.Size = new System.Drawing.Size(49, 15);
			this.labelTableID.TabIndex = 24;
			this.labelTableID.Text = "Table ID:";
			// 
			// textBoxTableID
			// 
			this.textBoxTableID.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxTableID.Lines = new string[0];
			this.textBoxTableID.Location = new System.Drawing.Point(608, 181);
			this.textBoxTableID.MaxLength = 32767;
			this.textBoxTableID.Name = "textBoxTableID";
			this.textBoxTableID.PasswordChar = '\0';
			this.textBoxTableID.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTableID.SelectedText = "";
			this.textBoxTableID.Size = new System.Drawing.Size(599, 20);
			this.textBoxTableID.TabIndex = 23;
			this.textBoxTableID.UseCustomBackColor = true;
			this.textBoxTableID.UseSelectable = true;
			this.textBoxTableID.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// checkBoxFirstRowAreColumnNames
			// 
			this.checkBoxFirstRowAreColumnNames.AutoSize = true;
			this.checkBoxFirstRowAreColumnNames.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
			this.checkBoxFirstRowAreColumnNames.Location = new System.Drawing.Point(608, 214);
			this.checkBoxFirstRowAreColumnNames.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.checkBoxFirstRowAreColumnNames.Name = "checkBoxFirstRowAreColumnNames";
			this.checkBoxFirstRowAreColumnNames.Size = new System.Drawing.Size(203, 15);
			this.checkBoxFirstRowAreColumnNames.Style = MetroFramework.MetroColorStyle.Blue;
			this.checkBoxFirstRowAreColumnNames.TabIndex = 24;
			this.checkBoxFirstRowAreColumnNames.Text = "The first row contains column names";
			this.checkBoxFirstRowAreColumnNames.UseSelectable = true;
			this.checkBoxFirstRowAreColumnNames.CheckedChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelRefreshToken
			// 
			this.labelRefreshToken.AutoSize = true;
			this.labelRefreshToken.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelRefreshToken.Location = new System.Drawing.Point(608, 244);
			this.labelRefreshToken.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelRefreshToken.Name = "labelRefreshToken";
			this.labelRefreshToken.Size = new System.Drawing.Size(78, 15);
			this.labelRefreshToken.TabIndex = 24;
			this.labelRefreshToken.Text = "Refresh token:";
			// 
			// textBoxRefreshToken
			// 
			this.textBoxRefreshToken.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxRefreshToken.Lines = new string[0];
			this.textBoxRefreshToken.Location = new System.Drawing.Point(1213, 3);
			this.textBoxRefreshToken.MaxLength = 32767;
			this.textBoxRefreshToken.Name = "textBoxRefreshToken";
			this.textBoxRefreshToken.PasswordChar = '\0';
			this.textBoxRefreshToken.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRefreshToken.SelectedText = "";
			this.textBoxRefreshToken.Size = new System.Drawing.Size(599, 20);
			this.textBoxRefreshToken.TabIndex = 23;
			this.textBoxRefreshToken.UseCustomBackColor = true;
			this.textBoxRefreshToken.UseSelectable = true;
			this.textBoxRefreshToken.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// textBoxClientID
			// 
			this.textBoxClientID.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxClientID.Lines = new string[0];
			this.textBoxClientID.Location = new System.Drawing.Point(1213, 29);
			this.textBoxClientID.MaxLength = 32767;
			this.textBoxClientID.Name = "textBoxClientID";
			this.textBoxClientID.PasswordChar = '\0';
			this.textBoxClientID.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxClientID.SelectedText = "";
			this.textBoxClientID.Size = new System.Drawing.Size(599, 20);
			this.textBoxClientID.TabIndex = 25;
			this.textBoxClientID.UseCustomBackColor = true;
			this.textBoxClientID.UseSelectable = true;
			this.textBoxClientID.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelClientSecret
			// 
			this.labelClientSecret.AutoSize = true;
			this.labelClientSecret.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelClientSecret.Location = new System.Drawing.Point(1213, 57);
			this.labelClientSecret.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelClientSecret.Name = "labelClientSecret";
			this.labelClientSecret.Size = new System.Drawing.Size(70, 15);
			this.labelClientSecret.TabIndex = 26;
			this.labelClientSecret.Text = "Client secret:";
			// 
			// textBoxClientSecret
			// 
			this.textBoxClientSecret.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxClientSecret.Lines = new string[0];
			this.textBoxClientSecret.Location = new System.Drawing.Point(1213, 80);
			this.textBoxClientSecret.MaxLength = 32767;
			this.textBoxClientSecret.Name = "textBoxClientSecret";
			this.textBoxClientSecret.PasswordChar = '\0';
			this.textBoxClientSecret.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxClientSecret.SelectedText = "";
			this.textBoxClientSecret.Size = new System.Drawing.Size(599, 20);
			this.textBoxClientSecret.TabIndex = 25;
			this.textBoxClientSecret.UseCustomBackColor = true;
			this.textBoxClientSecret.UseSelectable = true;
			this.textBoxClientSecret.TextChanged += new System.EventHandler(this.ControlInputChanged);
			// 
			// labelClientID
			// 
			this.labelClientID.AutoSize = true;
			this.labelClientID.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelClientID.Location = new System.Drawing.Point(1213, 108);
			this.labelClientID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.labelClientID.Name = "labelClientID";
			this.labelClientID.Size = new System.Drawing.Size(51, 15);
			this.labelClientID.TabIndex = 26;
			this.labelClientID.Text = "Client ID:";
			// 
			// labelProvider
			// 
			this.labelProvider.AutoSize = true;
			this.labelProvider.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelProvider.Location = new System.Drawing.Point(3, 0);
			this.labelProvider.Name = "labelProvider";
			this.labelProvider.Size = new System.Drawing.Size(53, 15);
			this.labelProvider.TabIndex = 26;
			this.labelProvider.Text = "Provider:";
			// 
			// comboBoxDataProvider
			// 
			this.comboBoxDataProvider.FontSize = MetroFramework.MetroComboBoxSize.Small;
			this.comboBoxDataProvider.ItemHeight = 19;
			this.comboBoxDataProvider.Location = new System.Drawing.Point(3, 18);
			this.comboBoxDataProvider.Name = "comboBoxDataProvider";
			this.comboBoxDataProvider.Size = new System.Drawing.Size(617, 25);
			this.comboBoxDataProvider.Style = MetroFramework.MetroColorStyle.Blue;
			this.comboBoxDataProvider.TabIndex = 1;
			this.comboBoxDataProvider.UseSelectable = true;
			this.comboBoxDataProvider.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProvider_SelectedIndexChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.buttonBackTabpage2);
			this.tabPage2.Controls.Add(this.buttonDesign);
			this.tabPage2.Controls.Add(this.buttonPreview);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.HorizontalScrollbarBarColor = true;
			this.tabPage2.HorizontalScrollbarHighlightOnWheel = false;
			this.tabPage2.HorizontalScrollbarSize = 10;
			this.tabPage2.Location = new System.Drawing.Point(4, 41);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(623, 382);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "2. Project settings";
			this.tabPage2.VerticalScrollbarBarColor = true;
			this.tabPage2.VerticalScrollbarHighlightOnWheel = false;
			this.tabPage2.VerticalScrollbarSize = 10;
			// 
			// buttonBackTabpage2
			// 
			this.buttonBackTabpage2.Location = new System.Drawing.Point(3, 353);
			this.buttonBackTabpage2.Name = "buttonBackTabpage2";
			this.buttonBackTabpage2.Size = new System.Drawing.Size(106, 26);
			this.buttonBackTabpage2.TabIndex = 21;
			this.buttonBackTabpage2.Text = "< Back";
			this.buttonBackTabpage2.UseSelectable = true;
			this.buttonBackTabpage2.Click += new System.EventHandler(this.ButtonNavigate);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(677, 542);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Resizable = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "List & Label C# NoSql DataProvider Sample";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroLabel label1;
        private combit.ListLabel24.ListLabel LL;
        private MetroFramework.Controls.MetroComboBox comboBoxTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel labelSelectedFields;
        private MetroFramework.Controls.MetroLabel labelAvailableFields;
        private System.Windows.Forms.ListBox listBoxAvailableFields;
        private MetroFramework.Controls.MetroButton buttonToAvailableFields;
        private MetroFramework.Controls.MetroButton buttonToSelectedFields;
        private System.Windows.Forms.ListBox listBoxSelectedFields;
        private MetroFramework.Controls.MetroLabel labelLogo;
        private MetroFramework.Controls.MetroTextBox textBoxTitle;
        private MetroFramework.Controls.MetroLabel labelTitle;
        private MetroFramework.Controls.MetroButton buttonLogo;
        private MetroFramework.Controls.MetroTextBox textBoxLogo;
        private MetroFramework.Controls.MetroLabel labelTable;
        private MetroFramework.Controls.MetroButton buttonDesign;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

		#endregion
		private MetroFramework.Controls.MetroButton buttonPreview;
		private MetroFramework.Controls.MetroTabControl tabControl1;
		private MetroFramework.Controls.MetroTabPage tabPage1;
		private MetroFramework.Controls.MetroTabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private MetroFramework.Controls.MetroLabel labelAddress;
		private MetroFramework.Controls.MetroTextBox textBoxAddress;
		private MetroFramework.Controls.MetroLabel labelUsername;
		private MetroFramework.Controls.MetroTextBox textBoxUsername;
		private MetroFramework.Controls.MetroLabel labelPassword;
		private MetroFramework.Controls.MetroTextBox textBoxPassword;
		private MetroFramework.Controls.MetroLabel labelDBName;
		private MetroFramework.Controls.MetroTextBox textBoxDBName;
		private MetroFramework.Controls.MetroLabel labelPort;
		private MetroFramework.Controls.MetroTextBox textBoxPort;
		private MetroFramework.Controls.MetroLabel labelKeyspace;
		private MetroFramework.Controls.MetroTextBox textBoxKeyspace;
		private MetroFramework.Controls.MetroLabel labelObjects;
		private MetroFramework.Controls.MetroTextBox textBoxObjects;
		private MetroFramework.Controls.MetroLabel labelProvider;
		private MetroFramework.Controls.MetroComboBox comboBoxDataProvider;
		private MetroFramework.Controls.MetroButton buttonNextTabpage1;
		private MetroFramework.Controls.MetroButton buttonDataProviderTest;
		private MetroFramework.Controls.MetroButton buttonBackTabpage2;
		private MetroFramework.Controls.MetroLabel labelDomain;
		private MetroFramework.Controls.MetroTextBox textBoxDomain;
		private MetroFramework.Controls.MetroLabel labelTableID;
		private MetroFramework.Controls.MetroTextBox textBoxTableID;
		private MetroFramework.Controls.MetroCheckBox checkBoxFirstRowAreColumnNames;
		private MetroFramework.Controls.MetroLabel labelRefreshToken;
		private MetroFramework.Controls.MetroTextBox textBoxRefreshToken;
		private MetroFramework.Controls.MetroLabel labelClientID;
		private MetroFramework.Controls.MetroTextBox textBoxClientID;
		private MetroFramework.Controls.MetroLabel labelClientSecret;
		private MetroFramework.Controls.MetroTextBox textBoxClientSecret;
	}
}

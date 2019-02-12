Partial Class Form1


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer = Nothing

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LL = New combit.ListLabel24.ListLabel(Me.components)
        Me.tabControl1 = New MetroFramework.Controls.MetroTabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelAddress = New MetroFramework.Controls.MetroLabel()
        Me.TextBoxAddress = New MetroFramework.Controls.MetroTextBox()
        Me.LabelUserName = New MetroFramework.Controls.MetroLabel()
        Me.TextBoxUsername = New MetroFramework.Controls.MetroTextBox()
        Me.LabelPassword = New MetroFramework.Controls.MetroLabel()
        Me.TextBoxPassword = New MetroFramework.Controls.MetroTextBox()
        Me.LabelDBName = New MetroFramework.Controls.MetroLabel()
        Me.TextBoxDBName = New MetroFramework.Controls.MetroTextBox()
        Me.LabelPort = New MetroFramework.Controls.MetroLabel()
        Me.TextBoxPort = New MetroFramework.Controls.MetroTextBox()
        Me.TextBoxKeySpace = New MetroFramework.Controls.MetroTextBox()
        Me.TextBoxObjects = New MetroFramework.Controls.MetroTextBox()
        Me.TextBoxDomain = New MetroFramework.Controls.MetroTextBox()
        Me.TextBoxTableID = New MetroFramework.Controls.MetroTextBox()
        Me.CheckBoxFirstRowAreColumnNames = New MetroFramework.Controls.MetroCheckBox()
        Me.TextBoxRefreshToken = New MetroFramework.Controls.MetroTextBox()
        Me.TextBoxClientID = New MetroFramework.Controls.MetroTextBox()
        Me.TextBoxClientSecret = New MetroFramework.Controls.MetroTextBox()
        Me.LabelKeyspace = New MetroFramework.Controls.MetroLabel()
        Me.LabelObjects = New MetroFramework.Controls.MetroLabel()
        Me.LabelDomain = New MetroFramework.Controls.MetroLabel()
        Me.LabelTableID = New MetroFramework.Controls.MetroLabel()
        Me.LabelRefreshToken = New MetroFramework.Controls.MetroLabel()
        Me.LabelClientID = New MetroFramework.Controls.MetroLabel()
        Me.LabelClientSecret = New MetroFramework.Controls.MetroLabel()
        Me.LabelProvider = New MetroFramework.Controls.MetroLabel()
        Me.ComboBoxDataProvider = New MetroFramework.Controls.MetroComboBox()
        Me.ButtonNextTabpage1 = New MetroFramework.Controls.MetroButton()
        Me.buttonDataProviderTest = New MetroFramework.Controls.MetroButton()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.ButtonPreview = New MetroFramework.Controls.MetroButton()
        Me.ButtonDesign = New MetroFramework.Controls.MetroButton()
        Me.ButtonBackTabpage2 = New MetroFramework.Controls.MetroButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonLogo = New MetroFramework.Controls.MetroButton()
        Me.TextBoxLogo = New MetroFramework.Controls.MetroTextBox()
        Me.LabelLogo = New MetroFramework.Controls.MetroLabel()
        Me.TextBoxTitle = New MetroFramework.Controls.MetroTextBox()
        Me.LabelTitle = New MetroFramework.Controls.MetroLabel()
        Me.buttonToAvailableFields = New MetroFramework.Controls.MetroButton()
        Me.buttonToSelectedFields = New MetroFramework.Controls.MetroButton()
        Me.ListBoxSelectedFields = New System.Windows.Forms.ListBox()
        Me.ListBoxAvailableFields = New System.Windows.Forms.ListBox()
        Me.LabelSelectedFields = New MetroFramework.Controls.MetroLabel()
        Me.LabelAvailableFields = New MetroFramework.Controls.MetroLabel()
        Me.ComboBoxTable = New MetroFramework.Controls.MetroComboBox()
        Me.LabelTable = New MetroFramework.Controls.MetroLabel()
        Me.Label1 = New MetroFramework.Controls.MetroLabel()
        Me.Label4 = New MetroFramework.Controls.MetroLabel()
        Me.Label5 = New MetroFramework.Controls.MetroLabel()
        Me.Label3 = New MetroFramework.Controls.MetroLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LL
        '
        Me.LL.AutoDestination = combit.ListLabel24.LlPrintMode.Preview
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.AutoShowPrintOptions = False
        Me.LL.AutoShowSelectFile = False
        Me.LL.DataBindingMode = combit.ListLabel24.DataBindingMode.DelayLoad
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.FileRepository = Nothing
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_100
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'tabControl1
        '
        Me.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Location = New System.Drawing.Point(23, 105)
        Me.tabControl1.Multiline = True
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(631, 427)
        Me.tabControl1.Style = MetroFramework.MetroColorStyle.Blue
        Me.tabControl1.TabIndex = 15
        Me.tabControl1.UseSelectable = True
        '
        'tabPage1
        '
        Me.tabPage1.BackColor = System.Drawing.Color.Transparent
        Me.tabPage1.Controls.Add(Me.GroupBox2)
        Me.tabPage1.Controls.Add(Me.LabelProvider)
        Me.tabPage1.Controls.Add(Me.ComboBoxDataProvider)
        Me.tabPage1.Controls.Add(Me.ButtonNextTabpage1)
        Me.tabPage1.Controls.Add(Me.buttonDataProviderTest)
        Me.tabPage1.Location = New System.Drawing.Point(4, 41)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Size = New System.Drawing.Size(623, 382)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "1. Data provider settings"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(617, 298)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Provider Parameter"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelAddress)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxAddress)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelUserName)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxUsername)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelPassword)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxPassword)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelDBName)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxDBName)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelPort)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxPort)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxKeySpace)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxObjects)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxDomain)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxTableID)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBoxFirstRowAreColumnNames)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxRefreshToken)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxClientID)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxClientSecret)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelKeyspace)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelObjects)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelDomain)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelTableID)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelRefreshToken)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelClientID)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelClientSecret)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 19)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(605, 273)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'LabelAddress
        '
        Me.LabelAddress.AutoSize = True
        Me.LabelAddress.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelAddress.Location = New System.Drawing.Point(3, 5)
        Me.LabelAddress.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelAddress.Name = "LabelAddress"
        Me.LabelAddress.Size = New System.Drawing.Size(52, 15)
        Me.LabelAddress.TabIndex = 0
        Me.LabelAddress.Text = "Address:"
        '
        'TextBoxAddress
        '
        Me.TextBoxAddress.Lines = New String(-1) {}
        Me.TextBoxAddress.Location = New System.Drawing.Point(3, 28)
        Me.TextBoxAddress.MaxLength = 32767
        Me.TextBoxAddress.Name = "TextBoxAddress"
        Me.TextBoxAddress.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxAddress.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxAddress.SelectedText = ""
        Me.TextBoxAddress.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxAddress.TabIndex = 1
        Me.TextBoxAddress.UseCustomBackColor = True
        Me.TextBoxAddress.UseSelectable = True
        '
        'LabelUserName
        '
        Me.LabelUserName.AutoSize = True
        Me.LabelUserName.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelUserName.Location = New System.Drawing.Point(3, 56)
        Me.LabelUserName.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(61, 15)
        Me.LabelUserName.TabIndex = 2
        Me.LabelUserName.Text = "Username:"
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.Lines = New String(-1) {}
        Me.TextBoxUsername.Location = New System.Drawing.Point(3, 79)
        Me.TextBoxUsername.MaxLength = 32767
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxUsername.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxUsername.SelectedText = ""
        Me.TextBoxUsername.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxUsername.TabIndex = 3
        Me.TextBoxUsername.UseCustomBackColor = True
        Me.TextBoxUsername.UseSelectable = True
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelPassword.Location = New System.Drawing.Point(3, 107)
        Me.LabelPassword.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(58, 15)
        Me.LabelPassword.TabIndex = 4
        Me.LabelPassword.Text = "Password:"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Lines = New String(-1) {}
        Me.TextBoxPassword.Location = New System.Drawing.Point(3, 130)
        Me.TextBoxPassword.MaxLength = 32767
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxPassword.SelectedText = ""
        Me.TextBoxPassword.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxPassword.TabIndex = 5
        Me.TextBoxPassword.UseCustomBackColor = True
        Me.TextBoxPassword.UseSelectable = True
        '
        'LabelDBName
        '
        Me.LabelDBName.AutoSize = True
        Me.LabelDBName.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelDBName.Location = New System.Drawing.Point(3, 158)
        Me.LabelDBName.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelDBName.Name = "LabelDBName"
        Me.LabelDBName.Size = New System.Drawing.Size(89, 15)
        Me.LabelDBName.TabIndex = 6
        Me.LabelDBName.Text = "Database name:"
        '
        'TextBoxDBName
        '
        Me.TextBoxDBName.Lines = New String(-1) {}
        Me.TextBoxDBName.Location = New System.Drawing.Point(3, 181)
        Me.TextBoxDBName.MaxLength = 32767
        Me.TextBoxDBName.Name = "TextBoxDBName"
        Me.TextBoxDBName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxDBName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxDBName.SelectedText = ""
        Me.TextBoxDBName.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxDBName.TabIndex = 7
        Me.TextBoxDBName.UseCustomBackColor = True
        Me.TextBoxDBName.UseSelectable = True
        '
        'LabelPort
        '
        Me.LabelPort.AutoSize = True
        Me.LabelPort.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelPort.Location = New System.Drawing.Point(3, 209)
        Me.LabelPort.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelPort.Name = "LabelPort"
        Me.LabelPort.Size = New System.Drawing.Size(32, 15)
        Me.LabelPort.TabIndex = 8
        Me.LabelPort.Text = "Port:"
        '
        'TextBoxPort
        '
        Me.TextBoxPort.Lines = New String(-1) {}
        Me.TextBoxPort.Location = New System.Drawing.Point(3, 232)
        Me.TextBoxPort.MaxLength = 32767
        Me.TextBoxPort.Name = "TextBoxPort"
        Me.TextBoxPort.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxPort.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxPort.SelectedText = ""
        Me.TextBoxPort.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxPort.TabIndex = 9
        Me.TextBoxPort.UseCustomBackColor = True
        Me.TextBoxPort.UseSelectable = True
        '
        'TextBoxKeySpace
        '
        Me.TextBoxKeySpace.Lines = New String(-1) {}
        Me.TextBoxKeySpace.Location = New System.Drawing.Point(608, 3)
        Me.TextBoxKeySpace.MaxLength = 32767
        Me.TextBoxKeySpace.Name = "TextBoxKeySpace"
        Me.TextBoxKeySpace.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxKeySpace.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxKeySpace.SelectedText = ""
        Me.TextBoxKeySpace.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxKeySpace.TabIndex = 10
        Me.TextBoxKeySpace.UseCustomBackColor = True
        Me.TextBoxKeySpace.UseSelectable = True
        '
        'TextBoxObjects
        '
        Me.TextBoxObjects.Lines = New String(-1) {}
        Me.TextBoxObjects.Location = New System.Drawing.Point(608, 29)
        Me.TextBoxObjects.MaxLength = 32767
        Me.TextBoxObjects.Name = "TextBoxObjects"
        Me.TextBoxObjects.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxObjects.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxObjects.SelectedText = ""
        Me.TextBoxObjects.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxObjects.TabIndex = 11
        Me.TextBoxObjects.UseCustomBackColor = True
        Me.TextBoxObjects.UseSelectable = True
        '
        'TextBoxDomain
        '
        Me.TextBoxDomain.Lines = New String(-1) {}
        Me.TextBoxDomain.Location = New System.Drawing.Point(608, 55)
        Me.TextBoxDomain.MaxLength = 32767
        Me.TextBoxDomain.Name = "TextBoxDomain"
        Me.TextBoxDomain.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxDomain.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxDomain.SelectedText = ""
        Me.TextBoxDomain.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxDomain.TabIndex = 12
        Me.TextBoxDomain.UseCustomBackColor = True
        Me.TextBoxDomain.UseSelectable = True
        '
        'TextBoxTableID
        '
        Me.TextBoxTableID.Lines = New String(-1) {}
        Me.TextBoxTableID.Location = New System.Drawing.Point(608, 81)
        Me.TextBoxTableID.MaxLength = 32767
        Me.TextBoxTableID.Name = "TextBoxTableID"
        Me.TextBoxTableID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxTableID.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxTableID.SelectedText = ""
        Me.TextBoxTableID.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxTableID.TabIndex = 13
        Me.TextBoxTableID.UseCustomBackColor = True
        Me.TextBoxTableID.UseSelectable = True
        '
        'CheckBoxFirstRowAreColumnNames
        '
        Me.CheckBoxFirstRowAreColumnNames.AutoSize = True
        Me.CheckBoxFirstRowAreColumnNames.FontWeight = MetroFramework.MetroCheckBoxWeight.Light
        Me.CheckBoxFirstRowAreColumnNames.Location = New System.Drawing.Point(608, 114)
        Me.CheckBoxFirstRowAreColumnNames.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.CheckBoxFirstRowAreColumnNames.Name = "CheckBoxFirstRowAreColumnNames"
        Me.CheckBoxFirstRowAreColumnNames.Size = New System.Drawing.Size(203, 15)
        Me.CheckBoxFirstRowAreColumnNames.Style = MetroFramework.MetroColorStyle.Blue
        Me.CheckBoxFirstRowAreColumnNames.TabIndex = 14
        Me.CheckBoxFirstRowAreColumnNames.Text = "The first row contains column names"
        Me.CheckBoxFirstRowAreColumnNames.UseSelectable = True
        '
        'TextBoxRefreshToken
        '
        Me.TextBoxRefreshToken.Lines = New String() {"MetroTextBox1"}
        Me.TextBoxRefreshToken.Location = New System.Drawing.Point(608, 142)
        Me.TextBoxRefreshToken.MaxLength = 32767
        Me.TextBoxRefreshToken.Name = "TextBoxRefreshToken"
        Me.TextBoxRefreshToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxRefreshToken.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxRefreshToken.SelectedText = ""
        Me.TextBoxRefreshToken.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxRefreshToken.TabIndex = 15
        Me.TextBoxRefreshToken.Text = "MetroTextBox1"
        Me.TextBoxRefreshToken.UseCustomBackColor = True
        Me.TextBoxRefreshToken.UseSelectable = True
        '
        'TextBoxClientID
        '
        Me.TextBoxClientID.Lines = New String(-1) {}
        Me.TextBoxClientID.Location = New System.Drawing.Point(608, 168)
        Me.TextBoxClientID.MaxLength = 32767
        Me.TextBoxClientID.Name = "TextBoxClientID"
        Me.TextBoxClientID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxClientID.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxClientID.SelectedText = ""
        Me.TextBoxClientID.Size = New System.Drawing.Size(75, 23)
        Me.TextBoxClientID.TabIndex = 16
        Me.TextBoxClientID.UseCustomBackColor = True
        Me.TextBoxClientID.UseSelectable = True
        '
        'TextBoxClientSecret
        '
        Me.TextBoxClientSecret.Lines = New String(-1) {}
        Me.TextBoxClientSecret.Location = New System.Drawing.Point(608, 197)
        Me.TextBoxClientSecret.MaxLength = 32767
        Me.TextBoxClientSecret.Name = "TextBoxClientSecret"
        Me.TextBoxClientSecret.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxClientSecret.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxClientSecret.SelectedText = ""
        Me.TextBoxClientSecret.Size = New System.Drawing.Size(599, 20)
        Me.TextBoxClientSecret.TabIndex = 17
        Me.TextBoxClientSecret.UseCustomBackColor = True
        Me.TextBoxClientSecret.UseSelectable = True
        '
        'LabelKeyspace
        '
        Me.LabelKeyspace.AutoSize = True
        Me.LabelKeyspace.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelKeyspace.Location = New System.Drawing.Point(608, 225)
        Me.LabelKeyspace.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelKeyspace.Name = "LabelKeyspace"
        Me.LabelKeyspace.Size = New System.Drawing.Size(56, 15)
        Me.LabelKeyspace.TabIndex = 18
        Me.LabelKeyspace.Text = "Keyspace:"
        '
        'LabelObjects
        '
        Me.LabelObjects.AutoSize = True
        Me.LabelObjects.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelObjects.Location = New System.Drawing.Point(608, 250)
        Me.LabelObjects.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelObjects.Name = "LabelObjects"
        Me.LabelObjects.Size = New System.Drawing.Size(149, 15)
        Me.LabelObjects.TabIndex = 19
        Me.LabelObjects.Text = "Objects (comma seperated):"
        '
        'LabelDomain
        '
        Me.LabelDomain.AutoSize = True
        Me.LabelDomain.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelDomain.Location = New System.Drawing.Point(1213, 5)
        Me.LabelDomain.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelDomain.Name = "LabelDomain"
        Me.LabelDomain.Size = New System.Drawing.Size(49, 15)
        Me.LabelDomain.TabIndex = 20
        Me.LabelDomain.Text = "Domain:"
        '
        'LabelTableID
        '
        Me.LabelTableID.AutoSize = True
        Me.LabelTableID.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelTableID.Location = New System.Drawing.Point(1213, 25)
        Me.LabelTableID.Name = "LabelTableID"
        Me.LabelTableID.Size = New System.Drawing.Size(49, 15)
        Me.LabelTableID.TabIndex = 21
        Me.LabelTableID.Text = "Table ID:"
        '
        'LabelRefreshToken
        '
        Me.LabelRefreshToken.AutoSize = True
        Me.LabelRefreshToken.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelRefreshToken.Location = New System.Drawing.Point(1213, 45)
        Me.LabelRefreshToken.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelRefreshToken.Name = "LabelRefreshToken"
        Me.LabelRefreshToken.Size = New System.Drawing.Size(78, 15)
        Me.LabelRefreshToken.TabIndex = 22
        Me.LabelRefreshToken.Text = "Refresh token:"
        '
        'LabelClientID
        '
        Me.LabelClientID.AutoSize = True
        Me.LabelClientID.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelClientID.Location = New System.Drawing.Point(1213, 70)
        Me.LabelClientID.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelClientID.Name = "LabelClientID"
        Me.LabelClientID.Size = New System.Drawing.Size(51, 15)
        Me.LabelClientID.TabIndex = 23
        Me.LabelClientID.Text = "Client ID:"
        '
        'LabelClientSecret
        '
        Me.LabelClientSecret.AutoSize = True
        Me.LabelClientSecret.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelClientSecret.Location = New System.Drawing.Point(1213, 95)
        Me.LabelClientSecret.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelClientSecret.Name = "LabelClientSecret"
        Me.LabelClientSecret.Size = New System.Drawing.Size(70, 15)
        Me.LabelClientSecret.TabIndex = 24
        Me.LabelClientSecret.Text = "Client secret:"
        '
        'LabelProvider
        '
        Me.LabelProvider.AutoSize = True
        Me.LabelProvider.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelProvider.Location = New System.Drawing.Point(3, 0)
        Me.LabelProvider.Name = "LabelProvider"
        Me.LabelProvider.Size = New System.Drawing.Size(53, 15)
        Me.LabelProvider.TabIndex = 19
        Me.LabelProvider.Text = "Provider:"
        '
        'ComboBoxDataProvider
        '
        Me.ComboBoxDataProvider.DropDownWidth = 617
        Me.ComboBoxDataProvider.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.ComboBoxDataProvider.ItemHeight = 19
        Me.ComboBoxDataProvider.Location = New System.Drawing.Point(3, 18)
        Me.ComboBoxDataProvider.Name = "ComboBoxDataProvider"
        Me.ComboBoxDataProvider.Size = New System.Drawing.Size(617, 25)
        Me.ComboBoxDataProvider.Style = MetroFramework.MetroColorStyle.Blue
        Me.ComboBoxDataProvider.TabIndex = 18
        Me.ComboBoxDataProvider.UseSelectable = True
        '
        'ButtonNextTabpage1
        '
        Me.ButtonNextTabpage1.Enabled = False
        Me.ButtonNextTabpage1.Location = New System.Drawing.Point(514, 353)
        Me.ButtonNextTabpage1.Name = "ButtonNextTabpage1"
        Me.ButtonNextTabpage1.Size = New System.Drawing.Size(106, 26)
        Me.ButtonNextTabpage1.TabIndex = 17
        Me.ButtonNextTabpage1.Text = "Next >"
        Me.ButtonNextTabpage1.UseSelectable = True
        '
        'buttonDataProviderTest
        '
        Me.buttonDataProviderTest.BackColor = System.Drawing.SystemColors.Control
        Me.buttonDataProviderTest.Location = New System.Drawing.Point(402, 353)
        Me.buttonDataProviderTest.Name = "buttonDataProviderTest"
        Me.buttonDataProviderTest.Size = New System.Drawing.Size(106, 26)
        Me.buttonDataProviderTest.TabIndex = 1
        Me.buttonDataProviderTest.Text = "Test"
        Me.buttonDataProviderTest.UseSelectable = True
        '
        'tabPage2
        '
        Me.tabPage2.BackColor = System.Drawing.Color.Transparent
        Me.tabPage2.Controls.Add(Me.ButtonPreview)
        Me.tabPage2.Controls.Add(Me.ButtonDesign)
        Me.tabPage2.Controls.Add(Me.ButtonBackTabpage2)
        Me.tabPage2.Controls.Add(Me.GroupBox1)
        Me.tabPage2.Location = New System.Drawing.Point(4, 41)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Size = New System.Drawing.Size(623, 382)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "2. Project settings"
        '
        'ButtonPreview
        '
        Me.ButtonPreview.Location = New System.Drawing.Point(514, 348)
        Me.ButtonPreview.Name = "ButtonPreview"
        Me.ButtonPreview.Size = New System.Drawing.Size(106, 26)
        Me.ButtonPreview.TabIndex = 16
        Me.ButtonPreview.Text = "Preview..."
        Me.ButtonPreview.UseSelectable = True
        '
        'ButtonDesign
        '
        Me.ButtonDesign.Location = New System.Drawing.Point(402, 348)
        Me.ButtonDesign.Name = "ButtonDesign"
        Me.ButtonDesign.Size = New System.Drawing.Size(106, 26)
        Me.ButtonDesign.TabIndex = 15
        Me.ButtonDesign.Text = "Design..."
        Me.ButtonDesign.UseSelectable = True
        '
        'ButtonBackTabpage2
        '
        Me.ButtonBackTabpage2.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonBackTabpage2.Location = New System.Drawing.Point(3, 348)
        Me.ButtonBackTabpage2.Name = "ButtonBackTabpage2"
        Me.ButtonBackTabpage2.Size = New System.Drawing.Size(106, 26)
        Me.ButtonBackTabpage2.TabIndex = 14
        Me.ButtonBackTabpage2.Text = "< Back"
        Me.ButtonBackTabpage2.UseSelectable = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox1.Controls.Add(Me.ButtonLogo)
        Me.GroupBox1.Controls.Add(Me.TextBoxLogo)
        Me.GroupBox1.Controls.Add(Me.LabelLogo)
        Me.GroupBox1.Controls.Add(Me.TextBoxTitle)
        Me.GroupBox1.Controls.Add(Me.LabelTitle)
        Me.GroupBox1.Controls.Add(Me.buttonToAvailableFields)
        Me.GroupBox1.Controls.Add(Me.buttonToSelectedFields)
        Me.GroupBox1.Controls.Add(Me.ListBoxSelectedFields)
        Me.GroupBox1.Controls.Add(Me.ListBoxAvailableFields)
        Me.GroupBox1.Controls.Add(Me.LabelSelectedFields)
        Me.GroupBox1.Controls.Add(Me.LabelAvailableFields)
        Me.GroupBox1.Controls.Add(Me.ComboBoxTable)
        Me.GroupBox1.Controls.Add(Me.LabelTable)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(617, 337)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Project Layout"
        '
        'ButtonLogo
        '
        Me.ButtonLogo.Location = New System.Drawing.Point(581, 305)
        Me.ButtonLogo.Name = "ButtonLogo"
        Me.ButtonLogo.Size = New System.Drawing.Size(27, 19)
        Me.ButtonLogo.TabIndex = 12
        Me.ButtonLogo.Text = "..."
        Me.ButtonLogo.UseSelectable = True
        '
        'TextBoxLogo
        '
        Me.TextBoxLogo.Lines = New String(-1) {}
        Me.TextBoxLogo.Location = New System.Drawing.Point(6, 304)
        Me.TextBoxLogo.MaxLength = 32767
        Me.TextBoxLogo.Name = "TextBoxLogo"
        Me.TextBoxLogo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxLogo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxLogo.SelectedText = ""
        Me.TextBoxLogo.Size = New System.Drawing.Size(569, 20)
        Me.TextBoxLogo.TabIndex = 11
        Me.TextBoxLogo.UseCustomBackColor = True
        Me.TextBoxLogo.UseSelectable = True
        '
        'LabelLogo
        '
        Me.LabelLogo.AutoSize = True
        Me.LabelLogo.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelLogo.Location = New System.Drawing.Point(6, 283)
        Me.LabelLogo.Name = "LabelLogo"
        Me.LabelLogo.Size = New System.Drawing.Size(36, 15)
        Me.LabelLogo.TabIndex = 10
        Me.LabelLogo.Text = "Logo:"
        '
        'TextBoxTitle
        '
        Me.TextBoxTitle.Lines = New String() {"Dynamically created project"}
        Me.TextBoxTitle.Location = New System.Drawing.Point(6, 256)
        Me.TextBoxTitle.MaxLength = 32767
        Me.TextBoxTitle.Name = "TextBoxTitle"
        Me.TextBoxTitle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxTitle.SelectedText = ""
        Me.TextBoxTitle.Size = New System.Drawing.Size(602, 20)
        Me.TextBoxTitle.TabIndex = 9
        Me.TextBoxTitle.Text = "Dynamically created project"
        Me.TextBoxTitle.UseCustomBackColor = True
        Me.TextBoxTitle.UseSelectable = True
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelTitle.Location = New System.Drawing.Point(7, 235)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(30, 15)
        Me.LabelTitle.TabIndex = 8
        Me.LabelTitle.Text = "Title:"
        '
        'buttonToAvailableFields
        '
        Me.buttonToAvailableFields.Location = New System.Drawing.Point(290, 163)
        Me.buttonToAvailableFields.Name = "buttonToAvailableFields"
        Me.buttonToAvailableFields.Size = New System.Drawing.Size(35, 30)
        Me.buttonToAvailableFields.TabIndex = 7
        Me.buttonToAvailableFields.Text = "<"
        Me.buttonToAvailableFields.UseSelectable = True
        '
        'buttonToSelectedFields
        '
        Me.buttonToSelectedFields.Location = New System.Drawing.Point(290, 127)
        Me.buttonToSelectedFields.Name = "buttonToSelectedFields"
        Me.buttonToSelectedFields.Size = New System.Drawing.Size(35, 30)
        Me.buttonToSelectedFields.TabIndex = 6
        Me.buttonToSelectedFields.Text = ">"
        Me.buttonToSelectedFields.UseSelectable = True
        '
        'ListBoxSelectedFields
        '
        Me.ListBoxSelectedFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBoxSelectedFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBoxSelectedFields.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ListBoxSelectedFields.Location = New System.Drawing.Point(331, 96)
        Me.ListBoxSelectedFields.Name = "ListBoxSelectedFields"
        Me.ListBoxSelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxSelectedFields.Size = New System.Drawing.Size(277, 132)
        Me.ListBoxSelectedFields.Sorted = True
        Me.ListBoxSelectedFields.TabIndex = 5
        '
        'ListBoxAvailableFields
        '
        Me.ListBoxAvailableFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBoxAvailableFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBoxAvailableFields.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ListBoxAvailableFields.Location = New System.Drawing.Point(6, 96)
        Me.ListBoxAvailableFields.Name = "ListBoxAvailableFields"
        Me.ListBoxAvailableFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxAvailableFields.Size = New System.Drawing.Size(278, 132)
        Me.ListBoxAvailableFields.Sorted = True
        Me.ListBoxAvailableFields.TabIndex = 4
        '
        'LabelSelectedFields
        '
        Me.LabelSelectedFields.AutoSize = True
        Me.LabelSelectedFields.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelSelectedFields.Location = New System.Drawing.Point(331, 75)
        Me.LabelSelectedFields.Name = "LabelSelectedFields"
        Me.LabelSelectedFields.Size = New System.Drawing.Size(83, 15)
        Me.LabelSelectedFields.TabIndex = 3
        Me.LabelSelectedFields.Text = "Selected Fields:"
        '
        'LabelAvailableFields
        '
        Me.LabelAvailableFields.AutoSize = True
        Me.LabelAvailableFields.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelAvailableFields.Location = New System.Drawing.Point(7, 75)
        Me.LabelAvailableFields.Name = "LabelAvailableFields"
        Me.LabelAvailableFields.Size = New System.Drawing.Size(85, 15)
        Me.LabelAvailableFields.TabIndex = 2
        Me.LabelAvailableFields.Text = "Available Fields:"
        '
        'ComboBoxTable
        '
        Me.ComboBoxTable.DropDownWidth = 602
        Me.ComboBoxTable.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.ComboBoxTable.ItemHeight = 19
        Me.ComboBoxTable.Location = New System.Drawing.Point(6, 43)
        Me.ComboBoxTable.Name = "ComboBoxTable"
        Me.ComboBoxTable.Size = New System.Drawing.Size(602, 25)
        Me.ComboBoxTable.Style = MetroFramework.MetroColorStyle.Blue
        Me.ComboBoxTable.TabIndex = 1
        Me.ComboBoxTable.UseSelectable = True
        '
        'LabelTable
        '
        Me.LabelTable.AutoSize = True
        Me.LabelTable.FontSize = MetroFramework.MetroLabelSize.Small
        Me.LabelTable.Location = New System.Drawing.Point(7, 22)
        Me.LabelTable.Name = "LabelTable"
        Me.LabelTable.Size = New System.Drawing.Size(35, 15)
        Me.LabelTable.TabIndex = 0
        Me.LabelTable.Text = "Table:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.Label1.Location = New System.Drawing.Point(23, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "US:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.Label4.Location = New System.Drawing.Point(52, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(422, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "This sample shows the usage of NoSql data providers."
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.Label5.Location = New System.Drawing.Point(23, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "D:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.Label3.Location = New System.Drawing.Point(52, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(422, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Dieses Beispiel zeigt die Verwendung von NoSql Datenprovidern."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "sunshine.gif"
        Me.OpenFileDialog1.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|A" &
    "ll Files (*.*)|*.*"
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(677, 542)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Resizable = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List & Label VB.NET NoSql DataProvider Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LL As combit.ListLabel24.ListLabel
    Private WithEvents tabControl1 As MetroFramework.Controls.MetroTabControl
    Private WithEvents tabPage1 As TabPage
    Private WithEvents tabPage2 As TabPage
    Private WithEvents buttonDataProviderTest As MetroFramework.Controls.MetroButton
    Private WithEvents ButtonNextTabpage1 As MetroFramework.Controls.MetroButton
    Private WithEvents ComboBoxDataProvider As MetroFramework.Controls.MetroComboBox
    Friend WithEvents LabelProvider As MetroFramework.Controls.MetroLabel
    Private WithEvents Label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents Label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents Label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents Label3 As MetroFramework.Controls.MetroLabel
    Private WithEvents GroupBox2 As GroupBox
    Private WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Private WithEvents LabelAddress As MetroFramework.Controls.MetroLabel
    Private WithEvents TextBoxAddress As MetroFramework.Controls.MetroTextBox
    Private WithEvents LabelUserName As MetroFramework.Controls.MetroLabel
    Friend WithEvents TextBoxUsername As MetroFramework.Controls.MetroTextBox
    Private WithEvents LabelPassword As MetroFramework.Controls.MetroLabel
    Friend WithEvents TextBoxPassword As MetroFramework.Controls.MetroTextBox
    Private WithEvents LabelDBName As MetroFramework.Controls.MetroLabel
    Friend WithEvents TextBoxDBName As MetroFramework.Controls.MetroTextBox
    Private WithEvents LabelPort As MetroFramework.Controls.MetroLabel
    Private WithEvents TextBoxPort As MetroFramework.Controls.MetroTextBox
    Private WithEvents GroupBox1 As GroupBox
    Private WithEvents ComboBoxTable As MetroFramework.Controls.MetroComboBox
    Friend WithEvents LabelTable As MetroFramework.Controls.MetroLabel
    Private WithEvents LabelAvailableFields As MetroFramework.Controls.MetroLabel
    Private WithEvents ListBoxAvailableFields As ListBox
    Private WithEvents LabelSelectedFields As MetroFramework.Controls.MetroLabel
    Private WithEvents ListBoxSelectedFields As ListBox
    Private WithEvents buttonToAvailableFields As MetroFramework.Controls.MetroButton
    Private WithEvents buttonToSelectedFields As MetroFramework.Controls.MetroButton
    Private WithEvents LabelLogo As MetroFramework.Controls.MetroLabel
    Private WithEvents TextBoxTitle As MetroFramework.Controls.MetroTextBox
    Private WithEvents LabelTitle As MetroFramework.Controls.MetroLabel
    Private WithEvents TextBoxLogo As MetroFramework.Controls.MetroTextBox
    Private WithEvents ButtonLogo As MetroFramework.Controls.MetroButton
    Private WithEvents ButtonPreview As MetroFramework.Controls.MetroButton
    Private WithEvents ButtonDesign As MetroFramework.Controls.MetroButton
    Private WithEvents ButtonBackTabpage2 As MetroFramework.Controls.MetroButton
    Private WithEvents OpenFileDialog1 As OpenFileDialog
    Private WithEvents TextBoxKeySpace As MetroFramework.Controls.MetroTextBox
    Private WithEvents TextBoxObjects As MetroFramework.Controls.MetroTextBox
    Private WithEvents TextBoxDomain As MetroFramework.Controls.MetroTextBox
    Private WithEvents TextBoxTableID As MetroFramework.Controls.MetroTextBox
    Private WithEvents CheckBoxFirstRowAreColumnNames As MetroFramework.Controls.MetroCheckBox
    Private WithEvents TextBoxRefreshToken As MetroFramework.Controls.MetroTextBox
    Private WithEvents TextBoxClientID As MetroFramework.Controls.MetroTextBox
    Private WithEvents TextBoxClientSecret As MetroFramework.Controls.MetroTextBox
    Friend WithEvents LabelKeyspace As MetroFramework.Controls.MetroLabel
    Private WithEvents LabelObjects As MetroFramework.Controls.MetroLabel
    Private WithEvents LabelDomain As MetroFramework.Controls.MetroLabel
    Private WithEvents LabelTableID As MetroFramework.Controls.MetroLabel
    Private WithEvents LabelRefreshToken As MetroFramework.Controls.MetroLabel
    Private WithEvents LabelClientID As MetroFramework.Controls.MetroLabel
    Private WithEvents LabelClientSecret As MetroFramework.Controls.MetroLabel
End Class

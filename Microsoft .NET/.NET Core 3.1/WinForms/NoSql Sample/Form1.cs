using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using combit.Reporting;
using combit.Reporting.DataProviders;
using combit.Reporting.Dom;
using System.Text.RegularExpressions;

namespace DataProvidersWithoutSolidStructure
{
    public partial class Form1 : Form
    {
		private bool _hasPassedTest = false;
		private IDataProvider _dataProvider = null;
		private System.Collections.ObjectModel.ReadOnlyCollection<ITable> _dataProviderTables = null;

		[STAThread]
		public static void Main()
		{
            SetProcessDPIAware();
            Application.EnableVisualStyles();
			Application.Run(new Form1());
		}
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        public Form1()
        {
            Directory.SetCurrentDirectory(@"..\..\..\..\..\..\Report Files");

            InitializeComponent();
			InitializeComboBoxProvider();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			tabControl1.SelectedTab = tabPage1;
		}

		private void ButtonNavigate(object sender, EventArgs e)
		{
			if (sender == buttonNextTabpage1)
			{
				tabControl1.SelectedTab = tabPage2;
			}
			else if (sender == buttonBackTabpage2)
			{
				tabControl1.SelectedTab = tabPage1;
			}
		}

		private void ControlInputChanged(object sender, EventArgs e)
		{
			buttonNextTabpage1.Enabled = false;
			_hasPassedTest = false;
		}

		private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{
			if (!_hasPassedTest)
			{
				e.Cancel = true;
			}
		}

		#region DataProvider Settings Tabview

		private void InitializeComboBoxProvider()
		{
			//D: Alle verfügbaren Datenprovider in die comboBox einfügen
			//US: Add all available data providers into the comboBox
			comboBoxDataProvider.Items.Add("Cassandra");
			comboBoxDataProvider.Items.Add("MongoDB");
			comboBoxDataProvider.Items.Add("Salesforce");
			comboBoxDataProvider.Items.Add("Google Spreadsheets (Public)");
			comboBoxDataProvider.Items.Add("Google Spreadsheets (Private)");
			comboBoxDataProvider.SelectedIndex = 0;
		}

		private IDataProvider CreateDataProvider(string selectedProvider)
		{
			//D: Den korrekten Datenprovider initialisieren
			//US: Initialize the correct data provider
			IDataProvider provider = null;
			
			switch (selectedProvider)
			{
				case "Cassandra":
					provider = new CassandraDataProvider(	textBoxAddress.Text,
															textBoxKeyspace.Text);
					break;
				case "MongoDB":
					provider = new MongoDBDataProvider(	textBoxAddress.Text,
														textBoxDBName.Text,
														textBoxUsername.Text,
														textBoxPassword.Text,
														textBoxPort.Text);
					break;
				case "Salesforce":
					string[] salesforceObjects = null;
					if (!String.IsNullOrWhiteSpace(textBoxObjects.Text))
					{
						salesforceObjects = textBoxObjects.Text.Trim().Split(',');
					}

					provider = new SalesforceDataProvider(textBoxUsername.Text,
															textBoxPassword.Text,
															salesforceObjects,
															textBoxAddress.Text);
					break;
				case "Google Spreadsheets (Public)":
					provider = new GoogleSpreadsheetsDataProvider(	textBoxTableID.Text,
																	checkBoxFirstRowAreColumnNames.Checked,
																	"");
					break;
				case "Google Spreadsheets (Private)":
					provider = new GoogleSpreadsheetsDataProvider(	textBoxTableID.Text,
																	checkBoxFirstRowAreColumnNames.Checked,
																	textBoxRefreshToken.Text,
																	textBoxClientID.Text,
																	textBoxClientSecret.Text);
					break;
			}

			return provider;
		}

		private bool IsAllInputGivenForDataProvider(string selectedDataProvider)
		{
			foreach (Control item in flowLayoutPanel1.Controls)
			{

				if (item == textBoxObjects)
				{
					continue;
				}

				if (selectedDataProvider == "MongoDB")
				{
					if (item == textBoxPassword || item == textBoxUsername)
					{
						continue;
					}
				}

				if (item is TextBox && item.Visible == true)
				{
					if (String.IsNullOrWhiteSpace(item.Text))
					{
						return false;
					}
				}
			}
			return true;
		}

		private void ResetControlsInFlowLayoutPanel()
		{
			while (flowLayoutPanel1.Controls.Count > 0)
			{
				flowLayoutPanel1.Controls.RemoveAt(0);
			}

			textBoxAddress.Text = "";
			textBoxPort.Text = "";
		}

		private void ComboBoxProvider_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedItem = comboBoxDataProvider.SelectedItem as string;

			ResetControlsInFlowLayoutPanel();

			//D: Alle benötigten Eingabefelder hinzufügen
			//US: Add all needed input boxes
			switch (selectedItem)
			{
				case "Cassandra":
					flowLayoutPanel1.Controls.Add(labelAddress);
					flowLayoutPanel1.Controls.Add(textBoxAddress);
					textBoxAddress.Text = "";

					flowLayoutPanel1.Controls.Add(labelKeyspace);
					flowLayoutPanel1.Controls.Add(textBoxKeyspace);
					textBoxKeyspace.Text = "";
					break;
					
				case "MongoDB":
					flowLayoutPanel1.Controls.Add(labelAddress);
					flowLayoutPanel1.Controls.Add(textBoxAddress);
					textBoxAddress.Text = "";

					flowLayoutPanel1.Controls.Add(labelUsername);
					flowLayoutPanel1.Controls.Add(textBoxUsername);
					textBoxUsername.Text = "";

					flowLayoutPanel1.Controls.Add(labelPassword);
					flowLayoutPanel1.Controls.Add(textBoxPassword);
					textBoxPassword.Text = "";

					flowLayoutPanel1.Controls.Add(labelDBName);
					flowLayoutPanel1.Controls.Add(textBoxDBName);
					textBoxDBName.Text = "";

					flowLayoutPanel1.Controls.Add(labelPort);
					flowLayoutPanel1.Controls.Add(textBoxPort);
					textBoxPort.Text = "27017";
					break;

				case "Salesforce":
					flowLayoutPanel1.Controls.Add(labelAddress);
					flowLayoutPanel1.Controls.Add(textBoxAddress);
					textBoxAddress.Text = "https://login.salesforce.com/services/oauth2/token";

					flowLayoutPanel1.Controls.Add(labelUsername);
					flowLayoutPanel1.Controls.Add(textBoxUsername);
					textBoxUsername.Text = "";

					flowLayoutPanel1.Controls.Add(labelPassword);
					flowLayoutPanel1.Controls.Add(textBoxPassword);
					textBoxPassword.Text = "";

					flowLayoutPanel1.Controls.Add(labelObjects);
					flowLayoutPanel1.Controls.Add(textBoxObjects);
					textBoxObjects.Text = "";
					break;

				case "Google Spreadsheets (Public)":
					flowLayoutPanel1.Controls.Add(labelTableID);
					flowLayoutPanel1.Controls.Add(textBoxTableID);
					textBoxTableID.Text = "";

					flowLayoutPanel1.Controls.Add(checkBoxFirstRowAreColumnNames);
					break;

				case "Google Spreadsheets (Private)":
					flowLayoutPanel1.Controls.Add(labelTableID);
					flowLayoutPanel1.Controls.Add(textBoxTableID);
					textBoxTableID.Text = "";

					flowLayoutPanel1.Controls.Add(checkBoxFirstRowAreColumnNames);

					flowLayoutPanel1.Controls.Add(labelRefreshToken);
					flowLayoutPanel1.Controls.Add(textBoxRefreshToken);
					textBoxRefreshToken.Text = "";

					flowLayoutPanel1.Controls.Add(labelClientID);
					flowLayoutPanel1.Controls.Add(textBoxClientID);
					textBoxClientID.Text = "";

					flowLayoutPanel1.Controls.Add(labelClientSecret);
					flowLayoutPanel1.Controls.Add(textBoxClientSecret);
					textBoxClientSecret.Text = "";
					break;
			}

			buttonNextTabpage1.Enabled = false;
		}

		private void ButtonDataProviderTest_Click(object sender, EventArgs e)
		{
			string selectedDataProvider = comboBoxDataProvider.SelectedItem as string;
			
			if (IsAllInputGivenForDataProvider(selectedDataProvider))
			{
				bool passedTest = false;

				Cursor.Current = Cursors.WaitCursor;
				try
				{
					_dataProvider = CreateDataProvider(selectedDataProvider);
					_dataProviderTables = _dataProvider.Tables;

					if (_dataProviderTables.Count > 0)
					{
						passedTest = true;
					}
					else
					{
						MessageBox.Show("The data provider returned 0 tables.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				catch (ListLabelException LlException)
				{
					//D: Exception abfangen
					//US: Catch exceptions
					MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch(Exception f)
				{
					MessageBox.Show("The data provider could not be created successfully:\n" + f.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				Cursor.Current = Cursors.Default;

				if (passedTest)
				{
					InitTabpage2();
					buttonNextTabpage1.Enabled = true;
					_hasPassedTest = true;
					MessageBox.Show("The data provider was successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					_dataProvider = null;
					_dataProviderTables = null;
				}
			}
			else
			{
				MessageBox.Show("Please fill out the input boxes.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		#endregion


		#region Project Settings Tabview
		private void InitTabpage2()
		{
			//D: Alle Felder aus der Liste löschen
			//US: Clear all fields from the list
			listBoxAvailableFields.Items.Clear();
			listBoxSelectedFields.Items.Clear();

			textBoxLogo.Text = Path.Combine(Directory.GetCurrentDirectory(), "sunshine.gif");

			InitComboBoxTable();
		}

		private void InitComboBoxTable()
		{
			if (_dataProvider != null)
			{
				comboBoxTable.Items.Clear();
				//D: Alle verfügbaren Tabellen in das Control schreiben
				//US: Add all available tables to the control

				foreach (var table in _dataProviderTables)
				{
					comboBoxTable.Items.Add(CleanUpString(table.TableName));
				}
			}

			//D: Ersten Eintrag selektieren
			//US: Select first entry
			comboBoxTable.SelectedIndex = 0;
		}

        private void DesignProject_Click(object sender, EventArgs e)
        {
            try
            {
                //D: Den Datenprovider setzen
                //US: Set the data provider
				LL.DataSource = _dataProvider;

                //D: List & Label Projekt anhand Einstellungen erstellen
                //US: Create List & Label project based on the settings
                GenerateLLProject();

                //D: Designer aufrufen
                //US: Call the designer
                LL.Design(LlProject.List, Path.Combine(Application.StartupPath, "dynamic.lst"));
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PrintProject_Click(object sender, EventArgs e)
        {
            try
            {
				//D: Den Datenprovider setzen
				//US: Set the data provider
				LL.DataSource = _dataProvider;

				//D: List & Label Projekt anhand Einstellungen erstellen
				//US: Create List & Label project based on the settings
				GenerateLLProject();

                //D: Drucken
                //US: Print
                LL.Print(LlProject.List, Path.Combine(Application.StartupPath, "dynamic.lst"));
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //D: Hinweis: Beim Verwenden der List & Label DOM Klassen ist zu beachten, dass die einzelnen Eigenschaftswerte als Zeichenkette angegeben werden           
        //	   müssen. Dies ist notwendig, um ein Höchstmaß an Flexibilität zu gewährleisten, da somit auch List & Label Formeln erlaubt sind.

        //US: Hint: When using List & Label DOM classes, please note that the property values have to be passed as strings. This is neccessary to ensure a
        //		 maximum of flexibility - this way, List & Label formulas can be used as property values.
        private void GenerateLLProject()
        {
            try
            {
                //D: Neues DOM-Projekt vom Typ LlProject.List erzeugen
                //US: Create new DOM project of type LlProject.List
                using (ProjectList proj = new ProjectList(LL))
                {
                    //D: Dateinamen und Dateizugriffsoptionen setzen
                    //US: Set file name and file access options
                    proj.Open(Path.Combine(Application.StartupPath, "dynamic.lst"), LlDomFileMode.Create, LlDomAccessMode.ReadWrite);

                    //D: Standardschrift und -größe setzen
                    //US: Set default font and size
                    proj.Settings.DefaultFont.FaceName = "\"Calibri\"";
                    proj.Settings.DefaultFont.Size = "12";

                    //D: Designschema setzen
                    //US: Set design scheme
                    proj.ProjectParameters["LL.DesignScheme"].Contents = "\"COMBITCOLORWHEEL\"";

                    //D: Eine neue Projektbeschreibung zuweisen
                    //US: Assign new project description
                    proj.ProjectParameters["LL.ProjectDescription"].Contents = textBoxTitle.Text;
					
                    //D: Ein leeres Text-Objekt erstellen
                    //US: Create an empty text object
                    ObjectText llobjText = new ObjectText(proj.Objects);

                    //D: Auslesen der Seitenkoordinaten der ersten Seite
                    //US: Get the coordinates for the first page
                    Size pageExtend = proj.Regions[0].Paper.Extent.Get();

                    //D: Setzen von Eigenschaften für das Text-Objekt. Alle Einheiten sind SCM (1/1000 mm).
                    //US: Set some properties for the text object. All units are SCM (1/1000 mm).
                    llobjText.Position.Set(10000, 10000, pageExtend.Width - 65000, 27000);

                    //D: Hinzufügen eines Absatzes und Setzen diverser Eigenschaften
                    //US: Add a paragraph to the text object and set some properties
                    Paragraph llobjParagraph = new Paragraph(llobjText.Paragraphs);
                    llobjParagraph.Contents = string.Format("\"{0}\"", textBoxTitle.Text);
                    llobjParagraph.Font.Bold = "True";

                    //D: Hinzufügen eines Grafikobjekts
                    //US: Add a drawing object
                    ObjectDrawing llobjPic = new ObjectDrawing(proj.Objects);
                    llobjPic.Source.FileInfo.FileName = textBoxLogo.Text;
                    llobjPic.Position.Set(pageExtend.Width - 50000, 10000, pageExtend.Width - (pageExtend.Width - 40000), 27000);

                    //D: Hinzufügen eines Tabellencontainers und Setzen diverser Eigenschaften
                    //US: Add a table container and set some properties
                    ObjectReportContainer container = new ObjectReportContainer(proj.Objects);
                    container.Position.Set(10000, 40000, pageExtend.Width - 20000, pageExtend.Height - 44000);

                    //D: In dem Tabellencontainer eine Tabelle hinzufügen
                    //US: Add a table into the table container
                    SubItemTable table = new SubItemTable(container.SubItems);

                    //D: Gewünschte Tabelle als Datenquelle setzen
                    //US: Set required source table
                    table.TableId = comboBoxTable.Text;

                    //D: Zebramuster für Tabelle definieren
                    //US: Define zebra pattern for table
                    table.LineOptions.Data.ZebraPattern.Style = "1";
                    table.LineOptions.Data.ZebraPattern.Pattern = "1";
                    table.LineOptions.Data.ZebraPattern.Color = "LL.Scheme.BackgroundColor0";

                    //D: Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
                    //US: Add a new data line including all selected fields
                    TableLineData tableLineData = new TableLineData(table.Lines.Data);
                    TableLineHeader tableLineHeader = new TableLineHeader(table.Lines.Header);

                    foreach (string fieldName in listBoxSelectedFields.Items)
                    {
                        string fieldWidth = (Convert.ToInt32(container.Position.Width) / listBoxSelectedFields.Items.Count).ToString();

                        //D: Kopfzeile definieren
                        //US: Define header line
                        TableFieldText header = new TableFieldText(tableLineHeader.Fields);
                        header.Contents = string.Format("\"{0}\"", fieldName);
                        header.Filling.Style = "1";
                        header.Filling.Color = "LL.Scheme.BackgroundColor2";
                        header.Font.Bold = "True";
                        header.Font.Color = "LL.Color.White";
                        header.Width = fieldWidth;

                        //D: Datenzeile definieren
                        //US: Define data line
                        TableFieldText tableField = new TableFieldText(tableLineData.Fields);
                        tableField.Contents = comboBoxTable.Text + "." + fieldName;
                        tableField.Width = fieldWidth;
                        tableField.Filling.Pattern = "0";
                    }
					
                    //D: Projekt speichern
                    //US: Save project
                    proj.Save();
                }
            }
            catch (ListLabelException LlException)
            {
				//D: Exception abfangen
				//US: Catch exceptions
				MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
			
		}

        private void ComboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //D: Alle Felder aus der Liste löschen
            //US: Clear all fields from the list
            listBoxAvailableFields.Items.Clear();
            listBoxSelectedFields.Items.Clear();

			try
			{
				var schemaRow = _dataProviderTables[comboBoxTable.SelectedIndex].SchemaRow;
				foreach (var column in schemaRow.Columns)
				{
					listBoxAvailableFields.Items.Add(CleanUpString(column.ColumnName));
				}
			}
			catch (NotImplementedException)
			{
				//D: Alle verfügbaren Felder in die ListBox einfügen
				//US: Add all available fields into the listbox
				foreach (var row in _dataProviderTables[comboBoxTable.SelectedIndex].Rows)
				{
					foreach (var column in row.Columns)
					{
						listBoxAvailableFields.Items.Add(CleanUpString(column.ColumnName));
					}
					break;
				}
			}
		}

        private void SelectField_Click(object sender, EventArgs e)
        {
            if (sender == buttonToSelectedFields)
            {
                while (listBoxAvailableFields.SelectedItems.Count > 0)
                {
                    listBoxSelectedFields.Items.Add(listBoxAvailableFields.SelectedItems[0]);
                    listBoxAvailableFields.Items.Remove(listBoxAvailableFields.SelectedItems[0]);
                }
            }
            else if (sender == buttonToAvailableFields)
            {
                while (listBoxSelectedFields.SelectedItems.Count > 0)
                {
                    listBoxAvailableFields.Items.Add(listBoxSelectedFields.SelectedItems[0]);
                    listBoxSelectedFields.Items.Remove(listBoxSelectedFields.SelectedItems[0]);
                }
            }
        }

        private void ButtonLogo_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = textBoxLogo.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBoxLogo.Text = openFileDialog1.FileName;
        }

        private void ListBoxAvailableFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxAvailableFields.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                buttonToSelectedFields.PerformClick();
            }
        }

        private void ListBoxSelectedFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxSelectedFields.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                buttonToAvailableFields.PerformClick();
            }
        }

		private string CleanUpString(string input)
		{
			Regex regex = new Regex("[\\s+-.,!@#$%^&*();\\/|<>\"']");
			return regex.Replace(input, "_"); ;
		}

		#endregion

	}
}

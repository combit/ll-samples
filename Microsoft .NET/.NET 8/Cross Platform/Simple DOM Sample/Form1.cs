using Antlr4.Runtime.Atn;

using combit.Reporting;
using combit.Reporting.Dom;

using Microsoft.Win32;

using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace DOMSimple
{
    public partial class Form1 : Form
    {
        private DataSet? _dataSet;
        public Form1()
        {
            Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\..\..\..\..\Report Files\Cross Platform");
            InitializeComponent();
            LL = new ListLabel();

            InitDataSet();
        }

        // Init Data Set to access nwind.mdb
        private void InitDataSet()
        {
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            String databasePath = String.Empty;
            if (installKey != null)
            {
                databasePath = (string)installKey.GetValue("NWINDPath", "");
            }

            if (databasePath.Length == 0)
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");

            _dataSet = new DataSet();
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath;
            OleDbConnection myOledbConnection = new(connectionString);
            myOledbConnection.Open();

            DataTable table = myOledbConnection.GetSchema("Tables");

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tables and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                if (dr["TABLE_TYPE"].ToString() == "TABLE")
                {
                    string? tableName = dr["Table_Name"].ToString();
                    OleDbDataAdapter dataAdapter = tableName == "Orders" || tableName == "Order Details"
                        ? new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "] WHERE OrderID > 11040", myOledbConnection))
                        : new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", myOledbConnection));

                    //D: Die "Orders" und "Order Details" Tabelle einschränken.
                    //US: Limit the "Order" and "Order Details" table. 

                    if (tableName == "Order Details")
                        tableName = tableName.Replace(" ", "_");

                    dataAdapter.FillSchema(_dataSet, SchemaType.Source, tableName!);
                    dataAdapter.Fill(_dataSet, tableName!);
                }
            }

            //D: Verbindung schliessen
            //US: Close connection
            myOledbConnection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //D: Alle verfügbaren Tabellen in das Control schreiben
            //US: Add all available tables to the control
            foreach (DataTable dt in _dataSet!.Tables)
                comboBoxTable.Items.Add(dt.TableName);

            //D: Ersten Eintrag selektieren
            //US: Select first entry
            comboBoxTable.SelectedIndex = 0;

            textBox2.Text = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName, "sunshine.gif");
        }

        private void PrintProject_Click(object sender, EventArgs e)
        {
            try
            {
                //D: An das DataSet Objekt binden
                //US: Now bind to the DataSet
                LL.SetDataBinding(_dataSet!, comboBoxTable.Text);

                //D: List & Label Projekt anhand Einstellungen erstellen
                //US: Create List & Label project based on the settings
                GenerateLLProject();

                // D: Speichern-Dialog öffnen  
                // US: Open save file dialog  
                SaveFileDialog saveFileDialog = new()
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    Title = "Save Report as PDF",
                    FileName = Path.GetFileName("dynamic.json").Replace(".json", ".pdf")

                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // D: Exportpfad setzen  
                    // US: Set export path  
                    string exportPath = saveFileDialog.FileName;

                    //D: Drucken
                    //US: Print
                    ExportConfiguration exportConf = new(LlExportTarget.Pdf, exportPath, Path.Combine(Application.StartupPath, "dynamic.json"))
                    {
                        ShowResult = true
                    };

                    LL.Export(exportConf);
                }

            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //D: Hinweis: Beim Verwenden der List & Label DOM Klassen ist zu beachten, dass die einzelnen Eigenschafts-Werte als Zeichenkette angegeben werden           
        //	   müssen. Dies ist notwendig um ein Höchstmaß an Flexibilität zu gewährleisten, da somit auch List & Label Formeln erlaubt sind.

        //US: Hint: When using List & Label DOM classes please note that the property values have to be passed as strings. This is necessary to ensure a
        //		 maximum of flexibility - om this way, List & Label formulas can be used as property values.
        private void GenerateLLProject()
        {
            try
            {
                //D: Neues DOM-Projekt vom Typen LlProject.List erzeugen, Projektnamen und Zugriffsoptionen setzen
                //US: Create new DOM project, type LlProject.List, set project name and access options
                using var proj = LL.OpenProject(Path.Combine(Application.StartupPath, "dynamic.json"), LlDomFileMode.Create, LlDomAccessMode.ReadWrite, LlProject.List) ?? throw new ListLabelException("Project cannot be opened.");

                //D: Standardschrift und -größe setzen
                //US: Set default font and size
                proj.Settings.DefaultFont.FaceName = "Calibri";
                proj.Settings.DefaultFont.Size = "12";

                //D: Designschema setzen
                //US: Set design scheme
                proj.ProjectParameters["LL.DesignScheme"].Contents = "\"COMBITCOLORWHEEL\"";

                //D: Eine neue Projektbeschreibung zuweisen
                //US: Assign new project description
                proj.ProjectParameters["LL.ProjectDescription"].Contents = textBox1.Text;

                //D: Ein leeres Text Objekt erstellen
                //US: Create an empty text object
                ObjectText llobjText = new(proj.Objects);

                //D: Auslesen der Seitenkoordinaten der ersten Seite
                //US: Get the coordinates for the first page
                Size pageExtend = proj.Regions[0].Paper.Extent.Get();

                //D: Setzen von Eigenschaften für das Textobjekt. Alle Einheiten sind SCM (1/1000 mm).
                //US: Set some properties for the text object. All units are SCM (1/1000 mm).
                llobjText.Position.Set(10000, 10000, pageExtend.Width - 65000, 27000);

                //D: Hinzufügen eines Absatzes und setzen diverser Eigenschaften
                //US: Add a paragraph to the text object and set some properties
                Paragraph llobjParagraph = new(llobjText.Paragraphs)
                {
                    Contents = string.Format("\"{0}\"", textBox1.Text)
                };
                llobjParagraph.Font.Bold = "True";

                //D: Hinzufügen eines Grafikobjekts
                //US: Add a drawing object
                ObjectDrawing llobjPic = new(proj.Objects);
                llobjPic.Source.FileInfo.FileName = textBox2.Text;
                llobjPic.Position.Set(pageExtend.Width - 50000, 10000, pageExtend.Width - (pageExtend.Width - 40000), 27000);

                //D: Hinzufügen eines Tabellencontainers und setzen diverser Eigenschaften
                //US: Add a table container and set some properties
                ObjectReportContainer container = new(proj.Objects);
                container.Position.Set(10000, 40000, pageExtend.Width - 20000, pageExtend.Height - 44000);

                //D: In dem Tabellencontainer eine Tabelle hinzufügen
                //US: Add a table into the table container
                SubItemTable table = new(container.SubItems)
                {
                    //D: Gewünschte Tabelle als Datenquelle setzen
                    //US: Set required source table
                    TableId = comboBoxTable.Text
                };

                //D: Zebramuster für Tabelle definieren
                //US: Define zebra pattern for table
                table.LineOptions.Data.ZebraPattern.Style = "1";
                table.LineOptions.Data.ZebraPattern.Pattern = "1";
                table.LineOptions.Data.ZebraPattern.Color = "LL.Scheme.BackgroundColor0";

                //D: Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
                //US: Add a new data line including all selected fields
                TableLineData tableLineData = new(table.Lines.Data);
                TableLineHeader tableLineHeader = new(table.Lines.Header);

                foreach (string fieldName in ListBox2.Items)
                {
                    string fieldWidth = (Convert.ToInt32(container.Position.Width) / ListBox2.Items.Count).ToString();

                    //D: Kopfzeile definieren
                    //US: Define header line
                    TableFieldText header = new(tableLineHeader.Fields)
                    {
                        Contents = string.Format("\"{0}\"", fieldName)
                    };
                    header.Filling.Style = "1";
                    header.Filling.Color = "LL.Scheme.BackgroundColor2";
                    header.Font.Bold = "True";
                    header.Font.Color = "LL.Color.White";
                    header.Width = fieldWidth;

                    //D: Datenzeile definieren
                    //US: Define data line
                    TableFieldBase tableField;

                    if (_dataSet!.Tables[comboBoxTable.Text]!.Columns[fieldName]!.DataType == typeof(System.Byte[]))
                    {
                        tableField = new TableFieldDrawing(tableLineData.Fields)
                        {
                            Contents = comboBoxTable.Text + "." + fieldName
                        };
                    }
                    else
                    {
                        tableField = new TableFieldText(tableLineData.Fields)
                        {
                            Contents = comboBoxTable.Text + "." + fieldName
                        };
                    }

                    tableField.Width = fieldWidth;
                    tableField.Filling.Pattern = "0";

                }

                //D: Projekt speichern
                //US: Save project
                proj.Save();

            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void ComboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //D: Alle Felder aus der Liste löschen
            //US: Clear all fields from the list
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();

            //D: Alle verfügbaren Felder in die ListBox einfügen
            //US: Add all available fields into the listbox
            foreach (DataColumn col in _dataSet!.Tables[comboBoxTable.Text]!.Columns)
                ListBox1.Items.Add(col.ColumnName);
        }

        private void SelectField_Click(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                while (ListBox1.SelectedItems.Count > 0)
                {
                    ListBox2.Items.Add(ListBox1.SelectedItems[0]!);
                    ListBox1.Items.Remove(ListBox1.SelectedItems[0]!);
                }
            }
            else if (sender == button2)
            {
                while (ListBox2.SelectedItems.Count > 0)
                {
                    ListBox1.Items.Add(ListBox2.SelectedItems[0]!);
                    ListBox2.Items.Remove(ListBox2.SelectedItems[0]!);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = textBox2.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox2.Text = openFileDialog1.FileName;
        }

        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = ListBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                button1.PerformClick();
            }
        }

        private void ListBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = ListBox2.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                button2.PerformClick();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using combit.Reporting;
using combit.Reporting.DataProviders;
using combit.Reporting.Dom;
using Microsoft.Win32;

namespace DataGridView
{
    public partial class Form1 : Form
    {
        private DataSet _myDataSet;
        private List<string> _invisibleColumns = new List<string>();

        public Form1()
        {
            InitializeComponent();
            InitDataSet();
        }

        private void InitDataSet()
        {
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            string databasePath = String.Empty;
            if (installKey != null)
            {
                databasePath = (string)installKey.GetValue("NWINDPath", "");
            }
            if (databasePath.Length == 0)
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath;
            OleDbConnection myOledbConnection = new OleDbConnection(connectionString);

            myOledbConnection.Open();

            DataTable table = myOledbConnection.GetSchema("Tables");

            string tableName;
            _myDataSet = new DataSet();

            //D:  Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tables and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                if (dr["TABLE_TYPE"].ToString() == "TABLE")
                {
                    tableName = dr["Table_Name"].ToString();
                    OleDbDataAdapter dataAdapter;

                    //D:  Die "Orders" und "Order Details" Tabelle einschränken.
                    //US: Limit the "Order" and "Order Details" table. 
                    if (tableName == "Orders" || tableName == "Order Details")
                        dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "] WHERE OrderID > 11040", myOledbConnection));
                    else
                        dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", myOledbConnection));


                    if (tableName == "Order Details")
                        tableName = tableName.Replace(" ", "_");

                    dataAdapter.FillSchema(_myDataSet, SchemaType.Source, tableName);
                    dataAdapter.Fill(_myDataSet, tableName);
                }
            }

            //D:  Verbindung schliessen
            //US: Close connection
            myOledbConnection.Close();

            //D:  Alle verfügbaren Tabellen in das Control schreiben
            //US: Add all available tables to combobox control
            foreach (DataTable dt in _myDataSet.Tables)
                cbTable.Items.Add(dt.TableName);

            //D:  Ersten Eintrag selektieren
            //US: Select first entry
            cbTable.SelectedIndex = 0;
        }

        //D: Hinweis: Beim Verwenden der List & Label DOM Klassen ist zu beachten, dass die einzelnen Eigenschafts-Werte als Zeichenkette angegeben werden           
        //	   müssen. Dies ist notwendig um ein Höchstmaß an Flexibilität zu gewährleisten, da somit auch List & Label Formeln erlaubt sind.

        // US: Hint: When using List & Label DOM classes please note that the property values have to be passed as strings. This is necessary to ensure a
        // maximum of flexibility - om this way, List & Label formulas can be used as property values.
        private void GenerateLLProject()
        {
            try
            {
                //D:  Neues DOM-Projekt vom Typen LlProject.List erzeugen
                //US: Create new DOM project, type LlProject.List
                using (ProjectList proj = new ProjectList(LL))
                {
                    //D:  Dateinamen und Dateizugriffsoptionen setzen
                    //US: Set file name and file access options
                    proj.Open(Path.Combine(Application.StartupPath, "dynamic.lst"), LlDomFileMode.Create, LlDomAccessMode.ReadWrite);

                    //D: Standardschrift und -größe setzen
                    //US: Set default font and size
                    proj.Settings.DefaultFont.FaceName = "\"Calibri\"";
                    proj.Settings.DefaultFont.Size = "12";

                    //D: Designschema setzen
                    //US: Set design scheme
                    proj.ProjectParameters["LL.DesignScheme"].Contents = "\"COMBITCOLORWHEEL\"";


                    //D:  Eine neue Projektbeschreibung zuweisen
                    //US: Assign new project description
                    proj.ProjectParameters["LL.ProjectDescription"].Contents = tbDescription.Text;

                    //D:  Default-Ausgabeziel setzen
                    //US: set default export target
                    proj.Settings.DefaultDestination = "PRV";

                    //D:  Auslesen der Seitenkoordinaten der ersten Seite
                    //US: Get the coordinates for the first page
                    Size pageExtend = proj.Regions[0].Paper.Extent.Get();
                    float pageWidth = pageExtend.Width - 15000;

                    //D:  Hinzufügen eines Berichtscontainers und setzen diverser Eigenschaften
                    //US: Add a report container and set some properties
                    ObjectReportContainer container = new ObjectReportContainer(proj.Objects);
                    container.Position.Set(7500, 5000, (int)pageWidth, pageExtend.Height - 10000);

                    //D:  In dem Berichtscontainer eine Tabelle hinzufügen
                    //US: Add a table into the report container
                    SubItemTable table = new SubItemTable(container.SubItems);

                    //D:  Gewünschte Tabelle als Datenquelle setzen
                    //US: Set required source table
                    table.TableId = cbTable.Text;

                    //D:  Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
                    //US: Add a new data line including all selected fields
                    TableLineHeader tableLineHeader = new TableLineHeader(table.Lines.Header);
                    TableLineData tableLineData = new TableLineData(table.Lines.Data);

                    //D:  Aktuelle DPI holen
                    //US: Get current DPI
                    int currentDPI = 0;
                    using (Graphics g = this.CreateGraphics())
                    {
                        currentDPI = (int)g.DpiX;
                    }

                    double fieldWidth;

                    bool onlyVisibleColumns = false;
                    if (cbOnlyDisplayableColumns.Checked)
                        onlyVisibleColumns = true;

                    //D:  Im ersten Durchlauf den Multiplikator berechnen, im zweiten die Tabelle
                    //US: Calculate the multiplicator at first pass, on second pass create the table

                    double allFieldsWidth = 0, multiplicator = 1, completeFieldWidth = 0;
                    for (int pass = 1; pass <= 2; pass++)
                    {
                        foreach (DataGridViewColumn dataColumn in dgvData.Columns)
                        {
                            //D:  Sollte die Spalte auf unsichtbar gestellt sein, dann ignorieren
                            //US: If the column is invisisble -> ignore it
                            if (dataColumn.Visible)
                            {
                                //D:  Spaltenbreite berechnen
                                //US: Calculate the columnwidth
                                fieldWidth = ((dataColumn.Width * 2.54) / currentDPI) * 10000;

                                completeFieldWidth += fieldWidth;
                                if ((completeFieldWidth <= pageWidth) || !onlyVisibleColumns)
                                {
                                    if (pass == 1)
                                        allFieldsWidth += fieldWidth;
                                    else
                                        AddHeaderAndData(tableLineHeader, tableLineData, dataColumn, (fieldWidth * multiplicator).ToString());

                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        completeFieldWidth = 0;
                        multiplicator = pageWidth / allFieldsWidth;
                    }

                    //D:  Projekt speichern
                    //US: Save project
                    proj.Save();
                }
            }
            catch (ListLabelException LlException)
            {
                //D:  Exception abfangen
                //US: Catch exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddHeaderAndData(TableLineHeader tableLineHeader, TableLineData tableLineData, DataGridViewColumn dataColumn, string fieldWidth)
        {
            //D:  Kopfzeile definieren
            //US: Define header line
            TableFieldText header = new TableFieldText(tableLineHeader.Fields);
            header.Contents = string.Format("\"{0}\"", dataColumn.Name);
            header.Filling.Style = "1";
            header.Filling.Color = "LL.Scheme.BackgroundColor2";
            header.Font.Bold = "True";
            header.Font.Color = "LL.Color.White";
            header.Width = fieldWidth;

            //D:  Datenzeile definieren
            //US: Define data line
            TableFieldText tableField = new TableFieldText(tableLineData.Fields);
            tableField.Contents = cbTable.Text + "." + dataColumn.Name;
            tableField.Width = fieldWidth;
            tableField.Filling.Pattern = "0";
        }

        private void BtnDesign_Click(object sender, EventArgs e)
        {
            try
            {
                //D:  Provider für List & Label erstellen
                //US: Create provider for List & Label
                AdoDataProvider provider = new AdoDataProvider(GetDataTable());

                //D:  An den Provider binden
                //US: Bind to provider
                LL.DataSource = provider;
                LL.AutoShowPrintOptions = true;

                //D:  List & Label Projekt anhand Einstellungen erstellen
                //US: Create List & Label project based on the settings
                GenerateLLProject();

                //D:  Designer aufrufen
                //US: Call the designer
                LL.Design(LlProject.List, Path.Combine(Application.StartupPath, "dynamic.lst"));
            }
            catch (ListLabelException LlException)
            {
                //D:  Exception abfangen
                //US: Catch exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            _invisibleColumns.Clear();
            FillDataGridView(cbTable.Text);
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void FillDataGridView(string tableName)
        {
            //D:  Alle Einträge enfernen
            //US: Remove all entries
            if (dgvData.RowCount != 0 || dgvData.ColumnCount != 0)
            {
                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
            }

            DataTable dataTable = _myDataSet.Tables[tableName];

            //D:  Alle Spalten dem DataGridView hinzufügen
            //US: Add all columns to DataGridView
            foreach (DataColumn dc in dataTable.Columns)
            {
                //D:  Wenn der Datentyp string ist, soll eine Textspalte hinzugefügt werden
                //US: If the data type is string, add a text column
                if (dc.DataType.ToString() != "System.Byte[]")
                {
                    DataGridViewColumn column = new DataGridViewColumn();
                    column.Name = dc.ToString();
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    dgvData.Columns.Add(column);
                }
                //D:  Wenn der Datentyp byte ist, soll eine Bilderspalte hinzugefügt werden
                //US: If the data type is byte, add an image column
                else
                {
                    // Bug with .NET Core and Byte[] / Base64 to Image
                    DataGridViewImageColumn column = new DataGridViewImageColumn();
                    column.Name = dc.ToString();
                    column.CellTemplate = new DataGridViewImageCell();
                    dgvData.Columns.Add(column);
                }
            }

            //D:  Alle Reihen dem DataGridView hinzufügen
            //US: Add all rows to the DataGridView
            foreach (DataRow dr in dataTable.Rows)
            {
                object[] objectArray = dr.ItemArray;
                dgvData.Rows.Add(objectArray);
            }


        }

        private DataTable GetDataTable()
        {

            DataTable dataTable = new DataTable(cbTable.Text);
            int invisibleColumns = 0;

            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                if (column.Visible)
                {
                    if (column.CellTemplate.ToString().Contains("DataGridViewImageCell"))
                        dataTable.Columns.Add(column.Name, typeof(Byte[]));
                    else
                        dataTable.Columns.Add(column.Name);
                }
                else
                    invisibleColumns++;
            }

            int row = 0, dgvColumnCount = dataTable.Columns.Count + invisibleColumns;
            foreach (DataGridViewRow dgvrow in dgvData.Rows)
            {
                dataTable.Rows.Add();
                DataRow dr = dataTable.Rows[row];
                for (int i = 0; i < dgvColumnCount; i++)
                {
                    if (dgvrow.Cells[i].Visible)
                    {
                        if (dgvrow.Cells[i].ValueType.ToString() == "System.Drawing.Image")
                        {
                            if (dgvrow.Cells[i].Value != null && !(dgvrow.Cells[i].Value.ToString().Contains("Bitmap")))
                            {
                                dr[dgvrow.Cells[i].OwningColumn.Name] = dgvrow.Cells[i].Value;
                            }
                        }
                        else
                        {
                            dr[dgvrow.Cells[i].OwningColumn.Name] = dgvrow.Cells[i].Value;
                        }
                    }
                }
                row++;
            }
            return dataTable;
        }

        private void DgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsRightClick.Items.Clear();
                //D:  Für jede Spalte eine Checkbox erstellen
                //US: Create check box for each column
                foreach (DataGridViewColumn col in dgvData.Columns)
                {
                    CheckBox cb = new CheckBox();
                    cb.Name = col.Name + "";
                    cb.Text = col.Name + "    ";
                    cb.BackColor = Color.White;
                    //D:  Wenn die Spalte sichtbar ist, Checkbox checken
                    //US: If column is visible, check the checkbox
                    cb.Checked = !_invisibleColumns.Contains(col.Name);

                    cb.Click += new EventHandler(Cb_Clicked);
                    ToolStripControlHost ch = new ToolStripControlHost(cb);
                    cmsRightClick.Items.Add(ch);

                }
                cmsRightClick.Show(Cursor.Position);
                cmsRightClick.Refresh();
            }
        }

        void Cb_Clicked(object sender, System.EventArgs e)
        {
            CheckBox clickedCombobox = ((CheckBox)sender);

            if (clickedCombobox.Checked)
            {
                dgvData.Columns[clickedCombobox.Name].Visible = true;
                _invisibleColumns.Remove(clickedCombobox.Name);
            }
            else
            {
                dgvData.Columns[clickedCombobox.Name].Visible = false;
                _invisibleColumns.Add(clickedCombobox.Name);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //D:  Provider für List & Label erstellen
                //US: Create provider for List & Label
                AdoDataProvider provider = new AdoDataProvider(GetDataTable());

                //D:  An den provider binden
                //US: Bind to provider
                LL.DataSource = provider;
                LL.AutoShowPrintOptions = true;
                
                //D:  List & Label Projekt anhand Einstellungen erstellen
                //US: Create List & Label project based on the settings
                GenerateLLProject();

                //D:  Drucken
                //US: Print
                LL.Print(LlProject.List, Path.Combine(Application.StartupPath, "dynamic.lst"));
            }
            catch (ListLabelException LlException)
            {
                //D:  Exception abfangen
                //US: Catch exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

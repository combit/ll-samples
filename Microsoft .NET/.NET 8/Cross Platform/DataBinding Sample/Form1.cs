using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml;
using combit.Reporting;
using combit.Reporting.DataProviders;
using DataBind.GenericList;
using Microsoft.Win32;
using System.Threading;
using static Antlr4.Runtime.Atn.SemanticContext;
using System.Configuration.Provider;
using System.Xml.Linq;



namespace DataBinding
{
    public partial class Form1 : Form
    {
        private string _databasePath;
        private string _xmlFile;

        public Form1()
        {
            InitializeComponent();
            LL = new ListLabel();

            //D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbank- und XML-Pfad auslesen
            //US: Set path to main sample path, read database- and xml-path
            Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\..\..\..\..\Report Files\Cross Platform");
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            if (installKey != null)
            {
                _databasePath = (string)installKey.GetValue("NWINDPath", string.Empty);
                _xmlFile = Path.Combine(installKey.GetValue("LL" + LL.GetMajorVersion() + "SampleDir").ToString(), "Microsoft .NET\\Report Files\\sampledata.xml");
            }

            if (string.IsNullOrEmpty(_databasePath) || !File.Exists(_databasePath))
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");

            if (string.IsNullOrEmpty(_xmlFile) || !File.Exists(_xmlFile))
                MessageBox.Show("Unable to find sampledata.xml. Make sure List & Label is installed correctly.", "List & Label");
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT Customers.CompanyName, Orders.CustomerID from Customers, Orders WHERE Orders.CustomerID=Customers.CustomerID AND Orders.OrderID > 11040", conn);
            OleDbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
                cbCustomerNames.Items.Add(new ItemClass(dr[0].ToString(), dr[1].ToString()));
        }

        private void EnableButtons(bool enableButtons)
        {

            // get all controls of the form
            foreach (Control control in this.Controls)
            {
                // look at the tab control with its sub pages
                if (control is TabControl == false)
                    continue;

                // get all tab pages
                foreach (TabPage tabPage in (control as TabControl).Controls)
                {
                    // get all controls of the sub page
                    foreach (Control controlInTabControl in tabPage.Controls)
                    {
                        // get all buttons of the sub page
                        foreach (Control innerControlInTabControl in controlInTabControl.Controls)
                        {
                            if (innerControlInTabControl is Button)
                            {
                                (innerControlInTabControl as Button).Enabled = enableButtons;
                            }
                        }
                    }
                }
            }
        }

        private DataTable CreateDataTable()
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Products INNER JOIN Categories ON (Products.CategoryID=Categories.CategoryID)", conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable("Products");
            adapter.FillSchema(dt, SchemaType.Source);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        private DataView CreateDataView()
        {
            return CreateDataTable().DefaultView;
        }

        private OleDbCommand CreateOleDbCommand()
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Products INNER JOIN Categories ON (Products.CategoryID=Categories.CategoryID)", conn);
            conn.Close();
            return cmd;
        }

        private DataSet CreateDataSet()
        {
            DataSet ds = new System.Data.DataSet();

            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);

            conn.Open();

            DataTable table = conn.GetSchema("Tables");

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tabels and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                if (dr["TABLE_TYPE"].ToString() == "TABLE")
                {
                    string tableName = dr["Table_Name"].ToString();
                    OleDbDataAdapter dataAdapter;

                    //D: Die "Orders" und "Order Details" Tabelle einschränken.
                    //US: Limit the "Order" an "Order Details" table.
                    //if (tableName == "Orders" || tableName == "Order Details")
                    //    dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "] WHERE OrderID > 11040", conn));
                    //else
                    dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", conn));

                    dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                    dataAdapter.Fill(ds, tableName);
                }

            }

            List<string> childTables = new List<string>() { "Products", "Orders", "Orders", "Order Details", "Order Details", "Orders", "Products" };
            List<string> childCols = new List<string>() { "CategoryID", "CustomerID", "EmployeeID", "OrderID", "ProductID", "ShipVia", "SupplierID" };
            List<string> parentTables = new List<string>() { "Categories", "Customers", "Employees", "Orders", "Products", "Shippers", "Suppliers" };
            List<string> parentCols = new List<string>() { "CategoryID", "CustomerID", "EmployeeID", "OrderID", "ProductID", "ShipperID", "SupplierID" };
            List<string> relationNames = new List<string>() { "Categories2Products", "Customers2Orders", "Employees2Orders", "Orders2Order Details", "Products2Order Details", "Shippers2Orders", "Suppliers2Products" };

            //D: Relationen auslesen
            //US: Get relations
            for (int i = 0; i < relationNames.Count; i++)
            {
                ds.Relations.Add(new DataRelation(relationNames[i], ds.Tables[parentTables[i]].Columns[parentCols[i]], ds.Tables[childTables[i]].Columns[childCols[i]]));
            }

            //D: Verbindung schliessen
            //US: Close connection
            conn.Close();

            return (ds);
        }

        private DataSet CreateDataSetGantt()
        {
            DataSet ds = new DataSet();
            string dbPath = Path.GetDirectoryName(_databasePath);

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + "\\gantt.mdb");
            conn.Open();

            DataTable table = conn.GetSchema("Tables");

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tables and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                if (dr["TABLE_TYPE"].ToString() == "TABLE")
                {
                    string tableName = dr["Table_Name"].ToString();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", conn));
                    dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                    dataAdapter.Fill(ds, tableName);
                }
            }

            //D: Verbindung schliessen
            //US: Close connection
            conn.Close();

            return ds;
        }

        private DataProviderCollection CreateProviderCollection(bool useDataViewManager)
        {
            DataSet ds = CreateDataSet();
            DataSet dataSetGantt = CreateDataSetGantt();
            CsvDataProvider provider = new CsvDataProvider(Application.StartupPath + @"\..\..\..\..\..\..\Report Files\Sales.csv", true);

            //D:Daten je nach Auswahl in einer Datenquelle kombinieren
            //US:combine data to one datasource
            DataProviderCollection providerCollection = new DataProviderCollection();
            providerCollection.Add(provider);

            if (!useDataViewManager)
            {
                providerCollection.Add(new AdoDataProvider(ds));
                providerCollection.Add(new AdoDataProvider(dataSetGantt));
            }
            else
            {
                DataViewManager dvm = new DataViewManager(ds);
                DataViewManager dataViewManagerGantt = new DataViewManager(dataSetGantt);

                //D: Filter
                //US: Filter
                if (cbCustomerNames.Text != string.Empty)
                {
                    ItemClass selectedItem = (ItemClass)cbCustomerNames.SelectedItem;

                    //D: Für den Fall, dass der Filter der eingegeben wurde in der Collection nicht gefunden werden kann, wird eine Fehlermeldung ausgegeben, und null zurückgegeben.
                    //US: In case the filter is invalid, and therefore cannot be found inside the Collection, show an error message, and return null.

                    if (selectedItem == null)
                    {
                        MessageBox.Show("The entered Filter is invalid. Please check, correct and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    dvm.DataViewSettings["Customers"].RowFilter = "CustomerID='" + selectedItem.Value + "'";
                }
                providerCollection.Add(new AdoDataProvider(dvm));
                providerCollection.Add(new AdoDataProvider(dataViewManagerGantt));
            }

            return (providerCollection);
        }

        private string GetFilePathFromDialog(string filter, string initialFileName = "", string defaultFileName = "")
        {
            // Use defaultFileName if it's provided, otherwise fall back to initialFileName
            string fileName = !string.IsNullOrEmpty(defaultFileName) ? defaultFileName : initialFileName;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = filter,
                FileName = fileName, // Use (either defaultFileName or initialFileName)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }

        private void Print_DataSet_Click(object sender, EventArgs e)
        {
            try
            {
                // D: Schaltflächen deaktivieren  
                // US: Disable buttons  
                EnableButtons(false);

                // D: Datenquelle erstellen  
                // US: Create data source  
                DataProviderCollection providerCollection = CreateProviderCollection(false);

                // D: Projektdatei abrufen  
                // US: Get project file  
                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "Unterberichte und Relationen.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export als PDF  
                    // US: Export as PDF  
                    ExportToPdf(projectFile, providerCollection, string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing DataSet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable buttons  
                EnableButtons(true);
            }
        }

        private void Print_XML_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButtons(false);
                XmlDocument xmlDocument = new XmlDocument();

                // D: XML-Datei laden  
                // US: Load XML file  
                xmlDocument.Load(_xmlFile);

                // D: XML-Datenquelle erstellen  
                // US: Create XML data source  
                XmlDataProvider provider = new XmlDataProvider(xmlDocument);

                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "InvoiceList.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    ExportToPdf(projectFile, provider, string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableButtons(true);
            }
        }

        private void Print_Reader_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButtons(false);

                // D: Datenbankbefehl erstellen  
                // US: Create database command  
                OleDbCommand cmd = CreateOleDbCommand();

                // D: Datenanbieter für das Kommando erstellen  
                // US: Create data provider for the command  
                DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
                provider.AddCommand(cmd, "Products");

                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "simple.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    ExportToPdf(projectFile, provider, "Products");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing Reader: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableButtons(true);
            }
        }

        private void Print_DataView_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButtons(false);

                // D: DataView erstellen  
                // US: Create DataView  
                DataView dv = CreateDataView();

                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "simple.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    ExportToPdf(projectFile, dv, string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing DataView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableButtons(true);
            }
        }

        private void Print_DataTable_Click(object sender, EventArgs e)
        {
            try
            {
                // D: Schaltflächen deaktivieren  
                // US: Disable buttons  
                EnableButtons(false);

                // D: Datenquelle erstellen  
                // US: Create data source  
                DataProviderCollection providerCollection = CreateProviderCollection(false);
                DataTable dt = CreateDataTable();

                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "simple.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export als PDF  
                    // US: Export as PDF  
                    ExportToPdf(projectFile, dt, "products");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing DataTable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable buttons  
                EnableButtons(true);
            }
        }

        private void Print_DataViewManager_Click(object sender, EventArgs e)
        {
            try
            {
                // D: Schaltflächen deaktivieren  
                // US: Disable buttons  
                EnableButtons(false);

                // D: Datenquelle erstellen  
                // US: Create data source  
                DataProviderCollection providerCollection = CreateProviderCollection(true);

                if (providerCollection == null)
                {
                    // D: Schaltflächen aktivieren und abbrechen  
                    // US: Enable buttons and return  
                    EnableButtons(true);
                    return;
                }

                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "Unterberichte und Relationen.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export als PDF  
                    // US: Export as PDF  
                    ExportToPdf(projectFile, providerCollection, string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during export: " + ex.Message);
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable buttons  
                EnableButtons(true);
            }
        }

        private void Print_GenericList_Click(object sender, EventArgs e)
        {
            try
            {
                // D: Schaltflächen deaktivieren  
                // US: Disable buttons  
                EnableButtons(false);

                // D: Generische Liste von Kunden erstellen  
                // US: Create generic list of customers  
                List<Customer> customerList = GenericList.GetGenericList();
                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "genericlist.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export als PDF  
                    // US: Export as PDF  
                    ExportToPdf(projectFile, customerList, string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during export: " + ex.Message);
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable buttons  
                EnableButtons(true);
            }
        }

        private void Print_SQL_Click(object sender, EventArgs e)
        {
            try
            {
                // D: Schaltflächen deaktivieren  
                // US: Disable buttons  
                EnableButtons(false);

                // D: SQL-Verbindung erstellen  
                // US: Create SQL connection  
                SqlConnection conn = new SqlConnection(tbConnectionString.Text);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // D: SQL-Datenanbieter erstellen  
                // US: Create SQL data provider  
                SqlConnectionDataProvider prov = new SqlConnectionDataProvider(conn);
                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "Unterberichte und Relationen.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Datenquelle und -mitglied festlegen  
                    // US: Set data source and data member  
                    LL.DataSource = prov;
                    LL.DataMember = string.Empty;

                    // D: Export als PDF  
                    // US: Export as PDF  
                    ExportToPdf(projectFile, prov, string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during export: " + ex.Message);
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable buttons  
                EnableButtons(true);
            }
        }

        private void PrintOdataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButtons(false);

                // Get the project file using the dialog
                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "OData sub reports and relations.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // Use the project file and the OData URL
                    ODataDataProvider provider = new ODataDataProvider(odataUrlTb.Text, false);
                    LL.DataSource = provider;
                    LL.DataMember = string.Empty;

                    // D: Export als PDF  
                    // US: Export as PDF
                    ExportToPdf(projectFile, provider, string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during export: " + ex.Message);
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable buttons  
                EnableButtons(true);
            }

        }

        private void RestPrintBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // D: Schaltflächen deaktivieren  
                // US: Disable buttons  
                EnableButtons(false);

                // D: REST-Datenanbieter erstellen  
                // US: Create REST data provider  
                RestDataProvider provider = new RestDataProvider(restUrlTb.Text);

                // D: Projektdatei mit Dialog öffnen und auswählen  
                // US: Open project file using the dialog
                string projectFile = GetFilePathFromDialog("List & Label Project Files (*.json)|*.json", "REST.json");

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Datenquelle festlegen  
                    // US: Set data source  
                    LL.DataSource = provider;
                    LL.DataMember = string.Empty;

                    // D: Export als PDF  
                    // US: Export as PDF  
                    ExportToPdf(projectFile, provider, string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during export: " + ex.Message);
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable buttons  
                EnableButtons(true);
            }
        }


        private void ExportToPdf(string projectFile, object dataSource, string dataMember)
        {
            try
            {
                // D: DataSource und DataMember festlegen  
                // US: Set data source and data member  
                LL.DataSource = dataSource;
                LL.DataMember = dataMember;

                // D: Speichern-Dialog öffnen  
                // US: Open save file dialog  
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    Title = "Save Report as PDF",
                    FileName = Path.GetFileName(projectFile).Replace(".json", ".pdf")

                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // D: Exportpfad setzen  
                    // US: Set export path  
                    string exportPath = saveFileDialog.FileName;

                    // D: Export-Konfiguration erstellen  
                    // US: Create export configuration  
                    ExportConfiguration exportConfig = new ExportConfiguration(LlExportTarget.Pdf, exportPath, projectFile)
                    {
                        // D: Ergebnis anzeigen
                        // US: Show result
                        ShowResult = true

                    };

                    // D: Export ausführen  
                    // US: Perform export  
                    LL.Export(exportConfig);
                }

            }
            catch (ListLabelException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    class ItemClass
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ItemClass(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}

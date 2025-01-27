using combit.Reporting;
using combit.Reporting.DataProviders;
using Microsoft.Win32;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Repository
{
    public partial class Form1 : Form
    {
        private readonly string _fileRepo = Path.Combine(Application.StartupPath + @"\..\..\..\App_Data\repository.db");
        private readonly string _databasePath;

        public Form1()
        {
            InitializeComponent();

            //D: Icon für Anwendung setzen. Wird auch für die Elementsammlung-Dialog vewendet.
            //Us: Set icon for application. Is also used for the repository dialog.
            this.Icon = new Icon(Application.StartupPath + @"\..\..\..\ll.ico");

            //D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbank- und XML-Pfad auslesen
            //US: Set path to main sample path, read database- and xml-path
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            if (installKey != null)
            {
                _databasePath = (string)installKey.GetValue("NWINDPath", string.Empty);
            }

            if (string.IsNullOrEmpty(_databasePath) || !File.Exists(_databasePath))
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");

        }

        static class CmbtSettings
        {

            public static class LanguageSettings
            {
            //D: Sprache des Windows-Betriebssystems abfragen.
            //US: Get the language of the Windows operating system.
            public static string OSLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            //public static string OSLanguage = "de";
            //public static string OSLanguage = "en";

                // D:   Einstellen der Sprache für die Berichte und Designer anhand der Systemsprache.
                // US:  Setting the language for the reports and the Designer depending on the language of the system.
                public static LlLanguage Language
                {
                    get
                    {
                        return OSLanguage == "de" ? LlLanguage.German : LlLanguage.English;
                    }
                }

                // D: Setzen der Einheiten auf Inch oder Millimeter anhand der Systemsprache. SysDefault Werte verwenden für den WebReportDesigner immer Millimeter, um die Synchronisierung zwischen Client und Server zu gewährleisten.
                // US: Set the Unit to Inch or Millimeter depending on the language of the system. SysDefault Values automatically use millimeter in the web report designer context to make sure client and server units are synchronized. 
                public static LlUnits Unit
                {
                    get
                    {
                        return OSLanguage == "de" ? LlUnits.Millimeter_1_100 : LlUnits.Inch_1_1000;
                    }
                }
            }

            public static string RepositoryLanguage
            {
                get
                {
                    return LanguageSettings.Language == LlLanguage.German ? "de" : "en";
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            conn.Open();

            OleDbCommand cmd = new("SELECT DISTINCT Customers.CompanyName, Orders.CustomerID from Customers, Orders WHERE Orders.CustomerID=Customers.CustomerID AND Orders.OrderID > 11040", conn);
            _ = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        private DataSet CreateDataSet()
        {
            DataSet ds = new();

            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            OleDbConnection conn = new("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);

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
                    if (tableName == "Orders" || tableName == "Order Details")
                        dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "] WHERE OrderID > 11040", conn));
                    else
                        dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", conn));

                    dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                    dataAdapter.Fill(ds, tableName);
                }

            }

            List<string> childTables = new() { "Products", "Orders", "Orders", "Order Details", "Order Details", "Orders", "Products" };
            List<string> childCols = new() { "CategoryID", "CustomerID", "EmployeeID", "OrderID", "ProductID", "ShipVia", "SupplierID" };
            List<string> parentTables = new() { "Categories", "Customers", "Employees", "Orders", "Products", "Shippers", "Suppliers" };
            List<string> parentCols = new() { "CategoryID", "CustomerID", "EmployeeID", "OrderID", "ProductID", "ShipperID", "SupplierID" };
            List<string> relationNames = new() { "Categories2Products", "Customers2Orders", "Employees2Orders", "Orders2Order Details", "Products2Order Details", "Shippers2Orders", "Suppliers2Products" };

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
            DataSet ds = new();
            string dbPath = Path.GetDirectoryName(_databasePath);

            OleDbConnection conn = new("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + "\\gantt.mdb");
            conn.Open();

            DataTable table = conn.GetSchema("Tables");

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tables and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                if (dr["TABLE_TYPE"].ToString() == "TABLE")
                {
                    string tableName = dr["Table_Name"].ToString();
                    OleDbDataAdapter dataAdapter = new(new OleDbCommand("SELECT * FROM [" + tableName + "]", conn));
                    dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                    dataAdapter.Fill(ds, tableName);
                }
            }

            //D: Verbindung schliessen
            //US: Close connection
            conn.Close();

            return ds;
        }

        private DataProviderCollection CreateProviderCollection()
        {
            DataSet ds = CreateDataSet();
            DataSet dataSetGantt = CreateDataSetGantt();
            CsvDataProvider provider = new(Application.StartupPath + @"\..\..\..\..\..\..\Report Files\Sales.csv", true);

            //D:Daten je nach Auswahl in einer Datenquelle kombinieren
            //US:combine data to one datasource
            DataProviderCollection providerCollection = new()
            {
                provider,
                new AdoDataProvider(ds),
                new AdoDataProvider(dataSetGantt)
            };

            return (providerCollection);
        }

        private void BtnDesign_Click(object sender, EventArgs e)
        {
            DataProviderCollection providerCollection = CreateProviderCollection();

            using ListLabel ll = new(CmbtSettings.LanguageSettings.Language);

            ll.DataSource = providerCollection;

            // D: Repository-Modus aktivieren
            // US: Activate Repository-mode
            ll.FileRepository = new SQLiteFileRepository(_fileRepo, CmbtSettings.RepositoryLanguage);

            try
            {
                // D: Bearbeitung der Elementsammlung verhindern.
                // US: Prevent editing of the repository.
                //ll.DesignerWorkspace.ProhibitedActions.Add(LlDesignerAction.FileManageRepository);

                //D: Designer aufrufen
                //US: call the designer
                ll.AutoDefineField += Ll_AutoDefineField;

                ll.Design();
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Ll_AutoDefineField(object sender, AutoDefineElementEventArgs e)
        {
            // D: Datum der Northwind-Datensätze in aktuellen Bereich verschieben
            // US: Move Northwind dates to a more current point in time
            if (e.Value != null && e.Value != DBNull.Value && e.FieldType == LlFieldType.Date && e.Name.Contains("Orders"))
            {
                DateTime dt = (DateTime)e.Value;
                int YearOffset = DateTime.Now.Year - 2010 + 14;
                e.Value = new DateTime(dt.Year + YearOffset, Convert.ToInt32(dt.Month), Convert.ToInt32(dt.Day));
            }

            if (e.Name.StartsWith("Sales"))
            {
                e.FieldType = LlFieldType.Numeric;
            }

        }
    }
}


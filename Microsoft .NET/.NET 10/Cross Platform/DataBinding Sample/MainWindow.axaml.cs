using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Controls.Converters;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Platform.Storage;
using Avalonia.VisualTree;

using combit.Reporting;
using combit.Reporting.DataProviders;

using DataBind.GenericList;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

using static Antlr4.Runtime.Atn.SemanticContext;

namespace DataBinding
{
    public partial class MainWindow : Window
    {
        internal ListLabel LL;
        private string? _databasePath = Path.Combine(GetSamplesDirectory(), "northwind.db");
        private string _startPath;
        private string _xmlFile = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "..", "Report Files", "sampledata.xml"));

        public static string GetSamplesDirectory()
        {
            // D: Beispielpfad 
            // US: sample path
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "..", ".."));
        }

        public static string GetReportFilesDirectory()
        {
            // D: Pfad zu den Reportdateien 
            // US: Path to report files
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "..", "Report Files", "Cross Platform"));
        }

        private async Task<string> OpenJsonFileAsync(string defaultFile)
        {
            // D: Datei öffnen-Dialog öffnen, wenn übergebenes Projekt nicht vorhanden ist
            // US: Show File open dialog if report file is not available
            if (File.Exists(defaultFile))
            {
                bool useDefault = true;
                if (useDefault)
                    return defaultFile;
            }

            var files = await this.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                AllowMultiple = false,
                Title = "Select List & Label Project File",
                FileTypeFilter = new[]
                {
            new FilePickerFileType("JSON Files") { Patterns = new[] { "*.json" } }
        }
            });

            return files?.FirstOrDefault()?.Path.LocalPath ?? string.Empty;
        }

        public MainWindow()
        {
            InitializeComponent();

            Console.WriteLine("Starting project");

            LL = new ListLabel();

            if (String.IsNullOrEmpty(_databasePath))
            {
                Console.WriteLine("Unable to find sample database. Make sure List & Label is installed correctly.");
            }

            this.Opened += MainWindow_Opened;

            _startPath = GetReportFilesDirectory();

        }

        private void MainWindow_Opened(object? sender, System.EventArgs e)
        {
            // D: CustomerCombobox für DataViewManager befüllen
            // US: Fill CustomerCombobox for DataViewManager
            LoadCustomersToCombobox();
        }

        private void LoadCustomersToCombobox()
        {
            // D: CustomerCombobox für DataViewManager befüllen
            // US: Fill CustomerCombobox for DataViewManager

            var conn = new SqliteConnection($"Data Source={_databasePath}");
            conn.Open();

            var cmd = new SqliteCommand("SELECT DISTINCT Customers.CompanyName, Orders.CustomerID FROM Customers JOIN Orders ON Orders.CustomerID = Customers.CustomerID WHERE Orders.OrderID > 11040", conn);

            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ComboBoxCustomerNames.Items.Add(new ItemClass(dr[0].ToString()!, dr[1].ToString()!));
            }

            conn.Close();
        }

        private void EnableButton(bool enable)
        {
            EnableButtonRecursive(this, enable);
        }

        private void EnableButtonRecursive(Control control, bool enable)
        {
            if (control is Button btn)
                btn.IsEnabled = enable;

            if (control is ContentControl cc && cc.Content is Control child)
                EnableButtonRecursive(child, enable);

            if (control is Panel panel)
            {
                foreach (var childcontent in panel.Children.OfType<Control>())
                    EnableButtonRecursive(childcontent, enable);
            }
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable("Products");

            using var conn = new SqliteConnection($"Data Source={_databasePath};");
            conn.Open();

            string sqlitequery = @"SELECT * FROM Products INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID";

            using var cmd = conn.CreateCommand();
            cmd.CommandText = sqlitequery;

            using var reader = cmd.ExecuteReader();
            dt.Load(reader);   

            return dt;
        }

        private DataView CreateDataView()
        {
            return CreateDataTable().DefaultView;
        }

        private static void FillTable(SqliteConnection conn, DataSet ds, string tableName, string sql)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            using var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly);

            DataTable table = new(tableName);
            DataTable schemaTable = reader.GetSchemaTable()!;

            foreach (DataRow row in schemaTable.Rows)
            {
                string columnName = row["ColumnName"]!.ToString()!;
                Type dataType = (Type)row["DataType"]!;
                bool allowDBNull = (bool)row["AllowDBNull"]!;

                DataColumn column = new(columnName, dataType)
                {
                    AllowDBNull = allowDBNull
                };

                table.Columns.Add(column);
            }

            reader.Close();

            using var dataReader = cmd.ExecuteReader();
            table.Load(dataReader);

            if (ds.Tables.Contains(tableName))
                ds.Tables.Remove(tableName);

            ds.Tables.Add(table);
        }

        private DataSet CreateDataSet()
        {
            DataSet ds = new();

            using var conn = new SqliteConnection($"Data Source={_databasePath};");
            conn.Open();

            using var schemaCmd = conn.CreateCommand();
            schemaCmd.CommandText =
                "SELECT name FROM sqlite_master " +
                "WHERE type = 'table' " +
                "AND name NOT LIKE 'sqlite_%' " +
                "ORDER BY name;";

            using var schemaReader = schemaCmd.ExecuteReader();

            while (schemaReader.Read())
            {
                string tableName = schemaReader.GetString(0);

                string sql;

                if (tableName == "Orders" || tableName == "Order Details")
                {
                    sql =
                        $"SELECT * FROM \"{tableName}\" " +
                        "WHERE OrderID > 11040 " +
                        "AND OrderID < 11077";
                }
                else if (tableName == "Customers")
                {
                    sql =
                        "SELECT c.* FROM Customers c " +
                        "WHERE EXISTS (" +
                            "SELECT 1 FROM Orders o " +
                            "WHERE o.CustomerID = c.CustomerID " +
                            "AND o.OrderID > 11040 " +
                            "AND o.OrderID < 11077" +
                        ")";
                }
                else
                {
                    sql = $"SELECT * FROM \"{tableName}\" LIMIT 1000";
                }

                FillTable(conn, ds, tableName, sql);
            }


            // Relationen definieren
            string[] childTables = { "Products", "Orders", "Orders", "Order Details", "Order Details", "Orders", "Products" };
            string[] childCols = { "CategoryID", "CustomerID", "EmployeeID", "OrderID", "ProductID", "ShipVia", "SupplierID" };
            string[] parentTables = { "Categories", "Customers", "Employees", "Orders", "Products", "Shippers", "Suppliers" };
            string[] parentCols = { "CategoryID", "CustomerID", "EmployeeID", "OrderID", "ProductID", "ShipperID", "SupplierID" };
            string[] relationNames = { "Categories2Products", "Customers2Orders", "Employees2Orders", "Orders2Order Details", "Products2Order Details", "Shippers2Orders", "Suppliers2Products" };

            for (int i = 0; i < relationNames.Length; i++)
            {
                ds.Relations.Add(
                    new DataRelation(
                        relationNames[i],
                        ds.Tables[parentTables[i]]!.Columns[parentCols[i]]!,
                        ds.Tables[childTables[i]]!.Columns[childCols[i]]!
                    )
                );
            }

            return ds;
        }

        private DataSet CreateDataSetGantt()
        {
            DataSet ds = new DataSet();

            string dbPath = Path.Combine(GetSamplesDirectory(), "gantt.db");

            using var conn = new SqliteConnection($"Data Source={dbPath};");
            conn.Open();

            var tables = new List<string>();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';";

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0)!);
                }
            }

            foreach (var tableName in tables)
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM \"{tableName}\"";

                using var reader = cmd.ExecuteReader();

                DataTable dt = new DataTable(tableName);
                dt.Load(reader);

                ds.Tables.Add(dt);
            }

            return ds;
        }

        private DataProviderCollection CreateProviderCollection(bool useDataViewManager)
        {
            DataSet ds = CreateDataSet();
            DataSet dataSetGantt = CreateDataSetGantt();
            CsvDataProvider provider = new CsvDataProvider(Path.Combine(GetSamplesDirectory(), "Microsoft .NET", "Report Files", "Sales.csv"), true);

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
                if (ComboBoxCustomerNames.Text != string.Empty)
                {
                    ItemClass selectedItem = (ItemClass)ComboBoxCustomerNames.SelectedItem!;

                    //D: Für den Fall, dass der Filter der eingegeben wurde in der Collection nicht gefunden werden kann, wird eine Fehlermeldung ausgegeben, und null zurückgegeben.
                    //US: In case the filter is invalid, and therefore cannot be found inside the Collection, show an error message, and return null.

                    if (selectedItem == null)
                    {
                        Console.WriteLine("The entered Filter is invalid. Please check, correct and try again.", "Error");
                        return null!;
                    }
                    dvm.DataViewSettings["Customers"]!.RowFilter = "CustomerID='" + selectedItem.Value + "'";
                }
                providerCollection.Add(new AdoDataProvider(dvm));
                providerCollection.Add(new AdoDataProvider(dataViewManagerGantt));
            }

            return (providerCollection);
        }

        private async void BtnDataSetPrint_Click(object? sender, RoutedEventArgs e)
        {
            try
            {

                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export
                EnableButton(false);

                //D: An die providerCollection binden
                //US: now bind to the providerCollection 
                DataProviderCollection providerCollection = CreateProviderCollection(false);

                // D: Projektdatei setzen  
                // US: Get project file  
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "Unterberichte und Relationen.json");
                string projectFile = await OpenJsonFileAsync(defaultFile);

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export
                    // US: Export                       
                    await ExportToPdfAsync(this, projectFile, providerCollection, string.Empty);
                }
            }
            catch (ListLabelException ex)
            {
                System.Diagnostics.Debug.WriteLine("Information: " + ex.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable button  
                EnableButton(true);
            }
        }

        private async void BtnXmlPrint_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export
                EnableButton(false);

                XmlDocument xmlDocument = new();

                // D: XML-Datei laden  
                // US: Load XML file  
                xmlDocument.Load(_xmlFile);

                //D: Erstelle ein XmlDataProvider Objekt
                //US: create a XmlDataProvider object
                XmlDataProvider provider = new XmlDataProvider(xmlDocument);

                // D: Projektdatei setzen  
                // US: Get project file 
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "InvoiceList.json");
                string projectFile = await OpenJsonFileAsync(defaultFile);

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export
                    // US: Export   
                    await ExportToPdfAsync(this, projectFile, provider, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error printing XML: {ex.Message}", "Error");
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable button  
                EnableButton(true);
            }
        }

        private async void BtnDataViewManagerPrint_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export 
                EnableButton(false);

                // D: Datenquelle erstellen  
                // US: Create data source  
                DataProviderCollection providerCollection = CreateProviderCollection(true);

                //D: Falls null zurückgegeben wurde, was für den Fall, dass der Filter ungültig sein sollte erwartet wird, wird der Methodenaufruf beendet.
                //US:This stops execution if providerCollection returns null, which is expected, if the Filter the user entered is wrong. Therefore interrupt further execution.
                if (providerCollection == null)
                {
                    // D: Schaltflächen aktivieren und abbrechen  
                    // US: Enable buttons and return  
                    EnableButton(true);
                    return;
                }

                // D: Projektdatei setzen  
                // US: Get project file  
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "Unterberichte und Relationen.json");
                string projectFile = await OpenJsonFileAsync(defaultFile);

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export
                    // US: Export
                    await ExportToPdfAsync(this, projectFile, providerCollection, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Information: " + ex.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
            finally
            {
                // D: Schaltfläche aktivieren  
                // US: Enable button
                EnableButton(true);
            }
        }

        private async void BtnDataViewPrint_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export 
                EnableButton(false);

                // D: DataView erstellen  
                // US: Create DataView  
                DataView dv = CreateDataView();

                // D: Projektdatei setzen  
                // US: Get project file  
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "simple.json");
                string projectFile = await OpenJsonFileAsync(defaultFile);

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export
                    // US: Export
                    await ExportToPdfAsync(this, projectFile, dv, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Information: " + ex.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
            finally
            {
                // D: Schaltfläche aktivieren  
                // US: Enable button
                EnableButton(true);
            }
        }

        private async void BtnDataTablePrint_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export 
                EnableButton(false);

                // D: Datenquelle erstellen  
                // US: Create data source  
                DataProviderCollection providerCollection = CreateProviderCollection(false);
                DataTable dt = CreateDataTable();

                // D: Projektdatei setzen  
                // US: Get project file 
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "simple.json");
                string projectFile = await OpenJsonFileAsync(defaultFile);

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export
                    // US: Export
                    await ExportToPdfAsync(this, projectFile, dt, "products");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Information: " + ex.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
            finally
            {
                // D: Schaltfläche aktivieren  
                // US: Enable button
                EnableButton(true);
            }
        }

        private async void BtnGenericListPrint_Click(object? sender, RoutedEventArgs e)
        {

            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export  
                EnableButton(false);

                //D: Erstelle eine generische Liste
                //US: create a generic lis
                List<Customer> customerList = GenericList.GetGenericList();

                // D: Projektdatei setzen  
                // US: Get project file 
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "GenericList.json");
                string projectFile = await OpenJsonFileAsync(defaultFile);

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Export
                    // US: Export 
                    await ExportToPdfAsync(this, projectFile, customerList, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Information: " + ex.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
            finally
            {
                // D: Schaltfläche aktivieren  
                // US: Enable button
                EnableButton(true);
            }
        }

        private async void BtnSqlServerPrint_Click(object? sender, RoutedEventArgs e)
        {
            //!!!!  IMPORTANT   !!!!
            // D: SqlConnectionDataProvider wird nur auf Windows Plattformen unterstützt
            // US: SqlConnectionDataProvider is only supported on Windows platforms!
            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export  
                EnableButton(false);

                // D: SQL-Verbindung erstellen  
                // US: Create SQL connection  
                SqlConnection conn = new SqlConnection(TextBoxSqlConnectionstring.Text);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // D: SQLConnec erstellen  
                // US: Create SQL data provider  
#pragma warning disable CA1416 // Validate platform compatibility, cause it is only supported on "Windows" platforms
                SqlConnectionDataProvider prov = new SqlConnectionDataProvider(conn);
#pragma warning restore CA1416 // Validate platform compatibility

                // D: Projektdatei setzen  
                // US: Get project file 
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "Unterberichte und Relationen.json");
                string projectFile = await OpenJsonFileAsync(defaultFile);

                if (!string.IsNullOrEmpty(projectFile))
                {
                    // D: Datenquelle und -mitglied festlegen  
                    // US: Set data source and data member  
                    LL.DataSource = prov;
                    LL.DataMember = string.Empty;

                    // D: Export als PDF  
                    // US: Export as PDF  
                    await ExportToPdfAsync(this, projectFile, prov, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Information: " + ex.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
            finally
            {
                // D: Schaltfläche aktivieren  
                // US: Enable button 
                EnableButton(true);
            }
        }

        private async void BtnODataPrint_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export  
                EnableButton(false);

                // D: Projektdatei setzen  
                // US: Get project file 
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "OData sub reports and relations.json");
                string projectFile = await OpenJsonFileAsync(defaultFile);

                if (!string.IsNullOrEmpty(projectFile))
                {
                    //D: Erstelle ein ODataDataProvider Objekt
                    //US: create a ODataDataProvider object
                    ODataDataProvider provider = new ODataDataProvider(TextBoxODataUrl.Text!, false);
                    LL.DataSource = provider;
                    LL.DataMember = string.Empty;

                    // D: Export
                    // US: Export
                    await ExportToPdfAsync(this, projectFile, provider, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Information: " + ex.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable buttons  
                EnableButton(true);
            }
        }

        private async Task ExportToPdfAsync(Window parent, string projectFile, object dataSource, string dataMember)
        {
            try
            {
                // D: DataSource und DataMember festlegen  
                // US: Set data source and data member  
                LL.DataSource = dataSource;
                LL.DataMember = dataMember;

                // D: Speichern-Dialog öffnen  
                // US: Open save file dialog  
                var saveResult = await parent.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
                {
                    SuggestedFileName = Path.GetFileName(projectFile).Replace(".json", ".pdf"),
                    FileTypeChoices = new[]
               {
                new FilePickerFileType("PDF Files")
                {
                    Patterns = new[] { "*.pdf" }
                }
            },
                    Title = "Save Report as PDF"
                });

                if (saveResult == null)
                    return; 

                string exportPath = saveResult.Path.LocalPath;

                // D: ExportConfiguration erstellen
                // US: Create ExportConfiguration
                ExportConfiguration exportConfig = new ExportConfiguration(LlExportTarget.Pdf, exportPath, projectFile)
                {
                    ShowResult = true
                };

                // D: Export durchführen
                // US: Execute export
                LL.Export(exportConfig);
            }
            catch (ListLabelException ex)
            {
                Console.WriteLine(ex.Message);
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
}
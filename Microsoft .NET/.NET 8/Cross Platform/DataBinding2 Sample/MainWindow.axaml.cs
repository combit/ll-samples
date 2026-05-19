using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

using combit.Reporting;

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataBinding2
{
    public partial class MainWindow : Window
    {
        internal ListLabel LL;
        private string? _databasePath = Path.Combine(GetSamplesDirectory(), "northwind.db");        
        private string _startPath;

        public MainWindow()
        {
            InitializeComponent();
            InitDataSet();

            Console.WriteLine("Starting project");

            LL = new ListLabel();

            if (String.IsNullOrEmpty(_databasePath))
            {
                Console.WriteLine("Unable to find sample database. Make sure List & Label is installed correctly.");
            }

            _startPath = GetReportFilesDirectory();

        }

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

        private DataSet InitDataSet()
        {
            DataSet ds = new();

            using var conn = new SqliteConnection($"Data Source={_databasePath};");
            conn.Open();

            string sqlOrders = @"SELECT * FROM ""Orders"" WHERE OrderID > 11040 AND OrderID < 11077";

            using (var cmdOrders = new SqliteCommand(sqlOrders, conn))
            using (var reader = cmdOrders.ExecuteReader())
            {
                DataTable dtOrders = new DataTable("Orders");

                // Create columns based on reader schema, but force the date column to DateTime
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var name = reader.GetName(i);
                    var type = name.Contains("Date", StringComparison.OrdinalIgnoreCase)
                        ? typeof(DateTime)
                        : reader.GetFieldType(i);

                    dtOrders.Columns.Add(name, type);
                }

                dtOrders.Load(reader);
                ds.Tables.Add(dtOrders);
            }

            string sqlOrderDetails = @"
        SELECT od.OrderID,
               od.Quantity,
               od.UnitPrice,
               od.ProductID,
               p.ProductID AS ProductsProductID,
               p.CategoryID,
               p.Discontinued,
               p.ProductName,
               p.QuantityPerUnit,
               p.ReorderLevel,
               p.SupplierID,
               p.UnitPrice AS ProductsUnitPrice,
               p.UnitsInStock,
               p.UnitsOnOrder
        FROM ""Order Details"" od
        INNER JOIN Products p ON od.ProductID = p.ProductID
        WHERE od.OrderID > 11040";

            using (var cmdOrderDetails = new SqliteCommand(sqlOrderDetails, conn))
            using (var reader = cmdOrderDetails.ExecuteReader())
            {
                DataTable dtOrderDetails = new DataTable("Order Details");
                dtOrderDetails.Load(reader);
                ds.Tables.Add(dtOrderDetails);
            }

            DataRelation relation = new DataRelation("Orders2Order Details", ds.Tables["Orders"]!.Columns["OrderID"]!, ds.Tables["Order Details"]!.Columns["OrderID"]!, false);
            ds.Relations.Add(relation);

            return ds;
        }

        private async void BtnInvoiceListPrint_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export
                EnableButton(false);

                using ListLabel LL = new();

                //D: Datenquelle anmelden
                //US: Bind the datasource
                LL.SetDataBinding(InitDataSet(), string.Empty);

                //D: Die order master Daten sollen als Felder angemeldet werden
                //US: we want to have the order master data as fields
                LL.AutoMasterMode = LlAutoMasterMode.AsFields;

                // D: Projektdatei setzen  
                // US: Get project file  
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "inv_lst.json");
                LL.AutoProjectFile = await OpenJsonFileAsync(defaultFile);

                // D: Export
                // US: Export  
                ExportConfiguration exportConfiguration = new ExportConfiguration(LlExportTarget.Pdf, Path.Combine(GetReportFilesDirectory(), Path.GetFileNameWithoutExtension(LL.AutoProjectFile) + ".pdf"), LL.AutoProjectFile);
                exportConfiguration.ShowResult = true;
                LL.Export(exportConfiguration);

                System.Diagnostics.Debug.WriteLine("Export completed successfully.");
            }
            catch (ListLabelException LlException)
            {
                System.Diagnostics.Debug.WriteLine("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }

            catch (Exception ex)
            {
                // Show any other errors
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable button  
                EnableButton(true);
            }
        }

        private async void BtnInvoiceMergePrint_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                using ListLabel LL = new();

                //D: Datenquelle anmelden
                //US: Bind the datasource
                //LL.SetDataBinding(_commandSetDataProvider!, "Orders");
                LL.DataSource = InitDataSet();
                LL.DataMember = "Orders";

                //D: Die order master Daten sollen als Variablen angemeldet werden
                //US: we want to have the order master data as variables
                LL.AutoMasterMode = LlAutoMasterMode.AsVariables;

                // D: Projektdatei setzen  
                // US: Get project file  
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "inv_merg.json");
                LL.AutoProjectFile = await OpenJsonFileAsync(defaultFile);

                //D: ExportConfiguration erzeugen
                //US: create ExportConfiguration
                ExportConfiguration exportConfiguration = new ExportConfiguration(LlExportTarget.Pdf, Path.Combine(GetReportFilesDirectory(), Path.GetFileNameWithoutExtension(LL.AutoProjectFile) + ".pdf"), LL.AutoProjectFile);
                exportConfiguration.ShowResult = true;

                //D: Drucken
                //US: print
                LL.Export(exportConfiguration);

                System.Diagnostics.Debug.WriteLine("Export completed successfully.");

            }
            catch (ListLabelException LlException)
            {
                System.Diagnostics.Debug.WriteLine("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }

            catch (Exception ex)
            {
                // Show any other errors
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable button  
                EnableButton(true);
            }

        }
    }
}
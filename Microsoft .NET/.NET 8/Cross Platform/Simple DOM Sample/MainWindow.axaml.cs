using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

using combit.Reporting;
using combit.Reporting.Dom;

using Irony.Parsing.Construction;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace DOMSimple
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

            this.Opened += MainWindow_Opened;

            _startPath = GetReportFilesDirectory();

        }

        private void MainWindow_Opened(object? sender, System.EventArgs e)
        {
            //D: Alle verfügbaren Tabellen in das Control schreiben
            //US: Add all available tables to the control
            foreach (DataTable dt in InitDataSet()!.Tables)
                ComboboxTables.Items.Add(dt.TableName);

            //D: Ersten Eintrag selektieren
            //US: Select first entry
            ComboboxTables.SelectedIndex = 0;
            ListboxAvailable.SelectedIndex = 0;
                                 
            TextboxSelectLogo.Text = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "..", "Report Files", "logo.bmp"));
        }

        private void ComboboxTables_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            //D: Alle Felder aus der Liste löschen
            //US: Clear all fields from the list
            ListboxAvailable.Items.Clear();
            ListboxSelected.Items.Clear();

            //D: Alle verfügbaren Felder in die ListBox einfügen
            //US: Add all available fields into the listbox
            foreach (DataColumn col in InitDataSet()!.Tables[ComboboxTables.Text]!.Columns)
                ListboxAvailable.Items.Add(col.ColumnName);
        }

        private void ListboxSelected_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            BtnUnselect.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void ListboxAvailable_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            BtnSelect.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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
            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            DataSet ds = new();

            using (var conn = new SQLiteConnection($"Data Source={_databasePath};"))
            {
                conn.Open();

                DataTable schema = conn.GetSchema("Tables");

                //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
                //US: Iterate all tabels and add them to the DataSet
                foreach (DataRow row in schema.Rows)
                {
                    string tableType = row["TABLE_TYPE"].ToString()!;
                    if (tableType != "table" && tableType != "TABLE")
                        continue;

                    string tableName = row["TABLE_NAME"].ToString()!;

                    SQLiteDataAdapter dataAdapter;

                    //D: Die "Customers", "Orders" und "Order Details" Tabelle einschränken.
                    //US: Limit the "Customers", "Orders" and "Order Details" table. 

                    if (tableName == "Orders" || tableName == "Order Details")
                        dataAdapter = new SQLiteDataAdapter($"SELECT * FROM \"{tableName}\" " +
                            "WHERE OrderID > 11040 " +
                            "AND OrderID < 11077",
                            conn);

                    else if (tableName == "Customers")
                    {
                        dataAdapter = new SQLiteDataAdapter(
                            "SELECT c.* FROM Customers c " +
                            "WHERE EXISTS (" +
                                "SELECT 1 FROM Orders o " +
                                "WHERE o.CustomerID = c.CustomerID " +
                                "AND o.OrderID > 11040 " +
                                "AND o.OrderID < 11077" +
                            ")",
                            conn);
                    }
                    else
                        dataAdapter = new SQLiteDataAdapter($"SELECT * FROM \"{tableName}\" LIMIT 1000", conn);

                    dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                    dataAdapter.Fill(ds, tableName);
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
                    ds.Relations.Add(new DataRelation(relationNames[i], ds.Tables[parentTables[i]]!.Columns[parentCols[i]]!, ds.Tables[childTables[i]]!.Columns[childCols[i]]!));
                }
            }

            return ds;
        }

        private void SelectField_Click(object sender, RoutedEventArgs e)
        {
            if (sender == BtnSelect)
            {
                while (ListboxAvailable.SelectedItems!.Count > 0)
                {
                    ListboxSelected.Items.Add(ListboxAvailable.SelectedItems[0]!);
                    ListboxAvailable.Items.Remove(ListboxAvailable.SelectedItems[0]!);
                }
            }
            else if (sender == BtnUnselect)
            {
                while (ListboxSelected.SelectedItems!.Count > 0)
                {
                    ListboxAvailable.Items.Add(ListboxSelected.SelectedItems[0]!);
                    ListboxSelected.Items.Remove(ListboxSelected.SelectedItems[0]!);
                }
            }
        }

        private async void SelectLogo_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current?.ApplicationLifetime is not Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop || desktop.MainWindow is not Window window)
                return;

            var fileResult = await window.StorageProvider.OpenFilePickerAsync(
                new FilePickerOpenOptions
                {
                    Title = "Select an image",
                    AllowMultiple = false,
                    FileTypeFilter = new[]
                    {
                new FilePickerFileType("Image files")
                {
                    Patterns = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.svg" }
                }
                    }
                });

            if (fileResult?.Count > 0)
            {
                var localPath = fileResult[0].TryGetLocalPath();
                if (localPath != null)
                {
                    TextboxSelectLogo.Text = localPath;
                }
            }
        }

        private void BtnPrintProject_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export
                EnableButton(false);

                //D: An das DataSet Objekt binden
                //US: Now bind to the DataSet
                LL.SetDataBinding(InitDataSet()!, ComboboxTables.Text!);

                //D: List & Label Projekt anhand Einstellungen erstellen
                //US: Create List & Label project based on the settings
                GenerateLLProject();


                // D: Projektdatei setzen  
                // US: Get project file  
                string defaultFile = Path.Combine(GetReportFilesDirectory(), "dynamic.json");
                LL.AutoProjectFile =defaultFile;

                // D: Export
                // US: Export  
                ExportConfiguration exportConfiguration = new ExportConfiguration(LlExportTarget.Pdf, Path.Combine(GetReportFilesDirectory(), Path.GetFileNameWithoutExtension(LL.AutoProjectFile) + ".pdf"), LL.AutoProjectFile)
                {
                        ShowResult = true
                };
                LL.Export(exportConfiguration);
                
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                System.Diagnostics.Debug.WriteLine("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
            finally
            {
                // D: Schaltflächen aktivieren  
                // US: Enable button  
                EnableButton(true);
            }
        }

        private void GenerateLLProject()
        {
            try
            {
                //D: Neues DOM-Projekt vom Typen LlProject.List erzeugen, Projektnamen und Zugriffsoptionen setzen
                //US: Create new DOM project, type LlProject.List, set project name and access options
                using var proj = LL.OpenProject(Path.Combine(GetReportFilesDirectory(), "dynamic.json"), LlDomFileMode.Create, LlDomAccessMode.ReadWrite, LlProject.List) ?? throw new ListLabelException("Project cannot be opened.");

                //D: Standardschrift und -größe setzen
                //US: Set default font and size
                proj.Settings.DefaultFont.FaceName = "Calibri";
                proj.Settings.DefaultFont.Size = "12";

                //D: Designschema setzen
                //US: Set design scheme
                proj.ProjectParameters["LL.DesignScheme"].Contents = "\"COMBITCOLORWHEEL\"";

                //D: Eine neue Projektbeschreibung zuweisen
                //US: Assign new project description
                proj.ProjectParameters["LL.ProjectDescription"].Contents = TextboxTitle.Text!;

                //D: Ein leeres Text Objekt erstellen
                //US: Create an empty text object
                ObjectText llobjText = new(proj.Objects);

                //D: Auslesen der Seitenkoordinaten der ersten Seite
                //US: Get the coordinates for the first page
                System.Drawing.Size pageExtend = proj.Regions[0].Paper.Extent.Get();

                //D: Setzen von Eigenschaften für das Textobjekt. Alle Einheiten sind SCM (1/1000 mm).
                //US: Set some properties for the text object. All units are SCM (1/1000 mm).
                llobjText.Position.Set(10000, 10000, pageExtend.Width - 65000, 27000);

                //D: Hinzufügen eines Absatzes und setzen diverser Eigenschaften
                //US: Add a paragraph to the text object and set some properties
                Paragraph llobjParagraph = new(llobjText.Paragraphs)
                {
                    Contents = string.Format("\"{0}\"", TextboxTitle.Text)
                };
                llobjParagraph.Font.Bold = "True";

                //D: Hinzufügen eines Grafikobjekts
                //US: Add a drawing object
                ObjectDrawing llobjPic = new(proj.Objects);
                llobjPic.Source.FileInfo.FileName = TextboxSelectLogo.Text!;
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
                    TableId = ComboboxTables.Text!
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

                foreach (string? fieldName in ListboxSelected.Items)
                {
                    string fieldWidth = (Convert.ToInt32(container.Position.Width) / ListboxSelected.Items.Count).ToString();

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

                    if (InitDataSet()!.Tables[ComboboxTables.Text]!.Columns[fieldName!]!.DataType == typeof(System.Byte[]))
                    {
                        tableField = new TableFieldDrawing(tableLineData.Fields)
                        {
                            Contents = ComboboxTables.Text + "." + fieldName
                        };
                    }
                    else
                    {
                        tableField = new TableFieldText(tableLineData.Fields)
                        {
                            Contents = ComboboxTables.Text + "." + fieldName
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
                System.Diagnostics.Debug.WriteLine("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
        }

    }
}
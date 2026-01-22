using Avalonia.Controls;
using Avalonia.Interactivity;

using combit.Reporting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection.Emit;

namespace Unicode
{
    public partial class MainWindow : Window
    {
        internal ListLabel LL;
        private string? _databasePath = Path.Combine(GetSamplesDirectory(), "address.db");
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
            //D: RadioButton Label setzen
            //US: Set radio button Label
            RadioBtnLabel.IsChecked = true;

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

                    dataAdapter = new SQLiteDataAdapter("SELECT * FROM Persons", conn);

                    dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                    dataAdapter.Fill(ds, tableName);
                }
            }

            return ds;
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

        private void BtnPrint_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                // D: Schaltfläche für den Export deaktivieren  
                // US: Disable button for export
                EnableButton(false);

                // Following best practices, we are using a new instance for every job
                using ListLabel LL = new();
               
                // Now bind to the DataSet
                LL.SetDataBinding(InitDataSet(), string.Empty);

                if (RadioBtnLabel.IsChecked == true)
                {
                    LL.AutoProjectFile = Path.Combine(GetReportFilesDirectory(), "simple_label_unicode.json");
                }
                else if (RadioBtnList.IsChecked == true)
                {
                    LL.AutoProjectFile = Path.Combine(GetReportFilesDirectory(), "simple_list_unicode.json");
                }

                // D: Export
                // US: Export  
                ExportConfiguration exportConfiguration = new(LlExportTarget.Pdf, Path.Combine(GetReportFilesDirectory(), Path.GetFileNameWithoutExtension(LL.AutoProjectFile) + ".pdf"), LL.AutoProjectFile)
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
    }
}

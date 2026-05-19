using Avalonia.Controls;
using Avalonia.Interactivity;

using combit.Reporting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
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
            DataSet ds = new();

            using var conn = new SqliteConnection($"Data Source={_databasePath};");
            conn.Open();

                        string getTablesSql = @"SELECT name 
                            FROM sqlite_master 
                            WHERE type='table' 
                              AND name NOT LIKE 'sqlite_%';";

            using (var cmdTables = new SqliteCommand(getTablesSql, conn))
            using (var readerTables = cmdTables.ExecuteReader())
            {
                while (readerTables.Read())
                {
                    string tableName = readerTables.GetString(0);

                    string sql = $"SELECT * FROM \"{tableName}\";";

                    using var cmd = new SqliteCommand(sql, conn);
                    using var reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable(tableName);
                    dt.Load(reader);
                    ds.Tables.Add(dt);
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

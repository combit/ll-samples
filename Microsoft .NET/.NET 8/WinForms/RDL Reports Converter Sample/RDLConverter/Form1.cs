using System;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using combit.Reporting;
using combit.Reporting.Converters;
using Microsoft.Win32;
using combit.Reporting.DataProviders;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string sampleDir;
        private RegistryKey installKey;

        private string SourceFileName
        {
            get
            {
                return textSourceFile.Text;
            }
            set
            {
                textSourceFile.Text = value;
            }
        }

        private string TargetFileName
        {
            get
            {
                return textTargetFile.Text;
            }
            set
            {
                textTargetFile.Text = value;
            }
        }

        public Form1()
        {
            InitializeComponent();

            installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            if (installKey != null)
                sampleDir = (string)installKey.GetValue("LL30SampleDir", string.Empty);

            if (!sampleDir.EndsWith("\\"))
                sampleDir += "\\";

            SourceFileName = Path.GetFullPath(Path.GetDirectoryName(Application.StartupPath + @"\..\..\..\") + @"\RDLReports.rdl");
            TargetFileName = Path.GetFullPath(Path.GetDirectoryName(Application.StartupPath + @"\..\..\..\") + @"\ReportConvert.lst");

            // D: Setze Cursor an die letzte Position
            // US: Set cursor to the last position
            textSourceFile.Select(textSourceFile.Text.Length, 1);
            textTargetFile.Select(textTargetFile.Text.Length, 1);

            //D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbankpfad auslesen
            //US: Set path to main sample path, read database path
            Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\..\..\..\..\..\Report Files");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //D: Neue ListLabel Instanz erstellen
            //US: Create new ListLabel instance
            using (ListLabel ll = new ListLabel())
            {
                try
                {                    
                    //D: Erstelle ein RptConverter Objekt
                    //US: Create an RptConverter object
                    RdlConverter rdlConverter = new RdlConverter(SourceFileName);

                    //D: Datenquellen aus Bericht auslesen
                    //US: Exract report datasources
                    Dictionary<string, IDbCommand> commands = rdlConverter.GetDataSource(null);
                    DbCommandSetDataProvider dataProvider = new DbCommandSetDataProvider();
                    dataProvider.MinimalSelect = false;
                    dataProvider.PrefixTableNameWithSchema = false;
                    foreach (var item in commands)
                    {
                        dataProvider.AddCommand(item.Value, item.Key);
                    }
                    ll.DataSource = dataProvider;

                    //D: Konvertiere den Bericht
                    //US: Convert the report
                    try
                    {
                        rdlConverter.ConvertReport(ll, SourceFileName, TargetFileName);
                    }
                    catch (SqlException)
                    {
                        string msg = string.Format("The selected RDL report uses a datasource which is currently not accessible.\n\nThe connection string is as follows:\n\"{0}\"\n\nThus the datasource is not accessible we are using sample data to perform a conversion. Errors can be ignored.", commands.First().Value.Connection.ConnectionString);
                        MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        DataSet ds = new DataSet("SampleDataSet");
                        DataTable dt = new DataTable("SampleData");
                        dt.Columns.Add("ID", typeof(int));
                        dt.Columns.Add("Name", typeof(string));
                        ds.Tables.Add(dt);
                        DataRow sampleRow = dt.NewRow();
                        sampleRow.SetField("ID", 1);
                        sampleRow.SetField("Name", "Sample");
                        dt.Rows.Add(sampleRow);

                        ll.DataSource = ds;

                        rdlConverter.ConvertReport(ll, SourceFileName, TargetFileName);

                        ll.AutoProjectFile = TargetFileName;
                        ll.AutoShowSelectFile = false;
                        ll.Design();
                        return;
                    }
                    DialogResult result = MessageBox.Show("Conversion finished, do you want to open the Designer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //D: Designer mit konvertiertem Bericht öffnen
                    //US: Open the Designer with the converted report
                    if (result == DialogResult.Yes)
                    {
                        ll.AutoProjectFile = TargetFileName;
                        ll.AutoShowSelectFile = false;
                        ll.Design();
                    }
                }
                //D: Einfaches Fehlerhandling
                //US: Simple error handling                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Source + " " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void SelectSourceFile_Click(object sender, EventArgs e)
        {
            try
            {
                //D: RDL Reports Datei auswählen
                //US: Choose the RDL Reports file
                System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Filter = "RDL Reports files (*.rdl)|*.rdl|All Files (*.*)|*.*";
                openFileDialog.InitialDirectory = sampleDir + "Microsoft .NET\\Report Files";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    SourceFileName = openFileDialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SelectTargetFile_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                CultureInfo ci = CultureInfo.CurrentCulture;
                if (ci.TwoLetterISOLanguageName == "de")
                    saveFileDialog.Filter = "List & Label Bericht (*.lst)|*.lst|Alle Dateien (*.*)|*.*";
                else
                    saveFileDialog.Filter = "List & Label Report (*.rpt)|*.rpt|All Files (*.*)|*.*";

                saveFileDialog.InitialDirectory = sampleDir + "Microsoft .NET\\Report Files";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    TargetFileName = saveFileDialog.FileName;

            }
            //D: Einfaches Fehlerhandling
            //US: Simple error handling
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TextTargetFile_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Name == textSourceFile.Name)
                toolTip1.Show(textSourceFile.Text, textSourceFile);
            else if ((sender as TextBox).Name == textTargetFile.Name)
                toolTip1.Show(textTargetFile.Text, textTargetFile);
        }

        private void TextSourceFile_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide((sender as TextBox));
        }
    }
}

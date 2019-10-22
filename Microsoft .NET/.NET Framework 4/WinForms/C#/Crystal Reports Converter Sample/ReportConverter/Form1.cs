using System;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using combit.ListLabel25;
using combit.ListLabel25.Converters;
using Microsoft.Win32;
using combit.ListLabel25.DataProviders;

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
                sampleDir = (string)installKey.GetValue("LL" + LlCore.LlGetVersion(LlVersion.Major) + "SampleDir", string.Empty);

            if (!sampleDir.EndsWith("\\"))
                sampleDir += "\\";

            SourceFileName = sampleDir + @"Microsoft .NET\C# Crystal Reports Converter\ReportConverter\CrystalReports.rpt";
            TargetFileName = sampleDir + @"Microsoft .NET\C# Crystal Reports Converter\ReportConverter\ReportConvert.lst";

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
                    ll.DataMember = "Customers";
                    DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
                    provider.AddCommand(CreateOleDbCommand(), "Customers", "[{0}]", null);
                    ll.DataSource = provider;

                    //D: Erstelle ein RptConverter Objekt
                    //US: Create an RptConverter object
                    RptConverter rptConverter = new RptConverter();

                    //D: Konvertiere den Report
                    //US: Convert the Report
                    rptConverter.ConvertReport(ll, SourceFileName, TargetFileName, "Customers");
                    DialogResult result = MessageBox.Show("Conversion finished, do you want to open the Designer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //D: Designer öffnen mit konvertiertem Report
                    //US: Open the designer with the converted Report
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

        private OleDbCommand CreateOleDbCommand()
        {
            string databasePath = string.Empty;
            if (installKey != null)
                databasePath = (string)installKey.GetValue("NWINDPath", string.Empty);

            if (databasePath == string.Empty)
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath);
            return new OleDbCommand("SELECT * FROM Customers ORDER BY Country ASC", conn);
        }

        private void SelectSourceFile_Click(object sender, EventArgs e)
        {
            try
            {
                //D: Crystal Reports Datei auswählen
                //US: Choose the Crystal Reports file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Crystal Reports files (*.rpt)|*.rpt|All files (*.*)|*.*";
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
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                CultureInfo ci = CultureInfo.CurrentCulture;
                if (ci.TwoLetterISOLanguageName == "de")
                    saveFileDialog.Filter = "List & Label Bericht (*.lst)|*.lst|All files (*.*)|*.*";
                else
                    saveFileDialog.Filter = "List & Label Report (*.rpt)|*.rpt|All files (*.*)|*.*";

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

using combit.Reporting;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Custom_Logger_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            // DE: Um die Log-Ausgaben von List & Label zu verarbeiten, muss ein Logger-Objekt an den ListLabel-Konstruktor
            //     übergeben werden, das das ILlLogger-Interface implementiert. Dieses Beispiel enthält Referenzimplementierungen
            //     dieser Schnittstelle für die Frameworks NLog, log4net sowie eine Ausgabe in ein ListView.

            // US: To capture log output from List & Label, an object implementing the ILlLogger interface must be passed to the ListLabel constructor.
            //     This sample contains reference implementations of this interface for the NLog and log4net frameworks, as well as
            //     logger which writes to a ListView.



            // DE:  Kategorienauswahl speichern
            // US:  Store log category selection

            var selectedCategories = new LogCategories()
            {
                EnablePrinterInformation = chkPrinterInfo.Checked,
                EnableDataProvider = chkDataProvider.Checked,
                EnableLicensing = chkLicensing.Checked,
                EnableDotNetComponent = chkNetFx.Checked,
                EnableApiCalls = chkNativeAPI.Checked,
                EnableOther = chkOther.Checked
            };


            // DE:  Logger für NLog, log4net oder ListView anlegen
            // US:  Create logger for NLog, log4net or the ListView
            ILlLogger logger = null;

            // Adapter for NLog Framework
            if (tabsLogType.SelectedTab == tabPageNLog)
            {
                var nlogLog = NLog.LogManager.GetLogger("ListLabelSample");
                logger = new ListLabel2NLogAdapter(nlogLog, selectedCategories);
            }

            // Adapter for log4net Framework
            else if (tabsLogType.SelectedTab == tabPageLog4Net)
            {
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));

                var log4netLog = log4net.LogManager.GetLogger("ListLabelSample");
                logger = new ListLabel2Log4NetAdapter(log4netLog, selectedCategories);
            }

            // Log to ListView
            else if (tabsLogType.SelectedTab == tabPageListView)
            {
                listviewMessages.Items.Clear();
                logger = new ListViewLogger(listviewMessages, selectedCategories, chkIncludeDebugLevel.Checked);
            }


            var dataProvider = GenericList.GetGenericList();

            // DE:  Optional kann ein eigener Logger für den Datenprovider gesetzt werden, falls nicht, wird der Logger der ListLabel-Komponente geerbt.
            // US:  Optionally a dedicated logger can be assigned to the data provider. If not set, the logger of the ListLabel component is inherited.

            //if (dataProvider is ISupportsLogger)
            //{
            //    (dataProvider as ISupportsLogger).SetLogger(new ExampleLogger(),  /* overrideExisting: */ true);
            //}


            // DE:  Der benutzerdefinierte Logger wird im Konstruktor übergeben. Achtung: Die Eigenschaft "Debug" des ListLabel-Objekts wird bei Angabe eines eigenen Loggers ignoriert.
            // US:  The user-defined logger is passed to the constructor. Note: The 'Debug' property of the ListLabel object is ignored when a custom logger is used.
            using var LL = new ListLabel(logger);
            try
            {
                // D:   Den Datenprovider bei List & Label anmelden und den Designer starten
                // US:  Pass the data provider to List & Label and start the Designer

                LL.DataSource = dataProvider;
                LL.AutoProjectFile = "genericlist.lst";
                LL.AutoShowSelectFile = false;
                LL.Export(new ExportConfiguration(LlExportTarget.Pdf, Path.GetTempFileName(), LL.AutoProjectFile));

                if (tabsLogType.SelectedTab == tabPageNLog)
                {
                    btnOpenLogFile_NLog.Enabled = true;
                }
                else if (tabsLogType.SelectedTab == tabPageLog4Net)
                {
                    btnOpenLogFile_Log4Net.Enabled = true;
                }
                else if (tabsLogType.SelectedTab == tabPageListView)
                {
                    listviewMessages.Enabled = true;
                }

                if (tabsLogType.SelectedTab != tabPageListView)
                {
                    if (MessageBox.Show("Print is complete. Open Log File?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        BtnOpenLogFile_Click(null, null);
                    }
                }
            }
            catch (ListLabelException ex)
            {
                MessageBox.Show("Information: " + ex.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\..\..\..\..\Report Files");
            tabsLogType.SelectedIndex = 0;
        }


        private void BtnOpenLogFile_Click(object sender, EventArgs e)
        {
            var fileName = (tabsLogType.SelectedTab == tabPageLog4Net ? "llsample_log4net.log" : "llsample_nlog.log");
            var logPath = Path.Combine(Path.GetTempPath(), fileName);

            if (!File.Exists(logPath) || new FileInfo(logPath).Length == 0)
            {
                MessageBox.Show("No log file has been created yet or log file is empty.");
                return;
            }

            Process.Start(new ProcessStartInfo(logPath) { UseShellExecute = true });
        }
    }


    // DE:  Hilfsklasse zum Speichern der Logkategorienauswahl
    // US:  Helper class to store the log category selection
    public class LogCategories
    {
        public bool EnablePrinterInformation;
        public bool EnableDataProvider;
        public bool EnableLicensing;
        public bool EnableDotNetComponent;
        public bool EnableApiCalls;
        public bool EnableOther;

        // List & Label has more categories, but those are the most important
    }

}

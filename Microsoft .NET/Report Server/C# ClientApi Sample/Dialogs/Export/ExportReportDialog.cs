using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class ExportReportDialog : Form
    {

        private readonly IReportServerClient _rsClient;
        private ReportTemplate _selectedTemplate;

        public ExportReportDialog(IReportServerClient rsClient, ReportTemplate selectedTemplate = null)
        {
            _rsClient = rsClient;
            _selectedTemplate = selectedTemplate;

            InitializeComponent();
            lblStatus.Text = "Status: Ready";
        }

        private void ExportReportDialog_Load(object sender, EventArgs e)
        {
            LoadReportTemplateList();
            LoadExportProfileList();
        }


        private async void LoadReportTemplateList()
        {
            List<ReportTemplate> reportTemplates = new List<ReportTemplate>(await _rsClient.ReportTemplates.GetAllAsync());
            cbReportTemplate.Items.Clear();
            cbReportTemplate.Items.AddRange(reportTemplates.ToArray());

            // If this dialog was opened for a certain template in the report templates dialog, select that report template:
            if (_selectedTemplate != null)
            {
                cbReportTemplate.SelectedIndex = reportTemplates.FindIndex(item => item.Id == _selectedTemplate.Id);
            }
        }

        private async void LoadExportProfileList()
        {
            // Report Server has two types of export profiles: some create files like PDF or JPG (FileExportProfile), others send the report to a printer that is connected to the server (PrinterExportProfile)
            // Here we want to combine all sorts of export profiles in one combobox:
            List<ExportProfile> exportProfiles = new List<ExportProfile>(await _rsClient.ExportProfiles.GetAllForExportAsync());
            cbExportProfile.Items.Clear();
            cbExportProfile.Items.AddRange(exportProfiles.ToArray());

            // Add the printer profiles
            List<PrintOnServerProfile> printProfiles = new List<PrintOnServerProfile>(await _rsClient.ExportProfiles.GetAllForPrintOnServerAsync());
            cbExportProfile.Items.AddRange(printProfiles.ToArray());

            // If this dialog was opened for a certain template in the report templates dialog, select the default export profile of that report template:
            if (_selectedTemplate != null)
            {
                cbExportProfile.SelectedIndex = exportProfiles.FindIndex(item => item.Id == _selectedTemplate.DefaultExportProfileId);
            }
        }

        private async void btnExportOrPrint_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            lblStatus.Text = "Status: Export running";
            progressBar.Style = ProgressBarStyle.Marquee;

            try
            {
                string reportTemplateId = (cbReportTemplate.SelectedItem as ReportTemplate).Id;
                string exportProfileId = (cbExportProfile.SelectedItem as ExportProfileBase)?.Id;   // with null as export profile, the default export profile of the report template will be used

                // Prepare an export and set the options:
                PreparedReport preparedExport = _rsClient.Exporter.PrepareExport(reportTemplateId, exportProfileId);
                preparedExport.DisableCaching = chkDisableCache.Checked;

                // Copy the rows of the report parameter listview to the report parameter list of the export:
                foreach (ListViewItem listViewItem in lvReportParameters.Items)
                {
                    string parameterName = listViewItem.Text;
                    object paramterValue = listViewItem.Tag;

                    preparedExport.ReportParameters.Add(parameterName, paramterValue);
                }

                // Now we need to check what kind of export profile was selected:

                // For file exports, we need to wait until the export is completed on the server and then download the files
                if (cbExportProfile.SelectedItem is ExportProfile)
                {
                    await ExportAndDownloadFiles(preparedExport);
                }

                // and for export profiles that send the report to a printer on the server, we start the print and just wait until everything has been sent to the printer
                else if (cbExportProfile.SelectedItem is PrintOnServerProfile)
                {
                    await ExportAndPrintOnServer(preparedExport);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                progressBar.Style = ProgressBarStyle.Blocks;
                lblStatus.Text = "Status: Ready";
                this.Enabled = true;
            }
        }

        // Exports a report and downloads the files
        private async Task ExportAndDownloadFiles(PreparedReport preparedExport)
        {
            ExportResult result = await preparedExport.ExportAsync();
            MessageBox.Show("The export was completed and the files are ready for download, please choose a directory to save the file(s).");

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                await result.DownloadFilesAsync(folderBrowserDialog.SelectedPath, CancellationToken.None);
                if (MessageBox.Show("The report has been downloaded, would you like to open it?", "ClientAPI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string reportFilePath = Path.Combine(folderBrowserDialog.SelectedPath, result.FirstPageFileLink.RelativeFilePath);
                    Process.Start(new ProcessStartInfo(reportFilePath) { UseShellExecute = true });
                }
            }
        }

        // Starts printing a report on a printer which is connected to the server
        private async Task ExportAndPrintOnServer(PreparedReport preparedExport)
        {
            await preparedExport.PrintOnServerAsync();
            MessageBox.Show("The report has been printed successfully.");
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            DefineReportParameterDialog defParamDialog = new DefineReportParameterDialog();
            if (defParamDialog.ShowDialog() == DialogResult.OK)
            {
                ListViewItem listViewRow = new ListViewItem(defParamDialog.ParameterName);
                listViewRow.SubItems.Add(defParamDialog.ParameterValue.ToString());
                listViewRow.Tag = defParamDialog.ParameterValue;
                lvReportParameters.Items.Add(listViewRow);
            }
        }

        // We have export profiles for file export and for printing in the combobox, so set the correct text for the export/print button
        private void cbExportProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExportProfile.SelectedItem is PrintOnServerProfile)
            {
                btnExportOrPrint.Text = "Print";
            }
            else
            {
                btnExportOrPrint.Text = "Export";
            }
        }


        // When the report template has no report parameters to specify, disable the corresponding controls
        private void cbReportTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportTemplate reportTemplate = cbReportTemplate.SelectedItem as ReportTemplate;
            bool hasReportParameters = false;
            if (reportTemplate != null)
            {
                hasReportParameters = reportTemplate.HasParameters;
            }

             lvReportParameters.Enabled = btnAddParameter.Enabled = hasReportParameters;
        }

    }
}

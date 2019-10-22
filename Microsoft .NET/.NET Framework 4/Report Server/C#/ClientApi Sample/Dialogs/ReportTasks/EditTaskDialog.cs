using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class EditTaskDialog : Form
    {

        private readonly IReportServerClient _rsClient;
        private readonly ReportTask _selectedTask;

        public EditTaskDialog(IReportServerClient rsClient, ReportTask selectedTask)
        {
            _rsClient = rsClient;
            _selectedTask = selectedTask;
            InitializeComponent();

            LoadReportTemplateList();
            LoadExportProfileList();

            if (selectedTask != null)   // initialize the UI with the values from an existing task?
            {
                txtName.Text = selectedTask.Name;
                chkDisableReportCache.Checked = selectedTask.DisableReportCache;
                chkSkipPrintOfEmptyReports.Checked = selectedTask.SkipPrintOnServerWhenReportIsEmpty;
            }
        }

        private async void LoadReportTemplateList()
        {
            try
            {
                List<ReportTemplate> reportTemplates = new List<ReportTemplate>(await _rsClient.ReportTemplates.GetAllAsync());
                cbReportTemplates.Items.Clear();
                cbReportTemplates.Items.AddRange(reportTemplates.ToArray());

                // If this dialog was opened for an existing task, select that taks's report template:
                if (_selectedTask != null)
                {
                    cbReportTemplates.SelectedIndex = reportTemplates.FindIndex(item => item.Id == _selectedTask.ReportTemplateId);
                }
            }
            catch (ReportServerApiException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void LoadExportProfileList()
        {
            try
            {
                // Report Server has two types of export profiles: some create files like PDF or JPG (FileExportProfile), others send the report to a printer that is connected to the server (PrinterExportProfile)
                // Here we want to combine all sorts of export profiles in one combobox:
                List<ExportProfile> exportProfiles = new List<ExportProfile>(await _rsClient.ExportProfiles.GetAllForExportAsync());
                cbExportProfiles.Items.Clear();
                cbExportProfiles.Items.AddRange(exportProfiles.ToArray());

                // Add the printer profiles
                List<PrintOnServerProfile> printProfiles = new List<PrintOnServerProfile>(await _rsClient.ExportProfiles.GetAllForPrintOnServerAsync());
                cbExportProfiles.Items.AddRange(printProfiles.ToArray());

                // If this dialog was opened for a certain template in the report templates dialog, select the default export profile of that report template:
                if (_selectedTask != null)
                {
                    cbExportProfiles.SelectedIndex = exportProfiles.FindIndex(item => item.Id == _selectedTask.ExportProfileId);
                }
            }
            catch (ReportServerApiException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void chkSetReportParameters_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetReportParameters.Checked)
                MessageBox.Show("Please note that setting the report parameters will clear all (!) existing parameters and then set the parameters defined here.");

            lvReportParameters.Enabled = btnAddParameter.Enabled = chkSetReportParameters.Checked;   // enable/disable the corresponding controls
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            ReportTemplate selectedTemplate = cbReportTemplates.SelectedItem as ReportTemplate;
            ExportProfileBase selectedExportProfile = cbExportProfiles.SelectedItem as ExportProfileBase;

            ReportTask editedTask;
            if (_selectedTask != null)   // we are editing an existing task
            {
                editedTask = _selectedTask;
                editedTask.ReportTemplateId = selectedTemplate.Id;
                editedTask.ExportProfileId = selectedExportProfile.Id;
            }
            else   // we are creating a new task
            {
                if (selectedTemplate == null || selectedExportProfile == null)
                {
                    MessageBox.Show("A report template and an export profile need to be selected first.");
                    return;
                }
                else
                {
                    editedTask = _rsClient.ReportTasks.NewTask(selectedTemplate, selectedExportProfile);
                }
            }


            editedTask.Name = txtName.Text;
            editedTask.DisableReportCache = chkDisableReportCache.Checked;
            editedTask.SkipPrintOnServerWhenReportIsEmpty = chkSkipPrintOfEmptyReports.Checked;

            if (chkSetReportParameters.Checked)
            {
                // First we convert the items in the report parameter listview back to ReportParameter objects
                List<ReportParameter> paramtersToSet = new List<ReportParameter>();
                foreach (ListViewItem row in lvReportParameters.Items)
                {
                    ReportParameter currentParameter = new ReportParameter();
                    currentParameter.Name = row.Text;   // Name is in first column
                    currentParameter.UseDefault = bool.Parse(row.SubItems[2].Text);   // the last column contains the boolean for "Use Default Parameter"
                    if (!currentParameter.UseDefault)
                    {
                        object parameterValue = row.Tag;   // we have saved the parameter value (of type Object) in the Tag property when we added the row to the listview!
                        currentParameter.SetValue(row.Tag);
                    }
                    paramtersToSet.Add(currentParameter);
                }
                editedTask.SetReportParameters(paramtersToSet);
            }

            try
            {
                await editedTask.CreateOrUpdateAsync();
                MessageBox.Show("The changes have been applied.");
                this.Close();
            }
            catch (ModelValidationFailedException ex)
            {
                Program.ShowValidationErrorsAtControls(this, errorProvider1, ex);    // show validation errors at the controls which contain the invalid input
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            var defineParamDialog = new DefineReportParameterDialog(/* allow Default Value: */ true);
            if (defineParamDialog.ShowDialog() == DialogResult.OK)
            {
                ListViewItem newListItem = lvReportParameters.Items.Add(defineParamDialog.ParameterName);
                newListItem.SubItems.Add((defineParamDialog.ParameterValue ?? "<Default>").ToString());
                newListItem.SubItems.Add(defineParamDialog.ParameterUseDefaultValue.ToString());
                newListItem.Tag = defineParamDialog.ParameterValue;    // save the original value of the report parameter in the tag property for later use
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void cbReportTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the report template has no report parameters to specify, disable the corresponding controls
            ReportTemplate reportTemplate = cbReportTemplates.SelectedItem as ReportTemplate;
            bool hasReportParameters = false;
            if (reportTemplate != null)
            {
                hasReportParameters = reportTemplate.HasParameters;
            }

            chkSetReportParameters.Enabled = lvReportParameters.Enabled = btnAddParameter.Enabled = hasReportParameters;
        }
    }
}

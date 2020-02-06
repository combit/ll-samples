using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class RunTaskDialog : Form
    {

        private readonly IReportServerClient _rsClient;
        private readonly ReportTask _task;

        public RunTaskDialog(IReportServerClient rsClient, ReportTask task)
        {
            _rsClient = rsClient;
            InitializeComponent();
            lblStatus.Text = "Status: Ready";

            _task = task;

            if (task != null)
            {
                txtTaskId.Text = task.Id;
                txtTaskId.ReadOnly = true;
            }
        }

        private void chkSetReportParameters_CheckedChanged(object sender, EventArgs e)
        {
            lvReportParameters.Enabled = chkSetReportParameters.Checked;   // enable/disable the corresponding controls
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                lblStatus.Text = "Status: Task running";
                progressBar.Style = ProgressBarStyle.Marquee;

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                if (chkSetReportParameters.Checked)
                {
                    // First we convert the items in the report parameter listview back to ReportParameter objects
                    List<ReportParameter> paramtersToSet = new List<ReportParameter>();
                    foreach (ListViewItem row in lvReportParameters.Items)
                    {
                        parameters.Add(row.Text, row.Tag);
                    }
                }

                await _rsClient.ReportTasks.RunTaskAsync(txtTaskId.Text, parameters);
                MessageBox.Show("The task was completed.");
            }
            catch (TaskFailedException tfEx)   // catching this specific exception type gives access to the phase of task execution where the error occured (report generation/exection of task action/...)
            {
                MessageBox.Show("Task failed in the phase '" + tfEx.TaskPhase + "'. Reason: " + tfEx.Message);
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Enabled = true;
                lblStatus.Text = "Status: Ready";
                progressBar.Style = ProgressBarStyle.Blocks;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RunTaskDialog_Load(object sender, EventArgs e)
        {
            LoadParameterListAsync();
        }

        private async void LoadParameterListAsync()
        {
            if (_task != null)
            {
                ReportTemplate template = await _rsClient.ReportTemplates.GetByIdAsync(_task.ReportTemplateId);
                if (template.HasParameters)
                {
                    chkSetReportParameters.Enabled = true;
                    lvReportParameters.Items.Add("Loading...");
                    IEnumerable<ReportDataParameter> parameters = await _task.GetParametersAsync();
                    // Remove Loading... Item from ListView 
                    lvReportParameters.Items.Clear();

                    foreach (ReportDataParameter param in parameters)
                    {
                        if (param.Choices.Count() != 0 && param.SelectMultiple)
                        {
                            param.Value = param.Choices.Select(choice => choice.Value).ToArray();
                        }

                        ListViewItem listViewRow = new ListViewItem(param.Name);
                        listViewRow.SubItems.Add(param.Value != null ? param.Value.ToString() : string.Empty);
                        listViewRow.Tag = param.Value ?? string.Empty;
                        lvReportParameters.Items.Add(listViewRow);
                    }
                }
            }
        }

        private void lvReportParameters_ItemActivate(object sender, EventArgs e)
        {
            if (lvReportParameters.SelectedItems[0] is ListViewItem item)
            {
                DefineReportParameterDialog defParamDialog = new DefineReportParameterDialog(item.Text, item.Tag);
                if (defParamDialog.ShowDialog() == DialogResult.OK)
                {
                    item.SubItems.Clear();
                    item.Name = defParamDialog.ParameterName;
                    item.Text = defParamDialog.ParameterName;
                    item.SubItems.Add(defParamDialog.ParameterValue.ToString());
                    item.Tag = defParamDialog.ParameterValue;

                }
            }
        }
    }
}

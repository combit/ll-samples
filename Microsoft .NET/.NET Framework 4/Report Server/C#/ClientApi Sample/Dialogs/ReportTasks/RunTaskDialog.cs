using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class RunTaskDialog : Form
    {

        private readonly IReportServerClient _rsClient;

        public RunTaskDialog(IReportServerClient rsClient, ReportTask task)
        {
            _rsClient = rsClient;
            InitializeComponent();
            lblStatus.Text = "Status: Ready";

            if (task != null)
            {
                txtTaskId.Text = task.Id;
                txtTaskId.ReadOnly = true;
            }
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                lblStatus.Text = "Status: Task running";
                progressBar.Style = ProgressBarStyle.Marquee;

                await _rsClient.ReportTasks.RunTaskAsync(txtTaskId.Text);
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
    }
}

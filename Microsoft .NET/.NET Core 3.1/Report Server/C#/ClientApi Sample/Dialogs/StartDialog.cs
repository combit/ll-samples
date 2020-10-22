using ClientApiExample.Dialogs.DataSources;
using combit.ReportServer.ClientApi;
using System;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class StartDialog : Form
    {

        private readonly IReportServerClient _rsClient;

        public StartDialog(IReportServerClient rsClient)
        {
            _rsClient = rsClient;
            InitializeComponent();
        }

        private void btnManageReports_Click(object sender, EventArgs e)
        {
            new ManageReportTemplatesDialog(_rsClient).ShowDialog(this);
        }

        private void btnManageDatasources_Click(object sender, EventArgs e)
        {
            if (!_rsClient.HasPermissionTo(UserRights.ManageDataSources))
            {
                MessageBox.Show("The current user has no permission to manage data sources.");
                return;
            }

            new ManageDataSourcesDialog(_rsClient).ShowDialog(this);
        }

        private void btnListLabelSamples_Click(object sender, EventArgs e)
        {
            var uploadLlDataProviderDialog = new CreateDataProviderDialog(_rsClient);
            if (uploadLlDataProviderDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (MessageBox.Show("Would you like to set the access rights of the user groups for the new data source?", "ClientAPI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var setUserGroupsDialog = new ChooseDataSourceUserGroupsDialog(uploadLlDataProviderDialog.CreatedDataSource);
                    setUserGroupsDialog.ShowDialog(this);
                }
            }
        }

        private void btnManageReportTasks_Click(object sender, EventArgs e)
        {
            if (!_rsClient.HasPermissionTo(UserRights.UseTaskPlaner))
            {
                MessageBox.Show("The current user has no permission to manage tasks (scheduled reports).");
                return;
            }

            new ManageReportTasksDialog(_rsClient).ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var importProjectDialog = new ImportProjectDialog(_rsClient);
            importProjectDialog.ShowDialog();
        }
    }
}

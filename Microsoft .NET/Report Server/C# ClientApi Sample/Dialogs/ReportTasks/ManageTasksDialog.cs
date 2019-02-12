using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class ManageReportTasksDialog : Form
    {

        private readonly IReportServerClient _rsClient;

        public ManageReportTasksDialog(IReportServerClient rsClient)
        {
            _rsClient = rsClient;
            InitializeComponent();

        }


        private void ManageReportTasksDialog_Load(object sender, EventArgs e)
        {
            RefreshReportTaskList();
        }

        private async void RefreshReportTaskList()
        {
            IEnumerable<ReportTask> tasks = await _rsClient.ReportTasks.GetAllAsync();
            listViewReportTasks.Items.Clear();

            foreach (ReportTask task in tasks)
            {
                ListViewItem listItem = new ListViewItem(task.Name);
                listItem.SubItems.Add(task.Owner);
                listItem.SubItems.Add(task.ModifiedBy);
                listItem.SubItems.Add(task.ModifiedOnUtc.ToLocalTime().ToString());
                listItem.Tag = task;

                listViewReportTasks.Items.Add(listItem);
            }

            if (listViewReportTasks.Items.Count > 0)
            {
                listViewReportTasks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRunScheduledReport_Click(object sender, EventArgs e)
        {
            if (listViewReportTasks.SelectedIndices.Count != 1)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            ReportTask selectedTask = listViewReportTasks.SelectedItems[0].Tag as ReportTask;

            new RunTaskDialog(_rsClient, selectedTask).ShowDialog(this);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            EditTaskDialog editDialog = new EditTaskDialog(_rsClient, null);
            editDialog.ShowDialog(this);

            RefreshReportTaskList();
        }

        private void btnEditProperties_Click(object sender, EventArgs e)
        {
            if (listViewReportTasks.SelectedIndices.Count != 1)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            ReportTask selectedTask = listViewReportTasks.SelectedItems[0].Tag as ReportTask;

            EditTaskDialog editDialog = new EditTaskDialog(_rsClient, selectedTask);
            editDialog.ShowDialog(this);

            RefreshReportTaskList();
        }

        private async void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (listViewReportTasks.SelectedIndices.Count != 1)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            ReportTask selectedTask = listViewReportTasks.SelectedItems[0].Tag as ReportTask;

            await selectedTask.DeleteAsync();

            RefreshReportTaskList();
        }

        private void btnManageActions_Click(object sender, EventArgs e)
        {
            if (listViewReportTasks.SelectedIndices.Count != 1)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            ReportTask selectedTask = listViewReportTasks.SelectedItems[0].Tag as ReportTask;

            ManageTaskActionsDialog actionsDialog = new ManageTaskActionsDialog(_rsClient, selectedTask);
            actionsDialog.ShowDialog();
        }

        private void btnManageTriggers_Click_1(object sender, EventArgs e)
        {
            if (listViewReportTasks.SelectedIndices.Count != 1)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            ReportTask selectedTask = listViewReportTasks.SelectedItems[0].Tag as ReportTask;

            ManageTaskTriggersDialog triggersDialog = new ManageTaskTriggersDialog(_rsClient, selectedTask);
            triggersDialog.ShowDialog();
        }
    }
}

using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class ManageTaskActionsDialog : Form
    {


        private readonly IReportServerClient _rsClient;
        private readonly ReportTask _reportTask;

        public ManageTaskActionsDialog(IReportServerClient rsClient, ReportTask reportTask)
        {
            _rsClient = rsClient;
            _reportTask = reportTask;
            InitializeComponent();

        }

        private void ManageTaskActionsDialog_Load(object sender, EventArgs e)
        {
            LoadActionsList();
        }

        private async void LoadActionsList()
        {
            IEnumerable<ReportTaskAction> actions = await _reportTask.GetActionsAsync();
            listViewActions.Items.Clear();

            foreach (ReportTaskAction trigger in actions)
            {
                ListViewItem listItem = new ListViewItem(trigger.Name);
                listItem.SubItems.Add(trigger.GetType().Name);
                listItem.Tag = trigger;

                listViewActions.Items.Add(listItem);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditProperties_Click(object sender, EventArgs e)
        {
            if (listViewActions.SelectedIndices.Count != 1)
                return;

            ReportTaskAction selectedAction = listViewActions.SelectedItems[0].Tag as ReportTaskAction;

            OpenEditorDialogForAction(selectedAction);
        }

        private async void btnDeleteAction_Click(object sender, EventArgs e)
        {
            if (listViewActions.SelectedIndices.Count != 1)
                return;

            ReportTaskAction selectedAction = listViewActions.SelectedItems[0].Tag as ReportTaskAction;

            try
            {
                await selectedAction.DeleteAsync();
                LoadActionsList();
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddEmailAction_Click(object sender, EventArgs e)
        {
            ReportTaskEmailAction newEmailAction = new ReportTaskEmailAction(_reportTask);
            OpenEditorDialogForAction(newEmailAction);
        }

        private void btnAddFileCopyAction_Click(object sender, EventArgs e)
        {
            ReportTaskFileCopyAction newFileCopyAction = new ReportTaskFileCopyAction(_reportTask);
            OpenEditorDialogForAction(newFileCopyAction);
        }

        private void btnAddFtpUploadAction_Click(object sender, EventArgs e)
        {
            ReportTaskFtpUploadAction newFtpUploadAction = new ReportTaskFtpUploadAction(_reportTask);
            OpenEditorDialogForAction(newFtpUploadAction);
        }

        private void btnAddSharepointAction_Click(object sender, EventArgs e)
        {
            ReportTaskSharepointUploadAction newFtpUploadAction = new ReportTaskSharepointUploadAction(_reportTask);
            OpenEditorDialogForAction(newFtpUploadAction);
        }


        private void OpenEditorDialogForAction(ReportTaskAction selectedAction)
        {
            Form editorDialog = null;

            if (selectedAction is ReportTaskEmailAction)
            {
                editorDialog = new EditEmailActionDialog(selectedAction as ReportTaskEmailAction);
            }
            else if (selectedAction is ReportTaskFileCopyAction)
            {
                editorDialog = new EditFileCopyActionDialog(selectedAction as ReportTaskFileCopyAction);
            }
            else if (selectedAction is ReportTaskFtpUploadAction)
            {
                editorDialog = new EditFtpActionDialog(selectedAction as ReportTaskFtpUploadAction);
            }
            else if (selectedAction is ReportTaskSharepointUploadAction)
            {
                editorDialog = new EditSharepointActionDialog(selectedAction as ReportTaskSharepointUploadAction);
            }
            else
            {
                return;
            }

            editorDialog.ShowDialog();
            LoadActionsList();
        }
    }
}

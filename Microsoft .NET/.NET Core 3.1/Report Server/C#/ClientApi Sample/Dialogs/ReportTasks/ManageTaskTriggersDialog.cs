using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class ManageTaskTriggersDialog : Form
    {


        private readonly IReportServerClient _rsClient;
        private readonly ReportTask _reportTask;

        public ManageTaskTriggersDialog(IReportServerClient rsClient, ReportTask reportTask)
        {
            _rsClient = rsClient;
            _reportTask = reportTask;
            InitializeComponent();

        }


        private void ManageTaskTriggersDialog_Load(object sender, EventArgs e)
        {
            LoadTriggerList();
        }

        private async void LoadTriggerList()
        {
            IEnumerable<ReportTaskTrigger> triggers = await _reportTask.GetTriggersAsync();
            listViewTriggers.Items.Clear();

            foreach (ReportTaskTrigger trigger in triggers)
            {
                ListViewItem listItem = new ListViewItem(trigger.Name);
                listItem.SubItems.Add(trigger.GetType().Name);
                listItem.Tag = trigger;

                listViewTriggers.Items.Add(listItem);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTrigger_Click(object sender, EventArgs e)
        {
            ReportTaskTimedTrigger newTrigger = new OneTimeTrigger(_reportTask);

            EditTimeTriggerDialog editTimeTriggerDialog = new EditTimeTriggerDialog(newTrigger);
            editTimeTriggerDialog.ShowDialog();

            LoadTriggerList();
        }

        private void btnEditProperties_Click(object sender, EventArgs e)
        {
            if (listViewTriggers.SelectedIndices.Count != 1)
                return;

            ReportTaskTrigger selectedTrigger = listViewTriggers.SelectedItems[0].Tag as ReportTaskTrigger;

            if (selectedTrigger is ReportTaskTimedTrigger)
            {
                EditTimeTriggerDialog editTimeTriggerDialog = new EditTimeTriggerDialog(selectedTrigger as ReportTaskTimedTrigger);
                editTimeTriggerDialog.ShowDialog();
            }

            LoadTriggerList();
        }

        private async void btnDeleteTrigger_Click(object sender, EventArgs e)
        {
            if (listViewTriggers.SelectedIndices.Count != 1)
                return;

            ReportTaskTrigger selectedTrigger = listViewTriggers.SelectedItems[0].Tag as ReportTaskTrigger;

            try
            {
                await selectedTrigger.DeleteAsync();
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadTriggerList();
        }

    }
}

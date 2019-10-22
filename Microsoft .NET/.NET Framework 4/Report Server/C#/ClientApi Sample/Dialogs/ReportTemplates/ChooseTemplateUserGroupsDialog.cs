using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ClientApiExample
{
    public partial class ChooseTemplateUserGroupsDialog : Form
    {

        private readonly ReportTemplate _reportTemplate;

        public ChooseTemplateUserGroupsDialog(ReportTemplate reportTemplate)
        {
            _reportTemplate = reportTemplate;
            InitializeComponent();
        }

        private void ChooseTemplateUserGroupsDialog_Load(object sender, EventArgs e)
        {
            LoadAssignedUserGroups();
        }

        private async void LoadAssignedUserGroups()
        {
            try
            {
                var assignedGroups = await _reportTemplate.GetSelectedAndAvailableUserGroupsAsync();
                lstUserGroups.BeginUpdate();
                lstUserGroups.Items.Clear();
                foreach (var item in assignedGroups)
                {
                    UserGroup group = item.Value;
                    bool isSelected = item.IsSelected;

                    lstUserGroups.Items.Add(group, isSelected);
                }
                lstUserGroups.EndUpdate();
            }
            catch (ReportServerApiException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                await _reportTemplate.SetSelectedUserGroupsAsync(lstUserGroups.CheckedItems.OfType<UserGroup>());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

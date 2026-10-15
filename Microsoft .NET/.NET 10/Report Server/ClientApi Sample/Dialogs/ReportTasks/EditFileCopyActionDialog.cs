using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class EditFileCopyActionDialog : Form
    {

        private readonly ReportTaskFileCopyAction _currentAction;

        public EditFileCopyActionDialog(ReportTaskFileCopyAction fileCopyAction)
        {
            _currentAction = fileCopyAction;

            InitializeComponent();

            txtName.Text = fileCopyAction.Name;
            txtLocation.Text = fileCopyAction.Location;
            txtUserName.Text = fileCopyAction.UserName;
            txtPassword.Text = fileCopyAction.Password;
            chkOverrideFiles.Checked = fileCopyAction.AllowOverride;
            chkSkipIfEmpty.Checked = fileCopyAction.IgnoreForEmptyReports;
        }


        private async void btnOK_Click(object sender, EventArgs e)
        {
            _currentAction.Name = txtName.Text;
            _currentAction.Location = txtLocation.Text;
            _currentAction.UserName = txtUserName.Text;
            _currentAction.Password = txtPassword.Text;
            _currentAction.AllowOverride = chkOverrideFiles.Checked;
            _currentAction.IgnoreForEmptyReports = chkSkipIfEmpty.Checked;

            try
            {
                await _currentAction.CreateOrUpdateAsync();
                MessageBox.Show("The changes have been applied.");
                this.Close();
            }
            catch (ModelValidationFailedException ex)
            {
                // Display input errors at the controls with the invalid values:
                Program.ShowValidationErrorsAtControls(this, errorProvider1, ex);
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

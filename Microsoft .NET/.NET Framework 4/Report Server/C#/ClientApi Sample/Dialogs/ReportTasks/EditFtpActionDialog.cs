using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class EditFtpActionDialog : Form
    {

        private readonly ReportTaskFtpUploadAction _currentAction;

        public EditFtpActionDialog(ReportTaskFtpUploadAction ftpUploadAction)
        {
            _currentAction = ftpUploadAction;

            InitializeComponent();

            txtName.Text = ftpUploadAction.Name;
            txtFtpUrl.Text = ftpUploadAction.FtpUrl;
            txtUserName.Text = ftpUploadAction.UserName;
            txtPassword.Text = ftpUploadAction.Password;
            chkSkipIfEmpty.Checked = ftpUploadAction.IgnoreForEmptyReports;
        }


        private async void btnOK_Click(object sender, EventArgs e)
        {
            _currentAction.Name = txtName.Text;
            _currentAction.FtpUrl = txtFtpUrl.Text;
            _currentAction.UserName = txtUserName.Text;
            _currentAction.Password = txtPassword.Text;
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

using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class EditSharepointActionDialog : Form
    {

        private readonly ReportTaskSharepointUploadAction _currentAction;

        public EditSharepointActionDialog(ReportTaskSharepointUploadAction sharepointAction)
        {
            _currentAction = sharepointAction;

            InitializeComponent();

            txtName.Text = sharepointAction.Name;
            txtServerUrl.Text = sharepointAction.ServerUrl;
            txtUserName.Text = sharepointAction.UserName;
            txtPassword.Text = sharepointAction.Password;
            txtLibrary.Text = sharepointAction.LibraryName;
            txtFolderInLibrary.Text = sharepointAction.FolderInLibrary;
            chkSkipIfEmpty.Checked = sharepointAction.IgnoreForEmptyReports;
        }


        private async void btnOK_Click(object sender, EventArgs e)
        {
            _currentAction.Name = txtName.Text;
            _currentAction.ServerUrl = txtServerUrl.Text;
            _currentAction.UserName = txtUserName.Text;
            _currentAction.Password = txtPassword.Text;
            _currentAction.LibraryName = txtLibrary.Text;
            _currentAction.FolderInLibrary = txtFolderInLibrary.Text;
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

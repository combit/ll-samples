using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class EditEmailActionDialog : Form
    {

        private readonly ReportTaskEmailAction _currentAction;

        public EditEmailActionDialog(ReportTaskEmailAction emailAction)
        {
            _currentAction = emailAction;

            InitializeComponent();

            txtName.Text = emailAction.Name;
            txtRecipients.Text = emailAction.Recipients;
            txtSubject.Text = emailAction.Subject;
            txtMessageText.Text = emailAction.MessageText;
            chkForceZipArchive.Checked = emailAction.ForceZipArchive;
            chkSkipIfEmpty.Checked = emailAction.IgnoreForEmptyReports;
        }


        private async void btnOK_Click(object sender, EventArgs e)
        {
            _currentAction.Name = txtName.Text;
            _currentAction.Recipients = txtRecipients.Text;
            _currentAction.Subject = txtSubject.Text;
            _currentAction.MessageText = txtMessageText.Text;
            _currentAction.ForceZipArchive = chkForceZipArchive.Checked;
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

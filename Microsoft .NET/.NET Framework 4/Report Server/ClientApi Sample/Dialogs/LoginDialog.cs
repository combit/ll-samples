using combit.ReportServer.ClientApi;
using System;
using System.Windows.Forms;

namespace ClientApiExample
{
    public partial class LoginDialog : Form
    {

        public IReportServerClient Client;

        public LoginDialog()
        {
            InitializeComponent();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = btnCancel.Enabled = false;

            try
            {
                IReportServerClient rsClient = await ReportServer.ConnectAsync(txtServerUrl.Text,
                    new ClientOptions()
                    {
                        Authentication = new ApiTokenAuthentication(txtUserName.Text, txtClientToken.Text)
                    });

                this.Client = rsClient;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidCredentialsException)
            {
                MessageBox.Show("The entered credentials are wrong or the user does not exist.");
            }

            catch (ReportServerApiException ex)  // errors from the Report Server API - usually a localized error message is available
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)   // exceptions not related to the Report Server (network connection errors, firewall problems, ...)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnOK.Enabled = btnCancel.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

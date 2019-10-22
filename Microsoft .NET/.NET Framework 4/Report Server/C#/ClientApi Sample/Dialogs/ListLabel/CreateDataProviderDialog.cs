using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using combit.ListLabel25.ReportServerIntegration;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs.DataSources
{
    public partial class CreateDataProviderDialog : Form
    {

        private readonly IReportServerClient _rsClient;

        public CreateDataProviderDialog(IReportServerClient rsClient)
        {
            _rsClient = rsClient;
            InitializeComponent();
        }


        public DataSource CreatedDataSource { get; private set; }

        private async void btnApply_Click(object sender, EventArgs e)
        {

            try
            {
                // Create a List & Label data provider
                var csvDataProvider = new combit.ListLabel25.DataProviders.CsvDataProvider(txtCsvFilePath.Text, chkCsvFirstLineHeaders.Checked, txtCsvTableName.Text, txtCsvSeparatorChar.Text[0]);

                // Use the ReportServerIntegration library to create a data source in Report Server from the data provider of List & Label
                DataSource newDataSource  = await IntegrationTools.CreateDataSourceFromDataProvider(txtName.Text, csvDataProvider, _rsClient);

                // Set the remaining properties on the new datasource
                newDataSource.Description = txtDescription.Text;
                await newDataSource.CreateOrUpdateAsync();

                CreatedDataSource = newDataSource;
                MessageBox.Show("The data source has been created successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ModelValidationFailedException ex)
            {
                MessageBox.Show(ex.Message);

                // Map input errors to the controls with the invalid value:
                foreach (var modelError in ex.ErrorDetails)
                {
                    Control controlWithInvalidInput = this.Controls.OfType<Control>().FirstOrDefault(control => control.Tag as string == modelError.FieldName);
                    if (controlWithInvalidInput != null)
                        errorProvider.SetError(controlWithInvalidInput, modelError.ErrorText);
                }

            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // If the data source was already created on the server, but could not be configured with the LL data provider, delete the model on the server
                if (CreatedDataSource != null && this.DialogResult != DialogResult.OK)
                {
                    await CreatedDataSource.DeleteAsync(true);
                    CreatedDataSource = null;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Windows.Forms;
using System.Linq;

namespace ClientApiExample
{
    public partial class CreateTemplateDialog : Form
    {

        private readonly IReportServerClient _rsClient;
        private readonly TemplateFolder _parentFolder;

        public ReportTemplate Result { get; private set; }

        public CreateTemplateDialog(IReportServerClient rsClient, TemplateFolder parentFolder)
        {
            _rsClient = rsClient;
            _parentFolder = parentFolder;

            InitializeComponent();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            ReportProjectType projectType = ReportProjectType.Default;
            if (rbCard.Checked)
                projectType = ReportProjectType.Card;
            else if (rbLabel.Checked)
                projectType = ReportProjectType.Label;
            else if (rbMasterDetail.Checked)
                projectType = ReportProjectType.MasterDetailList;

            ReportTemplate newTemplate = _rsClient.ReportTemplates.NewTemplate(projectType);
            newTemplate.Name = txtName.Text;
            newTemplate.ParentFolderId = _parentFolder.Id;

            try
            {
                await newTemplate.CreateOrUpdateAsync();
                this.Result = newTemplate;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ModelValidationFailedException ex)
            {
                foreach (var modelError in ex.ErrorDetails)
                {
                    Control controlWithError = this.Controls.OfType<Control>().FirstOrDefault(c => c.Tag as string == modelError.FieldName);
                    if (controlWithError != null)
                        errorProvider.SetError(controlWithError, modelError.ErrorText);
                }
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateTemplateDialog_Load(object sender, EventArgs e)
        {
            txtParentFolder.Text = _parentFolder.Name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

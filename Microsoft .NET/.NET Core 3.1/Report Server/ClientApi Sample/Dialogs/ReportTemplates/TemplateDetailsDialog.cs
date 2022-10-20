using combit.ReportServer.ClientApi.Objects;
using combit.ReportServer.ClientApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApiExample
{
    public partial class TemplateDetailsDialog : Form
    {

        private ReportTemplate _reportTemplate;

        public TemplateDetailsDialog(ReportTemplate reportTemplate)
        {
            _reportTemplate = reportTemplate;
            InitializeComponent();

            if (DesignMode)
                return;

            LoadDataForReportTemplate(reportTemplate);
        }

        private void TemplateDetailsDialog_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataForReportTemplate(ReportTemplate reportTemplate)
        {
            txtName.Text = reportTemplate.Name;
            txtDescription.Text = reportTemplate.Description;
            txtCreatedBy.Text = reportTemplate.CreatedBy;
            txtCreatedOn.Text = reportTemplate.CreatedOnUtc.ToString();
            txtChangedBy.Text = reportTemplate.ModifiedBy;
            txtChangedOn.Text = reportTemplate.ModifiedOnUtc.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();

                _reportTemplate.Name = txtName.Text;
                _reportTemplate.Description = txtDescription.Text;

                await _reportTemplate.CreateOrUpdateAsync();
                this.Close();
            }
            catch (ModelValidationFailedException ex)
            {
                Program.ShowValidationErrorsAtControls(this, errorProvider1, ex);    // show validation errors at the controls which contain the invalid input
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}

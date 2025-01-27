using combit.Reporting;
using combit.Reporting.ReportServerIntegration;
using combit.Reporting.Repository;
using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class ImportProjectDialog : Form
    {


        private readonly IReportServerClient _rsClient;

        public ImportProjectDialog(IReportServerClient rsClient)
        {
            _rsClient = rsClient;

            InitializeComponent();
            LoadReportTemplateList();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ReportTemplate template = cbReportTemplate.SelectedItem as ReportTemplate;

                using (RepositorySession repositorySession = await template.OpenRepositorySessionAsync())    // RepositorySession should always be disposed!
                {
                    IRepository listLabelRepository = repositorySession.AsRepository();

                    using (ListLabel LL = new ListLabel())
                    {
                        LL.FileRepository = listLabelRepository;
                        using (RepositoryImportUtil importUtil = new RepositoryImportUtil(listLabelRepository))
                        {
                            importUtil.ImportProjectFileWithDependencies(LL, txtProjectFile.Text, repositorySession.RootProjectItemId);
                        }
                    }

                    await repositorySession.CommitChangesAsync();
                }
                MessageBox.Show("The project has been imported successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LoadReportTemplateList()
        {
            List<ReportTemplate> reportTemplates = new List<ReportTemplate>(await _rsClient.ReportTemplates.GetAllAsync());
            cbReportTemplate.Items.Clear();
            cbReportTemplate.Items.AddRange(reportTemplates.ToArray());

            if (cbReportTemplate.Items.Count > 0)
                cbReportTemplate.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBrowseForProject_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtProjectFile.Text = openFileDialog1.FileName;
            }
        }
    }
}

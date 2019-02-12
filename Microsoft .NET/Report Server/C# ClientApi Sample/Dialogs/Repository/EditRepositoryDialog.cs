using combit.ListLabel24.Repository;
using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using combit.ListLabel24.ReportServerIntegration;
using combit.ListLabel24;

namespace ClientApiExample.Dialogs
{
    public partial class EditRepositoryDialog : Form
    {

        private readonly IReportServerClient _rsClient;
        private readonly ReportTemplate _reportTemplate;

        RepositorySession _repositorySession;

        public EditRepositoryDialog(IReportServerClient rsClient, ReportTemplate reportTemplate)
        {
            _rsClient = rsClient;
            _reportTemplate = reportTemplate;
            InitializeComponent();

            txtReportName.Text = reportTemplate.Name;
        }


        private async void EditRepositoryDialog_Load(object sender, EventArgs e)
        {
            // Open a repository on the server and create a connection to it.
            // RepositorySession should always be disposed - see the code in the FormClosed event.
            _repositorySession = await _reportTemplate.OpenRepositorySessionAsync();

            LoadRepositoryItemList();
        }


        private async void LoadRepositoryItemList()
        {
            try
            {
                IEnumerable<TemplateRepositoryItem> items = await _repositorySession.GetAllItemsAsync();
                lvRepoItems.Items.Clear();
                foreach (TemplateRepositoryItem item in items)
                {
                    ListViewItem listItem = lvRepoItems.Items.Add(item.ItemId);
                    listItem.Tag = item;
                    listItem.SubItems.Add(RepositoryItemDescriptor.LoadFromDescriptorString(item.Descriptor).GetUIName(0));
                    listItem.SubItems.Add(item.Type);
                    listItem.SubItems.Add(item.LastModificationUtc.ToLocalTime().ToString());
                }
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                await _repositorySession.CommitChangesAsync();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void btnDeleteRepoItem_Click(object sender, EventArgs e)
        {
            if (lvRepoItems.SelectedItems.Count != 1)
                return;

            TemplateRepositoryItem selectedItem = lvRepoItems.SelectedItems[0].Tag as TemplateRepositoryItem;

            try
            {
                await _repositorySession.DeleteItemAsync(selectedItem);
                lvRepoItems.Items.Remove(lvRepoItems.SelectedItems[0]);
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (lvRepoItems.SelectedItems.Count != 1)
                return;

            TemplateRepositoryItem selectedItem = lvRepoItems.SelectedItems[0].Tag as TemplateRepositoryItem;

            try
            {
                ViewRepositoryImageDialog imageDialog = new ViewRepositoryImageDialog(selectedItem);
                imageDialog.ShowDialog();
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void EditRepositoryDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            // IMPORTANT: The RepositorySession object is connected to a repository object on the server side.
            // We should close the session to free the object on the server.
            if (_repositorySession != null)
            {
                await _repositorySession.CloseRepositorySession();
            }
        }

        private void AddPdfFileMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pdfFile = openFileDialog1.FileName;

                using (RepositoryImportUtil importUtil = new RepositoryImportUtil(_repositorySession.AsRepository()))
                {
                    using (ListLabel LL = new ListLabel())
                    {
                        importUtil.ImportPdfFile(LL, pdfFile);
                    }

                }
                LoadRepositoryItemList();
            }
        }

        private void AddImageMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.jpg, *.png, *.gif)|*.jpg;*.png;*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pdfFile = openFileDialog1.FileName;

                using (RepositoryImportUtil importUtil = new RepositoryImportUtil(_repositorySession.AsRepository()))
                {
                    using (ListLabel LL = new ListLabel())
                    {
                        importUtil.ImportImageFile(LL, pdfFile);
                    }

                }
                LoadRepositoryItemList();
            }
        }

        private void addListLabelProjectMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "List & Label Project (*.lst, *.crd, *.lbl)|*.lst;*.crd;*.lbl";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string projectFile = openFileDialog1.FileName;

                using (RepositoryImportUtil importUtil = new RepositoryImportUtil(_repositorySession.AsRepository()))
                {
                    using (ListLabel LL = new ListLabel())
                    {
                        importUtil.ImportProjectFile(LL, projectFile);
                    }

                }
                LoadRepositoryItemList();
            }
        }
    }
}

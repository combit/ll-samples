using ClientApiExample.Dialogs;
using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientApiExample
{
    public partial class ManageReportTemplatesDialog : Form
    {

        private readonly IReportServerClient _rsClient;
        private TreeNode _selectedFolderTreeNode;
        private TemplateFolder _rootTemplateFolder;
        private string _lastSearchText = null;

        public ManageReportTemplatesDialog(IReportServerClient rsClient)
        {
            _rsClient = rsClient;

            InitializeComponent();
        }

        private void ReportTemplateListDialog_Load(object sender, EventArgs e)
        {
            LoadFolderTree();
            LoadReportTemplateList();
        }

        private async void LoadReportTemplateList()
        {
            string parentFolderID = (_selectedFolderTreeNode?.Tag as TemplateFolder)?.Id;

            _lastSearchText = txtSearchText.Text;
            var reportTemplates = await _rsClient.ReportTemplates.SearchAsync(txtSearchText.Text.Split(' '), parentFolderID);
            templateList.BeginUpdate();
            templateList.Items.Clear();
            foreach (var template in reportTemplates)
            {
                var listViewItem = templateList.Items.Add(template.Name);
                listViewItem.SubItems.Add(template.CreatedBy);
                listViewItem.SubItems.Add(template.ModifiedBy);
                listViewItem.SubItems.Add(template.ModifiedOnUtc.ToLocalTime().ToString());
                listViewItem.Tag = template;
            }
            templateList.EndUpdate();
        }

        private async void LoadFolderTree()
        {
            var rootFolder = await _rsClient.Management.GetReportTemplateFoldersAsync();
            _rootTemplateFolder = rootFolder;
            folderTree.BeginUpdate();
            folderTree.Nodes.Clear();
            folderTree.Nodes.Add("<All>");
            AddSubItemToFolderTreeView(rootFolder, null);
            folderTree.ExpandAll();
            folderTree.EndUpdate();
        }


        private void AddSubItemToFolderTreeView(TemplateFolder folder, TreeNode parentFolder)
        {
            TreeNode treeNode = new TreeNode(folder.Name);
            treeNode.Tag = folder;

            if (folder.SubItems != null)
            {
                foreach (TemplateFolder subFolder in folder.SubItems)
                {
                    AddSubItemToFolderTreeView(subFolder, treeNode);
                }
            }

            if (parentFolder != null)
            {
                parentFolder.Nodes.Add(treeNode);
            }
            else
            {
                folderTree.Nodes.Add(treeNode);
            }
        }


        private void txtSearchText_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearchText.Text != _lastSearchText)
            {
                LoadReportTemplateList();
            }
        }

        private void folderTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_selectedFolderTreeNode != null)   // Remove selection (bold font) from previously selected folder and set it to the new selected folder
            {
                _selectedFolderTreeNode.NodeFont = new Font(folderTree.Font, FontStyle.Regular);
                e.Node.NodeFont = new Font(folderTree.Font, FontStyle.Bold);
            }
            txtSearchText.Text = String.Empty;
            _selectedFolderTreeNode = e.Node;
            LoadReportTemplateList();
        }

        private void templateList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEditProperties.PerformClick();
        }

        private void btnEditProperties_Click(object sender, EventArgs e)
        {
            ReportTemplate selectedTemplate = GetSelectedReportTemplate();
            if (selectedTemplate == null)
                return;

            new TemplateDetailsDialog(selectedTemplate).ShowDialog(this);
        }

        private async void btnNewTemplate_Click(object sender, EventArgs e)
        {
            TemplateFolder parentFolder = _selectedFolderTreeNode?.Tag as TemplateFolder;
            if (parentFolder == null)
                parentFolder = _rootTemplateFolder;

            // Create Report Template Model
            var createTemplateDialog = new CreateTemplateDialog(_rsClient, parentFolder);


            if (createTemplateDialog.ShowDialog(this) != DialogResult.OK)
                return;

            ReportTemplate createdTemplate = createTemplateDialog.Result;

            bool operationCanceled = false;
            try
            {

                // Assign Data Sources
                var chooseDataSourceDialog = new ChooseDataSourcesDialog(createdTemplate);

                if (chooseDataSourceDialog.ShowDialog(this) != DialogResult.OK)
                {
                    operationCanceled = true;
                    return;
                }

                // Assign Access Rights for User Groups
                if (new ChooseTemplateUserGroupsDialog(createdTemplate).ShowDialog(this) != DialogResult.OK)
                {
                    operationCanceled = true;
                    return;
                }

            }
            finally
            {
                if (operationCanceled)   // User cancelled in one of the dialogs => delete the template
                {
                    await createdTemplate.DeleteAsync();
                }
                LoadReportTemplateList();
            }
        }

        private void btnChooseDatasources_Click(object sender, EventArgs e)
        {
            ReportTemplate selectedTemplate = GetSelectedReportTemplate();
            if (selectedTemplate == null)
                return;

            new ChooseDataSourcesDialog(selectedTemplate).ShowDialog(this);
        }

        private void btnEditAccessRights_Click(object sender, EventArgs e)
        {
            ReportTemplate selectedTemplate = GetSelectedReportTemplate();
            if (selectedTemplate == null)
                return;

            new ChooseTemplateUserGroupsDialog(selectedTemplate).ShowDialog(this);
        }

        private ReportTemplate GetSelectedReportTemplate()
        {
            if (templateList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a report template from the list.");
                return null;
            }

            return templateList.SelectedItems[0].Tag as ReportTemplate;
        }

        private async void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            ReportTemplate selectedTemplate = GetSelectedReportTemplate();
            if (selectedTemplate == null)
                return;

            try
            {
                await selectedTemplate.DeleteAsync();
                LoadReportTemplateList();
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ReportTemplate selectedTemplate = GetSelectedReportTemplate();
            if (selectedTemplate == null)
                return;

            ExportReportDialog exportDialog = new ExportReportDialog(_rsClient, selectedTemplate);
            exportDialog.ShowDialog();
        }

        private void btnEditRepository_Click(object sender, EventArgs e)
        {
            ReportTemplate selectedTemplate = GetSelectedReportTemplate();
            if (selectedTemplate == null)
                return;

            EditRepositoryDialog repositoryDialog = new EditRepositoryDialog(_rsClient, selectedTemplate);
            repositoryDialog.ShowDialog();
        }
    }
}

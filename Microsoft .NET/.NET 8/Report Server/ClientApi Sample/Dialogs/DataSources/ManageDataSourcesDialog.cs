using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace ClientApiExample.Dialogs
{
    public partial class ManageDataSourcesDialog : Form
    {

        private readonly IReportServerClient _rsClient;
        private TreeNode _selectedFolderTreeNode;
        private DatasourceFolder _rootFolder;
        private string _lastSearchText = null;

        public ManageDataSourcesDialog(IReportServerClient rsClient)
        {
            _rsClient = rsClient;
            InitializeComponent();
        }

        private void ManageDataSourcesDialog_Load(object sender, EventArgs e)
        {
            LoadFolderTree();
            LoadDataSourceList();
        }

        private async void LoadDataSourceList()
        {
            try
            {
                string parentFolderID = (_selectedFolderTreeNode?.Tag as DatasourceFolder)?.Id;
                IEnumerable<DataSource> dataSources;

                // Search for keywords or display contents of a certain folder?
                if (txtSearchText.Text.Length > 0)
                {
                    dataSources = await _rsClient.DataSources.SearchAsync(txtSearchText.Text.Split(' '));
                }
                else
                {
                    dataSources = await _rsClient.DataSources.GetAllAsync(parentFolderID);
                }

                lstDataSources.BeginUpdate();
                lstDataSources.Items.Clear();
                foreach (var template in dataSources)
                {
                    var listViewItem = lstDataSources.Items.Add(template.Name);
                    listViewItem.SubItems.Add(template.CreatedBy);
                    listViewItem.SubItems.Add(template.ModifiedBy);
                    listViewItem.SubItems.Add(template.ModifiedOnUtc.ToLocalTime().ToString());
                    listViewItem.Tag = template;
                }
                lstDataSources.EndUpdate();
            }
            catch (ReportServerApiException e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            }
        }

        private async void LoadFolderTree()
        {
            var rootFolder = await _rsClient.Management.GetDatasourceFoldersAsync();
            _rootFolder = rootFolder;
            folderTree.BeginUpdate();
            folderTree.Nodes.Clear();
            folderTree.Nodes.Add("<All>");
            AddSubItemToFolderTreeView(rootFolder, null);
            folderTree.ExpandAll();
            folderTree.EndUpdate();
        }

        private void AddSubItemToFolderTreeView(DatasourceFolder folder, TreeNode parentFolder)
        {
            TreeNode treeNode = new TreeNode(folder.Name);
            treeNode.Tag = folder;

            if (folder.SubItems != null)
            {
                foreach (DatasourceFolder subFolder in folder.SubItems)
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


        private DataSource GetSelectedDataSource()
        {
            if (lstDataSources.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a report template from the list.");
                return null;
            }

            return lstDataSources.SelectedItems[0].Tag as DataSource;
        }

        private void btnEditProperties_Click(object sender, EventArgs e)
        {
            DataSource selectedDataSource = GetSelectedDataSource();
            if (selectedDataSource == null)
                return;

            new DataSourceDetailsDialog(selectedDataSource).ShowDialog(this);
            LoadDataSourceList();
        }

        private void lstDataSources_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEditProperties.PerformClick();
        }

        private void btnEditAccessRights_Click(object sender, EventArgs e)
        {
            DataSource selectedDataSource = GetSelectedDataSource();
            if (selectedDataSource == null)
                return;

            new ChooseDataSourceUserGroupsDialog(selectedDataSource).ShowDialog(this);
        }

        private async void btnDataSourceTemplate_Click(object sender, EventArgs e)
        {
            DataSource selectedDataSource = GetSelectedDataSource();
            if (selectedDataSource == null)
                return;
            try
            {
                await selectedDataSource.DeleteAsync(/* ignore if data source is still in use: */ false);
                LoadDataSourceList();  // refresh the list
            }
            catch (InvalidInputException ex)    // this is thrown when the data source was is still assigned to at least one report template and contains a list of the template names.
            {
                // Ask the user if this should be ignored (however those report templates might not work anymore)
                if (MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine
                    + "Would you like to ignore this problem and delete the data source anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Try again and ignore references to the data source:
                    await selectedDataSource.DeleteAsync(true);
                }
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
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
            LoadDataSourceList();
        }

        private void txtSearchText_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearchText.Text != _lastSearchText)
            {
                LoadDataSourceList();
            }
        }
    }
}

using combit.ReportServer.ClientApi.Objects;
using System;
using System.Windows.Forms;
using System.Linq;
using combit.ReportServer.ClientApi;

namespace ClientApiExample
{
    public partial class ChooseDataSourcesDialog : Form
    {


        private readonly ReportTemplate _reportTemplate;

        public ChooseDataSourcesDialog(ReportTemplate reportTemplate)
        {
            _reportTemplate = reportTemplate;

            InitializeComponent();
        }

        private void ChooseDataSourcesDialog_Load(object sender, EventArgs e)
        {
            LoadDataSourcesOfReport();
        }

        private async void LoadDataSourcesOfReport()
        {
            try
            {
                var datasources = await _reportTemplate.GetSelectedAndAvailableDataSourcesAsync();
                lstDatasources.BeginUpdate();
                lstDatasources.Items.Clear();
                foreach (SelectableItem<DataSource> item in datasources)
                {
                    DataSource dataSource = item.Value;
                    lstDatasources.Items.Add(dataSource, item.IsSelected);
                }
                lstDatasources.EndUpdate();
                lblStatus.Text = lstDatasources.CheckedIndices.Count + " Datasource(s) selected";
            }
            catch (ReportServerApiException e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            }
        }

        private void lstDatasources_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstDatasources.SelectedItem != null)
            {
                txtDescription.Text = (lstDatasources.SelectedItem as DataSource).Description ?? String.Empty;
            }
            lblStatus.Text = lstDatasources.CheckedIndices.Count + " Datasource(s) selected";
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
                await _reportTemplate.SetSelectedDataSourcesAsync(lstDatasources.CheckedItems.Cast<DataSource>());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

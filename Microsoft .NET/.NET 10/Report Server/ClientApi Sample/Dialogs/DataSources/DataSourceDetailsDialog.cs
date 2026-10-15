using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ClientApiExample
{
    public partial class DataSourceDetailsDialog : Form
    {

        private DataSource _dataSource;

        public DataSourceDetailsDialog(DataSource dataSource)
        {
            _dataSource = dataSource;
            InitializeComponent();

            if (DesignMode)
                return;

            LoadDataForDataSource(dataSource);
        }

        private void LoadDataForDataSource(DataSource dataSource)
        {
            txtName.Text = dataSource.Name;
            txtDescription.Text = dataSource.Description;
            txtCreatedBy.Text = dataSource.CreatedBy;
            txtCreatedOn.Text = dataSource.CreatedOnUtc.ToString();
            txtChangedBy.Text = dataSource.ModifiedBy;
            txtChangedOn.Text = dataSource.ModifiedOnUtc.ToString();
            chkOnlyOwnerCanEdit.Checked = dataSource.OwnerOnlyEditable;
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

                _dataSource.Name = txtName.Text;
                _dataSource.Description = txtDescription.Text;
                _dataSource.OwnerOnlyEditable = chkOnlyOwnerCanEdit.Checked;

                await _dataSource.CreateOrUpdateAsync();
                this.Close();
            }
            catch (ModelValidationFailedException ex)
            {
                MessageBox.Show("The entered data is not valid. Please check the displayed error details.");
                foreach (var modelError in ex.ErrorDetails)
                {
                    errorProvider1.SetError(this.Controls.OfType<Control>().First(c => c.Tag as string == modelError.FieldName), modelError.ErrorText); 
                }
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

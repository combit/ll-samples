using System;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class DefineReportParameterDialog : Form
    {

        public string ParameterName { get; private set; }

        public object ParameterValue { get; private set; }

        public bool ParameterUseDefaultValue { get; private set; }

        public DefineReportParameterDialog(bool allowDefaultValue = false)
        {
            InitializeComponent();

            // We use this dialog for the report parameters for an export, but also for the pre-defined report parameters of report tasks. 
            // Only for the tasks it is possible to force a parameter to use its default value
            if (!allowDefaultValue)
            {
                tabControl1.TabPages.Remove(tabUseDefaultValue);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter a parameter name.");
                return;
            }
            ParameterName = txtName.Text;

            if (tabControl1.SelectedTab == tabUseSingleValue)   // Single Value
            {
                if (String.IsNullOrEmpty(txtSingleValue.Text))
                {
                    MessageBox.Show("Please enter a isngle value.");
                    return;
                }
                ParameterValue = txtSingleValue.Text;
            }
            else if (tabControl1.SelectedTab == tabUseMultipleValues)   // Multi Value
            {
                if (String.IsNullOrEmpty(txtMultiValue.Text))
                {
                    MessageBox.Show("Please enter at least one value.");
                    return;
                }
                ParameterValue = txtSingleValue.Text.Split('\n');   // parameter value type is string[]!
            }
            else if (tabControl1.SelectedTab == tabUseDateValue)  // Date Value
            {
                if (String.IsNullOrEmpty(txtSingleValue.Text))
                {
                    MessageBox.Show("Please enter a isngle value.");
                    return;
                }
                ParameterValue = dateTimePicker.Value;
            }
            else if (tabControl1.SelectedTab == tabUseDefaultValue)    // Use the default value of the report parameter
            {
                ParameterUseDefaultValue = true;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

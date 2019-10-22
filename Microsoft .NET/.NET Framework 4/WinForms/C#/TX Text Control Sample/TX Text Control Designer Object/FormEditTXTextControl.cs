using System;
using System.Collections.Generic;
using System.Windows.Forms;
using combit.ListLabel25;

namespace TXTextDesignerObject
{
	public partial class FormEditTXTextControl : Form
    {
		private FormEditTXTextControl()
		{
			InitializeComponent();
		}

        string _rtfDocumentContent = string.Empty;
        DataSource _rtfDataSource = DataSource.FreeText;
        List<string> _lstIdentifiers = new List<string>();
        ListLabel _LL = null;
		public FormEditTXTextControl(List<string> lstIdentifiers, DataSource rtfDataSource, string rtfDocumentContent, ListLabel LL)
		{
			InitializeComponent();

            _lstIdentifiers = lstIdentifiers;
            RTFDataSource = rtfDataSource;
            RTFDocumentContent = rtfDocumentContent;
			_LL = LL;

            //
            listLabelEditRTFControl.ParentComponent = _LL;
        }

        private void FrmEditTXTextControl_Load(object sender, EventArgs e)
		{
            //
            comboBoxIdentifiers.Items.AddRange(_lstIdentifiers.ToArray());

            // select predefined item in combobox
            // hint: selection an item in combobox makes an implicit update which loads the rtf
            switch (RTFDataSource)
            {
                case DataSource.FreeText:
                {
                    listLabelEditRTFControl.Content = RTFDocumentContent;
                    comboBoxIdentifiers.SelectedItem = _LL.Core.LoadString(35);
                }
                break;

                case DataSource.Identifier:
                {
                    comboBoxIdentifiers.SelectedItem = _rtfDocumentContent;
                }
                break;
            }
		}

        new private void Update()
        {
            try
            {
                if (comboBoxIdentifiers.SelectedItem.ToString() == _LL.Core.LoadString(35))
                {
                    // "(Freier Text)"
                    RTFDataSource = DataSource.FreeText;
                    RTFDocumentContent = listLabelEditRTFControl.Content;
                }
                else
                {
                    RTFDataSource = DataSource.Identifier;
                    RTFDocumentContent = comboBoxIdentifiers.SelectedItem.ToString();
                }

                LoadRTFContent();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            base.Update();
        }

		private void BtnOk_Click(object sender, EventArgs e)
		{
			try
			{
                Update();
                
                this.DialogResult = DialogResult.OK;
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
				this.DialogResult = DialogResult.Cancel;
			}
			
			this.Close();
		}

#region Properties

        public string RTFDocumentContent
        {
            get { return _rtfDocumentContent; }
            protected set { _rtfDocumentContent = value; }
        }

        public DataSource RTFDataSource
        {
            get { return _rtfDataSource; }
            protected set { _rtfDataSource = value; }
        }

        #endregion

        private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
        
        private void LoadRTFContent()
        {
            try
            {
                switch (RTFDataSource)
                {
                    case DataSource.FreeText:
                    {
                        listLabelEditRTFControl.Enabled = true;
                        listLabelEditRTFControl.Content = RTFDocumentContent;
                    }
                    break;

                    case DataSource.Identifier:
                    {
                       listLabelEditRTFControl.Content = string.Empty;
                        listLabelEditRTFControl.Enabled = false;
                    }
                    break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        
        private void FormEditTXTextControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            listLabelEditRTFControl.Dispose();
        }

        private void ComboBoxIdentifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update();
        }
    }
}

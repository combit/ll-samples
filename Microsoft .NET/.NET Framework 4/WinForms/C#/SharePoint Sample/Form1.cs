/*
 * Please download and install the SharePoint Foundation 2010 Client Object Model Redistributables.
 * http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=21786
 */
 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using combit.ListLabel25.DataProviders;
using Microsoft.Win32;
using System.Data.OleDb;
using combit.ListLabel25;
using System.Globalization;
using Microsoft.SharePoint.Client;
using System.Net;
using System.IO;
using combit.ListLabel25.SharePointExtensions;
using System.Diagnostics;

namespace SharePointSample
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private ListLabel _ll;

        public Form1()
        {
            InitializeComponent();

            _ll = new ListLabel(CultureInfo.CurrentCulture);
            comboBoxFormat.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_ll != null)
                _ll.Dispose();

            base.OnClosing(e);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ResetError();
                comboBoxBib.Items.Clear();

                //D: Erstelle ClientContext Objekt
                //US: create ClientContext object 
                using (ClientContext context = new ClientContext(txtServer.Text))
                {
                    //D: Setze Berechtigungen
                    //US: set credentials
                    if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                        context.Credentials = new NetworkCredential(txtName.Text, txtPassword.Text);

                    //D: Lade Listen
                    //US: load lists
                    ListCollection lists = context.Web.Lists;
                    context.Load(lists);
                    context.ExecuteQuery();

                    //D: Alle Listen durchlaufen und einen Eintrag in der ComboBox machen
                    //US: iterate through all lists and add an entry to the ComboBox
                    foreach (List list in lists)
                    {
                        if (list.BaseTemplate == (int)ListTemplateType.DocumentLibrary)
                            comboBoxBib.Items.Add(list.Title);
                    }

                    comboBoxBib.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ShowError(string exceptionMessage)
        {
            pictureBox1.Visible = lblInfo.Visible = true;
            lblInfo.Text = exceptionMessage;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(lblInfo, exceptionMessage);
        }

        private void ResetError()
        {
            pictureBox1.Visible = lblInfo.Visible = false;
            lblInfo.Text = string.Empty;
        }

        private void ShowInfo(string informationMessage)
        {
            pictureBox1.Visible = false;
            lblInfo.Visible = true;
            lblInfo.Text = informationMessage;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(lblInfo, informationMessage);			
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                //D: Setze Datenquelle
                //US: set data source
                _ll.DataSource = CreateDbCommandSetDataProvider();
                using (MemoryStream exportStream = new MemoryStream())
                {
                    //D: Erstelle Export Konfiguration
                    //US: create export configuration
                    LlExportTarget exportTarget = GetExportTargetFromIndex();
                    ExportConfiguration exportConfiguration = new ExportConfiguration(exportTarget, exportStream, @"..\..\..\simple.lst");
                    exportConfiguration.Path = txtFileName.Text + GetExtension(exportTarget);

                    //D: Setze SharePoint Verbindungsoptionen
                    //US: set sharepoint connection information
                    SharePointConnectionInformation sharePointConnectionInformation = new SharePointConnectionInformation(txtServer.Text, comboBoxBib.SelectedItem.ToString());
                    sharePointConnectionInformation.OverwriteExistingFile = chkOverwriteFile.Checked;
                    
                    if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                        sharePointConnectionInformation.NetworkCredential = new NetworkCredential(txtName.Text, txtPassword.Text);

                    _ll.Export(exportConfiguration, sharePointConnectionInformation);

                    ShowInfo(Properties.Resources.InfoExportSucceeded);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private static DbCommandSetDataProvider CreateDbCommandSetDataProvider()
        {
            string databasePath = string.Empty;
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            if (installKey != null)
                databasePath = (string)installKey.GetValue("NWINDPath", string.Empty);

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Products INNER JOIN Categories ON (Products.CategoryID = Categories.CategoryID)", conn);
            conn.Close();

            DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
            provider.AddCommand(cmd, "Products", "[{0}]", null);

            return provider;
        }

        private LlExportTarget GetExportTargetFromIndex()
        {
            int selectedIndex = comboBoxFormat.SelectedIndex;
            switch (selectedIndex)
            {
                case 0: return LlExportTarget.Pdf;
                case 1: return LlExportTarget.Xls;
                case 2: return LlExportTarget.Xlsx;
                case 4: return LlExportTarget.Rtf;
                case 5: return LlExportTarget.MultiTiff;
                default: return LlExportTarget.Pdf;
            }
        }

        private static string GetExtension(LlExportTarget exportTarget)
        {
            switch (exportTarget)
            {
                case LlExportTarget.MultiTiff: return ".tif";
                case LlExportTarget.Pdf: return ".pdf";
                case LlExportTarget.Rtf: return ".rtf";
                case LlExportTarget.Xls: return ".xls";
                case LlExportTarget.Xlsx: return ".xlsx";
                default: return string.Empty;
            }
        }

        private void ComboBoxBib_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = btnExport.Enabled = (comboBoxBib.Items.Count > 0);
        }

        private void ComboBoxBib_DropDown(object sender, EventArgs e)
        {
            if (comboBoxBib.Items.Count == 0)
                BtnRefresh_Click(this.btnRefresh, null);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //D: Öffne Downloadseite
            //US: Open download site
            try
            {
                Process.Start(@"http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=21786");
            }
            catch (Win32Exception) { }
            catch (ObjectDisposedException) { }
            catch (FileNotFoundException) { }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            //D: Öffne Downloadseite
            //US: Open download site
            try
            {
                Process.Start(@"http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=21786");
            }
            catch (Win32Exception) { }
            catch (ObjectDisposedException) { }
            catch (FileNotFoundException) { }
        }
    }
}

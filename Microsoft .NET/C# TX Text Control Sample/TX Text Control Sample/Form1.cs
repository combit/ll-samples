
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

using combit.ListLabel24;
using TXTextDesignerObject;

using MetroFramework.Forms;


// Hints:
// 
// Please consider the readme.txt in the root folder of this solution for some details.
//


namespace TXTextControlSample
{
	public partial class Form1 : MetroForm
	{
		String iconFileName;
		String projectFileName;
		String documentFileName;

		public Form1()
		{
			InitializeComponent();

            // Read some information from registry and set some general information
            String resourcePath = string.Empty;
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll", RegistryKeyPermissionCheck.ReadSubTree);
			if (regKey != null)
			{
				resourcePath = (String)regKey.GetValue("LL" + LlCore.LlGetVersion(LlVersion.Major) + "SampleDir", String.Empty);
				if (resourcePath.EndsWith(@"\"))
					resourcePath = resourcePath + @"Microsoft .NET\C# TX Text Control Sample\TX Text Control Sample\";
				else
					resourcePath = resourcePath + @"\Microsoft .NET\C# TX Text Control Sample\TX Text Control Sample\";
			}
			else
				MessageBox.Show("Unable to read correct information from registry.");

			openFileDialog.InitialDirectory = resourcePath;
			saveFileDialog.InitialDirectory = resourcePath;

			iconFileName = resourcePath + "TxText.ico";
			projectFileName = resourcePath + "TxTextDesignerObject.lst";
            documentFileName = resourcePath + "Great-Team.rtf";
        }

		private void Form1_Load(object sender, EventArgs e)
		{
            // Load document
            try
            {
                LoadRTFFile(documentFileName);
            }
            catch (FileLoadException exc)
            {
                MessageBox.Show(exc.Message);
            }
            
            UpdateLLDataSource();
        }
        
        private void MenuFileExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MenuFileLoadDocument_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
                    // General
                    documentFileName = openFileDialog.FileName;

                    LoadRTFFile(documentFileName);

                    UpdateLLDataSource();
                }
				catch(Exception exc)
				{
					MessageBox.Show(exc.Message);
				}
			}
		}
		
		private void MenuDesignDesign_Click(object sender, EventArgs e)
		{
			try
			{
                // Create designer object and declare it to List & Label
                listLabel.DesignerObjects.Clear();
				TXDesignerObject designerObject = new TXDesignerObject("TXTextObjectName", "TXTextObjectDescription", iconFileName, listLabel);

                #region Additional Settings
                
                designerObject.RecalcTableLayout = menuFileOptionsRecalcTableLayout.Checked;
                
                #endregion

                listLabel.DesignerObjects.Add(designerObject);

                // Switch to the List & Label Designer to layout the project
                listLabel.Design("TX Text Control with List & Label", LlProject.List, projectFileName, false);
                
                // Free the designer object
                listLabel.DesignerObjects.Remove(designerObject);
                designerObject.Dispose();
            }
			catch (LL_User_Aborted_Exception)
			{
				// Do nothing here, because the user cancelled the current List & Label action
			}
			catch(ListLabelException exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void MenuPrintPrint_Click(object sender, EventArgs e)
		{
			try
			{
				// Create designer object and declare it to List & Label
				listLabel.DesignerObjects.Clear();
                TXDesignerObject designerObject = new TXDesignerObject("TXTextObjectName", "TXTextObjectDescription", iconFileName, listLabel);

                #region Additional Settings
                
                designerObject.RecalcTableLayout = menuFileOptionsRecalcTableLayout.Checked;

                #endregion

                listLabel.DesignerObjects.Add(designerObject);

                // Print/Export the project
				listLabel.AutoShowSelectFile = false;
                listLabel.AutoShowPrintOptions = false;
                listLabel.AutoDestination = LlPrintMode.Preview;
				listLabel.Print(LlProject.List, projectFileName);
				
                // Free the designer object
                listLabel.DesignerObjects.Remove(designerObject);
                designerObject.Dispose();
			}
			catch(LL_User_Aborted_Exception)
			{
				// Do nothing here, because the user cancelled the current List & Label action
			}
			catch(ListLabelException exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

        #region Helpers

        private void UpdateLLDataSource()
        {
            // Add dummy datasource to force List & Label to work in data binding mode (e.g. real data preview in designer)
            DataTable dt = new DataTable("Person");
            dt.Columns.Add("Name");
            dt.Columns.Add("Firstname");
            dt.Columns.Add("Salutation");

            DataRow dr = null;
            
            dr = dt.NewRow();
            dr["Name"] = "Doe";
            dr["Firstname"] = "John";
            dr["Salutation"] = "Dear Mr.";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "Doe";
            dr["Firstname"] = "Jane";
            dr["Salutation"] = "Dear Mrs.";
            dt.Rows.Add(dr);
            
            listLabel.SetDataBinding(dt, "Person");
            listLabel.AutoMasterMode = LlAutoMasterMode.AsVariables;
            listLabel.Variables.Add("RTFVariable", GetRTFContentFromFile(documentFileName), LlFieldType.RTF);
        }

        private void LoadRTFFile(string documentFileName)
        {
            try
            {
                FileStream fileStreamToRead = new FileStream(documentFileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fileStreamToRead);
                listLabelRTFControl.Content = sr.ReadToEnd();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private string GetRTFContentFromFile(string documentFileName)
        {
            FileStream fileStreamToRead = new FileStream(documentFileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fileStreamToRead);
            return sr.ReadToEnd();
        }

        #endregion
    }
}

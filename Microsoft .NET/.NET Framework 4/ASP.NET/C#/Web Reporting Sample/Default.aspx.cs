using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using combit.Reporting.Repository;
using System.Linq;

namespace WebReporting
{
    /// <summary>
    /// Summary description for Default.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //D:    ComboBox mit den Listen fuellen
            //US:   Fill combobox with the available reports
            if (!Page.IsPostBack)
            {
                FillCombo();
                ContentContainer.Attributes["src"] = Request.ApplicationPath.TrimEnd('/') +  "/SamplePages/StartPage.aspx";
            }

            string t = DropDownListProjectFile.SelectedValue;
        }

        private void FillCombo()
        {
            try
            {
                //D: List Projekte der DropDownlist hinzufügen
                //US: Get all files from the \Reports directory
                DropDownListProjectFile.Items.Clear();

                List<ListItem> reportList = new List<ListItem>();

                foreach (var repositoryItem in RepositoryHelper.GetCurrentRepository().GetAllItems().OfType<CustomizedRepostoryItem>())
                {
                    if (RepositoryItemType.IsProjectType(repositoryItem.Type, false) && repositoryItem.ShowInToolbar)
                    {
                        reportList.Add(new ListItem(repositoryItem.ExtractDisplayName() ?? repositoryItem.InternalID, repositoryItem.InternalID));
                    }

                }
                reportList.Sort((a, b) => a.Text.CompareTo(b.Text));
                DropDownListProjectFile.DataTextField = "Text";
                DropDownListProjectFile.DataValueField = "Value";
                DropDownListProjectFile.DataSource = reportList;
                DropDownListProjectFile.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void DesignReport(object sender, System.EventArgs e)
        {
            if (DropDownListProjectFile.SelectedItem != null)
            {
                //D: Ausgewählte Projektdatei und Format
                //US: Get the choosen project file and format
                string reportRepositoryID = DropDownListProjectFile.SelectedItem.Value;
                ContentContainer.Attributes["src"] = String.Format("{0}/SamplePages/WebDesignerLauncher.aspx?reportRepositoryID={1}", Request.ApplicationPath.TrimEnd('/'), reportRepositoryID);
            }
        }

        protected void CreateNewProject(object sender, System.EventArgs e)
        {
            ContentContainer.Attributes["src"] = Request.ApplicationPath.TrimEnd('/') + "/SamplePages/AddItem.aspx";
        }


        protected void StartPage(object sender, System.EventArgs e)
        {
            ContentContainer.Attributes["src"] = Request.ApplicationPath.TrimEnd('/') + "/SamplePages/StartPage.aspx";
        }

        protected void ViewReport()
        {
            if (DropDownListProjectFile.SelectedItem != null)
            {
                //D: Ausgewählte Projektdatei und Format
                //US: Get the choosen project file and format
                string reportRepositoryID = DropDownListProjectFile.SelectedItem.Value;
                ContentContainer.Attributes["src"] = Request.ApplicationPath.TrimEnd('/') + "/SamplePages/HTML5Viewer.aspx?reportRepositoryID=" + reportRepositoryID;
            }
        }

        protected void DropDownListProjectFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewReport();
        }
    }
}

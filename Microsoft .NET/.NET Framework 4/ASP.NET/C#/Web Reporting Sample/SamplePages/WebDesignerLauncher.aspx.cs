using System;
using combit.ListLabel25;
using combit.ListLabel25.Repository;

namespace WebReporting
{
    // D:   Liefert eine Seite mit einer HTML/Javascript-Komponente, die den Start des Web Designers auf dem Client auslöst.
    // US:  Returns a page that contains a HTML/Javascript component which will triggert the start of the Web Designer on the client.
    public partial class WebDesignerLauncher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListLabel LL = new ListLabel();
            try
            {
                string reportRepositoryID = Request.QueryString["reportRepositoryID"];

                if (!RepositoryItem.IsValidItemId(reportRepositoryID))
                {
                    ErrorLabel.Text = "RepositoryID invalid!";
                    ErrorLabel.Visible = true;
                    DesignerControl1.Visible = false;
                }
                else if (!RepositoryHelper.GetCurrentRepository().ContainsItem(reportRepositoryID))
                {
                    ErrorLabel.Text = "The selected project does not exist!";
                    ErrorLabel.Visible = true;
                    DesignerControl1.Visible = false;
                }
                else
                {
                    // D:   Lade die zum Report passende Datenquelle.
                    // US:  Get the corresponding data source for the report.
                    LL.DataSource = RepositoryHelper.GetDataSourceForProject(reportRepositoryID);

                    // D:   Die Referenz auf das Repository muss an List & Label übergeben werden, damit die Repository-ID des Projekts für 'AutoProjectFile' akzeptiert wird.
                    // US:  The repository reference must be passed to List & Label to make the repository ID of the project a valid value for the 'AutoProjectFile' property.
                    LL.FileRepository = RepositoryHelper.GetCurrentRepository();

                    // D:   Anstelle des lokalen Dateipfads wird bei Verwendung von Repositories die ID der Datei im Repository verwendet.
                    // US:  When using a repository, the ID of the repository item has to be set instead of the local file path.
                    LL.AutoProjectFile = reportRepositoryID;
                    LL.AutoProjectType = RepositoryItemType.ToLlProject(RepositoryHelper.GetCurrentRepository().GetItem(reportRepositoryID).Type);

                    this.DesignerControl1.ParentComponent = LL;
                }
            }
            catch (combit.ListLabel25.ListLabelException ex)
            {
                Response.Write(ex.Message);
                LL.Dispose();
            }
        }
    }
}

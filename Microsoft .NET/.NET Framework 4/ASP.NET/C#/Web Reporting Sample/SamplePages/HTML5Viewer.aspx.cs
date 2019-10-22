using combit.ListLabel25;
using combit.ListLabel25.Repository;
using combit.ListLabel25.Web;
using System;
using System.IO;
using System.Web;

namespace WebReporting
{
    // D:   �ffnet den Html5Viewer f�r das Projekt mit der angegebenen Repository-ID
    // US:  Loads the Html5Viewer for the project with with specified repository ID.
    public partial class HTML5Viewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string reportRepositoryID = Request.QueryString["reportRepositoryID"];
            if (reportRepositoryID != null)
            {
                if (!RepositoryItem.IsValidItemId(reportRepositoryID))
                {
                    throw new HttpException(404, "Bad Request");
                }

                if (!RepositoryHelper.GetCurrentRepository().ContainsItem(reportRepositoryID))
                {
                    LabelError.Text = "The selected project does not exist";
                    LabelError.Visible = true;
                    Html5ViewerControl1.Visible = false;
                    return;
                }

                if (RepositoryHelper.GetCurrentRepository().GetItem(reportRepositoryID).IsEmpty)
                {
                    LabelError.Text = "The selected project is empty. Please run the Designer first.";
                    LabelError.Visible = true;
                    Html5ViewerControl1.Visible = false;
                    return;
                }

                // D:   'ReportName' wird im OnListLabelRequest-Event wieder zur�ckgeliefert, wo der Pfad zur Projektdatei gesetzt werden muss.
                //      Anstelle des lokalen Dateipfads wird bei Verwendung von Repositories die ID der Datei im Repository verwendet.
                // US:  The report name is returned in the OnListLabelRequest Event, where we need to set the project file.
                //      When using a repository, the ID of the repository item has to be set instead of the local file path.
                this.Html5ViewerControl1.ReportName = reportRepositoryID;

                // D:   Html5ViewerControl Options
                // US:  Html5ViewerControl options
                Html5ViewerOptions options = new Html5ViewerOptions();
                options.OnListLabelRequest += Services_OnListLabelRequest;
                options.UseUIMiniStyle = true;
                this.Html5ViewerControl1.Options = options;
            }
        }


        //D: Dieses Ereignis wird vom Html5Viewer ausgel�st
        //US: This event will be triggered by the Html5Viewer
        void Services_OnListLabelRequest(object sender, ListLabelRequestEventArgs e)
        {
            string repositoryIdOfProject = e.ReportName;

            // D: List & Label Objekt erzeugen 
            // US: Create List & Label object 
            ListLabel ll = new ListLabel();

            // D:   Lizenzschl�ssel f�r List & Label setzen. Auf Nicht-Entwicklungsrechnern wird ein Lizenzfehler angezeigt, falls dieser nicht gesetzt wurde.
            // US:  Set license key for List & Label (client + server). If not set, a license error will be displayed on non-development machines.
            // ll.LicensingInfo = "insert license here";

            try
            {
                // D:   Die Referenz auf das Repository muss an List & Label �bergeben werden, damit die Repository-ID des Projekts f�r 'AutoProjectFile' akzeptiert wird.
                // US:  The repository reference must be passed to List & Label to make the repository ID of the project a valid value for the 'AutoProjectFile' property.
                ll.FileRepository = RepositoryHelper.GetCurrentRepository();
                ll.AutoProjectFile = repositoryIdOfProject;

                // D:   Lade die zum Report passende Datenquelle.
                // US:  Get the corresponding data source for the report.
                ll.DataSource = RepositoryHelper.GetDataSourceForProject(repositoryIdOfProject);

                // D:   Der Html5Viewer ben�tigt ein Verzeichnis f�r tempor�re Dateien. Diese werden einige Minuten nach Schlie�en eines Html5Viewers automatisch gel�scht.
                // US:  The Html5Viewer requires a directory for temporary files. Some minutes after a Html5Viewer is closed, these files will be deleted automatically.
                e.ExportPath = Path.Combine(Global.TempDirectory, Guid.NewGuid().ToString("D"));

                e.NewInstance = ll;
            }
            catch (ListLabelException LlException)
            {
                Response.Write("<br><br><b>An error occurred:</b> " + LlException.Message);
                ll.Dispose();
                return;
            }
        }
    }


}

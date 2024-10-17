using combit.Reporting;
using combit.Reporting.Web.WebReportViewer;


namespace ReactWebReportingSample.Controllers
{
   
    public class LLWebReportViewerController : WebReportViewerController
    {
        public override void OnProvideListLabel(ProvideListLabelContext provideListLabelContext)
        {
            string repositoryIdOfProject = provideListLabelContext.ProjectName;
            
            ListLabel ll = DefaultSettings.GetListLabelInstance(repositoryIdOfProject, DefaultSettings.GetBaseRepository());
            // D:   Diese Zeile einkommentieren, wenn verschiedene Zeilendefinitionen verwendet werden und diese im Browser nicht exakt bündig gerendert werden
            // US:  Uncomment this line if different line definitions are used and they are not rendered exactly flush in the browser
            // ll.Core.LlXSetParameter(LlExtensionType.Export, "HTML5", "XHTML.ForceTableLineOneHundredPercentageWidth", "1");

            // D:   Der WebReportViewer benötigt ein Verzeichnis für temporäre Dateien. Diese werden einige Minuten nach Schließen eines WebReportViewer automatisch gelöscht.
            // US:  The WebReportViewer requires a directory for temporary files. Some minutes after a WebReportViewer is closed, these files will be deleted automatically.
            provideListLabelContext.ExportPath = Server.MapPath("~/App_Data/TempFiles"); //use the same tempDir (Demo)

            provideListLabelContext.NewInstance = ll;
        }

        public override void OnProvideRepository(ProvideRepositoryContext provideRepositoryContext)
        {
            provideRepositoryContext.FileRepository = DefaultSettings.GetBaseRepository();
        }
    }
}
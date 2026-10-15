using combit.Reporting;
using combit.Reporting.Web.WebReportViewer;

namespace VueWebReportingSample.Controllers
{
    /// <summary>
    /// WRV controller - inherits from WebReportViewerController.
    /// Provides the List &amp; Label instance and repository to the viewer.
    /// </summary>
    public class LLWebReportViewerController : WebReportViewerController
    {
        public override void OnProvideListLabel(ProvideListLabelContext provideListLabelContext)
        {
            string repositoryIdOfProject = provideListLabelContext.ProjectName;

            ListLabel ll = DefaultSettings.GetListLabelInstance(
                repositoryIdOfProject,
                DefaultSettings.GetBaseRepository(),
                false,
                provideListLabelContext.Initializing);

            // The WebReportViewer requires a directory for temporary files
            provideListLabelContext.ExportPath = Server.MapPath("~/App_Data/TempFiles");
            provideListLabelContext.NewInstance = ll;
        }

        public override void OnProvideRepository(ProvideRepositoryContext provideRepositoryContext)
        {
            provideRepositoryContext.FileRepository = DefaultSettings.GetBaseRepository();
        }
    }
}

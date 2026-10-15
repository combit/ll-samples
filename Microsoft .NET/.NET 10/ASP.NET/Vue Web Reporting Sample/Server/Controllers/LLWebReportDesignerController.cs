using combit.Reporting;
using combit.Reporting.Web.WebReportDesigner.Server;
using VueWebReportingSample.DataAccess;

namespace VueWebReportingSample.Controllers
{
    /// <summary>
    /// WRD controller - inherits from WebReportDesignerController.
    /// Provides the List &amp; Label instance, repository, and prohibited actions to the designer.
    /// </summary>
    public class LLWebReportDesignerController : WebReportDesignerController
    {
        public override void OnProvideListLabel(ProvideListLabelContext provideListLabelContext)
        {
            // D:   Den geoeffneten Bericht merken, damit der Designer beim naechsten Start wieder
            //      dort weitermacht.
            // US:  Remember the opened report so the designer resumes there on the next start.
            DefaultSettings.RememberOpenedProject(provideListLabelContext.RepositoryId);

            ListLabel ll = DefaultSettings.GetListLabelInstance(
                provideListLabelContext.RepositoryId,
                null,
                provideListLabelContext.IsPrinterless,
                provideListLabelContext.Initializing);

            provideListLabelContext.NewInstance = ll;
        }

        public override void OnProvideRepository(ProvideRepositoryContext provideFileRepositoryContext)
        {
            provideFileRepositoryContext.FileRepository = DefaultSettings.GetBaseRepository();
        }

        public override void OnProvideProhibitedActions(ProvideProhibitedActionsContext provideProhibitedActionsContext)
        {
            foreach (WebReportDesignerAction action in DefaultSettings.GetProhibitedActions())
            {
                provideProhibitedActionsContext.ProhibitedActions.Add(action);
            }
        }
    }
}

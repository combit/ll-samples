using System.Security.Principal;
using System.Web;
using combit.Reporting;
using combit.Reporting.Web.WebReportDesigner.Server;
using combit.Reporting.Web.WebReportDesigner.Server.JsonModels;

namespace ReactMVCWebReportingSample.Controllers
{
    public class LLWebReportDesignerController : WebReportDesignerController
    {
        public override void OnProvideListLabel(ProvideListLabelContext provideListLabelContext)
        {
            ListLabel ll = DefaultSettings.GetListLabelInstance(provideListLabelContext.RepositoryId);

            provideListLabelContext.NewInstance = ll;
        }

        public override void OnProvideRepository(ProvideRepositoryContext provideFileRepositoryContext)
        {
            provideFileRepositoryContext.FileRepository = DefaultSettings.GetBaseRepository();
        }

        public override void OnProvideWebReportDesignerSessionOptions(ProvideWebReportDesignerSessionOptionsContext provideWebReportDesignerSessionOptionsContext)
        {
            base.OnProvideWebReportDesignerSessionOptions(provideWebReportDesignerSessionOptionsContext);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using combit.Reporting;
using combit.Reporting.Web.WebReportDesigner.Server;
using combit.Reporting.Web.WebReportDesigner.Server.JsonModels;

namespace WebReporting.Controllers
{
    public class LLWebReportDesignerController : WebReportDesignerController
    {
        public override void OnProvideListLabel(ProvideListLabelContext provideListLabelContext)
        {
            ListLabel ll = DefaultSettings.GetListLabelInstance(provideListLabelContext.RepositoryId, null);

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
            base.OnProvideProhibitedActions(provideProhibitedActionsContext);
        }
    }
}
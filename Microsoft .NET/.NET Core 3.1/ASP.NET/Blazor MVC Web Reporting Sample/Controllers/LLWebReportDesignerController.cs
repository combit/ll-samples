﻿using combit.Reporting;
using combit.Reporting.Web.WebReportDesigner.Server;
using Microsoft.AspNetCore.Authorization;

namespace WebReporting.Controllers
{
    [Authorize]
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
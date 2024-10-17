using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using combit.Reporting;
using combit.Reporting.Web.WebReportDesigner.Server;
using combit.Reporting.Web.WebReportDesigner.Server.JsonModels;
using Microsoft.AspNetCore.Authorization;

namespace MvcWebReportingSample.Controllers
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
            foreach (WebReportDesignerAction action in DefaultSettings.GetProhibitedActions())
            {
                provideProhibitedActionsContext.ProhibitedActions.Add(action);
            }
        }

        public override void OnProvideFileUploadExtensions(ProvideFileUploadExtensions provideFileUploadExtensions)
        {
            //D:    Benutzerdefinierte und kommaseparierte Liste der hochladbaren Dateiformate des Web Report Designer
            //      WICHTIG: Die Projekttypen können variieren, je nachdem, wie die Dateierweiterungen über ListLabel.FileExtensions.SetFileExtension(LlProjectType, LlFileType) festgelegt wurden.
            //US:   Customized and comma-separated list of uploadable file formats of the Web Report Designer
            //      IMPORTANT: Project types can vary depending on how the file extensions are set through ListLabel.FileExtensions.SetFileExtension(LlProjectType, LlFileType).

            string generalTypes = ".pdf";
            string imageTypes = ".jpg,.jpeg,.png,.gif,.svg,.bmp,.emf,.tif,.tiff";

            if (DefaultSettings.GetListLabelInstance(provideFileUploadExtensions.RepositoryId, null).Language == LlLanguage.German)
            {
                string projectTypes = ".blg,.brf,.crd,.dfm,.gtc,.gtx,.idx,.lbl,.loc,.lsr,.lst,.toc";
                provideFileUploadExtensions.FileExtensions = generalTypes + "," + imageTypes + "," + projectTypes;
            }
            else if (DefaultSettings.GetListLabelInstance(provideFileUploadExtensions.RepositoryId, null).Language == LlLanguage.English)
            {
                string projectTypes = ".crd,.gtc,.gtx,.idx,.inv,.lab,.loc,.rpt,.srt,.toc,.ufm";
                provideFileUploadExtensions.FileExtensions = generalTypes + "," + imageTypes + "," + projectTypes;                
            }

        }

    }
}
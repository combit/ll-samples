
using combit.Reporting;
using combit.Reporting.DataProviders;
using combit.Reporting.Web.WebReportDesigner.Server;
using Newtonsoft.Json;

namespace ReactWebReportingSample.Controllers
{
    
    public class LLWebReportDesignerController : WebReportDesignerController
    {
        public override void OnProvideListLabel(ProvideListLabelContext provideListLabelContext)
        {
            ListLabel ll = DefaultSettings.GetListLabelInstance(provideListLabelContext.RepositoryId);

            //D:    Abrufen der ServerData und ClientData von provideListLabelContext. 
            //US:   Getting the ServerData and ClientData properties from provideListLabelContext.
            string clientData = string.Empty;
            string serverData = string.Empty;

            if (provideListLabelContext.ServerData != null && !string.IsNullOrEmpty(provideListLabelContext.ServerData.ToString()))
            {
                dynamic testData = JsonConvert.DeserializeObject((string)provideListLabelContext.ServerData);
                serverData = testData.testdata.ToString();
            }

            if (provideListLabelContext.ClientData != null && !string.IsNullOrEmpty(provideListLabelContext.ClientData.ToString()))
            {
                dynamic testData = JsonConvert.DeserializeObject((string)provideListLabelContext.ClientData);
                clientData = testData.testdata.ToString();
            }

            //D:    Einfaches Beispiel zur Verwendung der ServerData Objekte
            //US:   Simple example on how to use the ServerData objects.
            ll.Variables.Add("serverData", serverData);
            ll.Variables.Add("ClientData", clientData);

            provideListLabelContext.NewInstance = ll;
        }

        public override void OnProvideRepository(ProvideRepositoryContext provideFileRepositoryContext)
        {
            provideFileRepositoryContext.FileRepository = DefaultSettings.GetBaseRepository();
        }

        public override void OnProvideWebReportDesignerSessionOptions(ProvideWebReportDesignerSessionOptionsContext provideWebReportDesignerSessionOptionsContext)
        {
            base.OnProvideWebReportDesignerSessionOptions(provideWebReportDesignerSessionOptionsContext);

            //D:    Definition des ServerData Strings.
            //US:   Defining the ServerData string.
            provideWebReportDesignerSessionOptionsContext.Options.ServerData = "{\"testdata\":\"Im also a testData object\"}";
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
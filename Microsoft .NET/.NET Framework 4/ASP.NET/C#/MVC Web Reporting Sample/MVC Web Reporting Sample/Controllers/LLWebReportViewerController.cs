using combit.Reporting;
using combit.Reporting.Web.WebReportViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebReporting.Controllers
{
    public class LLWebReportViewerController : WebReportViewerController
    {
        public override void OnProvideListLabel(ProvideListLabelContext provideListLabelContext)
        {
            string repositoryIdOfProject = provideListLabelContext.ProjectName;
            ListLabel ll = DefaultSettings.GetListLabelInstance(repositoryIdOfProject, DefaultSettings.GetBaseRepository());

            ll.Core.LlXSetParameter(LlExtensionType.Export, "HTML5", "XHTML.ForceTableLineOneHundredPercentageWidth", "1");
            // D:   Der WebReportViewer benötigt ein Verzeichnis für temporäre Dateien. Diese werden einige Minuten nach Schließen eines WebReportViewer automatisch gelöscht.
            // US:  The WebReportViewer requires a directory for temporary files. Some minutes after a WebReportViewer is closed, these files will be deleted automatically.
            provideListLabelContext.ExportPath = SampleWebReportingApplication.TempDirectory; //use the same tempDir (Demo)
			
            //LL.Variables.Add("ArtikelListe.ArtikelNr.Von", string.Empty);
            //LL.Variables.Add("ArtikelListe.ArtikelNr.Bis", string.Empty);

            ll.Variables.Add("ItemList.ItemNo.From", string.Empty);
            ll.Variables.Add("ItemList.ItemNo.To", string.Empty);

            provideListLabelContext.NewInstance = ll;
        }

        public override void OnProvideRepository(ProvideRepositoryContext provideFileRepositoryContext)
        {
            provideFileRepositoryContext.FileRepository = DefaultSettings.GetBaseRepository();
        }

    }
}
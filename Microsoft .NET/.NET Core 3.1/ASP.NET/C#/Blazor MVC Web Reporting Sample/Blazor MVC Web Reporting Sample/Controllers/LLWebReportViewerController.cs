﻿using combit.Reporting;
using combit.Reporting.Web.WebReportViewer;
using System;
using System.IO;


namespace WebReporting.Controllers
{
	public class LLWebReportViewerController : WebReportViewerController
    {
        public override void OnProvideListLabel(ProvideListLabelContext provideListLabelContext)
        {
            string repositoryIdOfProject = provideListLabelContext.ProjectName;
            ListLabel ll = DefaultSettings.GetListLabelInstance(repositoryIdOfProject, DefaultSettings.GetBaseRepository());

            // D:   Der WebReportViewer benötigt ein Verzeichnis für temporäre Dateien. Diese werden einige Minuten nach Schließen eines WebReportViewer automatisch gelöscht.
            // US:  The WebReportViewer requires a directory for temporary files. Some minutes after a WebReportViewer is closed, these files will be deleted automatically.
            provideListLabelContext.ExportPath = Server.MapPath("~/App_Data/TempFiles"); //use the same tempDir (Demo)
			
            //LL.Variables.Add("ArtikelListe.ArtikelNr.Von", string.Empty);
            //LL.Variables.Add("ArtikelListe.ArtikelNr.Bis", string.Empty);

            ll.Variables.Add("ItemList.ItemNo.From", string.Empty);
            ll.Variables.Add("ItemList.ItemNo.To", string.Empty);

            provideListLabelContext.NewInstance = ll;
        }

        public override void OnProvideRepository(ProvideRepositoryContext provideRepositoryContext)
        {
            provideRepositoryContext.FileRepository = DefaultSettings.GetBaseRepository();
        }
    }
}
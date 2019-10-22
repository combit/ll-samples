using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;
using combit.ListLabel25;
using combit.ListLabel25.DataProviders;
using combit.ListLabel25.Dom;


namespace combit.Services
{

    /// <summary>
    /// Summary description for ReportingService
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]        
    [ScriptService]
    public sealed class ReportingService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public Response<Report[]> GetReportTemplates(string dataSourceId)
        {
            try
            {
                // D: Alle Berichte zur Datenquelle auslesen
                // US: Read all reports by data source
                string serverReportsPath = Server.MapPath("~/reports") + "\\" + dataSourceId;
                List<string> paths = new List<string>();
                paths.AddRange(Directory.GetFiles(serverReportsPath, "*.lst"));
                paths.AddRange(Directory.GetFiles(serverReportsPath, "*.lbl"));
                paths.AddRange(Directory.GetFiles(serverReportsPath, "*.crd"));

                List<Report> reports = new List<Report>();

                string image, description;
                foreach (var report in paths)
                {
                    image = GetReportImageUrl(dataSourceId, report);
                    description = GetReportDescription(report);

                    reports.Add(new Report(dataSourceId, report, description, image));
                }

                return new Response<Report[]>(reports.ToArray());
            }
            catch (Exception)
            {
                return new Response<Report[]>(new Error("<error no data>"));
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public Response<DataSource[]> GetDataSources()
        {
            // D: Alle Datenquellen holen
            // US: Get all data sources
            try
            {
                return new Response<DataSource[]>(new DataSource[]
                                                    {
                                                        new DataSource( "OLEDB", "Access datasource", "Northwind Access Database", "images/database.png"),
                                                        new DataSource( "OBJECT", "Object datasource", "Object Data Provider", "images/database.png"),
                                                        new DataSource( "XML1", "XML1 datasource", "Datasource Description", "images/database.png"),                                                       
                                                        new DataSource( "XML2", "XML2 datasource", "CRM Customer Data", "images/database.png"),                                                        
                                                        new DataSource( "JSON", "JSON datasource", "CRM Customer Data", "images/database.png"),
                                                        new DataSource( "CSV", "CSV datasource", "IIS Logfile", "images/database.png")
                                                        
                                                        // D: Hier können zusätzliche Datenquellen angefügt werden
                                                        // US: Add more data sources here
                                                    });
            }
            catch (Exception)
            {
                return new Response<DataSource[]>(new Error(1000, "<error no data>"));
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Response<string> Print(string dataSourceId, string report, string format)
        {
            string reportresult = string.Empty;
            try
            {
                IDataProvider provider = null;
                string dataMember = string.Empty;

                //D: Datenquelle auswählen
                //US: Chose data source
                switch (dataSourceId.ToUpperInvariant())
                {
                    case "XML1":
                        provider = new XmlDataProvider(Path.Combine(Server.MapPath("~/App_Data/"), "data.xml"));
                        dataMember = "book";
                        break;
                    case "XML2":
                        provider = new XmlDataProvider(Path.Combine(Server.MapPath("~/App_Data"), "data2.xml"));
                        dataMember = "Companies";
                        break;                    
                    case "JSON":
                        provider = new JsonDataProvider(File.ReadAllText(Path.Combine(Server.MapPath("~/App_Data"), "data.json")));
                        break;
                    case "OBJECT":
                        provider = new ObjectDataProvider(GenericList.GetGenericList());
                        break;
                    case "OLEDB":
                        provider = new OleDbConnectionDataProvider(new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Mode=Read;data source=" + Path.Combine(Server.MapPath("~/App_Data/"), "NWIND.MDB")));
                        dataMember = "Customers";
                        break;
                    case "CSV":
                        provider = new CsvDataProvider(Path.Combine(Server.MapPath("~/App_Data"), "iislog.csv"), true, "Log", '\t', 0, false);
                        break;
                    default:
                        return new Response<string>(new Error("Wrong Datasource: " + dataSourceId.ToUpperInvariant()));
                }

                //D: Export Format auswählen
                //US: Chose export formats
                string extension = string.Empty;
                LlExportTarget exportTarget = LlExportTarget.Pdf;
                switch (format.ToUpperInvariant())
                {
                    case "PDF":
                        extension = ".pdf";
                        exportTarget = LlExportTarget.Pdf;
                        break;
                    case "DOCX":
                        extension = ".docx";
                        exportTarget = LlExportTarget.Docx;
                        break;
                    case "XLSX":
                        extension = ".xlsx";
                        exportTarget = LlExportTarget.Xlsx;
                        break;
                    case "RTF":
                        extension = ".rtf";
                        exportTarget = LlExportTarget.Rtf;
                        break;
                    case "MHTML":
                        extension = ".mht";
                        exportTarget = LlExportTarget.Mhtml;
                        break;
                    case "MTIFF":
                        extension = ".tif";
                        exportTarget = LlExportTarget.MultiTiff;
                        break;
                    default:
                        return new Response<string>(new Error("Wrong Format: " + format.ToUpperInvariant()));
                }

                // D: List & Label Objekt erzeugen und exportieren
                // US: Create List & Label object and export
                using (ListLabel ll = new ListLabel())
                {
                    ll.DataSource = provider;

                    if (!string.IsNullOrEmpty(dataMember))
                        ll.DataMember = dataMember;

                    // D: Eindeutigen Dateinamen erzeugen
                    // US: Create unique filename
                    reportresult = "Report." + Guid.NewGuid() + extension;
                    string outputFile = System.IO.Path.GetTempPath() + reportresult;

                    ll.ExportOptions.Clear();
                    ll.ExportOptions.Add(LlExportOption.PdfFontMode, "6");

                    // D: Export starten
                    // US: Start export
                    ExportConfiguration exportConfiguration = new ExportConfiguration(exportTarget, outputFile, Server.MapPath("~/reports/") + dataSourceId + "/" + report)
                    {
                        ProjectType = ll.Core.LlUtilsGetProjectType(Server.MapPath("~/reports/") + dataSourceId + "/" + report)
                    };
                    ll.Export(exportConfiguration);
                }
            }
            catch (ListLabelException llException)
            {
                System.Diagnostics.Trace.WriteLine("Print : \nList & Label Exception:" + llException.Message);
                return new Response<string>(new Error("Information: " + llException.Message + "\n\nThis information was generated by a List & Label custom exception."));
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine("Print : \n Exception:" + e.ToString());
                return new Response<string>(new Error(e.ToString()));
            }

            return new Response<string>(reportresult);
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Response<ReportFormat[]> GetAvailableFormats()
        {
            //D: Verfügbar Export Formate
            //US: available export formats
            return new Response<ReportFormat[]>(new ReportFormat[]
                                                    {
                                                        new ReportFormat( "PDF", "Portable Document Format", ""),
                                                        new ReportFormat( "DOCX", "Microsoft Word Format", ""),
                                                        new ReportFormat( "RTF", "Richtext Format", ""),
                                                        new ReportFormat( "XLSX", "Microsoft Excel Format", ""),
                                                        new ReportFormat( "MHTML", "MIME HTML Format", ""),
                                                        new ReportFormat( "MTIFF", "Multipage Tagged Image File Format", "")
                                                        
                                                        // D: Hier können zusätzliche Exportformate angefügt werden
                                                        // US: Add more export formats here
                                                    });
        }

        internal static string GetReportImageUrl(string dataSourceId, string report)
        {
            // D: Bild URL zu Bericht holen
            // US: Get image URL to report
            try
            {
                string reportDir = "/reports/" + dataSourceId + "/";
                switch (Path.GetExtension(report))
                {
                    case ".lst":
                        return reportDir + Path.GetFileName(Path.ChangeExtension(report, "lsv"));
                    case ".lbl":
                        return reportDir + Path.GetFileName(Path.ChangeExtension(report, "lbv"));
                    case ".crd":
                        return reportDir + Path.GetFileName(Path.ChangeExtension(report, "crv"));
                    default:
                        return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        internal string GetReportDescription(string report)
        {
            // D: Bericht Beschreibung holen (über DOM)
            // US: Get report description (using DOM)
            string description = string.Empty;
            try
            {
                using (ListLabel ll = new ListLabel())
                {
                    ProjectBase project = null;
                    switch (ll.Core.LlUtilsGetProjectType(report))
                    {
                        case LlProject.List:
                            project = new ProjectList(ll);
                            break;
                        case LlProject.Card:
                            project = new ProjectCard(ll);
                            break;
                        case LlProject.Label:
                            project = new ProjectLabel(ll);
                            break;
                    }

                    project.Open(report, LlDomFileMode.Open, LlDomAccessMode.ReadOnly, true);
                    description = project.ProjectParameters["LL.ProjectDescription"].Contents;
                    project.Close();
					project.Dispose();
                }
            }
            catch (Exception) { }

            return description;
        }
        
    }
}

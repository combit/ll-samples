using System;
using System.Data.OleDb;
using System.Web.Routing;
using combit.ListLabel24;
using combit.ListLabel24.Web;
using combit.ListLabel24.DataProviders;
using System.IO;

namespace ASP.NET_Web_Services
{
    public class Global : System.Web.HttpApplication
    {
        // global List & Label job for better performance
        private ListLabel   _baseLL;
        private string _appDataPath;
        private string _reportsPath;

        protected void Application_Start(object sender, EventArgs e)
        {
            _baseLL = new ListLabel();

            //D: WebAPI des Html5Viewers registrieren. 
            //US: Register the viewer API
            Html5ViewerConfig.RegisterRoutes(RouteTable.Routes);            
            Html5ViewerConfig.OnListLabelRequest += Services_OnListLabelRequest;

            _appDataPath = Server.MapPath("~/App_Data");
            _reportsPath = Server.MapPath("~/reports/");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _baseLL.Dispose();
        }

        //D: Dieses Ereignis wird vom Html5Viewer ausgelöst
        //US: This event will be triggerd by the Html5Viewer
        void Services_OnListLabelRequest(object sender, ListLabelRequestEventArgs e)
        {
            IDataProvider provider = null;
            string dataMember = string.Empty;
            
            // we use the instanceName 
            string[] reportParts = e.ReportName.Split('|');
            string  report = reportParts[0];
            string  dataSourceId = reportParts[1];

            try
            {
                //D: Datenquelle auswählen
                //US: Chose data source
                switch (dataSourceId.ToUpperInvariant())
                {
                    case "XML1":
                        provider = new XmlDataProvider(Path.Combine(_appDataPath, "data.xml"));
                        dataMember = "book";
                        break;
                    case "XML2":
                        provider = new XmlDataProvider(Path.Combine(_appDataPath, "data2.xml"));
                        dataMember = "Companies";
                        break;
                    case "JSON":
                        provider = new JsonDataProvider(File.ReadAllText(Path.Combine(_appDataPath, "data.json")));
                        break;
                    case "OBJECT":
                        provider = new ObjectDataProvider(combit.Services.GenericList.GetGenericList());
                        break;
                    case "OLEDB":
                        provider = new OleDbConnectionDataProvider(new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Mode=Read;data source=" + Path.Combine(_appDataPath, "NWIND.MDB")));
                        dataMember = "Customers";
                        break;
                    case "CSV":
                        provider = new CsvDataProvider(Path.Combine(_appDataPath, "iislog.csv"), true, "Log", '\t', 0, false);
                        break;
                }

                // D: List & Label Objekt erzeugen 
                // US: Create List & Label object 
                ListLabel ll = new ListLabel
                {

                    // you can enable debugging here
                    //ll.Debug = LlDebug.Enabled;

                    DataSource = provider
                };

                if (!string.IsNullOrEmpty(dataMember))
                    ll.DataMember = dataMember;

                ll.AutoProjectFile = _reportsPath + dataSourceId + "/" + report;
                ll.AutoDestination = LlPrintMode.File;
                
                e.ExportPath = Path.GetTempPath();  // set temp directory
                e.NewInstance = ll;                  // return the instance
            }
            catch (ListLabelException llException)
            {
                System.Diagnostics.Trace.WriteLine("Print : \nList & Label Exception:" + llException.Message);
                return;
            }
            catch (Exception baseException)
            {
                System.Diagnostics.Trace.WriteLine("Print : \n Exception:" + baseException.ToString());
                return;
            }
        }
    }
}

using System;

namespace ASP.NET_Web_Services
{
    public partial class ReportResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // D: Berichtnamen im Titel anzeigen
            // US: Show report name in title
            string report = Request.QueryString["file"];
            this.Title = report;
        }
    }
}
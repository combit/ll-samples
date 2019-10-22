using System;

namespace ASP.NET_Web_Services
{
    public partial class Preview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            string instance = Request.QueryString["instance"];
            this.Title = "Preview of "+ instance;

            // D: Diese Eigenschaft dient zur Unterscheidung der verschiedenen Reports (siehe OnListLabelRequest)
            // US: This property helps to distinguish the different reports (see OnListLabelRequest)
            this.Html5ViewerControl1.ReportName = instance;

            // set the options
            this.Html5ViewerControl1.Options.ShowToolbarExportButton = false;
            this.Html5ViewerControl1.Options.UseCDNType = combit.ListLabel25.Web.CDNType.JQuery;
        }
    }
}

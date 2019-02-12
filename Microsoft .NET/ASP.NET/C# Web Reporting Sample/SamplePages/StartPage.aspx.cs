using combit.ListLabel24.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Threading;

namespace WebReporting
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] != null && Request.QueryString["action"] == "DeleteItem")
            {
                string repoItemId = Request.QueryString["reportRepositoryID"];
                if (repoItemId != null)
                {
                    repoItemId = HttpUtility.UrlDecode(repoItemId);
                    if (RepositoryItem.IsValidItemId(repoItemId))
                    {
                        RepositoryHelper.GetCurrentRepository().DeleteItem(repoItemId);
                    }
                }
            }
            else if (Request.QueryString["action"] != null && Request.QueryString["action"] == "DownloadItem")
            {
                string repoItemId = Request.QueryString["reportRepositoryID"];
                if (repoItemId != null)
                {
                    repoItemId = HttpUtility.UrlDecode(repoItemId);
                    if (RepositoryItem.IsValidItemId(repoItemId))
                    {
                        var repository = RepositoryHelper.GetCurrentRepository();
                        var itemToDownload = (CustomizedRepostoryItem)repository.GetItem(repoItemId);

                        // D:    Dateinamen bestimmen. Verwende den ursprünglichen Dateinamen (vor dem Import), den Anzeigenamen (aus dem Designer) oder die RepositoryItem-ID.
                        // US:   Get the file name. Use the original filename (before the import), the display name (from the Designer) or the repository item ID.
                        string fileName = itemToDownload.OriginalFileName;
                        if (string.IsNullOrEmpty(fileName))
                            fileName = itemToDownload.ExtractDisplayName() + ".bin";
                        if (string.IsNullOrEmpty(fileName))
                            fileName = itemToDownload.InternalID + ".bin";

                        using (var memoryStream = new MemoryStream())
                        {
                            repository.LoadItem(repoItemId, memoryStream, CancellationToken.None);
                            Response.Clear();
                            Response.ContentType = "application/octet-stream";
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                            byte[] buffer = memoryStream.ToArray();
                            Response.OutputStream.Write(buffer, 0, buffer.Length);
                            Response.Flush();
                            Response.End();
                        }

                    }
                }

            }

            if (!IsPostBack)
            {
                LiteralReadMe.Text = File.ReadAllText(Server.MapPath("~/Readme.html"));
                IEnumerable<CustomizedRepostoryItem> repositoryItems = RepositoryHelper.GetCurrentRepository().GetAllItems().OfType<CustomizedRepostoryItem>();

                // D:   Sortiere die Liste der Repository-Items alphabetisch nach Anzeigename.
                // US:  Sort the repository item list alphabetically by the display name.
                repositoryItems = from r in repositoryItems
                                  orderby r.ExtractDisplayName() ?? r.InternalID
                                  select r;
                RepeaterRepository.DataSource = repositoryItems;
                RepeaterRepository.DataBind();
            }
        }

        protected void RepeaterRepository_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CustomizedRepostoryItem repoItem = e.Item.DataItem as CustomizedRepostoryItem;

                // D:   Lese den Anzeigenamen des Repository-Items aus. Dieser ist optional und kann null sein! Daher Fallback auf die Repository-ID.
                // US:  Get the repository item's display name. This name is optional and may be null! So fallback to the repository ID.
                ((Label)e.Item.FindControl("LabelItemName")).Text = repoItem.ExtractDisplayName() ?? repoItem.InternalID + " (no display name defined)";

                string encodedId = HttpUtility.UrlEncode(repoItem.InternalID);
                HyperLink linkViewer = (HyperLink)e.Item.FindControl("LinkHtml5Viewer");
                linkViewer.NavigateUrl = "~/SamplePages/HTML5Viewer.aspx?reportRepositoryID=" + encodedId;
                HyperLink linkDesigner = (HyperLink)e.Item.FindControl("LinkDesigner");
                linkDesigner.NavigateUrl = "~/SamplePages/WebDesignerLauncher.aspx?reportRepositoryID=" + encodedId;
                HyperLink linkDownload = (HyperLink)e.Item.FindControl("LinkDownload");
                linkDownload.NavigateUrl = "~/SamplePages/StartPage.aspx?action=DownloadItem&reportRepositoryID=" + encodedId;

                if (RepositoryItemType.IsProjectType(repoItem.Type, false))  // Show Designer/Html5Viewer links only for project files
                {
                    linkViewer.Visible = true;
                    linkDesigner.Visible = true;
                }

                HyperLink linkDelete = (HyperLink)e.Item.FindControl("LinkDelete");
                linkDelete.NavigateUrl = "~/SamplePages/StartPage.aspx?action=DeleteItem&reportRepositoryID=" + encodedId;
            }
        }
    }
}

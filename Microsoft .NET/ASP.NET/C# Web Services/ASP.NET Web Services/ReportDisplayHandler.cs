using System;
using System.Web;
using System.IO;

namespace ASP.NET_Web_Services
{
    public sealed class ReportDisplayHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string contentType = null;

                //e.g.: Report.2c214866-73d4-4544-934a-38f67bb15bc4.pdf
                string fileName = context.Request.FilePath;

                System.Diagnostics.Trace.WriteLine("ReportDisplayHandler::ProcessRequest : FilePath: " + fileName);

                string[] urlParts = fileName.Split('/');

                if (urlParts.Length > 0)
                    fileName = urlParts[urlParts.Length - 1];


                string[] fileParts = fileName.Split('.');
                if (fileParts.Length == 3)
                {
                    contentType = MimeTypes.GetMimeTypeByFileExtension("." + fileParts[2]);
                }

                string reportResultDir = System.IO.Path.GetTempPath();
                string absoluteServerFilePath = reportResultDir + fileName;

                context.Response.Clear();
                context.Response.Buffer = true;

                if (!String.IsNullOrEmpty(contentType) && File.Exists(absoluteServerFilePath))
                {                    
                    context.Response.ContentType = contentType;
                    context.Response.WriteFile(absoluteServerFilePath);
                }

                context.Response.End();

                // delete after using
                if (File.Exists(absoluteServerFilePath))
                    File.Delete(absoluteServerFilePath);
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine("ReportDisplayHandler::ProcessRequest : \nException:" + e.ToString());
            }
        }

        #endregion
    }
}

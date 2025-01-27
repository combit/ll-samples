using System.IO;

namespace BlazorWebReportingSample
{
    public class Server
    {
        public static string MapPath(string path)
        {
            if (HostingEnvironment.Current == null)
            {
                return path.Replace("~", Directory.GetCurrentDirectory());

            }
            else
            {
                return path.Replace("~", HostingEnvironment.Current.ContentRootPath);

            }
        }
    }
}

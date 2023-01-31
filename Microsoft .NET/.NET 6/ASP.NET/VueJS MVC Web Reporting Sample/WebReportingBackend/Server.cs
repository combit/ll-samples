using System.IO;

namespace  VueJsMvcWebReportingSample

{
    public class Server
    {
        public static string MapPath(string path)
        {
            if (HostingEnviroment.Current == null)
            {
                return path.Replace("~", Directory.GetCurrentDirectory());

            }
            else
            {
                return path.Replace("~", HostingEnviroment.Current.ContentRootPath);

            }
        }
    }
}

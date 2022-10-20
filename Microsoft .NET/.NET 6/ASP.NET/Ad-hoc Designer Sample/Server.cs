namespace AdhocDesignerSample
{
    public static class Server
    {
        public static string MapPath(string path)
        {
            return path.Replace("~", HostingEnvironment.Current.ContentRootPath);
        }
    }
}
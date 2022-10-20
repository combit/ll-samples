using Microsoft.AspNetCore.Hosting;

namespace ReactMVCWebReportingSample
{
    public class HostingEnviroment
    {
        public static void Configure(IWebHostEnvironment hostingEnvironment)
        {
            Current = hostingEnvironment;
        }

        public static IWebHostEnvironment? Current { get; private set; }
    }
}

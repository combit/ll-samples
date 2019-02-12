using Microsoft.AspNetCore.Hosting;

namespace WebReporting
{
    public class HostingEnvironment
    {
        public static void Configure(IHostingEnvironment hostingEnvironment)
        {
            Current = hostingEnvironment;
        }

        public static IHostingEnvironment Current { get; private set; }
    }
}

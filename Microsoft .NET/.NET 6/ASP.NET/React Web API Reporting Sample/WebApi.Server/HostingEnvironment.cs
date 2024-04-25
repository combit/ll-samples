namespace WebApi
{
    public class HostingEnvironment
    {
        public static void Configure(IWebHostEnvironment hostingEnvironment)
        {
            Current = hostingEnvironment;
        }

        public static IWebHostEnvironment Current { get; private set; }
    }
}
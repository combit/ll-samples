using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebReporting
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static string RepositoryDatabaseFile { get; set; }
        public static string GanttDatabaseXmlFile { get; set; }
        public static string NorthwindFullDatabaseXmlFile { get; set; }
        public static string NorthwindSmallDatabaseXmlFile { get; set; }
        public static string NorthwindSmallDatabaseWithEmployeeListXmlFile { get; set; }
        public static string TempDirectory { get; set; }


        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseIISIntegration().Build();
        }

    }
}

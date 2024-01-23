using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AdhocDesignerSample
{
    public class Program
    {
        public static string RepositoryDatabaseFile { get; set; }
        public static string NorthwindFullDatabaseXmlFile { get; set; }
        public static string NorthwindFullDatabaseXmlSchemaFile { get; set; }
        public static string TempDirectory { get; set; }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

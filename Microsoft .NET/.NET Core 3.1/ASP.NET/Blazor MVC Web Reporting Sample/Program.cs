﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

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
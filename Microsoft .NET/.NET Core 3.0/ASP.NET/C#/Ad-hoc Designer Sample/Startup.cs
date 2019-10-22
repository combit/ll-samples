using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using combit.ListLabel25.AdhocDesign.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.Loader;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using combit.ListLabel25.AdhocDesign.Web.Controllers;

namespace AdhocDesignerSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
            });

            services.Configure<MvcOptions>(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddAdhocDesigner(c => { });

            services.AddMvc().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            HostingEnvironment.Configure(app.ApplicationServices.GetRequiredService<IWebHostEnvironment>());
            WebReporting.MemoryCache.Configure(app.ApplicationServices.GetRequiredService<IMemoryCache>());
            HttpContext.Configure(app.ApplicationServices.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>());

            Program.RepositoryDatabaseFile = Server.MapPath("~/App_Data/repository.db");
            Program.TempDirectory = Server.MapPath("~/App_Data/TempFiles");
            Program.GanttDatabaseXmlFile = Server.MapPath("~/App_Data/gantt.xml");
            Program.NorthwindFullDatabaseXmlFile = Server.MapPath("~/App_Data/northwind_full.xml");
            Program.NorthwindSmallDatabaseXmlFile = Server.MapPath("~/App_Data/northwind_small.xml");
            Program.NorthwindSmallDatabaseWithEmployeeListXmlFile = Server.MapPath("~/App_Data/northwind_small_WithEmployeeList.xml");

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseAdhocDesigner();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

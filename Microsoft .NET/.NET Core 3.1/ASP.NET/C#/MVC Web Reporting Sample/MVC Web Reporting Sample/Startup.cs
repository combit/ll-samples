﻿using combit.Reporting.Web;
using combit.Reporting.Web.WindowsClientWebDesigner.Server;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace WebReporting
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o => o.LoginPath = "/Sample/Login");
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AuthorizationMode", policy => policy.Requirements.Add(new AuthenticationModeRequirement()));
            });

            var assembly = typeof(Html5ViewerController).GetTypeInfo().Assembly;
            // AddWebApiConventions() for old WebApi, HttpResponseMessage, etc. support
            // AddApplicationPart() to enable routing for external LL assembly. IMPORTANT
            services.AddMvc().AddApplicationPart(assembly);
			services.AddMvc(options =>
            {
                 options.EnableEndpointRouting = false;
				//https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-2.1#special-case-formatters
				//If this formatter is not removed, return null; will result in an NoAction-Response instead of an OK-Response
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddSession();

            services.AddHttpContextAccessor();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Configure internal Singletons
            HostingEnvironment.Configure(app.ApplicationServices.GetRequiredService<IWebHostEnvironment>());
            MemoryCache.Configure(app.ApplicationServices.GetRequiredService<IMemoryCache>());
            HttpContext.Configure(app.ApplicationServices.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>());

            Program.RepositoryDatabaseFile = Server.MapPath("~/App_Data/repository.db");
            Program.TempDirectory = Server.MapPath("~/App_Data/TempFiles");
            Program.GanttDatabaseXmlFile = Server.MapPath("~/App_Data/gantt.xml");
            Program.NorthwindFullDatabaseXmlFile = Server.MapPath("~/App_Data/northwind_full.xml");
            Program.NorthwindSmallDatabaseXmlFile = Server.MapPath("~/App_Data/northwind_small.xml");
            Program.NorthwindSmallDatabaseWithEmployeeListXmlFile = Server.MapPath("~/App_Data/northwind_small_WithEmployeeList.xml");

            // D:   Festlegen, welche Setup-Datei an Clients ohne Web Designer-Installation ausgeliefert wird.
            // US:  Define which setup file to deploy to clients without a Web Designer installation.
            WindowsClientWebDesignerConfig.WindowsClientWebDesignerSetupFile = Server.MapPath("~/WebDesigner/LL26WebDesignerSetup.exe");

            // D:   Für Forms- und Windows Authentifizierung kann der Web Designer automatisch die benötigten Informationen übernehmen (z.B. Login-Cookie).
            //      WebDesignerAuthenticationModes.None erlaubt die Verwendung ohne Authentifizierung.
            // US:  For Forms- and Windows authentication, the Web Designer can automatically grab the required information (e.g. login cookies).
            //      WebDesignerAuthenticationModes.None allows to use no authentication at all.
            WindowsClientWebDesignerConfig.AuthenticationMode = WindowsClientWebDesignerAuthenticationModes.Automatic;

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(RegisterRoutes);
        }

        private void RegisterRoutes(IRouteBuilder routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //D: WebAPI/MVC-Routen von Html5Viewer und Web Designer registrieren. 
            //US: Register the WebAPI/MVC routes of the Html5Viewer and Web Designer.

            routes.MapRoute("Default", "{controller=Sample}/{action=Index}/{id?}");

            Html5ViewerConfig.RegisterRoutes(routes);
            WindowsClientWebDesignerConfig.RegisterRoutes(routes);
        }
    }
}

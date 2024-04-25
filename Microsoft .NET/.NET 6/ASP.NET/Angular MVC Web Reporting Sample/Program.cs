using Microsoft.Extensions.Caching.Memory;
using AngularMVCWebReportingSample;
using combit.Reporting.Web.WebReportDesigner.Server;
using combit.Reporting.Web.WebReportDesigner;
using combit.Reporting.Web.WebReportViewer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddWebReportDesigner();
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

WebReportDesignerHelper.ExtractWebReportDesignerScript(Server.MapPath("~/wwwroot"), "WebReportDesigner.js");
WebReportViewerHelper.ExtractWebReportViewerScript(Server.MapPath("~/wwwroot"), "WebReportViewer.js");

WebReportDesignerConfig.TempDirectory = Server.MapPath("~/App_Data/TempFiles");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Configure internal Singletons
HostingEnvironment.Configure(app.Services.GetRequiredService<IWebHostEnvironment>());
AngularMVCWebReportingSample.MemoryCache.Configure(app.Services.GetRequiredService<IMemoryCache>());

Program.RepositoryDatabaseFile = Server.MapPath("~/App_Data/repository.db");
Program.TempDirectory = Server.MapPath("~/App_Data/TempFiles");
Program.GanttDatabaseXmlFile = Server.MapPath("~/App_Data/gantt.xml");
Program.NorthwindFullDatabaseXmlFile = Server.MapPath("~/App_Data/northwind_full.xml");
Program.NorthwindSmallDatabaseXmlFile = Server.MapPath("~/App_Data/northwind_small.xml");
Program.NorthwindSmallDatabaseWithEmployeeListXmlFile = Server.MapPath("~/App_Data/northwind_small_WithEmployeeList.xml");

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Sample}/{action=Index}/{id?}"); 

app.MapControllerRoute( 
    name: "defaultApi",
    pattern: "api/{controller}/{id?}");

app.MapFallbackToFile("index.html");

app.UseWebReportDesigner();
app.UseWebReportViewer();

app.Run();

public partial class Program
{
    public static string RepositoryDatabaseFile { get; set; }
    public static string GanttDatabaseXmlFile { get; set; }
    public static string NorthwindFullDatabaseXmlFile { get; set; }
    public static string NorthwindSmallDatabaseXmlFile { get; set; }
    public static string NorthwindSmallDatabaseWithEmployeeListXmlFile { get; set; }
    public static string TempDirectory { get; set; }
}
using combit.Reporting.Web.WebReportDesigner;
using combit.Reporting.Web.WebReportDesigner.Server;
using combit.Reporting.Web.WebReportViewer;
using Microsoft.Extensions.Caching.Memory;
using VueWebReportingSample;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddWebReportDesigner();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

WebReportDesignerHelper.ExtractWebReportDesignerScript(Server.MapPath("~/wwwroot"), "WebReportDesigner.js");
WebReportViewerHelper.ExtractWebReportViewerScript(Server.MapPath("~/wwwroot"), "WebReportViewer.js");

// Set WRD temp directory
WebReportDesignerConfig.TempDirectory = Server.MapPath("~/App_Data/TempFiles");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Configure internal singletons
HostingEnvironment.Configure(app.Services.GetRequiredService<IWebHostEnvironment>());
VueWebReportingSample.MemoryCache.Configure(app.Services.GetRequiredService<IMemoryCache>());

// Configure static path properties
Program.RepositoryDatabaseFile = Server.MapPath("~\\App_Data\\repository.db");
Program.TempDirectory = Server.MapPath("~\\App_Data\\TempFiles");
Program.GanttDatabaseXmlFile = Server.MapPath("~/App_Data/gantt.xml");
Program.NorthwindFullDatabaseXmlFile = Server.MapPath("~/App_Data/northwind_full.xml");
Program.NorthwindSmallDatabaseXmlFile = Server.MapPath("~/App_Data/northwind_small.xml");
Program.NorthwindSmallDatabaseWithEmployeeListXmlFile = Server.MapPath("~/App_Data/northwind_small_WithEmployeeList.xml");

// CORS: Allow Vue dev server
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "defaultApi",
    pattern: "api/{controller}/{id?}");

// Fallback to SPA index.html (serves built frontend in production)
app.MapFallbackToFile("index.html");

// Enable List & Label middleware
app.UseWebReportViewer();
app.UseWebReportDesigner();

// In development, the SPA proxy (configured via csproj properties) automatically
// starts the Vue dev server and proxies requests to it.
// In production, the built frontend is served from wwwroot.

app.Run();

public partial class Program
{
    public static string RepositoryDatabaseFile { get; set; } = "";
    public static string GanttDatabaseXmlFile { get; set; } = "";
    public static string NorthwindFullDatabaseXmlFile { get; set; } = "";
    public static string NorthwindSmallDatabaseXmlFile { get; set; } = "";
    public static string NorthwindSmallDatabaseWithEmployeeListXmlFile { get; set; } = "";
    public static string TempDirectory { get; set; } = "";
}

using BlazorServerSample.Components;
using BlazorServerSample.Models;
using BlazorServerSample.Services;

var builder = WebApplication.CreateBuilder(args);

// ── Blazor Server with interactive server-side rendering ──────────────────
// Components that carry @rendermode InteractiveServer are rendered on the
// server and updated in real time via a SignalR connection.  LLCP runs
// entirely server-side here — no WASM compatibility issues.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ── Application services ──────────────────────────────────────────────────
builder.Services.AddScoped<CustomerDataService>();
builder.Services.AddScoped<ReportService>();

var app = builder.Build();

// ── HTTP pipeline ─────────────────────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// ── Minimal API: PDF download endpoint ───────────────────────────────────
// This endpoint generates the customer report entirely on the server and
// streams the PDF bytes directly to the browser.  Because it runs as a
// regular ASP.NET Core request, there are no WASM restrictions, no SignalR
// payload size concerns, and no JS interop required.
app.MapGet("/api/report/customer.pdf", (
    ReportService reportService,
    CustomerDataService customerData) =>
{
    IReadOnlyList<Customer> customers = customerData.GetCustomers();
    byte[] pdfBytes = reportService.GenerateCustomerReport(customers);
    return Results.File(pdfBytes, "application/pdf", "CustomerReport.pdf");
});

app.Run();

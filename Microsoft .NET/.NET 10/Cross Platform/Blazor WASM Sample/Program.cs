using BlazorWasmSample;
using BlazorWasmSample.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register application services via DI.
// Both services are scoped — each Blazor circuit (page load) gets its own instance.
builder.Services.AddScoped<CustomerDataService>();
builder.Services.AddScoped<ReportService>();

await builder.Build().RunAsync();

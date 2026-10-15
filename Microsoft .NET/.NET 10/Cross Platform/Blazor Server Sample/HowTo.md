# List & Label Cross Platform – Blazor Server Sample

A **Blazor Web App with interactive server-side rendering (SSR)** that demonstrates
how to use **List & Label Cross Platform (LLCP)** to generate a PDF report.  
LLCP and SkiaSharp run on the **ASP.NET Core server** — no WebAssembly involved,
so there are no platform-compatibility issues.

---

## Architecture

```
BlazorServerSample/
├── Components/
│   ├── App.razor              # Root HTML document + Blazor bootstrap
│   ├── Routes.razor           # Client-side router
│   ├── _Imports.razor         # Global using directives
│   ├── Layout/
│   │   ├── MainLayout.razor   # Page shell (sidebar + content area)
│   │   ├── NavMenu.razor      # Navigation sidebar
│   │   └── ReconnectModal.razor # SignalR reconnect dialog
│   └── Pages/
│       ├── Home.razor         # Landing page with architecture notes
│       ├── ReportPage.razor   # UI: data preview + Download button
│       └── NotFound.razor     # 404 page
├── Models/
│   └── Customer.cs            # Data model (Id, Name, City, Revenue)
├── Services/
│   ├── CustomerDataService.cs # In-memory list of sample customers
│   └── ReportService.cs       # LLCP DOM integration – builds & exports the PDF
├── Program.cs                 # ASP.NET Core setup, Blazor Server, PDF endpoint
└── wwwroot/                   # Static assets
```

### What runs where

| Layer | Location | Responsibility |
|---|---|---|
| UI (static HTML) | Server | Blazor renders HTML on the server and sends it to the browser |
| UI (interactivity) | Server ↔ Browser via SignalR | `@rendermode InteractiveServer` components update in real time |
| Data | Server | `CustomerDataService` — in-memory `List<Customer>` |
| Report layout | Server | `ReportService.BuildProjectStream` — LLCP DOM API |
| Rendering | Server | LLCP + SkiaSharp render pages to PDF |
| PDF delivery | Server → Browser | Minimal API endpoint streams the PDF as a file attachment |

---

## Prerequisites

| Tool | Version |
|---|---|
| .NET SDK | ≥ 10.0 |
| A modern browser | Chrome, Edge, Firefox |

No extra workloads are required — SkiaSharp is loaded as a regular native NuGet
package (`SkiaSharp.NativeAssets.Linux` for Linux servers).

---

## Quick Start

```bash
# 1. Navigate to the sample
cd "/Development/Microsoft .NET/.NET 10/Cross Platform/Blazor Server Sample"

# 2. Run the dev server
dotnet run

# 3. Open http://localhost:5200
#    Navigate to the "Report" page and click "Download Report"
```

The browser will prompt to save `CustomerReport.pdf`.

---

## How it Works

### 1. Data source

`CustomerDataService` returns a hard-coded `List<Customer>` (7 rows).  
`ObjectDataProvider` wraps the list and exposes it to LLCP under the table name
`"Customer"`, with field names matching the C# property names
(`Customer.Id`, `Customer.Name`, `Customer.City`, `Customer.Revenue`).

### 2. Report layout via DOM API

`ReportService.BuildProjectStream` creates the LLCP project layout **in code**:

```csharp
using var ll = new ListLabel();
using var project = ll.OpenProject(projectStream, LlProject.List);

// Static title text object (coordinates in 1/1000 mm)
var title = project.Objects.AddNewText();
title.Position.Set(20_000, 15_000, 170_000, 12_000);
title.Paragraphs.AddNew().Contents = "\"Customer Revenue Report\"";

// ReportContainer with a dynamic data table
var container = project.Objects.AddNewReportContainer();
container.Position.Set(20_000, 29_000, 170_000, 253_000);

var table = container.SubItems.AddNewTable();
table.TableId = "Customer";   // must match ObjectDataProvider table name

var header = new TableLineHeader(table.Lines.Header);
// … TableFieldText with static label formulas ("\"#\"", "\"Name\"", …) …

var data = new TableLineData(table.Lines.Data);
// … TableFieldText referencing "Customer.Id", "Customer.Name", … …

project.Save();   // serialises to the MemoryStream
```

All coordinates are in **1/1000 mm** (A4 = 210 000 × 297 000).

### 3. Export to PDF and stream to browser

The minimal API endpoint handles the complete request in a single step:

```csharp
// Program.cs
app.MapGet("/api/report/customer.pdf", (
    ReportService reportService,
    CustomerDataService customerData) =>
{
    var customers = customerData.GetCustomers();
    var pdfBytes  = reportService.GenerateCustomerReport(customers);
    return Results.File(pdfBytes, "application/pdf", "CustomerReport.pdf");
});
```

ASP.NET Core sets `Content-Disposition: attachment; filename=CustomerReport.pdf`,
so the browser saves the file rather than navigating to it.

### 4. Interactive Blazor component

The report page uses `@rendermode InteractiveServer` so the "Download" button
click is handled server-side via SignalR:

```razor
@rendermode InteractiveServer

<button @onclick="DownloadReport">Download Report</button>

@code {
    private void DownloadReport()
    {
        // forceLoad = true performs a regular HTTP GET — browser receives the
        // file response and shows the save dialog.
        Navigation.NavigateTo("/api/report/customer.pdf", forceLoad: true);
    }
}
```

---

## Deploying

```bash
dotnet publish -c Release
```

Deploy the published output to any ASP.NET Core-capable host (Azure App Service,
Docker, Linux VM, etc.).  No special workloads or native WASM linking required.

---

## Extending the Sample

| Goal | Where to look |
|---|---|
| Add more data fields | `Customer.cs` + `ReportService.AddDataLine` |
| Use a pre-designed layout | Replace `BuildProjectStream` with loading a `.json` resource |
| Add charts or barcodes | Use `new TableFieldChart(...)` / `new TableFieldBarcode(...)` in `AddDataLine` |
| Swap the data source | Replace `ObjectDataProvider` with `AdoDataProvider`, `SchemaAwareJsonDataProvider`, etc. |
| Replace the project reference | Change `<ProjectReference>` to `<PackageReference Include="combit.ListLabel.CrossPlatform" />` |

---

## Project Reference Note

The sample uses a `<ProjectReference>` to LLCP for local development.
The `SetTargetFramework` metadata pins it to `net10.0` so the build does not
attempt to compile the `net11.0` TFM when the .NET 11 SDK is not installed:

```xml
<ProjectReference Include="...\ListLabel.CrossPlatform.csproj">
  <SetTargetFramework>TargetFramework=net10.0</SetTargetFramework>
</ProjectReference>
```

Replace it with a NuGet reference when consuming the published package:

```xml
<PackageReference Include="combit.ListLabel.CrossPlatform" Version="x.y.z" />
```

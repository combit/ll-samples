# List & Label Cross Platform – Blazor WebAssembly Sample

A **standalone Blazor WebAssembly** application that demonstrates how to integrate
**List & Label Cross Platform (LLCP)** for in-browser PDF report generation.  
No server-side component is required — all rendering happens in the browser via WebAssembly.

---

## Architecture

```
BlazorWasmSample/
├── Models/
│   └── Customer.cs            # Simple data model (Id, Name, City, Revenue)
├── Services/
│   ├── CustomerDataService.cs # In-memory list of sample customers
│   └── ReportService.cs       # LLCP DOM integration – builds & exports the PDF
├── Pages/
│   ├── Home.razor             # Landing page with architecture notes
│   └── ReportPage.razor       # UI: data preview + "Generate Report" button
└── Layout/
    ├── MainLayout.razor
    └── NavMenu.razor
```

### What runs where

| Layer | Location | Responsibility |
|---|---|---|
| UI | Browser (WASM) | Blazor components, button click, loading spinner |
| Data | Browser (WASM) | `CustomerDataService` – in-memory `List<Customer>` |
| Report layout | Browser (WASM) | `ReportService.BuildProjectStream` – DOM API creates the layout |
| Rendering | Browser (WASM) | LLCP + SkiaSharp WASM binary render pages to PDF |
| Download | Browser (WASM) | JS interop creates a Blob URL and triggers `<a>.click()` |

Everything stays in the browser — **no HTTP calls, no backend**.

---

## Prerequisites

| Tool | Version | Notes |
|---|---|---|
| .NET SDK | ≥ 10.0 | `dotnet --version` |
| `wasm-tools` workload | latest | For native SkiaSharp linking at publish time |
| A modern browser | – | Chrome, Edge, Firefox |

Install the WASM workload once:

```bash
dotnet workload install wasm-tools
```

In case that the WASM workload needs to be updated:

```bash
dotnet workload restore
```

---

## Quick Start

```bash
# 1. Run Terminal or Command Line and navigate to the sample
cd "/Development/Microsoft .NET/.NET 10/Cross Platform/Blazor WASM Sample"

# 2. Run the dev server (hot-reload enabled)
dotnet run

# 3. Open http://localhost:5200 in your browser
#    Navigate to the "Report" page and click "Generate Report"
```

A PDF named `CustomerReport.pdf` will be downloaded to your browser's default
download folder.

---

## How it works

### 1. Data source

`CustomerDataService` returns a hard-coded `List<Customer>` (7 rows).  
`ObjectDataProvider` wraps the list and exposes it to LLCP under the table name
`"Customer"`, with field names matching the C# property names
(`Customer.Id`, `Customer.Name`, `Customer.City`, `Customer.Revenue`).

### 2. Report layout via DOM API

`ReportService.BuildProjectStream` builds a complete LLCP project **in code** —
no pre-designed `.lst` / `.json` file is needed:

```csharp
using var ll = new ListLabel();
using var project = ll.OpenProject(projectStream, LlProject.List);

// Static title text object
var title = project.Objects.AddNewText();
title.Position.Set(20_000, 15_000, 170_000, 12_000); // 1/1000 mm units
title.Paragraphs.AddNew().Contents = "\"Customer Revenue Report\"";

// ReportContainer with a dynamic data table
var container = project.Objects.AddNewReportContainer();
container.Position.Set(20_000, 29_000, 170_000, 253_000);

var table = container.SubItems.AddNewTable();
table.TableId = "Customer";     // matches ObjectDataProvider table name

var header = new TableLineHeader(table.Lines.Header);
// … add TableFieldText fields with static label formulas …

var data = new TableLineData(table.Lines.Data);
// … add TableFieldText fields referencing "Customer.Name", etc. …

project.Save();   // serialises to the MemoryStream
```

Coordinates are in **1/1000 mm** (A4 = 210 000 × 297 000).

### 3. Export to PDF

```csharp
var exportConfig = new ExportConfiguration(
    LlExportTarget.Pdf,
    pdfOutputStream,   // MemoryStream – no file system access needed
    projectStream);    // MemoryStream – the saved project definition
exportConfig.ShowResult = false;   // no file-open dialog in WASM
listLabel.Export(exportConfig);
```

### 4. Browser download

The resulting byte array is base64-encoded and handed to a small inline JS snippet
via `IJSRuntime.InvokeVoidAsync("eval", ...)` that creates a Blob URL and
simulates an anchor click.

---

## Publishing

For a production deployment the SkiaSharp native WASM binary must be statically
linked into the app bundle:

```bash
dotnet publish -c Release
```

> **Note:** `wasm-tools` workload must be installed before publishing.  
> The `SkiaSharp.NativeAssets.WebAssembly` package adds the native `.a` file;
> the Blazor WASM build chain links it automatically.

You can serve the resulting `wwwroot` folder with any static-file host
(GitHub Pages, Azure Static Web Apps, nginx, etc.).

---

## WASM Limitations

| Limitation | Details |
|---|---|
| **Single-threaded** | The default WASM runtime is single-threaded. Report generation blocks the main thread; the loading spinner prevents perceived freeze. For very large reports, consider offloading to a Web Worker. |
| **No host file system** | All I/O uses `MemoryStream`. There is no access to the user's disk during generation. |
| **Initial load size** | The SkiaSharp WASM binary adds a few MB. Enable Brotli compression on your web server. |
| **No designer** | The LLCP interactive designer runs only on Windows. Layouts must be defined via the DOM API or by loading a pre-designed `.json` project embedded as a resource. |

---

## Extending the Sample

| Goal | Where to look |
|---|---|
| Add more data fields | `Customer.cs` + `ReportService.AddDataLine` |
| Use a pre-designed layout | Replace `BuildProjectStream` with loading a `.json` resource |
| Add charts or barcodes | Use `new TableFieldChart(...)` / `new TableFieldBarcode(...)` |
| Switch data source | Replace `ObjectDataProvider` with `AdoDataProvider`, `SchemaAwareJsonDataProvider`, etc. |
| Replace the project reference | Change `<ProjectReference>` to `<PackageReference Include="combit.ListLabel32.CrossPlatform" />` |

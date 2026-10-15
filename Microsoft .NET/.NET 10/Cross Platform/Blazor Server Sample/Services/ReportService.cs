using BlazorServerSample.Models;
using combit.Reporting;
using combit.Reporting.DataProviders;
using combit.Reporting.Dom;

namespace BlazorServerSample.Services;

/// <summary>
/// Generates a PDF customer report using List &amp; Label Cross Platform.
/// All LLCP operations run on the ASP.NET Core server, avoiding any
/// WebAssembly platform restrictions.
/// </summary>
/// <remarks>
/// <para>
/// The report layout is built programmatically via the LLCP DOM API, so no
/// pre-designed <c>.lst</c> / <c>.json</c> project file is needed.
/// </para>
/// <para>
/// Both the project definition and the PDF output are kept in
/// <see cref="MemoryStream"/> instances — no temporary files are written to
/// the host file system.
/// </para>
/// </remarks>
public class ReportService
{
    // A4 dimensions in 1/1000 mm units (the coordinate system used by LLCP).
    private const int PageWidth  = 210_000;
    private const int PageHeight = 297_000;

    // Standard page margins (20 mm left/right, 15 mm top/bottom).
    private const int MarginLeft   =  20_000;
    private const int MarginTop    =  15_000;
    private const int MarginRight  =  20_000;
    private const int MarginBottom =  15_000;

    private const int ContentWidth  = PageWidth  - MarginLeft - MarginRight;  // 170 000
    private const int ContentHeight = PageHeight - MarginTop  - MarginBottom; // 267 000

    // Column widths (sum = ContentWidth = 170 000).
    private const int ColId      =  15_000;
    private const int ColName    =  60_000;
    private const int ColCity    =  55_000;
    private const int ColRevenue =  40_000;

    // Title object height and gap below it (in 1/1000 mm).
    private const int TitleHeight =  12_000;
    private const int TitleGap    =   2_000;

    /// <summary>
    /// Builds a customer list report using the LLCP DOM API and exports it to PDF.
    /// </summary>
    /// <param name="customers">The customer records to include in the report.</param>
    /// <returns>The raw PDF bytes.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="customers"/> is <see langword="null"/>.
    /// </exception>
    public byte[] GenerateCustomerReport(IReadOnlyList<Customer> customers)
    {
        ArgumentNullException.ThrowIfNull(customers);

        // 1. Build the project definition in a MemoryStream via the DOM API.
        using MemoryStream projectStream = BuildProjectStream();

        // 2. Export the project to PDF into a second MemoryStream.
        using MemoryStream pdfStream = ExportToPdf(customers, projectStream);

        return pdfStream.ToArray();
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Project definition (DOM)
    // ─────────────────────────────────────────────────────────────────────────

    private static MemoryStream BuildProjectStream()
    {
        // ListLabel is the main LLCP entry point.
        using var ll = new ListLabel();

        var projectStream = new MemoryStream();

        // OpenProject with a MemoryStream creates a brand-new in-memory project.
        using var project = ll.OpenProject(projectStream, LlProject.List)
            ?? throw new InvalidOperationException("Failed to create LLCP project.");

        AddTitleObject(project);
        AddReportContainer(project);

        // Persist the project definition into the MemoryStream.
        project.Save();

        // The project owns the stream and may dispose it when the project is disposed.
        // Return an independent copy for further processing.
        var projectBytes = projectStream.ToArray();
        return new MemoryStream(projectBytes);
    }

    /// <summary>
    /// Adds a static title text object at the top of the page.
    /// </summary>
    private static void AddTitleObject(ProjectBase project)
    {
        var title = project.Objects.AddNewText();

        // Position: left=20 mm, top=15 mm, width=170 mm, height=12 mm (in 1/1000 mm).
        title.Position.Set(MarginLeft, MarginTop, ContentWidth, TitleHeight);

        var paragraph = title.Paragraphs.AddNew();
        // LLCP formulas: string literals are enclosed in double quotes.
        paragraph.Contents = "\"Customer Revenue Report\"";
    }

    /// <summary>
    /// Adds a ReportContainer with a dynamic data table bound to the Customer table.
    /// </summary>
    private static void AddReportContainer(ProjectBase project)
    {
        // The ReportContainer is LLCP's repeating-data container.
        var container = project.Objects.AddNewReportContainer();

        // Place the container below the title, filling the remaining page height.
        int containerTop    = MarginTop + TitleHeight + TitleGap;
        int containerHeight = ContentHeight - TitleHeight - TitleGap;
        container.Position.Set(MarginLeft, containerTop, ContentWidth, containerHeight);

        // Add a dynamic table sub-item.
        // TableId must match the name that ObjectDataProvider exposes,
        // which equals the class name of the bound objects ("Customer").
        var table = container.SubItems.AddNewTable();
        table.TableId = nameof(Customer);

        AddHeaderLine(table);
        AddDataLine(table);
    }

    /// <summary>
    /// Adds a single header line with column title labels.
    /// </summary>
    private static void AddHeaderLine(SubItemTable table)
    {
        var headerLine = new TableLineHeader(table.Lines.Header);

        // Each TableFieldText in the header line contains a static label formula.
        AddTextField(headerLine.Fields, ColId,      "\"#\"");
        AddTextField(headerLine.Fields, ColName,    "\"Name\"");
        AddTextField(headerLine.Fields, ColCity,    "\"City\"");
        AddTextField(headerLine.Fields, ColRevenue, "\"Revenue\"");
    }

    /// <summary>
    /// Adds a data line whose fields reference Customer properties via the data source.
    /// </summary>
    private static void AddDataLine(SubItemTable table)
    {
        var dataLine = new TableLineData(table.Lines.Data);

        // Field identifiers follow the pattern "TableName.PropertyName".
        // ObjectDataProvider uses the class name ("Customer") as the table name
        // and the C# property names as the field names.
        AddTextField(dataLine.Fields, ColId,      "Customer.Id");
        AddTextField(dataLine.Fields, ColName,    "Customer.Name");
        AddTextField(dataLine.Fields, ColCity,    "Customer.City");
        AddTextField(dataLine.Fields, ColRevenue, "Customer.Revenue");
    }

    /// <summary>
    /// Appends a new text field with the specified width and contents formula.
    /// </summary>
    private static void AddTextField(
        CollectionTableFieldBases fields,
        int width,
        string contentsFormula)
    {
        var field = new TableFieldText(fields);
        // Width is stored as a string in the LLCP DOM (coordinate value in 1/1000 mm).
        field.Width    = width.ToString();
        field.Contents = contentsFormula;
        // Enable line wrapping so long values do not overflow the cell.
        field.Wrapping.Line  = "1";
        field.Wrapping.Force = "True";
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Export
    // ─────────────────────────────────────────────────────────────────────────

    private static MemoryStream ExportToPdf(
        IReadOnlyList<Customer> customers,
        MemoryStream projectStream)
    {
        // Wrap the customer list in an ObjectDataProvider — the simplest way to
        // provide in-memory .NET objects as a data source to LLCP.
        var dataProvider = new ObjectDataProvider(customers);

        using var ll = new ListLabel
        {
            DataSource    = dataProvider,
            // LicensingInfo: leave empty for evaluation / set to a valid key in production.
            LicensingInfo = string.Empty,
        };

        var pdfStream = new MemoryStream();

        // Stream-based ExportConfiguration: no file paths are required.
        var exportConfig = new ExportConfiguration(
            LlExportTarget.Pdf,
            pdfStream,
            projectStream);

        // ShowResult = false: do not attempt to open the result file.
        exportConfig.ShowResult = false;

        ll.Export(exportConfig);

        pdfStream.Seek(0, SeekOrigin.Begin);
        return pdfStream;
    }
}

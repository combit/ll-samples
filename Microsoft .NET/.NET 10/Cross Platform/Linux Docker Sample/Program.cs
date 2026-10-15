using combit.Logging;
using combit.Reporting;
using combit.Reporting.Dom;

using System;
using System.Data;
using System.IO;

class Program
{
    static void Main()
    {
        var outputPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "export", "report.pdf"));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

        var logPath = Path.ChangeExtension(outputPath, ".log");
        if (File.Exists(logPath))
        {
            File.Delete(logPath);
        }

        var logger = new DebwinLogger(logPath, Microsoft.Extensions.Logging.LogLevel.Debug);

        Console.WriteLine("Welcome to the List & Label CrossPlatform Docker Sample.\n");

        GenerateReport(outputPath, logger);
    }

    static void GenerateReport(string outputPath, DebwinLogger logger)
    {
        using var ll = new ListLabel();
        ll.Logger = logger;
        ll.DataSource = Items();

        Console.WriteLine("Start creation of report file using DOM.");

        var proj = ll.OpenProject(
            "test.json",
            LlDomFileMode.Create,
            LlDomAccessMode.ReadWrite,
            LlProject.List
        )!;

        //Project Settings
        proj.Settings.DefaultFont.FaceName = "Arial";
        proj.Settings.DefaultFont.Size = "12";
        proj.ProjectParameters["LL.DesignScheme"].Contents = "\"COMBITCOLORWHEEL\"";
        proj.ProjectParameters["LL.ProjectDescription"].Contents = "\"Item List with Barcodes\"";

        //New TextObject Headline  
        ObjectText HeaderText = new(proj.Objects)
        {
            Name = "Header"
        };
        HeaderText.Position.Left = "19990";
        HeaderText.Position.Top = "24990";
        HeaderText.Position.Width = "150010";
        HeaderText.Position.Height = "11980";

        //New Paragraph in TextObject
        Paragraph ParagraphHeader = new(HeaderText.Paragraphs)
        {
            Contents = "\"Item List\""
        };
        ParagraphHeader.Wrapping.Force = "False";
        ParagraphHeader.Font.Size = "28";
        ParagraphHeader.TabAlignment = "0";
        ParagraphHeader.TabPosition = "0";

        //New ReportContainer
        ObjectReportContainer ReportContainer = new(proj.Objects);
        ReportContainer.DefaultColumns.Distance = "0";
        ReportContainer.ReadOnly = "False";
        ReportContainer.LinkUUID = "";
        ReportContainer.LayerId = 0;
        ReportContainer.GroupId = 0;
        ReportContainer.LinkMode = 0;
        ReportContainer.Name = "Report Container";
        ReportContainer.Selected = "False";
        ReportContainer.Position.Left = "15010";
        ReportContainer.Position.Top = "52980";
        ReportContainer.Position.Width = "182880";
        ReportContainer.Position.Height = "220420";

        //New Table in ReportContainer
        SubItemTable Table = new(ReportContainer.SubItems);
        Table.LineOptions.Data.ForceSumCalculation = "False";
        Table.DefaultFrame.Left.Space = "990";
        Table.DefaultFrame.Left.Line.Visible = "False";
        Table.DefaultFrame.Top.Space = "500";
        Table.DefaultFrame.Top.Line.Color = "RGB(0,0,0)";
        Table.DefaultFrame.Right.Space = "990";
        Table.DefaultFrame.Right.Line.Color = "RGB(0,0,0)";
        Table.DefaultFrame.Bottom.Space = "500";
        Table.DefaultFrame.Bottom.Line.Color = "RGB(0,0,0)";
        Table.FixedSize.Enabled = "True";
        Table.SortOrderId = "\"\"";
        Table.TableId = "Item";
        Table.RelationId = "";
        Table.Columns.Distance = "990";

        //New HeaderLine in Table
        TableLineHeader HeaderLine = new(Table.Lines.Header);
        HeaderLine.Anchor.Contents = "0";
        HeaderLine.Name = "Header";
        HeaderLine.ReservedSpace.Left = "0";
        HeaderLine.ReservedSpace.Top = "0";
        HeaderLine.ReservedSpace.Right = "0";
        HeaderLine.ReservedSpace.Bottom = "7010";

        //New Field "No" in HeaderLine
        TableFieldText HeaderField = new(HeaderLine.Fields)
        {
            Contents = "\"ItemNo\""
        };
        HeaderField.Font.Bold = "True";
        HeaderField.Font.Color = "LL.Color.White";
        HeaderField.Font.Size = "12";
        HeaderField.Filling.Style = "1";
        HeaderField.Filling.Color = "LL.Scheme.BackgroundColor2";
        HeaderField.ObjectType = "Text";
        HeaderField.Frame.Default = "False";
        HeaderField.Frame.Left.Space = "5000";
        HeaderField.Frame.Left.Line.Visible = "False";
        HeaderField.Frame.Top.Space = "990";
        HeaderField.Frame.Top.Line.Visible = "False";
        HeaderField.Frame.Right.Space = "990";
        HeaderField.Frame.Right.Line.Visible = "False";
        HeaderField.Frame.Bottom.Space = "990";
        HeaderField.Frame.Bottom.Line.Visible = "False";
        HeaderField.Width = "30290";

        //New Field "Description" in HeaderLine
        TableFieldText HeaderField1 = new(HeaderLine.Fields);
        HeaderField1.Contents = "\"Description\"";
        HeaderField1.Font.Bold = "True";
        HeaderField1.Font.Color = "LL.Color.White";
        HeaderField1.Font.Size = "12";
        HeaderField1.Filling.Style = "1";
        HeaderField1.Filling.Color = "LL.Scheme.BackgroundColor2";
        HeaderField1.ObjectType = "Text";
        HeaderField1.Frame.Default = "False";
        HeaderField1.Frame.Left.Space = "0";
        HeaderField1.Frame.Left.Line.Visible = "False";
        HeaderField1.Frame.Top.Space = "990";
        HeaderField1.Frame.Top.Line.Visible = "False";
        HeaderField1.Frame.Right.Space = "990";
        HeaderField1.Frame.Right.Line.Visible = "False";
        HeaderField1.Frame.Bottom.Space = "990";
        HeaderField1.Frame.Bottom.Line.Visible = "False";
        HeaderField1.Width = "100400";

        //New Field "UnitPrice" in HeaderLine
        TableFieldText HeaderField2 = new(HeaderLine.Fields);
        HeaderField2.AlignmentHorizontal.Alignment = "2";
        HeaderField2.Contents = "\"Price in \" + Locale$ (20)";
        HeaderField2.Font.Bold = "True";
        HeaderField2.Font.Color = "LL.Color.White";
        HeaderField2.Font.Size = "12";
        HeaderField2.Filling.Style = "1";
        HeaderField2.Filling.Color = "LL.Scheme.BackgroundColor2";
        HeaderField2.ObjectType = "Text";
        HeaderField2.Frame.Default = "False";
        HeaderField2.Frame.Left.Space = "0";
        HeaderField2.Frame.Left.Line.Visible = "False";
        HeaderField2.Frame.Top.Space = "990";
        HeaderField2.Frame.Top.Line.Visible = "False";
        HeaderField2.Frame.Right.Space = "5000";
        HeaderField2.Frame.Right.Line.Visible = "False";
        HeaderField2.Frame.Bottom.Space = "990";
        HeaderField2.Frame.Bottom.Line.Visible = "False";
        HeaderField2.Width = "28570";

        //New Field "Barcode" in HeaderLine
        TableFieldText HeaderField3 = new(HeaderLine.Fields);
        HeaderField3.AlignmentHorizontal.Alignment = "1";
        HeaderField3.Contents = "\"Barcode\"";
        HeaderField3.Font.Bold = "True";
        HeaderField3.Font.Color = "LL.Color.White";
        HeaderField3.Font.Size = "12";
        HeaderField3.Filling.Style = "1";
        HeaderField3.Filling.Color = "LL.Scheme.BackgroundColor2";
        HeaderField3.ObjectType = "Text";
        HeaderField3.Frame.Default = "False";
        HeaderField3.Frame.Left.Space = "0";
        HeaderField3.Frame.Left.Line.Visible = "False";
        HeaderField3.Frame.Top.Space = "990";
        HeaderField3.Frame.Top.Line.Visible = "False";
        HeaderField3.Frame.Right.Space = "5000";
        HeaderField3.Frame.Right.Line.Visible = "False";
        HeaderField3.Frame.Bottom.Space = "990";
        HeaderField3.Frame.Bottom.Line.Visible = "False";
        HeaderField3.Width = "28570";

        //New DataLine in Table
        TableLineData DataLine = new(Table.Lines.Data);
        DataLine.Anchor.Contents = "0";
        DataLine.Name = "Item data first line";
        DataLine.ReservedSpace.Left = "0";
        DataLine.ReservedSpace.Top = "0";
        DataLine.ReservedSpace.Right = "0";
        DataLine.ReservedSpace.Bottom = "2990";

        //New Field Item.No in DataLine
        TableFieldText DataField = new(DataLine.Fields)
        {
            Contents = "Item.No"
        };
        //DataField.Font.Bold = "True";
        DataField.Font.Size = "12";
        DataField.Filling.Color = "LL.Scheme.BackgroundColor0";
        DataField.ObjectType = "Text";
        DataField.Frame.Default = "False";
        DataField.Frame.Left.Space = "5000";
        DataField.Frame.Left.Line.Visible = "False";
        DataField.Frame.Top.Space = "0";
        DataField.Frame.Top.Line.Visible = "False";
        DataField.Frame.Right.Space = "990";
        DataField.Frame.Right.Line.Visible = "False";
        DataField.Frame.Bottom.Space = "0";
        DataField.Frame.Bottom.Line.Visible = "False";
        DataField.Width = "30290";

        //New Field Item.Desciption in DataLine
        TableFieldText DataField2 = new(DataLine.Fields)
        {
            LineSpacing = "-3"
        };
        DataField2.Contents = "Item.Description";        
        DataField2.Font.Size = "12";
        DataField2.Filling.Color = "LL.Scheme.BackgroundColor0";
        DataField2.ObjectType = "Text";
        DataField2.Frame.Default = "False";
        DataField2.Frame.Left.Space = "0";
        DataField2.Frame.Left.Line.Visible = "False";
        DataField2.Frame.Top.Space = "0";
        DataField2.Frame.Top.Line.Visible = "False";
        DataField2.Frame.Right.Space = "990";
        DataField2.Frame.Right.Line.Visible = "False";
        DataField2.Frame.Bottom.Space = "0";
        DataField2.Frame.Bottom.Line.Visible = "False";
        DataField2.Width = "100400";

        //New Field Item.UnitPrice in DataLine
        TableFieldText DataField3 = new(DataLine.Fields);
        DataField3.AlignmentHorizontal.Alignment = "3";
        DataField3.Contents = "Item.UnitPrice";
        DataField3.Font.Size = "12";
        DataField3.Filling.Color = "LL.Scheme.BackgroundColor0";
        DataField3.ObjectType = "Text";
        DataField3.Frame.Default = "False";
        DataField3.Frame.Left.Space = "0";
        DataField3.Frame.Left.Line.Visible = "False";
        DataField3.Frame.Top.Space = "0";
        DataField3.Frame.Top.Line.Visible = "False";
        DataField3.Frame.Right.Space = "5000";
        DataField3.Frame.Right.Line.Visible = "False";
        DataField3.Frame.Bottom.Space = "0";
        DataField3.Frame.Bottom.Line.Visible = "False";
        DataField3.Width = "28570";

        //New Field Barcode in DataLine
        TableFieldBarcode FieldBarcode = new(DataLine.Fields)
        {
            BarcodeType = LlBarcodeType.QRCode,
            BarColor = "RGB(0,0,0)",
            Contents = "Barcode(Item.No + \" - \" + ToString$(Item.UnitPrice) + Locale$(20), \"QRCODE\")"
        };
        FieldBarcode.Font.Size = "12";
        FieldBarcode.Height = "UnitFromSCM(15000)";
        FieldBarcode.Filling.Color = "LL.Scheme.BackgroundColor0";
        FieldBarcode.ObjectType = "Barcode";
        FieldBarcode.Frame.Default = "False";
        FieldBarcode.Frame.Left.Space = "0";
        FieldBarcode.Frame.Left.Line.Visible = "False";
        FieldBarcode.Frame.Top.Space = "0";
        FieldBarcode.Frame.Top.Line.Visible = "False";
        FieldBarcode.Frame.Right.Space = "5000";
        FieldBarcode.Frame.Right.Line.Visible = "False";
        FieldBarcode.Frame.Bottom.Space = "0";
        FieldBarcode.Frame.Bottom.Line.Visible = "False";
        FieldBarcode.Width = "28570";

        //New FooterLine in Table
        TableLineFooter FooterLine = new(Table.Lines.Footer);
        FooterLine.Anchor.Contents = "0";
        FooterLine.Name = "Footer";
        FooterLine.ReservedSpace.Left = "0";
        FooterLine.ReservedSpace.Top = "5000";
        FooterLine.ReservedSpace.Right = "0";
        FooterLine.ReservedSpace.Bottom = "2990";

        //New empty Field in FooterLine
        TableFieldText FooterField = new(FooterLine.Fields);
        FooterField.Contents = "\"\"";
        FooterField.Filling.Color = "LL.Scheme.BackgroundColor1";
        FooterField.ObjectType = "Text";
        FooterField.Frame.Default = "False";
        FooterField.Frame.Left.Space = "0";
        FooterField.Frame.Left.Line.Visible = "False";
        FooterField.Frame.Top.Space = "0";
        FooterField.Frame.Top.Line.Visible = "False";
        FooterField.Frame.Right.Space = "0";
        FooterField.Frame.Right.Line.Visible = "False";
        FooterField.Frame.Bottom.Space = "0";
        FooterField.Frame.Bottom.Line.Visible = "False";
        FooterField.Width = "57650";

        //New Field Summary in FooterLine
        TableFieldText FooterField2 = new(FooterLine.Fields);
        FooterField2.AlignmentHorizontal.Alignment = "3";
        FooterField2.Contents = "Str$(Cond(not LastPage(), Count(Item.No, True), Count (Item.No, False)), 0, 0) + Cond(LastPage(),\" items in total\",\" items on this page\")";
        FooterField2.Font.Bold = "True";
        FooterField2.Font.Color = "LL.Color.White";
        FooterField2.Filling.Style = "1";
        FooterField2.Filling.Color = "LL.Scheme.BackgroundColor0";
        FooterField2.ObjectType = "Text";
        FooterField2.Frame.Default = "False";
        FooterField2.Frame.Left.Space = "2000";
        FooterField2.Frame.Left.Line.Visible = "False";
        FooterField2.Frame.Top.Space = "0";
        FooterField2.Frame.Top.Line.Visible = "False";
        FooterField2.Frame.Right.Space = "0";
        FooterField2.Frame.Right.Line.Visible = "False";
        FooterField2.Frame.Bottom.Space = "0";
        FooterField2.Frame.Bottom.Line.Visible = "False";
        FooterField2.Width = "96620";

        //New Field Sum of all UnitPrices in FooterLine
        TableFieldText FooterField3 = new(FooterLine.Fields);
        FooterField3.AlignmentHorizontal.Alignment = "3";
        FooterField3.Contents = "Cond (not LastPage(), Sum (Item.UnitPrice, True), Sum (Item.UnitPrice, False))";
        FooterField3.Font.Bold = "True";
        FooterField3.Font.Color = "LL.Color.White";
        FooterField3.Filling.Style = "1";
        FooterField3.Filling.Color = "LL.Scheme.BackgroundColor0";
        FooterField3.ObjectType = "Text";
        FooterField3.Frame.Default = "False";
        FooterField3.Frame.Left.Space = "0";
        FooterField3.Frame.Left.Line.Visible = "False";
        FooterField3.Frame.Top.Space = "0";
        FooterField3.Frame.Top.Line.Visible = "False";
        FooterField3.Frame.Right.Space = "2000";
        FooterField3.Frame.Right.Line.Visible = "False";
        FooterField3.Frame.Bottom.Space = "0";
        FooterField3.Frame.Bottom.Line.Visible = "False";
        FooterField3.Width = "28570";

        //New TextObject PageCounter  
        ObjectText PageCount = new(proj.Objects)
        {
            Name = "Print info"
        };
        PageCount.Position.Left = "15010";
        PageCount.Position.Top = "274950";
        PageCount.Position.Width = "182880";
        PageCount.Position.Height = "8730";

        //New Paragraph in TextObject
        Paragraph ParagraphPageCount = new(HeaderText.Paragraphs)
        {
            Contents = "\"Page \" + FStr$ (Page (),\"###\",1) + \" of \" + TotalPages$ () + \"¶\" + \"Effective: \" + LocDate$ (Today ()) + \" \" + LocTime$ (Now (),\"\",10)"
        };
        ParagraphPageCount.Wrapping.Force = "False";
        ParagraphPageCount.Font.Size = "28";
        ParagraphPageCount.TabAlignment = "0";
        ParagraphPageCount.TabPosition = "0";

        // Save DOM to MemoryStream
        MemoryStream projectStream = new();
        proj.Save(projectStream);
        File.WriteAllBytes(Path.ChangeExtension(outputPath, ".json"), projectStream.ToArray());

        proj.Dispose();

        Console.WriteLine("Finished creation of report file.");

        MemoryStream pdfStream = new();
        projectStream.Seek(0, SeekOrigin.Begin);

        ExportConfiguration exportConfiguration = new(
            LlExportTarget.Pdf,
            pdfStream,
            projectStream
        );

        Console.WriteLine("Start creating PDF.");
        ll.Export(exportConfiguration);
        Console.WriteLine($"PDF created at {outputPath}");
        Console.WriteLine($"Stream size: {pdfStream.Length} bytes");
        Console.WriteLine($"OS is {Environment.OSVersion}\n");

        File.WriteAllBytes(outputPath, pdfStream.ToArray());
    }

    //Dummy Data
    private static DataSet Items()
    {
        DataSet ds = new();
        DataTable dt = new("Item");
        dt.Columns.Add("No");
        dt.Columns.Add("Description");
        dt.Columns.Add("UnitPrice", typeof(double));

        dt.Rows.Add("EXPSA01", "Southern Africa Explorer: 20-day tour from Cape Town to Victoria Falls excluding flight.", 1500.00);
        dt.Rows.Add("EXPCH01", "Northern & Southern Chile: 23-day tour from Santiago to Punta Arenas including flight.", 3500.00);
        dt.Rows.Add("EXPMAL01", "Maldives diving trip: 14 days, southern Male Atoll, Paradise Beach **** excluding flight.", 1800.00);
        dt.Rows.Add("EXPHK01", "Hong Kong and Bali: 2 weeks, including flights, accommodation, excursions.", 1760.00);
        dt.Rows.Add("EXPYUC01", "Yucatan, On the Trail of the Maya, 2-week round trip, excluding flight.", 1200.00);
        dt.Rows.Add("EXPLON01", "London, sightseeing tour with boat trip on the Thames.", 60.00);
        dt.Rows.Add("EXCPAR01", "Paris, visit to the Louvre including guided tour and admission.", 40.00);
        dt.Rows.Add("EXCPAR02", "Paris, admission to the latest cabaret show at the Moulin Rouge including three-course meal.", 178.00);
        dt.Rows.Add("RNTCOT01", "Cottage, South of England with sea view, 4 persons.", 1050.00);
        dt.Rows.Add("RNTMTB01", "Vespa GT 125/200 l motor scooter for Rome, Paris.", 150.00);
        dt.Rows.Add("TRPBARC01", "Barcelona city trip: From the Sagrada Familia to Güell Park, excluding flight.", 360.00);
        dt.Rows.Add("TRPLON01", "Extended luxury weekend in London for two.", 2800.00);
        dt.Rows.Add("TRPNYC01", "Five-day city trip to New York including flight and accommodation.", 1500.00);
        dt.Rows.Add("TRPPRA01", "From Gothic to Baroque to Art Nouveau. City trip to Prague including accommodation.", 355.00);
        dt.Rows.Add("TRPROM01", "Five days, five friends: Discover Rome.", 555.00);
        dt.Rows.Add("TRPVEN01", "Carnival in Venice, trip for 2 persons including accommodation.", 450.00);
        dt.Rows.Add("TRVALA01", "Flight only: Alaska.", 1080.00);
        dt.Rows.Add("TRVAUS01", "Flight only: Australia.", 955.00);
        dt.Rows.Add("TRVBRA01", "Flight only: Brazil.", 783.00);

        ds.Tables.Add(dt);
        return ds;
    }
}
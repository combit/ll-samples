{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 Module : DOM List & Label sample
 Descr. : D:  Dieses Beispiel demonstriert die dynamische Erzeugung von List & Label
              Projekten
          US: This example shows the dynamic creation of List & Label projects
======================================================================================}
unit uMain;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms, Registry,
  Dialogs, L29, L29db, cmbtll29, L29dom, DB, ADODB, ExtCtrls, StdCtrls, ComCtrls, ActnList,
  System.Actions
  {$If CompilerVersion >=28} // >=XE7
  , System.UITypes
  {$ENDIF}
  ;

type
  TfrmMain = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    PageControl1: TPageControl;
    TbShtCrosstabData: TTabSheet;
    TbShtCorsstabProperties: TTabSheet;
    TbShtGeneralSettings: TTabSheet;
    TbShtFinish: TTabSheet;
    btnNext1: TButton;
    btnPrev2: TButton;
    btnNext2: TButton;
    btnPrev3: TButton;
    btnNext: TButton;
    btnDesign: TButton;
    btnPreview: TButton;
    Label5: TLabel;
    Label6: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    Label15: TLabel;
    Label16: TLabel;	
    Label17: TLabel;
    Label18: TLabel;
    GroupBox3: TGroupBox;
    GroupBox4: TGroupBox;
    Label21: TLabel;
    dtReportTitle: TEdit;
    CmbxPageFormat: TComboBox;
    FontDialog1: TFontDialog;
    ColorDialog1: TColorDialog;
    ADOConnection1: TADOConnection;
    LL: TDBL29_;
    btnColorCell1: TButton;
    lblColorCell1: TLabel;
    lblColorCell2: TLabel;
    lblColorRow1: TLabel;
    lblColorRow2: TLabel;
    btnColorCell2: TButton;
    btnColorRow1: TButton;
    btnColorRow2: TButton;
    btnDefaultFont: TButton;
    Panel1: TPanel;
    lblSampleText: TLabel;
    ActionList1: TActionList;
    ctnNextTab: TAction;
    ctnPreviosTab: TAction;
    dsCustomers: TDataSource;
    dsOrders: TDataSource;
    TblCustomers: TADOTable;
    TblOrders: TADOTable;
    TblOrderDetails: TADOTable;
    RdGrpCellSortOrder: TRadioGroup;
    RdGrpRowSortOrder: TRadioGroup;
    Panel2: TPanel;
    Label22: TLabel;
    Image1: TImage;
    Label24: TLabel;
    Label23: TLabel;
    Label25: TLabel;
    Label26: TLabel;
    Label27: TLabel;
    Label28: TLabel;
    lbl_Schema: TLabel;
    lbl_title: TLabel;
    lbl_Cell: TLabel;
    lbl_Row: TLabel;
    lbl_Project: TLabel;
    lbl_Font: TLabel;
    rdbtnCrosstab: TRadioButton;
    rdbtnPieChart: TRadioButton;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    dtTitle2: TEdit;
    Label14: TLabel;
    Label19: TLabel;
    rdbtnBarChart: TRadioButton;
    Label20: TLabel;
    Label29: TLabel;
    Label30: TLabel;
    dtTitle3: TEdit;
    Label31: TLabel;
    procedure btnColorCell1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btnColorCell2Click(Sender: TObject);
    procedure btnColorRow1Click(Sender: TObject);
    procedure btnColorRow2Click(Sender: TObject);
    procedure btnDefaultFontClick(Sender: TObject);
    procedure ctnNextTabExecute(Sender: TObject);
    procedure ctnPreviosTabExecute(Sender: TObject);
    procedure btnDesignClick(Sender: TObject);
    procedure btnPreviewClick(Sender: TObject);
    procedure TbShtFinishShow(Sender: TObject);
  private
    workingPath: String;
    function GenerateLLProject(): integer;
    procedure UpdateInfo();
    function TColorToRGB(oColor: TColor): string;
    procedure AddCrosstab(container: TLlDOMObjectReportContainer);
    procedure AddPieChart(container: TLlDOMObjectReportContainer);
    procedure AddBarChart(container: TLlDOMObjectReportContainer);
  public
    { Public declarations }
  end;

var
  frmMain: TfrmMain;
  lldomproj: TLlDomProjectList;
  llFont: TFont;

implementation

{$R *.dfm}

procedure TfrmMain.btnColorCell1Click(Sender: TObject);
begin
  ColorDialog1.Execute();
  lblColorCell1.Color :=  ColorDialog1.Color;
end;

procedure TfrmMain.btnColorCell2Click(Sender: TObject);
begin
  ColorDialog1.Execute();
  lblColorCell2.Color :=  ColorDialog1.Color;
end;

procedure TfrmMain.btnColorRow1Click(Sender: TObject);
begin
  ColorDialog1.Execute();
  lblColorRow1.Color :=  ColorDialog1.Color;
end;

procedure TfrmMain.btnColorRow2Click(Sender: TObject);
begin
  ColorDialog1.Execute();
  lblColorRow2.Color :=  ColorDialog1.Color;
end;

procedure TfrmMain.btnDefaultFontClick(Sender: TObject);
begin
   FontDialog1.Execute();
   lblSampleText.Font := FontDialog1.Font;
   llFont := FontDialog1.Font;
end;

procedure TfrmMain.btnDesignClick(Sender: TObject);
var
  nRet: integer;
begin
  LL.AutoDesignerFile := workingPath + 'dynamic.lst';
  LL.AutoProjectType := ptListProject;
  LL.AutoMasterMode := mmAsFields;
  LL.AutoShowSelectFile := No;

	//D: List & Label Projekt anhand Einstellungen erstellen
	//US: Create List & Label project based on the settings
  nRet := GenerateLLProject();
  if nRet <> 0 then
    MessageDlg(LL.LlGetErrortext(nRet), mtInformation, [mbOK], 0)
  else
    //D: Designer aufrufen
    //US: Call the designer
    LL.AutoDesign('Dynamically created project...');
end;

procedure TfrmMain.btnPreviewClick(Sender: TObject);
var
  nRet: integer;
begin
  LL.AutoDesignerFile := workingPath + 'dynamic.lst';
  LL.AutoShowSelectFile := No;
  LL.AutoProjectType := ptListProject;
  LL.AutoMasterMode := mmAsFields;
  LL.AutoDestination := adPreview;
  LL.AutoShowPrintOptions := No;

	//D: List & Label Projekt anhand Einstellungen erstellen
	//US: Create List & Label project based on the settings
  nRet := GenerateLLProject();
  if nRet <> 0 then
    MessageDlg(LL.LlGetErrortext(nRet), mtInformation, [mbOK], 0)
  else
    //D: Designer aufrufen
    //US: Call the designer
    LL.AutoPrint('Dynamically created project...', '');
end;

procedure TfrmMain.ctnNextTabExecute(Sender: TObject);
begin
  PageControl1.ActivePageIndex := PageControl1.ActivePageIndex + 1;
end;

procedure TfrmMain.ctnPreviosTabExecute(Sender: TObject);
begin
  PageControl1.ActivePageIndex := PageControl1.ActivePageIndex - 1;
end;

procedure TfrmMain.FormCreate(Sender: TObject);

var registry: TRegistry;
var regKeyPath: String;
var dbPath: String;
var tmp: String;

begin

  PageControl1.ActivePageIndex := 0;

  lblColorCell1.Color := 65484;
  lblColorCell2.Color := 16777215;

  lblColorRow1.Color := 16777215;
  lblColorRow2.Color := 3381759;

  llFont := TFont.Create();
  llFont.Name := 'Verdana';
  llFont.Size := 10;

  rdbtnCrosstab.Checked := true;

  // D: Datenbankpfad auslesen
  // US: Read database path
  registry := TRegistry.Create();
  registry.RootKey := HKEY_CURRENT_USER;
  regKeyPath := 'Software\combit\cmbtll\';
  if registry.KeyExists(regKeyPath) then
  begin

  if registry.OpenKeyReadOnly(regKeyPath) then
    begin

      dbPath := registry.ReadString('NWINDPath');
	  
	  tmp := registry.ReadString('LL' + IntToStr(LL.LlGetVersion(LL_VERSION_MAJOR)) + 'SampleDir');
	  if (tmp[Length(tmp)] = '\') then
		begin
		  workingPath := tmp + 'Delphi\BDE (Legacy)\Samples\';
		end
	  else
		  workingPath := tmp + '\Delphi\BDE (Legacy)\Samples\';
		  
      registry.CloseKey();

    end;
  end;
  registry.Free();

  if (dbPath = '') OR (workingPath = '') then
  begin

    ShowMessage('Unable to find sample database. Make sure List & Label is installed correctly.');
    exit;

  end;

  // D: Verzeichnis setzen
  // US: Set current dir
  workingPath := GetCurrentDir() + '\';

  if not ADOConnection1.Connected then
    begin

      ADOConnection1.ConnectionString := 'Provider=Microsoft.Jet.OLEDB.4.0;' +
                                         'User ID=Admin;' +
                                         'Data Source=' + dbPath + ';' +
                                         'Mode=Share Deny None;' +
                                         'Extended Properties="";' +
                                         'Jet OLEDB:Engine Type=4;';
      ADOConnection1.Connected := true;
      TblCustomers.Filter := 'CustomerID<''D''';
      TblCustomers.Filtered := true;

      TblCustomers.Active := true;
      TblOrders.Active := true;
      TblOrderDetails.Active := true;

    end;
end;

function TfrmMain.GenerateLLProject: integer;
var
  llobjText: TLlDOMObjectText;
  llobjParagraph: TLlDOMParagraph;
  llobjDrawing: TLlDOMObjectDrawing;

  container: TLlDOMObjectReportContainer;
  llobjHelper: TLlDOMObjectRectangle;
  Height, Width: integer;
begin

  //D: Das DOM Objekt an ein List & Label Objekt binden
  //US: Bind the DOM object to a List & Label object
  lldomproj := TLlDomProjectList.Create(LL);

  //D: Ein neues Listen Projekt mit dem Namen 'dynamic.lst' erstellen
  //US: Create a new listproject called 'dynamic.lst'
  result := lldomproj.Open(workingPath + 'dynamic.lst', fmCreate, amReadWrite);
  if result <> 0 then
    exit;

  //D: Mit dieser Eigenschaft kann die Seitenausrichtung bestimmt werden
  //US: With this property you can set the page orientation
  lldomproj.Regions[0].Paper.Orientation := IntToStr(CmbxPageFormat.ItemIndex+1);

  //D: Eine neue Projektbeschreibung dem Projekt zuweisen
  //US: Assign new project description to the project
  lldomproj.ProjectParameterList.ItemName['LL.ProjectDescription'].Contents := 'Dynamically created Project';

  //D: Ein leeres Text Objekt erstellen
  //US: Create an empty text object
  llobjText := TLlDOMObjectText.Create(lldomproj.ObjectList);

  //D: Auslesen der Seitenkoordinaten der ersten Seite
  //US: Get the coordinates for the first page
  Height := StrToInt(lldomproj.Regions[0].Paper.Extent.Vertical);
  Width := StrToInt(lldomproj.Regions[0].Paper.Extent.Horizontal);

  //D: Setzen von Eigenschaften für das Textobjekt
  //US: Set some properties for the text object
  llobjText.Position.Define(10000, 10000, Width-65000, 27000);
  llobjText.LayerID := '1';

  //D: Hinzufügen eines Paragraphen und setzen diverser Eigenschaften
  //US: Add a paragraph to the text object and set some properties
  llobjParagraph := TLlDOMParagraph.Create(llobjText.Paragraphs);
  llobjParagraph.Contents := '"' + dtReportTitle.Text + '"';
  llobjParagraph.Font.Bold := 'True';

  //D: Ändern der Standard Schriftart im Projekt
  //US: Change the default font for the project

  lldomproj.Settings.DefaultFont.SetFont(llFont);
  lldomproj.Settings.DefaultFont.Color := IntToStr(ColorToRGB(lblSampleText.Font.Color));;

  //D: Hinzufügen eines Grafikobjekts
  //US: Add a drawing object
  llobjDrawing := TLlDOMObjectDrawing.Create(lldomproj.ObjectList);
  llobjDrawing.Source.Fileinfo.Filename := 'sunshine.gif';
  llobjDrawing.Position.Define(Width - 50000, 10000, Width - (Width - 40000), 27000);
  llobjDrawing.LayerID := '1';

  //D: Hinzufügen eines Tabellencontainers und setzen diverser Eigenschaften
  //US: Add a table container and set some properties
  container := TLlDOMObjectReportContainer.Create(lldomproj.ObjectList);
  container.Position.Define(10000, 40000, Width - 20000, Height - 44000);

  if rdbtnCrosstab.Checked then
    AddCrosstab(container);
  if rdbtnPieChart.Checked then
    AddPieChart(container);
  if rdbtnBarChart.Checked then
    AddBarChart(container);

  //D: Hinzufügen eines Hilfs-Rechtecks. Wird verwendet um den Tabellencontainer auf der ersten Seite unterhalb der Überschrift anzuzeigen
  //US: Add a helper rectangle. This will be used for showing the tablecontainer at the first page under the title
  llobjHelper := TLlDOMObjectRectangle.Create(lldomproj.ObjectList);

  //D: Setzen von Eigenschaften für das Rechteck
  //US: Set some properties for the rectangle
  llobjHelper.Position.Define(10000, 10000, 1, 30000);
  llobjHelper.LayerID := '1';
  llobjHelper.Frame.Color := 'RGB(255, 255, 255)';

  //D: Den Berichtscontainer mit dem Rechteck Objekt verketten, so dass der Container auf den Folgeseiten mehr Platz einnimmt
  //US: Link the report container to the rectangle object in order to fill up space on following pages
  container.LinkTo(llobjHelper, TLlDOMVerticalLinkType.RelativeToEnd, TLlDOMVerticalSizeAdaptionType.Inverse);

  //D: Projekt Liste als Datei speichern
  //US: Save projectlist to file
  lldomproj.Save(workingPath + 'dynamic.lst');

  //D: Projekt Liste schliessen
  //US: Close project list
  lldomproj.Close();

end;

procedure TfrmMain.TbShtFinishShow(Sender: TObject);
begin
  UpdateInfo();
end;

function TfrmMain.TColorToRGB(oColor: TColor): string;
begin
  result := ('RGB(' + IntToStr( GetRValue( oColor ) ) + ','
                    + IntToStr( GetGValue( oColor ) ) + ','
                    + IntToStr( GetBValue( oColor ) ) + ')' );

end;

procedure TfrmMain.AddCrosstab(container: TLlDOMObjectReportContainer);
var
  crosstab: TLlDOMSubItemCrosstab;
  curr: TLlDOMPropertyOutputFormatterCurrency;
begin

  //D: In dem Container eine Kreuztabelle hinzufügen.
  //US: Add a crosstab into the container.
  crosstab := TLlDOMSubItemCrosstab.Create(container.SubItems);

  //D: Die Tabelle festlegen, aus der die Daten stammen sollen. Als Datenquelle wird die Tabelle "Order_Details" verwendet.
  //US: Define the source table. We use the "Order_Details" table as data source.
  crosstab.SourceTablePath := 'Customers;Orders(Customers2Orders);Order_Details(Orders2Order Details)';

  //D: Hier lassen sich die Daten festlegen, welche für die Zeilen verwendet werden sollen
  //US: Define the data which should be used for the rows
  crosstab.Definition.Rows.Groupings.Add('Customers.CustomerID');

  //D: Hier lassen sich die Daten festlegen, welche für die Spalten verwendet werden sollen
  //US: Define the data which should be used for the columns
  crosstab.Definition.Columns.Groupings.Add('Year(Orders.OrderDate)');
  crosstab.Definition.Columns.Groupings.Add('Month(Orders.OrderDate)');

  //D: Die Überschrift der Spalten kann hier angegeben werden
  //US: Define the cell tiltle with the following line
  crosstab.Definition.Columns.GroupLabel[1].Formula := 'Year$(Orders.OrderDate)';
  crosstab.Definition.Columns.GroupLabel[0].Formula := 'Month$(Orders.OrderDate)';

  //D: Die Überschrift der äussersten Spalten / Zeilen kann hier angegeben werden
  //US: Define the outside cell / row tiltle with the following line
  crosstab.Definition.Columns.GroupLabel.Items[2].Formula := '"Column title"';
  crosstab.Definition.Rows.GroupLabel.Items[1].Formula := '"Row title"';

  //D: Text und Wert, welcher in allen Zellen angezeigt werden soll
  //US: Text and value which should be used for all cells
  crosstab.Definition.Cells.All.Formula := 'Sum(Order_Details.Quantity*Order_Details.UnitPrice)';
  crosstab.Definition.Cells.All.Value := 'Sum(Order_Details.Quantity*Order_Details.UnitPrice)';

  // D: Spaltenüberschriften auf Folgeseiten wiederholen
  // US: Repeat column labels on following pages
  crosstab.Definition.RowWrapping.RepeatLabels := 'True';

  //D: Formatierung für die Zellen festlegen (Währungsformat)
  //US: Apply currency formatter to the cells
  curr := TLlDOMPropertyOutputFormatterCurrency.Create(crosstab.Definition.Cells.All.OutputFormatter);
  curr.CountOfDecimals := '2';

  //D: Diverse Einstellungen für die Farbgebung der Zeilen setzen
  //US: Define properties for the row color schema
  crosstab.Definition.Rows.GroupLabel[0].Filling.Style := '3';
  crosstab.Definition.Rows.GroupLabel[0].Filling.Color := TColorToRGB(lblColorRow1.Color);
  crosstab.Definition.Rows.GroupLabel[0].Filling.Color2 := TColorToRGB(lblColorRow2.Color);

  //D: Festlegen, ob die Zeilen aufsteigend oder absteigend sortiert werden sollen
  //US: Define whether the rows should be sorted ascending or descending
  case RdGrpCellSortOrder.ItemIndex of
    0:
      crosstab.Definition.Rows.GroupLabel[0].SortOrderAscending.SortOrder := '0';
    1:
      crosstab.Definition.Rows.GroupLabel[0].SortOrderAscending.SortOrder := '1';
  end;

  //D: Diverse Einstellungen für die Farbgebung der Spalten setzen
  //US: Define properties for the column color schema
  crosstab.Definition.Columns.GroupLabel[0].Filling.Style := '3';
  crosstab.Definition.Columns.GroupLabel[0].Filling.Color := TColorToRGB(lblColorCell1.Color);
  crosstab.Definition.Columns.GroupLabel[0].Filling.Color2:= TColorToRGB(lblColorCell2.Color);

  //D: Festlegen, ob die Spalten aufsteigend oder absteigend sortiert werden sollen
  //US: Define whether the columns should be sorted ascending or descending
  case RdGrpRowSortOrder.ItemIndex of
    0:
      crosstab.Definition.Columns.GroupLabel[0].SortOrderAscending.SortOrder := '0';
    1:
      crosstab.Definition.Columns.GroupLabel[0].SortOrderAscending.SortOrder := '1';
  end;

end;

//**** D: Erstellen eines Kreisdiagramms ****
//**** US: Create a pie-chart ****
procedure TfrmMain.AddPieChart(container: TLlDOMObjectReportContainer);
var
  chart: TLlDOMSubItemChart;
  engine: TLlDOMPropertyChartEnginePie3D;
  curr: TLlDOMPropertyOutputFormatterCurrency;
begin

  //D: In dem Container ein Chart-Objekt hinzufügen und dessen Namen vergeben.
  //US: Add a chart into the container and define its name.
  chart := TLlDOMSubItemChart.Create(ctPie3D, container.SubItems);
  chart.Name := 'Pie3D';

  //D: Die Tabelle festlegen, aus der die Daten stammen sollen. Als Datenquelle wird die Tabelle "Order_Details" verwendet.
  //US: Define the source table. We use the "Order_Details" table as data source.
  chart.SourceTablePath := 'Customers;Orders(Customers2Orders);Order_Details(Orders2Order Details)';

  //D: Um Zugriff auf die Chart-Engine zu bekommen, muss diese zunächst in den passenden Typ konvertiert werden
  //US: To access the chart-engine, it is necessary to convert it in the suitable type at first
  engine := chart.Definition.ChartEngine as TLlDOMPropertyChartEnginePie3D;

  //D: In den folgenden Zeilen wird die Datenquelle angegeben
  //US: In the following lines, the data source is defined
  engine.XAxis.Value := 'Customers.CustomerID';
  engine.YAxis[0].Value := 'Order_Details.UnitPrice*Order_Details.Quantity';
  engine.YAxis[0].CoordinateLabelOnObject.Placement := '1';
  engine.YAxis[0].CoordinateLabelOnObject.Formula := 'LL.ChartObject.ArcValue';

  //D: Die Überschrift des Charts kann hier angegeben werden
  //US: Define the chart title with the following line
  chart.Definition.Title.Contents := '"' + dtTitle2.Text + '"';

  //D: Formatierung für die Legende
  //US: Define the legend format
  curr := TLlDOMPropertyOutputFormatterCurrency.Create(engine.YAxis[0].CoordinateLabelOnObject.OutputFormatter);

  //D: Eine Anzahl von zwei Nachkommastellen
  //US: A number of two decimal places
  curr.CountOfDecimals := '2';

end;

//**** D: Erstellen eines Balkendiagramms ****
//**** US: Create a bar-chart ****
procedure TfrmMain.AddBarChart(container: TLlDOMObjectReportContainer);
var
  currBar: TLlDOMPropertyOutputFormatterCurrency;
  engineBar: TLlDOMPropertyChartEngineBar3D;
  chartBar: TLlDOMSubItemChart;
begin

  //D: In dem Container ein Chart-Objekt hinzufügen und dessen Namen vergeben.
  //US: Add a chart into the container and define its name.
  chartBar := TLlDOMSubItemChart.Create(ctBar3D, container.SubItems);

  chartBar.Name := 'Bar3D';

  //D: Die Tabelle festlegen, aus der die Daten stammen sollen. Als Datenquelle wird die Tabelle "Order_Details" verwendet.
  //US: Define the source table. We use the "Order_Details" table as data source.
  chartBar.SourceTablePath := 'Customers;Orders(Customers2Orders);Order_Details(Orders2Order Details)';

  //D: Um Zugriff auf die Chart-Engine zu bekommen, muss diese zunächst in den passenden Typ konvertiert werden
  //US: To access the chart-engine, it is necessary to convert it in the suitable type at first
  engineBar := chartBar.Definition.ChartEngine as TLlDOMPropertyChartEngineBar3D;

  //D: In den folgenden Zeilen wird die Datenquelle angegeben
  //US: In the following lines, the data source is defined
  engineBar.XAxis.Value := 'Customers.CustomerID';
  engineBar.YAxes[0].Value := 'Order_Details.UnitPrice*Order_Details.Quantity';
  engineBar.YAxes[0].CoordinateLabelOnObject.Placement := '1';

  //D: Die Überschrift des Charts kann hier angegeben werden
  //US: Define the chart title with the following line
  chartBar.Definition.Title.Contents := '"' + dtTitle3.Text + '"';

  //D: Formatierung für die Legende
  //US: Define the legend format
  currBar := TLlDOMPropertyOutputFormatterCurrency.Create(engineBar.YAxes[0].CoordinateLabelOnObject.OutputFormatter);

  //D: Eine Anzahl von zwei Nachkommastellen
  //US: A number of two decimal places
  currBar.CountOfDecimals := '2';

end;

procedure TfrmMain.UpdateInfo;
begin

  lbl_Schema.Caption := Label9.Caption;

  lbl_Cell.Caption := TColorToRGB(lblColorCell1.Color) + ' - ' + TColorToRGB(lblColorCell2.Color) + ', ' + RdGrpCellSortOrder.Items[RdGrpCellSortOrder.ItemIndex];
  lbl_Row.Caption := TColorToRGB(lblColorRow1.Color) + ' - ' + TColorToRGB(lblColorRow2.Color) + ', ' + RdGrpRowSortOrder.Items[RdGrpRowSortOrder.ItemIndex];

  lbl_Project.Caption := Label4.Caption;
  lbl_Font.Caption := llFont.Name + ', ' + IntToStr(llFont.Size);

end;

end.

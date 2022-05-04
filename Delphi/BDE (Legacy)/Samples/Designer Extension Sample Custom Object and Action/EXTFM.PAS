{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------

D:  Dieses Beispiel demonstriert die Erweiterung des Designers mit eigenen Objekten
US: This example demonstrates how to extend the designer with your own objects
======================================================================================}

unit extfm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, L27, L27dom, Menus, DB, ADODB, Registry, L27db
  {$If CompilerVersion >=28} // >=XE7
  , System.UITypes
  {$ENDIF}
  ;

type
  TDesExtForm = class(TForm)
    GradientFillObject: TLL27XObject;
    DesignButton: TButton;
    Label1: TLabel;
    Label2: TLabel;
    PopupMenu1: TPopupMenu;
    ColorDialog1: TColorDialog;
    EditColor11: TMenuItem;
    EditColor21: TMenuItem;
    RomanNumber: TLL27XFunction;
    Label3: TLabel;
    Label4: TLabel;
    chckBxDebug: TCheckBox;
    ADOConnection1: TADOConnection;
    Orders: TADOTable;
    OrderDetails: TADOTable;
    dsCustomers: TDataSource;
    dsOrders: TDataSource;
    LL: TDBL27_;
    Customers: TADOTable;
    CustomersCustomerID: TWideStringField;
    CustomersContactName: TWideStringField;
    CustomersAddress: TWideStringField;
    CustomersCity: TWideStringField;
    CustomersPhone: TWideStringField;
    LL27XAction4: TLL27XAction;
    procedure DesignButtonClick(Sender: TObject);
    procedure LLDefineVariables(Sender: TObject; UserData: Integer;
      IsDesignMode: Boolean; var Percentage: Integer;
      var IsLastRecord: Boolean; var Result: Integer);
    procedure GradientFillObjectDraw(Sender: TObject; Canvas: TCanvas;
      Rect: TRect; IsDesignMode: Boolean; var IsFinished: Boolean);
    procedure GradientFillObjectEdit(Sender: TObject;
      ParentHandle: Cardinal; var HasChanged: Boolean);
    procedure GradientFillObjectInitialCreation(Sender: TObject;
      ParentHandle: Cardinal);
    procedure EditColor1Click(Sender: TObject);
    procedure EditColor2Click(Sender: TObject);
    procedure LL27XAction1ExecuteAction;
    procedure chckBxDebugClick(Sender: TObject);
    procedure RomanNumberEvaluateFunction(Sender: TObject;
      var ResultType: TLL27XFunctionParameterType;
      var ResultValue: OleVariant; var DecimalPositions: Integer;
      const ParameterCount: Integer; const Parameter1, Parameter2,
      Parameter3, Parameter4: OleVariant);
    procedure RomanNumberParameterAutoComplete(Sender: TObject;
      ParameterIndex: Integer; var Values: TStringList);
    procedure FormCreate(Sender: TObject);
    procedure LL27XAction3ExecuteAction;
    procedure LL27XAction4ExecuteAction;
  private
    workingPath: String;
    procedure DeleteAllObjects();
    procedure GenerateLLCustomerlistTemplate();
    procedure GenerateLLStatisticTemplate();
    procedure AddPieChart(container: TLlDOMObjectReportContainer);
  public
    { Public declarations }
  end;

var
  DesExtForm: TDesExtForm;
  objName: string;

implementation

uses
 cmbtll27, gdi, clrSel, uquest, roman;

{$R *.dfm}

procedure TDesExtForm.DesignButtonClick(Sender: TObject);
begin
    // D:  Designer starten
    // US: Start Designer
    LL.AutoDesign('Designer Extension Sample');
end;

procedure TDesExtForm.LLDefineVariables(Sender: TObject; UserData: Integer;
  IsDesignMode: Boolean; var Percentage: Integer;
  var IsLastRecord: Boolean; var Result: Integer);
begin
    // D:  Nur einen Datensatz drucken
    // US: Print only one record
    if not IsDesignMode then
        IsLastRecord:=true;
end;

procedure TDesExtForm.GradientFillObjectDraw(Sender: TObject;
  Canvas: TCanvas; Rect: TRect; IsDesignMode: Boolean;
  var IsFinished: Boolean);
var
  color1, color2: TColor;
  color1Str, color2Str: string;
  code: integer;
begin
    with Sender as TLL27XObject do
    begin
        Properties.GetValue('Color1',color1Str);
        Properties.GetValue('Color2',color2Str);
        val(color1Str,color1,code);
        val(color2Str,color2,code);

        // D:  Objekt zeichnen
        // US: Draw object
        MyGradientFill(Canvas, Rect, color1, color2);
    end;
end;

procedure TDesExtForm.GradientFillObjectEdit(Sender: TObject;
  ParentHandle: Cardinal; var HasChanged: Boolean);
var
  color1, color2: TColor;
  color1Str, color2Str: string;
  code: integer;
begin
    // D:  Objekt bearbeiten
    // US: Edit object

    HasChanged:=False;
    with Sender as TLL27XObject do
    begin
        // D:  Dialog initialisieren
        // US: Initialize dialog
        Properties.GetValue('Color1',color1Str);
        Properties.GetValue('Color2',color2Str);
        val(color1Str,color1,code);
        val(color2Str,color2,code);
        with ColorSelectForm do
        begin
            SelColor1:=Color1;
            SelColor2:=Color2;

            // D:  Dialog anzeigen
            // US: Display dialog
            if ShowModal = mrOK then
            begin
                // D:  Neue Werte an Objekt übergeben
                // US: Pass new values to object
                Properties.AddProperty('Color1', Format('%d', [SelColor1]));
                Properties.AddProperty('Color2', Format('%d', [SelColor2]));
                HasChanged:=True;
            end;
        end;

    end;
end;

procedure TDesExtForm.GradientFillObjectInitialCreation(Sender: TObject;
  ParentHandle: Cardinal);
begin
    with Sender as TLL27XObject do
    begin
        // D:  Objekt initialisieren
        // US: Initialize object
        Properties.AddProperty('Color1', '255'); // $0000FF
        Properties.AddProperty('Color2', '65280');   // $00FF00
    end;
end;

procedure TDesExtForm.EditColor1Click(Sender: TObject);
var
  colorStr: string;
  code: integer;
  CurrentColor: TColorref;
begin
    // D:  Kontextmenuehandler für Farbe 1
    // US: Handler for "Color 1" context menu
    with (Sender as TLL27XObject) do
    begin
      Properties.GetValue('Color1',colorStr);
      val(colorStr,CurrentColor,code);
      with ColorDialog1 do
      begin
        Color:=CurrentColor;
        if Execute then
        begin
          CurrentColor:=Color;
          Properties.AddProperty('Color1', Format('%d', [CurrentColor]));
        end;
      end;
    end;
end;

procedure TDesExtForm.EditColor2Click(Sender: TObject);
var
  colorStr: string;
  code: integer;
  CurrentColor: TColorref;
begin
    // D:  Kontextmenuehandler für Farbe 2
    // US: Handler for "Color 2" context menu
    with (Sender as TLL27XObject) do
    begin
      Properties.GetValue('Color2',colorStr);
      val(colorStr,CurrentColor,code);
      with ColorDialog1 do
      begin
        Color:=CurrentColor;
        if Execute then
        begin
          CurrentColor:=Color;
          Properties.AddProperty('Color2', Format('%d', [CurrentColor]));
        end;
      end;
    end;
end;

procedure TDesExtForm.LL27XAction1ExecuteAction;
var
  proj: TLlDOMProjectList;
  found: boolean;
  i: integer;
begin
  proj := TLlDOMProjectList.Create(LL);
  proj.GetFromParent();

  frmquest.ShowModal;
  if objName = '' then
    exit;
    
  proj.DesignerRedraw := 'False';
  found := false;

  for i := 0 to proj.ObjectList.Count - 1 do
  begin
    if TLlDOMObjectBase(proj.ObjectList.Items[i]).Name = objName then
    begin
      found := true;
      TLlDOMObjectBase(proj.ObjectList.Items[i]).Selected := 'True';
    end else
      TLlDOMObjectBase(proj.ObjectList.Items[i]).Selected := 'False';
  end;

  proj.DesignerRedraw := 'True';

  if not found then
    ShowMessage('The object could not be found.');

end;

procedure TDesExtForm.chckBxDebugClick(Sender: TObject);
{D:  (De)aktiviert Debug-Ausgaben     }
{US: enables or disables debug output }
begin
   If chckBxDebug.checked=true
   then
   begin
        LL.DebugMode:=1;
        MessageDlg('D:  DEBWIN muss zur Anzeige von Debugausgaben gestartet werden'+#13
             +'US: Start DEBWIN to receive debug messages', mtInformation,
             [mbOK],0);
   end
   else LL.DebugMode:=0;
end;

procedure TDesExtForm.RomanNumberEvaluateFunction(Sender: TObject;
  var ResultType: TLL27XFunctionParameterType; var ResultValue: OleVariant;
  var DecimalPositions: Integer; const ParameterCount: Integer;
  const Parameter1, Parameter2, Parameter3, Parameter4: OleVariant);
begin
    // D:  Funktionsberechnung
    // US: Actual function evaluation
    ResultValue:=ToRoman(Parameter1);
end;

procedure TDesExtForm.RomanNumberParameterAutoComplete(Sender: TObject;
  ParameterIndex: Integer; var Values: TStringList);
var index: integer;
begin
    // D:  Werte für Auto-Complete vorgeben. Hier einfach nur "1".."9"
    // US: Offer auto complete values. For this sample just add "1".."9"
    for index:=1 to 9 do
    begin
        Values.Add(Format('%d',[index]));
    end;
end;

procedure TDesExtForm.FormCreate(Sender: TObject);

var registry: TRegistry;
var regKeyPath: String;
var dbPath: String;
var tmp: String;

begin
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
  LL.AutoDesignerFile := workingPath + 'desext.lst';

  if not ADOConnection1.Connected then
    begin

      ADOConnection1.ConnectionString := 'Provider=Microsoft.Jet.OLEDB.4.0;' +
                                         'User ID=Admin;' +
                                         'Data Source=' + dbPath + ';' +
                                         'Mode=Share Deny None;' +
                                         'Extended Properties="";' +
                                         'Jet OLEDB:Engine Type=4;';
      ADOConnection1.Connected := true;
      Customers.Active := true;
      Orders.Active := true;
      OrderDetails.Active := true;

    end;
end;

procedure TDesExtForm.DeleteAllObjects;
var
 proj: TLlDOMProjectList;
begin
 proj := TLlDOMProjectList.Create(LL);
 proj.GetFromParent();

 proj.DesignerRedraw := 'False';

 while (proj.ObjectList.Count <>0) do
 begin
   proj.ObjectList.DeleteSubobject(0);
 end;

 proj.DesignerRedraw := 'True';
end;

procedure TDesExtForm.GenerateLLCustomerlistTemplate;
var
  lldomproj: TLlDomProjectList;
  llobjText: TLlDOMObjectText;
  llobjParagraph: TLlDOMParagraph;
  llobjDrawing: TLlDOMObjectDrawing;

  container: TLlDOMObjectReportContainer;
  table: TLlDOMSubItemTable;
  tableLineData: TLlDOMTableLineData;
  tableLineHeader: TLlDOMTableLineHeader;
  header, tableField: TLlDOMTableFieldText;
  i, Height, Width: integer;
  fieldWidth: string;
begin
      //D: Das DOM Objekt an ein List & Label Objekt binden
      //US: Bind the DOM object to a List & Label object

      lldomproj := TLlDomProjectList.Create(LL);
      lldomproj.GetFromParent();

      //D: Mit dieser Eigenschaft kann die Seitenausrichtung bestimmt werden
      //US: With this property you can set the page orientation
      lldomproj.Regions[0].Paper.Orientation := '1';


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

      //D: Hinzufügen eines Paragraphen und setzen diverser Eigenschaften
      //US: Add a paragraph to the text object and set some properties
      llobjParagraph := TLlDOMParagraph.Create(llobjText.Paragraphs);
      llobjParagraph.Contents := '"Template for your customer list"';
      llobjParagraph.Font.Size := '18';
      llobjParagraph.Font.Bold := 'True';

      //D: Hinzufügen eines Grafikobjekts
      //US: Add a drawing object
      llobjDrawing := TLlDOMObjectDrawing.Create(lldomproj.ObjectList);
      llobjDrawing.Source.Fileinfo.Filename := 'sunshine.gif';
      llobjDrawing.Position.Define(Width - 50000, 10000, Width - (Width - 40000), 27000);

      //D: Hinzufügen eines Tabellencontainers und setzen diverser Eigenschaften
      //US: Add a table container and set some properties
      container := TLlDOMObjectReportContainer.Create(lldomproj.ObjectList);
      container.Position.Define(10000, 40000, Width - 20000, Height - 44000);

      //D: In dem Tabellencontainer eine Tabelle hinzufügen
      //US: Add a table into the table container
      table := TLlDOMSubItemTable.Create(container.SubItems);
      table.TableID := 'Customers';

      //D: Zebramuster für Tabelle definieren
      //US: Define zebra pattern for table
      table.LineOptions.Data.ZebraPattern.Style := '1';
      table.LineOptions.Data.ZebraPattern.Pattern := '1';
      table.LineOptions.Data.ZebraPattern.Color := 'RGB(225,225,225)';

      //D: Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
      //US: Add a new data line including all selected fields
      tableLineData := TLlDOMTableLineData.Create(table.Lines.Data);
      tableLineHeader := TLlDOMTableLineHeader.Create(table.Lines.Header);

      for i := 0 to 5 - 1 do
      begin

              fieldWidth := Format('%f', [StrToInt(container.Position.Width) / 5]);

              //D: Kopfzeile definieren
              //US: Define head line
              header := TLlDOMTableFieldText.Create(tableLineHeader.Fields);
              header.Contents := '"' + Customers.Fields[i].FieldName + '"';
              header.Filling.Style := '1';
              header.Filling.Color := 'RGB(255,153,51)';
              header.Font.Bold := 'True';
              header.Width := fieldWidth;

              //D: Datenzeile definieren
              //US: Define data line
              tableField := TLlDOMTableFieldText.Create(tableLineData.Fields);
              tableField.Contents := 'Customers.' + Customers.Fields[i].FieldName;
              tableField.Width := fieldWidth;

      end;

      lldomproj.DesignerRedraw := 'True';
      lldomproj.Free;	
end;

procedure TDesExtForm.LL27XAction3ExecuteAction;

var proj: TLlDomProjectList;

begin

  //D: Alle Objekte im Designer löschen
  //US: Delete all objects within the Designer
  DeleteAllObjects();

  proj := TLlDOMProjectList.Create(LL);
  proj.GetFromParent();
  proj.DesignerRedraw := 'False';

  //D: Druckvorlage per DOM erzeugen
  //US: Create the template via DOM
  GenerateLLCustomerlistTemplate();

  proj.DesignerRedraw := 'True';

end;

procedure TDesExtForm.GenerateLLStatisticTemplate;
var
  lldomproj: TLlDomProjectList;
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
  lldomproj.GetFromParent();

  //D: Mit dieser Eigenschaft kann die Seitenausrichtung bestimmt werden
  //US: With this property you can set the page orientation
  lldomproj.Regions[0].Paper.Orientation := '2';

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
  llobjParagraph.Contents := '"Template for your statistic"';
  llobjParagraph.Font.Bold := 'True';

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

  AddPieChart(container);

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

end;

procedure TDesExtForm.AddPieChart(container: TLlDOMObjectReportContainer);
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

  //D: Die Überschrift des Charts kann hier angegeben werden
  //US: Define the chart title with the following line
  chart.Definition.Title.Contents := '"Customer statistic"';

  chart.Definition.Background.Visible := 'True';
  chart.Definition.Background.Rounding := '25';
  chart.Definition.Background.Filling.Style := '2';
  chart.Definition.Background.Filling.Alpha := '50';
  chart.Definition.Background.Filling.Color := 'LL.Color.SkyBlue';
  chart.Definition.Background.Filling.Pattern := '2';

  chart.Definition.ChartEngine.Flat := 'False';

  //D: Um Zugriff auf die Chart-Engine zu bekommen, muss diese zunächst in den passenden Typ konvertiert werden
  //US: To access the chart-engine, it is necessary to convert it in the suitable type at first
  engine := chart.Definition.ChartEngine as TLlDOMPropertyChartEnginePie3D;

  //D: In den folgenden Zeilen wird die Datenquelle angegeben
  //US: In the following lines, the data source is defined
  engine.XAxis.Value := 'Customers.CustomerID';
  engine.YAxis[0].Value := 'Order_Details.UnitPrice*Order_Details.Quantity';
  engine.YAxis[0].CoordinateLabelOnObject.Placement := '1';
  engine.YAxis[0].CoordinateLabelOnObject.Formula := '1';
  engine.YAxis[0].ExplosionPercentage := '10';
  engine.YAxis[0].Width := '75';

  //D: Formatierung für die Legende
  //US: Define the legend format
  curr := TLlDOMPropertyOutputFormatterCurrency.Create(engine.YAxis[0].CoordinateLabelOnObject.OutputFormatter);

  //D: Eine Anzahl von zwei Nachkommastellen
  //US: A number of two decimal places
  curr.CountOfDecimals := '2';
end;

procedure TDesExtForm.LL27XAction4ExecuteAction;

var proj: TLlDomProjectList;

begin

  //D: Alle Objekte im Designer löschen
  //US: Delete all objects within the Designer
  DeleteAllObjects();

  proj := TLlDOMProjectList.Create(LL);
  proj.GetFromParent();
  proj.DesignerRedraw := 'False';

  //D: Druckvorlage per DOM erzeugen
  //US: Create the template via DOM
  GenerateLLStatisticTemplate();

  proj.DesignerRedraw := 'True';

end;

end.

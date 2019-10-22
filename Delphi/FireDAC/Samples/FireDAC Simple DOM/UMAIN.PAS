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
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Registry, DB, ADODB, L25dom, cmbtll25, LlReport_Types,
  FireDAC.Stan.Intf, FireDAC.Stan.Option, FireDAC.Stan.Error,
  FireDAC.UI.Intf, FireDAC.Phys.Intf, FireDAC.Stan.Def, FireDAC.Stan.Pool,
  FireDAC.Stan.Async, FireDAC.Phys, FireDAC.Phys.MSAcc, FireDAC.Phys.MSAccDef,
  FireDAC.VCLUI.Wait, FireDAC.Comp.Client, FireDAC.Stan.Param, FireDAC.DatS,
  FireDAC.DApt.Intf, FireDAC.DApt, FireDAC.Comp.DataSet, ListLabel25, StrUtils
  {$IFDEF ver280} // XE7
  , System.UITypes
  {$ENDIF}
  ;

type
  TfrmMain = class(TForm)
    btnDesign: TButton;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    BtnPreview: TButton;
    CmBxTables: TComboBox;
    Label5: TLabel;
    LstBxAvFields: TListBox;
    LstBxSelFields: TListBox;
    Label6: TLabel;
    Label7: TLabel;
    BtnSelect: TButton;
    BtnUnSelect: TButton;
    Label8: TLabel;
    Label9: TLabel;
    dtTitle: TEdit;
    dtLogo: TEdit;
    btnLogo: TButton;
    OpenDialog1: TOpenDialog;
    LL: TListLabel25;
    FDConnectionNorthwind: TFDConnection;
    DataSource1: TDataSource;
    FDTable: TFDTable;
    procedure FormCreate(Sender: TObject);
    procedure CmBxTablesClick(Sender: TObject);
    procedure BtnSelectClick(Sender: TObject);
    procedure BtnUnSelectClick(Sender: TObject);
    procedure btnDesignClick(Sender: TObject);
    procedure LstBxAvFieldsDblClick(Sender: TObject);
    procedure LstBxSelFieldsDblClick(Sender: TObject);
    procedure btnLogoClick(Sender: TObject);
    procedure BtnPreviewClick(Sender: TObject);
  private
    workingPath: String;
    TableName: TString;
    procedure GetTableFields();
    function GenerateLLProject(): integer;
    procedure SelectFields();
    procedure UnSelectFields();
    procedure ChangeTableName(ComboBox: TComboBox);
  public
    { Public declarations }
  end;

var
  frmMain: TfrmMain;
  lldomproj: TLlDomProjectList;

implementation

{$R *.dfm}

procedure TfrmMain.FormCreate(Sender: TObject);

Var NWindDatabasePath: String;
Registry: TRegistry;
Error: Boolean;
ErrorMessage: String;
begin

   Error := False;
   ErrorMessage := 'Unable to find sample database. Make sure List & Label is installed correctly.';

   Registry := TRegistry.Create(KEY_READ);
   if (Registry.OpenKeyReadOnly('Software\combit\cmbtll')) then
   begin

      NWindDatabasePath := Registry.ReadString('NWINDPath');
      if (FileExists(NWindDatabasePath)) then
      begin

        try

          FDConnectionNorthwind.Connected := False;
          FDConnectionNorthwind.Params.Database := NWindDatabasePath;
          FDConnectionNorthwind.Connected := True;

        Except

            on Ecx: Exception do
            begin

              Error := True;
              ErrorMessage := 'Unable to find sample database. Make sure List & Label is installed correctly.' + #13#10#13#10 + Ecx.ClassName + ' error raised, with message: ' + Ecx.Message;

            end;

        end;

      end
      else
      begin

        Error := True;

      end;

      Registry.CloseKey;

   end
   else
   begin

    Error := True;

   end;

  Registry.Free;

  if (Error) then
   begin
      MessageBox(self.Handle, PWideChar(ErrorMessage), 'List & Label', MB_OK);
   end;
  //D: Combobox mit Tabellennamen aus der Datasource füllen.
  //US:Fill the combobox with table names from the data source
  FDConnectionNorthwind.GetTableNames('', '', '',CmBxTables.Items, [osMy, osOther], [tkTable]);
  ChangeTableName(CmBxTables);
  CmBxTables.ItemIndex := 0;
  GetTableFields();

  //D: Pfad zum Logo für das Layout
  //US: Path for the logo for the layout
  dtLogo.Text := workingPath + 'sunshine.gif';

end;


procedure TfrmMain.ChangeTableName(ComboBox: TComboBox);
var
i: integer;
TableNameWithOutBrackets: string;
begin

  for i := 0 to ComboBox.Items.Count - 1 do
  //D: Entfernen der Klammern im Tabellennamen
  //US: Removing the brackets in the table name
    if AnsiStartsStr('[', ComboBox.Items[i]) then
      begin
      TableNameWithOutBrackets:= AnsiMidStr(ComboBox.Items[i],Pos('[', ComboBox.Items[i])+1, Pos(']', ComboBox.Items[i])-2) ;
      ComboBox.Items[i] := TableNameWithOutBrackets;
      break;
    end;

end;

procedure TfrmMain.CmBxTablesClick(Sender: TObject);
begin
  LstBxAvFields.Clear();
  LstBxSelFields.Clear();
  GetTableFields();
end;

procedure TfrmMain.GetTableFields;
begin
  FDConnectionNorthwind.GetFieldNames('', '', CmBxTables.Items[CmBxTables.ItemIndex],'', LstBxAvFields.Items);
end;

procedure TfrmMain.BtnPreviewClick(Sender: TObject);
var
  nRet: integer;
  ErrorBuffer: Array [0 .. 255] of char;
  ErrorText: TString;
begin

  //D: Tabelle für das Layout festlegen
  //US: Determine table for the layout
  TableName := CmBxTables.Items[CmBxTables.ItemIndex];
  FDTable.Active := false;
  FDTable.TableName:= TableName;
  FDTable.Active := true;
  DataSource1.DataSet:= FDTable;
  DataSource1.Enabled:= true;

  //D: Eintellungen für die List & Label Komponente setzen
  //US: Define properties for the List & Label control
  LL.DataController.DataSource:= DataSource1;
  with  LL.DataController.DetailSources.Add do
  begin
    Name:= TableName;
    DataSource:= DataSource1;
  end;

  LL.AutoProjectFile := workingPath + 'dynamic.lst';
  LL.AutoShowSelectFile := false;

	//D: List & Label Projekt anhand Einstellungen erstellen
	//US: Create List & Label project based on the settings
  nRet := GenerateLLProject();

  if nRet <> 0 then
  begin
    LlGetErrortext(nRet, ErrorBuffer, SizeOf(ErrorBuffer));
    ErrorText := IntToStr(nRet) + ' (' + StrPas(ErrorBuffer) + ' )';
    MessageDlg(ErrorText, mtInformation, [mbOK], 0);
  end
  else
    //D: Designer aufrufen
    //US: Call the designer
    LL.AutoDestination :=  TLlPrintMode.pmPreview;
    LL.AutoShowPrintOptions := false;
    LL.Print();

  LL.DataController.DetailSources.Clear;
end;

procedure TfrmMain.BtnSelectClick(Sender: TObject);
begin
  SelectFields();
end;

procedure TfrmMain.BtnUnSelectClick(Sender: TObject);
begin
  UnSelectFields();
end;

procedure TfrmMain.btnDesignClick(Sender: TObject);
var
  nRet: integer;
  ErrorBuffer: Array [0 .. 255] of char;
    ErrorText: TString;
begin

  //D: Tabelle für das Layout festlegen
  //US: Determine table for the layout
  TableName := CmBxTables.Items[CmBxTables.ItemIndex];
  FDTable.Active := false;
  FDTable.TableName := TableName;
  FDTable.Active := true;
  DataSource1.DataSet:= FDTable;
  DataSource1.Enabled:= true;

  //D: Eintellungen für die List & Label Komponente setzen
  //US: Define properties for the List & Label control
  LL.DataController.DataSource:= DataSource1;
  with  LL.DataController.DetailSources.Add do
  begin

    Name:= TableName;
    DataSource:= DataSource1;
  end;
  LL.AutoProjectFile := workingPath + 'dynamic.lst';
  LL.AutoShowSelectFile := false;

	//D: List & Label Projekt anhand Einstellungen erstellen
	//US: Create List & Label project based on the settings
  nRet := GenerateLLProject();
  if nRet <> 0 then
  begin
    LlGetErrortext(nRet, ErrorBuffer, SizeOf(ErrorBuffer));
    ErrorText := IntToStr(nRet) + ' (' + StrPas(ErrorBuffer) + ' )';
    MessageDlg(ErrorText, mtInformation, [mbOK], 0);
  end
  else
    //D: Designer aufrufen
    //US: Call the designer
    LL.Design();

  LL.DataController.DetailSources.Clear;
end;

//D:  Hinweis: Beim Verwenden der List & Label DOM Klassen ist zu beachten, dass
//    die einzelnen Eigenschafts-Werte als Zeichenkette angegeben werden müssen.
//    Dies ist notwendig um ein Höchstmaß an Flexibilität zu gewährleisten, da
//    somit auch List & Label Formeln erlaubt sind.
//US: Hint: When using List & Label DOM classes please note that the property
//    values have to be passed as strings. This is necessary to ensure a maximum
//    of flexibility - this way, List & Label formulas can be used as property
//    values.
function TfrmMain.GenerateLLProject: integer;
var
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
      TableName:= StringReplace(TableName, ' ', '_', [rfReplaceAll, rfIgnoreCase]);
      //D: Das DOM Objekt an ein List & Label Objekt binden
      //US: Bind the DOM object to a List & Label object
      lldomproj := TLlDomProjectList.Create(LL);

      //D: Ein neues Listen Projekt mit dem Namen 'dynamic.lst' erstellen
      //US: Create a new list project called 'dynamic.lst'
      result := lldomproj.Open(workingPath + 'dynamic.lst', fmCreate, amReadWrite);
      if result <> 0 then
        exit;

      //D: Eine neue Projektbeschreibung zuweisen
      //US: Assign new project description
      lldomproj.ProjectParameterList.ItemName['LL.ProjectDescription'].Contents := 'Dynamically Created Project';

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

      //D: Hinzufügen eines Paragraphen und Setzen diverser Eigenschaften
      //US: Add a paragraph to the text object and set some properties
      llobjParagraph := TLlDOMParagraph.Create(llobjText.Paragraphs);
      llobjParagraph.Contents := '"' + dtTitle.Text + '"';
      llobjParagraph.Font.Bold := 'True';

      //D: Hinzufügen eines Grafikobjekts
      //US: Add a drawing object
      llobjDrawing := TLlDOMObjectDrawing.Create(lldomproj.ObjectList);
      llobjDrawing.Source.Fileinfo.Filename := dtLogo.Text;
      llobjDrawing.Position.Define(Width - 50000, 10000, Width - (Width - 40000), 27000);

      //D: Hinzufügen eines Berichtscontainers und setzen diverser Eigenschaften
      //US: Add a report container and set some properties
      container := TLlDOMObjectReportContainer.Create(lldomproj.ObjectList);
      container.Position.Define(10000, 40000, Width - 20000, Height - 44000);

      //D: In dem Berichtscontainer eine Tabelle hinzufügen
      //US: Add a table into the report container
      table := TLlDOMSubItemTable.Create(container.SubItems);
      table.TableID := TableName;

      //D: Zebramuster für Tabelle definieren
      //US: Define zebra pattern for table
      table.LineOptions.Data.ZebraPattern.Style := '1';
      table.LineOptions.Data.ZebraPattern.Pattern := '1';
      table.LineOptions.Data.ZebraPattern.Color := 'RGB(225,225,225)';

      //D: Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
      //US: Add a new data line including all selected fields
      tableLineData := TLlDOMTableLineData.Create(table.Lines.Data);
      tableLineHeader := TLlDOMTableLineHeader.Create(table.Lines.Header);

      for i := 0 to LstBxSelFields.Items.Count - 1 do
      begin

              fieldWidth := Format('%f', [StrToInt(container.Position.Width) / LstBxSelFields.Items.Count]);

              //D: Kopfzeile definieren
              //US: Define head line
              header := TLlDOMTableFieldText.Create(tableLineHeader.Fields);
              header.Contents := '"' + LstBxSelFields.Items[i] + '"';
              header.Filling.Style := '1';
              header.Filling.Color := 'RGB(255,153,51)';
              header.Font.Bold := 'True';
              header.Width := fieldWidth;

              //D: Datenzeile definieren
              //US: Define data line
              tableField := TLlDOMTableFieldText.Create(tableLineData.Fields);
              tableField.Contents := TableName + '.' + LstBxSelFields.Items[i];
              tableField.Width := fieldWidth;

      end;

      //D: Projekt Liste als Datei speichern
      //US: Save projectlist to file
      lldomproj.Save(workingPath + 'dynamic.lst');


      //D: Projekt Liste schliessen
      //US: Close project list
      lldomproj.Close();
	  lldomproj.Free;

end;

procedure TfrmMain.LstBxAvFieldsDblClick(Sender: TObject);
begin
  SelectFields();
end;

procedure TfrmMain.SelectFields;
var
 i: integer;
begin
  for i := 0 to LstBxAvFields.Items.Count - 1 do
    if LstBxAvFields.Selected[i] then
     LstBxSelFields.Items.Add(LstBxAvFields.Items[i]);

  LstBxAvFields.DeleteSelected;
end;

procedure TfrmMain.UnSelectFields;
var
 i: integer;
begin
  for i := 0 to LstBxSelFields.Items.Count - 1 do
    if LstBxSelFields.Selected[i] then
      LstBxAvFields.Items.Add(LstBxSelFields.Items[i]);

  LstBxSelFields.DeleteSelected;
end;

procedure TfrmMain.LstBxSelFieldsDblClick(Sender: TObject);
begin
  UnSelectFields();
end;

procedure TfrmMain.btnLogoClick(Sender: TObject);
begin
  OpenDialog1.InitialDir := ExtractFilePath(Application.ExeName);
  if OpenDialog1.Execute then
    dtLogo.Text := OpenDialog1.FileName;
end;

end.

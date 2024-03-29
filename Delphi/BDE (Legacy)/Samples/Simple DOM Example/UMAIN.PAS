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
  Dialogs, StdCtrls, L29, Registry, DB, ADODB, L29dom, cmbtll29,
  L29db
  {$If CompilerVersion >=28} // >=XE7
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
    ADOConnection1: TADOConnection;
    Label8: TLabel;
    Label9: TLabel;
    dtTitle: TEdit;
    dtLogo: TEdit;
    LL: TDBL29_;
    btnLogo: TButton;
    OpenDialog1: TOpenDialog;
    DataSource1: TDataSource;
    ADOTable1: TADOTable;
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
    procedure GetTableFields();
    function GenerateLLProject(): integer;
    procedure SelectFields();
    procedure UnSelectFields();
  public
    { Public declarations }
  end;

var
  frmMain: TfrmMain;
  lldomproj: TLlDomProjectList;

implementation

{$R *.dfm}

procedure TfrmMain.FormCreate(Sender: TObject);

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

  if not ADOConnection1.Connected then
    begin

      ADOConnection1.ConnectionString := 'Provider=Microsoft.Jet.OLEDB.4.0;' +
                                         'User ID=Admin;' +
                                         'Data Source=' + dbPath + ';' +
                                         'Mode=Share Deny None;' +
                                         'Extended Properties="";' +
                                         'Jet OLEDB:Engine Type=4;';
      ADOConnection1.Connected := true;

    end;

  ADOConnection1.GetTableNames(CmBxTables.Items, False);
  CmBxTables.ItemIndex := 0;
  GetTableFields();

  //D: Pfad zum Logo f�r das Layout
  //US: Path for the logo of the layout
  dtLogo.Text := workingPath + 'sunshine.gif';

end;

procedure TfrmMain.CmBxTablesClick(Sender: TObject);
begin
  LstBxAvFields.Clear();
  LstBxSelFields.Clear();
  GetTableFields();
end;

procedure TfrmMain.GetTableFields;
begin
  ADOConnection1.GetFieldNames(CmBxTables.Items[CmBxTables.ItemIndex], LstBxAvFields.Items);
end;

procedure TfrmMain.BtnPreviewClick(Sender: TObject);
var
  nRet: integer;
begin

  //D: Tabelle f�r das Layout festlegen
  //US: Determine table for the layout
  ADOTable1.Active := false;
  ADOTable1.TableName := CmBxTables.Items[CmBxTables.ItemIndex];
  ADOTable1.Active := true;

  //D: Eintellungen f�r die List & Label Komponente setzen
  //US: Define properties for the List & Label control
  LL.DataSource := DataSource1;
  LL.AutoDesignerFile := workingPath + 'dynamic.lst';
  LL.AutoProjectType := ptListProject;
  LL.AutoMasterMode := mmNone;
  LL.AutoShowSelectFile := No;

	//D: List & Label Projekt anhand Einstellungen erstellen
	//US: Create List & Label project based on the settings
  nRet := GenerateLLProject();
  if nRet <> 0 then
    MessageDlg(LL.LlGetErrortext(nRet), mtInformation, [mbOK], 0)
  else
    //D: Designer aufrufen
    //US: Call the designer
    LL.AutoPrint('Dynamically created project...','');
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
begin

  //D: Tabelle f�r das Layout festlegen
  //US: Determine table for the layout
  ADOTable1.Active := false;
  ADOTable1.TableName := CmBxTables.Items[CmBxTables.ItemIndex];
  ADOTable1.Active := true;

  //D: Eintellungen f�r die List & Label Komponente setzen
  //US: Define properties for the List & Label control
  LL.DataSource := DataSource1;
  LL.AutoDesignerFile := workingPath + 'dynamic.lst';
  LL.AutoProjectType := ptListProject;
  LL.AutoMasterMode := mmNone;
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

//D:  Hinweis: Beim Verwenden der List & Label DOM Klassen ist zu beachten, dass
//    die einzelnen Eigenschafts-Werte als Zeichenkette angegeben werden m�ssen.
//    Dies ist notwendig um ein H�chstma� an Flexibilit�t zu gew�hrleisten, da
//    somit auch List & Label Formeln erlaubt sind.
//US: Hint: When using List & Label DOM classes please note that the property
//    values have to be passed as strings. This is necessary to ensure a maximum
//    of flexibility - om this way, List & Label formulas can be used as property
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

      //D: Das DOM Objekt an ein List & Label Objekt binden
      //US: Bind the DOM object to a List & Label object
      lldomproj := TLlDomProjectList.Create(LL);

      //D: Ein neues Listen Projekt mit dem Namen 'dynamic.lst' erstellen
      //US: Create a new listproject called 'dynamic.lst'
      result := lldomproj.Open(workingPath + 'dynamic.lst', fmCreate, amReadWrite);
      if result <> 0 then
        exit;

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

      //D: Setzen von Eigenschaften f�r das Textobjekt
      //US: Set some properties for the text object
      llobjText.Position.Define(10000, 10000, Width-65000, 27000);

      //D: Hinzuf�gen eines Paragraphen und setzen diverser Eigenschaften
      //US: Add a paragraph to the text object and set some properties
      llobjParagraph := TLlDOMParagraph.Create(llobjText.Paragraphs);
      llobjParagraph.Contents := '"' + dtTitle.Text + '"';
      llobjParagraph.Font.Bold := 'True';

      //D: Hinzuf�gen eines Grafikobjekts
      //US: Add a drawing object
      llobjDrawing := TLlDOMObjectDrawing.Create(lldomproj.ObjectList);
      llobjDrawing.Source.Fileinfo.Filename := dtLogo.Text;
      llobjDrawing.Position.Define(Width - 50000, 10000, Width - (Width - 40000), 27000);

      //D: Hinzuf�gen eines Tabellencontainers und setzen diverser Eigenschaften
      //US: Add a table container and set some properties
      container := TLlDOMObjectReportContainer.Create(lldomproj.ObjectList);
      container.Position.Define(10000, 40000, Width - 20000, Height - 44000);

      //D: In dem Tabellencontainer eine Tabelle hinzuf�gen
      //US: Add a table into the table container
      table := TLlDOMSubItemTable.Create(container.SubItems);
      table.TableID := StringReplace(CmBxTables.Items[CmBxTables.ItemIndex], ' ', '_', [rfReplaceAll, rfIgnoreCase]);

      //D: Zebramuster f�r Tabelle definieren
      //US: Define zebra pattern for table
      table.LineOptions.Data.ZebraPattern.Style := '1';
      table.LineOptions.Data.ZebraPattern.Pattern := '1';
      table.LineOptions.Data.ZebraPattern.Color := 'RGB(225,225,225)';

      //D: Eine neue Datenzeile hinzuf�gen mit allen ausgew�hlten Feldern
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
              tableField.Contents := CmBxTables.Items[CmBxTables.ItemIndex] + '.' + LstBxSelFields.Items[i];
              tableField.Width := fieldWidth;

      end;

      //D: Projekt Liste als Datei speichern
      //US: Save projectlist to file
      lldomproj.Save(workingPath + 'dynamic.lst');


      //D: Projekt Liste schliessen
      //US: Close project list
      lldomproj.Close();

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

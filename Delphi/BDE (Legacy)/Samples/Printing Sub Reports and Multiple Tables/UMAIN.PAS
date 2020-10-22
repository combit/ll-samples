{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : uMain.pas, uMain.dfm, uDataModule.pas, uDataModule.dfm, multitab.dpr
 Module : invoice sample
 Descr. : D:  Dieses Beispiel zeigt den Umgang mit Unerberichten und mehreren Tabellen
          US: This example demonstrates printing subreports und multiple tables
======================================================================================}
unit uMain;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ADODB, DB, L26, cmbtll26, StdCtrls, Buttons, Menus, uObject, uDataModule,
  Grids, DBGrids, Registry
  {$IFDEF ver280} // XE7
  , System.UITypes
  , Generics.Collections
  {$ENDIF}
  ;

type
  TFrmMultipleTables = class(TForm)
    Label5: TLabel;
    Label4: TLabel;
    Label3: TLabel;
    DebugCheckBox: TCheckBox;
    MainMenu1: TMainMenu;
    Edit1: TMenuItem;
    Report1: TMenuItem;
    Print1: TMenuItem;
    Report2: TMenuItem;
    LL: TL26_;
    File1: TMenuItem;
    Exit1: TMenuItem;
    procedure FormCreate(Sender: TObject);
    procedure Exit1Click(Sender: TObject);
    procedure Report1Click(Sender: TObject);
    procedure Report2Click(Sender: TObject);
    procedure DebugCheckBoxClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
    workingPath: String;
    procedure PassDataStructure();
    procedure DefineCurrentRecord(Prefix: string; Table: TADOTable; AsField: boolean);
    function PrintDataView(Table: TADOTable; Level, CurrentTableNo: integer):integer;
  public
    { Public declarations }
    FMapper: TTableMap;
    FTable: TADOTable;
    IsPrinting: boolean;
  end;

var
  FrmMultipleTables: TFrmMultipleTables;

implementation

{$R *.dfm}

procedure TFrmMultipleTables.DefineCurrentRecord(Prefix: string; Table: TADOTable; AsField: boolean);
var i: integer;
    ParentPrefix, MasterField, DetailField: String;
begin
       for i:= 0 to (Table.FieldCount - 1) do
       begin
          {D:  Für den Designer werden alle Felder übergeben}
          {US: For the Designer will all fields transfered}
          if not IsPrinting then
          begin
            {D:  Felder, die über einen JOIN in der TTable-Komponente verbunden sind  }
            {US: Fields, which are joined by the ttable component}
            if ( (Prefix <> '') and (pos('@',Table.Fields[i].FieldName) <= 0) ) then
            begin
              {D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen }
              {US: Transform database field types into List & Label field types}
              if AsField then
                      LL.LlDefineFieldFromTFieldExt(Prefix+Table.Fields[i].FieldName, Table.Fields[i])
              else
                      LL.LlDefineVariableFromTFieldExt(Prefix+Table.TableName,Table.Fields[i])
            end else
            begin
              if AsField then
                      LL.LlDefineFieldFromTFieldExt(Table.TableName,Table.Fields[i] )
              else
                      LL.LlDefineVariableFromTFieldExt(Table.TableName,Table.Fields[i]);
            end;
          end
          else
          begin
            {D:  Zur Druckzeit werden nur die benötigten Felder und Variablen übergeben}
            {US: For print time only the needed fields and variables will be transfered}
            {D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen }
            {US: Transform database field types into List & Label field types}
            if ( (Prefix <> '') and (pos('@',Table.Fields[i].FieldName) <= 0) ) then
            begin
              if AsField and (LL.LlPrintIsFieldUsed(Prefix + '*') > 0) then
                               LL.LlDefineFieldFromTFieldExt(Prefix+Table.Fields[i].FieldName, Table.Fields[i])
            else if (LL.LlPrintIsFieldUsed(Prefix + '*') > 0) then
                               LL.LlDefineVariableFromTFieldExt(Prefix+Table.TableName, Table.FieldList[i]);
            end else begin
              if AsField and (LL.LlPrintIsFieldUsed(Table.TableName+'.'+Table.Fields[i].FieldName) > 0) then
                              LL.LlDefineFieldFromTFieldExt(Table.TableName,Table.Fields[i] )
              else
                      if (LL.LlPrintIsVariableUsed(Table.TableName+'.'+Table.Fields[i].FieldName) > 0) then
                              LL.LlDefineVariableFromTFieldExt(Table.TableName, Table.Fields[i]);
            end;
          end;
       end;

   {D:  Übergabe aller Felder als 1:1-Relation}
   {US: Delivery all fields as 1:1-Relation}
   if Table.MasterSource <> nil then
   begin
      FMapper.GetValue(Table.TableName, FTable, MasterField, DetailField);
      ParentPrefix:=Prefix+Table.TableName+'.'+MasterField+'@'+TADOTable(Table.MasterSource.DataSet).TableName+'.'+DetailField+':';

     if not IsPrinting then
            DefineCurrentRecord(ParentPrefix, TADOTable(Table.MasterSource.DataSet), true)
     else
            DefineCurrentRecord(ParentPrefix, TADOTable(Table.MasterSource.DataSet), true);
   end;
end;


procedure TFrmMultipleTables.FormCreate(Sender: TObject);

var i: integer;
{$IFDEF VER280} // XE7
  var MasterFieldList: TList<TField>;
  var DetailFieldList: TList<TField>;
{$ELSE}
  var MasterFieldList: TList;
  var DetailFieldList: TList;
{$ENDIF}
var registry: TRegistry;
var tmp: String;
var regKeyPath: String;

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

    tmp := registry.ReadString('LL' + IntToStr(LL.LlGetVersion(LL_VERSION_MAJOR)) + 'SampleDir');
    if (tmp[Length(tmp)] = '\') then
    begin
      workingPath := tmp + 'Delphi\';
    end
    else
      workingPath := tmp + '\Delphi\';

      registry.CloseKey();

    end;
  end;
  registry.Free();

  if (workingPath = '') then
    ShowMessage('Unable to find sample database. Make sure List & Label is installed correctly.');

  // D: Verzeichnis setzen
  // US: Set current dir
  workingPath := GetCurrentDir() + '\';

  FMapper := TTableMap.Create;

  {$IFDEF VER280} // XE7
    MasterFieldList := TList<TField>.Create;
    DetailFieldList := TList<TField>.Create;
  {$ELSE}
    MasterFieldList := TList.Create;
    DetailFieldList := TList.Create;
  {$ENDIF}

  IsPrinting := False;

  {D:  Tabellen mappen und evtl. Fehler abfangen  }
  {US: Map table and checks for errors }
  Try

  with DataModule1 do begin
    for i := 0 to (ADOConnection1.DataSetCount-1) do
     if ADOConnection1.DataSets[i] is TADOTable then
     begin
      TADOTable(ADOConnection1.DataSets[i]).GetDetailLinkFields(MasterFieldList, DetailFieldList);

      if ( (MasterFieldList.Count > 0) and (DetailFieldList.Count >0) ) then
       FMapper.AddProperty(TADOTable(ADOConnection1.DataSets[i]).TableName, (ADOConnection1.DataSets[i] as TADOTable), TField(MasterFieldList.Items[0]).FieldName, TField(DetailFieldList.Items[0]).FieldName)
      else FMapper.AddProperty(TADOTable(ADOConnection1.DataSets[i]).TableName, (ADOConnection1.DataSets[i] as TADOTable), '', '');
     end;
  end;

  Except
    On E:Exception do
      ShowMessage(Format('D:   Beispiel-Datenbank nicht gefunden.'+#13+'US: Test database not found.'+#13#13'%s:''%s''.',[E.ClassName,E.Message]));
  end;

  MasterFieldList.Free;
  DetailFieldList.Free;

end;

procedure TFrmMultipleTables.Exit1Click(Sender: TObject);
begin
 Application.Terminate;
end;

procedure TFrmMultipleTables.Report1Click(Sender: TObject);
var FileName: TString;
begin
     FileName := workingPath + 'subrep.lst';
     {D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
          gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
          sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
     {US: Optional call to file selection dialog. Ommit this call and pass the
          required file as FileName if you don't want the dialog to appear. If only
          existing files should be selectable, remove the "or"ing with LL_FILE_ALSONEW }
     if LL.LlSelectFileDlgTitle(handle, 'Choose report file', LL_PROJECT_LIST or LL_FILE_ALSONEW, FileName) <> LL_ERR_USER_ABORTED then
     begin


          {D:  Daten definieren}
          {US: Define data     }
          PassDataStructure();

          {D:  Designer mit dem Titel 'Design report' und der gewählten Datei starten }
          {US: Opens the chosen file in the designer, sets designer title to 'Design report'}
          LL.LlDefineLayout(handle, 'Design report', LL_PROJECT_LIST, FileName);

     end;

end;

procedure TFrmMultipleTables.Report2Click(Sender: TObject);
var FileName: TString;
    nRet: integer;
    TableName, SortOrder,
    FMasterField, FDetailField: string;
    TableIndex: integer;
begin
     FileName := workingPath + 'subrep.lst';
     TableIndex := 0;
     {D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
          gewünschten Dateinamen übergeben.
     {US: Optional call to file selection dialog. Ommit this call and pass the
          required file as FileName if you don't want the dialog to appear. }
     if LL.LlSelectFileDlgTitle(handle, 'Choose report file', LL_PROJECT_LIST, FileName) = LL_ERR_USER_ABORTED then
        exit;

     {D:  Daten definieren. Die hier übergebenen Daten dienen nur der Syntaxprüfung - die Inhalte
          brauchen keine Echtdaten zu enthalten
     {US: Define data. The data passed here is only used for syntax checking and doesn't need
          to contain real data  }
     PassDataStructure();

     {D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.}
     {US: Start print job. Allow all export formats as target. Meter box with cancel button.}
     nRet:=LL.LlPrintWithBoxStart(LL_PROJECT_LIST, FileName, LL_PRINT_EXPORT, LL_BOXTYPE_STDABORT,
         handle, 'Printing report...');

     {D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).}
     {US: Most frequent cause for error code: -23 (Sytax Error).}
     if nRet<>0 then
     begin
          ShowMessage('Error during LlPrintWithBoxStart');
          exit;
     end;

     {D:  Druckoptionsdialog. Aufruf ist optional, es können sonst Ausgabeziel und
          Exportdateiname über LlXSetParameter() gesetzt werden bzw. der Drucker und
          die Druckoptionen über LlSetPrinterInPrinterFile() vorgegeben werden.
     {US: Optional call to print options dialog. You may also set the print target format
          and export file name using LlXSetParameter() or set the printer and print options
          using LlSetPrinterInPrinterFile()}
     nRet:=LL.LlPrintOptionsDialog(handle, 'Choose printing options');
     if nRet=LL_ERR_USER_ABORTED then
     begin
        LL.LlPrintEnd(0);
        exit;
     end;

     {D:  Erste Seite initialisieren; auch hier kann schon durch Objekte vor der Tabelle
          ein Seitenumbruch ausgelöst werden
     {US: Initialize first page. A page wrap may occur already caused by objects which are
          printed before the table}
     while LL.LlPrint = LL_WRN_REPEAT_DATA do;

     {D:  Root-Tabelle bestimmen und solange drucken bis keine mehr vorhanden}
     {US: Determine root table and print until no one is available}
     IsPrinting := true;
     if (LL.LlPrintDbGetRootTableCount <> 0) then
     begin

         repeat
          LL.LlPrintDbGetCurrentTable(TableName, false);
          if TableName <> 'LLStaticTable' then
          begin
            FMapper.GetValue(TableName, FTable, FMasterField, FDetailField);
            FTable.Sort := '';
            LL.LlPrintDbGetCurrentTableSortOrder(SortOrder);
            FTable.Sort := SortOrder;
            inc(TableIndex);
          end;
         until (PrintDataView(FTable, 0, TableIndex) <> LL_WRN_TABLECHANGE);
         
     end;
     {D:  Druck beenden}
     {US: Stop printing}
     LL.LlPrintEnd(0);
     IsPrinting := false;
end;

procedure TFrmMultipleTables.DebugCheckBoxClick(Sender: TObject);
{D:  (De)aktiviert Debug-Ausgaben     }
{US: enables or disables debug output }
begin
     If DebugCheckBox.Checked=true
     then
     begin
          LL.DebugMode:=1;
          MessageDlg('D:  DEBWIN muss zur Anzeige von Debugausgaben gestartet werden'+#13
               +'US: Start DEBWIN to receive debug messages', mtInformation,
               [mbOK],0);
     end
     else
        LL.DebugMode:=0;
end;

procedure TFrmMultipleTables.PassDataStructure;
var
 i, j, k: integer;
 {$IFDEF VER280} // XE7
 	FList: TList<TDataSet>;
 {$ELSE}
 	FList: TList;
 {$ENDIF}
begin
     {D:  Initialisierung    }
     {US: Initialization }
     LL.LlDbAddTable('','');
     {D:  Eine statische Tabelle anmelden}
     {US: Declare a static table}
     LL.LlDbAddTable('LLStaticTable','');
     LL.LlDefineFieldStart;
     LL.LlDefineVariableStart;
     LL.LlDefineChartFieldStart;

      with DataModule1 do begin
        {D:  Zuerst alle Tabellen anmelden...}
        {US: At first declare all tables...}
        for i := 0 to (ADOConnection1.DataSetCount-1) do
        begin
          LL.LlDbAddTable( TADOTable(ADOConnection1.DataSets[i]).TableName, '' );
          {D:  ...dann die Felder der Tabellen...}
          {US: ...then the fields of the tables...}
          DefineCurrentRecord('', (ADOConnection1.DataSets[i] as TADOTable), true);
        end;

        {D:  ...dann die Relationen zwischen den Tabellen...}
        {US: ... then the relation between the tables...}
        {$IFDEF VER280} // XE7
        	FList := TList<TDataSet>.Create;
        {$ELSE}
        	FList := TList.Create;
        {$ENDIF}
        for i := 0 to (ADOConnection1.DataSetCount-1) do
        begin
          with ADOConnection1.DataSets[i] as TADOTable do
          begin
            GetDetailDataSets(FList);
            if FList.Count > 0 then
            begin
              for k := 0 to FList.Count - 1 do
              LL.LlDbAddTableRelation(TADOTable(TDataSet(FList.Items[k])).TableName,
                                      TableName,
                                      TableName + '2' + TADOTable(TDataSet(FList.Items[k])).TableName,
                                      '');
            end;
            {D:  ...und zum Schluss die Sortierung}
            {US: ...and at the end the sorting}
            for j := 0 to FieldCount-1 do
            begin
              LL.LlDbAddTableSortOrder(TableName, Fields[j].FieldName + ' ASC', Fields[j].FieldName + ' [+]');
              LL.LlDbAddTableSortOrder(TableName, Fields[j].FieldName + ' DESC', Fields[j].FieldName + ' [-]');
            end;
          end;
        end;
        FList.Free;
      end;

end;


function TFrmMultipleTables.PrintDataView(Table: TADOTable; Level, CurrentTableNo: integer): integer;
var
 i: integer;
 nRet: integer;
 TableName, SortOrder,
 FMasterField, FDetailField: string;
 Percentage, MaxPercentage: currency;
begin

    LL.LlPrintDbGetCurrentTable(TableName, false);
    if (TableName = 'LLStaticTable') then
    begin
      nRet := LL.LlPrintFields();
      while nRet = LL_WRN_REPEAT_DATA do
      begin
        LL.LlPrint();
        nRet := LL.LlPrintFields();
        while nRet = LL_WRN_REPEAT_DATA do
          nRet := LL.LlPrintFieldsEnd;
      end;
     end else
     begin

       Table.First;
       MaxPercentage := 100/LL.LlPrintDbGetRootTableCount();

       {D:  Sortierung der aktuellen Tabelle bestimmen
       US: Determine the sort order of the current table}
       LL.LlPrintDbGetCurrentTableSortOrder(SortOrder);
       if Assigned(Table) then
         Table.Sort := SortOrder;
         
       {D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
       US: Wrap pages until record was fully printed}
       for i := 0 to Table.RecordCount - 1 do
       begin

        DefineCurrentRecord('', Table, true);

        nRet := LL.LlPrintFields();
        {D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
        US: Wrap pages until record was fully printed}
        while nRet = LL_WRN_REPEAT_DATA do
        begin
          LL.LlPrint();
          nRet := LL.LlPrintFields();
        end;

        {D:  Tabellenwechsel und Rekursion beginnen
        US: Change of table begin recursion}
        while nRet = LL_WRN_TABLECHANGE do
        begin
          LL.LlPrintDbGetCurrentTable(TableName, false);
          FMapper.GetValue(TableName, FTable, FMasterField, FDetailField);
          nRet := PrintDataView(FTable, Level + 1, 0);
        end;

        {D: Aktualisierung der Fortschrittsanzeige wenn Root-Datensatz gedruckt wird
        US: If a root record is printed update the progress bar }
        if Level = 0 then
        begin
         Percentage := MaxPercentage*(CurrentTableNo-1) + i/Table.RecordCount*MaxPercentage;
         LL.LlPrintSetBoxText('Printing report...',round(Percentage));
        end;

        Table.Next;

       end;
     end;

      nRet := LL.LlPrintFieldsEnd();
      {D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
      US: Wrap pages until record was fully printed}
      while nRet = LL_WRN_REPEAT_DATA do
        nRet := LL.LlPrintFieldsEnd();

      if TableName <> 'LLStaticTable' then
        Table.Sort := '';
      Result := nRet;

end;

procedure TFrmMultipleTables.FormClose(Sender: TObject;
  var Action: TCloseAction);
begin
  FMapper.Free;
end;

end.

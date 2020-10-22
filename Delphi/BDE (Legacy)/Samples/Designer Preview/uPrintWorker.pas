unit uPrintWorker;

interface

uses
  Classes, SysUtils, Windows, cmbtls26, cmbtll26, L26, ADODB, DB;

type
  TPrintWorker = class(TThread)
  private
    procedure DesignerPrintPreview();
    procedure DefineCurrentRecord();
    function GetTempFile(): string;
  protected
    procedure Execute; override;
    procedure UpdateCaption();
  public
    printInstance: TL26_;

    projectFile: string;
    originalProjectFile: string;
    controlHandle: Cardinal;
    eventHandle: Cardinal;
    pageCount: integer;
    doExport: boolean;

    FCount: integer;
    Terminated: boolean;

    IsPrinting: boolean;

    procedure FinalizePrinting();
    procedure ReleasePreviewControl(alsoEmptyPreviewControl: integer);
    procedure Abort();
  end;

implementation

uses
 uDesignerPreview;

{ PrintWorker }

{D:  Diese Prozedure übergibt den aktuellen Datensatz an List & Label.  }
{    Hier können Sie ansetzen, um ganz andere Datenquellen zu verwenden }
{US: This procedure passes the current record to List & Label. Customize}
{    it in order to pass completely different data                      }
procedure TPrintWorker.Abort;
begin
  {D:  Druck der Tabelle beenden, angehängte Objekte drucken
   US: Finish printing the table, print linked objects}
  while printInstance.LlPrintFieldsEnd = LL_WRN_REPEAT_DATA do;
  {D:  Druck beenden}
  {US: Stop printing}
  printInstance.LlPrintEnd(0);

  Terminated := True;
end;

procedure TPrintWorker.DefineCurrentRecord();
var
  i: integer;
begin
     {D:  Wiederholung für alle Datensatzfelder           }
     {US: Loop through all fields in the present recordset}
     For i:= 0 to (frmDesignerPreview.Customers.FieldCount-1) do
       {D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen }
       {US: Transform database field types into List & Label field types}
       printInstance.LlDefineFieldFromTField(frmDesignerPreview.Customers.Fields[i]);
end;

procedure TPrintWorker.DesignerPrintPreview;
var
  Ret: integer;
  tempFileName: string;
  printPages: integer;
begin
  // D:  Aktualisierung der Echtdatenvorschau Toolbar:
  // US: Update the real data preview toolbar:
  PostMessage(controlHandle, LS_VIEWERCONTROL_UPDATE_TOOLBAR, 0, 0);

  // D: Temporäres List & Label Projekt für den Druck übergeben:
  // US: Set temp List & Label project file for printing:
  tempFileName := GetTempFile();
  printInstance.LlSetOptionString(LL_OPTIONSTR_PREVIEWFILENAME, ExtractFileName(tempFileName));
  printInstance.LlPreviewSetTempPath(ExtractFilePath(tempFileName));
  printInstance.IncrementalPreview := 1;
  printInstance.NoNoTableCheck := Yes;

  SetEvent(eventHandle);

  printInstance.LlSetOptionString(LL_OPTIONSTR_ORIGINALPROJECTFILENAME, originalProjectFile);
  if not doExport then
  begin
    // D:  Aufruf, damit das Vorschau-Control die Kontrolle über die Vorschaudatei erhält:
    // US: Set the preview control as master for the preview file:
    printInstance.LlAssociatePreviewControl(controlHandle, 1);
  end;

  frmDesignerPreview.Customers.First();
  DefineCurrentRecord();

  try
    if not doExport then
    begin
      printInstance.LlPrintWithBoxStart(LL_PROJECT_LIST, projectFile, LL_PRINT_PREVIEW, LL_BOXTYPE_STDABORT, controlHandle, '');
      if pageCount > 0 then
        // D:  Maximalzahl der auzugebenen Vorschauseiten:
        // US: Set the page count for the preview:
        printInstance.LlPrintSetOption(LL_OPTION_LASTPAGE, pageCount);
    end else
    begin
      // D:  Fortschrittsanzeige während des Exports anzeigen:
      // US: Show the status box during the export:
      printInstance.LlPrintWithBoxStart(LL_PROJECT_LIST, projectFile, LL_PRINT_EXPORT, LL_BOXTYPE_STDABORT, controlHandle, 'Exporting report...');
      if printInstance.LlPrintOptionsDialog(controlHandle, '')=LL_ERR_USER_ABORTED then
      begin
        printInstance.LlPrintEnd(0);
        exit;
      end;
    end;

    printPages := 1;
    //D: Erste Seite des Drucks initalisieren, um sicherzustellen, dass ein Seitenumbruch vor der Tabelle erfolgt
    //US: Initialize first page. A page wrap may occur already caused by objects which are printed before the table
     while printInstance.LlPrint = LL_WRN_REPEAT_DATA do
     begin
       inc(printPages);
     end;

     IsPrinting := true;
     while not frmDesignerPreview.Customers.EOF do
     begin
          {D:  Jetzt Echtdaten für aktuellen Datensatz übergeben}
          {US: pass data for current record}
          DefineCurrentRecord();

          {D:  Tabellenzeile ausgeben, auf Rückgabewert prüfen und ggf. Seitenumbruch
               oder Abbruch auslösen
          {US: Print table line, check return value and abort printing or wrap pages
               if neccessary}
          Ret:=printInstance.LlPrintFields;
          if Ret = LL_ERR_USER_ABORTED then
          begin
               {D:  Benutzerabbruch}
               {US: User aborted}
               printInstance.LlPrintEnd(0);
               exit;
          end;
          {D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
           US: Wrap pages until record was fully printed}
          while Ret = LL_WRN_REPEAT_DATA do
          begin
            printInstance.LlPrint();
            inc(printPages);
            Ret := printInstance.LlPrintFields;
          end;

          if (printPages > pageCount) and (pageCount <> 0) then
          begin
            // D:  Maximale Seitenanzahl erreicht, Druckvorgang abbrechen:
            // US: Maximum page count reached, abort print job:
            printInstance.LlPrintAbort;

            {D:  Druck beenden}
            {US: Stop printing}
            printInstance.LlPrintEnd(0);

            exit;
          end;


          {D:  Fortschrittsanzeige aktualisieren}
          {US: Refresh progress meter}
          printInstance.LlPrintSetBoxText('Printing report...',Round(frmDesignerPreview.Customers.RecNo/frmDesignerPreview.Customers.RecordCount*100));
          frmDesignerPreview.Customers.Next;
     end;

     {D:  Druck der Tabelle beenden, angehängte Objekte drucken
      US: Finish printing the table, print linked objects}
     while printInstance.LlPrintFieldsEnd = LL_WRN_REPEAT_DATA do;

     {D:  Druck beenden}
     {US: Stop printing}
     printInstance.LlPrintEnd(0);
  finally
    DeleteFile(PChar(projectFile));
    printInstance.LlAssociatePreviewControl(0,1);
    Terminated := true;
  end;
end;

procedure TPrintWorker.Execute;
begin
  IsPrinting := false;
  Synchronize( DesignerPrintPreview );
end;

procedure TPrintWorker.FinalizePrinting();
begin
  Abort();
  ReleasePreviewControl(0);
end;

function TPrintWorker.GetTempFile: string;
var
  Buffer: PXChar;
begin
    GetMem(Buffer, (MAX_PATH+1)*sizeof(XChar));
    LlGetTempFileName('~', 'll', Buffer, MAX_PATH+1, 0);
    result:=String(Buffer);
    FreeMem(Buffer);
end;




procedure TPrintWorker.ReleasePreviewControl(alsoEmptyPreviewControl: integer);
begin
  printInstance.LlAssociatePreviewControl(controlHandle, alsoEmptyPreviewControl)
end;

procedure TPrintWorker.UpdateCaption();
begin
//  frmDesignerPreview.Memo1.Lines.Add('Updated in a thread: ' + myMessage);
end;

end.

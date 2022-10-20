unit uDesignerPreview;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs, DB,
  Registry, DBTables, ADODB, L28, StdCtrls, cmbtll28, L28db, uPrintWorker,
  ComCtrls, SyncObjs;

type
  TfrmDesignerPreview = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    dsCustomers: TDataSource;
    Customers: TADOTable;
    ADOConnection1: TADOConnection;
    LLDesign: TL28_;
    LLDesignerPrint: TL28_;
    DesignIL: TButton;
    procedure DesignILClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure LLDesignDesignerPrintJob(Sender: TObject; UserParam: Integer;
      ProjectFileName, OriginalFileName, ExportFormat: string;
      WithoutDialog: Boolean; Pages, Task, hWndPreviewControl: Cardinal;
      Event: NativeUInt; var returnValue: Integer);
  private
    workingPath: String;
    procedure DefineCurrentRecord();
  end;

var
  frmDesignerPreview: TfrmDesignerPreview;
  workerThread: TPrintWorker;
  critSect: TCriticalSection;

implementation

{$R *.DFM}

procedure TfrmDesignerPreview.DefineCurrentRecord;
var
  i: integer;
begin
  for i := 0 to Customers.FieldCount - 1 do
    LLDesign.LlDefineFieldFromTField(Customers.Fields[i]);
end;

procedure TfrmDesignerPreview.DesignILClick(Sender: TObject);
begin
	// D: Daten für das Designer Layout anmelden:
  // US: Set the preview data:
  DefineCurrentRecord();

	// D: Einschalten der Funktionen für den Druck / Export im Designer:
	// US: Set the option for the real data preview / export:
  LLDesign.LlSetOption(LL_OPTION_DESIGNERPREVIEWPARAMETER, 1);
  LLDesign.LlSetOption(LL_OPTION_DESIGNEREXPORTPARAMETER, 1);
  LLDesign.LlSetOption(LL_OPTION_DESIGNERPRINT_SINGLETHREADED, 1);

	//D: Designer aufrufen
	//US: call the designer
  LLDesign.LlDefineLayout(self.Handle, 'LL Designer Preview', LL_PROJECT_LIST, workingPath + 'simple.lst');
end;

procedure TfrmDesignerPreview.FormClose(Sender: TObject;
  var Action: TCloseAction);
begin
  critSect.Free;
end;

procedure TfrmDesignerPreview.FormCreate(Sender: TObject);

var registry: TRegistry;
var regKeyPath: String;
var dbPath: String;
var tmp: String;

begin

  critSect := TCriticalSection.Create;

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
	  
	  tmp := registry.ReadString('LL' + IntToStr(LLDesign.LlGetVersion(LL_VERSION_MAJOR)) + 'SampleDir');
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
  workingPath :=GetCurrentDir() + '\';

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

    end;
end;




procedure TfrmDesignerPreview.LLDesignDesignerPrintJob(Sender: TObject;
  UserParam: Integer; ProjectFileName, OriginalFileName, ExportFormat: string;
  WithoutDialog: Boolean; Pages, Task, hWndPreviewControl: Cardinal;
  Event: NativeUInt; var returnValue: Integer);
begin
    case Task of
    LL_DESIGNERPRINTCALLBACK_PREVIEW_START,
    LL_DESIGNERPRINTCALLBACK_EXPORT_START:
    begin
      with critSect do
      try
        Enter;

        // might be assigned from previous print
        if Assigned(workerThread) then
        begin
          workerThread.Free;
        end;

        workerThread := TPrintWorker.Create(true);
        with workerThread do
        begin
          printInstance := LLDesignerPrint;
          FreeOnTerminate := false;

            // D: Setzen der Event Parameter:
            // US: Set event parameter:
            projectFile := ProjectFileName;
            originalProjectFile := OriginalFileName;
            exportFormat := ExportFormat;
            controlHandle := hWndPreviewControl;
            eventHandle := Event;

            // D:  Im Export Fall die doExport Variable auf true setzen:
            // US: Set the doExport variable true for the export:
            if Task = LL_DESIGNERPRINTCALLBACK_EXPORT_START then
                doExport := true
            else
                doExport := false;

            // D:  Maximale Seitenanzahl für den Preview / Druck:
            // US: page count for the real data preview / print:
            pageCount := Pages;
{$ifdef USETHREADRESUME}
          Resume();
{$else}
          Start();
{$endif}
        end;
      finally
        Leave;
      end;
      exit;
    end;
    LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT,
    LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT:
    begin
      with critSect do
      try
        Acquire;
        if Assigned(workerThread) and not workerThread.Terminated then
          workerThread.Abort();

      finally
        Release;
      end;
      exit;
    end;
    LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE,
    LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE:
    begin
      with critSect do
      try
        Acquire;
        if Assigned(workerThread) then
          begin
            if not workerThread.Terminated then
              begin
                workerThread.FinalizePrinting();
                workerThread.WaitFor;
              end;
              workerThread.Free;
              workerThread:=nil;
          end;
      finally
        Release
      end;
      exit;
    end;
    LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE,
    LL_DESIGNERPRINTCALLBACK_EXPORT_QUEST_JOBSTATE:
    begin
      with critSect do
        try
          Acquire;
          if not Assigned(workerThread) then
            returnValue := 0;

          if Assigned(workerThread) then
          begin
            if (workerThread.Terminated) then
              returnValue := 0
            else
              returnValue := 2;
          end;
          finally
            Release;
          end;
          exit;
    end;
  end;

end;

end.

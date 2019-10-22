{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : uc_fm.pas
 Module : custom unicode sample
 Descr. : D:  Dieses Beispiel demonstriert den Druck über eine eigene Druckschleife
              unter Berücksichtigung internationaler Codepages.
          US: This example demonstrates the printout using a custom print loop
              in consideration of international codepages.
======================================================================================}


unit UC_FM;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, Menus, L25, cmbtll25, ADODB, DB, Registry
  {$IFDEF ver280} // XE7
  , System.UITypes
  {$ENDIF}
  ;

type
  TForm1 = class(TForm)
    MainMenu1: TMainMenu;
    File1: TMenuItem;
    Exit1: TMenuItem;
    Edit1: TMenuItem;
    Label1: TMenuItem;
    Report1: TMenuItem;
    Print1: TMenuItem;
    Label2: TMenuItem;
    Report2: TMenuItem;
    DebugCheckBox: TCheckBox;
    Label6: TLabel;
    Label5: TLabel;
    Label4: TLabel;
    Label3: TLabel;
    DataSource: TADOTable;
    LL: TL25_;
    procedure Exit1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure DefineCurrentRecord(AsField: boolean);
    procedure Label1Click(Sender: TObject);
    procedure Report1Click(Sender: TObject);
    procedure Label2Click(Sender: TObject);
    procedure Report2Click(Sender: TObject);
    procedure DebugCheckBoxClick(Sender: TObject);
  private
  workingPath: String;
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.FormCreate(Sender: TObject);

var registry: TRegistry;
var regKeyPath: String;
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

  // D: Verzeichnis setzen
  // US: Set current dir
  workingPath := GetCurrentDir() + '\';

  {D:  Lade die Datenbank, fange Fehler ab  }
  {US: Load the database, checks for errors }
  Try
         DataSource.Active := false;
         DataSource.ConnectionString := 'Provider=Microsoft.Jet.OLEDB.4.0;'+
                                        'Data Source=' + workingPath + 'Address.mdb;' +
                                        'Persist Security Info=False';
         DataSource.TableName := 'Persons';
         DataSource.Active := true;
  Except On E:Exception do
    ShowMessage(Format('D:   Beispiel-Datenbank nicht gefunden.'+#13+'US: Test database not found.'+#13#13'%s:''%s''.',[E.ClassName,E.Message]));
  end;

  {D:  Setzen der Codepage. Die Codepage muss auf dem System installiert sein. Hier japanische Codepage }
  {US: Setting of the codepage. The codepage must be installed on your system. In this case it is the Japanese codepage }
  LL.LlSetOption(LL_OPTION_CODEPAGE,932);

end;

procedure TForm1.DefineCurrentRecord(AsField: boolean);
var
    i:               integer;
begin
     {D:  Diese Prozedur übergibt den aktuellen Datensatz an List & Label.  }
     {    Hier können Sie ansetzen, um ganz andere Datenquellen zu verwenden }
     {US: This procedure passes the current record to List & Label. Customize}
     {    it in order to pass completely different data                      }

     {D:  Wiederholung für alle Datensatzfelder           }
     {US: Loop through all fields in the present recordset}
     For i:= 0 to (DataSource.FieldCount-1) do
     begin

          {D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen }
          {US: Transform database field types into List & Label field types}
          if AsField then
                    LL.LlDefineFieldFromTField(DataSource.Fields[i])
          else
                    LL.LlDefineVariableFromTField(DataSource.Fields[i]);
     end;
end;


procedure TForm1.Exit1Click(Sender: TObject);
begin
     Close;
end;

procedure TForm1.Label1Click(Sender: TObject);
var FileName: TString;
begin
     FileName := workingPath + 'simple.lbl';
     DataSource.First;

     {D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
          gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
          sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
     {US: Optional call to file selection dialog. Ommit this call and pass the
          required file as FileName if you don't want the dialog to appear. If only
          existing files should be selectable, remove the "or"ing with LL_FILE_ALSONEW }
     if LL.LlSelectFileDlgTitle(handle, 'Choose label file', LL_PROJECT_LABEL or LL_FILE_ALSONEW, FileName) <> LL_ERR_USER_ABORTED then
     begin
          {D:  Daten definieren}
          {US: Define data     }
          DefineCurrentRecord(False);

          {D:  Designer mit dem Titel 'Design label' und der gewählten Datei starten }
          {US: Opens the chosen file in the designer, sets designer title to 'Design label'}
          LL.LlDefineLayout(handle, 'Design label', LL_PROJECT_LABEL, FileName);
     end;
end;

procedure TForm1.Report1Click(Sender: TObject);
var FileName: TString;
begin
     FileName := workingPath + 'simple.lst';
     DataSource.First;
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
          DefineCurrentRecord(True);

          {D:  Designer mit dem Titel 'Design report' und der gewählten Datei starten }
          {US: Opens the chosen file in the designer, sets designer title to 'Design report'}
          LL.LlDefineLayout(handle, 'Design report', LL_PROJECT_LIST, FileName);
     end;
end;

procedure TForm1.Label2Click(Sender: TObject);
var FileName: TString;
    Ret: integer;
begin
     FileName := workingPath + 'simple.lbl';
     DataSource.First;
     {D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
          gewünschten Dateinamen übergeben.
     {US: Optional call to file selection dialog. Ommit this call and pass the
          required file as FileName if you don't want the dialog to appear.}
     if LL.LlSelectFileDlgTitle(handle, 'Choose label file', LL_PROJECT_LABEL, FileName) = LL_ERR_USER_ABORTED then
        exit;

     {D:  Daten definieren. Die hier übergebenen Daten dienen nur der Syntaxprüfung - die Inhalte
          brauchen keine Echtdaten zu enthalten
     {US: Define data. The data passed here is only used for syntax checking and doesn't need
          to contain real data  }
     DefineCurrentRecord(False);

     {D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.}
     {US: Start print job. Allow all export formats as target. Meter box with cancel button.}
     Ret:=LL.LlPrintWithBoxStart(LL_PROJECT_LABEL, FileName, LL_PRINT_EXPORT, LL_BOXTYPE_NORMALMETER,
         handle, 'Printing label...');

     {D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).}
     {US: Most frequent cause for error code: -23 (Sytax Error).}
     if Ret<>0 then
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
     Ret:=LL.LlPrintOptionsDialog(handle, 'Choose printing options');
     if Ret=LL_ERR_USER_ABORTED then
		 begin
			LL.LlPrintEnd(0);
			exit;
		 end;

     {D:  Eigentliche Druckschleife; Wiederholung, solange Daten vorhanden}
     {US: Print loop. Repeat while there is still data to print}
     while not DataSource.EOF do
		 begin
			  {D:  Jetzt Echtdaten für aktuellen Datensatz übergeben}
			  {US: pass data for current record}
			  DefineCurrentRecord(False);

			  {D:  Ein Etikett ausdrucken}
			  {US: Print one label}
			  Ret:=LL.LlPrint;
			while Ret = LL_WRN_REPEAT_DATA do
				begin
					Ret:= LL.LlPrint;
				end;
				
			if Ret = LL_ERR_USER_ABORTED then
				begin
					LL.LlPrintEnd(0);
				   exit;
				end;

			  {D:  Fortschrittsanzeige aktualisieren}
			  {US: Refresh progress meter}
			  LL.LlPrintSetBoxText('Printing label...',Round(DataSource.RecNo/DataSource.RecordCount*100));

			  {D:  Zum nächsten Datensatz wechseln}
			  {US: Skip to next record}
			  DataSource.Next;
		 end;

     {D:  Druck beenden}
     {US: Stop printing}
     LL.LlPrintEnd(0);
end;

procedure TForm1.Report2Click(Sender: TObject);
var FileName: TString;
    Ret: integer;
begin
     FileName := workingPath + 'simple.lst';
     DataSource.First;
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
     DefineCurrentRecord(True);

     {D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.}
     {US: Start print job. Allow all export formats as target. Meter box with cancel button.}
     Ret:=LL.LlPrintWithBoxStart(LL_PROJECT_LIST, FileName, LL_PRINT_EXPORT, LL_BOXTYPE_NORMALMETER,
         handle, 'Printing report...');

     {D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).}
     {US: Most frequent cause for error code: -23 (Sytax Error).}
     if Ret<>0 then
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
     Ret:=LL.LlPrintOptionsDialog(handle, 'Choose printing options');
     if Ret=LL_ERR_USER_ABORTED then
     begin
        LL.LlPrintEnd(0);
        exit;
     end;

     {D:  Erste Seite initialisieren; auch hier kann schon durch Objekte vor der Tabelle
          ein Seitenumbruch ausgelöst werden
     {US: Initialize first page. A page wrap may occur already caused by objects which are
          printed before the table}
     while LL.LlPrint = LL_WRN_REPEAT_DATA do;

     {D:  Eigentliche Druckschleife; Wiederholung, solange Daten vorhanden}
     {US: Print loop. Repeat while there is still data to print}
     while not DataSource.EOF do
     begin
          {D:  Jetzt Echtdaten für aktuellen Datensatz übergeben}
          {US: pass data for current record}
          DefineCurrentRecord(TRUE);

          {D:  Tabellenzeile ausgeben, auf Rückgabewert prüfen und ggf. Seitenumbruch
               oder Abbruch auslösen
          {US: Print table line, check return value and abort printing or wrap pages
               if neccessary}
          Ret:=LL.LlPrintFields;
          if Ret = LL_ERR_USER_ABORTED then
          begin
               {D:  Benutzerabbruch}
               {US: User aborted}
               LL.LlPrintEnd(0);
               exit;
          end;
          {D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
           US: Wrap pages until record was fully printed}
          while Ret = LL_WRN_REPEAT_DATA do
          begin
               LL.LlPrint;
               Ret:=LL.LlPrintFields;
          end;

          {D:  Fortschrittsanzeige aktualisieren}
          {US: Refresh progress meter}
          LL.LlPrintSetBoxText('Printing report...',Round(DataSource.RecNo/DataSource.RecordCount*100));
          DataSource.Next;
     end;

     {D:  Druck der Tabelle beenden, angehängte Objekte drucken
      US: Finish printing the table, print linked objects}
     while LL.LlPrintFieldsEnd = LL_WRN_REPEAT_DATA do;

     {D:  Druck beenden}
     {US: Stop printing}
     LL.LlPrintEnd(0);
end;

procedure TForm1.DebugCheckBoxClick(Sender: TObject);
{D:  (De)aktiviert Debug-Ausgaben     }
{US: enables or disables debug output }
begin
     If DebugCheckBox.checked=true
     then
     begin
          LL.DebugMode:=1;
          MessageDlg('D:  DEBWIN muss zur Anzeige von Debugausgaben gestartet werden'+#13
               +'US: Start DEBWIN to receive debug messages', mtInformation,
               [mbOK],0);
     end
     else LL.DebugMode:=0;
end;

end.

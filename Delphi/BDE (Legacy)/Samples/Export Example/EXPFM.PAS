{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : expfm.pas
 Module : export sample
 Descr. : D:  Dieses Beispiel demonstriert den Export ohne Benutzerinteraktion.
          US: This example demonstrates a quiet export.
======================================================================================}

unit expfm;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, L30, DB, DBTables,cmbtll30, Registry, ADODB
  {$If CompilerVersion >=28} // >=XE7
  , System.UITypes
  {$ENDIF}
  ;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    LL: TL30_;
    Label2: TLabel;
    FormatCombo: TComboBox;
    Label3: TLabel;
    Label4: TLabel;
    Edit1: TEdit;
    FileSelectBtn: TButton;
    SaveDialog1: TSaveDialog;
    GoBtn: TButton;
    CheckShowFile: TCheckBox;
    ADOConnection1: TADOConnection;
    ADOTableArticle: TADOTable;
    procedure FormCreate(Sender: TObject);
    procedure LLDefineFields(Sender: TObject; UserData: Integer;
      IsDesignMode: Boolean; var Percentage: Integer;
      var IsLastRecord: Boolean; var EventResult: Integer);
    procedure FormatComboChange(Sender: TObject);
    procedure FileSelectBtnClick(Sender: TObject);
    procedure GoBtnClick(Sender: TObject);
    procedure LLSetPrintOptions(Sender: TObject;
      var PrintMethodOptionFlags: Integer);
  private
    { Private declarations }
    FileFilter:      String;
    FileName:        String;
    ExporterName:    String;
    CurPath:         String;
  public
    { Public declarations }

  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.FormCreate(Sender: TObject);

var errorOccurred: Boolean;
var registry: TRegistry;
var regKeyPath: String;
var errorText: String;
var DataFileName: String;
var DataFilePath: String;

begin

    {D:  Bestimme den Dateinamen der Beispiel-Datenbank}
    {US: Set the filename for the test database        }
    errorOccurred := true;
    registry := TRegistry.Create();
    registry.RootKey := HKEY_CURRENT_USER;
    regKeyPath := 'Software\combit\cmbtll\';
    if registry.KeyExists(regKeyPath) then
    begin

      if registry.OpenKeyReadOnly(regKeyPath) then
      begin

	    DataFilePath := registry.ReadString('LL' + IntToStr(LL.LlGetVersion(LL_VERSION_MAJOR)) + 'SampleDir');
		  if (DataFilePath[Length(DataFilePath)] = '\') then
		    begin
		  	  DataFileName:='samples.mdb';
		    end
		  else
			  DataFileName:='\samples.mdb';
        registry.CloseKey();

        if FileExists(DataFilePath + DataFileName) then
          begin

            {D:  Lade die Datenbank, fange Fehler ab  }
            {US: Load the database, checks for errors }
            Try
              begin
                   ADOConnection1.ConnectionString :='Provider=Microsoft.Jet.OLEDB.4.0;Data Source= ' + DataFilePath + DataFileName +';' ;
                   ADOConnection1.Connected :=true;
                   ADOConnection1.LoginPrompt :=false;
                   ADOTableArticle.active := false;
                   ADOTableArticle.TableName :='article';
                   ADOTableArticle.active := true;

                   {D:  Setze Dateipfad für LL Projektdateien }
                   {US: Set path fo LL project files}
                   CurPath :=  GetCurrentDir()+'\';
                   errorOccurred := false;
              end
            Except On EDBEngineError Do
              //
            End;
          end;
      end;
    end;
    registry.Free();

    if errorOccurred then
    begin

      errorText := 'D:  Beispiel-Datenbank nicht gefunden' + #13 + 'US: Test database not found';
      MessageDlg(errorText, mtError, [mbOK], 0);

    end;

     FormatCombo.ItemIndex:=0;
     FormatComboChange(self);
end;

procedure TForm1.LLDefineFields(Sender: TObject; UserData: Integer;
  IsDesignMode: Boolean; var Percentage: Integer;
  var IsLastRecord: Boolean; var EventResult: Integer);
{D:  Dieser Event wird von den List & Label - Befehlen design und print
     ausgelöst. Er wird für jeden Datensatz aufgerufen, um die Felder
     und deren Inhalt an List & Label zu übergeben.
 US: This event is called by the List & Label methods design and print.
     It gets called once per record to define the fields and their
     contents.}


var
    i:               integer;

begin

     {D:  Wiederholung für alle Datensatzfelder           }
     {US: Loop through all fields in the present recordset}
     For i:= 0 to (ADOTableArticle.FieldCount-1) do
     begin

          {D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen }
          {US: Transform database field types into List & Label field types}
	  LL.LlDefineFieldFromTField(ADOTableArticle.Fields[i]);
     end;

     {D:  Werden Echt-Daten benötigt (nicht bei Designer-Aufruf)       }
     {US: Is real data needed (not when method design has been called) }
     if not IsDesignMode then
     begin

          {D:  Prozentanzeige aktualisieren und zu nächsten Datensatz wechseln }
          {US: Set percentage value for meter info and move to next record     }
          Percentage:=Round(ADOTableArticle.RecNo/ADOTableArticle.RecordCount*100);
          ADOTableArticle.Next;

          {D:  Druck beenden, wenn kein weiterer Datensatz vorhanden ist}
          {US: End printing if last record is reached                   }
          if ADOTableArticle.EOF=True then IsLastRecord:=true;
     end;

end;

procedure TForm1.FormatComboChange(Sender: TObject);
begin
     {D:  Default-Dateinamen, Filter und Exporternamen setzen}
     {US: Set default file name, path and exporter name}
     case FormatCombo.ItemIndex of
     0: begin
          FileFilter := 'Adobe PDF Format|*.pdf';
          FileName := 'export.pdf';
          ExporterName := 'PDF';
        end;
     1: begin
          FileFilter := 'Multi-Mime HTML Format|*.mht';
          FileName := 'export.mht';
          ExporterName := 'MHTML';
        end;
     2: begin
          FileFilter := 'Rich Text Format (RTF)*.rtf';
          FileName := 'export.rtf';
          ExporterName := 'RTF';
        end;
     3: begin
          FileFilter := 'XML Format|*.xml';
          FileName := 'export.xml';
          ExporterName := 'XML';
        end;
     4: begin
          FileFilter := 'TIFF Picture|*.tif';
          FileName := 'export.tif';
          ExporterName := 'PICTURE_MULTITIFF';
        end;
     5: begin
          FileFilter := 'Text Format|*.txt';
          FileName := 'export.txt';
          ExporterName := 'TXT';
        end;
     6: begin
          FileFilter := 'Microsoft Excel Format|*.xls';
          FileName := 'export.xls';
          ExporterName := 'XLS';
        end;
     7: begin
          FileFilter := 'List & Label Preview Format|*.ll';
          FileName := 'export.ll';
          ExporterName := 'PRV';
        end;
     end;
     FileName:=CurPath + FileName;
     Edit1.Text := FileName;
end;

procedure TForm1.FileSelectBtnClick(Sender: TObject);
begin
     {D:  Dateiauswahl für Exportdatei}
     {US: Choose file name for export file}
     with SaveDialog1 do
     begin
          InitialDir := ExtractFilePath(self.FileName);
          FileName := ExtractFileName(self.FileName);
          Filter := FileFilter;
          if Execute then
          begin
             self.FileName := FileName;
             Edit1.Text := FileName;
          end;
     end;
end;

procedure TForm1.GoBtnClick(Sender: TObject);
begin
     {D:  Druck starten. Die Exporteroptionen werden in LLSetPrintOptions übergeben.
          Wichtig: hier keinen Dateiauswahl- und keinen Druckoptionsdialog anzeigen}
     {US: Start printing. The exporter options are passed in LLSetPrintOptions.
          Important: no file selection dialog and no print options dialog is displayed.}

     ADOTableArticle.First;

     LL.Print(0,LL_PROJECT_LIST,CurPath + 'simple.lst',false,LL_PRINT_EXPORT,
     LL_BOXTYPE_STDWAIT,handle,'Print list...', false,
     '');
end;

procedure TForm1.LLSetPrintOptions(Sender: TObject;
  var PrintMethodOptionFlags: Integer);
begin
     {D:  Exportoptionen setzen}
     {US: Set export options}

     {D:  Exportformat festlegen}
     {US: Set export format}
     LL.LlPrintSetOptionString(LL_PRNOPTSTR_EXPORT, ExporterName);

     {D:  Pfad}
     {US: Path}
     LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.Path', ExtractFilePath(FileName)+'\');

     {D:  Dateiname}
     {US: Filename}
     LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.File', ExtractFileName(FileName));

     {D:  Modus ohne Interaktion}
     {US: Quiet mode}
     LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.Quiet', '1');

     {D:  Je nach Benutzerauswahl: Anzeige des Ergebnisses}
     {US: Depending on user's choice: show result}
     if CheckShowFile.Checked then
        LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.ShowResult', '1')
     else
        LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.ShowResult', '0')


     {D: Um jetzt noch zusätzlich das Exportergebnis per Mail zu versenden, würden die unten
          stehenden Codezeilen benötigt. Damit wird eine Mail an llmailtest@combit.net gesendet.
          Als Exportformat ist in diesem Beispiel HTML notwendig, so dass das Ergebnis des HTML-
          Exportes direkt als HTML Body der Mail versendet würde. Ausserdem muß über die 
          Export.Mail.SMTP...-Optionen ein gültiger SMTP-Server angegeben werden.
      US: To additonally send the result as eMail, you'd need the following code lines. This
          will send an email to llmailtest@combit.net. Set the export format to HTML, as this sample
          will send the result as HTML body of the mail. You need to set a valid SMTP server
          using the Export.Mail.SMTP... options..}
(*
     LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.SendAsMail', '1');
     LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.Mail.To', 'combit GmbH <SMTP:llmailtest@combit.net>');
     LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.Mail.Subject', 'combit List & Label mail test');
     LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.Mail.ShowDialog', '1');
     LL.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, 'Export.Mail.SendResultAs', 'text/html');
*)

end;

end.

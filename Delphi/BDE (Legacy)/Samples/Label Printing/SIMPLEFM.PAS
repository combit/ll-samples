{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : simplefm.pas, simplefm.dfm, simple.dpr
 Module : simple label sample
 Descr. : D:  Dieses Beispiel demonstriert das Designen und Drucken von Etiketten.
          US: This example demonstrates how to design and print labels.
======================================================================================}

unit simplefm;

interface

uses
  Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  Windows, Registry, DB, DBTables, L28, cmbtll28, StdCtrls,  L28db,
  Data.Win.ADODB
  {$If CompilerVersion >=28} // >=XE7
  , System.UITypes
  {$ENDIF}
  ;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    DesignButton: TButton;
    PreviewButton: TButton;
    PrintButton: TButton;
    DebugCheckBox: TCheckBox;

    LL: TDBL28_;
    ADOConnection1: TADOConnection;
    ADOTableArticle: TADOTable;
    dsProducts: TDataSource;
    procedure FormCreate(Sender: TObject);
    procedure PreviewButtonClick(Sender: TObject);
    procedure PrintButtonClick(Sender: TObject);
    procedure DebugCheckBoxClick(Sender: TObject);
    procedure DesignButtonClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    CurPath, DataFilePath, DataFileName: string;
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.FormCreate(Sender: TObject);

var regKeyPath: String;
var errorText: String;
var registry: TRegistry;
var errorOccurred: Boolean;


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
                      CurPath := GetCurrentDir()+ '\';

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
end;

procedure TForm1.PreviewButtonClick(Sender: TObject);
begin
     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;

     {D:  Projekt als Vorschau ausdrucken}
     {US: Print project to preview}
     LL.DataSource := dsProducts;
     LL.AutoDesignerFile := CurPath + 'simple.lbl';
     LL.AutoShowSelectFile := No;
     LL.AutoDestination := adPreview;
     LL.AutoPrint('Print labels to preview','');
end;

procedure TForm1.PrintButtonClick(Sender: TObject);
begin
     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;

     {D:  Projekt auf Drucker/Export ausdrucken }
     {US: Print project to printer/export      }
     LL.DataSource := dsProducts;
     LL.AutoDesignerFile := CurPath + 'simple.lbl';
     LL.AutoShowSelectFile := No;
     LL.AutoDestination := adPrinter;
     LL.AutoPrint('Print labels to printer','');
end;

procedure TForm1.DebugCheckBoxClick(Sender: TObject);
{D:  (De)aktiviert Debug-Ausgaben     }
{US: enables or disables debug output }
begin
     If DebugCheckBox.checked=true
     then
     begin
          LL.DebugMode:=1;
          MessageDlg('D:  Debwin muss zur Anzeige von Debugausgaben gestartet werden'+#13
               +'US: Start Debwin to receive debug messages', mtInformation,
               [mbOK],0);
     end
     else LL.DebugMode:=0;
end;


procedure TForm1.DesignButtonClick(Sender: TObject);
begin
     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;

     {D:  Designer mit dem Titel 'Design Label' starten }
     {US: Opens the designer, sets designer title to 'Design Label'}
     LL.DataSource := dsProducts;
     LL.AutoDesignerFile := CurPath + 'simple.lbl';
     LL.AutoShowSelectFile := No;
     LL.AutoDesign('Design Label');

end;

end.

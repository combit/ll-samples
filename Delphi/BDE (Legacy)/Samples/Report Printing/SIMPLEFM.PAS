{==============================================================================

 Copyright (C) combit GmbH

-------------------------------------------------------------------------------
 File   : simplefm.pas, simplefm.dfm, simple2.dpr
 Module : simple list sample
 Descr. : D:  Dieses Beispiel demonstriert das Designen und Drucken von Listen.
          US: This example demonstrates how to design and print lists.
===============================================================================}

unit simplefm;

interface

uses
  Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DB, DBTables, cmbtll28, L28, StdCtrls, L28db, Registry, Windows,
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
    procedure DesignButtonClick(Sender: TObject);
    procedure PreviewButtonClick(Sender: TObject);
    procedure PrintButtonClick(Sender: TObject);
    procedure DebugCheckBoxClick(Sender: TObject);
  private
    { Private declarations }
  public
  CurPath, DataFilePath, DataFileName: string;
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.FormCreate(Sender: TObject);

var errorText: String;
var regKeyPath: String;
var errorOccurred: Boolean;
var registry: TRegistry;

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

procedure TForm1.DesignButtonClick(Sender: TObject);
begin
     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;
     LL.Datasource :=dsProducts;
     {D:  Designer mit dem Titel 'Design List' starten }
     {US: Opens the designer, sets designer title to 'Design List'}
     LL.AutoDesignerFile := CurPath + 'simple.lst';
     LL.AutoShowSelectFile := No;
     LL.AutoDesign('Design List');
end;

procedure TForm1.PreviewButtonClick(Sender: TObject);
begin
     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;
     LL.Datasource :=dsProducts;
     {D:  Projekt als Vorschau ausdrucken}
     {US: Print project to preview}
     LL.AutoDesignerFile := CurPath + 'simple.lst';
     LL.AutoShowSelectFile := No;
     LL.AutoDestination := adPreview;
     LL.AutoPrint('Print list to preview','');
end;

procedure TForm1.PrintButtonClick(Sender: TObject);
begin
      begin
     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;
     LL.Datasource :=dsProducts;
     {D:  Projekt auf Drucker ausdrucken }
     {US: Print project to printer}
     LL.AutoDesignerFile := CurPath + 'simple.lst';
     LL.AutoShowSelectFile := No;
     LL.AutoDestination := adPrinter;
     LL.AutoPrint('Print list to printer','');
     end;
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


end.

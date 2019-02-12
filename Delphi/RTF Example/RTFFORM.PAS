{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : rtfform.pas, rtfform.dfm, rtfdemo.dpr
 Module : List & Label rtf sample
 Descr. : D:  Dieses Beispiel demonstriert die Verwendung von RTF-Variablen
          US: This example demonstrates how to deal with RTF-variables.
======================================================================================}

unit rtfform;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ComCtrls, L24, cmbtll24, Registry;

type
  TForm1 = class(TForm)
    LoadButton: TButton;
    DesignButton: TButton;
    PreviewButton: TButton;
    PrintButton: TButton;
    OpenDialog1: TOpenDialog;
    Label1: TLabel;
    Label2: TLabel;
    LL: TL24_;
    RTF: TLL24RTFObject;
    procedure LoadButtonClick(Sender: TObject);
    procedure DesignButtonClick(Sender: TObject);
    procedure PreviewButtonClick(Sender: TObject);
    procedure PrintButtonClick(Sender: TObject);
    procedure LLDefineVariables(Sender: TObject; UserData: Integer;
      IsDesignMode: Boolean; var Percentage: Integer;
      var IsLastRecord: Boolean; var EventResult: Integer);
    procedure FormCreate(Sender: TObject);
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

procedure TForm1.LoadButtonClick(Sender: TObject);
var Buffer: TMemoryStream;
begin
     {D:  Dateiauswahldialog öffnen und RTF-Control füllen}
     {US: execute file open dialog and fill RTF-Control   }
     OpenDialog1.InitialDir := workingPath;
     If OpenDialog1.execute then
     begin
          Buffer:=TMemoryStream.create;
          Buffer.LoadFromFile(OpenDialog1.FileName);
          RTF.Text:=PAnsiChar(Buffer.Memory);
          PrintButton.enabled:=true;
          PreviewButton.enabled:=true;
          DesignButton.enabled:=true;
          Buffer.Free;
     end;
end;

procedure TForm1.DesignButtonClick(Sender: TObject);
begin

     {D:  Designer für Datei rtf.lbl aufrufen  }
     {US: call designer for file rtf.lbl      }
     LL.Design(0,handle,'Design Label', LL_PROJECT_LABEL,
        workingPath + 'rtf.lbl', true, true);
end;

procedure TForm1.PreviewButtonClick(Sender: TObject);
begin
     {D:  Projekt 'rtf.lbl als Vorschau ausdrucken}
     {US: Print project 'rtf.lbl' to preview      }
     LL.Print(0,LL_PROJECT_LABEL, workingPath + 'rtf.lbl', true, LL_PRINT_PREVIEW,
     LL_BOXTYPE_STDWAIT,handle,'Print labels to preview', true,
     '');
end;

procedure TForm1.PrintButtonClick(Sender: TObject);
begin
     {D:  Projekt 'rtf.lbl auf Drucker/Export ausdrucken}
     {US: Print project 'rtf.lbl' to printer/export     }
     LL.Print(0,LL_PROJECT_LABEL, workingPath + 'rtf.lbl', true, LL_PRINT_EXPORT,
     LL_BOXTYPE_STDWAIT,handle,'Print labels to preview', true,
     '');
end;

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
        workingPath := tmp + 'Delphi\RTF Example\';
      end
      else
        workingPath := tmp + '\Delphi\RTF Example\';

      registry.CloseKey();
    end;
  end;
  registry.Free();

end;

procedure TForm1.LLDefineVariables(Sender: TObject; UserData: Integer;
  IsDesignMode: Boolean; var Percentage: Integer;
  var IsLastRecord: Boolean; var EventResult: Integer);
{D:  Diese Routine wird von List & Label aufgerufen, um den Inhalt des
     RichEdit-Controls zu übergeben
 US: This routine is called by List & Label to hand over the contents of
     the RichEdit-Control                                                 }

begin
     LL.LlDefineVariableExt('RTF-Field', RTF.Text,
          LL_RTF);

     {D:  Nur eine RTF-Variable in diesem Beispiel vorhanden}
     {US: only one RTF-variable is used for this example    }
     if not (IsDesignMode) then
        IsLastRecord:=true;
end;

end.

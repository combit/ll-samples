{==============================================================================

 Copyright (C) combit GmbH

-------------------------------------------------------------------------------
 File   : picfm.pas, picfm.dfm, picture.dpr
 Module : picture box sample
 Descr. : D:  Dieses Beispiel demonstriert die Übergabe von Grafikobjekten
              an List & Label.
          US: This example demonstrates how to define graphic-objects to
              List & Label.
===============================================================================}


unit picfm;

interface

uses
  Windows, Messages, SysUtils, Classes, clipbrd, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls, OleCtrls, Menus, L27, cmbtll27, Registry;

type
  TPictureForm = class(TForm)
    Image1: TImage;
    Label2: TLabel;
    EMFButton: TButton;
    Label4: TLabel;
    BufferImage: TImage;
    Label3: TLabel;
    Bevel1: TBevel;
    Image2: TImage;
    Label6: TLabel;
    BitmapButton: TButton;
    Label5: TLabel;
    Button1: TButton;
    LL: TL27_;
    procedure PrintLabel;
    procedure FormCreate(Sender: TObject);
    procedure DesignButtonClick(Sender: TObject);
    procedure EMFButtonClick(Sender: TObject);
    procedure BitmapButtonClick(Sender: TObject);
    procedure LLDefineVariables(Sender: TObject; UserData: Integer;
      IsDesignMode: Boolean; var Percentage: Integer;
      var IsLastRecord: Boolean; var EventResult: Integer);
   
  private
  workingPath: String;
  WMFFlag: boolean;
    { Private declarations }
  public
    { Public declarations }
  end;

var
  PictureForm: TPictureForm;

implementation

{$R *.DFM}

procedure TPictureForm.FormCreate(Sender: TObject);

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
        workingPath := tmp + '\Delphi\BDE (Legacy)\Samples\';
      end
      else
        workingPath := tmp + '\Delphi\BDE (Legacy)\Samples\';

        registry.CloseKey();

      end;
    end;
    registry.Free();

    Image1.picture.LoadFromFile(workingPath + 'sunny.wmf');
    Image2.picture.LoadFromFile(workingPath + 'fruchten.bmp');

    // D: Verzeichnis setzen
    // US: Set current dir
    workingPath := GetCurrentDir() +'\';
end;



procedure TPictureForm.EMFButtonClick(Sender: TObject);
begin
     {D:  WMF in Puffer übertragen}
     {US: Transfer WMF to buffer }
     BufferImage.Picture.Metafile:=Image1.Picture.Metafile;
     WMFFlag:=true;

     {D:  Etikettendruck aufrufen; Projekt picture.lbl}
     {US: Start label printing; project picture.lbl   }
     PrintLabel;

end;

procedure TPictureForm.BitmapButtonClick(Sender: TObject);
begin
     {D:  Bitmap in Puffer übertragen}
     {US: Transfer Bitmap to buffer }
     BufferImage.Picture.Bitmap:=Image2.Picture.Bitmap;
     WMFFlag:=false;

     {D:  Etikettendruck aufrufen; Projekt picture.lbl}
     {US: Start label printing; project picture.lbl   }
     PrintLabel;

end;

procedure TPictureForm.DesignButtonClick(Sender: TObject);
begin
     {D:  Etikettendesigner aufrufen; Projekt: picture.lbl }
     {US: Start label designer; project: picture.lbl       }
     LL.Design(0,handle,'Design Labels', LL_PROJECT_LABEL,
        workingPath + 'picture.lbl',true, false);
end;



procedure TPictureForm.PrintLabel;

begin
     LL.Print(0,LL_PROJECT_LABEL, workingPath + 'picture.lbl',true,LL_PRINT_PREVIEW,
         LL_BOXTYPE_STDWAIT,handle,'Print label to preview', true,
         '');
end;
procedure TPictureForm.LLDefineVariables(Sender: TObject;
  UserData: Integer; IsDesignMode: Boolean; var Percentage: Integer;
  var IsLastRecord: Boolean; var EventResult: Integer);
{D:  Wird vom Programm aufgerufen, wenn Variablen definiert werden}
{US: Is called by the program to define variables                 }

begin

     if WMFFlag=false then
     LL.LlDefineVariableExtHandle('Picture', BufferImage.picture.bitmap.handle,
         LL_DRAWING_HBITMAP)
     else
     LL.LlDefineVariableExtHandle('Picture', BufferImage.picture.metafile.handle,
        LL_DRAWING_HEMETA);

     If not IsDesignMode then
     begin
          IsLastRecord:=true;
          Percentage:=100;
     end;
end;

end.

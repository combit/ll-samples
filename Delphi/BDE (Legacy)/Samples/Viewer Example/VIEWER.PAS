{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : viewer.pas, viewer.dfm, Llviewer.dpr
 Module : List & Label Viewer example
 Descr. : D:  Dieses Beispiel demonstriert die Verwendung des Preview-Controls
          US: This example demonstrates the usage of the preview control
======================================================================================}

unit viewer;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  OleCtrls, Menus, L25, cmbtll25, Registry;

type
  TViewForm = class(TForm)

    OpenDialog: TOpenDialog;
    MainMenu: TMainMenu;
    File1: TMenuItem;
    Open1: TMenuItem;
    Exit1: TMenuItem;
    View1: TMenuItem;
    FirstPage1: TMenuItem;
    PreviousPage1: TMenuItem;
    NextPage1: TMenuItem;
    LastPage1: TMenuItem;
    N1: TMenuItem;
    Zoomin1: TMenuItem;
    Zoomout1: TMenuItem;
    FittoPage1: TMenuItem;
    Saveas1: TMenuItem;
    N2: TMenuItem;
    Print1: TMenuItem;
    CurrentPage1: TMenuItem;
    MultiplePages1: TMenuItem;
    LlViewer: TLL25PreviewControl;
    procedure FormCreate(Sender: TObject);
    procedure Open1Click(Sender: TObject);
    procedure Exit1Click(Sender: TObject);
    procedure FormResize(Sender: TObject);
    procedure FirstPage1Click(Sender: TObject);
    procedure PreviousPage1Click(Sender: TObject);
    procedure NextPage1Click(Sender: TObject);
    procedure LastPage1Click(Sender: TObject);
    procedure Zoomin1Click(Sender: TObject);
    procedure Zoomout1Click(Sender: TObject);
    procedure FittoPage1Click(Sender: TObject);
    procedure Saveas1Click(Sender: TObject);
    procedure CurrentPage1Click(Sender: TObject);
    procedure MultiplePages1Click(Sender: TObject);
    procedure LlViewerPageChanged(Sender: TObject; NewPageIndex: Integer);

  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
   ViewForm: TViewForm;

implementation

{$R *.DFM}

procedure TViewForm.FormCreate(Sender: TObject);

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
			
			// cmbtll25
			tmp := registry.ReadString('LL25SampleDir');
			if (tmp[Length(tmp)] = '\') then
				begin
					tmp := tmp + 'Delphi\BDE (Legacy)\Samples\Viewer Example\';
				end
			else
					tmp := tmp + '\Delphi\BDE (Legacy)\Samples\Viewer Example\';

			registry.CloseKey();

		end;
	end;
	registry.Free();
	
	LlViewer.InputFileName := tmp + 'invoice.ll';
end;

procedure TViewForm.Open1Click(Sender: TObject);
begin
     if OpenDialog.execute then
        LlViewer.InputFileName:=OpenDialog.FileName;
end;

procedure TViewForm.Exit1Click(Sender: TObject);
begin
     ViewForm.close;
end;

procedure TViewForm.FormResize(Sender: TObject);
begin
     LlViewer.Height:=ViewForm.ClientHeight;
     LlViewer.Width:=ViewForm.ClientWidth;
end;

procedure TViewForm.FirstPage1Click(Sender: TObject);
begin
     LlViewer.GotoFirst;
end;

procedure TViewForm.PreviousPage1Click(Sender: TObject);
begin
     LlViewer.GotoPrevious;
end;

procedure TViewForm.NextPage1Click(Sender: TObject);
begin
     LlViewer.GotoNext;
end;

procedure TViewForm.LastPage1Click(Sender: TObject);
begin
     LlViewer.GotoLast;
end;

procedure TViewForm.Zoomin1Click(Sender: TObject);
begin
     LlViewer.ZoomTimes2;
end;

procedure TViewForm.Zoomout1Click(Sender: TObject);
begin
     LlViewer.ZoomRevert;
end;

procedure TViewForm.FittoPage1Click(Sender: TObject);
begin
     LlViewer.ZoomReset;
end;

procedure TViewForm.Saveas1Click(Sender: TObject);
begin
     LlViewer.SaveAs;
end;

procedure TViewForm.CurrentPage1Click(Sender: TObject);
begin
     Llviewer.PrintCurrentPage(true);
end;

procedure TViewForm.MultiplePages1Click(Sender: TObject);
begin
     Llviewer.PrintAllPages(true);
end;

procedure TViewForm.LlViewerPageChanged(Sender: TObject;
  NewPageIndex: Integer);
begin
     FirstPage1.enabled:=true;
     PreviousPage1.enabled:=true;
     LastPage1.enabled:=true;
     NextPage1.enabled:=true;

     If NewPageIndex = 0 then
     begin
          FirstPage1.enabled:=false;
          PreviousPage1.enabled:=false;
     end;

    If NewPageIndex = Llviewer.PageCount-1 then
    begin
              LastPage1.enabled:=false;
              NextPage1.enabled:=false;
    end;

end;

end.

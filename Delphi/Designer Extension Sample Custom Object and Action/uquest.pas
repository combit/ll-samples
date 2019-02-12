unit uquest;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, extfm;

type
  Tfrmquest = class(TForm)
    dtObjectName: TEdit;
    btnOK: TButton;
    Label1: TLabel;
    procedure btnOKClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmquest: Tfrmquest;

implementation

{$R *.dfm}

procedure Tfrmquest.btnOKClick(Sender: TObject);
begin
  objName :=  dtObjectName.Text;
  ModalResult := mrOk;
end;

procedure Tfrmquest.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  ModalResult := mrOk;
end;

end.

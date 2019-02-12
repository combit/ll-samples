unit clrSel;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TColorSelectForm = class(TForm)
    GroupBox1: TGroupBox;
    Button1: TButton;
    Button2: TButton;
    ColorDialog1: TColorDialog;
    ColorDialog2: TColorDialog;
    Button3: TButton;
    Button4: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    SelColor1, SelColor2: TColor;
  end;

var
  ColorSelectForm: TColorSelectForm;

implementation

{$R *.DFM}

procedure TColorSelectForm.Button1Click(Sender: TObject);
begin
    with ColorDialog1 do
    begin
      Color:=SelColor1;
      if Execute then
        SelColor1:=Color;
    end;
end;

procedure TColorSelectForm.Button2Click(Sender: TObject);
begin
    with ColorDialog2 do
    begin
      Color:=SelColor2;
      if Execute then
        SelColor2:=Color;
    end;
end;

end.

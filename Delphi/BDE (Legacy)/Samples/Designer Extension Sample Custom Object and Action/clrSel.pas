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
    FOwnerWnd: HWND;
  protected
    procedure CreateParams(var Params: TCreateParams); override;
  public
    SelColor1, SelColor2: TColor;
    class function Execute(AOwnerWnd: HWND; var AColor1, AColor2: TColor): TModalResult;
  end;

var
  ColorSelectForm: TColorSelectForm;

implementation

{$R *.DFM}
procedure TColorSelectForm.CreateParams(var Params: TCreateParams);
begin
  inherited CreateParams(Params);
  if FOwnerWnd <> 0 then
  begin
    Params.WndParent := FOwnerWnd;                        // owner, not parent
    Params.ExStyle := Params.ExStyle and not WS_EX_APPWINDOW; // no extra taskbar button
  end;
end;
 class function TColorSelectForm.Execute(AOwnerWnd: HWND;
  var AColor1, AColor2: TColor): TModalResult;
var
  Dlg: TColorSelectForm;
  R: TRect;
begin
  Dlg := TColorSelectForm.Create(nil);
  try
    Dlg.FOwnerWnd := AOwnerWnd;
    Dlg.SelColor1 := AColor1;
    Dlg.SelColor2 := AColor2;
    Dlg.PopupMode := pmExplicit;   // stop the VCL re-pointing WndParent at Application/MainForm
    Dlg.Position  := poDesigned;
    if (AOwnerWnd <> 0) and GetWindowRect(AOwnerWnd, R) then
    begin
      Dlg.Left := R.Left + (R.Right - R.Left - Dlg.Width) div 2;
      Dlg.Top  := R.Top + (R.Bottom - R.Top - Dlg.Height) div 2;
    end;
    Result := Dlg.ShowModal;
    if Result = mrOK then
    begin
      AColor1 := Dlg.SelColor1;
      AColor2 := Dlg.SelColor2;
    end;
  finally
    Dlg.Free;
  end;
end;

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

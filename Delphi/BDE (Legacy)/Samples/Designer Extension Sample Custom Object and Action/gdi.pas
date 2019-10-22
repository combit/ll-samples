unit gdi;

interface

uses graphics,classes,windows;

function MyGradientFill(C : TCanvas; Rect : TRect;
  Col1, Col2 : DWORD) : Boolean;

implementation

type
  GradientFillType = function (Handle: HDC;
    pVertex: Pointer;  dwNumVertex: DWORD; pMesh: Pointer;
    dwNumMesh: DWORD; dwMode: DWORD): DWORD; stdcall;

var
  fGradientFill : GradientFillType;
  fMsimg32han   : THandle;


function MyGradientFill(C : TCanvas; Rect : TRect;
  Col1, Col2 : DWORD) : Boolean;
type
  // TRIVERTEX is declared *wrong* in Windows.pas
  TriVertex = packed record
    X     : DWord;
    Y     : DWord;
    Red   : Word;
    Green : Word;
    Blue  : Word;
    Alpha : Word;
  end;
VAR
  TVs           : ARRAY[0..1] OF TriVertex;
  GradRect      : GRADIENT_RECT;
begin
  Result := False;
  // fGradientFill is initialized in the initialization section
  IF @fGradientFill <> nil THEN
    begin
      WITH TVS[0] DO
        begin
          X     := Rect.Left;
          Y     := Rect.Top;
          Red   := GetRValue(Col1) SHL 8;
          Green := GetGValue(Col1) SHL 8;
          Blue  := GetBValue(Col1) SHL 8;
          Alpha := 0;
        end;
      WITH TVS[1] DO
        begin
          X     := Rect.Right;
          Y     := Rect.Bottom;
          Red   := GetRValue(Col2) SHL 8;
          Green := GetGValue(Col2) SHL 8;
          Blue  := GetBValue(Col2) SHL 8;
          Alpha := 0;
        end;
      GradRect.UpperLeft := 0;
      GradRect.LowerRight := 1;
      Result := fGradientFill(C.Handle, @TVS, 2, @GradRect, 1,
        GRADIENT_FILL_RECT_H) <> 0;
    end;
  // If the gradient fill function failed or was unavailable,
  // just fill the whole rectangle
  IF NOT Result THEN
    begin
      C.Brush.Color := Col1;
      C.Brush.Style := bsSolid;
      C.FillRect(Rect);
    end;
end;


initialization
  fMsimg32han := LoadLibrary('msimg32.dll');
  IF fMsimg32han > 0 THEN
    begin
      @fGradientFill := GetProcAddress(fMsimg32han, 'GradientFill');
    end
  ELSE
    begin
      @fGradientFill := nil;
      fMsimg32han := 0;
    end;
finalization
  IF fMsimg32han <> 0 THEN
    FreeLibrary(fMsimg32han);
end.


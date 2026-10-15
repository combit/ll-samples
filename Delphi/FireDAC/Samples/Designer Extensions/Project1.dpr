program Project1;





uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {Form1},
  clrSel in 'clrSel.pas' {ColorSelectForm},
  gdi in 'gdi.pas',
  roman in 'roman.pas',
  uquest in 'uquest.pas' {frmquest},
  combit.ListLabel32 in '..\..\Component\Sources\combit.ListLabel32.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TColorSelectForm, ColorSelectForm);
  Application.CreateForm(Tfrmquest, frmquest);
  Application.Run;
end.

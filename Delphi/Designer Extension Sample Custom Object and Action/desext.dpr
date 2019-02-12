program desext;

uses
  Forms,
  extfm in 'extfm.pas' {DesExtForm},
  gdi in 'gdi.pas',
  clrSel in 'clrSel.pas' {ColorSelectForm},
  uquest in 'uquest.pas' {frmquest},
  roman in 'roman.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TDesExtForm, DesExtForm);
  Application.CreateForm(TColorSelectForm, ColorSelectForm);
  Application.CreateForm(Tfrmquest, frmquest);
  Application.Run;
end.

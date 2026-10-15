program Project1;
uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {Form1},
  combit.ListLabel32.Core.Repository in 'combit.ListLabel32.Core.Repository.pas',
  combit.ListLabel32.Repository in 'combit.ListLabel32.Repository.pas';

{$R *.res}
begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.

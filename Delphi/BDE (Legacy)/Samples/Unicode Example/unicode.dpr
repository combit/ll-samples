program unicode;

uses
  Forms,
  uc_fm in 'uc_fm.pas' {Form1};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.

program Invoice;

uses
  Forms,
  invfm in 'INVFM.PAS' {Form1};

{$R *.RES}

begin
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.

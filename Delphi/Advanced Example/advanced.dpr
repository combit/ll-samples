program Advanced;

uses
  Forms,
  Advfm in 'ADVFM.PAS' {Form1},
  Prop in 'PROP.PAS' {SelectColorForm};

{$R *.RES}

begin
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TSelectColorForm, SelectColorForm);
  Application.Run;
end.

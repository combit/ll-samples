program LlViewer;

uses
  Forms,
  viewer in 'viewer.pas' {ViewForm};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TViewForm, ViewForm);
  Application.Run;
end.

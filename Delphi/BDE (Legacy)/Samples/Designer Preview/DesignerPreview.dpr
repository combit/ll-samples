program DesignerPreview;

uses
  Forms,
  uDesignerPreview in 'uDesignerPreview.pas' {frmDesignerPreview},
  uPrintWorker in 'uPrintWorker.pas';
  
{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TfrmDesignerPreview, frmDesignerPreview);
  Application.Run;
end.

program picture;

uses
  Forms,
  picfm in 'picfm.pas' {PictureForm};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TPictureForm, PictureForm);
  Application.Run;
end.

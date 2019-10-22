program multitab;

uses
  Forms,
  uMain in 'uMain.pas' {frmMultipleTables},
  uObject in 'uObject.pas',
  uDataModule in 'uDataModule.pas' {DataModule1: TDataModule};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TDataModule1, DataModule1);
  Application.CreateForm(TfrmMultipleTables, frmMultipleTables);
  Application.Run;
end.

unit Prop;

interface

uses WinTypes, WinProcs, Classes, Graphics, Forms, Controls, Buttons,
  StdCtrls, ExtCtrls;

type
  TSelectColorForm = class(TForm)
    OKButton: TButton;
    CancelButton: TButton;
    ColorGroup: TRadioGroup;
    procedure OKButtonClick(Sender: TObject);
    procedure SetParameter(NewParameter: string);
  private
    sParameter: string;
    { Private declarations }
  public
    { Public declarations }
  published
  property Parameter: String read sParameter write SetParameter;

  end;

var
  SelectColorForm: TSelectColorForm;

implementation

{$R *.DFM}

procedure TSelectColorForm.OKButtonClick(Sender: TObject);
begin
     If ColorGroup.ItemIndex=0 then parameter:='R';
     If ColorGroup.ItemIndex=1 then parameter:='G';
     If ColorGroup.ItemIndex=2 then parameter:='B';
     ModalResult:=mrOK;
end;

procedure TSelectColorForm.SetParameter(NewParameter: String);
begin
     If NewParameter='R' then ColorGroup.ItemIndex:=0;
     If NewParameter='G' then ColorGroup.ItemIndex:=1;
     If NewParameter='B' then ColorGroup.ItemIndex:=2;
     sParameter:=NewParameter;
end;
end.

unit uObject;

interface

uses
  classes, ADODB;

type
  TTableMap = class
  protected
    FKeyList: TStringList;
    FValueList: TList;
    FMasterFieldList: TStringList;
    FDetailFieldList: TStringList;
  public
    constructor Create;
    destructor Destroy; override;
    procedure AddProperty(Key: String; Value: TADOTable; MasterField, DetailField: String);
    function GetValue(Key: String; var Value: TADOTable; var MasterField, DetailField: String): boolean;
  end;

implementation



{ TPropertyMap }

procedure TTableMap.AddProperty(Key: String; Value: TADOTable; MasterField, DetailField: String);
var
 Pos: integer;
begin
    Pos:=FKeyList.IndexOf(Key);
    if Pos<>-1 then
    begin
      FKeyList.Delete(Pos);
      FValueList.Delete(Pos);
      FMasterFieldList.Delete(Pos);
      FDetailFieldList.Delete(Pos);
    end;
    FKeyList.Add(Key);
    FValueList.Add(Value);
    FMasterFieldList.Add(MasterField);
    FDetailFieldList.Add(DetailField);
end;

constructor TTableMap.Create;
begin
 inherited create;
 FKeyList := TStringList.Create;
 FValueList := TList.Create;
 FMasterFieldList := TStringList.Create;
 FDetailFieldList := TStringList.Create;
end;

destructor TTableMap.Destroy;
begin
  FKeyList.Free;
  FValueList.Free;
  FMasterFieldList.Free;
  FDetailFieldList.Free;

  inherited destroy;
end;

function TTableMap.GetValue(Key: String; var Value: TADOTable; var MasterField, DetailField: String): boolean;
var
 Pos: integer;
begin
    result:=false;
    Pos:=FKeyList.IndexOf(Key);
    if Pos=-1 then
    begin
        Value := nil;
        MasterField := '';
        DetailField := '';
        exit;
    end;
    Value:=FValueList[Pos];
    MasterField:=FMasterFieldList[Pos];
    DetailField:=FDetailFieldList[Pos];
    result:=true;
end;

end.

unit uDataModule;

interface

uses
  SysUtils, Windows, Classes, DB, ADODB, Dialogs, ComObj, Registry
  {$If CompilerVersion >=28} // >=XE7
  , System.UITypes
  {$ENDIF}
  ;

type
  TDataModule1 = class(TDataModule)
    dsProducts: TDataSource;
    ADOConnection1: TADOConnection;
    Products: TADOTable;
    OrderDetails: TADOTable;
    Orders: TADOTable;
    Customers: TADOTable;
    dsOrderDetails: TDataSource;
    dsOrders: TDataSource;
    dsCustomers: TDataSource;
    OrderDetailsOrderID: TIntegerField;
    OrderDetailsProductID: TIntegerField;
    OrderDetailsUnitPrice: TBCDField;
    OrderDetailsQuantity: TSmallintField;
    OrderDetailsDiscount: TFloatField;
    OrderDetailsProductNameProductsProductIDProductName: TStringField;
    procedure DataModuleCreate(Sender: TObject);
    procedure DataModuleDestroy(Sender: TObject);
    procedure ADOConnection1ConnectComplete(Connection: TADOConnection; const error: Error; var EventStatus: TEventStatus);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DataModule1: TDataModule1;

implementation

{$R *.dfm}

procedure TDataModule1.DataModuleCreate(Sender: TObject);

var i: Integer;
var registry: TRegistry;
var regKeyPath: String;
var dbPath: String;

begin

  // D: Datenbankpfad auslesen
  // US: Read database path
  registry := TRegistry.Create();
  registry.RootKey := HKEY_CURRENT_USER;
  regKeyPath := 'Software\combit\cmbtll\';
  if registry.KeyExists(regKeyPath) then
  begin

  if registry.OpenKeyReadOnly(regKeyPath) then
    begin

      dbPath := registry.ReadString('NWINDPath');
      registry.CloseKey();

    end;
  end;
  registry.Free();

  if (dbPath = '') then
    begin
      ShowMessage('Unable to find sample database. Make sure List & Label is installed correctly.');
    end
  else
    begin
     {D:  ADO Verbidnungsinformationen  setzen}
     {US: Specifies the connection information for the data store }
      ADOConnection1.ConnectionString := 'Provider=Microsoft.Jet.OLEDB.4.0;' +
                                         'Data Source=' + dbPath + ';' +
                                         'Persist Security Info=False';

     {D:  Lade die Datenbank, fange Fehler ab  }
     {US: Load the database, checks for errors }
     Try
        ADOConnection1.Connected := true;

  //        Customers.Filter := 'CustomerID ' + '< ' + QuotedStr('D');
        Customers.Filter := 'CustomerID ' + '< ' + QuotedStr('B');
        Customers.Filtered := true;

        for i := 0 to (ADOConnection1.DataSetCount-1) do
          ADOConnection1.DataSets[i].Active := true;

     Except
       on E : EADOError do
            MessageDlg('D:  Beispiel-Datenbank nicht gefunden'+ #13 + 'US: Test database not found',mtError,[mbOK],0);
       on E : EOleError do
            ShowMessage(Format('D:   Beispiel-Datenbank nicht gefunden.'+#13+'US: Test database not found.'+#13#13'%s:''%s''.',[E.ClassName,E.Message]));
       on E : EOleException do
            ShowMessage(Format('D:   Beispiel-Datenbank nicht gefunden.'+#13+'US: Test database not found.'+#13#13'%s:''%s''.',[E.ClassName,E.Message]));
     End;
    end;
end;

procedure TDataModule1.DataModuleDestroy(Sender: TObject);
var
 i: integer;
begin
        for i := 0 to (ADOConnection1.DataSetCount-1) do
          ADOConnection1.DataSets[i].Active := false;

        ADOConnection1.Connected := false;
end;

procedure TDataModule1.ADOConnection1ConnectComplete(Connection: TADOConnection; const error: Error; var EventStatus: TEventStatus);
begin

   if EventStatus = esErrorsOccured then
   begin
    ShowMessage(  error.Description );
    Halt;
   end;

end;

end.

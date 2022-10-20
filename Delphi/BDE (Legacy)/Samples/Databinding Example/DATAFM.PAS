unit datafm;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs, DB,
  Registry, DBTables, ADODB, L28, StdCtrls, cmbtll28, L28db;
        
type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    DesignIL: TButton;
    PrintIL: TButton;
    DesignIIL: TButton;
    PrintIIL: TButton;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    DBL28_1: TDBL28_;
    DBL28_2: TDBL28_;
    dsOrders: TDataSource;
    dsCustomers: TDataSource;
    dsOrderDetails: TDataSource;
    dsProducts: TDataSource;
    Customers: TADOTable;
    ADOConnection1: TADOConnection;
    Orders: TADOTable;
    OrderDetails: TADOTable;
    Products: TADOTable;
    procedure DesignILClick(Sender: TObject);
    procedure PrintILClick(Sender: TObject);
    procedure DesignIILClick(Sender: TObject);
    procedure PrintIILClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
    workingPath: String;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.DesignILClick(Sender: TObject);
begin

  DBL28_1.AutoShowSelectFile := No;
  DBL28_1.AutoDesignerFile := workingPath + 'inv_var.lst';
  DBL28_1.AutoDesign('Invoice List');

end;

procedure TForm1.PrintILClick(Sender: TObject);
begin

  DBL28_1.AutoShowSelectFile := No;
  DBL28_1.AutoDesignerFile := workingPath + 'inv_var.lst';
  DBL28_1.AutoPrint('Invoice List', '');

end;

procedure TForm1.DesignIILClick(Sender: TObject);
begin

  DBL28_2.AutoShowSelectFile := No;
  DBL28_2.AutoDesignerFile := workingPath + 'inv_fie.lst';
  DBL28_2.AutoDesign('Invoice/Item List');

end;

procedure TForm1.PrintIILClick(Sender: TObject);
begin

  DBL28_2.AutoShowSelectFile := No;
  DBL28_2.AutoDesignerFile := workingPath + 'inv_fie.lst';
  DBL28_2.AutoPrint('Invoice/Item List','');

end;

procedure TForm1.FormCreate(Sender: TObject);

var registry: TRegistry;
var regKeyPath: String;
var dbPath: String;
var tmp: String;

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
	  
	  tmp := registry.ReadString('LL' + IntToStr(DBL28_1.LlGetVersion(LL_VERSION_MAJOR)) + 'SampleDir');
	  if (tmp[Length(tmp)] = '\') then
		begin
		  workingPath := tmp + 'Delphi\BDE (Legacy)\Samples\';
		end
	  else
		  workingPath := tmp + '\Delphi\BDE (Legacy)\Samples\';
      
      registry.CloseKey();

    end;
  end;
  registry.Free();

  if (dbPath = '') OR (workingPath = '') then
  begin

    ShowMessage('Unable to find sample database. Make sure List & Label is installed correctly.');
    exit;

  end;

  // D: Verzeichnis setzen
  // US: Set current dir
  workingPath := GetCurrentDir() + '\';

  if not ADOConnection1.Connected then
    begin

      ADOConnection1.ConnectionString := 'Provider=Microsoft.Jet.OLEDB.4.0;' +
                                         'User ID=Admin;' +
                                         'Data Source=' + dbPath + ';' +
                                         'Mode=Share Deny None;' +
                                         'Extended Properties="";' +
                                         'Jet OLEDB:Engine Type=4;';
      ADOConnection1.Connected := true;
      Customers.Active := true;
      Orders.Active := true;
      OrderDetails.Active := true;
      Products.Active := true;

    end;
end;

end.

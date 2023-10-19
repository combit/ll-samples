{==============================================================================

 Copyright (C) combit GmbH

-------------------------------------------------------------------------------
 File   : uChart.pas, uChart.dfm, chart.dpr
 Module : chart sample
 Descr. : D:  Dieses Beispiel demonstriert das Designen und Drucken von Charts.
          US: This example demonstrates how to design and print charts.
===============================================================================}

unit uChart;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs, DB,
  Registry, DBTables, ADODB, L29, StdCtrls, cmbtll29,  L29db;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    LL: TDBL29_;
    dsOrders: TDataSource;
    dsCustomers: TDataSource;
    dsOrderDetails: TDataSource;
    Customers: TADOTable;
    ADOConnection1: TADOConnection;
    Orders: TADOTable;
    OrderDetails: TADOTable;
    btnDesign: TButton;
    btnPrint: TButton;
    procedure LLExprError(Sender: TObject; ErrorText: string;
      lResult: Integer);
    procedure btnDesignClick(Sender: TObject);
    procedure btnPrintClick(Sender: TObject);
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

procedure TForm1.LLExprError(Sender: TObject; ErrorText: string;
  lResult: Integer);
begin
  ShowMessage(ErrorText);
end;

procedure TForm1.btnDesignClick(Sender: TObject);
begin

  LL.AutoShowSelectFile := No;
  LL.AutoDesignerFile := workingPath + 'chart.lst';
  LL.AutoDesign('Sales Report');

end;

procedure TForm1.btnPrintClick(Sender: TObject);
begin

  LL.AutoShowSelectFile := No;
  LL.AutoDesignerFile := workingPath + 'chart.lst';
  LL.AutoPrint('Sales Report', '');

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
	  
	  tmp := registry.ReadString('LL' + IntToStr(LL.LlGetVersion(LL_VERSION_MAJOR)) + 'SampleDir');
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
    workingpath := GetCurrentDir() +'\';

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

    end;
end;

end.

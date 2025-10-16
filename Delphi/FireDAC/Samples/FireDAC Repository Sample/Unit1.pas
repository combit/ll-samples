unit Unit1;

interface

uses
  Registry, LlReport_Types,
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, FireDAC.Stan.Intf, FireDAC.Stan.Option,
  FireDAC.Stan.Error, FireDAC.UI.Intf, FireDAC.Phys.Intf, FireDAC.Stan.Def,
  FireDAC.Stan.Pool, FireDAC.Stan.Async, FireDAC.Phys,
  FireDAC.VCLUI.Wait, Vcl.StdCtrls, Data.DB,
  FireDAC.Comp.Client,  FireDAC.Stan.Param, FireDAC.DatS, FireDAC.DApt.Intf, FireDAC.DApt,
  FireDAC.Comp.DataSet, FireDAC.Phys.MySQLDef, FireDAC.Phys.MySQL, FireDAC.Phys.MSAcc, FireDAC.Phys.MSAccDef,
  Vcl.ExtCtrls, Vcl.Grids, Vcl.DBGrids, ListLabel31, FireDAC.Phys.MSSQL,
  FireDAC.Phys.MSSQLDef, LlRepository, LlCoreRepository;

type
  TForm1 = class(TForm)
    lblGermanDescription: TLabel;
    lblEnglishDescription: TLabel;
    lblGerman: TLabel;
    lblEnglish: TLabel;
    FDConnectionNorthwind: TFDConnection;
    FDQueryOrders: TFDQuery;
    DataSourceOrders: TDataSource;
    FDQueryOrderDetails: TFDQuery;
    DataSourceOrderDetails: TDataSource;
    ListLabel: TListLabel31;
    DataSourceRepository: TDataSource;
    FDQueryRepository: TFDQuery;
    FDConnectionRepository: TFDConnection;
    btnDesignInvoiceAndItemsList: TButton;
    procedure FormCreate(Sender: TObject);
    procedure btnDesignInvoiceAndItemsListClick(Sender: TObject);


  private
    { Private declarations }
    FDbRepository: ILlDBBaseRepositry;
    FCoreRepository: ILlRepository;
    procedure CreateRepositoryTable;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}
uses system.Generics.Collections, cmbtLL31x;

procedure TForm1.btnDesignInvoiceAndItemsListClick(Sender: TObject);
begin

  ListLabel.DataController.AutoMasterMode := TLlAutoMasterMode.mmAsFields;
  ListLabel.DataController.DataMember := '';
  FDbRepository := TLlDBBaseRepository.Create;
  FDbRepository.Attributes := [];
  FDbRepository.Datasource := DataSourceRepository;
  FDbRepository.LoadAll;
  FCoreRepository := TLlCoreRepository.Create(FDbRepository);
  ListLabel.Core.LlSetOption(LL_OPTION_ILLREPOSITORY, NativeInt(FCoreRepository));
  ListLabel.Design;

end;



procedure TForm1.CreateRepositoryTable;
var
  sl: TStrings;
  command: TFDCommand;
begin

  sl := TStringList.Create;
  try
    FDConnectionRepository.GetTableNames('', '', '', sl);
    if sl.IndexOf('[LL$Repository]') < 0 then
    begin
      // create Repository table
      sl.Clear;
      sl.Add('');
      sl.Add('CREATE TABLE [LL$Repository](');
      sl.Add('	Id COUNTER NOT NULL,');
      sl.Add('	InternalId TEXT(80) NOT NULL,');
      sl.Add('	FolderId TEXT(250) NULL,');
      sl.Add('	ItemDescriptor MEMO NULL,');
      sl.Add('	AType TEXT(80) NULL,');
      sl.Add('	LastModification date NULL,');
      sl.Add('	Stream image NULL,');
      sl.Add('  CONSTRAINT UK_LLRepositry UNIQUE(InternalId),');
      sl.Add('  CONSTRAINT PK_LLRepositry PRIMARY KEY (Id)');
      sl.Add(')');
      command := TFDCommand.Create(self);
      try
        command.Connection := FDConnectionRepository;
        command.Execute(sl.Text);
      finally
        command.Free;
      end;
    end;
  finally
    sl.Free;
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
Var NWindDatabasePath: String;
Registry: TRegistry;
Error: Boolean;
ErrorMessage: String;
begin

   Error := False;
   ErrorMessage := 'Unable to find sample database. Make sure List & Label is installed correctly.';

   Registry := TRegistry.Create(KEY_READ);
   if (Registry.OpenKeyReadOnly('Software\combit\cmbtll')) then
   begin

      NWindDatabasePath := Registry.ReadString('NWINDPath');
      if (FileExists(NWindDatabasePath)) then
      begin

        try

          FDConnectionNorthwind.Connected := False;
          FDConnectionNorthwind.Params.Database := NWindDatabasePath;
          FDConnectionNorthwind.Connected := True;

          FDConnectionRepository.Connected := False;
          FDConnectionRepository.Params.Database := GetCurrentDir + '\' + 'Repository.mdb';
          FDConnectionRepository.Connected := True;
          CreateRepositoryTable;
        Except

            on Ecx: Exception do
            begin

              Error := True;
              ErrorMessage := 'Unable to find sample database. Make sure List & Label is installed correctly.' + #13#10#13#10 + Ecx.ClassName + ' error raised, with message: ' + Ecx.Message;

            end;

        end;

      end
      else
      begin

        Error := True;

      end;

      Registry.CloseKey;

   end
   else
   begin

    Error := True;

   end;

   Registry.Free;

   if (Error) then
   begin

      MessageBox(self.Handle, PWideChar(ErrorMessage), 'List & Label', MB_OK);

      btnDesignInvoiceAndItemsList.Enabled := False;
    end;

end;

end.

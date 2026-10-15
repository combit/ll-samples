unit Unit1;

interface

uses
  Registry, combit.ListLabel32.Report.Types,
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics, Vcl.Controls, Vcl.Forms, Vcl.Dialogs,
  Vcl.StdCtrls, Vcl.ExtCtrls, Data.DB,
  FireDAC.Stan.Intf, FireDAC.Stan.Option, FireDAC.Stan.Error,
  FireDAC.UI.Intf, FireDAC.Phys.Intf, FireDAC.Stan.Def,
  FireDAC.Stan.Pool, FireDAC.Stan.Async, FireDAC.Phys,
  FireDAC.VCLUI.Wait, FireDAC.Comp.Client, FireDAC.Stan.Param,
  FireDAC.DatS, FireDAC.DApt.Intf, FireDAC.DApt,
  FireDAC.Comp.DataSet, FireDAC.Phys.MSAcc, FireDAC.Phys.MSAccDef,
  combit.ListLabel32;

type
  TForm1 = class(TForm)
    lblGerman: TLabel;
    lblGermanDescription: TLabel;
    lblEnglish: TLabel;
    lblEnglishDescription: TLabel;
    groupExport: TGroupBox;
    lblFormat: TLabel;
    lblFilename: TLabel;
    formatCb: TComboBox;
    fileNameEd: TEdit;
    selectButton: TButton;
    showFileCheck: TCheckBox;
    createButton: TButton;
    FDConnectionNorthwind: TFDConnection;
    FDQueryOrders: TFDQuery;
    DataSourceProducts: TDataSource;
    ListLabel: TListLabel32;
    SaveDialog: TSaveDialog;
    procedure FormCreate(Sender: TObject);
    procedure formatCbChange(Sender: TObject);
    procedure selectButtonClick(Sender: TObject);
    procedure createButtonClick(Sender: TObject);

  private
    FDatabasePath: string;
    FStartPath: string;
    FFileFilter: string;
    FExportTarget: TLlExportTarget;
    LExportConfiguration : TLlExportConfiguration;
    FExportBase: string;
    function GetFileName: string;
    procedure SetFileName(const Value: string);
    property FileName: string read GetFileName write SetFileName;
  public

  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

function ExportTargetFromIndex(AIndex: Integer): TLlExportTarget;
begin
  case AIndex of
    0:  Result := TLlExportTarget.Pdf;
    1:  Result := TLlExportTarget.Mhtml;
    2:  Result := TLlExportTarget.Rtf;
    3:  Result := TLlExportTarget.Xml;
    4:  Result := TLlExportTarget.MultiTiff;
    5:  Result := TLlExportTarget.Text;
    6:  Result := TLlExportTarget.Xls;
    7:  Result := TLlExportTarget.Xlsx;
    8:  Result := TLlExportTarget.Xhtml;
    9:  Result := TLlExportTarget.Preview;
    10: Result := TLlExportTarget.Docx;
  else
    Result := TLlExportTarget.Pdf;
  end;
end;

function ExportExtensionFromIndex(AIndex: Integer): string;
begin
  case AIndex of
    0:  Result := '.pdf';
    1:  Result := '.mht';
    2:  Result := '.rtf';
    3:  Result := '.xml';
    4:  Result := '.tif';
    5:  Result := '.txt';
    6:  Result := '.xls';
    7:  Result := '.xlsx';
    8:  Result := '.htm';
    9:  Result := '.ll';
    10: Result := '.docx';
  else
    Result := '.pdf';
  end;
end;

function FileFilterFromIndex(AIndex: Integer): string;
begin
  case AIndex of
    0:  Result := 'PDF Files|*.PDF';
    1:  Result := 'MHTML Files|*.mht';
    2:  Result := 'RTF Files|*.RTF';
    3:  Result := 'XML Files|*.XML';
    4:  Result := 'Tiff Files|*.TIF';
    5:  Result := 'Text Files|*.TXT';
    6:  Result := 'Excel Files|*.XLS';
    7:  Result := 'Excel Files|*.XLSX';
    8:  Result := 'HTML Files|*.HTM';
    9:  Result := 'Preview Files|*.LL';
    10: Result := 'Word Files|*.DOCX';
  else
    Result := 'PDF Files|*.PDF';
  end;
end;

function TForm1.GetFileName: string;
begin
  Result := fileNameEd.Text;
end;

procedure TForm1.SetFileName(const Value: string);
begin
  fileNameEd.Text := Value;
end;

procedure TForm1.FormCreate(Sender: TObject);
var
  Reg: TRegistry;
  Error: Boolean;
  ErrorMessage: string;
begin
  FFileFilter := 'PDF Files|*.PDF';
  FExportTarget := TLlExportTarget.Pdf;
  FExportBase := 'export.pdf';
  Error := False;
  ErrorMessage := 'Unable to find sample database. Make sure List & Label is installed correctly.';

  Reg := TRegistry.Create(KEY_READ);
  try
    Reg.RootKey := HKEY_CURRENT_USER;
    if Reg.OpenKeyReadOnly('Software\combit\cmbtll') then
    begin
      FDatabasePath := Reg.ReadString('NWINDPath');

      if FileExists(FDatabasePath) then
      begin
        try
          FDConnectionNorthwind.Connected := False;
          FDConnectionNorthwind.Params.Database := FDatabasePath;
          FDConnectionNorthwind.Connected := True;
        except
          on E: Exception do
          begin
            Error := True;
            ErrorMessage := ErrorMessage
              + #13#10#13#10 + E.ClassName + ' error raised, with message: ' + E.Message;
          end;
        end;
      end
      else
        Error := True;

      Reg.CloseKey;
    end
    else
      Error := True;
  finally
    Reg.Free;
  end;

  if Error then
  begin
    MessageBox(Self.Handle, PWideChar(ErrorMessage), 'List & Label', MB_OK);
    createButton.Enabled := False;
  end;

  FStartPath := ExtractFilePath(Application.ExeName);
  SetCurrentDir(FStartPath);
  FileName := IncludeTrailingPathDelimiter(FStartPath) + FExportBase;
  formatCb.ItemIndex := 0;

end;

procedure TForm1.formatCbChange(Sender: TObject);
var
  BaseName: string;
begin
  FFileFilter := FileFilterFromIndex(formatCb.ItemIndex);
  FExportTarget := ExportTargetFromIndex(formatCb.ItemIndex);

  BaseName := ChangeFileExt(ExtractFileName(fileNameEd.Text),
                             ExportExtensionFromIndex(formatCb.ItemIndex));
  FExportBase := BaseName;

  FileName := IncludeTrailingPathDelimiter(ExtractFilePath(fileNameEd.Text)) + FExportBase;
end;

procedure TForm1.selectButtonClick(Sender: TObject);
begin
  SaveDialog.Filter := FFileFilter;
  SaveDialog.FileName := FileName;

  if SaveDialog.Execute then
    FileName := SaveDialog.FileName;

  SetCurrentDir(FStartPath);
end;

procedure TForm1.createButtonClick(Sender: TObject);
begin
  try
    FDQueryOrders.Active := True;

    // create export configuration
    LExportConfiguration := TLlExportConfiguration.Create(FExportTarget,fileNameEd.Text,'simple.lst');
    LExportConfiguration.ShowResult  := showFileCheck.Checked;

    {
    To additonally send the result as eMail, you'd need the following code lines. This
    will send an email to llmailtest@combit.net. Set the export format to HTML, as this sample
    will send the result as HTML body of the mail. You need to set a valid SMTP server
    using the LlExportOption.ExportMailSmtp... options.


    ListLabel.ExportOptions.Clear();
    ListLabel.ExportOptions.Add(TLlExportOption.ExportSendAsMail, '1');
    ListLabel.ExportOptions.Add(TLlExportOption.ExportMailTo, 'combit GmbH <SMTP:llmailtest@combit.net>');
    ListLabel.ExportOptions.Add(TLlExportOption.ExportMailSubject, 'combit List & Label mail test');
    ListLabel.ExportOptions.Add(TLlExportOption.ExportMailShowDialog, '1');
    ListLabel.ExportOptions.Add(TLlExportOption.ExportMailSendResultAs, 'text/html');
    }

     // Start export
    ListLabel.Export(LExportConfiguration);

  except
    on E: Exception do
      MessageBox(Self.Handle,
        PWideChar('Information: ' + E.Message + #13#10#13#10 +
          'This information was generated by a List & Label exception.'),
        'Information', MB_OK or MB_ICONINFORMATION);
  end;
end;

end.

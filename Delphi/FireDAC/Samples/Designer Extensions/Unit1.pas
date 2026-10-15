unit Unit1;

interface

uses
  Registry, combit.ListLabel32.Report.Types,
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, FireDAC.Stan.Intf, FireDAC.Stan.Option,
  FireDAC.Stan.Error, FireDAC.UI.Intf, FireDAC.Phys.Intf, FireDAC.Stan.Def,
  FireDAC.Stan.Pool, FireDAC.Stan.Async, FireDAC.Phys,
  FireDAC.VCLUI.Wait, Vcl.StdCtrls, Data.DB,
  FireDAC.Comp.Client,  FireDAC.Stan.Param, FireDAC.DatS, FireDAC.DApt.Intf, FireDAC.DApt,
  FireDAC.Comp.DataSet, FireDAC.Phys.MySQLDef, FireDAC.Phys.MySQL, FireDAC.Phys.MSAcc, FireDAC.Phys.MSAccDef,
  Vcl.ExtCtrls, Vcl.Grids, Vcl.DBGrids, combit.ListLabel32.DOM, combit.ListLabel32, FireDAC.Phys.MSSQL,
  FireDAC.Phys.MSSQLDef, Vcl.Menus;

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
    ListLabel: TListLabel32;
    RomanNumber: TLlDesignerFunction32;
    DesignButton: TButton;
    FindObjectAction: TLDesignerAction32;
    GradientFillObject: TLlDesignerObject32;


    procedure FormCreate(Sender: TObject);

    procedure GradientFillObjectDraw(Sender: TObject; Canvas: TCanvas;
      Rect: TRect; IsDesignMode: Boolean; var IsFinished: Boolean);
    procedure RomanNumberEvaluateFunction(Sender: TObject;
      var ResultType: TLlDesignerFunction32ParameterType;
      var ResultValue: OleVariant; var DecimalPositions: Integer;
      const ParameterCount: Integer; const Parameter1, Parameter2, Parameter3,
      Parameter4: OleVariant);
    procedure DesignButtonClick(Sender: TObject);
    procedure FindObjectActionExecuteAction;
    procedure GradientFillObjectEdit(Sender: TObject; ParentHandle: NativeUInt;
      var HasChanged: Boolean);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  objName: string;
implementation

{$R *.dfm}
uses system.Generics.Collections , gdi, clrSel, uquest, roman;



procedure TForm1.DesignButtonClick(Sender: TObject);
begin
  ListLabel.DataController.AutoMasterMode := TLlAutoMasterMode.mmAsFields;
  ListLabel.DataController.DataMember := '';
  ListLabel.AutoProjectFile := 'desext.lst';

  ListLabel.Design ();
end;

procedure TForm1.FindObjectActionExecuteAction;
var
  proj: TLlDOMProjectList;
  found: boolean;
  i: integer;
begin
  proj := TLlDOMProjectList.Create(LIstLabel);
  proj.GetFromParent();

  frmquest.ShowModal;
  if objName = '' then
    exit;

  proj.DesignerRedraw := 'False';
  found := false;

  for i := 0 to proj.ObjectList.Count - 1 do
  begin
    if TLlDOMObjectBase(proj.ObjectList.Items[i]).Name = objName then
    begin
      found := true;
      TLlDOMObjectBase(proj.ObjectList.Items[i]).Selected := 'True';
    end else
      TLlDOMObjectBase(proj.ObjectList.Items[i]).Selected := 'False';
  end;

  proj.DesignerRedraw := 'True';

  if not found then
    ShowMessage('The object could not be found.');

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

        ListLabel.AutoProjectFile := GetCurrentDir() + '\' + 'desext.lst';
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

   end;

end;

procedure TForm1.GradientFillObjectDraw(Sender: TObject; Canvas: TCanvas;
  Rect: TRect; IsDesignMode: Boolean; var IsFinished: Boolean);
var
  color1, color2: TColor;
  color1Str, color2Str: string;
  code: integer;
begin
    with Sender as TLlDesignerObject32 do
    begin
        Properties.GetValue('Color1',color1Str);
        Properties.GetValue('Color2',color2Str);
        val(color1Str,color1,code);
        val(color2Str,color2,code);

        // D:  Objekt zeichnen
        // US: Draw object
        MyGradientFill(Canvas, Rect, color1, color2);
    end;
end;


procedure TForm1.GradientFillObjectEdit(Sender: TObject;
  ParentHandle: NativeUInt; var HasChanged: Boolean);
var
  color1, color2: TColor;
  color1Str, color2Str: string;
  code: integer;
begin

    // D:  Objekt bearbeiten
    // US: Edit object

    HasChanged:=False;
    with Sender as TLlDesignerObject32 do
    begin
        // D:  Dialog initialisieren
        // US: Initialize dialog
        Properties.GetValue('Color1',color1Str);
        Properties.GetValue('Color2',color2Str);
        val(color1Str,color1,code);
        val(color2Str,color2,code);

        // D:  Dialog anzeigen, Farben werden per var-Parameter uebergeben
        // US: Show dialog, colors are passed in/out via var parameters
        if TColorSelectForm.Execute(ParentHandle, color1, color2) = mrOK then
        begin
            Properties.AddProperty('Color1', Format('%d', [color1]));
            Properties.AddProperty('Color2', Format('%d', [color2]));
            HasChanged:=True;
        end;

    end;
end;
procedure TForm1.RomanNumberEvaluateFunction(Sender: TObject;
  var ResultType: TLlDesignerFunction32ParameterType;
  var ResultValue: OleVariant; var DecimalPositions: Integer;
  const ParameterCount: Integer; const Parameter1, Parameter2, Parameter3,
  Parameter4: OleVariant);
begin
    // D:  Funktionsberechnung
    // US: Actual function evaluation
    ResultValue:=ToRoman(Parameter1);
end;

end.

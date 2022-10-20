{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : advfm.pas, advfm.dfm, advanced.dpr
 Module : advanced List & Label sample
 Descr. : D:  Dieses Beispiel demonstriert die Verwendung verschiedener Callbacks.
          US: This example demonstrates the usage of a variety of callbacks.
======================================================================================}

unit Advfm;

interface

uses
  SysUtils, Registry, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
  Forms, Dialogs, StdCtrls, Menus, DB, DBTables, Prop, L28, cmbtll28,
  ADODB
  {$If CompilerVersion >=28} // >=XE7
  , System.UITypes
  {$ENDIF}
  ;

type
  TForm1 = class(TForm)
    MainMenu1: TMainMenu;
    File1: TMenuItem;
    Exit1: TMenuItem;
    Edit1: TMenuItem;
    Label1: TMenuItem;
    Report1: TMenuItem;
    Print1: TMenuItem;
    Label2: TMenuItem;
    Report2: TMenuItem;
    Options1: TMenuItem;
    Usecallbacksfortablecoloring1: TMenuItem;
    DebugCheckBox: TCheckBox;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    LL: TL28_;
    ADOConnection1: TADOConnection;
    ADOTableArticle: TADOTable;
    procedure FormCreate(Sender: TObject);
    procedure Label1Click(Sender: TObject);
    procedure PrintLabelClick(Sender: TObject);
    procedure DebugCheckBoxClick(Sender: TObject);
    procedure Report1Click(Sender: TObject);
    procedure PrintListClick(Sender: TObject);

    procedure Usecallbacksfortablecoloring1Click(Sender: TObject);

    procedure Exit1Click(Sender: TObject);
    procedure LLDefineFields(Sender: TObject; UserData: Integer;
      IsDesignMode: Boolean; var Percentage: Integer;
      var IsLastRecord: Boolean; var EventResult: Integer);
    procedure LLDefineVariables(Sender: TObject; UserData: Integer;
      IsDesignMode: Boolean; var Percentage: Integer;
      var IsLastRecord: Boolean; var EventResult: Integer);
    procedure LLTableLine(Sender: TObject; LineType: TTableLineType;
      Canvas: TCanvas; Rect: TRect; PageLine, Line: Integer;
      Zebra: Boolean; SpacingRect: TRect);
    procedure LLTableField(Sender: TObject; FieldType: TTableFieldType;
      Canvas: TCanvas; Rect: TRect; LineDef, Index: Integer;
      SpacingRect: TRect);
    procedure LLVarHelpText(Sender: TObject; const Name: string;
      var HelpText: string);
    procedure LLDrawUserobj(Sender: TObject; Name, Contents: String;
      VarType: Integer; VarPointer: Pointer; ContentsHandle: THandle;
      Isotropic: Boolean; Parameters: String; Canvas: TCanvas;
      var Rect: TRect; PaintMode: TPaintMode);
    procedure LLEditUserobj(Sender: TObject; Name: String;
      VarType: Integer; VarPointer: Pointer; ContentsHandle: THandle;
      var Isotropic: Boolean; ParentHandle: Cardinal;
      var Parameters: String);
  private
    { Private declarations }
  public
    { Public declarations }
    CurPath, DataFilePath, DataFileName: string;
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.FormCreate(Sender: TObject);

var errorOccurred: Boolean;
var registry: TRegistry;
var regKeyPath: String;
var errorText: String;


begin

     {D:  Bestimme den Dateinamen der Beispiel-Datenbank}
     {US: Set the filename for the test database        }
     errorOccurred := true;
     registry := TRegistry.Create();
     registry.RootKey := HKEY_CURRENT_USER;
     regKeyPath := 'Software\combit\cmbtll\';
     if registry.KeyExists(regKeyPath) then
     begin

        if registry.OpenKeyReadOnly(regKeyPath) then
        begin

		  DataFilePath := registry.ReadString('LL' + IntToStr(LL.LlGetVersion(LL_VERSION_MAJOR)) + 'SampleDir');
		  if (DataFilePath[Length(DataFilePath)] = '\') then
		    begin
		  	  DataFileName:='samples.mdb';
		    end
		  else
			  DataFileName:='\samples.mdb';

          registry.CloseKey();

          if FileExists(DataFilePath + DataFileName) then
            begin

              {D:  Lade die Datenbank, fange Fehler ab  }
              {US: Load the database, checks for errors }
              Try
                begin
                     ADOConnection1.ConnectionString :='Provider=Microsoft.Jet.OLEDB.4.0;Data Source= ' + DataFilePath + DataFileName +';' ;
                     ADOConnection1.Connected :=true;
                     ADOConnection1.LoginPrompt :=false;
                     ADOTableArticle.active := false;
                     ADOTableArticle.TableName :='article';
                     ADOTableArticle.active := true;

                     {D:  Setze Dateipfad für LL Projektdateien }
                     {US: Set path fo LL project files}
                      CurPath := GetCurrentDir()+ '\';

                     errorOccurred := false;
                end
              Except On EDBEngineError Do
                //
              End;
            end;
        end;
     end;
     registry.Free();

     if errorOccurred then
     begin
     
        errorText := 'D:  Beispiel-Datenbank nicht gefunden' + #13 + 'US: Test database not found';
        MessageDlg(errorText, mtError, [mbOK], 0);
       
     end;
end;


procedure TForm1.PrintLabelClick(Sender: TObject);

var projectFile: String;

begin
      LL.OnDefineVariables := LLDefineVariables;
      LL.OnDefineFields := nil;

     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;
     {D:  Projekt 'advanced.lbl als Vorschau ausdrucken}
     {US: Print project 'advanced.lbl' to preview      }
     projectFile := CurPath + 'advanced.lbl';
     LL.Print(10, LL_PROJECT_LABEL, projectFile, true, LL_PRINT_EXPORT,
     LL_BOXTYPE_STDWAIT, handle, 'Print labels to preview', true,
     '');

end;

procedure TForm1.Report1Click(Sender: TObject);

var projectFile: String;

begin
      LL.OnDefineVariables := nil;
      LL.OnDefineFields := LLDefineFields;

     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;

     {D:  Designer mit dem Titel 'Design Lists' und der Datei advanced.lst starten }
     {US: Opens advanced.lst in the designer, sets designer title to 'Design Lists'}
     projectFile := CurPath + 'advanced.lst';
     LL.Design(0, handle, 'Design Lists', LL_PROJECT_LIST, projectFile, true, false);
end;

procedure TForm1.PrintListClick(Sender: TObject);

var projectFile: String;

begin
      LL.OnDefineVariables := nil;
      LL.OnDefineFields := LLDefineFields;

     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;

     {D:  Projekt 'advanced.lst als Vorschau ausdrucken}
     {US: Print project 'advanced.lst' to preview      }
     projectFile := CurPath + 'advanced.lst';
     LL.Print(0, LL_PROJECT_LIST, projectFile, true, LL_PRINT_EXPORT,
     LL_BOXTYPE_STDWAIT,handle, 'Print list to preview', true, '');
end;


procedure TForm1.DebugCheckBoxClick(Sender: TObject);
{D:  (De)aktiviert Debug-Ausgaben     }
{US: enables or disables debug output }
begin
     If DebugCheckBox.checked=true
     then
     begin
          LL.DebugMode:=1;
          MessageDlg('D:  DEBWIN muss zur Anzeige von Debugausgaben gestartet werden'+#13
               +'US: Start DEBWIN to receive debug messages', mtInformation,
               [mbOK],0);
     end
     else LL.DebugMode:=0;
end;

procedure TForm1.Usecallbacksfortablecoloring1Click(Sender: TObject);
begin
     UseCallbacksForTableColoring1.checked:=
     not(UseCallbacksForTableColoring1.checked);

     If UseCallbacksForTableColoring1.checked then
     begin
          LL.TableColoringMode:=tcUserDefined;
          LL.OnTableLine:=LLTableLine;
          LL.OnTableField:=LLTableField;
     end
     else
     begin
         LL.TableColoringMode:=tcNormal;
         LL.OnTableLine:=nil;
         LL.OnTableField:=nil;
     end;
end;


procedure TForm1.Exit1Click(Sender: TObject);
begin
 close;
end;

procedure TForm1.LLDefineFields(Sender: TObject; UserData: Integer;
  IsDesignMode: Boolean; var Percentage: Integer;
  var IsLastRecord: Boolean; var EventResult: Integer);
{D:  Dieser Event wird von den List & Label - Befehlen design und print
     ausgelöst. Er wird für jeden Datensatz aufgerufen, um die Felder
     und deren Inhalt an List & Label zu übergeben.
 US: This event is called by the List & Label methods design and print.
     It gets called once per record to define the fields and their
     contents.}


var
    i:               integer;

begin

     {D:  Wiederholung für alle Datensatzfelder           }
     {US: Loop through all fields in the present recordset}
     For i:= 0 to (ADOTableArticle.FieldCount-1) do
     begin

          {D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen }
          {US: Transform database field types into List & Label field types}
          LL.LlDefineFieldFromTField(ADOTableArticle.Fields[i]);
     end;

     {D:  Werden Echt-Daten benötigt (nicht bei Designer-Aufruf)       }
     {US: Is real data needed (not when method design has been called) }
     if not IsDesignMode then
     begin

          {D:  Prozentanzeige aktualisieren und zu nächsten Datensatz wechseln }
          {US: Set percentage value for meter info and move to next record     }
          Percentage:=Round(ADOTableArticle.RecNo/ADOTableArticle.RecordCount*100);
          ADOTableArticle.Next;

          {D:  Druck beenden, wenn kein weiterer Datensatz vorhanden ist}
          {US: End printing if last record is reached                   }
          if ADOTableArticle.EOF=True then IsLastRecord:=true;
     end;

     {D:  User-Objekte anmelden }
     {US: Define user-objects   }
     LL.LlDefineFieldExt('SalesStatistics','',LL_DRAWING_USEROBJ);
     LL.LlDefineFieldExt('SalesStatisticsColored','',
                                       LL_DRAWING_USEROBJ_DLG);


end;

procedure TForm1.LLDefineVariables(Sender: TObject; UserData: Integer;
  IsDesignMode: Boolean; var Percentage: Integer;
  var IsLastRecord: Boolean; var EventResult: Integer);
{D:  Dieser Event wird von den List & Label - Befehlen design und print
     ausgelöst. Er wird für jeden Datensatz aufgerufen, um die Variablen
     und deren Inhalt an List & Label zu übergeben.
 US: This event is called by the List & Label methods design and print.
     It gets called once per record to define the variables and their
     contents.}


var
    i:               integer;

begin

     {D:  Wiederholung für alle Datensatzfelder           }
     {US: Loop through all fields in the present recordset}
     For i:= 0 to (ADOTableArticle.FieldCount-1) do
     begin
          {D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen }
          {US: Transform database field types into List & Label field types}
          LL.LlDefineVariableFromTField(ADOTableArticle.Fields[i]);
     end;

     {D:  Werden Echt-Daten benötigt (nicht bei Designer-Aufruf)       }
     {US: Is real data needed (not when method design has been called) }
     if not IsDesignMode then
     begin
          {D:  Prozentanzeige aktualisieren und zu nächsten Datensatz wechseln }
          {US: Set percentage value for meter info and move to next record     }
          Percentage:=Round(ADOTableArticle.RecNo/ADOTableArticle.RecordCount*100);
          ADOTableArticle.Next;

          {D:  Druck beenden, wenn kein weiterer Datensatz vorhanden ist}
          {US: End printing if last record is reached                   }
          if ADOTableArticle.EOF=True then IsLastRecord:=true;
     end;

     {D:  User-Objekte anmelden }
     {US: define user-objects   }
     LL.LlDefineVariableExt('SalesStatistics','',LL_DRAWING_USEROBJ);
     LL.LlDefinevariableExt('SalesStatisticsColored','',
                                  LL_DRAWING_USEROBJ_DLG);

end;

procedure TForm1.Label1Click(Sender: TObject);

var projectFile: String;

begin
      LL.OnDefineVariables := LLDefineVariables;
      LL.OnDefineFields := nil;

     {D:  Zum ersten Datensatz wechseln }
     {US: Move to first record          }
     ADOTableArticle.First;

     {D:  Designer mit dem Titel 'Design Labels' und der Datei advanced.lbl starten }
     {US: Opens advanced.lbl in the designer, sets designer title to 'Design Labels'}
     projectFile := CurPath + 'advanced.lbl';
     LL.Design(0, handle, 'Design Labels', LL_PROJECT_LABEL, projectFile, true, false);
end;


procedure TForm1.LLTableLine(Sender: TObject; LineType: TTableLineType;
  Canvas: TCanvas; Rect: TRect; PageLine, Line: Integer; Zebra: Boolean;
  SpacingRect: TRect);

{D:  Dieser Callback wird für jede Zeile aufgerufen}
{US: This callback is called for each table line   }

begin
     {D:  Jede zweite Datenzeile mit der Hintergrundfarbe Blau füllen}
     {US: Color every second body line with blue background          }
     If (LineType=ltBody) and
        (PageLine mod 2 = 0) then
     begin
          Canvas.Brush.Color:=clBlue;
          Canvas.Pen.Style:=psClear;
          Canvas.Rectangle(Rect.left, Rect.top, Rect.right, Rect.bottom);
     end;
end;

procedure TForm1.LLTableField(Sender: TObject; FieldType: TTableFieldType;
  Canvas: TCanvas; Rect: TRect; LineDef, Index: Integer;
  SpacingRect: TRect);
{D:  Dieser Callback wird für jedes Feld einer Tabelle aufgerufen, nachdem
     OnTableLine für jede Zeile aufgerufen wurde
 US: This callback is called for each field of a table line after OnTableLine
     was called }

begin
     {D:  Jeweils das zweite Feld mit rotem Hintergrund füllen  }
     {US: Fill the second body field with a red background      }
     If (FieldType=ftBody) and
        (Index=1) then
     begin
          Canvas.Brush.Color:=clRed;
          Canvas.Pen.Style:=psClear;
          Canvas.Rectangle(Rect.left, Rect.top, Rect.right, Rect.bottom);
     end;
end;


procedure TForm1.LLVarHelpText(Sender: TObject; const Name: string;
  var HelpText: string);
{D:  Definiert Beschreibungs-Texte für einige Variablen}
{US: Defines description texts for some variables      }

begin
     If Name='ARTICLENO' then HelpText:='Article number' else
     if Name='DESCRIPT1' then HelpText:='Short description' else
     if Name='DESCRIPT2' then HelpText:='Description' else
     if Name='PRICEPP' then HelpText:='Price per piece' else
     if Name='SalesStatistics' then
        HelpText:='Sales statistic of the article' else
     HelpText:='Sorry, no help available';

end;

procedure TForm1.LLDrawUserobj(Sender: TObject; Name, Contents: String;
  VarType: Integer; VarPointer: Pointer; ContentsHandle: THandle;
  Isotropic: Boolean; Parameters: String; Canvas: TCanvas; var Rect: TRect;
  PaintMode: TPaintMode);

var
      i      : longint;
      x,y    : longint;
      rc     : tRect;
      nColor : longint;
      StepWidth: integer;
      height   : real;

begin
     {D:  'SalesStatistic' ausgeben}
     {US: Print sales statistic    }

     if Name='SalesStatistics' then
     begin
          Canvas.Pen.Color:=clBlack;
          rc:=Rect;
          rc.top:=rc.top+10;
          rc.bottom:=rc.bottom-10;


          {D:  Rahmen malen}
          {US: draw frame  }
          with Canvas do
          begin
            MoveTo(rc.left, rc.top);
            LineTo(rc.right, rc.top);
            LineTo(rc.right, rc.bottom);
            LineTo(rc.left, rc.bottom);
            LineTo(rc.left, rc.top);

            {D:  Zufallsdaten für Grafik ermitteln}
            {US: get random-data for chart        }
            Randomize;
            StepWidth:=(rc.right-rc.left) div 10;
            height:=rc.bottom-rc.top;
            for i:=0 to 10 do
            begin
                 x:=rc.left+StepWidth*i;
                 y:=rc.top+round(height*Random);
                 if (i=0) then
                 MoveTo(x, y)
                 else
                 LineTo(x, y);
            end;
          end;
     end
     else
     if Name='SalesStatisticsColored' then
     begin
          if (Parameters='R') or
             (Parameters='')then nColor:=RGB(255,0,0)
          else
          if Parameters='G' then nColor:=RGB(0,255,0)
          else
          nColor:=RGB(0,0,255);

          Canvas.Pen.Color:=clBlack;
          rc:=Rect;
          rc.top:=rc.top+10;
          rc.bottom:=rc.bottom-10;

          with Canvas do
          begin

            MoveTo(rc.left, rc.top);

            {D:  Rahmen malen}
            {US: draw frame  }
            LineTo(rc.right, rc.top);
            LineTo(rc.right, rc.bottom);
            LineTo(rc.left, rc.bottom);
            LineTo(rc.left, rc.top);
            Canvas.Brush.Color:=nColor;
            Rectangle(rc.left, rc.top, rc.right, rc.bottom);

            {D:  Zufallsdaten für Grafik ermitteln}
            {US: get random-data for chart        }
            Randomize;
            StepWidth:=(rc.right-rc.left) div 10;
            height:=rc.bottom-rc.top;
            for i:=0 to 10 do
            begin
                 x:=rc.left+StepWidth*i;
                 y:=rc.top+round(height*Random);
                 if (i=0) then
                     MoveTo(x, y)
                 else
                     LineTo(x, y);
            end;
          end;
     end;
end;



procedure TForm1.LLEditUserobj(Sender: TObject; Name: String;
  VarType: Integer; VarPointer: Pointer; ContentsHandle: THandle;
  var Isotropic: Boolean; ParentHandle: Cardinal; var Parameters: String);
begin
     {D:  Benutzer hat auf 'Bearbeiten' geklickt}
     {US: User clicked 'Edit'                   }
     SelectColorForm.Parameter:=Parameters;
     If SelectColorForm.ShowModal=mrOK then
     Parameters:=SelectColorForm.Parameter;
end;

end.

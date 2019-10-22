{=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : invfm.pas, invfm.dfm, invoice.dpr
 Module : invoice sample
 Descr. : D:  Dieses Beispiel demonstriert das Designen und Drucken von Rechnungen
          US: This example demonstrates how to design and print invoices.
======================================================================================}


unit invfm;

interface

uses
  Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DB, DBTables, cmbtll25, L25, StdCtrls, Registry, Windows, ADODB
  {$IFDEF ver280} // XE7
  , System.UITypes
  {$ENDIF}
  ;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    InvoiceList: TListBox;
    Label3: TLabel;
    DesignButton: TButton;
    PreviewButton: TButton;
    PrintButton: TButton;
    DebugCheckBox: TCheckBox;
    ADOTableInvoice: TADOTable;
    ADOTableItems: TADOTable;
    LL: TL25_;
    ADOConnection1: TADOConnection;
    procedure GetInvoiceNo;
    procedure DefineFields;
    procedure DefineVars;
    procedure PrintInvoice(PrintMode: integer);
    procedure FormCreate(Sender: TObject);
    procedure PreviewButtonClick(Sender: TObject);
    procedure DesignButtonClick(Sender: TObject);
    procedure PrintButtonClick(Sender: TObject);
    procedure DebugCheckBoxClick(Sender: TObject);
  private
    { Private declarations }
    CurPath: string;
    recNo: integer;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.GetInvoiceNo;
begin

     {D:  Rechnungsnr. aus der Datenbank einlesen und in Listbox schreiben}
     {US: Read invoice numbers from database and add to listbox           }

     {D:  Alle Listeneinträge löschen }
     {US: Clear listbox               }
     InvoiceList.clear;

     {D:  Zum ersten Datensatz der Rechnungstabelle wechseln}
     {US: Move to first record in invoice table             }
     ADOTableInvoice.first;

     {D:  Solange das Ende der Rechnungstabelle nicht erreicht ist...}
     {US: Loop until reaching the end of the invoice table           }
     while not (ADOTableInvoice.eof) do
     begin

          {D:  Rechnungsnr. der Liste hinzufügen}
          {US: Add invoice no. to list          }
          InvoiceList.Items.Add('No. '+ADOTableInvoice.Fields[0].AsString+' from '+
            ADOTableInvoice.Fields[1].AsString+', '+ADOTableInvoice.Fields[2].AsString);

          {D:  Zum nächsten Datensatz wechseln}
          {US: Move to next record            }
          ADOTableInvoice.next;
     end;

     {D:  Standardeintrag wählen}
     {US: Set default item      }
     InvoiceList.ItemIndex:=0;
end;

procedure TForm1.DefineFields;

{D:  Posten-Daten aus dem aktuellen Datensatz lesen und als List & Label Feld
     definieren
 US: Read item data from the current recordset and define as List & Label field}

var
    i:               integer;

begin
     For i:= 0 to (ADOTableItems.FieldCount-1) do
     begin

          {D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen }
          {US: Transform database field types into List & Label field types}
	  LL.LlDefineFieldFromTField(ADOTableItems.Fields[i]);
     end;
end;

procedure TForm1.DefineVars;

{D:  Rechnungs-Daten aus dem aktuellen Datensatz lesen und als List & Label
     Variablen definieren
 US: Read invoice-data from current recordset and define as List & Label
     variables                                                             }

 var
    i:               integer;

begin
     For i:= 0 to (ADOTableInvoice.FieldCount-1) do
     begin

          {D:  Umsetzung der Datenbank-Feldtypen in List & Label Variablentypen}
          {US: Transform database field types into List & Label variable types }
	  LL.LlDefineVariableFromTField(ADOTableInvoice.Fields[i]);
     end;
end;

procedure TForm1.PrintInvoice(PrintMode: integer);

{D:  Ausgewählte Rechnung drucken}
{US: Print selected invoice      }
var
    FileName:        string;
    nRet:            integer;
begin
     {D:  Zum ersten Datensatz wechseln}
     {US: Move to first record         }
     ADOTableInvoice.first;
     ADOTableItems.first;
     RecNo:=1;
     FileName := CurPath + 'invoice.lst';

     {D:  Variablen und Felder zurücksetzen}
     {US: reset variables and fields       }
     LL.LlDefineVariableStart;
     LL.LlDefineFieldStart;

     {D:  Variablen und Felder mit Dummy-Daten definieren}
     {US: Define variables and fields with dummy-data    }
     DefineVars;
     DefineFields;

     {D:  Auswahl der Projektdatei über Dateiauswahl-Dialog}
     {US: Select project file via file select dialog       }
     nRet:=LL.LlSelectFileDlg(handle, LL_PROJECT_LIST, FileName);

     {D:  Wenn Benutzer Abbrechen wählt Druck abbrechen}
     {US: Abort printing if user selected cancel       }
     if nRet=LL_ERR_USER_ABORTED then exit;

     {D:  Druck starten }
     {US: Start printing}
     LL.LlPrintWithBoxStart(LL_PROJECT_LIST, FileName, PrintMode,
       LL_BOXTYPE_STDWAIT, handle, 'Printing invoice');

     {D:  Druckoptionen setzen}
     {US: Set print options   }
      LL.LlPrintSetOption(LL_OPTION_COPIES, LL_COPIES_HIDE);
      {LL.LlPrintSetOption(LL_OPTION_PAGE, LL_PAGE_HIDE);}

     {D:  Dialog für Druckereinstellungen anzeigen}
     {US: Show print options dialog               }
     nRet:=LL.LlPrintOptionsDialog(handle, 'Configure printing parameters');

     {D:  Wenn Benutzer Abbrechen wählt Druck abbrechen}
     {US: Abort printing if user selected cancel       }
     if nRet=LL_ERR_USER_ABORTED then
     begin
        LL.LlPrintEnd(0);
        exit;
     end;

     {D:  Gehe zur ausgewählten Rechnung               }
     {US: Move to selected invoice                     }
     ADOTableInvoice.MoveBy(InvoiceList.ItemIndex);

     {D:  Variablen mit Echtdaten füllen               }
     {US: Fill variables with actual data              }
     DefineVars;

     {D:  Variablen drucken                            }
     {US: Print variables                              }
     LL.LlPrint;

     {D:  Solange das Ende der Postentabelle nicht erreicht ist...}
     {US: Loop until the end of the article table                 }
     While not ADOTableItems.EOF do
     begin

          {D:  Prozentbalken setzen                    }
          {US: Set meter bar                           }
          LL.LlPrintSetBoxText('Printing invoice',
          Round(RecNo/ADOTableItems.RecordCount*100));
          inc(RecNo);

          {D:  Wenn Rechnungsnummer übereinstimmt }
          {US: If invoice no fits selected        }
          if ADOTableInvoice.Fields[0].AsString=ADOTableItems.Fields[0].AsString then
          begin

               {D:  Felder mit Echtdaten aus aktuellem Datensatz füllen}
               {US: Fill fields with data from current record          }
               DefineFields;

               {D:  Felder drucken, bei Seitenumbruch Variablen und Felder
                    wiederholen
                US: Print fields, if page break occurred repeat fields and
                    variables                                          }
                While LL.LlPrintFields=LL_WRN_REPEAT_DATA do
                      LL.LlPrint;
          end;

          {D:  Gehe zum nächsten Datensatz                             }
          {US: Move to next record                                     }
          ADOTableItems.Next;
     end;

     {D:  Drucke Fusszeilen }
     {US: Print footer      }

     repeat
     nRet:=LL.LlPrintFieldsEnd
     until nRet<>LL_WRN_REPEAT_DATA;

     {D:  Druck beenden}
     {US: end print job}
     LL.LlPrintEnd(0);
end;

procedure TForm1.FormCreate(Sender: TObject);

var errorOccurred: Boolean;
var registry: TRegistry;
var regKeyPath: String;
var errorText: String;
var DataFileName: String;
var DataFilePath: String;

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
                     ADOTableItems.active := false;
                     ADOTableItems.TableName :='items';
                     ADOTableItems.active := true;
                     ADOTableInvoice.active := false;
                     ADOTableInvoice.TableName :='invoice';
                     ADOTableInvoice.active := true;


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

    GetInvoiceNo;
end;

procedure TForm1.DesignButtonClick(Sender: TObject);

var
    FileName:        string;
    nRet:	     integer;
begin
     {D:  Zum ersten Datensatz wechseln}
     {US: Move to first record         }
     ADOTableInvoice.first;
     ADOTableItems.first;

     {D:  Variablen und Felder zurücksetzen}
     {US: reset variables and fields       }
     LL.LlDefineVariableStart;
     LL.LlDefineFieldStart;

     {D:  Variablen und Felder mit Dummy-Daten definieren}
     {US: Define variables and fields with dummy-data    }
     DefineVars;
     DefineFields;

     {D:  Auswahl der Projektdatei über Dateiauswahl-Dialog}
     {US: Select project file via file select dialog       }
     FileName := CurPath + 'invoice.lst';
     nRet:=LL.LlSelectFileDlg(handle, LL_PROJECT_LIST, FileName);

     {D:  Wenn Benutzer Abbrechen wählt Druck abbrechen}
     {US: Abort printing if user selected cancel       }
     if nRet=LL_ERR_USER_ABORTED then exit;

     {D:  Designer starten}
     {US: Start designer  }
     LL.LlDefineLayout(handle,'Design invoice',
         OBJECT_LIST, FileName);

end;

procedure TForm1.PreviewButtonClick(Sender: TObject);
begin
{D:  Rechnung auf Preview drucken}
{US: Print invoice to preview    }
PrintInvoice(LL_PRINT_PREVIEW);
end;



procedure TForm1.PrintButtonClick(Sender: TObject);
begin
{D:  Rechnung auf Drucker/Export drucken}
{US: Print invoice to printer/export    }
PrintInvoice(LL_PRINT_EXPORT);
end;

procedure TForm1.DebugCheckBoxClick(Sender: TObject);

{D:  Debug-Ausgaben ein-/ausschalten}
{US: Toggle debug                   }

begin
     if DebugCheckBox.checked
     then
     begin
          LL.DebugMode:=1;
          MessageDlg('D:  DEBWIN muss zur Anzeige von Debugausgaben gestartet werden'+#13
               +'US: Start DEBWIN to receive debug messages', mtInformation,
               [mbOK],0);
     end
     else
     LL.DebugMode:=0;
end;

end.

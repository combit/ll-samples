//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "invfm.h"
#include <math.h>
#include <dir.h>
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "L25"
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::FormCreate(TObject* /*Sender*/)
{
	TString tmp, dataFilePath;
	bool errorOccurred = true;
	TString regKeyPath("Software\\combit\\cmbtll\\");
	TRegistry* pRegistry = new TRegistry();
	pRegistry->RootKey = HKEY_CURRENT_USER;

	if(pRegistry->KeyExists(regKeyPath))
	{
		if(pRegistry->OpenKeyReadOnly(regKeyPath))
		{
			tmp = pRegistry->ReadString("LL" + IntToStr(LL->LlGetVersion(LL_VERSION_MAJOR)) + "SampleDir");
			if (tmp[tmp.Length()] == '\\')
			  dataFilePath = tmp + "C++ Builder\\";
			else
			  dataFilePath = tmp + "\\C++ Builder\\";

			InvoiceName = "invoice.dbf";
			ItemsName = "items.dbf";

			pRegistry->CloseKey();

			if(FileExists(dataFilePath + InvoiceName) && (FileExists(dataFilePath + ItemsName)))
			{
				//D:   Lade die Datenbanken, fange Fehler ab
				//US: Load the databases, check for errors
				try
				{
					InvoiceTable->Active = false;
					ItemsTable->Active = false;
					InvoiceTable->DatabaseName = dataFilePath;
					ItemsTable->DatabaseName = dataFilePath;
					InvoiceTable->TableName = InvoiceName;
					ItemsTable->TableName = ItemsName;
					InvoiceTable->Active = true;
					ItemsTable->Active = true;

					// D:  Setze Dateipfad für LL Projektdateien }
					// US: Set path fo LL project files}
					CurPath = dataFilePath + ChangeFileExt(ExtractFileName((Application->ExeName)), "") + '\\';
					errorOccurred = false;
				}
				catch(...)
				{
					//MessageDlg("D:   Beispiel-Datenbank nicht gefunden\nUS: Test database not found",
					//mtError,TMsgDlgButtons() << mbOK,0);
				}
            }
        }
    }
	pRegistry->Free();

	if(errorOccurred)
		MessageDlg("D:   Beispiel-Datenbank nicht gefunden\nUS: Test database not found",mtError,TMsgDlgButtons() << mbOK,0);

	GetInvoiceNo();
}
//---------------------------------------------------------------------------


TForm1::GetInvoiceNo()
{
        //D:   Rechnungsnr. aus der Datenbank einlesen und in Listbox schreiben
        //US: Read invoice numbers from database and add to listbox

        //D:   Alle Listeneinträge löschen
        //US: Clear listbox
        InvoiceList->Clear();

        //D:   Zum ersten Datensatz der Rechnungstabelle wechseln
        //US: Move to first record in invoice table
        InvoiceTable->First();

        //D:   Solange das Ende der Rechnungstabelle nicht erreicht ist...
        //US: Loop until reaching the end of the invoice table
        while(!InvoiceTable->Eof)
        {
                TField *Field_0 = InvoiceTable->Fields->Fields[0];
                TField *Field_1 = InvoiceTable->Fields->Fields[1];
                TField *Field_2 = InvoiceTable->Fields->Fields[2];

                //D:   Rechnungsnr. der Liste hinzufügen
                //US: Add invoice no. to list
                InvoiceList->Items->Add("No. " + Field_0->AsString + " from " +
                Field_1->AsString + ", " + Field_2->AsString);

                //D:   Zum nächsten Datensatz wechseln
                //US: Move to next record
                InvoiceTable->Next();
        }

        //D:   Standardeintrag wählen
        //US: Set default item
        InvoiceList->ItemIndex=0;

        return(0);
}

void __fastcall TForm1::DesignButtonClick(TObject* /*Sender*/)
{
        String FileName;
        long nRet;

        //D:   Zum ersten Datensatz wechseln
        //US: Move to first record
        InvoiceTable->First();
        ItemsTable->First();

        //D:   Variablen und Felder zurücksetzen
        //US: reset variables and fields
        LL->LlDefineVariableStart();
        LL->LlDefineFieldStart();

        //D:   Variablen und Felder mit Dummy-Daten definieren
        //US: Define variables and fields with dummy-data
        DefineVars();
        DefineFields();

        //D:   Auswahl der Projektdatei über Dateiauswahl-Dialog
        //US: Select project file via file select dialog
        FileName = CurPath + "invoice.lst";
        nRet=LL->LlSelectFileDlgTitle((UINT)this->Handle, "Test", LL_PROJECT_LIST, FileName);

        //D:   Wenn Benutzer Abbrechen wählt Druck abbrechen
        //US: Abort printing if user selected cancel
        if(nRet==LL_ERR_USER_ABORTED)
        {
                return;
        }

        //D:   Designer starten
        //US: Start designer
        LL->LlDefineLayout((UINT)this->Handle,"Design invoice", OBJECT_LIST, FileName.c_str());

}
//---------------------------------------------------------------------------



TForm1::DefineVars()
{
        //D:   Rechnungs-Daten aus dem aktuellen Datensatz lesen und als List & Label Variablen definieren
        //US: Read invoice-data from current recordset and define as List & Label variables

        int i;
        long FieldType;
        String FieldName;
        String FieldContent;

        for(i=0; i<=InvoiceTable->FieldCount-1; i++)
        {
                //D:   Umsetzung der Datenbank-Feldtypen in List & Label Variablentypen
                //US: Transform database field types into List & Label variable types

                TField *Field = InvoiceTable->Fields->Fields[i];

                switch(Field->DataType)
                {
                case(ftInteger, ftSmallint, ftFloat):
                        //D:   numerische Variablen
                        //US: numerical Varaiables
                        FieldType=LL_NUMERIC;
                        FieldContent=Field->AsString;
                        break;
                case(ftDate):
                        //D:   für Delphi-Datumsvariablentyp Umwandlung in List & Label -Format
                        //US: transform delphi date type into List & Label format                                      }
                        FieldType=LL_DATE_DELPHI;
                        FieldContent=FloatToStr(StrToDate(Field->AsString));
                        break;
                case(ftBoolean):
                        //D:   Entscheidungsvariable wahr/falsch, boolean
                        //US: True/false variable, boolean
                        FieldType=LL_BOOLEAN;
                        FieldContent=Field->AsString;
                        break;
                default:
                        //D:   Zeichenformat = Text
                        //US: Characterformat = Text
                        FieldType=LL_TEXT;
                        FieldContent=Field->AsString;
                        break;
                }

                //D:   Variablenname, -inhalt und -typ an List & Label übergeben
                //US: Declare variablename, -content and -type to List & Label
                FieldName=Field->FieldName;
                LL->LlDefineVariableExt(FieldName,FieldContent,FieldType);
        }

        return(0);
}

TForm1::DefineFields()
{
        //D:   Posten-Daten aus dem aktuellen Datensatz lesen und als List & Label Feld definieren
        //US: Read item data from the current recordset and define as List & Label field

        int i;
        long FieldType;
        String FieldName;
        String FieldContent;

        for(i=0; i<=(ItemsTable->FieldCount)-1; i++)
        {
                //D:   Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen
                //US: Transform database field types into List & Label field types

                TField *Field = ItemsTable->Fields->Fields[i];

                switch(Field->DataType)
                {
                case(ftInteger, ftSmallint, ftFloat):
                        //D:   numerische Variablen
                        //US: numerical Varaiables
                        FieldType=LL_NUMERIC;
                        FieldContent=Field->AsString;
                        break;

                case(ftDate):
                        //D:   für Delphi-Datumsvariablentyp Umwandlung in List & Label -Format
                        //US: transform delphi date type into List & Label format
                        FieldType=LL_DATE_DELPHI;
                        FieldContent=FloatToStr(StrToDate(Field->AsString));
                        break;

                case(ftBoolean):
                        //D:   Entscheidungsvariable wahr/falsch, boolean
                        //US: True/false variable, boolean
                        FieldType=LL_BOOLEAN;
                        FieldContent=Field->AsString;
                        break;

                default:
                        //D:   Zeichenformat = Text
                        //US: Characterformat = Text
                        FieldType=LL_TEXT;
                        FieldContent=Field->AsString;
                        break;
                }

                //D:   Feldname, -inhalt und -typ an List & Label übergeben
                //US: Declare fieldname, fieldcontent and fieldtype to List & Label
                FieldName=Field->FieldName;
                LL->LlDefineFieldExt(FieldName,FieldContent,FieldType);
        }

        return(0);
}
void __fastcall TForm1::PreviewButtonClick(TObject* /*Sender*/)
{
        //D:   Rechnung auf Preview drucken
        //US: Print invoice to preview
        PrintInvoice(LL_PRINT_PREVIEW);
}
//---------------------------------------------------------------------------


TForm1::PrintInvoice(int PrintMode)
{
        //D:   Ausgewählte Rechnung drucken
        //US: Print selected invoice

        int nRet;
        String FileName;
        String TargetFormat;

        //D:   Zum ersten Datensatz wechseln
        //US: Move to first record
        InvoiceTable->First();
        ItemsTable->First();
        RecNo=1;
        FileName = CurPath + "invoice.lst";

        //D:   Variablen und Felder zurücksetzen
        //US: reset variables and fields
        LL->LlDefineVariableStart();
        LL->LlDefineFieldStart();

        //D:   Variablen und Felder mit Dummy-Daten definieren
        //US: Define variables and fields with dummy-data
        DefineVars();
        DefineFields();

        //D:   Auswahl der Projektdatei über Dateiauswahl-Dialog
        //US: Select project file via file select dialog
        nRet=LL->LlSelectFileDlg((UINT)this->Handle, LL_PROJECT_LIST, FileName);

        //D:   Wenn Benutzer Abbrechen wählt Druck abbrechen
        //US: Abort printing if user selected cancel
        if(nRet==LL_ERR_USER_ABORTED)
        {
                return(0);
        }

        //D:   Druck starten
        //US: Start printing
        nRet=LL->LlPrintWithBoxStart(LL_PROJECT_LIST, FileName, PrintMode,
        LL_BOXTYPE_STDWAIT, (UINT)this->Handle, "Printing invoice");

        //D:   Druckoptionen setzen
        //US: Set print options
        LL->LlPrintSetOption(LL_OPTION_COPIES, LL_COPIES_HIDE);
        //LL->LlPrintSetOption(LL_OPTION_PAGE, LL_PAGE_HIDE);

        //D:   Dialog für Druckereinstellungen anzeigen
        //US: Show print options dialog
        nRet=LL->LlPrintOptionsDialog((UINT)this->Handle, "Configure printing parameters");

        //D:   Wenn Benutzer Abbrechen wählt Druck abbrechen
        //US: Abort printing if user selected cancel
        if(nRet==LL_ERR_USER_ABORTED)
        {
                return(0);
        }

        LL->LlPrintGetOptionString(LL_PRNOPTSTR_EXPORT, TargetFormat);

        //D:   Gehe zur ausgewählten Rechnung
        //US: Move to selected invoice
        InvoiceTable->MoveBy(InvoiceList->ItemIndex);

        //D:   Variablen mit Echtdaten füllen
        //US: Fill variables with actual data
        DefineVars();

        //D:   Variablen drucken
        //US: Print variables
        LL->LlPrint();

        //D:   Solange das Ende der Postentabelle nicht erreicht ist...
        //US: Loop until the end of the article table
        while(!ItemsTable->Eof)
        {
                //D:   Prozentbalken setzen
                //US: Set meter bar
                nRet=LL->LlPrintSetBoxText("Printing invoice",
                floor(RecNo/ItemsTable->RecordCount*100));
                RecNo--;

                TField *Field_Inv = InvoiceTable->Fields->Fields[0];
                TField *Field_Itm = ItemsTable->Fields->Fields[0];

                //D:   Wenn Rechnungsnummer übereinstimmt
                //US: If invoice no fits selected
                if(Field_Inv->AsString==Field_Itm->AsString)
                {
                        //D:   Felder mit Echtdaten aus aktuellem Datensatz füllen
                        //US: Fill fields with data from current record
                        DefineFields();

                        //D:   Felder drucken, bei Seitenumbruch Variablen und Felder wiederholen
                        //US: Print fields, if page break occurred repeat fields and variables
                        while(LL->LlPrintFields()==LL_WRN_REPEAT_DATA)
                        {
                                nRet=LL->LlPrint();
                        }
                }

                //D:   Gehe zum nächsten Datensatz
                //US: Move to next record
                ItemsTable->Next();


        }
        do
        {
                 //D:   Drucke Fusszeilen
                //US: Print footer
                nRet=LL->LlPrintFieldsEnd();
        }
        while(nRet==LL_WRN_REPEAT_DATA);

        //D:   Druck beenden
        //US: end print job
        nRet=LL->LlPrintEnd(0);

        return(0);
}

void __fastcall TForm1::PrintButtonClick(TObject* /*Sender*/)
{
        //D:   Rechnung auf Drucker/Export drucken
        //US: Print invoice to printer/export
        PrintInvoice(LL_PRINT_EXPORT);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::DebugCheckBoxClick(TObject* /*Sender*/)
{
        //D:   Debug-Ausgaben ein-/ausschalten
        //US: Toggle debug
        if(DebugCheckBox->Checked)
        {
                LL->DebugMode=1;
                MessageDlg("D:   DEBWIN muss zur Anzeige von Debugausgaben gestartet werden\nUS: Start DEBWIN to receive debug messages",
                mtInformation,TMsgDlgButtons() << mbOK,0);
        }
		else
			LL->DebugMode = 0;
}
//---------------------------------------------------------------------------


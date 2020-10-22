//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "uPrtloop.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "L26"
#pragma resource "*.dfm"
TfrmPrtloop *frmPrtloop;
//---------------------------------------------------------------------------
__fastcall TfrmPrtloop::TfrmPrtloop(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmPrtloop::Label5Click(TObject* /*Sender*/)
{
        String FileName = "simple.lbl";
        ADOTblCustomers->First();

        //D: Dateiauswahldialog. Aufruf ist optional, sonst einfach on FileName den
        //gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
        //sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
        //US: Optional call to file selection dialog. Ommit this call and pass the
        //required file as FileName if you don´t want the dialog to appear. If only
        //existing files should be selctable, remove the "or"ing with LL_FILE_ALSONEW
        if (LL->LlSelectFileDlg((UINT)this->Handle,LL_PROJECT_LABEL|LL_FILE_ALSONEW,FileName) != LL_ERR_USER_ABORTED)
        {
                //D: Daten definieren
                //US: Define data
                DefineCurrentRecord(false);

                //D: Designer mit dem Titel 'Design label' und der gewählten Datei starten
                //US: Opens the chosen file in the designer, sets designer title to 'Design label'
                LL->LlDefineLayout((UINT)this->Handle,"Design label",LL_PROJECT_LABEL,FileName);
        }
}
//---------------------------------------------------------------------------
void TfrmPrtloop::DefineCurrentRecord(bool AsFields)
{
        int i;
        //D: Diese Prozedure übergibt den aktuellen Datensatz an List & Label. Hier können Sie
        //ansetzen, um andere Datenquellen zu verwenden
        //US: This procedure passes the current record to List & Label. Customize it in order to
        //pass different data

        //D: Wiederholung der Datenbank-Feldtypen für alle Datensatzfelder
        //US: Translation through all field types into List & Label field types
        for (i = 0; i < ADOTblCustomers->FieldCount; i++) {

                if (AsFields) {
                        LL->LlDefineFieldFromTField(ADOTblCustomers->Fields->Fields[i]);
                }
                else {
                        LL->LlDefineVariableFromTField(ADOTblCustomers->Fields->Fields[i]);
                }

        }
}
//---------------------------------------------------------------------------
void __fastcall TfrmPrtloop::DebugCheckBoxClick(TObject* /*Sender*/)
{
        //D: (De)aktiviert Debug-Ausgaben
        //US: Enables or disables debug output
        if (DebugCheckBox->Checked)
        {
                LL->DebugMode = 1;
                MessageDlg("D:  DEBWIN muss zur Anzeige von Debugausgaben gestartet werden\nUS: Start DEBWIN to receive debug messages",
                        mtInformation,TMsgDlgButtons() << mbOK,0);
        }
        else
        {
                LL->DebugMode = 0;
        }
}
//---------------------------------------------------------------------------
void __fastcall TfrmPrtloop::Label6Click(TObject* /*Sender*/)
{
        String FileName = "simple.lbl";
        int Ret;

        ADOTblCustomers->First();

        //D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
        //    gewünschten Dateinamen übergeben.
        //US: Optional call to file selection dialog. Ommit this call and pass the
        //    required file as FileName if you don't want the dialog to appear.
        if (LL->LlSelectFileDlg((UINT)this->Handle,LL_PROJECT_LABEL,FileName)==LL_ERR_USER_ABORTED) {
                return;
        }

        //D:  Daten definieren. Die hier übergebenen Daten dienen nur der Syntaxprüfung - die Inhalte
        //    brauchen keine Echtdaten zu enthalten
        //US: Define data. The data passed here is only used for syntax checking and doesn't need
        //    to contain real data
        DefineCurrentRecord(false);

        //D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.
        //US: Start print job. Allow all export formats as target. Meter box with cancel button.
        Ret = LL->LlPrintWithBoxStart(LL_PROJECT_LABEL,FileName,LL_PRINT_EXPORT,LL_BOXTYPE_STDABORT,(UINT)this->Handle,"Printink label...");

        //D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).
        //{US: Most frequent cause for error code: -23 (Sytax Error).
        if (Ret != 0) {
                ShowMessage("Error during LlPrintWithBoxStart");
                return;
        }

        //D:  Druckoptionsdialog. Aufruf ist optional, es können sonst Ausgabeziel und
        //    Exportdateiname über LlXSetParameter() gesetzt werden bzw. der Drucker und
        //    die Druckoptionen über LlSetPrinterInPrinterFile() vorgegeben werden.
        //US: Optional call to print options dialog. You may also set the print target format
        //    and export file name using LlXSetParameter() or set the printer and print options
        //    using LlSetPrinterInPrinterFile()
        if (LL->LlPrintOptionsDialog((UINT)this->Handle,"Choose printing options")==LL_ERR_USER_ABORTED) {
                LL->LlPrintEnd(0);
                return;
        }

        //D:  Eigentliche Druckschleife; Wiederholung, solange Daten vorhanden
        //US: Print loop. Repeat while there is still data to print
        while (!ADOTblCustomers->Eof) {

                //D:  Jetzt Echtdaten für aktuellen Datensatz übergeben
                //US: pass data for current record
                DefineCurrentRecord(false);

                //D:  Ein Etikett ausdrucken
                //US: Print one label
                Ret = LL->LlPrint();
				while (Ret==LL_WRN_REPEAT_DATA)
					Ret = LL->LlPrint();

                if (Ret==LL_ERR_USER_ABORTED) {
                        LL->LlPrintEnd(0);
                        return;
                }

                //D:  Fortschrittsanzeige aktualisieren
                //US: Refresh progress meter
                LL->LlPrintSetBoxText("Printing label...",(double)ADOTblCustomers->RecNo/ADOTblCustomers->RecordCount*100);

                //D:  Zum nächsten Datensatz wechseln
                //US: Skip to next record
                ADOTblCustomers->Next();
        }

        //D:  Druck beenden}
        //US: Stop printing}
        LL->LlPrintEnd(0);

}
//---------------------------------------------------------------------------
void __fastcall TfrmPrtloop::Report1Click(TObject* /*Sender*/)
{
        String FileName = "simple.lst";
        ADOTblCustomers->First();

        //D: Dateiauswahldialog. Aufruf ist optional, sonst einfach on FileName den
        //gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
        //sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
        //US: Optional call to file selection dialog. Ommit this call and pass the
        //required file as FileName if you don´t want the dialog to appear. If only
        //existing files should be selctable, remove the "or"ing with LL_FILE_ALSONEW
        if (LL->LlSelectFileDlg((UINT)this->Handle,LL_PROJECT_LIST|LL_FILE_ALSONEW,FileName) != LL_ERR_USER_ABORTED)
        {
                //D: Daten definieren
                //US: Define data
				DefineCurrentRecord(true);

                //D: Designer mit dem Titel 'Design label' und der gewählten Datei starten
                //US: Opens the chosen file in the designer, sets designer title to 'Design label'
                LL->LlDefineLayout((UINT)this->Handle,"Design report",LL_PROJECT_LIST,FileName);
        }

}
//---------------------------------------------------------------------------
void __fastcall TfrmPrtloop::Report2Click(TObject* /*Sender*/)
{
        String FileName = "simple.lst";
        int Ret;

        ADOTblCustomers->First();

        //D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
        //    gewünschten Dateinamen übergeben.
        //US: Optional call to file selection dialog. Ommit this call and pass the
        //    required file as FileName if you don't want the dialog to appear.
        if (LL->LlSelectFileDlg((UINT)this->Handle,LL_PROJECT_LIST,FileName)==LL_ERR_USER_ABORTED) {
                return;
        }

        //D:  Daten definieren. Die hier übergebenen Daten dienen nur der Syntaxprüfung - die Inhalte
        //    brauchen keine Echtdaten zu enthalten
        //US: Define data. The data passed here is only used for syntax checking and doesn't need
        //    to contain real data
        DefineCurrentRecord(true);

        //D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.
        //US: Start print job. Allow all export formats as target. Meter box with cancel button.
        Ret = LL->LlPrintWithBoxStart(LL_PROJECT_LIST,FileName,LL_PRINT_EXPORT,LL_BOXTYPE_STDABORT,(UINT)this->Handle,"Printink label...");

        //D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).
        //{US: Most frequent cause for error code: -23 (Sytax Error).
        if (Ret != 0) {
                ShowMessage("Error during LlPrintWithBoxStart");
                return;
        }

        //D:  Druckoptionsdialog. Aufruf ist optional, es können sonst Ausgabeziel und
        //    Exportdateiname über LlXSetParameter() gesetzt werden bzw. der Drucker und
        //    die Druckoptionen über LlSetPrinterInPrinterFile() vorgegeben werden.
        //US: Optional call to print options dialog. You may also set the print target format
        //    and export file name using LlXSetParameter() or set the printer and print options
        //    using LlSetPrinterInPrinterFile()
        if (LL->LlPrintOptionsDialog((UINT)this->Handle,"Choose printing options")==LL_ERR_USER_ABORTED) {
                LL->LlPrintEnd(0);
                return;
        }

        //D:  Erste Seite initialisieren; auch hier kann schon durch Objekte vor der Tabelle
        //    ein Seitenumbruch ausgelöst werden
        //US: Initialize first page. A page wrap may occur already caused by objects which are
        //    printed before the table
        Ret = LL->LlPrint();
        while (Ret==LL_WRN_REPEAT_DATA)
                Ret = LL->LlPrint();

        //D:  Eigentliche Druckschleife; Wiederholung, solange Daten vorhanden
        //US: Print loop. Repeat while there is still data to print
        while (!ADOTblCustomers->Eof) {

                //D:  Jetzt Echtdaten für aktuellen Datensatz übergeben
                //US: pass data for current record
                DefineCurrentRecord(true);

               //D:  Tabellenzeile ausgeben, auf Rückgabewert prüfen und ggf. Seitenumbruch
               //    oder Abbruch auslösen
               //US: Print table line, check return value and abort printing or wrap pages
               //if neccessary
                Ret = LL->LlPrintFields();
                if (Ret==LL_ERR_USER_ABORTED) {
                        LL->LlPrintEnd(0);
                        return;
                }

                //D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
                //US: Wrap pages until record was fully printed
                while (Ret==LL_WRN_REPEAT_DATA) {
                        LL->LlPrint();
                        Ret = LL->LlPrintFields();
                }

                //D:  Fortschrittsanzeige aktualisieren
                //US: Refresh progress meter
                LL->LlPrintSetBoxText("Printing label...",(double)ADOTblCustomers->RecNo/ADOTblCustomers->RecordCount*100);

                //D:  Zum nächsten Datensatz wechseln
                //US: Skip to next record
                ADOTblCustomers->Next();
        }

        //D:  Druck der Tabelle beenden, angehängte Objekte drucken
        //US: Finish printing the table, print linked objects
        Ret = LL->LlPrintFieldsEnd();
        while (Ret==LL_WRN_REPEAT_DATA)
                Ret = LL->LlPrintFieldsEnd();
                
        //D:  Druck beenden}
        //US: Stop printing}
        LL->LlPrintEnd(0);

}
//---------------------------------------------------------------------------
void __fastcall TfrmPrtloop::FormCreate(TObject* /*Sender*/)
{
  //D: Pfad setzen und Datenbankpfad auslesen
  //US: Set path and read database path
  SetCurrentDir(ExtractFilePath(Application->ExeName));


  String dbPath;
  TRegistry *reg = new TRegistry;

  try
  {
	reg->RootKey = HKEY_CURRENT_USER;
	if (reg->OpenKey("Software\\combit\\cmbtll",false)) {
	  dbPath = reg->ReadString("NWINDPath");
	}
	else ShowMessage("Unable to find sample database. Make sure List & Label is installed correctly.");
  }
  __finally
  {
   reg->CloseKey();
  }


 if (dbPath == "") {
	ShowMessage("Unable to find sample database. Make sure List & Label is installed correctly.");
 } else
 {
	if (!ADOConnection1->Connected) {
		ADOConnection1->ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=" + dbPath + ";Mode=Share Deny None;Extended Properties="";Jet OLEDB:Engine Type=4;";
		ADOConnection1->Connected = true;
		ADOTblCustomers->Active = true;
	}
 }

}
//---------------------------------------------------------------------------

void __fastcall TfrmPrtloop::Exit1Click(TObject* /*Sender*/)
{
	this->Close();
}
//---------------------------------------------------------------------------


/*=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : simplefm.pas, simplefm.dfm, simple.dpr
 Module : simple label sample
 Descr. : D:   Dieses Beispiel demonstriert das Designen und Drucken von Etiketten.
          US: This example demonstrates how to design and print labels.
======================================================================================*/

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "simplefm.h"
#include <dir.h>
#include <math.h>
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "L27"
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::DesignButtonClick(TObject* /*Sender*/)
{
     //D:   Zum ersten Datensatz wechseln
     //US: Move to first record
     DataSource->First();

     //D:   Designer mit dem Titel "Design Label" und der Datei simple.lbl starten
     //US: Opens simple.lbl in the designer, sets designer title to 'Design Label'
     LL->Design(0,(UINT)this->Handle,"Design Label", LL_PROJECT_LABEL,
        "Simple.lbl",true, true);


}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject* /*Sender*/)
{
	TString tmp;
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
			  DataFilePath = tmp + "C++ Builder\\";
			else
			  DataFilePath = tmp + "\\C++ Builder\\";

			DataFileName = "article.dbf";

			pRegistry->CloseKey();

			if(FileExists(DataFilePath + DataFileName))
			{
				//D:   Lade die Datenbanken, fange Fehler ab
				//US: Load the databases, check for errors
				try
				{
					DataSource->Active = false;
					DataSource->DatabaseName = DataFilePath;
					DataSource->TableName = DataFileName;
					DataSource->Active = true;

					// D:  Setze Dateipfad für LL Projektdateien }
					// US: Set path fo LL project files}
					CurPath = DataFilePath + ChangeFileExt(ExtractFileName((Application->ExeName)), "") + '\\';
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
}
//---------------------------------------------------------------------------

void __fastcall TForm1::LLDefineVariables(TObject* /*Sender*/, int /*UserData*/,
      bool IsDesignMode, int& Percentage, bool& IsLastRecord,
	  int& /*EventResult*/)
{

        //D:   Dieser Event wird von den List & Label - Befehlen design und print
        //ausgelöst. Er wird für jeden Datensatz aufgerufen, um die Variablen
        //und deren Inhalt an List & Label zu übergeben.

        //US: This event is called by the List & Label methods design and print.
        //It gets called once per record to define the variables and their
        //contents.


        int i;
        long FieldType;
        String FieldName;
        String FieldContent;

        //D:   Wiederholung für alle Datensatzfelder
        //US: Loop through all fields in the present recordset
        for(i= 0; i <= (DataSource->FieldCount-1); i++)
        {

                //D:   Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen
                //US: Transform database field types into List & Label field types
                TField* Field = DataSource->Fields->Fields[i];
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
                        //US: transform delphi date type into List & Label
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
                LL->LlDefineVariableExt(FieldName,FieldContent,FieldType);

        }

        //D:   Werden Echt-Daten benötigt (nicht bei Designer-Aufruf)
        //US: Is real data needed (not when method design has been called)
        if(!IsDesignMode)
        {
                //D:   Prozentanzeige aktualisieren und zu nächsten Datensatz wechseln
                //US: Set percentage value for meter info and move to next record
                Percentage=floor(DataSource->RecNo/DataSource->RecordCount*100);
                DataSource->Next();

                //D:   Druck beenden, wenn kein weiterer Datensatz vorhanden ist
                //US: End printing if last record is reached
                if(DataSource->Eof)
                {
                        IsLastRecord=true;
                }
        }

}
//---------------------------------------------------------------------------

void __fastcall TForm1::PreviewButtonClick(TObject* /*Sender*/)
{
        //D:   Zum ersten Datensatz wechseln
        //US: Move to first record
        DataSource->First();

        //D:   Projekt 'Simple.lbl als Vorschau ausdrucken
        //US: Print project 'Simple.lbl' to preview
        LL->Print(0,LL_PROJECT_LABEL,"Simple.lbl",true,LL_PRINT_PREVIEW,
        LL_BOXTYPE_STDWAIT,(UINT)this->Handle,"Print labels to preview", true, "");
}
//---------------------------------------------------------------------------

void __fastcall TForm1::PrintButtonClick(TObject* /*Sender*/)
{
        //D:   Zum ersten Datensatz wechseln
        //US: Move to first record
        DataSource->First();

        //D:   Projekt 'Simple.lbl auf Drucker/Export ausdrucken
        //US: Print project 'Simple.lbl' to printer/export
        LL->Print(0,LL_PROJECT_LABEL,"Simple.lbl",true,LL_PRINT_EXPORT,
        LL_BOXTYPE_STDWAIT,(UINT)this->Handle,"Print labels to printer", true,"");
}
//---------------------------------------------------------------------------

void __fastcall TForm1::DebugCheckBoxClick(TObject* /*Sender*/)
{
        //D:   (De)aktiviert Debug-Ausgaben
        //US: enables or disables debug output

        if(DebugCheckBox->Checked)
        {
                LL->DebugMode=1;
                MessageDlg("D:   DEBWIN muss zur Anzeige von Debugausgaben werden\nUS: Start DEBWIN to receive debug messages",
                mtInformation,TMsgDlgButtons() << mbOK,0);
        }
        else
        {
                LL->DebugMode=0;
        }
}
//---------------------------------------------------------------------------


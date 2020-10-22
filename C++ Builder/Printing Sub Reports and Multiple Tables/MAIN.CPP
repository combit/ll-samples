//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "DataModule.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "L26"
#pragma resource "*.dfm"
TFrmMultipleTables *FrmMultipleTables;

// Table Map Helper Class implementation

void TMyTableMap::AddTable(String Key, TADOTable* Value)
{
        int Pos=FKeyList->IndexOf(Key);
        if (Pos!=-1)
        {
          FKeyList->Delete(Pos);
          FValueList->Delete(Pos);
          FKeyFieldList->Delete(Pos);
        }
        FKeyList->Add(Key);
        FValueList->Add(Value);
        FKeyFieldList->Add(Value->IndexFieldNames);
}

TMyTableMap::TMyTableMap()
        : TObject()
{
        FKeyList=new(TStringList);
        FKeyFieldList=new(TStringList);
        FValueList=new(TList);
}

__fastcall TMyTableMap::~TMyTableMap()
{
        FKeyList->Free();
        FValueList->Free();
        FKeyFieldList->Free();
}

bool TMyTableMap::GetKeyField(String Key, String& KeyField)
{
        int Pos = FKeyList->IndexOf(Key);
        if (Pos==-1)
        {
                KeyField="";
                return(false);
        }
		KeyField=FKeyFieldList->Strings[Pos];
        return(true);
}

bool TMyTableMap::GetTable(String Key, TADOTable** Value)
{
        int Pos = FKeyList->IndexOf(Key);
        if (Pos==-1)
        {
                Value=NULL;
                return(false);
        }
        *Value=(TADOTable*)FValueList->Items[Pos];
        return(true);
}

//---------------------------------------------------------------------------
__fastcall TFrmMultipleTables::TFrmMultipleTables(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void TFrmMultipleTables::PassDataStructure()
{
        //D:  Zuerst alle Tabellen anmelden...
        //US: At first declare all tables...
        for (int i=0; i<DataModule1->ADOConnection1->DataSetCount; i++)
        {
                TADOTable* Table = (TADOTable*)DataModule1->ADOConnection1->DataSets[i];
                LL->LlDbAddTable(Table->TableName, "");
                //D:  ...dann die Felder der Tabellen...
                //US: ...then the fields of the tables...
				DefineCurrentRecord("", Table, true);
        }

        //D:  ...dann die Relationen zwischen den Tabellen...}
		//US: ... then the relation between the tables...}
		
		// since XE7: System::Generics::Collections::TList__1<TDataSet*>* FList = new (System::Generics::Collections::TList__1<TDataSet*>);
		TList* FList = new(TList);
        for (int i=0; i<DataModule1->ADOConnection1->DataSetCount; i++)
		{
				TADOTable* Table = (TADOTable*)DataModule1->ADOConnection1->DataSets[i];
				Table->GetDetailDataSets(FList);
                if (FList->Count > 0)
                {
                      LL->LlDbAddTableRelation(((TADOTable*)FList->Items[0])->TableName,
                                      Table->TableName,
                                      Table->TableName+"2"+((TADOTable*)FList->Items[0])->TableName,
                                      "");
                     //D:  ...und zum Schluss die Sortierung
                     //US: ...and at the end the sorting
                    for (int j=0; j<Table->FieldCount;j++)
                    {
                        LL->LlDbAddTableSortOrder(Table->TableName,
                                Table->Fields->Fields[j]->FieldName + " ASC", Table->Fields->Fields[j]->FieldName + " [+]");
                        LL->LlDbAddTableSortOrder(Table->TableName,
                                Table->Fields->Fields[j]->FieldName + " DESC", Table->Fields->Fields[j]->FieldName + " [-]");

                    }
                }
        }
        FList->Free();
}
void TFrmMultipleTables::DefineCurrentRecord(String Prefix, TADOTable* Table, bool AsField)
{
        for (int i=0; i<Table->FieldCount;i++)
        {
                //D:  Für den Designer werden alle Felder übergeben
                //US: For the Designer will all fields transfered
                if (!bIsPrinting)
                {
                        //D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen
                        //US: Transform database field types into List & Label field types
                        if (Prefix=="" || Table->Fields->Fields[i]->FieldName.Pos("@") <= 0)
                        {
                                if (AsField)
                                        if (Prefix!="")
                                                LL->LlDefineFieldFromTFieldExt(Prefix,Table->Fields->Fields[i]);
                                        else
                                                LL->LlDefineFieldFromTFieldExt(Table->TableName,Table->Fields->Fields[i]);
                                else
                                        LL->LlDefineVariableFromTFieldExt(Table->TableName,Table->Fields->Fields[i]);
                        }
                }
                else
                {
                        //D:  Zur Druckzeit werden nur die benötigten Felder und Variablen übergeben
                        //US: For print time only the needed fields and variables will be transfered
                        //D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen
                        //US: Transform database field types into List & Label field types
                        if (Prefix=="" || Table->Fields->Fields[i]->FieldName.Pos("@") <= 0)
                        {
                                if (AsField && (LL->LlPrintIsFieldUsed(Table->TableName+"."+Table->Fields->Fields[i]->FieldName) > 0))
                                    LL->LlDefineFieldFromTFieldExt(Table->TableName,Table->Fields->Fields[i]);
                                else if (LL->LlPrintIsVariableUsed(Table->TableName+"."+Table->Fields->Fields[i]->FieldName) > 0)
                                    LL->LlDefineVariableFromTFieldExt(Table->TableName,Table->Fields->Fields[i]);
                        }

                }
        }
        //D:  Übergabe aller Felder evtl. 1:1-Relation
        //US: Pass all 1:1-Relation fields
        if (Table->MasterSource)
        {
                String MasterSourceName = ((TADOTable*)(Table->MasterSource->DataSet))->TableName;
                for (int i=0; i<DataModule1->ComponentCount;i++)
                {
                        {
                                TADOTable* MasterTable =dynamic_cast<TADOTable*>(DataModule1->Components[i]);
                                if (MasterTable)
                                {
                                        if (MasterTable->TableName == MasterSourceName)
                                        {
                                                String KeyField="";
                                                FMapper->GetKeyField(Table->TableName, KeyField);
                                                String ChildPrefix=Prefix+Table->TableName+"."+KeyField+"@"+MasterTable->TableName+"."+Table->MasterFields+":";
                                                if (!bIsPrinting)
                                                        DefineCurrentRecord(ChildPrefix, MasterTable,true);
                                                else
                                                        //D:  Nur wenn Tabelle auch im Layout benutzt wird, Felder übergeben
                                                        //US: If and only if the table is used in the layout delivery of the fields
                                                        if (LL->LlPrintIsFieldUsed(ChildPrefix+"*") > 0)
                                                                DefineCurrentRecord(ChildPrefix, MasterTable,true);
                                        }
                                }
                        }
                        
                 }
        }

}

int TFrmMultipleTables::PrintDataView(TADOTable* Table, int Level, int CurrentTableNo)
{
        int nRet=0;

        Table->First();
        int MaxPercentage = 100/LL->LlPrintDbGetRootTableCount();

        //D:  Sortierung der aktuellen Tabelle bestimmen
        //US: Determine the sort order of the current table
        String SortOrder="";
        LL->LlPrintDbGetCurrentTableSortOrder(SortOrder);
        Table->Sort=SortOrder;

        for (int i =0; i<Table->RecordCount;i++)
        {
                DefineCurrentRecord("", Table, true);

                int nRet=LL->LlPrintFields();

                //D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
                //US: Wrap pages until record was fully printed}
                while (nRet==LL_WRN_REPEAT_DATA)
                {
                        LL->LlPrint();
                        nRet=LL->LlPrintFields();
                }

                //D:  Tabellenwechsel und Rekursion beginnen
                //US: Change of table begin recursion}
                while (nRet==LL_WRN_TABLECHANGE)
                {
                        String TableName = "";
                        LL->LlPrintDbGetCurrentTable(TableName, false);
                        FMapper->GetTable(TableName, &FTable);
                        nRet=PrintDataView(FTable, Level + 1, 0);
                }

                //D: Aktualisierung der Fortschrittsanzeige wenn Root-Datensatz gedruckt wird
                //US: If a root record is printed update the progress bar }
                if (Level==0)
                {
                        int Percentage=MaxPercentage*(CurrentTableNo-1)+(int)(((double)i/Table->RecordCount)*MaxPercentage);
                        LL->LlPrintSetBoxText("Printing report...",Percentage);
                }
                Table->Next();
        }

        nRet=LL->LlPrintFieldsEnd();

        //D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
        //US: Wrap pages until record was fully printed}
        while (nRet==LL_WRN_REPEAT_DATA)
                nRet=LL->LlPrintFieldsEnd();

        Table->Sort="";
        return(nRet);
}


void __fastcall TFrmMultipleTables::FormCreate(TObject* /*Sender*/)
{
        FMapper=new(TMyTableMap);
        FTable=NULL;
        bIsPrinting=false;

        //D:  Tabellen mappen und evtl. Fehler abfangen
        //US: Map table and checks for errors
        try
        {
                for (int i=0; i<DataModule1->ADOConnection1->DataSetCount;i++)
                {
                        TADOTable* Table=(TADOTable*)DataModule1->ADOConnection1->DataSets[i];
                        if (Table)
                                FMapper->AddTable(Table->TableName, Table);
                }
        }
        catch (Exception &E)
        {
                ShowMessage("D:   Beispiel-Datenbank nicht gefunden.\nUS: Test database not found.");
        }
}
//---------------------------------------------------------------------------

void __fastcall TFrmMultipleTables::FormClose(TObject* /*Sender*/,
	  TCloseAction& /*Action*/)
{
        FMapper->Free();
}
//---------------------------------------------------------------------------

void __fastcall TFrmMultipleTables::Report1Click(TObject* /*Sender*/)
{
        String FileName="subrep.lst";
        /*D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
            gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
            sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
         US: Optional call to file selection dialog. Ommit this call and pass the
            required file as FileName if you don't want the dialog to appear. If only
            existing files should be selectable, remove the "or"ing with LL_FILE_ALSONEW */
        if ((LL->LlSelectFileDlgTitle((UINT)this->Handle, "Choose report file", LL_PROJECT_LIST|LL_FILE_ALSONEW, FileName))!=LL_ERR_USER_ABORTED)
        {
            PassDataStructure();
            //D:  Designer mit dem Titel 'Design report' und der gewählten Datei starten
            //US: Opens the chosen file in the designer, sets designer title to 'Design report'
            LL->LlDefineLayout((UINT)this->Handle, "Design report", LL_PROJECT_LIST, FileName);

        }
}
//---------------------------------------------------------------------------

void __fastcall TFrmMultipleTables::Report2Click(TObject* /*Sender*/)
{
        String FileName = "subrep.lst";
        int nRet = 0;
        String TableName="";
        String SortOrder="";        


        /*D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
            gewünschten Dateinamen übergeben.
        US: Optional call to file selection dialog. Ommit this call and pass the
            required file as FileName if you don't want the dialog to appear. */
        nRet=LL->LlSelectFileDlg((UINT)this->Handle, LL_PROJECT_LIST, FileName);

        //GR: Wenn Benutzer Abbrechen wählt Druck abbrechen
        //US: Abort printing if user selected cancel
        if(nRet==LL_ERR_USER_ABORTED)
        {
                return;
        }

        /*D:  Daten definieren. Die hier übergebenen Daten dienen nur der Syntaxprüfung - die Inhalte
          brauchen keine Echtdaten zu enthalten
         US: Define data. The data passed here is only used for syntax checking and doesn't need
          to contain real data  */
        PassDataStructure();

        /*D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.
          US: Start print job. Allow all export formats as target. Meter box with cancel button.*/
        nRet=LL->LlPrintWithBoxStart(LL_PROJECT_LIST, FileName, LL_PRINT_EXPORT, LL_BOXTYPE_STDABORT,
           (UINT)this->Handle, "Printing report...");

        /*D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).
         US: Most frequent cause for error code: -23 (Sytax Error).*/
        if (nRet!=0)
        {
            ShowMessage("Error during LlPrintWithBoxStart");
            return;
        }

     /*D:  Druckoptionsdialog. Aufruf ist optional, es können sonst Ausgabeziel und
          Exportdateiname über LlXSetParameter() gesetzt werden bzw. der Drucker und
          die Druckoptionen über LlSetPrinterInPrinterFile() vorgegeben werden.
       US: Optional call to print options dialog. You may also set the print target format
          and export file name using LlXSetParameter() or set the printer and print options
          using LlSetPrinterInPrinterFile()*/
        nRet=LL->LlPrintOptionsDialog((UINT)this->ClientHandle, "Configure printing parameters");

        //GR: Wenn Benutzer Abbrechen wählt Druck abbrechen
        //US: Abort printing if user selected cancel
        if(nRet==LL_ERR_USER_ABORTED)
        {
                return;
        }

        /*D:  Erste Seite initialisieren; auch hier kann schon durch Objekte vor der Tabelle
             ein Seitenumbruch ausgelöst werden
         US: Initialize first page. A page wrap may occur already caused by objects which are
             printed before the table*/
        while (LL->LlPrint()==LL_WRN_REPEAT_DATA);

        /*D:  Root-Tabelle bestimmen und solange drucken bis keine mehr vorhanden
         US: determine root table and print until no one is available*/
        bIsPrinting=true;
        do
        {
                LL->LlPrintDbGetCurrentTable(TableName, false);
                FMapper->GetTable(TableName, &FTable);
                FTable->Sort="";
                LL->LlPrintDbGetCurrentTableSortOrder(SortOrder);
                FTable->Sort=SortOrder;
        }
        while(PrintDataView(FTable, 0, 1)==LL_WRN_TABLECHANGE);

        //D:  Druck beenden}
        //US: Stop printing}
        LL->LlPrintEnd(0);
        bIsPrinting=false;
}
//---------------------------------------------------------------------------

void __fastcall TFrmMultipleTables::Exit1Click(TObject* /*Sender*/)
{
	this->Close();
}
//---------------------------------------------------------------------------



//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataModule.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TDataModule1 *DataModule1;
//---------------------------------------------------------------------------
__fastcall TDataModule1::TDataModule1(TComponent* Owner)
        : TDataModule(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TDataModule1::DataModuleCreate(TObject* /*Sender*/)
{
        //D:  ADO Verbidnungsinformationen  setzen
        //US: Specifies the connection information for the data store }
        ADOConnection1->ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\NWIND.MDB;Persist Security Info=False";

        //D:  Lade die Datenbank, fange Fehler ab  }
        //US: Load the database, checks for errors }
        try
        {
                ADOConnection1->Connected = true;

	        Customers->Filter= "CustomerID<"+ QuotedStr("D");
        	Customers->Filtered=true;


                for (int i=0; i<ADOConnection1->DataSetCount; i++)
                        ADOConnection1->DataSets[i]->Active=true;
        }
        catch (EADOError &e)
        {
                ShowMessage("D:  Beispiel-Datenbank nicht gefunden\nUS: Test database not found");
        }


}
//---------------------------------------------------------------------------
void __fastcall TDataModule1::DataModuleDestroy(TObject* /*Sender*/)
{
        for (int i=0; i<ADOConnection1->DataSetCount; i++)
                ADOConnection1->DataSets[i]->Active=false;

        ADOConnection1->Connected = false;
}
//---------------------------------------------------------------------------

/*=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : uDatabind.cpp, uDatabind.h, Databind.dpr
 Module : databind sample
 Descr. : D:   Dieses Beispiel demonstriert die Verwendung des datengebundenen Constrols
          US: This example demonstrates the usage of the data bound control
======================================================================================*/

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "uCrosstab.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "L25"
#pragma link "L25db"
#pragma resource "*.dfm"
TfrmCrosstab *frmCrosstab;
//---------------------------------------------------------------------------
__fastcall TfrmCrosstab::TfrmCrosstab(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmCrosstab::btnDesignILClick(TObject* /*Sender*/)
{
	DBL25_1->AutoDesign("Sales Report");
}
//---------------------------------------------------------------------------
void __fastcall TfrmCrosstab::btnPrintILClick(TObject* /*Sender*/)
{
	DBL25_1->AutoPrint("Sales Report", "");
}
//-------------------------------------------------------------------------
void __fastcall TfrmCrosstab::FormCreate(TObject* /*Sender*/)
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
		ADOTblOrders->Active = true;
		ADOTblOrderDetails->Active = true;
	}

 }

}
//-------------------------------------------------------------

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include <Vcl.Dialogs.hpp>
#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "ListLabel29"
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::btnDesignInvoiceAndItemsListClick(TObject *Sender)
{
  ListLabelInvoiceList->DataController->AutoMasterMode = mmAsFields;
  ListLabelInvoiceList->DataController->DataMember = "";
  ListLabelInvoiceList->AutoProjectFile = "..\\..\\inv_lst.lst";
  ListLabelInvoiceList->Design();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::btnPrintInvoiceAndItemsListClick(TObject *Sender)
{
  ListLabelInvoiceList->DataController->AutoMasterMode = mmAsFields;
  ListLabelInvoiceList->DataController->DataMember = "";
  ListLabelInvoiceList->AutoProjectFile = "..\\..\\inv_lst.lst";
  ListLabelInvoiceList->Print();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::btnDesignInvoiceMergeClick(TObject *Sender)
{
  ListLabelInvoiceMerge->DataController->AutoMasterMode = mmAsVariables;
  ListLabelInvoiceMerge->DataController->DataMember = "Orders";
  ListLabelInvoiceMerge->AutoProjectFile = "..\\..\\inv_merg.lst";
  ListLabelInvoiceMerge->Design();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::btnPrintInvoiceMergeClick(TObject *Sender)
{
  ListLabelInvoiceMerge->DataController->AutoMasterMode = mmAsVariables;
  ListLabelInvoiceMerge->DataController->DataMember = "Orders";
  ListLabelInvoiceMerge->AutoProjectFile = "..\\..\\inv_merg.lst";
  ListLabelInvoiceMerge->Print();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate( TObject* Sender )
{
  String NWindDatabasePath;

  bool Error = false;
  String  ErrorMessage;
  Error = false;
  ErrorMessage = "Unable to find sample database. Make sure List & Label is installed correctly.";
  TRegistry *Registry = new TRegistry;
  Registry->RootKey = HKEY_CURRENT_USER;
  if ( Registry->OpenKey( "Software\\combit\\cmbtll", true) )
  {
	NWindDatabasePath = Registry->ReadString( "NWINDPath" );
	if ( FileExists( NWindDatabasePath ) )
    {
      try
	  {
		FDConnectionNorthwind->Connected = false;
		FDConnectionNorthwind->Params->Database = NWindDatabasePath;
		FDConnectionNorthwind->Connected = true;
	  }
	  catch( Exception& Ecx )
	  {
	  {
		Error = true;
		ErrorMessage =  "Unable to find sample database. Make sure List & Label is installed correctly.\n Error raised, with message:\n " + Ecx.Message;
	  }
	  }
	Registry->CloseKey();
	}
	else
	{
	  Error = true;
	}

  }
  else
  {
	Error = true;
  }

  Registry->Free();
  if ( Error )
  {

	MessageDlg(ErrorMessage,mtError,TMsgDlgButtons() << mbOK ,0);   
	btnDesignInvoiceMerge->Enabled = false;
	btnPrintInvoiceMerge->Enabled = false;
	btnDesignInvoiceAndItemsList->Enabled = false;
	btnPrintInvoiceAndItemsList->Enabled = false;
  }
}
//---------------------------------------------------------------------------


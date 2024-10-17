//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include "ListLabel30.hpp"
#include <Data.DB.hpp>
#include <FireDAC.Comp.Client.hpp>
#include <FireDAC.Phys.hpp>
#include <FireDAC.Phys.Intf.hpp>
#include <FireDAC.Phys.MSAcc.hpp>
#include <FireDAC.Phys.MSAccDef.hpp>
#include <FireDAC.Stan.Async.hpp>
#include <FireDAC.Stan.Def.hpp>
#include <FireDAC.Stan.Error.hpp>
#include <FireDAC.Stan.Intf.hpp>
#include <FireDAC.Stan.Option.hpp>
#include <FireDAC.Stan.Pool.hpp>
#include <FireDAC.UI.Intf.hpp>
#include <FireDAC.VCLUI.Wait.hpp>
#include <FireDAC.Comp.DataSet.hpp>
#include <FireDAC.DApt.hpp>
#include <FireDAC.DApt.Intf.hpp>
#include <FireDAC.DatS.hpp>
#include <FireDAC.Stan.Param.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// Von der IDE verwaltete Komponenten
	TLabel *lblEnglish;
	TLabel *lblGerman;
	TLabel *lblGermanDescription;
	TLabel *lblEnglishDescription;
	TGroupBox *groupInvoiceMerge;
	TButton *btnDesignInvoiceMerge;
	TButton *btnPrintInvoiceMerge;
	TGroupBox *groupInvoiceAndItemsList;
	TButton *btnDesignInvoiceAndItemsList;
	TButton *btnPrintInvoiceAndItemsList;
	TFDConnection *FDConnectionNorthwind;
	TFDQuery *FDQueryOrders;
	TFDQuery *FDQueryOrderDetails;
	TDataSource *DataSourceOrders;
	TDataSource *DataSourceOrderDetails;
	TListLabel30 *ListLabelInvoiceList;
	TListLabel30 *ListLabelInvoiceMerge;
	void __fastcall btnDesignInvoiceAndItemsListClick(TObject *Sender);
	void __fastcall btnPrintInvoiceAndItemsListClick(TObject *Sender);
	void __fastcall btnDesignInvoiceMergeClick(TObject *Sender);
	void __fastcall btnPrintInvoiceMergeClick(TObject *Sender);
	void __fastcall FormCreate(TObject *Sender);
private:	// Benutzer-Deklarationen
public:		// Benutzer-Deklarationen
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif

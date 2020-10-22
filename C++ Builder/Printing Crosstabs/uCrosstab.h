//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ADODB.hpp>
#include <DB.hpp>
#include <Registry.hpp>
#include "L26.hpp"
#include "L26db.hpp"
//---------------------------------------------------------------------------
class TfrmCrosstab : public TForm
{
__published:	// IDE-managed Components
	TADOConnection *ADOConnection1;
	TADOTable *ADOTblCustomers;
	TADOTable *ADOTblOrders;
	TADOTable *ADOTblOrderDetails;
	TDataSource *dsCustomers;
	TDataSource *dsOrders;
	TDBL26_ *DBL26_1;
	TLabel *Label1;
	TLabel *Label2;
	TLabel *Label3;
	TLabel *Label4;
        TButton *btnPrintIL;
        TButton *btnDesignIL;
	void __fastcall btnDesignILClick(TObject *Sender);
	void __fastcall btnPrintILClick(TObject *Sender);
	void __fastcall FormCreate(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TfrmCrosstab(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmCrosstab *frmCrosstab;
//---------------------------------------------------------------------------
#endif

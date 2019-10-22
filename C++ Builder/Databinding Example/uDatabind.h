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
#include "L25.hpp"
#include "L25db.hpp"
//---------------------------------------------------------------------------
class TfrmDatbind : public TForm
{
__published:	// IDE-managed Components
	TADOConnection *ADOConnection1;
	TADOTable *ADOTblCustomers;
	TADOTable *ADOTblOrders;
	TADOTable *ADOTblOrderDetails;
	TADOTable *ADOTblProducts;
	TDataSource *dsCustomers;
	TDataSource *dsOrders;
	TDataSource *dsOrderDetails;
	TDBL25_ *DBL25_1;
	TDBL25_ *DBL25_2;
	TGroupBox *GroupBox1;
	TButton *btnDesignIL;
	TButton *btnPrintIL;
	TGroupBox *GroupBox2;
	TButton *btnDesignIIL;
	TButton *btnPrintIIL;
	TLabel *Label1;
	TLabel *Label2;
	TLabel *Label3;
	TLabel *Label4;
	void __fastcall btnDesignILClick(TObject *Sender);
	void __fastcall btnPrintILClick(TObject *Sender);
	void __fastcall btnDesignIILClick(TObject *Sender);
	void __fastcall btnPrintIILClick(TObject *Sender);
	void __fastcall FormCreate(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TfrmDatbind(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmDatbind *frmDatbind;
//---------------------------------------------------------------------------
#endif

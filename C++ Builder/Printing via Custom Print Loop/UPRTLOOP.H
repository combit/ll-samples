//---------------------------------------------------------------------------

#ifndef uPrtloopH
#define uPrtloopH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Menus.hpp>
#include <DB.hpp>
#include <DBTables.hpp>
#include <ADODB.hpp>
#include <Registry.hpp>
#include "L26.hpp"
//---------------------------------------------------------------------------
class TfrmPrtloop : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TCheckBox *DebugCheckBox;
        TMainMenu *MainMenu1;
        TMenuItem *File1;
        TMenuItem *Edit1;
        TMenuItem *Print1;
        TMenuItem *Exit1;
        TMenuItem *Label5;
        TMenuItem *Report1;
        TMenuItem *Label6;
        TMenuItem *Report2;
        TADOConnection *ADOConnection1;
        TADOTable *ADOTblCustomers;
        TL26_ *LL;
        void __fastcall Label5Click(TObject *Sender);
        void __fastcall DebugCheckBoxClick(TObject *Sender);
        void __fastcall Label6Click(TObject *Sender);
        void __fastcall Report1Click(TObject *Sender);
        void __fastcall Report2Click(TObject *Sender);
	void __fastcall FormCreate(TObject *Sender);
	void __fastcall Exit1Click(TObject *Sender);
private:	// User declarations
        void DefineCurrentRecord(bool AsFields);
public:		// User declarations
        __fastcall TfrmPrtloop(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmPrtloop *frmPrtloop;
//---------------------------------------------------------------------------
#endif

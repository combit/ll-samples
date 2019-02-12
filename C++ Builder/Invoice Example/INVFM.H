//---------------------------------------------------------------------------

#ifndef invfmH
#define invfmH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Db.hpp>
#include <DBTables.hpp>
#include "L24.hpp"
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TListBox *InvoiceList;
        TButton *DesignButton;
        TButton *PreviewButton;
        TButton *PrintButton;
        TCheckBox *DebugCheckBox;
        TTable *InvoiceTable;
        TTable *ItemsTable;
        TL24_ *LL;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall DesignButtonClick(TObject *Sender);
        void __fastcall PreviewButtonClick(TObject *Sender);
        void __fastcall PrintButtonClick(TObject *Sender);
        void __fastcall DebugCheckBoxClick(TObject *Sender);
private:
        String CurPath, DataFilePath, InvoiceName, ItemsName;
        int RecNo;

 public:		// User declarations
        __fastcall TForm1(TComponent* Owner);
        GetInvoiceNo();
        DefineVars();
        DefineFields();
        PrintInvoice(int PrintMode);

};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif

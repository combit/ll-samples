//---------------------------------------------------------------------------

#ifndef Simple2fmH
#define Simple2fmH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Db.hpp>
#include <DBTables.hpp>
#include "L27.hpp"

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
        TButton *DesignButton;
        TButton *PreviewButton;
        TButton *PrintButton;
        TCheckBox *DebugCheckBox;
        TTable *DataSource;
        TL27_ *LL;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall DesignButtonClick(TObject *Sender);
        void __fastcall PreviewButtonClick(TObject *Sender);
        void __fastcall PrintButtonClick(TObject *Sender);
        void __fastcall DebugCheckBoxClick(TObject *Sender);
        void __fastcall LLDefineFields(TObject *Sender, int UserData,
          bool IsDesignMode, int &Percentage, bool &IsLastRecord,
          int &EventResult);
private:	// User declarations
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif

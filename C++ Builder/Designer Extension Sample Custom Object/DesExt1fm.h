//---------------------------------------------------------------------------

#ifndef DesExt1fmH
#define DesExt1fmH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Dialogs.hpp>
#include <Menus.hpp>
#include "L26.hpp"

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
        TButton *DesignButton;
        TButton *PrintButton;
		TLl26XObject *SplitColorRect;
        TPopupMenu *PopupMenu1;
        TMenuItem *EditColor1;
        TMenuItem *EditColor21;
        TColorDialog *ColorDialog1;
        TL26_ *LL;
        void __fastcall DesignButtonClick(TObject *Sender);
        void __fastcall SplitColorRectInitialCreation(TObject *Sender,
          DWORD ParentHandle);
        void __fastcall SplitColorRectEdit(TObject *Sender,
          DWORD ParentHandle, bool &HasChanged);
        void __fastcall EditColor1Click(TObject *Sender);
        void __fastcall PrintButtonClick(TObject *Sender);
        void __fastcall LLDefineVariables(TObject *Sender, int UserData,
          bool IsDesignMode, int &Percentage, bool &IsLastRecord,
          int &EventResult);
        void __fastcall EditColor21Click(TObject *Sender);
        void __fastcall SplitColorRectDraw(TObject *Sender,
          TCanvas *Canvas, TRect &Rect, bool IsDesignMode,
          bool &IsFinished);
private:	// User declarations
public:		// User declarations

        __fastcall TForm1(TComponent* Owner);
        MySplitColRectFill(TCanvas * Canvas, TRect & Rect, TColor color1, TColor color2);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif

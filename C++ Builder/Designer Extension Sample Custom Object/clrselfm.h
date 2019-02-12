//---------------------------------------------------------------------------

#ifndef clrselfmH
#define clrselfmH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Dialogs.hpp>
//---------------------------------------------------------------------------
class TColorSelectForm : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TButton *Button1;
        TButton *Button2;
        TButton *Button3;
        TButton *Button4;
        TColorDialog *ColorDialog1;
        TColorDialog *ColorDialog2;
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall Button2Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        TColor SelColor1, SelColor2;
        __fastcall TColorSelectForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TColorSelectForm *ColorSelectForm;
//---------------------------------------------------------------------------
#endif

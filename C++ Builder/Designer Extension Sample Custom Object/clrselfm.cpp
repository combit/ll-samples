//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "clrselfm.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TColorSelectForm *ColorSelectForm;
//---------------------------------------------------------------------------
__fastcall TColorSelectForm::TColorSelectForm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TColorSelectForm::Button1Click(TObject* /*Sender*/)
{
        ColorDialog1->Color=SelColor1;
        if(ColorDialog1->Execute())
		{
                SelColor1=ColorDialog1->Color;
        }
}
//---------------------------------------------------------------------------
void __fastcall TColorSelectForm::Button2Click(TObject* /*Sender*/)
{
        ColorDialog2->Color=SelColor2;
        if(ColorDialog2->Execute())
        {
                SelColor2=ColorDialog2->Color;
        }
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DesExt1fm.h"
#include "clrselfm.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "L26"
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::DesignButtonClick(TObject* /*Sender*/)
{
        // D:  Designer starten
        // US: Start Designer
        LL->Design(0, (UINT)this->Handle, "Designer Extension", LL_PROJECT_CARD, "desext.crd", false,true);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SplitColorRectInitialCreation(TObject* Sender,
	  DWORD /*ParentHandle*/)
{
		TLl26XObject *pObj = dynamic_cast <TLl26XObject*>(Sender);

        // D:  Objekt initialisieren
        // US: Initialize object
        pObj->Properties->AddProperty("Color1", "16711680"); // $00FF0000
        pObj->Properties->AddProperty("Color2", "255");   // $000000FF
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SplitColorRectEdit(TObject* Sender,
      DWORD /*ParentHandle*/, bool& HasChanged)
{
        TColor color1, color2;
        String color1Str, color2Str;

        // D:  Objekt bearbeiten
        // US: Edit object

        HasChanged=false;
		TLl26XObject *pObj = dynamic_cast<TLl26XObject*> (Sender);

        // D:  Dialog initialisieren
        // US: Initialize dialog
        pObj->Properties->GetValue("Color1",color1Str);
        pObj->Properties->GetValue("Color2",color2Str);

        color1=(TColor)color1Str.ToInt();
        color2=(TColor)color2Str.ToInt();

        TColorSelectForm *pClrSelFm = dynamic_cast<TColorSelectForm*> (ColorSelectForm);

        pClrSelFm->SelColor1=color1;
        pClrSelFm->SelColor2=color2;

        // D:  Dialog anzeigen
        // US: Display dialog
        if(pClrSelFm->ShowModal() == mrOk)
        {
                // D:  Neue Werte an Objekt übergeben
                // US: Pass new values to object
                pObj->Properties->AddProperty("Color1", Format("%d", ARRAYOFCONST((pClrSelFm->SelColor1))));
                pObj->Properties->AddProperty("Color2", Format("%d", ARRAYOFCONST((pClrSelFm->SelColor2))));
                HasChanged=true;
        }

}
//---------------------------------------------------------------------------

void __fastcall TForm1::PrintButtonClick(TObject* /*Sender*/)
{
        // D:  Druck starten
        // US: Start printout
        LL->Print(0, LL_PROJECT_CARD, "desext.crd", false, LL_PRINT_EXPORT,
        LL_BOXTYPE_STDWAIT, (UINT)this->Handle, "Designer Extension", true, "");
}
//---------------------------------------------------------------------------

void __fastcall TForm1::LLDefineVariables(TObject* /*Sender*/, int /*UserData*/,
	  bool IsDesignMode, int& /*Percentage*/, bool& IsLastRecord,
      int& /*EventResult*/)
{
        // D:  Nur einen Datensatz drucken
        // US: Print only one record
        if(!IsDesignMode)
        {
                IsLastRecord=true;
        }
}
//---------------------------------------------------------------------------
       
void __fastcall TForm1::EditColor1Click(TObject* Sender)
{
        String colorStr;
        TColor CurrentColor;

        // D:  Kontextmenuehandler für Farbe 1
        // US: Handler for "Color 1" context menu
		TLl26XObject *pObj  = dynamic_cast<TLl26XObject*> (Sender);

        pObj->Properties->GetValue("Color1",colorStr);

        CurrentColor=(TColor)colorStr.ToInt();

        ColorDialog1->Color=CurrentColor;
        if(ColorDialog1->Execute())
        {
                CurrentColor=ColorDialog1->Color;
				pObj->Properties->AddProperty("Color1", Format("%d", ARRAYOFCONST((CurrentColor))));
        }

}

//---------------------------------------------------------------------------

void __fastcall TForm1::EditColor21Click(TObject* Sender)
{
        String colorStr;
        TColor CurrentColor;

        // D:  Kontextmenuehandler für Farbe 1
        // US: Handler for "Color 1" context menu
		TLl26XObject *pObj  = dynamic_cast<TLl26XObject*> (Sender);

        pObj->Properties->GetValue("Color2",colorStr);

        CurrentColor=(TColor)colorStr.ToInt();

        ColorDialog1->Color=CurrentColor;
        if(ColorDialog1->Execute())
        {
                CurrentColor=ColorDialog1->Color;
                pObj->Properties->AddProperty("Color2", Format("%d", ARRAYOFCONST((CurrentColor))));
        }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SplitColorRectDraw(TObject* Sender,
      TCanvas* Canvas, TRect& Rect, bool /*IsDesignMode*/, bool& /*IsFinished*/)
{
        TColor color1, color2;
        String color1Str, color2Str;

		TLl26XObject *pObj  = dynamic_cast<TLl26XObject*> (Sender);

        pObj->Properties->GetValue("Color1",color1Str);
        pObj->Properties->GetValue("Color2",color2Str);

        color1=(TColor)color1Str.ToInt();
        color2=(TColor)color2Str.ToInt();

        // D:  Objekt zeichnen
        // US: Draw object
		MySplitColRectFill(Canvas, Rect, color1, color2);
}
//---------------------------------------------------------------------------

TForm1::MySplitColRectFill(TCanvas * Canvas, TRect &Rect, TColor color1, TColor color2)
{

        TRect rect_left, rect_right;

        rect_left=Rect;
        rect_left.Right = Rect.Left+(Rect.Width()/2);

        rect_right = Rect;
        rect_right.Left  = Rect.Left+(Rect.Width()/2);

        Canvas->Brush->Color=color1;
        Canvas->FillRect(rect_left);

        Canvas->Brush->Color=color2;
        Canvas->FillRect(rect_right);

        return(1);
}



//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DesExt2fm.h"
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
        LL->Design(0, (UINT)this->Handle, "Designer Extension", LL_PROJECT_CARD, "desext.crd", false, true);
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

void __fastcall TForm1::AddNumberParameterAutoComplete(TObject* /*Sender*/,
	  int /*ParameterIndex*/, TStringList *&Values)
{
        int index;

        // D:  Werte für Auto-Complete vorgeben. Hier einfach nur "1".."9"
        // US: Offer auto complete values. For this sample just add "1".."9"
        for(index=1; index<=9; index++)
        {
                Values->Add(Format("%d", ARRAYOFCONST((index))));
        }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::AddNumberEvaluateFunction(TObject* /*Sender*/,
	  TLl26XFunctionParameterType& /*ResultType*/, OleVariant &ResultValue,
	  int& /*DecimalPositions*/, const int /*ParameterCount*/,
	  const OleVariant& Parameter1, const OleVariant& Parameter2,
	  const OleVariant& /*Parameter3*/, const OleVariant& /*Parameter4*/)
{
		// D:  Funktionsberechnung
		// US: Actual function evaluation
		ResultValue = Parameter1.VDouble + Parameter2.VDouble;
}
//---------------------------------------------------------------------------


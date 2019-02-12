//---------------------------------------------------------------------------

#ifndef DesExt2fmH
#define DesExt2fmH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "L24.hpp"
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
		TLabel *Label1;
		TLabel *Label2;
		TButton *DesignButton;
		TButton *PrintButton;
		TLl24XFunction *AddNumber;
		TL24_ *LL;
		void __fastcall DesignButtonClick(TObject *Sender);
		void __fastcall PrintButtonClick(TObject *Sender);
		void __fastcall LLDefineVariables(TObject *Sender, int UserData,
		  bool IsDesignMode, int &Percentage, bool &IsLastRecord,
		  int &EventResult);
		void __fastcall AddNumberParameterAutoComplete(TObject *Sender,
		  int ParameterIndex, TStringList *&Values);
		void __fastcall AddNumberEvaluateFunction(TObject *Sender,
		  TLl24XFunctionParameterType &ResultType, OleVariant &ResultValue,
		  int &DecimalPositions, const int ParameterCount,
		  const OleVariant &Parameter1, const OleVariant &Parameter2,
		  const OleVariant &Parameter3, const OleVariant &Parameter4);
private:	// User declarations
public:		// User declarations
		__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif

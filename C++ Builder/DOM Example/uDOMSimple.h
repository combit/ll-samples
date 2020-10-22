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
#include "L26.hpp"
#include "L26db.hpp"
#include "L26dom.hpp"
#include <Dialogs.hpp>
//---------------------------------------------------------------------------
class TfrmDOMSimple : public TForm
{
__published:	// IDE-managed Components
	TADOConnection *ADOConnection1;
	TADOTable *ADOTable1;
	TDataSource *DataSource1;
	TDBL26_ *LL;
	TGroupBox *GroupBox3;
	TComboBox *CmBxTables;
	TListBox *LstBxAvFields;
	TListBox *LstBxSelFields;
	TEdit *dtTitle;
	TEdit *dtLogo;
	TButton *btnLogo;
	TButton *btnDesign;
	TButton *btnPreview;
	TButton *BtnSelect;
	TButton *BtnUnSelect;
	TLabel *Label5;
	TLabel *Label6;
	TLabel *Label7;
	TLabel *Label8;
	TLabel *Label1;
	TLabel *Label2;
	TLabel *Label3;
	TLabel *Label4;
	TLabel *Label9;
	TOpenDialog *OpenDialog1;
	void __fastcall FormCreate(TObject *Sender);
	void __fastcall CmBxTablesClick(TObject *Sender);
	void __fastcall LstBxAvFieldsDblClick(TObject *Sender);
	void __fastcall LstBxSelFieldsDblClick(TObject *Sender);
	void __fastcall BtnSelectClick(TObject *Sender);
	void __fastcall BtnUnSelectClick(TObject *Sender);
	void __fastcall btnLogoClick(TObject *Sender);
	void __fastcall btnDesignClick(TObject *Sender);
	void __fastcall btnPreviewClick(TObject *Sender);
private:	// User declarations
	String workingPath;
	void InitializeDbConnection();
	void GetTableFields();
	void SelectFields();
	void UnSelectFields();
	int __fastcall GenerateLLProject();
public:		// User declarations
	__fastcall TfrmDOMSimple(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmDOMSimple *frmDOMSimple;
//---------------------------------------------------------------------------
#endif

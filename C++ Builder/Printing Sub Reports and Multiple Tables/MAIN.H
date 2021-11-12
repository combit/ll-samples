//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <ADODb.hpp>
#include <Forms.hpp>
#include <Menus.hpp>
#include "L27.hpp"

class TMyTableMap : public TObject
{
  protected:
    TStringList* FKeyList;
    TStringList* FKeyFieldList;
    TList* FValueList;

  public:
    TMyTableMap();
    virtual __fastcall ~TMyTableMap();
    void AddTable(String Key, TADOTable* Value);
    void RemoveTable(String Key);
    bool GetTable(String Key, TADOTable** Value);
    bool GetKeyField(String Key, String& KeyField);
};

//---------------------------------------------------------------------------
class TFrmMultipleTables : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label5;
        TLabel *Label4;
        TLabel *Label3;
        TCheckBox *DebugCheckBox;
        TMainMenu *MainMenu1;
        TMenuItem *File1;
        TMenuItem *Exit1;
        TMenuItem *Edit1;
        TMenuItem *Report1;
        TMenuItem *Print1;
        TMenuItem *Report2;
        TL27_ *LL;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall Report1Click(TObject *Sender);
        void __fastcall Report2Click(TObject *Sender);
	void __fastcall Exit1Click(TObject *Sender);
private:	// User declarations
        bool bIsPrinting;
        TMyTableMap* FMapper;
        TADOTable* FTable;

        void PassDataStructure();
        void DefineCurrentRecord(String Prefix, TADOTable* Table, bool AsField);
        int PrintDataView(TADOTable* Table, int Level, int CurrentTableNo);

public:		// User declarations
        __fastcall TFrmMultipleTables(TComponent* Owner);
};



//---------------------------------------------------------------------------
extern PACKAGE TFrmMultipleTables *FrmMultipleTables;
//---------------------------------------------------------------------------
#endif

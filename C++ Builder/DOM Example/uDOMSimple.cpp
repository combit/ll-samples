/*=====================================================================================

 Copyright (C) combit GmbH

--------------------------------------------------------------------------------------
 File   : uDatabind.cpp, uDatabind.h, Databind.dpr
 Module : databind sample
 Descr. : D:   Dieses Beispiel demonstriert die Verwendung des datengebundenen Constrols
          US: This example demonstrates the usage of the data bound control
======================================================================================*/

//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "uDOMSimple.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "L25"
#pragma link "L25db"
#pragma link "L25dom"
#pragma resource "*.dfm"
TfrmDOMSimple *frmDOMSimple;
//---------------------------------------------------------------------------
__fastcall TfrmDOMSimple::TfrmDOMSimple(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
void TfrmDOMSimple::UnSelectFields()
{
 int i;
 for (i = 0; i < LstBxSelFields->Items->Count; i++) {
	 if (LstBxSelFields->Selected[i]) {
		 LstBxAvFields->Items->Add(LstBxSelFields->Items->Strings[i]);
	 }
 }
 LstBxSelFields->DeleteSelected();
}
//---------------------------------------------------------------------------
void TfrmDOMSimple::SelectFields()
{
  int i;
  for (i = 0; i < LstBxAvFields->Items->Count; i++) {
	if (LstBxAvFields->Selected[i]) {
	 LstBxSelFields->Items->Add(LstBxAvFields->Items->Strings[i]);
	}
  }

  LstBxAvFields->DeleteSelected();
}
//---------------------------------------------------------------------------
void TfrmDOMSimple::InitializeDbConnection()
{
  String dbPath;
  TRegistry *reg = new TRegistry;

  try
  {
	reg->RootKey = HKEY_CURRENT_USER;
	if (reg->OpenKey("Software\\combit\\cmbtll",false))
	  dbPath = reg->ReadString("NWINDPath");
	else
		ShowMessage("Unable to find sample database. Make sure List & Label is installed correctly.");
  }
  __finally
  {
   reg->CloseKey();
  }

 if (dbPath == "")
 {
	ShowMessage("Unable to find sample database. Make sure List & Label is installed correctly.");
 }
 else
 {
	if (!ADOConnection1->Connected)
	{
		ADOConnection1->ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=" + dbPath + ";Mode=Share Deny None;Extended Properties="";Jet OLEDB:Engine Type=4;";
		ADOConnection1->Connected = true;
	}
 }
}
//---------------------------------------------------------------------------
void TfrmDOMSimple::GetTableFields()
{
  ADOConnection1->GetFieldNames(CmBxTables->Items->Strings[CmBxTables->ItemIndex], LstBxAvFields->Items);
}
//---------------------------------------------------------------------------
int __fastcall TfrmDOMSimple::GenerateLLProject()
{
	  //D: Das DOM Objekt an ein List & Label Objekt binden
	  //US: Bind the DOM object to a List & Label object
	  TLlDOMProjectList *lldomproj = new TLlDOMProjectList(LL);

	  //D: Ein neues Listen Projekt mit dem Namen 'dynamic.lst' erstellen
	  //US: Create a new listproject called 'dynamic.lst'
	  int result = lldomproj->Open(String(ExtractFilePath(Application->ExeName) + "dynamic.lst"), L25dom::fmCreate, amReadWrite);
	  if (result != 0)
		  return result;

	  //D: Eine neue Projektbeschreibung dem Projekt zuweisen
	  //US: Assign new project description to the project
	  lldomproj->ProjectParameterList->ItemName["LL.ProjectDescription"]->Contents = "Dynamically created Project";

	  //D: Ein leeres Text Objekt erstellen
	  //US: Create an empty text object
	  TLlDOMObjectText *llobjText = new TLlDOMObjectText(lldomproj->ObjectList);

	  //D: Auslesen der Seitenkoordinaten der ersten Seite
	  //US: Get the coordinates for the first page
	  int Height = StrToInt(lldomproj->Regions->Items[0]->Paper->Extent->Vertical);
	  int Width = StrToInt(lldomproj->Regions->Items[0]->Paper->Extent->Horizontal);

      //D: Setzen von Eigenschaften für das Textobjekt
      //US: Set some properties for the text object
	  llobjText->Position->Define(10000, 10000, Width-65000, 27000);

	  //D: Hinzufügen eines Paragraphen und setzen diverser Eigenschaften
	  //US: Add a paragraph to the text object and set some properties
	  TLlDOMParagraph *llobjParagraph = new TLlDOMParagraph(llobjText->Paragraphs);
	  llobjParagraph->Contents = "'" + dtTitle->Text + "'";
      llobjParagraph->Font->Bold = "True";

      //D: Hinzufügen eines Grafikobjekts
      //US: Add a drawing object
	  TLlDOMObjectDrawing *llobjDrawing = new TLlDOMObjectDrawing(lldomproj->ObjectList);
	  llobjDrawing->Source->Fileinfo->FileName = dtLogo->Text;
	  llobjDrawing->Position->Define(Width - 50000, 10000, Width - (Width - 40000), 27000);

      //D: Hinzufügen eines Tabellencontainers und setzen diverser Eigenschaften
      //US: Add a table container and set some properties
	  TLlDOMObjectReportContainer *container = new TLlDOMObjectReportContainer(lldomproj->ObjectList);
	  container->Position->Define(10000, 40000, Width - 20000, Height - 44000);

      //D: In dem Tabellencontainer eine Tabelle hinzufügen
      //US: Add a table into the table container
	  TLlDOMSubItemTable *table = new TLlDOMSubItemTable(container->SubItems);
	  table->TableId = CmBxTables->Items->Strings[CmBxTables->ItemIndex];

	  //D: Zebramuster für Tabelle definieren
	  //US: Define zebra pattern for table
	  table->LineOptions->Data->ZebraPattern->Style = "1";
	  table->LineOptions->Data->ZebraPattern->Pattern = "12";
	  table->LineOptions->Data->ZebraPattern->Color = "RGB(225,225,225)";

	  //D: Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
	  //US: Add a new data line including all selected fields
	  TLlDOMTableLineData *tableLineData = new TLlDOMTableLineData(table->Lines->Data);
	  TLlDOMTableLineHeader *tableLineHeader = new TLlDOMTableLineHeader(table->Lines->Header);

	  int i;
	  for (i = 0; i < LstBxSelFields->Items->Count; i++)
	  {
		  TVarRec vr[] = {StrToInt(container->Position->Width) / LstBxSelFields->Items->Count};
		  String fieldWidth = String::Format("%d", vr, 0);

		  //D: Kopfzeile definieren
		  //US: Define head line
		  TLlDOMTableFieldText *header = new TLlDOMTableFieldText(tableLineHeader->Fields);
		  header->Contents = "'" + LstBxSelFields->Items->Strings[i] + "'";
		  header->Filling->Style = "1";
		  header->Filling->Color = "RGB(255,153,51)";
		  header->Font->Bold = "True";
		  header->Width = fieldWidth;

		  //D: Datenzeile definieren
		  //US: Define data line
		  TLlDOMTableFieldText *tableField = new TLlDOMTableFieldText(tableLineData->Fields);
		  tableField->Contents = CmBxTables->Items->Strings[CmBxTables->ItemIndex] + "." + LstBxSelFields->Items->Strings[i];
		  tableField->Width = fieldWidth;
	  }

      //D: Projekt Liste als Datei speichern
      //US: Save projectlist to file
	  lldomproj->Save(ExtractFilePath(Application->ExeName) + "dynamic.lst");

	  //D: Projekt Liste schliessen
	  //US: Close project list
	  lldomproj->Close();
	  return result;
}
//---------------------------------------------------------------------------
void __fastcall TfrmDOMSimple::FormCreate(TObject* /*Sender*/)
{
  //D: Pfad setzen und Datenbankpfad auslesen
  //US: Set path and read database path
  workingPath = ExtractFilePath(Application->ExeName);
  if((workingPath[workingPath.Length()] == '\\') && (workingPath[workingPath.Length() - 1] == '.'))
	workingPath = workingPath.SetLength(workingPath.Length() -2);

  SetCurrentDir(workingPath);

  //D: Datenbankverbindung herstellen
  //US: Create database connection
  InitializeDbConnection();
  ADOConnection1->GetTableNames(CmBxTables->Items, False);
  CmBxTables->ItemIndex = 0;
  GetTableFields();

  //D: Pfad zum Logo für das Layout
  //US: Path for the logo of the layout
  dtLogo->Text = workingPath + "\sunshine.gif";
}
//---------------------------------------------------------------------------
void __fastcall TfrmDOMSimple::CmBxTablesClick(TObject* /*Sender*/)
{
  LstBxAvFields->Clear();
  LstBxSelFields->Clear();
  GetTableFields();
}
//---------------------------------------------------------------------------

void __fastcall TfrmDOMSimple::LstBxAvFieldsDblClick(TObject* /*Sender*/)
{
	SelectFields();
}
//---------------------------------------------------------------------------

void __fastcall TfrmDOMSimple::LstBxSelFieldsDblClick(TObject* /*Sender*/)
{
	UnSelectFields();	
}
//---------------------------------------------------------------------------

void __fastcall TfrmDOMSimple::BtnSelectClick(TObject* /*Sender*/)
{
	SelectFields();	
}
//---------------------------------------------------------------------------

void __fastcall TfrmDOMSimple::BtnUnSelectClick(TObject* /*Sender*/)
{
	UnSelectFields();	
}
//---------------------------------------------------------------------------

void __fastcall TfrmDOMSimple::btnLogoClick(TObject* /*Sender*/)
{
  OpenDialog1->InitialDir = workingPath;
  OpenDialog1->Filter = "All Picture Files (*.bmp;*.jpg;*.png;*.wmf;*.gif)|*.bmp;*.jpg;*.png;*.wmf;*.gif";
  if (OpenDialog1->Execute())
	dtLogo->Text = OpenDialog1->FileName;
}
//---------------------------------------------------------------------------

void __fastcall TfrmDOMSimple::btnDesignClick(TObject* /*Sender*/)
{
  //D: Tabelle für das Layout festlegen
  //US: Determine table for the layout
  ADOTable1->Active = false;
  ADOTable1->TableName = CmBxTables->Items->Strings[CmBxTables->ItemIndex];
  ADOTable1->Active = true;

  //D: Eintellungen für die List & Label Komponente setzen
  //US: Define properties for the List & Label control
  LL->DataSource = DataSource1;
  LL->AutoDesignerFile = workingPath + "\dynamic.lst";
  LL->AutoProjectType = ptListProject;
  LL->AutoMasterMode = mmNone;
  LL->AutoShowSelectFile = TPropYesNo::Yes;

	//D: List & Label Projekt anhand Einstellungen erstellen
	//US: Create List & Label project based on the settings
  int nRet = GenerateLLProject();
  if (nRet < 0)
  {
	ShowMessage(LL->LlGetErrortext(nRet));
  }
  else
  {
	//D: Designer aufrufen
	//US: Call the designer
	LL->AutoDesign("Dynamic created project...");
  }
}
//---------------------------------------------------------------------------

void __fastcall TfrmDOMSimple::btnPreviewClick(TObject* /*Sender*/)
{
  //D: Tabelle für das Layout festlegen
  //US: Determine table for the layout
  ADOTable1->Active = false;
  ADOTable1->TableName = CmBxTables->Items->Strings[CmBxTables->ItemIndex];
  ADOTable1->Active = true;

  //D: Eintellungen für die List & Label Komponente setzen
  //US: Define properties for the List & Label control
  LL->DataSource = DataSource1;
  LL->AutoDesignerFile = workingPath + "\dynamic.lst";
  LL->AutoProjectType = ptListProject;
  LL->AutoMasterMode = mmNone;
  LL->AutoShowSelectFile = TPropYesNo::Yes;

  //D: List & Label Projekt anhand Einstellungen erstellen
  //US: Create List & Label project based on the settings
  int nRet = GenerateLLProject();
  if (nRet < 0)
  {
	ShowMessage(LL->LlGetErrortext(nRet));
  }
  else
  {
	//D: Designer aufrufen
	//US: Call the designer
	LL->AutoPrint("Dynamic created project...","");
  }
}
//---------------------------------------------------------------------------


//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
USERES("multitab.res");
USEFORM("main.cpp", FrmMultipleTables);
USEFORM("DataModule.cpp", DataModule1); /* TDataModule: File Type */
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TDataModule1), &DataModule1);                 
                 Application->CreateForm(__classid(TFrmMultipleTables), &FrmMultipleTables);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        return 0;
}
//---------------------------------------------------------------------------

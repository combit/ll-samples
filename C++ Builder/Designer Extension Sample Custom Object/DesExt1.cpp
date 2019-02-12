//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
USERES("DesExt1.res");
USEFORM("DesExt1fm.cpp", Form1);
USEFORM("clrselfm.cpp", ColorSelectForm);
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TForm1), &Form1);
                 Application->CreateForm(__classid(TColorSelectForm), &ColorSelectForm);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        return 0;
}
//---------------------------------------------------------------------------

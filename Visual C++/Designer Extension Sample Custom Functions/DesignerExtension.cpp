
// DesignerExtension.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "DesignerExtension.h"
#include "DesignerExtensionDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CDesignerExtensionApp

BEGIN_MESSAGE_MAP(CDesignerExtensionApp, CWinApp)
	ON_COMMAND(ID_HELP, &CWinApp::OnHelp)
END_MESSAGE_MAP()


// CDesignerExtensionApp construction
//================================================================================
CDesignerExtensionApp::CDesignerExtensionApp()
//================================================================================
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CDesignerExtensionApp object

CDesignerExtensionApp theApp;


// CDesignerExtensionApp initialization

//================================================================================
BOOL CDesignerExtensionApp::InitInstance()
//================================================================================
{
	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

	CDesignerExtensionDlg dlg;
	m_pMainWnd = &dlg;
	dlg.DoModal();

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
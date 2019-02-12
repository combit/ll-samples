//=============================================================================
//
//  Project: List & Label
//           Copyright (C) combit GmbH, All Rights Reserved
//
//  Authors: combit Software Team
//
//-----------------------------------------------------------------------------
//
//  Module:  LLMFC - List & Label MFC Sample Application
//
//	Descr. :D:	Dieses Beispiel demonstriert den Druck von relational verknüpften Tabellen
//				über eine eigene Druckschleife und die echtdaten Vorschau des Designer
//				Bitte beachten Sie, dass dieses Beispiel den Schwerpunkt auf die Grundlagen
//				von List & Label legt, weshalb nur minimales Error-Handling verwendet wird.
//			US: This example demonstrates the printout of relational tables using a custom
//				print loop and the realdata preview of the designer.
//				In order to focus on the fundamentals of List & Label and prevent
//				code clutter, minimal error handling is done in the example.
//
//=============================================================================

#include "stdafx.h"
#include "DesignerPreview.h"
#include "DesignerPreviewDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDesignerPreviewApp

BEGIN_MESSAGE_MAP(CDesignerPreviewApp, CWinApp)
	//{{AFX_MSG_MAP(CDesignerPreviewApp)
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDesignerPreviewApp construction

CDesignerPreviewApp::CDesignerPreviewApp()
{
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CDesignerPreviewApp object

CDesignerPreviewApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CDesignerPreviewApp initialization

BOOL CDesignerPreviewApp::InitInstance()
{
	m_SafehJob = LlJobOpen(CMBTLANG_DEFAULT);
	// Standard initialization
	CDesignerPreviewDlg dlg;
	m_pMainWnd = &dlg;
	::CoInitialize(NULL);
	int nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
	}
	else if (nResponse == IDCANCEL)
	{
	}

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}

BOOL CDesignerPreviewApp::ExitInstance()
{
	LlJobClose(m_SafehJob);

	return CWinApp::ExitInstance();
}

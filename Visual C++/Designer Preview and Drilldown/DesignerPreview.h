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


#if !defined(AFX_DESIGNERPREVIEW_H__3EFFFBB5_CBF6_458E_96BC_BB3FC1EB0496__INCLUDED_)
#define AFX_DESIGNERPREVIEW_H__3EFFFBB5_CBF6_458E_96BC_BB3FC1EB0496__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols
#include "..\cmbtll28.h"
/////////////////////////////////////////////////////////////////////////////
// CDesignerPreviewApp:
// See DesignerPreview.cpp for the implementation of this class
//

class CDesignerPreviewApp : public CWinApp
{
public:
	CDesignerPreviewApp();
	
private:
	HJOB			m_SafehJob;
// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDesignerPreviewApp)
	public:
	virtual BOOL InitInstance();
	virtual BOOL ExitInstance();


	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CDesignerPreviewApp)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DESIGNERPREVIEW_H__3EFFFBB5_CBF6_458E_96BC_BB3FC1EB0496__INCLUDED_)

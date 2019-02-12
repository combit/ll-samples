// DesignerExtension.h : main header file for the DesignerExtension application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols

// CDesignerExtensionApp:
// See DesignerExtension.cpp for the implementation of this class
//

class CDesignerExtensionApp : public CWinApp
{
public:
	CDesignerExtensionApp();

// Overrides
	public:
	virtual BOOL InitInstance();


	DECLARE_MESSAGE_MAP()
};

extern CDesignerExtensionApp theApp;
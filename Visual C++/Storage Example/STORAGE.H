//=============================================================================
//
//  Project: List & Label
//           Copyright (C) combit GmbH, All Rights Reserved
//
//  Authors: combit Software Team
//
//-----------------------------------------------------------------------------
//
//  Module:  Storage - List & Label MFC Sample Application
//
//=============================================================================
// Storage.h : main header file for the Storage application
//

#if !defined(AFX_LLSTORAGESAMPLE_H__8D349AEE_16B2_4A0D_BD22_9DDF1581AA7B__INCLUDED_)
#define AFX_LLSTORAGESAMPLE_H__8D349AEE_16B2_4A0D_BD22_9DDF1581AA7B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CLLStorageSampleApp:
// See Storage.cpp for the implementation of this class
//

class CLLStorageSampleApp : public CWinApp
{
public:
	CLLStorageSampleApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CLLStorageSampleApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CLLStorageSampleApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_LLSTORAGESAMPLE_H__8D349AEE_16B2_4A0D_BD22_9DDF1581AA7B__INCLUDED_)

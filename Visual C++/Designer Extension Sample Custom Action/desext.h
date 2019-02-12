// desext.h : main header file for the DESEXT application
//

#if !defined(AFX_DESEXT_H__1D02E8B9_2337_43B0_9989_B63678268B92__INCLUDED_)
#define AFX_DESEXT_H__1D02E8B9_2337_43B0_9989_B63678268B92__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CDesextApp:
// See desext.cpp for the implementation of this class
//

class CDesextApp : public CWinApp
{
public:
	CDesextApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDesextApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CDesextApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DESEXT_H__1D02E8B9_2337_43B0_9989_B63678268B92__INCLUDED_)

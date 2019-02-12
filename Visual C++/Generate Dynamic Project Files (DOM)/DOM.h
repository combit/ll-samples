// DOM.h : main header file for the DOM application
//

#if !defined(AFX_DOM_H__C368ABB4_F772_47B7_8371_10ED3B558DAA__INCLUDED_)
#define AFX_DOM_H__C368ABB4_F772_47B7_8371_10ED3B558DAA__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CDOMApp:
// See DOM.cpp for the implementation of this class
//

class CDOMApp : public CWinApp
{
public:
	CDOMApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDOMApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CDOMApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DOM_H__C368ABB4_F772_47B7_8371_10ED3B558DAA__INCLUDED_)

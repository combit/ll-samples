// rtf_samp.h : main header file for the RTF_SAMP application
//

#if !defined(AFX_RTF_SAMP_H__FAEBA1A7_8B95_11D2_9CD9_444553540000__INCLUDED_)
#define AFX_RTF_SAMP_H__FAEBA1A7_8B95_11D2_9CD9_444553540000__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CRtf_sampApp:
// See rtf_samp.cpp for the implementation of this class
//

class CRtf_sampApp : public CWinApp
{
public:
	CRtf_sampApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CRtf_sampApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CRtf_sampApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_RTF_SAMP_H__FAEBA1A7_8B95_11D2_9CD9_444553540000__INCLUDED_)

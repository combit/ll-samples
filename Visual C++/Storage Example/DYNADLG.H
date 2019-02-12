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
// DynaDlg.h : header file
//
#if !defined(AFX_LLSTORAGESAMPLEDLG_H__CF5AB043_BE4B_41F0_A8B6_D0CA70E436AF__INCLUDED_)
#define AFX_LLSTORAGESAMPLEDLG_H__CF5AB043_BE4B_41F0_A8B6_D0CA70E436AF__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

// D:   Laden des Header-Files fuer die Deklaration
// US: load	the header file for declaration
#include "..\cmbtls24.hx"


/////////////////////////////////////////////////////////////////////////////
// CLLStorageSampleDlg dialog
class CLLStorageSampleDlg : public CDialog
{
// Construction
public:
	CLLStorageSampleDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CLLStorageSampleDlg)
	enum { IDD = IDD_LLSTORAGESAMPLE_DIALOG };
	CStatic	m_staCopyCount;
	CStatic	m_staProjectfile;
	CStatic	m_staPrinter;
	CStatic	m_staJobname;
	CStatic	m_staCreation;
	CStatic	m_Error;
	CEdit	m_nPagesEdit;
	CButton	m_btBack;
	CButton	m_btForward;
	CStatic	m_llPagesStatic;
	CStatic	m_llJobsStatic;
	CStatic	m_LLStatic;
	CEdit	m_sLLFileEdit;
	CString	m_sLLJobs;
	CString	m_sLLPages;
	CString	m_sLLFile;
	int		m_nPages;
	CString m_sFile;
	CString m_sAppendFile;
	CRect	rc;
	HDC		dc;
	int		m_nPageCount;
	CString	m_sCreation;
	CString	m_sJobname;
	CString	m_sProjectfile;
	CString	m_sPrinter;
	CString	m_sCopyCount;
	CString	m_sPageNr;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CLLStorageSampleDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
	bool AppendDrawLLFile();
	bool DrawLLFile();

protected:
	HICON	m_hIcon;
	
	// D:   Deklaration der Job Handle von List & Label
	// US: declaration of the List & Label job handle 
	HSTG	m_hStgOrg;
	HLLSTG	m_hStgAppend;

	// Generated message map functions
	//{{AFX_MSG(CLLStorageSampleDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnDestroy();
	afx_msg void OnAboutbox();
	afx_msg void OnForward();
	afx_msg void OnBack();
	afx_msg void OnFileAppend();
	afx_msg void OnFileOpen();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_LLSTORAGESAMPLEDLG_H__CF5AB043_BE4B_41F0_A8B6_D0CA70E436AF__INCLUDED_)

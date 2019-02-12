// DOMDlg.h : header file
//

#if !defined(AFX_DOMDLG_H__0C8743DF_3DA4_48CC_B700_1BE2263907C8__INCLUDED_)
#define AFX_DOMDLG_H__0C8743DF_3DA4_48CC_B700_1BE2263907C8__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "..\cmbtll24.h"

/////////////////////////////////////////////////////////////////////////////
// CDOMDlg dialog

class CDOMDlg : public CDialog
{

private:
	void DefineFields(int nRecord);
	void FillListControl(int nRecord);
	int GenerateLLProject(void);

private:
	HJOB m_hJob;
	CString m_sFileName;

// Construction
public:
	CDOMDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CDOMDlg)
	enum { IDD = IDD_DOM_DIALOG };
	CListCtrl	m_oListSelectedVars;
	CListCtrl	m_oListAvailableVars;
	CButton	m_oCheckDebug;
	CEdit	m_oEditLogoPath;
	CString	m_sLogoPath;
	CString	m_sProjectTitle;
	BOOL	m_bDebug;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDOMDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;
	virtual void OnCancel();


	// Generated message map functions
	//{{AFX_MSG(CDOMDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClose();
	afx_msg void OnButtonCreateReport();
	afx_msg void OnButtonPreview();
	afx_msg void OnButtonSelectFile();
	afx_msg void OnButtonSelect();
	afx_msg void OnButtonDeselect();
	afx_msg void OnCheckDebug();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DOMDLG_H__0C8743DF_3DA4_48CC_B700_1BE2263907C8__INCLUDED_)

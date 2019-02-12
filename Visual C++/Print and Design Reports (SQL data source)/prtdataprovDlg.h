// prtdataprovDlg.h : header file
//

#if !defined(AFX_PRTDATAPROVDLG_H__0C8743DF_3DA4_48CC_B700_1BE2263907C8__INCLUDED_)
#define AFX_PRTDATAPROVDLG_H__0C8743DF_3DA4_48CC_B700_1BE2263907C8__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "prtdataprovider.h"
/////////////////////////////////////////////////////////////////////////////
// CPrtdataprovDlg dialog

class CPrtdataprovDlg : public CDialog
{
public:
	CPrintManager _PM;
private:
	HJOB m_hJob;
// Construction
public:
	CPrtdataprovDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CPrtdataprovDlg)
	enum { IDD = IDD_PRTDATAPROV_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CPrtdataprovDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
	static UINT m_uLLMessageBase;	// message base for LuL messages
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CPrtdataprovDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnBtnDesignReport();
	afx_msg void OnBtnPrintReport();
	afx_msg void OnClose();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_PRTDATAPROVDLG_H__0C8743DF_3DA4_48CC_B700_1BE2263907C8__INCLUDED_)

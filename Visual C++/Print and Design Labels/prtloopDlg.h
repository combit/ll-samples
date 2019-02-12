// prtloopDlg.h : header file
//

#if !defined(AFX_PRTLOOPDLG_H__0C8743DF_3DA4_48CC_B700_1BE2263907C8__INCLUDED_)
#define AFX_PRTLOOPDLG_H__0C8743DF_3DA4_48CC_B700_1BE2263907C8__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "..\cmbtll24.h"

/////////////////////////////////////////////////////////////////////////////
// CPrtloopDlg dialog

class CPrtloopDlg : public CDialog
{

private:
	void DefineVariables(int nRecord, bool isPrinting);
	void DefineFields(int nRecord, bool isPrinting);

private:
	HJOB m_hJob;
	CList<CString, CString> VarList;

// Construction
public:
	CPrtloopDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CPrtloopDlg)
	enum { IDD = IDD_PRTLOOP_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CPrtloopDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
	static UINT m_uLuLMessageBase;	// message base for LuL messages
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CPrtloopDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnBtnDesignReport();
	afx_msg void OnBtnPrintReport();
	afx_msg void OnBtnDesignLabel();
	afx_msg void OnBtnPrintLabel();
	afx_msg void OnClose();
	afx_msg void OnCancel();
	//}}AFX_MSG
	afx_msg LRESULT OnLulMessage(WPARAM wParam, LPARAM lParam);
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_PRTLOOPDLG_H__0C8743DF_3DA4_48CC_B700_1BE2263907C8__INCLUDED_)

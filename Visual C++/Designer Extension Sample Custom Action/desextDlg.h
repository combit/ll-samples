// desextDlg.h : header file
//

#if !defined(AFX_DESEXTDLG_H__3AD8D01C_EE61_4E7C_8353_4E6B52E5924E__INCLUDED_)
#define AFX_DESEXTDLG_H__3AD8D01C_EE61_4E7C_8353_4E6B52E5924E__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "..\cmbtll27.h"
#include "DomItem.h"

/////////////////////////////////////////////////////////////////////////////
// CDesextDlg dialog

class CDesextDlg : public CDialog
{

private:
	HJOB m_hJob;
	CString m_sFileName;

	int ExecuteDesignerAction();


// Construction
public:
	CDesextDlg(CWnd* pParent = NULL);	// standard constructor

	static UINT m_uLuLMessageBase;	// message base for LuL messages

// Dialog Data
	//{{AFX_DATA(CDesextDlg)
	enum { IDD = IDD_DESEXT_DIALOG };
	BOOL	m_bDebug;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDesextDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;
 

	// Generated message map functions
	//{{AFX_MSG(CDesextDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnButtonDesign();
	afx_msg void OnCheckDebug();
	afx_msg void OnClose();
	//}}AFX_MSG
	afx_msg LRESULT OnLulMessage(WPARAM wParam, LPARAM lParam);
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DESEXTDLG_H__3AD8D01C_EE61_4E7C_8353_4E6B52E5924E__INCLUDED_)

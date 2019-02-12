#if !defined(AFX_XINPUTFORM_H__4E8B903E_E359_42C0_BDCC_07AAEA163DAF__INCLUDED_)
#define AFX_XINPUTFORM_H__4E8B903E_E359_42C0_BDCC_07AAEA163DAF__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// XInputForm.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CXInputForm dialog

class CXInputForm : public CDialog
{
// Construction
public:
	CXInputForm(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CXInputForm)
	enum { IDD = IDD_XINPUTFORM_DIALOG };
	CEdit	m_oObjectName;
	CString	m_sObjectName;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CXInputForm)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CXInputForm)
	virtual BOOL OnInitDialog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_XINPUTFORM_H__4E8B903E_E359_42C0_BDCC_07AAEA163DAF__INCLUDED_)

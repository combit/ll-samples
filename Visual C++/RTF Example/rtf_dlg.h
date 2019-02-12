// rtf_sampDlg.h : header file
//
//{{AFX_INCLUDES()
#include "lul.h"
#include "richtext.h"
#include "llrtfctrl.h"
//}}AFX_INCLUDES

#if !defined(AFX_RTF_SAMPDLG_H__FAEBA1A9_8B95_11D2_9CD9_444553540000__INCLUDED_)
#define AFX_RTF_SAMPDLG_H__FAEBA1A9_8B95_11D2_9CD9_444553540000__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

/////////////////////////////////////////////////////////////////////////////
// CRtf_sampDlg dialog

class CRtf_sampDlg : public CDialog
{
// Construction
public:
	CRtf_sampDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CRtf_sampDlg)
	enum { IDD = IDD_RTF_SAMP_DIALOG };
	CLlRtfCtrl	m_LlRtfCtrl;
	CLul	m_ListLabel;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CRtf_sampDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	virtual BOOL PreTranslateMessage(MSG* pMsg);
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CRtf_sampDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnBtnDesign();
	afx_msg void OnCmndDefineVariables(long nUserData, long bDummy, long FAR* pnProgressInPerc, long FAR* pbLastRecord);
	afx_msg void OnBtnPrintToPrinter();
	afx_msg void OnBtnPrintToPreview();
	afx_msg void OnCmndPrintJobSupervisionList1(LPCTSTR sDevice, long dwJobID, long dwState);
	DECLARE_EVENTSINK_MAP()
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_RTF_SAMPDLG_H__FAEBA1A9_8B95_11D2_9CD9_444553540000__INCLUDED_)

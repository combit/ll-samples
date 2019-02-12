// MainFrm.h : interface of the CMainFrame class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_MAINFRM_H__A77FDE6D_0D16_4C18_93AD_34C0060AE29E__INCLUDED_)
#define AFX_MAINFRM_H__A77FDE6D_0D16_4C18_93AD_34C0060AE29E__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CMainFrame : public CFrameWnd
{
	
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMainFrame)
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	//}}AFX_VIRTUAL

private:
	bool GetTlbButtonState(long nID);
	void SetTlbButtonState(long nID, long nState);
// Implementation
public:
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:  // control bar embedded members
	CStatusBar  m_wndStatusBar;

// Generated message map functions
protected:
	//{{AFX_MSG(CMainFrame)
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnOpenFile();
	afx_msg void OnFileSave();
	afx_msg void OnFileSendto();
	afx_msg void OnFileExit();
	afx_msg void OnUpdateFileSaveas(CCmdUI* pCmdUI);
	afx_msg void OnUpdateFileSendto(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewFirstpage(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewLastpage(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewNextpage(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewPreviouspage(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewZoomfit(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewZoomin(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewZoomrevert(CCmdUI* pCmdUI);
	afx_msg void OnViewFirstpage();
	afx_msg void OnViewLastpage();
	afx_msg void OnViewNextpage();
	afx_msg void OnViewPreviouspage();
	afx_msg void OnViewZoomfit();
	afx_msg void OnViewZoomin();
	afx_msg void OnViewZoomrevert();
	afx_msg void OnUpdateViewShowthumbnail(CCmdUI* pCmdUI);
	afx_msg void OnViewShowthumbnail();
	afx_msg void OnViewShowexitbutton();
	afx_msg void OnUpdateViewShowexitbutton(CCmdUI* pCmdUI);
	afx_msg void OnFilePrintPrintall();
	afx_msg void OnUpdateFilePrintPrintall(CCmdUI* pCmdUI);
	afx_msg void OnFilePrintCurrentpage();
	afx_msg void OnUpdateFilePrintCurrentpage(CCmdUI* pCmdUI);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_MAINFRM_H__A77FDE6D_0D16_4C18_93AD_34C0060AE29E__INCLUDED_)

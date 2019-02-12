// viewerView.h : interface of the CViewerView class
//
/////////////////////////////////////////////////////////////////////////////
//{{AFX_INCLUDES()
#include "llviewctrl.h"
//}}AFX_INCLUDES

#if !defined(AFX_VIEWERVIEW_H__7C89AD50_3BD5_428D_9170_9400653A9CD5__INCLUDED_)
#define AFX_VIEWERVIEW_H__7C89AD50_3BD5_428D_9170_9400653A9CD5__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

// predeclaration
class CViewerDoc;

class CViewerView : public CFormView
{
protected: // create from serialization only
	CViewerView();
	DECLARE_DYNCREATE(CViewerView)

public:
	//{{AFX_DATA(CViewerView)
	enum { IDD = IDD_VIEWER_FORM };
	CLlViewCtrl	m_LlView;
	//}}AFX_DATA


// Attributes
public:
	CViewerDoc* GetDocument();

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CViewerView)
	public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual void OnInitialUpdate(); // called first time after construct
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnPrint(CDC* pDC, CPrintInfo* pInfo);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CViewerView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CViewerView)
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnBtnPressLlviewctrl1(long nID, BOOL FAR* pbIgnore);
	afx_msg void OnLoadFinishedLlviewctrl1(BOOL bSuccessful);
	DECLARE_EVENTSINK_MAP()
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in viewerView.cpp
inline CViewerDoc* CViewerView::GetDocument()
   { return (CViewerDoc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_VIEWERVIEW_H__7C89AD50_3BD5_428D_9170_9400653A9CD5__INCLUDED_)

// viewerView.cpp : implementation of the CViewerView class
//

#include "stdafx.h"
#include "viewer.h"

#include "viewerDoc.h"
#include "viewerView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CViewerView

IMPLEMENT_DYNCREATE(CViewerView, CFormView)

BEGIN_MESSAGE_MAP(CViewerView, CFormView)
	//{{AFX_MSG_MAP(CViewerView)
	ON_WM_MOVE()
	ON_WM_SIZE()
	//}}AFX_MSG_MAP
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, CFormView::OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CViewerView construction/destruction

CViewerView::CViewerView()
	: CFormView(CViewerView::IDD)
{
	//{{AFX_DATA_INIT(CViewerView)
	//}}AFX_DATA_INIT
	// TODO: add construction code here

}

CViewerView::~CViewerView()
{
}

void CViewerView::DoDataExchange(CDataExchange* pDX)
{
	CFormView::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CViewerView)
	DDX_Control(pDX, IDC_LLVIEWCTRL1, m_LlView);
	//}}AFX_DATA_MAP
}

BOOL CViewerView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CFormView::PreCreateWindow(cs);
}

void CViewerView::OnInitialUpdate()
{
	CFormView::OnInitialUpdate();
	GetParentFrame()->RecalcLayout();
	ResizeParentToFit();
	
}

/////////////////////////////////////////////////////////////////////////////
// CViewerView printing

BOOL CViewerView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CViewerView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CViewerView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CViewerView::OnPrint(CDC* pDC, CPrintInfo* /*pInfo*/)
{
	// TODO: add customized printing code here
}

/////////////////////////////////////////////////////////////////////////////
// CViewerView diagnostics

#ifdef _DEBUG
void CViewerView::AssertValid() const
{
	CFormView::AssertValid();
}

void CViewerView::Dump(CDumpContext& dc) const
{
	CFormView::Dump(dc);
}

CViewerDoc* CViewerView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CViewerDoc)));
	return (CViewerDoc*)m_pDocument;
}
#endif //_DEBUG


void CViewerView::OnSize(UINT nType, int cx, int cy) 
{
	CFormView::OnSize(nType, cx, cy);
	
	if(m_LlView.m_hWnd)
	{
		//Size the control
		m_LlView.SetWindowPos(NULL, 0, 0, cx, cy, SWP_SHOWWINDOW);
	}

	//Hide the Scollbars
	EnableScrollBarCtrl(SB_BOTH, FALSE);

	
}

BEGIN_EVENTSINK_MAP(CViewerView, CFormView)
    //{{AFX_EVENTSINK_MAP(CViewerView)
	ON_EVENT(CViewerView, IDC_LLVIEWCTRL1, 1 /* BtnPress */, OnBtnPressLlviewctrl1, VTS_I4 VTS_PBOOL)
	//}}AFX_EVENTSINK_MAP
END_EVENTSINK_MAP()


void CViewerView::OnBtnPressLlviewctrl1(long nID, BOOL FAR* pbIgnore) 
{
	if(nID == 114) // exit-button was clicked
	{
		// try to close the main window (exit app)
		if(this->GetParent()->GetSafeHwnd() != NULL)
			::PostMessage(this->GetParent()->GetSafeHwnd(), WM_CLOSE, 0, 0);
	}
}


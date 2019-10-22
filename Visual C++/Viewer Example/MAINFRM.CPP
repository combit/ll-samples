// MainFrm.cpp : implementation of the CMainFrame class
//

#include "stdafx.h"
#include "viewer.h"
#include "cmll25v.h"
#include "ViewerView.h"
#include "mainfrm.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWnd)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	//{{AFX_MSG_MAP(CMainFrame)
	ON_WM_CREATE()
	ON_COMMAND(ID_SD_SD, OnOpenFile)
	ON_COMMAND(ID_FILE_SAVEAS, OnFileSave)
	ON_COMMAND(ID_FILE_SENDTO, OnFileSendto)
	ON_COMMAND(ID_FILE_EXIT, OnFileExit)
	ON_UPDATE_COMMAND_UI(ID_FILE_SAVEAS, OnUpdateFileSaveas)
	ON_UPDATE_COMMAND_UI(ID_FILE_SENDTO, OnUpdateFileSendto)
	ON_UPDATE_COMMAND_UI(ID_VIEW_FIRSTPAGE, OnUpdateViewFirstpage)
	ON_UPDATE_COMMAND_UI(ID_VIEW_LASTPAGE, OnUpdateViewLastpage)
	ON_UPDATE_COMMAND_UI(ID_VIEW_NEXTPAGE, OnUpdateViewNextpage)
	ON_UPDATE_COMMAND_UI(ID_VIEW_PREVIOUSPAGE, OnUpdateViewPreviouspage)
	ON_UPDATE_COMMAND_UI(ID_VIEW_ZOOMFIT, OnUpdateViewZoomfit)
	ON_UPDATE_COMMAND_UI(ID_VIEW_ZOOMIN, OnUpdateViewZoomin)
	ON_UPDATE_COMMAND_UI(ID_VIEW_ZOOMREVERT, OnUpdateViewZoomrevert)
	ON_COMMAND(ID_VIEW_FIRSTPAGE, OnViewFirstpage)
	ON_COMMAND(ID_VIEW_LASTPAGE, OnViewLastpage)
	ON_COMMAND(ID_VIEW_NEXTPAGE, OnViewNextpage)
	ON_COMMAND(ID_VIEW_PREVIOUSPAGE, OnViewPreviouspage)
	ON_COMMAND(ID_VIEW_ZOOMFIT, OnViewZoomfit)
	ON_COMMAND(ID_VIEW_ZOOMIN, OnViewZoomin)
	ON_COMMAND(ID_VIEW_ZOOMREVERT, OnViewZoomrevert)
	ON_UPDATE_COMMAND_UI(ID_VIEW_SHOWTHUMBNAIL, OnUpdateViewShowthumbnail)
	ON_COMMAND(ID_VIEW_SHOWTHUMBNAIL, OnViewShowthumbnail)
	ON_COMMAND(ID_VIEW_SHOWEXITBUTTON, OnViewShowexitbutton)
	ON_UPDATE_COMMAND_UI(ID_VIEW_SHOWEXITBUTTON, OnUpdateViewShowexitbutton)
	ON_WM_MOVE()
	ON_COMMAND(ID_FILE_PRINT_PRINTALL, OnFilePrintPrintall)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT_PRINTALL, OnUpdateFilePrintPrintall)
	ON_COMMAND(ID_FILE_PRINT_CURRENTPAGE, OnFilePrintCurrentpage)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT_CURRENTPAGE, OnUpdateFilePrintCurrentpage)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

static UINT indicators[] =
{
	ID_SEPARATOR,           // status line indicator
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL,
};

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	// TODO: add member initialization code here
	
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	if (!m_wndStatusBar.Create(this) ||
		!m_wndStatusBar.SetIndicators(indicators,
		  sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CFrameWnd::PreCreateWindow(cs) )
		return FALSE;
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame diagnostics


#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWnd::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWnd::Dump(dc);
}

#endif //_DEBUG

//-----------------------------------------------------------
bool CMainFrame::GetTlbButtonState(long nID)
//-----------------------------------------------------------
{
	long nBtnState;
	
	IToolbarButtons tlbBtns;

	//Attach to Toolbarclass
	tlbBtns=((CViewerView*)GetActiveView())->m_LlView.GetToolbarButtons();

	//Get the current Button state
	nBtnState = tlbBtns.GetButtonState(nID);
			
	if(nBtnState==2 || nBtnState==-1)
	{
		return(false);
	}
	else
	{
		return(true);
	}

}


//-----------------------------------------------------------
void CMainFrame::SetTlbButtonState(long nID, long nState)
//-----------------------------------------------------------
{	
	IToolbarButtons tlbBtns;

	//Attach to Toolbarclass
	tlbBtns=((CViewerView*)GetActiveView())->m_LlView.GetToolbarButtons();

	//Get the current Button state
	tlbBtns.SetButtonState(nID, nState);

}

//*******************************************************
//*						MENU COMMAND					*
//*******************************************************
//-----------------------------------------------------------
void CMainFrame::OnOpenFile() 
//-----------------------------------------------------------
{
	CFileDialog dlg(
						TRUE,
						TEXT(".ll"),
						NULL,
						OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT,
						TEXT("List & Label Files (*.LL)|*.ll|All Files (*.*)|*.*|"), 
						NULL
					);

	if(dlg.DoModal()==IDOK)
	{
		//Open the selected ListLabel file
		((CViewerView*)GetActiveView())->m_LlView.SetFileURL(dlg.GetPathName());
		
		//Set the new windowtext
		SetWindowText(dlg.GetFileName() + TEXT(" - combit List & Label viewersample"));
	}
	
}


//-----------------------------------------------------------
void CMainFrame::OnFileSave() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.SaveAs();
}


//-----------------------------------------------------------
void CMainFrame::OnFileSendto() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.SendTo();
}


//-----------------------------------------------------------
void CMainFrame::OnFileExit() 
//-----------------------------------------------------------
{
	//close dialog
	::SendMessage(m_hWnd, WM_CLOSE, 0, 0);
}


//-----------------------------------------------------------
void CMainFrame::OnViewFirstpage() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.GotoFirst();
}

//-----------------------------------------------------------
void CMainFrame::OnViewLastpage() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.GotoLast();
}

//-----------------------------------------------------------
void CMainFrame::OnViewNextpage() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.GotoNext();	
}

//-----------------------------------------------------------
void CMainFrame::OnViewPreviouspage() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.GotoPrev();	
}
//-----------------------------------------------------------
void CMainFrame::OnViewZoomfit() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.ZoomReset();	
}

//-----------------------------------------------------------
void CMainFrame::OnViewZoomin() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.ZoomTimes2();	
}
//-----------------------------------------------------------
void CMainFrame::OnViewZoomrevert() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.ZoomRevert();	
}


//-----------------------------------------------------------
void CMainFrame::OnViewShowthumbnail() 
//-----------------------------------------------------------
{
	int nShowThumbnail;
	nShowThumbnail = ((CViewerView*)GetActiveView())->m_LlView.GetShowThumbnails();
	
	((CViewerView*)GetActiveView())->m_LlView.SetShowThumbnails(!nShowThumbnail);
}


//-----------------------------------------------------------
void CMainFrame::OnViewShowexitbutton() 
//-----------------------------------------------------------
{
	
	//Get the exitbutton state			
	if(GetTlbButtonState(114))
	{
		//enable exitbutton
		SetTlbButtonState(114, -1);
	}
	else
	{
		//hide exitbutton
		SetTlbButtonState(114, 1);
	}

}


//-----------------------------------------------------------
void CMainFrame::OnFilePrintPrintall() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.PrintAllPages(TRUE);		
}


//-----------------------------------------------------------
void CMainFrame::OnFilePrintCurrentpage() 
//-----------------------------------------------------------
{
	((CViewerView*)GetActiveView())->m_LlView.PrintCurrentPage(0);	
}



//*******************************************************
//*						MENU UPDATE						*
//*******************************************************
//-----------------------------------------------------------
void CMainFrame::OnUpdateFileSaveas(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(116)));
}

//-----------------------------------------------------------
void CMainFrame::OnUpdateFileSendto(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(115)));
}

//-----------------------------------------------------------
void CMainFrame::OnUpdateViewFirstpage(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(102)));
}

//-----------------------------------------------------------
void CMainFrame::OnUpdateViewLastpage(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(103)));
}

//-----------------------------------------------------------
void CMainFrame::OnUpdateViewNextpage(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(105)));
}

//-----------------------------------------------------------
void CMainFrame::OnUpdateViewPreviouspage(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(104)));
}

//-----------------------------------------------------------
void CMainFrame::OnUpdateViewZoomfit(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(108)));
}

//-----------------------------------------------------------
void CMainFrame::OnUpdateViewZoomin(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(100)));
}

//-----------------------------------------------------------
void CMainFrame::OnUpdateViewZoomrevert(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(101)));
}


//-----------------------------------------------------------
void CMainFrame::OnUpdateViewShowthumbnail(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	int nShowThumbnail;
	nShowThumbnail = ((CViewerView*)GetActiveView())->m_LlView.GetShowThumbnails();

	pCmdUI->SetCheck(nShowThumbnail);
}


//-----------------------------------------------------------
void CMainFrame::OnUpdateViewShowexitbutton(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->SetCheck((GetTlbButtonState(114)));
}


//-----------------------------------------------------------
void CMainFrame::OnUpdateFilePrintPrintall(CCmdUI* pCmdUI) 
//-----------------------------------------------------------
{
	pCmdUI->Enable((GetTlbButtonState(113)));
}


//-----------------------------------------------------------
void CMainFrame::OnUpdateFilePrintCurrentpage(CCmdUI* pCmdUI)
//----------------------------------------------------------- 
{
	pCmdUI->Enable((GetTlbButtonState(112)));
}

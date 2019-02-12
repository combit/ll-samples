// DesignerExtensionDlg.cpp : implementation file
//

#include "stdafx.h"
#include "DesignerExtension.h"
#include "DesignerExtensionDlg.h"
#include "ListLabel.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDesignerExtensionDlg dialog

CDesignerExtensionDlg::CDesignerExtensionDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDesignerExtensionDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CDesignerExtensionDlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	m_poMyRecordSet = NULL;
}

void CDesignerExtensionDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDesignerExtensionDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CDesignerExtensionDlg, CDialog)
	//{{AFX_MSG_MAP(CDesignerExtensionDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_DESIGNREPORT, OnButtonDesignReport)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDesignerExtensionDlg message handlers

BOOL CDesignerExtensionDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon


	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CDesignerExtensionDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CDesignerExtensionDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

//================================================================================
void CDesignerExtensionDlg::OnButtonDesignReport()
//================================================================================
{
	CListLabel oListLabel(CMBTLANG_DEFAULT);

	// D:	Neue Funktion(en) hinzufügen.
	// US:	Add new function(s).
	oListLabel.AddFunction(new LlXFctConvertToRoman);
	oListLabel.AddFunction(new LlXFctReverseString);
	oListLabel.AddFunction(new LlXFctEncodeURL);

	oListLabel.Design(NULL
						, (std::wstring)_T("DesignerExtension")
						, LL_PROJECT_LIST
						, (std::wstring)_T("Custom functions.lst")
						, 0);
}
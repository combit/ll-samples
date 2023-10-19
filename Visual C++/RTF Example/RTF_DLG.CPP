/*= MODULE ===================================================================
|
| Copyright (C) combit GmbH
|
|-----------------------------------------------------------------------------
| File   : rtf_dlg.cpp
| Module : CRtf_SampDlg
| Descr. : D:   Dieses Beispiel zeigt den Druck eines RTF Textes.
|              Hierbei wird mit Hilfe des List & Label OCX Controls und 
|              eines RTF-Controls das Drucken und Designen eines solchen Textes
|              vorgefuehrt.
|          US: This sample shows the simple printing and designing of a RTF text.
|              Is uses the List & Label OCX Control.
==================================================================  MODULE =*/

#include "stdafx.h"
#include "rtf_samp.h"
#include "rtf_dlg.h"

// D:  	Wenn Sie das List & Label OCX Control verwenden, sollten Sie vor
//      dem #include der Headerdatei _NO_CMLL29APIDEFINES definieren      
// US:	If you use the List & Label OCX Control, you should define 
//		_NO_CMLL29APIDEFINES before you include the List & Label header

#define _NO_CMLL29APIDEFINES
#include "..\cmbtll29.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CRtf_sampDlg dialog

CRtf_sampDlg::CRtf_sampDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CRtf_sampDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CRtf_sampDlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CRtf_sampDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CRtf_sampDlg)
	DDX_Control(pDX, IDC_LLRTFCTRL1, m_LlRtfCtrl);
	DDX_Control(pDX, IDC_LISTLABEL1, m_ListLabel);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CRtf_sampDlg, CDialog)
	//{{AFX_MSG_MAP(CRtf_sampDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_DESIGN, OnBtnDesign)
	ON_BN_CLICKED(IDC_BTN_PRNTOPRINTER, OnBtnPrintToPrinter)
	ON_BN_CLICKED(IDC_BTN_PRNTOPREVIEW, OnBtnPrintToPreview)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CRtf_sampDlg message handlers

BOOL CRtf_sampDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	

	// D:   Aktiviert OLE Automation fuer das List & Label Objekt
	// US: Enables OLE automation for List & Label object.
	m_ListLabel.EnableAutomation();
	
	// D:   Das List & Label Objekt an das RTF-Control binden
	// US: Binds the List & Label object to the RTF-Control
	if(m_ListLabel.GetControlUnknown())
	{
		LPDISPATCH pDispatch;

		if(SUCCEEDED(m_ListLabel.GetControlUnknown()->QueryInterface(IID_IDispatch,
				(LPVOID*)&pDispatch)))
		{
			ASSERT(pDispatch != NULL);			

			m_LlRtfCtrl.EnableAutomation();
			m_LlRtfCtrl.SetParentComponent(pDispatch);
			pDispatch->Release();
			pDispatch = NULL;	
		}
	}

	CFile file;
	if(file.Open(TEXT("Sample.rtf"), CFile::modeRead))
	{
		
		UINT nChars = (UINT)file.GetLength();
		CHAR* sCharString = new CHAR[nChars];
		file.Read(sCharString, nChars);
		CString sText(sCharString);
		m_LlRtfCtrl.SetText((LPCTSTR)sText);
		delete[] sCharString;
	}
	else
	{
		CString sErrorText;
		sErrorText.LoadString(IDS_ERROR);
		m_LlRtfCtrl.SetText((LPCTSTR)sErrorText);
	}

	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CRtf_sampDlg::OnPaint() 
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
HCURSOR CRtf_sampDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CRtf_sampDlg::OnBtnDesign() 
{
	// D:   Startet den Designer mit dem Titel "Design RTF Sample Card" und der Datei "rtf.lbl"
    // US: Opens "rtf.lbl" within the designer titled "Design RTF Sample Card"
	m_ListLabel.Design(0, (long) GetSafeHwnd(), TEXT("Design RTF Sample Card"), LL_PROJECT_CARD, TEXT("rtf.crd"), TRUE);
}

void CRtf_sampDlg::OnBtnPrintToPrinter() 
{
	// D:   Druckt das Projekt "rtf.crd" auf dem Drucker aus
    // US: Prints "rtf.crd" to printer
	m_ListLabel.LlSetDebug(1);
	m_ListLabel.Print(0, LL_PROJECT_CARD, TEXT("rtf.crd"), TRUE, LL_PRINT_EXPORT, LL_BOXTYPE_EMPTYWAIT, (long) GetSafeHwnd()
		, TEXT("Print RTF Sample Card to Printer")
		, TRUE, TEXT(""));
	
}

void CRtf_sampDlg::OnBtnPrintToPreview() 
{
	// D:   Druckt das Projekt "rtf.crd" als Vorschau aus
    // US: Prints "rtf.crd" to preview	

	m_ListLabel.Print(0, LL_PROJECT_CARD, TEXT("rtf.crd"), TRUE, LL_PRINT_PREVIEW, LL_BOXTYPE_EMPTYWAIT, (long) GetSafeHwnd()
		, TEXT("Print RTF Sample Card to Preview")
		, TRUE, TEXT(""));
}


BEGIN_EVENTSINK_MAP(CRtf_sampDlg, CDialog)
    //{{AFX_EVENTSINK_MAP(CRtf_sampDlg)
	ON_EVENT(CRtf_sampDlg, IDC_LISTLABEL1, 23 /* CmndDefineVariables */, OnCmndDefineVariables, VTS_I4 VTS_I4 VTS_PI4 VTS_PI4)
	ON_EVENT(CRtf_sampDlg, IDC_LISTLABEL1, 26 /* CmndPrintJobSupervision */, OnCmndPrintJobSupervisionList1, VTS_BSTR VTS_I4 VTS_I4)
	//}}AFX_EVENTSINK_MAP
END_EVENTSINK_MAP()


void CRtf_sampDlg::OnCmndDefineVariables(long nUserData, long bDummy, long FAR* pnProgressInPerc, long FAR* pbLastRecord) 
{	
	//D:   Dieser Event wird von den List & Label Befehlen Print und Design ausgelöst
	//    Er wird für jeden Datensatz aufgerufen um die Variablen und deren Inhalt
	//    an List & Label zu übergeben.
	//US: This event is called by the List & Label methods Print and Design
	//    It will be called for each record to define the vaiables and their
	//    contents

	CString		sRTFText;
	sRTFText = (LPCTSTR)m_LlRtfCtrl.GetText();
	m_ListLabel.LlDefineVariableStart();
	
	// D:   Formatierten Text des RTF-Controls als Variable in List & Label definieren
    // US: Define formatted text from RTF control as List & Label variable    

	m_ListLabel.LlDefineVariableExt(_T("RTF-Field"), (LPCTSTR) sRTFText, LL_RTF);

	//D:   Werden Echt-Daten benötigt? (nicht bei Designer-Aufruf)
    //US: Is real data needed? (not when method Design has been called)
	if(bDummy == 0)
		*pbLastRecord = 1;
}



void CRtf_sampDlg::OnCmndPrintJobSupervisionList1(LPCTSTR sDevice, long dwJobID, long dwState) 
{
	// TODO: Add your control notification handler code here
	Sleep(100);	
}

BOOL CRtf_sampDlg::PreTranslateMessage(MSG* pMsg)
{
	// prevent dialog from being closed by ESC
	if ( pMsg->message == WM_KEYDOWN || pMsg->message==WM_KEYUP )
	{
		switch ( pMsg->wParam )
		{
			case VK_ESCAPE:
			case VK_RETURN:
				
				if(GetParent() && (GetStyle() & WS_CHILD))
				{
					GetParent()->PostMessage(pMsg->message, pMsg->wParam, pMsg->lParam);
					return TRUE;
				}
				else
					return TRUE; // if escape key by-pass.
		}
	}

	return CDialog::PreTranslateMessage(pMsg);
}

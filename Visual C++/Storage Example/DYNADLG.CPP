//=============================================================================
//
//  Project: List & Label
//           Copyright (C) combit GmbH, All Rights Reserved
//
//  Authors: combit Software Team
//
//-----------------------------------------------------------------------------
//
//  Module:  Storage - List & Label MFC Sample Application
//
//=============================================================================
// DynaDlg.cpp : implementation file
//
#include "stdafx.h"
#include "Storage.h"
#include "DynaDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


// D:   Vorbereitung für dynamisches Laden der List & Label Storage DLL
// US: preparing storage load of the List & Label Storage DLL
#define	IMPLEMENTATION
#undef _LS29_H
#include "..\cmbtls29.hx"
#undef	IMPLEMENTATION


/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About
class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	afx_msg void OnExit();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
	ON_COMMAND(IDCANCEL, OnExit)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// helper funtion
CString GetSamplePath()
{
	wchar_t app_path[_MAX_PATH];
	GetModuleFileName((HMODULE)AfxGetApp()->m_hInstance, app_path, MAX_PATH);
	
	wchar_t drive[_MAX_DRIVE], dir[_MAX_DIR], fname[_MAX_FNAME], ext[_MAX_EXT];
	_wsplitpath_s(app_path, drive, _MAX_DRIVE, dir, _MAX_DIR, fname, _MAX_FNAME, ext, _MAX_EXT);
	CString app_str = app_path;
	app_str.Format(_T("%s%s"), (LPCTSTR)drive, (LPCTSTR)dir);
	app_str = app_str.Left(app_str.ReverseFind('\\'));
	app_str = app_str.Left(app_str.ReverseFind('\\'));

	return app_str;
}

/////////////////////////////////////////////////////////////////////////////
// CLLStorageSampleDlg dialog

CLLStorageSampleDlg::CLLStorageSampleDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CLLStorageSampleDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CLLStorageSampleDlg)
	m_sLLJobs = _T("");
	m_sLLPages = _T("");
	m_sLLFile = _T("");
	m_sCreation = _T("");
	m_sJobname = _T("");
	m_sProjectfile = _T("");
	m_sPrinter = _T("");
	m_sCopyCount = _T("");
	m_sPageNr = _T("");
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_LL_ICON);
}

void CLLStorageSampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CLLStorageSampleDlg)
	DDX_Control(pDX, IDC_STATIC_COPY_COUNT, m_staCopyCount);
	DDX_Control(pDX, IDC_STATIC_PROJECTFILE, m_staProjectfile);
	DDX_Control(pDX, IDC_STATIC_PRINTER, m_staPrinter);
	DDX_Control(pDX, IDC_STATIC_JOBNAME, m_staJobname);
	DDX_Control(pDX, IDC_STATIC_CREATE, m_staCreation);

	DDX_Control(pDX, IDC_PAGES, m_nPagesEdit);
	DDX_Control(pDX, IDC_BACK, m_btBack);
	DDX_Control(pDX, IDC_FORWARD, m_btForward);
	DDX_Control(pDX, IDC_LL_PAGECOUNT, m_llPagesStatic);
	DDX_Control(pDX, IDC_JOBS, m_llJobsStatic);
	DDX_Control(pDX, IDC_LL_STATIC, m_LLStatic);
	DDX_Control(pDX, IDC_LLFILE, m_sLLFileEdit);
	DDX_Text(pDX, IDC_JOBS, m_sLLJobs);
	DDX_Text(pDX, IDC_LL_PAGECOUNT, m_sLLPages);
	DDX_Text(pDX, IDC_LLFILE, m_sLLFile);
	DDX_Text(pDX, IDC_STATIC_CREATE, m_sCreation);
	DDX_Text(pDX, IDC_STATIC_JOBNAME, m_sJobname);
	DDX_Text(pDX, IDC_STATIC_PROJECTFILE, m_sProjectfile);
	DDX_Text(pDX, IDC_STATIC_PRINTER, m_sPrinter);
	DDX_Text(pDX, IDC_STATIC_COPY_COUNT, m_sCopyCount);
	DDX_Text(pDX, IDC_PAGES, m_sPageNr);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CLLStorageSampleDlg, CDialog)
	//{{AFX_MSG_MAP(CLLStorageSampleDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_DESTROY()
	ON_COMMAND(IDS_ABOUTBOX, OnAboutbox)
	ON_BN_CLICKED(IDC_FORWARD, OnForward)
	ON_BN_CLICKED(IDC_BACK, OnBack)
	ON_COMMAND(ID_FILE_APPEND, OnFileAppend)
	ON_COMMAND(ID_FILE_OPEN, OnFileOpen)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()



/////////////////////////////////////////////////////////////////////////////
// CLLStorageSampleDlg message handlers

BOOL CLLStorageSampleDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	
	// D:   List & Label wir dynamisch geladen
	// US: storage load 
	if(LS29xLoad() < 0) 
	{
		  AfxMessageBox(TEXT("List & Label storage load failed!"));
	}
	else
	{
		// D:   Das Laden hat funktioniert
		// US: load succesfull	 
	}
	
   	m_LLStatic.GetWindowRect(rc);
	ScreenToClient(rc);
	dc = (this->GetDC())->m_hDC;

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CLLStorageSampleDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CLLStorageSampleDlg::OnPaint() 
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
		int x = (rect.Width()  - cxIcon ) / 2;
		int y = (rect.Height() - cyIcon ) / 2;
		
		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}

	DrawLLFile();
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CLLStorageSampleDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

 
void CLLStorageSampleDlg::OnDestroy() 
{
	// D:   List & Label entladen
	// US: unload List & Label
   	LS29xUnload();

	CDialog::OnDestroy();
}


//=============================================================================
bool CLLStorageSampleDlg::DrawLLFile()
//=============================================================================
{
 	UpdateData(TRUE);
	
	if(m_sFile.GetLength() <= 0)
		return false;

	// D:   Oeffne eine Druckvorschaudatei
	// US: open a preview file
	m_hStgOrg = LlStgsysStorageOpen(m_sFile, TEXT(""), TRUE, TRUE);
	if(m_hStgOrg == 0)
	{
		AfxMessageBox(TEXT("LlStgsysStorageOpen failed (DrawLLFile)"));
		return false;
	}

	// D:   Zeichne Druckvorschaudatei
	// US: draw preview file
	if(LlStgsysDrawPage(m_hStgOrg, dc, NULL, FALSE, rc, m_nPages, TRUE, NULL) < 0)
	{
		AfxMessageBox(TEXT("LlStgsysDrawPage failed"));
		LlStgsysStorageClose(m_hStgOrg);
		return false;
	}

	// D:   Anzahl der Jobs
	// US: job count
	int nJobCount = 0;
	nJobCount = LlStgsysGetJobCount(m_hStgOrg);
	if(nJobCount < 0)
	{
		// D:   Fehlerbehandlung
		// US: error handling
		AfxMessageBox(TEXT("LlStgsysGetJobCount failed"));
		LlStgsysStorageClose(m_hStgOrg);
		return false;
	}

	m_sLLJobs.Format(TEXT("%d"),nJobCount);
	m_llJobsStatic.SetWindowText(m_sLLJobs);

 	// D:   Anzahl der Seiten
	// US: page count
	m_nPageCount = LlStgsysGetPageCount(m_hStgOrg);
	if(m_nPageCount < 0)
	{
			// D:   Fehlerbehandlung
		// US: error handling
		AfxMessageBox(TEXT("LlStgsysGetPageCount failed"));
		LlStgsysStorageClose(m_hStgOrg);
		return false;
	} 

   	m_sLLPages.Format(TEXT("%d"),m_nPageCount);
	m_llPagesStatic.SetWindowText(m_sLLPages);

	// D:   Projektdatei
	// US: project file name
	if(LlStgsysGetPageOptionString(m_hStgOrg, m_nPages, LS_OPTION_PROJECTNAME, m_sProjectfile.GetBuffer(_MAX_PATH), _MAX_PATH ) < 0)
	{
	   	// D:   Fehlerbehandlung
		// US: error handling
	   	AfxMessageBox(TEXT("LL_STGSYS_OPTION_PROJECTNAME failed"));
		LlStgsysStorageClose(m_hStgOrg);
		return false;
	}  

	m_sProjectfile.ReleaseBuffer();
	wchar_t fname[_MAX_FNAME];
	wchar_t ext[_MAX_EXT];
	_wsplitpath_s(m_sProjectfile, NULL, NULL, NULL, NULL, fname, _MAX_FNAME, ext, _MAX_EXT);
	CString sOutput;
	sOutput.Format(TEXT("%s%s"),fname,ext);
   	m_staProjectfile.SetWindowText(sOutput);
	sOutput.ReleaseBuffer();

	// D:   Druckername
	// US: printer
	if(LlStgsysGetPageOptionString(m_hStgOrg, m_nPages, LS_OPTION_USED_PRTDEVICE, m_sPrinter.GetBuffer(_MAX_PATH), _MAX_PATH ) < 0)
	{
	 	// D:   Fehlerbehandlung
		// US: error handling
	   	AfxMessageBox(TEXT("LS_OPTION_USED_PRTDEVICE failed"));
		LlStgsysStorageClose(m_hStgOrg);
		return false;
	}

	m_sPrinter.ReleaseBuffer();
   	m_staPrinter.SetWindowText(m_sPrinter);

	// D:   Erstellungsdatum
	// US: creation date
	if(LlStgsysGetPageOptionString(m_hStgOrg, m_nPages, LS_OPTION_CREATION, m_sCreation.GetBuffer(_MAX_PATH), _MAX_PATH ) < 0)
	{
		// D:   Fehlerbehandlung
		// US: error handling
	   	AfxMessageBox(TEXT("LL_STGSYS_OPTION_CREATION failed"));
		LlStgsysStorageClose(m_hStgOrg);
		return false;
	}
   
	m_sCreation.ReleaseBuffer();
	m_staCreation.SetWindowText(m_sCreation);

	// D:   Jobname
	// US: job name
	if(LlStgsysGetPageOptionString(m_hStgOrg, m_nPages, LS_OPTION_JOBNAME, m_sJobname.GetBuffer(_MAX_PATH), _MAX_PATH ) < 0)
	{
		// D:   Fehlerbehandlung
		// US: error handling
	   	AfxMessageBox(TEXT("LlStgsysGetPageOptionString with LS_OPTION_JOBNAME failed"));
		LlStgsysStorageClose(m_hStgOrg);
		return false;
	}

	m_sJobname.ReleaseBuffer();
	m_staJobname.SetWindowText(m_sJobname);

	// D:   Kopien
	// US: copies
	int nCopies;
	nCopies = LlStgsysGetPageOptionValue(m_hStgOrg, m_nPages, LS_OPTION_COPIES);
	if(nCopies < 0)
	{
		// D:   Fehlerbehandlung
		// US: error handling
   		AfxMessageBox(TEXT("LS_OPTION_COPIES failed!"));
		LlStgsysStorageClose(m_hStgOrg);
		return false;
	}	 
	
	m_sCopyCount.Format(TEXT("%d"), nCopies);
	m_staCopyCount.SetWindowText(m_sCopyCount);
	
	CString sPages;
	sPages.Format(TEXT("%d / %d"), m_nPages, m_nPageCount);
	m_nPagesEdit.SetWindowText(sPages);

	LlStgsysStorageClose(m_hStgOrg);
	return true;
}


//=============================================================================
bool CLLStorageSampleDlg::AppendDrawLLFile()
//=============================================================================
{
	UpdateData(TRUE);
	
 	// D:   Oeffne Druckvorschaudatei zum schreiben
	// US: open preview file for writing
	m_hStgOrg = LlStgsysStorageOpen(m_sFile, TEXT(""), FALSE, TRUE);
	if( m_hStgOrg == 0)
	{
		AfxMessageBox(TEXT("LlStgsysStorageOpen failed"));
		return false;
	}

	// D:   Oeffne Druckvorschaudatei zum angaengen
	// US: open another preview file to append
	m_hStgAppend = LlStgsysStorageOpen(m_sAppendFile, TEXT(""), FALSE, TRUE);
	if(m_hStgAppend == 0)
	{
		AfxMessageBox(TEXT("LlStgsysStorageOpen failed"));
		LlStgsysStorageClose(m_hStgOrg);
		return false;
	}
  
	bool bRet = false;
	CWaitCursor wait;

	// D:   Haenge Druckvorschaudatei an
	// US: append preview file
	int nErrorAppend; 
	nErrorAppend = LlStgsysAppend(m_hStgOrg, m_hStgAppend);
	if(nErrorAppend < 0)
	{
		// D:  Fehlerbehandlung
		// US: error handling
		AfxMessageBox(TEXT("LlStgsysAppend failed"));		
		bRet = false;
	}
	else
	{		
		bRet = true;
	}	
		
	// D:  Schliesse Druckvorschaudateien
	// US: close preview files 
	LlStgsysStorageClose(m_hStgAppend);
	LlStgsysStorageClose(m_hStgOrg);

	return bRet;
}


void CLLStorageSampleDlg::OnFileAppend()
{
	CFileDialog dlg(TRUE,TEXT("*.ll"),TEXT("*.ll"),OFN_FILEMUSTEXIST|OFN_HIDEREADONLY, 
	TEXT("List & Label Viewer file (*.ll)|*.ll|All files (*.*)|*.*||")); 

	CString sInitDir = GetSamplePath();
	dlg.m_ofn.lpstrInitialDir = sInitDir;

	if (dlg.DoModal() == IDOK)
	{
		m_sAppendFile = dlg.GetPathName();
		if(m_sAppendFile == m_sFile)
		{
			AfxMessageBox(TEXT("You selected the same List & Label(*.ll) File!\nPlease select another file to attach."));
		}
		else
		{
			m_nPages = 1;
			if(AppendDrawLLFile())
			{
				DrawLLFile();
			}
		}
	}
}

void CLLStorageSampleDlg::OnFileOpen() 
{
	CFileDialog dlg(TRUE,TEXT("*.ll"),TEXT("*.ll"), OFN_FILEMUSTEXIST|OFN_HIDEREADONLY, 
	TEXT("List & Label Viewer file (*.ll)|*.ll|All files (*.*)|*.*||"));
	
	CString sInitDir = GetSamplePath();
	dlg.m_ofn.lpstrInitialDir = sInitDir;

	if (dlg.DoModal() == IDOK)
	{
		m_sFile = dlg.GetPathName();
		m_sLLFileEdit.SetWindowText(m_sFile);

		m_nPages = 1;
	   	if(DrawLLFile())
		{
			if(m_nPageCount > 1)
				m_btForward.EndModalState();
			else
				m_btForward.BeginModalState();
		
			CMenu* mmenu = GetMenu();
			CMenu* submenu = mmenu->GetSubMenu(0);
			submenu->EnableMenuItem(ID_FILE_APPEND,MF_BYCOMMAND | MF_ENABLED);
		}
	}
}

void CAboutDlg::OnExit() 
{
	exit(0);
}

void CLLStorageSampleDlg::OnAboutbox() 
{
	CAboutDlg about;
	about.DoModal();
}

void CLLStorageSampleDlg::OnForward() 
{
	m_nPages++;
	if(m_nPages == m_nPageCount)
	{
		m_btForward.BeginModalState();
	}
		
	if(DrawLLFile())
	{
		CString sPages;
		sPages.Format(TEXT("%d / %d"), m_nPages, m_nPageCount);
		m_nPagesEdit.SetWindowText(sPages);
		m_btBack.EndModalState();
	}

} 
 
void CLLStorageSampleDlg::OnBack() 
{  	
	m_nPages--;
	if(m_nPages == 1)
	{
		m_btBack.BeginModalState();
	}
	
	if(DrawLLFile())
	{
		CString sPages;
		sPages.Format(TEXT("%d / %d"), m_nPages, m_nPageCount);
		m_nPagesEdit.SetWindowText(sPages);
		m_btForward.EndModalState();
	}
}

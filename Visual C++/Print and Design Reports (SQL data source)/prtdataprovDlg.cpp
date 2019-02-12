//=============================================================================
//
//  Project: List & Label
//           Copyright (C) combit GmbH, All Rights Reserved
//
//  Authors: combit Software Team
//
//-----------------------------------------------------------------------------
//
//  List & Label  Sample Application
//
//=============================================================================
// prtdataprovDlg.cpp : implementation file
//

#include "stdafx.h"
#include "prtdataprov.h"
#include "prtdataprovDlg.h"
#include "prtdataprovider.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


/////////////////////////////////////////////////////////////////////////////
// CPrtdataprovDlg dialog

//---------------------------------------------------------------------
CPrtdataprovDlg::CPrtdataprovDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CPrtdataprovDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CPrtdataprovDlg)
	// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

}
//---------------------------------------------------------------------
void CPrtdataprovDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CPrtdataprovDlg)
	// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}
//---------------------------------------------------------------------

BEGIN_MESSAGE_MAP(CPrtdataprovDlg, CDialog)
	//{{AFX_MSG_MAP(CPrtdataprovDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_DESIGN_REPORT, OnBtnDesignReport)
	ON_BN_CLICKED(IDC_BTN_PRINT_REPORT, OnBtnPrintReport)
	ON_WM_CLOSE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPrtdataprovDlg message handlers

//---------------------------------------------------------------------
BOOL CPrtdataprovDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// D:   Erstellen des List & Label Jobs
	// US:  Create the List & Label Job
	m_hJob = LlJobOpen(CMBTLANG_DEFAULT);

	if (m_hJob == LL_ERR_BAD_JOBHANDLE)
	{
		MessageBox(_T("Job can't be initialized!"), _T("List & Label Sample App"), MB_OK | MB_ICONSTOP);
	}
	else if (m_hJob == LL_ERR_NO_LANG_DLL)
	{
		MessageBox(_T("Language file not found!\nEnsure that *.lng files can be found in your LL DLL directory."),
				   _T("List & Label Sample App"),
				   MB_OK | MB_ICONSTOP);
	}
	else
	{
		auto lookupDatabasePath = []() {
			TCHAR  szPath[MAX_PATH];
			CDPString sRet;
			CDPString sDBName = DATABASENAME;
			// Retrieve the full path for the current module.
			if (sDBName.empty() || GetModuleFileName(NULL, szPath, sizeof szPath) == 0)
				return sRet;
			auto sPathData = SQLiteHelp::strsplit(CDPString(szPath), L'\\');
			sPathData.erase(std::remove_if(sPathData.begin(), sPathData.end(), [](const CDPString& e) { return e.empty(); }), sPathData.end());
			while(sPathData.size() > 1)
			{
				sPathData.pop_back();
				sRet.clear();
				for (auto& e : sPathData)
					sRet += sRet.empty() ? e : (CDPString(L"\\") + e);
				sRet += (CDPString(L"\\") + sDBName);
				if (_waccess(sRet.c_str(), 0) == 0)
					return sRet;
			}
			return sRet;
		};
		
		// D:   Datenbankschema konfigurieren und die Datenbank öffnen
		// US:  Configure and open database
		CDPSchema::CSchemaFilter& filter = _PM.GetSchema().GetFilter();
		filter._databasepath = lookupDatabasePath();
		filter._tablefilt = L"-Playlist*,+*";
		//filter._mastertable = L"+OnTheFlyMaster";
		//filter._vartables = L"+OnTheFlyMaster";
		filter._bUseInMemoryDB = true;
		CPrintManager::CJobDataRec::bUseDelayedDefinition = true;
		
		auto customInit = [](CPrintManager* pm) -> void
		{
			{
				SQLiteStatement::Execute(*pm->GetConnection(), "create table OnTheFlyMaster (Key1 INT, Key2 INT, Text TEXT);");
				for (int i = 0; i < 10; i++)
					for (int x = 0; x < 10; x++)
						SQLiteStatement::Execute(*pm->GetConnection(), "insert into OnTheFlyMaster values (?1, ?2, ?3);", i, x, SQLiteHelp::xsprintf("OnTheFlyMaster_%d_%d", i, x));
			}
			{
				SQLiteStatement::Execute(*pm->GetConnection(), "create table OnTheFly (Key1 INT, Key2 INT, Text TEXT);");
				for (int i = 0; i < 10; i++)
					for (int x = 0; x < 10; x++)
						SQLiteStatement::Execute(*pm->GetConnection(), "insert into OnTheFly values (?1, ?2, ?3);", i, x, SQLiteHelp::xsprintf("OnTheFly_%d_%d", i, x));
			}
			{
				SQLiteStatement::Execute(*pm->GetConnection(), "create table OnTheFly2 (Key1 INT REFERENCES OnTheFly (Key1), Key2 INT REFERENCES OnTheFly (Key2), Text TEXT);");
				for (int i = 0; i < 10; i++)
					for (int x = 0; x < 10; x++)
						SQLiteStatement::Execute(*pm->GetConnection(), "insert into OnTheFly2 values (?1, ?2, ?3);", i, x, SQLiteHelp::xsprintf("OnTheFly2_%d_%d", i, x));
			}
		};
		filter._CustomDataInit = std::make_shared<std::function<void(CPrintManager*)>>(customInit);
		if (!_PM.Init(true))
		{
			GetDlgItem(IDC_BTN_DESIGN_REPORT)->EnableWindow(FALSE);
			GetDlgItem(IDC_BTN_PRINT_REPORT)->EnableWindow(FALSE);
		}
	}

	return TRUE;  // return TRUE  unless you set the focus to a control
}
//---------------------------------------------------------------------
// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.
void CPrtdataprovDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM)dc.GetSafeHdc(), 0);

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
//---------------------------------------------------------------------
// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CPrtdataprovDlg::OnQueryDragIcon()
{
	return (HCURSOR)m_hIcon;
}
//---------------------------------------------------------------------
void CPrtdataprovDlg::OnBtnDesignReport()
{
	int nRet = 0;
	CString sFileName = _T("NestedSubTables.lst");

	nRet = LlSelectFileDlgTitleEx(m_hJob, m_hWnd, _T(""), LL_PROJECT_LIST | LL_FILE_ALSONEW
								  , sFileName.GetBuffer(1024), 1024, NULL);

	sFileName.ReleaseBuffer();

	if (nRet < 0)
	{
		CString sErrorText;
		sErrorText.Format(_T("Error while opening file. (Error: %d)"), nRet);
		if (nRet != LL_ERR_USER_ABORTED)
			MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK | MB_ICONEXCLAMATION);
		return;
	}

	// D:   Erzeugen des Datenproviders. Initialisierung des PrintJobs und Ausführung via InitJob/RunJob
	// US:  Creation of the Datenprovider. Initialize the PrintJob und subsequently execute via InitJob/RunJob.

	CPrintManager::CJobDataRec JR;
	JR._uJobType = CPrintManager::CJobType::TYPE_DESIGN;
	JR._pDataProvider = new CPrintDataProviderRoot(_PM, 0);
	JR._sFilename = (LPCTSTR)sFileName;
	JR._hWnd = m_hWnd;
	_PM.InitJob(JR);
	_PM.RunJob(JR._hJob);
}
//---------------------------------------------------------------------
void CPrtdataprovDlg::OnBtnPrintReport()
{
	int nRet = 0;
	CString sFileName = _T("NestedSubTables.lst");

	// D:   Auswahl der Projekt-Datei über Datei-Auswahl-Dialog
	// US: Select project-file via File-Select dialog
	nRet = LlSelectFileDlgTitleEx(m_hJob, m_hWnd, _T(""), LL_PROJECT_LIST
								  , sFileName.GetBuffer(1024), 1024, NULL);
	sFileName.ReleaseBuffer();

	if (nRet < 0)
	{
		CString sErrorText;
		sErrorText.Format(_T("Error While Printing. (Error: %d)"), nRet);
		if (nRet != LL_ERR_USER_ABORTED)
			MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK | MB_ICONEXCLAMATION);

		return;
	}

	// D:   Erzeugen des Datenproviders. Initialisierung des PrintJobs und Ausführung via InitJob/RunJob   
	// US:  Creation of the Datenprovider. Initialize the PrintJob und subsequently execute via InitJob/RunJob.

	CPrintManager::CJobDataRec JR;
	JR._uJobType = CPrintManager::CJobType::TYPE_PRINT;
	JR._pDataProvider = new CPrintDataProviderRoot(_PM, 0);
	JR._sFilename = (LPCTSTR)sFileName;
	JR._hWnd = m_hWnd;

	_PM.InitJob(JR);
	_PM.RunJob(JR._hJob);
}
//---------------------------------------------------------------------
void CPrtdataprovDlg::OnClose()
{
	// D:   Beenden des List & Label Jobs
	// US: Close the List & Label Job
	LlJobClose(m_hJob);
	CDialog::OnClose();
}

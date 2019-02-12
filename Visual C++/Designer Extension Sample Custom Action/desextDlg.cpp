// desextDlg.cpp : implementation file
//

#include "stdafx.h"
#include "desext.h"
#include "desextDlg.h"
#include "XInputForm.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDesextDlg dialog

// D:  Registrieren eines Nachrichtenkanals für List & Label Callbacks
// US: register LuL MessageBase:
UINT CDesextDlg::m_uLuLMessageBase = RegisterWindowMessage(_T("cmbtLLMessage"));

CDesextDlg::CDesextDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDesextDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CDesextDlg)
	m_bDebug = FALSE;
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_LL_ICON);
}

void CDesextDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDesextDlg)
	DDX_Check(pDX, IDC_CHECK_DEBUG, m_bDebug);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CDesextDlg, CDialog)
	//{{AFX_MSG_MAP(CDesextDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_DESIGN, OnButtonDesign)
	ON_BN_CLICKED(IDC_CHECK_DEBUG, OnCheckDebug)
	ON_WM_CLOSE()
	//}}AFX_MSG_MAP
	ON_REGISTERED_MESSAGE(m_uLuLMessageBase,OnLulMessage)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// helper function
CString GetSamplePath()
{
	TCHAR app_path[_MAX_PATH];
	GetModuleFileName((HMODULE)AfxGetApp()->m_hInstance, app_path, MAX_PATH);
	
	TCHAR drive[_MAX_DRIVE], dir[_MAX_DIR], fname[_MAX_FNAME], ext[_MAX_EXT];
	_wsplitpath_s(app_path, drive, _MAX_DRIVE, dir, _MAX_DIR, fname, _MAX_FNAME, ext, _MAX_EXT);
	CString app_str = app_path;
	app_str.Format(_T("%s%s"), (LPCTSTR)drive, (LPCTSTR)dir);
	app_str = app_str.Left(app_str.ReverseFind('\\'));
	app_str = app_str.Left(app_str.ReverseFind('\\'));

	return app_str;
}

/////////////////////////////////////////////////////////////////////////////
// CDesextDlg message handlers
//================================================================================
BOOL CDesextDlg::OnInitDialog()
//================================================================================
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	m_hJob = LlJobOpen(-1);

	if (m_hJob==LL_ERR_BAD_JOBHANDLE)
	{
		MessageBox(_T("Job can't be initialized!"), _T("List & Label Sample App"), MB_OK|MB_ICONSTOP);
	}
	else if (m_hJob==LL_ERR_NO_LANG_DLL)
	{
		MessageBox(_T("Language file not found!\nEnsure that *.lng files can be found in your LuL DLL directory."),
					_T("List & Label Sample App"),
					MB_OK|MB_ICONSTOP);
	}
	
	OnCheckDebug();

	// Report file name:
	m_sFileName = GetSamplePath() + _T("\\desext.lst");
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.
//================================================================================
void CDesextDlg::OnPaint() 
//================================================================================
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
//================================================================================
HCURSOR CDesextDlg::OnQueryDragIcon()
//================================================================================
{
	return (HCURSOR) m_hIcon;
}


//================================================================================
void CDesextDlg::OnButtonDesign() 
//================================================================================
{
	int nReturn;
	// D: Designer um Button erweitern
	nReturn = LlDesignerAddAction(m_hJob, 10100,  
				LLDESADDACTIONFLAG_ADD_TO_TOOLBAR | LLDESADDACTION_ACCEL_VIRTKEY | LLDESADDACTION_ACCEL_CONTROL | 0x46, 
				_T("&Find object"), _T("1.1"), _T("Find object"), 642, NULL);


	if (LlDefineLayout(m_hJob, m_hWnd, _T("Designer"), LL_PROJECT_LIST, m_sFileName) < 0)
	{
	    MessageBox(_T("Error by calling LlDefineLayout"), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
		return;
	}	

}


//================================================================================
void CDesextDlg::OnCheckDebug() 
//================================================================================
{
	UpdateData(TRUE);
	LlSetDebug(m_bDebug);
}


//================================================================================
void CDesextDlg::OnClose() 
//================================================================================
{
	// D:	Beenden des List & Label Jobs
	// US:	Close the List & Label Job
	LlJobClose(m_hJob);
	CDialog::OnClose();
}


//=============================================================================
LRESULT CDesextDlg::OnLulMessage(WPARAM wParam, LPARAM lParam)
//=============================================================================
{
	// D:  Dies ist die List & Label Callback Funktion.
	//     Saemtliche Rueckmeldungen bzw. Events werden dieser Funktion
	//     gemeldet.
	// US: This is the List & Label Callback function.
	//     Is is called for requests an notifications.


	PSCLLCALLBACK	pscCallback = (PSCLLCALLBACK) lParam;
	LRESULT			lRes = TRUE;


	ASSERT(pscCallback->_nSize == sizeof(scLlCallback));	// D:  Die groesse der Callback Struktur muss stimmen!
															// US: sizes of callback structs must match!

	switch(wParam)
	{
		case LL_QUERY_DESIGNERACTIONSTATE:
			// D:  Aktion immer erlauben, hier kann ansonsten auch eine Bedingung verwendet werden 
			// US: Always allow the action, otherwise you could use a condition 
			pscCallback->_lReply = (1); // (Default: 1)
			break;


		case LL_CMND_SELECTMENU:
			if (pscCallback->_lParam == 10100)
			{
				// execute custom code
				ExecuteDesignerAction();
				
				return (TRUE);
			}
			break;


		default:
				pscCallback->_lReply = lRes = FALSE; // D:   Die Nachricht wurde nicht bearbeitet.
													 // US: indicate that message hasn't been processed
	}

	return(lRes);
}


//=============================================================================
int CDesextDlg::ExecuteDesignerAction()
//=============================================================================
{
	//D: Das DOM Objekt für das Projekt erzeugen
	//US: Get the project's DOM object 
	HLLDOMOBJ hProj; 
	int nRet = LlDomGetProject(m_hJob, &hProj);
	if(nRet < 0 )
	{
		MessageBox(_T("Error open project"), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
		return nRet;
	}
	CDomItem oDOMProject(hProj);


	// D: Objektname eingeben:
	// US: Input object name:
	CXInputForm	*pDlg = new CXInputForm();
	CString sObjName = "objText2";
	pDlg->m_sObjectName = sObjName;

	if (pDlg->DoModal() == IDOK)
	{	
		sObjName = pDlg->m_sObjectName;
	}
	
	delete pDlg;
	
	//D: Redraw im Projekt deaktivieren:
	//US: No Redraw:
	oDOMProject.SetProperty(_T("DesignerRedraw"), "False");


	//D: Das Objektlistenobjekt erzeugen
	//US: Get the object list object 
	CDomItem oObjectList = oDOMProject.GetObject(_T("Objects"));
	int nItemCount = 0;
	oObjectList.ItemCount(nItemCount);

	CString sItemObjectName;
	bool bFound = false;

	// D: Objektliste interieren:
	// US: Interate the object list:
	for (int y=0; y < nItemCount; y++)
	{ 
		CDomItem oItemObject = oObjectList[y];
		oItemObject.GetProperty(_T("Name"), sItemObjectName);

		if (sItemObjectName == sObjName)
		{
			bFound  = true;
			oItemObject.SetProperty(_T("Selected"), _T("True"));
		}
		else
		{
			oItemObject.SetProperty(_T("Selected"), _T("False"));
		}		

	}

	//D: Redraw im Projekt wieder aktivieren um z.B. MessageBoxen wieder anzuzeigen:
	//US: Activate Redraw:
	oDOMProject.SetProperty(_T("DesignerRedraw"), _T("True"));
	
	if (!bFound)
    {
		MessageBox(_T("The object could not be found."), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
	}

	return nRet;
}

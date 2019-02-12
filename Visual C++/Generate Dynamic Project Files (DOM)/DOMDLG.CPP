// DOMDlg.cpp : implementation file
//

#include "stdafx.h"
#include "DOM.h"
#include "DOMDlg.h"
#include "..\cmbtll24.h"
#include "DomItem.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDOMDlg dialog

CDOMDlg::CDOMDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDOMDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CDOMDlg)
	m_sLogoPath = _T("");
	m_sProjectTitle = _T("");
	m_bDebug = FALSE;
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CDOMDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDOMDlg)
	DDX_Control(pDX, IDC_LIST_SELECTED_VARS, m_oListSelectedVars);
	DDX_Control(pDX, IDC_LIST_AVAILABLE_VARS, m_oListAvailableVars);
	DDX_Control(pDX, IDC_CHECK_DEBUG, m_oCheckDebug);
	DDX_Control(pDX, IDC_EDIT_LOGO_PATH, m_oEditLogoPath);
	DDX_Text(pDX, IDC_EDIT_LOGO_PATH, m_sLogoPath);
	DDX_Text(pDX, IDC_EDIT_PROJECT_TITLE, m_sProjectTitle);
	DDX_Check(pDX, IDC_CHECK_DEBUG, m_bDebug);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CDOMDlg, CDialog)
	//{{AFX_MSG_MAP(CDOMDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_CLOSE()
	ON_COMMAND(IDCANCEL,OnCancel)
	ON_BN_CLICKED(IDC_BUTTON_CREATE_REPORT, OnButtonCreateReport)
	ON_BN_CLICKED(IDC_BUTTON_PREVIEW, OnButtonPreview)
	ON_BN_CLICKED(IDC_BUTTON_SELECT_FILE, OnButtonSelectFile)
	ON_BN_CLICKED(IDC_BUTTON_SELECT, OnButtonSelect)
	ON_BN_CLICKED(IDC_BUTTON_DESELECT, OnButtonDeselect)
	ON_BN_CLICKED(IDC_CHECK_DEBUG, OnCheckDebug)
	//}}AFX_MSG_MAP
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
// CDOMDlg message handlers
//================================================================================
BOOL CDOMDlg::OnInitDialog()
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
	m_sFileName = GetSamplePath() + _T("\\dynamic.lst");

	// D: Default Werte setzten
	// US: Set default value
	m_sLogoPath = GetSamplePath() + _T("\\sunshine.gif");
	m_oEditLogoPath.SetWindowText(m_sLogoPath);

	GetDlgItem(IDC_EDIT_PROJECT_TITLE)->SetWindowText(_T("Dynamically created Project"));
	FillListControl(0);

	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.
//================================================================================
void CDOMDlg::OnPaint() 
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
HCURSOR CDOMDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

//================================================================================
void CDOMDlg::DefineFields(int nRecord)
//================================================================================
{
	CString sVarName, sVarContent;

	// D:	Hier werden virtuelle Felder definiert.
	//		 Wichtig: Normalerweise würden Sie hier ihre Datenbankfelder anmelden
	// US:	Define virtual variables
	//		 Important: Normally, you would define your database fields here

	CString sLine;
	for (int y=0; y < m_oListSelectedVars.GetItemCount() ; y++)
	{ 
		sLine = m_oListSelectedVars.GetItemText(y,0);
		sVarName = sLine;
		sVarContent.Format(_T("%s, Record No. %d"), (LPCTSTR)sLine, nRecord);
		LlDefineField(m_hJob, sVarName, sVarContent);
	}

    // D:	Definition eines numerischen Feldes
    // US:	Definition of a numerical field
	LlDefineFieldExt(m_hJob, _T("FixedField10"), _T("1"), LL_NUMERIC, NULL);
}

//================================================================================
void CDOMDlg::FillListControl(int nRecord)
//================================================================================
{
	CString sVarName, sVarContent;

	// D:	CListCtrl füllen
	// US:	Fill CListCtrl
	for (int i=0; i<9; i++)
	{
		sVarName.Format(_T("FixedField%d"), i);
		sVarContent.Format(_T("FixedField%d, Record No. %d"), i, nRecord);
 	
		if(i < 3)
			m_oListSelectedVars.InsertItem(i, sVarName);
		else
			m_oListAvailableVars.InsertItem(i, sVarName);
	}
}

//================================================================================
void CDOMDlg::OnCancel()
//================================================================================
{
	// D:	Beenden des List & Label Jobs
	// US:	Close the List & Label Job
	LlJobClose(m_hJob);
	CDialog::OnCancel();
}

//================================================================================
void CDOMDlg::OnClose() 
//================================================================================
{
	// D:	Beenden des List & Label Jobs
	// US:	Close the List & Label Job
	LlJobClose(m_hJob);
	CDialog::OnClose();
}

//D:	Beim Verwenden der List & Label DOM Klassen ist zu beachten, dass die einzelnen Werte als Zeichenkette angegeben werden müssen.
//		 Dies ist notwendig um ein Höchstmass an Flexibilität zu gewährleisten, da somit auch List & Label Formeln erlaubt sind.
//US:	Hint: When using List & Label DOM classes please note that the values have to be passed as strings. This is necessary to ensure a
//		 maximum of flexibility, as List & Label formulas are also allowed for the values.
//================================================================================
int CDOMDlg::GenerateLLProject()
//================================================================================
{
	UpdateData(true);

	//D: Ein neues Listen-Projekt mit dem Namen 'dynamic.lst' erstellen
	//US: Create a new list project called 'dynamic.lst'
	int nRet = LlProjectOpen(m_hJob, LL_PROJECT_LIST, m_sFileName, LL_PRJOPEN_CD_CREATE_ALWAYS | LL_PRJOPEN_AM_READWRITE);
	if(nRet < 0 )
	{
		MessageBox(_T("Error open project"), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
		return nRet;
	}

	//D: Das DOM Objekt für das Projekt erzeugen
	//US: Get the project's DOM object 
	HLLDOMOBJ hProj; 
	nRet = LlDomGetProject(m_hJob, &hProj);
	CDomItem oDOMProject(hProj);

	//D: Eine neue Projektbeschreibung dem Projekt zuweisen
	//US: Assign new project description to the project
	oDOMProject.SetProperty(_T("ProjectParameters.LL.ProjectDescription.Contents"), m_sProjectTitle);

	//D: Das Objektlistenobjekt erzeugen
	//US: Get the object list object 
	CDomItem oObjectList = oDOMProject.GetObject(_T("Objects"));

	// D: Die nachfolgenden Objekte stehen für die Neuanlage im Designer zur Verfügung:
	// US: The following objects are available in the designer:
	// "Line", "Rectangle", "Ellipse", "Drawing", "Text", "Template", "Barcode", "RTFText", 
	// "LLX:LLHTMLOBJECT", "ReportContainer", "Crosstab"

	//D: Ein leeres Text Objekt erstellen
	//US: Create an empty text object
	CDomItem oTextObject( oObjectList.CreateSubObject(0, _T("Text")));
	oTextObject.SetProperty(_T("Name"), _T("My new Textobject"));

	//D: Auslesen der Seitenkoordinaten der ersten Seite
	//US: Get the page coordinates for the first page
	CDomItem oRegionsList = oDOMProject.GetObject(_T("Regions"));
	CDomItem oRegion = oRegionsList[0];


	CString sHorizontal;
	oRegion.GetProperty(_T("Paper.Extent.Horizontal"), sHorizontal);
	
	int nHorizontal = 0;
	nHorizontal = _wtoi(sHorizontal) - 105000;
	sHorizontal.Format(_T("%d"), nHorizontal);
	
	//D: Setzen von Eigenschaften für das Textobjekt
	//US: Set some properties for the text object
	oTextObject.SetProperty(_T("Position.Left"),  _T("10000"));
	oTextObject.SetProperty(_T("Position.Top"),  _T("10000"));
	oTextObject.SetProperty(_T("Position.Width"),  sHorizontal);
	oTextObject.SetProperty(_T("Position.Height"),  _T("27000"));

	// D: Der Ebene "Erste Seite" zuweisen
	// US: Assign to "First Page" layer
	oTextObject.SetProperty(_T("LayerID"), "1");

	//D: Hinzufügen eines Absatzes und Setzen diverser Eigenschaften
	//US: Add a paragraph to the text object and set some properties
	CDomItem oParagraphList( oTextObject.GetObject(_T("Paragraphs")));
	CDomItem oParagraph( oParagraphList.CreateSubObject(0, _T("Paragraph")));
	oParagraph.SetProperty(_T("Contents"), _T("'") + m_sProjectTitle + _T("'"));
	oParagraph.SetProperty(_T("Font.Bold"), _T("True"));
	oParagraph.SetProperty(_T("Font.Size"), _T("16.0"));

	//D: Hinzufügen eines Grafikobjekts
	//US: Add a drawing object
	CDomItem oDrawingObject( oObjectList.CreateSubObject(0, _T("Drawing")));
	oDrawingObject.SetProperty("Source.FileInfo.Filename", m_sLogoPath);
	oDrawingObject.SetProperty(_T("Position.Left"),  _T("120000"));
	oDrawingObject.SetProperty(_T("Position.Top"),  _T("9700"));
	oDrawingObject.SetProperty(_T("Position.Width"),  _T("73500"));
	oDrawingObject.SetProperty(_T("Position.Height"),  _T("36200"));

	// D: Der Ebene "Erste Seite" zuweisen
	// US: Assign to "First Page" layer
	oDrawingObject.SetProperty(_T("LayerID"), "1");

	// D: Die nachfolgenden Objekte stehen für die Neuanlage innerhalb einer Tabellenzeile zur Verfügung:
	// US: The following objects are available in a table row:
	// "Text", "RTFText", "Drawing", "Barcode", "LLX:LLHTMLObject"

	//D: Hinzufügen eines Berichtscontainers und Setzen diverser Eigenschaften
	//US: Add a report container and set some properties
	CDomItem oReportContainer( oObjectList.CreateSubObject(0, _T("ReportContainer")));
	oReportContainer.SetProperty(_T("Position.Left"), _T("14000"));
	oReportContainer.SetProperty(_T("Position.Top"),  _T("70000"));
	oReportContainer.SetProperty(_T("Position.Width"), _T("177000"));
	oReportContainer.SetProperty(_T("Position.Height"), _T("210000"));

	// D: Verketten des Berichtscontainers mit dem Textobjekt
	// US: Link the report container to the text object
	CString sTextID;
	oTextObject.GetProperty(_T("ID"), sTextID);
	oReportContainer.SetProperty(_T("LinkID"), sTextID);

	// D: Verkettung: Positionsanpassung vertikal:relativ zu Ende.
	// D: Grössenanpassung vertikal:invers
	// US: Link To - Type: Position Adaption: Vertical Relativ to end.
	// US: Size Adaption: Vertical Proportinal
	CString sLinkMode;
	int nLinkMode = LL_LINK_VPOS_END | LL_LINK_VSIZE_INV;
	sLinkMode.Format(_T("%d"), nLinkMode);
	oReportContainer.SetProperty(_T("LinkMode"), sLinkMode );

	//D: Eine Tabelle im Berichtscontainer hinzufügen
	//US: Add a table to the report container
	CDomItem oSubItems(oReportContainer.GetObject(_T("SubItems")));
	CDomItem oTable(oSubItems.CreateSubObject(0, _T("Table")));

	//D: Eine neue Datenzeile hinzufügen 
	//US: Add a new data line
	CDomItem oTableLines( oTable.GetObject(_T("Lines")));
	CDomItem oTableData( oTableLines.GetObject(_T("Data")));

	CDomItem oDataLine( oTableData.CreateSubObject(0, _T("Line")));
	oDataLine.SetProperty(_T("Name"), _T("My new table line"));

	CString sContainerPositionWidth;
	oReportContainer.GetProperty(_T("Position.Width"), sContainerPositionWidth);
	int nContainerPositionWidth = _wtoi(sContainerPositionWidth);

	//D: Kopfzeile hinzufügen
	//US: Add header line
	CDomItem oTableHeader(oTableLines.GetObject(_T("Header")));
	CDomItem oHeaderLine(oTableHeader.CreateSubObject(0, _T("Line")));

	//D: Kopf- und Datenzeile mit den gewählten Feldern füllen
	//US: Add the selected fields to the header and data line
	CString sVarContent;
	CString sVarName;
	int nItemCount = m_oListSelectedVars.GetItemCount();
	CString sfieldWidth;

	CDomItem oHeaderFields(oHeaderLine.GetObject(_T("Fields")));
	CDomItem oTableLinesFields( oDataLine.GetObject(_T("Fields")));

	for (int y=0; y < nItemCount; y++)
	{ 
		sVarName		= m_oListSelectedVars.GetItemText(y,0);
		int nfieldWidth = nContainerPositionWidth / nItemCount;
		sfieldWidth.Format(_T("%d"), nfieldWidth);

		//D: Kopfzeile füllen
		//US: Define header line
		CDomItem oTableHeaderField(oHeaderFields.CreateSubObject(0, _T("Text")));
		oTableHeaderField.SetProperty(_T("Contents"),  _T("'")+ sVarName +_T("'"));
		oTableHeaderField.SetProperty(_T("Filling.Style"),  "1");
		oTableHeaderField.SetProperty(_T("Filling.Color"), _T( "RGB(204,204,255)"));
		oTableHeaderField.SetProperty(_T("Font.Bold"), _T("True"));
		oTableHeaderField.SetProperty(_T("Width"), sfieldWidth);

		//D: Datenzeile füllen
		//US: Define data line
		CDomItem oTableLine(oTableLinesFields.CreateSubObject(0, _T("Text")));
		oTableLine.SetProperty(_T("Contents"),  sVarName);
		oTableLine.SetProperty(_T("Width"), sfieldWidth);
	}

	//D: Projekt speichern
	//US: Save project
	LlProjectSave(m_hJob, NULL);

	//D: Projekt schliessen
	//US: Close project
	LlProjectClose(m_hJob);

	return nRet;
}


//================================================================================
void CDOMDlg::OnButtonCreateReport() 
//================================================================================
{
	UpdateData(TRUE);

    // D:   Zurücksetzen der internen Feld-Puffer
    // US: Clear the field buffer
    LlDefineFieldStart(m_hJob);
	
	// D:	Hier werden virtuelle Variablen definiert.
	//		 Wichtig: Normalerweise würden Sie hier ihre Datenbankfelder anmelden
	// US:	Define the variables virtually
	//		 Important: Normally you use here your database functions
	DefineFields(0);

	if(GenerateLLProject() >= 0)
	{
		if (LlDefineLayout(m_hJob, m_hWnd, _T("Designer"), LL_PROJECT_LIST, m_sFileName) < 0)
		{
	        MessageBox(_T("Error by calling LlDefineLayout"), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
			return;
		}
	}
}


//================================================================================
void CDOMDlg::OnButtonPreview() 
//================================================================================
{
	HWND hWnd = m_hWnd;
	int  nRet = 0;

    // D:   Zurücksetzen der internen Variablen-Puffer
    // US: define variables for load check
    LlDefineFieldStart(m_hJob);
	DefineFields(0);

	// D:   Auswahl der Projekt-Datei über Datei-Auswahl-Dialog
    // US: Select project-file via File-Select dialog
	if(GenerateLLProject() < 0)
	{
	        MessageBox(_T("Error creating project"), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
			return;
	}


    // D:   Druck starten
    // US: Start printing
	if (LlPrintWithBoxStart(m_hJob, LL_PROJECT_LIST, m_sFileName,
							LL_PRINT_EXPORT,
							LL_BOXTYPE_STDABORT, hWnd, _T("Printing...")) < 0)
    {
        MessageBox(_T("Error While Printing"), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
        return;
    }

	LlPrintSetOption(m_hJob, LL_OPTION_COMPRESSSTORAGE | LL_STG_COMPRESS_THREADED, 0);
	LlPrintSetOptionString(m_hJob, LL_PRNOPTSTR_EXPORT, _T("PRV"));
	
    int  nRecCount = 11, nLastPage, nRecno;

	nLastPage = LlPrintGetOption(m_hJob, LL_OPTION_LASTPAGE);
    nRecno = 1;

	nRet = LlPrint(m_hJob);
	while (nRet == LL_WRN_REPEAT_DATA)
	{
		nRet = LlPrint(m_hJob);
	}

    // D:   Druckschleife
    //     Diese wird so lange wiederholt, bis sämtliche Daten abgearbeitet wurden, oder
    //     ein Fehler auftritt.
    // US: Do printing loop only when there is any data to be printed and no error has occurred:
	while (nRecno < nRecCount && (nRet == 0) && (LlPrintGetCurrentPage(m_hJob) <= nLastPage))
	{
    	// D:   Prozentbalken in der Fortschritts-Anzeige setzen
        // US: Set percent-bar
    	nRet = LlPrintSetBoxText(m_hJob, _T("Printing..."), (100 * nRecno / nRecCount));
        if (nRet == LL_ERR_USER_ABORTED)
   		{
    		LlPrintEnd(m_hJob,0);
    		return;
   		}

		DefineFields(nRecno);

    	// D:   Drucken der aktuellen Tabellenzeile
    	// US: Now print the table line:
    	nRet = LlPrintFields(m_hJob);

		while (nRet == LL_WRN_REPEAT_DATA)
		{
			LlPrint(m_hJob);
			nRet = LlPrintFields(m_hJob);
		}

	    // D:   gehe zum naechsten Datensatz
	    // US: now (virtually) goto next record
		nRecno++;
  	}

	// D:	Alle Datensätze wurden gedruckt, jetzt wird die Tabelle geleert
	//		 Sollte die Fußzeile nicht auf diese Seite passen, wird es auf der nächsten probiert:
	// US:	All records have been printed, now flush the table
	//		 If footer doesn't fit to this page try again for the next page:
	while (LlPrintFieldsEnd(m_hJob)==LL_WRN_REPEAT_DATA)
	{
		// D:	Wiederholungen...
		// US:	just repeat...
	}

	//D:   Druck beenden
    //US: Ends printjob
	LlPrintEnd(m_hJob, 0);
}


//================================================================================
void CDOMDlg::OnButtonSelectFile() 
//================================================================================
{
	CFileDialog dlg(TRUE, _T("*.jpg; *.gif; *.bmp; *.png; *.wmf"), NULL, OFN_FILEMUSTEXIST|OFN_HIDEREADONLY, 
	_T("All Picture Files (*.jpg, *.gif, *.bmp, *.png, *.wmf)|*.jpg; *.gif; *.bmp; *.png; *.wmf|All files (*.*)|*.*||")); 	
	
	CString sInitDir = GetSamplePath();
	dlg.m_ofn.lpstrInitialDir = sInitDir;

	if (dlg.DoModal() == IDOK)
	{
		m_sLogoPath = dlg.GetPathName();
		m_oEditLogoPath.SetWindowText(m_sLogoPath);
	}
}

//================================================================================
void CDOMDlg::OnButtonSelect() 
//================================================================================
{
	UINT i, uSelectedCount = m_oListAvailableVars.GetSelectedCount();
	int  nItem = -1;

	if (uSelectedCount > 0)
	{
		CString sLine;
		for (i=0;i < uSelectedCount;i++)
		{
			nItem = m_oListAvailableVars.GetNextItem(nItem, LVNI_SELECTED);
			m_oListSelectedVars.InsertItem(m_oListSelectedVars.GetItemCount() + 1, m_oListAvailableVars.GetItemText(nItem, 0));
			m_oListAvailableVars.DeleteItem(nItem);
		}
	}
}

//================================================================================
void CDOMDlg::OnButtonDeselect() 
//================================================================================
{
	UINT i, uSelectedCount = m_oListSelectedVars.GetSelectedCount();
	int  nItem = -1;

	if (uSelectedCount > 0)
	{
		CString sLine;
		for (i=0;i < uSelectedCount;i++)
		{
			nItem = m_oListSelectedVars.GetNextItem(nItem, LVNI_SELECTED);
			m_oListAvailableVars.InsertItem(m_oListAvailableVars.GetItemCount() + 1, m_oListSelectedVars.GetItemText(nItem, 0));
			m_oListSelectedVars.DeleteItem(nItem);	
		}
	}
}

//================================================================================
void CDOMDlg::OnCheckDebug() 
//================================================================================
{
	UpdateData(TRUE);

	LlSetDebug(m_bDebug);
}

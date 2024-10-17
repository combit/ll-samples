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
// prtloopDlg.cpp : implementation file
//

#include "stdafx.h"
#include "prtloop.h"
#include "prtloopDlg.h"
#include "..\cmbtll30.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CPrtloopDlg dialog

CPrtloopDlg::CPrtloopDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CPrtloopDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CPrtloopDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CPrtloopDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CPrtloopDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}
// D:   Registrieren eines Nachrichtenkanals für List & Label Callbacks
// US: register LuL MessageBase:
UINT CPrtloopDlg::m_uLuLMessageBase = RegisterWindowMessage(_T("cmbtLLMessage"));

BEGIN_MESSAGE_MAP(CPrtloopDlg, CDialog)
	//{{AFX_MSG_MAP(CPrtloopDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_DESIGN_REPORT, OnBtnDesignReport)
	ON_BN_CLICKED(IDC_BTN_PRINT_REPORT, OnBtnPrintReport)
	ON_BN_CLICKED(IDC_BTN_DESIGN_LABEL, OnBtnDesignLabel)
	ON_BN_CLICKED(IDC_BTN_PRINT_LABEL, OnBtnPrintLabel)
	ON_WM_CLOSE()
	ON_REGISTERED_MESSAGE(m_uLuLMessageBase,OnLulMessage)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPrtloopDlg message handlers

BOOL CPrtloopDlg::OnInitDialog()
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

	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CPrtloopDlg::OnPaint() 
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
HCURSOR CPrtloopDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

// ------------------------------------------------------------------------------
void CPrtloopDlg::DefineVariables(int nRecord, bool isPrinting)
// ------------------------------------------------------------------------------
{
	CString sVarName, sVarContent;

	// D:   Hier werden virtuelle Variablen definiert.
	//     Wichtig: Normalerweise wuerden Sie hier ihre Datenbankfelder anmelden
	// US: Define the variables virtually
	//     Important: Normally you use here your database functions
	for (int i=1; i<10; i++)
	{
		sVarName.Format(_T("FixedVariable%d"), i);
		sVarContent.Format(_T("FixedVariable%d, Record No. %d"), i, nRecord);
		    
		// D:   Prüfen ob gedruckt wird
		// US:	check whether is printing
		if(isPrinting)
		{	
			POSITION pos = VarList.Find(sVarName);
			if(pos != NULL)
			{
				LlDefineVariable(m_hJob, sVarName, sVarContent);
			}
		}
		else
		{
			LlDefineVariable(m_hJob, sVarName, sVarContent);
		}
    }

    // D:   Definition eines numerischen Feldes
    // US: definition of a numerical field
	//     Important: Normally you'd use here your database functions
	LlDefineVariableExt(m_hJob, _T("FixedVariable10"), _T("1"), LL_NUMERIC, NULL);
	    // D:   Definition der Barcode-Variablen
    //     Normalerweise definiert man nur die Barcode-Typen die man benoetigt
    // US: definition of barcode variables
    //     Normally you define only the barcode variables which are really needed
	LlDefineVariableExt(m_hJob,_T("Barcode_EAN13"), _T("44|44444|44444"), LL_BARCODE_EAN13, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_EAN13P2"), _T("44|44444|44444|44"), LL_BARCODE_EAN13, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_EAN13P5"), _T("44|44444|44444|44444"), LL_BARCODE_EAN13, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_EAN128"), _T("EAN128ean1288"), LL_BARCODE_EAN128, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_CODE128"), _T("Code 128"), LL_BARCODE_CODE128, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_Codabar"), _T("A123456A"), LL_BARCODE_CODABAR, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_UPCA"), _T("44|44444"), LL_BARCODE_EAN8, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_UPCE"), _T("4|44444|44444"), LL_BARCODE_UPCA, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_3OF9"), _T("*TEST*"), LL_BARCODE_3OF9, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_25IND"), _T("44444"), LL_BARCODE_25INDUSTRIAL, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_25IL"), _T("444444"), LL_BARCODE_25INTERLEAVED, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_25MAT"), _T("44444"), LL_BARCODE_25MATRIX, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_25DL"), _T("44444"), LL_BARCODE_25DATALOGIC, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_POSTNET5"), _T("44444"), LL_BARCODE_POSTNET, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_POSTNET10"), _T("44444-4444"), LL_BARCODE_POSTNET, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_POSTNET12"), _T("44444-444444"), LL_BARCODE_POSTNET, NULL);
	LlDefineVariableExt(m_hJob,_T("Barcode_FIM"), _T("A"), LL_BARCODE_FIM, NULL);
}

// ------------------------------------------------------------------------------
void CPrtloopDlg::DefineFields(int nRecord, bool isPrinting)
// ------------------------------------------------------------------------------
{
	CString sFieldName, sFieldContent;	

    // D:   Hier werden virtuelle Felder definiert.
	//     Wichtig: Normalerweise wuerden Sie hier ihre Datenbankfelder anmelden
	// US: Define the fields virtually
	//     Important: Normally you use here your database functions
	for (int j=1; j<10; j++)
	{
		sFieldName.Format(_T("Field%d"), j);
		sFieldContent.Format(_T("Field%d, Record No.%d"), j, nRecord);

		// D:   Prüfen ob gedruckt wird
		// US:	check whether is printing	
		if(isPrinting)
		{
			POSITION pos = VarList.Find(sFieldName);
			if(pos != NULL)
			{
				LlDefineField(m_hJob, sFieldName, sFieldContent);
			}
		}
		else
		{
			LlDefineField(m_hJob, sFieldName, sFieldContent);
		}
    }

    // D:   Definition eines numerischen Feldes
    // US: definition of a numerical field
	//     Important: Normally you'd use here your database functions
	LlDefineFieldExt(m_hJob, _T("NumericalField"), _T("1"), LL_NUMERIC, NULL);

	 // D:   Definition der Barcode-Variablen
    //     Normalerweise definiert man nur die Barcode-Typen die man benoetigt
    // US: definition of barcode variables
    //     Normally you define only the barcode variables which you do need
    //     in this example the barcodes are constant
    //     so they will not defined again in the printing loop
		LlDefineFieldExt(m_hJob,_T("Barcode_EAN13"), _T("44|44444|44444"), LL_BARCODE_EAN13, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_EAN13P2"), _T("44|44444|44444|44"), LL_BARCODE_EAN13, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_EAN13P5"), _T("44|44444|44444|44444"), LL_BARCODE_EAN13, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_EAN128"), _T("EAN128ean128"), LL_BARCODE_EAN128, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_CODE128"), _T("Code 128"), LL_BARCODE_CODE128, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_Codabar"), _T("A123456A"), LL_BARCODE_CODABAR, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_UPCA"), _T("44|44444"), LL_BARCODE_EAN8, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_UPCE"), _T("4|44444|44444"), LL_BARCODE_UPCA, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_3OF9"), _T("*TEST*"), LL_BARCODE_3OF9, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_25IND"), _T("44444"), LL_BARCODE_25INDUSTRIAL, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_25IL"), _T("444444"), LL_BARCODE_25INTERLEAVED, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_25MAT"), _T("44444"), LL_BARCODE_25MATRIX, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_25DL"), _T("44444"), LL_BARCODE_25DATALOGIC, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_POSTNET5"), _T("44444"), LL_BARCODE_POSTNET, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_POSTNET10"), _T("44444-4444"), LL_BARCODE_POSTNET, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_POSTNET12"), _T("44444-444444"), LL_BARCODE_POSTNET, NULL);
	LlDefineFieldExt(m_hJob,_T("Barcode_FIM"), _T("A"), LL_BARCODE_FIM, NULL);
}


void CPrtloopDlg::OnBtnDesignReport() 
{
	int nRet = 0;
	CString sFileName = _T("simple.lst");
	HWND hWnd = m_hWnd;
	
	nRet = LlSelectFileDlgTitleEx(m_hJob, hWnd, _T(""), LL_PROJECT_LIST|LL_FILE_ALSONEW
								, sFileName.GetBuffer(1024), 1024, NULL);

	sFileName.ReleaseBuffer();

	if (nRet < 0)
   	{
    	CString sErrorText;
		sErrorText.Format(_T("Error while opening file. (Error: %d)"), nRet);
    	if (nRet != LL_ERR_USER_ABORTED)
			MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);

        return;
    }
	
	// D:   Zurücksetzen der internen Variablen-Puffer
	// US: Clear the variable Buffer
    LlDefineVariableStart(m_hJob);
	
	// D:   Hier werden virtuelle Variablen definiert.
	//     Wichtig: Normalerweise wuerden Sie hier ihre Datenbankfelder anmelden
	// US: Define the variables virtually
	//     Important: Normally you use here your database functions
	DefineVariables(0, false);
	
    // D:   Zurücksetzen der internen Feld-Puffer
    // US: Clear the field buffer
    LlDefineFieldStart(m_hJob);
	
    // D:   Hier werden virtuelle Felder definiert.
	//     Wichtig: Normalerweise wuerden Sie hier ihre Datenbankfelder anmelden
	// US: Define the fields virtually
	//     Important: Normally you use here your database functions
	DefineFields(0, false);
	
	nRet = LlDefineLayout(m_hJob, hWnd, _T("Designer"), LL_PROJECT_LIST, sFileName);
	if(nRet < 0)
    {
    	CString sErrorText;
		sErrorText.Format(_T("Error by calling LlDefineLayout. (Error: %d)"), nRet);
		MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
        return;
    }
}

void CPrtloopDlg::OnBtnPrintReport() 
{
	int nRet = 0, nTokenPos = 0, nBuffer = 0;
	HWND hWnd = m_hWnd;
	CString sFileName = _T("simple.lst"), VarListString;
	
	// D:   Auswahl der Projekt-Datei über Datei-Auswahl-Dialog
    // US: Select project-file via File-Select dialog
	nRet = LlSelectFileDlgTitleEx(m_hJob, hWnd, _T(""), LL_PROJECT_LIST
									, sFileName.GetBuffer(1024), 1024, NULL);
	sFileName.ReleaseBuffer();
	
	if (nRet < 0)
   	{
		CString sErrorText;
		sErrorText.Format(_T("Error While Printing. (Error: %d)"), nRet);
    	if (nRet != LL_ERR_USER_ABORTED)
			MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
		
        return;
    }

	nBuffer = LlGetUsedIdentifiers(m_hJob, sFileName, NULL ,0);
	if(nBuffer > 0)
	{
		//D: UsedIdentifiers aus dem Projekt lesen
		//US: get UsedIdentifiers from project
		LlGetUsedIdentifiers(m_hJob,sFileName, VarListString.GetBuffer(nBuffer), nBuffer);
		VarListString.ReleaseBuffer();
	}

	//D: String splitten und in liste einfügen
	//US: splitting the string an add items to list
	for(CString sItem = VarListString.Tokenize(_T(";"), nTokenPos); nTokenPos >= 0; sItem = VarListString.Tokenize(_T(";"), nTokenPos))
	{
		//D: UsedIdentifiers in Liste einfügen
		//US: adding UsedIdentifiers to list
		VarList.AddTail(CString(sItem) );
	}
	
    // D:   Zurücksetzen der internen Variablen-Puffer
	// US: Clear the variable Buffer
    LlDefineVariableStart(m_hJob);
	
	// D:   Hier werden virtuelle Variablen definiert.
	//     Wichtig: Normalerweise wuerden Sie hier ihre Datenbankfelder anmelden
	// US: Define the variables virtually
	//     Important: Normally you use here your database functions
	DefineVariables(0, true);
	
    // D:   Zurücksetzen der internen Feld-Puffer
    // US: Clear the field buffer
    LlDefineFieldStart(m_hJob);
	
    // D:   Hier werden virtuelle Felder definiert.
	//     Wichtig: Normalerweise wuerden Sie hier ihre Datenbankfelder anmelden
	// US: Define the fields virtually
	//     Important: Normally you use here your database functions
	DefineFields(0,true);
	
    // D:   Druck starten
    // US: Start printing
	nRet = LlPrintWithBoxStart(m_hJob, LL_PROJECT_LIST, sFileName,
							LL_PRINT_EXPORT,
							LL_BOXTYPE_STDABORT, hWnd, _T("Printing..."));
    if (nRet  < 0)
	{
        CString sErrorText;
		sErrorText.Format(_T("Error While Printing. (Error: %d)"), nRet);
		MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
        return;
    }
	
	LlPrintSetOptionString(m_hJob, LL_PRNOPTSTR_EXPORT, _T("PRV"));
	
	if (LlPrintOptionsDialog(m_hJob, hWnd, _T("Select printing options")) < 0)
    {
        LlPrintEnd(m_hJob,0);
        return;
    }
	
    int  nRecCount = 11, nLastPage, nRecno;
	
	nLastPage = LlPrintGetOption(m_hJob, LL_OPTION_LASTPAGE);
    nRecno = 1;
	
	while (LlPrint(m_hJob) == LL_WRN_REPEAT_DATA)
	{
	}
	
    // D:   Druckschleife
    //     Diese wird so lange wiederholt, bis saemtliche Daten abgearbeitet wurden, oder
    //     ein Fehler auftritt.
    // US: do printing loop only when there is any data to be printed and no error has occurred:
	while (nRecno < nRecCount && (nRet == 0) && (LlPrintGetCurrentPage(m_hJob) <= nLastPage))
	{
		DefineFields(nRecno,true);

    	// D:   Prozentbalken in der Fortschritts-Anzeige setzen
        // US: Set percent-bar
    	nRet = LlPrintSetBoxText(m_hJob, _T("Printing..."), (100 * nRecno / nRecCount));
        if (nRet == LL_ERR_USER_ABORTED)
   		{
    		LlPrintEnd(m_hJob,0);
    		return;
   		}

    	// D:   Drucken der aktuellen Tabellenzeile
    	// US: now print the table line:
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

	// US: all records have been printed, now flush the table
	//     If footer doesn't fit to this page try again for the next page:

	while (LlPrintFieldsEnd(m_hJob) == LL_WRN_REPEAT_DATA)
	{
		// US: just repeat...
	}

	//D:   Druck beenden
    //US: Ends printjob
	LlPrintEnd(m_hJob, 0);
}

void CPrtloopDlg::OnBtnDesignLabel() 
{
    int nRet = 0;
	CString sFileName = _T("simple.lbl");
	HWND hWnd = m_hWnd;

	// D:   Auswahl der Projekt-Datei über Datei-Auswahl-Dialog
    // US: Select project-file via File-Select dialog
	nRet = LlSelectFileDlgTitleEx(m_hJob, hWnd, _T(""), LL_PROJECT_LABEL|LL_FILE_ALSONEW
									, sFileName.GetBuffer(1024), 1024, NULL);

	sFileName.ReleaseBuffer();

	if (nRet < 0)
   	{
    	CString sErrorText;
		sErrorText.Format(_T("Error while opening file. (Error: %d)"), nRet);
    	if (nRet != LL_ERR_USER_ABORTED)
			MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);

        return;
    }
	
	// D:   Zurücksetzen der internen Variablen-Puffer
	// US: Clear the variable Buffer
    LlDefineVariableStart(m_hJob);
	DefineVariables(0, false);
	
	nRet = LlDefineLayout(m_hJob, hWnd, _T("Designer"), LL_PROJECT_LABEL, sFileName);
	if(nRet < 0)
    {
    	CString sErrorText;
		sErrorText.Format(_T("Error by calling LlDefineLayout. (Error: %d)"), nRet);
		MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
        return;
    }
}

void CPrtloopDlg::OnBtnPrintLabel() 
{
	int nRet = 0, nTokenPos = 0, nBuffer = 0;
	HWND hWnd = m_hWnd;
	CString sFileName = _T("simple.lbl"), VarListString;

	// D:   Auswahl der Projekt-Datei über Datei-Auswahl-Dialog
    // US: Select project-file via File-Select dialog
	nRet = LlSelectFileDlgTitleEx(m_hJob, hWnd, _T(""), LL_PROJECT_LABEL
									, sFileName.GetBuffer(1024), 1024, NULL);

	sFileName.ReleaseBuffer();
	if (nRet < 0)
   	{
		CString sErrorText;
		sErrorText.Format(_T("Error While Printing. (Error: %d)"), nRet);
    	if (nRet != LL_ERR_USER_ABORTED)
			MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);

        return;
    }

	nBuffer = LlGetUsedIdentifiers(m_hJob, sFileName, NULL, 0);
	if(nBuffer > 0)
	{	
		// D: UsedIdentifiers aus dem Projekt lesen
		// US: get UsedIdentifiers from project
		LlGetUsedIdentifiers(m_hJob, sFileName, VarListString.GetBuffer(nBuffer), nBuffer);
		VarListString.ReleaseBuffer();
	}

	// D: String splitten und in liste einfügen
	// US: splitting the string an add items to list
	for(CString sItem = VarListString.Tokenize(_T(";"), nTokenPos); nTokenPos >= 0; sItem = VarListString.Tokenize(_T(";"), nTokenPos))
	{
		// D: UsedIdentifiers in Liste einfügen
		// US: adding UsedIdentifiers to list
		VarList.AddTail(CString(sItem));
	}

    // D:   Zurücksetzen der internen Variablen-Puffer
    // US: define variables for load check
    LlDefineVariableStart(m_hJob);

	// D:  Variablen definieren und IsPrinting setzen
	// US: Define the variables and set IsPrinting
	DefineVariables(0, true);

    // D:   Druck starten
    // US: Start printing
	nRet = LlPrintWithBoxStart(m_hJob, LL_PROJECT_LABEL, sFileName,
							LL_PRINT_EXPORT,
							LL_BOXTYPE_STDABORT, hWnd, _T("Printing..."));
    if(nRet < 0)
	{
        CString sErrorText;
		sErrorText.Format(_T("Error While Printing. (Error: %d)"), nRet);
		MessageBox(sErrorText, _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
        return;
    }

	LlPrintSetOptionString(m_hJob, LL_PRNOPTSTR_EXPORT, _T("PRV"));

	if (LlPrintOptionsDialog(m_hJob, hWnd, _T("Select printing options")) < 0)
    {
        LlPrintEnd(m_hJob, 0);
        return;
    }

    int  nRecCount = 11, nLastPage, nRecno = 1;
	nLastPage = LlPrintGetOption(m_hJob, LL_OPTION_LASTPAGE);
    

    // D:   Druckschleife
    //     Diese wird so lange wiederholt, bis saemtliche Daten abgearbeitet wurden, oder
    //     ein Fehler auftritt.
    // US: do printing loop only when there is any data to be printed and no error has occurred:
	while (nRecno < nRecCount && (nRet == 0) && (LlPrintGetCurrentPage(m_hJob) <= nLastPage))
	{
		DefineVariables(nRecno,true);

		// D:   Variablen drucken
		// US: Print variables
    	nRet = LlPrint(m_hJob);

		while (nRet == LL_WRN_REPEAT_DATA)
		{
			nRet = LlPrint(m_hJob);
		}

    	// D:   Prozentbalken in der Fortschritts-Anzeige setzen
        // US: Set percent-bar
    	nRet = LlPrintSetBoxText(m_hJob, _T("Printing..."), (100 * nRecno / nRecCount));
        if (nRet == LL_ERR_USER_ABORTED)
   		{
    		LlPrintEnd(m_hJob,0);
    		return;
   		}

		// D:   gehe zum naechsten Datensatz
	    // US: now (virtually) goto next record
		nRecno++;	
  	}

	//D:   Druck beenden
    //US: Ends printjob
	LlPrintEnd(m_hJob, 0);
}

void CPrtloopDlg::OnCancel()
{
	LlJobClose(m_hJob);

	CDialog::OnCancel();

}

void CPrtloopDlg::OnClose() 
{
	// D:   Beenden des List & Label Jobs
	// US: Close the List & Label Job
	LlJobClose(m_hJob);

	CDialog::OnClose();
}


LRESULT CPrtloopDlg::OnLulMessage(WPARAM wParam, LPARAM lParam)
//=============================================================================
{
	// D:   Dies ist die List & Label Callback Funktion.
	//     Saemtliche Rueckmeldungen bzw. Events werden dieser Funktion
	//     gemeldet.
	// US: This is the List & Label Callback function.
	//     Is is called for requests an notifications.


	PSCLLCALLBACK	pscCallback = (PSCLLCALLBACK) lParam;
	LRESULT			lRes = TRUE;
	CString			sVariableDescr;

	TCHAR szHelpText[256];

	ASSERT(pscCallback->_nSize == sizeof(scLlCallback));	// D:   Die groesse der Callback Struktur muss stimmen!
															// US: sizes of callback structs must match!

	switch(wParam)
	{
		case LL_CMND_VARHELPTEXT:	// D:   Es wird ein Beschreibungstext für eine Variable erfragt.
									// US: Helptext needed for selected variable within designer

				// D:   ( pscCallback->_lParam enthält einen LPCTSTR des Beschreibungstextes )
				// US: ( pscCallback->_lParam contains a LPCTSTR to the name of the selected variable )

				sVariableDescr = (LPCTSTR)pscCallback->_lParam;

				if (!sVariableDescr.IsEmpty())
					_stprintf_s(szHelpText,
							_T("This is the sample field / variable '%s'."),
							(LPCTSTR)sVariableDescr);
				else
					_tcscpy_s(szHelpText, _T("No variable or field selected."));

				pscCallback->_lReply = (LPARAM)szHelpText;
				break;

		default:
				pscCallback->_lReply = lRes = FALSE; // D:   Die Nachricht wurde nicht bearbeitet.
													 // US: indicate that message hasn't been processed
	}

	return(lRes);
}

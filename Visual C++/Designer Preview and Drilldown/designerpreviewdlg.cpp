//=============================================================================
//
//  Project: List & Label
//           Copyright (C) combit GmbH, All Rights Reserved
//
//  Authors: combit Software Team
//
//-----------------------------------------------------------------------------
//
//  Module:  LLMFC - List & Label MFC Sample Application
//
//	Descr. :D:	Dieses Beispiel demonstriert den Druck von relational verknüpften Tabellen
//				über eine eigene Druckschleife und die echtdaten Vorschau des Designer
//				Bitte beachten Sie, dass dieses Beispiel den Schwerpunkt auf die Grundlagen
//				von List & Label legt, weshalb nur minimales Error-Handling verwendet wird.
//			US: This example demonstrates the printout of relational tables using a custom
//				print loop and the realdata preview of the designer.
//				In order to focus on the fundamentals of List & Label and prevent
//				code clutter, minimal error handling is done in the example.
//
//=============================================================================

#include "stdafx.h"
#include "DesignerPreview.h"
#include "DesignerPreviewDlg.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

// drilldown feature
class CLock
{

private:
	
	LONG&	m_n;
	
public:
	
	CLock(LONG& n)
		: m_n(n)
	{
		::InterlockedIncrement(&m_n);
	}
	
	~CLock()
	{
		::InterlockedDecrement(&m_n);
	}
};

/////////////////////////////////////////////////////////////////////////////
// D:  Waehlen Sie hier die List & Label Sprache für den Designer und die
//     Dialoge aus :
//    (Die entsprechenden Sprachkonstanten entnehmen Sie der Datei cmll27.h)

// US: choose your LuL-Language for all designer, dialogs, etc... here:
//    (see cmll27.h for other language-constants)

const int LUL_LANGUAGE = CMBTLANG_DEFAULT;


// D:  Callback Funktion
// US: callback procedure
static LRESULT CALLBACK LLCallbackProc(int wParam, LPARAM lParam, DWORD lUserParam)
{
	CDesignerPreviewDlg* pThis = (CDesignerPreviewDlg*) lUserParam;
	ASSERT(pThis);
	return(pThis->ForwardToLulMessage(wParam, lParam));
}


/////////////////////////////////////////////////////////////////////////////
// CDesignerPreviewDlg dialog

CDesignerPreviewDlg::CDesignerPreviewDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CDesignerPreviewDlg::IDD, pParent),
	m_nInPrintLoop(0),
	m_hPrintJob(NULL),
	m_nUniqueDrillDownJobID(0),
	m_nAbortCounter(0)
{
	::InitializeCriticalSection(&m_oDrillDownCS);

	//{{AFX_DATA_INIT(CDesignerPreviewDlg)
	m_nLimitRecord = 20;
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_LL_ICON);
	m_bDebug = FALSE;
}

CDesignerPreviewDlg::~CDesignerPreviewDlg()
{
	::DeleteCriticalSection(&m_oDrillDownCS);
}

void CDesignerPreviewDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDesignerPreviewDlg)
	DDX_Control(pDX, IDC_CHECK_DEBUG, m_oCheckDebug);
	DDX_Text(pDX, IDC_EDIT_LIMIT_RECORD, m_nLimitRecord);
	DDV_MinMaxInt(pDX, m_nLimitRecord, -1, 99999999);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CDesignerPreviewDlg, CDialog)
	//{{AFX_MSG_MAP(CDesignerPreviewDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_CHECK_DEBUG, OnCheckDebug)
	ON_COMMAND(ID_EDIT_REPORT, OnEditReport)
	ON_COMMAND(ID_FILE_EXIT, OnFileExit)
	ON_COMMAND(ID_PRINT_REPORT, OnPrintReport)
	ON_WM_DESTROY()
	ON_WM_CLOSE()
	ON_WM_CANCELMODE()	
	//}}AFX_MSG_MAP
	//ON_REGISTERED_MESSAGE(m_uLuLMessageBase, OnLulMessage)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDesignerPreviewDlg message handlers
CString GetApplicationPath()
{
	TCHAR app_path[_MAX_PATH];

	GetModuleFileName((HMODULE)AfxGetApp()->m_hInstance, app_path, MAX_PATH);
	CString app_str = app_path;
	app_str = app_str.Left(app_str.ReverseFind('\\')+1);

	return app_str;
}


///////////////////////////////////////////////////////////
//                                                       //
//      PrintProviderError Function                      //
//                                                       //
///////////////////////////////////////////////////////////
void PrintProviderError(_ConnectionPtr pConnection)
{
	// D: Hier können Sie die ADO Fehlerbehandlung vornehmen
	// US:ADO error handling

    // Print Provider Errors from Connection object.
    // pErr is a record object in the Connection's Error collection.
    ErrorPtr    pErr  = NULL;

    if( (pConnection->Errors->Count) > 0)
    {
        long nCount = pConnection->Errors->Count;
        // Collection ranges from 0 to nCount -1.
        for(long i = 0;i < nCount;i++)
        {
            pErr = pConnection->Errors->GetItem(i);
        }
    }
}


///////////////////////////////////////////////////////////
//                                                       //
//      PrintComError Function                           //
//                                                       //
///////////////////////////////////////////////////////////
void PrintComError(_com_error &e)
{
   _bstr_t bstrSource(e.Source());
   _bstr_t bstrDescription(e.Description());

	// D: Hier können Sie die ADO Fehlerbehandlung vornehmen
	// US:ADO error handling
}


// ------------------------------------------------------------------------------
BOOL CDesignerPreviewDlg::OnInitDialog()
// ------------------------------------------------------------------------------
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}


// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::OnSysCommand(UINT nID, LPARAM lParam)
// ------------------------------------------------------------------------------
{	
	CDialog::OnSysCommand(nID, lParam);	
}


// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.
// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::OnPaint() 
// ------------------------------------------------------------------------------
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
// ------------------------------------------------------------------------------
HCURSOR CDesignerPreviewDlg::OnQueryDragIcon()
// ------------------------------------------------------------------------------
{
	return (HCURSOR) m_hIcon;
}


// ------------------------------------------------------------------------------
bool CDesignerPreviewDlg::InitADOConnection()
// ------------------------------------------------------------------------------
{
	m_sConnStr = L"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
	m_sConnStr = m_sConnStr + GetApplicationPath();
	m_sConnStr += L"..\\..\\..\\nwind.mdb";
	m_sConnStr += L";";

	m_pConnection	= NULL;
	HRESULT         hr = S_OK;
	hr = ::CoInitialize( NULL );
	
	// D:	ADO Connection öffnen
	// US:	Open connection
	if( !FAILED( hr ) )
		hr = m_pConnection.CreateInstance( __uuidof( Connection ) );

	// US: The following exception handling assumes a valid Connection
	// US: object, so drop out if we couldn't create one for any reason.
	if ( FAILED(hr) )
		return false;

	try
	{
		m_pConnection->Open(m_sConnStr, L"", L"", -1);
		m_pConnection->CursorLocation = adUseClient;

		// US: For any error condition, dump results to TRACE.
		// US: You may get a failure that does not raise an exception.
		// US: The ADO Errors collection will likely be empty, but
		// US: check anyway.
		if( FAILED( hr ) )
		{
			return false;
		}
	}
	catch( CException *e )
	{
		e->Delete();
	}
	catch( _com_error &e )
	{
		e;
	 
		if( FAILED( hr ) )
		{
			return false;
		}
	 
	}
	catch(...)
	{
		return false;
	}

	if(FillSchemaInfo())
		return true;
	else
		return false;
}


// ------------------------------------------------------------------------------
bool CDesignerPreviewDlg::FillSchemaInfo()
// ------------------------------------------------------------------------------
{
	m_olstDataTable.RemoveAll();
	m_olstDataRelation.RemoveAll();


	_RecordsetPtr  pRstSchema	= NULL;
	try
    {
		// D: Tabellen auslesen
		// US: Read the table
		_CommandPtr pCmd;
		pCmd.CreateInstance(__uuidof(Command));
		pRstSchema = m_pConnection->OpenSchema(adSchemaTables);

		CString sCheckTableName;
		CString sCheckTableType;
		while(!(pRstSchema->EndOfFile))
        {
			_bstr_t table_name = pRstSchema->Fields->GetItem(_T("TABLE_NAME"))->Value;
			_bstr_t table_type = pRstSchema->Fields->GetItem(_T("TABLE_TYPE"))->Value;
		
			sCheckTableName.Format(_T("%s"), (LPCTSTR)table_name);
			sCheckTableType.Format(_T("%s"), (LPCTSTR)table_type);

			if((sCheckTableName.Mid(0, 4) != _T("MSys") && sCheckTableType == _T("TABLE")))
			{
				m_scRecordSetInformation.sTableName = sCheckTableName;
				
				// only for drilldown for getting subtables/childs
				if((m_oLlDrillDownParameters.m_hAttachInfo != NULL) && (m_scRecordSetInformation.sTableName == m_oLlDrillDownParameters.m_sSubreportTableID))
				{
					CString sTmpTable = m_oLlDrillDownParameters.m_sSubreportKeyField;
					sTmpTable = sTmpTable.Mid(sTmpTable.Find('.') + 1);
					
					// we have to read the fieldtype of key-field to get the correct seperator
					_RecordsetPtr pRecordSet = NULL;
					pRecordSet.CreateInstance(__uuidof(Recordset));
					pRecordSet->Open(_T("SELECT * FROM [") + table_name + _T("]"), m_pConnection.GetInterfacePtr(), adOpenForwardOnly, adLockBatchOptimistic, adCmdText);
					pRecordSet->MarshalOptions = adMarshalModifiedOnly;
					
					_bstr_t idFieldName = sTmpTable.AllocSysString();
					int nType = pRecordSet->Fields->GetItem(idFieldName)->Type;
					::SysFreeString(idFieldName);
					pRecordSet->Close();
					
					m_scRecordSetInformation.sSQL = TEXT("SELECT * FROM [") +sCheckTableName + TEXT("]" + _T(" WHERE [") + sTmpTable + _T("]=") + GetSepFromType(nType) + m_oLlDrillDownParameters.m_sKeyValue) + GetSepFromType(nType);
				}
				else
					m_scRecordSetInformation.sSQL = _T("SELECT * FROM [") + sCheckTableName + _T("]");
				
				m_olstDataTable.AddTail(m_scRecordSetInformation);
			}

	        pRstSchema->MoveNext();
		}
		pRstSchema->Close();

		
		// D:	Relationen einlesen
		// US:	fill relation
		pRstSchema = m_pConnection->OpenSchema(adSchemaForeignKeys);
		while(!(pRstSchema->EndOfFile))
        {
			_bstr_t fk_table_name	= pRstSchema->Fields->GetItem(_T("FK_TABLE_NAME"))->Value;
			_bstr_t fk_column_name	= pRstSchema->Fields->GetItem(_T("FK_COLUMN_NAME"))->Value;
			_bstr_t pk_table_name	= pRstSchema->Fields->GetItem(_T("PK_TABLE_NAME"))->Value;
			_bstr_t pk_column_name	= pRstSchema->Fields->GetItem(_T("PK_COLUMN_NAME"))->Value;
			
			m_scRecordSetInformation.sChildTable.Format(_T("%s"), (LPCTSTR) fk_table_name);
			m_scRecordSetInformation.sChildCol.Format(_T("%s"), (LPCTSTR) fk_column_name);
			m_scRecordSetInformation.sParentTable.Format(_T("%s"), (LPCTSTR) pk_table_name);
			m_scRecordSetInformation.sParentCol.Format(_T("%s"), (LPCTSTR) pk_column_name);
			m_scRecordSetInformation.sRelationName = m_scRecordSetInformation.sParentTable + _T("2") + m_scRecordSetInformation.sChildTable;
			m_scRecordSetInformation.sSQL = _T("SELECT * FROM [") + m_scRecordSetInformation.sParentTable + _T("]");
						
			m_olstDataRelation.AddTail(m_scRecordSetInformation);
	        pRstSchema->MoveNext();
		}

		// D:	Objekte schliessen
		// US:	Clean up objects before exit
        pRstSchema->Close(); 

	}
	catch (_com_error &e)
    {
        // US: Notify the user of errors if any.
        // US: Pass a connection pointer accessed from the Connection.        
        PrintProviderError(m_pConnection);
        PrintComError(e);
		return false;
    }
	return true;
}


// ------------------------------------------------------------------------------
bool CDesignerPreviewDlg::InitRecordSet(_RecordsetPtr &pRecordSet,_ConnectionPtr pConnection, const CString& sSQL)
// ------------------------------------------------------------------------------
{
	_variant_t stmpSQL;
	stmpSQL		= sSQL;	

	try
	{
		if(pRecordSet != NULL)
		{
			if(pRecordSet->State == adStateOpen)
				pRecordSet->Close();
		}
		else
		{
			pRecordSet	= NULL;
			pRecordSet.CreateInstance(__uuidof(Recordset));
		}
	
		pRecordSet->Open(stmpSQL, pConnection.GetInterfacePtr(), adOpenStatic, adLockBatchOptimistic, adCmdText);
		pRecordSet->MarshalOptions = adMarshalModifiedOnly;

	}
	catch(_com_error &e)
	{
		// D:	ADO Fehlerbehandlung 
		// US:	ADO error handling		
		e;
		return false;
	};
	
	return true;
}

// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::CleanUpRecordSet(_RecordsetPtr &pRecordSet)
// ------------------------------------------------------------------------------
{
	// D:	ADO RecordSet Objekt schliessen
	// US:	Clean up objects before exit.
	if(pRecordSet != NULL)
	{
		if(pRecordSet->State == adStateOpen)
			pRecordSet->Close();
	}
}


// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::CleanUpConnection(_ConnectionPtr &pConnection)
// ------------------------------------------------------------------------------
{
	if(pConnection != NULL)
	{
		if(pConnection->State == adStateOpen)
			pConnection->Close();
	}
}

// ------------------------------------------------------------------------------
CString CDesignerPreviewDlg::GetPictureFilename(void)
// ------------------------------------------------------------------------------
{
	CString	sTempFile;
	CString sTemp;		
	::GetTempPath(_MAX_PATH, sTemp.GetBuffer(_MAX_PATH));
	::GetTempFileName(sTemp, _T(""), 0, sTempFile.GetBuffer(_MAX_PATH));
	sTempFile.ReleaseBuffer();
	return sTempFile;
}

// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::DefineCurrentSortOrders(HLLJOB hJob, _RecordsetPtr &pRecordSet, const CString& sTableName)
// ------------------------------------------------------------------------------
{
	 // D:  Diese Prozedur definiert für jedes Feld eine Sortierung in List & Label.
    // US: This procedure defines a sort order for each field in List & Label.
    
    // D:  Wiederholung für alle Felder eines Datensatzen
    // US: Loop for each field in the current recordset
	_variant_t vIndex;
	vIndex = (short) 0;
	for (short intLoop = 0; intLoop <= (pRecordSet->Fields->Count-1); ++intLoop)
    {
		vIndex = intLoop;
		::LlDbAddTableSortOrderEx(hJob, sTableName, pRecordSet->Fields->GetItem(vIndex)->Name + " ASC", pRecordSet->Fields->GetItem(vIndex)->Name + " [+]", pRecordSet->Fields->GetItem(vIndex)->Name);
		::LlDbAddTableSortOrderEx(hJob, sTableName, pRecordSet->Fields->GetItem(vIndex)->Name + " DESC", pRecordSet->Fields->GetItem(vIndex)->Name + " [-]", pRecordSet->Fields->GetItem(vIndex)->Name);
	}
}


// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::CleanUpImages(void)
// ------------------------------------------------------------------------------
{
	POSITION pos = m_olstImages.GetHeadPosition();
	for (int i=0;i < m_olstImages.GetCount(); ++i)
	{
	   CString sBmp = m_olstImages.GetNext(pos);
	   _tunlink(sBmp);
	}

	m_olstImages.RemoveAll();
}


// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::DefineCurrentRecord(HLLJOB hJob, _RecordsetPtr pRecordSet, const CString& sPrefix, bool bWithUseCheck)
// ------------------------------------------------------------------------------
{
	long nRet = 0;
	long nPara = 0;
	_variant_t sFldVal;
	CString sContent;
	_variant_t vIndex;
	vIndex = (short) 0;

    // D:  Diese Prozedur übergibt den aktuellen Datensatz an List & Label.
    // US: This procedure passes the current record to List & Label.

    // D: Nur wenn Tabelle auch im Layout benutzt wird, Felder übergeben}
    // US: If and only if the table is used in the layout delivery of the fields}
    if((bWithUseCheck && sPrefix.GetLength() > 0) && (::LlPrintIsFieldUsed(hJob, sPrefix.Mid(0, sPrefix.GetLength() - 1) + _T("*")) == 0))
		return;


	CString sFieldUsed;
	CString sFieldName;
	// D:  Wiederholung für alle Felder eines Datensatzen
    // US: Loop for each field in the present recordset
	int nFieldCount = pRecordSet->Fields->Count;
	for (short intLoop = 0; intLoop <= (nFieldCount-1); intLoop++)
    {
		vIndex = intLoop;
	
		sFieldName = (LPSTR)pRecordSet->Fields->GetItem(vIndex)->Name;
		// D:  Zur Druckzeit werden nur die benötigten Felder und Variablen übergeben}
        // US: For print time only the needed fields and variables will be transfered}
		if(!bWithUseCheck || LlPrintIsFieldUsed(hJob, sPrefix + sFieldName) != 0)
		{
			variant_t FldVal = pRecordSet->Fields->GetItem(vIndex)->GetValue(); 
			
			// D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen
            // US: Transform database field types into List & Label field types
			int propType = (int)pRecordSet->Fields->GetItem(vIndex)->GetType();

			if (FldVal.vt == VT_NULL)
				sContent = "(NULL)";

			switch(propType)
			{		
				// D: Zeichen Feld
				// US: char field
				case(adVarWChar):
				case(adVarChar):
				case(adChar):
				case(adLongVarChar):
				case(adLongVarWChar):
				case(adBSTR):
					nPara = LL_TEXT;
					if(FldVal.vt != VT_NULL)
						sContent = (LPCSTR) (_bstr_t)FldVal.bstrVal;
					break;

				
				// D:  Boolean Feld
				// US: boolean field
				case(adBoolean):
					 nPara = LL_BOOLEAN;
					if(FldVal.boolVal)
						 sContent = ".T.";
					else
						sContent = ".F.";
					
					break;

				case(adDate):
					// D:  Falls der Datentyp "Datum" ist, Umwandlung in einen numerischen Datumswert
					// US: convert datatype "Date" to a numeric date-value
					nPara = LL_DATE_MS;
					if(FldVal.vt != VT_NULL)
						sContent.Format(_T("%f"), (DATE)COleDateTime(FldVal));					
					break;

				// D:  Zeichnung
				// US: Drawing
				case(adLongVarBinary):
				{
						byte* pBmp;
						nPara = LL_DRAWING;
						COleSafeArray myArray;
						myArray.Attach(FldVal);
						long nLBound, nUBound;
						myArray.GetLBound(1, &nLBound);
						myArray.GetUBound(1, &nUBound);
						int nSize = nUBound-nLBound-78;
						if(nSize > 78)
						{
							myArray.AccessData((LPVOID*)&pBmp);
							pBmp+=78; 

							CFile TempFile;
							CString sTempFileName = GetPictureFilename();
							TempFile.Open(sTempFileName, CFile::modeCreate | CFile::modeWrite);
							TempFile.Write(pBmp, nSize);
							TempFile.Close();

							m_olstImages.AddTail(sTempFileName);

							//decrement lock count
							myArray.UnaccessData();
							::LlDefineFieldExt(hJob, sPrefix+sFieldName, sTempFileName, nPara, NULL);
							
						}
						continue;
				}
					
				// D:  Numerisches Feld
				//	US: Numeric field
                default:
						if(FldVal.vt != VT_NULL)
						{
							FldVal.ChangeType(VT_BSTR);
							sContent = FldVal.bstrVal;	
						}
						nPara = LL_NUMERIC;
					break;				

			};               
              
			// D:  Feldname, -inhalt und -typ an List & Label übergeben
            // US: Declare fieldname, fieldcontent and fieldtype to List & Label
            if(sContent.IsEmpty())
				nRet = ::LlDefineFieldExt(hJob, sPrefix + sFieldName, _T(""), nPara, NULL);
		    else
				nRet = ::LlDefineFieldExt(hJob, sPrefix + sFieldName, sContent, nPara, NULL);
        
		}    
	}
}


// ------------------------------------------------------------------------------
int CDesignerPreviewDlg::PrintTable(HLLJOB hJob
							 , bool bIsSubTable
							 , _RecordsetPtr &pRecordSet
							 , int nTabIndex
							 , int nIndexCurrentTable)
// ------------------------------------------------------------------------------
{
	int ret = 0;
	int nType = 0;
	
	_RecordsetPtr pRecordSetOne;	
	CString	sCurrentTable;
	CString sCurrentSortOrderID;
	CString sCurrentRelationID;
	CString sPrefixstring;
	CString sPrefixstring2;

	int nRecord = 0;
	int nPercTotal = 0;

	if(pRecordSet->RecordCount > 0)
	{
		pRecordSet->MoveFirst();
		do
		{
			if(bIsSubTable)
			{
				// D:  Daten für Untertabellen definieren
				// US: Define data for sub tables
				DefineCurrentRecord(hJob, pRecordSet, m_olstDataRelation.GetAt(m_olstDataRelation.FindIndex(nTabIndex)).sChildTable + ".", true);
				CString sChildCol;
				// D:  Daten für 1:1 Rückrelation definieren
				// US: Define data for 1:1 relations
				for (POSITION pos = m_olstDataRelation.GetHeadPosition(); pos != NULL; )
				{
					// D:	Checke für die Kind-Tabelle der aktuellen Relation, ob es auch eine Kind-Tabelle
					//		einer anderen Relation gibt
					// US:	Check for each child table of the current relation, if a child table of another
					//		relation exist
					if(m_olstDataRelation.GetAt(m_olstDataRelation.FindIndex(nTabIndex)).sChildTable == m_olstDataRelation.GetAt(pos).sChildTable)
					{						
						_variant_t vType = m_olstDataRelation.GetAt(pos).sChildCol;
						nType = pRecordSet->Fields->GetItem(vType)->Type;
												
						_variant_t vValue = pRecordSet->Fields->GetItem(vType)->GetValue();
						vValue.ChangeType(VT_BSTR);
						sChildCol = vValue.bstrVal;

						sPrefixstring = m_olstDataRelation.GetAt(pos).sChildTable + "." + m_olstDataRelation.GetAt(pos).sChildCol + "@" + m_olstDataRelation.GetAt(pos).sParentTable + "." + m_olstDataRelation.GetAt(pos).sParentCol + ":";
						if(LlPrintIsFieldUsed(hJob, sPrefixstring+"*") == 1)
						{
							m_olstDataRelation.GetAt(pos).sSQL = "SELECT * FROM [" + m_olstDataRelation.GetAt(pos).sParentTable +
							"] WHERE [" + m_olstDataRelation.GetAt(pos).sParentCol + "]=" + GetSepFromType(nType) + sChildCol + GetSepFromType(nType);
							
							InitRecordSet(pRecordSetOne, m_pConnection, m_olstDataRelation.GetAt(pos).sSQL);
							DefineCurrentRecord(hJob, pRecordSetOne, sPrefixstring, true);

							// D:  2-stufige Relationen werden berücksichtigt
							// US: relation depth for 2 relations
							for (POSITION posRel = m_olstDataRelation.GetHeadPosition(); posRel != NULL; )
							{
								if(m_olstDataRelation.GetAt(pos).sParentTable == m_olstDataRelation.GetAt(posRel).sChildTable)
								{
						
                        			sPrefixstring2 = sPrefixstring + m_olstDataRelation.GetAt(posRel).sChildTable + 	
											"." + m_olstDataRelation.GetAt(posRel).sChildCol + "@" + m_olstDataRelation.GetAt(posRel).sParentTable + "." + m_olstDataRelation.GetAt(posRel).sParentCol + ":";		

									if(LlPrintIsFieldUsed(hJob, sPrefixstring2+"*") == 1)
									{
										m_olstDataRelation.GetAt(posRel).sSQL = "SELECT [" + m_olstDataRelation.GetAt(posRel).sParentTable + "].* FROM [" +
											m_olstDataRelation.GetAt(posRel).sChildTable + 	"] inner join [" + m_olstDataRelation.GetAt(posRel).sParentTable + "] on [" +
											m_olstDataRelation.GetAt(pos).sParentTable + "].[" + m_olstDataRelation.GetAt(posRel).sChildCol + "] = [" + m_olstDataRelation.GetAt(posRel).sParentTable +
											"].[" + m_olstDataRelation.GetAt(posRel).sParentCol +
											"] WHERE [" +
											m_olstDataRelation.GetAt(pos).sParentTable + "].[" + m_olstDataRelation.GetAt(pos).sParentCol + "] = " +
											GetSepFromType(nType) + sChildCol + GetSepFromType(nType);
																		   
										InitRecordSet(pRecordSetOne, m_pConnection, m_olstDataRelation.GetAt(posRel).sSQL);
										DefineCurrentRecord(hJob, pRecordSetOne, sPrefixstring2, true);
									}
								}
  
								m_olstDataRelation.GetNext(posRel);
							}
						}
					}

					m_olstDataRelation.GetNext(pos);
	
				}

			}
			else
			{
				// D:  Aktualisierung der Fortschrittsanzeige wenn Root-Datensatz gedruckt wird
				// US: If a root record is printed update the progress bar
				if(m_nLimitRecord <= 0)
					m_nLimitRecord = 20;
				int		nMaxPerc = 100 / LlPrintDbGetRootTableCount(hJob);
				int		nMaxRecs = min(pRecordSet->GetRecordCount(), m_nLimitRecord);
				float	nRecPos = ((float)pRecordSet->GetAbsolutePosition()/(float)nMaxRecs);
				nPercTotal = (int)(nMaxPerc  * nIndexCurrentTable + ((nRecPos) * nMaxPerc));
				ret = ::LlPrintSetBoxText(hJob, _T("Printing report..."), nPercTotal);

				// D:  Daten für Haupttabellen definieren
				// US: Define data for root tables
				DefineCurrentRecord(hJob, pRecordSet, m_olstDataTable.GetAt(m_olstDataTable.FindIndex(nTabIndex)).sTableName + ".", true);

				CString sChildCol;      
				// D:  Daten für 1:1 Relationen definieren
				// US: Define data for 1:1 relations
				for (POSITION pos = m_olstDataRelation.GetHeadPosition(); pos != NULL; )
				{
					if(m_olstDataTable.GetAt(m_olstDataTable.FindIndex(nTabIndex)).sTableName == m_olstDataRelation.GetAt(pos).sChildTable)
					{						
						_variant_t vType = m_olstDataRelation.GetAt(pos).sChildCol;
						nType = pRecordSet->Fields->GetItem(vType)->Type;
						
						
						_variant_t vValue = pRecordSet->Fields->GetItem(vType)->GetValue();
						vValue.ChangeType(VT_BSTR);
						sChildCol = vValue.bstrVal;	

						sPrefixstring = m_olstDataRelation.GetAt(pos).sChildTable + "." + m_olstDataRelation.GetAt(pos).sChildCol + "@" + m_olstDataRelation.GetAt(pos).sParentTable + "." + m_olstDataRelation.GetAt(pos).sParentCol + ":";
						if(::LlPrintIsFieldUsed(hJob, sPrefixstring+"*") == 1)
						{
							m_olstDataRelation.GetAt(pos).sSQL = "SELECT * FROM [" + m_olstDataRelation.GetAt(pos).sParentTable +
							"] WHERE [" + m_olstDataRelation.GetAt(pos).sParentCol + "]=" + GetSepFromType(nType) + 
							sChildCol + GetSepFromType(nType);

							InitRecordSet(pRecordSetOne, m_pConnection, m_olstDataRelation.GetAt(pos).sSQL);
							DefineCurrentRecord(hJob, pRecordSetOne, sPrefixstring, true);
					
							for (POSITION posRel = m_olstDataRelation.GetHeadPosition(); posRel != NULL; )
							{
								if(m_olstDataRelation.GetAt(pos).sParentTable == m_olstDataRelation.GetAt(posRel).sChildTable)
								{													
									sPrefixstring = m_olstDataRelation.GetAt(pos).sChildTable + "." + m_olstDataRelation.GetAt(pos).sParentCol + "@" + m_olstDataRelation.GetAt(pos).sParentTable + "." + m_olstDataRelation.GetAt(pos).sParentCol + ":";
									sPrefixstring2 = sPrefixstring + m_olstDataRelation.GetAt(posRel).sChildTable + 
											"." + m_olstDataRelation.GetAt(posRel).sChildCol + "@" + m_olstDataRelation.GetAt(posRel).sParentTable + "." + m_olstDataRelation.GetAt(posRel).sParentCol + ":";

									if(LlPrintIsFieldUsed(hJob, sPrefixstring2+"*") == 1)
									{
										m_olstDataRelation.GetAt(posRel).sSQL = "SELECT [" + m_olstDataRelation.GetAt(posRel).sParentTable + "].* FROM [" +
											m_olstDataRelation.GetAt(posRel).sChildTable + "] inner join [" + m_olstDataRelation.GetAt(posRel).sParentTable + "] on [" +
											m_olstDataRelation.GetAt(pos).sParentTable + "].[" + m_olstDataRelation.GetAt(posRel).sChildCol+"] = ["+
											m_olstDataRelation.GetAt(posRel).sParentTable + "].["+m_olstDataRelation.GetAt(posRel).sParentCol+
											"] WHERE [" +
											m_olstDataRelation.GetAt(pos).sParentTable + "].[" + m_olstDataRelation.GetAt(pos).sParentCol + "] = " +GetSepFromType(nType) + sChildCol + GetSepFromType(nType);
										
										InitRecordSet(pRecordSetOne, m_pConnection, m_olstDataRelation.GetAt(posRel).sSQL);
										DefineCurrentRecord(hJob, pRecordSetOne, sPrefixstring2, true);
									}
								}
								m_olstDataRelation.GetNext(posRel);
							}
						}
					}
				
					m_olstDataRelation.GetNext(pos);					
				}
			
			}
			ret = ::LlPrintFields(hJob);
			if(ret == LL_ERR_USER_ABORTED)
			{
				// D:  Benutzerabbruch
				// US: User aborted
				::LlPrintEnd (hJob, 0);
				CleanUpRecordSet(pRecordSetOne);
				return ret;
			}
			
			// D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
			// US: Wrap pages until record was fully printed
			while(ret == LL_WRN_REPEAT_DATA)
			{
				LlPrint(hJob);
				ret = ::LlPrintFields(hJob);
			}

			
			if(ret == LL_ERR_USER_ABORTED)
			{
				// D:  Benutzerabbruch
				// US: User aborted
				::LlPrintEnd(hJob, 0);
				CleanUpRecordSet(pRecordSetOne);
				return ret;
			}
						
			int nBuffer = 0;
			int nRelationIndex = 0;
			while(ret == LL_WRN_TABLECHANGE)
			{
				// D:  Root-Tabelle bestimmen und solange drucken bis keine mehr vorhanden
				// US: determine root table and print until no one is available	
				nBuffer  = ::LlPrintDbGetCurrentTable(hJob, NULL, 0, true);
				if(nBuffer > 0)
				{
					::LlPrintDbGetCurrentTable(hJob, sCurrentTable.GetBuffer(nBuffer+1), nBuffer+1, false);
					sCurrentTable.ReleaseBuffer();					
				}

				if (sCurrentTable == "LLStaticTable")
				{
					ret = ::LlPrintFields(hJob);
					while (ret == LL_WRN_REPEAT_DATA)
					{
						::LlPrint(hJob);
						ret = ::LlPrintFields(hJob);
					}

					do
					{
						ret = ::LlPrintFieldsEnd(hJob);
					}
					while (ret == LL_WRN_REPEAT_DATA);
				}
				else
				{
					nBuffer = ::LlPrintDbGetCurrentTableRelation(hJob, NULL, 0);
					if(nBuffer > 0)
					{
						::LlPrintDbGetCurrentTableRelation(hJob, sCurrentRelationID.GetBuffer(nBuffer+1), nBuffer+1);
						sCurrentRelationID.ReleaseBuffer();
					}

					nBuffer = ::LlPrintDbGetCurrentTableSortOrder(hJob, NULL, 0);
					if(nBuffer > 0)
					{
						
						::LlPrintDbGetCurrentTableSortOrder(hJob, sCurrentSortOrderID.GetBuffer(nBuffer+1), nBuffer+1);
						sCurrentSortOrderID.ReleaseBuffer();
					}					
					
														
					nRelationIndex = GetIndexOfRelation(sCurrentRelationID);
					
					CString sChildCol;
					_variant_t vType = m_olstDataRelation.GetAt(m_olstDataRelation.FindIndex(nRelationIndex)).sParentCol;
					nType = pRecordSet->Fields->Item[vType]->Type;
					_variant_t vValue = pRecordSet->Fields->GetItem(vType)->GetValue();
					vValue.ChangeType(VT_BSTR);
					sChildCol = vValue.bstrVal;	
					CString sSubSQL;

					
					sSubSQL = "SELECT * FROM [" +
						m_olstDataRelation.GetAt(m_olstDataRelation.FindIndex(nRelationIndex)).sChildTable +
						"] WHERE [" + m_olstDataRelation.GetAt(m_olstDataRelation.FindIndex(nRelationIndex)).sChildCol +
						"]=" + GetSepFromType(nType) + sChildCol +
						GetSepFromType(nType);

					m_olstDataRelation.GetAt(m_olstDataRelation.FindIndex(nRelationIndex)).sSQL=sSubSQL ;
					_RecordsetPtr pRSy;
					InitRecordSet(pRSy, m_pConnection, m_olstDataRelation.GetAt(m_olstDataRelation.FindIndex(nRelationIndex)).sSQL);
					pRSy->Sort = (_bstr_t)sCurrentSortOrderID;
					
					ret = PrintTable(hJob, true, pRSy, nRelationIndex, 0);
					CleanUpRecordSet(pRSy);
				}

				if(ret == LL_ERR_USER_ABORTED)
				{
					 // D:  Benutzerabbruch
					// US: User aborted
					LlPrintEnd (hJob, 0);
					return ret;
				}

			}
			
			pRecordSet->MoveNext();
			nRecord++;
	            
		}
		while(!pRecordSet->EndOfFile && (m_nLimitRecord>0? nRecord < m_nLimitRecord : true));
		CleanUpRecordSet(pRecordSetOne);				
	}


	// D:  Druck der Tabelle beenden, angehängte Objekte drucken
	// US: Finish printing the table, print linked objects
	ret = ::LlPrintFieldsEnd(hJob);
	while(ret == LL_WRN_REPEAT_DATA)
	{
		ret = ::LlPrintFieldsEnd(hJob);	
	}
	
	return ret;
}


// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::PassDataStructure(HLLJOB hJob)
// ------------------------------------------------------------------------------
{
	_RecordsetPtr	pRecordSet		= NULL;
	CString			sTableName;
	POSITION		pos = NULL;

	::LlDbAddTable(hJob, _T("LLStaticTable"), _T(""));
	
	// D:  Durchlaufe Tabellen-Array und mache vorhanden Tabellen und Sortierungen bekannt
    // US: skip through table array and declare existing tables and corresponding sort orders
	for (pos = m_olstDataTable.GetHeadPosition(); pos != NULL; )
	{
		sTableName = m_olstDataTable.GetAt(pos).sTableName;
		::LlDbAddTable(hJob, sTableName, _T(""));
		VERIFY(InitRecordSet(pRecordSet, m_pConnection, m_olstDataTable.GetAt(pos).sSQL) == true);

		DefineCurrentRecord(hJob, pRecordSet, sTableName + _T("."), false);
		
		 // D:  Unterroutine zum Definieren der Sortierungen aufrufen
        //	US: call sub routing to define sort orders
		DefineCurrentSortOrders(hJob, pRecordSet, sTableName);
		m_olstDataTable.GetNext(pos);

		CleanUpRecordSet(pRecordSet);
	}

	CString sPrefixstring;
	CString sPrefixstring2;
	CString sParentTable;

	// D:  Durchlaufe Relations-Array und mache vorhanden Relationen bekannt
    // US: skip through relation array and declare existing relations
	for (pos = m_olstDataRelation.GetHeadPosition(); pos != NULL; )
	{
		sParentTable = m_olstDataRelation.GetAt(pos).sParentTable;
		CString sChildTable = m_olstDataRelation.GetAt(pos).sChildTable;
		::LlDbAddTableRelationEx(hJob, sChildTable, sParentTable, m_olstDataRelation.GetAt(pos).sRelationName, TEXT(""),sChildTable+TEXT(".")+m_olstDataRelation.GetAt(pos).sChildCol, sParentTable+TEXT(".")+m_olstDataRelation.GetAt(pos).sParentCol); // 2009-06-30 O
		//::LlDbAddTableRelation(hJob, m_olstDataRelation.GetAt(pos).sChildTable, sParentTable, m_olstDataRelation.GetAt(pos).sRelationName, "");
		
		// D:  1:1 Relationen bekannt machen
        // US: Declare 1:1 relations
		VERIFY(InitRecordSet(pRecordSet, m_pConnection, m_olstDataRelation.GetAt(pos).sSQL) == true);

		sPrefixstring = m_olstDataRelation.GetAt(pos).sChildTable + _T(".") + m_olstDataRelation.GetAt(pos).sChildCol + _T("@") + m_olstDataRelation.GetAt(pos).sParentTable + _T(".") + m_olstDataRelation.GetAt(pos).sParentCol + _T(":");
		DefineCurrentRecord(hJob, pRecordSet, sPrefixstring, false);
		CleanUpRecordSet(pRecordSet);

		// D:  Suche in allen anderen Relationen, ob die aktuelle Eltern-Tabelle
        //     Kind einer anderen Relation ist
        // US: search in all other relations if the current parent table is child of
        //     another relation
		for (POSITION posChild = m_olstDataRelation.GetHeadPosition(); posChild != NULL; )
		{
			if(sParentTable == m_olstDataRelation.GetAt(posChild).sChildTable)	
			{
				sPrefixstring2 = sPrefixstring + m_olstDataRelation.GetAt(posChild).sChildTable +
					 "." + m_olstDataRelation.GetAt(posChild).sChildCol + "@" + m_olstDataRelation.GetAt(posChild).sParentTable + "." + m_olstDataRelation.GetAt(posChild).sParentCol + ":";

				InitRecordSet(pRecordSet, m_pConnection, m_olstDataRelation.GetAt(posChild).sSQL);
				DefineCurrentRecord(hJob, pRecordSet, sPrefixstring2, false);
				CleanUpRecordSet(pRecordSet);
			}
				
			m_olstDataTable.GetNext(posChild);
		}

		m_olstDataTable.GetNext(pos);
	}

	CleanUpRecordSet(pRecordSet);
}


// ------------------------------------------------------------------------------
int CDesignerPreviewDlg::GetIndexOfRelation(const CString& sRelationName)
// ------------------------------------------------------------------------------
{
	int			nZahl = 0;
	POSITION	pos = NULL;
	for (pos = m_olstDataRelation.GetHeadPosition(); pos != NULL; )
	{
		if(m_olstDataRelation.GetNext(pos).sRelationName == sRelationName)
		{	
			return nZahl;
		}
		nZahl++;
	}	
	return 0;
}

// ------------------------------------------------------------------------------
int CDesignerPreviewDlg::GetIndexOfTable(const CString& sTableName)
// ------------------------------------------------------------------------------
{
	int			nZahl = 0;
	POSITION	pos = NULL;
	for (pos = m_olstDataTable.GetHeadPosition(); pos != NULL; )
	{
		if(m_olstDataTable.GetNext(pos).sTableName == sTableName)
		{	
			return nZahl;
		}
		nZahl++;
	}
	
	return 0;
}

// ------------------------------------------------------------------------------
CString CDesignerPreviewDlg::GetSepFromType(int nInType)
// ------------------------------------------------------------------------------
{
	if((nInType == adVarWChar) || (nInType == adVarChar) || (nInType == adChar) || (nInType == adBSTR))
	{	
		return "'";
	}
	else
	{
		return "";
	}
}

// ------------------------------------------------------------------------------
bool CDesignerPreviewDlg::InitLuL(HLLJOB* phJob/*= NULL*/)
// ------------------------------------------------------------------------------
{
	HLLJOB hJob = NULL;

	// D:  Initialisieren von List & Label. Es wird ein Job geoeffnet.
	// US: Initialize List & Label. Open Job.
	hJob = ::LlJobOpen(LUL_LANGUAGE);
	if (hJob == LL_ERR_BAD_JOBHANDLE || hJob == 0)
	{
		MessageBox(_T("Job can't be initialized!"), _T("List & Label Sample App"), MB_OK|MB_ICONSTOP);
		return false;
	}
	else if (hJob == LL_ERR_NO_LANG_DLL)
	{
		MessageBox(_T("Language file not found!\nEnsure that *.lng files can be found in your LuL DLL directory."),
					_T("List & Label Sample App"),
					MB_OK|MB_ICONSTOP);
		return false;
	}
	
	if(phJob != NULL)
		*phJob = hJob;
	else
		m_hJob = hJob;

	::LlSetOption(hJob, LL_OPTION_CALLBACKPARAMETER, (LONG) this);
	::LlSetNotificationCallback(hJob, (FARPROC) LLCallbackProc);

	return true;
}

// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::OnCheckDebug() 
// ------------------------------------------------------------------------------
{
	if (m_oCheckDebug.GetCheck())
	{
		MessageBox(_T("Start DEBWIN to receive debug messages."),
					_T("List & Label Sample App"), MB_OK | MB_ICONINFORMATION);
		LlSetDebug(LL_DEBUG_CMBTLL);
		m_bDebug = TRUE;	
	}
	else
	{
		LlSetDebug(FALSE);
		m_bDebug = FALSE;
	}
}

// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::OnFileExit() 
// ------------------------------------------------------------------------------
{
	OnOK();	
}

// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::OnDestroy() 
// ------------------------------------------------------------------------------
{
	CDialog::OnDestroy();
	
	CleanUpConnection(m_pConnection);
}
 
// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::OnEditReport() 
// ------------------------------------------------------------------------------
{
  	UpdateData(TRUE);

	if(!InitADOConnection())
	{
		MessageBox(_T("Make sure that Nwind.mdb is in your List & Label install path!"),
					_T("List & Label Sample App"), MB_OK | MB_ICONEXCLAMATION );
	}
	else
	{
		if(InitLuL())
		{
			TCHAR szFilename[_MAX_PATH] = _T("*.lst");

			/*
			D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
				gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
				sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
    
			US: Optional call to file selection dialog. Ommit this call and pass the
				required file as FileName if you don't want the dialog to appear. If only
				existing files should be selectable, remove the "or"ing with LL_FILE_ALSONEW*/
			if(::LlSelectFileDlgTitleEx(m_hJob, m_hWnd, _T("Design report"), LL_PROJECT_LIST|LL_FILE_ALSONEW, szFilename, sizeof(szFilename), NULL) == 0) 
			{ 
				// D:  Daten definieren
				// US: Define data
				PassDataStructure(m_hJob);
				
				// D:  Diese variablen werden zur Kommunikation für den Echtdatenpreview im Designer benötigt
				// US: These variables are requred for communication of designer preview
				memset(&m_oLLRDP,0,sizeof(m_oLLRDP));			
				::InitializeCriticalSection(&m_oLLRDP.m_CS);
				m_oLLRDP.m_pInternal		= this;
				m_oLLRDP.m_hThreadRunning	= ::CreateEvent(NULL,TRUE /*bManualReset*/,FALSE,NULL);
				m_oLLRDP.m_hThreadPrinting  = ::CreateEvent(NULL, TRUE /*bManualReset*/, FALSE, NULL);
				wcscpy_s(m_oLLRDP.m_szFilename, _MAX_PATH, szFilename);

				::LlSetOption(m_hJob, LL_OPTION_DESIGNERPREVIEWPARAMETER,(LPARAM)&m_oLLRDP);
				::LlSetOption(m_hJob, LL_OPTION_DESIGNEREXPORTPARAMETER,(LPARAM)&m_oLLRDP);

				
				// activate drilldown feature
				::LlSetOption(m_hJob, LL_OPTION_DRILLDOWNPARAMETER, (LPARAM)&m_oLlDrillDownParameters);
				
				// D:  Designer mit dem Titel 'Design' und der gewählten Datei starten
				// US: Opens the chosen file in the designer, sets designer title to 'Design'
				if (::LlDefineLayout(m_hJob, m_hWnd, _T("Designer"), LL_PROJECT_LIST, szFilename) < 0)
					MessageBox(_T("Error by calling LlDefineLayout"), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
				
				// deactivate drilldown feature
				::LlSetOption(m_hJob, LL_OPTION_DRILLDOWNPARAMETER, NULL);
				
				::LlSetOption(m_hJob, LL_OPTION_DESIGNERPREVIEWPARAMETER, 0);
				::CloseHandle(m_oLLRDP.m_hThreadRunning);
				m_oLLRDP.m_hThreadRunning = NULL;
				::CloseHandle(m_oLLRDP.m_hThreadPrinting);
				m_oLLRDP.m_hThreadPrinting = NULL;
				::DeleteCriticalSection(&m_oLLRDP.m_CS);
			}
			::LlJobClose(m_hJob);
			m_hJob = 0;
			CleanUpConnection(m_pConnection);
		}
	}
}

// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::OnPrintReport() 
// ------------------------------------------------------------------------------
{
	UpdateData(TRUE);

	if(!InitADOConnection())
	{
		MessageBox(_T("Make sure that Nwind.mdb is in your List & Label install path!"),
					_T("List & Label Sample App"), MB_OK | MB_ICONEXCLAMATION );
	}
	else
	{
		DoPrintReport();

		CleanUpConnection(m_pConnection);
	}
}

// ------------------------------------------------------------------------------
LRESULT CDesignerPreviewDlg::ForwardToLulMessage(WPARAM wParam, LPARAM lParam)
// ------------------------------------------------------------------------------
{
	return OnLulMessageHandler(wParam, lParam);
}

// ------------------------------------------------------------------------------
LRESULT CDesignerPreviewDlg::OnLulMessageHandler(WPARAM wParam, LPARAM lParam)
// ------------------------------------------------------------------------------
{
	// D:  Dies ist die List & Label Callback Funktion. Saemtliche Rueckmeldungen bzw. Events werden dieser Funktion gemeldet.
	// US: This is the List & Label Callback function. Is is called for requests and notifications.
	
	LRESULT lRes = TRUE;
	switch(wParam)
	{		
		case LL_NTFY_DESIGNERPRINTJOB:
		{
			scLlDesignerPrintJob* pscLRDDJ = (scLlDesignerPrintJob*) lParam;
			ASSERT(pscLRDDJ && pscLRDDJ->_nSize == sizeof(scLlDesignerPrintJob));				
			
			lRes = OnNtfyRealDataDesignerJob(pscLRDDJ);
		}	
		break;
		
		case LL_NTFY_VIEWERDRILLDOWN:
		{
			scLlDrillDownJob* pscLlDrillDownJob = (scLlDrillDownJob*)lParam;
			ASSERT(pscLlDrillDownJob && pscLlDrillDownJob->_nSize == sizeof(scLlDrillDownJob));
			
			lRes = OnNtfyViewerDrillDown(pscLlDrillDownJob);
		}
		break;
		
		// D:  Die Nachricht wurde nicht bearbeitet.
		// US: indicate that message hasn't been processed default.
		default:
		{
			lRes = FALSE;											
		}
		break;
	}
	
	return(lRes);
}

// ------------------------------------------------------------------------------
// D:  Dies ist der Thread der im Hintergrund für Designer Echtdatenvorschau zuständig ist
// US: This is the thread resposible for creating the designer realdata preview
unsigned int ThFctBackgroundPreview(void* pParam)
// ------------------------------------------------------------------------------
{
	ASSERT(pParam);
	scMyRealDataParameters*	pMRDP = (scMyRealDataParameters*) (pParam);
	HLLJOB					hJob = 0;
	bool					bInitOK = false;

	CDesignerPreviewDlg* pDlg = (CDesignerPreviewDlg*) pMRDP->m_pInternal;
	ASSERT(pDlg);

	::EnterCriticalSection(&pMRDP->m_CS);
	bInitOK = pDlg->InitLuL(&hJob);
	pMRDP->m_hLLJob = hJob;
	::LeaveCriticalSection(&pMRDP->m_CS);

	// D:  informiert den Aufrufer, dass der thread nun aktiv ist
	// US: used for synchronization with caller
	::SetEvent(pMRDP->m_hThreadRunning);

	if(bInitOK)
	{		
		::SetEvent(pMRDP->m_hStateChangeNotificationEvent);
			

		if (pMRDP->m_bPreview)
		{
			::LlAssociatePreviewControl(pMRDP->m_hLLJob, pMRDP->m_hWnd, 1);
		}

		// D:  erzeuge vorschau
		// US: create preview print
		ASSERT(::WaitForSingleObject(pMRDP->m_hThreadPrinting, 0) != WAIT_OBJECT_0);
		pDlg->DoPrintReport(pMRDP->m_hThreadPrinting, pMRDP->m_hLLJob, pMRDP->m_szFilename, pMRDP->m_bPreview, pMRDP->m_nPages, pMRDP->m_szExportFormat, pMRDP->m_bWithoutDialog);	
		::ResetEvent(pMRDP->m_hThreadPrinting);

		if (pMRDP->m_bPreview)
		{
			::LlAssociatePreviewControl(pMRDP->m_hLLJob, NULL, 1);
		}
	
		::EnterCriticalSection(&pMRDP->m_CS);
		::LlJobClose(pMRDP->m_hLLJob);
		pMRDP->m_hLLJob = 0;
		::LeaveCriticalSection(&pMRDP->m_CS);

		::DeleteFile(pMRDP->m_szFilename);
		
		::SetEvent(pMRDP->m_hStateChangeNotificationEvent);	
	}
	
	::ResetEvent(pMRDP->m_hThreadRunning);

	// D:  beenden des Threads (schließt handle, ...)
	// US: end thread (close handle,...)
	AfxEndThread(0);
	return 0;
}

// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::WaitForEndOfWorkerThread()
// ------------------------------------------------------------------------------
{
	if (m_oLLRDP.m_hWorkerThread)
		{
		::EnableWindow(this->GetSafeHwnd(), false);

		HANDLE  arh[1] = { m_oLLRDP.m_hWorkerThread };
		bool    bSignalled = false;

		while (!bSignalled)
			{
			switch (::MsgWaitForMultipleObjects(1, arh, FALSE, INFINITE, QS_ALLINPUT))
				{
				case WAIT_OBJECT_0 + 1: // a message
					{
					MSG		msg;
					while (::PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
						{
						if (msg.message != WM_CLOSE)
							{
							::TranslateMessage(&msg);
							::DispatchMessage(&msg);
							}
						}
					}
					break;
				case WAIT_ABANDONED_0:
					break;
				case WAIT_FAILED:
				case WAIT_OBJECT_0:
					bSignalled = true;
					break;
				}
			}

		::DeleteObject(m_oLLRDP.m_hWorkerThread);
		m_oLLRDP.m_hWorkerThread = NULL;

		::EnableWindow(this->GetSafeHwnd(), true);
		}
}

// ------------------------------------------------------------------------------
INT CDesignerPreviewDlg::OnNtfyRealDataDesignerJob(scLlDesignerPrintJob* pscLRDDJ)
// ------------------------------------------------------------------------------
{
	ASSERT(pscLRDDJ);

	switch(pscLRDDJ->_nFunction)
	{
	 //--------------------
	 case LL_DESIGNERPRINTCALLBACK_EXPORT_START:
	 case LL_DESIGNERPRINTCALLBACK_PREVIEW_START:
		 {			
			INT		nAbortCounter(m_nAbortCounter);

			WaitForEndOfWorkerThread();

			if (m_nAbortCounter == nAbortCounter)
				{
				ASSERT(m_oLLRDP.m_hLLJob == 0);
				wcscpy_s(m_oLLRDP.m_szFilename, MAX_PATH, CString(pscLRDDJ->_pszProjectFileName).Left(MAX_PATH));
				m_oLLRDP.m_nPages							= pscLRDDJ->_nPages;
				m_oLLRDP.m_hWnd								= pscLRDDJ->_hWnd;
				m_oLLRDP.m_hStateChangeNotificationEvent	= pscLRDDJ->_hEvent;
				m_oLLRDP.m_bPreview							= (pscLRDDJ->_nFunction==LL_DESIGNERPRINTCALLBACK_PREVIEW_START);
				m_sOriginalProjectFileName					= pscLRDDJ->_pszOriginalProjectFileName;

				if (pscLRDDJ->_pszExportFormat)
				{
					wcscpy_s(m_oLLRDP.m_szExportFormat, 15, CString(pscLRDDJ->_pszExportFormat).Left(15));
				}
				m_oLLRDP.m_bWithoutDialog					= pscLRDDJ->_bWithoutDialog;

				CWinThread* pTmpThread = AfxBeginThread(ThFctBackgroundPreview, (LPVOID) &m_oLLRDP, THREAD_PRIORITY_NORMAL, 32000);
				if(pTmpThread)
				{								
					if(m_oLLRDP.m_hThreadRunning)
					{
						::DuplicateHandle(GetCurrentProcess(),pTmpThread->m_hThread
											, GetCurrentProcess(),&m_oLLRDP.m_hWorkerThread
											, 0
											, FALSE
											, DUPLICATE_SAME_ACCESS);
						::WaitForSingleObject(m_oLLRDP.m_hThreadRunning, INFINITE);					
					}
				}						
			}
		 }
		 break;
	 //--------------------
	 case LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT:
	 case LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT:
 		 {
		 ::EnterCriticalSection(&m_oLLRDP.m_CS);
		 if (m_oLLRDP.m_hLLJob != 0)
			{
				::WaitForSingleObject(m_oLLRDP.m_hThreadPrinting, INFINITE); // must be printing (LlPrintAbort() does nothing until PrintStart() is finished) to accept an abort
				::LlPrintAbort(m_oLLRDP.m_hLLJob);	// D: kein Fehlercheck - es könnte LL_ERR_PRINTING_JOB legal gemeldet werden...
													// US: nor error check here
			}
			++m_nAbortCounter;
			::LeaveCriticalSection(&m_oLLRDP.m_CS);
		 }
		 break;
	 //--------------------
	 case LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE:
	 case LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE:
		 {
			::EnterCriticalSection(&m_oLLRDP.m_CS);
			if (m_oLLRDP.m_hLLJob != 0)
			{
				::LlPrintAbort(m_oLLRDP.m_hLLJob);	// D:  kein Fehlercheck - es könnte LL_ERR_PRINTING_JOB legal gemeldet werden...
													// US: nor error check here
			}
			++m_nAbortCounter;
			::LeaveCriticalSection(&m_oLLRDP.m_CS);
			
			WaitForEndOfWorkerThread();
		 }
		 break;

	 //--------------------
	 case LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE:
		{
			if (m_oLLRDP.m_hWorkerThread != NULL &&
				::WaitForSingleObject(m_oLLRDP.m_hWorkerThread, 0) == WAIT_TIMEOUT)
			{
				return(LL_DESIGNERPRINTTHREAD_STATE_RUNNING);
			}
			else
	  		{
				return(LL_DESIGNERPRINTTHREAD_STATE_STOPPED);
	  		}
		}
		break;

	  
	 default:
			break;

	};

	return TRUE;
}



// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::AbortIfNeeded()
// ------------------------------------------------------------------------------
{
	if(m_nInPrintLoop)
	{
		::LlPrintAbort(m_hPrintJob);
	}
}


// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::NtfyDDJobFinished(
											UINT_PTR nID // drilldown jobID
											)
// ------------------------------------------------------------------------------
{
	::EnterCriticalSection(&m_oDrillDownCS);
	
	CDesignerPreviewDlg* pSample = NULL;
	if(m_MapDrillDownSample.Lookup(nID, *&pSample))
	{
		::LeaveCriticalSection(&m_oDrillDownCS);
		
		// delete sampleapp and remove ID from map
		delete pSample;
		pSample = NULL;
		m_MapDrillDownSample.RemoveKey(nID);
		
		::EnterCriticalSection(&m_oDrillDownCS);
	}
	
	::LeaveCriticalSection(&m_oDrillDownCS);
}


// ------------------------------------------------------------------------------
unsigned int ThFctDrillDownPreview(
									void* pParam
									)
// ------------------------------------------------------------------------------
{
	scMyDrillDownParameters*	pDrillDownParameters = (scMyDrillDownParameters*)pParam;
	ASSERT(pDrillDownParameters);
	
 	CDesignerPreviewDlg* pSample = (CDesignerPreviewDlg*)pDrillDownParameters->m_pInternal;
	ASSERT(pSample);
	
	::EnterCriticalSection(&pSample->m_oLlDrillDownParameters.m_CS);
	
	HLLJOB hLlJob = 0;
	pSample->InitLuL(&hLlJob);
	pDrillDownParameters->m_hLlJob = hLlJob;
	::LeaveCriticalSection(&pSample->m_oLlDrillDownParameters.m_CS);
	
	if(pDrillDownParameters->m_hLlJob > 0)
	{
		::LlAssociatePreviewControl(pDrillDownParameters->m_hLlJob, (HWND)pDrillDownParameters->m_hAttachInfo, LL_ASSOCIATEPREVIEWCONTROLFLAG_DELETE_ON_CLOSE | LL_ASSOCIATEPREVIEWCONTROLFLAG_HANDLE_IS_ATTACHINFO);
		
		// important
		::LlSetOptionString(pDrillDownParameters->m_hLlJob, LL_OPTIONSTR_PREVIEWFILENAME, pDrillDownParameters->m_sPreviewFileName);
		
		// D:  erzeuge vorschau
		// US: create preview print
		pSample->DoPrintReport(0, pDrillDownParameters->m_hLlJob, pDrillDownParameters->m_sProjectFileName, TRUE);
		
		::EnterCriticalSection(&pSample->m_oLlDrillDownParameters.m_CS);
		
		::LlJobClose(pDrillDownParameters->m_hLlJob);
		pDrillDownParameters->m_hLlJob = 0;
		
		::LeaveCriticalSection(&pSample->m_oLlDrillDownParameters.m_CS);
	}
	
	pDrillDownParameters->m_pSample->NtfyDDJobFinished(pDrillDownParameters->m_nID);
	
	// D:  beenden des Threads (schließt handle, ...)
	// US: end thread (close handle,...)
	::AfxEndThread(0);
	return 0;
}


// ------------------------------------------------------------------------------
UINT_PTR CDesignerPreviewDlg::OnNtfyViewerDrillDown(
													scLlDrillDownJob* pscLlDrillDownJob
													)
// ------------------------------------------------------------------------------
{
	UINT_PTR nReturn = 0;
	ASSERT(pscLlDrillDownJob);
	switch(pscLlDrillDownJob->_nFunction)
	{
		case LL_DRILLDOWN_START:
		{
			CDesignerPreviewDlg* pSample = new CDesignerPreviewDlg(this);

			// add sample to map
			::EnterCriticalSection(&m_oDrillDownCS);
			m_nUniqueDrillDownJobID++;
			m_MapDrillDownSample[m_nUniqueDrillDownJobID] = pSample;
			::LeaveCriticalSection(&m_oDrillDownCS);
			
			// get/copy callback parameters locally
			pSample->m_oLlDrillDownParameters.m_pSample = this;
			pSample->m_oLlDrillDownParameters.m_pInternal = pSample;
			pSample->m_oLlDrillDownParameters.m_nFunction = pscLlDrillDownJob->_nFunction;
			pSample->m_oLlDrillDownParameters.m_nUserParameter = pscLlDrillDownJob->_nUserParameter;
			pSample->m_oLlDrillDownParameters.m_sTableID = pscLlDrillDownJob->_pszTableID;
			pSample->m_oLlDrillDownParameters.m_sRelationID = pscLlDrillDownJob->_pszRelationID;
			pSample->m_oLlDrillDownParameters.m_sSubreportTableID = pscLlDrillDownJob->_pszSubreportTableID;
			pSample->m_oLlDrillDownParameters.m_sKeyField = pscLlDrillDownJob->_pszKeyField;
			pSample->m_oLlDrillDownParameters.m_sSubreportKeyField = pscLlDrillDownJob->_pszSubreportKeyField;
			pSample->m_oLlDrillDownParameters.m_sKeyValue = pscLlDrillDownJob->_pszKeyValue;
			pSample->m_oLlDrillDownParameters.m_sProjectFileName = pscLlDrillDownJob->_pszProjectFileName;
			pSample->m_oLlDrillDownParameters.m_sPreviewFileName = pscLlDrillDownJob->_pszPreviewFileName;
			pSample->m_oLlDrillDownParameters.m_sTooltipText = pscLlDrillDownJob->_pszTooltipText;
			pSample->m_oLlDrillDownParameters.m_sTabText = pscLlDrillDownJob->_pszTabText;
			pSample->m_oLlDrillDownParameters.m_hWnd = pscLlDrillDownJob->_hWnd;
			pSample->m_oLlDrillDownParameters.m_hAttachInfo = pscLlDrillDownJob->_hAttachInfo;
			pSample->m_oLlDrillDownParameters.m_nID = m_nUniqueDrillDownJobID; // set unique JobID for drilldown. Important to ensure the correct drilldown job is handled
			nReturn = m_nUniqueDrillDownJobID; // return value for LL-callback has to be drilldown jobid
			
			AfxBeginThread(ThFctDrillDownPreview, (LPVOID) &pSample->m_oLlDrillDownParameters, THREAD_PRIORITY_NORMAL, 32000);
		}
		break;
		
		case LL_DRILLDOWN_FINALIZE:
		{
			// get unique ID from param
			UINT_PTR nID = (int)pscLlDrillDownJob->_nID;
			
			// search for sampleapp in map with the ID
			::EnterCriticalSection(&m_oDrillDownCS);
			CDesignerPreviewDlg* pSample = NULL;
			if(nID == 0) // abort all ll-prints in map
			{
				POSITION oPos = m_MapDrillDownSample.GetStartPosition();
				UINT_PTR nCurrentID = 0;
				while(oPos != NULL)
				{
					m_MapDrillDownSample.GetNextAssoc(oPos, nCurrentID, pSample);				
					pSample->AbortIfNeeded();
				}
			}
			else if(m_MapDrillDownSample.Lookup(nID, pSample))
				pSample->AbortIfNeeded();
			
			::LeaveCriticalSection(&m_oDrillDownCS);
		}
		break;
		
		default:
			break;
	}
	return nReturn;
}

// ------------------------------------------------------------------------------
void CDesignerPreviewDlg::DoPrintReport(HANDLE hEventPrinting/* = 0*/
								 , HLLJOB hExternalJob/*=0*/
								 , LPCTSTR lpszFileName/*=NULL*/
								 , BOOL bToPreviewNoBox/*=FALSE*/
								 , INT nMaxNoOfPages /*=-1*/
								 , LPCTSTR lpszExportFormat
								 , BOOL bWithoutDialog)
// ------------------------------------------------------------------------------
{
	if (m_pConnection==NULL)
	{
		if (!InitADOConnection())
		{
			return;
		}
	}

	HLLJOB hJob = NULL;
	if(hExternalJob != 0)
		hJob = hExternalJob;
	else
	{
		if(InitLuL())
		{
			hJob = m_hJob;
		}
		else
			return;
	}
	m_hPrintJob = hJob;

	CString			sFileName = _T("*.lst");
	_RecordsetPtr	pRecordSetX;

	if(lpszFileName != NULL)
		sFileName = lpszFileName;

	
	// D:	Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
	//		gewünschten Dateinamen übergeben.
	// US:	Optional call to file selection dialog. Ommit this call and pass the
	//		required file as FileName if you don't want the dialog to appear.
	if(lpszFileName == NULL && ::LlSelectFileDlgTitleEx(hJob, m_hWnd, _T("Design report"), LL_PROJECT_LIST|LL_FILE_ALSONEW,  sFileName.GetBuffer(_MAX_PATH+1), _MAX_PATH, NULL) == LL_ERR_USER_ABORTED) 
	{
		sFileName.ReleaseBuffer();
		MessageBox(_T("User aborted"), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
	}
	else
	{
		sFileName.ReleaseBuffer();

		// D:	Daten definieren. Die hier übergebenen Daten dienen nur der Syntaxprüfung - die Inhalte
		//		brauchen keine Echtdaten zu enthalten
		// US:	Define data. The data passed here is only used for syntax checking and doesn't need
		//	    to contain real data		
		PassDataStructure(hJob);
		
		// activate drilldown feature
		::LlSetOption(hJob, LL_OPTION_DRILLDOWNPARAMETER, (LPARAM)&m_oLlDrillDownParameters);
		
		// D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.
		// US: Start print job. Allow all export formats as target. Meter box with cancel button.
		INT nPrintStartRet = 0;
		if(bToPreviewNoBox)
		{
			::LlSetOptionString(hJob, LL_OPTIONSTR_ORIGINALPROJECTFILENAME, m_sOriginalProjectFileName);
			
			nPrintStartRet = ::LlPrintWithBoxStart(hJob, LL_PROJECT_LIST
								, sFileName
								, LL_PRINT_EXPORT
								, LL_BOXTYPE_NONE, m_hWnd, _T("Printing..."));
		}
		else
		{
			nPrintStartRet = ::LlPrintWithBoxStart(hJob, LL_PROJECT_LIST
								, sFileName
								, LL_PRINT_EXPORT
								, LL_BOXTYPE_STDABORT, m_hWnd, _T("Printing..."));
		}

		if (hEventPrinting != NULL)
			::SetEvent(hEventPrinting);

		if(nPrintStartRet < 0)
		{
			MessageBox(_T("Error While Printing"), _T("List & Label Sample App"), MB_OK|MB_ICONEXCLAMATION);
			
			// deactivate drilldown feature
			::LlSetOption(hJob, LL_OPTION_DRILLDOWNPARAMETER, NULL);
			
			if(hExternalJob == 0)
			{
				::LlJobClose(m_hJob);
				m_hJob = 0;
			}
			return;
		}

	TCHAR aczOption[256] = {0};
	if (lpszExportFormat)
	{
		LlPrintSetOptionString(hJob, LL_PRNOPTSTR_EXPORT, lpszExportFormat);
		wcscpy_s(aczOption, 256, CString(lpszExportFormat).Left(256));
	}
	else
	{
		// default choice shall be PREVIEW if no default Exporter has been chosen		
		LlPrintGetOptionString(hJob, LL_PRNOPTSTR_EXPORT, aczOption, sizeof(aczOption)/sizeof(TCHAR));
		if (aczOption[0] == 0)
			LlPrintSetOptionString(hJob, LL_PRNOPTSTR_EXPORT, TEXT("PRV"));
	}
        
		// D:  Einstellungen bzw. optionen für den Drucker-Optionen-Dialog
		// US: Predifined selections for Print options dialog
		::LlPrintSetOption(hJob, LL_PRNOPT_COPIES, 		LL_COPIES_HIDE);
		::LlPrintSetOption(hJob, LL_PRNOPT_STARTPAGE,	1);
		if(nMaxNoOfPages > 0)
			::LlPrintSetOption(hJob, LL_PRNOPT_LASTPAGE, nMaxNoOfPages);
		if (bWithoutDialog == FALSE && bToPreviewNoBox == FALSE && ::LlPrintOptionsDialog(hJob, m_hWnd, _T("Select printing options")) < 0)
		{
			::LlPrintEnd(hJob,0);
			
			// deactivate drilldown feature
			::LlSetOption(hJob, LL_OPTION_DRILLDOWNPARAMETER, NULL);
			
			if(hExternalJob == 0)
			{
				::LlJobClose(m_hJob);
				m_hJob = 0;
			}
			return;
		}	

		int nLastPage, nRecno;
		TCHAR szPrinter[MAX_PATH], szPort[MAX_PATH];

		::LlPrintGetPrinterInfo(hJob, szPrinter, MAX_PATH, szPort, MAX_PATH);
		nLastPage = ::LlPrintGetOption(hJob, LL_OPTION_LASTPAGE );
		nRecno = 1;
		
		{
			CLock	nPrintLoop(m_nInPrintLoop);
		
		// D:	Erste Seite initialisieren; auch hier kann schon durch Objekte vor der Tabelle
		//		ein Seitenumbruch ausgelöst werden
		// US:	Initialize first page. A page wrap may occur already caused by objects which are
		//		printed before the table
		do
		{
		}
		while(::LlPrint(hJob) == LL_WRN_REPEAT_DATA);


		int nTableRet = 0;
		int nTableIndex = 0;
		  
		int nIndexCurrentTable = 0;
		int nBuffer = 0;
		CString sTableID;
		CString sSortOrderID;

		// D:  Eigentliche Druckschleife; Wiederholung, solange Daten vorhanden
		// US: Print loop. repeat while there is still data to print
		if (::LlPrintDbGetRootTableCount(hJob)!=0)
		{
			do    
			{
				// D:  Root-Tabelle bestimmen und solange drucken bis keine mehr vorhanden
				// US: determine root table and print until no one is available
				nBuffer  = LlPrintDbGetCurrentTable(hJob, NULL, 0, true);
				if(nBuffer > 0)
				{				
					::LlPrintDbGetCurrentTable(hJob, sTableID.GetBuffer(nBuffer+1), nBuffer + 1, false);
					sTableID.ReleaseBuffer();
				}

				if (sTableID == _T("LLStaticTable"))
				{
					nTableRet = ::LlPrintFields(hJob);
					while (nTableRet == LL_WRN_REPEAT_DATA)
					{
						::LlPrint(hJob);
						nTableRet = ::LlPrintFields(hJob);
					}

					do
					{
						nTableRet = ::LlPrintFieldsEnd(hJob);
					}
					while (nTableRet == LL_WRN_REPEAT_DATA);
				}
				else
				{
					nBuffer  = ::LlPrintDbGetCurrentTableSortOrder(hJob, NULL, 0);
					if(nBuffer > 0)
					{						
						::LlPrintDbGetCurrentTableSortOrder(hJob, sSortOrderID.GetBuffer(nBuffer + 1), nBuffer + 1);
						sSortOrderID.ReleaseBuffer();
					}
													
					nTableIndex = GetIndexOfTable(sTableID);
					InitRecordSet(pRecordSetX, m_pConnection, m_olstDataTable.GetAt(m_olstDataTable.FindIndex(nTableIndex)).sSQL);
					pRecordSetX->Sort = (_bstr_t)sSortOrderID;
					 
					nTableRet = PrintTable(hJob, false, pRecordSetX, nTableIndex, nIndexCurrentTable);
				}
           		nIndexCurrentTable = nIndexCurrentTable + 1;
				
    
			}while(nTableRet == LL_WRN_TABLECHANGE);
		}

		} // for m_nInPrintLoop lock

		// D:  Druck beenden
		// US: Stop printing
		::LlPrintEnd(hJob, 0);
	}
	CleanUpRecordSet(pRecordSetX);	
	
	// deactivate drilldown feature
	::LlSetOption(hJob, LL_OPTION_DRILLDOWNPARAMETER, NULL);
	
	if(hExternalJob == 0)
	{
		::LlJobClose(m_hJob);
		m_hJob = 0;
	}
}




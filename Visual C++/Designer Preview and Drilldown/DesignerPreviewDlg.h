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


#if !defined(AFX_DESIGNERPREVIEWDLG_H__66710930_1100_46D6_B842_8272D828FC2A__INCLUDED_)
#define AFX_DESIGNERPREVIEWDLG_H__66710930_1100_46D6_B842_8272D828FC2A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "..\cmbtll29.h"
#include <afxtempl.h>


#define INITGUID
#import "REPLACEDLLPATH" rename_namespace("ADOCG") rename("EOF", "EndOfFile")
using namespace ADOCG;
#include "icrsint.h"

/////////////////////////////////////////////////////////////////////////////
struct scRecordSetInformation              
{
	CString	sTableName;
	CString sRelationName;
	CString sParentTable;
	CString sChildTable;
	CString sParentCol;
	CString sChildCol;
	CString sSQL;
};

struct scMyRealDataParameters
{
	void*				m_pInternal;
	bool				m_bPreview;
	CRITICAL_SECTION	m_CS;
	HANDLE				m_hWorkerThread;
	HLLJOB				m_hLLJob;
	HANDLE				m_hThreadRunning;
	HANDLE				m_hThreadPrinting;
	TCHAR				m_szFilename[MAX_PATH];
	UINT				m_nPages;
	HWND				m_hWnd;
	HANDLE				m_hStateChangeNotificationEvent;
	TCHAR				m_szExportFormat[15];
	BOOL				m_bWithoutDialog;
};


// drilldown feature
class CDesignerPreviewDlg;
typedef CMap<UINT_PTR, UINT_PTR&, CDesignerPreviewDlg*, CDesignerPreviewDlg*> CXMapSample;

struct scMyDrillDownParameters
{
	UINT m_nFunction;
	UINT_PTR m_nUserParameter;
	CString m_sTableID;
	CString m_sRelationID;
	CString m_sSubreportTableID;
	CString m_sKeyField;
	CString m_sSubreportKeyField;
	CString m_sKeyValue;
	CString m_sProjectFileName;
	CString m_sPreviewFileName;
	CString m_sTooltipText;
	CString m_sTabText;
	void* m_pInternal;
	class CDesignerPreviewDlg* m_pSample;
	HWND m_hWnd;
	UINT_PTR m_nID;
	HANDLE m_hAttachInfo;
	HLLJOB m_hLlJob;
	CRITICAL_SECTION m_CS;

	scMyDrillDownParameters()
		: m_pInternal(NULL),
		m_pSample(NULL),
		m_hAttachInfo(NULL),
		m_hLlJob(NULL),
		m_hWnd(NULL),
		m_nFunction(0),
		m_nID(0),
		m_nUserParameter(0)
	{
		::InitializeCriticalSection(&m_CS);
	}

	~scMyDrillDownParameters()
	{
		::DeleteCriticalSection(&m_CS);
	}
};

/////////////////////////////////////////////////////////////////////////////
// CDesignerPreviewDlg dialog

class CDesignerPreviewDlg : public CDialog
{

private:

	void CleanUpImages(void);
	CString GetPictureFilename(void);
	bool InitADOConnection(void);
	bool FillSchemaInfo(void);
	void PassDataStructure(HLLJOB hJob);
	bool InitRecordSet(_RecordsetPtr &pResordSet,_ConnectionPtr pConnection, const CString& sSQL);
	void InitConnection(_ConnectionPtr &pConnection);
	void DefineCurrentSortOrders(HLLJOB hJob, _RecordsetPtr &pResordSet, const CString& sTableName);
	void DefineCurrentRecord(HLLJOB hJob, _RecordsetPtr pResordSet, const CString& sPrefix, bool bWithUseCheck);
	int PrintTable(HLLJOB hJob, bool bIsSubTable, _RecordsetPtr &pRecordSet, int nTabIndex, int nIndexCurrentTable);
	void CleanUpRecordSet(_RecordsetPtr &pRecordSet);
	void CleanUpConnection(_ConnectionPtr &pConnection);
	int GetIndexOfRelation(const CString& sRelationName);
	int GetIndexOfTable(const CString& sTableName);
	CString GetSepFromType(int nInType);		

	INT OnNtfyRealDataDesignerJob(scLlDesignerPrintJob* pscLRDDJ);
	void WaitForEndOfWorkerThread();


private:

	_ConnectionPtr	m_pConnection;
   	_bstr_t			m_sConnStr;
	CString			m_sDatabaseName;
	BOOL			m_bDebug;
	HJOB			m_hJob;
	CString			m_sOriginalProjectFileName;
	INT				m_nAbortCounter;

	scRecordSetInformation									m_scRecordSetInformation;
	CList<scRecordSetInformation,scRecordSetInformation&>	m_olstDataTable;
	CList<scRecordSetInformation,scRecordSetInformation&>	m_olstDataRelation;
	CList<CString, CString&>								m_olstImages;
	
	scMyRealDataParameters	m_oLLRDP;
	
// Construction
public:

	CDesignerPreviewDlg(CWnd* pParent = NULL);	// standard constructor
	~CDesignerPreviewDlg();

	bool InitLuL(HLLJOB* phJob = NULL);
	void DoPrintReport(HANDLE hEventPrinting=0, HLLJOB hExternalJob=0, LPCTSTR lpszFileName=NULL, BOOL bToPreviewNoBox=FALSE, INT nMaxNoOfPages = -1, LPCTSTR lpszExportFormat=NULL, BOOL bWithoutDialog=FALSE);
	
	// drilldown feature
	HLLJOB m_hPrintJob;
	CXMapSample m_MapDrillDownSample;
	UINT_PTR m_nUniqueDrillDownJobID;
	scMyDrillDownParameters	m_oLlDrillDownParameters;
	CRITICAL_SECTION m_oDrillDownCS;
	LONG m_nInPrintLoop;
	
	UINT_PTR OnNtfyViewerDrillDown(scLlDrillDownJob* pscLlDrillDownJob);
	void NtfyDDJobFinished(UINT_PTR nDDJobID);
	void AbortIfNeeded();
	
	LRESULT ForwardToLulMessage(WPARAM wParam, LPARAM lParam);

// Dialog Data
	//{{AFX_DATA(CDesignerPreviewDlg)
	enum { IDD = IDD_DESIGNERPREVIEW_DIALOG };
	CButton	m_oCheckDebug;
	int		m_nLimitRecord;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDesignerPreviewDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL
	

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CDesignerPreviewDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnCheckDebug();
	afx_msg void OnEditReport();
	afx_msg void OnFileExit();
	afx_msg void OnPrintReport();
	afx_msg void OnDestroy();
	afx_msg void OnInfo();
	//}}AFX_MSG
	afx_msg LRESULT OnLulMessageHandler(WPARAM wParam, LPARAM lParam);
	DECLARE_MESSAGE_MAP()
};


//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DESIGNERPREVIEWDLG_H__66710930_1100_46D6_B842_8272D828FC2A__INCLUDED_)

// D:
// Produkt:	combit List & Label 30
// Beschreibung: List & Label C++ DesignerExtension
// Funktion: Zeigt das Hinzufügen von eigenen Funktionen zu List & Label
// Copyright: Copyright (C) combit GmbH

// US:
// Product: combit List & Label 30
// Description: List & Label C++ DesignerExtension
// Function: Shows how to add your own functions to List & Label
// Copyright: Copyright (C) combit GmbH

#include "stdafx.h"
#include "ListLabel.h"

#ifndef LL_OPTION_LLXINTERFACE
#define LL_OPTION_LLXINTERFACE 53
#endif

//================================================================================
CListLabel::CListLabel(INT nLangID)
//================================================================================
{
	m_poFunctionProvider = new LlXFunctionProvider; ASSERT(m_poFunctionProvider);

	m_hJob = 0;

	::LlSetDebug(1);

	m_hJob = ::LlJobOpen(nLangID);

	if (m_hJob==LL_ERR_BAD_JOBHANDLE)
	{
		MessageBox(NULL, _T("Job can't be initialized!"), _T("List & Label Sample App"), MB_OK|MB_ICONSTOP);
	}
	else if (m_hJob==LL_ERR_NO_LANG_DLL)
	{
		MessageBox(NULL, _T("Language file not found!\nEnsure that *.lng files can be found in your List & Label DLL directory."),
					_T("List & Label Sample App"),
					MB_OK|MB_ICONSTOP);
	}
}

//================================================================================
CListLabel::~CListLabel()
//================================================================================
{
	if (m_hJob > 0)
	{
		::LlSetOption(m_hJob, LL_OPTION_LLXINTERFACE, 0);
		::LlJobClose(m_hJob);
	}
}

//================================================================================
long CListLabel::Design(long hWnd, std::wstring sbTitle, long nObjType, std::wstring sbObjName, long bWithFileSelect)
//================================================================================
{
	::LlSetOption(m_hJob, LL_OPTION_LLXINTERFACE, (INT_PTR) m_poFunctionProvider->GetBaseInterface());

	std::wstring sTitle(sbTitle);
	std::wstring sObjName(sbObjName);

	long nRet = 0;

	if (bWithFileSelect != 0)
	{
		TCHAR* pszBuffer = NULL;
		pszBuffer = new TCHAR[_MAX_PATH+1];
		ASSERT(pszBuffer);
		pszBuffer[0] = _T('\0');
		_tcscpy_s(pszBuffer, _MAX_PATH+1, sObjName.substr(0, _MAX_PATH).c_str());

		nRet = ::LlSelectFileDlgTitleEx((HJOB) m_hJob, (HWND) hWnd, NULL, (UINT) nObjType & (0x000F | LL_FILE_ALSONEW), pszBuffer, _MAX_PATH, NULL);
		if (nRet != 0)
		{
			delete[] pszBuffer;
			return nRet;
		}

		sObjName = pszBuffer;
		delete[] pszBuffer;
	}

	::LlDefineChartFieldStart((HJOB) m_hJob);

	if ((nObjType & ~LL_FILE_ALSONEW) == LL_PROJECT_LIST)
	{
		::LlDefineFieldStart((HJOB) m_hJob);
		LLCmndDefineFields();
	}

	// D:	LL_FILE_ALSONEW hat bei LlDefineLayout eine andere Bedeutung.
	// US:	LL_FILE_ALSONEW has a different meaning with LlDefineLayout.
	long nTmpObjType = nObjType & ~LL_FILE_ALSONEW;

	nRet = ::LlDefineLayout((HJOB) m_hJob, (HWND) hWnd, sTitle.c_str(), (UINT) nTmpObjType, sObjName.c_str());

	::LlSetOption((HJOB) m_hJob, 53, (LONG) 0);

	return (nRet);
}

//================================================================================
void CListLabel::LLCmndDefineFields()
//================================================================================
{
	// D:	Definiert den Feldinhalt und Datentyp in List & Label.
	// US:	Defines the field value and data type in List & Label.
	LlDefineFieldExt(m_hJob,_T("String1"), _T("List & Label"), LL_TEXT, NULL);
	LlDefineFieldExt(m_hJob,_T("String2"), _T("Designer Extension"), LL_TEXT, NULL);
	LlDefineFieldExt(m_hJob,_T("String3"), _T("combit GmbH"), LL_TEXT, NULL);

	LlDefineFieldExt(m_hJob,_T("Url1"), _T("en.wikipedia.org/wiki/Côte_d'Azur"), LL_TEXT, NULL);
	LlDefineFieldExt(m_hJob,_T("Url2"), _T("www.google.com/#q=λ"), LL_TEXT, NULL);
	LlDefineFieldExt(m_hJob,_T("Url3"), _T("www.google.com/#q=äöü"), LL_TEXT, NULL);

	LlDefineFieldExt(m_hJob,_T("Number1"), _T("42"), LL_NUMERIC_INTEGER, NULL);
	LlDefineFieldExt(m_hJob,_T("Number2"), _T("378"), LL_NUMERIC_INTEGER, NULL);
	LlDefineFieldExt(m_hJob,_T("Number3"), _T("5713"), LL_NUMERIC_INTEGER, NULL);
}

//================================================================================
void CListLabel::AddFunction(LlXFct* pFunction)
//================================================================================
{
	m_poFunctionProvider->AddFunction(pFunction);
}

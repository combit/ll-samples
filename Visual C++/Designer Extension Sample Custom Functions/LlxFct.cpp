#include <stdafx.h>
#include "Llx.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


/***************************************************************************/
// re-define the GUIDs
#define	CMBTGUID_IMPLEMENTATION	TRUE
#undef LXINTERF_H
#undef _LLX_BASE_H_
#undef _LLX_FCT_H_

#define ROUND_TO_INT(f) (static_cast<int>(f >= 0.0 ? (f + 0.5) : (f - 0.5)))

#include "LL30interf_designer_extension.h"
//================================================================================
LlFctList::~LlFctList()
//================================================================================
{
	Clear();
}

//================================================================================
LlFctList& LlFctList::operator = (const LlFctList& rhs)
//================================================================================
{
	if(&rhs != this)
	{
		*static_cast<std::list<LlXFct*>*>(this) = (rhs);
		if (&rhs != this)
		{
			LlXFct* pFunction = NULL;
			for (const_iterator iter=this->begin(); iter != this->end(); ++iter)
			{
				pFunction = (*iter);
				ASSERT(pFunction);
				pFunction->AddRef();
			}
		}
	}
	return *this;
}

//================================================================================ 
void LlFctList::Clear()
//================================================================================ 
{
	LlXFct* pFunction = NULL;
	for (const_iterator iter=this->begin(); iter != this->end(); ++iter)
	{
		pFunction = (*iter);
		ASSERT(pFunction);
		pFunction->Release();
	}
	clear();
}

//================================================================================ 
LlXFct::LlXFct(void)
	: _hLLJob(0)
		, _nRef(1)
		, _bDesigntime(TRUE)
		, _pLLBase(NULL)
//================================================================================ 
{
}

//================================================================================ 
LlXFct::~LlXFct(void)
//================================================================================ 
{
}

//================================================================================ 
STDMETHODIMP LlXFct::QueryInterface(REFIID riid, VOID** ppvObj)
//================================================================================ 
{
    *ppvObj = NULL;

    if (riid == IID_IUnknown)
	{
        *ppvObj = this;
		AddRef();
	}
    if (riid == IID_LLX_IFUNCTION)
	{
        *ppvObj = this;
		AddRef();
	}

    if (*ppvObj != NULL)
    {
		return(S_OK);
    }

    return(E_NOINTERFACE);
}

//================================================================================ 
STDMETHODIMP_(ULONG) LlXFct::AddRef(void)
//================================================================================ 
{
	ASSERT(_nRef >= 0);
    return ++_nRef;
}

//================================================================================ 
STDMETHODIMP_(ULONG) LlXFct::Release(void)
//================================================================================ 
{
	ASSERT(_nRef > 0);

	if (--_nRef != 0)
	{
		if (_nRef == 1)
			if (_pLLBase)
			{
				_pLLBase->Release();
				_pLLBase=NULL;
			}

		return(_nRef);
	}
    delete this;
    return 0;
}

//================================================================================ 
STDMETHODIMP LlXFct::SetLLJob(HLLJOB hLLJob, ILlBase* pLLBase)
//================================================================================ 
{
	_hLLJob = hLLJob;

	if (_pLLBase)
		_pLLBase->Release();

	_pLLBase = pLLBase;
	if (_pLLBase)
		_pLLBase->AddRef();

	return(S_OK);
}

//================================================================================ 
STDMETHODIMP LlXFct::SetOption(INT nOption, INT_PTR nValue)
//================================================================================ 
{
	switch (nOption)
	{
	case LLXFUNCTION_OPTION_LANGUAGE:
		_nLanguage = (INT)nValue;
		return(S_OK);
	case LLXFUNCTION_OPTION_DESIGNTIME:
		_bDesigntime = ((nValue & 1) != 0);
		break;
	}
	return(E_INVALIDARG);
}

//================================================================================ 
STDMETHODIMP LlXFct::GetOption(INT nOption, INT_PTR* pnValue)
//================================================================================ 
{
	switch (nOption)
	{
	case LLXFUNCTION_OPTION_LANGUAGE:
		*pnValue = _nLanguage;
		return(S_OK);
	}
	return(E_INVALIDARG);
}

//================================================================================ 
STDMETHODIMP LlXFct::GetName(BSTR* pbsName)
//================================================================================ 
{
	SysReAllocString(pbsName, _bstr_t(FctName()));
	return(S_OK);
}

//================================================================================ 
STDMETHODIMP LlXFct::GetDescr(BSTR* pbsDescr)
//================================================================================ 
{
    SysReAllocString(pbsDescr, _bstr_t(FctDescr()));
	return(S_OK);
}

//================================================================================ 
STDMETHODIMP LlXFct::GetGroups(BSTR* pbsGroup)
//================================================================================ 
{
    SysReAllocString(pbsGroup, _bstr_t(FctGroups()));
	return(S_OK);
}

//================================================================================ 
STDMETHODIMP LlXFct::GetGroupDescr(BSTR bsGroup, BSTR* pbsGroupDescr)
//================================================================================ 
{
    SysReAllocString(pbsGroupDescr, _bstr_t(FctGroupDescr(bsGroup)));
	return(S_OK);
}

//================================================================================
STDMETHODIMP LlXFct::GetParaCount(INT* pnMinParas, INT* pnMaxParas)
//================================================================================
{
	FctGetParaCount(pnMinParas, pnMaxParas);
	return(S_OK);
}

//================================================================================
STDMETHODIMP LlXFct::GetParaTypes(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4)
//================================================================================
{
	FctGetParaTypes(pnTypeRes, pnTypeArg1, pnTypeArg2, pnTypeArg3, pnTypeArg4);
	return(S_OK);
}

//================================================================================
STDMETHODIMP LlXFct::CheckSyntax(BSTR* pbsError, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4)
//================================================================================
{
	CString	sError;

	if (FctCheckSyntax(sError,
			pnResType,
			pnLLType,
			pnDecs,
			nArgs,
			VarArg1,VarArg2,VarArg3,VarArg4) < 0)
	{
		*pnResType = -1;
		SysReAllocString(pbsError, _bstr_t(sError));
		return(E_FAIL);
	}
	return(S_OK);
}

//================================================================================ 
STDMETHODIMP LlXFct::Execute(VARIANT* pVarRes, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4)
//================================================================================ 
{
	if (FctExecute(pVarRes, pnResType, pnLLType, pnDecs, nArgs, VarArg1, VarArg2, VarArg3, VarArg4) == 0)
		return(S_OK);
	else
		return(E_FAIL);
}

//================================================================================ 
STDMETHODIMP LlXFct::GetParaValueHint(INT nPara, BSTR* pbsHint, BSTR* pbsTabbedList)
//================================================================================ 
{
	CString sError;	
	CString sTabbedList;

	FctGetParaValueHint(nPara, sError, sTabbedList);

    SysReAllocString(pbsHint, _bstr_t(sError));
    SysReAllocString(pbsTabbedList, _bstr_t(sTabbedList));
	return(S_OK);
}

///////////////////////////////////////////////////////////////////////////////
// LlXFunctionProvider

//================================================================================ 
LlXFunctionProvider::LlXFunctionProvider()
//================================================================================ 
{
	m_FctList.clear();
}

//================================================================================ 
LlXFunctionProvider::~LlXFunctionProvider()
//================================================================================ 
{
}

//================================================================================ 
void LlXFunctionProvider::AddFunction(LlXFct* pFunction)
//================================================================================ 
{
	ASSERT(pFunction);
	
	// get current function name
	BSTR bstrFunctionName(NULL);
	pFunction->GetName(&bstrFunctionName);
	CString sFunctionName((LPCTSTR)bstrFunctionName);
	::SysFreeString(bstrFunctionName);
	bstrFunctionName = NULL;
	
	// step through the existing function list and 'ignore' duplicates
	for (std::list<LlXFct*>::iterator iterLlXFct(m_FctList.begin()); iterLlXFct != m_FctList.end(); ++iterLlXFct)
	{
		(*iterLlXFct)->GetName(&bstrFunctionName);
		CString sExistingFunctionName((LPCTSTR)bstrFunctionName);
		::SysFreeString(bstrFunctionName);
		bstrFunctionName = NULL;
		
		if (sExistingFunctionName == sFunctionName)
		{
			pFunction->Release();
			return;
		}
	}
	
	m_FctList.push_back(pFunction);
}

//================================================================================ 
ILlXInterface* LlXFunctionProvider::GetBaseInterface()
//================================================================================ 
{
	LlXBase* pBase = new LlXBase(m_FctList);
	return((ILlXInterface*)pBase);
}

///////////////////////////////////////////////////////////////////////////////
// LlXFctConvertToRoman
//
// DE: Konvertiert arabische Zahlen in römische Zahlen. Kommazahlen werden gerundet.
// US: Converts arabic numbers to roman numbers. Decimal places will be rounded.
///////////////////////////////////////////////////////////////////////////////

//================================================================================
CString	LlXFctConvertToRoman::FctName(void)
//================================================================================
{
	return(_T("ConvertToRoman_CustomFunction"));
}

//================================================================================
CString	LlXFctConvertToRoman::FctDescr(void)
//================================================================================
{
	return(_T("ConvertToRoman_CustomFunction({Number})\t{String}\tConverts arabic numbers to roman numbers. Decimal places will be rounded."));
}

//================================================================================
CString LlXFctConvertToRoman::FctGroups(void)
//================================================================================
{
	return(_T("Custom functions"));
}

// DE: Unbenutze Variablennamen behalten (falls sie in Zukunft benutzt werden sollen), die entsprechende Warnung aber deaktivieren.
// US: Keep variable names for easier (future) usage of them but disable warning about unused parameters.
#pragma warning(push)
#pragma warning(disable: 4100) 

//================================================================================
CString LlXFctConvertToRoman::FctGroupDescr(const CString& sGroup)
//================================================================================
{
	return(_T("Custom functions"));
}

//================================================================================
void LlXFctConvertToRoman::FctGetParaCount(INT* pnMinParas, INT* pnMaxParas)
//================================================================================
{
	*pnMinParas=1;
	*pnMaxParas=1;
}

//================================================================================
void LlXFctConvertToRoman::FctGetParaTypes(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4)
//================================================================================
{
	*pnTypeRes = LL_FCTPARATYPE_STRING;
	*pnTypeArg1 = LL_FCTPARATYPE_DOUBLE;
}

//================================================================================
INT	LlXFctConvertToRoman::FctCheckSyntax(CString& sError, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4)
//================================================================================
{
	// DE: Prüft, ob der Funktionsparamenter den größten zu konvertierenden Wert überschritten oder den kleinsten zu konvertierenden Wert unterschritten hat. 
	//		Größere / kleinere Zahlen machen keinen Sinn, da sowieso immer nur das gleiche Zeichen angezeigt wird.
	// US: Checks if the function parameter is bigger than the highest desired value or smaller than the lowest desired value.
	//		Bigger / smaller numbers do not make much sense as the roman string would only consist of the same letter over and over again.
	if (VarArg1.dblVal > 10000000 || VarArg1.dblVal < -10000000)
	{
		sError = _T("Too big!");
		return (-1);
	}
	return (0);
}

//================================================================================
INT	LlXFctConvertToRoman::FctExecute(VARIANT* pVarRes, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4)
//================================================================================
{
	int nNumberToConvert = ROUND_TO_INT(VarArg1.dblVal);
	CString sConvertedString = _T("");

	const wchar_t* hundredthousands[]	= {_T(""), _T("C̅"), _T("C̅C̅"), _T("C̅C̅C̅"), _T("C̅D̅"), _T("D̅"), _T("D̅C̅"), _T("D̅C̅C̅"), _T("D̅C̅C̅C̅"), _T("C̅M̅")};
    const wchar_t* tenthousands[]		= {_T(""), _T("X̅"), _T("X̅X̅"), _T("X̅X̅X̅"), _T("X̅L̅"), _T("L̅"), _T("L̅X̅"), _T("L̅X̅X̅"), _T("L̅X̅X̅X̅"), _T("X̅C̅")};
    const wchar_t* thousands[]			= {_T(""), _T("I̅"), _T("I̅I̅"), _T("I̅I̅I̅"), _T("I̅V̅"), _T("V̅"), _T("V̅I̅"), _T("V̅I̅I̅"), _T("V̅I̅I̅I̅"), _T("I̅X̅")};

	const wchar_t* hundreds[]			= {_T(""), _T("C"), _T("CC"), _T("CCC"), _T("CD"), _T("D"), _T("DC"), _T("DCC"), _T("DCCC"), _T("CM")};
    const wchar_t* tens[]				= {_T(""), _T("X"), _T("XX"), _T("XXX"), _T("XL"), _T("L"), _T("LX"), _T("LXX"), _T("LXXX"), _T("XC")};
    const wchar_t* ones[]				= {_T(""), _T("I"), _T("II"), _T("III"), _T("IV"), _T("V"), _T("VI"), _T("VII"), _T("VIII"), _T("IX")};
	
	if (nNumberToConvert < 0)
	{
		sConvertedString.Append(_T("-"));
		nNumberToConvert *= (-1);
	}

	while (nNumberToConvert >= 1000000) 
	{
		sConvertedString.Append(_T("M̅"));
        nNumberToConvert -= 1000000;
    }

	sConvertedString.Append(hundredthousands[nNumberToConvert/100000]);
	nNumberToConvert = nNumberToConvert % 100000;

	sConvertedString.Append(tenthousands[nNumberToConvert/10000]);
	nNumberToConvert = nNumberToConvert % 10000;

	sConvertedString.Append(thousands[nNumberToConvert/1000]);
	nNumberToConvert = nNumberToConvert % 1000;

    sConvertedString.Append(hundreds[nNumberToConvert/100]);
	nNumberToConvert = nNumberToConvert % 100;

    sConvertedString.Append(tens[nNumberToConvert/10]);
	nNumberToConvert = nNumberToConvert % 10;

    sConvertedString.Append(ones[nNumberToConvert]);

	*pnResType = LL_FCTPARATYPE_STRING;
	*pnLLType = LL_TEXT;

	pVarRes->bstrVal = SysAllocString(_bstr_t(sConvertedString));
	pVarRes->vt = VT_BSTR;

	return 0;
}

//================================================================================ 
void LlXFctConvertToRoman::FctGetParaValueHint(INT nPara, CString& sHint, CString& TabbedList)
//================================================================================ 
{
	switch (nPara)
	{
	case 0:
		sHint.Format(_T("An arabic number, e.g. 42"));
		break;
	default:
		sHint=_T("");
		ASSERT(FALSE);
		break;
	}
}

// DE: Warnung zu unbenutzten Variablen wieder aktivieren.
// US: Enable warning about unused variables.
#pragma warning(pop)

///////////////////////////////////////////////////////////////////////////////
// LlXFctReverseString
//
// DE: Zeigt alle Zeichen eines Strings in umgekehrter Reihenfolge.
// US: Shows all characters of a string in reversed order.
///////////////////////////////////////////////////////////////////////////////

//================================================================================
CString	LlXFctReverseString::FctName(void)
//================================================================================
{
	return(_T("ReverseString_CustomFunction"));
}

//================================================================================
CString	LlXFctReverseString::FctDescr(void)
//================================================================================
{
	return(_T("ReverseString_CustomFunction({String})\t{String}\tShows all characters of a string in reversed order."));
}

//================================================================================
CString LlXFctReverseString::FctGroups(void)
//================================================================================
{
	return(_T("Custom functions"));
}

// DE: Unbenutze Variablennamen behalten (falls sie in Zukunft benutzt werden sollen), die entsprechende Warnung aber deaktivieren.
// US: Keep variable names for easier (future) usage of them but disable warning about unused parameters.
#pragma warning(push)
#pragma warning(disable: 4100) 

//================================================================================
CString LlXFctReverseString::FctGroupDescr(const CString& sGroup)
//================================================================================
{
	return(_T("Custom functions"));
}

//================================================================================
void LlXFctReverseString::FctGetParaCount(INT* pnMinParas, INT* pnMaxParas)
//================================================================================
{
	*pnMinParas=1;
	*pnMaxParas=1;
}

//================================================================================
void LlXFctReverseString::FctGetParaTypes(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4)
//================================================================================
{
	*pnTypeRes = LL_FCTPARATYPE_STRING;
	*pnTypeArg1 = LL_FCTPARATYPE_STRING;
}

//================================================================================
INT	LlXFctReverseString::FctCheckSyntax(CString& sError, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4)
//================================================================================
{
	return (0);
}

//================================================================================
INT	LlXFctReverseString::FctExecute(VARIANT* pVarRes, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4)
//================================================================================
{
	CString sInput = VarArg1.bstrVal;
	CString sOutput = _T("");

	for (int i = sInput.GetLength()-1; i >= 0; --i)
	{
		sOutput.AppendChar(sInput.GetAt(i));
	}

	*pnResType = LL_FCTPARATYPE_STRING;
	*pnLLType = LL_TEXT;

	pVarRes->bstrVal = SysAllocString(_bstr_t(sOutput));
	pVarRes->vt = VT_BSTR;

	return (0);
}

//================================================================================ 
void LlXFctReverseString::FctGetParaValueHint(INT nPara, CString& sHint, CString& TabbedList)
//================================================================================ 
{
	switch (nPara)
	{
	case 0:
		sHint.Format(_T("A normal string, e.g. \"Hello\""));
		break;
	default:
		sHint=_T("");
		ASSERT(FALSE);
		break;
	}
}

// DE: Warnung zu unbenutzten Variablen wieder aktivieren.
// US: Enable warning about unused variables.
#pragma warning(pop)

///////////////////////////////////////////////////////////////////////////////
// LlXFctEncodeURL
//
// DE: Enkodiert eine URL (UTF-8).
// US: Encodes a URL (UTF-8).
///////////////////////////////////////////////////////////////////////////////

//================================================================================
CString	LlXFctEncodeURL::FctName(void)
//================================================================================
{
	return(_T("EncodeURL_CustomFunction"));
}

//================================================================================
CString	LlXFctEncodeURL::FctDescr(void)
//================================================================================
{
	return(_T("EncodeURL_CustomFunction({String}{Boolean})\t{String}\tEncodes a URL (UTF-8)."));
}

//================================================================================
CString LlXFctEncodeURL::FctGroups(void)
//================================================================================
{
	return(_T("Custom functions"));
}

// DE: Unbenutze Variablennamen behalten (falls sie in Zukunft benutzt werden sollen), die entsprechende Warnung aber deaktivieren.
// US: Keep variable names for easier (future) usage of them but disable warning about unused parameters.
#pragma warning(push)
#pragma warning(disable: 4100) 

//================================================================================
CString LlXFctEncodeURL::FctGroupDescr(const CString& sGroup)
//================================================================================
{
	return(_T("Custom functions"));
}

//================================================================================
void LlXFctEncodeURL::FctGetParaCount(INT* pnMinParas, INT* pnMaxParas)
//================================================================================
{
	*pnMinParas=1;
	*pnMaxParas=2;
}

//================================================================================
void LlXFctEncodeURL::FctGetParaTypes(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4)
//================================================================================
{
	*pnTypeRes = LL_FCTPARATYPE_STRING;
	*pnTypeArg1 = LL_FCTPARATYPE_STRING;
	*pnTypeArg2 = LL_FCTPARATYPE_BOOL;
}

//================================================================================
INT	LlXFctEncodeURL::FctCheckSyntax(CString& sError, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4)
//================================================================================
{
	return (0);
}

//================================================================================
INT	LlXFctEncodeURL::FctExecute(VARIANT* pVarRes, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4)
//================================================================================
{
	CString sInput = VarArg1.bstrVal;
	BOOL bEncodeReservedChars = (nArgs == 2) ? VarArg2.boolVal : FALSE;
	CString sOutput = _T("");
	CString sAllowedChars = _T("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_.~");
	CString sReservedChars = bEncodeReservedChars ? _T("") : _T("!*'();:@&=+$,/?%#[]");

	for (int i = 0; i < sInput.GetLength(); ++i)
	{
		if (sAllowedChars.Find(sInput.GetAt(i)) < 0 && sReservedChars.Find(sInput.GetAt(i)) < 0)
		{
			int nCodePoint = static_cast<int>(sInput.GetAt(i));
			
			if (nCodePoint < 32) // DE: ASCII Kontroll-Zeichen, US: ASCII control characters
				sOutput.AppendFormat(_T("%%%02x"), nCodePoint);
			else if (nCodePoint == 127) // DE: ASCII Kontroll-Zeichen, US: ASCII control characters
				sOutput.AppendFormat(_T("%%%02x"), nCodePoint);
			else if (nCodePoint < 128) // DE: ASCII Zeichen die nicht erlaubt oder reserviert sind, US: Non-allowed or non-reserved ascii characters
				sOutput.AppendFormat(_T("%%%02x"), nCodePoint);
			else if (nCodePoint < 2048) // DE: Zeichen bestehend aus 2 Bytes, US: Characters consisting of 2 bytes
			{
				sOutput.AppendFormat(_T("%%%02x%%%02x"), (192 + ((nCodePoint >> 6) & 0x1F)), (128 + (nCodePoint & 0x3F)));
			}
			else if (nCodePoint < 65536) // DE: Zeichen bestehend aus 3 Bytes, US: Characters consisting of 3 bytes
			{
				sOutput.AppendFormat(_T("%%%02x%%%02x%%%02x"), (224 + ((nCodePoint >> 12) & 0xF)), (128 + ((nCodePoint >> 6) & 0x3F)), (128 + (nCodePoint & 0x3F)));
			}
			else if (nCodePoint < 2097152) // DE: Zeichen bestehend aus 4 Bytes, US: Characters consisting of 4 bytes
			{
				sOutput.AppendFormat(_T("%%%02x%%%02x%%%02x%%%02x"), (240 + ((nCodePoint >> 18) & 0x7)), (128 + ((nCodePoint >> 12) & 0x3F)), (128 + ((nCodePoint >> 6) & 0x3F)), (128 + (nCodePoint & 0x3F)));
			}
		}
		else
			sOutput.AppendChar(sInput.GetAt(i));
	}

	*pnResType = LL_FCTPARATYPE_STRING;
	*pnLLType = LL_TEXT;

	pVarRes->bstrVal = SysAllocString(_bstr_t(sOutput));
	pVarRes->vt = VT_BSTR;

	return (0);
}

//================================================================================ 
void LlXFctEncodeURL::FctGetParaValueHint(INT nPara, CString& sHint, CString& TabbedList)
//================================================================================ 
{
	switch (nPara)
	{
	case 0:
		sHint.Format(_T("A URL with special characters, e.g. \"www.google.com/#q=λ\""));
		break;
	case 1:
		sHint.Format(_T("Optional: Indicates whether or not to encode reserved characters. Default: False"));
		break;
	default:
		sHint=_T("");
		ASSERT(FALSE);
		break;
	}
}

// DE: Warnung zu unbenutzten Variablen wieder aktivieren.
// US: Enable warning about unused variables.
#pragma warning(pop)

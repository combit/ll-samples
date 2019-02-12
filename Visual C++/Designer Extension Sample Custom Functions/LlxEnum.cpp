#include <stdafx.h>
#include "Llx.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



//================================================================================
LlXEnumFunctions::LlXEnumFunctions(LlFctList& FctList)
	: _nRef(0)
//================================================================================
{
	_FctList.clear();
	_FctList = FctList;
	_iter = _FctList.begin();
}

//================================================================================
LlXEnumFunctions::~LlXEnumFunctions(void)
//================================================================================
{
}

//================================================================================
STDMETHODIMP LlXEnumFunctions::QueryInterface(REFIID riid, VOID** ppvObj)
//================================================================================
{
    *ppvObj = NULL;

    if (riid == IID_IUnknown)
	{
        *ppvObj = this;
		AddRef();
	}
    if (riid == IID_LLX_IENUMFUNCTIONS)
	{
        *ppvObj = this;
		AddRef();
	}

    if (*ppvObj != NULL)
	{
		return(S_OK);
    }

    return (E_NOINTERFACE);
}

//================================================================================
STDMETHODIMP_(ULONG) LlXEnumFunctions::AddRef(void)
//================================================================================
{
	ASSERT(_nRef >= 0);
    return ++_nRef;
}

//================================================================================
STDMETHODIMP_(ULONG) LlXEnumFunctions::Release(void)
//================================================================================
{
	ASSERT(_nRef > 0);

	if (--_nRef != 0)
		return(_nRef);

    delete this;

    return 0;
}

//================================================================================
STDMETHODIMP LlXEnumFunctions::Next(ULONG nCount, ILlXFunction** ppFct, ULONG *nENUMed)
//================================================================================
{
	*nENUMed = 0;
	LlXFct* pFunction = NULL;
	while (nCount > 0 && _iter != _FctList.end())
	{
		pFunction = (*_iter);
		if (pFunction)
		{
			if (!SUCCEEDED(pFunction->QueryInterface(IID_LLX_IFUNCTION,(void**)ppFct)))
			{
				return (E_FAIL);
			}

			++ppFct;
			if (nENUMed)
				++*nENUMed;
			--nCount;
		}
		else
		{
			return (E_FAIL);
		}
		_iter++;
	}
	return(S_OK);
}

//================================================================================
STDMETHODIMP LlXEnumFunctions::Skip(ULONG nDelta)
//================================================================================
{
	for (UINT i = 0; i < nDelta && _iter != _FctList.end(); ++i)
	{
		_iter++;
	}

	if (_iter == _FctList.end())
	{
		_iter--;
		return (E_FAIL);
	}
	return(S_OK);
}

//================================================================================
STDMETHODIMP LlXEnumFunctions::Reset(void)
//================================================================================
{
	_iter = _FctList.begin();
	return(S_OK);
}

//================================================================================
STDMETHODIMP LlXEnumFunctions::Clone(ILlXEnumFunctions **)
//================================================================================
{
	return((E_NOTIMPL));
}
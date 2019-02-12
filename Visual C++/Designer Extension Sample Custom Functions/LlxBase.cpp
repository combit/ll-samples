#include <stdafx.h>
#include "Llx.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



//================================================================================
LlXBase::LlXBase(LlFctList& FctList)
//================================================================================
	: _nRef(0)
{
	_FctList=FctList;
}

//================================================================================
LlXBase::~LlXBase(void)
//================================================================================
{
}

//================================================================================
STDMETHODIMP LlXBase::QueryInterface(REFIID riid, VOID** ppv)
//================================================================================
{
    *ppv = NULL;

    if (riid == IID_IUnknown)
	{
        *ppv = this;
	    AddRef();
	}
    if (riid == IID_LLX_IBASE)
	{
        *ppv = this;
	    AddRef();
	}
    if (riid == IID_LLX_IENUMFUNCTIONS)
	{
        LlXEnumFunctions* pObj = new  LlXEnumFunctions(_FctList);
        if (!SUCCEEDED(pObj->QueryInterface(riid,ppv)))
            delete pObj;
	}

    if (*ppv == NULL)
	{
	    return (E_NOINTERFACE);
	}
	return(S_OK);
}

//================================================================================
STDMETHODIMP_(ULONG) LlXBase::AddRef(void)
//================================================================================
{
	ASSERT(_nRef >= 0);
    return ++_nRef;
}

//================================================================================
STDMETHODIMP_(ULONG) LlXBase::Release(void)
//================================================================================
{
	ASSERT(_nRef > 0);

	if (--_nRef != 0)
		return(_nRef);

    delete this;
    return 0;
}
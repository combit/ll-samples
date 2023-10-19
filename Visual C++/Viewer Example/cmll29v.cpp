// Machine generated IDispatch wrapper class(es) created with ClassWizard

#include "stdafx.h"
#include "cmll29v.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



/////////////////////////////////////////////////////////////////////////////
// IToolbarButtons properties

/////////////////////////////////////////////////////////////////////////////
// IToolbarButtons operations

long IToolbarButtons::GetButtonState(long nButtonID)
{
	long result;
	static BYTE parms[] =
		VTS_I4;
	InvokeHelper(0x1, DISPATCH_METHOD, VT_I4, (void*)&result, parms,
		nButtonID);
	return result;
}

void IToolbarButtons::SetButtonState(long nButtonID, long nButtonState)
{
	static BYTE parms[] =
		VTS_I4 VTS_I4;
	InvokeHelper(0x2, DISPATCH_METHOD, VT_EMPTY, NULL, parms,
		 nButtonID, nButtonState);
}

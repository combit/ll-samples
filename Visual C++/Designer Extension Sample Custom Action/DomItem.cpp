// DomItem.cpp: implementation of the CDomItem class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "DomItem.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CDomItem::CDomItem(HLLDOMOBJ handle)
{
	m_nDomHandle	= 	handle;
}


CDomItem::~CDomItem()
{

}


//================================================================================
int	CDomItem::GetProperty(const CString sPropertyName, CString& sPropertyValue)
//================================================================================
{
	CString sValue;
	int nReturnValue = 0;

	nReturnValue = LlDomGetProperty(m_nDomHandle, sPropertyName, NULL, 0);
	if(nReturnValue > 0)
	{

		nReturnValue = LlDomGetProperty(m_nDomHandle, sPropertyName, sValue.GetBuffer(nReturnValue+1), nReturnValue+1);
		sValue.ReleaseBuffer();
		sPropertyValue = sValue;
		
	}

	return nReturnValue;	
}


//================================================================================
int CDomItem::SetProperty(const CString sPropertyName, const CString sPropertyValue)
//================================================================================
{
	int nReturnValue = LlDomSetProperty(m_nDomHandle, sPropertyName, sPropertyValue);
	return nReturnValue;
}


//================================================================================
int CDomItem::DeleteSubObject(const int nIndex)
//================================================================================
{
	int nReturnValue = LlDomDeleteSubobject(m_nDomHandle, nIndex);
	return nReturnValue;
}


//================================================================================
CDomItem CDomItem::CreateSubObject(int nIndex, const CString sObjectName)
//================================================================================
{
	HLLDOMOBJ hObj = NULL;
	int nReturnValue = LlDomCreateSubobject(m_nDomHandle, nIndex, sObjectName, &hObj);

	if (nReturnValue>=0)
		return CDomItem(hObj);
	else
		return NULL;
}


//================================================================================
CDomItem CDomItem::GetObject(const CString sObjectName)
//================================================================================
{
	HLLDOMOBJ hObj = NULL;
	int nReturnValue = LlDomGetObject(m_nDomHandle, sObjectName, &hObj);

	if (nReturnValue>=0)
		return CDomItem(hObj);
	else
		return NULL;
}


//================================================================================
int CDomItem::ItemCount(int& nItemCount)
//================================================================================
{
	int nCount = 0;
	int nReturnValue = LlDomGetSubobjectCount(m_nDomHandle, &nCount);
	nItemCount = nCount;

	return nReturnValue;
}


//================================================================================
CDomItem CDomItem::operator[](int nIndex) const
//================================================================================
{
	HLLDOMOBJ hObj = NULL;
	int nReturnValue = LlDomGetSubobject(m_nDomHandle, nIndex, &hObj);
	if (nReturnValue>=0)
		return CDomItem(hObj);
	else
		return NULL;
}






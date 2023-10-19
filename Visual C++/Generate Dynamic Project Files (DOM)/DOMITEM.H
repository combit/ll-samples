// DomItem.h: interface for the CDomItem class.
//
//////////////////////////////////////////////////////////////////////


#if !defined(AFX_DOMITEM_H__D7A0F0BA_B289_4D1E_AC3E_760AA262365A__INCLUDED_)
#define AFX_DOMITEM_H__D7A0F0BA_B289_4D1E_AC3E_760AA262365A__INCLUDED_

#include "..\cmbtll29.h"

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CDomItem  
{
public:
	CDomItem(HLLDOMOBJ handle);
	virtual ~CDomItem();

public:
	CDomItem CreateSubObject(const int nIndex, const CString sObjectName);
	int DeleteSubObject(const int nIndex);
	int	GetProperty(const CString sPropertyName, CString& sPropertyValue);
	int SetProperty(const CString sPropertyName, const CString sPropertyValue);
	int ItemCount(int& nItemCount);
	CDomItem GetObject(CString sObjectName);
	CDomItem operator[](int nIndex) const;


public:
	HLLDOMOBJ m_nDomHandle;

};

#endif // !defined(AFX_DOMITEM_H__D7A0F0BA_B289_4D1E_AC3E_760AA262365A__INCLUDED_)

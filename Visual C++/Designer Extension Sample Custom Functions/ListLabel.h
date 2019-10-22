// D:
// Produkt:	combit List & Label 25
// Beschreibung: List & Label C++ DesignerExtension
// Funktion: Zeigt das Hinzufügen von eigenen Funktionen zu List & Label
// Copyright: Copyright (C) combit GmbH

// US:
// Product: combit List & Label 25
// Description: List & Label C++ DesignerExtension
// Function: Shows how to add your own functions to List & Label
// Copyright: Copyright (C) combit GmbH

#pragma once

#include "Llx.h"
#include <string>

class CListLabel
{
public:
	CListLabel(INT nlangID);
	~CListLabel();

	long Design(long hWnd
					, std::wstring sbTitle
					, long nObjType
					, std::wstring sbObjName
					, long bWithFileSelect);

protected:
	HLLJOB m_hJob;
	LlXFunctionProvider* m_poFunctionProvider;

public:
	void AddFunction(LlXFct* pFunction);

protected:
	virtual void LLCmndDefineFields();
};

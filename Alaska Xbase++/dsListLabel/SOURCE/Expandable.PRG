/*============================================================================
 File Name:	   Expandable.PRG
 Author:       Marcus Herz
 Description:
 Created:			 03.06.2020     15:52:56        Updated: þ03.06.2020      þ15:52:56
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//=========================================
PROCEDURE Expandable(nPrintingTarget, lDesignDocument, cFolder)
	LOCAL nError
	LOCAL oListLabel

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// D: Tabellen & Relation hinzufügen
	// US: Add tables & relations
	// D: Tabellen & Relation hinzufügen
	// US: Add tables & relations
	DbUseArea(.T., , "CUSTOMERS")
	dbsetIndex("CUSTOMERS")
	ordsetfocus("CUSTOMERID")

	DbUseArea(.T., , "PRODUCTS")
	dbsetIndex("PRODUCTS")
	ordsetfocus("PRODUCTID")

	DbUseArea(.T., , "ORDDETAIL")
	dbsetIndex("ORDDETAIL")
	ordsetfocus("ORDDERID")

	dbSetRelation( "PRODUCTS",{|| ORDDETAIL->PRODUCTID},,"PRODUCTID")

	DbUseArea(.T., , "ORDERS")
	dbsetIndex("ORDERS")
	ordsetfocus("ORDDERID")
	Goto top

	dbSetRelation( "CUSTOMERS",{|| ORDERS->CUSTOMERID},,"CUSTOMERID")

	// DEMO CODE starts here
	// D: Tabellen anmelden: AddTable(cSymbol, cDescription)
	// US:register tables
	oListLabel	:DefaultExport("PDF;PRN" )
	oListLabel	:AddTable("ORDDETAIL")
	oListLabel	:AddTable("ORDERS")

	// D: alle Felder der Workarea für LLDefineField anmelden
	// US:register all columns of workarea for LLDefineField
	oListLabel	:DataSetField(select("ORDDETAIL")	,"ORDDETAIL")
	oListLabel	:DataSetField(select("ORDERS")		,"ORDERS"	)
	oListLabel	:DataSetField(select("CUSTOMERS")	,"CUSTOMERS")
	oListLabel	:DataSetField(select("PRODUCTS")		,"PRODUCTS"	)

	// D: Relation definieren :AddTableRelationEx(cChild, cParent, cRelation, cDescription, cChildKey, cParentKey)
	// US:define relation
	oListLabel	:AddTableRelation("ORDDETAIL","ORDERS","ORDDETAIL", "", "ORDDETAIL.ORDERID", "ORDERS.ORDERID")

	// D: Expandable einschalten
	// US:enable expandable
	oListLabel	:enableExpand(1)
	oListLabel	:enabledrilldown(1)

	// D:  callback um den Scope der Kind Tabelle neu zusetzen
	// US: callback to set scope according to parent key
	oListLabel	:tablechange	:= {|o,l,c,p| _TableChange(o,l,c,p)}

	// D: Workarea anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register workarea, the report will skip through this table
	oListLabel:connect(select("ORDERS"))

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )
	oListLabel:PrintOption(nPrintingTarget)

	IF lDesignDocument
		oListLabel:design()
	ELSE
		oListLabel:PrintOption(nPrintingTarget)
		nError := oListLabel:print()
		IF nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		ENDIF
	ENDIF
	// D: aufräumen
	// E: clean up
	oListLabel:destroy()
	(select("ORDERS"))->(dbclosearea())
	(select("ORDDETAIL"))->(dbclosearea())
	(select("CUSTOMERS"))->(dbclosearea())
	(select("PRODUCTS"))->(dbclosearea())

RETURN

/*============================================================================
 $Function:    _TableChange(oLL,lStart,cChild,cParent)
 $Argument:    oLL			oListLabel instance, Klasse
 $Argument:    lStart		TRUE: vor dem Druck, Scope setzen, before print, set scope
									FALSE: nach dem Druck, Scope löschen, after print, clear scope
 $Argument:    cChild		Child Table, alias or table object
 $Argument:    cParent		Parent Table, alias or table object
 $Return:      unbedeutend, unimportant
==============================================================================*/
STATIC FUNC _TableChange(oLL,lStart,cChild,cParent)
	if empty(cParent)
		// nothing to do
	elseif lStart
		if cChild <> cParent
			(oLL:GetSelect(cChild))->(dbsetscope( SCOPE_BOTH, (oLL:GetSelect(cParent))->ORDERID))
		endif
   elseif !lStart
		(oLL:GetSelect(cChild))->(dbClearScope())
	endif
RETURN NIL








/*============================================================================
 File Name:	   ReportcontainerArray.PRG
 Author:       Marcus Herz
 Description:
 Created:			 23.11.2021     08:51:31        Updated: þ23.11.2021      þ08:51:31
 Copyright:		 2021 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//=========================================
PROCEDURE ReportContainerArray(nPrintingTarget, lDesignDocument, cFolder)
	LOCAL nError
	LOCAL oListLabel
	LOCAL aInvoice	:= {}
	LOCAL aItems	:= {}

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: Tabellen & Relation hinzufügen
	// US: Add tables & relations
	DbUseArea(.T., , "ITEMS")
	dbsetIndex("Items")
	ordsetfocus("BILLNO")
	aItems	:= {_scatter()}

	DbUseArea(.T., , "INVOICE")
	dbsetIndex("INVOICE")
	ordsetfocus("BILLNO")
	Goto top
	// D: Daten der Invoice in Array lesen
	// US:Read data of INVOICE into array
	do while !eof()
		aadd( aItems, _scatter())
		dbskip()
	enddo

	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// DEMO CODE starts here
	// D: Tabellen anmelden: AddTable(cSymbol, cDescription)
	// US:register tables
	oListLabel	:AddTable("ITEMS")
	oListLabel	:AddTable("INVOICE")

	// D: alle Felder der Workarea für LLDefineField anmelden
	// US:register all columns of workarea for LLDefineField
	oListLabel	:DataSetField(aItems, "ITEMS")
	oListLabel	:DataSetField(aInvoice, "INVOICE")

	// D: Relation definieren :AddTableRelationEx(cChild, cParent, cRelation, cDescription, cChildKey, cParentKey)
	// US:define relation
	oListLabel	:AddTableRelation("ITEMS","INVOICE","INVOICETOITEMS")

	// D: aktuelle Workarea anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register active workarea, the report will skip through this table
	oListLabel:connect(aInvoice)

	// D: Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

	// D:  callback um den Scope der Kind Tabelle neu zusetzen
	// US: callback to set scope according to parent key
	oListLabel:tablechange	:= {|o,l,c,p| _TableChange(o,l,c,p, aItems)}

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
	(select("Invoice"))->(dbclosearea())
	(select("items"))->(dbclosearea())
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
			// D: Item Array mit den enstprechenden Daten füllen
			// US:
			aItems	:= oLL:GetSelect(cChild)
			items->->(dbsetscope( SCOPE_BOTH, oLL:GetSelect(cParent)[]


			(oLL:GetSelect(cChild))->(dbsetscope( SCOPE_BOTH, (oLL:GetSelect(cParent))->billno))
		endif
   elseif !lStart
		(oLL:GetSelect(cChild))->(dbClearScope())
	endif
RETURN NIL

//=========================================
STATIC FUNC _scatter()
	LOCAL aRet	:= array(fcount())
	LOCAL i
	for i := fcount() to 1 step -1
		aRet[i] := fieldget(i)
	next
RETURN aRet

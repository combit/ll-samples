/*============================================================================
 File Name:	   reportcontainer.PRG
 Author:       Marcus Herz
 Description:
 Created:			 29.05.2020     14:52:49        Updated: þ29.05.2020      þ14:52:49
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//=========================================
PROCEDURE dboReportContainer(nPrintingTarget, lDesignDocument, cFolder)
	LOCAL nError
	LOCAL oListLabel
	LOCAL dboItems, dboInvoice

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

	// DEMO CODE starts here
	// D: Datenbank sollte bei Applikation liegen...
	//    Tabellen mit Xbase++ DBE öffnen und die Workarea in einem Klasseobjekt kapseln (hier XClass++)
	// US: Database should be with application exe...
	//    open tables via Xbase++ DBE and wrap workarea in a class object (using XClass++)
	dboItems	:= OpenDbTable("ITEMS")
	dboItems:ordsetfocus("BILLNO")

	dboInvoice	:= OpenDbTable("INVOICE")
	dboInvoice:ordsetfocus("BILLNO")


	// D: Tabellen anmelden: AddTable(cSymbol, cDescription)
	// US:register tables
	oListLabel	:AddTable("ITEMS")
	oListLabel	:DataSetField(dboItems, "ITEMS")

	oListLabel	:AddTable("INVOICE")
	oListLabel	:DataSetField(dboInvoice, "INVOICE")

	// D: Relation definieren :AddTableRelationEx(cChild, cParent, cRelation, cDescription, cChildKey, cParentKey)
	// US:define relation
	oListLabel	:AddTableRelation("ITEMS","INVOICE","InvoiceToItems")

	// D: Tabellenobjekt anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register table object, the report will skip through this table
	oListLabel:connect(dboInvoice)

	// D: Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )
	oListLabel:tablechange	:= {|o,l,c,p| _TableChange(o,l,c,p)}
	oListLabel:PrintOption(nPrintingTarget)

	if lDesignDocument
		oListLabel:design()
	else
		nError := oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	// D: aufräumen
	// US: clean up
	oListLabel:destroy()

	// D:  Destroy Objekt, Datei schliessen
	// US: Destroy object, close table
	dboInvoice:close()
	dboItems:close()
RETURN

//=========================================
STATIC FUNC _TableChange(oLL,lStart,cChild,cParent)
	if lStart .and. !empty(cParent)
		if cChild <> cParent
			oLL:GetSelect(cChild):setscope( SCOPE_BOTH, (oLL:GetSelect(cParent)):billno)
		endif
   elseif !lStart .and. !empty(cParent)
		oLL:GetSelect(cChild):ClearScope()
	endif
RETURN NIL


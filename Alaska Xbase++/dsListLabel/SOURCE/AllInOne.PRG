/*============================================================================
 File Name:	   AllInOne.PRG
 Author:       Marcus Herz
 Description:
 Created:			 26.05.2021     13:01:04        Updated: þ26.05.2021      þ13:01:04
 Copyright:		 2021 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include ".ch"

#include "lldemo.ch"

//=========================================
PROCEDURE AllInOne(nPrintingTarget, lDesignDocument, cFolder)
	LOCAL nError
	LOCAL oListLabel

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: Tabellen & Relation hinzufügen
	// US: Add tables & relations
	DbUseArea(.T., , "Items")
	dbsetIndex("Items")
	ordsetfocus("BILLNO")

	DbUseArea(.T., , "INVOICE")
	dbsetIndex("INVOICE")
	ordsetfocus("BILLNO")
	dbGotop()

	// DEMO CODE starts here
	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// D: Tabellen anmelden: AddTable(cSymbol, cDescription)
	// US:register tables
	oListLabel	:AddTable("ITEMS")
	oListLabel	:AddTable("INVOICE")

	// D: alle Felder der Workarea für LLDefineField anmelden
	// US:register all columns of workarea for LLDefineField
	oListLabel	:DataSetField(select("Items"), "Items")
	oListLabel	:DataSetField(select("Invoice"), "Invoice")

	// D: Relation definieren :AddTableRelationEx(cChild, cParent, cRelation, cDescription, cChildKey, cParentKey)
	// US:define relation
	oListLabel	:AddTableRelationEx("ITEMS","INVOICE","InvoiceToItems", "", "Items.BILLNO", "Invoice.BILLNO")
	oListLabel	:AddTableRelationEx("INVOICE","ITEMS","InvoiceToItems", "", "Items.BILLNO", "Invoice.BILLNO")
	oListLabel	:AddTableRelationEx("","ITEMS","InvoiceToItems", "", "Items.BILLNO", "Invoice.BILLNO")

	// D: Drilldown einschalten
	// US:enable drilldown
	oListLabel	:enableDrillDown(1)
	oListLabel	:enableReportParameter(1)

	// D: Workarea anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register workarea, the report will skip through this table
	oListLabel:connect(select("Invoice"))

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )
	oListLabel:PrintOption(nPrintingTarget)

	IF lDesignDocument
		oListLabel:design()
	ELSE
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

/*============================================================================
 File Name:	   sqlADS.PRG
 Author:       Marcus Herz
 Description:
 Created:			 26.05.2021     09:22:41        Updated: þ26.05.2021      þ09:22:41
 Copyright:		 2021 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"
#include "dsAceServer.ch"

//=========================================
PROCEDURE sqlADS(nPrintingTarget, lDesignDocument, cFolder)
	LOCAL nError
	LOCAL oListLabel
	LOCAL dboInvoice, dboItems
	LOCAL sqlConn
	LOCAL addLLDemo

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: ADS Datendictionary öffnen, using AdsClass++
	// US: open ADS datadictionary    using AdsClass++
	addLLDemo   := dsAceDD():new()
	addLLDemo:connect(fullpath(".\data\lldemo.add",,false),,,,ADS_LOCAL_SERVER)
	if !addLLDemo:Connected()
		ErrorBox("Error conneting to ADS: " + Var2Char(addLLDemo:Lasterror()))
		RETURN
	endif

	// D: INVOICE öffnen
	// US:open INVOICE
	dboInvoice	:= addLLDemo:OpenSelect("select * from Invoice order by billno")
	dboInvoice	:alias	:= "Invoice"


	// D: Items öffnen, hier ein SQL für :prepare() erzeugen
	// US:open ITEMS, create SQL for :prepare()
	sqlConn	:= addLLDemo:CreateSql()
	sqlConn:prepare("select * from items where billno = :BILLNO order by articleno")
	sqlConn:setparam("BILLNO", "")

	dboItems	:= sqlConn:Execute2Table()
	dboItems	:alias	:= "Items"

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
	oListLabel	:DataSetField(dboItems, "ITEMS")
	oListLabel	:DataSetField(dboInvoice, "INVOICE")

	// D: Relation definieren, setzt den Parameter BILLNO auf den Wert von Invoice:billno
	// US:define relation, set parameter BILLNO to value of Invoice:billno
	oListLabel	:AddTableRelation("ITEMS","INVOICE","InvoiceToItems@param?BILLNO=billno")

	// D: aktuelle Workarea anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register active workarea, the report will skip through this table
	oListLabel:connect(dboInvoice)

	// D: Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

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
	dboInvoice:Close()
	dboItems:Close()
	sqlConn:Close()
	addLLDemo:close()

RETURN


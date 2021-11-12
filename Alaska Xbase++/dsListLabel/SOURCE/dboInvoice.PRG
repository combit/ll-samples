/*============================================================================
 File Name:	   xclInvoice.PRG
 Author:       Marcus Herz
 Description:
 Created:			 29.05.2020     14:19:07        Updated: þ29.05.2020      þ14:19:07
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//-------------------------------------------------------------------
PROCEDURE xclInvoice(nPrintingTarget, lDesignDocument, cFolder)
	//-------------------------------------------------------------------
	LOCAL nCount := 0, nError
	LOCAL oListLabel
	LOCAL dbInvoice, dbItems

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	select(0)
	dbInvoice	:= OpenDbTable("INVOICE")
	dbInvoice:ordsetfocus("BILLNO")
	dbInvoice:Gotop()

	// select invoice
	dsSelectValue(,,"Select Invoice",dbInvoice,{;
		{"BILLNO"	,"BILLNO"},;
		{"Company"	,"NAME"	},;
		{"City"		,"CITY"	}},,,,{800,600})

	select(0)
	dbItems	:= OpenDbTable("Items")
	dbItems:ordsetfocus("BILLNO")
	dbItems:Gotop()

	dbItems:setscope( SCOPE_BOTH, dbInvoice:BILLNO )
	dbItems:Gotop()
	// D: Anzahl Artikel auf Rechnung sSelectedNo ermitteln
	// US: Count how many items are on bill sSelectedNo
	Do While .not. dbItems:eof()
		nCount++
		dbItems:Skip()
	EndDo
	dbItems:Gotop()

	// DEMO CODE starts here
	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// D: Felder für LLDefineVariable anmelden,
	// US:register columns for LLDefineVariable,
	oListLabel:DataSetVariable(dbInvoice, "INVOICE")

	// D: aktuelle Workarea anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register active workarea, the report will skip through this table
	oListLabel:connect(dbItems)

	// D: Anzahl Sätze für Fortschrittsbalken
	// US:number of records for progress bar
	oListLabel:lastrec(nCount)

	// D: alle Felder der aktuellen Workarea für LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField(dbItems, "ITEMS")

	// D: Extra Variable definieren für LLDefineField
	// US:define extra variable for LLDefineField
	oListLabel:defineField("ITEMS.ARTICLENO_EAN128", {|o,db| db:fieldget("ARTICLENO")}, LL_BARCODE_EAN128 )

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

	// D: Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	if lDesignDocument
		// D: Designer starten
		// US: start designer
		oListLabel:design()
	else
		// D: Preview, Druck oder Export ausführen
		// US: execute preview, print or export
		oListLabel:PrintOption(nPrintingTarget)
		nError := oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	// D: aufräumen
	// E: clean up
	oListLabel:destroy()

	dbItems:Close()
	dbInvoice:Close()
RETURN



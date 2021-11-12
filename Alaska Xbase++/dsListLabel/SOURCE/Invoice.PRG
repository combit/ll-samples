/*============================================================================
 File Name:	   Invoice.PRG
 Author:       Marcus Herz
 Description:
 Created:			 29.05.2020     14:19:07        Updated: þ29.05.2020      þ14:19:07
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//-------------------------------------------------------------------
PROCEDURE Invoice(nPrintingTarget, lDesignDocument, cFolder)
	//-------------------------------------------------------------------
	LOCAL nCount := 0, nError
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

	// DEMO CODE starts here
	// D: Datenbank sollte bei Applikation liegen...
	// US: Database should be with application exe...
	DbUseArea(.T., , "INVOICE")
	dbsetIndex("INVOICE")
	ordsetfocus("BILLNO")
	Goto top

	// select invoice
	dsSelectValue(,,"Select Invoice",select(),{;
		{"BILLNO"	,"BILLNO"},;
		{"Company"	,"NAME"	},;
		{"City"		,"CITY"	}},,,,{800,600})


	// D: Felder für LLDefineVariable anmelden, kein Parameter: aktuellen Workarea
	// US:register columns for LLDefineVariable, no paramater: active workarea
	oListLabel:DataSetVariable()

	DbUseArea(.T., , "Items")
	dbsetIndex("Items")
	ordsetfocus("BILLNO")

	set filter to field->billNo == invoice->BILLNO
	Goto top
	// D: Anzahl Artikel auf Rechnung ermitteln
	// US: Count how many items are on billNo
	Do While .not. eof()
		nCount++
		Skip
	EndDo
	Goto top

	// D: aktuelle Workarea anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register active workarea, the report will skip through this table
	oListLabel:connect()

	// D: Anzahl Sätze für Fortschrittsbalken
	// US:number of records for progress bar
	oListLabel:lastrec(nCount)

	// D: alle Felder der aktuellen Workarea für LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField()

	// D: Extra Variable definieren für LLDefineField
	// US:define extra variable for LLDefineField
	oListLabel:defineField("ARTICLENO_EAN128", {|o,n| (n)->ARTICLENO}, LL_BARCODE_EAN128 )

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

	dbCloseArea()
RETURN



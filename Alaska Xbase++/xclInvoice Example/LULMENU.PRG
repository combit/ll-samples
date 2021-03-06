//////////////////////////////////////////////////////////////////////
//
//  LULMENU.PRG
//
//  Copyright: Copyright (C) combit GmbH
//  Copyright: DS-Datasoft GmbH&CO.KG
//
//  Content:
//  D: List & Label Druckroutinen
//  US: List & Label printing routines
//
//  D: in Verbindung mit XClass++
//  D: Alle List & Label spezifische Routinen befinden sich in dsListLabel.PRG
//  US: for use with XClass++
//  US: All List & Label specific routines are found in dsListLabel.PRG
//////////////////////////////////////////////////////////////////////

#include "xclass.ch"
#include "dsListLabel.ch"

// D: Ab hier beginnen List & Label spezifische Design- und Druckroutinen
// US: List & Label specific print and design routines start here

//-------------------------------------------------------------------
PROCEDURE PrintInvoice(nPrintingTarget, lDesignDocument)
	//-------------------------------------------------------------------
	LOCAL nCount := 0, nError
	LOCAL dbInvoice, dbItems
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

	// D: Fehler beim Laden der Library
	// US: Library loading error
	If oListLabel:Status() <> XBP_STAT_INIT
		ConfirmBox(SetAppWindow(),"Error loading CMLL26.DLL !."+chr(13)+;
			"OS error#"+Alltrim(Str(DosError()))+Chr(13)+;                             //
			DosErrorMessage(DosError())+chr(13)+;
			Chr(13)+;
			"Tip:"+chr(13)+;
			"In later Xbase++ versions you can check with"+chr(13)+;
			"'DosErrorMessage(DosError())' for error description.",;
			"L&L DLL loading error",;
			XBPMB_OK ,XBPMB_CRITICAL+XBPMB_APPMODAL+XBPMB_MOVEABLE )

		Return
	EndIf

	// D: Datenbank sollte bei Applikation liegen...
	// US: Database should be with application exe...
	dbInvoice	:= OpenDbServer("Invoice")
	dbInvoice:Goto(memvar->oListBox:GetData()[1])

	// D: alle Felder der aktuellen Workarea f�r LLDefineVariable anmelden
	// US:register all columns of active workarea for LLDefineVariable
	oListLabel:DataSetVariable(dbInvoice)

	dbItems	:= OpenDbServer("ITEMS")

	dbItems	:setfilter({|| field->BILLNO == dbInvoice:BILLNO })
	dbItems	:Gotop()
	// D: Anzahl Artikel auf Rechnung sSelectedNo ermitteln
	// US: Count how many items are on bill sSelectedNo
	Do While .not. dbItems:eof()
		nCount++
		dbItems:Skip()
	EndDo
	dbItems:Gotop()

	// D: aktuelle Workarea anmelden
	// US:register active workarea
	oListLabel:connect(dbItems)

	// D: Anzahl S�tze f�r Fortschrittsbalken
	// US:number of records for progress bar
	oListLabel:lastrec(nCount)

	// D: alle Felder der aktuellen Workarea f�r LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField(dbItems)

	// D: Extra Variable definieren f�r LLDefineField
	// US:define extra variable for LLDefineField
	oListLabel:defineField("ARTICLENO_EAN128", {|o,n| n:ARTICLENO}, LL_BARCODE_EAN128 )

	// D: Mehrfache Tabellenzeilendefinitionen ermoeglichen
	// US: Enable multiple table lines
	LlSetOption(oListLabel:hJob, LL_OPTION_MULTIPLETABLELINES, 1)

	// D: oder
	// US: or
	oListLabel:prepareblock	:= {|o| LlSetOption(o:hJob, LL_OPTION_MULTIPLETABLELINES, 1)}

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

	// D: Callback event in Druckvorschau
	// US: catch callback event in preview
	oListLabel:Callback	:= {|nEvent,nId,oListLabel| ;
		iif( nEvent = LL_NTFY_VIEWERBTNCLICKED .and. ( nId = MNUID_LL_PRINT .or. nId = MNUID_LL_PRINT_RM ),;
			msgBox("Hello World"),)}

	if lDesignDocument
		// D: Designer starten
		// US: start designer
		oListLabel:design()
	else
		// D: Preview, Druck oder Export ausf�hren
		// US: execute preview, print or export
		oListLabel:PrintOption(nPrintingTarget)
		nError := oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	oListLabel:close()

	dbItems:close()
	dbInvoice:close()

RETURN



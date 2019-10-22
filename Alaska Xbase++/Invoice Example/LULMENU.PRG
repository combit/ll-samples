//////////////////////////////////////////////////////////////////////
//
//  LULMENU.PRG
//
//  Copyright: Copyright (C) combit GmbH
//
//  Content:
//  D: List & Label Druckroutinen
//  US: List & Label printing routines
//////////////////////////////////////////////////////////////////////

#include "Xbp.ch"
#include "dll.ch"
#include "common.ch"
#include "dsListLabel.ch"

// D: Ab hier beginnen List & Label spezifische Design- und Druckroutinen
// US: List & Label specific print and design routines start here

//-------------------------------------------------------------------
PROCEDURE PrintInvoice(nPrintingTarget, lDesignDocument)
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

	// D: Fehler beim Laden der Library
	// US: Library loading error
	If oListLabel:Status() <> XBP_STAT_INIT
		ConfirmBox(SetAppWindow(),"Error loading CMLL25.DLL !."+chr(13)+;
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
	USE "INVOICE" NEW alias invoice
	Goto top

	Goto memvar->oListBox:GetData()[1]

	// D: alle Felder der aktuellen Workarea für LLDefineVariable anmelden
	// US:register all columns of active workarea for LLDefineVariable
	oListLabel:DataSetVariable()

	USE "ITEMS" NEW

	set filter to field->billNo == invoice->BILLNO
	Goto top
	// D: Anzahl Artikel auf Rechnung sSelectedNo ermitteln
	// US: Count how many items are on bill sSelectedNo
	Do While .not. eof()
		nCount++
		Skip
	EndDo
	Goto top

	// D: aktuelle Workarea anmelden
	// US:register active workarea
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
		// D: Preview, Druck oder Export ausführen
		// US: execute preview, print or export
		oListLabel:PrintOption(nPrintingTarget)
		nError := oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	oListLabel:close()

	CLOSE ALL

RETURN



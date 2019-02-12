//////////////////////////////////////////////////////////////////////
//
//  LULMENU.PRG
//
//  Copyright: Copyright (C) combit GmbH
//  Copyright: DS-Datasoft GmbH&CO.KG
//
//  Content:
//  D: Menue für LULDEMO.EXE und List & Label Druckroutinen
//  US: Menu for LULDEMO.EXE and List & Label printing routines
//
//  D: in Verbindung mit XClass++
//  D: Alle List & Label spezifische Routinen befinden sich in dsListLabel.PRG
//  US: for use with XClass++
//  US: All List & Label specific routines are found in dsListLabel.PRG
//////////////////////////////////////////////////////////////////////

#include "xclass.ch"
#include "dsListLabel.ch"

//-------------------------------------------------------------------
PROCEDURE PrintList(nPrintingTarget, lDesignDocument)
	//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL dbArticle
	LOCAL nError

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, see LlPrintWithBoxStart
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
		ConfirmBox(SetAppWindow(),"Error loading CMLL24.DLL !."+chr(13)+;
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
	dbArticle	:= OpenDbServer("Article")
	dbArticle	:gotop()
	dbArticle	:alias	:= "Article"

	// D: aktuelle Workarea anmelden
	// US:register active workarea
	oListLabel:connect(dbArticle)

	// D: alle Felder der aktuellen Workarea für LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField(dbArticle)

	// D: auskommentieren und mit articleNamed.lst verwenden, um Klarnamen für Felder im Designer anzuzeigen
	// US: uncomment and use with articelNamed.lst to show usage of descriptive field names in designer
	/*
	oListLabel:DataSetField(dbArticle,,{;
			{"Article No"		,"ARTICLENO"},;
			{"Description 1"	,"DESCRIPT1"},;
			{"Description 2"	,"DESCRIPT2"},;
			{"Unit Price"		,"PRICEPP"	},;
			{"Available?"		,"AVAILABLE"},;
			{"Delivery Date"	,"DELIVERY"	},;
			{"on Stock"			,"STOCK"		}})
	*/

	// D: Extra Feld definieren für LLDefineField, wird nach jedem Skip ausgeführt
	// US:define extra field for LLDefineField, executed after each skip
	oListLabel:defineField("ARTICLENO_EAN128", {|o,n| n:ARTICLENO}, LL_BARCODE_EAN128 )

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
		nError	:= oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif

	endif
	oListLabel:close()

	dbArticle:close()

RETURN


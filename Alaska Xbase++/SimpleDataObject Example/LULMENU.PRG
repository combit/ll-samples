//////////////////////////////////////////////////////////////////////
//
//  LULMENU.PRG
//
//  Copyright: Copyright (C) combit GmbH
//
//  Content:
//  D: Menue f�r LULDEMO.EXE und List & Label Druckroutinen
//  US: Menu for LULDEMO.EXE and List & Label printing routines
//////////////////////////////////////////////////////////////////////

#include "Xbp.ch"
#include "dll.ch"
#include "common.ch"
#include "dsListLabel.ch"
#include "dac.ch"

//-------------------------------------------------------------------
PROCEDURE PrintList(nPrintingTarget, lDesignDocument)
//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL nError
	LOCAL aData	:= {}

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
	USE ARTICLE NEW

	// D: Universal SQL, erzeugt Array mit einem Dataobject je Element und Satz
	// US: Universal SQL, creates array with a Dataobject for each element and record
	SELECT * FROM article INTO OBJECTS aData


  	close

	// D: Array anmelden
	// US:register array
	oListLabel:connect(aData)

	oListLabel:DataSetField(aData)

	oListLabel:defineField("ARTICLENO_EAN128", {|o,aData, nRec| aData[nRec]:ARTICLENO}, LL_BARCODE_EAN128 )

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

	CLOSE ALL

RETURN

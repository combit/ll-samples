/*============================================================================
 File Name:	   Simple1.PRG
 Author:       Marcus Herz
 Description:
 Created:			 28.05.2020     14:20:46        Updated: þ12.03.2021      þ08:23:57
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//-------------------------------------------------------------------
PROCEDURE Simple1(nPrintingTarget, lDesignDocument, cFolder)
	//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL nError
	FIELD articleno

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO LL_PRINT_PREVIEW

	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: Datenbank sollte bei Applikation liegen...
	// US: Database should be with application exe...
	USE ARTICLE INDEX ARTICLE NEW
	SET ORDER TO articleno
	GOTO TOP

	// DEMO CODE starts here
	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// D: aktuelle Workarea anmelden
	// US:register active workarea
	oListLabel:connect()

	// D: Felder für LLDefineVariable anmelden, kein Parameter: aktuellen Workarea
	// US:register columns for LLDefineVariable, no paramater: active workarea
	oListLabel:DataSetVariable()

	// D: Extra Variable definieren für LLDefineVariable
	// US:define extra variable for LLDefineVariable
	oListLabel:defineVariable("ARTICLENO_EAN128", {|o,n| (n)->ARTICLENO}, LL_BARCODE_EAN128 )

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LABEL, "Select File" )

	// D: 2 Etiketten je Datensatz
	// US: 2 lables for each record
	oListLabel:Quantity(2)

	// D: Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	IF lDesignDocument
		// D: Designer starten
		// US: start designer
		oListLabel:design()
	ELSE
		// D: Preview, Druck oder Export ausführen
		// US: execute preview, print or export
		oListLabel:PrintOption(nPrintingTarget)
		nError	:= oListLabel:print()
		IF nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		ENDIF
	ENDIF
	// D: aufräumen
	// E: clean up
	oListLabel:destroy()

	dbCloseArea()
RETURN

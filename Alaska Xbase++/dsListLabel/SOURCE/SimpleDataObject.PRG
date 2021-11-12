/*============================================================================
 File Name:	   SimpleDataObject.PRG
 Author:       Marcus Herz
 Description:
 Created:			 03.06.2020     15:01:45        Updated: þ03.06.2020      þ15:01:45
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"
#include "dac.ch"

//-------------------------------------------------------------------
PROCEDURE SimpleDataObject(nPrintingTarget, lDesignDocument, cFolder	)
	LOCAL oListLabel
	LOCAL nError
	LOCAL aData	:= {}

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: Datenbank sollte bei Applikation liegen...
	// US: Database should be with application exe...
	DbUseArea(.T., , "ARTICLE")
	dbsetIndex("ARTICLE")
	ordsetfocus("ARTICLENO")

	// DEMO CODE starts here
	// D: Universal SQL, erzeugt Array mit einem Dataobject je Satz
	// US: Universal SQL, creates array with a dataobject for each record
	SELECT * FROM article INTO OBJECTS aData

	dbclosearea()

	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// D: Array anmelden
	// US:register array
	oListLabel:connect(aData)

	oListLabel:DataSetField(aData)


	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

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
		nError := oListLabel:print()
		IF nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		ENDIF
	ENDIF
	// D: aufräumen
	// E: clean up
	oListLabel:destroy()

RETURN

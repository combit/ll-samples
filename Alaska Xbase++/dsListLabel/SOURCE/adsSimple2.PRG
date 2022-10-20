/*============================================================================
 File Name:	   adsSimple2.PRG
 Author:       Marcus Herz
 Description:
 Created:			 28.05.2020     14:23:54        Updated: þ28.05.2020      þ14:23:54
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"
#include "dsAceServer.ch"

//-------------------------------------------------------------------
PROCEDURE adsSimple2(nPrintingTarget, lDesignDocument, cFolder)
//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL nError
	LOCAL dboArticle
	LOCAL addLLDemo

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// DEMO CODE starts here
	// D: ADS Datendictionary öffnen, mit AdsClass++
	// US: open ADS datadictionary    using AdsClass++
	addLLDemo   := dsAceDD():new()
	addLLDemo:connect(fullpath(".\data\lldemo.add",,FALSE),,,,ADS_LOCAL_SERVER)
	if !addLLDemo:Connected()
		ErrorBox("Error conneting to ADS: " + Var2Char(addLLDemo:Lasterror()))
		RETURN
	endif

	// D: Tabelle als Tabellenobjekt öffnen
	// US: open table as table object
	dboArticle	:= addLLDemo:OpenTable("ARTICLE")
	dboArticle:ordsetfocus("ARTICLENO")

	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())

	// D: dbRelease/dbRequest disablen, keine DBE, nicht nötig für AdsClass++
	// US:dbRelease/dbRequest disablen, no DBE, no need for AdsClass++
	oListLabel:UseDbRequest(FALSE)

	// D: Standard Verzeichnis für Vorlagen
	// US:default folder for layout
	oListLabel:AddPath(cFolder)

	// D: aktuelles Tabellenobjekt anmelden
	// US:register table object
	oListLabel:connect(dboArticle)

	// D: alle Felder der aktuellen Workarea für LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField(dboArticle, "ARTICLE")

	// D: Extra Feld definieren für LLDefineField, wird nach jedem Skip ausgeführt
	// US:define extra field for LLDefineField, executed after each skip
	oListLabel:defineField("ARTICLE.ARTICLENO_EAN128", {|o,db| db:fieldget("ARTICLENO")}, LL_BARCODE_EAN128 )

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
	// US: clean up
	oListLabel:destroy()

	// D:  Destroy Objekte
	// US: Destroy objects
	dboArticle:Close()
	addLLDemo:close()

RETURN


/*============================================================================
 File Name:	   xclSimple2.PRG
 Author:       Marcus Herz
 Description:
 Created:			 28.05.2020     14:23:54        Updated: þ28.05.2020      þ14:23:54
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//-------------------------------------------------------------------
PROCEDURE dboSimple2Opt(nPrintingTarget, lDesignDocument, cFolder)
//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL nError
	LOCAL dboArticle

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, see LlPrintWithBoxStart
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
	//    eine Tabelle mit Xbase++ DBE öffnen und die Workarea in einem Klasseobjekt kapseln (hier XClass++)
	// US: Database should be with application exe...
	//    open a table via Xbase++ DBE and wrap workarea in a class object (using XClass++)
	dboArticle	:= OpenDbTable("ARTICLE")
	dboArticle:ordsetfocus("ARTICLENO")

	// D: aktuelle Workarea anmelden
	// US:register active workarea
	oListLabel:connect(dboArticle, "ARTICLE")

	// D: alle Felder der aktuellen Workarea für LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField(dboArticle)

	// D: Extra Feld definieren für LLDefineField, wird nach jedem Skip ausgeführt
	// US:define extra field for LLDefineField, executed after each skip
	oListLabel:defineField("ARTICLE.ARTICLENO_EAN128", {|o,db| db:fieldget("ARTICLENO")}, LL_BARCODE_EAN128 )

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

	// D: Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	// D: Optinierte Datenübergabe an List & Label
	// US: optimize passing data to List & Label
	oListLabel	:OptimizeDatalink()

	if lDesignDocument
		// D:  Designer starten
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
	// D:  aufräumen
	// US: clean up
	oListLabel:destroy()

	// D:  Destroy Objekt, Datei schliessen
	// US: Destroy object, close table
	dboArticle:Close()

RETURN



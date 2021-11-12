/*============================================================================
 File Name:	   PDF.prg
 Author:       Marcus Herz
 Description:
 Created:			 26.05.2021     12:52:13        Updated: þ26.05.2021      þ12:52:13
 Copyright:		 2021 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/


#include "lldemo.ch"

//-------------------------------------------------------------------
PROCEDURE Pdf(nPrintingTarget, lDesignDocument, cFolder)
//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL lRet
	LOCAL cFile	:= "PDF"+ strzero(seconds(),8.0)+".PDF"

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: Datenbank sollte bei Applikation liegen...
	// US: Database should be with application exe...
	USE ARTICLE INDEX ARTICLE NEW
	GOTO TOP

	// DEMO CODE starts here
	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// D: aktuelle Workarea anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register active workarea, the report will skip through this table
	oListLabel:connect()

	// D: alle Felder der aktuellen Workarea für LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField()

	// D: Extra Feld definieren für LLDefineField, wird nach jedem Skip ausgeführt
	// US:define extra field for LLDefineField, executed after each skip
	oListLabel:defineField("ARTICLENO_EAN128", {|o,n| (n)->ARTICLENO}, LL_BARCODE_EAN128 )

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

	IF lDesignDocument
		// D: Designer starten
		// US: start designer
		oListLabel:design()
	ELSE
		// D:  automatisiertes Erstellen eines PDF ohne Benutzeraingriff: SaveAsPdf(cFile, lQuiet)
		// US: automated creation of a PDF file without user interaction: SaveAsPdf(cFile, lQuiet)
		lRet	:= oListLabel:saveaspdf(cFile, true )
		if !lRet
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		else
			runshell('/C start " " /MIN "'+ GetAppDir()+cFile +'"')
		endif
		CopyFiles2Clipboard(GetApp():GetHWnd(), true, GetAppDir()+cFile)
	ENDIF

	// D: aufräumen
	// E: clean up
	oListLabel:destroy()

	dbCloseArea()

RETURN


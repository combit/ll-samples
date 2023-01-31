/*============================================================================
 File Name:	   Simple2Stream.prg
 Author:       Marcus Herz
 Description:
 Created:			 19.12.2022     10:12:06        Updated: þ19.12.2022      þ10:12:06
 Copyright:		 2022 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//-------------------------------------------------------------------
PROCEDURE Simple2Stream(nPrintingTarget, lDesignDocument, cFolder)
//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL nError, nRec
	LOCAL cStream

	// D:  LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D:  .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D:  Report aus DBF wählen
	// US: select report from repository

	USE REPOSITORY NEW

	nRec	:= dsSelectValue(,, "Select Report", select(),{;
		{"Title"		,"TITLE"		}},,,, {600,500})

	if empty(nRec)
		dbclosearea()
		RETURN
	endif

	// DEMO CODE starts here
	cStream	:= field->report

	// D:  Datenbank sollte bei Applikation liegen...
	// US: Database should be with application exe...
	USE ARTICLE INDEX ARTICLE NEW
	GOTO TOP

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

	// D:  Callback event in Druckvorschau
	// US: catch callback event in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	// D:  Inhalt des MEMO Feldes für Report übergeben
	// US: pass content of memo field for report
	oListLabel:Stream2Report(cStream, LL_PROJECT_LIST)

	IF lDesignDocument
		// D:  Designer starten
		// US: start designer
		oListLabel:design()

		// D:  Designer Aktion gespeichert
		// US: designer action saved
		IF oListLabel:designerUpdated()
      	IF ("REPOSITORY")->(dbrlock())
				("REPOSITORY")->REPORT		:= oListLabel:Report2Stream()
				("REPOSITORY")->LASTUPDATE	:= dtos(date()) +" "+ time()
            ("REPOSITORY")->(dbunlock())
         ENDIF
      ENDIF
	ELSE

		// D: Preview, Druck oder Export ausführen
		// US: execute preview, print or export
		oListLabel:PrintOption(nPrintingTarget)
		nError := oListLabel:print()
		if nError > 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	ENDIF

	// D: aufräumen
	// E: clean up
	oListLabel:destroy()

	("ARTICLE")->(dbclosearea())

	("REPOSITORY")->(dbCloseArea())

RETURN


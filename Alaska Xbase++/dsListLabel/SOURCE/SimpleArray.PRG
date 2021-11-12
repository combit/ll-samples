/*============================================================================
 File Name:	   SimpleArray.PRG
 Author:       Marcus Herz
 Description:
 Created:			 03.06.2020     15:06:23        Updated: þ03.06.2020      þ15:06:23
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//-------------------------------------------------------------------
PROCEDURE SimpleArray(nPrintingTarget, lDesignDocument, cFolder)
//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL nError, i, f, fCnt, nEan
	LOCAL aData
	FIELD articleno

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: Datenbank sollte bei Applikation liegen...
	// US: Database should be with application exe...
	USE ARTICLE INDEX ARTICLE NEW
	SET ORDER TO articleno
	GOTO TOP

	// DEMO CODE starts here
	// D: Tabelle in Array kopieren
	// US: copy table to array
	GOTO TOP
	fCnt	:= Fcount()
	i		:= 0

	// D: 2-dim Array
	// US: 2 dim array
	aData	:= array( lastrec(), fCnt)
	DO WHILE !eof()
		i++
		FOR f := 1 TO fCnt
			aData[i,f] := FieldGet(f)
		NEXT
		dbSkip()
	ENDDO

	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// D: Felder definieren für LLDefineField, wird für jedes Array Element ausgeführt
	// US:define fields for LLDefineField, executed for each array element
	FOR f := 1 TO fCnt
		oListLabel:defineField(FieldName(f), _crtBlock(f))
	NEXT

	// D: Feldposition für EAN LLDefineField
	// US: get fieldpos for EAN LLDefineField
	nEan  := fieldpos("ARTICLENO")

	dbclosearea()

	// DEMO CODE starts here
	// D: Array anmelden
	// US:register array
	oListLabel:connect(aData)

	oListLabel:defineField("ARTICLENO_EAN128", {|o,aData, nRec| aData[nRec][nEan]}, LL_BARCODE_EAN128 )

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

//=========================================
// detached local
//=========================================
STATIC FUNC _crtBlock(f)		;RETURN {|o,aData,nRec| aData[nRec,f]}

//////////////////////////////////////////////////////////////////////
//
//  LULMENU.PRG
//
//  Copyright: Copyright (C) combit GmbH
//
//  Content:
//  D: Menue für LULDEMO.EXE und List & Label Druckroutinen
//  US: Menu for LULDEMO.EXE and List & Label printing routines
//////////////////////////////////////////////////////////////////////

#include "Xbp.ch"
#include "dll.ch"
#include "common.ch"
#include "dsListLabel.ch"

//-------------------------------------------------------------------
PROCEDURE PrintList(nPrintingTarget, lDesignDocument)
//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL nError, i, f, fCnt, nEan
	LOCAL aData

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
	USE ARTICLE NEW

	// D: Datenbank in Array kopieren
	// US: copy Database to array
	Goto top
	fCnt	:= fcount()
	i		:= 0

	// D: Feldposition für EAN LLDefineField
	// US: get fieldpos for EAN LLDefineField
	nEan  := fieldpos("ARTICLENO")


	// D: 2-dim Array
	// US: 2 dim array
	aData	:= array( lastrec(), fCnt)
	do while !eof()
		i++
		for f := 1 to fCnt
			aData[i,f] := fieldget(f)
		next
		dbskip()
	enddo

	// D: Extra Feld definieren für LLDefineField, wird nach jedem Skip ausgeführt
	// US:define extra field for LLDefineField, executed after each skip
	for f := 1 to fCnt
		oListLabel:defineField(fieldname(f), _crtBlock(f))
	next

	close


	// D: Array anmelden
	// US:register array
	oListLabel:connect(aData)

	oListLabel:defineField("ARTICLENO_EAN128", {|o,aData, nRec| aData[nRec][nEan]}, LL_BARCODE_EAN128 )

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

//=========================================
// detached local
//=========================================
STATIC FUNC _crtBlock(f)		;RETURN {|o,aData,nRec| aData[nRec,f]}

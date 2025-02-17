/*============================================================================
 File Name:	   Invoice.PRG
 Author:       Marcus Herz
 Description:
 Created:			 29.05.2020     14:19:07        Updated: �29.05.2020      �14:19:07
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"
#include "dll.ch"

EXTERN LONG DocumentProperties( ;
	hWnd AS UINTEGER, ;
	hPrinter AS UINTEGER, ;
	cDevice AS STRING, ;
	@DevModeOut AS STRUCTURE, ;
	@DevModeIn AS STRUCTURE, ;
	fMode AS UINTEGER ) IN WINSPOOL.DRV


EXTERN BOOL OpenPrinter( ;
	cPrinter AS STRING, ;
	@nHandle AS UINTEGER, ;
	nDefaults  AS UINTEGER) IN WINSPOOL.DRV

#define DM_OUT_BUFFER     2
//-------------------------------------------------------------------
PROCEDURE Invoice(nPrintingTarget, lDesignDocument, cFolder)
	//-------------------------------------------------------------------
	LOCAL nCount := 0, nError
	LOCAL oListLabel

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
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
	// US: Database should be with application exe...
	DbUseArea(.T., , "INVOICE")
	dbsetIndex("INVOICE")
	ordsetfocus("BILLNO")
	Goto top

	// select invoice
	dsSelectValue(,,"Select Invoice",select(),{;
		{"BILLNO"	,"BILLNO"},;
		{"Company"	,"NAME"	},;
		{"City"		,"CITY"	}},,,,{800,600})


	// D: Felder f�r LLDefineVariable anmelden, kein Parameter: aktuellen Workarea
	// US:register columns for LLDefineVariable, no paramater: active workarea
	oListLabel:DataSetVariable()

	DbUseArea(.T., , "Items")
	dbsetIndex("Items")
	ordsetfocus("BILLNO")

	set filter to field->billNo == invoice->BILLNO
	Goto top
	// D: Anzahl Artikel auf Rechnung ermitteln
	// US: Count how many items are on billNo
	Do While .not. eof()
		nCount++
		Skip
	EndDo
	Goto top

	// D: aktuelle Workarea anmelden, �ber dies Tabelle wird f�r die Liste geskippt
	// US:register active workarea, the report will skip through this table
	oListLabel:connect()

	// D: Anzahl S�tze f�r Fortschrittsbalken
	// US:number of records for progress bar
	oListLabel:lastrec(nCount)

	// D: alle Felder der aktuellen Workarea f�r LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField()

	// D: Extra Variable definieren f�r LLDefineField
	// US:define extra variable for LLDefineField
	oListLabel:defineField("ARTICLENO_EAN128", {|o,n| (n)->ARTICLENO}, LL_BARCODE_EAN128 )

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

	// D: Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

  	oListLabel:SetDevMode( "dmDefaultSource", 2 )
  	oListLabel:SetDevMode( "dmColor", 1 )

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
	// D: aufr�umen
	// E: clean up
	oListLabel:destroy()

	dbCloseArea()
RETURN


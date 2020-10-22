//////////////////////////////////////////////////////////////////////
//
//  Copyright: Copyright (C) combit GmbH
//
//  Contents:
//        This is a standard win32 exe.
//
//////////////////////////////////////////////////////////////////////
#include "xclass.ch"
#include "dsListLabel.ch"

PROCEDURE Main

	LOCAL nEvent := xbe_None, mp1 := 0, mp2 := 0, oXbp := 0

	PRIVATE lDebugOutput := .f.

	SET DATE TO SYSTEM
	SET DELETED ON
	SET PATH TO (".\;..\")

	// D: globale Einstellungen, Lizenz eintragen, Designer Echtdatenvorschau aktivieren
	// US: global settings, add licence, enable designer preview
	//dsListLabel():LicensingInfo(<...>)
	dsListLabel():DefaultDesignerPreview(.t.)
	dsListLabel():DefaultPath("xclReport Container")

	// D: Form erzeugen
	// US: create form
	CreateMainWindow()

	SetAppWindow():show()
	SetAppFocus( SetAppWindow())

	DO WHILE nEvent <> xbeP_Close
		nEvent := AppEvent( @mp1, @mp2, @oXbp )
		oXbp:handleEvent( nEvent, mp1, mp2 )
	END DO

	SetAppWindow():destroy()
	CLOSE ALL
	Quit

RETURN

// D: Standardmaessiges Xbase++ Fenster nicht erzeugen - wird nicht gebraucht
// US: Don't create default Xbase++ window - it's not needed
PROCEDURE AppSys()

RETURN

PROCEDURE PrintReport(nPrintingTarget, lDesign)
	LOCAL oListLabel
	LOCAL nError
	LOCAL dbInvoice, dbItems

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
	dbInvoice	:= OpenDbServer("Invoice")
	dbInvoice	:createindex("BILLNO", , "BILLNO")
	dbInvoice	:ordsetfocus("BILLNO")

	// D: Tabellen & Relation hinzufügen
	// US: Add tables & relations
	dbItems	:= OpenDbServer("ITEMS")
	dbItems	:createindex("BILLNO", , "InvoiceNO")
	dbItems	:ordsetfocus("BILLNO")

	oListLabel	:AddTable( "ITEMS")
	oListLabel	:DataSetField(dbItems, "Items")

	oListLabel	:AddTable( "INVOICE" )
	oListLabel	:DataSetField(dbInvoice, "Invoice")

	oListLabel	:AddTableRelation("ITEMS","INVOICE","<BILLNO", "Invoice Items")

	oListLabel	:Connect(dbInvoice)

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel	:SetProperty(, LL_PROJECT_LIST, "Select File" )

	// D:  Relation wird über Relationsausdruck gesetzt, da mit < beginnt
	// US: relation is set by expression which starts with <

	oListLabel	:PrintOption(nPrintingTarget)

	// D: Callback event in Druckvorschau
	// US: catch callback event in preview
	oListLabel	:Callback	:= {|nEvent,nId,oListLabel| ;
		iif( nEvent = LL_NTFY_VIEWERBTNCLICKED .and. ( nId = MNUID_LL_PRINT .or. nId = MNUID_LL_PRINT_RM ),;
			msgBox("Hello World"),)}

	if !empty(lDesign)
		oListLabel:Design()
	else
		nError := oListLabel:Print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	oListLabel:Close()
	Close Databases

RETURN


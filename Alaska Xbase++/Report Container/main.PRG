//////////////////////////////////////////////////////////////////////
//
//  Copyright: Copyright (C) combit GmbH
//
//  Contents:
//        This is a standard win32 exe.
//
//////////////////////////////////////////////////////////////////////
#include "Appevent.ch"
#include "Xbp.ch"
#include "dll.ch"
#include "common.ch"
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
	dsListLabel():DefaultPath("Report Container")

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
	LOCAL oListLabel	:= dsListLabel():New(SetAppWindow())
	LOCAL nError

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

	// D: Tabellen & Relation hinzufügen
	// US: Add tables & relations
	DbUseArea(.T., , "Items")
   INDEX ON ITEMS->BILLNO TO InvoiceNO
   SET INDEX TO InvoiceNO

	oListLabel	:AddTable(, "Items")
	oListLabel	:DataSetField(, "Items")

	DbUseArea(.T., , "Invoice")
   INDEX ON INVOICE->BILLNO TO BILLNO
   SET INDEX TO BILLNO

	oListLabel	:AddTable(, "Invoice" )
	oListLabel	:DataSetField(, "Invoice")

	oListLabel	:AddTableRelation("Items","Invoice","InvoiceToItems")

	oListLabel:connect()

	// D: Callback event in Druckvorschau
	// US: catch callback event in preview
	oListLabel:Callback	:= {|nEvent,nId,oListLabel| ;
		iif( nEvent = LL_NTFY_VIEWERBTNCLICKED .and. ( nId = MNUID_LL_PRINT .or. nId = MNUID_LL_PRINT_RM ),;
			msgBox("Hello World"),)}

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )
	oListLabel:tablechange	:= {|o,l,c,p| _TableChange(o,l,c,p)}
	oListLabel:PrintOption(nPrintingTarget)

	if !empty(lDesign)
		oListLabel:design()
	else
		nError := oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	oListLabel:close()
	Close Databases

RETURN

//=========================================
STATIC FUNC _TableChange(oLL,lStart,cChild,cParent)
	if lStart .and. !empty(cParent)
		if cChild <> cParent
			(oLL:GetSelect(cChild))->(dbsetscope( SCOPE_BOTH, (oLL:GetSelect(cParent))->billno))
		endif
   elseif !lStart .and. !empty(cParent)
		(oLL:GetSelect(cChild))->(dbClearScope())
	endif
RETURN NIL


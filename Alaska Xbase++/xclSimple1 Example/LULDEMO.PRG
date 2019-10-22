//////////////////////////////////////////////////////////////////////
//
//  LULDEMO.PRG
//
//  Copyright: Copyright (C) combit GmbH
//  Copyright: DS-Datasoft GmbH&CO.KG
//
//  Content:
//  D: Hauptroutine fuer List & Label Etikettenbeispiel
//  US: Main routine for List & Label label sample
//
//  D: in Verbindung mit XClass++
//  D: Alle List & Label spezifische Routinen befinden sich in dsListLabel.PRG
//  US: for use with XClass++
//  US: All List & Label specific routines are found in dsListLabel.PRG
//////////////////////////////////////////////////////////////////////

#include "xclass.ch"
#include "dsListLabel.ch"


PROCEDURE Main()
	LOCAL nEvent := xbe_None, mp1 := 0, mp2 := 0, oXbp := 0
	Private lDebugOutput := .f.
	SET DATE TO SYSTEM
	SET DELETED ON
	SET PATH TO (".\;..\")

	// D: globale Einstellungen, Lizenz eintragen, Designer Echtdatenvorschau aktivieren
	// US: global settings, add licence, enable designer preview
	//dsListLabel():LicensingInfo(<...>)
	dsListLabel():DefaultDesignerPreview(.t.)
	dsListLabel():DefaultPath("xclSimple1 Example")

	CreateMainWindow()

	SetAppWindow():show()
	SetAppFocus( SetAppWindow())

	DO WHILE nEvent <> xbeP_Close
		nEvent := AppEvent( @mp1, @mp2, @oXbp )
		oXbp:handleEvent( nEvent, mp1, mp2 )
	ENDDO
	SetAppWindow():destroy()
	CLOSE ALL
	Quit
RETURN


PROCEDURE CreateMainWindow()
	Local nHeight := 200, nWidth := 480
	Local aSize    := AppDesktop():currentSize()
	Local aPos := {Int( (aSize[1]-nWidth ) / 2 ), Int( (aSize[2]-nHeight) / 2 )}
	LOCAL oDlg, oStatic, oXbp
	Local oButton

	oDlg := XbpDialog():new()
	oDlg:title    := "List & Label 25 Xbase++ - Demo"
	oDlg:border   := XBPDLG_DLGBORDER
	oDlg:taskList := .T.
	oDlg:maxButton:= .F.
	oDlg:create( ,, aPos, {nWidth, nHeight},, .F. )

	MenuCreate( oDlg:menuBar() )

	oStatic := XbpStatic():new( oDlg:DrawingArea,, {12, 95},  {456, 20} )
	oStatic:caption := "D:  Dieses Beispiel demonstriert das Designen und Drucken von Etiketten"
	oStatic:create()

	oStatic := XbpStatic():new( oDlg:DrawingArea,, {12, 50},  {456, 20} )
	oStatic:caption := "US: This example demonstrates how to design and print labels"
	oStatic:create()


	oButton := XbpPushButton():new(oDlg:DrawingArea,, {12, 12},  {100, 24} )
	oButton:caption := "Design"
	oButton:create()
	oButton:activate:= {|uNIL1, uNIL2, oObj| oObj:disable(), PrintLabels(,.t.), oObj:enable() }

	oButton := XbpPushButton():new(oDlg:DrawingArea,, {132, 12},  {100, 24} )
	oButton:caption := "Preview"
	oButton:create()
	oButton:activate:= {|uNIL1, uNIL2, oObj| oObj:disable(), PrintLabels(), oObj:enable()  }

	oButton := XbpPushButton():new(oDlg:DrawingArea,, {252, 12},  {100, 24} )
	oButton:caption := "Export"
	oButton:create()
	oButton:activate:= {|uNIL1, uNIL2, oObj| oObj:disable(), PrintLabels(LL_PRINT_EXPORT), oObj:enable()  }

	// D: Debugoption setzen
	// US: Set debug option
	oXbp := XbpCheckbox():new(oDlg:DrawingArea, , {372,12}, {100,24} )
	oXbp:caption := "Debug output"
	oXbp:create()
	oXbp:selected := {| lCheck, uNIL, self | dsListLabel():DefaultDebug(lCheck), IIf(lCheck,;
		MsgBox("D: Debwin muss zur Anzeige von Debugausgaben gestartet werden"+chr(13)+;
		"US: Start Debwin to receive debug messages","Debug option"),Nil) }
	SetAppWindow( oDlg )
RETURN

// D: Menuesystem erzeugen
// US: Create menu-system
//-------------------------------------------------------------------
STATIC PROCEDURE MenuCreate( oMenuBar )
	//-------------------------------------------------------------------
	LOCAL oMenu
	// D: Menue erzeugen
	// US: Create menu
	oMenu := XbpMenu():new( oMenuBar ):create()
	oMenu:title := "Help"
	oMenu:addItem( { "~About",  {|| AboutBox() } } )

	oMenuBar:addItem( {oMenu, NIL} )

RETURN

STATIC Procedure AboutBox()
	ConfirmBox(SetAppWindow() , "List & Label 25 Xbase++ Demo (c) 2019 combit GmbH", "About", XBPMB_OK , XBPMB_INFORMATION+XBPMB_APPMODAL+XBPMB_MOVEABLE )
RETURN

// D: Standardmaessiges Xbase++ Fenster nicht erzeugen - wird nicht gebraucht
// US: Don't create default Xbase++ window - it's not needed
Procedure AppSys(); return

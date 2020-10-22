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


PROCEDURE CreateMainWindow()
	Local nHeight := 200, nWidth := 480
	Local aSize    := AppDesktop():currentSize()
	Local aPos := {Int( (aSize[1]-nWidth ) / 2 ), Int( (aSize[2]-nHeight) / 2 )}
	LOCAL oDlg, oStatic
	Local oButton

	oDlg := XbpDialog():new()
	oDlg:title    := "List & Label 26 Xbase++ - Demo"
	oDlg:border   := XBPDLG_DLGBORDER
	oDlg:taskList := .T.
	oDlg:maxButton:= .F.
	oDlg:create( ,, aPos, {nWidth, nHeight},, .F. )

	MenuCreate( oDlg:menuBar() )

	oStatic := XbpStatic():new( oDlg:DrawingArea,, {12, 95},  {456, 20} )
	oStatic:caption := "D:  Dieses Beispiel demonstriert die Verwendung des Berichtscontainers"
	oStatic:create()

	oStatic := XbpStatic():new( oDlg:DrawingArea,, {12, 50},  {456, 20} )
	oStatic:caption := "US: This example demonstrates how to use the report container"
	oStatic:create()

	oButton := XbpPushButton():new(oDlg:DrawingArea,, {12, 12},  {100, 24} )
	oButton:caption := "Design"
	oButton:create()
	oButton:activate:= {|uNIL1, uNIL2, oObj| oObj:disable(), PrintReport(, .t.), oObj:enable() }

	oButton := XbpPushButton():new(oDlg:DrawingArea,, {132, 12},  {100, 24} )
	oButton:caption := "Preview"
	oButton:create()
	oButton:activate:={|uNIL1, uNIL2, oObj| oObj:disable(), PrintReport(LL_PRINT_PREVIEW), oObj:enable() }

	SetAppWindow( oDlg )
RETURN

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
	ConfirmBox(SetAppWindow() , "List & Label 26 Xbase++ Demo (c) 2020 combit GmbH", "About", XBPMB_OK , XBPMB_INFORMATION+XBPMB_APPMODAL+XBPMB_MOVEABLE )
RETURN

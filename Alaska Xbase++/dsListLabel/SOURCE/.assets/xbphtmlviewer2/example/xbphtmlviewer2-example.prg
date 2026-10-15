#include "xbp.ch"

PROCEDURE Main()
 LOCAL oDlg
 LOCAL oXbp

   SET CHARSET TO ANSI

   // Create a form for hosting the HTML viewer object
   oDlg := XbpDialog():new( AppDesktop() )
   oDlg:taskList := .T.
   oDlg:create( ,,, {640,480} )
   CenterControl( oDlg )

   // Create the HTML viewer object and arrange for it to cover the form's
   // content area
   oXbp := XbpHTMLViewer2():new( oDlg:drawingArea )
   oXbp:layoutAlign := XBPLAYOUT_LEFT + XBPLAYOUT_TOP + XBPLAYOUT_RIGHT + XBPLAYOUT_BOTTOM
   oXbp:create( ,, {10,10}, {600,420} )

   oXbp:navigate( "http://www.alaska-software.com" )

   oDlg:showModal()
   oDlg:destroy()
RETURN


PROCEDURE AppSys()
   // Prevent creation of the default console window
RETURN

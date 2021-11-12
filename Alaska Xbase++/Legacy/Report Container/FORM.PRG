///////////////////////////////////////////////////////////////////////////////
//
//  Vom Xbase++ FormDesigner generierter Klassen Code
//    Erstellt am: 09.11.2011 Zeit: 14:32:11
//
//  Contents  :
//    Diese Datei enthÑlt das GerÅst zur Implementierung der Nutzungsebene.
//    Daher kann und soll diese Datei verÑndert werden.
//
///////////////////////////////////////////////////////////////////////////////

#include "gra.ch"
#include "xbp.ch"
#include "common.ch"
#include "appevent.ch"
#include "font.ch"


******************************************************************************
* Von der Darstellungsklasse abgeleitete Klasse zur Implementierung der
* Programmlogik. Die Instanzvariablen der einzelnen Objekte sind in der
* Klasse _NewForm deklariert.
******************************************************************************
CLASS NewForm FROM _NewForm
   EXPORTED:
      METHOD init
      METHOD create
ENDCLASS

******************************************************************************
* Formular initialisieren
******************************************************************************
METHOD NewForm:init( oParent, oOwner, aPos, aSize, aPP, lVisible )

   * Methode der Superklasse rufen
   ::_NewForm:init( oParent, oOwner, aPos, aSize, aPP, lVisible )

RETURN self


******************************************************************************
* Systemresourcen anfordern
******************************************************************************
METHOD NewForm:create( oParent, oOwner, aPos, aSize, aPP, lVisible )

   * Methode der Superklasse rufen
   ::_NewForm:create( oParent, oOwner, aPos, aSize, aPP, lVisible )


   * Formular anzeigen
   ::show()

RETURN self


******************************************************************************
* Main Prozedur zum Testen des Formulars
******************************************************************************
PROCEDURE Main

   LOCAL nEvent, oXbp, mp1, mp2

   NewForm():New():Create()

   nEvent := xbe_None
   WHILE nEvent != xbeP_Close
      nEvent := AppEvent ( @mp1, @mp2, @oXbp )
      oXbp:HandleEvent ( nEvent, mp1, mp2 )
      IF nEvent == xbeP_Quit
         QUIT   // AppQuit()
      ENDIF
   ENDDO

RETURN

* Programmcode fÅr die Implementierungsebene der Klasse einfÅgen
#include "_FORM.PRG"

//EOF
/////

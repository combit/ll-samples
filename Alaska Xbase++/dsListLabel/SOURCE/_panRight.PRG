//  converted for XClass++ 05/28/2020 /////////////////////////////////////////
//
//  Vom Xbase++ FormDesigner generierter Klassen Code
//    Erstellt am: 28.05.2020 Zeit: 15:02:30
//
//  Contents  :
//    Diese Datei enthÑlt die Implementierungsebene eines Formulares und
//    wird vom Xbase++ FormDesigner automatisch Åberschrieben. Sie sollte
//    niemals editiert werden, da die énderungen verloren gehen kînnten.
//
///////////////////////////////////////////////////////////////////////////////

#ifndef _PANRIGHT_
#define _PANRIGHT_

#include "lldemo.ch"

#PRAGMA LIBRARY( "ascom10.lib" )

CLASS _panRight FROM dsSplitPanel
   EXPORTED:
      VAR editControls

      * Enthaltene Kontrollelemente
      VAR pbDesign
      VAR pbPreview
      VAR sleFolder
      VAR pbExport
      VAR oTabCtrl

      METHOD init
      METHOD create
ENDCLASS

******************************************************************************
* Formular initialisieren
******************************************************************************
METHOD _panRight:init( oParent, oOwner, aPos, aSize, aPP, lVisible )


   DEFAULT oParent  TO AppDesktop(), ;
           aPos     TO {602,367}, ;
           lVisible TO .F.

   DEFAULT aPP TO {}
   AAdd ( aPP, { XBP_PP_COMPOUNDNAME, "8.Arial" } )

   IF Empty(aSize) == .T.
      IF IsMemberVar(self,"ClientSize") == .T.
         aSize := {0,0}
      ELSE
         aSize := {888,470}
      ENDIF
   ENDIF

   ::dsSplitPanel:init( oParent, oOwner, aPos, aSize, aPP, lVisible )
   IF aSize[1] == 0 .AND. aSize[2] == 0
      ::dsSplitPanel:ClientSize := {872,431}
   ENDIF
   ::dsSplitPanel:taskList := .T.
   ::dsSplitPanel:title := "panRight"

   ::editControls := {}

   ::pbDesign  := dsPushButton():new( ::drawingArea, , {16,12}, {148,28}, { { XBP_PP_BGCLR, XBPSYSCLR_BUTTONMIDDLE }, { XBP_PP_FGCLR, -58 } } )
   ::pbDesign:caption := "Show demo"
   ::pbDesign:tabStop := .T.
   ::pbDesign:activate := {|| NIL }

   ::pbPreview := dsPushButton():new( ::drawingArea, , {168,12}, {148,28}, { { XBP_PP_BGCLR, XBPSYSCLR_BUTTONMIDDLE }, { XBP_PP_FGCLR, -58 } } )
   ::pbPreview:caption := "Cancel"
   ::pbPreview:tabStop := .T.
   ::pbPreview:activate := {|| NIL }

   ::sleFolder := dsSLE():new( ::drawingArea, , {12,396}, {788,20}, { { XBP_PP_BGCLR, XBPSYSCLR_ENTRYFIELD }, { XBP_PP_FGCLR, GRA_CLR_DARKBLUE } } )
   ::sleFolder:border := .F.
   ::sleFolder:bufferLength := 60
   ::sleFolder:editable := .F.
   ::sleFolder:tabStop := .T.

   ::pbExport  := dsPushButton():new( ::drawingArea, , {320,12}, {148,28}, { { XBP_PP_BGCLR, XBPSYSCLR_BUTTONMIDDLE }, { XBP_PP_FGCLR, -58 } } )
   ::pbExport:caption := "Cancel"
   ::pbExport:tabStop := .T.
   ::pbExport:activate := {|| NIL }

   ::oTabCtrl  := dsTabControl():new( ::drawingArea, , {12,52}, {844,332}, { { XBP_PP_BGCLR, -255 } } )
   ::oTabCtrl:caption := "Gruppe"
   ::oTabCtrl:clipSiblings := .T.
   ::oTabCtrl:type := XBPSTATIC_TYPE_GROUPBOX

RETURN self


******************************************************************************
* Systemresourcen anfordern
******************************************************************************
METHOD _panRight:create( oParent, oOwner, aPos, aSize, aPP, lVisible )

   ::dsSplitPanel:create( oParent, oOwner, aPos, aSize, aPP, lVisible )

   ::pbDesign:create()

   ::pbPreview:create()

   ::sleFolder:create()

   ::pbExport:create()

   ::oTabCtrl:create()


RETURN self

#endif

//EOF
/////

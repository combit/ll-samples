/*============================================================================
 File Name:	   apputil.prg
 Author:       Marcus Herz
 Description:
 Created:			 08.02.2010     09:32:29        Updated: þ12.03.2010	þ09:22:14
 Copyright:		 2010 by DS-Datasoft, 87654 Friesenried
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"
#pragma library( "ascom10.lib" )

static scKey := ""

/*============================================================================
 $Function:    RestorePos([cSection], [lRegistry])
 $Group:
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    cSection		Ini Default GetUserName() oder Registry-Key Default "software\" + Appname()
 $Argument:    lRegistry	False, Eintrag wird in Appini geschrieben, Default
 									True, Eintrag wird in Registry geschrieben
 $Return:      true, wenn gesetzt
 $See Also:
 $Example:
==============================================================================*/
FUNC RestorePos(cSection, lRegistry)
	local oApp		:= GetApp()
	LOCAL cValue
   LOCAL aVal, aMin, aPos, aSize, aAppSize

	if !empty(lRegistry)
   	cValue	:= ReadRegistry(,cSection, "POSITION" )
		DEFAULT cValue TO ""
	else
		DEFAULT cSection TO GetUserName()
		cValue	:= AppIni():Getentry( cSection, "POSITION", "", "C" )
	endif

	if !empty( cValue)
		aVal	:= aStrExtract(cValue, ",")
      aeval(aVal, {|u| u:=val(u)},,, True )

		asize(aVal, 6)
      if !empty(aVal[6]) .and. IsObject(oApp) .and. IsMembervar(oApp, "ChildMaximized")
			oApp:ChildMaximized	:= true
		endif

      if !empty(aVal[5] )
			oApp:SetFramestate(XBPDLG_FRAMESTAT_MAXIMIZED)
			RETURN true

      else
         aPos  := {aVal[1], aVal[2]}
         aSize := {aVal[3], aVal[4]}
         aMin  := oApp:minSize

         if IsArray(aMin)
            iif(aSize[1] < aMin[1], aSize[1] := aMin[1],)
            iif(aSize[2] < aMin[2], aSize[2] := aMin[2],)
         endif

			if aSize[2] < 50
            RETURN False
         endif
			aAppSize	:= AppDesktop():currentSize()
         if aSize[2] > aAppSize[2]
            aSize[2] := aAppSize[2]
            aPos[2]  := 0
         endif

         if aPos[1]+aSize[1] < 0
            aPos[1] := 0
         endif
         if aPos[2]+aSize[2] > aAppSize[2]
            aPos[2] := aAppSize[2]-aSize[2]
         endif

         if aPos[2]+aSize[2] < 0
            aPos[2] := 0
         endif

         iif(aPos[2] > aAppSize[2]-aSize[2], aPos[2] := aAppSize[2]-aSize[2],)

         oApp:setposandsize(aPos, aSize)

         RETURN True
		endif
	endif
RETURN false

/*============================================================================
 $Function:    SavePos([cSection], [lRegistry])
 $Group:
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    cSection		Ini Default dsGetUserName() oder Registry-Key Default "software\" + Appname()
 $Argument:    lRegistry	False, Eintrag wird in Appini geschrieben, Default
 									True, Eintrag wird in Registry geschrieben
 $Return:      NIL
 $See Also:
 $Example:
==============================================================================*/
FUNC SavePos(cSection, lRegistry)
	LOCAL aPos, aSize
	LOCAL cValue
	LOCAL i
	local oIni, oReg
	local oApp	:= GetApp()

	DEFAULT lRegistry TO false

	if lRegistry
		if empty(cSection)
			if !empty(scKey)
				cSection	:= scKey
			else
				cSection	:= "Software\"+ subs(AppName(),1, len(AppName()) -4 )
			endif
		endif
		oReg := dsRegistry():new(HKEY_CURRENT_USER)
	else
		DEFAULT cSection TO GetUserName()
		oIni	:= AppIni()
	endif

	if oApp:GetFrameState() == XBPDLG_FRAMESTAT_MAXIMIZED
		if lRegistry
   		cValue	:= oReg:GetValue(cSection, "POSITION")
			DEFAULT cValue TO ""
		else
			cValue	:= oIni:Getentry( GetUserName(), "POSITION", "", "C" )
		endif
		if (i := At( cValue, ",",4 )) > 0
			cValue := subs( cValue, 1, i) + "1"
		else
			cValue	:= ",,,,1"
		endif

   elseif oApp:GetFrameState() == XBPDLG_FRAMESTAT_MINIMIZED
      RETURN NIL

	else
		aPos	:= getApp():currentpos()
		aSize	:= getApp():currentSize()
      if aPos[1]+aSize[1] < 0 .or. aPos[2]+aSize[2] < 0
         RETURN NIL
      endif
		cValue	:= ntrim( aPos[1])+","+ntrim( aPos[2])+","+ntrim( aSize[1])+","+ntrim( aSize[2])+",0"
	endif
	cValue	+= if( IsObject(oApp) .and. IsMembervar(oApp, "ChildMaximized") .and. oApp:ChildMaximized, ",1", ",0" )

	if lRegistry
   	oReg:CreateKey(cSection)
   	oReg:SetValue(cSection, "POSITION", REG_SZ, cValue)
		oReg:destroy()
	else
		oIni:Writeentry( cSection, "POSITION", cValue )
	endif
RETURN NIL

//=========================================
FUNC DialogPos(oDlg, oParent)
	LOCAL aSize, aPSize

	if oDlg:GetFrameState() = XBPDLG_FRAMESTAT_MAXIMIZED .or. ;
			GetApp():IsChildMaximized()
		// nothing to do
	else
		if oDlg:GetModalState() = XBP_DISP_APPMODAL
			aPSize	:= GetApp():currentSize()

		elseif IsObject( oParent)
			aPSize	:= oParent:currentSize()

		else
			aPSize	:= GetApp():drawingarea:currentSize()
		endif
		aSize	:= oDlg:currentsize()
		if aSize[1] > aPSize[1]
			aSize[1]	:= aPSize[1]
		endif
		if aSize[2] > aPSize[2]
			aSize[2]	:= aPSize[2]
		endif
	endif
RETURN NIL

/*============================================================================
 $Function:    DefaultRegistryKey( cKey)
 $Group:
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    cKey
 $Return:      scKey
 $See Also:
 $Example:
	DefaultRegistryKey( "Software\BSA")

==============================================================================*/
FUNC DefaultRegistryKey( cKey)
	if IsCharacter(cKey)
		scKey	:= cKey
	endif
RETURN scKey

/*============================================================================
 $Function:    WriteRegistry([hKey], [cKey], cSubkey, xValue, [hType] )
 $Group:
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    hKey			Default: HKEY_CURRENT_USER
 $Argument:    cKey			Default: "Software\"+ subs(AppName(),1, len(AppName()) -4 )
									das Makro "%DEFAULT%" wird durch "Software\"+ subs(AppName(),1, len(AppName()) -4 ) ersetzt
 $Argument:    cSubkey     Schlüssel
 $Argument:    xValue		Wert, mögliche Typen C M N D L A
									REG_SZ				String, dtos(date)
									REG_DWORD			numerisch, logisch false = 0, true = 1
									REG_BINARY			string, mit 0-byte
									REG_MULTI_SZ		sichern von Arrays, jeder Datentyp
									REG_EXPAND_SZ		Environment Variablen auflösen
 $Argument:    hType			Default: REG_SZ, bei xValue Numerisch/logisch REG_DWORD, bei Array REG_MULTI_SZ
 $Return:      ERROR_SUCCESS (0) wenn erfolgreich
 $See Also:    ReadRegistry
 $Example:
 WriteRegistry(, "Software\"+ subs(AppName(),1, len(AppName()) -4 ), "SIZE", "300x500" )

 WriteRegistry(,, "SIZE", "300x500" )
 cVal	:= ReadRegistry(,, "SIZE" )

 WriteRegistry(,, "ID", 4711, REG_DWORD )
 nId	:= ReadRegistry(,, "ID" )

 // Sichern einer Fensterposition:
 WriteRegistry(,,"%DEFAULT%\dlgWE\Pos",::currentpos(), REG_MULTI_SZ)
 WriteRegistry(,,"%DEFAULT%\dlgWE\Size",::currentsize(), REG_MULTI_SZ)

 // Restore einer Fensterposition:
 ::_dlgWe:create()
 ::SetPosandsize(ReadRegistry(,,"%DEFAULT%\dlgWE\Pos", "N" ),ReadRegistry(,,"%DEFAULT%\dlgWE\Size", "N" ))

==============================================================================*/
FUNC WriteRegistry(hKey, cKey, cSubkey, xValue, hType)
	LOCAL oReg
	LOCAL nError
	LOCAL cTmp

	if hKey == NIL
		hKey	:= HKEY_CURRENT_USER
	endif
	if valtype(xValue) = "D"
		xValue	:= dtos(xValue)
	elseif valtype(xValue) = "L"
		xValue	:= if(xValue, 1, 0)
	elseif xValue = NIL
		xValue	:= ""
	endif

	if hType == NIL
		if IsNumber( xValue ) .or. IsLogical( xValue )
			hType	:= REG_DWORD
		elseif IsArray( xValue )
			hType	:= REG_MULTI_SZ
		else
			hType	:= REG_SZ
		endif
	endif
	if !empty(scKey)
		cTmp	:= scKey
	else
		cTmp	:= "Software\"+ subs(AppName(),1, len(AppName()) -4 )
	endif

	if empty(cKey)
		cKey	:= cTmp
	else
		cKey	:= strtran(cKey, "%DEFAULT%", cTmp )
	endif
	oReg := dsRegistry():new(hKey)
   oReg:CreateKey(cKey)
   nError	:= oReg:SetValue(cKey, cSubKey, hType, xValue)
	oReg:destroy()
RETURN nError

/*============================================================================
 $Function:    ReadRegistry([hKey], [cKey], cSubkey, [cType] )
 $Function:    ReadRegistry([hKey], [cKey], cSubkey, [l2Numeric] )
 $Group:
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    hKey			Default: HKEY_CURRENT_USER
 $Argument:    cKey			Default: "Software\"+ subs(AppName(),1, len(AppName()) -4 )
 $Argument:    cSubkey     Schlüssel
 $Argument:    cType			Rückgabe Datentyp, für Date und Logisch und numerisch Arrays
 $Argument:    l2Numeric	in Zusammenspiel mit REG_MULTI_SZ, Array Elemente werden nach numerisch konvertiert
 $Return:      xRet			Wert, Typ abhängig von Art des Schlüssels, siehe WriteRegistry
 $See Also:    WriteRegistry
 $Example:
 	siehe WriteRegistry
==============================================================================*/
FUNC ReadRegistry(hKey, cKey, cSubkey, cType, xDefault )
	LOCAL oReg
	LOCAL xRet
	LOCAL cTmp

	if hKey == NIL
		hKey	:= HKEY_CURRENT_USER
	endif

	if !empty(scKey)
		cTmp	:= scKey
	else
		cTmp	:= "Software\"+ subs(AppName(),1, len(AppName()) -4 )
	endif

	if cKey == NIL
		cKey	:= cTmp
	else
		cKey	:= strtran(cKey, "%DEFAULT%", cTmp )
	endif

	oReg	:= dsRegistry():new(hKey)
  	xRet	:= oReg:GetValue(cKey, cSubKey, true , , cType )

	if oReg:Status() = ERROR_FILE_NOT_FOUND .and. xDefault != NIL
		xRet	:= xDefault
	endif
	oReg:destroy()

RETURN xRet


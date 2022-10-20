/*============================================================================
 File Name:	   pgOCX.prg
 Author:       Marcus Herz
 Description:
 Created:		08.08.2022     10:25:30        Updated: þ08.08.2022      þ10:25:30
 Copyright:		2022 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

#define TLBS_PRV_HIDE	-1

//=========================================
CLASS pgOCX FROM dsTabPage
	HIDDEN:
	PROTECTED:
	EXPORTED:
		VAR ocxLL
		METHOD Create
		METHOD Open
ENDCLASS

//=========================================
METHOD pgOCX:Create()
	LOCAL bErr
	LOCAL oToolbar
	LOCAL lInstalled	:= FALSE

	// DEMO CODE starts here
	bErr	:= Errorblock({|| break()})
	begin sequence
		::ocxLL	:= dsActiveXControl():new( ::drawingArea,,{10,10},{800,500})
		if IsObject(::ocxLL)
			::ocxLL	:clsID := "cmll28v.LLViewCtrl"
			::ocxLL	:enableresize	:= TRUE
			lInstalled	:= TRUE
		else
			break
		endif
	recover
		Errorbox("List & Label Anzeige Control nicht installiert")
	end sequence

	::dsTabPage:create()
	if lInstalled
		begin sequence
			::ocxLL:create()
			::ocxLL	:ShowThumbnails	:= FALSE
			// D:  einige Toolbar Buttons disablen, IDs stehen in MENUID.TXT
			// US: disable some toolbar buttons, see MENUID.TXT for IDs
			oToolbar	:= ::ocxLL:ToolbarButtons()
			oToolbar	:SetButtonState( 114, TLBS_PRV_HIDE )                                // close preview
			oToolbar	:SetButtonState( 115, TLBS_PRV_HIDE )                                // Senden an / send to
			oToolbar	:SetButtonState( 116, TLBS_PRV_HIDE )                                // Speichern als / save as
			oToolbar	:SetButtonState( 118, TLBS_PRV_HIDE )                                // suchen/ seek
			oToolbar	:SetButtonState( 119, TLBS_PRV_HIDE )                                // suchen/ seek
			oToolbar	:SetButtonState( 121, TLBS_PRV_HIDE )                                // suchen/ seek
			oToolbar	:SetButtonState( 122, TLBS_PRV_HIDE )                                // suchen/ seek
			oToolbar	:SetButtonState( 126, TLBS_PRV_HIDE )                                // präsentation
		end sequence
	endif
	Errorblock(bErr)

RETURN self

//=========================================
METHOD pgOCX:Open(cFile)
	::ocxLL:FileURL	:= cFile
RETURN self

/*============================================================================
 File Name:	   pgHtmlViewer2.prg
 Author:       Marcus Herz
 Description:
 Created:		08.08.2022     10:25:30        Updated: þ18.08.2025      þ10:00:19
 Copyright:		 2026 DS-Datasoft
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"
#include "xbp.ch"

//=========================================
CLASS pgHtmlViewer2 FROM dsTabPage
	HIDDEN:
	PROTECTED:
	EXPORTED:
		VAR oHtmlViewer2
		METHOD Create
		METHOD Open
ENDCLASS

//=========================================
METHOD pgHtmlViewer2:Create()
	LOCAL bErr
	LOCAL lInstalled	:= FALSE
	LOCAL aSize

	bErr	:= Errorblock({|| break()})
	begin sequence
		::oHtmlViewer2	:= dsHTMLViewer2():new( ::drawingArea)
		if IsObject(::oHtmlViewer2)
			::oHtmlViewer2	:enableresize	:= TRUE
			lInstalled		:= TRUE
		else
			::oHtmlViewer2	:= NIL
			break
		endif
	end sequence

	::dsTabPage:create()
   aSize			:= ::currentsize()
	if lInstalled
		begin sequence
			::oHtmlViewer2:create(,, {10,10}, {aSize[1] -20, aSize[2] -20})
		end sequence
	endif
	Errorblock(bErr)

RETURN self

//=========================================
METHOD pgHtmlViewer2:Open(cFile)
	if IsObject(::oHtmlViewer2)
		::oHtmlViewer2:navigate(cFile)
	endif
RETURN self

/*============================================================================
 $Class:         dsHTMLViewer2
 $Group:
 $Description:   Anpassung des xbpHtmlViewer2 an die XClass++ Umgebung.
 $Parentclass:   xbpHtmlViewer
 $Subclass:
 $See Also:
==============================================================================*/
CLASS dsHTMLViewer2 FROM xbpHTMLViewer2, dsParent, dsTooltip, dsEdit
	EXPORTED:
		VAR aCargo

		INLINE METHOD Init(oParent, oOwner, aPos, aSize, aPP, lVisible)
			::xbpHTMLViewer2:Init(oParent, oOwner, aPos, aSize, aPP, lVisible)
			::dsParent:Init(oParent, oOwner)
   		::dsTooltip:init()
			::dsEdit:Init()
			::lClipperKey := FALSE
			RETURN self

		INLINE METHOD Create(oParent, oOwner, aPos, aSize, aPP, lVisible)
			::xbpHTMLViewer2:Create(oParent, oOwner, aPos, aSize, aPP, lVisible)
			::dsParent:create(oParent, oOwner)
			::dsEdit:Create()
			RETURN self

		INLINE METHOD Destroy()
			::xbpHTMLViewer2:Destroy()
			::dsParent:Destroy()
			::dsEdit:Destroy()
			RETURN self

ENDCLASS


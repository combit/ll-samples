/*============================================================================
 File Name:	   panRight.PRG
 Author:       Marcus Herz
 Description:
 Created:			 28.05.2020     15:15:52        Updated: þ28.05.2020      þ15:15:52
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"
#include "fileio.ch"
#include "appevent.ch"

******************************************************************************
* Von der Darstellungsklasse abgeleitete Klasse zur Implementierung der
* Programmlogik. Die Instanzvariablen der einzelnen Objekte sind in der
* Klasse _panRight deklariert.
******************************************************************************
CLASS panRight FROM _panRight
   EXPORTED:
      METHOD create
		METHOD StartPrint(lExport,lDesign)
		METHOD ReadData

		INLINE ACCESS ASSIGN METHOD TabControl		;RETURN ::oTabCtrl
ENDCLASS

******************************************************************************
* Systemresourcen anfordern
******************************************************************************
METHOD panRight:create()
	LOCAL oPage

	::sleFolder	:datalink := {|| ::Server:APP}
	::sleFolder	:setResizeMode(TOP_LEFT, SIZE_WIDTH )
	::sleFolder	:EditAble := False

	::pbDesign	:activate	:= {|| ::StartPrint(,true, ::SplitControl:server:folder)}
	::pbPreview	:activate	:= {|| ::StartPrint(,, ::SplitControl:server:folder)}
	::pbExport	:activate	:= {|| ::StartPrint(LL_PRINT_EXPORT,, ::SplitControl:server:folder)}

	::pbDesign	:caption	:= "Design"
	::pbPreview	:caption	:= "Preview"
	::pbExport	:caption	:= "Export"

	oPage := pgDescrption():new(::oTabCtrl)
	oPage:Caption	:= "Description"
	oPage:PageId   := 100
	oPage:connect(::SplitControl:server)
	::oTabCtrl:AddPage(oPage)

	oPage := pgCode():new(::oTabCtrl)
	oPage:Caption	:= "Code"
	oPage:PageId   := 200
	oPage:connect(::SplitControl:server)
	::oTabCtrl:AddPage(oPage)

	::oTabCtrl:enableResize := True

   ::_panRight:create()
RETURN self

//=========================================
METHOD panRight:ReadData()
	::oTabCtrl:activePage:ReadData()
	::_panRight:readData()
	if ::Server:MODUS = "G"
		::pbDesign	:disable()
		::pbPreview	:disable()
		::pbExport	:disable()
	else
		::pbDesign	:enable()
		::pbPreview	:enable()
		::pbExport	:enable()
	endif
RETURN self

//=========================================
METHOD panRight:StartPrint(nExport,lDesign, cFolder)
	LOCAL cPrg	:= alltrim(::Server:APP)

	cPrg	:= left(cPrg, at(".", cPrg)-1)

	if Isfunction(cPrg)
		&(cPrg)(nExport,lDesign, Fullpath(cFolder))
	else
		InfoBox("Modul not implemented")
	endif

RETURN self

//=========================================
CLASS pgDescrption FROM dsTabPage
	HIDDEN:
	PROTECTED:
	EXPORTED:
		VAR oMle
		METHOD Create
ENDCLASS

//=========================================
METHOD pgDescrption:Create()

	::oMle	:= dsMle():new(::drawingarea,,{3,3},{500,200})
	::oMle:datalink		:= {|x|if(x==NIL, ::Server:fieldget(if(GetLanguage() == SET_GERMAN, "DE", "US" ) +"_COMMENT"), ::Server:fieldput(if(GetLanguage() == SET_GERMAN, "DE", "US" ) +"_COMMENT",x))}
	::oMle:editable		:= dsGetUsername() = "mh"
	::oMle:enableResize	:= True
	::oMle:horizScroll	:= False
	::oMle:wordWrap		:= True
	::oMle:writeblock		:= {|| ::Server:rlock(), ::oMle:GetData(), ::Server:unlock()}
	::oMle:setColorBG(GraMakeRGBColor({255,255,196}))

	::dsTabPage:Create()
	::oMle:create()
RETURN self

//=========================================
CLASS pgCode FROM dsTabPage
	HIDDEN:
	PROTECTED:
	EXPORTED:
		VAR oMle
		METHOD Create
		METHOD ReadData
ENDCLASS

//=========================================
METHOD pgCode:Create()

	::oMle	:= dsMle():new(::drawingarea,,{3,3},{500,200})
	::oMle:editable		:= false
	::oMle:enableResize	:= True
	::oMle:wordWrap		:= false
	::oMle:setColorBG(GraMakeRGBColor({255,255,196}))
	::oMle:setfontcompoundname("12.Consolas")

	::dsTabPage:Create()
	::oMle:create()
RETURN self

//=========================================
METHOD pgCode:ReadData()
	LOCAL cPrg
	LOCAL nLen
	LOCAL hHandle  := FOpen(getappdir() +"source\"+ alltrim(::Server:app), FO_READ )

	nLen	:= FSeek(hHandle, 0, FS_END )
	FSeek(hHandle, 0, FS_SET )
	cPrg  := FreadStr(hHandle, nLen )
	fclose(hHandle)
	cPrg	:= strtran(cPrg, chr(9), space(3))

	::oMle:setdata(cPrg)
	nLen	:= at("// DEMO CODE", cPrg )
	nLen	+= at(chr(10), subs( cPrg, nLen ))

	::oMle:setFirstChar(++nLen)

RETURN self



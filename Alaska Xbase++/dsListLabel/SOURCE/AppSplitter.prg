/*============================================================================
 File Name:    dlgsplitterVT.prg
 Description:
 Created:      06.02.2006     20:53:18        Updated: þ06.02.2006    þ20:53:18
 Copyright:    2006 by DS-Datasoft GmbH&Co.KG, 87654 Friesenried
 Revision:
============================================================================*/

#include "lldemo.ch"
#include "appevent.ch"

//=========================================
CLASS AppSplitter FROM dsApp
	HIDDEN:
	PROTECTED:
	EXPORTED:
		VAR oBrowse
		VAR cLang
		VAR oSplitCtrl
		METHOD Create
		METHOD EditDescription()
		METHOD Init
		METHOD Show()

		INLINE METHOD Refresh
			::cLang	:= if(GetLanguage() == SET_GERMAN, "DE", "US" )
			::oBrowse:ForceRefresh()
			::oSplitCtrl:setrightpanel():ReadData()
			RETURN self
ENDCLASS

//=========================================
METHOD AppSplitter:Init(oParent, oOwner, aPos, aSize, aPP)
	UNUSED (oParent)
	UNUSED (oOwner)
	::dsApp:init(aPos, aSize, aPP, DS_APP_MDI)
RETURN self

//=========================================
METHOD AppSplitter:Create()
	LOCAL dbSamples
	LOCAL panLeft, panRight
	LOCAL nWidth

	::dsApp:create()

	::cLang	:= if(GetLanguage() == SET_GERMAN, "DE", "US" )

	dbSamples := OpenDbTable("Samples")

	// main SplitControl1
	::oSplitCtrl := dsSplitControl():new(GetApp():drawingArea, TRUE,,,, FALSE)
	::oSplitCtrl:SplitLine:setColorBG( GraMakeRGBColor({176,216,255}) )
	::oSplitCtrl:create()
	::oSplitCtrl:connect(dbSamples, TRUE )

   //*** left panel
	panLeft  := dsSplitPanel():new(::oSplitCtrl)
	panLeft:enableCollapse := FALSE

	panRight := panRight():new(::oSplitCtrl) //,,,, {{ XBP_PP_BGCLR, XBPSYSCLR_DIALOGBACKGROUND}})

	::oBrowse := dsXBrowse():new( panLeft, , {5,5}, {396,416} )
	::oBrowse:connect(dbSamples)
	::oBrowse:AddFont(1, SetDefaultBrowseFont())
	::oBrowse:AddFont(10, "10.Arial italic bold")
	::oBrowse:stableBlock	:= {|| panRight:readData()}
	::oBrowse:colorBlock		:= {|oB| if(oB:Server:MODUS = "G", {GRA_CLR_DARKBLUE, GraMakeRGBColor({255,255,196}), GRA_CLR_BLUE, GRA_CLR_YELLOW},)}
	::oBrowse:fontBlock		:= {|oB| if(oB:Server:MODUS = "G", 10, 1)}

	::oBrowse:addColumnDB({{, {|x| dbSamples:fieldget(::cLang +"_SAMPLE")}}})

	panLeft:create()
	::oBrowse:create()

	panRight:enableCollapse := FALSE
	panRight:enableResize	:= TRUE
	panRight:connect(dbSamples)
	panRight:create()

	::oSplitCtrl:SetPanel(panLeft, panRight)

	nWidth	:= ReadRegistry(,, "SPLIT", "N", 497 )
	::oSplitCtrl:setpanelsize(nWidth)
	GetApp():AddDestroyblock(, {|| WriteRegistry(,, "SPLIT", ::oSplitCtrl:setpanelsize())})

	::RegisterHotkey(xbeK_F2	,{|| ::EditDescription()})
	::RegisterHotkey(xbeK_ESC	,{|| ::EditDescription(TRUE)})
RETURN self

//=========================================
METHOD AppSplitter:Show()
	::dsApp:show()
	::oSplitCtrl:show()
RETURN self

//=========================================
METHOD AppSplitter:EditDescription(lCancel)
	if ::oSplitCtrl:getrightpanel():TabControl:getActivePage():PageId == 100
		if IsLogic(lCancel) .and. lCancel
			::oSplitCtrl:getrightpanel():TabControl:getActivePage():oMle:enableedit(FALSE)

		elseif ::oSplitCtrl:getrightpanel():TabControl:getActivePage():oMle:editable
			eval(::oSplitCtrl:getrightpanel():TabControl:getActivePage():oMle:writeblock())
		else
			::oSplitCtrl:getrightpanel():TabControl:getActivePage():oMle:enableedit(TRUE)
		endif
	endif
RETURN self

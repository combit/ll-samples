/*============================================================================


 File Name:	   main.prg
 Author:       Marcus Herz
 Description:
 Created:			 28.05.2020     12:49:25        Updated: þ28.05.2020      þ12:49:25
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"
#include "dsListLabel.ch"
#include "Nls.ch"

//=========================================
PROC Main()
	LOCAL oApp, oIni
	LOCAL aLang
	LOCAL cPath	:= AppName(.t.)

	cPath	:= subs(cPath, 1, rat("\", cPath))

	oIni	:= dsIniFile():New(cPath + "lldemo.ini")
	oIni:Read()

	cPath	+= "data"

	SET(_SET_CHARSET	,CHARSET_ANSI)
	SET(_SET_DATEFORMAT,"" )
	SET(_SET_DELETED	,FALSE )
	SET(_SET_PATH		,cPath )
	SET(_SET_DEFAULT	,cPath )

	_CheckIndex(cPath)

	// D: settings für LLDemo
	// US: settings for LLDemo
	DefaultRegistrykey("Software\LLDemo")

	IF !empty(oIni:GetEntry("LLDEMO", "language"))
		SetLanguage(oIni:GetEntry("LLDEMO", "language",,"N"))
	ELSE
		aLang	:= ReadRegistry(,"Control Panel\Desktop", "PreferredUILanguages" )
		IF IsArray(aLang)
			SetLanguage(if(aLang[1] = "de", SET_GERMAN, SET_AMERICAN ))
		ELSE
			IF SetLocale(NLS_ICOUNTRY) $ {"49", "44", "43"}
				SetLanguage(SET_GERMAN)
			ELSE
				SetLanguage(SET_AMERICAN)
			ENDIF
		ENDIF
	ENDIF

   SetDefaultBrowseFont("11.Arial")
   SetDefaultTextFont("11.Arial")
   SetDefaultEditFont("11.Arial")
   SetDefaultButtonFont("11.Arial")
   SetDefaultMessageFont("11.Arial")
   SetDefaultTabriderFont("11.Arial")
   SetDefaultMleFont("12.Arial")
   SetAutoAccelerator( FALSE )
   EnableFocusFrame( FALSE )
	EnableTooltip(TRUE)

	dsBaseProperty();
		:SetInitProperty("XBROWSE"			,"enableResize"			,true);
		:SetInitProperty("XBROWSE"			,"WheelSkip"				,1 );
		:SetInitProperty("XBROWSE"			,"setColorBG"				,GRA_CLR_WHITE)

	// D: Designer Preview aktivieren
	// US: activate Designer Preview
	dsListLabel():DefaultDesignerPreview(.t.)

	// D: Ist List & Label installiert
	// US: Chekc wether List & Label is installed
	IF !dsListLabel():ModulInstalled()
		ConfirmBox(SetAppWindow(),"Error loading CMLL"+ ntrim(dsListLabel():version()) +".DLL!."+chr(13)+;
			"OS error#"+Alltrim(Str(DosError()))+Chr(13)+;                             //
			DosErrorMessage(DosError())+chr(13),;
			"L&L DLL loading error",;
			XBPMB_OK ,XBPMB_CRITICAL+XBPMB_APPMODAL+XBPMB_MOVEABLE )
		RETURN
	ENDIF
	dsListLabel():DefaultBoxType(LL_BOXTYPE_NONE)

	// D: Hier wird Ihr persoenlicher Lizenzinfostring eingetragen - siehe perslic.txt
	// US: Enter your licensing info string here - see perslic.txt
/*	dsListLabel():LicensingInfo(hJob, LL_OPTIONSTR_LICENSINGINFO, "<Personal License Key>"...) */

	IF !empty(oIni:getentry("combit", "LicensingInfo"))
		dsListLabel():LicensingInfo(oIni:getentry("combit", "LicensingInfo"))
	ENDIF

   oApp	:= AppSplitter():New(,,,{1200,800})
   oApp:FrameClientArea := FALSE

	oApp:Title := "dsListLabel"
   oApp:icon  := ICON_APPLICATION
	oApp:create()

   GetApp(oApp)

	oApp:CreateToolbar()
	oApp:Toolbar:ButtonSize := {28, 28}
	oApp:Toolbar:AddItem(101, BMP_GERMANY	,{|| _SwitchLanguage(SET_GERMAN)})
	oApp:Toolbar:AddItem(102, BMP_USA		,{|| _SwitchLanguage(SET_AMERICAN)})
	oApp:Toolbar:AddItem(103, BMP_HELP		,{|| _StartHelp()})
	RestorePos(, true )

   // start application´s main event loop
   oApp:Show()

   AppExec()

	SavePos(, TRUE )

	oIni	:WriteEntry("LLDEMO", "language", GetLanguage())
	oIni	:destroy()

	CLOSE ALL
	QUIT

RETURN

//=========================================
PROC dbeSys()	;dsDbeSys("FOXCDX")	;RETURN
PROC AppSys() 								;RETURN

//=========================================
STATIC PROCEDURE _CheckIndex(cPath)
	// D: Tabellen & Relation hinzufügen
	// US: Add tables & relations
	IF !file(cPath +"\ITEMS.CDX")
		DbUseArea(.T., , "Items", .f.)
   	INDEX ON field->BILLNO 		TAG BILLNO TO ITEMS
   	INDEX ON field->ARTICLENO 	TAG ARTICLENO TO ITEMS
		dbclosearea()
	ENDIF

	IF !file(cPath +"\INVOICE.CDX")
		DbUseArea(.T., , "Invoice", .f.)
   	INDEX ON field->BILLNO 		TAG BILLNO TO INVOICE
		dbclosearea()
	ENDIF

	IF !file(cPath +"\ARTICLE.CDX")
		DbUseArea(.T., , "Article", .f.)
   	INDEX ON field->ARTICLENO 	TAG ARTICLENO TO ARTICLE
		dbclosearea()
	ENDIF

	IF !file(cPath +"\Samples.CDX")
		DbUseArea(.T., , "Samples", .f.)
   	INDEX ON field->POS 	TAG POS TO Samples
		dbclosearea()
	ENDIF

RETURN

//=========================================
FUNC CatchCallback(nEvent,nId,oListLabel)
	UNUSED (oListLabel)
	// D: in der Vorschau wurde ein Toolbar Icon geklickt
	// US: preview click in toolbar
	IF nEvent = LL_NTFY_VIEWERBTNCLICKED
		IF nId = MNUID_LL_PRINT .or. nId = MNUID_LL_PRINT_RM
			msgBox("Document is printed")

		ELSEIF nId = MNUID_LL_SEND_TO
			msgBox("Document is send to")

		ELSEIF nId = MNUID_LL_SAVE_AS
			msgBox("Document is saved")
		ENDIF
	ENDIF
RETURN 0

//=========================================
STATIC FUNC _SwitchLanguage(nLanguage)
	SetLanguage( nLanguage )
	GetApp():Toolbar:ItemSwitchMode(101, if(nLanguage = SET_GERMAN, BUTTON_SWITCH_ON ,BUTTON_SWITCH_OFF ))
	GetApp():Toolbar:ItemSwitchMode(102, if(nLanguage = SET_AMERICAN, BUTTON_SWITCH_ON ,BUTTON_SWITCH_OFF ))
	GetApp():Refresh()
RETURN NIL

//=========================================
STATIC FUNC _StartHelp()
	IF GetLanguage() = SET_GERMAN
		runshell('/C start "" "'+fullpath(".\HELP\DEUTSCH\dsListLabel.CHM",, .f.)+'"')
	ELSE
		runshell('/C start "" "'+fullpath(".\HELP\ENGLISH\dsListLabel.CHM",, .f.)+'"')
	ENDIF
RETURN NIL

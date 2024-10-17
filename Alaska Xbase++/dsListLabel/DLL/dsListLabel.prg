/*============================================================================
 File Name:	   dsListLabel.prg
 Author:	 		Marcus Herz
 Description:
 Created:		19.08.2016     13:33:08	  Updated: þ14.11.2022	þ13:33:35
 Copyright:		2016 by DS-Datasoft
 Revision:

 Remark: Set Tab to 3 blanks

 Any List&Label Version can be used by defining
 /D__LL=30
 /D__LL=<version number>
 in the COMPILE_FLAGS in XPJ

============================================================================*/
#include "dsListLabel.ch"
#include "dll.ch"
#include "xbp.ch"
#include "common.ch"
#include "class.ch"
#include "fileio.ch"
#include "WINSDK-WINUSER.CH"


// WIN API DEVMODE
#define CCHFORMNAME			32

#command INSTANCE <variablename> AS STRUCTURE <structurename> => <variablename> := <structurename>_xpp_structure():new()

#if XPPVER < 2001392
	#error This DLL needs Xbase++ Version 2.0 or higher
#endif	// XPPVER < 2001392

STATIC snJobId	:= 0


EXTERN LONG GetComputerName(@cBuffer as STRING, @nBin AS LONG) 			IN KERNEL32.DLL
EXTERN LONG GetUserName( @cBuffer as STRING, @nBuflen AS LONG)  			IN ADVAPI32.DLL
EXTERN INTEGER GetTempPath( len AS UINTEGER, @buffer AS STRING )			IN KERNEL32.DLL
EXTERN LONG SetEvent(hEvent AS UINTEGER)											IN KERNEL32.DLL
EXTERN INTEGER GetTempFileName(;
	lpPathName as STRING,;
	lpPrefixString  as STRING,;
	uUnique AS INTEGER,;
	@lpTempFileName as STRING) IN KERNEL32.DLL

EXTERN UINTEGER LocalAlloc(;
	uFlags   AS UINTEGER,;
	uBytes   AS UINTEGER) in Kernel32.DLL

EXTERN UINTEGER LocalFree(;
	uBytes   AS UINTEGER) in Kernel32.DLL


// DLL specific
#translate ntrim(<n>)	=> alltrim(str(<n>))
#ifndef DEBUGOUT
	#translate debugout(<n,.n.>)	=>
#endif  // DEBUGOUT

// ::_dbFields[]
// ::_dbVariables[]
#define __SELECT		1
#define __SYMBOL		2
#define __LLDESC		3
#define __STRUCT		4
#define __ALIAS		5
#define __LEVEL		6

#define _SKIPBLOCK	{|o, c| if(empty(c),    ,if(IsObject(c), c:skip(),  (c)->(dbskip()))	)}
#define _TOPBLOCK		{|o, c| if(empty(c),    ,if(IsObject(c), c:gotop(), (c)->(dbgotop())))}
#define _EOFBLOCK		{|o, c| if(empty(c),TRUE,if(IsObject(c), c:eof(),   (c)->(eof()))		)}
#define _RECNOBLOCK	{|o, c| if(empty(c),   0,if(IsObject(c), c:recno(), (c)->(recno()))	)}
#define _TAB			chr(9)


//=========================================
EXIT Procedure dsListLabelStop
	LOCAL bErr	:= Errorblock({||break()})
	BEGIN SEQUENCE
		LLModuleExit()
	END SEQUENCE
	Errorblock(bErr)
RETURN

/*============================================================================
 $Class:	  dsListLabel
 $Group:
 $Author:	 Marcus Herz, DS-Datasoft
 $Description:
 $Subclass:
 $See Also:
 $Example:
==============================================================================*/
CLASS dsListLabel FROM DbContainer
HIDDEN:
   VAR _DataObject                                             // zur freine Verfügung, for free use


PROTECTED:
	CLASS VAR __aDefaultPath			SHARED							// paths to search reports
	CLASS VAR __aDefaultVar				SHARED							// LlDefineVariable
	CLASS VAR __aRights					SHARED							// rights
	CLASS VAR __bConfig					SHARED							// user callback after LLPrint[withBox]Start
	CLASS VAR __bPrepare					SHARED							// user callback before LLPrint[withBox]Start
	CLASS VAR __cEmailProvider			SHARED							// Emailprovider
	CLASS VAR __cExportFormat			SHARED							// possible exports
	CLASS VAR __cExportPath				SHARED							// possible exports
	CLASS VAR __cIgnoreField			SHARED							// mask to ignore field
	CLASS VAR __cLicence					SHARED							// your licence
	CLASS VAR __cPrinter					SHARED							//
	CLASS VAR __cPrintText				SHARED							// progrss bar
	CLASS VAR __cSmtpIPAddress			SHARED							// Email Versand
	CLASS VAR __cSmtpPassword			SHARED							// Email Versand
	CLASS VAR __cSmtpSenderAddress	SHARED							// Email Versand
	CLASS VAR __cSmtpSenderName   	SHARED							// Email Versand
	CLASS VAR __cSmtpUser				SHARED							// Email Versand
	CLASS VAR __cTempPath				SHARED							// Tmp path
	CLASS VAR __lDesignerPreview  	SHARED							// enable real data preview
	CLASS VAR __lUseDbRequest			SHARED							// wenn mit Tabellenobjekten ohne *DBE
	CLASS VAR __nBoxType					SHARED							// LlPrintWithBoxStart
	CLASS VAR __nDebug					SHARED							// LlSetDebug(::__nDebug )
	CLASS VAR __nEnableDrillDown  	SHARED							// enable drilldown
	CLASS VAR __nEnableExpand		  	SHARED							// enable expand
	CLASS VAR __nLanguage				SHARED							// LlJobOpen(::__nLanguage)
	CLASS VAR __nSmtpIPPort				SHARED							// Email Versand
	CLASS VAR __nZoom						SHARED							// Zoom bei Preview
	CLASS VAR __onError					SHARED							// Fehler Handling
	CLASS VAR __toUpper					SHARED							// Symbol UPPERCASE

   VAR cOutFile                                                // export filename
   VAR cOutPut                                                 // export medium
   VAR cReport                                                 // layout file
   VAR cTitle                                                  // LlSelectFileDlgTitleEx
   VAR cShowExport                                             // export datei nach erstellen anzeigen/öffnen
   VAR nSelect                                                 // selectarea to skip for listings
   VAR _bNotify                     NODEBUG                    // callbackslot bei preview druck
   VAR _aAddTable                   NODEBUG                    // report container
   VAR _aAddTableRelation           NODEBUG                    // report container
   VAR _aField                                                 // array with {name, block} for LLDefineField
   VAR _aPath                                                  // paths für layout files
   VAR _aRights                     NODEBUG							//
   VAR _aSync                       NODEBUG							//
	VAR _aUsedChartFields            NODEBUG                    // returns array with names of used chart fields
	VAR _aUsedFields						NODEBUG							// returns array with names of used fields
	VAR _aUsedVariables					NODEBUG							// returns array with names of used variables
   VAR _aVar                                                   // array with {name, block} for LLDefineVariable
   VAR _bConfig                                                // callback before LLPrint[withBox]Start
   VAR _bCopyblock                                             // wird bei mehrfach druck ausgewertet
   VAR _bEOF		                                             // eof
   VAR _bPrepare                                               // callback slot just before LLPrint[WithBox]Start
   VAR _bRecno		                                             // recno
   VAR _bSkip																	// skipblock
	VAR _bSortOrder                                             // callback für sortierung
   VAR _bTableChange                                           // wenn tabelle sich ändert bei Berichts container
   VAR _bTop                                              		// gotop bei tablechange und druckstart
   VAR _aData                                                  // druck array
   VAR _cErrorMessage                                          //
	VAR _cExportPath															//
   VAR _cIgnoreField                                           // mask for excluding fields with like
   VAR _cMaster                                                // master table for report container
   VAR _cPrinter                                               //
   VAR _cPrintText                                             // Caption für Print Progress Balken
   VAR _cZUGFeRDXML															// für ZugFerd
   VAR _dbFields                                               // array mit tables/workareas for llDefineField
   VAR _dbVariables                                            // array mit tables/workareas for llDefineVariable
   VAR _lDesign			                                       // start design mode
	VAR _lDesignerUpdated
   VAR _lDesignerPreview                                       // designer preview enabled
   VAR _lIsReleased                 NODEBUG                    // internal
	VAR _lOptimize                   NODEBUG                    //
   VAR _lOptions                    NODEBUG                    // internal
	VAR _lPrepared                   NODEBUG                    // internal
   VAR _lPrintAtEof                                            // wenn TRUE, wird immer mindestens 1 Satz übergeben auch wenn eof()
   VAR _lRtf                                                   // LlSetOption(-1, LL_OPTION_MAXRTFVERSION, 0 )
	VAR _lStreamMode                                            // Stream2Report
   VAR _lUseDbRequest 	            NODEBUG                    // nur FALSE für ADSClass++ PQclass++, eigene Lösungen
   VAR _lSubReport                  NODEBUG                    // TRUE wenn mit berichtscontainer
   VAR _nBoxType                                               // art der fortschritts anzeige
	VAR _hDevmode                    NODEBUG                    // LOCALALLOC hHandle für LOACLFREE
	VAR _nDrillDown                  NODEBUG                    // drilldown
   VAR _nError                                                 //
	VAR _nExpand	                  NODEBUG                    // expandable region
   VAR _nFirstpage                                             //
   VAR _nLastpage                                              //
   VAR _nLastRec                                               //
   VAR _nPages		                                             //
   VAR _nProject                                               // LL_PROJECT_LIST LL_PROJECT_CARD LL_PROJECT_LABEL
   VAR _nPrintOption                                           // LL_PRINT_PREVIEW LL_PRINT_NORMAL LL_PRINT_EXPORT for LLPrint[WithBox]Start
   VAR _nQuantity                                              // number of labels for each record
	VAR _nReportParameter           	NODEBUG                    // report parameter
   VAR _nRootSelect                 NODEBUG                    //
   VAR _nStatus                                                // XBP_STAT_*
   VAR _oParent                     NODEBUG                    //
	VAR templateDefineFieldExt			NODEBUG                    // internal
	VAR templateDefineVariableExt		NODEBUG							// internal

	METHOD _Datalink                                            //
	METHOD _InitDevMode(nIndex)
	METHOD _PrepareExport													//
	METHOD _PrintStart                                          // wrap LlPrint[WithBox]Start
	METHOD _PrintTable                                          //
	METHOD _RaiseError(nError, cArgs, cOperation)               //
	METHOD _SetPrinter                                          //
	METHOD _Synchronize
	METHOD _Varlink                                             //

EXPORTED:
	VAR datalink
   VAR cExportFormat                                           // export format "PRV" "PRN" "PDF"
	VAR hJob 	READONLY
	VAR hWnd 	READONLY
	VAR oDevmode

	CLASS METHOD DefaultPath(xSet)
	CLASS METHOD initClass

	METHOD AddPath																//
	METHOD AddSync																//
	METHOD AddTable															//
	METHOD AddTableEx															//
	METHOD AddTableRelation													//
	METHOD AddTableRelationEx												//
	METHOD AddTableSortOrderEx												//
	METHOD Clear																//
	METHOD Clone																//
	METHOD Connect																//
	METHOD Datalink															//
	METHOD DatalinkTable														//
	METHOD DataSetField														//
	METHOD DataSetStruct														//
	METHOD DataSetVariable													//
	METHOD DbReleaseAll														//
	METHOD DbRequestAll														//
	METHOD DefineField 														//
	METHOD DefineVariable													//
	METHOD Design																//
	METHOD Destroy																//
	METHOD EnableDebug														//
	METHOD ExportFile 														//
	METHOD ExportPath
	METHOD GetDevMode															//
	METHOD GetErrorText														//
	METHOD GetPrinter 														//
	METHOD GetSelect															//
	METHOD Init																	//
	METHOD Notify																//
	METHOD OptimizeDatalink													//
	METHOD Prepare																//
	METHOD Print																//
	METHOD PrintLabel															//
	METHOD Report2Stream														//
	METHOD ResetMenue															//
	METHOD SaveAsPreview														//
	METHOD SaveAsPDF															//
	METHOD SendAsMail															//
	METHOD SetChildRelation          									//
	METHOD SetDefaultPrinter												//
	METHOD SetDevMode															//
	METHOD SetMenuId															//
	METHOD SetProperty														//
	METHOD SetValue
	METHOD Stream2Report

	METHOD Close			IS Destroy

	ACCESS ASSIGN METHOD Printer
	ACCESS ASSIGN METHOD Report
	ACCESS ASSIGN METHOD SelectOptions
	ACCESS ASSIGN METHOD SetExport
	ACCESS ASSIGN METHOD SetFirstpage
	ACCESS ASSIGN METHOD SetPreView
	ACCESS ASSIGN METHOD PrintOption
	ACCESS ASSIGN METHOD SetTitle

	INLINE ACCESS METHOD GetLastPage								;RETURN ::_nLastPage
	INLINE ACCESS METHOD GetParent		   					;RETURN ::_oParent
	INLINE ACCESS METHOD Connected		   					;RETURN ::nSelect
	INLINE ACCESS METHOD Server			   					;RETURN ::nSelect

	INLINE ACCESS ASSIGN METHOD SetDesign(xSet)				;::_lDesign			:= !empty(xSet)			;RETURN self
	INLINE ACCESS ASSIGN METHOD PrintAtEof(xSet)	 			;::_lPrintAtEof	:= xSet						;RETURN self
	INLINE ACCESS ASSIGN METHOD ShowExport(xSet)	 			;::cShowExport   	:= if( xSet, "1", "0")	;RETURN self

	INLINE METHOD DatalinkVariable(cId, xValue, cLLtype )	;RETURN ::_varlink(1, {{cId, xValue, cLLtype}})
	INLINE METHOD GetLastError										;RETURN ::_nError
	INLINE METHOD GetLastMessage									;RETURN ::_cErrorMessage
	INLINE METHOD GetOutPutFile									;RETURN ::cOutFile
	INLINE METHOD IsPreview											;RETURN (::_nPrintOption == LL_PRINT_PREVIEW .or. ::cOutput = "PRV")
	INLINE METHOD Output												;RETURN ::cOutput
	INLINE METHOD Status												;RETURN if( ! empty(::hJob), XBP_STAT_INIT, XBP_STAT_FAILURE )
	INLINE METHOD UsedChartFields									;RETURN ::_aUsedChartFields
	INLINE METHOD UsedFields										;RETURN ::_aUsedFields
	INLINE METHOD UsedVariables									;RETURN ::_aUsedVariables

	INLINE METHOD SetOptionString(nMode, cVal)
		LlSetOptionString(::hJob, nMode, cVal)
		RETURN self

	INLINE METHOD SetOption(nMode, nValue)
		LlSetOption(::hJob, nMode, if( IsLogic(nValue), if(nValue, 1, 0 ), nValue ))
		RETURN self

	INLINE METHOD Zoom(nZoom)
		LlSetOption(::hJob, LL_OPTION_PRVZOOM_PERC, nZoom )
		RETURN self

	INLINE METHOD ClearSync()						;::_aSync	:= {}						;RETURN self
	INLINE METHOD CloneDataSetField(aList)		;::_dbFields	:= aclone(aList)	;RETURN self
	INLINE METHOD CloneDataSetVariable(aTable);::_dbVariables:= aclone(aTable)	;RETURN self
	INLINE METHOD CloneDefineField(aField)		;::_aField	:= aclone(aField)		;RETURN self
	INLINE METHOD CloneDefineVariable(aVar)	;::_aVar		:= aclone(aVar)		;RETURN self
	INLINE METHOD ResetRights()					;::_aRights	:= aclone(::__aRights);RETURN self
	INLINE METHOD UseDbRequest(xSet)				;::_lUseDbRequest := xSet 			;RETURN self
	INLINE METHOD ZugferdXML(xSet)				;::_cZUGFeRDXML	:= xSet			;RETURN self

	//=========================================
	// for free use
	INLINE ACCESS ASSIGN METHOD Dataobject
		if ::_Dataobject == NIL
			::_Dataobject	:= Dataobject():New()
		endif
		RETURN ::_Dataobject

	//=========================================
	INLINE ACCESS ASSIGN METHOD DesignerPreview( xSet)
		if IsLogic(xSet)
			::_lDesignerPreview		:= xSet
			RETURN self
		endif
		RETURN ::_lDesignerPreview

	//=========================================
	INLINE ACCESS ASSIGN METHOD BoxType( xSet)
		if IsNumber(xSet)
			::_nBoxType		:= xSet
			RETURN self
		endif
		RETURN ::_nBoxType

	//=========================================
	INLINE ACCESS ASSIGN METHOD onNotify( xSet)
		if IsBlock(xSet)
			::_bNotify		:= xSet
			RETURN self
		endif
		RETURN ::_bNotify

	//=========================================
	INLINE ACCESS ASSIGN METHOD Lastrec( xSet)
		if IsNumber(xSet)
			::_nLastRec		:= xSet
			RETURN self
		endif
		RETURN ::_nLastRec

	//=========================================
	INLINE ACCESS ASSIGN METHOD DesignerUpdated( xSet)
		if IsLogical(xSet)
			::_lDesignerUpdated		:= xSet
			RETURN self
		endif
		RETURN ::_lDesignerUpdated

	//=========================================
	INLINE ACCESS ASSIGN METHOD Quantity( xSet)
		if IsNumber(xSet)
			::_nQuantity	:= xSet
			RETURN self
		endif
		RETURN ::_nQuantity

	//=========================================
	INLINE ACCESS ASSIGN METHOD IgnoreFieldmask( xSet)
		if IsCharacter(xSet)
			::_cIgnoreField  := xSet
			RETURN self
		endif
		RETURN ::_cIgnoreField

	//=========================================
	INLINE ASSIGN METHOD ExportFormat( xSet)
		if IsCharacter( xSet) .and. !empty(xSet)
			::cExportFormat   := xSet
			LlSetOptionString(::hJob, LL_OPTIONSTR_EXPORTS_ALLOWED_IN_PREVIEW, ::cExportFormat)
		endif
		RETURN self

	//=========================================
	INLINE ASSIGN METHOD PrintText( xSet)
		if IsCharacter( xSet)
			::_cPrintText	:= xSet
		endif
		RETURN self

	//=========================================
	INLINE ACCESS ASSIGN METHOD Pages( xSet)
		if IsNumber( xSet)
			::_nPages		:= xSet
			RETURN self
		endif
		RETURN ::_nPages

	//=========================================
	INLINE ACCESS ASSIGN METHOD ProjectType( xSet)
		if IsNumber( xSet)
			::_nProject		:= xSet
			RETURN self
		endif
		RETURN ::_nProject

	//=========================================
	INLINE ACCESS ASSIGN METHOD Project( xSet)														// obsolet backward compatible,use ProjectType
		if IsNumber( xSet)
			::_nProject		:= xSet
			RETURN self
		endif
		RETURN ::_nProject

//=========================================
	INLINE ACCESS ASSIGN METHOD SkipBlock( xSet)
		if IsBlock( xSet)
			::_bSkip	:= xSet
			RETURN self
     	elseif pcount() = 1
     		::_bSkip   := _SKIPBLOCK			// default, muss immer gültiger codeblock sein
    	endif
    	RETURN ::_bSkip

	//=========================================
	INLINE ACCESS ASSIGN METHOD TopBlock( xSet)
   	if IsBlock( xSet)
   		::_bTop	:= xSet
			RETURN self
  		elseif pcount() = 1
  			::_bTop   := _TOPBLOCK           // default, muss immer gültiger codeblock sein
 		endif
 		RETURN ::_bTop

//=========================================
	INLINE ACCESS ASSIGN METHOD EofBlock( xSet)
		if IsBlock( xSet)
			::_bEof	:= xSet
			RETURN self
     	elseif pcount() = 1
     		::_bEOF   := _EOFBLOCK           // default, muss immer gültiger codeblock sein
    	endif
    	RETURN ::_bEOF

//=========================================
	INLINE ACCESS ASSIGN METHOD RecnoBlock( xSet)
		if IsBlock( xSet)
			::_bRecno	:= xSet
			RETURN self
     	elseif pcount() = 1
     		::_bRecno   := _RECNOBLOCK       // default, muss immer gültiger codeblock sein
    	endif
    	RETURN ::_bRecno

	//=========================================
	INLINE ACCESS ASSIGN METHOD TableChange( xSet)
		if IsBlock( xSet)
			::_bTableChange   := xSet
			RETURN self
		endif
		RETURN ::_bTableChange

	//=========================================
	INLINE ACCESS ASSIGN METHOD ConfigBlock( xSet)
		if IsBlock( xSet)
			::_bConfig		:= xSet
			RETURN self
		endif
		RETURN ::_bConfig

	//=========================================
	INLINE ACCESS ASSIGN METHOD PrepareBlock( xSet)
		if IsBlock( xSet)
			::_bPrepare		:= xSet
			RETURN self
		endif
		RETURN ::_bPrepare

	//=========================================
	INLINE ACCESS ASSIGN METHOD CopyBlock( xSet)
		if IsBlock( xSet)
			::_bCopyblock	:= xSet
			RETURN self
		endif
		RETURN ::_bCopyblock

	//=========================================
	INLINE METHOD EnableDrillDown( xSet)
		if IsLogical(xSet) .and. xSet
			::_nDrillDown	:= 1
		elseif IsNumber(xSet)
			::_nDrillDown	:= xSet
		else
			::_nDrillDown	:= 0
		endif
		LlSetOption(::hJob, LL_OPTION_DRILLDOWNPARAMETER, ::_nDrillDown)
		RETURN self

	//=========================================
	INLINE METHOD EnableExpand( xSet)
		if IsLogical(xSet) .and. xSet
			::_nExpand	:= 1
		elseif IsNumber(xSet)
			::_nExpand	:= xSet
		else
			::_nExpand	:= 0
		endif
		LlSetOption(::hJob, LL_OPTION_EXPANDABLE_REGIONS_REALDATAJOBPARAMETER, ::_nExpand)
		LlSetOption(::hJob, LL_OPTION_REPORT_PARAMETERS_REALDATAJOBPARAMETER, ::_nExpand)
		RETURN self

	//=========================================
	INLINE CLASS Method DefaultBoxType(xSet)	     		;::__nBoxType				:= xSet					;RETURN self
	INLINE CLASS Method DefaultUseDbRequest(xSet)		;::__lUseDbRequest		:= xSet					;RETURN self
	INLINE CLASS Method DefaultDesignerPreview(xSet)	;::__lDesignerPreview	:= xSet					;RETURN self
	INLINE CLASS Method DefaultEmailProvider(xSet)		;::__cEmailProvider		:= xSet					;RETURN self
	INLINE CLASS Method DefaultEnableDrillDown(xSet)  	;::__nEnableDrillDown	:= xSet					;RETURN self
	INLINE CLASS Method DefaultEnableExpand(xSet)		;::__nEnableExpand		:= xSet					;RETURN self
	INLINE CLASS Method DefaultExport(xSet)				;::__cExportFormat		:= xSet					;RETURN self
	INLINE CLASS Method DefaultExportPath(xSet)			;::__cExportPath			:= xSet					;RETURN self
	INLINE CLASS Method DefaultIgnoreFieldMask(xSet)   ;::__cIgnoreField			:= xSet					;RETURN self
	INLINE CLASS Method DefaultLanguage(xSet)				;::__nLanguage				:= xSet					;RETURN self
	INLINE CLASS Method DefaultMenuDisabled(xSet)		;::__aRights				:= aclone(xSet)		;RETURN self
	INLINE CLASS Method DefaultPrinter(xSet)	     		;::__cPrinter				:= xSet					;RETURN self
	INLINE CLASS Method DefaultPrintText(xSet)     		;::__cPrintText			:= xSet					;RETURN self
	INLINE CLASS Method DefaultSmtpIPAddress(xSet)		;::__cSmtpIPAddress 		:= xSet					;RETURN self
	INLINE CLASS Method DefaultSmtpIPPort(xSet)			;::__nSmtpIPPort    		:= xSet					;RETURN self
	INLINE CLASS Method DefaultSmtpPassword(xSet)		;::__cSmtpPassword  		:= xSet					;RETURN self
	INLINE CLASS Method DefaultSmtpSenderAddress(xSet)	;::__cSmtpSenderAddress	:= xSet					;RETURN self
	INLINE CLASS Method DefaultSmtpSenderName(xSet)		;::__cSmtpSenderName		:= xSet					;RETURN self
	INLINE CLASS Method DefaultSmtpUser(xSet)				;::__cSmtpUser				:= xSet					;RETURN self
	INLINE CLASS Method DefaultTempPath(xSet)				;::__cTempPath				:= _SlashPath(xSet)	;RETURN self
	INLINE CLASS Method DefaultZoom(xSet)					;::__nZoom					:= xSet					;RETURN self
	INLINE CLASS Method LicensingInfo(xSet)				;::__cLicence				:= xSet					;RETURN self
	INLINE CLASS Method SymbolsToUpper(xSet)				;::__toUpper				:= xSet					;RETURN self
	INLINE CLASS Method Version()																							;RETURN __LL

	//=========================================
	INLINE CLASS Method LLVersion()
		LOCAL hJob	:= LlJobOpen(::__nLanguage)
		LOCAL xRet	:= 0
		if hJob == NIL .or. hJob < 0
			RETURN 0
		endif
		xRet	:= LlGetVersion(LL_VERSION_MAJOR)
		LlJobClose(hJob)
		RETURN xRet

	//=========================================
	INLINE CLASS Method DefaultVariable(cSymbol, xValue, nLLType)
		LOCAL nPos
		LOCAL cTmp	:= cSymbol
		nPos   := ascan( ::__aDefaultVar, {|a| a[1] == cTmp})
		if nPos > 0
			::__aDefaultVar[nPos,2] := xValue
			::__aDefaultVar[nPos,3] := nLLType
		else
			aadd( ::__aDefaultVar, {cSymbol, xValue, nLLType})
		endif
		RETURN self

	//=========================================
	INLINE CLASS Method DefaultConfigBlock(bSet)
		if IsBlock(bSet)
			::__bConfig	:= bSet
		endif
		RETURN self

	//=========================================
	INLINE CLASS Method DefaultPrepareBlock(bSet)
		if IsBlock(bSet)
			::__bPrepare	:= bSet
		endif
		RETURN self

	//=========================================
	INLINE CLASS Method onError(xSet)
		if IsBlock(xSet)
			::__onError	:= xSet
		endif
		RETURN self

	//=========================================
	INLINE CLASS Method DefaultDebug(xSet)
		if IsNumber(xSet)
			::__nDebug   := xSet
		elseif IsLogical(xSet)
			if xSet
				::__nDebug   := LL_DEBUG_CMBTLL
			else
				::__nDebug   := 0
			endif
		endif
		RETURN self

	//=========================================
	INLINE CLASS Method ModulInstalled()
		RETURN LLModuleInit()

ENDCLASS

//=========================================
CLASS METHOD dsListLabel:InitClass()
	if ::__aDefaultVar == NIL
		::__aDefaultVar			:= {}
		::__aRights					:= {}
		::__bConfig					:= NIL
		::__bPrepare				:= NIL
		::__aDefaultPath			:= {}
		::__cEmailProvider		:= "SMTP"
		::__cExportFormat			:= ""
		::__cExportPath			:= getEnv("USERPROFILE")+"\Documents"
		::__cIgnoreField			:= ""
		::__cLicence				:= ""
		::__cPrintText				:= "Printing..."
		::__cSmtpIPAddress		:= ""
		::__cSmtpPassword			:= ""
		::__cSmtpSenderAddress	:= ""
		::__cSmtpSenderName		:= ""
		::__cSmtpUser				:= ""
		::__cTempPath				:= _GetTempPath()
		::__lDesignerPreview		:= FALSE
		::__lUseDbRequest			:= TRUE
		::__nBoxType				:= LL_BOXTYPE_STDWAIT
		::__nDebug					:= 0
		::__nEnableDrillDown 	:= 0
		::__nEnableExpand		 	:= 0
		::__nLanguage				:= -1
		::__nSmtpIPPort			:= 25
		::__nZoom					:= 100
		::__toUpper					:= FALSE
	endif
RETURN self

//=========================================
CLASS METHOD dsListLabel:DefaultPath(xSet)
	LOCAL aTmp
	LOCAL i, iCnt

	if pcount() = 0
		RETURN ::__aDefaultPath
	endif

	if IsArray(xSet)
		iCnt	:= len( xSet)
		for i := 1 to iCnt
			xSet[i]	:= strtran( xSet[i], "%APPDATA%"		, GetEnv("APPDATA"))
			xSet[i]	:= strtran( xSet[i], "%USERPROFILE%", GetEnv("APPDATA"))
			aadd(::__aDefaultPath, xSet[i] )
		next

	elseif IsCharacter(xSet)
		if ";" $ xSet
			aTmp	:= _aStrExtract(xSet, ";")
			iCnt	:= len( aTmp)
			for i := 1 to iCnt
				aTmp[i]	:= strtran( aTmp[i], "%APPDATA%"		, GetEnv("APPDATA"))
				aTmp[i]	:= strtran( aTmp[i], "%USERPROFILE%", GetEnv("APPDATA"))
				aadd(::__aDefaultPath, aTmp[i] )
			next
		else
			xSet	:= strtran( xSet, "%APPDATA%"		, GetEnv("APPDATA"))
			xSet	:= strtran( xSet, "%USERPROFILE%", GetEnv("APPDATA"))
			aadd(::__aDefaultPath, xSet )
		endif
	endif
RETURN ::__aDefaultPath

/*============================================================================
 $Method:	Init(oParent, lRtf )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:     oParent
 $Argument:     lRtf
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Init( oParent, lRtf )
	LOCAL oError

	INSTANCE ::oDevmode		as STRUCTURE DEVMODE

	::DbContainer:Init()
	if IsNumber(oParent)                                                             // :clone(), Designer Preview
		::hWnd			:= oParent

	elseif IsObject(oParent)
		::hWnd			:= oParent:GetHWND()
	else
		oParent			:= SetAppWindow()
		::hWnd			:= SetAppWindow():GetHWND()
	endif

	::_bSkip					:= _SKIPBLOCK
	::_bTop					:= _TOPBLOCK
	::_bEof					:= _EOFBLOCK
	::_bRecno   			:= _RECNOBLOCK
	::_lDesignerUpdated	:= FALSE
	::_lRtf					:= lRtf
	::_lStreamMode			:= FALSE
	::_oParent				:= oParent                                                     // aufrufender dialog
	::_aRights				:= aclone(::__aRights)
	::_cExportPath			:= ::__cExportPath
	::_cPrintText			:= ::__cPrintText

	if !LLModuleInit()
		::_nStatus   := XBP_STAT_FAILURE
		if IsBlock(::__onError)
			oError	:= Error():New()
			oError:args				:= CMBT_DLL
			oError:canDefault		:= FALSE
			oError:canRetry		:= TRUE
			oError:canSubstitute := FALSE
			oError:osCode			:= DosError()
			oError:description   := DosErrorMessage(oError:osCode)
			oError:genCode			:= oError:osCode
			oError:operation     := "Error Loading " + CMBT_DLL
			oError:subSystem     := "ListLabel"
			oError:cargo			:= self
			oError:thread			:= threadid()
			eval(::__onError, oError)
		endif
		RETURN self
	endif

	// booster
	::templateDefineFieldExt		:= templateDefineFieldExt()
	::templateDefineVariableExt	:= templateDefineVariableExt()

	if empty(lRtf)                                                                   // ausschalten wegen performance
		LlSetOption(-1, LL_OPTION_MAXRTFVERSION, 0 )
	endif

	::hJob	 := LlJobOpen(::__nLanguage)
	if empty(::hJob) .or. ::hJob < 0
		::_nError   := ::hJob
		::_nStatus  := XBP_STAT_FAILURE
		::hJob		:= 0
		::_RaiseError(::_nError, var2char(::__nLanguage), "LLJobOpen()")
		RETURN self
	endif
	::_nStatus		:= XBP_STAT_CREATE                                                // laden DLL erfolgreich

	// defaults + reset
	LlSetPrinterDefaultsDir(::hJob, ::__cTempPath)
	LlPreviewSetTempPath(::hJob, ::__cTempPath)

	if !empty(::__nDebug)
		LlSetDebug(::__nDebug )
	endif

	LlSetOptionString (::hJob, LL_OPTIONSTR_LICENSINGINFO    ,::__cLicence )

	LlViewerProhibitAction(::hJob, 0)
	aeval( ::_aRights, {|n| LlViewerProhibitAction(::hJob, n )})

	::Clear(1)

RETURN self

/*============================================================================
 $Method:      Prepare()
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    None
 $Return:      self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Prepare()
	LOCAL nError    := 0
	LOCAL cPath, cTmp
	LOCAL i, nLen

	if ! IsNumber(::hJob) .or. ::hJob <= 0                                           // ::hJob kann auch NIL sein!!!
		RETURN LL_ERR_BAD_JOBHANDLE
	endif
	if ::_lPrepared
		RETURN 0
	endif

	::_nRootSelect := ::nSelect

	if IsObject(::nSelect )
		if empty(::_nLastRec)
			if IsMethod(::nSelect, "countrec")
				::_nLastRec	:= ::nSelect:countrec()                                     // nur AdsClass++

			elseif IsMethod(::nSelect, "lastrec")
				::_nLastRec	:= ::nSelect:lastrec()
			endif
		endif

	elseif IsArray(::nSelect )
		::_nLastRec		:= len(::nSelect)
		::_bSkip			:= {|o, n| NIL}
		::_bTop			:= {|o, n| NIL}

	elseif IsNumber(::nSelect) .and. ::nSelect > 0
		if empty(::_nLastRec)
			::_nLastRec   := (::nSelect)->(lastrec())
		endif
	endif

	::_nLastRec				:= max(1, ::_nLastRec)
	::_aUsedFields			:= {}
	::_aUsedVariables		:= {}
	::_aUsedChartFields	:= {}

	IF ::_lOptimize
		// bei arrays vorerst nicht möglich
		::_lOptimize	:= !( ascan(::_dbFields, {|a| valtype(a[1]) = "A"}) == 0 .or. ascan(::_dbVariables, {|a| valtype(a[1]) = "A"}) == 0)
	ENDIF

	eval(::_bTop, self, ::nSelect )

	nLen  := 5000
	cTmp	:= space(nLen)
	nError	:= LLGetUsedIdentifiersEx(::hJob, ::cReport, LL_USEDIDENTIFIERSFLAG_FIELDS, @cTmp, nLen)
	if nError == 0
		cTmp	:= _Trim0(cTmp)
		if !empty(cTmp)
			::_aUsedFields	:= _astrextract(cTmp, ";")
			asort(::_aUsedFields)
		endif
	endif

	nLen  := 5000
	cTmp	:= space(nLen)
	nError	:= LLGetUsedIdentifiersEx(::hJob, ::cReport, LL_USEDIDENTIFIERSFLAG_VARIABLES, @cTmp, nLen)
	if nError == 0
		cTmp	:= _Trim0(cTmp)
		if !empty(cTmp)
			::_aUsedVariables	:= _astrextract(cTmp, ";")
			asort(::_aUsedVariables)
		endif
	endif

	nLen  := 5000
	cTmp	:= space(nLen)
	nError	:= LLGetUsedIdentifiersEx(::hJob, ::cReport, LL_USEDIDENTIFIERSFLAG_CHARTFIELDS, @cTmp, nLen)
	if nError == 0
		cTmp	:= _Trim0(cTmp)
		if !empty(cTmp)
			::_aUsedChartFields	:= _astrextract(cTmp, ";")
			asort(::_aUsedChartFields)
		endif
	endif

	cTmp	:= NIL

	::_Synchronize(1)
	::datalink(1, 1 )                                                                // erstinit variablen
	if ::_nProject == LL_PROJECT_LIST
		::datalink(0, 1 )                                                          	// erstinit felder
	endif

	if empty( ::_cPrinter ) .and. !empty(::__cPrinter)
		::_cPrinter	:= ::__cPrinter
	endif

	if !empty( ::_cPrinter )
		::_SetPrinter(::_cPrinter)
	endif

	if IsBlock(::_bPrepare)                                                          // User Callback
		eval(::_bPrepare, self, ::hJob )
	endif

	if !::_PrintStart()
		RETURN ::_nError
	endif

	LlPrintSetOption(::hJob, LL_PRNOPT_PAGE , ::_nFirstpage )

	if IsCharacter(::cOutFile) .and. ( i := rat("\", ::cOutFile )) > 0
		::_cExportPath	:= left( ::cOutFile, i )
		::cOutFile := subs( ::cOutFile, ++i)
	endif

	if IsBlock(::_bConfig)                                                           // User Callback
		eval(::_bConfig, self, ::hJob )
	endif

	::_PrepareExport()

	if !::IsPreview() .and. ::_lOptions
		::_nError   := LLPrintOptionsDialog( ::hJob, ::hWND, "")
		if ::_nError == LL_ERR_USER_ABORTED
			::GetErrorText(::_nError)
			RETURN LL_ERR_USER_ABORTED
		endif
		::GetPrinter()
	endif

	nLen			:= 250
	::cOutPut	:= space(nLen)
	::cOutFile  := space(nLen)
	cPath	 		:= space(nLen)

	// das in dem Druck-dialog evt. ausgewählte Exportformat, es kann ja nur eins ausgewählt worden sein
	LlPrintGetOptionString(::hJob, LL_PRNOPTSTR_EXPORT, @::cOutPut, nLen)
	::cOutPut   := _Trim0( ::cOutPut)

	if !empty(::cOutPut)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ::cOutPut   ,"Export.File", @::cOutFile, nLen)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ::cOutPut   ,"Export.Path", @cPath, nLen)
		::_cExportPath	:= _Trim0(cPath )
		::cOutFile		:= ::_cExportPath + _Trim0( ::cOutFile)
	endif

	::_lPrepared	:= TRUE

RETURN 0

/*============================================================================
 $Method:	Print(bPrint)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    bPrint
 $Return:	nError
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Print(bPrint)
	LOCAL nError	:= 0
	LOCAL nLastRec, nRec, nPrint := 0, _nQuantity, nPage
	LOCAL oSelf		:= self:&(self:classname())
	LOCAL cChild
	LOCAL lPrintAtEof
	LOCAL oCallBack

	if ! IsNumber(::hJob) .or. ::hJob <= 0							 // ::hJob kann auch NIL sein!!!
		RETURN LL_ERR_BAD_JOBHANDLE
	endif

	if ::_lDesign															// abwärtskompatibel
		RETURN ::design()
	endif

	if ::_nError = LL_ERR_USER_ABORTED
		RETURN ::_nError
	endif

	if !::_lPrepared
		// kann in Subclass überschrieben werden
		nError	:= oSelf:prepare()
		if nError <> 0
			RETURN nError
		endif
	endif

	oCallBack   := LLCallBack():New(self )
	if IsBlock( ::_bNotify)
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_VIEWERBTNCLICKED, oCallBack)
	endif
	if !empty(::_nDrillDown) .or. !empty(::_nExpand)
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_VIEWERDRILLDOWN, oCallBack)
	endif
   IF ::IsPreview()
      LlPrintSetOptionString(::hJob, LL_PRNOPTSTR_PREVIEWTITLE, ::cTitle )
   ENDIF

	nLastRec	:= ::_nLastRec
	nRec   	:= 0
	nPage  	:= 0

	if IsBlock( bPrint )
		// LlPrint + llPrintEnd  muß hier in codeblock gestartet werden !!
		::_nError   	:= ::eval( bPrint, self, ::nSelect )
		if !IsNumber(::_nError)
			::_nError	:= 0
		endif
		::_nLastpage   := LlPrintGetCurrentPage(::hJob)

	else
		if ::_nProject == LL_PROJECT_LIST
			nLastRec   *= ::_nQuantity
			for _nQuantity := 1 to ::_nQuantity
				lPrintAtEof   := ::_lPrintAtEof
				nRec     := 0
				nError   := 0
				eval(::_bTop, self, ::nSelect )
				if IsBlock(::_bCopyblock)
					eval( ::_bCopyblock, self, ::nSelect, _nQuantity )
				endif
				do while LlPrint(::hJob) == LL_WRN_REPEAT_DATA; enddo

				if ::_lSubReport
					cChild   := space(50)
					LlPrintDbGetCurrentTable(::hJob, @cChild, 50, FALSE )
					cChild := _Trim0( cChild )
					if IsBlock(::_bTableChange) .and. cChild != "LLStaticTable"
						eval(::_bTableChange, self, TRUE, ::getSelect(cChild), "")
					endif
					::nSelect	:= ::getSelect(cChild)

					if IsArray( ::nSelect)
						do while !nError = LL_ERR_USER_ABORTED
							nError := ::_PrintTable(cChild, "", 0 )
							if nError = LL_WRN_TABLECHANGE
								cChild   := space(50)
								LlPrintDbGetCurrentTable(::hJob, @cChild, 50, FALSE )
								cChild := _Trim0( cChild )
								if IsBlock(::_bTableChange) .and. cChild != "LLStaticTable"
									eval(::_bTableChange, self, TRUE, ::getSelect(cChild), "")
								endif
								::nSelect	:= ::getSelect(cChild)
								if IsBlock(::_bTableChange) .and. cChild != "LLStaticTable"
									eval(::_bTableChange, self, FALSE, ::getSelect(cChild), "")
								endif
								loop
							endif
							exit
						enddo

					else
						do while !nError = LL_ERR_USER_ABORTED

							nError := ::_PrintTable(cChild, ::_cMaster, 0 )

							if nError = LL_WRN_TABLECHANGE
								cChild   := space(50)
								LlPrintDbGetCurrentTable(::hJob, @cChild, 50, FALSE )
								cChild := _Trim0( cChild )
								if IsBlock(::_bTableChange) .and. cChild != "LLStaticTable"
									eval(::_bTableChange, self, TRUE, ::getSelect(cChild), "")
								endif
								::nSelect	:= ::getSelect(cChild)

								if IsBlock(::_bTableChange) .and. cChild != "LLStaticTable"
									eval(::_bTableChange, self, FALSE, ::getSelect(cChild), "")
								endif
								loop
							endif
							exit
						enddo
						::GetErrorText(nError)
					endif

				elseif IsArray( ::nSelect)
						nLastRec	:= len(::nSelect)
						for nPrint := 1 to nLastRec
							::_Synchronize(nPrint)
							::datalink(0, nPrint)
							do while (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
								LlPrint(::hJob)
							enddo
							nPage		:= LlPrintGetCurrentPage(::hJob)
							LlPrintSetBoxText(::hJob, ::_cPrintText, nPrint / nLastRec * 100 )
							if ::_nPages > 0 .and. nPage > ::_nPages
								exit
							endif
						next
				else
					do while nError == 0 .and. (!eval(::_bEof, self, ::nSelect) .or. lPrintAtEof ) .and. nRec <> eval(::_bRecno,self,::nSelect) .and. (::_nPages == 0 .or. nPage <= ::_nPages)
						nRec   := eval(::_bRecno, self,::nSelect)
						lPrintAtEof   := FALSE
						::_Synchronize( nRec, ::nSelect)
						::datalink(0, nRec)
						do while (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
							::datalink(1, nRec)
							LlPrint(::hJob)
						enddo
						nPage		:= LlPrintGetCurrentPage(::hJob)
						eval( ::_bSkip, self, ::nSelect)
						LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / nLastRec * 100 )
					enddo
					do while (nError := LlPrintFieldsEnd(::hJob)) == LL_WRN_REPEAT_DATA; enddo
					::_nLastpage   := LlPrintGetCurrentPage(::hJob)
				endif
				if (::IsPreview() .and. !IsBlock(::_bCopyblock)) .or. nError == LL_ERR_USER_ABORTED
					::GetErrorText(nError)
					exit
				endif
				LlPrintResetProjectState(::hJob)
			next

		elseif IsObject(::nSelect )									    // CRD oder LBL
			eval(::_bTop, self, ::nSelect )
			do while nError == 0 .and. (!::nSelect:eof() .or. ::_lPrintAtEof) .and. nRec <> ::nSelect:recno() .and. (::_nPages == 0 .or. nPage <= ::_nPages)
				nRec   := ::nSelect:recno()
				::_lPrintAtEof   := FALSE
				::_Synchronize( nRec, ::nSelect)
				::datalink(1, nRec)
				for _nQuantity := 1 to ::_nQuantity
					do while (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA	;enddo
				next
				nPage		:= LlPrintGetCurrentPage(::hJob)
				eval( ::_bSkip, self, ::nSelect)
				LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / nLastRec * 100 )
			enddo

		elseif IsNumber(::nSelect) .and. ::nSelect > 0									    // CRD oder LBL
			eval(::_bTop, self, ::nSelect )
			do while nError == 0 .and. (!(::nSelect)->(eof()) .or. ::_lPrintAtEof) .and. nRec <> (::nSelect)->(recno()) .and. (::_nPages == 0 .or. nPage <= ::_nPages)
				nRec   := (::nSelect)->(recno())
				::_lPrintAtEof   := FALSE
				::_Synchronize( nRec, ::nSelect)
				::datalink(1, nRec)
				for _nQuantity := 1 to ::_nQuantity
					do while (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA	;enddo
				next
				nPage		:= LlPrintGetCurrentPage(::hJob)
				eval( ::_bSkip, self, ::nSelect)
				LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / nLastRec * 100 )
			enddo

		elseif IsArray( ::nSelect)
			for nPrint := 1 to nLastRec
				::_Synchronize( nPrint)
				::datalink(1, nPrint)
				for _nQuantity := 1 to ::_nQuantity
					do while (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA	;enddo
				next
				nPage		:= LlPrintGetCurrentPage(::hJob)
				if ::_nPages > 0 .and. nPage > ::_nPages
					exit
				endif
				LlPrintSetBoxText(::hJob, ::_cPrintText, nPrint / nLastRec * 100 )
			next

		else
			// aktuelle Daten einmal ausgeben,
			for _nQuantity := 1 to ::_nQuantity
				do while (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA .and. ::_nProject <> LL_PROJECT_LABEL .and. (::_nPages == 0 .or. nPage <= ::_nPages); enddo
				nPage		:= LlPrintGetCurrentPage(::hJob)
				LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / ::_nQuantity * 100 )
			next
		endif
		::_nLastpage   := LlPrintGetCurrentPage(::hJob)
		::_nError 		:= LlPrintEnd(::hJob,0)
		::_RaiseError(::_nError, ::cReport, "LlPrintEnd()")
	endif

	if ::_nError == 0 .and. IsBlock(::_bNotify) .and. !::IsPreView()
		// falls direkt druck
		eval( ::_bNotify, LL_NTFY_AFTERPRINT, MNUID_LL_PRINT, self )
	endif

	if !empty(llGetOption( ::hJob, LL_OPTION_INCREMENTAL_PREVIEW ))
		LlPreviewDeleteFiles(::hJob, ::cReport, ::__cTempPath)
	endif

	if IsObject(oCallBack)
		oCallBack:destroy()
	endif
	::_lPrepared	:= FALSE

RETURN nError

/*============================================================================
 $Method:	Design()
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    None
 $Return:	0
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Design()
	LOCAL oCallback

	if ! IsNumber(::hJob) .or. ::hJob <= 0                                           // ::hJob kann auch NIL sein!!!
		RETURN LL_ERR_BAD_JOBHANDLE
	endif
	::_lDesign	:= TRUE

	::_Synchronize( 1 )
	::datalink(1, 1 )                                                                 // erstinit variablen
	if ::_nProject == LL_PROJECT_LIST
		::datalink(0, 1 )                                                         // erstinit felder
	endif

	if IsBlock(::_bPrepare)
		eval(::_bPrepare, self, ::nSelect )
	endif

	oCallBack   := LLCallBack():New(self )
	if ::_lStreamMode
		LlSetNotificationCallbackExt(::hJob, LL_CMND_SAVEFILENAME, oCallBack)
	endif

	if ::_lDesignerPreview
  		LlSetOption(::hJob,LL_OPTION_DESIGNERPREVIEWPARAMETER, 1)
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_DESIGNERPRINTJOB, oCallBack)
		if !empty(::_nDrillDown) .or. !empty(::_nExpand)
			LlSetNotificationCallbackExt(::hJob, LL_NTFY_VIEWERDRILLDOWN, oCallBack)
		endif
	endif

	::_nError	:= LlDefineLayout(::hJob, ::hWnd, "Designer", ::_nProject, ::cReport)

	::_RaiseError(::_nError, ::cReport, "LlDefineLayout()")


	oCallback:destroy()
RETURN 0

//=========================================
METHOD dsListLabel:_PrintTable(cChild, cParent, nRek )
	LOCAL nSelect	:= 0
	LOCAL nScope	:= 0
	LOCAL nOSelect	:= ::nSelect
	LOCAL oSelf		:= self:&(self:classname())
	LOCAL cRelation, cSubChild
	LOCAL nError , nPrint, nPage, nRecNo, nLastRec
	LOCAL dbChild, dbParent

	if cChild == "LLStaticTable"
		nError := LlPrintFields(::hJob)
		do while nError == LL_WRN_REPEAT_DATA
			do while LlPrint(::hJob) == LL_WRN_REPEAT_DATA
			enddo
			nError	:= LlPrintFields(::hJob)
		enddo
		nError	:= LlPrintFieldsEnd(::hJob)
		RETURN nError
	endif

	nPage			:= 0
	nPrint 		:= 0
	nSelect		:= ::getSelect(cChild)
	cRelation	:= space(200)
	nError		:= LlPrintDbGetCurrentTableRelation(::hJob, @cRelation, 200 )
	cRelation	:= _Trim0( cRelation )
	dbChild		:= nSelect
	if !empty(cParent)
		dbParent	:= ::getSelect(cParent)
	endif

	eval(::_bTop, self, nSelect )
	::nSelect   := nSelect
	::_Synchronize( -1, cParent)
	::datalink(0, 1 )

	if IsArray( nSelect)
		if !empty(cRelation)
			// kann in Subclass überschrieben werden
			oSelf:SetChildRelation(cRelation, cParent, cChild, @nScope)
		endif

		nLastRec	:= len( nSelect)
		nRecNo	   := 0

		do while nError == 0 .and. nRecNo < nLastrec  .and. (::_nPages == 0 .or. nPage <= ::_nPages)
			nRecNo++
			::_Synchronize( nRecNo, cChild )
			::datalink(0, nRecNo )
			do while (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
				do while LlPrint(::hJob) == LL_WRN_REPEAT_DATA
				enddo
			enddo
			do while nError == LL_WRN_TABLECHANGE
				cSubChild   := space(50)
				LlPrintDbGetCurrentTable(::hJob, @cSubChild, 50, FALSE )
				cSubChild := _Trim0( cSubChild )

				if IsBlock(::_bTableChange) .and. cChild != "LLStaticTable"
					eval(::_bTableChange, self, TRUE, cSubChild, cChild, nRecNo )
				endif

				nError := ::_PrintTable(cSubChild, cChild, 0 )
			enddo
			nPage		:= LlPrintGetCurrentPage(::hJob)
         if empty(cParent)
				LlPrintSetBoxText(::hJob, ::_cPrintText, nRecNo / nLastRec * 100 )
         endif
		enddo

	else
		if !empty(cRelation)
			// kann in Subclass überschrieben werden
			oSelf:SetChildRelation(cRelation, coalesce(dbParent, ::getSelect(::_cMaster), ::_nRootSelect), nSelect, @nScope)
		endif

		do while nError == 0 .and. !eval(::_bEof, self, nSelect) .and. (::_nPages == 0 .or. nPage <= ::_nPages)
			nRecNo	:= eval(::_bRecno,self,nSelect)
			::_Synchronize( nRecNo, nSelect )
			::datalink(0, nRecNo )
			do while (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
				do while LlPrint(::hJob) == LL_WRN_REPEAT_DATA
				enddo
			enddo

			do while nError == LL_WRN_TABLECHANGE
				cSubChild		:= space(50)
				nError	:= LlPrintDbGetCurrentTable(::hJob, @cSubChild, 50, FALSE )
				cSubChild		:= _Trim0( cSubChild )

				if IsBlock(::_bTableChange) .and. cChild != "LLStaticTable"
					eval(::_bTableChange, self, TRUE, cSubChild, cChild, nRecNo )
				endif

				nError	:= ::_PrintTable(cSubChild, cChild, nRek + 1 )
			enddo
			nPage		:= LlPrintGetCurrentPage(::hJob)
			eval( ::_bSkip, self, nSelect)
         if empty(cParent)
				LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / ::_nLastRec * 100 )
         endif
		enddo
	endif
	::GetErrorText(nError)

	if nError != LL_ERR_USER_ABORTED
		do while (nError := LlPrintFieldsEnd(::hJob)) == LL_WRN_REPEAT_DATA
		enddo
	endif
	::_nLastpage   := LlPrintGetCurrentPage(::hJob)

	if nScope = 1
		dbChild:clearscope()
	endif
	::nSelect   := nOSelect

RETURN nError

//=========================================
METHOD dsListLabel:_PrepareExport()
	LOCAL aExport
	LOCAL i, iCnt
	LOCAL cOutFile	:= ::cOutFile

	if empty(::cExportFormat)
		RETURN self
	endif

	aExport   := _astrextract(::cExportFormat, ";")
	iCnt	:= len( aExport)

	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ""   ,"Export.Path", ::_cExportPath)
	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ""   ,"Export.ShowResult", ::cShowExport)

	if empty(cOutFile)
		cOutFile	:= "LLEXPORT"+dtos(date())+strtran(time(),":")
	else
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  			,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XHTML"			,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "HTML"				,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "JQM"  			,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PPTX" 			,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XLS"  			,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XML"  			,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_JPEG"	,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_TIFF"	,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_BMP"	,"Export.Quiet", "1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"				,"Export.Quiet", "1")
	endif

	for i := 1 to iCnt
		if aExport[i] = "PDF"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"	,"Export.File", _SetExtension(cOutFile, "PDF") )

		elseif aExport[i] = "XHTML"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XHTML","Export.File", _SetExtension(cOutFile, "HTML") )

		elseif aExport[i] = "HTML"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "HTML" ,"Export.File", _SetExtension(cOutFile, "HTML") )

		elseif aExport[i] = "JQM"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "JQM"  ,"Export.File", _SetExtension(cOutFile, "HTML") )

		elseif aExport[i] = "PPTX"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PPTX" ,"Export.File", _SetExtension(cOutFile, "PPTX") )

		elseif aExport[i] = "XLS"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XLS"  ,"Export.File", _SetExtension(cOutFile, "XLS") )

		elseif aExport[i] = "XML"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XML"  ,"Export.File", _SetExtension(cOutFile, "XML"))

		elseif aExport[i] = "TXT"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"  ,"Export.OnlyTableData", "1")
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"  ,"Export.FrameChar", "NONE")
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"  ,"Export.SeparatorChar", ";")
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"  ,"Export.File", _SetExtension(cOutFile, "TXT"))

		elseif aExport[i] = "PICTURE_JPEG"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_JPEG"  ,"Export.File", _SetExtension(cOutFile, "JPG"))

		elseif aExport[i] = "PICTURE_TIFF"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_TIFF"  ,"Export.File", _SetExtension(cOutFile, "TIF"))

		elseif aExport[i] = "PICTURE_BMP"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_BMP"	,"Export.File", _SetExtension(cOutFile, "BMP"))
		endif
	next
	LLSetOptionString(::hJob, LL_OPTIONSTR_EXPORTS_ALLOWED, ::cExportFormat)
	if ! ";" $ ::cExportFormat                                                       // nur 1 Export def., dann keine Auswahl
		::_nError	:= LlPrintSetOptionString(::hJob, LL_PRNOPTSTR_EXPORT, ::cExportFormat)
		::_RaiseError(::_nError, ::cExportFormat, "LlPrintSetOptionString(LL_PRNOPTSTR_EXPORT)")
		::_lOptions   := FALSE
	else
		::_lOptions   := TRUE
	endif
RETURN self

//=========================================
METHOD dsListLabel:_Synchronize(nRecno, cMaster )
	LOCAL i, iCnt

	iCnt   := len( ::_aSync)
	for i := 1 to iCnt
		if IsBlock(::_aSync[i])
			::eval( ::_aSync[i], self, ::nSelect, nRecno, cMaster )
		endif
	next
RETURN self

/*============================================================================
 items@scope?billno	=> {|oListLabel, dbParent, dbChild| dbChild:setscope(SCOPE_BOTH, dbParent:BILLNO)}
 items@scope?billno	=> {|oListLabel, dbParent, dbChild| (dbChild)->(dbsetscope(SCOPE_BOTH, dbParent->BILLNO))}

 ADS SQL:
 items@param?billno=billno	=> setparam("billno", dbParent:billno)

 PostgreSQL:
 items@param?billno	=> setparam("$1", dbParent:billno)
==============================================================================*/
METHOD dsListLabel:SetChildRelation( cRelation, dbParent, dbChild, pnScope)
	LOCAL nPos	:= 0
	LOCAL i, iCnt
	LOCAL aKey, aTmp
	LOCAL bKey

	// kein unterstufe
	if empty(cRelation)
		pnScope	:= 0
		RETURN self
	endif

	if (nPos := at("@scope?", cRelation)) > 0
		bKey	:= &("{|o,dbP,dbC| " + subs(cRelation,nPos+7) +"}")
		if IsObject(dbChild)
			aKey	:= eval( bKey, self, dbParent, dbChild )
			if aKey != NIL
				dbChild:setscope(SCOPE_BOTH, aKey )
			endif
		else
			aKey	:= (dbParent)->(eval( bKey, self, dbParent, dbChild ))
			if aKey != NIL
				(dbChild)->(dbSetScope(SCOPE_BOTH, aKey))
			endif
		endif
		pnScope	:= 1

	elseif (nPos := at("@raw?", cRelation)) > 0                                          //.or. (nPos := at(";", cRelation)) > 0
		// nur AdsClass++, rawkey-scope
		aKey     := _aStrExtract(subs(cRelation,nPos+5), ";")
		aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, TRUE )
		if len(aKey) == 1
			aKey	:= aKey[1]
		endif
		if IsObject(dbChild)
			dbChild:setscope(SCOPE_BOTH, aKey )
		endif
		pnScope	:= 1

	elseif (nPos := at("@param?", cRelation)) > 0
		// nur mit SQL, daher auch nur mit Tabellenobjekten möglich
		// bezeichnung@param:rec_id=4711&wert=klar
		cRelation:= subs(cRelation, nPos+7 )
		aKey     := _aStrExtract(cRelation, "&")
		iCnt		:= len( aKey)
		if dbChild:IsDerivedfrom("dsAceQTable")
			// ADS arbeitet mit named Parameter, deswegen immer ein Pärchen: {name,wert}
			for i := 1 to iCnt
				if ";" $ aKey[i]
					aTmp	:= _aStrExtract(aKey[i], ";" )
					dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
				elseif ":" $ aKey[i]
					aTmp	:= _aStrExtract(aKey[i], ":" )
					dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
				elseif "=" $ aKey[i]
					aTmp	:= _aStrExtract(aKey[i], "=" )
					dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
				endif
			next
			dbChild:refreshSql(TRUE)

		elseif dbChild:IsDerivedfrom("dsPQselect")
			// bezeichnung@param:4711&klar
			// PostgreSQL arbeitet mit nummerierten Parametern, keine Nummer darf fehlen, keine darf doppelt erscheinen
			// deswegen werden immer alle Parameter in der richtigen Reihenfolge definiert
			aTmp	:= {}
			for i := 1 to iCnt
				aadd( aTmp, dbParent:fieldget(aKey[i]))
			next
			dbChild:execute(, aTmp)
		endif

#ifdef _XCLASS
		// only for backward compatibility
	elseif left(cRelation,1 ) = "&"
		bKey	:= &("{|o,dbP,dbC| " + subs(cRelation,2) +"}")
		aKey	:= eval( bKey, self, dbParent, dbChild )
		if aKey != NIL
			dbChild:setscope(, aKey )
			pnScope	:= 1
		endif

	elseif left(cRelation,1 ) $ "<;"
		aKey     := _aStrExtract(subs(cRelation,2), ";")
		aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, TRUE )
		if len(aKey) == 1
			aKey	:= aKey[1]
		endif
		dbChild:setscope(, aKey )
		pnScope	:= 1

	elseif (nPos := at("<", cRelation)) > 0
		aKey     := _aStrExtract(subs(cRelation,nPos+1), ";")
		if IsObject(dbParent)
			aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, TRUE )
		else
			aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := (dbParent)->(fieldget(a)))},,, TRUE )
		endif
		if len(aKey) == 1
			aKey	:= aKey[1]
		endif
		if IsObject(dbChild)
			dbChild:setscope(SCOPE_BOTH, aKey )
		else
			(dbChild)->(dbSetScope(SCOPE_BOTH, aKey))
		endif
		pnScope	:= 1

	elseif (nPos := at("$", cRelation)) > 0
		aKey     := _aStrExtract(subs(cRelation,nPos+1), "$")
		iCnt	:= len( aKey)
		for i := 1 to iCnt
			if ";" $ aKey[i]
				aTmp	:= _aStrExtract(aKey[i], ";" )
				dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
			elseif ":" $ aKey[i]
				aTmp	:= aStrExtract(aKey[i], ":" )
				dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
			else
				dbChild:SqlConn():setparam( aKey[i], dbParent:fieldget(aKey[i]))
			endif
		next
		dbChild:refreshSql()

	elseif ";" $ cRelation
		aKey     := _aStrExtract(cRelation, ";")
		aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, TRUE )
		if len(aKey) == 1
			aKey	:= aKey[1]
		endif
		dbChild:setscope(, aKey )
		pnScope	:= 1

#endif

	endif
RETURN self

/*============================================================================
 $Method:	PrintLabel(nQuantity, lJobOpen)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nQuantity
 $Argument:     lJobOpen
 $Return:	nError
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:PrintLabel(nQuantity, lJobOpen)
	LOCAL nPos	:= 0

	if nQuantity = NIL
		nQuantity	:= coalesce(::_nQuantity,1)
	endif

	::_Synchronize( 1)
	::datalink(1, 1)
	do while ::_nError == 0 .and. nPos++ < nQuantity
      DllExecuteCall( ::templateDefineFieldExt,::hJob,  "Number" ,var2char(nPos)   ,LL_NUMERIC, 0 )
		::_nError	:= LlPrint(::hJob)
		LlPrintSetBoxText(::hJob, ::_cPrintText, nPos / nQuantity * 100 )
	enddo
	if empty(lJobOpen)
		LlPrintEnd(::hJob,0)
	endif
RETURN ::_nError

/*============================================================================
 $Method:	  Close()
 $Author:	  Marcus Herz
 $Description:   Printjob beenden, Ident mit destroy
 $Argument:	None
 $Return:	  self
 $See Also:
==============================================================================*/
METHOD dsListLabel:Destroy()
	::DbContainer:destroy()

	if !empty(::_hDevmode)
		LocalFree( ::_hDevmode)
	endif

	::templateDefineFieldExt		:= NIL
	::templateDefineVariableExt	:= NIL

	::_DataObject	:= NIL
	::_nStatus		:= XBP_STAT_INIT
	if IsNumber(::hJob) .and. ::hJob > 0                                             // ::hJob kann auch NIL sein!!!
		LlJobClose(::hJob)
	endif
	::hJob			:= NIL
RETURN self

/*============================================================================
 $Method:	getSelect(cSymbol)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    cSymbol
 $Return:	nRet
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:getSelect(cSymbol)
	if empty(cSymbol)
		RETURN NIL
	elseif IsNumber(cSymbol)
		RETURN cSymbol
	elseif IsObject(cSymbol)
		RETURN cSymbol
	endif
RETURN ::GetDbContainer(cSymbol)

/*============================================================================
 $Method:	EnableDebug(xSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:EnableDebug(xSet)
	LOCAL nDebug
	if IsNumber(xSet)
		nDebug   	:= xSet
	elseif IsLogical(xSet)
		if xSet
			nDebug	:= LL_DEBUG_CMBTLL
		else
			nDebug	:= 0
		endif
	endif
	LlSetDebug( nDebug)
RETURN self

/*============================================================================
 $Method:	SetProperty(cReport, nProject, cTitle )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument: cReport
 $Argument: nProject
 $Argument: cTitle
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SetProperty(cReport, nProject, cTitle )
	LOCAL cTmp
	LOCAL i, iCnt

	if nProject != NIL
		::_nProject	:= nProject
	endif
	if IsCharacter(cReport )                                                           // diesen Report auswählen
		iCnt	:= len( ::_aPath)
		for i := 1 to iCnt
			if file( _Fullpath( cReport, ::_aPath[i]))
				::cReport	:= _Fullpath( cReport, ::_aPath[i] )
				exit
			endif
		next
		if empty(::cReport)
			iCnt	:= len( ::__aDefaultPath)
			for i := 1 to iCnt
				if file( _Fullpath( cReport, ::__aDefaultPath[i]))
					::cReport	:= _Fullpath( cReport, ::__aDefaultPath[i] )
					exit
				endif
			next
		endif

	elseif !empty( ::hJob )
		if !empty(::_aPath)
			curdir(::_aPath[1])
		elseif !Empty(::__aDefaultPath)
			curdir(::__aDefaultPath[1])
		endif
		::cReport	:= replicate(chr(0),255)
		::_nError	:= LlSelectFileDlgTitleEx( ::hJob, ::hWND, coalesce( cTitle, "Select file"), ::_nProject, @::cReport, 255)
		if ::_nError <> 0
			::GetErrorText(::_nError)
		endif
		::cReport	:= _trim0(::cReport)
	endif

	if nProject == NIL .and. !empty( ::cReport)
		cTmp	:= upper( right(::cReport,3))

		if cTmp = "CRD"
			::_nProject	:= LL_PROJECT_CARD
		elseif cTmp = "LST"
			::_nProject	:= LL_PROJECT_LIST
		elseif cTmp = "LBL"
			::_nProject	:= LL_PROJECT_LABEL
		endif
	endif
RETURN self

/*============================================================================
 $Method:	Connect([nSelect/cAlias/aArray,dboTable])
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nSelect
 $Argument:    cAlias
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Connect(nSelect)
	if IsObject(nSelect) .or. IsArray(nSelect)
		::nSelect   := nSelect

	else
		if pcount() > 0
			if IsCharacter(nSelect)
				nSelect   := select(nSelect)
			endif
			::nSelect   := nSelect
		else
			::nSelect   := Select()
		endif
	endif
RETURN self

//=========================================
METHOD dsListLabel:_PrintStart()
	if ::_nBoxType >= 0
		::_nError   := LlPrintWithBoxStart(::hJob,	;
			::_nProject,;
			::cReport,;
			::_nPrintOption,;
			::_nBoxType,;
			::hWND,;
			::cTitle )
	else
		::_nError   := LlPrintStart(::hJob,;
			::_nProject,;
			::cReport,;
			::_nPrintOption )
	endif
	if ::_nError == 0
		::_nStatus   := XBP_STAT_CREATE

	elseif ::_nError == LL_ERR_USER_ABORTED
		// quit, no error
		::_nStatus   := XBP_STAT_INIT
		::GetErrorText(::_nError)

	else
		::_nStatus   := XBP_STAT_FAILURE
		::_RaiseError(::_nError, ::cReport, "LlPrint[WithBox]Start()" )
	endif
RETURN ::_nError == 0

//=========================================
METHOD dsListLabel:_SetPrinter(cPrinter)
	if empty( cPrinter)
		cPrinter   := ::_cPrinter
	endif
	if !empty( cPrinter) .and. !empty(::hJob)
		LlSetPrinterInPrinterFile(::hJob, ::_nProject, ::cReport, -1, cPrinter, 0)
	endif
RETURN self

//=========================================
METHOD dsListLabel:SetDevMode(cProperty, xValue, nIndex )
	LOCAL nError
	if empty(::_hDevMode)
		nError	:= ::_InitDevMode(nIndex)
	endif
   if ascan( ::oDevmode:classdescribe(3), lower(cProperty)) > 0
		::oDevMode:&(cProperty)	:= xValue
		nError	:= LlSetPrinterInPrinterFile(::hJob, ::_nProject, ::cReport, nIndex, , ::_hDevmode)
   else
   	nError	:= -1
   endif
RETURN nError

//=========================================
METHOD dsListLabel:GetDevMode(cProperty)
	if empty(::_hDevMode)
		::_InitDevMode()
	endif
   if ascan( ::oDevmode:classdescribe(3), lower(cProperty)) > 0
		RETURN ::oDevMode:&(cProperty)
	endif
RETURN NIL

/*============================================================================
 $Method:	GetPrinter()
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:
 $Return:	cPrinter
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:GetPrinter()
	LOCAL nLen		:= 200
	LOCAL cPrinter	:= space(nLen)
	LOCAL cPort		:= space(20)
	LlPrintGetPrinterInfo(::hJob, @cPrinter, nLen, @cPort, 20 )
	::_cPrinter   := _Trim0(cPrinter)
RETURN ::_cPrinter

/*============================================================================
 $Method:	SetDefaultPrinter()
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    None
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SetDefaultPrinter()
	if !empty(::hJob)
		LlSetPrinterToDefault(::hJob, ::_nProject, ::cReport)
	endif
RETURN self

//=========================================
METHOD dsListLabel:SetTitle(xSet)
	if IsCharacter(xSet)
		::cTitle   := xSet
	endif
RETURN self

//=========================================
METHOD dsListLabel:PrintOption(nPrtMode)
	local nOMode	:= ::_nPrintOption
	if IsNumber(nPrtMode)
		::_nPrintOption	:= nPrtMode
	endif
RETURN nOMode

/*============================================================================
 $Method:	SetExport(xSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Return:	::_nPrintOption
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SetExport(xSet)
	if IsLogical(xSet)
		if xSet
			::_nPrintOption := LL_PRINT_EXPORT
		else
			::_nPrintOption := LL_PRINT_NORMAL
		endif
	endif
RETURN ::_nPrintOption == LL_PRINT_EXPORT

/*============================================================================
 $Method:	SetPreView(xSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Return:	::_nPrintOption == LL_PRINT_PREVIEW
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SetPreView(xSet)
	if IsLogical(xSet)
		if xSet
			::_nPrintOption := LL_PRINT_PREVIEW
		else
			::_nPrintOption := LL_PRINT_NORMAL
		endif
	endif
RETURN ::_nPrintOption == LL_PRINT_PREVIEW

/*============================================================================
 $Method:	Report(cReport)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument: cReport
 $Return:	::cReport
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Report(cReport)
	LOCAL i, iCnt
	if IsCharacter(cReport)
      ::cReport   := cReport
		if !file(cReport)
			iCnt	:= len( ::_aPath)
			for i := 1 to iCnt
				if file( _Fullpath( cReport, ::_aPath[i] ))
					::cReport	:= _Fullpath( cReport, ::_aPath[i] )
					exit
				endif
			next
      endif
		if !file(::cReport)
			iCnt	:= len( ::__aDefaultPath)
			for i := 1 to iCnt
				if file( _Fullpath( cReport, ::__aDefaultPath[i] ))
					::cReport	:= _Fullpath( cReport, ::__aDefaultPath[i] )
					exit
				endif
			next
		endif

		// autodetect Projekttype
		cReport	:= upper( right(::cReport,3))
		if cReport = "CRD"
			::_nProject	:= LL_PROJECT_CARD
		elseif cReport = "LST"
			::_nProject	:= LL_PROJECT_LIST
		elseif cReport = "LBL"
			::_nProject	:= LL_PROJECT_LABEL
		endif
	endif
RETURN ::cReport

//=========================================
METHOD dsListLabel:Stream2Report(cStream, nProject)
	LOCAL hHandle

	if IsNumber( nProject )
		::_nProject   := nProject
	endif

	::cReport	:= space(255)
	GetTempFileName( ::__cTempPath, "LLT", 0, @::cReport)
	::cReport	:= alltrim(::cReport)

	hHandle	:= fopen(::cReport, FO_WRITE)
	fwrite(hHandle, cStream)
	fclose(hHandle)

	::_lStreamMode	:= TRUE

RETURN self

//=========================================
METHOD dsListLabel:Report2Stream(pnError)
	LOCAL hHandle
	LOCAL nLen
	LOCAL cStream
	pnError  := 0
	hHandle	:= fopen(::cReport, FO_READ)
	if hHandle < 0
		pnError	:= ferror()
		RETURN ""
	endif
	nLen	:= FSeek(hHandle, 0, FS_END )
	FSeek(hHandle, 0, FS_SET )
	cStream	:= freadstr(hHandle, nLen )
	fclose(hHandle)
RETURN cStream

/*============================================================================
 $Method:	SelectOptions(xSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Return:	xRet
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SelectOptions(xSet)
	LOCAL xRet:=::_lOptions
	if IsLogical(xSet)
		::_lOptions := xSet
	endif
RETURN xRet

/*============================================================================
 $Method:	Printer(xSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Return:	xRet
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Printer(xSet)
	LOCAL xRet:=::_cPrinter
	if IsCharacter(xSet) .and. !empty(xSet)
		::_cPrinter := xSet
		::_lOptions := FALSE

	elseif pcount() == 1 .and. empty(xSet)
		::_cPrinter := NIL
		::_lOptions := TRUE
	endif
	if !empty( ::_cPrinter) .and. !empty(::hJob)
		LlSetPrinterInPrinterFile(::hJob, ::_nProject, ::cReport, -1, ::_cPrinter, 0)
	endif
RETURN xRet

/*============================================================================
 $Method:	Datalink(nMode, [nRecno], [reserved] )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nMode
 $Argument:    nRecno
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Datalink(nMode, nRecno)
	LOCAL i, iCnt
	LOCAL aDb
	LOCAL nPos, nPos2
	LOCAL dbTable
	LOCAL cField, cTable
	LOCAL lRet

	nMode   	  := coalesce(nMode, 0)

	if IsBlock(::datalink) .and. !::_lDesign
		if nMode == 0
			lRet	:= eval(::datalink, self, nMode, nRecno)
		else
			lRet	:= eval(::datalink, self, nMode, nRecno)
		endif
		if !IsLogic(lRet) .and. lRet
			RETURN self
		endif

	elseif ::_lOptimize .and. !::_lDesign
		if nMode == 0
			iCnt := len( ::_aUsedFields)
			// nur mit
			for i := 1 to iCnt
				dbTable	:= NIL
				if (nPos := rat(".", ::_aUsedFields[i])) > 0
					nPos2 	:= rat(".", ::_aUsedFields[i], nPos -1)
					cTable	:= subs(::_aUsedFields[i], nPos2+1, nPos - nPos2 - 1)
					dbTable	:= ::GetDbContainer(cTable, FALSE )
					cField	:= subs(::_aUsedFields[i], nPos + 1)
				else
					cTable	:= ""
					cField	:= ::_aUsedFields[i]
				endif
				if IsObject( dbTable ) .and. dbTable:IsField(cField)
					::SetValue( nMode, ::_aUsedFields[i], dbTable:fieldget(cField))

				elseif IsNumber( dbTable ) .and. (dbTable)->(Fieldpos(cField)) > 0
					::SetValue( nMode, ::_aUsedFields[i], (dbTable)->(fieldget(Fieldpos(cField))))

				elseif Fieldpos(cField) > 0
					::SetValue( nMode, ::_aUsedFields[i], fieldget(Fieldpos(cField)))
				endif
			next
		else
			iCnt := len( ::_aUsedVariables)
			for i := 1 to iCnt
				dbTable	:= NIL
				// ::_aUsedVariables[i] => "AUFTRAG.ARTIKEL.ARTBEZ"
				if (nPos := rat(".", ::_aUsedVariables[i])) > 0
					nPos2 := rat(".", ::_aUsedVariables[i], nPos -1)
					cTable  := subs(::_aUsedVariables[i], nPos2+1, nPos - nPos2 - 1)
					dbTable := ::GetDbContainer(cTable, FALSE )
					cField  := subs(::_aUsedVariables[i], nPos + 1)
				else
					cTable	:= ""
					cField	:= ::_aUsedFields[i]
				endif

				if IsObject( dbTable ) .and. dbTable:IsField(cField)
					::SetValue( nMode, ::_aUsedFields[i], dbTable:fieldget(cField))

				elseif IsNumber( dbTable ) .and. (dbTable)->(Fieldpos(cField)) > 0
					::SetValue( nMode, ::_aUsedFields[i], (dbTable)->(fieldget(Fieldpos(cField))))

				elseif Fieldpos(cField) > 0
					::SetValue( nMode, ::_aUsedFields[i], fieldget(Fieldpos(cField)))
				endif
			next
		endif
	else
		if nMode == 0
			aDb   := ::_dbFields
		else
			aDb   := ::_dbVariables
		endif

		iCnt   := len( aDb)
		for i := 1 to iCnt
			if aDb[i] == NIL
				aremove(aDb, i)
				iCnt--
				loop
			endif
			::_datalink( nMode, aDb[i,__SELECT], aDb[i,__LLDESC], aDb[i,__STRUCT], nRecno)
		next
	endif
	if nMode == 0
		::_VarLink(nMode, ::_aField, nRecno )
	else
		::_VarLink(nMode, ::_aVar, nRecno )
	endif

RETURN self

//=========================================
METHOD dsListLabel:DatalinkTable(nMode, xServer, nRec )
	LOCAL cDesigner
	LOCAL aField, aList
	LOCAL nPos	:= 0

	if nMode == 0
		aList	:= ::_dbFields
	else
		aList	:= ::_dbVariables
	endif

	if IsCharacter(xServer)                                                          // 1. Parameter von :datasetField
		nPos := ascan(aList, {|a| a[__SYMBOL] == xServer })
		if nPos > 0
			aField	:= aList[nPos,__STRUCT]
			cDesigner:= aList[nPos,__LLDESC]
			xServer	:= aList[nPos,__SELECT]
		endif
	else                                                                          // Server oder select bereich, 1. Parameter von :datasetField
		nPos := ascan(aList, {|a| a[__SELECT] == xServer })
		if nPos > 0
			aField	:= aList[nPos,__STRUCT]
			cDesigner:= aList[nPos,__LLDESC]
		endif
	endif
	if nPos == 0
		RETURN self
	endif
RETURN ::_datalink(nMode, xServer, cDesigner, aField, nRec)

/*============================================================================
 $Method:      SetValue(nMode, cName, xValue, nLLType))
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    nMode
 $Argument:     cName
 $Argument:     xValue
 $Return:      self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SetValue(nMode, cName, xValue, nLLType)
	LOCAL cStr
	LOCAL nLL	:= nLLType

	if xValue == NIL
		RETURN FALSE
	endif

	if valtype(xValue) = "N"
		// var2lchar setzt 2 decimalen [set(_SET_DECIMALS)] und ignoriert die Genauigkeit der Zahl
		nLL   := coalesce(nLL, LL_NUMERIC)
		cStr  := ntrim(xValue)
		if xValue == int(xValue)
			nLL   := LL_NUMERIC_INTEGER
		endif

	elseif valtype(xValue) = "D"
		nLL   := coalesce(nLL, LL_DATE_YYYYMMDD)
		if !empty( xValue)
			cStr	:= dtos(xValue)
		else
			cStr	:= '(NULL)'
		endif

	elseif valtype(xValue) = "L"
		nLL	:= coalesce(nLL, LL_BOOLEAN)
		cStr	:= if(xValue, "T","F")

	else
		nLL   := coalesce(nLL, LL_TEXT)
		if Set( _SET_CHARSET ) == CHARSET_OEM
			cStr  := alltrim(ConvtoAnsiCP(xValue))
		else
			cStr  := alltrim(xValue)
		endif

		if empty( cStr)
			cStr	:= " "
		elseif left(cStr,5) = "{\rtf"
			nLL   := coalesce(nLL, LL_RTF)
		endif
	endif
	if empty( nMode )
      DllExecuteCall( ::templateDefineFieldExt,::hJob, cName, cStr, nLL, 0 )
	else
      DllExecuteCall( ::templateDefineVariableExt,::hJob, cName, cStr, nLL, 0 )
	endif
RETURN TRUE

//=========================================
METHOD dsListLabel:_datalink(nMode, nSelect, cDesigner, aField, nRecno )
	LOCAL cId
	LOCAL xRet
	LOCAL i, iCnt, nPos
	LOCAL lStruct   	:= FALSE
	LOCAL nSourceType	:= 0

	if IsObject(nSelect)
		if nSelect:IsDerivedfrom("dataobject")
			nSourceType	+= 2
		else
			nSourceType	+= 1
		endif
	elseif IsArray(nSelect)
		nSourceType		+= 4
		if nRecno > len(nSelect)
			RETURN self
		endif
	endif

	DEFAULT cDesigner to ""

	if !IsArray( aField)
		if IsObject(nSelect)
			if IsMethod(nSelect,"dbstruct")
				aField	:= nSelect:dbstruct()
			endif
		elseif !empty(nSelect)
			aField	:= (nSelect)->(dbstruct())
		endif
	endif

	iCnt	:= len( aField)
	if iCnt = 0
		RETURN self
	endif
	lStruct	:= IsArray(aField[1]) .and. len( aField[1]) >= 3                        // stimmt auch bei dataobject

	if !empty(cDesigner) .and. !cDesigner[-1] $ ".:"
		cDesigner	+= "."
	endif

	for i := 1 to iCnt
		if lStruct
			cId   := aField[i,1]
			if !empty(::_cIgnoreField) .and. like( ::_cIgnoreField ,aField[i,1])
				loop
			endif
			if nSourceType == 0
				xRet	:= if(IsObject(nSelect), nSelect:fieldget(i),(nSelect)->(fieldget(i)))
			elseif nSourceType == 1

				xRet	:= if(IsObject(nSelect), nSelect:fieldget(i),(nSelect)->(fieldget(i)))
			else
				xRet	:= nSelect:&cId.
			endif
		else
			if !IsArray(aField[i])
				cId	:= aField[i]
				if nSourceType == 4                                                     // array mit dataobject
					xRet	:= nSelect[nRecno]:&cId.
				else
					if nSourceType == 0
						nPos	:= (nSelect)->(fieldpos(aField[i]))
						xRet	:= (nSelect)->(fieldget(nPos))

					elseif nSourceType == 1
						xRet	:= nSelect:fieldget(aField[i])

					elseif nSourceType == 2
						xRet	:= nSelect:&cId.
					endif
				endif

			elseif IsBlock(aField[i,2])
				cId	:= aField[i,1]
				xRet	:= eval(aField[i,2], self, nSelect, nRecno )

			else
				cId	:= aField[i,1]
				if nSourceType == 0
					xRet	:= (nSelect)->(fieldget(fieldpos(aField[i,2])))
				elseif nSourceType == 1
					xRet	:= nSelect:fieldget(aField[i,2])
				endif
			endif
		endif

		if xRet == NIL
			loop
		endif

		::SetValue(nMode, cDesigner + cId, xRet)

	next
RETURN self

//=========================================
METHOD dsListLabel:_Varlink( nMode, aVar, nRecno )
	LOCAL xRet
	LOCAL i, iCnt

	iCnt	:= len( aVar)

	for i := 1 to iCnt
		if IsBlock(aVar[i,2])
			xRet	:= eval( aVar[i,2], self, ::nSelect, nRecno  )
		else
			xRet	:= aVar[i,2]
		endif

		if xRet == NIL
			loop
		endif

		::SetValue(nMode, aVar[i,1], xRet)
	next
RETURN self

/*============================================================================
 $Method:	DefineField(xSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:DefineField(cVar, xValue, nLLType)
	LOCAL nPos   := 0

	cVar	:= alltrim(cVar)
	if ::__toUpper
		cVar	:= upper(cVar)
	endif
	if (nPos := ascan(::_aField, {|x| x[1] == cVar})) > 0
		::_aField[nPos, 2]   := xValue
		::_aField[nPos, 3]   := nLLType
	else
		aadd( ::_aField, {cVar, xValue, nLLType})
	endif
RETURN self

/*============================================================================
 $Method:	DefineVariable(xSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:DefineVariable(cVar, xValue, nLLType)
	LOCAL nPos   := 0

	if ::__toUpper
		cVar	:= upper(cVar)
	endif
	if (nPos := ascan(::_aVar, {|x| x[1] == cVar})) > 0
		::_aVar[nPos, 2]   := xValue
		::_aVar[nPos, 3]   := nLLType
	else
		aadd( ::_aVar, {cVar, xValue, nLLType})
	endif
RETURN self

/*============================================================================
 $Method:	DataSetVariable(nSelect, cSymbol, cDesigner ,aField )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nSelect
 $Argument:     cSymbol
 $Argument:     cDesigner
 $Argument:     aField
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:DataSetVariable(nSelect, cSymbol, cDesigner ,aField )
	LOCAL nPos

	if IsArray(nSelect)
		cSymbol	:= coalesce( cSymbol,"")

	elseif IsObject(nSelect)
		if IsMembervar(nSelect, "Alias")
			cSymbol	:= coalesce( cSymbol, nSelect:Alias, "")

		else
			cSymbol	:= coalesce( cSymbol, "")
		endif
	else
		nSelect	:= coalesce( nSelect, Select())
		cSymbol	:= coalesce( cSymbol,"")
	endif
	cSymbol	:= alltrim(cSymbol)
	cDesigner  := coalesce( cDesigner, cSymbol )
	if ::__toUpper
		cSymbol	:= upper(cSymbol)
	endif

	nPos := ascan(::_dbVariables, {|a| a[2] == cSymbol })
	if nPos == 0 .and. !empty(nSelect )
		if IsArray(nSelect)
			if len(nSelect) > 0 .and. nSelect[1]:IsDerivedfrom( "dataobject")
				aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
				aeval( aField, {|a| a := a[1]},,,TRUE)
				aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner, aField })
			endif

		elseif IsObject(nSelect)
			if nSelect:IsDerivedfrom("dataobject")
				aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner ,;
					coalesce(aField, nSelect:classdescribe(CLASS_DESCR_MEMBERS)), cSymbol})
			else
				if empty(aField)
					if IsMethod(nSelect,"dbstruct")
						aField	:= nSelect:dbstruct()
					endif
				endif
				if IsMemberVar(nSelect, "alias" )
					aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner ,aField, nSelect:alias })
				else
					aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner ,aField, cSymbol})
				endif
			endif
		else
			aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner ,;
				coalesce(aField, (nSelect)->(dbstruct())), alias(nSelect)})
		endif

	elseif nPos > 0
		if nSelect == NIL
			aremove(::_dbVariables, nPos )
		else
			::_dbVariables[nPos,__SELECT]	:= nSelect
			::_dbVariables[nPos,__SYMBOL]	:= cSymbol
			::_dbVariables[nPos,__LLDESC]	:= cDesigner
			if IsArray(nSelect)
				if len(nSelect) > 0 .and. nSelect[1]:IsDerivedfrom("dataobject")
					aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
					aeval( aField, {|a| a := a[1]},,,TRUE)
					::_dbVariables[nPos,__STRUCT]	:= aField
				endif
			elseif IsObject(nSelect)
				if nSelect:IsDerivedfrom("dataobject")
					::_dbVariables[nPos,__STRUCT]	:= nSelect:classdescribe(CLASS_DESCR_MEMBERS)
					::_dbVariables[nPos,__ALIAS ]	:= cSymbol

				else
					if empty(aField)
						if IsMethod(nSelect,"dbstruct")
							aField	:= nSelect:dbstruct()
						endif
					endif
					::_dbVariables[nPos,__STRUCT]	:= aField
					if IsMemberVar(nSelect, "alias" )
						::_dbVariables[nPos,__ALIAS ]	:= nSelect:alias
					else
						::_dbVariables[nPos,__ALIAS ]	:= ""
					endif
				endif
			else
				::_dbVariables[nPos,__STRUCT]	:= coalesce(aField, (nSelect)->(dbstruct()))
				::_dbVariables[nPos,__ALIAS ]	:= alias(nSelect)
			endif
		endif
	endif
	::AddDbContainer( cSymbol, nSelect )
RETURN self

/*============================================================================
 $Method:	DataSetField(nSelect, cSymbol, cDesigner ,aField, nRekursiv )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nSelect
 $Argument:     cSymbol
 $Argument:     cDesigner
 $Argument:     aField
 $Argument:     nRekursiv
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:DataSetField(nSelect, cSymbol, cDesigner ,aField, nRekursiv )
	LOCAL nPos

	if nSelect == NIL	 .and. pCount() == 1                                           // für abmelden
		// NIL mit xbase ist aktuelle workarea !!!
		cSymbol	:= alltrim(cSymbol)
		if ::__toUpper
			cSymbol	:= upper(cSymbol)
		endif
		nPos := ascan(::_dbFields, {|a| a[__SYMBOL] == cSymbol})
		if nPos > 0
			aRemove(::_dbFields, nPos )
		endif
		RETURN self
	endif

	if IsArray(nSelect)
		cSymbol	:= coalesce( cSymbol,"")

	elseif IsObject(nSelect)
		nSelect	:= nSelect
		if IsMembervar(nSelect, "Alias")
			cSymbol	:= coalesce( cSymbol, nSelect:Alias, "")
		else
			cSymbol	:= coalesce( cSymbol, "")
		endif
	else
		nSelect	:= coalesce( nSelect,  Select())
		cSymbol	:= coalesce( cSymbol,  "")
	endif
	cSymbol	:= alltrim(cSymbol)
	cDesigner	:= coalesce( cDesigner, cSymbol )
	if ::__toUpper
		cSymbol	:= upper(cSymbol)
	endif
	nRekursiv	:= coalesce( nRekursiv, -99)

	nPos := ascan(::_dbFields, {|a| a[2] == cSymbol })
	if nPos == 0 .and. !empty(nSelect )
		if IsArray(nSelect)
			if len(nSelect) > 0 .and. nSelect[1]:IsDerivedfrom( "dataobject")
				aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
				aeval( aField, {|a| a := a[1]},,,TRUE)
				aadd( ::_dbFields, {nSelect, cSymbol, cDesigner,;
					aField, -1, nRekursiv})
			endif
		elseif IsObject(nSelect)
			if empty(aField)
				if IsMethod(nSelect,"dbstruct")
					aField	:= nSelect:dbstruct()
				endif
			endif
			if IsMembervar(nSelect, "Alias")
				aadd( ::_dbFields, {nSelect, cSymbol, cDesigner,aField, nSelect:alias, nRekursiv})
			else
				aadd( ::_dbFields, {nSelect, cSymbol, cDesigner,aField, cSymbol, nRekursiv})
			endif
		else
			aadd( ::_dbFields, {nSelect, cSymbol, cDesigner,;
				coalesce(aField, (nSelect)->(dbstruct())), alias(nSelect), nRekursiv})
		endif

	elseif nPos > 0
		::_dbFields[nPos,__SELECT]	:= nSelect
		::_dbFields[nPos,__SYMBOL]	:= cSymbol
		::_dbFields[nPos,__LLDESC]	:= cDesigner
		if IsArray(nSelect)
			if len(nSelect) > 0 .and. nSelect[1]:IsDerivedfrom("dataobject")
				aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
				aeval( aField, {|a| a := a[1]},,,TRUE)
				::_dbFields[nPos,__STRUCT]	:= aField
			endif
		elseif IsObject(nSelect)
			::_dbFields[nPos,__STRUCT]	:= coalesce(aField, nSelect:dbstruct())
			if IsMembervar(nSelect, "Alias")
				::_dbFields[nPos,__ALIAS ]	:= nSelect:alias
			else
				::_dbFields[nPos,__ALIAS ]	:= ""
			endif
		else
			::_dbFields[nPos,__STRUCT]	:= coalesce(aField, (nSelect)->(dbstruct()))
			::_dbFields[nPos,__ALIAS ]	:= alias(nSelect)
		endif
		::_dbFields[nPos,__LEVEL ]	:= nRekursiv
	endif

	::AddDbContainer( cSymbol, nSelect )

RETURN self

/*============================================================================
 $Method:      DataSetStruct( cSymbol, aStruct)
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    cSymbol
 $Argument:     aStruct
 $Return:      self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:DataSetStruct( cSymbol, aStruct)
	LOCAL nPos
	cSymbol	:= alltrim(cSymbol)
	if ::__toUpper
		cSymbol	:= upper(cSymbol)
	endif
	nPos := ascan(::_dbFields, {|a| a[__SYMBOL] == cSymbol })
	if nPos > 0
		::_dbFields[nPos,__STRUCT]	:= aStruct
	endif
	nPos := ascan(::_dbVariables, {|a| a[__SYMBOL] == cSymbol })
	if nPos > 0
		::_dbVariables[nPos,__STRUCT]	:= aStruct
	endif
RETURN self

/*============================================================================
 $Method:	AddTable(nSelect, lMaster)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nSelect
 $Argument:     lMaster
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:AddTable(cSymbol, lMaster)
	LOCAL i, iCnt
	::_lSubReport   := TRUE

	if IsArray(cSymbol)                                                              // clone
		iCnt   := len(cSymbol )
		for i := 1 to iCnt
			LlDbAddTable(::hJob, cSymbol[i,1])
			if cSymbol[i,2]
				LlDbSetMasterTable(::hJob, cSymbol[i,1])
			endif
		next
	else
		if pcount() = 3                                                                  // abwärtskompatibel
			lMaster	:= pvalue(3)
		elseif !IsLogic(lMaster)
			lMaster	:= FALSE
		endif
		if empty(cSymbol)
			cSymbol	:= alias()
		endif
		cSymbol	:= alltrim(cSymbol)
		if ::__toUpper
			cSymbol	:= upper(cSymbol)
		endif
		LlDbAddTable(::hJob, cSymbol)
		aadd( ::_aAddTable, {cSymbol, !empty(lMaster)})

		if !empty(lMaster)
			LlDbSetMasterTable(::hJob, cSymbol)
			::_cMaster	:= cSymbol
		endif
		if len( ::_aAddTable) == 1
			LlDbAddTable(::hJob, "LLStaticTable")
			aadd( ::_aAddTable, {"LLStaticTable", FALSE })
		endif
	endif
RETURN self

/*============================================================================
 $Method:	AddTableEx(nSelect, cSymbol, lMaster, nOptions)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nSelect
 $Argument:     cSymbol
 $Argument:     lMaster
 $Argument:     nOptions
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:AddTableEx(cSymbol, cDescription, nOptions, lMaster)
	::_lSubReport   := TRUE

	if empty(cSymbol)
		cSymbol	:= alias()
	endif
	if empty(cDescription)
		cDescription	:= cSymbol
	endif
	cSymbol	:= alltrim(cSymbol)
	if ::__toUpper
		cSymbol	:= upper(cSymbol)
	endif

	LlDbAddTableEx(::hJob, cSymbol, cDescription, nOptions)
	aadd( ::_aAddTable, {cSymbol, cDescription, !empty(lMaster), nOptions})

	if !empty(lMaster)
		LlDbSetMasterTable(::hJob, cSymbol)
		::_cMaster	:= cSymbol
	endif
	if len( ::_aAddTable) == 1
		LlDbAddTable(::hJob, "LLStaticTable", "")
		aadd( ::_aAddTable, {"LLStaticTable", "", FALSE })
	endif
RETURN self

/*============================================================================
 $Method:	AddTableRelation(cChild, cParent, cRelation, cDescription)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    cChild
 $Argument:     cParent
 $Argument:     cRelation
 $Argument:     cDescription
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:AddTableRelation(cChild, cParent, cRelation, cDescription)
	LOCAL i, iCnt
	if IsArray(cChild)                                                               // clone
		iCnt   := len(cChild )
		for i := 1 to iCnt
			if len(cChild[i]) >= 6
				LlDbAddTableRelation( ::hJob, cChild[i,1], cChild[i,2], cChild[i,3], cChild[i,4], cChild[i,5], cChild[i,6])
			else
				LlDbAddTableRelation( ::hJob, cChild[i,1], cChild[i,2], cChild[i,3], cChild[i,4])
			endif
		next
	else
		if ::__toUpper
			cChild	:= upper(cChild)
			cParent	:= upper(cParent)
			cRelation:= upper(cRelation)
		endif

		aadd( ::_aAddTableRelation, {cChild, cParent, cRelation, coalesce(cDescription,"")})
		LlDbAddTableRelation( ::hJob, cChild, cParent, cRelation, coalesce(cDescription,""))
	endif
RETURN self

/*============================================================================
 $Method:	AddTableRelationEx(cChild, cParent, cRelation, cDescription, cChildKey, cParentKey)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    cChild
 $Argument:     cParent
 $Argument:     cRelation
 $Argument:     cDescription
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:AddTableRelationEx(cChild, cParent, cRelation, cDescription, cChildKey, cParentKey)
	if ::__toUpper
		cChild	:= upper(cChild)
		cParent	:= upper(cParent)
		cRelation:= upper(cRelation)
	endif
	aadd( ::_aAddTableRelation, {cChild, cParent, cRelation, coalesce(cDescription,"", cChildKey, cParentKey)})
	LlDbAddTableRelationEx( ::hJob, cChild, cParent, cRelation, coalesce(cDescription,""), cChildKey, cParentKey)
RETURN self

/*============================================================================
 $Method:      AddTableSortOrderEx(cTable, cSortId, cSortBez, cSortField)
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    cTable
 $Argument:     cSortId
 $Argument:     cSortBez
 $Argument:     cSortField
 $Return:      self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:AddTableSortOrderEx(cTable, cSortId, cSortBez, cSortField)
	if ::__toUpper
		cTable	:= upper(cTable)
	endif
	LlDbAddTableSortOrderEx( ::hJob, cTable, cSortId, cSortBez, cSortField)
RETURN self

/*============================================================================
 $Method:	AddSync(xSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:AddSync(xSet)
	if IsBlock(xSet)
		aadd( ::_aSync, xSet )
	elseif IsArray(xSet)
		::_aSync   := xSet                                                            // clone
	endif
RETURN self

/*============================================================================
 $Method:	ExportFile(cFile)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    cFile
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:ExportFile(cFile)
	LOCAL nPos1	:= 0, nPos2
	LOCAL cTmp1, cTmp2

	if (nPos1 := at("%", cFile )) > 0
		cTmp1	:= subs(cFile, nPos1)
		nPos2 := at("%", cTmp1, 2 )
		cTmp2	:= upper(left(cTmp1, nPos2))

		cTmp2   := strtran( cTmp2, "%TEMP%", ::__cTempPath)
		cTmp2   := strtran( cTmp2, "%EIGENE_DATEIEN%", GetEnv("USERPROFILE") + "\Documents")
		cTmp2   := strtran( cTmp2, "%DOCUMENTS%", GetEnv("USERPROFILE") + "\Documents")
		cTmp2   := strtran( cTmp2, "%USERPROFILE%", GetEnv("USERPROFILE") )
		cFile   := left(cFile,nPos1-1) + cTmp2 + subs(cFile, nPos1 + nPos2 )
	endif
	cFile   := _fullpath(cFile)
	::cOutFile   := cFile
RETURN self

/*============================================================================
 $Method:	SaveAsPreview(cFile, bPrint )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    cFormat
 $Argument:    cFile
 $Argument:     lQuiet
 $Argument:     bPrint
 $Return:	::_nError == 0
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SaveAsPreview( cFile, bPrint )
	LOCAL _nPrintOption  := ::_nPrintOption
	LOCAL nBoxType	:= ::_nBoxType
	LOCAL cExport	:= ::cExportFormat
	LOCAL cReport	:= ::cReport
	LOCAL nPos

	if empty( cFile)
		RETURN FALSE
	endif
	nPos	:= rat("\", cReport)
	if nPos > 0
		cReport	:= Subs(cReport, nPos +1)
	endif
	cReport	:= left(cReport, rat(".", cReport))

	::_nBoxType	:= 0
	::_nPrintOption  := LL_PRINT_EXPORT
	::ExportFormat("PRV")
	llSetOption( ::hJob, LL_OPTION_INCREMENTAL_PREVIEW, FALSE  )
	::ShowExport( FALSE )

	::_nError := ::Print(bPrint)

	ferase( cFile )
	frename(::__cTempPath + cReport + "LL", cFile )

	::_nPrintOption 	:= _nPrintOption
	::_nBoxType			:= nBoxType
	::cExportFormat	:= cExport

RETURN ::_nError == 0

/*============================================================================
 $Method:	SaveAsPdf(cFile, lQuiet, bPrint, cXRechnungXML )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    cFile
 $Argument:     lQuiet
 $Argument:     bPrint
 $Return:	::_nError == 0
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SaveAsPdf(cFile, lQuiet, bPrint)
	LOCAL _nPrintOption  := ::_nPrintOption
	LOCAL nBoxType  := ::_nBoxType
	LOCAL cExport   := ::cExportFormat

	if empty( cFile)
		RETURN FALSE
	endif

	::_nBoxType	:= 0
	::_nPrintOption  := LL_PRINT_EXPORT
	::ExportFormat("PDF")
	::ExportFile(cFile)
	if IsLogical(lQuiet )
		::ShowExport(!lQuiet)
	endif
	if !empty( ::_cZUGFeRDXML) .and. File(::_cZUGFeRDXML)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"PDF.Conformance", "pdfa3b")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"PDF.ZUGFeRDConformanceLevel", "EN 16931")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"PDF.ZUGFeRDVersion", "2.1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"PDF.ZUGFeRDXmlPath", ::_cZUGFeRDXML)
	endif

	::_nError := ::Print(bPrint)

	::_nPrintOption 	:= _nPrintOption
	::_nBoxType			:= nBoxType
	::cExportFormat	:= cExport

RETURN ::_nError == 0

/*============================================================================
 $Method:	SendAsMail(lDialog, cTo, cCC, cBCC, cSubject, cBody, cFile, aAttach, bPrint )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    lDialog
 $Argument:     cTo
 $Argument:     cCC
 $Argument:     cBCC
 $Argument:     cSubject
 $Argument:     cBody
 $Argument:     cFile
 $Argument:     aAttach
 $Argument:     bPrint
 $Return:	lRet
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SendAsMail(lDialog, cTo, cCC, cBCC, cSubject, cBody, cFile, aAttach, bPrint )
	LOCAL i
	LOCAL cAttach   := ""
	LOCAL lRet

	if empty(cFile)
		cFile   := _slashpath(getenv("TEMP")) + "PRT" + strzero(seconds(),8 )+ ".PDF"
	endif

	if empty(cTo) .or. empty(cSubject)
		lDialog   := TRUE
	endif
	ferase(cFile)

	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.SendAsMail"	   , "1" )
	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.ShowDialog"   , if( empty(lDialog), "0", "1"))

	if !empty(cTo)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.To"	   , cTo)
	endif
	if !empty(cCC)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.CC"	   , cCC)
	endif
	if !empty(cBCC)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.BCC"	, cBCC)
	endif
	if !empty(cSubject)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.Subject"   , cSubject )
	endif
	//LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.Provider"	, "XMAPI" )
	// bei rtf text ist anlage teil des body und nicht als attachment ausgewiesen, leider
	if !empty(cBody)
		//LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.Body:application/RTF"	, cBody )
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.Body"	, cBody )
	endif

	if IsArray( aAttach) .and. !empty(aAttach)
		for i := len( aAttach) to 1 step -1
			if file(aAttach[i])
				cAttach += _TAB + aAttach[i]
			endif
		next
		if !empty(cAttach)
			cAttach := subs( cAttach, 2)                                               // 1. tab weg
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.AttachmentList"	, cAttach )
		endif
	else
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.AttachmentList"	, "" )
	endif

	if !empty(::__cSmtpIPAddress)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.Provider"	    		,::__cEmailProvider )
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.ServerAddress",::__cSmtpIPAddress)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.ServerPort"   ,::__nSmtpIPPort)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.User"	   	,::__cSmtpUser)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.Password"     ,::__cSmtpPassword)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.SenderAddress",::__cSmtpSenderAddress)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.SenderName"   ,::__cSmtpSenderName )
	endif

	lRet  := ::SaveAsPdf(cFile, TRUE, bPrint )

	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.SendAsMail", "0" )

RETURN lRet

/*============================================================================
 $Method:	Clear(nMode)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    lAll
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Clear(nMode)
	LOCAL cTmp
	LOCAL nLen

	DEFAULT nMode to 0

	LlDefineFieldStart(::hJob)
	LlDefineVariableStart(::hJob)
	LlDefineSortOrderStart(::hJob)
	LlDbAddTable(::hJob, "", "")

	::_aAddTable	   	:= {}
	::_aAddTableRelation := {}
	::_aField				:= {}
	::_lOptimize  			:= FALSE
	::_aPath					:= {}
	::_aSync					:= {}
	::_aVar					:= aclone(::__aDefaultVar)
	::_cErrorMessage		:= ""
	::_dbFields				:= {}
	::_dbVariables			:= {}
	::_lIsReleased			:= FALSE
	::_lPrepared			:= FALSE
	::_lPrintAtEof			:= FALSE
	::_lSubReport			:= FALSE
	::_nError				:= 0
	::_nFirstpage			:= 1
	::_nLastpage			:= 1
	::_nLastRec				:= 0
	::_nPages				:= 0
	::_nStatus				:= XBP_STAT_INIT

	if 1 $ nMode
		::cOutFile				:= ""
		::cOutPut				:= ""
		::cShowExport			:= "1"                                                         // anzeigen
		::cTitle					:= "Druck"
		::_bConfig				:= ::__bConfig
		::_bPrepare				:= ::__bPrepare
		::_cIgnoreField		:= ::__cIgnoreField
		::_cPrinter				:= ""
		::_lDesign				:= FALSE
		::_lDesignerPreview  := ::__lDesignerPreview
		::_lDesignerPreview  := ::__lDesignerPreview
		::_lOptions				:= TRUE
		::_lUseDbRequest		:= ::__lUseDbRequest
		::_nBoxType				:= ::__nBoxType
		::_nDrillDown			:= ::__nEnableDrillDown
		::_nExpand				:= ::__nEnableExpand
		::_nPrintOption		:= LL_PRINT_NORMAL
		::_nProject				:= LL_PROJECT_LIST                                             // default
		::_nQuantity			:= 1
	endif

	// handsome options
#ifndef DEBUG
	LlSetOption(::hJob, LL_OPTION_NOPARAMETERCHECK		,1)                        // performance boost
#endif
	LlSetOption(::hJob, LL_OPTION_XLATVARNAMES		   ,0)
	LlSetOption(::hJob, LL_OPTION_SETCREATIONINFO		,1)
	LlSetOption(::hJob, LL_OPTION_SORTVARIABLES			,1)
	LlSetOption(::hJob, LL_OPTION_NOFILEVERSIONUPGRADEWARNING,1)
	LlSetOption(::hJob, LL_OPTION_ADDVARSTOFIELDS		,1)
	LlSetOption(::hJob, LL_OPTION_SUPPORTPAGEBREAK		,1)
	LlSetOption(::hJob, LL_OPTION_CONVERTCRLF				,1)
	LlSetOption(::hJob, LL_OPTION_ESC_CLOSES_PREVIEW	,1)
	LlSetOption(::hJob, LL_OPTION_SKIPRETURNATENDOFRTF	,1)
	LlSetOption(::hJob, LL_OPTION_PRVZOOM_PERC			,::__nZoom )
	LlSetOption(::hJob, LL_OPTION_TABSTOPS					,LL_TABS_EXPAND )

	if !empty(::__cExportFormat)
		LlSetOptionString (::hJob, LL_OPTIONSTR_EXPORTS_ALLOWED_IN_PREVIEW, ::__cExportFormat)
	endif

	// interne defaults
	if ascan(::_aVar, {|x| x[1] == "USER"}) = 0
		cTmp	:= space(255)
		nLen	:= 255
		GetUsername( @cTmp, @nLen )
		cTmp	:= left(cTmp, --nLen)
		aadd( ::_aVar, {"USER"   ,cTmp, LL_TEXT})
	endif

	if ascan(::_aVar, {|x| x[1] == "COMPUTER"}) = 0
		cTmp	:= space(255)
		nLen	:= 255
		GetComputername( @cTmp, @nLen)
		cTmp	:= left(cTmp, nLen)
		aadd( ::_aVar, {"COMPUTER"   ,cTmp, LL_TEXT})
	endif

RETURN self

/*============================================================================
 $Method:	SetMenuId(xSet, lSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Argument:     lSet
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SetMenuId(xSet, lSet)
	LOCAL nPos
	nPos   := ascan( ::_aRights, xSet)
	if !empty(lSet)
		if nPos > 0
			aremove(::_aRights, nPos)
		endif
	elseif nPos == 0
		aadd( ::_aRights, xSet )
	endif
RETURN self

/*============================================================================
 $Method:	ResetMenue()
 $Author:	Marcus Herz
 $Topic:
 $Description: alles einschränkungen löschen
 $Argument:    None
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:ResetMenue()
	LlViewerProhibitAction(::hJob, 0)
RETURN self

/*============================================================================
 $Method:      OptimizeDatalink( [nMode] )
 $Author:      Marcus Herz
 $Topic:
 $Description:	Es werden bei der Datenübergabe standardmässig alle Variablen/Felder übergeben
					$N$Der Optimierungsschalter übergibt dann nur noch die benutzten.
 $Return:      self
 $Hint:		   Nur in Verbindung mit Tabellenobjekten möglich
 $See Also:		datalink
 $Example:
==============================================================================*/
METHOD dsListLabel:OptimizeDatalink()
	::_lOptimize	:= TRUE
RETURN self

/*============================================================================
 $Method:	SetFirstpage(nPage)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nPage
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SetFirstpage(nPage)
	if !empty( nPage)
		if ::_nStatus = XBP_STAT_CREATE
			LlPrintSetOption(::hJob, LL_PRNOPT_PAGE , nPage )
		endif
		::_nFirstpage   := nPage
	endif
RETURN self

/*============================================================================
 $Method:      AddPath( xSet, [lFirst])
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet		Pfad, wird angefügt, kann ; als Trenner für Pfade enthalten
 $Argument:    xSet		Array mit Pfaden ersetzt komplett
 $Argument:     lFirst wenn TRUE, wird an erster Stelle ingefügt
 $Return:      self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:AddPath( xSet, lFirst)
	LOCAL aTmp
	LOCAL i, iCnt
	if IsCharacter( xSet) .and. !empty(xSet)
		if ";" $ xSet
			aTmp	:= _aStrExtract(xSet, ";")
			iCnt	:= len( aTmp)
			for i := 1 to iCnt
				aTmp[i]	:= strtran( aTmp[i], "%APPDATA%", GetEnv("APPDATA"))
				aTmp[i]	:= strtran( aTmp[i], "%USERPROFILE%", GetEnv("APPDATA"))
				aadd(::_aPath, aTmp[i] )
			next
		elseif !empty(lFirst)
			xSet	:= strtran( xSet, "%APPDATA%", GetEnv("APPDATA"))
			xSet	:= strtran( xSet, "%USERPROFILE%", GetEnv("APPDATA"))
			iCnt	:= len(::_aPath)
			aSize(::_aPath, ++iCnt)
			aIns(::_aPath, 1, xSet )
		else
			xSet	:= strtran( xSet, "%APPDATA%", GetEnv("APPDATA"))
			xSet	:= strtran( xSet, "%USERPROFILE%", GetEnv("APPDATA"))
			aadd(::_aPath, xSet )
		endif

	elseif IsArray( xSet)
		::_aPath	:= aclone(xSet)
		iCnt	:= len( ::_aPath)
		for i := 1 to iCnt
			::_aPath[i]	:= strtran( ::_aPath[i], "%APPDATA%", GetEnv("APPDATA"))
			::_aPath[i]	:= strtran( ::_aPath[i], "%USERPROFILE%", GetEnv("APPDATA"))
		next

	elseif pcount() == 0
		::_aPath	:= {}
	endif
RETURN self

//=========================================
METHOD dsListLabel:Clone(nProjecthWnd, cReport )
	LOCAL oRet
	LOCAL cClass	:= ::Classname()

	oRet := &(cClass)()

	oRet	:= oRet:New( nProjecthWnd, ::_lRtf )
	oRet:report				:= cReport
	oRet:ProjectType		:= ::_nProject
	oRet:Configblock		:= ::_bConfig
	oRet:PrepareBlock		:= ::_bPrepare
	oRet:Skipblock			:= ::_bSkip
	oRet:Topblock			:= ::_bTop
	oRet:EofBlock			:= ::_bEof
	oRet:RecnoBlock		:= ::_bRecno
	oRet:TableChange		:= ::_bTableChange
	oRet:CopyBlock			:= ::_bCopyblock
	oRet:Quantity			:= ::Quantity
	oRet:CopyDbContainer(self, FALSE)
	oRet:AddPath(::_aPath)
	oRet:AddSync(aclone(::_aSync))
	oRet:BoxType(::_nBoxType)
	oRet:Connect(::nSelect)
	oRet:CloneDataSetField(::_dbFields)
	oRet:CloneDataSetVariable(::_dbVariables)
	oRet:CloneDefineField(::_aField)
	oRet:CloneDefineVariable(::_aVar)
	oRet:enableDrillDown(::_nDrillDown)
	oRet:enableExpand(::_nExpand)
	oRet:ExportFormat(::cExportFormat)
	oRet:IgnoreFieldmask(::_cIgnoreField)
	oRet:LastRec(::_nLastRec)
	oRet:PrintAtEof(::_lPrintAtEof)
	oRet:SetFirstPage(::_nFirstpage)
	oRet:SetPreview(TRUE)
	oRet:SetTitle(::cTitle)
	oRet:UseDbRequest(::_lUseDbRequest)

	if ::_lSubReport
		oRet:AddTable(::_aAddTable )
		oRet:AddTableRelation(::_aAddTableRelation )
	endif
RETURN oRet

//=========================================
METHOD dsListLabel:DbReleaseAll()
	LOCAL i, iCnt
	LOCAL aSelect   := {}
	LOCAL x
	UNUSED (x)

	if ::_lIsReleased .or. !::_lUseDbRequest
		RETURN self
	endif

	iCnt   := len( ::_dbFields)
	for i := 1 to iCnt
		if IsArray(::_dbFields[i,__SELECT])
		elseif ascan(aSelect, ::_dbFields[i,__SELECT]) = 0
			if IsNumber(::_dbFields[i,__SELECT])
				x := dbRelease(::_dbFields[i,__SELECT])

			elseif IsObject(::_dbFields[i,__SELECT]) .and. isMethod(::_dbFields[i,__SELECT], "select") .and. ::_dbFields[i,__SELECT]:select() > 0
				x := dbRelease(::_dbFields[i,__SELECT]:select())
			endif
			aadd( aSelect, ::_dbFields[i,__SELECT])
		endif
	next

	iCnt   := len( ::_dbVariables)
	for i := 1 to iCnt
		if IsArray(::_dbVariables[i,__SELECT])
		elseif ascan(aSelect, ::_dbVariables[i,__SELECT]) = 0
			if IsNumber(::_dbVariables[i,__SELECT])
				x := dbRelease(::_dbVariables[i,__SELECT])

			elseif IsObject(::_dbVariables[i,__SELECT]) .and. isMethod(::_dbVariables[i,__SELECT], "select") .and. ::_dbVariables[i,__SELECT]:select() > 0
				x := dbRelease(::_dbVariables[i,__SELECT]:select())
			endif
		endif
		aadd( aSelect, ::_dbVariables[i,__SELECT])
	next
	::_lIsReleased		:= TRUE
RETURN self

//=========================================
METHOD dsListLabel:DbRequestAll()
	LOCAL i, iCnt
	LOCAL aSelect   := {}
	LOCAL x
	UNUSED (x)

	if !::_lUseDbRequest
		RETURN self
	endif

	iCnt   := len( ::_dbFields)
	for i := 1 to iCnt
		if IsArray(::_dbFields[i,__SELECT])
		elseif ascan(aSelect, ::_dbFields[i,__SELECT]) = 0
			if IsNumber(::_dbFields[i,__SELECT])
				dbSelectArea(::_dbFields[i,__SELECT])
				x := DbRequest(::_dbFields[i,__ALIAS])

			elseif IsObject(::_dbFields[i,__SELECT]) .and. isMethod(::_dbFields[i,__SELECT], "select") .and. ::_dbFields[i,__SELECT]:select() > 0
				dbSelectArea(::_dbFields[i,__SELECT]:select())
				x := DbRequest(::_dbFields[i,__SELECT]:alias)
			endif
			aadd( aSelect, ::_dbFields[i,__SELECT])
		endif
	next

	iCnt   := len( ::_dbVariables)
	for i := 1 to iCnt
		if IsArray(::_dbVariables[i,__SELECT])
		elseif ascan(aSelect, ::_dbVariables[i,__SELECT]) = 0
			if IsNumber(::_dbVariables[i,__SELECT])
				dbSelectArea(::_dbVariables[i,__SELECT])
				x := DbRequest(::_dbVariables[i,__ALIAS] )

			elseif IsObject(::_dbVariables[i,__SELECT]) .and. isMethod(::_dbVariables[i,__SELECT], "select") .and. ::_dbVariables[i,__SELECT]:select() > 0
				dbSelectArea(::_dbVariables[i,__SELECT]:select())
				x := DbRequest(::_dbVariables[i,__SELECT]:alias)
			endif
			aadd( aSelect, ::_dbVariables[i,__SELECT])
		endif
	next
	::_lIsReleased		:= FALSE
RETURN self

//=========================================
METHOD dsListLabel:GetErrorText(nError)
	if nError == NIL
		nError	:= ::_nError
	endif

	::_cErrorMessage := replicate(chr(0),255)
	LlGetErrortext(nError, @::_cErrorMessage, 255)
	::_cErrorMessage   	:= _trim0( ::_cErrorMessage )

	if Set( _SET_CHARSET ) == CHARSET_OEM
		::_cErrorMessage  := alltrim(ConvtoOemCP(::_cErrorMessage))
	endif
RETURN ::_cErrorMessage

/*============================================================================
 $Method:	_RaiseError(nError, cArgs, cOperation)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nError
 $Argument:     cArgs
 $Argument:     cOperation
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:_RaiseError(nError, cArgs, cOperation)
	LOCAL oError

	if nError = 0
		RETURN self
	endif

	if IsBlock(::__onError)
		oError   := Error():New()
		oError:args				:= coalesce(cArgs, "" )
		oError:canDefault		:= FALSE
		oError:canRetry		:= TRUE
		oError:canSubstitute	:= FALSE
		oError:description	:= ::GetErrorText(nError)
		oError:filename		:= CMBT_DLL
		oError:genCode			:= nError
		oError:osCode			:= nError
		oError:operation		:= cOperation
		oError:subSystem		:= "dsListLabel"
		oError:thread			:= threadid()
		oError:cargo	   	:= self
		eval(::__onError, oError)
	endif
RETURN self

//=========================================
METHOD dsListLabel:Notify(nEvent, nId )
	if IsBlock(::_bNotify)
		::eval(::_bNotify, nEvent, nId, self )
	endif
RETURN self

//=========================================
METHOD dsListLabel:_InitDevMode(nIndex)
   local nSize, nError

	DEFAULT nIndex to -1
	// erstinit
	nSize	:= 0

   nError	:= LlGetPrinterFromPrinterFile(;
			::hJob,;
			LL_PROJECT_LIST,;
			::cReport,;
			-1,;
			NIL,;
			NIL,;
			NIL,;
			@nSize)

	::_hDevmode	:= LocalAlloc( 0 ,nSize)

   nError	:= LlGetPrinterFromPrinterFile(;
			::hJob,;
			::_nProject,;
			::cReport,;
			nIndex,;
			NIL,;
			NIL,;
			::_hDevmode,;
			nSize)

	::oDevMode:SetAddress(::_hDevmode)
RETURN nError

//=========================================
METHOD dsListLabel:ExportPath(cPath)
	if IsCharacter(cPath)
		::_cExportPath	:= _slashPath(cPath)
	endif
RETURN ::_cExportPath

//=========================================
CLASS LLCallBack FROM DllCallBack
	EXPORTED:
		VAR oListLabel
		METHOD Execute(x1,x2,x3)

		INLINE METHOD Init(oListLabel)
			::oListLabel	:= oListLabel
//			::DllCallBack:init( , DLL_OSAPI+DLL_TYPE_INT32, DLL_TYPE_UINT32, DLL_TYPE_UINT32, DLL_TYPE_UINT32)
			SUPER:init( , DLL_OSAPI+DLL_TYPE_INT32, DLL_TYPE_UINT32, DLL_TYPE_UINT32, DLL_TYPE_UINT32)
			RETURN self

ENDCLASS

//=========================================
METHOD LLCallBack:Execute(nNotification, nStructurePtr, xDummy)
	LOCAL lThreadRuns := FALSE
	LOCAL oThread
	LOCAL nProjecthWnd, hEvent, nPages, hAttach, nParam, nId
	LOCAL cProjectName, cProjectOrgName, cExpFormat
	LOCAL cPreviewName ,cParent, cChild, cKeyfield, cRefField
	LOCAL xValue
	LOCAL oLlCallbackNotify			as STRUCTURE LlCallbackNotify
	LOCAL oLlDrillDownJobNotify	as STRUCTURE LlDrillDownJobNotify
	LOCAL oListLabel := ::oListLabel
	UNUSED (xDummy)

	IF nNotification == LL_NTFY_DESIGNERPRINTJOB
		oLlCallbackNotify	:setAddress(nStructurePtr)
		DO CASE
		CASE oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_PREVIEW_START .or. ;
				oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_EXPORT_START
			// Init/retrieve values for the print thread
			nProjecthWnd	:= oLlCallbackNotify:Get_hWnd()
			hEvent			:= oLlCallbackNotify:Get_hEvent()
    		nPages			:= oLlCallbackNotify:Get_nPages() // number of pages to be printed
			cProjectName	:= oLlCallbackNotify:_pszProjectNameFromVar()
			cProjectOrgName:= oLlCallbackNotify:_pszOriginalProjectFileNameFromVar()
			cExpFormat		:= oLlCallbackNotify:_pszExportFormatFromVar()

			oListLabel:dbReleaseAll()
			// Start print thread
			oThread   := Thread():new()
			oThread   :start( {|| _ThreadPrint(oThread, oListLabel, hEvent, nProjecthWnd, cProjectName, cProjectOrgName, cExpFormat, nPages)})
			lThreadRuns := TRUE

		CASE oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT .or. ;
				oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT
			_PrintRuns(FALSE, TRUE, snJobId)
			lThreadRuns := FALSE

		CASE oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE .or. ;
				oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE
			lThreadRuns := FALSE
			oListLabel:dbRequestAll()

		CASE oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE .or. ;
				oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_EXPORT_QUEST_JOBSTATE
			lThreadRuns := _PrintRuns(FALSE, TRUE, snJobId )
			lThreadRuns := FALSE

		ENDCASE

		oLlCallbackNotify:Set_hEvent( IF(lThreadRuns,LL_DESIGNERPRINTTHREAD_STATE_RUNNING,LL_DESIGNERPRINTTHREAD_STATE_STOPPED))

		RETURN IF(lThreadRuns,LL_DESIGNERPRINTTHREAD_STATE_RUNNING,LL_DESIGNERPRINTTHREAD_STATE_STOPPED)

	ELSEIF nNotification == LL_NTFY_VIEWERDRILLDOWN

		oLlDrillDownJobNotify:setAddress(nStructurePtr)
		nId	:= int(oLlDrillDownJobNotify:Get_nID())

		nParam	:= snJobId

		IF oLlDrillDownJobNotify:Get_nFunction() == LL_DRILLDOWN_START						// 1
			// Init/retrieve values for the print thread
			nProjecthWnd	:= oLlDrillDownJobNotify:Get_hWnd()
			cProjectName	:= oLlDrillDownJobNotify:_pszProjectFileNameFromVar()
			cPreviewName	:= oLlDrillDownJobNotify:_pszPreviewFileNameFromVar()
  			nParam			:= oLlDrillDownJobNotify:Get_nUserParameter()
			cParent			:= oLlDrillDownJobNotify:_pszTableIDFromVar()
//			cRelation		:= oLlDrillDownJobNotify:_pszRelationIDFromVar()
			cChild			:= oLlDrillDownJobNotify:_pszSubreportTableIDFromVar()
			cKeyField		:= oLlDrillDownJobNotify:_pszKeyFieldFromVar()
			cRefField		:= oLlDrillDownJobNotify:_pszSubreportKeyFieldFromVar()
			xValue			:= oLlDrillDownJobNotify:_pszKeyValueFromVar()
			hAttach			:= oLlDrillDownJobNotify:Get_hAttachInfo()

			if snJobId = 0 .or. !_PrintRuns(, TRUE, snJobId)
				oListLabel:dbReleaseAll()
				// Start print thread
				oThread   := Thread():new()
				nParam    := ++snJobId
				oThread   :start( {|| _ThreadPrintDrillDown(oThread, oListLabel, nProjecthWnd, cProjectName, cPreviewName, hAttach, cParent, cKeyfield, cChild, cRefField, xValue )})
			endif

		ELSEIF oLlDrillDownJobNotify:Get_nFunction() == LL_DRILLDOWN_FINALIZE			// 2
			if !_PrintRuns(, TRUE, nId )
				oListLabel:dbRequestAll()
			endif

		ENDIF
		RETURN nParam

	ELSEIF nNotification == LL_CMND_SAVEFILENAME
		oListLabel:DesignerUpdated( TRUE )

	ELSEIF nNotification == LL_NTFY_VIEWERBTNCLICKED
		oListLabel:notify(nNotification, nStructurePtr)

	ENDIF
RETURN 0

//=========================================
STATIC FUNC _ThreadPrint(oThread, oDesigner, hEvent, nProjecthWnd, cProjectName, cProjectOrgName, cExpFormat, nPages)
	LOCAL oListLabel
   local nEvent	:= hEvent

	_PrintRuns(TRUE, FALSE, snJobId )
	SetEvent(hEvent)

	oListLabel	:= oDesigner:clone(nProjecthWnd, cProjectName)
	oThread		:cargo   := {oDesigner, oListLabel }
	oListLabel	:Pages	:= nPages
	oListLabel	:dbRequestAll()
   if !empty(cProjectOrgName)
		LlSetOptionString(oListLabel:hJob, LL_OPTIONSTR_ORIGINALPROJECTFILENAME, cProjectOrgName)
   else
		LlSetOptionString(oListLabel:hJob, LL_OPTIONSTR_ORIGINALPROJECTFILENAME, cProjectName)
   endif
	LlAssociatePreviewControl(oListLabel:hJob, nProjecthWnd, LL_ASSOCIATEPREVIEWCONTROLFLAG_DELETE_ON_CLOSE)

	oListLabel	:ExportFormat(cExpFormat)
	oListLabel	:print()
	oListLabel	:dbReleaseAll()
	oListLabel	:destroy()

	LlAssociatePreviewControl(oListLabel:hJob,NIL,1)							// associate the window handle

	_PrintRuns(FALSE, TRUE, snJobId )
	SetEvent(nEvent)

RETURN NIL

//=========================================
STATIC FUNC _ThreadPrintDrillDown(oThread, oDesigner, nProjecthWnd, cProjectName, cPreviewName, hAttach, cParent, cKeyfield, cChild, cRefField, xValue  )
	LOCAL oListLabel
	LOCAL dbParent
	LOCAL dbChild
	UNUSED (cKeyField)
	UNUSED (cRefField)

	_PrintRuns(TRUE, FALSE, snJobId)

	oListLabel	:= oDesigner:clone(nProjecthWnd, cProjectName)
	oThread:cargo   := {oDesigner, oListLabel }
	oListLabel	:dbRequestAll()
	LlSetOptionString(oListLabel:hJob, LL_OPTIONSTR_PREVIEWFILENAME, cPreviewName)
	LlAssociatePreviewControl(oListLabel:hJob, hAttach, LL_ASSOCIATEPREVIEWCONTROLFLAG_DELETE_ON_CLOSE + LL_ASSOCIATEPREVIEWCONTROLFLAG_HANDLE_IS_ATTACHINFO)

	if !empty(xValue)
  		dbChild	:= oListLabel:GetDbContainer(cChild)
		dbParent	:= oListLabel:GetDbContainer(cParent)
		if IsNumber(dbParent)
			(dbParent)->(dbseek(xValue))
			(dbParent)->(dbsetscope(SCOPE_BOTH, xValue))
			(dbChild)->(dbsetscope(SCOPE_BOTH, xValue))

		elseif IsObject(dbParent)
			dbParent:seek(xValue)
			dbParent:setscope(SCOPE_BOTH, xValue)
			dbChild:setscope(SCOPE_BOTH, xValue)
		endif
	endif

	oListLabel	:print()
	oListLabel	:dbReleaseAll()
	oListLabel	:destroy()
	LlAssociatePreviewControl(oListLabel:hJob,NIL,1)							// associate the window handle
	_PrintRuns(FALSE, TRUE, snJobId )
RETURN NIL

//=========================================
STATIC FUNCTION _PrintRuns(lSet, lCheck, nJobId)
	STATIC aPrintRuns := {}
	LOCAL nFindThread := AScan(aPrintRuns,{|a|a[1] == nJobId })

	if nFindThread = 0
		if lCheck
			RETURN TRUE
		endif
		aAdd(aPrintRuns,{nJobId,FALSE})
		nFindThread := Len(aPrintRuns)
	endif
	if lSet != NIL
		aPrintRuns[nFindThread,2] := lSet
	endif
RETURN aPrintRuns[nFindThread,2]

//=========================================
// XClass++ copy
//=========================================
STATIC FUNC _FullPath(cPath, cCurDir)
	LOCAL nPos

	if empty(cCurdir)
		cCurdir   := strtran(AppName(TRUE), AppName(), "")
	endif

	cCurdir   := _SlashPath(cCurDir)

	if left(cPath,2) = ".."									    // 1. hoch
		// curdir auch 1 noch oben
		nPos   := rat("\", cCurdir, len( cCurdir)-1)
		if nPos == 0											// fehler
			RETURN cPath
		endif
		RETURN _FullPath(subs(cPath,4), left(cCurDir, nPos ))

	elseif left(cPath,2) = ".\"									// relativer pfad
		cPath   := cCurDir + subs( cPath, 3 )

	elseif left(cPath,1) = "\" .and. ! subs(cPath,2,1) = "\"				 // absolut, aber ohne LW
		if subs(cCurDir,2,1) = ":"
			cPath   := left(cCurDir,2) + cPath

		elseif left(cCurDir,2) = "\\"
			if (nPos := at(cCurDir,"\",  3)) > 0
				cPath   := left(cCurDir,--nPos) + cPath
			endif
		endif

	elseif !(left(cPath,2) = "\\" .or. subs(cPath,2,1) = ":" )			     // kein (UNC oder LW)
		cPath   := cCurDir + cPath

	endif
RETURN cPath

//=========================================
// XClass++ copy
//=========================================
STATIC FUNC _SlashPath(cPath)
	if empty( cPath)
		RETURN ""
	endif
	cPath   := alltrim(cPath)
	if subs( cPath, -1 ) != "\"
		cPath   += "\"
	endif
RETURN cPath

//=========================================
STATIC FUNC _aStrExtract(cStr, cToken)
	LOCAL i, iCnt
	LOCAL aRet	:= {""}

	iCnt	:= len( cStr)
	for i := 1 to iCnt
		if cStr[i] = cToken
			aadd(aRet, "")
		else
			aRet[-1] += cStr[i]
		endif
	next
RETURN aRet

//=========================================
STATIC FUNC _GetTempPath()
	LOCAL sBuffer
	LOCAL nBuffSize	:= 261
	sBuffer 	:= space(261)
	nBuffSize	:= GetTempPath(nBuffSize, @sBuffer)
return substr( sBuffer, 1, nBuffsize )

//=========================================
STATIC FUNC _GetExportName(cPath, cExt)		;RETURN cPath + "LLEXPORT"+dtos(date())+strtran(time(),":")+"."+cExt

//=========================================
STATIC FUNC _SetExtension(cFile, cExt)
	LOCAL nLen   := len( "."+ cExt )
	if right(upper(cFile), nLen ) != "."+ cExt
		cFile   += "."+ cExt
	endif
RETURN cFile

//=========================================
// wegen API 0-Bytes
STATIC FUNC _Trim0( cStr)
	LOCAL nPos   := at(chr(0), cStr)
	if nPos > 0
		cStr := left( cStr, nPos -1 )
	endif
RETURN alltrim( cStr )

//=========================================
// Xclass Uses xclass:dsDbContainer with extended methods
// nice to have if you are used to it
//=========================================
#ifndef _XCLASS
STATIC CLASS DbContainer
	HIDDEN:
	PROTECTED:
		Var _aDbContainer

	EXPORTED:
		METHOD AddDbContainer
		METHOD CloseDbContainer
		METHOD Destroy
		METHOD GetDbContainer

		//=========================================
		INLINE METHOD Init
			::_aDbContainer  := {}
			RETURN self

		//=========================================
		INLINE METHOD GetDbAllContainer()	;RETURN ::_aDbContainer

		//=========================================
		INLINE METHOD CopyDbContainer(oDlg, lClose)
			LOCAL i, iCnt
			LOCAL aDbContainer := oDlg:GetDbAllContainer()

			DEFAULT lClose to FALSE

			iCnt	:= len(aDbContainer)
			::_aDbContainer	:= array(iCnt)
			for i := 1 to iCnt
				if i == 1
					::_aDbContainer[i]	:= dataobject():New()
				else
					::_aDbContainer[i]	:= ::_aDbContainer[1]:copy()
				endif
				if IsArray(aDbContainer[i])                                             // XCLASS
					::_aDbContainer[i]:Symbol	:= aDbContainer[i,1]
					::_aDbContainer[i]:Select	:= aDbContainer[i,2]
				else
					::_aDbContainer[i]:Symbol	:= aDbContainer[i]:symbol
					::_aDbContainer[i]:Select	:= aDbContainer[i]:Select
				endif
				::_aDbContainer[i]:Close	:= lClose
			next
			RETURN self

ENDCLASS

/*============================================================================
 $Method:      AddDbContainer(cNameID, uSelect, lDbClose )
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    cNameID
 $Argument:     uSelect
 $Argument:     lDbClose
 $Return:      self
 $See Also:
 $Example:
==============================================================================*/
METHOD DbContainer:AddDbContainer(cNameID, uSelect, lDbClose )
	LOCAL nPos

	if (IsNumber(uSelect) .or. IsObject(uSelect) .or. IsArray(uSelect)) .and. IsCharacter(cNameID) .and. ! empty(cNameID)
		if IsCharacter(cNameID)
			cNameID := upper(cNameID)
		endif
		if (nPos := ascan(::_aDbContainer, {|e| e:Symbol == cNameID})) > 0
			::_aDbContainer[nPos]:Select	:= uSelect
			::_aDbContainer[nPos]:Close	:= !Empty(lDbClose)
		else
			aadd( ::_aDbContainer, dataobject():New())
			::_aDbContainer[-1]:Symbol	:= cNameID
			::_aDbContainer[-1]:Select	:= uSelect
			::_aDbContainer[-1]:Close	:= !Empty(lDbClose)
		endif
	endif
RETURN self

/*============================================================================
 $Method:      Destroy()
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    None
 $Return:      self
 $See Also:
 $Example:
==============================================================================*/
METHOD DbContainer:Destroy()
	LOCAL i, iCnt

	iCnt	:= len( ::_aDbContainer)
	for i := 1 to iCnt
      if ! IsNil(::_aDbContainer[i]) .and. ::_aDbContainer[i]:close
			if IsObject(::_aDbContainer[i]:select)
				::_aDbContainer[i]:select:Close()
			elseif IsNumber(::_aDbContainer[i]:select) .and. (::_aDbContainer[i]:select)->(Used())
				(::_aDbContainer[i]:select)->(DbCloseArea())
			endif
      endif
		::_aDbContainer[i]	:= NIL
  	next
	::_aDbContainer	:= {}
RETURN self

/*============================================================================
 $Method:			GetDbContainer(cNameID)
 $Author:      	Dieter Stelzner
 $Topic:       	Selectnummer oder Serverobjekt aus dem Dbcontainer ermitteln
 $Description: 	Selectnummer oder Serverobjekt aus dem Dbcontainer ermitteln.
 $Argument:       cNameID        Symbol-NameID der gesuchten Workarea bzw. Servers. Wenn NIL wird ein Array
                                 mit allen Serverobjekten bzw. Selectnummern zurückgegeben.
 $Return:         Selectnummer bzw. Serverobjekt wenn gefunden und cNameID übergeben wurde. $N$
                  Wenn nichts gefunden Wird; NIL
 $See Also:    	AddDbcontainer
==============================================================================*/
METHOD DbContainer:GetDbContainer(cNameID )
	LOCAL nPos
	LOCAL aRet

	if pcount() = 0
		aRet := array(len(::_aDbContainer))
		aeval(::_aDbContainer, {|a,n| aRet[n] := a:select })
		RETURN aRet
	endif

	if IsCharacter(cNameID)
		cNameID := upper(cNameID)
	endif

	if (nPos := ascan(::_aDbContainer, {|e| e:Symbol == cNameID})) > 0
		RETURN ::_aDbContainer[nPos]:select
	endif

RETURN NIL

//=========================================
METHOD DbContainer:CloseDbContainer(cNameID)
	LOCAL nPos

	if IsCharacter(cNameID)
		cNameID := upper(cNameID)
	endif
  	if (nPos := ascan(::_aDbContainer, {|e| e:Symbol == cNameID})) > 0
		if IsObject(::_aDbContainer[nPos]:Select)
			::_aDbContainer[nPos]:Select:Close()

		elseif IsNumber(::_aDbContainer[nPos]:Select) .and. (::_aDbContainer[nPos]:Select)->(Used())
			(::_aDbContainer[nPos]:Select)->(DbCloseArea())
		endif
     	aremove(::_aDbContainer, nPos)
  	endif
RETURN self
#else
CLASS DbContainer from dsDbContainer		;ENDCLASS
#endif

/*============================================================================
 $Procedure:	 DataSetField(hJob)
 $Group:
 $Author:      Marcus Herz
 $Topic:
 $Description:
 $Argument:    hJob
 $See Also:
 $Example:
==============================================================================*/
PROC DataSetField(hJob, nMode)
	LOCAL aStruct	:= dbStruct()
	LOCAL i, iCnt, nLL
	LOCAL xRet, cStr

	iCnt	:= len( aStruct)
	for i := 1 to iCnt
		xRet	:= fieldget(i)

		if aStruct[i,2] = "N"
			nLL   := LL_NUMERIC
			cStr  := ltrim(str(xRet))
			if aStruct[i,4] == 0
				nLL   := LL_NUMERIC_INTEGER
			endif

		elseif aStruct[i,2] = "D"
			if !empty( xRet)
				cStr	:= dtos(xRet)
				nLL   := LL_DATE_YYYYMMDD
			else
				cStr	:= '1e100'
				nLL   := LL_DATE_MS
			endif

		elseif aStruct[i,2] = "L"
			nLL	:= LL_BOOLEAN
			cStr	:= if(xRet, "T","F")

		else
			nLL   := LL_TEXT
			if Set( _SET_CHARSET ) == CHARSET_OEM
				cStr  := rtrim(ConvtoAnsiCP(xRet))
			else
				cStr  := rtrim(xRet)
			endif
			if empty( cStr)
				cStr	:= " "
			endif
		endif
		if empty( nMode )
			LlDefineFieldExt(hJob, aStruct[i,1], cStr, nLL, 0 )
		else
			LlDefineVariableExt(hJob, aStruct[i,1], cStr, nLL, 0 )
		endif
	next
RETURN

STRUCTURE DEVMODE
	VAR dmDeviceName				AS STRING[CCHDEVICENAME]				//   1-32
	VAR dmSpecVersion				AS USHORT                           //  33
	VAR dmDriverVersion			AS USHORT                           //  35
	VAR dmSize						AS USHORT                           //  37
	VAR dmDriverExtra				AS USHORT                           //  39
	VAR dmFields					AS UINTEGER                         //  41
	VAR dmOrientation				AS USHORT                           //  45
	VAR dmPaperSize				AS USHORT                           //  47
	VAR dmPaperLength				AS USHORT                           //  49
	VAR dmPaperWidth				AS USHORT                           //  51
	VAR dmScale						AS USHORT                           //  53
	VAR dmCopies					AS USHORT                           //  55
	VAR dmDefaultSource			AS USHORT                           //  57  PaperBin
	VAR dmPrintQuality			AS USHORT                           //  59
	VAR dmColor						AS USHORT                           //  61
	VAR dmDuplex					AS USHORT                           //  63
	VAR dmYResolution				AS USHORT                           //  65
	VAR dmTTOption					AS USHORT                           //  67
	VAR dmCollate					AS USHORT                           //  69
	VAR dmFormName					AS STRING[CCHFORMNAME]              //  71-102
	VAR dmUnusedPadding			AS UINTEGER                         // 103
	VAR dmLogPixels				AS USHORT                           // 107
	VAR dmBitsPerPel				AS UINTEGER                         // 109
	VAR dmPelsWidth				AS UINTEGER                         // 113
	VAR dmPelsHeight				AS UINTEGER                         // 117
	VAR dmDisplayFrequency		AS UINTEGER                         // 121
	VAR dmICMMethod				AS UINTEGER                         // 125
	VAR dmICMIntent				AS UINTEGER                         // 129
	VAR dmMediaType				AS UINTEGER                         // 133
	VAR dmDitherType				AS UINTEGER                         // 137
	VAR dmReserved1				AS UINTEGER                         // 141
	VAR dmReserved2				AS UINTEGER                         // 145
	VAR dmPanningWidth			AS UINTEGER                         // 149
	VAR dmPanningHeight			AS UINTEGER                         // 153-156
ENDSTRUCTURE




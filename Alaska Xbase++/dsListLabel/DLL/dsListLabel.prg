/*============================================================================
 File Name:	   dsListLabel.prg
 Author:	 		Marcus Herz
 Description:
 Created:		19.08.2016     13:33:08	  Updated: þ18.08.2025	þ10:18:58
 Copyright:		2016 by DS-Datasoft
 Revision:

 Remark: Set TAB to 3 blanks

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

#IF XPPVER < 2001392
	#error This DLL needs Xbase++ Version 2.0 or higher
#ENDIF	// XPPVER < 2001392

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
#ENDIF  // DEBUGOUT

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
	CLASS VAR __aDefaultPath			NODEBUG SHARED					// paths to search reports
	CLASS VAR __aDefaultVar				NODEBUG SHARED					// LlDefineVariable
	CLASS VAR __aRights					NODEBUG SHARED					// rights
	CLASS VAR __bConfig					NODEBUG SHARED					// user callback after LLPrint[withBox]Start
	CLASS VAR __bPrepare					NODEBUG SHARED					// user callback before LLPrint[withBox]Start
	CLASS VAR __cEmailProvider			NODEBUG SHARED					// Emailprovider
	CLASS VAR __cExportFormat			NODEBUG SHARED					// possible exports
	CLASS VAR __cExportPath				NODEBUG SHARED					// possible exports
	CLASS VAR __cIgnoreField			NODEBUG SHARED					// mask to ignore field
	CLASS VAR __cLicence					NODEBUG SHARED					// your licence
	CLASS VAR __cPrinter					NODEBUG SHARED					//
	CLASS VAR __cPrintText				NODEBUG SHARED					// progrss bar
	CLASS VAR __cSmtpIPAddress			NODEBUG SHARED					// Email Versand
	CLASS VAR __cSmtpPassword			NODEBUG SHARED					// Email Versand
	CLASS VAR __cSmtpSenderAddress	NODEBUG SHARED					// Email Versand
	CLASS VAR __cSmtpSenderName   	NODEBUG SHARED					// Email Versand
	CLASS VAR __cSmtpUser				NODEBUG SHARED					// Email Versand
	CLASS VAR __cTempPath				NODEBUG SHARED					// Tmp path
	CLASS VAR __lDesignerPreview  	NODEBUG SHARED					// enable real data preview
	CLASS VAR __lUseDbRequest			NODEBUG SHARED					// wenn mit Tabellenobjekten ohne *DBE
	CLASS VAR __nBoxType					NODEBUG SHARED					// LlPrintWithBoxStart
	CLASS VAR __nDebug					NODEBUG SHARED					// LlSetDebug(::__nDebug )
	CLASS VAR __nEnableDrillDown  	NODEBUG SHARED					// enable drilldown
	CLASS VAR __nEnableExpand		  	NODEBUG SHARED					// enable expand
	CLASS VAR __nLanguage				NODEBUG SHARED					// LlJobOpen(::__nLanguage)
	CLASS VAR __nSmtpIPPort				NODEBUG SHARED					// Email Versand
	CLASS VAR __nZoom						NODEBUG SHARED					// Zoom bei Preview
	CLASS VAR __onError					NODEBUG SHARED					// Fehler Handling
	CLASS VAR __toUpper					NODEBUG SHARED					// Symbol UPPERCASE

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
	VAR hJob 								READONLY
	VAR hWnd 								READONLY
	VAR oDevmode

	CLASS METHOD DefaultPath
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
	INLINE METHOD IsPreview											;RETURN (::_nPrintOption == LL_PRINT_PREVIEW .OR. ::cOutput = "PRV")
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

	INLINE METHOD ClearSync()						;::_aSync			:= {}							;RETURN self
	INLINE METHOD CloneDataSetField(aList)		;::_dbFields		:= aclone(aList)			;RETURN self
	INLINE METHOD CloneDataSetVariable(aTable);::_dbVariables	:= aclone(aTable)			;RETURN self
	INLINE METHOD CloneDefineField(aField)		;::_aField			:= aclone(aField)			;RETURN self
	INLINE METHOD CloneDefineVariable(aVar)	;::_aVar				:= aclone(aVar)			;RETURN self
	INLINE METHOD ResetRights()					;::_aRights			:= aclone(::__aRights)	;RETURN self
	INLINE METHOD UseDbRequest(xSet)				;::_lUseDbRequest := xSet 						;RETURN self
	INLINE METHOD ZugferdXML(xSet)				;::_cZUGFeRDXML	:= xSet						;RETURN self

	//=========================================
	// for free use
	INLINE ACCESS ASSIGN METHOD Dataobject
		IF ::_Dataobject == NIL
			::_Dataobject	:= Dataobject():New()
		ENDIF
		RETURN ::_Dataobject

	//=========================================
	INLINE ACCESS ASSIGN METHOD DesignerPreview( xSet)
		IF IsLogic(xSet)
			::_lDesignerPreview		:= xSet
			RETURN self
		ENDIF
		RETURN ::_lDesignerPreview

	//=========================================
	INLINE ACCESS ASSIGN METHOD BoxType( xSet)
		IF IsNumber(xSet)
			::_nBoxType		:= xSet
			RETURN self
		ENDIF
		RETURN ::_nBoxType

	//=========================================
	INLINE ACCESS ASSIGN METHOD onNotify( xSet)
		IF IsBlock(xSet)
			::_bNotify		:= xSet
			RETURN self
		ENDIF
		RETURN ::_bNotify

	//=========================================
	INLINE ACCESS ASSIGN METHOD Lastrec( xSet)
		IF IsNumber(xSet)
			::_nLastRec		:= xSet
			RETURN self
		ENDIF
		RETURN ::_nLastRec

	//=========================================
	INLINE ACCESS ASSIGN METHOD DesignerUpdated( xSet)
		IF IsLogical(xSet)
			::_lDesignerUpdated		:= xSet
			RETURN self
		ENDIF
		RETURN ::_lDesignerUpdated

	//=========================================
	INLINE ACCESS ASSIGN METHOD Quantity( xSet)
		IF IsNumber(xSet)
			::_nQuantity	:= xSet
			RETURN self
		ENDIF
		RETURN ::_nQuantity

	//=========================================
	INLINE ACCESS ASSIGN METHOD IgnoreFieldmask( xSet)
		IF IsCharacter(xSet)
			::_cIgnoreField  := xSet
			RETURN self
		ENDIF
		RETURN ::_cIgnoreField

	//=========================================
	INLINE ASSIGN METHOD ExportFormat( xSet)
		IF IsCharacter( xSet) .AND. !empty(xSet)
			::cExportFormat   := xSet
			LlSetOptionString(::hJob, LL_OPTIONSTR_EXPORTS_ALLOWED_IN_PREVIEW, ::cExportFormat)
		ENDIF
		RETURN self

	//=========================================
	INLINE ASSIGN METHOD PrintText( xSet)
		IF IsCharacter( xSet)
			::_cPrintText	:= xSet
		ENDIF
		RETURN self

	//=========================================
	INLINE ACCESS ASSIGN METHOD Pages( xSet)
		IF IsNumber( xSet)
			::_nPages		:= xSet
			RETURN self
		ENDIF
		RETURN ::_nPages

	//=========================================
	INLINE ACCESS ASSIGN METHOD ProjectType( xSet)
		IF IsNumber( xSet)
			::_nProject		:= xSet
			RETURN self
		ENDIF
		RETURN ::_nProject

	//=========================================
	INLINE ACCESS ASSIGN METHOD Project( xSet)														// obsolet backward compatible,use ProjectType
		IF IsNumber( xSet)
			::_nProject		:= xSet
			RETURN self
		ENDIF
		RETURN ::_nProject

//=========================================
	INLINE ACCESS ASSIGN METHOD SkipBlock( xSet)
		IF IsBlock( xSet)
			::_bSkip	:= xSet
			RETURN self
     	ELSEIF pcount() = 1
     		::_bSkip   := _SKIPBLOCK																		// default, must be valid codeblock, muss immer gültiger codeblock sein
		ENDIF
    	RETURN ::_bSkip

	//=========================================
	INLINE ACCESS ASSIGN METHOD TopBlock( xSet)
   	IF IsBlock( xSet)
   		::_bTop	:= xSet
			RETURN self
  		ELSEIF pcount() = 1
  			::_bTop   := _TOPBLOCK           															// default, must be valid codeblock, muss immer gültiger codeblock sein
		ENDIF
 		RETURN ::_bTop

//=========================================
	INLINE ACCESS ASSIGN METHOD EofBlock( xSet)
		IF IsBlock( xSet)
			::_bEof	:= xSet
			RETURN self
     	ELSEIF pcount() = 1
     		::_bEOF   := _EOFBLOCK           															// default, must be valid codeblock, muss immer gültiger codeblock sein
		ENDIF
    	RETURN ::_bEOF

//=========================================
	INLINE ACCESS ASSIGN METHOD RecnoBlock( xSet)
		IF IsBlock( xSet)
			::_bRecno	:= xSet
			RETURN self
     	ELSEIF pcount() = 1
     		::_bRecno   := _RECNOBLOCK       															// default, must be valid codeblock, muss immer gültiger codeblock sein
		ENDIF
    	RETURN ::_bRecno

	//=========================================
	INLINE ACCESS ASSIGN METHOD TableChange( xSet)
		IF IsBlock( xSet)
			::_bTableChange   := xSet
			RETURN self
		ENDIF
		RETURN ::_bTableChange

	//=========================================
	INLINE ACCESS ASSIGN METHOD ConfigBlock( xSet)
		IF IsBlock( xSet)
			::_bConfig		:= xSet
			RETURN self
		ENDIF
		RETURN ::_bConfig

	//=========================================
	INLINE ACCESS ASSIGN METHOD PrepareBlock( xSet)
		IF IsBlock( xSet)
			::_bPrepare		:= xSet
			RETURN self
		ENDIF
		RETURN ::_bPrepare

	//=========================================
	INLINE ACCESS ASSIGN METHOD CopyBlock( xSet)
		IF IsBlock( xSet)
			::_bCopyblock	:= xSet
			RETURN self
		ENDIF
		RETURN ::_bCopyblock

	//=========================================
	INLINE METHOD EnableDrillDown( xSet)
		IF IsLogical(xSet) .AND. xSet
			::_nDrillDown	:= 1
		ELSEIF IsNumber(xSet)
			::_nDrillDown	:= xSet
		ELSE
			::_nDrillDown	:= 0
		ENDIF
		LlSetOption(::hJob, LL_OPTION_DRILLDOWNPARAMETER, ::_nDrillDown)
		RETURN self

	//=========================================
	INLINE METHOD EnableExpand( xSet)
		IF IsLogical(xSet) .AND. xSet
			::_nExpand	:= 1
		ELSEIF IsNumber(xSet)
			::_nExpand	:= xSet
		ELSE
			::_nExpand	:= 0
		ENDIF
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
		IF hJob == NIL .OR. hJob < 0
			RETURN 0
		ENDIF
		xRet	:= LlGetVersion(LL_VERSION_MAJOR)
		LlJobClose(hJob)
		RETURN xRet

	//=========================================
	INLINE CLASS Method DefaultVariable(cSymbol, xValue, nLLType)
		LOCAL nPos
		LOCAL cTmp	:= cSymbol
		nPos   := ascan( ::__aDefaultVar, {|a| a[1] == cTmp})
		IF nPos > 0
			::__aDefaultVar[nPos,2] := xValue
			::__aDefaultVar[nPos,3] := nLLType
		ELSE
			aadd( ::__aDefaultVar, {cSymbol, xValue, nLLType})
		ENDIF
		RETURN self

	//=========================================
	INLINE CLASS Method DefaultConfigBlock(bSet)
		IF IsBlock(bSet)
			::__bConfig	:= bSet
		ENDIF
		RETURN self

	//=========================================
	INLINE CLASS Method DefaultPrepareBlock(bSet)
		IF IsBlock(bSet)
			::__bPrepare	:= bSet
		ENDIF
		RETURN self

	//=========================================
	INLINE CLASS Method onError(xSet)
		IF IsBlock(xSet)
			::__onError	:= xSet
		ENDIF
		RETURN self

	//=========================================
	INLINE CLASS Method DefaultDebug(xSet)
		IF IsNumber(xSet)
			::__nDebug   := xSet
		ELSEIF IsLogical(xSet)
			IF xSet
				::__nDebug   := LL_DEBUG_CMBTLL
			ELSE
				::__nDebug   := 0
			ENDIF
		ENDIF
		RETURN self

	//=========================================
	INLINE CLASS Method ModulInstalled()
		RETURN LLModuleInit()

ENDCLASS

//=========================================
CLASS METHOD dsListLabel:InitClass()
	IF ::__aDefaultVar == NIL
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
		::__onError					:= Errorblock()
		::__toUpper					:= FALSE

	ENDIF
RETURN self

//=========================================
CLASS METHOD dsListLabel:DefaultPath(xSet)
	LOCAL aTmp
	LOCAL i, iCnt

	IF pcount() = 0
		RETURN ::__aDefaultPath
	ENDIF

	IF IsArray(xSet)
		iCnt	:= len( xSet)
		FOR i := 1 TO iCnt
			xSet[i]	:= strtran( xSet[i], "%APPDATA%"		, GetEnv("APPDATA"))
			xSet[i]	:= strtran( xSet[i], "%USERPROFILE%", GetEnv("APPDATA"))
			aadd(::__aDefaultPath, xSet[i] )
		NEXT

	ELSEIF IsCharacter(xSet)
		IF ";" $ xSet
			aTmp	:= _aStrExtract(xSet, ";")
			iCnt	:= len( aTmp)
			FOR i := 1 TO iCnt
				aTmp[i]	:= strtran( aTmp[i], "%APPDATA%"		, GetEnv("APPDATA"))
				aTmp[i]	:= strtran( aTmp[i], "%USERPROFILE%", GetEnv("APPDATA"))
				aadd(::__aDefaultPath, aTmp[i] )
			NEXT
		ELSE
			xSet	:= strtran( xSet, "%APPDATA%"		, GetEnv("APPDATA"))
			xSet	:= strtran( xSet, "%USERPROFILE%", GetEnv("APPDATA"))
			aadd(::__aDefaultPath, xSet )
		ENDIF
	ENDIF
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
	IF IsNumber(oParent)                                                             // :clone(), Designer Preview
		::hWnd			:= oParent

	ELSEIF IsObject(oParent)
		::hWnd			:= oParent:GetHWND()
	ELSE
		oParent			:= SetAppWindow()
		::hWnd			:= SetAppWindow():GetHWND()
	ENDIF

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

	IF !LLModuleInit()
		::_nStatus   := XBP_STAT_FAILURE
		IF IsBlock(::__onError)
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
		ENDIF
		RETURN self
	ENDIF

	// booster
	::templateDefineFieldExt		:= templateDefineFieldExt()
	::templateDefineVariableExt	:= templateDefineVariableExt()

	IF empty(lRtf)                                                                   // ausschalten wegen performance
		LlSetOption(-1, LL_OPTION_MAXRTFVERSION, 0 )
	ENDIF

	::hJob	 := LlJobOpen(::__nLanguage)
	IF empty(::hJob) .OR. ::hJob < 0
		::_nError   := ::hJob
		::_nStatus  := XBP_STAT_FAILURE
		::hJob		:= 0
		::_RaiseError(::_nError, var2char(::__nLanguage), "LLJobOpen()")
		RETURN self
	ENDIF
	::_nStatus		:= XBP_STAT_CREATE                                                // laden DLL erfolgreich

	// defaults + reset
	LlSetPrinterDefaultsDir(::hJob, ::__cTempPath)
	LlPreviewSetTempPath(::hJob, ::__cTempPath)

	IF !empty(::__nDebug)
		LlSetDebug(::__nDebug )
	ENDIF

	LlSetOptionString (::hJob, LL_OPTIONSTR_LICENSINGINFO    ,::__cLicence )

	LlViewerProhibitAction(::hJob, 0)
	AEVAL( ::_aRights, {|n| LlViewerProhibitAction(::hJob, n )})

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

	IF ! IsNumber(::hJob) .OR. ::hJob <= 0                                           // ::hJob kann auch NIL sein!!!
		RETURN LL_ERR_BAD_JOBHANDLE
	ENDIF
	IF ::_lPrepared
		RETURN 0
	ENDIF

	::_nRootSelect := ::nSelect

	IF IsObject(::nSelect )
		IF empty(::_nLastRec)
			IF IsMethod(::nSelect, "countrec")
				::_nLastRec	:= ::nSelect:countrec()                                     // nur AdsClass++

			ELSEIF IsMethod(::nSelect, "lastrec")
				::_nLastRec	:= ::nSelect:lastrec()
			ENDIF
		ENDIF

	ELSEIF IsArray(::nSelect )
		::_nLastRec		:= len(::nSelect)
		::_bSkip			:= {|o, n| NIL}
		::_bTop			:= {|o, n| NIL}

	ELSEIF IsNumber(::nSelect) .AND. ::nSelect > 0
		IF empty(::_nLastRec)
			::_nLastRec   := (::nSelect)->(lastrec())
		ENDIF
	ENDIF

	::_nLastRec				:= max(1, ::_nLastRec)
	::_aUsedFields			:= {}
	::_aUsedVariables		:= {}
	::_aUsedChartFields	:= {}

	IF ::_lOptimize
		// bei arrays vorerst nicht möglich
		::_lOptimize	:= !( ascan(::_dbFields, {|a| valtype(a[1]) = "A"}) == 0 .OR. ascan(::_dbVariables, {|a| valtype(a[1]) = "A"}) == 0)
	ENDIF

	eval(::_bTop, self, ::nSelect )

	nLen  := 5000
	cTmp	:= space(nLen)
	nError	:= LLGetUsedIdentifiersEx(::hJob, ::cReport, LL_USEDIDENTIFIERSFLAG_FIELDS, @cTmp, nLen)
	IF nError == 0
		cTmp	:= _Trim0(cTmp)
		IF !empty(cTmp)
			::_aUsedFields	:= _astrextract(cTmp, ";")
			asort(::_aUsedFields)
		ENDIF
	ENDIF

	nLen  := 5000
	cTmp	:= space(nLen)
	nError	:= LLGetUsedIdentifiersEx(::hJob, ::cReport, LL_USEDIDENTIFIERSFLAG_VARIABLES, @cTmp, nLen)
	IF nError == 0
		cTmp	:= _Trim0(cTmp)
		IF !empty(cTmp)
			::_aUsedVariables	:= _astrextract(cTmp, ";")
			asort(::_aUsedVariables)
		ENDIF
	ENDIF

	nLen  := 5000
	cTmp	:= space(nLen)
	nError	:= LLGetUsedIdentifiersEx(::hJob, ::cReport, LL_USEDIDENTIFIERSFLAG_CHARTFIELDS, @cTmp, nLen)
	IF nError == 0
		cTmp	:= _Trim0(cTmp)
		IF !empty(cTmp)
			::_aUsedChartFields	:= _astrextract(cTmp, ";")
			asort(::_aUsedChartFields)
		ENDIF
	ENDIF

	cTmp	:= NIL

	::_Synchronize(1)
	::datalink(1, 1 )                                                                // erstinit variablen
	IF ::_nProject == LL_PROJECT_LIST
		::datalink(0, 1 )                                                          	// erstinit felder
	ENDIF

	IF empty( ::_cPrinter ) .AND. !empty(::__cPrinter)
		::_cPrinter	:= ::__cPrinter
	ENDIF

	IF !empty( ::_cPrinter )
		::_SetPrinter(::_cPrinter)
	ENDIF

	IF IsBlock(::_bPrepare)                                                          // User Callback
		eval(::_bPrepare, self, ::hJob )
	ENDIF

	IF !::_PrintStart()
		RETURN ::_nError
	ENDIF

	LlPrintSetOption(::hJob, LL_PRNOPT_PAGE , ::_nFirstpage )

	IF IsCharacter(::cOutFile) .AND. ( i := rat("\", ::cOutFile )) > 0
		::_cExportPath	:= left( ::cOutFile, i )
		::cOutFile := subs( ::cOutFile, ++i)
	ENDIF

	IF IsBlock(::_bConfig)                                                           // User Callback
		eval(::_bConfig, self, ::hJob )
	ENDIF

	::_PrepareExport()

	IF !::IsPreview() .AND. ::_lOptions
		::_nError   := LLPrintOptionsDialog( ::hJob, ::hWND, "")
		IF ::_nError == LL_ERR_USER_ABORTED
			::GetErrorText(::_nError)
			RETURN LL_ERR_USER_ABORTED
		ENDIF
		::GetPrinter()
	ENDIF

	nLen			:= 250
	::cOutPut	:= space(nLen)
	::cOutFile  := space(nLen)
	cPath	 		:= space(nLen)

	// das in dem Druck-dialog evt. ausgewählte Exportformat, es kann ja nur eins ausgewählt worden sein
	LlPrintGetOptionString(::hJob, LL_PRNOPTSTR_EXPORT, @::cOutPut, nLen)
	::cOutPut   := _Trim0( ::cOutPut)

	IF !empty(::cOutPut)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ::cOutPut   ,"Export.File", @::cOutFile, nLen)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ::cOutPut   ,"Export.Path", @cPath, nLen)
		::_cExportPath	:= _Trim0(cPath )
		::cOutFile		:= ::_cExportPath + _Trim0( ::cOutFile)
	ENDIF

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
	LOCAL dbTable
	LOCAL oCallBack

	IF ! IsNumber(::hJob) .OR. ::hJob <= 0							 // ::hJob kann auch NIL sein!!!
		RETURN LL_ERR_BAD_JOBHANDLE
	ENDIF

	IF ::_lDesign															// abwärtskompatibel
		RETURN ::design()
	ENDIF

	IF ::_nError = LL_ERR_USER_ABORTED
		RETURN ::_nError
	ENDIF

	IF !::_lPrepared
		// kann in Subclass überschrieben werden
		nError	:= oSelf:prepare()
		IF nError <> 0
			RETURN nError
		ENDIF
	ENDIF

	oCallBack   := LLCallBack():New(self )
	IF IsBlock( ::_bNotify)
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_VIEWERBTNCLICKED, oCallBack)
	ENDIF
	IF !empty(::_nDrillDown) .OR. !empty(::_nExpand)
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_VIEWERDRILLDOWN, oCallBack)
	ENDIF
   IF ::IsPreview()
      LlPrintSetOptionString(::hJob, LL_PRNOPTSTR_PREVIEWTITLE, ::cTitle )
   ENDIF

	nLastRec	:= ::_nLastRec
	nRec   	:= 0
	nPage  	:= 0

	IF IsBlock( bPrint )
		// LlPrint + llPrintEnd  muß hier in codeblock gestartet werden !!
		::_nError   	:= ::eval( bPrint, self, ::nSelect )
		IF !IsNumber(::_nError)
			::_nError	:= 0
		ENDIF
		::_nLastpage   := LlPrintGetCurrentPage(::hJob)

	ELSE
		IF ::_nProject == LL_PROJECT_LIST
			nLastRec   *= ::_nQuantity
			FOR _nQuantity := 1 TO ::_nQuantity
				lPrintAtEof   := ::_lPrintAtEof
				nRec     := 0
				nError   := 0
				IF !empty(::_cMaster)
					::nSelect	:= ::GetSelect(::_cMaster)
				ENDIF
				eval(::_bTop, self, ::nSelect )
				IF IsBlock(::_bCopyblock)
					eval( ::_bCopyblock, self, ::nSelect, _nQuantity )
				ENDIF
				::datalink(1, 1)
				DO WHILE LlPrint(::hJob) == LL_WRN_REPEAT_DATA; ENDDO

				IF ::_lSubReport .AND. !empty(::_cMaster)
					dbTable	:= ::GetSelect(::_cMaster)

					nRec	:= eval(::_bRecno,self,dbTable)

					DO WHILE nError != LL_ERR_USER_ABORTED .AND. (!eval(::_bEof, self, dbTable) .OR. lPrintAtEof ) .AND. (::_nPages == 0 .OR. nPage <= ::_nPages)
						cChild   := space(50)
						LlPrintDbGetCurrentTable(::hJob, @cChild, 50, FALSE )
						cChild := _Trim0( cChild )
                  IF !empty(cChild)
							nError := ::_PrintTable(cChild, ::_cMaster, 0 )
                  ENDIF
						IF nError = LL_WRN_TABLECHANGE
							loop
						ENDIF
						eval( ::_bSkip, self, dbTable)
						IF nRec == eval(::_bRecno,self,dbTable) .OR. ;                            // skip ohne eof flag
							   eval(::_bEof, self, dbTable)
							exit
						ENDIF
						nRec	:= eval(::_bRecno,self,dbTable)
						::_Synchronize( nRec)
				  		::datalink(1, nRec)
				  		::datalink(0, nRec)
						LlPrintResetProjectState(::hJob)
					ENDDO
					::_nLastpage   := LlPrintGetCurrentPage(::hJob)

				ELSEIF ::_lSubReport
					cChild   := space(50)
					LlPrintDbGetCurrentTable(::hJob, @cChild, 50, FALSE )
					cChild := _Trim0( cChild )
					IF IsBlock(::_bTableChange) .AND. cChild != "LLStaticTable"
						eval(::_bTableChange, self, TRUE, ::getSelect(cChild), "")
					ENDIF
					::nSelect	:= ::getSelect(cChild)

					IF IsArray( ::nSelect)
						DO WHILE !nError = LL_ERR_USER_ABORTED
							nError := ::_PrintTable(cChild, "", 0 )
							IF nError = LL_WRN_TABLECHANGE
								cChild   := space(50)
								LlPrintDbGetCurrentTable(::hJob, @cChild, 50, FALSE )
								cChild := _Trim0( cChild )
								IF IsBlock(::_bTableChange) .AND. cChild != "LLStaticTable"
									eval(::_bTableChange, self, TRUE, ::getSelect(cChild), "")
								ENDIF
								::nSelect	:= ::getSelect(cChild)
								IF IsBlock(::_bTableChange) .AND. cChild != "LLStaticTable"
									eval(::_bTableChange, self, FALSE, ::getSelect(cChild), "")
								ENDIF
								loop
							ENDIF
							exit
						ENDDO
						DO WHILE (nError := LlPrintFieldsEnd(::hJob)) == LL_WRN_REPEAT_DATA; ENDDO
						::_nLastpage   := LlPrintGetCurrentPage(::hJob)

					ELSE
						DO WHILE !nError = LL_ERR_USER_ABORTED

							nError := ::_PrintTable(cChild, ::_cMaster, 0 )

							IF nError = LL_WRN_TABLECHANGE
								cChild   := space(50)
								LlPrintDbGetCurrentTable(::hJob, @cChild, 50, FALSE )
								cChild := _Trim0( cChild )
								IF IsBlock(::_bTableChange) .AND. cChild != "LLStaticTable"
									eval(::_bTableChange, self, TRUE, ::getSelect(cChild), "")
								ENDIF
								::nSelect	:= ::getSelect(cChild)

								IF IsBlock(::_bTableChange) .AND. cChild != "LLStaticTable"
									eval(::_bTableChange, self, FALSE, ::getSelect(cChild), "")
								ENDIF
								loop
							ENDIF
							exit
						ENDDO
						DO WHILE (nError := LlPrintFieldsEnd(::hJob)) == LL_WRN_REPEAT_DATA; ENDDO
						::_nLastpage   := LlPrintGetCurrentPage(::hJob)
						::GetErrorText(nError)
					ENDIF

				ELSEIF IsArray( ::nSelect)
					nLastRec	:= len(::nSelect)
					FOR nPrint := 1 TO nLastRec
						::_Synchronize(nPrint)
						::datalink(0, nPrint)
						DO WHILE (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
							LlPrint(::hJob)
						ENDDO
						nPage		:= LlPrintGetCurrentPage(::hJob)
						LlPrintSetBoxText(::hJob, ::_cPrintText, nPrint / nLastRec * 100 )
						IF ::_nPages > 0 .AND. nPage > ::_nPages
							exit
						ENDIF
					NEXT
					DO WHILE (nError := LlPrintFieldsEnd(::hJob)) == LL_WRN_REPEAT_DATA; ENDDO
					::_nLastpage   := LlPrintGetCurrentPage(::hJob)

				ELSE
					DO WHILE nError == 0 .AND. (!eval(::_bEof, self, ::nSelect) .OR. lPrintAtEof ) .AND. nRec <> eval(::_bRecno,self,::nSelect) .AND. (::_nPages == 0 .OR. nPage <= ::_nPages)
						nRec   := eval(::_bRecno, self,::nSelect)
						lPrintAtEof   := FALSE
						::_Synchronize( nRec, ::nSelect)
						::datalink(0, nRec)
						DO WHILE (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
							::datalink(1, nRec)
							LlPrint(::hJob)
						ENDDO
						nPage		:= LlPrintGetCurrentPage(::hJob)
						eval( ::_bSkip, self, ::nSelect)
						LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / nLastRec * 100 )
					ENDDO
					DO WHILE (nError := LlPrintFieldsEnd(::hJob)) == LL_WRN_REPEAT_DATA; ENDDO
					::_nLastpage   := LlPrintGetCurrentPage(::hJob)
				ENDIF
				IF (::IsPreview() .AND. !IsBlock(::_bCopyblock)) .OR. nError == LL_ERR_USER_ABORTED
					::GetErrorText(nError)
					exit
				ENDIF
				LlPrintResetProjectState(::hJob)
			NEXT

		ELSEIF IsObject(::nSelect )									    // CRD oder LBL
			eval(::_bTop, self, ::nSelect )
			DO WHILE nError == 0 .AND. (!::nSelect:eof() .OR. ::_lPrintAtEof) .AND. nRec <> ::nSelect:recno() .AND. (::_nPages == 0 .OR. nPage <= ::_nPages)
				nRec   := ::nSelect:recno()
				::_lPrintAtEof   := FALSE
				::_Synchronize( nRec, ::nSelect)
				::datalink(1, nRec)
				FOR _nQuantity := 1 TO ::_nQuantity
					DO WHILE (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA	;ENDDO
				NEXT
				nPage		:= LlPrintGetCurrentPage(::hJob)
				eval( ::_bSkip, self, ::nSelect)
				LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / nLastRec * 100 )
			ENDDO

		ELSEIF IsNumber(::nSelect) .AND. ::nSelect > 0									    // CRD oder LBL
			eval(::_bTop, self, ::nSelect )
			DO WHILE nError == 0 .AND. (!(::nSelect)->(eof()) .OR. ::_lPrintAtEof) .AND. nRec <> (::nSelect)->(recno()) .AND. (::_nPages == 0 .OR. nPage <= ::_nPages)
				nRec   := (::nSelect)->(recno())
				::_lPrintAtEof   := FALSE
				::_Synchronize( nRec, ::nSelect)
				::datalink(1, nRec)
				FOR _nQuantity := 1 TO ::_nQuantity
					DO WHILE (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA	;ENDDO
				NEXT
				nPage		:= LlPrintGetCurrentPage(::hJob)
				eval( ::_bSkip, self, ::nSelect)
				LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / nLastRec * 100 )
			ENDDO

		ELSEIF IsArray( ::nSelect)
			FOR nPrint := 1 TO nLastRec
				::_Synchronize( nPrint)
				::datalink(1, nPrint)
				FOR _nQuantity := 1 TO ::_nQuantity
					DO WHILE (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA	;ENDDO
				NEXT
				nPage		:= LlPrintGetCurrentPage(::hJob)
				IF ::_nPages > 0 .AND. nPage > ::_nPages
					exit
				ENDIF
				LlPrintSetBoxText(::hJob, ::_cPrintText, nPrint / nLastRec * 100 )
			NEXT

		ELSE
			// aktuelle Daten einmal ausgeben,
			FOR _nQuantity := 1 TO ::_nQuantity
				DO WHILE (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA .AND. ::_nProject <> LL_PROJECT_LABEL .AND. (::_nPages == 0 .OR. nPage <= ::_nPages); ENDDO
				nPage		:= LlPrintGetCurrentPage(::hJob)
				LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / ::_nQuantity * 100 )
			NEXT
		ENDIF
		::_nLastpage   := LlPrintGetCurrentPage(::hJob)
		::_nError 		:= LlPrintEnd(::hJob,0)
		::_RaiseError(::_nError, ::cReport, "LlPrintEnd()")
	ENDIF

	IF ::_nError == 0 .AND. IsBlock(::_bNotify) .AND. !::IsPreView()
		// falls direkt druck
		eval( ::_bNotify, LL_NTFY_AFTERPRINT, MNUID_LL_PRINT, self )
	ENDIF

	IF !empty(llGetOption( ::hJob, LL_OPTION_INCREMENTAL_PREVIEW ))
		LlPreviewDeleteFiles(::hJob, ::cReport, ::__cTempPath)
	ENDIF

	IF IsObject(oCallBack)
		oCallBack:destroy()
	ENDIF
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

	IF ! IsNumber(::hJob) .OR. ::hJob <= 0                                           // ::hJob kann auch NIL sein!!!
		RETURN LL_ERR_BAD_JOBHANDLE
	ENDIF
	::_lDesign	:= TRUE

	::_Synchronize( 1 )
	::datalink(1, 1 )                                                                 // erstinit variablen
	IF ::_nProject == LL_PROJECT_LIST
		::datalink(0, 1 )                                                         // erstinit felder
	ENDIF

	IF IsBlock(::_bPrepare)
		eval(::_bPrepare, self, ::nSelect )
	ENDIF

	oCallBack   := LLCallBack():New(self )
	IF ::_lStreamMode
		LlSetNotificationCallbackExt(::hJob, LL_CMND_SAVEFILENAME, oCallBack)
	ENDIF

	IF ::_lDesignerPreview
  		LlSetOption(::hJob,LL_OPTION_DESIGNERPREVIEWPARAMETER, 1)
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_DESIGNERPRINTJOB, oCallBack)
		IF !empty(::_nDrillDown) .OR. !empty(::_nExpand)
			LlSetNotificationCallbackExt(::hJob, LL_NTFY_VIEWERDRILLDOWN, oCallBack)
		ENDIF
	ENDIF

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

	IF cChild == "LLStaticTable"
		nError := LlPrintFields(::hJob)
		DO WHILE nError == LL_WRN_REPEAT_DATA
			DO WHILE LlPrint(::hJob) == LL_WRN_REPEAT_DATA
			ENDDO
			nError	:= LlPrintFields(::hJob)
		ENDDO
		nError	:= LlPrintFieldsEnd(::hJob)
		RETURN nError
	ENDIF

	nPage			:= 0
	nPrint 		:= 0
	nSelect		:= ::getSelect(cChild)
	cRelation	:= space(200)
	nError		:= LlPrintDbGetCurrentTableRelation(::hJob, @cRelation, 200 )
	cRelation	:= _Trim0( cRelation )
	dbChild		:= nSelect
	IF !empty(cParent)
		dbParent	:= ::getSelect(cParent)
	ENDIF

	eval(::_bTop, self, nSelect )
	::nSelect   := nSelect
	::_Synchronize( -1, cParent)
	::datalink(0, 1 )

	IF IsArray( nSelect)
		IF !empty(cRelation)
			// kann in Subclass überschrieben werden
			oSelf:SetChildRelation(cRelation, cParent, cChild, @nScope)
		ENDIF

		nLastRec	:= len( nSelect)
		nRecNo	   := 0

		DO WHILE nError == 0 .AND. nRecNo < nLastrec  .AND. (::_nPages == 0 .OR. nPage <= ::_nPages)
			nRecNo++
			::_Synchronize( nRecNo, cChild )
			::datalink(0, nRecNo )
			DO WHILE (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
				DO WHILE LlPrint(::hJob) == LL_WRN_REPEAT_DATA
				ENDDO
			ENDDO
			DO WHILE nError == LL_WRN_TABLECHANGE
				cSubChild   := space(50)
				LlPrintDbGetCurrentTable(::hJob, @cSubChild, 50, FALSE )
				cSubChild := _Trim0( cSubChild )

				IF IsBlock(::_bTableChange) .AND. cChild != "LLStaticTable"
					eval(::_bTableChange, self, TRUE, cSubChild, cChild, nRecNo )
				ENDIF

				nError := ::_PrintTable(cSubChild, cChild, 0 )
			ENDDO
			nPage		:= LlPrintGetCurrentPage(::hJob)
         IF empty(cParent)
				LlPrintSetBoxText(::hJob, ::_cPrintText, nRecNo / nLastRec * 100 )
         ENDIF
		ENDDO

	ELSE
		IF !empty(cRelation)
			// kann in Subclass überschrieben werden
			oSelf:SetChildRelation(cRelation, coalesce(dbParent, ::getSelect(::_cMaster), ::_nRootSelect), nSelect, @nScope)
		ENDIF

		DO WHILE nError == 0 .AND. !eval(::_bEof, self, nSelect) .AND. (::_nPages == 0 .OR. nPage <= ::_nPages)
			nRecNo	:= eval(::_bRecno,self,nSelect)
			::_Synchronize( nRecNo, nSelect )
			::datalink(0, nRecNo )
			DO WHILE (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
				DO WHILE LlPrint(::hJob) == LL_WRN_REPEAT_DATA
				ENDDO
			ENDDO

			DO WHILE nError == LL_WRN_TABLECHANGE
				cSubChild		:= space(50)
				nError	:= LlPrintDbGetCurrentTable(::hJob, @cSubChild, 50, FALSE )
				cSubChild		:= _Trim0( cSubChild )

				IF IsBlock(::_bTableChange) .AND. cChild != "LLStaticTable"
					eval(::_bTableChange, self, TRUE, cSubChild, cChild, nRecNo )
				ENDIF

				nError	:= ::_PrintTable(cSubChild, cChild, nRek + 1 )
			ENDDO
			nPage		:= LlPrintGetCurrentPage(::hJob)
			eval( ::_bSkip, self, nSelect)
         IF empty(cParent)
				LlPrintSetBoxText(::hJob, ::_cPrintText, ++nPrint / ::_nLastRec * 100 )
         ENDIF
		ENDDO
	ENDIF
	::GetErrorText(nError)

	IF nError != LL_ERR_USER_ABORTED
		DO WHILE (nError := LlPrintFieldsEnd(::hJob)) == LL_WRN_REPEAT_DATA ;ENDDO
	ENDIF
	::_nLastpage   := LlPrintGetCurrentPage(::hJob)

	IF nScope = 1
		IF IsObject(dbChild)
			dbChild:clearscope()
		ELSE
			(dbChild)->(dbClearScope(SCOPE_BOTH))
		ENDIF
	ENDIF
	::nSelect   := nOSelect

RETURN nError

//=========================================
METHOD dsListLabel:_PrepareExport()
	LOCAL aExport
	LOCAL i, iCnt
	LOCAL cOutFile	:= ::cOutFile

	IF empty(::cExportFormat)
		RETURN self
	ENDIF

	aExport   := _astrextract(::cExportFormat, ";")
	iCnt	:= len( aExport)

	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ""   ,"Export.Path", ::_cExportPath)
	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ""   ,"Export.ShowResult", ::cShowExport)

	IF empty(cOutFile)
		cOutFile	:= "LLEXPORT"+dtos(date())+strtran(time(),":")
	ELSE
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
	ENDIF

	FOR i := 1 TO iCnt
		IF aExport[i] = "PDF"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"	,"Export.File", _SetExtension(cOutFile, "PDF") )

		ELSEIF aExport[i] = "XHTML"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XHTML","Export.File", _SetExtension(cOutFile, "HTML") )

		ELSEIF aExport[i] = "HTML"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "HTML" ,"Export.File", _SetExtension(cOutFile, "HTML") )

		ELSEIF aExport[i] = "JQM"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "JQM"  ,"Export.File", _SetExtension(cOutFile, "HTML") )

		ELSEIF aExport[i] = "PPTX"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PPTX" ,"Export.File", _SetExtension(cOutFile, "PPTX") )

		ELSEIF aExport[i] = "XLS"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XLS"  ,"Export.File", _SetExtension(cOutFile, "XLS") )

		ELSEIF aExport[i] = "XML"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XML"  ,"Export.File", _SetExtension(cOutFile, "XML"))

		ELSEIF aExport[i] = "TXT"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"  ,"Export.OnlyTableData", "1")
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"  ,"Export.FrameChar", "NONE")
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"  ,"Export.SeparatorChar", ";")
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"  ,"Export.File", _SetExtension(cOutFile, "TXT"))

		ELSEIF aExport[i] = "PICTURE_JPEG"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_JPEG"  ,"Export.File", _SetExtension(cOutFile, "JPG"))

		ELSEIF aExport[i] = "PICTURE_TIFF"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_TIFF"  ,"Export.File", _SetExtension(cOutFile, "TIF"))

		ELSEIF aExport[i] = "PICTURE_BMP"
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_BMP"	,"Export.File", _SetExtension(cOutFile, "BMP"))
		ENDIF
	NEXT
	LLSetOptionString(::hJob, LL_OPTIONSTR_EXPORTS_ALLOWED, ::cExportFormat)
	IF ! ";" $ ::cExportFormat                                                       // nur 1 Export def., dann keine Auswahl
		::_nError	:= LlPrintSetOptionString(::hJob, LL_PRNOPTSTR_EXPORT, ::cExportFormat)
		::_RaiseError(::_nError, ::cExportFormat, "LlPrintSetOptionString(LL_PRNOPTSTR_EXPORT)")
		::_lOptions   := FALSE
	ELSE
		::_lOptions   := TRUE
	ENDIF
RETURN self

//=========================================
METHOD dsListLabel:_Synchronize(nRecno, cMaster )
	LOCAL i, iCnt

	iCnt   := len( ::_aSync)
	FOR i := 1 TO iCnt
		IF IsBlock(::_aSync[i])
			::eval( ::_aSync[i], self, ::nSelect, nRecno, cMaster )
		ENDIF
	NEXT
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
	IF empty(cRelation)
		pnScope	:= 0
		RETURN self
	ENDIF

	IF (nPos := at("@scope?", cRelation)) > 0
		bKey	:= &("{|o,dbP,dbC| " + subs(cRelation,nPos+7) +"}")
		IF IsObject(dbChild)
			aKey	:= eval( bKey, self, dbParent, dbChild )
			IF aKey != NIL
				dbChild:setscope(SCOPE_BOTH, aKey )
			ENDIF
		ELSE
			aKey	:= (dbParent)->(eval( bKey, self, dbParent, dbChild ))
			IF aKey != NIL
				(dbChild)->(dbSetScope(SCOPE_BOTH, aKey))
			ENDIF
		ENDIF
		pnScope	:= 1

	ELSEIF (nPos := at("@raw?", cRelation)) > 0                                          //.OR. (nPos := at(";", cRelation)) > 0
		// nur AdsClass++, rawkey-scope
		aKey     := _aStrExtract(subs(cRelation,nPos+5), ";")
		aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, TRUE )
		IF len(aKey) == 1
			aKey	:= aKey[1]
		ENDIF
		IF IsObject(dbChild)
			dbChild:setscope(SCOPE_BOTH, aKey )
		ENDIF
		pnScope	:= 1

	ELSEIF (nPos := at("@param?", cRelation)) > 0
		// nur mit SQL, daher auch nur mit Tabellenobjekten möglich
		// bezeichnung@param:rec_id=4711&wert=klar
		cRelation:= subs(cRelation, nPos+7 )
		aKey     := _aStrExtract(cRelation, "&")
		iCnt		:= len( aKey)
		IF dbChild:IsDerivedfrom("dsAceQTable")
			// ADS arbeitet mit named Parameter, deswegen immer ein Pärchen: {name,wert}
			FOR i := 1 TO iCnt
				IF ";" $ aKey[i]
					aTmp	:= _aStrExtract(aKey[i], ";" )
					dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
				ELSEIF ":" $ aKey[i]
					aTmp	:= _aStrExtract(aKey[i], ":" )
					dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
				ELSEIF "=" $ aKey[i]
					aTmp	:= _aStrExtract(aKey[i], "=" )
					dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
				ENDIF
			NEXT
			dbChild:refreshSql(TRUE)

		ELSEIF dbChild:IsDerivedfrom("dsPQselect")
			// bezeichnung@param:4711&klar
			// PostgreSQL arbeitet mit nummerierten Parametern, keine Nummer darf fehlen, keine darf doppelt erscheinen
			// deswegen werden immer alle Parameter in der richtigen Reihenfolge definiert
			aTmp	:= {}
			FOR i := 1 TO iCnt
				aadd( aTmp, dbParent:fieldget(aKey[i]))
			NEXT
			dbChild:execute(, aTmp)
		ENDIF

	ELSEIF (nPos := at("<", cRelation)) > 0
		aKey     := _aStrExtract(subs(cRelation,nPos+1), ";")
		IF IsObject(dbParent)
			aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, TRUE )
		ELSE
			aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"),), a := (dbParent)->(fieldget(fieldpos(a)))},,, TRUE )
		ENDIF
		IF len(aKey) == 1
			aKey	:= aKey[1]
		ENDIF
		IF IsObject(dbChild)
			dbChild:setscope(SCOPE_BOTH, aKey )
		ELSE
			(dbChild)->(dbSetScope(SCOPE_BOTH, aKey))
		ENDIF
		pnScope	:= 1

#ifdef _XCLASS
		// only FOR backward compatibility
	ELSEIF left(cRelation,1 ) = "&"
		bKey	:= &("{|o,dbP,dbC| " + subs(cRelation,2) +"}")
		aKey	:= eval( bKey, self, dbParent, dbChild )
		IF aKey != NIL
			dbChild:setscope(, aKey )
			pnScope	:= 1
		ENDIF

	ELSEIF left(cRelation,1 ) $ "<;"
		aKey     := _aStrExtract(subs(cRelation,2), ";")
		aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, TRUE )
		IF len(aKey) == 1
			aKey	:= aKey[1]
		ENDIF
		dbChild:setscope(, aKey )
		pnScope	:= 1

	ELSEIF (nPos := at("$", cRelation)) > 0
		aKey     := _aStrExtract(subs(cRelation,nPos+1), "$")
		iCnt	:= len( aKey)
		FOR i := 1 TO iCnt
			IF ";" $ aKey[i]
				aTmp	:= _aStrExtract(aKey[i], ";" )
				dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
			ELSEIF ":" $ aKey[i]
				aTmp	:= aStrExtract(aKey[i], ":" )
				dbChild:SqlConn():setparam( aTmp[1], dbParent:fieldget(aTmp[2]))
			ELSE
				dbChild:SqlConn():setparam( aKey[i], dbParent:fieldget(aKey[i]))
			ENDIF
		NEXT
		dbChild:refreshSql()

	ELSEIF ";" $ cRelation
		aKey     := _aStrExtract(cRelation, ";")
		aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, TRUE )
		IF len(aKey) == 1
			aKey	:= aKey[1]
		ENDIF
		dbChild:setscope(, aKey )
		pnScope	:= 1

#ENDIF

	ENDIF
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

	IF nQuantity = NIL
		nQuantity	:= coalesce(::_nQuantity,1)
	ENDIF

	::_Synchronize( 1)
	::datalink(1, 1)
	DO WHILE ::_nError == 0 .AND. nPos++ < nQuantity
      DllExecuteCall( ::templateDefineFieldExt,::hJob,  "Number" ,var2char(nPos)   ,LL_NUMERIC, 0 )
		::_nError	:= LlPrint(::hJob)
		LlPrintSetBoxText(::hJob, ::_cPrintText, nPos / nQuantity * 100 )
	ENDDO
	IF empty(lJobOpen)
		LlPrintEnd(::hJob,0)
	ENDIF
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

	IF !empty(::_hDevmode)
		LocalFree( ::_hDevmode)
	ENDIF

	::templateDefineFieldExt		:= NIL
	::templateDefineVariableExt	:= NIL

	::_DataObject	:= NIL
	::_nStatus		:= XBP_STAT_INIT
	IF IsNumber(::hJob) .AND. ::hJob > 0                                             // ::hJob kann auch NIL sein!!!
		LlJobClose(::hJob)
	ENDIF
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
	IF empty(cSymbol)
		RETURN NIL
	ELSEIF IsNumber(cSymbol)
		RETURN cSymbol
	ELSEIF IsObject(cSymbol)
		RETURN cSymbol
	ENDIF
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
	IF IsNumber(xSet)
		nDebug   	:= xSet
	ELSEIF IsLogical(xSet)
		IF xSet
			nDebug	:= LL_DEBUG_CMBTLL
		ELSE
			nDebug	:= 0
		ENDIF
	ENDIF
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

	IF nProject != NIL
		::_nProject	:= nProject
	ENDIF
	IF IsCharacter(cReport )                                                           // diesen Report auswählen
		iCnt	:= len( ::_aPath)
		FOR i := 1 TO iCnt
			IF file( _Fullpath( cReport, ::_aPath[i]))
				::cReport	:= _Fullpath( cReport, ::_aPath[i] )
				exit
			ENDIF
		NEXT
		IF empty(::cReport)
			iCnt	:= len( ::__aDefaultPath)
			FOR i := 1 TO iCnt
				IF file( _Fullpath( cReport, ::__aDefaultPath[i]))
					::cReport	:= _Fullpath( cReport, ::__aDefaultPath[i] )
					exit
				ENDIF
			NEXT
		ENDIF

	ELSEIF !empty( ::hJob )
		IF !empty(::_aPath)
			curdir(::_aPath[1])
		ELSEIF !Empty(::__aDefaultPath)
			curdir(::__aDefaultPath[1])
		ENDIF
		::cReport	:= replicate(chr(0),255)
		::_nError	:= LlSelectFileDlgTitleEx( ::hJob, ::hWND, coalesce( cTitle, "Select file"), ::_nProject, @::cReport, 255)
		IF ::_nError <> 0
			::GetErrorText(::_nError)
		ENDIF
		::cReport	:= _trim0(::cReport)
	ENDIF

	IF nProject == NIL .AND. !empty( ::cReport)
		cTmp	:= upper( right(::cReport,3))

		IF cTmp = "CRD"
			::_nProject	:= LL_PROJECT_CARD
		ELSEIF cTmp = "LST"
			::_nProject	:= LL_PROJECT_LIST
		ELSEIF cTmp = "LBL"
			::_nProject	:= LL_PROJECT_LABEL
		ENDIF
	ENDIF
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
	IF IsObject(nSelect) .OR. IsArray(nSelect)
		::nSelect   := nSelect

	ELSE
		IF pcount() > 0
			IF IsCharacter(nSelect)
				nSelect   := select(nSelect)
			ENDIF
			::nSelect   := nSelect
		ELSE
			::nSelect   := Select()
		ENDIF
	ENDIF
RETURN self

//=========================================
METHOD dsListLabel:_PrintStart()
	IF ::_nBoxType >= 0
		::_nError   := LlPrintWithBoxStart(::hJob,	;
			::_nProject,;
			::cReport,;
			::_nPrintOption,;
			::_nBoxType,;
			::hWND,;
			::cTitle )
	ELSE
		::_nError   := LlPrintStart(::hJob,;
			::_nProject,;
			::cReport,;
			::_nPrintOption )
	ENDIF
	IF ::_nError == 0
		::_nStatus   := XBP_STAT_CREATE

	ELSEIF ::_nError == LL_ERR_USER_ABORTED
		// quit, no error
		::_nStatus   := XBP_STAT_INIT
		::GetErrorText(::_nError)

	ELSE
		::_nStatus   := XBP_STAT_FAILURE
		::_RaiseError(::_nError, ::cReport, "LlPrint[WithBox]Start()" )
	ENDIF
RETURN ::_nError == 0

//=========================================
METHOD dsListLabel:_SetPrinter(cPrinter)
	IF empty( cPrinter)
		cPrinter   := ::_cPrinter
	ENDIF
	IF !empty( cPrinter) .AND. !empty(::hJob)
		LlSetPrinterInPrinterFile(::hJob, ::_nProject, ::cReport, -1, cPrinter, 0)
	ENDIF
RETURN self

//=========================================
METHOD dsListLabel:SetDevMode(cProperty, xValue, nIndex )
	LOCAL nError
	IF empty(::_hDevMode)
		nError	:= ::_InitDevMode(nIndex)
	ENDIF
   IF ascan( ::oDevmode:classdescribe(3), lower(cProperty)) > 0
		::oDevMode:&(cProperty)	:= xValue
		nError	:= LlSetPrinterInPrinterFile(::hJob, ::_nProject, ::cReport, nIndex, , ::_hDevmode)
   ELSE
   	nError	:= -1
   ENDIF
RETURN nError

//=========================================
METHOD dsListLabel:GetDevMode(cProperty)
	IF empty(::_hDevMode)
		::_InitDevMode()
	ENDIF
   IF ascan( ::oDevmode:classdescribe(3), lower(cProperty)) > 0
		RETURN ::oDevMode:&(cProperty)
	ENDIF
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
	IF !empty(::hJob)
		LlSetPrinterToDefault(::hJob, ::_nProject, ::cReport)
	ENDIF
RETURN self

//=========================================
METHOD dsListLabel:SetTitle(xSet)
	IF IsCharacter(xSet)
		::cTitle   := xSet
	ENDIF
RETURN self

//=========================================
METHOD dsListLabel:PrintOption(nPrtMode)
	local nOMode	:= ::_nPrintOption
	IF IsNumber(nPrtMode)
		::_nPrintOption	:= nPrtMode
	ENDIF
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
	IF IsLogical(xSet)
		IF xSet
			::_nPrintOption := LL_PRINT_EXPORT
		ELSE
			::_nPrintOption := LL_PRINT_NORMAL
		ENDIF
	ENDIF
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
	IF IsLogical(xSet)
		IF xSet
			::_nPrintOption := LL_PRINT_PREVIEW
		ELSE
			::_nPrintOption := LL_PRINT_NORMAL
		ENDIF
	ENDIF
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
	IF IsCharacter(cReport)
      ::cReport   := cReport
		IF !file(cReport)
			iCnt	:= len( ::_aPath)
			FOR i := 1 TO iCnt
				IF file( _Fullpath( cReport, ::_aPath[i] ))
					::cReport	:= _Fullpath( cReport, ::_aPath[i] )
					exit
				ENDIF
			NEXT
      ENDIF
		IF !file(::cReport)
			iCnt	:= len( ::__aDefaultPath)
			FOR i := 1 TO iCnt
				IF file( _Fullpath( cReport, ::__aDefaultPath[i] ))
					::cReport	:= _Fullpath( cReport, ::__aDefaultPath[i] )
					exit
				ENDIF
			NEXT
		ENDIF

		// autodetect Projekttype
		cReport	:= upper( right(::cReport,3))
		IF cReport = "CRD"
			::_nProject	:= LL_PROJECT_CARD
		ELSEIF cReport = "LST"
			::_nProject	:= LL_PROJECT_LIST
		ELSEIF cReport = "LBL"
			::_nProject	:= LL_PROJECT_LABEL
		ENDIF
	ENDIF
RETURN ::cReport

//=========================================
METHOD dsListLabel:Stream2Report(cStream, nProject)
	LOCAL hHandle

	IF IsNumber( nProject )
		::_nProject   := nProject
	ENDIF

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
	IF hHandle < 0
		pnError	:= ferror()
		RETURN ""
	ENDIF
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
	IF IsLogical(xSet)
		::_lOptions := xSet
	ENDIF
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
	IF IsCharacter(xSet) .AND. !empty(xSet)
		::_cPrinter := xSet
		::_lOptions := FALSE

	ELSEIF pcount() == 1 .AND. empty(xSet)
		::_cPrinter := NIL
		::_lOptions := TRUE
	ENDIF
	IF !empty( ::_cPrinter) .AND. !empty(::hJob)
		LlSetPrinterInPrinterFile(::hJob, ::_nProject, ::cReport, -1, ::_cPrinter, 0)
	ENDIF
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

	IF IsBlock(::datalink) .AND. !::_lDesign
		IF nMode == 0
			lRet	:= eval(::datalink, self, nMode, nRecno)
		ELSE
			lRet	:= eval(::datalink, self, nMode, nRecno)
		ENDIF
		IF !IsLogic(lRet) .AND. lRet
			RETURN self
		ENDIF

	ELSEIF ::_lOptimize .AND. !::_lDesign
		IF nMode == 0
			iCnt := len( ::_aUsedFields)
			// nur mit
			FOR i := 1 TO iCnt
				dbTable	:= NIL
				IF (nPos := rat(".", ::_aUsedFields[i])) > 0
					nPos2 	:= rat(".", ::_aUsedFields[i], nPos -1)
					cTable	:= subs(::_aUsedFields[i], nPos2+1, nPos - nPos2 - 1)
					dbTable	:= ::GetDbContainer(cTable, FALSE )
					cField	:= subs(::_aUsedFields[i], nPos + 1)
				ELSE
					cTable	:= ""
					cField	:= ::_aUsedFields[i]
				ENDIF
				IF IsObject( dbTable ) .AND. dbTable:IsField(cField)
					::SetValue( nMode, ::_aUsedFields[i], dbTable:fieldget(cField))

				ELSEIF IsNumber( dbTable ) .AND. (dbTable)->(Fieldpos(cField)) > 0
					::SetValue( nMode, ::_aUsedFields[i], (dbTable)->(fieldget(Fieldpos(cField))))

				ELSEIF Fieldpos(cField) > 0
					::SetValue( nMode, ::_aUsedFields[i], fieldget(Fieldpos(cField)))
				ENDIF
			NEXT
		ELSE
			iCnt := len( ::_aUsedVariables)
			FOR i := 1 TO iCnt
				dbTable	:= NIL
				// ::_aUsedVariables[i] => "AUFTRAG.ARTIKEL.ARTBEZ"
				IF (nPos := rat(".", ::_aUsedVariables[i])) > 0
					nPos2 := rat(".", ::_aUsedVariables[i], nPos -1)
					cTable  := subs(::_aUsedVariables[i], nPos2+1, nPos - nPos2 - 1)
					dbTable := ::GetDbContainer(cTable, FALSE )
					cField  := subs(::_aUsedVariables[i], nPos + 1)
				ELSE
					cTable	:= ""
					cField	:= ::_aUsedFields[i]
				ENDIF

				IF IsObject( dbTable ) .AND. dbTable:IsField(cField)
					::SetValue( nMode, ::_aUsedFields[i], dbTable:fieldget(cField))

				ELSEIF IsNumber( dbTable ) .AND. (dbTable)->(Fieldpos(cField)) > 0
					::SetValue( nMode, ::_aUsedFields[i], (dbTable)->(fieldget(Fieldpos(cField))))

				ELSEIF Fieldpos(cField) > 0
					::SetValue( nMode, ::_aUsedFields[i], fieldget(Fieldpos(cField)))
				ENDIF
			NEXT
		ENDIF
	ELSE
		IF nMode == 0
			aDb   := ::_dbFields
		ELSE
			aDb   := ::_dbVariables
		ENDIF

		iCnt   := len( aDb)
		FOR i := 1 TO iCnt
			IF aDb[i] == NIL
				aremove(aDb, i)
				iCnt--
				loop
			ENDIF
			::_datalink( nMode, aDb[i,__SELECT], aDb[i,__LLDESC], aDb[i,__STRUCT], nRecno)
		NEXT
	ENDIF
	IF nMode == 0
		::_VarLink(nMode, ::_aField, nRecno )
	ELSE
		::_VarLink(nMode, ::_aVar, nRecno )
	ENDIF

RETURN self

//=========================================
METHOD dsListLabel:DatalinkTable(nMode, xServer, nRec )
	LOCAL cDesigner
	LOCAL aField, aList
	LOCAL nPos	:= 0

	IF nMode == 0
		aList	:= ::_dbFields
	ELSE
		aList	:= ::_dbVariables
	ENDIF

	IF IsCharacter(xServer)                                                          // 1. Parameter von :datasetField
		nPos := ascan(aList, {|a| a[__SYMBOL] == xServer })
		IF nPos > 0
			aField	:= aList[nPos,__STRUCT]
			cDesigner:= aList[nPos,__LLDESC]
			xServer	:= aList[nPos,__SELECT]
		ENDIF
	ELSE                                                                          // Server oder select bereich, 1. Parameter von :datasetField
		nPos := ascan(aList, {|a| a[__SELECT] == xServer })
		IF nPos > 0
			aField	:= aList[nPos,__STRUCT]
			cDesigner:= aList[nPos,__LLDESC]
		ENDIF
	ENDIF
	IF nPos == 0
		RETURN self
	ENDIF
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

	IF xValue == NIL
		RETURN FALSE
	ENDIF

	IF valtype(xValue) = "N"
		// var2lchar setzt 2 decimalen [set(_SET_DECIMALS)] und ignoriert die Genauigkeit der Zahl
		nLL   := coalesce(nLL, LL_NUMERIC)
		cStr  := ntrim(xValue)
		IF xValue == int(xValue)
			nLL   := LL_NUMERIC_INTEGER
		ENDIF

	ELSEIF valtype(xValue) = "D"
		nLL   := coalesce(nLL, LL_DATE_YYYYMMDD)
		IF !empty( xValue)
			cStr	:= dtos(xValue)
		ELSE
			cStr	:= '(NULL)'
		ENDIF

	ELSEIF valtype(xValue) = "L"
		nLL	:= coalesce(nLL, LL_BOOLEAN)
		cStr	:= if(xValue, "T","F")

	ELSE
		nLL   := coalesce(nLL, LL_TEXT)
		IF Set( _SET_CHARSET ) == CHARSET_OEM
			cStr  := alltrim(ConvtoAnsiCP(xValue))
		ELSE
			cStr  := alltrim(xValue)
		ENDIF

		IF empty( cStr)
			cStr	:= " "
		ELSEIF left(cStr,5) = "{\rtf"
			nLL   := coalesce(nLL, LL_RTF)
		ENDIF
	ENDIF
	IF empty( nMode )
      DllExecuteCall( ::templateDefineFieldExt,::hJob, cName, cStr, nLL, 0 )
	ELSE
      DllExecuteCall( ::templateDefineVariableExt,::hJob, cName, cStr, nLL, 0 )
	ENDIF
RETURN TRUE

//=========================================
METHOD dsListLabel:_datalink(nMode, nSelect, cDesigner, aField, nRecno )
	LOCAL cId
	LOCAL xRet
	LOCAL i, iCnt, nPos
	LOCAL lStruct   	:= FALSE
	LOCAL nSourceType	:= 0

	IF IsObject(nSelect)
		IF nSelect:IsDerivedfrom("dataobject")
			nSourceType	+= 2
		ELSE
			nSourceType	+= 1
		ENDIF
	ELSEIF IsArray(nSelect)
		nSourceType		+= 4
		IF nRecno > len(nSelect)
			RETURN self
		ENDIF
	ENDIF

	DEFAULT cDesigner TO ""

	IF !IsArray( aField)
		IF IsObject(nSelect)
			IF IsMethod(nSelect,"dbstruct")
				aField	:= nSelect:dbstruct()
			ENDIF
		ELSEIF !empty(nSelect)
			aField	:= (nSelect)->(dbstruct())
		ENDIF
	ENDIF

	iCnt	:= len( aField)
	IF iCnt = 0
		RETURN self
	ENDIF
	lStruct	:= IsArray(aField[1]) .AND. len( aField[1]) >= 3                        // stimmt auch bei dataobject

	IF !empty(cDesigner) .AND. !cDesigner[-1] $ ".:"
		cDesigner	+= "."
	ENDIF

	FOR i := 1 TO iCnt
		IF lStruct
			cId   := aField[i,1]
			IF !empty(::_cIgnoreField) .AND. like( ::_cIgnoreField ,aField[i,1])
				loop
			ENDIF
			IF nSourceType == 0
				xRet	:= if(IsObject(nSelect), nSelect:fieldget(i),(nSelect)->(fieldget(i)))
			ELSEIF nSourceType == 1

				xRet	:= if(IsObject(nSelect), nSelect:fieldget(i),(nSelect)->(fieldget(i)))
			ELSE
				xRet	:= nSelect:&cId.
			ENDIF
		ELSE
			IF !IsArray(aField[i])
				cId	:= aField[i]
				IF nSourceType == 4                                                     // array mit dataobject
					xRet	:= nSelect[nRecno]:&cId.
				ELSE
					IF nSourceType == 0
						nPos	:= (nSelect)->(fieldpos(aField[i]))
						xRet	:= (nSelect)->(fieldget(nPos))

					ELSEIF nSourceType == 1
						xRet	:= nSelect:fieldget(aField[i])

					ELSEIF nSourceType == 2
						xRet	:= nSelect:&cId.
					ENDIF
				ENDIF

			ELSEIF IsBlock(aField[i,2])
				cId	:= aField[i,1]
				xRet	:= eval(aField[i,2], self, nSelect, nRecno )

			ELSE
				cId	:= aField[i,1]
				IF nSourceType == 0
					xRet	:= (nSelect)->(fieldget(fieldpos(aField[i,2])))
				ELSEIF nSourceType == 1
					xRet	:= nSelect:fieldget(aField[i,2])
				ENDIF
			ENDIF
		ENDIF

		IF xRet == NIL
			loop
		ENDIF

		::SetValue(nMode, cDesigner + cId, xRet)

	NEXT
RETURN self

//=========================================
METHOD dsListLabel:_Varlink( nMode, aVar, nRecno )
	LOCAL xRet
	LOCAL i, iCnt

	iCnt	:= len( aVar)

	FOR i := 1 TO iCnt
		IF IsBlock(aVar[i,2])
			xRet	:= eval( aVar[i,2], self, ::nSelect, nRecno  )
		ELSE
			xRet	:= aVar[i,2]
		ENDIF

		IF xRet == NIL
			loop
		ENDIF

		::SetValue(nMode, aVar[i,1], xRet)
	NEXT
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
	IF ::__toUpper
		cVar	:= upper(cVar)
	ENDIF
	IF (nPos := ascan(::_aField, {|x| x[1] == cVar})) > 0
		::_aField[nPos, 2]   := xValue
		::_aField[nPos, 3]   := nLLType
	ELSE
		aadd( ::_aField, {cVar, xValue, nLLType})
	ENDIF
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

	IF ::__toUpper
		cVar	:= upper(cVar)
	ENDIF
	IF (nPos := ascan(::_aVar, {|x| x[1] == cVar})) > 0
		::_aVar[nPos, 2]   := xValue
		::_aVar[nPos, 3]   := nLLType
	ELSE
		aadd( ::_aVar, {cVar, xValue, nLLType})
	ENDIF
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

	IF IsArray(nSelect)
		cSymbol	:= coalesce( cSymbol,"")

	ELSEIF IsObject(nSelect)
		IF IsMembervar(nSelect, "Alias")
			cSymbol	:= coalesce( cSymbol, nSelect:Alias, "")

		ELSE
			cSymbol	:= coalesce( cSymbol, "")
		ENDIF
	ELSEIF IsCharacter(nSelect)
		cSymbol	:= coalesce( cSymbol,nSelect)
		nSelect	:= select(nSelect)
	ELSE
		nSelect	:= coalesce( nSelect, Select())
		cSymbol	:= coalesce( cSymbol,"")
	ENDIF
	cSymbol	:= alltrim(cSymbol)
	cDesigner  := coalesce( cDesigner, cSymbol )
	IF ::__toUpper
		cSymbol	:= upper(cSymbol)
	ENDIF

	nPos := ascan(::_dbVariables, {|a| a[2] == cSymbol })
	IF nPos == 0 .AND. !empty(nSelect )
		IF IsArray(nSelect)
			IF len(nSelect) > 0 .AND. nSelect[1]:IsDerivedfrom( "dataobject")
				aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
				aeval( aField, {|a| a := a[1]},,,TRUE)
				aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner, aField })
			ENDIF

		ELSEIF IsObject(nSelect)
			IF nSelect:IsDerivedfrom("dataobject")
				aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner ,;
					coalesce(aField, nSelect:classdescribe(CLASS_DESCR_MEMBERS)), cSymbol})
			ELSE
				IF empty(aField)
					IF IsMethod(nSelect,"dbstruct")
						aField	:= nSelect:dbstruct()
					ENDIF
				ENDIF
				IF IsMemberVar(nSelect, "alias" )
					aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner ,aField, nSelect:alias })
				ELSE
					aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner ,aField, cSymbol})
				ENDIF
			ENDIF
		ELSE
			aadd( ::_dbVariables, {nSelect, cSymbol, cDesigner ,;
				coalesce(aField, (nSelect)->(dbstruct())), alias(nSelect)})
		ENDIF

	ELSEIF nPos > 0
		IF nSelect == NIL
			aremove(::_dbVariables, nPos )
		ELSE
			::_dbVariables[nPos,__SELECT]	:= nSelect
			::_dbVariables[nPos,__SYMBOL]	:= cSymbol
			::_dbVariables[nPos,__LLDESC]	:= cDesigner
			IF IsArray(nSelect)
				IF len(nSelect) > 0 .AND. nSelect[1]:IsDerivedfrom("dataobject")
					aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
					aeval( aField, {|a| a := a[1]},,,TRUE)
					::_dbVariables[nPos,__STRUCT]	:= aField
				ENDIF
			ELSEIF IsObject(nSelect)
				IF nSelect:IsDerivedfrom("dataobject")
					::_dbVariables[nPos,__STRUCT]	:= nSelect:classdescribe(CLASS_DESCR_MEMBERS)
					::_dbVariables[nPos,__ALIAS ]	:= cSymbol

				ELSE
					IF empty(aField)
						IF IsMethod(nSelect,"dbstruct")
							aField	:= nSelect:dbstruct()
						ENDIF
					ENDIF
					::_dbVariables[nPos,__STRUCT]	:= aField
					IF IsMemberVar(nSelect, "alias" )
						::_dbVariables[nPos,__ALIAS ]	:= nSelect:alias
					ELSE
						::_dbVariables[nPos,__ALIAS ]	:= ""
					ENDIF
				ENDIF
			ELSE
				::_dbVariables[nPos,__STRUCT]	:= coalesce(aField, (nSelect)->(dbstruct()))
				::_dbVariables[nPos,__ALIAS ]	:= alias(nSelect)
			ENDIF
		ENDIF
	ENDIF
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

	IF nSelect == NIL	 .AND. pCount() == 1                                           // für abmelden
		// NIL mit xbase ist aktuelle workarea !!!
		cSymbol	:= alltrim(cSymbol)
		IF ::__toUpper
			cSymbol	:= upper(cSymbol)
		ENDIF
		nPos := ascan(::_dbFields, {|a| a[__SYMBOL] == cSymbol})
		IF nPos > 0
			aRemove(::_dbFields, nPos )
		ENDIF
		RETURN self
	ENDIF

	IF IsArray(nSelect)
		cSymbol	:= coalesce( cSymbol,"")

	ELSEIF IsObject(nSelect)
		nSelect	:= nSelect
		IF IsMembervar(nSelect, "Alias")
			cSymbol	:= coalesce( cSymbol, nSelect:Alias, "")
		ELSE
			cSymbol	:= coalesce( cSymbol, "")
		ENDIF
	ELSEIF IsCharacter(nSelect)
		cSymbol	:= coalesce( cSymbol,nSelect)
		nSelect	:= select(nSelect)
	ELSE
		nSelect	:= coalesce( nSelect,  Select())
		cSymbol	:= coalesce( cSymbol,  "")
	ENDIF
	cSymbol	:= alltrim(cSymbol)
	cDesigner	:= coalesce( cDesigner, cSymbol )
	IF ::__toUpper
		cSymbol	:= upper(cSymbol)
	ENDIF
	nRekursiv	:= coalesce( nRekursiv, -99)

	nPos := ascan(::_dbFields, {|a| a[2] == cSymbol })
	IF nPos == 0 .AND. !empty(nSelect )
		IF IsArray(nSelect)
			IF len(nSelect) > 0 .AND. nSelect[1]:IsDerivedfrom( "dataobject")
				aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
				aeval( aField, {|a| a := a[1]},,,TRUE)
				aadd( ::_dbFields, {nSelect, cSymbol, cDesigner,;
					aField, -1, nRekursiv})
			ENDIF
		ELSEIF IsObject(nSelect)
			IF empty(aField)
				IF IsMethod(nSelect,"dbstruct")
					aField	:= nSelect:dbstruct()
				ENDIF
			ENDIF
			IF IsMembervar(nSelect, "Alias")
				aadd( ::_dbFields, {nSelect, cSymbol, cDesigner,aField, nSelect:alias, nRekursiv})
			ELSE
				aadd( ::_dbFields, {nSelect, cSymbol, cDesigner,aField, cSymbol, nRekursiv})
			ENDIF
		ELSE
			aadd( ::_dbFields, {nSelect, cSymbol, cDesigner,;
				coalesce(aField, (nSelect)->(dbstruct())), alias(nSelect), nRekursiv})
		ENDIF

	ELSEIF nPos > 0
		::_dbFields[nPos,__SELECT]	:= nSelect
		::_dbFields[nPos,__SYMBOL]	:= cSymbol
		::_dbFields[nPos,__LLDESC]	:= cDesigner
		IF IsArray(nSelect)
			IF len(nSelect) > 0 .AND. nSelect[1]:IsDerivedfrom("dataobject")
				aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
				aeval( aField, {|a| a := a[1]},,,TRUE)
				::_dbFields[nPos,__STRUCT]	:= aField
			ENDIF
		ELSEIF IsObject(nSelect)
			::_dbFields[nPos,__STRUCT]	:= coalesce(aField, nSelect:dbstruct())
			IF IsMembervar(nSelect, "Alias")
				::_dbFields[nPos,__ALIAS ]	:= nSelect:alias
			ELSE
				::_dbFields[nPos,__ALIAS ]	:= ""
			ENDIF
		ELSE
			::_dbFields[nPos,__STRUCT]	:= coalesce(aField, (nSelect)->(dbstruct()))
			::_dbFields[nPos,__ALIAS ]	:= alias(nSelect)
		ENDIF
		::_dbFields[nPos,__LEVEL ]	:= nRekursiv
	ENDIF

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
	IF ::__toUpper
		cSymbol	:= upper(cSymbol)
	ENDIF
	nPos := ascan(::_dbFields, {|a| a[__SYMBOL] == cSymbol })
	IF nPos > 0
		::_dbFields[nPos,__STRUCT]	:= aStruct
	ENDIF
	nPos := ascan(::_dbVariables, {|a| a[__SYMBOL] == cSymbol })
	IF nPos > 0
		::_dbVariables[nPos,__STRUCT]	:= aStruct
	ENDIF
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

	IF IsArray(cSymbol)                                                              // clone
		iCnt   := len(cSymbol )
		FOR i := 1 TO iCnt
			LlDbAddTable(::hJob, cSymbol[i,1])
			IF cSymbol[i,2]
				LlDbSetMasterTable(::hJob, cSymbol[i,1])
			ENDIF
		NEXT
	ELSE
		IF pcount() = 3                                                                  // abwärtskompatibel
			lMaster	:= pvalue(3)
		ELSEIF !IsLogic(lMaster)
			lMaster	:= FALSE
		ENDIF
		IF empty(cSymbol)
			cSymbol	:= alias()
		ENDIF
		cSymbol	:= alltrim(cSymbol)
		IF ::__toUpper
			cSymbol	:= upper(cSymbol)
		ENDIF
		LlDbAddTable(::hJob, cSymbol)
		aadd( ::_aAddTable, {cSymbol, !empty(lMaster)})

		IF !empty(lMaster)
			LlDbSetMasterTable(::hJob, cSymbol)
			::_cMaster	:= cSymbol
		ENDIF
		IF len( ::_aAddTable) == 1
			LlDbAddTable(::hJob, "LLStaticTable")
			aadd( ::_aAddTable, {"LLStaticTable", FALSE })
		ENDIF
	ENDIF
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

	IF empty(cSymbol)
		cSymbol	:= alias()
	ENDIF
	IF empty(cDescription)
		cDescription	:= cSymbol
	ENDIF
	cSymbol	:= alltrim(cSymbol)
	IF ::__toUpper
		cSymbol	:= upper(cSymbol)
	ENDIF

	LlDbAddTableEx(::hJob, cSymbol, cDescription, nOptions)
	aadd( ::_aAddTable, {cSymbol, cDescription, !empty(lMaster), nOptions})

	IF !empty(lMaster)
		LlDbSetMasterTable(::hJob, cSymbol)
		::_cMaster	:= cSymbol
	ENDIF
	IF len( ::_aAddTable) == 1
		LlDbAddTable(::hJob, "LLStaticTable", "")
		aadd( ::_aAddTable, {"LLStaticTable", "", FALSE })
	ENDIF
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
	IF IsArray(cChild)                                                               // clone
		iCnt   := len(cChild )
		FOR i := 1 TO iCnt
			IF len(cChild[i]) >= 6
				LlDbAddTableRelationEx( ::hJob, cChild[i,1], cChild[i,2], cChild[i,3], cChild[i,4], cChild[i,5], cChild[i,6])
			ELSE
				LlDbAddTableRelation( ::hJob, cChild[i,1], cChild[i,2], cChild[i,3], cChild[i,4])
			ENDIF
		NEXT
	ELSE
		IF ::__toUpper
			cChild	:= upper(cChild)
			cParent	:= upper(cParent)
			cRelation:= upper(cRelation)
		ENDIF

		aadd( ::_aAddTableRelation, {cChild, cParent, cRelation, coalesce(cDescription,"")})
		LlDbAddTableRelation( ::hJob, cChild, cParent, cRelation, coalesce(cDescription,""))
	ENDIF
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
	IF ::__toUpper
		cChild	:= upper(cChild)
		cParent	:= upper(cParent)
		cRelation:= upper(cRelation)
	ENDIF
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
	IF ::__toUpper
		cTable	:= upper(cTable)
	ENDIF
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
	IF IsBlock(xSet)
		aadd( ::_aSync, xSet )
	ELSEIF IsArray(xSet)
		::_aSync   := xSet                                                            // clone
	ENDIF
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

	IF (nPos1 := at("%", cFile )) > 0
		cTmp1	:= subs(cFile, nPos1)
		nPos2 := at("%", cTmp1, 2 )
		cTmp2	:= upper(left(cTmp1, nPos2))

		cTmp2   := strtran( cTmp2, "%TEMP%", ::__cTempPath)
		cTmp2   := strtran( cTmp2, "%EIGENE_DATEIEN%", GetEnv("USERPROFILE") + "\Documents")
		cTmp2   := strtran( cTmp2, "%DOCUMENTS%", GetEnv("USERPROFILE") + "\Documents")
		cTmp2   := strtran( cTmp2, "%USERPROFILE%", GetEnv("USERPROFILE") )
		cFile   := left(cFile,nPos1-1) + cTmp2 + subs(cFile, nPos1 + nPos2 )
	ENDIF
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

	IF empty( cFile)
		RETURN FALSE
	ENDIF
	nPos	:= rat("\", cReport)
	IF nPos > 0
		cReport	:= Subs(cReport, nPos +1)
	ENDIF
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

	IF empty( cFile)
		RETURN FALSE
	ENDIF

	::_nBoxType	:= 0
	::_nPrintOption  := LL_PRINT_EXPORT
	::ExportFormat("PDF")
	::ExportFile(cFile)
	IF IsLogical(lQuiet )
		::ShowExport(!lQuiet)
	ENDIF
	IF !empty( ::_cZUGFeRDXML) .AND. File(::_cZUGFeRDXML)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"PDF.Conformance", "pdfa3b")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"PDF.ZUGFeRDConformanceLevel", "EXTENDED")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"PDF.ZUGFeRDVersion", "2.1")
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"PDF.ZUGFeRDXmlPath", ::_cZUGFeRDXML)
	ENDIF

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

	IF empty(cFile)
		cFile   := _slashpath(getenv("TEMP")) + "PRT" + strzero(seconds(),8 )+ ".PDF"
	ENDIF

	IF empty(cTo) .OR. empty(cSubject)
		lDialog   := TRUE
	ENDIF
	ferase(cFile)

	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.SendAsMail"	   , "1" )
	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.ShowDialog"   , if( empty(lDialog), "0", "1"))

	IF !empty(cTo)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.To"	   , cTo)
	ENDIF
	IF !empty(cCC)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.CC"	   , cCC)
	ENDIF
	IF !empty(cBCC)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.BCC"	, cBCC)
	ENDIF
	IF !empty(cSubject)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.Subject"   , cSubject )
	ENDIF
	//LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.Provider"	, "XMAPI" )
	// bei rtf text ist anlage teil des body und nicht als attachment ausgewiesen, leider
	IF !empty(cBody)
		//LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.Body:application/RTF"	, cBody )
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.Body"	, cBody )
	ENDIF

	IF IsArray( aAttach) .AND. !empty(aAttach)
		FOR i := len( aAttach) TO 1 step -1
			IF file(aAttach[i])
				cAttach += _TAB + aAttach[i]
			ENDIF
		NEXT
		IF !empty(cAttach)
			cAttach := subs( cAttach, 2)                                               // 1. tab weg
			LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.AttachmentList"	, cAttach )
		ENDIF
	ELSE
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Mail.AttachmentList"	, "" )
	ENDIF

	IF !empty(::__cSmtpIPAddress)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.Provider"	    		,::__cEmailProvider )
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.ServerAddress",::__cSmtpIPAddress)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.ServerPort"   ,::__nSmtpIPPort)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.User"	   	,::__cSmtpUser)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.Password"     ,::__cSmtpPassword)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.SenderAddress",::__cSmtpSenderAddress)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.Mail.SMTP.SenderName"   ,::__cSmtpSenderName )
	ENDIF

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

	DEFAULT nMode TO 0

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

	IF 1 $ nMode
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
	ENDIF

	// handsome options
#ifndef DEBUG
	LlSetOption(::hJob, LL_OPTION_NOPARAMETERCHECK		,1)                        // performance boost
#ENDIF
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

	IF !empty(::__cExportFormat)
		LlSetOptionString (::hJob, LL_OPTIONSTR_EXPORTS_ALLOWED_IN_PREVIEW, ::__cExportFormat)
	ENDIF

	// interne defaults
	IF ascan(::_aVar, {|x| x[1] == "USER"}) = 0
		cTmp	:= space(255)
		nLen	:= 255
		GetUsername( @cTmp, @nLen )
		cTmp	:= left(cTmp, --nLen)
		aadd( ::_aVar, {"USER"   ,cTmp, LL_TEXT})
	ENDIF

	IF ascan(::_aVar, {|x| x[1] == "COMPUTER"}) = 0
		cTmp	:= space(255)
		nLen	:= 255
		GetComputername( @cTmp, @nLen)
		cTmp	:= left(cTmp, nLen)
		aadd( ::_aVar, {"COMPUTER"   ,cTmp, LL_TEXT})
	ENDIF

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
	IF !empty(lSet)
		IF nPos > 0
			aremove(::_aRights, nPos)
		ENDIF
	ELSEIF nPos == 0
		aadd( ::_aRights, xSet )
	ENDIF
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
	IF !empty( nPage)
		IF ::_nStatus = XBP_STAT_CREATE
			LlPrintSetOption(::hJob, LL_PRNOPT_PAGE , nPage )
		ENDIF
		::_nFirstpage   := nPage
	ENDIF
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
	IF IsCharacter( xSet) .AND. !empty(xSet)
		IF ";" $ xSet
			aTmp	:= _aStrExtract(xSet, ";")
			iCnt	:= len( aTmp)
			FOR i := 1 TO iCnt
				aTmp[i]	:= strtran( aTmp[i], "%APPDATA%", GetEnv("APPDATA"))
				aTmp[i]	:= strtran( aTmp[i], "%USERPROFILE%", GetEnv("APPDATA"))
				aadd(::_aPath, aTmp[i] )
			NEXT
		ELSEIF !empty(lFirst)
			xSet	:= strtran( xSet, "%APPDATA%", GetEnv("APPDATA"))
			xSet	:= strtran( xSet, "%USERPROFILE%", GetEnv("APPDATA"))
			iCnt	:= len(::_aPath)
			aSize(::_aPath, ++iCnt)
			aIns(::_aPath, 1, xSet )
		ELSE
			xSet	:= strtran( xSet, "%APPDATA%", GetEnv("APPDATA"))
			xSet	:= strtran( xSet, "%USERPROFILE%", GetEnv("APPDATA"))
			aadd(::_aPath, xSet )
		ENDIF

	ELSEIF IsArray( xSet)
		::_aPath	:= aclone(xSet)
		iCnt	:= len( ::_aPath)
		FOR i := 1 TO iCnt
			::_aPath[i]	:= strtran( ::_aPath[i], "%APPDATA%", GetEnv("APPDATA"))
			::_aPath[i]	:= strtran( ::_aPath[i], "%USERPROFILE%", GetEnv("APPDATA"))
		NEXT

	ELSEIF pcount() == 0
		::_aPath	:= {}
	ENDIF
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

	IF ::_lSubReport
		oRet:AddTable(::_aAddTable )
		oRet:AddTableRelation(::_aAddTableRelation )
	ENDIF
RETURN oRet

//=========================================
METHOD dsListLabel:DbReleaseAll()
	LOCAL i, iCnt
	LOCAL aSelect   := {}
	LOCAL x
	UNUSED (x)

	IF ::_lIsReleased .OR. !::_lUseDbRequest
		RETURN self
	ENDIF

	iCnt   := len( ::_dbFields)
	FOR i := 1 TO iCnt
		IF IsArray(::_dbFields[i,__SELECT])
		ELSEIF ascan(aSelect, ::_dbFields[i,__SELECT]) = 0
			IF IsNumber(::_dbFields[i,__SELECT])
				x := dbRelease(::_dbFields[i,__SELECT])

			ELSEIF IsObject(::_dbFields[i,__SELECT]) .AND. isMethod(::_dbFields[i,__SELECT], "select") .AND. ::_dbFields[i,__SELECT]:select() > 0
				x := dbRelease(::_dbFields[i,__SELECT]:select())
			ENDIF
			aadd( aSelect, ::_dbFields[i,__SELECT])
		ENDIF
	NEXT

	iCnt   := len( ::_dbVariables)
	FOR i := 1 TO iCnt
		IF IsArray(::_dbVariables[i,__SELECT])
		ELSEIF ascan(aSelect, ::_dbVariables[i,__SELECT]) = 0
			IF IsNumber(::_dbVariables[i,__SELECT])
				x := dbRelease(::_dbVariables[i,__SELECT])

			ELSEIF IsObject(::_dbVariables[i,__SELECT]) .AND. isMethod(::_dbVariables[i,__SELECT], "select") .AND. ::_dbVariables[i,__SELECT]:select() > 0
				x := dbRelease(::_dbVariables[i,__SELECT]:select())
			ENDIF
		ENDIF
		aadd( aSelect, ::_dbVariables[i,__SELECT])
	NEXT
	::_lIsReleased		:= TRUE
RETURN self

//=========================================
METHOD dsListLabel:DbRequestAll()
	LOCAL i, iCnt
	LOCAL aSelect   := {}
	LOCAL x
	UNUSED (x)

	IF !::_lUseDbRequest
		RETURN self
	ENDIF

	iCnt   := len( ::_dbFields)
	FOR i := 1 TO iCnt
		IF IsArray(::_dbFields[i,__SELECT])
		ELSEIF ascan(aSelect, ::_dbFields[i,__SELECT]) = 0
			IF IsNumber(::_dbFields[i,__SELECT])
				dbSelectArea(::_dbFields[i,__SELECT])
				x := DbRequest(::_dbFields[i,__ALIAS])

			ELSEIF IsObject(::_dbFields[i,__SELECT]) .AND. isMethod(::_dbFields[i,__SELECT], "select") .AND. ::_dbFields[i,__SELECT]:select() > 0
				dbSelectArea(::_dbFields[i,__SELECT]:select())
				x := DbRequest(::_dbFields[i,__SELECT]:alias)
			ENDIF
			aadd( aSelect, ::_dbFields[i,__SELECT])
		ENDIF
	NEXT

	iCnt   := len( ::_dbVariables)
	FOR i := 1 TO iCnt
		IF IsArray(::_dbVariables[i,__SELECT])
		ELSEIF ascan(aSelect, ::_dbVariables[i,__SELECT]) = 0
			IF IsNumber(::_dbVariables[i,__SELECT])
				dbSelectArea(::_dbVariables[i,__SELECT])
				x := DbRequest(::_dbVariables[i,__ALIAS] )

			ELSEIF IsObject(::_dbVariables[i,__SELECT]) .AND. isMethod(::_dbVariables[i,__SELECT], "select") .AND. ::_dbVariables[i,__SELECT]:select() > 0
				dbSelectArea(::_dbVariables[i,__SELECT]:select())
				x := DbRequest(::_dbVariables[i,__SELECT]:alias)
			ENDIF
			aadd( aSelect, ::_dbVariables[i,__SELECT])
		ENDIF
	NEXT
	::_lIsReleased		:= FALSE
RETURN self

//=========================================
METHOD dsListLabel:GetErrorText(nError)
	IF nError == NIL
		nError	:= ::_nError
	ENDIF

	::_cErrorMessage := replicate(chr(0),255)
	LlGetErrortext(nError, @::_cErrorMessage, 255)
	::_cErrorMessage   	:= _trim0( ::_cErrorMessage )

	IF Set( _SET_CHARSET ) == CHARSET_OEM
		::_cErrorMessage  := alltrim(ConvtoOemCP(::_cErrorMessage))
	ENDIF
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

	IF nError = 0
		RETURN self
	ENDIF

	IF IsBlock(::__onError)
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
	ENDIF
RETURN self

//=========================================
METHOD dsListLabel:Notify(nEvent, nId )
	IF IsBlock(::_bNotify)
		::eval(::_bNotify, nEvent, nId, self )
	ENDIF
RETURN self

//=========================================
METHOD dsListLabel:_InitDevMode(nIndex)
   local nSize, nError

	DEFAULT nIndex TO -1
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
	IF IsCharacter(cPath)
		::_cExportPath	:= _slashPath(cPath)
	ENDIF
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
		CASE oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_PREVIEW_START .OR. ;
				oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_EXPORT_START
			// Init/retrieve values FOR the print thread
			nProjecthWnd	:= oLlCallbackNotify:Get_hWnd()
			hEvent			:= oLlCallbackNotify:Get_hEvent()
    		nPages			:= oLlCallbackNotify:Get_nPages() // number of pages TO be printed
			cProjectName	:= oLlCallbackNotify:_pszProjectNameFromVar()
			cProjectOrgName:= oLlCallbackNotify:_pszOriginalProjectFileNameFromVar()
			cExpFormat		:= oLlCallbackNotify:_pszExportFormatFromVar()

			oListLabel:dbReleaseAll()
			// Start print thread
			oThread   := Thread():new()
			oThread   :start( {|| _ThreadPrint(oThread, oListLabel, hEvent, nProjecthWnd, cProjectName, cProjectOrgName, cExpFormat, nPages)})
			lThreadRuns := TRUE

		CASE oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT .OR. ;
				oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT
			_PrintRuns(FALSE, TRUE, snJobId)
			lThreadRuns := FALSE

		CASE oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE .OR. ;
				oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE
			lThreadRuns := FALSE
			oListLabel:dbRequestAll()

		CASE oLlCallbackNotify:Get_nFunction() == LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE .OR. ;
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
			// Init/retrieve values FOR the print thread
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

			IF snJobId = 0 .OR. !_PrintRuns(, TRUE, snJobId)
				oListLabel:dbReleaseAll()
				// Start print thread
				oThread   := Thread():new()
				nParam    := ++snJobId
				oThread   :start( {|| _ThreadPrintDrillDown(oThread, oListLabel, nProjecthWnd, cProjectName, cPreviewName, hAttach, cParent, cKeyfield, cChild, cRefField, xValue )})
			ENDIF

		ELSEIF oLlDrillDownJobNotify:Get_nFunction() == LL_DRILLDOWN_FINALIZE			// 2
			IF !_PrintRuns(, TRUE, nId )
				oListLabel:dbRequestAll()
			ENDIF

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
   IF !empty(cProjectOrgName)
		LlSetOptionString(oListLabel:hJob, LL_OPTIONSTR_ORIGINALPROJECTFILENAME, cProjectOrgName)
   ELSE
		LlSetOptionString(oListLabel:hJob, LL_OPTIONSTR_ORIGINALPROJECTFILENAME, cProjectName)
   ENDIF
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

	IF !empty(xValue)
  		dbChild	:= oListLabel:GetDbContainer(cChild)
		dbParent	:= oListLabel:GetDbContainer(cParent)
		IF IsNumber(dbParent)
			(dbParent)->(dbseek(xValue))
			(dbParent)->(dbsetscope(SCOPE_BOTH, xValue))
			(dbChild)->(dbsetscope(SCOPE_BOTH, xValue))

		ELSEIF IsObject(dbParent)
			dbParent:seek(xValue)
			dbParent:setscope(SCOPE_BOTH, xValue)
			dbChild:setscope(SCOPE_BOTH, xValue)
		ENDIF
	ENDIF

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

	IF nFindThread = 0
		IF lCheck
			RETURN TRUE
		ENDIF
		aAdd(aPrintRuns,{nJobId,FALSE})
		nFindThread := Len(aPrintRuns)
	ENDIF
	IF lSet != NIL
		aPrintRuns[nFindThread,2] := lSet
	ENDIF
RETURN aPrintRuns[nFindThread,2]

//=========================================
// XClass++ copy
//=========================================
STATIC FUNC _FullPath(cPath, cCurDir)
	LOCAL nPos

	IF empty(cCurdir)
		cCurdir   := strtran(AppName(TRUE), AppName(), "")
	ENDIF

	cCurdir   := _SlashPath(cCurDir)

	IF left(cPath,2) = ".."									    // 1. hoch
		// curdir auch 1 noch oben
		nPos   := rat("\", cCurdir, len( cCurdir)-1)
		IF nPos == 0											// fehler
			RETURN cPath
		ENDIF
		RETURN _FullPath(subs(cPath,4), left(cCurDir, nPos ))

	ELSEIF left(cPath,2) = ".\"									// relativer pfad
		cPath   := cCurDir + subs( cPath, 3 )

	ELSEIF left(cPath,1) = "\" .AND. ! subs(cPath,2,1) = "\"				 // absolut, aber ohne LW
		IF subs(cCurDir,2,1) = ":"
			cPath   := left(cCurDir,2) + cPath

		ELSEIF left(cCurDir,2) = "\\"
			IF (nPos := at(cCurDir,"\",  3)) > 0
				cPath   := left(cCurDir,--nPos) + cPath
			ENDIF
		ENDIF

	ELSEIF !(left(cPath,2) = "\\" .OR. subs(cPath,2,1) = ":" )			     // kein (UNC oder LW)
		cPath   := cCurDir + cPath

	ENDIF
RETURN cPath

//=========================================
// XClass++ copy
//=========================================
STATIC FUNC _SlashPath(cPath)
	IF empty( cPath)
		RETURN ""
	ENDIF
	cPath   := alltrim(cPath)
	IF subs( cPath, -1 ) != "\"
		cPath   += "\"
	ENDIF
RETURN cPath

//=========================================
STATIC FUNC _aStrExtract(cStr, cToken)
	LOCAL i, iCnt
	LOCAL aRet	:= {""}

	iCnt	:= len( cStr)
	FOR i := 1 TO iCnt
		IF cStr[i] = cToken
			aadd(aRet, "")
		ELSE
			aRet[-1] += cStr[i]
		ENDIF
	NEXT
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
	IF right(upper(cFile), nLen ) != "."+ cExt
		cFile   += "."+ cExt
	ENDIF
RETURN cFile

//=========================================
// wegen API 0-Bytes
STATIC FUNC _Trim0( cStr)
	LOCAL nPos   := at(chr(0), cStr)
	IF nPos > 0
		cStr := left( cStr, nPos -1 )
	ENDIF
RETURN alltrim( cStr )

//=========================================
// Xclass Uses xclass:dsDbContainer with extended methods
// nice TO have IF you are used TO it
// class to handle table objects
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

			DEFAULT lClose TO FALSE

			iCnt	:= len(aDbContainer)
			::_aDbContainer	:= array(iCnt)
			FOR i := 1 TO iCnt
				IF i == 1
					::_aDbContainer[i]	:= dataobject():New()
				ELSE
					::_aDbContainer[i]	:= ::_aDbContainer[1]:copy()
				ENDIF
				IF IsArray(aDbContainer[i])                                             // XCLASS
					::_aDbContainer[i]:Symbol	:= aDbContainer[i,1]
					::_aDbContainer[i]:Select	:= aDbContainer[i,2]
				ELSE
					::_aDbContainer[i]:Symbol	:= aDbContainer[i]:symbol
					::_aDbContainer[i]:Select	:= aDbContainer[i]:Select
				ENDIF
				::_aDbContainer[i]:Close	:= lClose
			NEXT
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

	IF (IsNumber(uSelect) .OR. IsObject(uSelect) .OR. IsArray(uSelect)) .AND. IsCharacter(cNameID) .AND. ! empty(cNameID)
		IF IsCharacter(cNameID)
			cNameID := upper(cNameID)
		ENDIF
		IF (nPos := ascan(::_aDbContainer, {|e| e:Symbol == cNameID})) > 0
			::_aDbContainer[nPos]:Select	:= uSelect
			::_aDbContainer[nPos]:Close	:= !Empty(lDbClose)
		ELSE
			aadd( ::_aDbContainer, dataobject():New())
			::_aDbContainer[-1]:Symbol	:= cNameID
			::_aDbContainer[-1]:Select	:= uSelect
			::_aDbContainer[-1]:Close	:= !Empty(lDbClose)
		ENDIF
	ENDIF
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
	FOR i := 1 TO iCnt
      IF ! IsNil(::_aDbContainer[i]) .AND. ::_aDbContainer[i]:close
			IF IsObject(::_aDbContainer[i]:select)
				::_aDbContainer[i]:select:Close()
			ELSEIF IsNumber(::_aDbContainer[i]:select) .AND. (::_aDbContainer[i]:select)->(Used())
				(::_aDbContainer[i]:select)->(DbCloseArea())
			ENDIF
      ENDIF
		::_aDbContainer[i]	:= NIL
  	NEXT
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

	IF pcount() = 0
		aRet := array(len(::_aDbContainer))
		aeval(::_aDbContainer, {|a,n| aRet[n] := a:select })
		RETURN aRet
	ENDIF

	IF IsCharacter(cNameID)
		cNameID := upper(cNameID)
	ENDIF

	IF (nPos := ascan(::_aDbContainer, {|e| e:Symbol == cNameID})) > 0
		RETURN ::_aDbContainer[nPos]:select
	ENDIF

RETURN NIL

//=========================================
METHOD DbContainer:CloseDbContainer(cNameID)
	LOCAL nPos

	IF IsCharacter(cNameID)
		cNameID := upper(cNameID)
	ENDIF
  	IF (nPos := ascan(::_aDbContainer, {|e| e:Symbol == cNameID})) > 0
		IF IsObject(::_aDbContainer[nPos]:Select)
			::_aDbContainer[nPos]:Select:Close()

		ELSEIF IsNumber(::_aDbContainer[nPos]:Select) .AND. (::_aDbContainer[nPos]:Select)->(Used())
			(::_aDbContainer[nPos]:Select)->(DbCloseArea())
		ENDIF
     	aremove(::_aDbContainer, nPos)
  	ENDIF
RETURN self
#ELSE
CLASS DbContainer from dsDbContainer		;ENDCLASS
#ENDIF

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
	FOR i := 1 TO iCnt
		xRet	:= fieldget(i)

		IF aStruct[i,2] = "N"
			nLL   := LL_NUMERIC
			cStr  := ltrim(str(xRet))
			IF aStruct[i,4] == 0
				nLL   := LL_NUMERIC_INTEGER
			ENDIF

		ELSEIF aStruct[i,2] = "D"
			IF !empty( xRet)
				cStr	:= dtos(xRet)
				nLL   := LL_DATE_YYYYMMDD
			ELSE
				cStr	:= '1e100'
				nLL   := LL_DATE_MS
			ENDIF

		ELSEIF aStruct[i,2] = "L"
			nLL	:= LL_BOOLEAN
			cStr	:= if(xRet, "T","F")

		ELSE
			nLL   := LL_TEXT
			IF Set( _SET_CHARSET ) == CHARSET_OEM
				cStr  := rtrim(ConvtoAnsiCP(xRet))
			ELSE
				cStr  := rtrim(xRet)
			ENDIF
			IF empty( cStr)
				cStr	:= " "
			ENDIF
		ENDIF
		IF empty( nMode )
			LlDefineFieldExt(hJob, aStruct[i,1], cStr, nLL, 0 )
		ELSE
			LlDefineVariableExt(hJob, aStruct[i,1], cStr, nLL, 0 )
		ENDIF
	NEXT
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




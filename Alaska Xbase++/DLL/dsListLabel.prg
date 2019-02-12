/*============================================================================
 File Name:	   dsListLabel.prg
 Author:	 Marcus Herz
 Description:
 Created:			 19.08.2016     13:33:08	  Updated: þ19.08.2016	þ13:33:08
 Copyright:		 2016 by DS-Datasoft, 87654 Friesenried
 Revision:
 Remark: Set Tabs to 3 blanks
============================================================================*/
#include "dsListLabel.ch"
#include "dll.ch"
#include "xbp.ch"
#include "common.ch"
#include "class.ch"

#ifdef _XCLASS
#include "dsserver.ch"
#include "dsTranslate.ch"
#endif	// _XCLASS

// ::_aList
// ::_aTable
#define __SELECT		1
#define __SYMBOL		2
#define __LLDESC		3
#define __STRUCT		4
#define __ALIAS		5
#define __STUFE		6

static scVersion	:= "24"

#if XPPVER >= 2000840
	// ab dieser version mit Xbase EXTERN
	// kein C-Code mehr
	EXTERN LONG GetComputerName(@cBuffer as STRING, @nBin AS LONG) 	IN WIN32API
	EXTERN LONG GetUserName( @cBuffer as STRING, @nBuflen AS LONG)  	IN WIN32API
	EXTERN INTEGER GetTempPath( len AS UINTEGER, @buffer AS STRING )	IN WIN32API
	EXTERN LONG SetEvent(hEvent AS UINTEGER)									IN WIN32API
#else
	DLLFUNCTION GetComputerNameA(@cBuffer, @nBin)   USING STDCALL FROM KERNEL32.DLL
	DLLFUNCTION GetUserNameA( @cBuffer, @cBuflen)   USING STDCALL FROM ADVAPI32.DLL
	DLLFUNCTION GetTempPathA( buffsize, @buffer )   USING STDCALL FROM KERNEL32.DLL
	DLLFUNCTION SetEvent(hEvent)			 				USING STDCALL FROM KERNEL32.DLL

#endif	// XPPVER

#ifdef _DESIGNERPREVIEW
	#include "ot4xb.ch"

	#ifndef _CALLBACK
		#define _CALLBACK
	#endif
#endif	// _DESIGNERPREVIEW

#if XPPVER < 2000840
#ifdef _CALLBACK
	// c-functions for notification,=> callback.obj
	#pragma map(RegisterLLCallback	,"_RegisterLLCallback"	)
	#pragma map(UnRegisterLLCallback	,"_UnRegisterLLCallback")
#endif 	// _CALLBACK
#endif	// XPPVER

#xtranslate _TAB	=> chr(9)
#xtranslate true	=> .T.
#xtranslate false	=> .F.

//=========================================
INIT Procedure dsListLabelInit	;scVersion	:= var2char(__LL)	;RETURN

//=========================================
EXIT Procedure dsListLabelStop
	Errorblock({||break()})
	begin sequence
		_EvalLLFunc("ModuleExit")
	end sequence
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
#ifdef _XCLASS
CLASS dsListLabel FROM dsDbContainer
#else
CLASS dsListLabel
#endif
PROTECTED:
	CLASS VAR __aDefaultVar				SHARED							//
	CLASS VAR __aConfig					SHARED							//
	CLASS VAR __aPrepare					SHARED							//
	CLASS VAR __aRecht					SHARED							//
	CLASS VAR __cDefaultPath			SHARED							//
	CLASS VAR __cExport					SHARED							//
	CLASS VAR __cIgnoreField			SHARED							//
	CLASS VAR __cLicence					SHARED							//
	CLASS VAR __cEmailProvider			SHARED							//
	CLASS VAR __onError					SHARED							//
	CLASS VAR __cSmtpIPAddress			SHARED							//
	CLASS VAR __nSmtpIPPort				SHARED							//
	CLASS VAR __cSmtpPassword			SHARED							//
	CLASS VAR __cSmtpSenderAddress	SHARED							//
	CLASS VAR __cSmtpSenderName   	SHARED							//
	CLASS VAR __cSmtpUser				SHARED							//
	CLASS VAR __lDesignerPreview  	SHARED							//
	CLASS VAR __nBoxType					SHARED							//
	CLASS VAR __nDebug					SHARED							//
	CLASS VAR __nLanguage				SHARED							//
	CLASS VAR __nZoom						SHARED							//

   VAR cOutFile                                                //
   VAR cOutPut                                                 //
   VAR cReport                                                 //
   VAR cTitle                                                  //
   VAR cExportFormat                                           //
   VAR cShowExport                                             // export datei nach erstellen anzeigen/öffnen
   VAR nSelect                                                 //
   VAR xCallback                                               // callbackslot bei preview druck
   VAR _aAddTable                                              //
   VAR _aAddTableRelation                                      //
   VAR _aField                                                 //
   VAR _aList                                                  //
   VAR _aRecht                                                 //
   VAR _aSync                                                  //
	VAR _aOptimize                                              //
   VAR _aTable                                                 //
	VAR _aUsedFields															//
   VAR _aVar                                                   //
   VAR _bConfig                                                //
   VAR _bCopyblock                                             // wird bei mehrfach druck ausgewertet
   VAR _bPrepare                                               //
   VAR _bSkipBlock                                             // skipblock, immer
   VAR _bTableChange                                           // wenn tabelle sich ändert bei Berichts container
   VAR _bTopBlock                                              // topblock bei tablechange und druckstart
   VAR _aData                                                  // druck von array
   VAR _cErrorMessage                                          //
   VAR _cIgnoreField                                           //
   VAR _cPrinter                                               //
   VAR _lDesign			                                       //
   VAR _lDesignerPreview                                       //
   VAR _lIsReleased
   VAR _lOptions                                               //
   VAR _lPrintAtEof                                            // wenn true, wird immer mindestens 1 Satz übergeben auch wenn eof()
   VAR _lRtf
   VAR _lSubReport                                             // true wenn mit berichtscontainer
   VAR _nBoxType                                               // art der fortschritts anzeige
   VAR _nError                                                 //
   VAR _nFirstpage                                             //
   VAR _nLastpage                                              //
   VAR _nLastRec                                               //
   VAR _nPages		                                             //
   VAR _nProject                                               //
   VAR _nPrintOption                                           //
   VAR _nQuantity                                              //
   VAR _nRootSelect                                            //
   VAR _nStatus                                                //
   VAR _oParent                                                //

   METHOD _Datalink                                            //
   METHOD _PrintStart                                          //
   METHOD _PrintTable                                          //
   METHOD _Varlink                                             //
   METHOD _RaiseError(nError, cArgs, cOperation)               //
   METHOD _SetPrinter                                          //
	METHOD _SetRelation(dbParent,dbChild)

EXPORTED:
	VAR hJob, hWnd READONLY
   Var DataObject

	CLASS METHOD initClass

	METHOD AddSync
	METHOD AddTable
	METHOD AddTableRelation
	METHOD Clear
	METHOD Clone
	METHOD Connect
	METHOD Datalink
	METHOD DatalinkTable(nMode, dbServer, cDesigner )
	METHOD DataSetField
	METHOD DataSetStruct( cSymbol, aStruct)
	METHOD DataSetVariable
	METHOD DbReleaseAll
	METHOD DbRequestAll
	METHOD DefaultPrinter
	METHOD DefineField
	METHOD DefineVariable
	METHOD Design
	METHOD Destroy
	METHOD EnableDebug
	METHOD ExportFile
	METHOD GetPrinter
	METHOD GetSelect(cSymbol)
	METHOD Init
	METHOD OptimizeDatalink( nMode, lOptimize)
	METHOD Print
	METHOD PrintLabel
	METHOD ResetMenue
	METHOD SaveAsPDF
	METHOD SendAsMail
	METHOD SetMenuId
	METHOD SetProperty

	METHOD Close					   IS Destroy

	ACCESS ASSIGN METHOD Printer
	ACCESS ASSIGN METHOD Report
	ACCESS ASSIGN METHOD SelectOptions
	ACCESS ASSIGN METHOD SetExport(xSet)
	ACCESS ASSIGN METHOD SetFirstpage
	ACCESS ASSIGN METHOD SetPreView
	ACCESS ASSIGN METHOD PrintOption
	ACCESS ASSIGN METHOD SetTitle

	INLINE ACCESS METHOD GetLastPage								;RETURN ::_nLastPage
	INLINE ACCESS METHOD GetParent		   					;RETURN ::_oParent
	INLINE ACCESS METHOD Connected		   					;RETURN ::nSelect
	INLINE ACCESS METHOD Server			   					;RETURN ::nSelect

	INLINE ACCESS ASSIGN METHOD SetDesign(xSet)				;::_lDesign			:= !empty(xSet)			;RETURN self
	INLINE ACCESS ASSIGN METHOD PrintAtEof( xSet)	 		;::_lPrintAtEof	:= xSet						;RETURN self
	INLINE ACCESS ASSIGN METHOD ShowExport( xSet)	 		;::cShowExport   	:= if( xSet, "1", "0")	;RETURN self

	INLINE METHOD DatalinkVariable(cId, xValue, cLLtype )	;RETURN ::_varlink(1, {{cId, xValue, cLLtype}})
	INLINE METHOD GetLastError										;RETURN ::_nError
	INLINE METHOD GetLastMessage									;RETURN ::_cErrorMessage
	INLINE METHOD GetOutPutFile									;RETURN ::cOutFile
	INLINE METHOD IsPreview											;RETURN (::_nPrintOption == LL_PRINT_PREVIEW .or. ::cOutput = "PRV")
	INLINE METHOD Output												;RETURN ::cOutput
	INLINE METHOD Status												;RETURN if( ! empty(::hJob), XBP_STAT_INIT, XBP_STAT_FAILURE )

	INLINE METHOD ClearSync()
		::_aSync	:= {}
		RETURN self

	INLINE METHOD ResetRights()
		::_aRecht	:= aclone(::__aRecht)
		RETURN self

	INLINE METHOD SetOptionString(nMode, cVal)
		LlSetOptionString(::hJob, nMode, cVal)
		RETURN self

	INLINE METHOD SetOption(nMode, nValue)
		LlSetOption(::hJob, nMode, if( IsLogic(nValue), if(nValue, 1, 0 ), nValue ))
		RETURN self

	INLINE METHOD Zoom(nZoom)
		LlSetOption(::hJob, LL_OPTION_PRVZOOM_PERC, nZoom )
		RETURN self

	INLINE METHOD CloneDefineField(aField)		;::_aField	:= aclone(aField)		;RETURN self
	INLINE METHOD CloneDefineVariable(aVar)	;::_aVar		:= aclone(aVar)		;RETURN self
	INLINE METHOD CloneDataSetField(aList)		;::_aList	:= aclone(aList)		;RETURN self
	INLINE METHOD CloneDataSetVariable(aTable);::_aTable	:= aclone(aTable)		;RETURN self

	//=========================================
	INLINE ACCESS ASSIGN METHOD BoxType( xSet)
		if IsNumber(xSet)
			::_nBoxType		:= xSet
			RETURN self
		endif
		RETURN ::_nBoxType

	//=========================================
	INLINE ACCESS ASSIGN METHOD CallBack( xSet)
		if IsBlock(xSet)
			::xCallback		:= xSet
			RETURN self
		endif
		RETURN ::xCallback

	//=========================================
	INLINE ACCESS ASSIGN METHOD Lastrec( xSet)
		if IsNumber(xSet)
			::_nLastRec		:= xSet
			RETURN self
		endif
		RETURN ::_nLastRec

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
	INLINE ACCESS ASSIGN METHOD Project( xSet)														// backward compatible
		if IsNumber( xSet)
			::_nProject		:= xSet
			RETURN self
		endif
		RETURN ::_nProject

//=========================================
	INLINE ACCESS ASSIGN METHOD SkipBlock( xSet)
		if IsBlock( xSet)
			::_bSkipBlock	:= xSet
     	elseif pcount() = 1
#ifdef _XCLASS
     		::_bSkipBlock   := {|o, c| c:skip()}					  	// default
#else
     		::_bSkipBlock   := {|o, c| (c)->(dbskip())}				// default
#endif
    	endif
    	RETURN ::_bSkipBlock

	//=========================================
	INLINE ACCESS ASSIGN METHOD TopBlock( xSet)
   	if IsBlock( xSet)
   		::_bTopBlock	:= xSet
  		elseif pcount() = 1
#ifdef _XCLASS
  			::_bTopBlock   := {|o, c| c:gotop()}                  // default
#else
  			::_bTopBlock   := {|o, c| (c)->(dbgotop())}           // default
#endif
			RETURN self
 		endif
 		RETURN ::_bTopBlock

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
	INLINE CLASS Method DefaultBoxType(xSet)	     		;::__nBoxType				:= xSet				;RETURN self
	INLINE CLASS Method DefaultDesignerPreview(xSet)	;::__lDesignerPreview	:= xSet				;RETURN self
	INLINE CLASS Method DefaultExport(xSet)				;::__cExport				:= xSet				;RETURN self
	INLINE CLASS Method DefaultIgnoreFieldMask(xSet)   ;::__cIgnoreField			:= xSet				;RETURN self
	INLINE CLASS Method DefaultLanguage(xSet)				;::__nLanguage				:= xSet				;RETURN self
	INLINE CLASS Method DefaultMenuDisabled(xSet)		;::__aRecht					:= aclone(xSet)	;RETURN self
	INLINE CLASS Method DefaultSmtpIPAddress(xSet)		;::__cSmtpIPAddress 		:= xSet				;RETURN self
	INLINE CLASS Method DefaultSmtpIPPort(xSet)			;::__nSmtpIPPort    		:= xSet				;RETURN self
	INLINE CLASS Method DefaultSmtpPassword(xSet)		;::__cSmtpPassword  		:= xSet				;RETURN self
	INLINE CLASS Method DefaultSmtpSenderAddress(xSet)	;::__cSmtpSenderAddress	:= xSet				;RETURN self
	INLINE CLASS Method DefaultSmtpSenderName(xSet)		;::__cSmtpSenderName		:= xSet				;RETURN self
	INLINE CLASS Method DefaultSmtpUser(xSet)				;::__cSmtpUser				:= xSet				;RETURN self
	INLINE CLASS Method DefaultZoom(xSet)					;::__nZoom					:= xSet				;RETURN self
	INLINE CLASS Method LicensingInfo(xSet)				;::__cLicence				:= xSet				;RETURN self

	//=========================================
	INLINE CLASS Method DefaultVariable(cSymbol, xValue, nLLType)
		LOCAL nPos
		LOCAL cTmp	:= upper(cSymbol)
		nPos   := ascan( ::__aDefaultVar, {|a| upper(a[1]) == cTmp})
		if nPos > 0
			::__aDefaultVar[nPos,2] := xValue
			::__aDefaultVar[nPos,3] := nLLType
		else
			aadd( ::__aDefaultVar, {cSymbol, xValue, nLLType})
		endif
		RETURN self

	//=========================================
	INLINE CLASS Method DefaultPath(xSet)
		if ! empty(xSet) .and. IsCharacter(xSet)
			xSet	:= strtran( xSet, "%APPDATA%", GetEnv("APPDATA"))
			::__cDefaultPath   := _slashpath(_Fullpath( xSet))
		endif
		RETURN ::__cDefaultPath

	//=========================================
	INLINE CLASS Method DefaultPrepareBlock(bSet)
		if IsBlock(bSet)
			aadd( ::__aPrepare, bSet )
		endif
		RETURN self

	//=========================================
	INLINE CLASS Method DefaultConfigBlock(bSet)
		if IsBlock(bSet)
			aadd( ::__aConfig, bSet )
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
	INLINE CLASS Method DesignerPreviewEnabled()
#ifdef _DESIGNERPREVIEW
		RETURN true
#else
		RETURN false
#endif
ENDCLASS

//=========================================
CLASS METHOD dsListLabel:InitClass()
	if ::__aDefaultVar == NIL
		::__aConfig					:= {}
		::__aDefaultVar			:= {}
		::__aPrepare				:= {}
		::__aRecht					:= {}
		::__cDefaultPath			:= ""
		::__cEmailProvider		:= "SMTP"
		::__cExport					:= ""
		::__cIgnoreField			:= ""
		::__cLicence				:= ""
		::__cSmtpIPAddress		:= ""
		::__cSmtpPassword			:= ""
		::__cSmtpSenderAddress	:= ""
		::__cSmtpSenderName		:= ""
		::__cSmtpUser				:= ""
		::__lDesignerPreview		:= false
		::__nBoxType				:= LL_BOXTYPE_STDWAIT
		::__nDebug					:= 0
		::__nLanguage				:= -1
		::__nSmtpIPPort			:= 25
		::__nZoom					:= 100
	endif
RETURN self

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
	LOCAL lRet
	LOCAL cTmp
	LOCAL i, iCnt
	LOCAL oError
#ifdef _XCLASS
	::dsDbContainer:Init()
#endif

	if IsNumber(oParent)										 // :clone(), Designer Preview
		::hWnd			:= oParent

	elseif IsObject(oParent)
		::hWnd			:= oParent:GetHWND()
	else
		oParent			:= SetAppWindow()
		::hWnd			:= SetAppWindow():GetHWND()
	endif
	::_cErrorMessage	:= ""
	::cOutFile			:= ""
	::cOutPut			:= ""
	::cReport			:= ""
	::cShowExport		:= "1"									// anzeigen
	::cTitle				:= "Druck"
	::hJob				:= 0
	::nSelect			:= 0
	::_oParent			:= oParent								  // aufrufender dialog
	::_aAddTable	   := {}
	::_aAddTableRelation := {}
	::_aField			:= {}
	::_aList				:= {}
	::_aRecht			:= aclone(::__aRecht)
	::_aSync				:= {}
	::_aOptimize  		:= {.f.,.f.}
	::_aTable			:= {}
	::_aVar				:= {}
	::_cIgnoreField	:= ::__cIgnoreField
	::_lDesign			:= false
	::_lDesignerPreview  := ::__lDesignerPreview
	::_lIsReleased		:= false
	::_lOptions			:= true
	::_lPrintAtEof		:= false
	::_lRtf				:= lRtf
	::_lSubReport		:= false
	::_nBoxType			:= ::__nBoxType
	::_nError			:= 0
	::_nFirstpage		:= 1
	::_nLastpage		:= 1
	::_nPages			:= 0
	::_nProject			:= LL_PROJECT_LIST							// default
	::_nPrintOption	:= LL_PRINT_NORMAL
	::_nQuantity		:= 1
	::_nStatus			:= XBP_STAT_INIT
#if XPPVER >= 2000840
	::DataObject		:= DataObject():New()
#endif

	if !empty(::__aDefaultVar)
		::_aVar			:= aclone(::__aDefaultVar)
	endif

	lRet := _EvalLLFunc("ModuleInit")

	if !lRet
		::_nStatus   := XBP_STAT_FAILURE
		if IsBlock(::__onError)
			oError	:= Error():New()
			oError:args				:= "CMLL"+ scVersion + ".DLL"
			oError:canDefault		:= false
			oError:canRetry		:= true
			oError:canSubstitute := false
			oError:osCode			:= DosError()
			oError:description   := DosErrorMessage(oError:osCode)
			oError:genCode			:= oError:osCode
			oError:operation     := "Error Loading CMLL"+ scVersion + ".DLL"
			oError:subSystem     := "ListLabel"
			oError:cargo			:= self
			oError:thread			:= threadid()
			eval(::__onError, oError)
		endif
		RETURN self
	endif

	if empty(lRtf)											 // ausschalten wegen performance
		LlSetOption(-1, LL_OPTION_MAXRTFVERSION, 0 )
	endif

	::hJob	 := LlJobOpen(::__nLanguage)
	if ::hJob < 0
		::_nError   := ::hJob
		::_nStatus  := XBP_STAT_FAILURE
		::hJob		:= 0
		::_RaiseError(::_nError, var2char(::__nLanguage), "LLJobOpen()")
		RETURN self
	endif
	::_nStatus		:= 1									 // laden DLL erfolgreich

#ifdef _DESIGNERPREVIEW
	if IsNumber(oParent)
		LlAssociatePreviewControl(::hJob, ::hWnd, LL_ASSOCIATEPREVIEWCONTROLFLAG_DELETE_ON_CLOSE)
	endif
#endif

	// defaults + reset
	LlSetPrinterDefaultsDir(::hJob, _GetTempPath())
	LlPreviewSetTempPath(::hJob, _GetTempPath())
	LlDefineFieldStart(::hJob)
	LlDefineVariableStart(::hJob)
	LlDefineSortOrderStart(::hJob)
	LlDbAddTable(::hJob, "", "")

	if !empty(::__nDebug)
		LlSetDebug(::hJob, ::__nDebug )
	endif

#ifndef DEBUG
	LlSetOption(::hJob, LL_OPTION_NOPARAMETERCHECK		,1)
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

	LlSetOptionString (::hJob, LL_OPTIONSTR_LICENSINGINFO    ,::__cLicence )
	if !empty(::__cExport)
		LlSetOptionString (::hJob, LL_OPTIONSTR_EXPORTS_ALLOWED_IN_PREVIEW, ::__cExport)
	endif

	::ResetMenue()

	// interne defaults
	if ascan(::_aVar, {|x| x[1] == "USER"}) = 0
#if XPPVER >= 2000840
		cTmp	:= space(255)
		iCnt	:= 255
		GetUsername( @cTmp, @iCnt )
		cTmp	:= left(cTmp, --iCnt)
#else
		cTmp	:= space(255)
		iCnt	:= u2bin(255)
		GetUsernameA( @cTmp, @iCnt)
		cTmp	:= substr( cTmp, 1, bin2u( iCnt ) - 1 )
#endif
		aadd( ::_aVar, {"USER"   ,cTmp, LL_TEXT})
	endif

	if ascan(::_aVar, {|x| x[1] == "COMPUTER"}) = 0
#if XPPVER >= 2000840
		cTmp	:= space(255)
		iCnt	:= 255
		GetComputername( @cTmp, @iCnt)
		cTmp	:= left(cTmp, iCnt)
#else
		cTmp	:= space(255)
		iCnt	:= u2bin(255)
		GetComputernameA( @cTmp, @iCnt)
		cTmp	:= substr( cTmp, 1, bin2u( iCnt ) - 1 )
#endif
		aadd( ::_aVar, {"COMPUTER"   ,cTmp, LL_TEXT})
	endif

	iCnt	:= len( ::__aPrepare)
	for i := 1 to iCnt
		eval(::__aPrepare[i], self, ::hJob)
	next

RETURN self

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
	LOCAL nError    := 0
	LOCAL _nLastRec := 1, nRec, nPrint := 0, _nQuantity, nPage
	LOCAL cPath     := getEnv("USERPROFILE")+"\Documents"
	LOCAL aExport
	LOCAL cChild
	LOCAL i, iCnt
	LOCAL lPrintAtEof
	LOCAL bEof, bRecno
	LOCAL nCallBack := 0
#ifdef _XCLASS
	LOCAL cTmp
	LOCAL dbTable
#endif

	if ! IsNumber(::hJob) .or. ::hJob <= 0							 // ::hJob kann auch NIL sein!!!
		RETURN LL_ERR_BAD_JOBHANDLE
	endif

	::_nRootSelect := ::nSelect

	if ::_lDesign
		// abwärtskompatibel
		RETURN ::design()
	endif

#ifdef _XCLASS
	bEof		:= {|n| n:eof()}
	bRecno   := {|n| n:recno()}
	if empty( ::_bSkipBlock)
		::_bSkipBlock   := {|o, n| n:skip()}
	endif
	if empty( ::_bTopBlock)
		::_bTopBlock   := {|o, n| n:gotop()}
	endif

#else
	bEof		:= {|n| (n)->(eof())}
	bRecno   := {|n| (n)->(recno())}
	if empty( ::_bSkipBlock)
		::_bSkipBlock	:= {|o, n| (n)->(dbskip())}
	endif
	if empty( ::_bTopBlock)
		::_bTopBlock	:= {|o, n| (n)->(dbgotop())}
	endif

#endif

	if IsObject(::nSelect )
#ifdef _XCLASS
		if IsServer(::nSelect )
      	dbTable  := ::nSelect
      	::nSelect:pushstate()
			if IsMethod(::nSelect, "countrec")
				_nLastRec	:= ::nSelect:countrec()                                        // nur ace

			elseif IsMethod(::nSelect, "lastrec")
				_nLastRec	:= ::nSelect:lastrec()
			endif
		endif
#endif
	elseif IsArray(::nSelect )
		_nLastRec   := len(::nSelect)
		::_bSkipBlock	:= {|o, n| NIL}
		::_bTopBlock	:= {|o, n| NIL}

	elseif IsNumber(::nSelect) .and. ::nSelect > 0
		_nLastRec   := (::nSelect)->(lastrec())
		eval(::_bTopBlock, self, ::nSelect )
	endif

	::cOutPut	:= space(250)
	::datalink(1, 1 )											 // erstinit variablen
	if ::_nProject == LL_PROJECT_LIST
		::datalink(0,1, -1 )										// erstinit felder
	endif

	if !empty( ::_cPrinter )
		::_SetPrinter()
	endif

	if IsBlock(::_bPrepare)
		eval(::_bPrepare, self, ::nSelect )
	endif

	if !::_PrintStart()
		RETURN ::_nError
	endif
#ifdef _XCLASS
	if ::_aOptimize[1]
		cTmp	:= space(5000)
		nError	:= LLGetUsedIdentifiersEx(::hJob, ::cReport, LL_USEDIDENTIFIERSFLAG_FIELDS, @cTmp, 5000)
		if nError == 0
			::_aUsedFields	:= _astrextract(_Trim0(cTmp), ";")
			asort(::_aUsedFields)
		endif
		cTmp	:= NIL
	endif
#endif
	iCnt   := len( ::__aConfig)
	for i := 1 to iCnt
		eval(::__aConfig[i], self, ::hJob)
	next

	LlPrintSetOption(::hJob, LL_PRNOPT_PAGE , ::_nFirstpage )

	if IsCharacter(::cOutFile) .and. ( i := rat("\", ::cOutFile )) > 0
		cPath := left( ::cOutFile, i )
		::cOutFile := subs( ::cOutFile, ++i)
		LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ""   ,"Export.Path", cPath)
	endif
	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, ""   ,"Export.ShowResult", ::cShowExport)

	if IsBlock(::_bConfig)
		eval(::_bConfig, self, ::hJob )
	endif

	if IsCharacter( ::cExportFormat ) .and. !empty(::cExportFormat)
		aExport   := _astrextract(::cExportFormat, ";")

		for i := len( aExport) to 1 step -1
			if aExport[i] = "PDF"
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.File", _SetExtension(::cOutFile, "PDF") )
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.File", _GetExportName(cPath, "PDF"))
				endif

			elseif aExport[i] = "XHTML"
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XHTML"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XHTML"   ,"Export.File", _SetExtension(::cOutFile, "HTML") )
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XHTML"   ,"Export.File", _GetExportName(cPath, "HTML"))
				endif

			elseif aExport[i] = "HTML"
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "HTML"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "HTML"   ,"Export.File", _SetExtension(::cOutFile, "HTML") )
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "HTML"   ,"Export.File", _GetExportName(cPath, "HTML"))
				endif

			elseif aExport[i] = "JQM"
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "JQM"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "JQM"   ,"Export.File", _SetExtension(::cOutFile, "HTML") )
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "JQM"   ,"Export.File", _GetExportName(cPath, "HTML"))
				endif

			elseif aExport[i] = "PPTX"
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PPTX"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PPTX"   ,"Export.File", _SetExtension(::cOutFile, "PPTX") )
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PPTX"   ,"Export.File", _GetExportName(cPath, "PPTX"))
				endif

			elseif aExport[i] = "XLS"
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XLS"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XLS"   ,"Export.File", _SetExtension(::cOutFile, "XLS") )
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XLS"   ,"Export.File", _GetExportName(cPath, "XLS"))
				endif

			elseif aExport[i] = "XML"
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XML"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XML"   ,"Export.File", _SetExtension(::cOutFile, "XML"))
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XML"   ,"Export.File", _GetExportName(cPath, "XML"))
				endif

			elseif aExport[i] = "PICTURE_JPEG"
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_JPEG"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_JPEG"   ,"Export.File", _SetExtension(::cOutFile, "JPG"))
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_JPEG"   ,"Export.File", _GetExportName(cPath, "JPG"))
				endif

			elseif aExport[i] = "PICTURE_TIFF"
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_TIFF"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_TIFF"   ,"Export.File", _SetExtension(::cOutFile, "TIF"))
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_TIFF"   ,"Export.File", _GetExportName(cPath, "TIF"))
				endif

			elseif aExport[i] = "TXT"
				LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"   ,"Export.OnlyTableData", "1")
				LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"   ,"Export.FrameChar", "NONE")
				LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"   ,"Export.SeparatorChar", ";")
				if !empty(::cOutFile)
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"   ,"Export.Quiet", "1")
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"   ,"Export.File", _SetExtension(::cOutFile, "TXT"))
				else
					LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"   ,"Export.File", _GetExportName(cPath, "TXT"))
				endif
			endif
		next
		LLSetOptionString(::hJob, LL_OPTIONSTR_EXPORTS_ALLOWED, ::cExportFormat)
		if ! ";" $ ::cExportFormat								    // nur 1 Export def., dann keine Auswahl
			::_nError	:= LlPrintSetOptionString(::hJob, LL_PRNOPTSTR_EXPORT, ::cExportFormat)
			::_RaiseError(::_nError, ::cExportFormat, "LlPrintSetOptionString(LL_PRNOPTSTR_EXPORT)")
			::_lOptions   := false
		else
			::_lOptions   := true
		endif
	endif

	if !::IsPreview() .and. ::_lOptions
		::_nError   := LLPrintOptionsDialog( ::hJob, ::hWND, "")
		if ::_nError == LL_ERR_USER_ABORTED
			RETURN LL_ERR_USER_ABORTED
		endif
		::GetPrinter()
	endif

	// das in dem Druck-dialog evt. ausgewählte Exportformat, es kann ja nur eins ausgewählt worden sein
	LlPrintGetOptionString(::hJob, LL_PRNOPTSTR_EXPORT, @::cOutPut, 250)
	::cOutPut   := _Trim0( ::cOutPut)
	::cOutFile  := space(250)
	cPath	 := space(250)

	if ::cOutPut = "PDF"
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.File", @::cOutFile, 250)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"Export.Path", @cPath, 250)
	elseif ::cOutPut = "HTML"
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "HTML"   ,"Export.File", @::cOutFile, 250)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "HTML"   ,"Export.Path", @cPath, 250)
	elseif ::cOutPut = "XLS"
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XLS"   ,"Export.File", @::cOutFile, 250)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XLS"   ,"Export.Path", @cPath, 250)
	elseif ::cOutPut = "XML"
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XML"   ,"Export.File", @::cOutFile, 250)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "XML"   ,"Export.Path", @cPath, 250)
	elseif ::cOutPut = "PICTURE_JPEG"
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_JPEG"   ,"Export.File", @::cOutFile, 250)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_JPEG"   ,"Export.Path", @cPath, 250)
	elseif ::cOutPut = "PICTURE_TIFF"
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_TIFF"   ,"Export.File", @::cOutFile, 250)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PICTURE_TIFF"   ,"Export.Path", @cPath, 250)
	elseif ::cOutPut = "TXT"
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"   ,"Export.File", @::cOutFile, 250)
		LlXGetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "TXT"   ,"Export.Path", @cPath, 250)
	endif
	::cOutFile   := _Trim0(cPath ) + _Trim0( ::cOutFile)

	if IsNumber(::_nLastRec )
		_nLastRec   := ::_nLastRec
	endif
	if empty(_nLastRec)
		_nLastRec   := 1
	endif

#if XPPVER >= 2000840
	if IsBlock(::xCallback)
		nCallBack   := _LLPreviewCallBack():New(self,::xCallback)
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_VIEWERBTNCLICKED, nCallBack:functionpointer)
	endif

#else
#ifdef _CALLBACK
	if IsBlock(::xCallback)
		nCallBack   := RegisterLLCallBack(::xCallback)
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_VIEWERBTNCLICKED, nCallBack)
	endif
#endif
#endif

	nRec   := 0
	nPage  := 0
	if IsBlock( bPrint )
		// LlPrint + llPrintEnd  muß hier in codeblock gestartet werden !!
		::_nError   	:= ::eval( bPrint, self, ::nSelect )
		::_nLastpage   := LlPrintGetCurrentPage(::hJob)

	else
		if ::_nProject == LL_PROJECT_LIST
			_nLastRec   *= ::_nQuantity
			for _nQuantity := 1 to ::_nQuantity
				lPrintAtEof   := ::_lPrintAtEof
				nRec     := 0
				nError   := 0
				if IsObject(::nSelect ) .or. (IsNumber(::nSelect ) .and. ::nSelect > 0)
					eval(::_bTopBlock, self, ::nSelect )
				endif
				if IsBlock(::_bCopyblock)
					eval( ::_bCopyblock, self, ::nSelect, _nQuantity )
				endif
				do while LlPrint(::hJob) == LL_WRN_REPEAT_DATA
				enddo
				if IsArray( ::nSelect)
					for nPrint := 1 to _nLastRec
						::datalink(0, nPrint)
						do while (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
							LlPrint(::hJob)
						enddo
						nPage		:= LlPrintGetCurrentPage(::hJob)
						LlPrintSetBoxText(::hJob, "Printing", nPrint / _nLastRec * 100 )
#ifdef _DESIGNERPREVIEW
						if !_PrintRuns(,.t.)
							LlPrintAbort(::hJob)
							exit
						endif
#endif
						if ::_nPages > 0 .and. nPage > ::_nPages
							exit
						endif
					next

				elseif ::_lSubReport
					do while true
						cChild   := space(50)
						LlPrintDbGetCurrentTable(::hJob, @cChild, 50, false )
						cChild := _Trim0( cChild )
						if IsBlock(::_bTableChange)
#ifdef _XCLASS
							eval(::_bTableChange, self, true, ::getSelect(cChild), "")
#else
							eval(::_bTableChange, self, true, cChild, "")
#endif
						endif

						nError := ::_PrintTable(cChild, "", 0 )

						if nError = LL_WRN_TABLECHANGE
							if IsBlock(::_bTableChange)
#ifdef _XCLASS
								eval(::_bTableChange, self, false, ::getSelect(cChild), "")
#else
								eval(::_bTableChange, self, false, cChild, "")
#endif
							endif
							loop
						endif
#ifdef _DESIGNERPREVIEW
						if !_PrintRuns(,.t.)
							LlPrintAbort(::hJob)
							exit
						endif
#endif
						exit
					enddo
				else
					do while nError == 0 .and. (!eval(bEof, ::nSelect) .or. lPrintAtEof ) .and. nRec <> eval(bRecno,::nSelect) .and. (::_nPages == 0 .or. nPage <= ::_nPages)
						nRec   := eval(bRecno, ::nSelect)
						lPrintAtEof   := false
						::datalink(0)
						do while (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
							LlPrint(::hJob)
						enddo
						nPage		:= LlPrintGetCurrentPage(::hJob)
						eval( ::_bSkipBlock, self, ::nSelect)
						LlPrintSetBoxText(::hJob, "Printing", ++nPrint / _nLastRec * 100 )
#ifdef _DESIGNERPREVIEW
						if !_PrintRuns(,.t.)
							LlPrintAbort(::hJob)
							exit
						endif
#endif
					enddo
					do while (nError := LlPrintFieldsEnd(::hJob)) == LL_WRN_REPEAT_DATA
					enddo
					::_nLastpage   := LlPrintGetCurrentPage(::hJob)
				endif
				if ::IsPreview() .and. !IsBlock(::_bCopyblock)
					exit
				endif
				LlPrintResetProjectState(::hJob)
			next

		elseif IsObject(::nSelect )									    // CRD oder LBL
			eval(::_bTopBlock, self, ::nSelect )
			do while nError == 0 .and. (!::nSelect:eof() .or. ::_lPrintAtEof) .and. nRec <> ::nSelect:recno() .and. (::_nPages == 0 .or. nPage <= ::_nPages)
				nRec   := ::nSelect:recno()
				::_lPrintAtEof   := false
				::datalink(1)
				for _nQuantity := 1 to ::_nQuantity
					do while (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA	;enddo
				next
				nPage		:= LlPrintGetCurrentPage(::hJob)
				eval( ::_bSkipBlock, self, ::nSelect)
				LlPrintSetBoxText(::hJob, "Printing", ++nPrint / _nLastRec * 100 )
#ifdef _DESIGNERPREVIEW
				if !_PrintRuns(,.t.)
					LlPrintAbort(::hJob)
					exit
				endif
#endif
			enddo

		elseif IsNumber(::nSelect) .and. ::nSelect > 0									    // CRD oder LBL
			eval(::_bTopBlock, self, ::nSelect )
			do while nError == 0 .and. (!(::nSelect)->(eof()) .or. ::_lPrintAtEof) .and. nRec <> (::nSelect)->(recno()) .and. (::_nPages == 0 .or. nPage <= ::_nPages)
				nRec   := (::nSelect)->(recno())
				::_lPrintAtEof   := false
				::datalink(1)
				for _nQuantity := 1 to ::_nQuantity
					do while (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA	;enddo
				next
				nPage		:= LlPrintGetCurrentPage(::hJob)
				eval( ::_bSkipBlock, self, ::nSelect)
				LlPrintSetBoxText(::hJob, "Printing", ++nPrint / _nLastRec * 100 )
#ifdef _DESIGNERPREVIEW
				if !_PrintRuns(,.t.)
					LlPrintAbort(::hJob)
					exit
				endif
#endif
			enddo

		elseif IsArray( ::nSelect)
			for nPrint := 1 to _nLastRec
				::datalink(1, nPrint)
				for _nQuantity := 1 to ::_nQuantity
					do while (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA	;enddo
				next
				nPage		:= LlPrintGetCurrentPage(::hJob)
				if ::_nPages == 0 .or. nPage <= ::_nPages
					exit
				endif
				LlPrintSetBoxText(::hJob, "Printing", nPrint / _nLastRec * 100 )
#ifdef _DESIGNERPREVIEW
				if !_PrintRuns(,.t.)
					LlPrintAbort(::hJob)
					exit
				endif
#endif
			next

		else
			// aktuelle Daten einmal ausgeben,
			for _nQuantity := 1 to ::_nQuantity
				do while (nError := LlPrint(::hJob)) == LL_WRN_REPEAT_DATA .and. ::_nProject <> LL_PROJECT_LABEL .and. (::_nPages == 0 .or. nPage <= ::_nPages)
				enddo
				nPage		:= LlPrintGetCurrentPage(::hJob)
				LlPrintSetBoxText(::hJob, "Printing", ++nPrint / ::_nQuantity * 100 )
			next
		endif
		::_nLastpage   := LlPrintGetCurrentPage(::hJob)
		::_nError := LlPrintEnd(::hJob,0)
		::_RaiseError(::_nError, ::cReport, "LlPrintEnd()")
	endif
	::_nStatus   := 1

	if ::_nError == 0 .and. IsBlock(::xCallback) .and. !::IsPreView()
		// falls direkt druck
		eval( ::xCallback, LL_NTFY_AFTERPRINT, MNUID_LL_PRINT, self )
	endif

	LlSetNotificationCallbackExt(::hJob, LL_NTFY_VIEWERBTNCLICKED, NIL )
	LlPreviewDeleteFiles(::hJob, ::cReport, _GetTempPath())
	LlAssociatePreviewControl(::hJob,NIL,1)							// associate the window handle

#ifdef _XCLASS
	if IsServer(dbTable)
      dbTable:popstate()
	endif
#endif

#if XPPVER >= 2000840
	if IsObject(nCallback)
		nCallback:destroy()
	endif
#else
#ifdef _CALLBACK
	if nCallback > 0
		UnRegisterLLCallBack()
	endif
#endif	// _CALLBACK
#endif	// XPPVER

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
#ifdef _DESIGNERPREVIEW
	LOCAL nCallback
#endif
	if ! IsNumber(::hJob) .or. ::hJob <= 0							 // ::hJob kann auch NIL sein!!!
		RETURN LL_ERR_BAD_JOBHANDLE
	endif

	::datalink(1,1 )											 // erstinit variablen
	if ::_nProject == LL_PROJECT_LIST
		::datalink(0, 1, -1 )										// erstinit felder
	endif

	if IsBlock(::_bPrepare)
		eval(::_bPrepare, self, ::nSelect )
	endif

#ifdef _DESIGNERPREVIEW
	if ::_lDesignerPreview
		LlSetOption(::hJob,LL_OPTION_DESIGNERPREVIEWPARAMETER, 1)
#if XPPVER >= 2000840
		nCallBack   := _LLDesignerCallBack():New(self)
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_DESIGNERPRINTJOB, nCallBack:functionpointer)
#else
		nCallBack   := RegisterLLCallBack({|x,y,o| DesignerCallback(x,y,z,self)})
		LlSetNotificationCallbackExt(::hJob, LL_NTFY_DESIGNERPRINTJOB, nCallBack)
#endif	// XPPVER
	endif
#endif	// _DESIGNERPREVIEW

	::_nError	:= LlDefineLayout(::hJob, ::hWnd, "Designer", ::_nProject, ::cReport)
	::_RaiseError(::_nError, ::cReport, "LlDefineLayout()")

#ifdef _DESIGNERPREVIEW
	if ::_lDesignerPreview
#if XPPVER >= 2000840
		nCallback:destroy()
#else
		UnRegisterLLCallBack()
#endif
	endif
#endif
RETURN 0

//=========================================
METHOD dsListLabel:_PrintTable(cChild, cParent, nRek )
	LOCAL nSelect   := 0
	LOCAL cRelation, cTmp
	LOCAL nError , _nLastRec, nPrint := 0, nPage
	LOCAL lScope	:= false
	LOCAL nOSelect	:= ::nSelect
#ifdef _XCLASS
	LOCAL dbChild, dbParent
	LOCAL bEof	:= {|n| n:eof()}
#else
	LOCAL bKey
	LOCAL cKey
	LOCAL bEof	:= {|n| (n)->(eof())}
#endif

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

	nSelect	:= ::getSelect(cChild)
	nPage    := 0

#ifdef _XCLASS
	if IsObject(cParent)
		dbParent		:= cParent
		cParent		:= space(200)
		nError		:= LlPrintDbGetCurrentTableRelation(::hJob, @cParent, 200 )
		cParent		:= _Trim0( cParent )
	endif
	dbChild		:= nSelect
	if !IsObject(dbParent)
		dbParent	:= ::getSelect(cParent)
	endif
	::_SetRelation(ifempty(dbParent, ::_nRootSelect), nSelect, @lScope)
#endif

	if Empty(cParent)                                                                // root tabelle
		eval(::_bTopBlock, self, nSelect )
		::nSelect   := nSelect
		::datalink(0, ,-1 )
#ifdef _XCLASS
  		if ::nSelect:dbType == SRV_ACE .or. ::nSelect:dbType == SRV_ACESQL
			_nLastRec   := max(1, nSelect:countrec())
		else
			_nLastRec   := max(1, nSelect:lastrec())
		endif
#else
		_nLastRec   := max(1, (nSelect)->(lastrec()))
#endif
		do while !eval(bEof, nSelect) .and. nError <> LL_ERR_USER_ABORTED .and. (::_nPages == 0 .or. nPage <= ::_nPages)
			::datalink(0, ,nRek )
			do while (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
				do while LlPrint(::hJob) == LL_WRN_REPEAT_DATA
				enddo
			enddo

			do while nError == LL_WRN_TABLECHANGE
				cTmp		:= space(50)
				nError	:= LlPrintDbGetCurrentTable(::hJob, @cTmp, 50, false )
				cTmp		:= _Trim0( cTmp )
				nError	:= ::_PrintTable(cTmp, cChild, nRek + 1 )
			enddo
			nPage		:= LlPrintGetCurrentPage(::hJob)
			eval( ::_bSkipBlock, self, nSelect)
			LlPrintSetBoxText(::hJob, "Printing", ++nPrint / _nLastRec * 100 )
#ifdef _DESIGNERPREVIEW
			if !_PrintRuns(,.t.)
				LlPrintAbort(::hJob)
				exit
			endif
#endif
		enddo

	//=========================================
	else
		// unterstufe
		cRelation	:= space(200)
		nError		:= LlPrintDbGetCurrentTableRelation(::hJob, @cRelation, 200 )
		cRelation	:= _Trim0( cRelation )

#ifdef _XCLASS
		dbChild		:= nSelect
		if !IsObject(dbParent)
			dbParent	:= ::getSelect(cParent)
		endif
		::nSelect   := dbChild
		if IsBlock(::_bTableChange)
			eval(::_bTableChange, self, true, dbChild, dbParent )
		endif
		dbChild:gotop()
		do while !dbChild:eof() .and. nError <> LL_ERR_USER_ABORTED .and. (::_nPages == 0 .or. nPage <= ::_nPages)
			::datalink(0, ,nRek )
			do while (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
				do while LlPrint(::hJob) == LL_WRN_REPEAT_DATA
				enddo
			enddo
			do while nError == LL_WRN_TABLECHANGE
				cTmp		:= space(50)
				nError	:= LlPrintDbGetCurrentTable(::hJob, @cTmp, 50, false )
				cTmp		:= _Trim0( cTmp )
				nError	:= ::_PrintTable(cTmp, dbChild, nRek + 1 )
			enddo
			nPage		:= LlPrintGetCurrentPage(::hJob)
			eval( ::_bSkipBlock, self, dbChild)
#ifdef _DESIGNERPREVIEW
			if !_PrintRuns(,.t.)
				LlPrintAbort(::hJob)
				exit
			endif
#endif
		enddo
		if lScope
			dbChild:clearscope()
		endif
		if IsBlock(::_bTableChange)
			eval(::_bTableChange, self, false, dbChild, dbParent )
		endif
		// ende XCLASS
#else
		if left(cRelation,2 ) = "&"
			bKey	:= &("{|o,p,c| " + subs(cRelation,2) +"}")
			cKey	:= eval( bKey, self, cParent, cChild )
			if cKey != NIL
				(nSelect)->(dbSetScope(SCOPE_BOTH, cKey))
				lScope	:= true
			endif

		elseif left(cRelation,1 ) = "<"
			cKey	:= (cParent)->(&(subs(cRelation,2)))
			(nSelect)->(dbSetScope(SCOPE_BOTH, cKey))
			lScope	:= true
		endif

		::nSelect   := nSelect
		if IsBlock(::_bTableChange)
			eval(::_bTableChange, self, true, cChild, cParent )
		endif
		(nSelect)->(dbgotop())
		do while !(nSelect)->(eof()) .and. nError <> LL_ERR_USER_ABORTED .and. (::_nPages == 0 .or. nPage <= ::_nPages)
			::datalink(0, ,nRek )
			do while (nError := LlPrintFields(::hJob)) == LL_WRN_REPEAT_DATA
				do while LlPrint(::hJob) == LL_WRN_REPEAT_DATA
				enddo
			enddo

			do while nError == LL_WRN_TABLECHANGE
				cTmp   := space(50)
				nError := LlPrintDbGetCurrentTable(::hJob, @cTmp, 50, false )
				cTmp   := _Trim0( cTmp )
				nError := ::_PrintTable(cTmp, cChild, nRek + 1 )
			enddo
			nPage		:= LlPrintGetCurrentPage(::hJob)
			eval( ::_bSkipBlock, self, nSelect)
#ifdef _DESIGNERPREVIEW
			if !_PrintRuns(,.t.)
				LlPrintAbort(::hJob)
				exit
			endif
#endif
		enddo
		if lScope
			(nSelect)->(dbClearScope())
		endif
		if IsBlock(::_bTableChange)
			eval(::_bTableChange, self, false, cChild, cParent )
		endif
#endif
		::nSelect   := nOSelect
	endif
	do while (nError := LlPrintFieldsEnd(::hJob)) == LL_WRN_REPEAT_DATA
	enddo
	::_nLastpage   := LlPrintGetCurrentPage(::hJob)
RETURN nError

//=========================================
METHOD dsListLabel:_SetRelation(dbParent,dbChild, lScope)
	LOCAL cRelation
	LOCAL i, iCnt
	LOCAL aKey, aTmp
	LOCAL bKey
	UNUSED (dbParent)
	UNUSED (dbChild)
	UNUSED (i)
	UNUSED (iCnt)
	UNUSED (aKey)
	UNUSED (bKey)
	UNUSED (aTmp)
	UNUSED (lScope)

	// unterstufe
	cRelation	:= space(200)
	LlPrintDbGetCurrentTableRelation(::hJob, @cRelation, 200 )
	cRelation	:= _Trim0( cRelation )

#ifdef _XCLASS
	if !IsServer(dbParent)
		RETURN self
	endif

	if left(cRelation,1 ) = "&"
		bKey	:= &("{|o,dbP,dbC| " + subs(cRelation,2) +"}")
		aKey	:= eval( bKey, self, dbParent, dbChild )
		if aKey != NIL
			dbChild:setscope(, aKey )
			lScope	:= true
		endif

	elseif left(cRelation,1 ) $ "<;"
		aKey     := _aStrExtract(subs(cRelation,2), ";")
		aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, true )
		if len(aKey) == 1
			aKey	:= aKey[1]
		endif
		dbChild:setscope(, aKey )
		lScope	:= true

	elseif left(cRelation,1 ) = "$"                                                // SQL Parameter: $_POSTEN:_REC_ID$AUFTRAG:AUFTRNR
		aKey     := aStrExtract(subs(cRelation,2), "$")
		iCnt	:= len( aKey)
		for i := 1 to iCnt
			if ";" $ aKey[i]
				aTmp	:= aStrExtract(aKey[i], ";" )
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
		aKey     := aStrExtract(cRelation, ";")
		aeval( aKey, {|a| if(a = "'", a := strtran(a, "'"), a := dbParent:fieldget(a))},,, true )
		if len(aKey) == 1
			aKey	:= aKey[1]
		endif
		dbChild:setscope(, aKey )
		lScope	:= true

	endif
#endif

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
	LOCAL nRet := 0
	cSymbol	:= upper(cSymbol)
	if (nRet := ascan( ::_aList, {|a| a[__SYMBOL] == cSymbol})) > 0
		nRet  := ::_aList[nRet, __SELECT]
	elseif (nRet := ascan( ::_aTable, {|a| a[__SYMBOL] == cSymbol})) > 0
		nRet  := ::_aTable[nRet, __SELECT]
	endif
RETURN nRet

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

	::datalink(1,1)
	do while ::_nError == 0 .and. nPos++ < nQuantity
		LlDefineVariableExt(::hJob,  "Number" ,var2char(nPos)   ,LL_NUMERIC, 0 )
		::_nError	:= LlPrint(::hJob)
		LlPrintSetBoxText(::hJob, "Printing", nPos / nQuantity * 100 )
	enddo
	if empty(lJobOpen)
		LlPrintEnd(::hJob,0)
		::_nStatus   := 1
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
#ifdef _XCLASS
	::dsDbContainer:close()
#endif
#if XPPVER >= 2000840
	::DataObject	:= NIL
#endif
	::_nStatus		:= 0
	if IsNumber(::hJob) .and. ::hJob > 0							   // ::hJob kann auch NIL sein!!!
		LlJobClose(::hJob)
	endif
	::hJob			:= NIL
RETURN self

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
	LlSetDebug(::hJob, nDebug)
RETURN self

/*============================================================================
 $Method:	SetProperty(xData, nProject, cTitle )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xData
 $Argument:     nProject
 $Argument:     cTitle
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:SetProperty(xData, nProject, cTitle )
	LOCAL cTmp
	if nProject != NIL
		::_nProject	:= nProject
	endif
	if IsCharacter(xData )									     // diesen Report auswählen
		::cReport	:= _Fullpath( xData, ::__cDefaultPath )

	elseif !empty( ::hJob )
		if !empty(::__cDefaultPath)
			curdir(::__cDefaultPath)
		endif
		::cReport	:= replicate(chr(0),255)
		LlSelectFileDlgTitleEx( ::hJob, ::hWND, coalesce( cTitle, "Select file"), ::_nProject, @::cReport, 255)
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
 $Method:	Connect([nSelect])
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nSelect
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
RETURN

//=========================================
METHOD dsListLabel:_PrintStart(xBoxType)
	if pcount() == 0
		xBoxType   := ::_nBoxType
	endif
	if !empty(xBoxType) .and. if(IsNumber(xBoxType), xBoxType >= 0, true )
		::_nError   := LlPrintWithBoxStart(::hJob,	;
			::_nProject,;
			::cReport,;
			::_nPrintOption,;
			if(IsNumber(xBoxType), xBoxType, LL_BOXTYPE_NORMALWAIT),;
			::hWND,;
			::cTitle )
	else
		::_nError   := LlPrintStart(::hJob,;
			::_nProject,;
			::cReport,;
			::_nPrintOption )
	endif
	if ::_nError == 0
		::_nStatus   := 2

	elseif ::_nError == LL_ERR_USER_ABORTED
		// quit, no error
		::_nStatus   := 0

	else
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

/*============================================================================
 $Method:	GetPrinter()
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:
 $Return:	_Trim0@(cPrinter@)
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:GetPrinter()
	LOCAL cPrinter   := space(100)
	LlPrintGetPrinterInfo(::hJob, @cPrinter, 100, "", 0 )
	::_cPrinter   := _Trim0(cPrinter)
RETURN ::_cPrinter

/*============================================================================
 $Method:	DefaultPrinter()
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    None
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:DefaultPrinter()
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
 $Method:	Report(xSet)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    xSet
 $Return:	xRet
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Report(xSet)
	LOCAL xRet   := ::cReport
	if IsCharacter(xSet)
		::cReport := _Fullpath( xSet, ::__cDefaultPath)
		// autodetect Projekttype
		xSet	:= upper( right(::cReport,3))
		if xSet = "CRD"
			::_nProject   := LL_PROJECT_CARD
		elseif xSet = "LST"
			::_nProject   := LL_PROJECT_LIST
		elseif xSet = "LBL"
			::_nProject   := LL_PROJECT_LABEL
		endif
	endif
RETURN xRet

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
		::_lOptions := false

	elseif pcount() == 1 .and. empty(xSet)
		::_cPrinter := NIL
		::_lOptions := true
	endif
	if !empty( ::_cPrinter) .and. !empty(::hJob)
		LlSetPrinterInPrinterFile(::hJob, ::_nProject, ::cReport, -1, ::_cPrinter, 0)
	endif
RETURN xRet

/*============================================================================
 $Method:	Datalink(nMode, [nRecno], [nRekursiv] )
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nMode
 $Argument:    nRecno
 $Argument:     nRekursiv, intern
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Datalink(nMode, nRecno, nRekursiv )
	LOCAL i, iCnt
	LOCAL aDb
#ifdef _XCLASS
	LOCAL nPos, nPos2
	LOCAL dbTable
#endif

	nRekursiv  := coalesce(nRekursiv, 0)
	nMode   	  := coalesce(nMode, 0)

	if nMode = 0 .or. ::_nProject == LL_PROJECT_LABEL .or. ::_nProject == LL_PROJECT_CARD
		iCnt   := len( ::_aSync)
		for i := 1 to iCnt
		if IsBlock(::_aSync[i])
				::eval( ::_aSync[i], self, ::nSelect, nRecno, nRekursiv )
			endif
		next
	endif
#ifdef _XCLASS
	if IsArray(::_aUsedFields) .and. empty(nMode) .and. (iCnt := len( ::_aUsedFields)) > 0
		// nur mit Xclass++
		for i := 1 to iCnt
			if (nPos := rat(".", ::_aUsedFields[i])) > 0
				nPos2 := rat(".", ::_aUsedFields[i], nPos -1)
				dbTable := ::GetDbContainer(subs(::_aUsedFields[i], nPos2+1, nPos - nPos2 - 1), false )
				if IsServer( dbTable ) .and. dbTable:IsField(subs(::_aUsedFields[i], nPos + 1))
					::_datalink( nMode, dbTable, left(::_aUsedFields[i], nPos-1 ), {subs(::_aUsedFields[i], nPos + 1)})
				endif
			else
				::_datalink( nMode, ::_nConnect,"", {::_aUsedFields[i]})
			endif
		next
	else
#endif
		if nMode == 0
			aDb   := ::_aList
		else
			aDb   := ::_aTable
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
#ifdef _XCLASS
	endif
#endif
	if nMode == 0
		::_VarLink(nMode, ::_aField, nRecno )
	else
		::_VarLink(nMode, ::_aVar, nRecno )
	endif

RETURN self

//=========================================
METHOD dsListLabel:DatalinkTable(nMode, xServer )
	LOCAL cDesigner
	LOCAL aField, aList
	LOCAL nPos	:= 0

	if nMode == 0
		aList	:= ::_aList
	else
		aList	:= ::_aTable
	endif

	if IsCharacter(xServer)			// 1. Parameter von :datasetField
		nPos := ascan(aList, {|a| a[__SYMBOL] == xServer })
		if nPos > 0
			aField	:= aList[nPos,__STRUCT]
			cDesigner:= aList[nPos,__LLDESC]
			xServer	:= aList[nPos,__SELECT]
		endif
	else	// Server oder select bereich, 1. Parameter von :datasetField
		nPos := ascan(aList, {|a| a[__SELECT] == xServer })
		if nPos > 0
			aField	:= aList[nPos,__STRUCT]
			cDesigner:= aList[nPos,__LLDESC]
		endif
	endif
	if nPos == 0
		RETURN self
	endif
RETURN ::_datalink(nMode, xServer, cDesigner, aField)

//=========================================
METHOD dsListLabel:_datalink(nMode, nSelect, cDesigner, aField, nRecno )
	LOCAL cStr, cId
	LOCAL xRet
	LOCAL nLL
	LOCAL i, iCnt
	LOCAL lStruct   := false
#ifndef _XCLASS
	LOCAL nPos
#endif

	Default cDesigner to ""

	if !IsArray( aField)
#ifdef _XCLASS
		aField	:= nSelect:struct()
#else
		aField	:= (nSelect)->(dbstruct())
#endif
	endif

	iCnt	:= len( aField)
	if iCnt = 0
		RETURN self
	endif
	lStruct	:= IsArray(aField[1]) .and. len( aField[1]) >= 4

	if !empty(cDesigner) .and. !cDesigner[-1] $ ".:"
		cDesigner	+= "."
	endif

	for i := 1 to iCnt
		if lStruct
			cId   := aField[i,1]
			if !empty(::_cIgnoreField) .and. like( ::_cIgnoreField ,aField[i,1])
				loop
			endif
#ifdef _XCLASS
			xRet	:= nSelect:fieldget(i)
#else
			xRet	:= (nSelect)->(fieldget(i))
#endif
		else
			if !IsArray(aField[i])
				cId	:= aField[i]
				if IsArray(nSelect)
					xRet	:= nSelect[nRecno]:&cId.
				else
#ifdef _XCLASS
					xRet	:= nSelect:fieldget(aField[i])
#else
					nPos	:= (nSelect)->(fieldpos(aField[i]))
					xRet	:= (nSelect)->(fieldget(nPos))
#endif
				endif

			elseif IsBlock(aField[i,2])
				cId	:= aField[i,1]
				xRet	:= eval(aField[i,2], self, nSelect, nRecno )

			else
				cId	:= aField[i,1]
#ifdef _XCLASS
				xRet	:= nSelect:fieldget(aField[i,2])
#else
				nPos	:= (nSelect)->(fieldpos(aField[i,2]))
				xRet	:= (nSelect)->(fieldget(nPos))
#endif
			endif
		endif

		if xRet == NIL
			loop
		endif

		if valtype(xRet) = "N"
			// var2lchar setzt 2 decimalen [set(_SET_DECIMALS)] und ignoriert die Genauigkeit der Zahl
			nLL   := LL_NUMERIC
			cStr  := ltrim(str(xRet))
			if at(".", cStr) == 0
				nLL   := LL_NUMERIC_INTEGER
			endif

		elseif valtype(xRet) = "D"
			if !empty( xRet)
				cStr	:= dtos(xRet)
				nLL   := LL_DATE_YYYYMMDD
			else
				cStr	:= '1e100'
				nLL   := LL_DATE_MS
			endif

		elseif valtype(xRet) = "L"
			nLL	:= LL_BOOLEAN
			cStr	:= if(xRet, "T","F")

		else
			nLL   := LL_TEXT
			if Set( _SET_CHARSET ) == CHARSET_OEM
				cStr  := alltrim(ConvtoAnsiCP(xRet))
			else
				cStr  := alltrim(xRet)
			endif

			if empty( cStr)
				cStr	:= " "
			elseif left(cStr,5) = "{\rtf"
				nLL   := LL_RTF
			endif
		endif
		if empty( nMode )
			LlDefineFieldExt(::hJob, cDesigner + cId, cStr, nLL, 0 )
		else
			LlDefineVariableExt(::hJob, cDesigner + cId, cStr, nLL, 0 )
		endif
	next
RETURN self

//=========================================
METHOD dsListLabel:_Varlink( nMode, aVar, nRecno )
	LOCAL cStr
	LOCAL xRet
	LOCAL nLL
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

		if valtype(xRet) = "N"
			// evt einheiten umrechnen
			nLL	:= LL_NUMERIC
			cStr  := ltrim(str(xRet))
			if at(".", cStr) == 0
				nLL   := LL_NUMERIC_INTEGER
			endif

		elseif valtype(xRet) = "D"
			if !empty( xRet)
				cStr	:= dtos(xRet)
				nLL	:= LL_DATE_YYYYMMDD
			else
				cStr	:= '1e100'
				nLL	:= LL_DATE_MS
			endif

		elseif valtype(xRet) = "L"
			nLL	:= LL_BOOLEAN
			cStr	:= if(xRet, "Ja", "Nein")

		else
			nLL	:= LL_TEXT
			if Set( _SET_CHARSET ) == CHARSET_OEM
				cStr	:= alltrim(ConvtoAnsiCP(xRet))
			else
				cStr	:= alltrim(xRet)
			endif
			if empty( cStr)
				cStr	:= " "
			elseif left(cStr,5) = "{\rtf"
				nLL	:= LL_RTF
			endif
		endif
		if len(aVar[i]) >= 3 .and. !empty(aVar[i,3])					    // überschreibt default
			nLL	:= aVar[i,3]
		endif
		if empty( nMode )
			LlDefineFieldExt(::hJob,  aVar[i,1] ,cStr   ,nLL, 0 )
		else
			LlDefineVariableExt(::hJob,  aVar[i,1] ,cStr   ,nLL, 0 )
		endif
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
	LOCAL cTmp

	cTmp   := upper(alltrim(cVar))
	if ( nPos := ascan(::_aField, {|x| upper(x[1]) == cTmp})) > 0
		::_aField[nPos, 2]   := xValue
		::_aField[nPos, 3]   := nLLType
	else
		aadd( ::_aField, {alltrim(cVar), xValue, nLLType})
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
	LOCAL cTmp

	cTmp   := upper(alltrim(cVar))
	if ( nPos := ascan(::_aVar, {|x| upper(x[1]) == cTmp})) > 0
		::_aVar[nPos, 2]   := xValue
		::_aVar[nPos, 3]   := nLLType
	else
		aadd( ::_aVar, {alltrim(cVar), xValue, nLLType})
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

#ifdef _XCLASS
	cSymbol    := coalesce( cSymbol,nSelect:Alias)
#else
	nSelect    := coalesce( nSelect, Select())
	cSymbol    := coalesce( cSymbol,"")
#endif
	cDesigner  := coalesce( cDesigner, cSymbol )

//	nPos := ascan(::_aTable, {|a| a[1] == nSelect })
	nPos := ascan(::_aTable, {|a| a[2] == upper(cSymbol )})
	if nPos == 0 .and. !empty(nSelect )
#ifdef _XCLASS
		aadd( ::_aTable, {nSelect, upper(cSymbol), cDesigner ,;
			coalesce(aField, nSelect:struct()), nSelect:alias })
#else
		aadd( ::_aTable, {nSelect, upper(cSymbol), cDesigner ,;
			coalesce(aField, (nSelect)->(dbstruct())), alias(nSelect)})
#endif
	elseif nPos > 0
		if nSelect == NIL
			aremove(::_aTable, nPos )
		else
			::_aTable[nPos,__SELECT]	:= nSelect
			::_aTable[nPos,__SYMBOL]	:= upper(cSymbol)
			::_aTable[nPos,__LLDESC]	:= cDesigner
#ifdef _XCLASS
			::_aTable[nPos,__STRUCT]	:= coalesce(aField, nSelect:struct())
			::_aTable[nPos,__ALIAS ]	:= nSelect:alias
#else
			::_aTable[nPos,__STRUCT]	:= coalesce(aField, (nSelect)->(dbstruct()))
			::_aTable[nPos,__ALIAS ]	:= alias(nSelect)
#endif
		endif
	endif
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

#ifdef _XCLASS
	if nSelect == NIL																			// für abmelden
		// NIL mit xbase ist aktuelle workarea !!!
		cSymbol	:= upper(cSymbol )
		nPos := ascan(::_aList, {|a| a[__SYMBOL] == cSymbol})
		if nPos > 0
			aRemove(::_aList, nPos )
		endif
		RETURN self
	endif
#endif
	if IsArray(nSelect)
		cSymbol    := coalesce( cSymbol,"")
	else

#ifdef _XCLASS
		cSymbol    := coalesce( cSymbol,nSelect:Alias)
#else
		nSelect    := coalesce( nSelect, Select())
		cSymbol    := coalesce( cSymbol,"")
#endif
	endif
	cDesigner  := coalesce( cDesigner, cSymbol )
	nRekursiv  := coalesce( nRekursiv, -99)

//	nPos := ascan(::_aList, {|a| a[1] == nSelect })
	nPos := ascan(::_aList, {|a| a[2] == upper(cSymbol )})
	if nPos == 0 .and. !empty(nSelect )
		if IsArray(nSelect)
			if len(nSelect) > 0 .and. nSelect[1]:IsDerivedfrom( "dataobject")
				aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
				aeval( aField, {|a| a := a[1]},,,.t.)
				aadd( ::_aList, {nSelect, upper(cSymbol), cDesigner,;
					aField, -1, nRekursiv})
			endif
		else
#ifdef _XCLASS
			aadd( ::_aList, {nSelect, upper(cSymbol), cDesigner ,;
				coalesce(aField, nSelect:struct()), nSelect:alias, nRekursiv })
#else
			aadd( ::_aList, {nSelect, upper(cSymbol), cDesigner,;
				coalesce(aField, (nSelect)->(dbstruct())), alias(nSelect), nRekursiv})
#endif
		endif
	elseif nPos > 0
		::_aList[nPos,__SELECT]	:= nSelect
		::_aList[nPos,__SYMBOL]	:= upper(cSymbol)
		::_aList[nPos,__LLDESC]	:= cDesigner
#ifdef _XCLASS
		::_aList[nPos,__STRUCT]	:= coalesce(aField, nSelect:struct())
		::_aList[nPos,__ALIAS ]	:= nSelect:alias
#else
		if IsArray(nSelect)
			if len(nSelect) > 0 .and. nSelect[1]:IsDerivedfrom("dataobject")
				aField	:= nSelect[1]:classdescribe(CLASS_DESCR_MEMBERS)
				aeval( aField, {|a| a := a[1]},,,.t.)
				::_aList[nPos,__STRUCT]	:= aField
			endif
		else
			::_aList[nPos,__STRUCT]	:= coalesce(aField, (nSelect)->(dbstruct()))
			::_aList[nPos,__ALIAS ]	:= alias(nSelect)
		endif
#endif
		::_aList[nPos,__STUFE ]	:= nRekursiv
	endif
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
	cSymbol	:= upper(cSymbol)
	nPos := ascan(::_aList, {|a| a[__SYMBOL] == cSymbol })
	if nPos > 0
		::_aList[nPos,__STRUCT]	:= aStruct
	endif
	nPos := ascan(::_aTable, {|a| a[__SYMBOL] == cSymbol })
	if nPos > 0
		::_aTable[nPos,__STRUCT]	:= aStruct
	endif
RETURN self

/*============================================================================
 $Method:	AddTable(nSelect, cSymbol, lMaster)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nSelect
 $Argument:     cSymbol
 $Argument:     lMaster
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:AddTable(cSymbol, cDescription, lMaster)
	LOCAL i, iCnt
	::_lSubReport   := true

	if IsArray(cSymbol)										  // clone
		iCnt   := len(cSymbol )
		for i := 1 to iCnt
			LlDbAddTable(::hJob, cSymbol[i,1],cSymbol[i,2])
			if cSymbol[i,3]
				LlDbSetMasterTable(::hJob, cSymbol[i,1])
			endif
		next
	else
		if empty(cSymbol)
			cSymbol	:= alias()
		endif
		if empty(cDescription)
			cDescription	:= cSymbol
		endif
		LlDbAddTable(::hJob, cSymbol, cDescription)
		aadd( ::_aAddTable, {cSymbol, cDescription, !empty(lMaster)})

		if !empty(lMaster)
			LlDbSetMasterTable(::hJob, cSymbol)
		endif
		if len( ::_aAddTable) == 1
			LlDbAddTable(::hJob, "LLStaticTable", "")
			aadd( ::_aAddTable, {"LLStaticTable", "", false })
		endif
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
	if IsArray(cChild)										   // clone
		iCnt   := len(cChild )
		for i := 1 to iCnt
			LlDbAddTableRelation( ::hJob, cChild[i,1], cChild[i,2], cChild[i,3], cChild[i,4])
		next
	else
		cChild	:= upper(cChild)                                                     // anpassung an LL
		cParent  := upper( cParent)
		aadd( ::_aAddTableRelation, {cChild, cParent, cRelation, coalesce(cDescription,"")})
		LlDbAddTableRelation( ::hJob, cChild, cParent, cRelation, coalesce(cDescription,""))
	endif
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
		::_aSync   := xSet										// clone
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

		cTmp2   := strtran( cTmp2, "%TEMP%", _GetTempPath())
		cTmp2   := strtran( cTmp2, "%EIGENE_DATEIEN%", GetEnv("USERPROFILE") + "\Documents")
		cTmp2   := strtran( cTmp2, "%DOCUMENTS%", GetEnv("USERPROFILE") + "\Documents")
		cTmp2   := strtran( cTmp2, "%USERPROFILE%", GetEnv("USERPROFILE") )
		cFile   := left(cFile,nPos1-1) + cTmp2 + subs(cFile, nPos1 + nPos2 )
	endif
	cFile   := _fullpath(cFile)
	::cOutFile   := cFile
RETURN self

/*============================================================================
 $Method:	SaveAsPdf(cFile, lQuiet, bPrint )
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
METHOD dsListLabel:SaveAsPdf(cFile, lQuiet, bPrint )
	LOCAL _nPrintOption  := ::_nPrintOption
	LOCAL nBoxType  := ::_nBoxType
	LOCAL cExport   := ::cExportFormat

	if empty( cFile)
		RETURN false
	endif

	::_nBoxType	:= 0
	::_nPrintOption  := LL_PRINT_EXPORT
	::ExportFormat("PDF")
	::ExportFile(cFile)
	if IsLogical(lQuiet )
		::ShowExport(!lQuiet)
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
		lDialog   := true
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
			cAttach := subs( cAttach, 2)							     // 1. tab weg
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

	lRet  := ::SaveAsPdf(cFile, true, bPrint )

	LlXSetParameter(::hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"  ,"Export.SendAsMail", "0" )

RETURN lRet

/*============================================================================
 $Method:	Clear(lAll)
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    lAll
 $Return:	self
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:Clear(lAll)
	LOCAL cTmp, iCnt

	if !empty(lAll)
		LlDefineVariableStart(::hJob)
		LlDefineFieldStart(::hJob)
		LLDbAddTable(::hJob, "", "")
	endif
	::_aField	   := {}
	::_aTable	   := {}
	::_aList	    := {}
	::_aSync	    := {}
	::_aVar	     := {}
	::_lSubReport     := false
	::_nError	   := 0
	::cOutFile	  := ""
	::cOutPut	   := ""
	::cReport	   := ""
	::cShowExport     := "1"
	::_lOptions	 := true
	::_nQuantity	:= 1
	::nSelect	   := NIL

	if !empty(::__aDefaultVar)
		::_aVar	   := aclone(::__aDefaultVar)
	endif

	// interne defaults
	if ascan(::_aVar, {|x| x[1] == "USER"}) = 0
#if XPPVER >= 2000840
		cTmp	:= space(255)
		iCnt	:= 255
		GetUsername( @cTmp, @iCnt)
		cTmp	:= left(cTmp, iCnt)
#else
		cTmp	:= space(255)
		iCnt	:= u2bin(255)
		GetUsernameA( @cTmp, @iCnt)
		cTmp	:= substr( cTmp, 1, bin2u( iCnt ) - 1 )
#endif
		aadd( ::_aVar, {"USER"   ,cTmp,})
	endif

	if ascan(::_aVar, {|x| x[1] == "COMPUTER"}) = 0
#if XPPVER >= 2000840
		cTmp	:= space(255)
		iCnt	:= 255
		GetComputername( @cTmp, @iCnt)
		cTmp	:= left(cTmp, iCnt)
#else
		cTmp	:= space(255)
		iCnt	:= u2bin(255)
		GetComputernameA( @cTmp, @iCnt)
		cTmp	:= substr( cTmp, 1, bin2u( iCnt ) - 1 )
#endif
		aadd( ::_aVar, {"COMPUTER"   ,cTmp,})
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
	nPos   := ascan( ::_aRecht, xSet)
	if !empty(lSet)
		if nPos > 0
			aremove(::_aRecht, nPos)
		endif
	elseif nPos == 0
		aadd( ::_aRecht, xSet )
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
	aeval( ::_aRecht, {|n| LlViewerProhibitAction(::hJob, n )})
RETURN self

/*============================================================================
 $Method:      OptimizeDatalink( nMode, [lOptimize])
 $Author:      Marcus Herz
 $Topic:
 $Description:	Es werden bei der Datenübergabe standardmässig alle Variablen/Felder übergeben
					Der Optimierungsschalter übergibt dann nur noch die benutzten
 $Argument:    nMode			0 = Felder, Default
									$N$1 = Variablen
 $Argument:    lOptimize	Default TRUE,
 $Return:      self
 $Hint:		Nur in Verbindung mit XClass++ und Tabellenobjekten möglich
 $See Also:
 $Example:
==============================================================================*/
METHOD dsListLabel:OptimizeDatalink( nMode, lOptimize)
	if IsNumber(nMode) .and. (nMode = 0 .or. nMode = 1)
		::_aOptimize[++nMode]	:= !empty(lOptimize)
	endif
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
		if ::_nStatus < 2
			::_nFirstpage   := nPage
		else
			LlPrintSetOption(::hJob, LL_PRNOPT_PAGE , nPage )
		endif
	endif
RETURN self

//=========================================
METHOD dsListLabel:Clone(nProjecthWnd, cReport )
	LOCAL oRet
	LOCAL cClass	:= ::Classname()

	oRet := &(cClass)()

	oRet	:= oRet:New( nProjecthWnd, ::_lRtf )
	oRet:report			:= cReport
	oRet:ProjectType	:= ::_nProject
	oRet:Configblock	:= ::_bConfig
	oRet:PrepareBlock	:= ::_bPrepare
	oRet:Skipblock		:= ::_bSkipBlock
	oRet:Topblock		:= ::_bTopBlock
	oRet:TableChange	:= ::_bTableChange
	oRet:CopyBlock		:= ::_bCopyblock
	oRet:Quantity		:= ::Quantity
#ifdef _XCLASS
	oRet:CopyDbContainer(self, false , false )
#endif

	oRet:AddSync(aclone(::_aSync))
	oRet:BoxType(::_nBoxType)
	oRet:Connect(::nSelect)
	oRet:CloneDataSetField(::_aList)
	oRet:CloneDataSetVariable(::_aTable)
	oRet:CloneDefineField(::_aField)
	oRet:CloneDefineVariable(::_aVar)
	oRet:ExportFormat(::cExportFormat)
	oRet:IgnoreFieldmask(::_cIgnoreField)
	oRet:LastRec(::_nLastRec)
	oRet:PrintAtEof(::_lPrintAtEof)
	oRet:SetFirstPage(::_nFirstpage)
	oRet:SetPreview(.t.)
	oRet:SetTitle(::cTitle)

	if ::_lSubReport
		oRet:AddTable(::_aAddTable )
		oRet:AddTableRelation(::_aAddTableRelation )
	endif
RETURN oRet

//=========================================
METHOD dsListLabel:DbReleaseAll()
	LOCAL i, iCnt
	LOCAL aSelect   := {}

	if ::_lIsReleased
		RETURN self
	endif

	::_lIsReleased		:= true

	iCnt   := len( ::_aList)
	for i := 1 to iCnt
		if IsNumber(::_aList[i,__SELECT])
			dbRelease(::_aList[i,__SELECT])
#ifdef _XCLASS
		elseif IsObject(::_aList[i,__SELECT]) .and. ::_aList[i,__SELECT]:dbType = SRV_DBF
			dbRelease(::_aList[i,__SELECT]:dbselect())
#endif
		endif
		aadd( aSelect, ::_aList[i,__SELECT])
	next

	iCnt   := len( ::_aTable)
	for i := 1 to iCnt
		if ascan(aSelect, ::_aTable[i,__SELECT]) = 0
			if IsNumber(::_aTable[i,__SELECT])
				dbRelease(::_aTable[i,__SELECT])
#ifdef _XCLASS
			elseif IsObject(::_aTable[i,__SELECT]) .and. ::_aTable[i,__SELECT]:dbType = SRV_DBF
				dbRelease(::_aTable[i,__SELECT]:dbselect())
#endif
			endif
		endif
	next

RETURN self

//=========================================
METHOD dsListLabel:DbRequestAll()
	LOCAL i, iCnt
	LOCAL aSelect   := {}
	::_lIsReleased		:= false

	iCnt   := len( ::_aList)
	for i := 1 to iCnt
		if IsNumber(::_aList[i,__SELECT])
			dbselectarea(::_aList[i,__SELECT])
			DbRequest(::_aList[i,__ALIAS])
#ifdef _XCLASS
		elseif IsObject(::_aList[i,__SELECT]) .and. ::_aList[i,__SELECT]:dbType = SRV_DBF
			::_aList[i,__SELECT]:select()
			DbRequest(::_aList[i,__SELECT]:alias)
#endif
		endif
		aadd( aSelect, ::_aList[i,__SELECT])
	next

	iCnt   := len( ::_aTable)
	for i := 1 to iCnt
		if ascan(aSelect, ::_aTable[i,__SELECT]) = 0
			if IsNumber(::_aTable[i,__SELECT])
				dbselectarea(::_aTable[i,__SELECT])
				DbRequest(::_aTable[i,__ALIAS])
#ifdef _XCLASS
			elseif IsObject(::_aTable[i,__SELECT]) .and. ::_aTable[i,__SELECT]:dbType = SRV_DBF
				::_aTable[i,__SELECT]:select()
				DbRequest(::_aTable[i,__SELECT]:alias)
#endif
			endif
		endif
	next
RETURN self

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

	::_cErrorMessage := replicate(chr(0),255)
	LlGetErrortext(nError, @::_cErrorMessage, 255)
	::_cErrorMessage   	:= _trim0( ::_cErrorMessage )

	if Set( _SET_CHARSET ) == CHARSET_OEM
		::_cErrorMessage  := alltrim(ConvtoOemCP(::_cErrorMessage))
	endif

	if IsBlock(::__onError)
		oError   := Error():New()
		oError:args				:= coalesce(cArgs, "" )
		oError:canDefault		:= false
		oError:canRetry		:= true
		oError:canSubstitute	:= false
		oError:description	:= ::_cErrorMessage
		oError:filename		:= "CMLL"+ scVersion + ".DLL"
		oError:genCode			:= nError
		oError:osCode			:= nError
		oError:operation		:= cOperation
		oError:subSystem		:= "dsListLabel"
		oError:thread			:= threadid()
		oError:cargo	   	:= self
		eval(::__onError, oError)
	endif
RETURN self

#ifdef _DESIGNERPREVIEW
/*============================================================================
 $Function:    DesignerCallback(nNotification, nStructurePtr, xDummy, oListLabel)
 $Group:
 $Author:	Marcus Herz
 $Topic:
 $Description:
 $Argument:    nNotification
 $Argument:     nStructurePtr
 $Argument:     oListLabel
 $Return:
 $See Also:
 $Example:
==============================================================================*/
FUNC DesignerCallback(nNotification, nStructurePtr, xDummy, oListLabel)
	LOCAL lThreadRuns := false
	LOCAL oCbLocal, oThread
	LOCAL nProjecthWnd, hEvent, nPages
	LOCAL cProjectName, cProjectOrgName, cExpFormat
	UNUSED (xDummy)

	IF nNotification == LL_NTFY_DESIGNERPRINTJOB
		// get the structure where nStructurePtr points to - .F. means: not a copy
		oCbLocal   := OT4XB_LlCallback():New():_link_(nStructurePtr,.F.)
		oCbLocal:_lock_()

		DO CASE
		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_PREVIEW_START .or. ;
				oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_START
			// Init/retrieve values for the print thread
			nProjecthWnd	:= oCbLocal:_hWnd
			hEvent			:= oCbLocal:_hEvent
    		nPages			:= oCbLocal:_nPages // number of pages to be printed
			cProjectName	:= PeekStr(oCbLocal:_pszProjectName,,-1)
			cProjectOrgName:= PeekStr(oCbLocal:_pszOriginalProjectFileName,,-1)
			if oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_START
				cExpFormat	:= PeekStr(oCbLocal:_pszExportFormat,,-1)
			endif
			oListLabel:dbReleaseAll()
			// Start print thread
			oThread   := Thread():new()
			oThread   :start( {|| _ThreadPrint(oThread, oListLabel , hEvent, nProjecthWnd, cProjectName, cProjectOrgName, cExpFormat, nPages)})
			oThread   :atEnd := {|| oThread:cargo[2]:dbReleaseAll()}
			lThreadRuns := true


		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_START
			// Init/retrieve values for the export thread
			nProjecthWnd	:= oCbLocal:_hWnd						   // window handle
			hEvent			:= oCbLocal:_hEvent						 // event no to be set by the printing routine
			cProjectName	:= PeekStr(oCbLocal:_pszProjectName,,-1)		    // filename from structure pointer
			cExpFormat		:= PeekStr(oCbLocal:_pszExportFormat,,-1)
			cProjectOrgName:= PeekStr(oCbLocal:_pszOriginalProjectFileName,,-1)

			oListLabel:dbReleaseAll()
			oThread   := Thread():new()
			oThread   :start( {|| _ThreadPrint(oThread, oListLabel , hEvent, nProjecthWnd, cProjectName, cProjectOrgName, cExpFormat)})
			oThread   :atEnd := {||  ;
				oThread:cargo[2]:dbReleaseAll()}
			lThreadRuns := true

		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT .or. ;
				oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT
			_PrintRuns(false, true )
			lThreadRuns := false

		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE .or. ;
				oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE
			cProjectName := PeekStr(oCbLocal:_pszProjectName,,-1)
			lThreadRuns := false
			FErase(cProjectName)
			oListLabel:dbRequestAll()

		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE .or. ;
				oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_QUEST_JOBSTATE
			lThreadRuns := _PrintRuns(,.t.)

		ENDCASE

		oCbLocal:_hEvent := IF(lThreadRuns,LL_DESIGNERPRINTTHREAD_STATE_RUNNING,LL_DESIGNERPRINTTHREAD_STATE_STOPPED) // set the event for L&L
		oCbLocal:_unlock_()
		oCbLocal:_unlink_(.F.)

	ELSEIF nNotification == LL_NTFY_VIEWERDRILLDOWN
		// get the structure where nStructurePtr points to - .F. means: not a copy
		oCbLocal   := OT4XB_LlCallback():New():_link_(nStructurePtr,.F.)
		oCbLocal:_lock_()

		DO CASE
		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_PREVIEW_START .or. ;
				oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_START
			// Init/retrieve values for the print thread
			nProjecthWnd	:= oCbLocal:_hWnd
			hEvent			:= oCbLocal:_hEvent
    		nPages			:= oCbLocal:_nPages // number of pages to be printed
			cProjectName	:= PeekStr(oCbLocal:_pszProjectName,,-1)
			cProjectOrgName:= PeekStr(oCbLocal:_pszOriginalProjectFileName,,-1)
			if oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_START
				cExpFormat	:= PeekStr(oCbLocal:_pszExportFormat,,-1)
			endif
			oListLabel:dbReleaseAll()
			// Start print thread
			oThread   := Thread():new()
			oThread   :start( {|| _ThreadPrint(oThread, oListLabel , hEvent, nProjecthWnd, cProjectName, cProjectOrgName, cExpFormat, nPages)})
			oThread   :atEnd := {|| oThread:cargo[2]:dbReleaseAll()}
			lThreadRuns := true


		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_START
			// Init/retrieve values for the export thread
			nProjecthWnd	:= oCbLocal:_hWnd						   // window handle
			hEvent			:= oCbLocal:_hEvent						 // event no to be set by the printing routine
			cProjectName	:= PeekStr(oCbLocal:_pszProjectName,,-1)		    // filename from structure pointer
			cExpFormat		:= PeekStr(oCbLocal:_pszExportFormat,,-1)
			cProjectOrgName:= PeekStr(oCbLocal:_pszOriginalProjectFileName,,-1)

			oListLabel:dbReleaseAll()
			oThread   := Thread():new()
			oThread   :start( {|| _ThreadPrint(oThread, oListLabel , hEvent, nProjecthWnd, cProjectName, cProjectOrgName, cExpFormat)})
			oThread   :atEnd := {||  ;
				oThread:cargo[2]:dbReleaseAll()}
			lThreadRuns := true

		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT .or. ;
				oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT
			_PrintRuns(false, true )
			lThreadRuns := false

		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE .or. ;
				oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE
			cProjectName := PeekStr(oCbLocal:_pszProjectName,,-1)
			lThreadRuns := false
			FErase(cProjectName)
			oListLabel:dbRequestAll()

		CASE oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE .or. ;
				oCbLocal:_nFunction == LL_DESIGNERPRINTCALLBACK_EXPORT_QUEST_JOBSTATE
			lThreadRuns := _PrintRuns(,.t.)

		ENDCASE

		oCbLocal:_hEvent := IF(lThreadRuns,LL_DESIGNERPRINTTHREAD_STATE_RUNNING,LL_DESIGNERPRINTTHREAD_STATE_STOPPED) // set the event for L&L
		oCbLocal:_unlock_()
		oCbLocal:_unlink_(.F.)


	ENDIF
RETURN IF(lThreadRuns,LL_DESIGNERPRINTTHREAD_STATE_RUNNING,LL_DESIGNERPRINTTHREAD_STATE_STOPPED)

//=========================================
// Create a structure using OT4XB
// this is precompiled to a function call, so it must stand outside the rest of the code
//=========================================
BEGIN STRUCTURE OT4XB_LlCallback
	MEMBER UINT	   _nSize
	MEMBER POINTER	_nUserParam
	MEMBER POINTER32    _pszProjectName						    //
	MEMBER POINTER32    _pszOriginalProjectFileName
	MEMBER UINT	   _nPages
	MEMBER UINT	   _nFunction
	MEMBER HWND	   _hWnd
	MEMBER HANDLE	 _hEvent
	MEMBER POINTER32    _pszExportFormat
	MEMBER BOOL	   _bWithoutDialog
END STRUCTURE

//=========================================
STATIC FUNC _ThreadPrint(oThread,oDesigner, hEvent, nProjecthWnd, cProjectName, cProjectOrgName, cExpFormat, nPages )
	LOCAL oListLabel

	_PrintRuns(true, false )
	SetEvent(hEvent)

	oListLabel	:= oDesigner:clone(nProjecthWnd, cProjectName)
	oThread:cargo   := {oDesigner, oListLabel }
	oListLabel	:Pages	:= nPages
	oListLabel	:dbRequestAll()
	LlSetOptionString(oListLabel:hJob, LL_OPTIONSTR_ORIGINALPROJECTFILENAME, cProjectOrgName)
	oListLabel	:ExportFormat(cExpFormat)
	oListLabel	:print()
	oListLabel	:destroy()
	_PrintRuns(false, false )
	SetEvent(hEvent)
RETURN NIL

//=========================================
STATIC FUNCTION _PrintRuns(lSet, lCheck)
	STATIC aPrintRuns := {}
	LOCAL nFindThread := AScan(aPrintRuns,{|a|a[1] == ThreadID() })

	if nFindThread = 0
		if lCheck
			RETURN true
		endif
		aAdd(aPrintRuns,{ThreadID(),.f.})
		nFindThread := Len(aPrintRuns)
	endif
	if lSet != NIL
		aPrintRuns[nFindThread,2] := lSet
	endif
RETURN aPrintRuns[nFindThread,2]
#endif

//=========================================
STATIC FUNC _FullPath(cPath, cCurDir)
	LOCAL nPos

	if empty(cCurdir)
		cCurdir   := strtran(AppName(.T.), AppName(), "")
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
STATIC FUNC _aStrExtract(cString, cDelim)
	LOCAL aRet:={}
	LOCAL nLen, nX:=1, nX2, nOff := 0, nPos:=0, nStr
	LOCAL cRet

	if ! IsCharacter(cString)
		RETURN aRet
	endif

	nLen := len( cString )
	nStr := len( cDelim ) -1
	cRet := space(nLen)

	do while True
		nX2   := nX + nOff
		nOff   := 0
		nPos := at(cDelim, cString, nX)
		if nPos > 0
			cRet := substr(cString, nX2, nPos-nX2)
			cRet := alltrim( cRet)
			aadd(aRet, cRet)
			nX := ++nPos + nStr

		elseif nX <= nLen - nStr
			cRet := substr(cString, nX2)
			cRet := alltrim(cRet)
			if nOff > 0
				cRet   := subs(cRet, 1, len(trim(cRet)) - 1 )
			endif
			aadd(aRet, cRet)
			exit

		elseif nX > nLen										  // z.B entry=
			aadd(aRet, "")
			exit

		else
			exit
		endif
	enddo
RETURN aRet

//=========================================
STATIC FUNC _GetTempPath()
	LOCAL sBuffer
	LOCAL nBuffSize	:= 261
#if XPPVER >= 2000840
	sBuffer 	:= space(261)
	nBuffSize	:= GetTempPath(nBuffSize, @sBuffer)
	sBuffer   := substr( sBuffer, 1, nBuffsize )
#else
	sBuffer 	:= Replicate(chr(0),261)
	GetTempPathA(nBuffsize, @sBuffer)
	sBuffer   := substr( sBuffer, 1, nBuffsize - 1 )
#endif
return sBuffer

//=========================================
STATIC FUNC _GetExportName(cPath, cExt)		;RETURN cPath + "LLEXPORT"+dtos(date())+strtran(time(),":")+"."+cExt

//=========================================
STATIC FUNC _SetExtension(cFile, cExt)
	LOCAL nLen   := len( "."+ cExt )
	if right(cFile, nLen ) != "."+ cExt
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
STATIC FUNC _EvalLLFunc(cFuncName)	;RETURN eval(&("{|| LL"+ scVersion + cFuncName +"()}"))

//=========================================
STATIC CLASS _LLPreviewCallBack FROM DllCallBack
	EXPORTED:
		VAR oPrint
		VAR bBlock

		INLINE METHOD Init(oPrint, bBlock)
			::oPrint	:= oPrint
			::bBlock	:= bBlock
			RETURN ::DllCallBack:Init(,,DLL_TYPE_UINT32,DLL_TYPE_UINT32, DLL_TYPE_UINT32 ):create()

		INLINE METHOD Execute(x1,x2,x3)
			eval(::bBlock, x1,x2,x3)
			RETURN 0

ENDCLASS

#ifdef _DESIGNERPREVIEW
//=========================================
STATIC CLASS _LLDesignerCallBack FROM DllCallBack
	EXPORTED:
		VAR oPrint
		VAR bBlock

		INLINE METHOD Init(oPrint)
			::oPrint	:= oPrint
			RETURN ::DllCallBack:Init(,,DLL_TYPE_UINT32,DLL_TYPE_UINT32, DLL_TYPE_UINT32 ):create()

		INLINE METHOD Execute(x1,x2,x3)
			DesignerCallback(x1,x2,x3,::oPrint)
			RETURN 0

ENDCLASS
#endif

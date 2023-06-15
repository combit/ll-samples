// Alaska Software Xbase++ module constants and function definitions for cmbtLL<nn>.DLL
//  (c) combit GmbH
//  [build of 2020-06-27 01:06:45]

// MODULE file to be included once in a project

// version is defined in dsListLabel.ch
// and project.xpj COMPILE_FLAGS

#include "dsListLabel.ch"
#include "dll.ch"

#if XPPVER < 2001392
#include "xpprt2.ch"
#endif

STATIC hDll := 0
STATIC nDLLLoadCount := 0

//
// Two commands for LL_EXTERN and CALLBACK_EXTERN calls. The difference is
// the return value only. A call will silently ignore the fact that
// the library failed getting loaded. For each function/procedure
// a template is created once and then reused for the next call.
// The command executes the call into the library with DLL_STDCALL
// and an ordinal. In case the functions are properly exported from
// the library then we call cFunctionName (use <FUNC>).
//
#command LL_EXTERN [<xCallConv:CDECL, STDCALL>] [VOID];
      [<xRetType:SHORT, USHORT, INTEGER, UINTEGER, LONG, BOOL, BOOL8, INTEGER64, UINTEGER64, SINGLE, DOUBLE, STRING, WSTRING, IDISPATCH>];
  		<FuncName>( [<paramVal1> AS <paramType1> [,<paramValN> AS <paramTypeN>]] );
  		[ORDINAL <nOrdinal>];
  		IN <LibraryName> [NAME <AliasName>] => ;
FUNCTION <FuncName>( <paramVal1>[,<paramValN>] )                   ;;
	STATIC template := NIL                                        ;;
	LOCAL xRet                                                    ;;
	IF hDll == 0                                                     ;;
		RETURN(NIL)                                                    ;;
	ENDIF                                                            ;;
	IF template == NIL                                            ;;
		template:=DllPrepareCall(<(LibraryName)>,Coalesce(__Sys( <xCallConv> ), DLL_STDCALL)+Coalesce(__Sys(<xRetType>),DLL_TYPE_INT32)+DLL_CALLMODE_COPY,Coalesce(<(AliasName)>,<nOrdinal>,<(FuncName)>),__Sys(<paramType1>)[,__Sys(<paramTypeN>)]) ;;
	ENDIF                                                        ;;
	xRet := DllExecuteCall( template,<paramVal1>[,<paramValN>] )  ;;
RETURN xRet


//
// parameters are passed by reference rather then a copy, callbacks
//
#command CALLBACK_EXTERN [<xCallConv:CDECL, STDCALL>] ;
      [<xRetType:SHORT, USHORT, INTEGER, UINTEGER, LONG, BOOL, BOOL8, INTEGER64, UINTEGER64, SINGLE, DOUBLE, STRING, WSTRING, IDISPATCH>];
  		<FuncName>( [<paramVal1> AS <paramType1> [,<paramValN> AS <paramTypeN>]] );
  		[ORDINAL <nOrdinal>];
  		IN <LibraryName> [NAME <AliasName>] => ;
FUNCTION <FuncName>( <paramVal1>[,<paramValN>] )                   ;;
	STATIC template := NIL                                        ;;
	LOCAL xRet                                                    ;;
	IF hDll == 0                                                     ;;
		RETURN(NIL)                                                    ;;
	ENDIF                                                            ;;
	IF template == NIL                                            ;;
		template:=DllPrepareCall(<(LibraryName)>,Coalesce(__Sys( <xCallConv> ), DLL_STDCALL)+Coalesce(__Sys(<xRetType>),DLL_TYPE_INT32),Coalesce(<(AliasName)>,<nOrdinal>,<(FuncName)>),__Sys(<paramType1>)[,__Sys(<paramTypeN>)]) ;;
	ENDIF                                                        ;;
	xRet := DllExecuteCall( template,<paramVal1>[,<paramValN>] )  ;;
RETURN xRet


//
// returns template to be used by DllExecuteCall
//
#command TEMPLATE_EXTERN [<xCallConv:CDECL, STDCALL>] [VOID];
      [<xRetType:SHORT, USHORT, INTEGER, UINTEGER, LONG, BOOL, BOOL8, INTEGER64, UINTEGER64, SINGLE, DOUBLE, STRING, WSTRING, IDISPATCH>];
  		<FuncName>( [<paramVal1> AS <paramType1> [,<paramValN> AS <paramTypeN>]] );
  		[ORDINAL <nOrdinal>];
  		IN <LibraryName> [NAME <AliasName>] => ;
FUNCTION <FuncName>( <paramVal1>[,<paramValN>] )                   ;;
	IF hDll == 0                                                     ;;
		RETURN(NIL)                                                    ;;
	ENDIF                                                            ;;
RETURN DllPrepareCall(<(LibraryName)>,Coalesce(__Sys( <xCallConv> ), DLL_STDCALL)+Coalesce(__Sys(<xRetType>),DLL_TYPE_INT32)+DLL_CALLMODE_COPY,Coalesce(<(AliasName)>,<nOrdinal>,<(FuncName)>),__Sys(<paramType1>)[,__Sys(<paramTypeN>)])



//
// Load the LL library dynamically.
// Raise an error on failure -> Can not find/load LL library.
// Call this routine once at application startup or ...
// call LLModuleInit() before and LLModuleExit() after the print job
// to load/unload the DLL with each print job.
// 05.05.2021 8:48AM removed version number in func name
FUNCTION LLModuleInit()
  IF hDll == 0
    hDll = DllLoad(CMBT_DLL)
    IF hDll == 0
      // Handle the error case in your app
      // Runtime error with semantic: Can not find DLL
    ELSE
      nDLLLoadCount++
    ENDIF
  ENDIF
RETURN (hDll <> 0)

//
// Unload the library.
// 05.05.2021 8:48AM removed version number in func name
//
PROCEDURE LLModuleExit()
  nDLLLoadCount--
  IF nDLLLoadCount <= 0 .AND. ;
      .NOT. hDll==0
    DllUnload( hDll )
    hDll	:= 0
    nDLLLoadCount := 0
  ENDIF
RETURN

//
// These lines are preprocessed into Xbase++ functions,
// to be called as: LlJobOpen(nLanguage)

LL_EXTERN INTEGER LlJobOpen(;                                                                     //
		nLanguage AS INTEGER ) ORDINAL 10 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlJobOpenLCID(;                                                                 //
		nLCID AS INTEGER ) ORDINAL 12 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN VOID LlJobClose(;                                                                       //
		hLlJob AS INTEGER ) ORDINAL 11 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN VOID LlSetDebug(;                                                                       //
		nOnOff AS INTEGER ) ORDINAL 13 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlGetVersion(;                                                                  //
		nCmd AS INTEGER ) ORDINAL 14 IN CMBT_DLL                                                    //
																																  //
LL_EXTERN INTEGER LlGetNotificationMessage(;                                                      //
		hLlJob AS INTEGER ) ORDINAL 15 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlSetNotificationMessage(;                                                      //
		hLlJob AS INTEGER ,;                                                                        //
		nMessage AS UINTEGER ) ORDINAL 16 IN CMBT_DLL                                               //
																																  //
//CALLBACK_EXTERN INTEGER LlSetNotificationCallback(;                                             //
LL_EXTERN INTEGER LlSetNotificationCallback(;                                               		  //
		hJob AS INTEGER,;                                                                           //
		lpfnEnum AS ACALLBACK ) ORDINAL 17 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlDefineField(;                                                                 //
		hJob AS INTEGER,;                                                                           // HLLJOB               hLlJob,
		pszVarName  AS STRING ,;                                                                    // LPCSTR               pszVarName,
		lpbufContents  AS STRING ) ORDINAL 18 IN CMBT_DLL                                           // LPCSTR               lpbufContents
																																  //
LL_EXTERN INTEGER LlDefineFieldExt(;                                                              //
		hJob AS INTEGER,;                                                                           // HLLJOB               hLlJob,
		pszVarName  AS STRING ,;                                                                    // LPCSTR               pszVarName,
		lpbufContents  AS STRING ,;                                                                 // LPCSTR               lpbufContents,
		lPara AS INTEGER,;                                                                          // INT                  lPara,
		lpPtr AS STRING ) ORDINAL 19 IN CMBT_DLL                                                    // LPVOID               lpPtr
																																  //
#pragma info(NOUSE)
TEMPLATE_EXTERN INTEGER templateDefineFieldExt(;                                                  //
		hJob AS INTEGER,;                                                                           //
		pszVarName  AS STRING ,;                                                                    //
		lpbufContents  AS STRING ,;                                                                 //
		lPara AS INTEGER,;                                                                          //
		lpPtr AS STRING ) ORDINAL 19 IN CMBT_DLL                                                    //
#pragma info(USE)
																																  //
LL_EXTERN INTEGER LlDefineFieldExtHandle(;                                                        //
		hJob AS INTEGER,;                                                                           //
		pszVarName  AS STRING ,;                                                                    //
		hContents  AS INTEGER ,;                                                                    //
		lPara AS INTEGER,;                                                                          //
		lpPtr AS STRING ) ORDINAL 20 IN CMBT_DLL                                                    //
																																  //
LL_EXTERN VOID LlDefineFieldStart(;                                                               //
		hJob AS INTEGER) ORDINAL 21 IN CMBT_DLL                                                     //
																																  //
LL_EXTERN INTEGER LlDefineVariable(;                                                              //
		hJob AS INTEGER,;                                                                           // HLLJOB               hLlJob,
		pszVarName AS STRING ,;                                                                     // LPCSTR               pszVarName,
		lpbufContents AS STRING ) ORDINAL 22 IN CMBT_DLL                                            // LPCSTR               lpbufContents
																																  //
LL_EXTERN INTEGER LlDefineVariableExt(;                                                           //
		hJob AS INTEGER,;                                                                           // HLLJOB               hLlJob,
		pszVarName AS STRING ,;                                                                     // LPCSTR               pszVarName,
		lpbufContents AS STRING ,;                                                                  // LPCSTR               lpbufContents,
		lPara AS INTEGER,;                                                                          // INT                  lPara,
		lpPtr AS STRING ) ORDINAL 23 IN CMBT_DLL                                                    // LPVOID               lpPtr
																																  //
#pragma info(NOUSE)
TEMPLATE_EXTERN INTEGER templateDefineVariableExt(;                                               //
		hJob AS INTEGER,;                                                                           //
		pszVarName AS STRING ,;                                                                     //
		lpbufContents AS STRING ,;                                                                  //
		lPara AS INTEGER,;                                                                          //
		lpPtr AS STRING ) ORDINAL 23 IN CMBT_DLL                                                    //
#pragma info(USE)
																																  //
LL_EXTERN INTEGER LlDefineVariableHandle(;                                                        //
		hJob AS INTEGER,;                                                                           //
		pszVarName  AS STRING ,;                                                                    //
		hContents  AS INTEGER ,;                                                                    //
		lPara AS INTEGER,;                                                                          //
		lpPtr AS STRING ) ORDINAL 24 IN CMBT_DLL                                                    //
																																  //
LL_EXTERN INTEGER LlDefineVariableName(;                                                          //
		hJob AS INTEGER,;                                                                           //
		pszVarName  AS STRING ) ORDINAL 25 IN CMBT_DLL                                              //
																																  //
LL_EXTERN VOID LlDefineVariableStart(;                                                            //
		hJob AS INTEGER ) ORDINAL 26 IN CMBT_DLL                                                    //
																																  //
LL_EXTERN INTEGER LlDefineSumVariable(;                                                           //
		hJob AS INTEGER,;                                                                           //
		pszVarName AS STRING ,;                                                                     //
		lpbufContents AS STRING ) ORDINAL 27 IN CMBT_DLL                                            //
																																  //
LL_EXTERN INTEGER LlDefineLayout(;                                                                //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		hWnd AS UINTEGER,;                                                                          // HWND                 hWnd,
		pszTitle  AS STRING ,;                                                                      // LPCSTR               pszTitle,
		nObjType AS UINTEGER,;                                                                      // UINT                 nObjType,
		pszObjName  AS STRING ) ORDINAL 28 IN CMBT_DLL                                              // LPCSTR               pszObjName
// no documentation                                                                               //
//LL_EXTERN INTEGER LlDlgEditLine(;                                                               //
//		hLlJob AS INTEGER,;                                                                         //
//		hWnd AS UINTEGER,;                                                                          //
//		nBufSize AS UINTEGER) ORDINAL 29 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlDlgEditLineEx(;                                                               //
		hLlJob AS INTEGER,;                                                                         //
		hWnd AS UINTEGER,;                                                                          //
		@pszBuffer  AS STRING ,;                                                                    //
		nBufSize AS UINTEGER,;                                                                      //
		nParaTypes AS UINTEGER,;                                                                    //
		pszTitle  AS STRING ,;                                                                      //
		bTable AS INTEGER,;                                                                         //
		pvReserved AS STRING ) ORDINAL 30 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlPreviewSetTempPath(;                                                          //
		hLlJob AS INTEGER,;                                                                         //
		pszPath AS STRING ) ORDINAL 31 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPreviewDeleteFiles(;                                                          //
		hLlJob AS INTEGER,;                                                                         //
		pszObjName  AS STRING ,;                                                                    //
		pszPath AS STRING ) ORDINAL 32 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPreviewDisplay(;                                                              //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		pszObjName  AS STRING ,;                                                                    // LPCSTR               pszObjName,
		pszPath AS STRING,;                                                                         // LPCSTR               pszPath,
		Wnd AS UINTEGER ) ORDINAL 33 IN CMBT_DLL                                                    // HWND                 Wnd
																																  //
LL_EXTERN INTEGER LlPreviewDisplayEx(;                                                            //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		pszObjName  AS STRING ,;                                                                    // LPCSTR               pszObjName,
		pszPath AS STRING,;                                                                         // LPCSTR               pszPath,
		Wnd AS UINTEGER,;                                                                           // HWND                 Wnd,
		nOptions AS UINTEGER,;                                                                      // UINT                 nOptions,
		pOptions AS STRING ) ORDINAL 34 IN CMBT_DLL                                                 // LPVOID               pOptions
																																  //
LL_EXTERN INTEGER LlPrint(;                                                                       //
		hLlJob AS INTEGER ) ORDINAL 35 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintAbort(;                                                                  //
		hLlJob AS INTEGER ) ORDINAL 36 IN CMBT_DLL                                                  //
																																  //
// no documentation                                                                               //
//LL_EXTERN INTEGER LlPrintCheckLineFit(;                                                         //
//		hLlJob AS INTEGER ) ORDINAL 37 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintEnd(;                                                                    //
		hLlJob AS INTEGER ,;                                                                        //
		nPages AS INTEGER ) ORDINAL 38 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintFields(;                                                                 //
		hLlJob AS INTEGER ) ORDINAL 39 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintFieldsEnd(;                                                              //
		hLlJob AS INTEGER ) ORDINAL 40 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintGetCurrentPage(;                                                         //
		hLlJob AS INTEGER ) ORDINAL 41 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintGetItemsPerPage(;                                                        //
		hLlJob AS INTEGER ) ORDINAL 42 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintGetItemsPerTable(;                                                       //
		hLlJob AS INTEGER ) ORDINAL 43 IN CMBT_DLL                                                  //
																																  //
// no documentation                                                                               //
//LL_EXTERN INTEGER LlPrintGetRemainingItemsPerTable(;                                            //
//		hLlJob AS INTEGER,;                                                                         //
//		pszField AS STRING ) ORDINAL 44 IN CMBT_DLL                                                 //
																																  //
// no documentation                                                                               //
//LL_EXTERN INTEGER LlPrintGetRemItemsPerTable(;                                                  //
//		hLlJob AS INTEGER,;                                                                         //
//		pszField AS STRING ) ORDINAL 45 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlPrintGetOption(;                                                              //
		hLlJob AS INTEGER,;
		nIndex AS INTEGER  ) ORDINAL 46 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlPrintGetPrinterInfo(;                                                         // CMBT_LL_WINAPI INT      DLLPROC  LlPrintGetPrinterInfoA
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		@pszPrn  AS STRING ,;                                                                       // LPSTR                pszPrn,
		nPrnLen AS UINTEGER,;                                                                       // UINT                 nPrnLen,
		@pszPort  AS STRING ,;                                                                      // LPSTR                pszPort,
		nPortLen AS UINTEGER ) ORDINAL 47 IN CMBT_DLL                                               // UINT                 nPortLen
																																  //
LL_EXTERN INTEGER LlPrintOptionsDialog(;                                                          //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		hWnd AS UINTEGER,;                                                                          // HWND                 hWnd,
		pszText  AS STRING ) ORDINAL 48 IN CMBT_DLL                                                 // LPCSTR               pszText
																																  //
LL_EXTERN INTEGER LlPrintSelectOffsetEx(;                                                         //
		hLlJob AS INTEGER,;                                                                         //
		hWnd AS UINTEGER ) ORDINAL 49 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN INTEGER LlPrintSetBoxText(;                                                             //
		hLlJob AS INTEGER,;                                                                         //
		pszText  AS STRING,;                                                                        //
		nPercentage AS INTEGER ) ORDINAL 50 IN CMBT_DLL                                             //
																																  //
LL_EXTERN INTEGER LlPrintSetOption(;                                                              //
		hLlJob AS INTEGER,;                                                                         //
		nIndex  AS INTEGER,;                                                                        //
		nValue AS INTEGER ) ORDINAL 51 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintUpdateBox(;                                                              //
		hLlJob AS INTEGER ) ORDINAL 52 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintStart(;                                                                  // CMBT_LL_WINAPI INT      DLLPROC  LlPrintStartA
		hLlJob AS INTEGER,;                                                                         // 	HLLJOB               hLlJob,
		nObjType  AS UINTEGER,;                                                                     // 	UINT                 nObjType,
		pszObjName AS STRING,;                                                                      // 	LPCSTR               pszObjName,
		nPrintOptions  AS INTEGER,;                                                                 // 	INT                  nPrintOptions,
		nReserved AS INTEGER ) ORDINAL 53 IN CMBT_DLL                                               // 	INT                  nReserved
																																  //
LL_EXTERN INTEGER LlPrintWithBoxStart(;                                                           // CMBT_LL_WINAPI INT      DLLPROC  LlPrintWithBoxStartA
		hLlJob AS INTEGER,;                                                                         // 	HLLJOB               hLlJob,
		nObjType  AS UINTEGER,;                                                                     // 	UINT                 nObjType,
		pszObjName AS STRING,;                                                                      // 	LPCSTR               pszObjName,
		nPrintOptions  AS INTEGER,;                                                                 // 	INT                  nPrintOptions,
		nBoxType  AS INTEGER,;                                                                      // 	INT                  nBoxType,
		hWnd  AS INTEGER,;                                                                          // 	HWND                 hWnd,
		pszTitle AS STRING ) ORDINAL 54 IN CMBT_DLL                                                 // 	LPCSTR               pszTitle
																																  //
LL_EXTERN INTEGER LlPrinterSetup(;                                                                // CMBT_LL_WINAPI INT      DLLPROC  LlPrinterSetupA
		hLlJob AS INTEGER,;                                                                         //  HLLJOB               hLlJob,
		hWnd  AS INTEGER,;                                                                          //  HWND                 hWnd,
		nObjType  AS UINTEGER,;                                                                     //  UINT                 nObjType,
		pszObjName AS STRING ) ORDINAL 55 IN CMBT_DLL                                               //  LPCSTR               pszObjName
																																  //
LL_EXTERN INTEGER LlSelectFileDlgTitleEx(;                                                        // CMBT_LL_WINAPI INT      DLLPROC  LlSelectFileDlgTitleExA
		hLlJob AS INTEGER,;                                                                         // 	HLLJOB               hLlJob,
		hWnd  AS INTEGER,;                                                                          // 	HWND                 hWnd,
		pszTitle AS STRING,;                                                                        // 	LPCSTR               pszTitle,
		nObjType  AS UINTEGER,;                                                                     // 	UINT                 nObjType,
		@pszObjName AS STRING,;                                                                     // 	LPSTR                pszObjName,
		nBufSize  AS UINTEGER,;                                                                     // 	UINT                 nBufSize,
		@pReserved AS STRING ) ORDINAL 56 IN CMBT_DLL                                               // 	LPVOID               pReserved
																																  //
LL_EXTERN VOID LlSetDlgboxMode(;                                                                  //
		nMode AS INTEGER ) ORDINAL 57 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN INTEGER LlGetDlgboxMode() ORDINAL 58 IN CMBT_DLL                                        //
																																  //
LL_EXTERN INTEGER LlExprParse(;                                                                   //
		hLlJob AS INTEGER,;                                                                         //
		lpExprText  AS STRING,;                                                                     //
		bIncludeFields AS INTEGER ) ORDINAL 59 IN CMBT_DLL                                          //
																																  //
LL_EXTERN INTEGER LlExprType(;                                                                    //
		hLlJob AS INTEGER,;                                                                         //
		lpExpr AS UINTEGER ) ORDINAL 60 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN VOID LlExprError(;                                                                      //
		hLlJob AS INTEGER,;                                                                         //
		@pszBuf  AS STRING,;                                                                        //
		nBufSize AS UINTEGER ) ORDINAL 61 IN CMBT_DLL                                               //
																																  //
LL_EXTERN VOID LlExprFree(;                                                                       //
		hLlJob AS INTEGER,;                                                                         //
		nBufSize AS UINTEGER ) ORDINAL 62 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlExprEvaluate(;                                                                //
		hLlJob AS INTEGER,;                                                                         //
		lpExpr AS UINTEGER,;                                                                        //
		@pszBuf  AS STRING,;                                                                        //
		nBufSize AS UINTEGER ) ORDINAL 63 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlExprGetUsedVars(;                                                             //
		hLlJob AS INTEGER,;                                                                         //
		lpExpr AS UINTEGER,;                                                                        //
		@pszBuf  AS STRING,;                                                                        //
		nBufSize AS UINTEGER ) ORDINAL 162 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlSetOption(;                                                                   //
		hLlJob AS INTEGER,;                                                                         //
		nMode AS UINTEGER,;                                                                         //
		nValue AS UINTEGER ) ORDINAL 64 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlGetOption(;                                                                   //
		hLlJob AS INTEGER,;                                                                         //
		nMode AS UINTEGER ) ORDINAL 65 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlSetOptionString(;                                                             //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		nMode AS UINTEGER,;                                                                         // INT                  nIndex,
		pszBuffer AS STRING ) ORDINAL 66 IN CMBT_DLL                                                // LPCSTR               pszBuffer
																																  //
LL_EXTERN INTEGER LlGetOptionString(;                                                             //
		hLlJob AS INTEGER,;                                                                         //
		nMode AS UINTEGER,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER) ORDINAL 67 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlPrintSetOptionString(;                                                        //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		nIndex AS UINTEGER,;                                                                        // INT                  nIndex,
		pszBuffer AS STRING ) ORDINAL 68 IN CMBT_DLL                                                // LPCSTR               pszBuffer
																																  //
LL_EXTERN INTEGER LlPrintGetOptionString(;                                                        //
		hLlJob AS INTEGER,;                                                                         //
		nMode AS UINTEGER,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER) ORDINAL 69 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlDesignerProhibitAction(;                                                      //
		hLlJob AS INTEGER,;                                                                         //
		nMenuID AS UINTEGER) ORDINAL 70 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlDesignerProhibitFunction(;                                                    //
		hLlJob AS INTEGER,;                                                                         //
		pszFunction AS STRING) ORDINAL 1 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlDesignerProhibitFunctionGroup(;                                               //
		hLlJob AS INTEGER,;                                                                         //
		nGroupFlags AS UINTEGER) ORDINAL 337 IN CMBT_DLL                                            //
																																  //
LL_EXTERN INTEGER LlPrintEnableObject(;                                                           //
		hLlJob AS INTEGER,;                                                                         //
		pszObjectName AS STRING,;                                                                   //
		bEnable AS INTEGER) ORDINAL 71 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlSetFileExtensions(;                                                           //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		nObjType AS UINTEGER,;                                                                      // INT                  nObjType,
		pszObjectExt AS STRING,;                                                                    // LPCSTR               pszObjectExt,
		pszPrinterExt AS STRING,;                                                                   // LPCSTR               pszPrinterExt
		pszSketchExt AS STRING ) ORDINAL 72 IN CMBT_DLL                                             // LPCSTR               pszSketchExt
																																  //
LL_EXTERN INTEGER LlPrintGetTextCharsPrinted(;                                                    //
		hLlJob AS INTEGER,;                                                                         //
		pszObjectName AS STRING ) ORDINAL 73 IN CMBT_DLL                                            //
																																  //
LL_EXTERN INTEGER LlPrintGetFieldCharsPrinted(;                                                   //
		hLlJob AS INTEGER,;                                                                         //
		pszObjectName AS STRING,;                                                                   //
		pszField AS STRING ) ORDINAL 74 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlPrintIsVariableUsed(;                                                         //
		hLlJob AS INTEGER,;                                                                         //
		pszVarName AS STRING ) ORDINAL 75 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlPrintIsFieldUsed(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		pszFieldName AS STRING ) ORDINAL 76 IN CMBT_DLL                                             //
																																  //
LL_EXTERN INTEGER LlPrintOptionsDialogTitle(;                                                     //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		hWnd AS INTEGER,;                                                                           // HWND                 hWnd,
		pszTitle AS STRING,;                                                                        // LPCSTR               pszTitle,
		pszText AS STRING ) ORDINAL 77 IN CMBT_DLL                                                  // LPCSTR               pszText
																																  //
LL_EXTERN INTEGER LlSetPrinterToDefault(;                                                         //
		hLlJob AS INTEGER,;                                                                         //
		nObjType AS UINTEGER,;                                                                      //
		pszObjName AS STRING ) ORDINAL 78 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlDefineSortOrderStart(;                                                        //
		hLlJob AS INTEGER )ORDINAL 79 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN INTEGER LlDefineSortOrder(;                                                             //
		hLlJob AS INTEGER,;                                                                         //
		pszIdentifier AS STRING,;                                                                   //
		@pszText AS STRING ) ORDINAL 80 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlDefineGetSortOrder(;                                                          //
		hLlJob AS INTEGER,;                                                                         //
		pszBuffer AS STRING,;                                                                       //
		nBufSize AS UINTEGER ) ORDINAL 81 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlDefineGrouping(;                                                              //
		hLlJob AS INTEGER,;                                                                         //
		pszSortorder AS STRING,;                                                                    //
		pszIdentifier AS STRING,;                                                                   //
		pszText AS STRING ) ORDINAL 82 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintGetGrouping(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 83 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlAddCtlSupport(;                                                               //
		hLlJob AS INTEGER,;                                                                         //
		nFlags AS UINTEGER,;                                                                        //
		pszInifile AS STRING ) ORDINAL 84 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlPrintBeginGroup(;                                                             //
		hLlJob AS INTEGER,;                                                                         //
		lParam AS UINTEGER,;                                                                        //
		@lpParam AS STRING ) ORDINAL 85 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlPrintEndGroup(;                                                               //
		hLlJob AS INTEGER,;                                                                         //
		lParam AS UINTEGER,;                                                                        //
		@lpParam AS STRING ) ORDINAL 86 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlPrintGroupLine(;                                                              //
		hLlJob AS INTEGER,;                                                                         //
		lParam AS UINTEGER,;                                                                        //
		@lpParam AS STRING ) ORDINAL 87 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlPrintGroupHeader(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		lParam AS UINTEGER ) ORDINAL 88 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlPrintGetFilterExpression(;                                                    //
		hLlJob AS INTEGER,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 89 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlPrintWillMatchFilter(;                                                        //
		hLlJob AS INTEGER ) ORDINAL 90 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintDidMatchFilter(;                                                         //
		hLlJob AS INTEGER ) ORDINAL 91 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlGetFieldContents(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		pszName AS STRING,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 93 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlGetVariableContents(;                                                         //
		hLlJob AS INTEGER,;                                                                         //
		pszName AS STRING,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 92 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlGetSumVariableContents(;                                                      //
		hLlJob AS INTEGER,;                                                                         //
		pszName AS STRING,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 94 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlGetUserVariableContents(;                                                     //
		hLlJob AS INTEGER,;                                                                         //
		pszName AS STRING,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 95 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlGetVariableType(;                                                             //
		hLlJob AS INTEGER,;                                                                         //
		pszName AS STRING ) ORDINAL 96 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlGetFieldType(;                                                                //
		hLlJob AS INTEGER,;                                                                         //
		pszName AS STRING ) ORDINAL 97 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlSetPrinterDefaultsDir(;                                                       //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		pszDir AS STRING ) ORDINAL 200 IN CMBT_DLL                                                  // LPCSTR               pszDir
																																  //
LL_EXTERN INTEGER LlCreateSketch(;                                                                //
		hLlJob AS INTEGER,;                                                                         //
		nObjType AS UINTEGER,;                                                                      //
		pszDir AS STRING ) ORDINAL 201 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlViewerProhibitAction(;                                                        //
		hLlJob AS INTEGER,;                                                                         //
		nMenuID AS INTEGER ) ORDINAL 202 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlPrintCopyPrinterConfiguration(;                                               //
		hLlJob AS INTEGER,;                                                                         //
		lpszFilename AS STRING,;                                                                    //
		nFunction AS INTEGER ) ORDINAL 203 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlSetPrinterInPrinterFile(;                                                     //
		hLlJob AS INTEGER,;                                                                         //
		nObjType AS UINTEGER,;                                                                      //
		pszObjName AS STRING,;                                                                      //
		nPrinterIndex AS UINTEGER,;                                                                 //
		pszPrinter AS STRING,;                                                                      //
		pDevMode AS INTEGER ) ORDINAL 204 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlRTFCreateObject(;                                                             //
		hLlJob AS INTEGER ) ORDINAL 228 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlRTFDeleteObject(;                                                             //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS INTEGER ) ORDINAL 229 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN INTEGER LlRTFSetText(;                                                                  //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS UINTEGER,;                                                                          //
		pszText AS STRING ) ORDINAL 230 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlRTFGetTextLength(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS UINTEGER,;                                                                          //
		nFlags AS UINTEGER ) ORDINAL 231 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlRTFGetText(;                                                                  //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS UINTEGER,;                                                                          //
		nFlags AS UINTEGER,;                                                                        //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 232 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlRTFEditObject(;                                                               //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS UINTEGER,;                                                                          //
		hWnd AS UINTEGER,;                                                                          //
		hPrnDC AS UINTEGER,;                                                                        //
		nProjectType AS UINTEGER,;                                                                  //
		bModal AS INTEGER ) ORDINAL 233 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlRTFCopyToClipboard(;                                                          //
		hLlJob AS INTEGER,;                                                                         //
		hRtf AS INTEGER ) ORDINAL 234 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN INTEGER LlRTFDisplay(;                                                                  //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS UINTEGER,;                                                                          //
		hDC AS UINTEGER,;                                                                           //
		pRC AS UINTEGER,;                                                                           //
		bRestart AS INTEGER,;                                                                       //
		pnState AS INTEGER ) ORDINAL 235 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlRTFEditorProhibitAction(;                                                     //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS UINTEGER,;                                                                          //
		nControlID AS INTEGER ) ORDINAL 109 IN CMBT_DLL                                             //
																																  //
LL_EXTERN INTEGER LlRTFEditorInvokeAction(;                                                       //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS UINTEGER,;                                                                          //
		nControlID AS INTEGER ) ORDINAL 117 IN CMBT_DLL                                             //
																																  //
LL_EXTERN VOID LlDebugOutput(;                                                                    //
		hLlJob AS INTEGER,;                                                                         //
		pszText AS STRING ) ORDINAL 240 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlEnumGetFirstVar(;                                                             //
		hLlJob AS INTEGER,;                                                                         //
		nFlags AS INTEGER ) ORDINAL 241 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlEnumGetFirstField(;                                                           //
		hLlJob AS INTEGER,;                                                                         //
		nFlags AS INTEGER ) ORDINAL 242 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlEnumGetFirstConstant(;                                                        //
		hLlJob AS INTEGER,;                                                                         //
		nFlags AS INTEGER ) ORDINAL 493 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlEnumGetNextEntry(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		nPos AS INTEGER,;                                                                           //
		nFlags AS INTEGER ) ORDINAL 243 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlEnumGetEntry(;                                                                //
		hLlJob AS INTEGER,;                                                                         //
		nPos AS INTEGER,;                                                                           //
		@pszNameBuf AS STRING,;                                                                     //
		nNameBufSize AS INTEGER,;                                                                   //
		@pszContBuf AS STRING,;                                                                     //
		nContBufSize AS INTEGER,;                                                                   //
		pHandle AS INTEGER,;                                                                        //
		pType AS INTEGER ) ORDINAL 244 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlPrintResetObjectStates(;                                                      //
		hLlJob AS INTEGER ) ORDINAL 245 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlXSetParameter(;                                                               //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		nExtensionType AS INTEGER,;                                                                 // INT                  nExtensionType,
		pszExtensionName AS STRING,;                                                                // LPCSTR               pszExtensionName,
		pszKey AS STRING,;                                                                          // LPCSTR               pszKey,
		pszValue AS STRING ) ORDINAL 246 IN CMBT_DLL                                                // LPCSTR               pszValue
																																  //
LL_EXTERN INTEGER LlXGetParameter(;                                                               // CMBT_LL_WINAPI INT      DLLPROC  LlXGetParameterA
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		nExtensionType AS INTEGER,;                                                                 // INT                  nExtensionType,
		pszExtensionName AS STRING,;                                                                // LPCSTR               pszExtensionName,
		pszKey AS STRING,;                                                                          // LPCSTR               pszKey,
		@pszBuffer AS STRING,;                                                                      // LPSTR                pszBuffer,
		nBufSize AS UINTEGER ) ORDINAL 247 IN CMBT_DLL                                              // UINT                 nBufSize

LL_EXTERN INTEGER LlPrintResetProjectState(;                                                      //
		hLlJob AS INTEGER ) ORDINAL 248 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN VOID LlDefineChartFieldStart(;                                                          //
		hLlJob AS INTEGER ) ORDINAL 2 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN INTEGER LlDefineChartFieldExt(;                                                         //
		hLlJob AS INTEGER,;                                                                         //
		pszVarName AS STRING,;                                                                      //
		pszContents AS STRING,;                                                                     //
		lPara AS INTEGER,;                                                                          //
		lpPtr AS STRING ) ORDINAL 3 IN CMBT_DLL                                                     //
																																  //
LL_EXTERN INTEGER LlPrintDeclareChartRow(;                                                        //
		hLlJob AS INTEGER,;                                                                         //
		nFlags AS INTEGER ) ORDINAL 4 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN INTEGER LlPrintGetChartObjectCount(;                                                    //
		hLlJob AS INTEGER,;                                                                         //
		nType AS INTEGER ) ORDINAL 6 IN CMBT_DLL                                                    //
																																  //
LL_EXTERN INTEGER LlPrintIsChartFieldUsed(;                                                       //
		hLlJob AS INTEGER,;                                                                         //
		pszFieldName AS STRING ) ORDINAL 5 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlGetChartFieldContents(;                                                       //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		pszName AS STRING,;                                                                         // LPCSTR               pszName,
		@pszBuffer AS STRING,;                                                                      // LPSTR                pszBuffer,
		nBufSize AS UINTEGER ) ORDINAL 8 IN CMBT_DLL                                                // UINT                 nBufSize
																																  //
LL_EXTERN INTEGER LlEnumGetFirstChartField(;                                                      //
		hLlJob AS INTEGER,;                                                                         //
		nFlags AS INTEGER ) ORDINAL 9 IN CMBT_DLL                                                   //
   																															  //
//CALLBACK_EXTERN INTEGER LlSetNotificationCallbackExt(;                                          // CMBT_LL_WINAPI FARPROC  DLLPROC  LlSetNotificationCallbackExt
LL_EXTERN INTEGER LlSetNotificationCallbackExt(;                                            		  // CMBT_LL_WINAPI FARPROC  DLLPROC  LlSetNotificationCallbackExt
		hJob AS INTEGER,;                                                                           //  HLLJOB               hLlJob,
		nEvent AS INTEGER,;                                                                         //  INT                  nEvent,
		lpfnEnum AS ACALLBACK ) ORDINAL 100 IN CMBT_DLL                                             //  FARPROC              lpfnNotify
																																  //
LL_EXTERN INTEGER LlGetPrinterFromPrinterFile(;                                                   //
		hJob AS INTEGER,;                                                                           // HLLJOB               hJob,
		nObjType AS UINTEGER,;                                                                      // UINT                 nObjType,
		pszObjectName AS STRING,;                                                                   // LPCSTR               pszObjectName,
		nPrinter AS INTEGER,;                                                                       // INT                  nPrinter,
		@pszPrinter AS STRING,;                                                                     // LPSTR                pszPrinter,
		@pnPrinterBufSize AS INTEGER,;                                                              // LLPUINT              pnPrinterBufSize,
		@pDevMode AS STRING,;                                                                       // _PDEVMODEA           pDevMode,
		@pnDevModeBufSize AS INTEGER ) ORDINAL 98 IN CMBT_DLL                                       // LLPUINT              pnDevModeBufSize
																																  //
LL_EXTERN INTEGER LlPrintGetRemainingSpacePerTable(;                                              //
		hJob AS INTEGER,;                                                                           //
		pszField AS STRING,;                                                                        //
		nDimension AS INTEGER ) ORDINAL 102 IN CMBT_DLL                                             //
																																  //
LL_EXTERN INTEGER LlSetDefaultProjectParameter(;                                                  //
		hJob AS INTEGER,;                                                                           //
		pszParameter AS STRING,;                                                                    //
		pszValue AS STRING,;                                                                        //
		nFlags AS INTEGER ) ORDINAL 108 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlGetDefaultProjectParameter(;                                                  //
		hJob AS INTEGER,;                                                                           // HLLJOB               hLlJob,
		pszParameter AS STRING,;                                                                    // LPCSTR               pszParameter,
		@pszBuffer AS STRING,;                                                                      // LPSTR                pszBuffer,
		nBufSize AS UINTEGER,;                                                                      // INT                  nBufSize,
		nFlags AS INTEGER ) ORDINAL 110 IN CMBT_DLL                                                 // _LPUINT              pnFlags
																																  //
LL_EXTERN INTEGER LlPrintSetProjectParameter(;                                                    //
		hJob AS INTEGER,;                                                                           //
		pszParameter AS STRING,;                                                                    //
		pszValue AS STRING,;                                                                        //
		nFlags AS INTEGER ) ORDINAL 113 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlPrintGetProjectParameter(;                                                    //
		hJob AS INTEGER,;                                                                           // HLLJOB               hLlJob,
		pszParameter AS STRING,;                                                                    // LPCSTR               pszParameter,
		bEvaluated AS INTEGER,;                                                                     // BOOL                 bEvaluated,
		@pszBuffer AS STRING,;                                                                      // LPSTR                pszBuffer,
		nBufSize AS UINTEGER,;                                                                      // INT                  nBufSize,
		nFlags AS INTEGER ) ORDINAL 114 IN CMBT_DLL                                                 // _LPUINT              pnFlags
																																  //
LL_EXTERN INTEGER LlExprContainsVariable(;                                                        //
		hJob AS INTEGER,;                                                                           //
		hExpr AS INTEGER,;                                                                          //
		pszVariable AS STRING ) ORDINAL 7 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlExprIsConstant(;                                                              //
		hJob AS INTEGER,;                                                                           //
		hExpr AS INTEGER ) ORDINAL 116 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlProfileStart(;                                                                //
		hJob AS INTEGER,;                                                                           //
		pszBuffer AS STRING,;                                                                       //
		pszFilename AS STRING,;                                                                     //
		nTicksMS AS INTEGER ) ORDINAL 136 IN CMBT_DLL                                               //
																																  //
LL_EXTERN VOID LlProfileEnd(;                                                                     //
		hThread AS INTEGER ) ORDINAL 137 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlDbAddTable(;                                                                  //
		hJob AS INTEGER,;                                                                           //
		pszTableID AS STRING,;                                                                      //
		pszDisplayName AS STRING ) ORDINAL 139 IN CMBT_DLL                                          //
																																  //
LL_EXTERN INTEGER LlDbAddTableRelation(;                                                          //
		hJob AS INTEGER,;                                                                           // HLLJOB               hJob,
		pszTableID AS STRING,;                                                                      // LPCSTR               pszTableID,
		pszParentTableID AS STRING,;                                                                // LPCSTR               pszParentTableID,
		pszRelationID AS STRING,;                                                                   // LPCSTR               pszRelationID,
		pszRelationDisplayName AS STRING ) ORDINAL 140 IN CMBT_DLL                                  // LPCSTR               pszRelationDisplayName
																																  //
LL_EXTERN INTEGER LlDbAddTableSortOrder(;                                                         //
		hJob AS INTEGER,;                                                                           //
		pszTableID AS STRING,;                                                                      //
		pszSortOrderID AS STRING,;                                                                  //
		pszSortOrderDisplayName AS STRING ) ORDINAL 141 IN CMBT_DLL                                 //
																																  //
LL_EXTERN INTEGER LlPrintDbGetCurrentTable(;                                                      //
		hJob AS INTEGER,;                                                                           //
		@pszTableID AS STRING,;                                                                     //
		nTableIDLength AS INTEGER,;                                                                 //
		bCompletePath AS INTEGER ) ORDINAL 142 IN CMBT_DLL                                          //
																																  //
LL_EXTERN INTEGER LlPrintDbGetCurrentTableRelation(;                                              //
		hJob AS INTEGER,;                                                                           //
		@pszRelationID AS STRING,;                                                                  //
		nRelationIDLength AS INTEGER ) ORDINAL 143 IN CMBT_DLL                                      //
																																  //
LL_EXTERN INTEGER LlPrintDbGetCurrentTableSortOrder(;                                             //
		hJob AS INTEGER,;                                                                           //
		@pszSortOrderID AS STRING,;                                                                 //
		nSortOrderIDLength AS INTEGER ) ORDINAL 146 IN CMBT_DLL                                     //
																																  //
LL_EXTERN INTEGER LlDbDumpStructure(;                                                             //
		hJob AS INTEGER ) ORDINAL 149 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN INTEGER LlPrintDbGetRootTableCount(;                                                    //
		hJob AS INTEGER ) ORDINAL 151 IN CMBT_DLL                                                   //
																																  //
LL_EXTERN INTEGER LlDbSetMasterTable(;                                                            //
		hJob AS INTEGER,;                                                                           //
		pszTableID AS STRING ) ORDINAL 152 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlDbGetMasterTable(;                                                            //
		hJob AS INTEGER,;                                                                           //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 157 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlXSetExportParameter(;                                                         //
		hJob AS INTEGER,;                                                                           // HLLJOB               hLlJob,
		pszExtensionName AS STRING,;                                                                // LPCSTR               pszExtensionName,
		pszKey AS STRING,;                                                                          // LPCSTR               pszKey,
		pszValue AS STRING ) ORDINAL 158 IN CMBT_DLL                                                // LPCSTR               pszValue
																																  //
LL_EXTERN INTEGER LlXGetExportParameter(;                                                         //
		hJob AS INTEGER,;                                                                           // HLLJOB               hLlJob,
		pszExtensionName AS STRING,;                                                                // LPCSTR               pszExtensionName,
		pszKey AS STRING,;                                                                          // LPCSTR               pszKey,
		@pszBuffer AS STRING,;                                                                      // LPSTR                pszBuffer,
		nBufSize AS UINTEGER ) ORDINAL 160 IN CMBT_DLL                                              // UINT                 nBufSize
																																  //
LL_EXTERN INTEGER LlXlatName(;                                                                    //
		hJob AS INTEGER,;                                                                           //
		pszName AS STRING,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 164 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlDesignerProhibitEditingObject(;                                               //
		hJob AS INTEGER,;                                                                           //
		pszObject AS STRING ) ORDINAL 185 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlGetUsedIdentifiers(;                                                          //
		hJob AS INTEGER,;                                                                           //
		pszProjectName AS STRING,;                                                                  //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 186 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlExprGetUsedVarsEx(;                                                           //
		hJob AS INTEGER,;                                                                           //
		lpExpr AS INTEGER,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		bOrgName AS INTEGER ) ORDINAL 205 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlDomGetProject(;                                                               //
		hJob AS INTEGER,;                                                                           //
		@phDOMObj AS INTEGER ) ORDINAL 206 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlDomGetProperty(;                                                              //
		hDOMObj AS INTEGER,;                                                                        //
		pszName AS STRING,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		bOrgName AS INTEGER ) ORDINAL 207 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlDomSetProperty(;                                                              //
		hDOMObj AS INTEGER,;                                                                        //
		pszName AS STRING,;                                                                         //
		pszValue AS STRING ) ORDINAL 208 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlDomGetObject(;                                                                //
		hDOMObj AS INTEGER,;                                                                        //
		pszName AS STRING,;                                                                         //
		@phDOMSubObj AS INTEGER ) ORDINAL 209 IN CMBT_DLL                                           //
																																  //
LL_EXTERN INTEGER LlDomGetSubobjectCount(;                                                        //
		hDOMObj AS INTEGER,;                                                                        //
		@pnCount AS INTEGER ) ORDINAL 210 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlDomGetSubobject(;                                                             //
		hDOMObj AS INTEGER,;                                                                        //
		nPosition AS INTEGER,;                                                                      //
		@phDOMSubObj AS INTEGER ) ORDINAL 211 IN CMBT_DLL                                           //
																																  //
LL_EXTERN INTEGER LlDomCreateSubobject(;                                                          //
		hDOMObj AS INTEGER,;                                                                        //
		nPosition AS INTEGER,;                                                                      //
		pszType AS STRING,;                                                                         //
		@phDOMSubObj AS INTEGER ) ORDINAL 212 IN CMBT_DLL                                           //
																																  //
LL_EXTERN INTEGER LlDomDeleteSubobject(;                                                          //
		hDOMObj AS INTEGER,;                                                                        //
		nPosition AS INTEGER ) ORDINAL 213 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlProjectOpen(;                                                                 //
		hLlJob AS INTEGER,;                                                                         //
		nObjType AS UINTEGER,;                                                                      //
		pszObjName AS STRING,;                                                                      //
		nOpenMode AS UINTEGER ) ORDINAL 214 IN CMBT_DLL                                             //
																																  //
LL_EXTERN INTEGER LlProjectSave(;                                                                 //
		hLlJob AS INTEGER,;                                                                         //
		pszObjName AS STRING ) ORDINAL 215 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlProjectClose(;                                                                //
		hLlJob AS INTEGER ) ORDINAL 216 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlAssociatePreviewControl(;                                                     //
		hLlJob AS INTEGER,;                                                                         //
		hWndControl AS INTEGER,;                                                                    //
		nFlags AS INTEGER ) ORDINAL 218 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlGetErrortext(;                                                                //
		nError AS INTEGER,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS UINTEGER ) ORDINAL 219 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlSetPreviewOption(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		nOption AS UINTEGER,;                                                                       //
		nValue AS UINTEGER ) ORDINAL 221 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlGetPreviewOption(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		nOption AS UINTEGER,;                                                                       //
		nValue AS UINTEGER ) ORDINAL 222 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlDesignerInvokeAction(;                                                        //
		hLlJob AS INTEGER,;                                                                         //
		nMenuID AS INTEGER ) ORDINAL 223 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlDesignerRefreshWorkspace(;                                                    //
		hLlJob AS INTEGER ) ORDINAL 224 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlDesignerFileOpen(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		pszFilename AS STRING,;                                                                     //
		nValue AS UINTEGER ) ORDINAL 225 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlDesignerFileSave(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		nValue AS UINTEGER ) ORDINAL 226 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlDesignerAddAction(;                                                           //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		nID AS UINTEGER,;                                                                           // UINT                 nID,
		nFlags AS UINTEGER,;                                                                        // UINT                 nFlags,
		pszMenuText AS STRING,;                                                                     // LPCSTR               pszMenuText,
		pszMenuHierarchy AS STRING,;                                                                // LPCSTR               pszMenuHierarchy,
		pszTooltipText AS STRING,;                                                                  // LPCSTR               pszTooltipText,
		nIcon AS UINTEGER,;                                                                         // UINT                 nIcon,
		@pvReserved AS STRING ) ORDINAL 227 IN CMBT_DLL                                             // LPVOID               pvReserved
																																  //
LL_EXTERN INTEGER LlDesignerGetOptionString(;                                                     //
		hLlJob AS INTEGER,;                                                                         //
		nIndex AS UINTEGER,;                                                                        //
		pszBuffer AS STRING,;                                                                       //
		nBufSize AS INTEGER ) ORDINAL 236 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlDesignerSetOptionString(;                                                     //
		hLlJob AS INTEGER,;                                                                         //
		nIndex AS UINTEGER,;                                                                        //
		@pszBuffer AS STRING ) ORDINAL 237 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlJobOpenCopy(;                                                                 //
		hLlJob AS INTEGER ) ORDINAL 239 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlGetProjectParameter(;                                                         //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		pszProjectName AS STRING,;                                                                  // LPCSTR               pszProjectName,
		pszParameter AS STRING,;                                                                    // LPCSTR               pszParameter,
		@pszBuffer AS STRING,;                                                                      // LPSTR                pszBuffer,
		nBufSize AS INTEGER ) ORDINAL 249 IN CMBT_DLL                                               // UINT                 nBufSize
																																  //
LL_EXTERN INTEGER LlConvertBLOBToString(;                                                         //
		@pBytes AS INTEGER,;                                                                        //
		nBytes AS INTEGER,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS INTEGER,;                                                                       //
		bWithCompression AS INTEGER ) ORDINAL 250 IN CMBT_DLL                                       //
																																  //
LL_EXTERN INTEGER LlConvertStringToBLOB(;                                                         //
		pszText AS STRING,;                                                                         //  LPCSTR               pszText,
		@pBytes AS INTEGER,;                                                                        //  _PUINT8              pBytes,
		nBytes AS INTEGER ) ORDINAL 251 IN CMBT_DLL                                                 //  UINT                 nBytes
																																  //
LL_EXTERN INTEGER LlDbAddTableRelationEx(;                                                        //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hJob,
		pszTableID AS STRING,;                                                                      // LPCSTR               pszTableID,
		pszParentTableID AS STRING,;                                                                // LPCSTR               pszParentTableID,
		pszRelationID AS STRING,;                                                                   // LPCSTR               pszRelationID,
		pszRelationDisplayName AS STRING,;                                                          // LPCSTR               pszRelationDisplayName,
		pszKeyField AS STRING,;                                                                     // LPCSTR               pszKeyField,
		pszParentKeyField AS STRING ) ORDINAL 238 IN CMBT_DLL                                       // LPCSTR               pszParentKeyField
																																  //
LL_EXTERN INTEGER LlDbAddTableSortOrderEx(;                                                       //
		hLlJob AS INTEGER,;                                                                         //
		pszTableID AS STRING,;                                                                      //
		pszSortOrderID AS STRING,;                                                                  //
		pszSortOrderDisplayName AS STRING,;                                                         //
		pszParepszFieldntKeyField AS STRING ) ORDINAL 257 IN CMBT_DLL                               //
																																  //
LL_EXTERN INTEGER LlGetUsedIdentifiersEx(;                                                        // CMBT_LL_WINAPI INT   LlGetUsedIdentifiersExA
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hLlJob,
		pszProjectName AS STRING,;                                                                  // LPCSTR               pszProjectName,
		nIdentifierTypes AS UINTEGER,;                                                              // UINT                 nIdentifierTypes,
		@pszBuffer AS STRING,;                                                                      // LPSTR                pszBuffer,
		nBufSize AS UINTEGER ) ORDINAL 258 IN CMBT_DLL                                              // UINT                 nBufSize
																																  //
LL_EXTERN INTEGER LlGetTempFileName(;                                                             //
		pszPrefix AS STRING,;                                                                       // LPCSTR               pszPrefix,
		pszExt AS STRING,;                                                                          // LPCSTR               pszExt,
		@pszBuffer AS STRING,;                                                                      // LPSTR                pszBuffer,
		nBufSize AS INTEGER,;                                                                       // UINT                 nBufSize,
		nOptions AS INTEGER) ORDINAL 259 IN CMBT_DLL                                                // UINT                 nOptions
																																  //
LL_EXTERN INTEGER LlGetDebug() ORDINAL 260 IN CMBT_DLL                                            //
																																  //
LL_EXTERN INTEGER LlRTFEditorGetRTFControlHandle(;                                                //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS INTEGER) ORDINAL 261 IN CMBT_DLL                                                    //
																																  //
LL_EXTERN INTEGER LlGetDefaultPrinter(;                                                           //
		@pszPrinter AS STRING,;                                                                     //
		pnPrinterBufSize AS INTEGER,;                                                               //
		@pDevMode AS INTEGER,;                                                                      //
		@pnDevModeBufSize AS STRING,;                                                               //
		nOptions AS INTEGER) ORDINAL 262 IN CMBT_DLL                                                //
																																  //
LL_EXTERN INTEGER LlLocAddDictionaryEntry(;                                                       //
		hLlJob AS INTEGER,;                                                                         //
		nLCID AS INTEGER,;                                                                          //
		pszKey AS STRING,;                                                                          //
		pszValue AS STRING,;                                                                        //
		nType AS UINTEGER) ORDINAL 263 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlLocAddDesignLCID(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		nLCID AS UINTEGER) ORDINAL 264 IN CMBT_DLL                                                  //
																																  //
LL_EXTERN INTEGER LlIsUILanguageAvailable(;                                                       //
		nLanguage AS INTEGER,;                                                                      //
		nTypesToLookFor AS UINTEGER) ORDINAL 265 IN CMBT_DLL                                        //
																																  //
LL_EXTERN INTEGER LlIsUILanguageAvailableLCID(;                                                   //
		nLCID AS INTEGER,;                                                                          //
		nTypesToLookFor AS UINTEGER) ORDINAL 266 IN CMBT_DLL                                        //
																																  //
LL_EXTERN INTEGER LlDbAddTableEx(;                                                                //
		hLlJob AS INTEGER,;                                                                         // HLLJOB               hJob,
		pszTableID AS STRING,;                                                                      // LPCSTR               pszTableID,
		pszDisplayName AS STRING,;                                                                  // LPCSTR               pszDisplayName,
		nOptions AS UINTEGER) ORDINAL 267 IN CMBT_DLL                                               // UINT                 nOptions
																																  //
LL_EXTERN INTEGER LlRTFSetTextEx(;                                                                //
		hLlJob AS INTEGER,;                                                                         //
		hRTF AS INTEGER,;                                                                           //
		nFlags AS INTEGER,;                                                                         //
		pszText AS STRING ) ORDINAL 269 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlInplaceDesignerInteraction(;                                                  //
		hLlJob AS INTEGER,;                                                                         //
		nAction AS INTEGER,;                                                                        //
		wParam AS INTEGER,;                                                                         //
		lParam AS INTEGER ) ORDINAL 270 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlGetProjectDescription(;                                                       //
		hLlJob AS INTEGER,;                                                                         //
		pszProjectName AS STRING,;                                                                  //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS INTEGER ) ORDINAL 280 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlSRTriggerExport(;                                                             //
		hLlJob AS INTEGER,;                                                                         //
		hSessionJob AS INTEGER,;                                                                    //
		@pszID AS STRING,;                                                                          //
		@pszExportFormat AS STRING,;                                                                //
		nFlags AS INTEGER ) ORDINAL 289 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlExprGetUsedFunctions(;                                                        //
		hLlJob AS INTEGER,;                                                                         //
		lpExpr AS INTEGER,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS INTEGER ) ORDINAL 292 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlDesignerTriggerJobInUIThread(;                                                //
		hLlJob AS INTEGER,;                                                                         //
		nUserData AS INTEGER ) ORDINAL 293 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlJobOpenCopyEx(;                                                               //
		hLlJob AS INTEGER,;                                                                         //
		nFlags AS INTEGER ) ORDINAL 299 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlUtilsLcidFromLocaleName(;                                                     //
		@pszLocaleName AS STRING ) ORDINAL 319 IN CMBT_DLL                                          //
																																  //
LL_EXTERN INTEGER LlDesignerShowMessage(;                                                         //
		hLlJob AS INTEGER,;                                                                         //
		@pszTitle AS STRING,;                                                                       //
		@pszMessage AS STRING,;                                                                     //
		nFlags AS INTEGER ) ORDINAL 320 IN CMBT_DLL                                                 //
																																  //
LL_EXTERN INTEGER LlUtilsGetProjectType(;                                                         //
		hLlJob AS INTEGER,;                                                                         //
		@pszProjectFilename AS STRING) ORDINAL 325 IN CMBT_DLL                                      //
																																  //
LL_EXTERN INTEGER LlGetLastErrorText(;                                                            //
		hLlJob AS INTEGER,;                                                                         //
		@pszBuffer AS STRING,;                                                                      //
		nBufSize AS INTEGER ) ORDINAL 327 IN CMBT_DLL                                               //
																																  //
LL_EXTERN INTEGER LlProjectFindAndReplace(;                                                       //
		hLlJob AS INTEGER,;                                                                         //
		pszSearchText AS STRING,;                                                                   //
		pszReplaceText AS STRING,;                                                                  //
		nSARFlags AS INTEGER ) ORDINAL 312 IN CMBT_DLL                                              //
																																  //
LL_EXTERN INTEGER LlExprTypeMask(;                                                                //
		hLlJob AS INTEGER,;                                                                         //
		@lpExpr AS STRING) ORDINAL 345 IN CMBT_DLL                                                  //



//=========================================
// Create a function for structure
//=========================================
#if XPPVER >= 2001392
STRUCTURE LLCallbackNotify
#else
DEFINE STRUCTURE LLCallbackNotify
#endif
	VAR _nSize           AS UINTEGER
	VAR _nUserParam      AS UINTEGER
	VAR _pszProjectName  AS @STRING
	VAR _pszOriginalProjectFileName AS @STRING
	VAR _nPages          AS UINTEGER
	VAR _nFunction       AS UINTEGER
	VAR _hWnd            AS UINTEGER
	VAR _hEvent          AS UINTEGER
	VAR _pszExportFormat AS @STRING
	VAR _bWithoutDialog  AS UINTEGER
#if XPPVER >= 2001392
ENDSTRUCTURE
#else
ENDDEFINE
#endif

//=========================================
// Create a function for structure
//=========================================
#if XPPVER >= 2001392
STRUCTURE LlDrillDownJobNotify
#else
DEFINE STRUCTURE LlDrillDownJobNotify
#endif
	VAR _nSize					  AS UINTEGER
	VAR _nFunction            AS UINTEGER
	VAR _nUserParameter       AS @STRING
	VAR _pszTableID           AS @STRING
	VAR _pszRelationID        AS @STRING
	VAR _pszSubreportTableID  AS @STRING
	VAR _pszKeyField          AS @STRING
	VAR _pszSubreportKeyField AS @STRING
	VAR _pszKeyValue          AS @STRING
	VAR _pszProjectFileName   AS @STRING
	VAR _pszPreviewFileName   AS @STRING
	VAR _pszTooltipText       AS @STRING
	VAR _pszTabText           AS @STRING
	VAR _hWnd                 AS UINTEGER
	VAR _nID                  AS @STRING
	VAR _hAttachInfo          AS UINTEGER
	VAR _pszSRID              AS @STRING
	VAR _pszExportFormat      AS @STRING
#if XPPVER >= 2001392
ENDSTRUCTURE
#else
ENDDEFINE
#endif



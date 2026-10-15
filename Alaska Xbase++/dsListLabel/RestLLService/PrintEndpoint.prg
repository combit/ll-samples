/*============================================================================
 File Name:	   RestServer.prg
 Author:       Marcus Herz
 Description:
 Created:      26.07.2022     16:45:12        Updated: þ26.07.2022      þ16:45:12
 Copyright:		 2022 Pohlen Bedachungen
 Revision:
 $Group:
============================================================================*/


#include "xclass.ch"
#include "acexbp.ch"
#include "dsDebugLog.ch"
#include "fileio.ch"
#include "socket.ch"
#include "service.ch"

#define RUNNING        1
#define NOTRUNNING     2
#define PAUSING        3

#TRANSLATE ntrim(<n>) => trim(str(<n>))

#DEFINE MAX_PATH		260

STATIC cIp, nPort

STATIC EXTERN UINTEGER GetTempFileName( PathName as STRING, PrefixString as STRING, uUnique  as UINTEGER, @TempFileName  as STRING ) IN WIN32API
STATIC EXTERN UINTEGER GetTempPath(nBufferLength as UINTEGER, @Buffer AS STRING ) in WIN32API

CLASS Print FROM ServiceApp

	HIDDEN:
		CLASS VAR    nStatus

	PROTECTED:
		CLASS VAR    	nServerSocket
		CLASS VAR    	nFDSet
		CLASS VAR    	cRootDirectory

	EXPORTED:

		CLASS METHOD 	initClass
		CLASS METHOD 	setRootDirectory

		CLASS METHOD 	main
		CLASS METHOD 	pause
		CLASS METHOD 	continue
		CLASS METHOD 	stop

		METHOD 			execute
		METHOD 			post
		METHOD 			get
		METHOD 			put is post

ENDCLASS

//=========================================
CLASS METHOD Print:initClass()
	LOCAL oIni

	::nStatus := RUNNING

	set( _SET_COLLATION	,COLLAT_SYSTEM )
	set( _SET_CHARSET		,CHARSET_ANSI )

	oIni	:= AppReadIni(GetAppDir() +"RESTLLSERVER.INI")

	nPort	:= oIni:GetEntry("RESTLLSERVER", "PORT", 81, "N")
	cIp	:= oIni:GetEntry("RESTLLSERVER", "IPADR", "localhost")

RETURN SELF

//=========================================
CLASS METHOD Print:setRootDirectory( cDir )
	::cRootDirectory := cDir
RETURN SELF

//=========================================
CLASS METHOD Print:main()
	LOCAL oHttpEndpoint

	dsDebugLog():Forcelog(_LOG_TEXT, "Main ")

	oHttpEndpoint := HttpEndpoint():new( nPort, cIp )

	if oHttpEndpoint:start()
		dsDebugLog():Forcelog(_LOG_TEXT, "started: "+ cIp +":"+ ntrim(nPort))
	else
		dsDebugLog():Forcelog(_LOG_TEXT, "failed starting: "+ cIp +":"+ ntrim(nPort))
	endif

	//
	// Solange der Service laeuft werden wir
	//
	DO WHILE ::nStatus = RUNNING
		sleep(100)
	ENDDO

	oHttpEndpoint:stop()

	dsDebugLog():Forcelog(_LOG_TEXT, "closed ")

RETURN


// Hier folget die Implementierung der Callback
// method.
//
CLASS METHOD Print:pause()
	::nStatus := PAUSING
RETURN

CLASS METHOD Print:continue()
	::nStatus := RUNNING
RETURN

CLASS METHOD Print:stop()
	::nStatus := NOTRUNNING
RETURN

//=========================================
METHOD Print:Post()
	LOCAL doData	:= dataobject():New()

	doData	:= Json2Var(::httpRequest:Content)

	::httpResponse:AddHeader("statuscode", "200" )

   doData	:= dataobject():New()
	doData	:report	:= "mark"
	doData	:defineFields	:= {;
		{"R1", "wte"},;
		{"R2", "wtew"},;
		{"R3", "sfgn"},;
		{"R4", "zhjz"}}

RETURN var2Json(doData)


//=========================================
METHOD Print:Get()
	LOCAL cJson, cStream, cFile, cPath, cPdf
	LOCAL doJson, doRet
	LOCAL oListLabel
	LOCAL hHandle
   LOCAL nError, nLen, i, iCnt
   LOCAL aFiles

	cPath	:= space(MAX_PATH)
	nLen	:= GetTempPath(MAX_PATH, @cPath)
   cPath	:= left(cPath , nLen)

	cJson		:= ::httpRequest:Content
	doJson	:= Json2Var(cJson)

	aFiles	:= doJson:filenames
	IF IsArray(aFiles)
		iCnt	:= len( aFiles)
		FOR i := 1 TO iCnt
			hHandle	:= fcreate(cPath + aFiles[i,1])
			fwrite(hHandle, Base642Bin(aFiles[i,2]))
			fclose(hHandle)
		NEXT
	ENDIF

	cStream	:= doJson:reportstream
	cStream	:= Base642Bin(cStream)

	cFile		:= cPath + doJson:reportfile

	oListLabel	:= dsListLabel():New(SetAppWindow(), !empty(doJson:UseRtf))

	oListLabel:Stream2Report(cStream, doJson:ProjectType)

	// D: Felder für LLDefineVariable anmelden, kein Parameter: aktuellen Workarea
	// US:register columns for LLDefineVariable, no paramater: active workarea
	oListLabel:DataSetVariable(doJson:defineVariables  )

	// D: Json Array anmelden
	// US:register Json array
	oListLabel:connect(doJson:defineFields)

	// D: Anzahl Sätze für Fortschrittsbalken
	// US:number of records for progress bar
	oListLabel:lastrec(len(doJson:defineFields))

	oListLabel:ProjectType	:= doJson:ProjectType

	// D: alle Felder der aktuellen Workarea für LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField(doJson:defineFields )

	cPdf	:= left(cFile, len(cFile) - 3) + "PDF"

	// D:  Export ausführen
	// US: execute export
	nError := oListLabel:SaveAsPdf(cPdf, TRUE )

	hHandle	:= fopen(cPdf)
	nLen     := fseek( hHandle, 0, FS_END )
	cStream	:= space(nLen)
	fseek( hHandle, 0, FS_SET )
	fread(hHandle, @cStream, nLen)
	fclose(hHandle)

	// D: aufräumen
	// E: clean up
	oListLabel:destroy()
#ifndef DEBUG
	ferase(cFile)
	ferase(cPdf)
	IF IsArray(aFiles)
		iCnt	:= len(aFiles )
		FOR i := 1 TO iCnt
			ferase(cPath + aFiles[i,1])
		NEXT
	ENDIF
#endif

	doRet	:= dataobject():New()
	doRet:pdf	:= Bin2Base64(cStream, 72)
	doRet:errorcode:= nError

	::httpResponse:AddHeader("statuscode", "200" )

RETURN Var2Json(doRet)



// Dispatch the request to existing methods. Return a generic
// web page for all other requests.

METHOD Print:execute( cMethodName )
	LOCAL cResponse := ""

	IF IsMethod(SELF, cMethodName)
		RETURN SUPER:execute( cMethodName )
	ENDIF

	cResponse += "<!DOCTYPE html>"
	cResponse += "<html>"
	cResponse +=   "<head><title>Unhandled request</title></head>"
	cResponse +=   "<body>"
	cResponse +=     "<h1>No handler for: "+cMethodName+"</h1>"
	cResponse +=     "<p>Please try with: /print/get</p>"
	cResponse +=     "<small>Sorry</small>"
	cResponse +=   "</body>"
	cResponse += "<html>"

RETURN cResponse


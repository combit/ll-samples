/*============================================================================
 File Name:	   PrintEndpoint.prg
 Author:       Marcus Herz
 Description:
 Created:			 27.08.2026     14:16:13        Updated: þ27.08.2026      þ14:16:13
 Copyright:		 2026 DS-Datasoft
 Revision:
 $Group:
============================================================================*/


#include "common.ch"
#include "inkey.ch"
#include "dll.ch"
#include "fileio.ch"
#include "web.ch"

#TRANSLATE ntrim(<n>) => trim(str(<n>))

#DEFINE MAX_PATH		260

#pragma library("xclass.lib")


//=========================================
CLASS Print FROM WebHandler
	HIDDEN:
	PROTECTED:
	EXPORTED:
	METHOD execute
	METHOD post
	METHOD get
	METHOD put is post
	CLASS VAR cSilent

	INLINE CLASS METHOD InitClass
		IF ::cSilent == NIL
			::cSilent 	:= "0"
		ENDIF
		RETURN self

	INLINE CLASS METHOD Silent(xSet)
		::cSilent 	:= xSet
		RETURN self

ENDCLASS

//=========================================
METHOD Print:Post()
	LOCAL doData	:= dataobject():New()

#ifdef DEBUG
	? " post", time(), ::httpRequest:Content
#endif

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

	IF ::cSilent != "1"
#ifdef DEBUG
		? " get", time(), ::httpRequest:Content
#endif
	ENDIF

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

	IF ::cSilent != "1"
#ifdef DEBUG
		? " exec", time(), ::httpRequest:querystring
#endif
	ENDIF

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

FUNC RegisterXClass
RETURN if(file("XDEMO.DLL"), DllCall( "XDEMO.DLL", DLL_XPPCALL, "_Register", 1), NIL )


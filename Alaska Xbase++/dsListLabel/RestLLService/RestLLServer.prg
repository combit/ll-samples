/*============================================================================
 File Name:	   RestLLServer.prg
 Author:       Marcus Herz
 Description:
 Created:			 01.07.2026     10:21:22        Updated: þ01.07.2026      þ10:21:22
 Copyright:		 2026 DS-Datasoft
 Revision:
 $Group:

Dies wird per Hand gestartet,
Dienst RestLLService

============================================================================*/


#include "common.ch"
#include "inkey.ch"
#include "dll.ch"
#include "fileio.ch"
#include "web.ch"

#TRANSLATE ntrim(<n>) => trim(str(<n>))

#DEFINE MAX_PATH		260

#pragma library("xclass.lib")

STATIC scSilent := ""

STATIC EXTERN UINTEGER GetTempFileName( PathName as STRING, PrefixString as STRING, uUnique  as UINTEGER, @TempFileName  as STRING ) IN WIN32API
STATIC EXTERN UINTEGER GetTempPath(nBufferLength as UINTEGER, @Buffer AS STRING ) in WIN32API


PROCEDURE Main( cSilent)
	LOCAL oHttpEndpoint, oIni
	LOCAL cIp
	LOCAL nKey, nPort
	LOCAL lStarted

	IF !empty(cSilent)
		scSilent	:= cSilent
	ENDIF

	set( _SET_COLLATION	,COLLAT_SYSTEM )
	set( _SET_CHARSET		,CHARSET_ANSI )

	oIni	:= AppReadIni(".\RestLLServer.INI")
	nPort	:= oIni:GetEntry("RESTLLSERVER", "PORT", 81, "N")
	cIp	:= oIni:GetEntry("RESTLLSERVER", "IPADR", "localhost")

	Print():Silent( cSilent )
	//
	//
	// Create an end point for handling incoming
	// connections on the specified port
	//
	// Note: Requests to .html files are handled
	//       automatically by the Http end point!
	//       No code must be written for returning
	//       the sample .html file.
	//
	oHttpEndpoint := HttpEndpoint():new( nPort, cIp )

	lStarted := oHttpEndpoint:start()
	IF .NOT. lStarted
		IF scSilent != "1"
#ifdef DEBUG
			? "Startup error. Check if port "+ Var2Char(nPort) +" is already in use."
#endif
			inkey()
		ENDIF
		RETURN
	ENDIF

	IF scSilent = "1"
		setappwindow():hide()

	ELSE
		? "HttpEndpoint RestLLServer"
		?
		? "RestServer API"
		?

		? "     started:", cIp +":"+ ntrim(nPort)
		?
		? "Press ESC to quit"
	ENDIF


	// Continue until the ESC key was pressed
	nKey := 0
	DO WHILE nKey <> K_ESC
		nKey := Inkey(1)
	ENDDO

	//
	// Stop the endpoint before the application
	// terminates
	//
	oHttpEndpoint:stop()

RETURN


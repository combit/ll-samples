/*============================================================================
 File Name:	   PrintRestapi.prg
 Author:       Marcus Herz
 Description:
 Created:	   20.08.2026     10:45:21        Updated: þ20.08.2026      þ12:38:54
 Copyright:		2026 DS-Datasoft
 Revision:
============================================================================*/

#include "lldemo.ch"
#include "fileio.ch"
#include "dll.ch"
#include "appevent.ch"
#include "dsListLabel.ch"

#DEFINE MAX_PATH		260


STATIC EXTERN UINTEGER GetTempFileName( PathName as STRING, PrefixString as STRING, uUnique  as UINTEGER, @TempFileName  as STRING ) IN WIN32API
STATIC EXTERN UINTEGER GetTempPath(nBufferLength as UINTEGER, @Buffer AS STRING ) in WIN32API

//-------------------------------------------------------------------
PROCEDURE PrintRestAPI(nPrintingTarget, lDesignDocument, cFolder)
	//-------------------------------------------------------------------
	LOCAL cBillno, cFile, cResult, cJson, cStream, cPath, cTmp, cIpAdr
	LOCAL aFields, aFile
	LOCAL doVar, doTmp, doJson, doTmp1
	LOCAL oFileDlg, oHttp, oListLabel, panRight, oIni
	LOCAL hHandle
	LOCAL nError, nPos, nStart, nTmp, nPort

	UNUSED (nError)

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// restapi server starten
//	if ! FindApplication( "xbpDialog", "RestLLservice", FALSE ) .or. ;
//			! FindApplication( "xbpDialog", "RestLLserver", FALSE )
//		runshell('/C start "" RestLLserver.exe 1',, TRUE , TRUE )
//	endif
	if ! FindApplication( "xbpDialog", "RestLLserver", FALSE )
		runshell('/C start "" /MIN RestLLserver.exe 1',, TRUE , TRUE )
	endif

	doVar		:= NIL
	doTmp		:= NIL
	aFields	:= {}

	// D: Datenbank sollte bei Applikation liegen...
	// US: Database should be with application exe...
	DbUseArea(.T., , "INVOICE")
	dbsetIndex("INVOICE")
	ordsetfocus("BILLNO")

	DbGoTop()

	// select invoice
	cBillno	:= dsSelectValue(,SELECT_QSINGLE, "Select Invoice",select(),{;
		{"BILLNO"	,"BILLNO"},;
		{"Company"	,"NAME"	},;
		{"City"		,"CITY"	}},,,,;
		{800,600},,,,;
		{|| field->billNo})                                                           // return value

	if empty(cBillno)
		dbCloseArea()
		RETURN
	endif

	// D: Satz steht nach Auswahl richtig
	// US:record pointer is positioned at cBillno after selection
	SCATTER NAME doVar
	doTmp1	:= dataobject():New()
	doTmp1:merge(doVar, "INVOICE.")
	doVar	:= doTmp1
	dbCloseArea()

	// D:  allgemeine DEFAULTs
	// US: common DEFAULTs
	doVar:COMPUTER	:= dsGetComputerName()
	doVar:USER		:= dsGetUserName()

	// D: Daten in Array mit DataObjects kopieren
	// US:copy all data to array with DataObjects
	DbUseArea(.T., , "Items")
	dbsetIndex("Items")
	ordsetfocus("BILLNO")
	dbseek( cBillno )
	DO WHILE !eof() .AND. field->billno = cBillno
		SCATTER NAME doTmp
		doTmp1	:= dataobject():New()
		doTmp1:merge(doTmp, "ITEM.")
		aadd( aFields, doTmp1)
		dbSkip()
	ENDDO
	dbCloseArea()

	// D:  Dateieauswahl
	// US: Call file open dialog
	oFileDlg   := XbpFileDialog():new()
	oFileDlg:create( AppDesktop() )
	oFileDlg:restoreDir	:= TRUE
	oFileDlg:fileFilters	:= {{ "LST for Invoice", "*.lst"}}
	cFile := oFileDlg:open( cFolder,,, FALSE )

	IF !empty(cFile)
		// DEMO CODE starts here
		doJson	:= dataobject():New()
		doJson:defineVariables	:= doVar
		doJson:defineFields		:= aFields
//		doJson:VariableAlias		:= "INVOICE"
//		doJson:FieldAlias			:= "ITEM"
		doJson:UseRtf				:= FALSE

		IF lDesignDocument
			oListLabel	:= dsListLabel():New(SetAppWindow())
			oListLabel:Report	:= cFile

			// D: Felder für LLDefineVariable anmelden, kein Parameter: aktuellen Workarea
			// US:register columns for LLDefineVariable, no paramater: active workarea
			oListLabel:DataSetVariable(doJson:defineVariables )

			// D: Json Array anmelden
			// US:register Json array
			oListLabel:connect(doJson:defineFields)

			// D: Anzahl Sätze für Fortschrittsbalken
			// US:number of records for progress bar
			oListLabel:lastrec(len(doJson:defineFields))

			// D: alle Felder der aktuellen Workarea für LLDefineField anmelden
			// US:register all columns of active workarea for LLDefineField
			oListLabel:DataSetField(doJson:defineFields )

			// D: Dateiauswahldialog oeffnen
			// US: Call file open dialog
			IF AppKeyState(xbeK_CTRL) == APPKEY_DOWN
				oListLabel:Design()
			else
				oListLabel:PrintOption(nPrintingTarget)
				nError := oListLabel:print()
			ENDIF

		else
			// DEMO CODE starts here
			// D:  alle Dateien ohne Pfad !
			// US: all files without path !
      	cPath		:= left(cFile, rat("\", cFile))
			cStream	:= _Read2Stream(cFile)
			doJson:reportfile		:= subs(cFile, rat("\", cFile)+1)

			// D:  eingebettete Dateien
			// US: embedded files
			aFile	:= {}
			nStart:= 0
			DO WHILE TRUE
				nPos	:= at("Filename", cStream, nStart)
				IF nPos == 0
					exit
				ENDIF
				cFile	:= subs(cStream, nPos + 9, at(chr(13), cStream, nPos)- nPos -9)
				cTmp  := cFile
				IF at("\", cFile ) > 0
					cTmp		:= subs(cFile, rat("\", cFile )+1)
            	nTmp		:= at(chr(13), cStream, nPos)
            	nTmp		:= at(chr(13), cStream, nTmp+1)
					cStream	:= left(cStream, nPos + 8 ) + cTmp + CRLF + " bRelPath=True"+ subs(cStream, nTmp )
					aadd( aFile, {cTmp, Bin2Base64(_Read2Stream(cFile),71)})
				ELSE
					aadd( aFile, {cTmp, Bin2Base64(_Read2Stream(cPath + cFile),71)})
				ENDIF
            nStart	:= at(chr(13), cStream, nPos)
			ENDDO
#ifdef DEBUG
			memowrit("test.txt", cStream)
#endif
			doJson:reportstream	:= Bin2Base64(cStream, 72)

			// LL_PROJECT_LIST LL_PROJECT_CARD LL_PROJECT_LABEL
			doJson:ProjectType	:= LL_PROJECT_LIST
			doJson:output			:= "PDF"

			IF !empty(aFile)
				doJson:FileNames	:= aFile
			ENDIF

			cJson		:= Var2Json(doJson)

			oIni	:= dsIniFile():new(".\RestLLServer.INI")
			oIni:Read()
			nPort	:= oIni:GetEntry("RESTLLSERVER", "PORT", 81, "N")
			cIpAdr:= oIni:GetEntry("RESTLLSERVER", "IPADR", "localhost")
			oIni:destroy()

			oHttp		:= HttpClient():new( cIpAdr +":" + ntrim(nPort) +"/print/get")

			oHttp:setAcceptCharSet( "utf8" )
			oHttp:httpRequest:setContentType( "text/json" )
			oHttp:httpRequest:setContent( cJson )

      	cResult	:= oHttp:send()
			IF empty(cResult)
				Errorbox(oHttp:GetLastMessage())
         ELSE
				doJson:= Json2Var(cResult)

				cPath	:= space(MAX_PATH)

				nPos	:= GetTempPath(MAX_PATH, @cPath)
   			cPath	:= left(cPath , nPos)

				cFile	:= space(MAX_PATH)
				GetTempFileName(cPath,"PDF",0, @cFile)
				cFile		:= left(cFile, rat(".", cFile))+ "PDF"
				hHandle	:= fcreate(cFile)
				fwrite(hHandle, Base642Bin(doJson:pdf))
				fclose(hHandle)

				panRight	:= GetApplication():mainform:panRight
				panRight:oTabCtrl	:GetPage(400):open(cFile)
            panRight:oTabCtrl	:Activate(400)

				//	Runshell('/C start "" "'+cFile +'"',, TRUE)

			ENDIF
		ENDIF
	ENDIF

RETURN

/////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Liest Inhalt einer Datei in Variable
/// reads content of a file into variable
/// </summary>
/// <param name="cFile">cFile
/// </param>
/// <returns>cStream
/// </returns>
/// <remarks>
/// </remarks>
/////////////////////////////////////////////////////////////////////////////////
STATIC FUNC _Read2Stream(cFile)
	LOCAL hHandle
	LOCAL nLen
	LOCAL cStream

	hHandle	:= fopen(cFile)
	nLen     := fseek( hHandle, 0, FS_END )
	cStream	:= space(nLen)
	fseek( hHandle, 0, FS_SET )
	fread(hHandle, @cStream, nLen)
	fclose(hHandle)
RETURN cStream

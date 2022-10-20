/*============================================================================
 File Name:	   QRrechnung.prg
 Author:       Marcus Herz
 Description:  erzeugt SWISS QR Rechnung
 Created:			 08.08.2022     11:24:28        Updated: þ08.08.2022      þ11:24:28
 Copyright:		 2022 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"
#include "appevent.ch"


//-------------------------------------------------------------------
PROCEDURE QRRechnung(nPrintingTarget, lDesignDocument, cFolder)
//-------------------------------------------------------------------
	LOCAL oListLabel
	LOCAL nError
	LOCAL doRechnung, doCreditor

	// D:  LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE, LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D:  .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// DEMO CODE starts here
	// D: Dataobject für Daten initialisieren
	// US:initiate dataobject

	// D:  Kreditor
	// US: creditor
	doCreditor	:= dataobject():New()
	doCreditor	:ADRESSE1	:= "My Company"
	doCreditor	:ADRESSE2	:= "Am See 1"
	doCreditor	:ADRESSE3	:= "CH 8001 Zürich"
	doCreditor	:QRIBAN		:= "CH001234567890123456E"
	doCreditor	:QRREFERENZ	:= "123456"


	// D:  Daten des Auftrags / Kunden
	// US: invoice / client data
	doRechnung	:= dataobject():New()
	doRechnung	:RENR			:= "22002345"
	doRechnung	:AUFTRNR		:= 4711
	doRechnung	:KDNR			:= 4712
	doRechnung	:BRUTTO		:= 4711.12
	doRechnung	:ANREDE		:= "Fa."
	doRechnung	:LAND			:= "CH"
	doRechnung	:NAME1		:= "USB Switzerland AG"
	doRechnung	:NAME2		:= ""
	doRechnung	:ORT			:= "Zürich"
	doRechnung	:PLZ			:= "8001"
	doRechnung	:STRASSE		:= "Bahnhofstrasse 45"
	doRechnung	:WAEHRUNG	:= "CHF"
	doRechnung	:TEXT			:= "Ihre Bestellung vom 24.12."
	doRechnung	:REFERENZ	:= QRReferenz(doRechnung, doCreditor)
	doRechnung	:QRCODE		:= QRCode( doRechnung, doCreditor )

	// D:  alle Felder des Dataobjects via LLDefineVariable anmelden
	// US: register dataobjects for LLDefineVariable
	oListLabel:DataSetVariable(doRechnung	,"RECHNUNG")
	oListLabel:DataSetVariable(doCreditor	,"CREDITOR")

	// D:  Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_CARD, "Select File" )

	// D:  Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	if lDesignDocument
		// D:  Designer starten
		// US: start designer
		oListLabel:design()
	else
		// D:  Preview, Druck oder Export ausführen
		// US: execute preview, print or export
		oListLabel:PrintOption(nPrintingTarget)
		nError := oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	// D:  aufräumen
	// US: clean up
	oListLabel	:destroy()
	doRechnung	:= NIL
	doCreditor	:= NIL

RETURN

//=========================================
// text für QR Code
//=========================================
FUNC QrCode( doRechnung, doCreditor)
	LOCAL cCrLf	:= "~d013~d010"
	LOCAL cRet

	cCrLf	:= "~d010"

	cRet	:= "SPC" +cCrLf

	// version QRTYPE fix
	cRet	+= "0200" +cCrLf
	// coding type fix
	cRet	+= "1" +cCrLf
	// QR IBAN
	cRet	+= doCreditor:QRIBAN
	// Kreditor
	// Adress Typ
	cRet	+= "K" +cCrLf

	// zahlungsempfänger
	cRet	+= doCreditor:ADRESSE1 +cCrLf
	cRet	+= doCreditor:ADRESSE2 +cCrLf
	cRet	+= doCreditor:ADRESSE3 +cCrLf

	cRet	+= cCrLf+cCrLf
	// Land
	cRet	+= "CH" +cCrLf

	// 7x leere Felder Endgültiger Zahlungsempfänger
	cRet	+= cCrLf +cCrLf +cCrLf +cCrLf +cCrLf +cCrLf +cCrLf

	// Zahlungsbetrag
	cRet	+= ntrim(doRechnung:BRUTTO,2) +cCrLf
	// Währung
	cRet	+= "CHR" +cCrLf
	// Debitor
	// Adress Typ
	cRet	+= "K"+cCrLf
	//
	cRet	+= _char2Utf8Dez(alltrim(doRechnung:NAME1 -( " "+ doRechnung:NAME2))) +cCrLf
	//
	cRet	+= _char2Utf8Dez(alltrim(doRechnung:STRASSE)) +cCrLf
	//
	cRet	+= _char2Utf8Dez(alltrim(doRechnung:PLZ -(" "+ doRechnung:ORT)))
	cRet	+= cCrLf+cCrLf+cCrLf

	// Land
	cRet	+= alltrim(doRechnung:LAND) +cCrLf
	// Zahlungsreferenz
	cRet	+= "QRR" +cCrLf
	//
	cRet	+= QRReferenz(doRechnung, doCreditor) +cCrLf
	//
	cRet	+= "Rechnung "+ doRechnung:RENR +cCrLf
	//
	cRet	+= "EPD"
	if AppKeyState(xbeK_CTRL) == APPKEY_DOWN
		memowrit("qr.txt", strtran( cRet, cCrLf, chr(13) + chr(10)))
	endif
RETURN cRet

//=========================================
// Verfahren mit strukturierter Referenz ohne/mit zusätzliche Informationen
// - freier Text,
// - vorgebene Länge, mit 0 auffüllen!
// - Prüfziffer anhängen
//=========================================
FUNC QRReferenz(doRechnung, doCreditor)
	LOCAL cRet
	cRet	:= doCreditor:QRREFERENZ
	cRet	+= padr(strzero(doRechnung:Auftrnr, 6) + strzero(doRechnung:Kdnr, 5) + doRechnung:Renr, 26, "0")
	cRet	+= _Code( cRet)
RETURN cRet

//=========================================
// prüfziffer erzeugen
//=========================================
STATIC FUNC _Code(cStr)
	LOCAL i, iCnt
	LOCAL nVal
	LOCAL aCode	:= {;
		{0, 9, 4, 6, 8, 2, 7, 1, 3, 5, 0},;
		{9, 4, 6, 8, 2, 7, 1, 3, 5, 0, 9},;
		{4, 6, 8, 2, 7, 1, 3, 5, 0, 9, 8},;
		{6, 8, 2, 7, 1, 3, 5, 0, 9, 4, 7},;
		{8, 2, 7, 1, 3, 5, 0, 9, 4, 6, 6},;
		{2, 7, 1, 3, 5, 0, 9, 4, 6, 8, 5},;
		{7, 1, 3, 5, 0, 9, 4, 6, 8, 2, 4},;
		{1, 3, 5, 0, 9, 4, 6, 8, 2, 7, 3},;
		{3, 5, 0, 9, 4, 6, 8, 2, 7, 1, 2},;
		{5, 0, 9, 4, 6, 8, 2, 7, 1, 3, 1}}

	iCnt	:= len( cStr)
	nVal	:= 0
	for i := 1 to iCnt
		nVal := aCode[nVal+1, val(cStr[i])+1]
	next
RETURN str(aCode[nVal+1,11],1)

//=========================================
// convert utf-8 compatible
//=========================================
STATIC FUNC _char2Utf8Dez(c)
	LOCAL i, iCnt, k, kCnt
	LOCAL cRet, cTmp

	cRet	:= ""

	iCnt	:= len(c)
	for i := 1 to iCnt
		cTmp	:= char2Utf8(c[i])
		kCnt	:= len(cTmp)
		if kCnt == 1
			cRet	+= cTmp
		else
			for k := 1 to kCnt
				cRet += "~d"+ strzero(asc(cTmp[k]), 3)
			next
		endif
	next
RETURN cRet


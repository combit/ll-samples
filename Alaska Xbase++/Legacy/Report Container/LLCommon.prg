//////////////////////////////////////////////////////////////////////
//
//  LLCommon.prg
//
//  Copyright: Copyright (C) combit GmbH
//
//  Content:
//  D: Allgemeine List & Label Routinen
//  US: Common List & Label routines
//////////////////////////////////////////////////////////////////////


#include "Xbp.ch"
#include "dll.ch"
#include "common.ch"
#include "..\cmbtLL30.ch"


//-------------------------------------------------------------------
FUNCTION DefineData(hJob, lAsField, cTableAlias)
//-------------------------------------------------------------------

// D: Wird vom Programm aufgerufen, um die Daten entsprechend dem
//    neuen Datensatz zu definieren. In lAsField wird festgelegt,
//    ob die Daten als Felder oder als Variable an List & Label
//    uebergeben werden.
//    Daten werden aus dem aktuellen Arbeitsbereich ermittelt.

// US: Is called by the program TO define the variables according
//    TO the new record. lAsField distinguishes between field and
//    variable declaration TO List & Label
//    Data is retrived from current workarea.

LOCAL FldType, FldContent, DateBuffer, lExpr, i
LOCAL xFieldValue, cFieldName,cFullName
LOCAL nRet

    // D: Umwandlung von xbase ++ Feldtypen in List & Label Feldtypen
    // US: Conversion of xbase ++ field types TO List & Label field types
    FOR i := 1 TO fcount()
      cFieldName  := FieldName(i)
      xFieldValue := FieldGet(i)
      DO CASE
         CASE ValType(xFieldValue) == "N"; FldType := LL_NUMERIC
                                           FldContent=Str( xFieldValue )
         CASE ValType(xFieldValue) == "D"; FldType := LL_DATE
                                           DateBuffer := Replicate(chr(0), 255)

                                           // D: In Julianisches Datum konvertieren
                                           // US: Convert TO Julian Date

                                           // D: Ausdruck erzeugen
                                           // US: Create expression
                                           lExpr := LlExprParse(hJob,"DateToJulian(DATE("+;
                                                    chr(34)+DTOC(xFieldValue)+chr(34)+"))", .F.)

                                           // D: Ausdruck auswerten
                                           // US: Evaluate expression
                                           LlExprEvaluate(hJob, lExpr, @DateBuffer, 255)

                                           // D: Ausdruck freigeben
                                           // US: Free expression
                                           LlExprFree(hJob, lExpr)

                                           FldContent := DateBuffer

         CASE ValType(xFieldValue) == "L"; FldType := LL_BOOLEAN
                                           FldContent := IIF(xFieldValue,"TRUE","FALSE")
         CASE ValType(xFieldValue) == "C"; FldType := LL_TEXT
                                           FldContent := Trim(xFieldValue)
         CASE ValType(xFieldValue) == "M"; FldType := LL_TEXT
                                           FldContent := xFieldValue
        END CASE

        // D: Daten an List & Label uebergeben
        // US: Pass data TO List & Label
        cFullName:=cTableAlias+"."+cFieldName
        IF lAsField
           nRet := LlDefineFieldExt(hJob, cFullName, FldContent, FldType, 0 )
        ELSE
           nRet := LlDefineVariableExt(hJob, cFullName, FldContent, FldType, 0 )
        Endif
        IF .not. empty(nRet); Exit; Endif
    NEXT i



RETURN nRet

FUNCTION PrintLLTableRow(hJob,sCurrentTable)
LOCAL nBuffer,nRet

   // D: Tabellenzeile ausdrucken
   // US: Print table line
   nRet:=LlPrintFields(hJob)

   // D: Wenn Seitenumbruch, dann neue Kopfzeile drucken und alte Daten wiederholen
   // US: On page break print new header and repeat last data
   DO WHILE nRet=LL_WRN_REPEAT_DATA
      LlPrint(hJob)
      nRet := LlPrintFields(hJob)
   END DO

   DO WHILE nRet==LL_WRN_TABLECHANGE
      nBuffer := LlPrintDbGetCurrentTable(hJob, "",0,.F.)

      IF nBuffer >0
         sCurrentTable:=Replicate(chr(0), nBuffer)
         LlPrintDbGetCurrentTable(hJob,@sCurrentTable,nBuffer + 1,.F.)
         sCurrentTable = Left(sCurrentTable, Len(sCurrentTable)-1)
      END IF

      nRet = PrintTable(sCurrentTable, hJob)
   END DO

RETURN nRet

FUNCTION PrintLLTableFooter(hJob)
   // D: Drucke Fusszeile der letzten Seite
   // US: Print footer of last page
   LOCAL nRet:=LlPrintFieldsEnd(hJob)

   // D: Seitenumbruch fuer letzte Fusszeile, wenn noetig
   // US: Page break for last footer, IF necessary
   DO WHILE nRet=LL_WRN_REPEAT_DATA
      nRet:=LlPrintFieldsEnd(hJob)
  END DO
RETURN nRet


// D: LL Fehlermeldung anzeigen
// US: Display LL error message
PROCEDURE LLErrorMessage(nErrCode)
LOCAL cErrMsg := Replicate(chr(0),400)
IF .not. empty(nErrCode)
  LlGetErrortext(nErrCode, @cErrMsg, 390)

  ConfirmBox( , "#"+AllTrim(Str(nErrCode))+" "+cErrMsg,;
                "L&L error", ;
                XBPMB_OK , XBPMB_QUESTION+XBPMB_APPMODAL+XBPMB_MOVEABLE )
END IF
RETURN


// D: Andere Systemfunktionen...
// US: Other system FUNCTIONs...
DLLFUNCTION GetTempPathA( buffsize, @buffer ) ;
            USING STDCALL ;
            FROM KERNEL32.DLL

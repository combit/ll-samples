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
#include "..\cmbtll27.ch"


//-------------------------------------------------------------------
Function DefineData(hJob, lAsField)
//-------------------------------------------------------------------

// D: Wird vom Programm aufgerufen, um die Daten entsprechend dem
//    neuen Datensatz zu definieren. In lAsField wird festgelegt,
//    ob die Daten als Felder oder als Variable an List & Label
//    uebergeben werden.
//    Daten werden aus dem aktuellen Arbeitsbereich ermittelt.

// US: Is called by the program to define the variables according
//    to the new record. lAsField distinguishes between field and
//    variable declaration to List & Label
//    Data is retrived from current workarea.

LOCAL FldType, FldContent, DateBuffer, lExpr, i
Local xFieldValue, cFieldName
Local nRet

    // D: Umwandlung von xbase ++ Feldtypen in List & Label Feldtypen
    // US: Conversion of xbase ++ field types to List & Label field types
    FOR i := 1 to fcount()
      cFieldName  := FieldName(i)
      xFieldValue := FieldGet(i)
      DO CASE
         CASE ValType(xFieldValue) == "N"; FldType := LL_NUMERIC
                                           FldContent=Str( xFieldValue )
         CASE ValType(xFieldValue) == "D"; FldType := LL_DATE
                                           DateBuffer := Replicate(chr(0), 255)

                                           // D: In Julianisches Datum konvertieren
                                           // US: Convert to Julian Date

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
                                           FldContent := IIf(xFieldValue,"TRUE","FALSE")
         CASE ValType(xFieldValue) == "C"; FldType := LL_TEXT
                                           FldContent := Trim(xFieldValue)
         CASE ValType(xFieldValue) == "M"; FldType := LL_TEXT
                                           FldContent := xFieldValue
        END CASE

        // D: Daten an List & Label uebergeben
        // US: Pass data to List & Label
        If lAsField
           nRet := LlDefineFieldExt(hJob, cFieldName, FldContent, FldType, 0 )
        Else
           nRet := LlDefineVariableExt(hJob, cFieldName, FldContent, FldType, 0 )
        Endif
        If .not. empty(nRet); Exit; Endif
    NEXT i
RETURN nRet


Function PrintLLTableRow(hJob)
   // D: Tabellenzeile ausdrucken
   // US: Print table line
   Local nRet:=LlPrintFields(hJob)

   // D: Wenn Seitenumbruch, dann neue Kopfzeile drucken und alte Daten wiederholen
   // US: On page break print new header and repeat last data
   do while nRet=LL_WRN_REPEAT_DATA
     LlPrint(hJob)
     nRet := LlPrintFields(hJob)
   end do
Return nRet

Function PrintLLTableFooter(hJob)
  // D: Drucke Fusszeile der letzten Seite
  // US: Print footer of last page
  Local nRet:=LlPrintFieldsEnd(hJob)

  // D: Seitenumbruch fuer letzte Fusszeile, wenn noetig
  // US: Page break for last footer, if necessary
  do while nRet=LL_WRN_REPEAT_DATA
     nRet:=LlPrintFieldsEnd(hJob)
  end do
return nRet


// D: LL Fehlermeldung anzeigen
// US: Display LL error message
Procedure LLErrorMessage(nErrCode)
Local cErrMsg := Replicate(chr(0),400)
If .not. empty(nErrCode)
  LlGetErrortext(nErrCode, @cErrMsg, 390)

  ConfirmBox( , "#"+AllTrim(Str(nErrCode))+" "+cErrMsg,;
                "L&L error", ;
                XBPMB_OK , XBPMB_QUESTION+XBPMB_APPMODAL+XBPMB_MOVEABLE )
EndIf
Return


// D: Andere Systemfunktionen...
// US: Other system functions...
DLLFUNCTION GetTempPathA( buffsize, @buffer ) ;
            USING STDCALL ;
            FROM KERNEL32.DLL

FUNCTION MyGetTempPath()
  LOCAL nBuffSize := 261
  LOCAL sBuffer := Replicate(chr(0),261)

  GetTempPathA(nBuffsize, @sBuffer)
return sBuffer

//////////////////////////////////////////////////////////////////////
//
//  Copyright: Copyright (C) combit GmbH
//
//  Contents:
//        This is a standard win32 exe.
//
//////////////////////////////////////////////////////////////////////
#include "Appevent.ch"
#include "Xbp.ch"
#include "dll.ch"
#include "common.ch"
#include "..\cmbtLL29.ch"

PROCEDURE Main

LOCAL nEvent := xbe_None, mp1 := 0, mp2 := 0, oXbp := 0

PRIVATE lDebugOutput := .f.

    SET DATE TO SYSTEM
    SET DELETED ON

    //Form erzeugen
    CreateMainWindow()

    SetAppWindow():show()
    SetAppFocus( SetAppWindow())

    DO WHILE nEvent <> xbeP_Close
      nEvent := AppEvent( @mp1, @mp2, @oXbp )
      oXbp:handleEvent( nEvent, mp1, mp2 )
    END DO

    SetAppWindow():destroy()
    CLOSE ALL
    Quit

RETURN

// D: Standardmaessiges Xbase++ Fenster nicht erzeugen - wird nicht gebraucht
// US: Don't create default Xbase++ window - it's not needed
PROCEDURE AppSys()

RETURN

PROCEDURE DesignReport()

LOCAL hJob,nRet
LOCAL sFileName := Replicate(chr(0),255)

   // D: Fehler beim Laden der Library
   // US: Library loading error
   IF .not.LL29ModuleInit()
      ConfirmBox(SetAppWindow(),"Error loading CMLL29.DLL !."+chr(13)+;
                                "OS error#"+Alltrim(Str(DosError()))+Chr(13)+; //
                                DosErrorMessage(DosError())+chr(13)+;
                                Chr(13)+;
                                "Tip:"+chr(13)+;
                                "In later Xbase++ versions you can check with"+chr(13)+;
                                "'DosErrorMessage(DosError())' for error description.",;
                                "L&L DLL loading error",;
                                XBPMB_OK ,XBPMB_CRITICAL+XBPMB_APPMODAL+XBPMB_MOVEABLE )
   RETURN
   END IF

   // D: List & Label Job oeffnen und Handle holen
   // US: Open List & Label job, retrieve job handle
   hJob := LlJobOpen(-1)

   // D: Fehler - Druckprozess beenden...
   // US: Error - cancel printing process...
   IF (hJob < 0); LLErrorMessage(hJob); RETURN; END IF

   // D: Dateiauswahldialog oeffnen
   // US: Call file open dialog
   nRet :=LlSelectFileDlgTitleEx(hJob,SetAppWindow() :GetHwnd(),"Wählen Sie eine Datei aus",LL_PROJECT_LIST + LL_FILE_ALSONEW, @sFileName, 255)

   IF nRet <0
      LLErrorMessage(nRet)
      LlJobClose(hJob)
      LL29ModuleExit()
   ELSE

      // D: Tabellen & Relation hinzufügen
      // US: Add tables & relations
      DefineTables(hJob)

      // D: Designer aufrufen
      // US: Start designer
      nRet := LlDefineLayout(hJob, SetAppWindow():GetHWND(),"Designer", LL_PROJECT_LIST,sFileName)
      LlJobClose(hJob)
      LL29ModuleExit()
      Close Databases

   END IF

RETURN

PROCEDURE PrintReport(nPrintingTarget)
LOCAL sCurrentTable, nBuffer, hJob, nRet, rootCount
LOCAL sFileName := Replicate(chr(0),255)

   // D: Fehler beim Laden der Library
   // US: Library loading error
   IF .not.LL29ModuleInit()
      ConfirmBox(SetAppWindow(),"Error loading CMLL29.DLL !."+chr(13)+;
                                "OS error#"+Alltrim(Str(DosError()))+Chr(13)+; //
                                DosErrorMessage(DosError())+chr(13)+;
                                Chr(13)+;
                                "Tip:"+chr(13)+;
                                "In later Xbase++ versions you can check with"+chr(13)+;
                                "'DosErrorMessage(DosError())' for error description.",;
                                "L&L DLL loading error",;
                                XBPMB_OK ,XBPMB_CRITICAL+XBPMB_APPMODAL+XBPMB_MOVEABLE )
      RETURN
   END IF

   // D: List & Label Job oeffnen und Handle holen
   // US: Open List & Label job, retrieve job handle
   hJob := LlJobOpen(-1)

   // D: Fehler - Druckprozess beenden...
   // US: Error - cancel printing process...
   IF (hJob < 0); LLErrorMessage(hJob); RETURN; END IF

   // D: Dateiauswahldialog oeffnen
   // US: Call file open dialog
   nRet :=LlSelectFileDlgTitleEx(hJob,SetAppWindow() :GetHwnd(),"Wählen Sie eine Datei aus",LL_PROJECT_LIST  + LL_FILE_ALSONEW, @sFileName, 255)

   IF nRet <0
      LLErrorMessage(nRet)
      LlJobClose(hJob)
      LL29ModuleExit()
   ELSE
      // D: Tabellen & Relation hinzufügen
      // US: Add tables & relations
      DefineTables(hJob)

      // D: List & Label Druckjob starten
      // US: Start List & Label print job
      nRet :=LlPrintWithBoxStart(hJob,LL_PROJECT_LIST,sFileName,nPrintingTarget , LL_BOXTYPE_NORMALMETER,SetAppWindow() :GetHwnd(),"Druck")

      // D:Erste Seite initialisieren; auch hier kann schon durch Objekte vor der Tabelle
      //           ein Seitenumbruch ausgelÃƒÂ¶st werden
      // US:Initialize first page. A page wrap may occur already caused by objects which are
      //                printed before the table

      DO WHILE LlPrint(hJob) ==LL_WRN_REPEAT_DATA
      END DO

      nRet :=  LL_WRN_TABLECHANGE

      //D:  Eigentliche Druckschleife; Wiederholung, solange Daten vorhanden
      //US: Print loop. Repeat while there is still data to print
      rootCount :=LlPrintDbGetRootTableCount(hJob)
      IF rootCount <> 0
         DO WHILE nRet==LL_WRN_TABLECHANGE
            nBuffer := LlPrintDbGetCurrentTable(hJob, "",0,.T.)
            IF nBuffer >0
               sCurrentTable:= Replicate(chr(0),nBuffer)
               LlPrintDbGetCurrentTable(hJob,@sCurrentTable,nBuffer + 1,.F.)
               sCurrentTable = Left(sCurrentTable, Len(sCurrentTable)-1)
            END IF

            nRet := PrintTable(sCurrentTable, hJob)
         END DO
      END IF

      // D: List & Label Druckjob abschliessen
      // US: End List & Label print job
      nRet := LlPrintEnd(hJob, 0)

      LlJobClose(hJob)
      LL29ModuleExit()
      Close Databases

   END IF

RETURN


FUNCTION PrintTable(sCurrentTable, hJob)
LOCAL sCurrentTablePath, nBuffer, nRet, IsNotRoot

   IF sCurrentTable == "LLStaticTable"
      nRet := LlPrintFields(hJob)
      DO WHILE nRet == LL_WRN_REPEAT_DATA
         LlPrint(hJob)
         nRet := LlPrintFields(hJob)
      END DO
   ELSE
      DO CASE
      CASE sCurrentTable == "INVOICE"
         DbSelectArea("INVOICE")
         INDEX ON INVOICE->BILLNO TO BILLNO
         SET INDEX TO BILLNO

      CASE sCurrentTable == "ITEMS"
         DbSelectArea("ITEMS")
         INDEX ON ITEMS->BILLNO TO InvoiceNO
         SET INDEX TO InvoiceNO

         //D: Abfrage ob Root Tabelle
         //US:Check whether is root table
         nBuffer := LlPrintDbGetCurrentTable(hJob, "",0,.T.)
         IF nBuffer >0
            sCurrentTablePath :=Replicate(chr(0),nBuffer)
            LlPrintDbGetCurrentTable(hJob,@sCurrentTablePath,nBuffer + 1,.T.)
            IsNotRoot := ">" $ sCurrentTablePath
         END IF
         //D: Falls Untertabelle Filter setzen
         //US: IF subtable set filter
         IF IsNotRoot
            DbSetScope(SCOPE_BOTH,Invoice->BILLNO)
         END IF
      END CASE
    END IF
    // D: Schleife: Wiederholung fuer jeden Datensatz
    // US: Loop: repeat for each record
    DO WHILE !EOF()
      nRet := DefineData(hJob,.T.,sCurrentTable)

      // D: Tabellenzeile ausdrucken
      // US: Print table line
      nRet := PrintLLTableRow(hJob,sCurrentTable)

      IF .not. empty(nRet); LLErrorMessage(nRet); Exit; EndIf

      // D: Zum naechsten Datensatz wechseln
      // US: Move to next record
      DbSkip()

   END DO

   // D: Drucke Fusszeile der letzten Seite
   // US: Print footer of last page
   nRet:= PrintLLTableFooter(hJob)

   // D: Wichtig, Haupttabelle wieder auswählen,
   //    sonst wird nur 1. Datensatz gedruckt.
   // US: Important, set back the root table
   //    ELSE there is only the first record

   IF sCurrentTable == "ITEMS"
      DbSelectArea("INVOICE")
   END IF
RETURN nRet

FUNCTION DefineTables (hJob)
LOCAL cChildTable, cParentTable
LOCAL INVOICEDB, ITEMSDB
INVOICEDB := GetDataPath()+"\Invoice.dbf"
ITEMSDB   := GetDataPath()+"\Items.dbf"
   // D: DLL-internen Felderpuffer loeschen
   // US: Clear DLL-internal field buffer
   LlDefineFieldStart(hJob)
   LlDefineVariableStart(hJob)

   // D: DLL -internen Tabellenpuffer loeschen
   // US: Clear DLL-internal table buffer
   LlDbAddTable(hJob,"","")

   // D: Freie Tabelle anmelden
   // US:add static table
   LlDbAddTable(hJob,"LLStaticTable","Freier Inhalt")

   // D: Datenbank sollte bei Applikations liegen...
   // US: Database should be with application exe...
   DbUseArea(.T., , ITEMSDB, "Items" )
   DbGoTop()
   cChildTable := Alias(1)
   LlDbAddTable(hJob,cChildTable,"")
   DefineData(hJob,.T.,cChildTable)
   DbUseArea(.T., , INVOICEDB, "Invoice" )
   DbGoTop()
   cParentTable :=Alias(2)
   LlDbAddTable(hjob,cParentTable,"")
   DefineData(hJob,.T.,cParentTable)

   // D: Relation bekannt machen
   // US: register relation
   LlDbAddTableRelationEx(hJob,cChildTable,cParentTable,"InvoiceToItems","","BILLNO","BILLNO")
RETURN 0


FUNCTION GetDataPath()
  LOCAL cFileName := AppName(.T.)
  LOCAL nPosition := RAt( "\", cFileName )
  IF nPosition > 0
     cFileName := Left( cFileName, nPosition - 1)
  ENDIF
  nPosition := RAt( "\", cFileName )
  IF nPosition > 0
     cFileName := Left( cFileName, nPosition - 1)
  ENDIF
RETURN cFileName

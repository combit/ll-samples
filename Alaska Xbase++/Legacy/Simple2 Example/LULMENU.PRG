//////////////////////////////////////////////////////////////////////
//
//  LULMENU.PRG
//
//  Copyright: Copyright (C) combit GmbH
//
//  Content:
//  D: Menue für LULDEMO.EXE und List & Label Druckroutinen
//  US: Menu for LULDEMO.EXE and List & Label printing routines
//////////////////////////////////////////////////////////////////////

#include "Xbp.ch"
#include "dll.ch"
#include "common.ch"
#include "..\cmbtll27.ch"

//-------------------------------------------------------------------
PROCEDURE PrintList(nPrintingTarget, lDesignDocument)
//-------------------------------------------------------------------
Local hJob, nRet, sName := "Article"+Replicate(chr(0),255)
LOCAL nAkt := 0, nCount
Local cTemporaryPath := MyGetTempPath()
// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
// D: .t. - Druck/Export; .f. - Design
// US: .t. - print/export; .f. - design document
DEFAULT lDesignDocument  TO .f.

    // D: Fehler beim Laden der Library
    // US: Library loading error
    If .not.LL27ModuleInit()
    ConfirmBox(SetAppWindow(),"Error loading CMLL27.DLL !."+chr(13)+;
                                "OS error#"+Alltrim(Str(DosError()))+Chr(13)+; //
                                DosErrorMessage(DosError())+chr(13)+;
                                Chr(13)+;
                                "Tip:"+chr(13)+;
                                "In later Xbase++ versions you can check with"+chr(13)+;
                                "'DosErrorMessage(DosError())' for error description.",;
                                "L&L DLL loading error",;
                                XBPMB_OK ,XBPMB_CRITICAL+XBPMB_APPMODAL+XBPMB_MOVEABLE )


    Return
    EndIf

    If Memvar->lDebugOutput
      // D: Debug-Modus aktivieren
      // US: Activate debug mode
      LlSetDebug(LL_DEBUG_CMBTLL)
    Endif


    // D: List & Label Job oeffnen und Handle holen
    // US: Open List & Label job, retrieve job handle
    hJob := LlJobOpen(-1)
    // D: Fehler - Druckprozess beenden...
    // US: Error - cancel printing process...
    If (hJob < 0); LLErrorMessage(hJob); Return; Endif

    // D: Hier wird Ihr persoenlicher Lizenzinfostring eingetragen - siehe perslic.txt
    // US: Enter your licensing info string here - see perslic.txt
/*    LlSetOptionString (hJob, LL_OPTIONSTR_LICENSINGINFO, "<Personal License Key>"...) */

    // D: DLL-internen Felderpuffer loeschen
    // US: Clear DLL-internal field buffer
    LlDefineVariableStart(hJob)

    // D: Datenbank sollte bei Applikations liegen...
    // US: Database should be with application exe...
    USE &(GetDataPath()+"\ARTICLE") NEW
    Goto top
    nCount := LastRec()

    // D: Variablen aus Datenbank definieren
    // US: Define variables from database
    DefineData(hJob, .t.)
    DefineArticleEANCode(hJob, field->ARTICLENO)

    // D: Dateiauswahldialog oeffnen
    // US: Call file open dialog
    nRet:=LlSelectFileDlgTitleEx(hJob, SetAppWindow():getHWND(),;
                                 "Select File", LL_PROJECT_LIST, @sName, 255)
    If lDesignDocument
      if nRet != LL_ERR_USER_ABORTED
        // D: Designer aufrufen
        // US: Start designer
        nRet := LlDefineLayout(hJob, SetAppWindow():GetHWND(),;
                              "Designer", LL_PROJECT_LIST, sName)
      Endif
    Else
      // D: Drucken...
      // US: Printing...
      if nRet != LL_ERR_USER_ABORTED
         // D: List & Label Druckjob starten
             // US: Start List & Label print job
         LlSetPrinterDefaultsDir(hJob, cTemporaryPath)
         nRet := LlPrintWithBoxStart(hJob,                      ;
                                     LL_PROJECT_LIST,           ;
                                     sName,                     ;
                                     nPrintingTarget,           ;
                                     LL_BOXTYPE_STDWAIT,        ;
                                     SetAppWindow():GetHWND(),  ;
                                     "Preview")
         If .not. (nPrintingTarget ==  LL_PRINT_PREVIEW)
           // D: Zieloptionen auswaehlen wenn Export-Button gewaehlt wird
           // US: Chose target options if export button is chosen
           nRet := LlPrintOptionsDialogTitle(hJob, SetAppWindow():GetHWND(), "Chose export target", "for example printer, PDF, XPS, HTML, JPEG,...")
         Endif
         if nRet != LL_ERR_USER_ABORTED
           // D: Schliessen des Previews mit ESC erlauben
           // US: Allow to close preview window with ESC
           LLSetOption(hJob,LL_OPTION_ESC_CLOSES_PREVIEW, 1)

           LlPreviewSetTempPath(hJob, cTemporaryPath)

           // D: Kopfzeile der ersten Seite drucken
           // US: Print header for first page
           nRet := LlPrint(hJob)

           // D: Schleife: Wiederholung fuer jeden Datensatz
           // US: Loop: repeat for each record
           Do While .not. eof()
              // D: Fortschrittsanzeige aktualisieren
              // US: Update progress bar
              LlPrintSetBoxText(hJob, "Printing", ( (100*nAkt++)/nCount ))

              // D: Felder definieren
              // US: Define fields
              DefineData(hJob, .t.)

              // D: Tabellenzeile drucken
              // US: Print table line
              nRet := PrintLLTableRow(hJob)
              If .not. empty(nRet); LLErrorMessage(nRet); Exit; Endif

              SKIP
            end do

           // D: Drucke Fusszeile der letzten Seite
           // US: Print footer of last page
           nRet:= PrintLLTableFooter(hJob)

           // D: List & Label Druckjob abschliessen
           // US: End List & Label print job
           nRet := LlPrintEnd(hJob, 0)
           If .not. empty(nRet); LLErrorMessage(nRet); Endif

           // D: Temporaere Dateien loeschen, die nicht mehr gebraucht werden
           // US: Delete temporary files, it's not needed anymore
           LlPreviewDeleteFiles(hJob, sName, cTemporaryPath)
         Endif // LlPrintOptionsDialogTitle - LL_ERR_USER_ABORTED
       Endif // LL_ERR_USER_ABORTED
    Endif // lDesignDocument
    CLOSE ALL

    // D: List & Label-Job beenden
    // US: Close List & Label job
    LlJobClose(hJob)
    LL27ModuleExit()

RETURN

// D: Fuer Artikelnummer: EAN128-Barcode anlegen
// US: For article number: generate EAN128-barcode
Function DefineArticleEANCode(hJob, cCode, lAsField)
Local nRet
DEFAULT lAsField TO .t.
  // D: Zwischen Feld- und Variablendefinition unterscheiden
  // US: Distinguish between field and variable declaration
  If lAsField
    nRet := LlDefineFieldExt(hJob, "ARTICLENO_EAN128", Trim(cCode), LL_BARCODE_EAN128, 0 )
  Else
    nRet := LlDefineVariableExt(hJob, "ARTICLENO_EAN128", Trim(cCode), LL_BARCODE_EAN128, 0 )
  Endif
Return nRet


STATIC FUNCTION GetDataPath()
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

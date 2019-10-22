&ANALYZE-SUSPEND _VERSION-NUMBER UIB_v9r12 GUI
&ANALYZE-RESUME
&Scoped-define WINDOW-NAME CURRENT-WINDOW
&Scoped-define FRAME-NAME Dialog-Frame
&ANALYZE-SUSPEND _UIB-CODE-BLOCK _CUSTOM _DEFINITIONS Dialog-Frame 
/*========================================================================
'
' Copyright (C) combit GmbH
'
'-------------------------------------------------------------------------
' File   : sample.w
' Module : 
' Descr. : D:   Dieses Beispiel demonstriert das Designen und Drucken von
'              Listen mit combit List & Label
'          US: This example demonstrates how to design and print
'              reports with combit List & Label
========================================================================*/

/* ***************************  Definitions  ************************** */

/* Parameters Definitions ---                                           */

/* Local Variable Definitions ---                                       */

/* _UIB-CODE-BLOCK-END */
&ANALYZE-RESUME


&ANALYZE-SUSPEND _UIB-PREPROCESSOR-BLOCK 

/* ********************  Preprocessor Definitions  ******************** */

&Scoped-define PROCEDURE-TYPE DIALOG-BOX
&Scoped-define DB-AWARE no

/* Name of first Frame and/or Browse and/or first Query                 */
&Scoped-define FRAME-NAME Dialog-Frame

/* Standard List Definitions                                            */
&Scoped-Define ENABLED-OBJECTS BUTTON-1 BUTTON-2 

/* Custom List Definitions                                              */
/* List-1,List-2,List-3,List-4,List-5,List-6                            */

/* _UIB-PREPROCESSOR-BLOCK-END */
&ANALYZE-RESUME



/* ***********************  Control Definitions  ********************** */

/* Define a dialog box                                                  */

/* Definitions of the field level widgets                               */
DEFINE BUTTON BUTTON-1 
     LABEL "&Design ..." 
     SIZE 17 BY 1.14.

DEFINE BUTTON BUTTON-2 
     LABEL "&Print ..." 
     SIZE 17 BY 1.14.


/* ************************  Frame Definitions  *********************** */

DEFINE FRAME Dialog-Frame
     BUTTON-1 AT ROW 7.19 COL 4
     BUTTON-2 AT ROW 7.19 COL 60
     "(Sie muessen dazu mit der Progress DEMO-Datenbank verbunden sein!)" VIEW-AS TEXT
          SIZE 72 BY 1.19 AT ROW 2.43 COL 8
     "(You have to be connected to the Progress DEMO database!)" VIEW-AS TEXT
          SIZE 72 BY 1.19 AT ROW 4.81 COL 8
     "US: This sample demonstrates printing with combit List && Label" VIEW-AS TEXT
          SIZE 72 BY 1.19 AT ROW 3.86 COL 4
     "D:   Dieses Beispiel demonstriert das Drucken mit combit List && Label" VIEW-AS TEXT
          SIZE 72 BY 1.19 AT ROW 1.48 COL 4
     SPACE(4.00) SKIP(6.03)
    WITH VIEW-AS DIALOG-BOX KEEP-TAB-ORDER 
         SIDE-LABELS NO-UNDERLINE THREE-D  SCROLLABLE 
         TITLE "List & Label Sample".


/* *********************** Procedure Settings ************************ */

&ANALYZE-SUSPEND _PROCEDURE-SETTINGS
/* Settings for THIS-PROCEDURE
   Type: DIALOG-BOX
   Allow: Basic,Browse,DB-Fields,Query
   Other Settings: COMPILE
 */
&ANALYZE-RESUME _END-PROCEDURE-SETTINGS

&ANALYZE-SUSPEND _UIB-CODE-BLOCK _CUSTOM _INCLUDED-LIB Dialog-Frame 
/* ************************* Included-Libraries *********************** */

&GLOBAL-DEFINE cmll25_PERSISTENT PERSISTENT
&GLOBAL-DEFINE cmll25_DLLNAME cmll25.dll
{cmll25.i}

/* _UIB-CODE-BLOCK-END */
&ANALYZE-RESUME




/* ***********  Runtime Attributes and AppBuilder Settings  *********** */

&ANALYZE-SUSPEND _RUN-TIME-ATTRIBUTES
/* SETTINGS FOR DIALOG-BOX Dialog-Frame
                                                                        */
ASSIGN 
       FRAME Dialog-Frame:SCROLLABLE       = FALSE.

/* _RUN-TIME-ATTRIBUTES-END */
&ANALYZE-RESUME

 



/* ************************  Control Triggers  ************************ */

&Scoped-define SELF-NAME Dialog-Frame
&ANALYZE-SUSPEND _UIB-CODE-BLOCK _CONTROL Dialog-Frame Dialog-Frame
ON WINDOW-CLOSE OF FRAME Dialog-Frame /* List  Label Sample */
DO:
  APPLY "END-ERROR":U TO SELF.
END.

/* _UIB-CODE-BLOCK-END */
&ANALYZE-RESUME


&Scoped-define SELF-NAME BUTTON-1
&ANALYZE-SUSPEND _UIB-CODE-BLOCK _CONTROL BUTTON-1 Dialog-Frame
ON CHOOSE OF BUTTON-1 IN FRAME Dialog-Frame /* Design ... */
/*=====================================================================================
D:   Diese Funktion ruft den List & Label Designer auf
US: This function invokes the List & Label Designer
=====================================================================================*/

DO:
    def var hJob as integer.                                                              
    def var nRet as integer.
    def var psFilename as memptr.

    /* run LlSetDebug(1). */
    
    /* D:   List & Label Job oeffnen */
    /* US: Open List & Label job */
    run LlJobOpen(output hJob, {&CMBTLANG_DEFAULT}).

    /* D:   Debugging einschalten (das mit List & Label mitgeliefertes DEBWIN     */
    /*     starten, um die Ausgaben zu erhalten!)			                     */
    /* US: Enable debugging (DEBWIN  that came with List & Label must be         */
    /*     started to receive debug messages				                    */
    /* run LlSetDebug(1). */

    /* D:   Optionen setzen */
    /* US: Set options */
    run LlSetOption(output nRet, hJob, {&LL_OPTION_MULTIPLETABLELINES}, 1).

    /* D:   Variablen und Felder zuruecksetzen */
    /* US: reset variables and fields */
    run LlDefineVariableStart(hJob).
    run LlDefineFieldStart(hJob).
    
    /* D:   Variablen und Felder mit Beispiel-Daten fuer Designer definieren (hier der 1. Datensatzinhalt)*/
    /* US: Define variables and fields with sample-data for Designer (here contents of 1st. record) */
    FIND FIRST Customer.
    run LlDefineField (output nRet, hJob, "Customer.Name",    Customer.Name).
    run LlDefineField (output nRet, hJob, "Customer.Phone",   Customer.Phone).
    run LlDefineField (output nRet, hJob, "Customer.Contact", Customer.Contact).
    run LlDefineField (output nRet, hJob, "Customer.Address", Customer.Address).
    run LlDefineField (output nRet, hJob, "Customer.City",    Customer.City).
    run LlDefineFieldExt(output nRet, hJob, "Customer.Zip",   STRING(Customer.Zip), {&LL_NUMERIC}, 0).

    /* D:   Initialisiere Puffer fuer Dateiauswahl */
    /* US: Initialize buffer for fileopen dialog */
    SET-SIZE(psFilename) = 255.
    PUT-BYTE(psFilename, 1) = 0.

    /* D:   Dateiauswahl fuer Report Definitionsdatei (Auswahl+Neueingabe erlaubt)*/
    /* US: Fileopen dialog for report definition file (existing+new files allowed)*/
    run LlSelectFileDlgTitleEx (output nRet, hJob, 0
                                , "Select existing or specify new report file"
                                , {&LL_PROJECT_LIST} + {&LL_FILE_ALSONEW}
                                , input-output psFilename, 255
                                , 0).
        
    IF nRet = {&LL_ERR_USER_ABORTED} THEN
    DO:
        run LlJobClose(hJob).
        RETURN.
    END.

    /* D:   Designer starten */
    /* US: Start designer */
    run LlDefineLayout (output nRet, hJob, 0, "Designer"
                        , {&LL_PROJECT_LIST}, GET-STRING(psFilename, 1)).

    /* D:   List & Label Job schliessen */
    /* US: Close List & Label job */
    run LlJobClose(hJob).

END.

/* _UIB-CODE-BLOCK-END */
&ANALYZE-RESUME


&Scoped-define SELF-NAME BUTTON-2
&ANALYZE-SUSPEND _UIB-CODE-BLOCK _CONTROL BUTTON-2 Dialog-Frame
ON CHOOSE OF BUTTON-2 IN FRAME Dialog-Frame /* Print ... */
/*=====================================================================================
D:   Diese Funktion druckt alle Datensaetze der Customer Tabelle
US: This function prints all records of the Customer table
=====================================================================================*/

DO:
    def var hJob as integer.                                                              
    def var nRet as integer.
    def var nRecno as integer.
    def var bToPreview as logical.
    def var sBoxText as character.
    def var psFilename as memptr.

    /* D:   List & Label Job oeffnen */
    /* US: Open List & Label job */
    run LlJobOpen(output hJob, {&CMBTLANG_DEFAULT}).

    /* D:   Optionen setzen */
    /* US: Set options */
    run LlSetOption(output nRet, hJob, {&LL_OPTION_MULTIPLETABLELINES}, 1).

    /* D:   Debugging einschalten (das mit List & Label mitgeliefertes DEBWIN     */
    /*     starten, um die Ausgaben zu erhalten!)			                     */
    /* US: Enable debugging (DEBWIN  that came with List & Label must be         */
    /*     started to receive debug messages				                    */
    /* run LlSetDebug(1). */

    /* D:   Variablen und Felder zuruecksetzen */
    /* US: reset variables and fields */
    run LlDefineVariableStart(hJob).
    run LlDefineFieldStart(hJob).
    
    /* D:   Variablen und Felder mit Beispiel-Daten fuer Syntax-Check definieren (hier der 1. Datensatzinhalt) */
    /* US: Define variables and fields with sample-data for syntax check (here contents of 1st. record) */
    FIND FIRST Customer.
    run LlDefineField (output nRet, hJob, "Customer.Name",    Customer.Name).
    run LlDefineField (output nRet, hJob, "Customer.Phone",   Customer.Phone).
    run LlDefineField (output nRet, hJob, "Customer.Contact", Customer.Contact).
    run LlDefineField (output nRet, hJob, "Customer.Address", Customer.Address).
    run LlDefineField (output nRet, hJob, "Customer.City",    Customer.City).
    run LlDefineFieldExt(output nRet, hJob, "Customer.Zip",   STRING(Customer.Zip), {&LL_NUMERIC}, 0).

    /* D:   Initialisiere Puffer fuer Dateiauswahl */
    /* US: Initialize buffer for fileopen dialog */
    SET-SIZE(psFilename) = 255.
    PUT-BYTE(psFilename, 1) = 0.

    /* D:   Dateiauswahl fuer Report Definitionsdatei */
    /* US: Fileopen dialog for report definition file */
    run LlSelectFileDlgTitleEx (output nRet, hJob, 0
                                , "Select a report file to be printed"
                                , {&LL_PROJECT_LIST}
                                , input-output psFilename, 255
                                , 0).

    IF nRet = {&LL_ERR_USER_ABORTED} THEN
    DO:
        run LlJobClose(hJob).
        RETURN.
    END.

    /* D:   Druck starten */
    /* US: Start printing */
    run LlPrintWithBoxStart(output nRet, hJob, {&LL_PROJECT_LIST}
                            , GET-STRING(psFilename, 1), {&LL_PRINT_USERSELECT}
                            , {&LL_BOXTYPE_EMPTYABORT}, 0, "Printing CUSTOMER List.").

    /* D:   Druckoptionen setzen */
    /* US: Set print options */
    run LlPrintSetOption(output nRet, hJob, {&LL_PRNOPT_PRINTDLG_DEST}, {&LL_DESTINATION_PRV}).
    run LlPrintSetOption(output nRet, hJob, {&LL_PRNOPT_PRINTDLG_ONLYPRINTERCOPIES}, 1).

    /* D:   Dialog fuer Druckereinstellungen anzeigen */
    /* US: Show print options dialog */
    run LlPrintOptionsDialog(output nRet, hJob, 0, "Configure Printing Options").

    IF nRet = {&LL_ERR_USER_ABORTED} THEN
    DO:
        run LlPrintEnd (output nRet, hJob, 0).
        run LlJobClose(hJob).
        RETURN.
    END.

    run LlPrintGetOption(output nRet, hJob, {&LL_PRNOPT_PRINTDLG_DEST}).
    IF nRet = {&LL_DESTINATION_PRV} THEN
        bToPreview = TRUE.
    ELSE
        bToPreview = FALSE.    

    /* D:   Variablen drucken */
    /* US: Print variables */
    run LlPrint(output nRet, hJob).
    
    /* D:   Durchlaufen aller Datensaetze der Customer-Tabelle */
    /* US: Iterate over all records of the Customer table */
    nRecno = 0.
    FOR EACH Customer BY Name:
        
        /* D:   Fortschrittsanzeige aktualisieren */
        /* US: Update meterbar */
        nRecno = nRecno + 1.
        sBoxText = "Record " + STRING(nRecno).
        run LlPrintSetBoxText (output nRet, hJob, sBoxText, 0).
        IF nRet = {&LL_ERR_USER_ABORTED} THEN
            LEAVE.       

        /* D:   Felder mit Echtdaten aus aktuellem Datensatz fuellen */
        /* US: Fill fields with data from current record */
        run LlDefineField (output nRet, hJob, "Customer.Name",    Name).
        run LlDefineField (output nRet, hJob, "Customer.Phone",   Phone).
        run LlDefineField (output nRet, hJob, "Customer.Contact", Contact).
        run LlDefineField (output nRet, hJob, "Customer.Address", Address).
        run LlDefineField (output nRet, hJob, "Customer.City",    City).
        run LlDefineFieldExt(output nRet, hJob, "Customer.Zip",   STRING(Zip), {&LL_NUMERIC}, 0).

        /* D:   Datensatz drucken */
        /* US: Print record */
        run LlPrintFields (output nRet, hJob).

        IF nRet < 0 AND nRet <> {&LL_WRN_REPEAT_DATA} THEN
            LEAVE.      /* Error! */

        /* D:   Wenn Seite voll, dann Seitenwechsel und Datensatz erneut drucken */
        /* US: If page full then force new page an print record again */
        DO WHILE nRet = {&LL_WRN_REPEAT_DATA}:
            run LlPrint(output nRet, hJob).
            run LlPrintFields (output nRet, hJob).
        END.
        
    END.

    IF nRet < 0 THEN
    DO:
        /* Error! */
    END.
    ELSE
    DO:
        /* D:   Drucke Fusszeilen */
        /* US: Print footer */
        nRet = {&LL_WRN_REPEAT_DATA}.
        DO WHILE nRet = {&LL_WRN_REPEAT_DATA}:
            run LlPrintFieldsEnd (output nRet, hJob).
        END.
    END.

    /* D:   Druck beenden */
    /* US: End print job */
    run LlPrintEnd (output nRet, hJob, 0).

    /* D:   Fuer Preview-Druck Vorschau anzeigen und Preview-Datei loeschen */
    /* US: In preview mode display preview and delete temporary files */
    IF bToPreview = TRUE THEN
    DO:
        run LlPreviewDisplay (output nRet, hJob, GET-STRING(psFilename, 1), "", 0).
        run LlPreviewDeleteFiles (output nRet, hJob, GET-STRING(psFilename, 1), "").
    END.
    
    /* D:   List & Label Job schliessen */
    /* US: Close List & Label job */
    run LlJobClose(hJob).
  
END.

/* _UIB-CODE-BLOCK-END */
&ANALYZE-RESUME


&UNDEFINE SELF-NAME

&ANALYZE-SUSPEND _UIB-CODE-BLOCK _CUSTOM _MAIN-BLOCK Dialog-Frame 


/* ***************************  Main Block  *************************** */

/* Parent the dialog-box to the ACTIVE-WINDOW, if there is no parent.   */
IF VALID-HANDLE(ACTIVE-WINDOW) AND FRAME {&FRAME-NAME}:PARENT eq ?
THEN FRAME {&FRAME-NAME}:PARENT = ACTIVE-WINDOW.


/* Now enable the interface and wait for the exit condition.            */
/* (NOTE: handle ERROR and END-KEY so cleanup code will always fire.    */
MAIN-BLOCK:
DO ON ERROR   UNDO MAIN-BLOCK, LEAVE MAIN-BLOCK
   ON END-KEY UNDO MAIN-BLOCK, LEAVE MAIN-BLOCK:
  RUN enable_UI.
  WAIT-FOR GO OF FRAME {&FRAME-NAME}.
END.
RUN disable_UI.

/* _UIB-CODE-BLOCK-END */
&ANALYZE-RESUME


/* **********************  Internal Procedures  *********************** */

&ANALYZE-SUSPEND _UIB-CODE-BLOCK _PROCEDURE disable_UI Dialog-Frame  _DEFAULT-DISABLE
PROCEDURE disable_UI :
/*------------------------------------------------------------------------------
  Purpose:     DISABLE the User Interface
  Parameters:  <none>
  Notes:       Here we clean-up the user-interface by deleting
               dynamic widgets we have created and/or hide 
               frames.  This procedure is usually called when
               we are ready to "clean-up" after running.
------------------------------------------------------------------------------*/
  /* Hide all frames. */
  HIDE FRAME Dialog-Frame.
END PROCEDURE.

/* _UIB-CODE-BLOCK-END */
&ANALYZE-RESUME

&ANALYZE-SUSPEND _UIB-CODE-BLOCK _PROCEDURE enable_UI Dialog-Frame  _DEFAULT-ENABLE
PROCEDURE enable_UI :
/*------------------------------------------------------------------------------
  Purpose:     ENABLE the User Interface
  Parameters:  <none>
  Notes:       Here we display/view/enable the widgets in the
               user-interface.  In addition, OPEN all queries
               associated with each FRAME and BROWSE.
               These statements here are based on the "Other 
               Settings" section of the widget Property Sheets.
------------------------------------------------------------------------------*/
  ENABLE BUTTON-1 BUTTON-2 
      WITH FRAME Dialog-Frame.
  {&OPEN-BROWSERS-IN-QUERY-Dialog-Frame}
END PROCEDURE.

/* _UIB-CODE-BLOCK-END */
&ANALYZE-RESUME


// Revision: 30.08.2020
#INCLUDE cmbtll26.h
CLASS LL26InterfaceSample OF OBJECT
   this.hJob        =0                    //LL-Jobhandle
   //D: Fenster-Handle des aufrufenden Dialogs
   //E: Window-handle of calling dialog
   this.ParentHandle=0
   //D: Datenobjekt-Array mit verknüften Datensatzbereichen
   //E: Data-Array with related Rowsets
   this.Relations   =new ARRAY()
   //D: Hauptdatensatzbereich
   //E: Main Rowset
   this.rowset      =NULL
   //D: Dateierweiterung für Projektdatei
   //E: Fileextension of Projectfile
   this.Extension   =""
   //D: Dateiname der Projektdatei
   //E: Filename of Projectfile
   this.Filename    =""
   //D: Spracheinstellung für LL-DLL
   //E: Language of LL_DLL
   DO CASE
      CASE _app.oInfo.Language="deutsch"
         this.Language    =CMBTLANG_GERMAN
      CASE _app.oInfo.Language="english"
         this.Language    =CMBTLANG_ENGLISH
      OTHERWISE
         this.Language    =CMBTLANG_DEFAULT
   ENDCASE
   //D: Flag für Designmodus
   //E: Flag, whether LL opens in design-mode
   this.Design      =false
   //D: Vorgabe für Projektart
   //E: Default project
   this.ProjectMode =LL_PROJECT_LIST
   //D: Flag, ob die Auswahl von Kopien im Druckdialog angezeigt wird
   //E: Flag, whether the user can select copies
   this.HideCopies  =false
   //D: Flag, ob Seitenauswahl unterstützt wird
   //E: Flag, whether the user can select begin- and end-page
   this.HideSelection  =true
   //D: Flag, ob Auswahl der Druckvorlage ermöglicht wird
   //E: Flag, whether the user can select template
   this.HidePages   =false
   //D: Array zur Variablendefinition, d.h. Werte die nicht aus der Datenbasis generiert werden
   //   Enthält Sub-Arrays mit folgendem Aufbau {<Variablenname>,<Wert>,<Variablentyp> [,Dezimalstellen]}
   //E: Array for declaration of fixed variables (which are independent from database)
   //   Contains sub-arrays with following structure {<name>,<value>,<type> [,decimalLength]}
   this.UserVars=new ARRAY()
   //D: Flag, ob Berichtscontainer auch für einzelnen Tabellen verwendet wird
   //E: Flag, whether to use reportcontainer also for standalone tables
   this.ReportContainer=false
   //D: Flag, ob unbekannte Feldtypen eine Meldung erfolgt
   //E: Flag, whether to show a message, if unknown fieldtypes are used
   this.MainAsMaster=false
   //D: Flag, ob Hauptdatensatzbereich als Master-Bereich verwendet wird
   //E: Flag, whether to use the Main-Rowset as Master
   this.ShowUnknownFieldTypes=.NOT. "runtime"$LOWER(VERSION(1))
   
   this.LizenzInfo=""

   FUNCTION LoadExternLibrary
   LOCAL cError
   cError=""
   //Windows-API
   EXTERN CHANDLE GetActiveWindow(CVOID) user32
   EXTERN CHANDLE SetFocus(CHANDLE) user32
   //LL-API
   TRY
      EXTERN CLONG      LlDbAddTable(CLONG, CSTRING, CSTRING) CMLL26.DLL FROM "LlDbAddTableA"
      EXTERN CLONG      LlDbAddTableRelation(CLONG, CSTRING, CSTRING, CSTRING, CSTRING) CMLL26.DLL FROM "LlDbAddTableRelationA"
      EXTERN CLONG      LlDbSetMasterTable(CLONG, CSTRING) CMLL26.DLL FROM "LlDbSetMasterTableA"
      EXTERN CLONG      LlDefineFieldExt(CLONG, CSTRING, CSTRING, CLONG, CPTR) CMLL26.DLL FROM "LlDefineFieldExtA"
      EXTERN CVOID      LlDefineFieldStart(CLONG) CMLL26.DLL FROM "LlDefineFieldStart"
      EXTERN CLONG      LlDefineLayout(CLONG, CHANDLE, CSTRING, CULONG, CSTRING) CMLL26.DLL FROM "LlDefineLayoutA"
      EXTERN CLONG      LlDefineVariableExt(CLONG, CSTRING, CSTRING, CLONG, CPTR) CMLL26.DLL FROM "LlDefineVariableExtA"
      EXTERN CVOID      LlDefineVariableStart(CLONG) CMLL26.DLL FROM "LlDefineVariableStart"
      EXTERN CULONG     LlGetOption(CLONG, CLONG) CMLL26.DLL FROM "LlGetOption"
      EXTERN CLONG      LlGetOptionString(CLONG, CLONG, CSTRING, CULONG) CMLL26.DLL FROM "LlGetOptionStringA"
      EXTERN CLONG      LlJobOpen(CLONG) CMLL26.DLL FROM "LlJobOpen"
      EXTERN CVOID      LlJobClose(CLONG) CMLL26.DLL FROM "LlJobClose"
      EXTERN CLONG      LlPrint(CLONG) CMLL26.DLL FROM "LlPrint"
      EXTERN CLONG      LlPrintDbGetCurrentTable(CLONG, CSTRING, CULONG, CLOGICAL) CMLL26.DLL FROM "LlPrintDbGetCurrentTableA"
      EXTERN CLONG      LlPrintDbGetCurrentTableRelation(CLONG, CSTRING, CULONG) CMLL26.DLL FROM "LlPrintDbGetCurrentTableRelationA"
      EXTERN CLONG      LlPrintEnd(CLONG, CLONG) CMLL26.DLL FROM "LlPrintEnd"
      EXTERN CLONG      LlPrintFields(CLONG) CMLL26.DLL FROM "LlPrintFields"
      EXTERN CLONG      LlPrintFieldsEnd(CLONG) CMLL26.DLL FROM "LlPrintFieldsEnd"
      EXTERN CLONG      LlPrintGetOption(CLONG, CLONG) CMLL26.DLL FROM "LlPrintGetOption"
      EXTERN CLONG      LlPrintGetOptionString(CLONG, CLONG, CSTRING, CULONG) CMLL26.DLL FROM "LlPrintGetOptionStringA"
      EXTERN CLONG      LlPrintOptionsDialog(CLONG, CHANDLE, CSTRING) CMLL26.DLL FROM "LlPrintOptionsDialogA"
      EXTERN CLONG      LlPrintSetBoxText(CLONG, CSTRING, CLONG) CMLL26.DLL FROM "LlPrintSetBoxTextA"
      EXTERN CLONG      LlPrintSetOption(CLONG, CLONG, CLONG) CMLL26.DLL FROM "LlPrintSetOption"
      EXTERN CLONG      LlPrintSetOptionString(CLONG, CLONG, CSTRING) CMLL26.DLL FROM "LlPrintSetOptionStringA"
      EXTERN CLONG      LlPrintWithBoxStart(CLONG, CULONG, CSTRING, CLONG, CLONG, CHANDLE, CSTRING) CMLL26.DLL FROM "LlPrintWithBoxStartA"
      EXTERN CLONG      LlSelectFileDlgTitleEx(CLONG, CHANDLE, CSTRING, CULONG, CSTRING, CULONG, CPTR) CMLL26.DLL FROM "LlSelectFileDlgTitleExA"
      EXTERN CLONG      LlSetFileExtensions(CLONG, CLONG, CSTRING, CSTRING, CSTRING) CMLL26.DLL FROM "LlSetFileExtensionsA"
      EXTERN CLONG      LlSetOption(CLONG, CLONG, CULONG) CMLL26.DLL FROM "LlSetOption"
      EXTERN CLONG      LlSetOptionString(CLONG, CLONG, CSTRING) CMLL26.DLL FROM "LlSetOptionStringA"
      EXTERN CLONG      LlPreviewDeleteFiles(CLONG, CSTRING, CSTRING) CMLL26.DLL FROM "LlPreviewDeleteFilesA"
      EXTERN CLONG      LlPreviewDisplay(CLONG, CSTRING, CSTRING, CHANDLE) CMLL26.DLL FROM "LlPreviewDisplayA"
   CATCH(exception e)
      DO CASE
         CASE TYPE("_app.language")=="C" .AND. _app.language="DE"
            cError="Fehler beim Laden der Funktionsbibliothek"
         OTHERWISE
            cError="Cannot load function library"
      ENDCASE
   ENDTRY
   RETURN cError

   FUNCTION Render
   LOCAL cError
   LOCAL cTemplate
   LOCAL cPrint
   LOCAL cView
   LOCAL cOldDir
   LOCAL X
   LOCAL cChildName
   LOCAL cParentName
   LOCAL nError
   LOCAL nRet

   cError=""

   //D: Prüfen ob Funktionsbibliothek schon geladen
   //E: Check, whether the function library is already loaded
   IF .NOT. TYPE("LLJobOpen")=="FP"
      cError=CLASS::LoadExternLibrary()
   ENDIF
   IF EMPTY(cError)
      cOldDir=SET("DIRECTORY")
      //D: Fensterhandle des aktuell geöffneten Dialogs merken
      //E: Save window-handle of actual dialog
      this.ParentHandle=GetActiveWindow()
      IF EMPTY((this.ParentHandle))
         this.ParentHandle=_app.frameWin.hwnd
      ENDIF
      //D: List & Label Job Handle abholen
      //E: Retrieve List & Label job handle
      this.hJob = LlJobOpen((this.Language))
      //D: Dateinamen und Erweiterung normalisieren
      //E: Normalisize filename and extension
      IF EMPTY(this.Extension)
         IF "."$this.Filename
            this.Extension=RIGHT(this.Filename,LEN(this.Filename)-AT(".",this.Filename))
         ELSE
            this.Extension="LST"
         ENDIF
      ENDIF
      this.Extension=UPPER(RIGHT("."+this.Extension,4))
      IF EMPTY(this.Filename)
         this.Filename="*."+this.Extension
      ENDIF
      this.HideSelection=this.HideSelection .OR. ("*"$this.Filename .OR. "?"$this.Filename)
      IF this.HideSelection
         IF LEN(this.Filename)<5 .OR. .NOT. UPPER(RIGHT(this.Filename,4))==this.Extension
            this.Filename+=this.Extension
         ENDIF
      ENDIF
      //D: Projektart in Abhängigkeit von der Dateierweiterung festlegen
      //E: Select project-mode
      LLSetOptionString((this.hJob),LL_OPTIONSTR_LICENSINGINFO,(this.LizenzInfo))
      DO CASE
         CASE this.Extension$".LST"
            this.ProjectMode=LL_PROJECT_LIST
         CASE this.Extension$".CRD"
            this.ProjectMode=LL_PROJECT_CARD
         CASE this.Extension$".LBL"
            this.ProjectMode=LL_PROJECT_LABEL
         CASE this.Extension$".SUB"
            this.ProjectMode=LL_PROJECT_LIST
      ENDCASE
      IF .NOT. this.Extension$".LST .CRD .LBL"
         //D: Dateierweiterungen für Vorschau- und Druckdatei festlegen
         //E: Set extension for preview and printer-configuration file
         cTemplate=RIGHT(this.Extension,3)
         cPrint   =LEFT(cTemplate,2)+"P"
         cView    =LEFT(cTemplate,2)+"V"
         nError   =LLSetFileExtensions((this.hJob),(this.ProjectMode),cTemplate,cPrint,cView)
      ENDIF
      //D: Navigation unterdrücken
      //E: Suppress navigation
      this.rowset.NotifyControlsState=this.rowset.notifyControls
      this.rowset.notifyControls=false
      IF this.Relations.size>0
         //D: Relational verknüpfte Datensatzbereiche anmelden
         //E: Set all related database objects
         FOR X=1 TO this.Relations.size
            IF X=1
               //D: Puffer löschen
               //E: clear buffer
               nError=LlDbAddTable((this.hJob),"",NULL)
               //D: Hauptdatensatzbereich anmelden
               //E: set main dataobject
               nError=LlDbAddTable((this.hJob),this.rowset.parent.name,NULL)
            ELSE
               //D: Weitere Datensatzbereiche
               //E: Other rowsets
               IF .NOT. EMPTY(this.Relations[X].parent.masterSource)
                  this.MainAsMaster=true
               ENDIF
               IF .NOT. EMPTY(this.Relations[X].parent.rowset.masterRowset)
                  this.MainAsMaster=true
               ENDIF
            ENDIF
            cChildName =this.Relations[X].parent.name
            nError=LlDbAddTable((this.hJob),cChildName,NULL)
            DO CASE
               CASE .NOT. EMPTY(this.Relations[X].parent.masterSource)
                  cParentName=this.Relations[X].parent.masterSource.parent.name
                  nError=LlDbAddTableRelation((this.hJob),cChildName,cParentName,cChildName+"2"+cParentName,NULL)
               CASE .NOT. EMPTY(this.Relations[X].masterRowset)
                  cParentName=this.Relations[X].masterRowset.parent.name
                  nError=LlDbAddTableRelation((this.hJob),cChildName,cParentName,cChildName+"2"+cParentName,NULL)
            ENDCASE
            this.Relations[X].NotifyControlsState=this.Relations[X].notifyControls
            this.Relations[X].notifyControls=false
         NEXT
         IF this.MainAsMaster
            nError=LlDbSetMasterTable((this.hJob),this.rowset.parent.name)
         ENDIF
      ELSE
         IF this.ReportContainer
            //D: Immer Berichtscontainer verwenden
            //E: Always use report container
            nError=LlDbAddTable((this.hJob),"",NULL)
            //D: Hauptdatensatzbereich anmelden
            //E: set main dataobject
            nError=LlDbAddTable((this.hJob),this.rowset.parent.name,NULL)
         ENDIF
      ENDIF
      IF this.ProjectMode=LL_PROJECT_LIST
         LlSetOption((this.hJob),LL_OPTION_ADDVARSTOFIELDS,1)
      ENDIF
      LlSetOption((this.hJob),LL_OPTION_SORTVARIABLES,  1)
      //D: DLL-internen Variablenpuffer löschen
      //E: Clear DLL internal variable buffer
      LlDefineVariableStart((this.hJob))
      //D: DLL-internen Feldpuffer löschen
      //E: Clear DLL internal field buffer
      LlDefineFieldStart((this.hJob))
      IF this.Design
         IF TYPE("_app.oInfo.RibbonDesigner")=="L"
            //D: Benutzerdefinierte Ribbon-Einstellung setzen
            //E: Set user-defined ribbon settings
            LlSetOption((this.hJob),LL_OPTION_RIBBON_DEFAULT_ENABLEDSTATE,IIF(_app.oInfo.RibbonDesigner,1,0))
         ENDIF
         IF this.ProjectMode=LL_PROJECT_LIST
            CLASS::DesignList()
         ELSE
            CLASS::DesignLabel()
         ENDIF
         IF TYPE("_app.oInfo.RibbonDesigner")=="L"
            //D: Ribbon-Einstellungen zurückschreiben, falls vom Benutzer geändert
            //E: Write back Ribbon-settings, if changed in LLDialog
            nRet=LlGetOption((this.hJob),LL_OPTION_RIBBON_DEFAULT_ENABLEDSTATE)
            DO CASE
               CASE nRet=0
                  _app.oInfo.RibbonDesigner=false
               CASE nRet=1
                  _app.oInfo.RibbonDesigner=true
            ENDCASE
         ENDIF
      ELSE
         IF TYPE("_app.oInfo.RibbonViewer")=="L"
            //D: Benutzerdefinierte Ribbon-Einstellung setzen
            //E: Set user-defined ribbon settings
            LlSetOption((this.hJob),LL_OPTION_RIBBON_DEFAULT_ENABLEDSTATE,IIF(_app.oInfo.RibbonViewer,1,0))
         ENDIF
         IF this.ProjectMode=LL_PROJECT_LIST
            CLASS::PrintList()
         ELSE
            CLASS::PrintLabel()
         ENDIF
         IF TYPE("_app.oInfo.RibbonViewer")=="L"
            //D: Ribbon-Einstellungen zurückschreiben, falls vom Benutzer geändert
            //E: Write back Ribbon-settings, if changed in LLDialog
            nRet=LlGetOption((this.hJob),LL_OPTION_RIBBON_DEFAULT_ENABLEDSTATE)
            DO CASE
               CASE nRet=0
                  _app.oInfo.RibbonViewer=false
               CASE nRet=1
                  _app.oInfo.RibbonViewer=true
            ENDCASE
         ENDIF
      ENDIF
      //D: List & Label Job beenden
      //E: End List & Label job
      LlJobClose((this.hJob))
      //D: Ausgangsdialog aktivieren
      //E: Activate calling dialog
      SetFocus((this.ParentHandle))
      SET DIRECTORY TO (cOldDir)
      //D: Navigation wieder auf Ausgangszustand zurücksetzen
      //E: Set navigation to starting state
      this.rowset.notifyControls=this.rowset.NotifyControlsState
      FOR X=1 TO this.Relations.size
         this.Relations[X].notifyControls=this.Relations[X].NotifyControlsState
      NEXT
   ELSE
      MSGBOX(cError,"",16)
   ENDIF
   RETURN cError

   FUNCTION DefineUser
   LOCAL X
   LOCAL cVarName
   LOCAL cVarType
   LOCAL nLLVarType
   LOCAL xValue
   FOR X=1 TO this.UserVars.size
      cVarName=this.UserVars[X][1]
      cVarType=this.UserVars[X][3]
      nLLVarType=999
      //D: dBASE Variablentypen in List & Label Variablentypen übersetzen
      //E: Translate dBASE var types to List & Label var types
      DO CASE
         CASE cVarType=='LOGICAL'
            nLLVarType=LL_BOOLEAN
            xValue=IIF(EMPTY(this.UserVars[X][2]),"false","true")
         CASE cVarType=='MEMO' .OR. cVarType=='CHARACTER'
            nLLVarType=LL_TEXT
            xValue=this.UserVars[X][2]
         CASE cVarType=='DATE'
            nLLVarType=LL_DATE_YYYYMMDD
            xValue      =DTOS(this.UserVars[X][2])
         CASE cVarType=='DATETIME'
            nLLVarType=LL_TEXT
            xValue      =DTTOC(this.UserVars[X][2])
         CASE cVarType=="FLOAT" .OR. cVarType=="NUMERIC"
            nLLVarType=LL_NUMERIC_LOCALIZED
            xValue      =LTRIM(STR(this.UserVars[X][2],20,IIF(EMPTY(this.UserVars[X][4]),0,this.UserVars[X][4])))
         CASE cVarType=="LONG" .OR. cVarType=="DOUBLE" .OR. cVarType=="AUTOINC"
            nLLVarType=LL_NUMERIC
            xValue=LTRIM(STR(this.UserVars[X][2],20,0))
         CASE cVarType="OLE"
            //D: in dieser Schnittstelle nicht verfügbar
            //E: not supported in this interface calss
         CASE cVarType="BINARY"
            //D: in dieser Schnittstelle nicht verfügbar
            //E: not supported in this interface calss
      ENDCASE
      IF nLLVarType#999          
         //D: Als Variable anmelden
         //E: Declare as variable
         LlDefineVariableExt((this.hJob),cVarName,xValue,nLLVarType,"")
      ENDIF
   NEXT
   RETURN

   FUNCTION DefineData(oRowset,lAsFields,cPrefix)
   //D: Wird verwendet, um Felder und Variablen bei List & Label anzumelden
   //E: Is used to declare fields and variables to List & Label
   LOCAL nLLFieldType
   LOCAL i
   LOCAL cFieldname
   LOCAL cFieldType
   LOCAL xValue
   LOCAL cTable
   LOCAL nLLFieldType
   LOCAL cString
   LOCAL X
   LOCAL cRealType

   //D: Für alle Felder wiederholen
   //E: Loop for all fields
   DO CASE
      CASE .NOT. EMPTY(cPrefix)
         cTable=cPrefix
      CASE this.Relations.size>0
         cTable=oRowset.parent.name+"."
      OTHERWISE
         cTable=""
   ENDCASE
   FOR I=1 TO oRowset.fields.size
      cFieldName  =cTable+oRowset.fields[i].fieldname
      cFieldType  =UPPER(oRowset.fields[i].type)
      nLLFieldType=999
      //D: dBASE Feldtypen in List & Label Feldtypen übersetzen
      //E: Translate dBASE field types to List & Label field types
      DO CASE
         CASE cFieldType=='LOGICAL' .OR. cFieldType=='BOOLEAN'
            nLLFieldType=LL_BOOLEAN
            xValue=IIF(EMPTY(oRowset.fields[i].value),"false","true")     
         CASE cFieldType=='CHARACTER' .OR. LEFT(cFieldType,4)$'MEMO BLOB' .OR. cFieldType=='VARCHAR' .OR. cFieldType=='WCHAR' .OR. cFieldType=='VARWCHAR' .OR. cFieldType=='CHAR'
            nLLFieldType=LL_TEXT
            xValue=IIF(EMPTY(oRowset.fields[i].value),"",oRowset.fields[i].value)
         CASE cFieldType$'DBDATE'
            nLLFieldType=LL_DATE_YYYYMMDD
            xValue      =DTOS(oRowset.fields[i].value)
         CASE 'DATETIME'$cFieldType .OR. 'TIMESTAMP'$cFieldType
            nLLFieldType=LL_TEXT
            xValue      =DTTOC(oRowset.fields[i].value)
         CASE cFieldType=='FLOAT' .OR. cFieldType=='NUMERIC' .OR. cFieldType=='DECIMAL'  .OR. cFieldType=='REAL'
            nLLFieldType=LL_NUMERIC
            TRY
               xValue      =LTRIM(STR(oRowset.fields[i].value,20,IIF(EMPTY(oRowset.fields[i].decimalLength),0,oRowset.fields[i].decimalLength)))
            CATCH (exception e)
               xValue      =LTRIM(STR(oRowset.fields[i].value,20,SET("DECIMALS")))
            ENDTRY
         CASE cFieldType=='LONG' .OR. cFieldType=='DOUBLE' .OR. cFieldType=='AUTOINC' .OR. cFieldType=='SMALLINT'  .OR. cFieldType=='INTEGER'  .OR. cFieldType=='BIGINT'
            nLLFieldType=LL_NUMERIC
            xValue=LTRIM(STR(oRowset.fields[i].value,20,0))
         CASE cFieldType="ALPHA"  //Paradox-Alpha Felder
            nLLFieldType=LL_TEXT
            xValue      =IIF(EMPTY(xValue),"",xValue)
         CASE cFieldType=='OLE'
            //D: in dieser Schnittstelle nicht verfügbar
            //E: not supported in this interface class
         CASE cFieldType=='BINARY'
            //D: in dieser Schnittstelle nicht verfügbar
            //E: not supported in this interface class
         CASE cFieldType=='LONGVARCHAR'
            nLLFieldType=LL_TEXT
            xValue=IIF(EMPTY(oRowset.fields[i].value),"",oRowset.fields[i].value)
         CASE cFieldType=='TIME'
            nLLFieldType=LL_TEXT
            xValue=IIF(EMPTY(oRowset.fields[i].value),"",TTOC(oRowset.fields[i].value))
         CASE cFieldType=='LONGVARBINARY'
            //D: in dieser Schnittstelle nicht verfügbar
            //E: not supported in this interface class
         CASE UPPER(cFieldType)='ZEICHEN'
            //D: 'echte' Kalkualtionsfelder
            //E: native calculated fields
            cRealType=CLASS::ValType(xValue)
            DO CASE
               CASE cRealType=="CHARACTER"
                  nLLFieldType   =LL_TEXT
                  xValue=IIF(EMPTY(xValue),"",xValue)
               CASE cRealType=="DATE"
                  nLLFieldType   =LL_DATE_YYYYMMDD
                  xValue=DTOS(xValue)
               CASE cRealType=="LOGICAL"
                  nLLFieldType   =LL_BOOLEAN
                  xValue=IIF(EMPTY(xValue),"false","true")
               CASE cRealType=="NUMERIC"
                  nLLFieldType   =LL_NUMERIC_LOCALIZED
                  xValue=LTRIM(STR(xValue,20,IIF(EMPTY(nDecimals),0,nDecimals)))
               OTHERWISE
                  nLLFieldType   =LL_TEXT
                  xValue="<ungültiger Feldtyp>"
            ENDCASE
         OTHERWISE
            IF this.ShowUnknownFieldTypes
               IF _app.language="DE"
                  MSGBOX("Unbekannter Feldtyp: "+cFieldType,cFieldname)
               ELSE
                  MSGBOX("Unknown fieldtype: "+cFieldType,cFieldname)
               ENDIF
            ENDIF
      ENDCASE
      IF nLLFieldType#999
         IF EMPTY(lAsFields) 
            //D: Als Variable anmelden
            //E: Declare as variable
            LlDefineVariableExt((this.hJob),cFieldName,xValue,nLLFieldType,"")
         ELSE
            //D: Als Feld anmelden
            //E: Declare as field
            LlDefineFieldExt((this.hJob),cFieldName,xValue,nLLFieldType,"")
         ENDIF
      ENDIF
   NEXT
   //D: Felder in untergeordneten Datensatzbereichen anmelden
   //E: Declare related rowsets
   FOR X=1 TO this.Relations.size
      IF EMPTY(this.Relations[X].parent.masterSource)
         IF this.Relations[X].masterRowset.parent.name=oRowset.parent.name
            CLASS::DefineData((this.Relations[X]),lAsFields,cTable+this.Relations[X].parent.name+".")
          ENDIF
      ELSE
         IF this.Relations[X].parent.masterSource.parent.name=oRowset.parent.name
            CLASS::DefineData((this.Relations[X]),lAsFields,cTable+this.Relations[X].parent.name+".")
          ENDIF
      ENDIF
   NEXT
   RETURN

   FUNCTION SelectFile
   //D: Öffnet einen Dateiauswahldialog
   //E: Starts a File-Selection dialog
   LOCAL nRet
   LOCAL cBuffer

   IF "\"$this.Filename
      cBuffer=this.Filename
   ELSE
      cBuffer=SET("DIRECTORY")
      cBuffer+=IIF(RIGHT(cBuffer,1)=="\","","\")+"LLDef\"+this.Filename
   ENDIF
   cBuffer=cBuffer+REPLICATE(CHR(0),255-LEN(cBuffer))
   this.Filename=cBuffer
   nRet=0
   IF EMPTY(this.HideSelection)
      nRet = LlSelectFileDlgTitleEx((this.hJob),;
                                    (this.ParentHandle),;
                                    IIF(_app.language="DE","Projektdatei auswählen","Select Projectfile"),;
                                    BITOR(this.ProjectMode, LL_FILE_ALSONEW),;
                                    cBuffer,;
                                    255,;
                                    NULL)
      IF .NOT. nRet=LL_ERR_USER_ABORTED
          this.Filename=TRIM(cBuffer)
      ENDIF
   ENDIF
   RETURN nRet

   FUNCTION DesignList
   //D: Ruft den Designer für Listen-Projekte auf
   //E: Calls designer for list projects
   LOCAL nRet
   LOCAL X

   nRet=0
   this.rowset.first()
   //D: Mehrfache Zeilendefinitionen einschalten
   //E: Enable multiple tablelines
   LlSetOption((this.hJob), LL_OPTION_MULTIPLETABLELINES,1)
   //D: Alle Felder anmelden
   //E: Declare all fields
   CLASS::DefineData((this.rowset),true)
   FOR X=1 TO this.Relations.size
      CLASS::DefineData((this.Relations[X]),true)
   NEXT
   //D: Benutzer Variablen anmelden
   //E: Declare all user variables
   CLASS::DefineUser()
   //D: Projektdatei auswählen
   //E: Choose project file
   nRet = CLASS::SelectFile()
   //D: Abbrechen, wenn vom Benutzer gewünscht
   //E: Cancel on user request
   IF .NOT. nRet = LL_ERR_USER_ABORTED 
      //D: Designer starten
      //E: Call designer
      LlDefineLayout((this.hJob),;
                     (this.ParentHandle),;
                     "Designer",;
                     LL_PROJECT_LIST,;
                     this.Filename)
   ENDIF
   RETURN

   FUNCTION DesignLabel
   //D: Ruft den Designer für Etiketten- und Karteikarten-Projekts
   //E: Calls designer for label and card projects
   LOCAL nRet

   nRet=0
   this.rowset.first()
   //D: Alle Variablen anmelden
   //E: Declare all variables
   CLASS::DefineData((this.rowset),false)
   FOR X=1 TO this.Relations.size
      CLASS::DefineData((this.Relations[X]),true)
   NEXT
   //D: Benutzer Variablen anmelden
   //E: Declare all user variables
   CLASS::DefineUser()
   //D: Projektdatei auswählen
   //E: Choose project file
   nRet = CLASS::SelectFile()
   //D: Abbrechen, wenn vom Benutzer gewünscht
   //E: Cancel on user request
   IF .NOT. nRet = LL_ERR_USER_ABORTED 
      //D: Designer starten
      //E: Call designer
      LlDefineLayout((this.hJob),(this.ParentHandle),"Designer",(this.ProjectMode),(this.Filename))
   ENDIF
   RETURN nRet

   FUNCTION PrintLabel
   //D: Ruft den Preview-Druck für Karteikarten und Etiketten-Projekte auf
   //E: Calls preview print for label projects
   LOCAL nDest
   LOCAL nRet
   LOCAL nCurrent
   LOCAL nCount
   LOCAL bmRecord

   nDest = LL_DESTINATION_PRV
   nRet=0
   this.rowset.first()
   //D: Alle Variablen anmelden
   //E: Declare all variables
   CLASS::DefineData((this.rowset),false)
   FOR X=1 TO this.Relations.size
      CLASS::DefineData((this.Relations[X]),true)
   NEXT
   //D: Benutzer Variablen anmelden
   //E: Declare all user variables
   CLASS::DefineUser()
   //D: Projektdatei auswählen
   //E: Choose project file
   nRet = CLASS::SelectFile()
   //D: Abbrechen, wenn vom Benutzer gewünscht
   //E: Cancel on user request
   IF .NOT. nRet = LL_ERR_USER_ABORTED 
      //D: List & Label Druckjob starten
      //E: Start List & Label printing job
      LlPrintWithBoxStart((this.hJob),;
                          (this.ProjectMode),;
                          (this.Filename),;
                          LL_PRINT_USERSELECT,;
                          LL_BOXTYPE_NORMALWAIT,;
                          (this.ParentHandle),;
                          IIF(_app.language="DE","Druckauswahl","Print to Preview"))
      IF this.HideCopies
         LlPrintSetOption((this.hJob), LL_PRNOPT_COPIES, LL_COPIES_HIDE)
      ENDIF
      IF this.HidePages
         LlPrintSetOption((this.hJob), LL_OPTION_PAGE, LL_PAGE_HIDE)
      ENDIF
      //D: Default-Ziel setzen
      //E: Set default target
      LlPrintSetOption((this.hJob),LL_PRNOPT_PRINTDLG_DEST,nDest)
      //D: Druckauswahldialog anzeigen
      //E: Show print options dialog
      nRet=LlPrintoptionsDialog((this.hJob),;
                                (this.ParentHandle),;
                                IIF(_app.language="DE","Druckereinstellungen","Configure printing parameters"))
      //D: Abbrechen, wenn vom Benutzer gewünscht
      //E: Cancel printing on user request
      IF nRet = LL_ERR_USER_ABORTED 
         LlPrintEnd((this.hJob), 0)
      ELSE
         //D: Gewünschtes Druckziel merken
         //E: Retrieve print destination
         nDest =LlPrintGetOption((this.hJob),LL_PRNOPT_PRINTDLG_DEST)
         nCount=this.rowset.count()
         nCurrent=0
         //D: Durch alle Datensätze iterieren und Variablen übergeben
         //E: Loop through all records, pass variables
         DO WHILE nCount>0 .AND. nRet=0 .AND. .NOT. this.rowset.endOfSet
            bmRecord=this.rowset.bookmark()
            //D: Puffer mit den Daten des aktuellen Datensatzes füllen
            //E: Fill buffer with data of actual record
            CLASS::DefineData((this.rowset),false)
            FOR X=1 TO this.Relations.size
               CLASS::DefineData((this.Relations[X]),true)
            NEXT
            //D: Etikett mit den definierten Variablen drucken
            //E: Print label with defined variables
            nRet= LlPrint((this.hJob))
			Do WHILE nRet =LL_WRN_REPEAT_DATA
				nRet =LlPrint((this.hJob))
			ENDDO	
            this.rowset.next()
            //D: Fortschrittsbox setzen
            //E: Update progress meter
            IF this.rowset.endOfSet .OR. .NOT. bmRecord=this.rowset.bookmark()
               nCurrent++
               LlPrintSetBoxText((this.hJob),IIF(_app.language="DE","Druckfortschritt","Printing"),100*nCurrent/nCount)
            ENDIF
         ENDDO
         //D: List & Label Druckjob beenden
         //E: End List & Label printing job
         LlPrintEnd((this.hJob), 0)
         //D: Vorschau anzeigen, wenn keine Fehler vorlagen und Preview gewählt war
         //E: Display preview if no errors occurred and preview was targeted
         IF nRet=0 AND nDest=LL_DESTINATION_PRV
            LlPreviewDisplay((this.hJob),(this.Filename),"",(this.ParentHandle))
            //D: Temporäre Vorschaudatei löschen
            //E: Delete temporary preview file
            LlPreviewDeleteFiles((this.hJob),(this.Filename),"")
         ENDIF
      ENDIF
   ENDIF
   RETURN

   FUNCTION PrintList
   //D: Ruft den Preview-Druck für Listen-Projekt simple.lst auf
   //E: Calls preview print for list project simple.lst
   LOCAL nRet
   LOCAL nDest
   LOCAL nCurrent
   LOCAL nCount
   LOCAL X
   LOCAL bmRecord

   nRet=0
   nDest = LL_DESTINATION_PRV
   //D: Mehrfache Zeilendefinitionen einschalten
   //E: Enable multiple tablelines
   LlSetOption((this.hJob), LL_OPTION_MULTIPLETABLELINES,1)
   this.rowset.first()
   //D: Alle Variablen anmelden
   //E: Declare all variables
   CLASS::DefineData((this.rowset),true)
   FOR X=1 TO this.Relations.size
      CLASS::DefineData((this.Relations[X]),true)
   NEXT
   //D: Benutzer Variablen anmelden
   //E: Declare all user variables
   CLASS::DefineUser()
   //D: Projektdatei auswählen
   //E: Choose project file
   nRet = CLASS::SelectFile()
   //D: Abbrechen, wenn vom Benutzer gewünscht
   //E: Cancel on user request
   IF .NOT. nRet=LL_ERR_USER_ABORTED 
      //D:  List & Label Druckjob starten
      //E: Start List & Label printing job
      LlPrintWithBoxStart((this.hJob),;
                          (this.ProjectMode),;
                          (this.Filename),;
                          LL_PRINT_USERSELECT,;
                          LL_BOXTYPE_NORMALWAIT,;
                          (this.ParentHandle),;
                          IIF(_app.language="DE","Druckauswahl","Print to Preview"))
      IF this.HideCopies
         LlPrintSetOption((this.hJob), LL_PRNOPT_COPIES, LL_COPIES_HIDE)
      ENDIF
      IF this.HidePages
         LlPrintSetOption((this.hJob), LL_OPTION_PAGE, LL_PAGE_HIDE)
      ENDIF
      //D: Default-Ziel setzen
      //E: Set default target
      LlPrintSetOption((this.hJob), LL_PRNOPT_PRINTDLG_DEST, nDest)
      //D: Druckauswahldialog anzeigen
      //E: Show print options dialog
      nRet=LlPrintOptionsDialog((this.hJob),;
                                (this.ParentHandle),;
                                IIF(_app.language="DE","Druckereinstellungen","Configure printing parameters"))
      LlPrintSetOption((this.hJob),LL_OPTION_PAGE,1)
      //D: Abbrechen, wenn vom Benutzer gewünscht
      //E: Cancel printing on user request
      IF nRet = LL_ERR_USER_ABORTED 
         LlPrintEnd((this.hJob), 0)
      ELSE
         //D: Gewünschtes Druckziel merken
         //E: Retrieve print destination
         nDest   =LlPrintGetOption((this.hJob), LL_PRNOPT_PRINTDLG_DEST)
         nCount  =this.rowset.count()
         nCurrent=0
         //D: Kopfzeile der ersten Seite drucken
         //E: Print header line of first page
         LlPrint((this.hJob))
         //D: Äüßere Schleife: wiederholen für jede Seite
         //E: Outer loop: repeat for each page
         DO WHILE nCount>0 .AND. nRet=0 .AND. .NOT. this.rowset.endOfSet
            //D: Innere Schleife: wiederholen für jeden Datensatz
            //E: inner loop: repeat for each record
            DO WHILE nRet=0 .AND. .NOT. this.rowset.endOfSet
               bmRecord=this.rowset.bookmark()
               //D: Felder definieren
               //E: Define Fields
               CLASS::DefineData((this.rowset),true)
               FOR X=1 TO this.Relations.size
                  CLASS::DefineData((this.Relations[X]),true)
               NEXT
               //D: Tabellenzeile mit den definierten Feldern drucken
               //E: Print line with defined fields
               nRet= LlPrintFields((this.hJob))
               //D: Untergeordnete Tabellenobjekte drucken, fall Berichtscontainer verwendet werden
               //E: Print related table-data, if report-containers in use
               IF nRet=LL_WRN_TABLECHANGE
                  nRet=CLASS::PrintSubTable()
               ENDIF
               //D: Fortschrittsbox setzen
               //E: Update progress meter
               this.rowset.next()
               IF this.rowset.endOfSet .OR. .NOT. bmRecord=this.rowset.bookmark()
                  nCurrent++
                  LlPrintSetBoxText((this.hJob),IIF(_app.language="DE","Druckfortschritt","Printing"),100*nCurrent/nCount)
               ENDIF
            ENDDO
            //D: Wenn Seitenumbruch, dann neue Kopfzeile drucken und alte Daten wiederholen
            //E: on page break print new header and repeat last data
            DO WHILE nRet=LL_WRN_REPEAT_DATA
               LlPrint((this.hJob))
               nRet=LlPrintFields((this.hJob))
            ENDDO
         ENDDO
         //D: Fusszeile letzte Seite drucken
         //E: Print last page's footer
         nRet = LL_WRN_REPEAT_DATA
         DO WHILE nRet=LL_WRN_REPEAT_DATA
            nRet =LlPrintFieldsEnd((this.hJob))
         ENDDO
         //D: List & Label Druckjob beenden
         //E: End List & Label printing job
         LlPrintEnd((this.hJob),0)
         //D: Vorschau anzeigen, wenn keine Fehler vorlagen und Preview gewählt war
         //E: Display preview if no errors occurred and preview was targeted
         IF nRet=0 .AND. nDest=LL_DESTINATION_PRV
            LlPreviewDisplay((this.hJob),this.Filename,"",(this.ParentHandle))
            //D: Temporäre Vorschaudatei löschen
            //E: Delete temporary preview file
            LlPreviewDeleteFiles((this.hJob),(this.Filename),"")
         ENDIF
      ENDIF
   ENDIF
   RETURN

   FUNCTION PrintSubTable
   LOCAL nRet
   LOCAL cTable
   LOCAL cRelation
   LOCAL nLen
   LOCAL cSubTable
   LOCAL oRowset
   LOCAL X

   nLen     =200
   cTable   =SPACE(nLen)
   nRet     =LlPrintDbGetCurrentTable((this.hJob),cTable,nLen,true)
   cTable   =TRIM(cTable)
   DO CASE
      CASE "."$cTable
         cSubTable=UPPER(RIGHT(cTable,LEN(cTable)-RAT(".",cTable)))
      CASE ">"$cTable
         cSubTable=UPPER(RIGHT(cTable,LEN(cTable)-RAT(">",cTable)))
      OTHERWISE
         cSubTable=cTable
   ENDCASE
   FOR X=1 TO this.Relations.size
      IF cSubtable==UPPER(this.Relations[X].parent.name)
         EXIT
      ENDIF
   NEXT
   IF X<=this.Relations.size
      oRowset=this.Relations[X]
      oRowset.first()
      nRet=0
      DO WHILE nRet=0 .AND. .NOT. oRowset.endOfSet
         //D: Innere Schleife: wiederholen für jeden Datensatz
         //E: inner loop: repeat for each record
         DO WHILE nRet=0 .AND. .NOT. oRowset.endOfSet
            //D: Felder definieren
            //E: Define Fields
            CLASS::DefineData((oRowset),true)
            //D: Tabellenzeile mit den definierten Feldern drucken
            //E: Print line with defined fields
            nRet= LlPrintFields((this.hJob))
            IF nRet=LL_WRN_TABLECHANGE
               nRet=CLASS::PrintSubTable()
            ENDIF
            oRowset.next()
         ENDDO
         //D: Wenn Seitenumbruch, dann neue Kopfzeile drucken und alte Daten wiederholen
         //E: on page break print new header and repeat last data
         DO WHILE nRet=LL_WRN_REPEAT_DATA
            LlPrint((this.hJob))
            nRet=LlPrintFields((this.hJob))
         ENDDO
      ENDDO
      //D: Fusszeile letzte Seite drucken
      //E: Print last page's footer
      nRet = LL_WRN_REPEAT_DATA
      DO WHILE nRet=LL_WRN_REPEAT_DATA
         nRet =LlPrintFieldsEnd((this.hJob))
      ENDDO
   ENDIF
   RETURN nRet

   FUNCTION ValType
   PARAMETERS xValue
   LOCAL cType
   cType=TYPE("xValue")
   DO CASE
      CASE cType=="D"
         cType="DATE"
      CASE cType=="C"
         cType="CHARACTER"
      CASE cType=="N"
         cType="NUMERIC"
      CASE cType=="DT"
         cType="DATETIME"
      CASE cType=="B"
         cType="BINARY"
      CASE cType=="L"
         cType="LOGICAL"
      CASE cType=="U"
         cType="UNDEFINED"
   ENDCASE
   RETURN cType

endclass





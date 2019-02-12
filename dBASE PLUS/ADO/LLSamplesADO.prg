//Revision: 03.09.2018
//Für diese Beispielanwendung wird die Firebird-Datenbank LLSample.FDB verwendet.
//Bitte beachten Sie die Kommentare in der Funktion GetADODatabase
//
//This application example uses the Firebird Database LLSample.FDB
//Please pay attention to the comments in the function GetADODatabase
#INCLUDE "WINDEF.H"
#INCLUDE "WINREG.H"
LOCAL oApp
LOCAL cStartDir
LOCAL nHandle
LOCAL cProperty
LOCAL cValue
LOCAL f
LOCAL lOpen
LOCAL oRibbon

cStartDir=PROGRAM(0)
cStartDir=IIF(LEN(cStartDir)>3,LEFT(cStartDir,RAT("\",cStartDir)),cStartDir)
SET DIRECTORY TO (cStartDir)

_app.oInfo=new OBJECT()
_app.oInfo.ListAndLabel    ="LLSample"
_app.oInfo.LizenzInfo      =""
_app.oInfo.StartDialog     =true
_app.oInfo.Language        ="deutsch"
_app.oInfo.RibbonDesigner  =true
_app.oInfo.RibbonViewer    =true
IF FILE("LLSample.TXT")
   nHandle=FOPEN("LLSample.TXT")
   DO WHILE .NOT. FEOF(nHandle)
      cString  =FGETS(nHandle)
      cProperty=LOWER(TRIM(LEFT(cString,AT("=",cString)-1)))
      cValue   =LTRIM(TRIM(RIGHT(cString,LEN(cString)-AT("=",cString))))
      DO CASE
         CASE cProperty=="sprache"
            IF EMPTY(cValue) .OR. .NOT. cValue$"deutsch english"
               _app.oInfo.Language="deutsch"
            ELSE
               _app.oInfo.Language=cValue
            ENDIF
         CASE cProperty=="startdialog"
            _app.oInfo.StartDialog=EMPTY(cValue) .OR. UPPER(cValue)="ON"
         CASE cProperty=="lizenzinfo"
            _app.oInfo.LizenzInfo=cValue
         CASE cProperty=="ribbondesigner"
            _app.oInfo.RibbonDesigner=EMPTY(cValue) .OR. UPPER(cValue)="ON"
         CASE cProperty=="ribbonviewer"
            _app.oInfo.RibbonViewer=EMPTY(cValue) .OR. UPPER(cValue)="ON"
      ENDCASE
   ENDDO
   FCLOSE(nHandle)
   IF EMPTY(_app.oInfo.LizenzInfo)
      _app.oInfo.StartDialog=true
   ENDIF
ENDIF
IF _app.oInfo.StartDialog
   SET PROCEDURE TO ..\Options.WFM ADDITIVE
   f=new OptionsForm()
   f.mdi=false
   f.Init()
   lOpen=f.readModal()
   f.release()
ELSE
   lOpen=true
ENDIF
SET PROCEDURE TO PROGRAM(0)
SET PROCEDURE TO ..\LL24.CC   ADDITIVE
_app.MainADODatabase=GetADODatabase()
IF .NOT. _app.MainADODatabase.active
   IF _app.language="DE"
      MSGBOX("Connection Alias wurde nicht"+CHR(10)+;
             "installiert oder ist ungültig.")
   ELSE
      MSGBOX("Connection alias is not installed"+CHR(10)+;
             "or not available")
   ENDIF
   RETURN
ENDIF
oApp=new MDIApp()  //Anwendungsobjekt anlegen
SHELL(false)
SET PROCEDURE TO ..\LLRibbons.CC ADDITIVE
oRibbons=new LLRibbons()
oRibbons.CheckRibbons()
RELEASE OBJECT oRibbons
oApp.OldText=_app.frameWin.text
DO CASE
   CASE _app.oInfo.Language="deutsch"
      _app.frameWin.text="Beispielanwendung zur Integration von combit List & Label 24 in dBASE PLUS mit ADO (ohne BDE)"
   OTHERWISE
      _app.frameWin.text="Sample application to integration of combit List & Label 24 with dBASE PLUS with ADO (without BDE)"
ENDCASE
_app.speedbar =false
_app.statusbar=true
_app.tabbar   =false
RETURN oApp.open()

CLASS MDIApp
   _app.frameWin.app=this
   SET PROCEDURE TO ..\MainMenu.MNU ADDITIVE
   this.rootMenu  =new MainMenuMenu(_app.framewin,"Root")
   this.rootMenu.onInitMenu()

   FUNCTION Open
   LOCAL f
   f=new FORM()
   f.top=-100
   f.open()
   f.close()
   f.release()
   f=NULL
   RETURN true

   FUNCTION CloseApp
   this.close()
   RETURN

   FUNCTION OpenLabels(lDesign)
   LOCAL f

   f=FINDINSTANCE("LabelsADOForm")
   IF f==NULL
      SET PROCEDURE TO LabelsADO.WFM ADDITIVE
      f=new LabelsADOForm()
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.open()
      ELSE
         f.OpenReport()
      ENDIF
   ELSE
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.windowState=0
         f.setFocus()
      ELSE
         f.OpenReport()
      ENDIF
   ENDIF   
   RETURN

   FUNCTION OpenArticlelist(lDesign)
   LOCAL f

   f=FINDINSTANCE("ArticlelistADOForm")
   IF f==NULL
      SET PROCEDURE TO ArticlelistADO.WFM ADDITIVE
      f=new ArticlelistADOForm()
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.open()
      ELSE
         f.OpenReport()
      ENDIF
   ELSE
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.windowState=0
         f.setFocus()
      ELSE
         f.OpenReport()
      ENDIF
   ENDIF   
   RETURN

   FUNCTION OpenSubreport(lDesign)
   LOCAL f

   f=FINDINSTANCE("SubreportADOForm")
   IF f==NULL
      SET PROCEDURE TO SubReportADO.WFM ADDITIVE
      f=new SubReportADOForm()
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.open()
      ELSE
         f.OpenReport()
      ENDIF
   ELSE
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.windowState=0
         f.setFocus()
      ELSE
         f.OpenReport()
      ENDIF
   ENDIF   
   RETURN

   FUNCTION OpenDelivery(lDesign)
   LOCAL f
   f=FINDINSTANCE("DeliveryADOForm")
   IF f=NULL
      SET PROCEDURE TO DeliveryADO.WFM ADDITIVE
      f=new DeliveryADOForm()
      f.app=this
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.open()
      ELSE
         f.OpenReport()
      ENDIF
   ELSE
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.windowState=0
         f.setFocus()
      ELSE
         f.OpenReport()
      ENDIF
   ENDIF
   RETURN

   FUNCTION OpenChart(lDesign)
   LOCAL f
   f=FINDINSTANCE("ChartADOForm")
   IF f=NULL
      SET PROCEDURE TO ChartADO.WFM ADDITIVE
      f=new ChartADOForm()
      f.app=this
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.open()
      ELSE
         f.OpenReport()
      ENDIF
   ELSE
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.windowState=0
         f.setFocus()
      ELSE
         f.OpenReport()
      ENDIF
   ENDIF
   RETURN

   FUNCTION OpenEvents(lDesign)
   LOCAL f
   f=FINDINSTANCE("EventsADOForm")
   IF f=NULL
      SET PROCEDURE TO EventsADO.WFM ADDITIVE
      f=new EventsADOForm()
      f.app=this
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.open()
      ELSE
         f.OpenReport()
      ENDIF
   ELSE
      f.Init(lDesign)
      IF EMPTY(lDesign)
         f.windowState=0
         f.setFocus()
      ELSE
         f.OpenReport()
      ENDIF
   ENDIF
   RETURN

   FUNCTION OpenAbout
   LOCAL f
   f=FINDINSTANCE("AboutADOForm")
   IF f=NULL
      SET PROCEDURE TO AboutADO.WFM ADDITIVE
      f=new AboutADOForm()
      f.app=this
      f.Init()
      f.open()
   ELSE
      f.windowState=0
      f.setFocus()
   ENDIF
   RETURN

   FUNCTION OpenOptions
   LOCAL f

   SET PROCEDURE TO ..\Options.WFM ADDITIVE
   f=new OptionsForm()
   f.app=this
   f.Init()
   IF f.readModal()
      SET PROCEDURE TO ..\LLRibbons.CC ADDITIVE
      oRibbons=new LLRibbons()
      oRibbons.CheckRibbons()
      RELEASE OBJECT oRibbons
   ENDIF
   RETURN

   FUNCTION Close
   LOCAL f
   CLOSE FORMS
   IF "runtime"$LOWER(VERSION(1))
      QUIT
      RETURN
   ELSE
      _app.frameWin.text=this.OldText
      _app.MainADODatabase.active=false
      this.rootMenu  =null
      _app.frameWin.app=NULL
      SET PROCEDURE TO
      SHELL(true,true)
      f=new FORM()
      f.top=-100
      f.open()
      f.close()
      f.release()
   ENDIF
   RETURN
ENDCLASS


FUNCTION GetADODatabase
//Liefert das ADO-Datenbankobjekt der Anwendung
//Wenn die Verbindung hergestellt werden kann, ist das Objekt bereits aktiviert
//
//Create and opens the ADO-Database-Object
//If the connection is successfull the object is already activated.
LOCAL oDatabase
LOCAL cConnectionString
LOCAL cPath
LOCAL e

IF "runtime"$LOWER(VERSION(1))
   cPath=_app.EXEName
ELSE
   cPath=PROGRAM(1)
ENDIF
cPath=LEFT(cPath,RAT("\",cPath))
oDatabase=new ADODATABASE()
TRY
   //Einbindung per ODBC und Verbindungs-Alias
   //Connection via ODBC an database-alias
   oDatabase.databaseName="LLSample"
   oDatabase.active=true
   oDatabase.ConnectionType="Alias"
CATCH (exception e)
   //Alternative Einbindung per OLE DB
   //Alternating connection via OLE DB
   cConnectionString ="User ID=SYSDBA;"
   cConnectionString+="auto_commit_level=4096;"
   cConnectionString+="Location="+cPath+"\LLSample.FDB;"
   cConnectionString+="Password=masterkey;"
   cConnectionString+="auto_commit=true;"
   cConnectionString+="ctype=WIN1252;"
   cConnectionString+="Provider=LCPI.IBProvider.3.Lite;"
   oDatabase.connectionString=cConnectionString
   TRY
      oDatabase.active=true
      oDatabase.ConnectionType="OLE DB"
   CATCH(exception e)
      IF LEFT(cPath,2)="\\"
         IF _app.language="DE"
            MSGBOX("Bitte starten Sie diese Anwendung von einem lokalen Pfad.")
         ELSE
            MSGBOX("Please start this application from a local path.")
         ENDIF
      ENDIF
   ENDTRY
CATCH (exception e)
ENDTRY
RETURN oDatabase

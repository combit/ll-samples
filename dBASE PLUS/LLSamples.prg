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

SHELL(false)
_app.oInfo=new OBJECT()
_app.oInfo.ListAndLabel  ="LLSample"
_app.oInfo.LizenzInfo    =""
_app.oInfo.StartDialog   =true
_app.oInfo.Language      ="deutsch"
_app.oInfo.RibbonDesigner=true
_app.oInfo.RibbonViewer  =true
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
   SET PROCEDURE TO Options.WFM ADDITIVE
   f=new OptionsForm()
   f.mdi=false
   f.Init()
   lOpen=f.readModal()
   f.release()
ELSE
   lOpen=true
ENDIF
SET PROCEDURE TO PROGRAM(0)
SET PROCEDURE TO LL30.CC ADDITIVE
oApp=new MDIApp()  //Anwendungsobjekt anlegen
SET PROCEDURE TO LLRibbons.CC ADDITIVE
oRibbons=new LLRibbons()
oRibbons.CheckRibbons()
RELEASE OBJECT oRibbons
oApp.OldText=_app.frameWin.text
DO CASE
   CASE _app.oInfo.Language="deutsch"
      _app.frameWin.text="Beispielanwendung zur Integration von combit List & Label 30 in dBASE PLUS"
   OTHERWISE
      _app.frameWin.text="Sample application to integration of combit List & Label 30 with dBASE PLUS"
ENDCASE
_app.speedbar =false
_app.statusbar=true
_app.tabbar   =false
RETURN oApp.open()

CLASS MDIApp
   _app.frameWin.app=this
   SET PROCEDURE TO MainMenu.MNU ADDITIVE
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

   f=FINDINSTANCE("LabelsForm")
   IF f==NULL
      SET PROCEDURE TO Labels.WFM ADDITIVE
      f=new LabelsForm()
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

   f=FINDINSTANCE("ArticlelistForm")
   IF f==NULL
      SET PROCEDURE TO Articlelist.WFM ADDITIVE
      f=new ArticlelistForm()
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

   f=FINDINSTANCE("SubreportForm")
   IF f==NULL
      SET PROCEDURE TO SubReport.WFM ADDITIVE
      f=new SubReportForm()
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
   f=FINDINSTANCE("DeliveryForm")
   IF f=NULL
      SET PROCEDURE TO Delivery.WFM ADDITIVE
      f=new DeliveryForm()
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
   f=FINDINSTANCE("ChartForm")
   IF f=NULL
      SET PROCEDURE TO Chart.WFM ADDITIVE
      f=new ChartForm()
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
   f=FINDINSTANCE("EventsForm")
   IF f=NULL
      SET PROCEDURE TO Events.WFM ADDITIVE
      f=new EventsForm()
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
   f=FINDINSTANCE("AboutForm")
   IF f=NULL
      SET PROCEDURE TO About.WFM ADDITIVE
      f=new AboutForm()
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

   SET PROCEDURE TO ..\Shared\Options.WFM ADDITIVE
   f=new OptionsForm()
   f.app=this
   f.Init()
   IF f.readModal()
      SET PROCEDURE TO ..\Shared\LLRibbons.CC ADDITIVE
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



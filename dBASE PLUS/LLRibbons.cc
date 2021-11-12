// Revision: 27.08.21
#INCLUDE "WINDEF.H"
#INCLUDE "WINREG.H"
#DEFINE REG_PATH  "Software\Combit\CMBTLL\PlusRun\"
//This class may set the Ribbon Avtivity in LL Designer and Viewer
//For the designer this is also availanle by using the Optionen Menu
//but for Viewer is currently NO dialog to set the ribbon state separatly.
//Diese Klasse setzt die Ribbon-State Eigenschaft für Designer und Viewer
//separat. Derzeit steht hierzu nur im Designer eine entsprechende Funktionalität
//zur Verfügung, das Setzen unterschiedlicher Einstellungen für Designer/Viewer
//ist nur per Zugriff auf die Registry möglich.
//Designer --- HKEY_CURRENT_USER\Software\Combit\CMBTLL\PlusRun\Designer.Ribbon.Active
//Viewer   --- HKEY_CURRENT_USER\Software\Combit\CMBTLL\PlusRun\Viewer.Ribbon.Active
CLASS LLRibbons OF OBJECT
   this.Key     =0
   this.Language=0 

   IF .NOT. TYPE("RegOpenKeyEx")=="FP"
       EXTERN CLONG RegOpenKeyEx(HKEY, LPCTSTR, DWORD, REGSAM, PHKEY)                ADVAPI32 from "RegOpenKeyExA"
       EXTERN CLONG RegQueryValueEx(HKEY, LPTSTR, DWORD, LPDWORD, CSTRING, LPDWORD)  ADVAPI32 from "RegQueryValueExA"
       EXTERN CLONG RegCloseKey( HKEY )                                              ADVAPI32
       EXTERN CLONG RegCreateKeyEx(HKEY,LPCTSTR,DWORD, LPTSTR, DWORD,REGSAM,LPSTRUCTURE,PHKEY,LPDWORD) ADVAPI32 from "RegCreateKeyExA"
       EXTERN CLONG RegSetValueEx( HKEY, LPCTSTR, DWORD, DWORD, CSTRING, DWORD )     ADVAPI32 from "RegSetValueExA"
   ENDIF

   FUNCTION CheckRibbons
   LOCAL cStatus
   LOCAL nKey
   LOCAL nResult
   LOCAL cNewState

   cStatus=""
   nKey=0
   IF TYPE(_app.oInfo.Language)=="C" .AND. _app.oInfo.Language="deutsch"
      this.Language=1
   ENDIF
   nResult=RegOpenKeyEx(HKEY_CURRENT_USER,REG_PATH,0,KEY_ALL_ACCESS,nKey)
   //Schlüssel öffnen
   IF nResult==ERROR_SUCCESS
      this.Key=nKey
      //Check Ribbon for designer
      cStatus  =CLASS::GetRegistryValue("Designer")
      cNewState=IIF(EMPTY(_app.oInfo.RibbonDesigner),"F","T")
      IF cStatus#cNewState
         CLASS::SetRibbon("Designer",cNewState,EMPTY(cStatus))
      ENDIF
      //Check Ribbon for viewer
      cStatus  =CLASS::GetRegistryValue("Viewer")
      cNewState=IIF(EMPTY(_app.oInfo.RibbonViewer),"F","T")
      IF cStatus#cNewState
         CLASS::SetRibbon("Viewer",cNewState,EMPTY(cStatus))
      ENDIF
      RegCloseKey(nKey)
   ELSE
      DO CASE
         CASE this.Language=1
            MSGBOX("HKEY_CURRENT_USER\"+REG_PATH,"Schlüssel wurde nicht gefunden",16)
         OTHERWISE
            MSGBOX("HKEY_CURRENT_USER\"+REG_PATH,"Key not found",16)
      ENDCASE
   ENDIF
   RETURN

   FUNCTION GetRegistryValue(cKeyName)
   //Check the current Registry-Setting
   LOCAL nResult
   LOCAL nType
   LOCAL cValue
   LOCAL cData
   LOCAL nLen
   LOCAL nDisposition

   nResult= 0
   nType  = 0
   nLen   = 20
   cData  = SPACE(20)
   cValue =""

   nResult=RegQueryValueEx(this.Key,cKeyName+".Ribbon.Active",0,nType,cData,nLen)
   IF nResult == ERROR_SUCCESS
      cValue=TRIM(LTRIM(cData))
   ENDIF
   RETURN cValue

   FUNCTION SetRibbon(cDialogName,cNewState,lCreate)
   LOCAL nResult
   LOCAL nSubKey

   nResult=ERROR_SUCCESS
   nSubkey=0
   IF lCreate
      //Key wasn't defined, so create it now
      nResult=RegCreateKeyEx(this.Key, cDialogName+".Ribbon.Active", 0, 0, REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, 0, nSubkey, -1)
   ENDIF
   IF nResult==ERROR_SUCCESS
      nResult = RegSetValueEx(this.Key, cDialogName+".Ribbon.Active", 0, REG_SZ, cNewState,1)
      IF .NOT. nResult==ERROR_SUCCESS
         IF this.Language=1
            MSGBOX("Ribbon-Status konnte nicht gesetzt werden"+CHR(10)+"Code "+LTRIM(STR(nResult)),cDialogName,16)
         ELSE
            MSGBOX("Ribbon-state cannot be set."+CHR(10)+"Code "+LTRIM(STR(nResult)),cDialogName,16)
         ENDIF
      ENDIF
   ELSE
      IF this.Language=1
         MSGBOX("Ribbon-Status Eintrag konnte nicht erstellt werden"+CHR(10)+"Code "+LTRIM(STR(nResult)),cDialogName,16)
      ELSE
         MSGBOX("Ribbon-state item cannot be created."+CHR(10)+"Code "+LTRIM(STR(nResult)),cDialogName,16)
      ENDIF
   ENDIF
   RETURN
ENDCLASS

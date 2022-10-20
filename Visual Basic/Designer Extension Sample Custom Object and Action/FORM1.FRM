VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Object = "{2213E283-16BC-101D-AFD4-040224009C1C}#28.0#0"; "cmll28o.ocx"
Object = "{2B7D38A0-4385-47BE-9345-29F96556FB48}#1.0#0"; "cmll28fx.ocx"
Object = "{B25593B9-D834-48DC-83A3-E5FD148BCC2F}#1.0#0"; "cmll28ox.ocx"
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "List & Label Designer Extensions Sample"
   ClientHeight    =   2085
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   6765
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2085
   ScaleWidth      =   6765
   StartUpPosition =   3  'Windows Default
   Begin ListLabel.ListLabel ListLabel1 
      Left            =   3960
      Top             =   1560
      _Version        =   65537
      _ExtentX        =   661
      _ExtentY        =   661
      _StockProps     =   64
      Language        =   -1
      DialogMode      =   14
      DialogFrame     =   0
      Dialog3DText    =   0
      DialogButtons   =   0
      NewExpressions  =   1
      TableColoring   =   0
      TabStops        =   0
      EnablePageCallback=   -1  'True
      EnableProjectCallback=   -1  'True
      EnableObjectCallback=   -1  'True
      EnableHelpCallback=   -1  'True
      OnlyOneTable    =   0   'False
      MultipleTableLines=   -1  'True
      SortVariables   =   -1  'True
      HelpAvailable   =   -1  'True
      Dummy8          =   -1  'True
      ShowPredefVars  =   -1  'True
      UseHostprinter  =   0   'False
      EMFResolution   =   0
      AddVarsToFields =   0   'False
      ConvertCRLF     =   0   'False
      WizFileNew      =   0   'False
      VarsCaseSensitive=   -1  'True
      RealTime        =   0   'False
      SpaceOptimization=   -1  'True
      CompressStorage =   0   'False
      NoParameterCheck=   0   'False
      NoNoTableCheck  =   0   'False
      PreviewZoomPerc =   100
      PreviewRectLeft =   -1
      PreviewRectTop  =   -1
      PreviewRectWidth=   1
      PreviewRectHeight=   1
      Metric          =   1
      TabRepresentationCode=   247
      RetRepresentationCode=   182
      StorageSystem   =   1
      AutoMultipage   =   -1  'True
      UseBarcodeSizes =   0   'False
      MaxRTFVersion   =   1025
      DelayTableHeader=   0   'False
      OfnDialogExplorer=   -1  'True
      CreateInfo      =   -1  'True
      XlatVarNames    =   -1  'True
      PhantomSpaceRepresentationCode=   2
      LockNextCharRepresentationCode=   3
      ExprSepRepresentationCode=   164
      TextQuoteRepresentationCode=   1
      InterCharSpacing=   0   'False
      IncludeFontDescent=   0   'False
      Dummy6          =   -1  'True
      UseChartFields  =   0   'False
      Dummy7          =   -1  'True
      ProjectPassword =   ""
      LicensingInfo   =   ""
      IncrementalPreview=   -1  'True
      Dummy5          =   -1  'True
   End
   Begin VB.CommandButton ButtonPrint 
      Caption         =   "&Print..."
      Height          =   375
      Left            =   1680
      TabIndex        =   4
      Top             =   1560
      Width           =   1335
   End
   Begin MSComDlg.CommonDialog comDlgOpen 
      Left            =   4680
      Top             =   1560
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CheckBox Check1 
      Caption         =   "D&ebug Output"
      Height          =   375
      Left            =   5160
      TabIndex        =   3
      Top             =   1680
      Width           =   1335
   End
   Begin VB.CommandButton ButtonDesign 
      Caption         =   "&Design..."
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   1560
      Width           =   1335
   End
   Begin CMLL28OXLibCtl.DesignerObject DesObj_Picture 
      Left            =   3600
      Top             =   1560
      _cx             =   661
      _cy             =   661
      ObjectName      =   "MYOBJECT"
      Description     =   "MYOBJECT"
	  Icon            =   "FORM1.frx":0000
   End
   Begin CMLL28FXLibCtl.DesignerFunctions DesFunc_Add 
      Left            =   3240
      Top             =   1560
      _cx             =   661
      _cy             =   661
      FunctionName    =   "Add"
      Description     =   "Add two numeric values"
      GroupName       =   "Operators"
      MinimumParameters=   2
      MaximumParameters=   2
      ResultType      =   1
      Visible         =   -1  'True
   End
   Begin VB.Label Label2 
      Caption         =   "custom objects and functions."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Left            =   570
      TabIndex        =   6
      Top             =   1125
      Width           =   4665
   End
   Begin VB.Label Label1 
      Caption         =   "Designers um eigene Objekte und Funktionen."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      Left            =   465
      TabIndex        =   5
      Top             =   405
      Width           =   4980
   End
   Begin VB.Label Label4 
      Caption         =   "US: This example shows how to extend the designer with"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   120
      TabIndex        =   0
      Top             =   840
      Width           =   6495
   End
   Begin VB.Label Label3 
      Caption         =   "D:  Dieses Beispiel demonstriert die Erweiterung des"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   6495
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Type RECT
        left As Long
        top As Long
        right As Long
        bottom As Long
End Type

Private Declare Function StretchBlt Lib "gdi32" (ByVal hDC As Long, ByVal x As Long, ByVal y As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal hSrcDC As Long, ByVal xSrc As Long, ByVal ySrc As Long, ByVal nSrcWidth As Long, ByVal nSrcHeight As Long, ByVal dwRop As Long) As Long
Private Declare Function CreateCompatibleDC Lib "gdi32" (ByVal hDC As Long) As Long
Private Declare Function SelectObject Lib "gdi32" (ByVal hDC As Long, ByVal hObject As Long) As Long
Private Declare Function DeleteObject Lib "gdi32" (ByVal hObject As Long) As Long


'======================================================
Private Sub ButtonDesign_Click()
'======================================================
    'D: Designer um Button erweitern
    'US: Add a button in the designer
    Dim nRet As Long
    nRet = ListLabel1.LlDesignerAddAction(10100, LLDESADDACTIONFLAG_ADD_TO_TOOLBAR Or LLDESADDACTION_ACCEL_VIRTKEY _
            Or LLDESADDACTION_ACCEL_CONTROL Or &H46, "&Find object", "1.1", "Find object", 642, 0)
    
    'D : Startet den Designer mit dem Titel "Design card" und der Datei "desext.crd"
    'US: Opens "desext.crd" within the designer titled "Design card"
    Dim ret As Long
    ret = ListLabel1.Design(0, hWnd, "Design card", LL_PROJECT_CARD Or LL_FILE_ALSONEW, CStr(App.Path & "\desext.crd"), 1)
    
End Sub



'======================================================
Private Sub ButtonPrint_Click()
'======================================================

    'D : Startet den Druck der Datei "desext.crd"
    'US: Begin printing the file "desext.crd"
    Dim ret As Long
    ret = ListLabel1.Print(0, LL_PROJECT_CARD, CStr(App.Path & "\desext.crd"), 1, LL_PRINT_EXPORT, LL_BOXTYPE_STDWAIT, hWnd, "Print card", True, Environ$("temp"))

End Sub




'======================================================
Private Sub InitializeDesFunction()
'======================================================
    
    Dim param1 As DesignerFunctionsParameter
    Dim param2 As DesignerFunctionsParameter
    
    Set param1 = DesFunc_Add.Parameter1
    param1.Description = "First Value"
    param1.Type = LlParamType.ParamType_Double
    
    Set param2 = DesFunc_Add.Parameter2
    param2.Description = "Second Value"
    param2.Type = LlParamType.ParamType_Double
    
    DesFunc_Add.ParentComponent = ListLabel1

End Sub


'======================================================
Private Sub InitializeDesObject()
'======================================================

    DesObj_Picture.ParentComponent = ListLabel1
    Call DesObj_Picture.Properties.AddProperty("imagefile", "logo.bmp")

End Sub


'======================================================
Private Sub Check1_Click()
'======================================================
    
    'D : (De)aktiviert Debug-Ausgaben
    'US: enables or disables debug-print
    If Check1.Value = 1 Then
        MsgBox "D:   Debwin muss vor Visual Basic gestartet werden" & Chr(13) & Chr(10) & "US: Debwin must be started before Visual Basic"
        Form1.ListLabel1.LlSetDebug 1
    Else
        Form1.ListLabel1.LlSetDebug 0
    End If
    
End Sub


' D:    Dieser Event dient zur Berechnung der Funktion
' US:   This event is triggered to evaluate the function
'======================================================
Private Sub DesFunc_Add_EvaluateFunction(ResultValue As Variant, ResultType As CMLL28FXLibCtl.LlParamType, DecimalPositions As Long, ByVal Parameters As Long, ByVal Parameter1 As Variant, ByVal Parameter2 As Variant, ByVal Parameter3 As Variant, ByVal Parameter4 As Variant)
'======================================================

    ResultValue = CDbl(Parameter1) + CDbl(Parameter2)
    
    ResultType = ParamType_Double

End Sub


' D:    Der Event dient zur Anzeige einer Autovervollständigungs-Liste für die jeweiligen Parameter (Tabulator-Separiert).
'       Wenn nichts angegeben wird, so wird die Standard-Autovervollständigung verwendet.
' US:   This event is used to pass a tab separated list of entries for the Designer's auto complete feature. If no
'       values are passed, the standard behaviour is applied.
'======================================================
Private Sub DesFunc_Add_ParameterAutoComplete(ByVal ParameterIndex As Long, Values As String)
'======================================================

    Dim i As Integer
    Dim paraValues As String
    
    For i = 1 To 9
        paraValues = paraValues + CStr(i) + CStr(vbTab)
    Next
    
    Values = paraValues

End Sub



' D:    Das Ereignis "DrawDesignerObject" wird immer dann aufgerufen, wenn das Objekt gezeichnet werden soll.
'       Implementieren Sie hier Ihre Zeichnungsroutine.
' US:   This event is triggered to draw the object. Implement your own draw code here.
'======================================================
Private Sub DesObj_Picture_DrawDesignerObject(ByVal propertiesObject As CMLL28OXLibCtl.propertiesObject, ByVal hDC As Long, ByVal x As Long, ByVal y As Long, ByVal x2 As Long, ByVal y2 As Long)
'======================================================

    Dim imagefile As String

    If propertiesObject.ContainsKey("imagefile") Then
        
        imagefile = propertiesObject.GetValue("imagefile")
        
        If (Len(imagefile) > 0) Then
            Dim img As IPictureDisp, dc As Long, oldBrush As Long

            On Error Resume Next
            Set img = LoadPicture(imagefile)
                        
            If Err.Number <> 0 Then
                Exit Sub
            End If
            
            On Error GoTo 0

            dc = CreateCompatibleDC(0)

            Dim nWidth As Integer, nHeight As Integer
            
            nWidth = ScaleX(img.Width, vbHimetric, vbPixels)
            nHeight = ScaleY(img.Height, vbHimetric, vbPixels)

            oldBrush = SelectObject(dc, img)

            DeleteObject img
            Set img = Nothing
          
            StretchBlt hDC, x, y, x2 - x, y2 - y, dc, 0, 0, nWidth, nHeight, vbSrcCopy
            
            SelectObject dc, oldBrush
                          
        End If
    End If
End Sub


' D:    Beim Doppelklick auf das Object wird dieser Event aufgerufen. Hier können Sie beispielsweise
'       eigene Objekt-Eigenschaften in einem Dialog setzen lassen.
' US:   This event is triggered e.g. by a double click on the object. You may offer a dialog to set custom object properties here.
'======================================================
Private Sub DesObj_Picture_EditDesignerObject(ByVal propertiesObject As CMLL28OXLibCtl.propertiesObject, ByVal DesignerWindow As Long, HasChanged As Boolean)
'======================================================

    If propertiesObject.ContainsKey("imagefile") Then
        comDlgOpen.FileName = propertiesObject.GetValue("imagefile")
    End If
    
    comDlgOpen.Filter = "Picture Files (*.jpg, *.jpeg, *.bmp)|*.jpg; *.jpeg; *.bmp|All Files (*.*)|*.*|"
    comDlgOpen.InitDir = App.Path
    comDlgOpen.ShowOpen
    If (comDlgOpen.CancelError = False) Then
        Call propertiesObject.AddProperty("imagefile", comDlgOpen.FileName)
        HasChanged = True
    End If

End Sub

'======================================================
Private Sub Form_Load()
'======================================================
    
    Call InitializeDesFunction
    Call InitializeDesObject
    
    
End Sub


'======================================================
Private Sub ListLabel1_CmndDefineVariables(ByVal nUserData As Long, ByVal bDummy As Long, pnProgressInPerc As Long, pbLastRecord As Long)
'======================================================

    ' D:  Nur einen Datensatz drucken
    ' US: Print only one record
    If bDummy = 0 Then
        pbLastRecord = 1
    End If

End Sub

'======================================================
Private Sub ListLabel1_CmndSelectMenu(ByVal nMenuID As Long, pbProcessed As Long)
'======================================================

    If nMenuID = 10100 Then
        Call ExecuteDesignerAction
    End If
    
End Sub

'======================================================
Private Sub ExecuteDesignerAction()
'======================================================
    
    'D: Das DOM Objekt für das Projekt erzeugen
    'US: Get the project's DOM object
    Dim hProj As Long
    ListLabel1.LlDomGetProject hProj
    
    'D: Objektname eingeben
    'US: Input object name:
    Dim sObjectName As String
    sObjectName = InputBox("Find Object:", "Which object are you looking for?")
    
    If Len(sObjectName) > 0 Then
            
        'D: Redraw im Projekt deaktivieren:
        'US: No Redraw
        ListLabel1.LlDomSetProperty hProj, "DesignerRedraw", "False"
        
        'D: Das Objektlistenobjekt erzeugen
        'US: Get the object list object
        Dim hObjList As Long
        ListLabel1.LlDomGetObject hProj, "Objects", hObjList
        
        Dim nItemCount As Long
        nItemCount = 0
        ListLabel1.LlDomGetSubobjectCount hObjList, nItemCount
        
        Dim sItemObjectName As String
        Dim bfound As Boolean
        bfound = False
        
        'D: Objektliste iterieren
        'US: Iterate the object list
        Dim i As Long
        
        For i = 0 To (nItemCount - 1)
        
            Dim hObject As Long
            ListLabel1.LlDomGetSubobject hObjList, i, hObject
            
            Dim sName As String
            ListLabel1.LlDomGetProperty hObject, "Name", sName

            If sName = sObjectName Then
            
                bfound = True
                ListLabel1.LlDomSetProperty hObject, "Selected", "True"
                Exit For
                
            Else
                
                ListLabel1.LlDomSetProperty hObject, "Selected", "False"
                
            End If
            
        Next i
        
         ' D: Redraw im Projekt wieder aktivieren um z.B. MessageBoxen wieder anzuzeigen:
         ' US: Activate Redraw:
        ListLabel1.LlDomSetProperty hProj, "DesignerRedraw", "True"
         
        
        
    End If
       
    
End Sub

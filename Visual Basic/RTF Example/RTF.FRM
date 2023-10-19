VERSION 5.00
Object = "{E35C7E00-75CA-4B81-AABC-1FF3A0E535F3}#1.0#0"; "cmll29r.ocx"
Object = "{2213E283-16BC-101D-AFD4-040224009C1D}#29.0#0"; "cmll29o.ocx"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "List & Label  -  RTF Sample"
   ClientHeight    =   5595
   ClientLeft      =   5025
   ClientTop       =   3480
   ClientWidth     =   9075
   Icon            =   "RTF.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   5595
   ScaleWidth      =   9075
   Begin ListLabel.ListLabel ListLabel1 
      Left            =   7200
      Top             =   4800
      _Version        =   65537
      _ExtentX        =   1296
      _ExtentY        =   1085
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
      Dummy8          =   0   'False
      ShowPredefVars  =   -1  'True
      UseHostprinter  =   0   'False
      EMFResolution   =   0
      AddVarsToFields =   0   'False
      ConvertCRLF     =   -1  'True
      WizFileNew      =   0   'False
      VarsCaseSensitive=   -1  'True
      RealTime        =   0   'False
      SpaceOptimization=   -1  'True
      CompressStorage =   0   'False
      NoParameterCheck=   0   'False
      NoNoTableCheck  =   0   'False
      PreviewZoomPerc =   100
      PreviewRectLeft =   0
      PreviewRectTop  =   0
      PreviewRectWidth=   0
      PreviewRectHeight=   0
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
      IncludeFontDescent=   -1  'True
      Dummy6          =   -1  'True
      UseChartFields  =   0   'False
      Dummy7          =   -1  'True
      ProjectPassword =   ""
      LicensingInfo   =   ""
      IncrementalPreview=   -1  'True
      Dummy5          =   -1  'True
   End
   Begin CMLL29RLib.LlRtfCtrl LlRtfCtrl1 
      Height          =   3495
      Left            =   120
      OleObjectBlob   =   "RTF.frx":000C
      TabIndex        =   8
      Top             =   120
      Width           =   8655
   End
   Begin VB.CommandButton ButtonPrint 
      Caption         =   "&Print..."
      Height          =   375
      Left            =   3120
      TabIndex        =   4
      Top             =   3840
      Width           =   1125
   End
   Begin VB.CommandButton ButtonPreview 
      Caption         =   "Pre&view..."
      Height          =   375
      Left            =   1680
      TabIndex        =   3
      Top             =   3840
      Width           =   1125
   End
   Begin VB.CommandButton ButtonDesign 
      Caption         =   "&Design..."
      Height          =   375
      Left            =   240
      TabIndex        =   2
      Top             =   3840
      Width           =   1125
   End
   Begin VB.CheckBox Check1 
      Caption         =   "D&ebug Output"
      Height          =   375
      Left            =   4560
      TabIndex        =   5
      Top             =   3840
      Width           =   1335
   End
   Begin VB.Label Label4 
      Caption         =   "This example demonstrates the usage of RTF-variables"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   720
      TabIndex        =   7
      Top             =   5160
      Width           =   6165
   End
   Begin VB.Label Label3 
      Caption         =   "Dieses Beispiel demonstriert die Verwendung von RTF-Variablen"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   720
      TabIndex        =   6
      Top             =   4560
      Width           =   6165
   End
   Begin VB.Label Label2 
      Caption         =   "US: "
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   10.5
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   240
      Left            =   240
      TabIndex        =   1
      Top             =   5160
      Width           =   405
   End
   Begin VB.Label Label1 
      Caption         =   "D:   "
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   10.5
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   240
      Left            =   240
      TabIndex        =   0
      Top             =   4560
      Width           =   435
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

'======================================================
Private Sub ButtonDesign_Click()
'======================================================
    
    'D:   Startet den Designer mit dem Titel "Design RTF Page" und der Datei "rtf.lbl"
    'US: Opens "rtf.lbl" within the designer titled "Design RTF Page"
    ListLabel1.Design 0, hWnd, "Design RTF Page", LL_PROJECT_LABEL, "rtf.lbl", 1
    
End Sub

'======================================================
Private Sub ButtonPreview_Click()
'======================================================
    
    'D:   Druckt das Projekt "rtf.lbl" als Vorschau aus
    'US: Prints "rtf.lbl" to preview
    ret% = ListLabel1.Print(0, LL_PROJECT_LABEL, "rtf.lbl", 1, LL_PRINT_PREVIEW, _
                            LL_BOXTYPE_STDWAIT, hWnd, "Print RTF-page to preview", True, Environ$("temp"))

End Sub

'======================================================
Private Sub ButtonPrint_Click()
'======================================================
    
    'D:   Druckt das Projekt "rtf.lbl" auf dem Drucker aus
    'US: Prints "rtf.lbl" to printer
    ret% = ListLabel1.Print(0, LL_PROJECT_LABEL, "rtf.lbl", 1, LL_PRINT_EXPORT, _
                            LL_BOXTYPE_STDWAIT, hWnd, "Print RTF-page to printer", True, Environ$("temp"))

End Sub


'======================================================
Private Sub Check1_Click()
'======================================================
    
    'D:   (De)Aktiviert Debug-Ausgaben
    'US: enables or disables debug-print
    If Check1.Value = 1 Then
        MsgBox "D:   Debwin muss vor Visual Basic gestartet werden" & Chr(13) & Chr(10) & "US: Debwin must be started before Visual Basic"
        Form1.ListLabel1.LlSetDebug 1
    Else
        Form1.ListLabel1.LlSetDebug 0
    End If
    
End Sub








'======================================================
Private Sub Form_KeyPress(KeyAscii As Integer)
'======================================================
    
    'D:   Anwendung mit ESC beenden
    'US: Terminate application with ESC
    If KeyAscii = 27 Then Unload Form1
    
End Sub

Private Sub Form_Load()
'======================================================================================
'
' Copyright (C) combit GmbH
'
'--------------------------------------------------------------------------------------
' File   : rtf.vbp, rtf.frm, cmll29.bas
' Module : rtf sample
' Descr. : D:   Dieses Beispiel demonstriert die Verwendung von RTF-Variablen
'          US: This example demonstrates the usage of RTF-variables
'======================================================================================

'D:   Zentriert die Form auf dem Desktop
'US: Center form to desktop
Left = (Screen.Width - Width) / 2: Top = (Screen.Height - Height) / 2

'D:   Wechselt auf Laufwerk & Verzeichnis der Beispiel-Anwendung
'US: Change to drive & path of example-app
ChDrive App.Path
ChDir App.Path

'D:   Setzt die List & Label Sprache auf einen Default Wert
'US: Set the List & Label language to a default value
ListLabel1.Language = CMBTLANG_DEFAULT

'D:   RTF-Datei einladen
'US: Load RTF-file

Dim sTextLine As String, sFile As String, sAllText As String
sFile = "Sample.rtf"
Open sFile For Input As #1
Do While Not EOF(1)
   Line Input #1, sTextLine
   sAllText = sAllText & sTextLine
Loop
Close #1

LlRtfCtrl1.Text = sAllText

End Sub






Private Sub ListLabel1_CmndDefineVariables(ByVal nUserData As Long, ByVal bDummy As Long, pnProgressInPerc As Long, pbLastRecord As Long)

    'D:   Formatierten Text des RTF-Objektes als Variable in List & Label definieren
    'US Define formatted text from RTF-object as List & Label variable
    ret% = ListLabel1.LlDefineVariableExt("RTF-Field", LlRtfCtrl1.Text, LL_RTF)

    'D:   Nur eine zu druckende Variable nötig
    'US: Only one variable needed
    If bDummy = 0 Then pbLastRecord = 1
    
End Sub


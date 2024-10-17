VERSION 5.00
Object = "{2213E283-16BC-101D-AFD4-040224009C1E}#30.0#0"; "cmll30o.ocx"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "List & Label - DevMode-Sample"
   ClientHeight    =   4215
   ClientLeft      =   2130
   ClientTop       =   2745
   ClientWidth     =   7470
   BeginProperty Font 
      Name            =   "Tahoma"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "Devmode.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4215
   ScaleWidth      =   7470
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton Command1 
      Cancel          =   -1  'True
      Caption         =   "Close"
      Height          =   375
      Left            =   6240
      TabIndex        =   13
      Top             =   3600
      Width           =   1125
   End
   Begin VB.CheckBox Check1 
      Caption         =   "D&ebug Output"
      Height          =   375
      Left            =   3000
      TabIndex        =   12
      Top             =   3600
      Width           =   1335
   End
   Begin VB.CommandButton ButtonPreview 
      Caption         =   "Pre&view..."
      Height          =   375
      Left            =   120
      TabIndex        =   11
      Top             =   3600
      Width           =   1125
   End
   Begin VB.CommandButton ButtonPrint 
      Caption         =   "&Print..."
      Height          =   375
      Left            =   1560
      TabIndex        =   10
      Top             =   3600
      Width           =   1125
   End
   Begin VB.Frame Frame2 
      Caption         =   "Paper"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1935
      Left            =   3840
      TabIndex        =   9
      Top             =   1440
      Width           =   3495
      Begin VB.ComboBox Combo3 
         Height          =   315
         Left            =   720
         Style           =   2  'Dropdown List
         TabIndex        =   23
         Top             =   1400
         Width           =   2535
      End
      Begin VB.TextBox Text2 
         Height          =   315
         Left            =   720
         TabIndex        =   20
         Top             =   1040
         Width           =   615
      End
      Begin VB.TextBox Text1 
         Height          =   315
         Left            =   720
         TabIndex        =   18
         Top             =   680
         Width           =   615
      End
      Begin VB.ComboBox Combo2 
         Height          =   315
         Left            =   720
         Style           =   2  'Dropdown List
         TabIndex        =   14
         Top             =   320
         Width           =   2535
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Quality:"
         Height          =   195
         Index           =   7
         Left            =   120
         TabIndex        =   22
         Top             =   1440
         Width           =   570
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "mm"
         Height          =   195
         Index           =   6
         Left            =   1440
         TabIndex        =   21
         Top             =   1080
         Width           =   240
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "mm"
         Height          =   195
         Index           =   5
         Left            =   1440
         TabIndex        =   19
         Top             =   720
         Width           =   240
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Height:"
         Height          =   195
         Index           =   4
         Left            =   120
         TabIndex        =   17
         Top             =   1080
         Width           =   525
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Width:"
         Height          =   195
         Index           =   3
         Left            =   120
         TabIndex        =   16
         Top             =   720
         Width           =   480
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Name:"
         Height          =   195
         Index           =   2
         Left            =   120
         TabIndex        =   15
         Top             =   360
         Width           =   465
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Printer"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1215
      Left            =   120
      TabIndex        =   4
      Top             =   1440
      Width           =   3495
      Begin VB.ComboBox Combo1 
         Height          =   315
         Left            =   720
         Style           =   2  'Dropdown List
         TabIndex        =   7
         Top             =   320
         Width           =   2535
      End
      Begin VB.Label Label6 
         Caption         =   "printerport"
         Height          =   255
         Left            =   720
         TabIndex        =   8
         Top             =   720
         Width           =   2535
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Port:"
         Height          =   195
         Index           =   1
         Left            =   120
         TabIndex        =   6
         Top             =   720
         Width           =   360
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Name:"
         Height          =   195
         Index           =   0
         Left            =   120
         TabIndex        =   5
         Top             =   360
         Width           =   465
      End
   End
   Begin ListLabel.ListLabel ListLabel1 
      Left            =   5760
      Top             =   3600
      _Version        =   65537
      _ExtentX        =   661
      _ExtentY        =   661
      _StockProps     =   64
      Language        =   -1
      DialogMode      =   14
      DialogFrame     =   0
      Dialog3DText    =   1
      DialogButtons   =   1
      NewExpressions  =   1
      TableColoring   =   0
      TabStops        =   0
      EnablePageCallback=   0   'False
      EnableProjectCallback=   0   'False
      EnableObjectCallback=   0   'False
      EnableHelpCallback=   0   'False
      OnlyOneTable    =   0   'False
      MultipleTableLines=   0   'False
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
      NoParameterCheck=   -1  'True
      NoNoTableCheck  =   -1  'True
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
      IncludeFontDescent=   0   'False
      Dummy6          =   -1  'True
      UseChartFields  =   0   'False
      Dummy7          =   -1  'True
      ProjectPassword =   ""
      LicensingInfo   =   ""
      IncrementalPreview=   -1  'True
      Dummy5          =   -1  'True
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
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
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   435
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
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
      Left            =   120
      TabIndex        =   2
      Top             =   720
      Width           =   405
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Dieses Beispiel demonstriert die Verwendung des LlSetPrinterInPrinterFile Befehles"
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
      Left            =   600
      TabIndex        =   1
      Top             =   120
      Width           =   5175
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "This example demonstrates the usage of the LlSetPrinterInPrinterFile command"
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
      Left            =   600
      TabIndex        =   0
      Top             =   720
      Width           =   5175
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'======================================================
Sub DefineVars()
'======================================================

    'D:   Index des Druckers im Printers-Collection
    'US: Index of printer in Printers-Collection
    prn% = Combo1.ListIndex

    'D:   Variablen definieren und mit Inhalt füllen
    'US: Define variables and fill with content
    ret% = ListLabel1.LlDefineVariable("Printer-Name", Printers(prn%).DeviceName)
    ret% = ListLabel1.LlDefineVariable("Printer-Port", Printers(prn%).Port)
    
End Sub

'======================================================
Sub PrintThis(PrintMode As Integer)
'======================================================
    
    'D:   Deklarationen
    'US: Declarations
    Dim MyDevMode As DEVMODEA
    
    'D:   DevMode-Struktur erzeugen
    'US: Create DevMode-structure
    ReadDevMode Printers(Combo1.ListIndex).DeviceName, MyDevMode
    
    'D:   DevMode-Struktur manipulieren
    'US: Manipulate DevMode-structure
    ChangeDevMode MyDevMode
    
    'D:   DevMode-Struktur in P-Datei schreiben
    'US: Write DevMode-Struktur to P-file
    ret% = LlSetPrinterInPrinterFile(ListLabel1.hJob, LL_PROJECT_CARD, App.Path & "\devmode.crd", 0, Printers(Combo1.ListIndex).DeviceName, MyDevMode)
    
    'D:   Druck starten
    'US: Start printing
    ret% = ListLabel1.LlPrintWithBoxStart(LL_PROJECT_CARD, App.Path & "\devmode.crd", PrintMode, LL_BOXTYPE_STDWAIT, hwnd, "Printing card")
 
    'D:   Variablen füllen
    'US: Fill variables
    DefineVars
    
    'D:   Variablen drucken
    'US: Print variables
    ListLabel1.LlPrint

    'D:   Druck beenden
    'US: Ends printjob
    ret% = ListLabel1.LlPrintEnd(0)
End Sub

'======================================================
Private Sub ButtonPreview_Click()
'======================================================

    'D:   Druckt das Projekt als Vorschau aus
    'US: Prints to preview
    PrintThis LL_PRINT_PREVIEW
    
End Sub

'======================================================
Private Sub ButtonPrint_Click()
'======================================================

    'D:   Druckt das Projekt auf dem Drucker aus
    'US: Prints to printer
    PrintThis (LL_PRINT_EXPORT)

End Sub

'======================================================
Private Sub Check1_Click()
'======================================================
    
    'D:   (De)Aktiviert Debug-Ausgaben
    'US: enables or disables debug-print
    If Check1.Value = 1 Then
        MsgBox ("D:   DEBWIN muss vor Visual Basic gestartet werden" & Chr(13) & Chr(10) & "US: DEBWIN must be started before Visual Basic")
        ListLabel1.LlSetDebug 1
    Else
        ListLabel1.LlSetDebug 0
    End If

End Sub

'======================================================
Private Sub Combo1_Click()
'======================================================
    
    With Printers(Combo1.ListIndex)
        
        Label6.Caption = .Port
        
        Combo2.ListIndex = IIf(.PaperSize = 256, 41, .PaperSize)
        
        Combo3.ListIndex = 2
        For a% = 0 To 2
            If .PrintQuality = Combo3.List(a%) Then Combo3.ListIndex = a%
        Next a%
    
    End With
    
End Sub


'======================================================
Private Sub Combo2_Click()
'======================================================
    
    If Combo2.ListIndex = 41 Then
        Text1.Enabled = True
        Text2.Enabled = True
    Else
        Text1.Enabled = False
        Text2.Enabled = False
    End If

End Sub

'======================================================
Private Sub Command1_Click()
'======================================================

    'D:   Beispiel beenden
    'US: Close sample
    End

End Sub

'======================================================================================
Private Sub Form_Load()
'======================================================================================
'
' Copyright (C) combit GmbH
'
'--------------------------------------------------------------------------------------
' File   : demovde.vbp
' Module : devmode
' Descr. : D:   Dieses Beispiel demonstriert die Verwendung des
'              LlSetPrinterInPrinterFile  Befehles
'          US: This example demonstrates the usage of the
'              LlSetPrinterInPrinterFile command
'======================================================================================

'D:   Ist ein Drucker installiert?
'US: Any printer installed?
If Printers.Count = 0 Then
    MsgBox "D:   Kein Drucker installiert" & Chr(13) & Chr(10) & "US: No printer installed", 16, "List & Label Devmode Sample"
    End
End If

'D:   Zentriert die Form auf dem Desktop
'US: Center form to desktop
left = (Screen.Width - Width) / 2
top = (Screen.Height - Height) / 2

'D:   Einträge für Combo-Boxen laden
'US: Load contents for combo-boxes
LoadCombos

'D:   Markierung auf Standard-Drucker setzen
'US: Set listindex to default printer
For a% = 0 To Printers.Count - 1
    If Printers(a%).DeviceName = Printer.DeviceName Then
        Combo1.ListIndex = a%
        Exit For
    End If
Next a%

End Sub

'======================================================
Private Sub ListLabel1_CmndDefineVariables(ByVal nUserData As Long, ByVal bDummy As Long, pnProgressInPerc As Long, pbLastRecord As Long)
'======================================================

    'D:   Variablen in List & Label definieren
    'US: Define List & Label variables
'    ret% = ListLabel1.LlDefineVariableExt("RTF-Field", RichTextBox1.TextRTF, LL_RTF)

    'D:   Nur eine zu druckende Variable nötig
    'US: Only one variable needed
    If bDummy = 0 Then pbLastRecord = 1

End Sub

'======================================================
Sub LoadCombos()
'======================================================

    'D:   Drucker
    'US: Printers
    For a% = 0 To Printers.Count - 1
        Combo1.AddItem Printers(a%).DeviceName
    Next a%

    'D:   Papier
    'US: Paper
    Combo2.AddItem "Letter 8 1/2 x 11 in"
    Combo2.AddItem "Letter Small 8 1/2 x 11 in"
    Combo2.AddItem "Tabloid 11 x 17 in"
    Combo2.AddItem "Ledger 17 x 11 in"
    Combo2.AddItem "Legal 8 1/2 x 14 in"
    Combo2.AddItem "Statement 5 1/2 x 8 1/2 in"
    Combo2.AddItem "Executive 7 1/4 x 10 1/2 in"
    Combo2.AddItem "A3 297 x 420 mm"
    Combo2.AddItem "A4 210 x 297 mm"
    Combo2.AddItem "A4 Small 210 x 297 mm"
    Combo2.AddItem "A5 148 x 210 mm"
    Combo2.AddItem "B4 250 x 354"
    Combo2.AddItem "B5 182 x 257 mm"
    Combo2.AddItem "Folio 8 1/2 x 13 in"
    Combo2.AddItem "Quarto 215 x 275 mm"
    Combo2.AddItem "10x14 in"
    Combo2.AddItem "11x17 in"
    Combo2.AddItem "Note 8 1/2 x 11 in"
    Combo2.AddItem "Envelope #9 3 7/8 x 8 7/8"
    Combo2.AddItem "Envelope #10 4 1/8 x 9 1/2"
    Combo2.AddItem "Envelope #11 4 1/2 x 10 3/8"
    Combo2.AddItem "Envelope #12 4 \276 x 11"
    Combo2.AddItem "Envelope #14 5 x 11 1/2"
    Combo2.AddItem "C size sheet"
    Combo2.AddItem "D size sheet"
    Combo2.AddItem "E size sheet"
    Combo2.AddItem "Envelope DL 110 x 220mm"
    Combo2.AddItem "Envelope C5 162 x 229 mm"
    Combo2.AddItem "Envelope C3  324 x 458 mm"
    Combo2.AddItem "Envelope C4  229 x 324 mm"
    Combo2.AddItem "Envelope C6  114 x 162 mm"
    Combo2.AddItem "Envelope C65 114 x 229 mm"
    Combo2.AddItem "Envelope B4  250 x 353 mm"
    Combo2.AddItem "Envelope B5  176 x 250 mm"
    Combo2.AddItem "Envelope B6  176 x 125 mm"
    Combo2.AddItem "Envelope 110 x 230 mm"
    Combo2.AddItem "Envelope Monarch 3.875 x 7.5 in"
    Combo2.AddItem "6 3/4 Envelope 3 5/8 x 6 1/2 in"
    Combo2.AddItem "US Std Fanfold 14 7/8 x 11 in"
    Combo2.AddItem "German Std Fanfold 8 1/2 x 12 in"
    Combo2.AddItem "German Legal Fanfold 8 1/2 x 13 in"
    Combo2.AddItem "User defined"

    'D:   Qualität
    'US: Quality
    Combo3.AddItem "100 dpi"
    Combo3.AddItem "300 dpi"
    Combo3.AddItem "600 dpi"

End Sub

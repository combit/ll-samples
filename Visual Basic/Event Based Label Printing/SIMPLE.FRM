VERSION 5.00
Object = "{2213E283-16BC-101D-AFD4-040224009C1D}#29.0#0"; "cmll29o.ocx"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "List & Label  -  Simple Label Sample"
   ClientHeight    =   1995
   ClientLeft      =   3195
   ClientTop       =   6645
   ClientWidth     =   6855
   Icon            =   "simple.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   1995
   ScaleWidth      =   6855
   ShowInTaskbar   =   0   'False
   Begin VB.Data Data1 
      BOFAction       =   1  'BOF
      Caption         =   "Data1"
      Connect         =   "Access 2000;"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      EOFAction       =   1  'EOF
      Exclusive       =   -1  'True
      Height          =   300
      Left            =   5160
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   0  'Table
      RecordSource    =   "Article"
      Top             =   1080
      Visible         =   0   'False
      Width           =   1692
   End
   Begin VB.CommandButton ButtonPreview 
      Caption         =   "&Print/ Preview/ Export"
      Height          =   375
      Left            =   1560
      TabIndex        =   3
      Top             =   1440
      Width           =   2175
   End
   Begin VB.CommandButton ButtonDesign 
      Caption         =   "&Design..."
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   1440
      Width           =   1335
   End
   Begin VB.CheckBox Check1 
      Caption         =   "D&ebug Output"
      Height          =   375
      Left            =   4560
      TabIndex        =   4
      Top             =   1440
      Width           =   1335
   End
   Begin ListLabel.ListLabel ListLabel1 
      Left            =   6240
      Top             =   1440
      _Version        =   65537
      _ExtentX        =   1085
      _ExtentY        =   873
      _StockProps     =   64
      Language        =   0
      DialogMode      =   14
      DialogFrame     =   0
      Dialog3DText    =   0
      DialogButtons   =   1
      NewExpressions  =   1
      TableColoring   =   0
      TabStops        =   0
      EnablePageCallback=   -1  'True
      EnableProjectCallback=   -1  'True
      EnableObjectCallback=   -1  'True
      EnableHelpCallback=   -1  'True
      OnlyOneTable    =   0   'False
      MultipleTableLines=   0   'False
      SortVariables   =   -1  'True
      HelpAvailable   =   -1  'True
      Dummy8          =   0   'False
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
   Begin VB.Label Label4 
      Caption         =   "This example demonstrates how to design, print and export labels"
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
      TabIndex        =   6
      Top             =   720
      Width           =   6165
   End
   Begin VB.Label Label3 
      Caption         =   "Dieses Beispiel demonstriert das Designen, Drucken und Exportieren von Etiketten"
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
      TabIndex        =   5
      Top             =   120
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
      Left            =   120
      TabIndex        =   1
      Top             =   720
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
      Left            =   120
      TabIndex        =   0
      Top             =   120
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
    
    'D:   Springt zum ersten Datensatz
    'US: Jump to first record
    Form1.Data1.Recordset.MoveFirst
    
    'D:   Startet den Designer mit dem Titel "Article labels" und der Datei "simple.lbl"
    'US: Opens "simple.lbl" within the designer titled "Article labels"
    ListLabel1.Design 0, hWnd, "Design Labels", LL_PROJECT_LABEL, "simple.lbl", 1
    
End Sub

'======================================================
Private Sub ButtonPreview_Click()
'======================================================
    
    'D:   Springt zum ersten Datensatz
    'US: Jump to first record
    Form1.Data1.Recordset.MoveFirst
    
    'D:   Druckt das Projekt "simple.lbl" als Vorschau aus
    'US: Prints "simple.lbl" to preview
    ret% = ListLabel1.Print(0, LL_PROJECT_LABEL, "simple.lbl", 1, LL_PRINT_EXPORT, _
                            LL_BOXTYPE_STDWAIT, hWnd, "Print labels to preview", True, Environ$("temp"))

End Sub

'======================================================
Private Sub ButtonPrint_Click()
'======================================================
    
    'D:   Springt zum ersten Datensatz
    'US: Jump to first record
    Form1.Data1.Recordset.MoveFirst
    
    'D:   Druckt das Projekt "simple.lbl" auf dem Drucker aus
    'US: Prints "simple.lbl" to printer
	
    ret% = ListLabel1.Print(0, LL_PROJECT_LABEL, "simple.lbl", 1, LL_PRINT_EXPORT, _
                            LL_BOXTYPE_STDWAIT, hWnd, "Print labels to printer", True, Environ$("temp"))

End Sub


'======================================================
Private Sub Check1_Click()
'======================================================
    
    'D:   (De)Aktiviert Debug-Ausgaben
    'US: enables or disables debug-print
    If Check1.Value = 1 Then
        MsgBox ("D:   DEBWIN muss vor Visual Basic gestartet werden" & Chr(13) & Chr(10) & "US: DEBWIN must be started before Visual Basic")
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
' File   : simble.vbp, simple.frm, cmll29.bas
' Module : simple label sample
' Descr. : D:   Dieses Beispiel demonstriert das Designen und Drucken von Etiketten.
'          US: This example demonstrates how to design and print labels.
'======================================================================================

'D:   Zentriert die Form auf dem Desktop
'US: Center form to desktop
left = (Screen.Width - Width) / 2: top = (Screen.Height - Height) / 2

'D:   Wechselt auf Laufwerk & Verzeichnis der Beispiel-Anwendung
'US: Change to drive & path of example-app
ChDrive App.Path
ChDir App.Path

'D:   Schreibe in Path$ das übergeordnete Verzeichnis
'US: Set Path$ to parent-directory
Path$ = App.Path
While Mid(Path$, Len(Path$), 1) <> "\"
    Path$ = left(Path$, Len(Path$) - 1)
Wend

'D:   Lädt die Access-Datenbank
'US: Load Access-database
Data1.DatabaseName = Path$ & "simple.mdb"

'D:   Setzt die List & Label Sprache auf einen Default Wert
'US: Set the List & Label language to a default value
ListLabel1.Language = CMBTLANG_DEFAULT

End Sub





'======================================================
Private Sub ListLabel1_CmndDefineVariables(ByVal nUserData As Long, ByVal bDummy As Long, pnProgressInPerc As Long, pbLastRecord As Long)
'======================================================

'D:   Dieser Event wird von den List & Label Befehlen Print und Design ausgelöst
'    Er wird für jeden Datensatz aufgerufen um die Variablen und deren Inhalt
'    an List & Label zu übergeben.
'US: This event is called by the List & Label methods Print and Design
'    It will be called for each record to define the variables and their
'    contents
    
    Dim i As Integer
    
    'D:   Wiederholung für alle Felder eines Datensatzes
    'UR: Loop for each field in the present recordset
    For i = 0 To Form1.Data1.Recordset.Fields.Count - 1
        
        'D:   Wiederholung für alle Felder eines Datensatzes
        'UR: Loop for each field in the present recordset
        Select Case Form1.Data1.Recordset.Fields(i).Type
                                            
            'D:   Numerisches Feld
            'US: Numeric field
            Case 3, 4, 6, 7:     para = LL_NUMERIC:      content$ = Form1.Data1.Recordset.Fields(i)
            
            'D:   Falls der Datentyp "Datum" ist, Umwandlung in einen numerischen Datumswert
            'US: If datatype "Date" convert to numeric date-value
            Case 8:             para = LL_DATE_MS:      a! = CDate(Form1.Data1.Recordset.Fields(i)): content$ = a!:
            
            'D:   Entscheidungsfeld (Ja/Nein), Boolean
            'US: True/False field, boolean
            Case 1:            para = LL_BOOLEAN:      content$ = Form1.Data1.Recordset.Fields(i)
            
            'D:   Zeichenformat = Text
            'US: Characterformat = Text
            Case Else:          para = LL_TEXT:         content$ = Form1.Data1.Recordset.Fields(i)
        
        End Select
        
        nRet = Form1.ListLabel1.LlDefineVariableExt(Form1.Data1.Recordset.Fields(i).Name, _
                                                      content$, para)
    
    Next i

    'D:   Werden Echt-Daten benötigt? (nicht bei Designer-Aufruf)
    'US: Is real data needed? (not when method Design has been called)
    If bDummy = 0 Then

        'D:   Gehe zum nächsten Datensatz
        'US: Jump to next record
        pnProgressInPerc = Form1.Data1.Recordset.PercentPosition
        Form1.Data1.Recordset.MoveNext

        'D:   Wenn kein weiterer Datensatz mehr folgt, dann wird der Druck beendet
        'US: If there is no more recordset printing will be finished
        If Form1.Data1.Recordset.EOF = True Then pbLastRecord = 1
        
    End If

End Sub

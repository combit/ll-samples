VERSION 5.00
Object = "{2213E283-16BC-101D-AFD4-040224009C1D}#29.0#0"; "cmll29o.ocx"
Begin VB.Form Form1 
   Caption         =   "List & Label DOM Demo"
   ClientHeight    =   7050
   ClientLeft      =   165
   ClientTop       =   465
   ClientWidth     =   6165
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   7050
   ScaleWidth      =   6165
   StartUpPosition =   3  'Windows Default
   Begin ListLabel.ListLabel LL 
      Left            =   2280
      Top             =   6480
      _Version        =   65537
      _ExtentX        =   873
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
   Begin VB.CommandButton Preview 
      Caption         =   "Print..."
      Height          =   375
      Left            =   4680
      TabIndex        =   17
      Top             =   6480
      Width           =   1215
   End
   Begin VB.CheckBox DebugCheckBox 
      Caption         =   " Enable Debug"
      Height          =   255
      Left            =   240
      TabIndex        =   16
      Top             =   6480
      Width           =   1455
   End
   Begin VB.Frame Frame1 
      Caption         =   "Project Layout"
      Height          =   4575
      Left            =   240
      TabIndex        =   5
      Top             =   1680
      Width           =   5655
      Begin VB.CommandButton Deselect 
         Caption         =   "<"
         Height          =   375
         Left            =   2640
         TabIndex        =   15
         Top             =   1920
         Width           =   375
      End
      Begin VB.CommandButton Select 
         Caption         =   ">"
         Height          =   375
         Left            =   2640
         TabIndex        =   14
         Top             =   1440
         Width           =   375
      End
      Begin VB.TextBox Text2 
         Height          =   375
         Left            =   240
         TabIndex        =   13
         Top             =   3960
         Width           =   5175
      End
      Begin VB.TextBox Text1 
         Height          =   375
         Left            =   240
         TabIndex        =   11
         Text            =   "Dynamically created Project"
         Top             =   3240
         Width           =   5175
      End
      Begin VB.ListBox List2 
         Height          =   2010
         Left            =   3360
         TabIndex        =   7
         Top             =   840
         Width           =   2055
      End
      Begin VB.ListBox List1 
         Height          =   2010
         Left            =   240
         TabIndex        =   6
         Top             =   840
         Width           =   2055
      End
      Begin VB.Label Label8 
         Caption         =   "Logo:"
         Height          =   255
         Left            =   240
         TabIndex        =   12
         Top             =   3720
         Width           =   615
      End
      Begin VB.Label Label7 
         Caption         =   "Title:"
         Height          =   255
         Left            =   240
         TabIndex        =   10
         Top             =   3000
         Width           =   735
      End
      Begin VB.Label Label6 
         Caption         =   "Selected Fields:"
         Height          =   255
         Left            =   3360
         TabIndex        =   9
         Top             =   480
         Width           =   1335
      End
      Begin VB.Label Label5 
         Caption         =   "Avaible Fields:"
         Height          =   255
         Left            =   240
         TabIndex        =   8
         Top             =   480
         Width           =   1215
      End
   End
   Begin VB.CommandButton Design 
      Caption         =   "Design..."
      Height          =   375
      Left            =   3240
      TabIndex        =   0
      Top             =   6480
      Width           =   1335
   End
   Begin VB.Label Label4 
      Caption         =   "This example demonstrates the dynamic creation of one report by using a custom print loop"
      Height          =   495
      Left            =   600
      TabIndex        =   4
      Top             =   960
      Width           =   5415
   End
   Begin VB.Label Label3 
      Caption         =   "US:"
      Height          =   375
      Left            =   240
      TabIndex        =   3
      Top             =   960
      Width           =   375
   End
   Begin VB.Label Label2 
      Caption         =   "Dieses Beispiel demonstriert die dynamische Erstellung eines Reports über eine eigene Druckschleife "
      Height          =   495
      Left            =   600
      TabIndex        =   2
      Top             =   240
      Width           =   5295
   End
   Begin VB.Label Label1 
      Caption         =   "D:"
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   240
      Width           =   375
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub GenerateLLProject()

    Dim sFile
    sFile = App.Path & "\dom.lst"
    Dim hProj As Long
    'D: Ein neues Listen-Projekt mit dem Namen 'dom.lst' erstellen
    'US: Create a new list project called 'dom.lst'
    
    LL.LlProjectOpen LL_PROJECT_LIST, sFile, LL_PRJOPEN_CD_CREATE_ALWAYS Or LL_PRJOPEN_AM_READWRITE Or LL_PRJOPEN_EM_IGNORE_FORMULAERRORS
    LL.LlDomGetProject hProj
    'D: Eine neue Projektbeschreibung dem Projekt zuweisen
    'US: Assign new project description to the project
    LL.LlDomSetProperty hProj, "ProjectParameters.LL.ProjectDescription.Contents", Text1.Text
    
    'D: Das Objektlistenobjekt erzeugen
    'US: Get the object list object
    Dim hObjList As Long
    LL.LlDomGetObject hProj, "Objects", hObjList
    
    'D: Ein leeres Text Objekt erstellen
    'US: Create an empty text object"
    Dim hObjText As Long
    LL.LlDomCreateSubobject hObjList, 0, "Text", hObjText
    LL.LlDomSetProperty hObjText, "Name", "My new Textobject"
 
    'D: Setzen von Eigenschaften für das Textobjekt
    'US: Set some properties for the text object
    LL.LlDomSetProperty hObjText, "Position.Left", "10000"
    LL.LlDomSetProperty hObjText, "Position.Top", "10000"
    LL.LlDomSetProperty hObjText, "Position.Width", "73500"
    LL.LlDomSetProperty hObjText, "Position.Height", "27000"
        
    'D: Der Ebene "Erste Seite" zuweisen
    'US: Assign to "First Page" layer
    LL.LlDomSetProperty hObjText, "LayerID", "1"
    
    'D: Hinzufügen eines Absatzes und setzen diverser Eigenschaften
    'US: Add a paragraph to the text object and set some properties
    Dim hObjParagraphList As Long
    LL.LlDomGetObject hObjText, "Paragraphs", hObjParagraphList
    Dim hObjParagraph As Long
    LL.LlDomCreateSubobject hObjParagraphList, 0, "Paragraphs", hObjParagraph
    LL.LlDomSetProperty hObjParagraph, "Contents", "ProjectName"
    LL.LlDomSetProperty hObjParagraph, "Font.Bold", "True"
    LL.LlDomSetProperty hObjParagraph, "Font.Size", "16.0"
    
    'D: Hinzufügen eines Grafikobjekts
    'US: Add a drawing object
    Dim hObjDrawingObject As Long
    LL.LlDomCreateSubobject hObjList, 0, "Drawing", hObjDrawingObject
    LL.LlDomSetProperty hObjDrawingObject, "Source.FileInfo.Filename", Text2.Text
    LL.LlDomSetProperty hObjDrawingObject, "Position.Left", "120000"
    LL.LlDomSetProperty hObjDrawingObject, "Position.Top", "9700"
    LL.LlDomSetProperty hObjDrawingObject, "Position.Width", "73500"
    LL.LlDomSetProperty hObjDrawingObject, "Position.Height", "36200"
    
    'D: Der Ebene "Erste Seite" zuweisen
    'US: Assign to "First Page" layer
    LL.LlDomSetProperty hObjDrawingObject, "LayerID", "1"
       
    'D: Hinzufügen eines Berichtscontainers und setzen diverser Eigenschaften
    'US: Add a report container and set some properties
    Dim hObjReportContainer As Long
    LL.LlDomCreateSubobject hObjList, 0, "ReportContainer", hObjReportContainer
    LL.LlDomSetProperty hObjReportContainer, "Position.Left", "27000"
    LL.LlDomSetProperty hObjReportContainer, "Position.Top", "103500"
    LL.LlDomSetProperty hObjReportContainer, "Position.Width", "153400"
    LL.LlDomSetProperty hObjReportContainer, "Position.Height", "159500"
    
    'D: Eine Tabelle im Berichtscontainer hinzufügen
    'US: Add a table to the report container
    Dim hObjSubItems As Long
    LL.LlDomGetObject hObjReportContainer, "SubItems", hObjSubItems
    Dim hObjTable As Long
    LL.LlDomCreateSubobject hObjSubItems, 0, "Table", hObjTable
    
    'D: Eine neue Datenzeile hinzufügen
    'US: Add a new data line
    Dim hObjTableLines As Long
    LL.LlDomGetObject hObjTable, "Lines", hObjTableLines
    Dim hObjTableData As Long
    LL.LlDomGetObject hObjTableLines, "Data", hObjTableData
    Dim hObjTableLine As Long
    LL.LlDomCreateSubobject hObjTableData, 0, "Line", hObjTableLine
    LL.LlDomSetProperty hObjTableLine, "Name", "My new table line"
    
    Dim sContainerPositionWidth As String
    Dim nContainerPositionWidth As Double
    LL.LlDomGetProperty hObjReportContainer, "Position.Width", sContainerPositionWidth
    nContainerPositionWidth = CDbl(sContainerPositionWidth)
    
    'D: Kopfzeile hinzufügen
    'US: Add header line
    Dim hObjTableHeader As Long
    LL.LlDomGetObject hObjTableLines, "Header", hObjTableHeader
    Dim hObjTableHeaderLine As Long
    LL.LlDomCreateSubobject hObjTableHeader, 0, "Line", hObjTableHeaderLine
    
    'D: Kopf- und Datenzeile mit den gewählten Feldern füllen
    'US: Add the selected fields to the header and data line
    Dim hObjTableHeaderFields As Long
    LL.LlDomGetObject hObjTableHeaderLine, "Fields", hObjTableHeaderFields
    Dim hObjTableDataFields As Long
    LL.LlDomGetObject hObjTableLine, "Fields", hObjTableDataFields
    
    Dim nItemCount As Integer
    Dim sfieldWidth As String
    nItemCount = List2.ListCount
    
    Dim j
    For j = 0 To (nItemCount - 1)
        
        Dim sContents As String
        Dim nfieldWidth As Double
        nfieldWidth = nContainerPositionWidth / nItemCount
        sfieldWidth = CStr(nfieldWidth)
        sContents = List2.List(j)
        
        'D: Kopfzeile füllen
        'US: Define header line
        Dim hObjTableHeaderField As Long
        LL.LlDomCreateSubobject hObjTableHeaderFields, j, "Text", hObjTableHeaderField
        LL.LlDomSetProperty hObjTableHeaderField, "Contents", "'" & sContents & "'"
        LL.LlDomSetProperty hObjTableHeaderField, "Filling.Style", "1"
        LL.LlDomSetProperty hObjTableHeaderField, "Filling.Color", "RGB(204,204,255)"
        LL.LlDomSetProperty hObjTableHeaderField, "Font.Bold", "True"
        LL.LlDomSetProperty hObjTableHeaderField, "Width", sfieldWidth
            
        'D: Datenzeile füllen
        'US: Define data line
        Dim hObjTableDataField As Long
        LL.LlDomCreateSubobject hObjTableDataFields, j, "Text", hObjTableDataField
        LL.LlDomSetProperty hObjTableDataField, "Contents", sContents
        LL.LlDomSetProperty hObjTableDataField, "Width", sfieldWidth
            
    Next j
    
    'D: Projekt speichern
    'US: Save project
    LL.LlProjectSave sFile
    
    'D: Projekt schliessen
    'US: Close project
    LL.LlProjectClose


End Sub

Private Sub Deselect_Click()
    If List2.ListIndex >= 0 Then
        If List2.Selected(List2.ListIndex) Then
            List1.AddItem List2.List(List2.ListIndex), 0
            List2.RemoveItem List2.ListIndex
            List2.Refresh
        End If
    End If
End Sub

Private Sub Design_Click()

    'D:   Variablen und Felder zurücksetzen
    'US:  Reset variables and fields
    LL.LlDefineVariableStart
    LL.LlDefineFieldStart
    
    GenerateLLProject
    
    'D:   Hier werden virtuelle Variablen definiert.
    '     Wichtig: Normalerweise wuerden Sie hier ihre Datenbankfelder anmelden
    'US:  Define the variables virtually
    '     Important: Normally you use here your database functions
    DefineFields 0, False
    DefineVariables
    
    If (LL.LlDefineLayout(hWnd, "Designer", LL_PROJECT_LIST, App.Path & "\dom.lst") < 0) Then
        MsgBox "Error by calling LlDefineLayout", "List & Label Sample App"
    End If
        
    
    
End Sub

Private Sub Form_Load()

    'D:   Zentriert die Form auf dem Desktop
    'US: Center form to desktop
    left = (Screen.Width - Width) / 2: top = (Screen.Height - Height) / 2
    
    Text2.Text = App.Path & "\sunshine.gif"
    Call DefineFields(0, True)

End Sub


Private Sub Preview_Click()

    Dim Ret As Integer
    Dim sFile
    sFile = App.Path & "\dom.lst"
    
    GenerateLLProject
    
    'D:   Zurücksetzen der internen Variablen-Puffer
    'US: define variables for load check
    LL.LlDefineVariableStart
    LL.LlDefineFieldStart
    DefineVariables
    DefineFields 0, False
    
    'D:   Druck starten
    'US: Start printing
    Ret = LL.LlPrintWithBoxStart(LL_PROJECT_LIST, sFile, LL_PRINT_EXPORT, LL_BOXTYPE_STDABORT, Form1.hWnd, "Printing report...")

    'D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).
    'US: Most frequent cause for error code: -23 (Sytax Error).
    If Ret <> 0 Then
        MsgBox ("Error during LlPrintWithBoxStart")
        Exit Sub
    End If
    
    LL.LlPrintSetOptionString LL_PRNOPTSTR_EXPORT, "PRV"
    
    Ret = LL.LlPrintOptionsDialog(Form1.hWnd, "Choose printing options")
    If Ret = LL_ERR_USER_ABORTED Then
        LL.LlPrintEnd (0)
        Exit Sub
    End If
    
    Dim nRecCount, nLastPage, nRecno
    nRecCount = 11
    nRecno = 1
    nLastPage = LL.LlPrintGetOption(LL_OPTION_LASTPAGE)
    
    'D:  Erste Seite initialisieren
    'US: Initialize first page
    While LL.LlPrint = LL_WRN_REPEAT_DATA
    Wend
    
    'D:  Druckschleife
    '    Diese wird so lange wiederholt, bis saemtliche Daten abgearbeitet wurden, oder
    '    ein Fehler auftritt.
    'US: do printing loop only when there is any data to be printed and no error has occurred:
    While (nRecno < nRecCount And (nRet = 0) And (LL.LlPrintGetCurrentPage() <= nLastPage))
        
        'D:  Tabellenzeile ausgeben, auf Rückgabewert prüfen und ggf. Seitenumbruch
        '    oder Abbruch auslösen
        'US: Print table line, check return value and abort printing or wrap pages
        '    if neccessary
        Ret = LL.LlPrintFields
        If Ret = LL_ERR_USER_ABORTED Then
            'D:  Benutzerabbruch
            'US: User aborted
            LL.LlPrintEnd (0)
            Exit Sub
        End If
        'D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
        'US: Wrap pages until record was fully printed
        While Ret = LL_WRN_REPEAT_DATA
            LL.LlPrint
            Ret = LL.LlPrintFields
        Wend

        'D:  Fortschrittsanzeige aktualisieren
        'US: Refresh progress meter
        LL.LlPrintSetBoxText "Printing report...", (100 * nRecno / nRecCount)
        nRecno = nRecno + 1
    Wend
    
    'D:  Druck der Tabelle beenden, angehängte Objekte drucken
    'US: Finish printing the table, print linked objects
    While LL.LlPrintFieldsEnd = LL_WRN_REPEAT_DATA
    Wend
    
    'D:  Druck beenden
    'US: Stop printing
    LL.LlPrintEnd 0
End Sub

Private Sub Select_Click()

    If List1.ListIndex >= 0 Then
        If List1.Selected(List1.ListIndex) Then
            List2.AddItem List1.List(List1.ListIndex), 0
            List1.RemoveItem List1.ListIndex
            List1.Refresh
        End If
    End If


End Sub

Private Sub DebugCheckBox_Click()
    'D:  (De)aktiviert Debug-Ausgaben
    'US: enables or disables debug output
    If DebugCheckBox.Value Then
        Call MsgBox("D:  DEBWIN muss vor Visual Basic gestartet werden" & vbCrLf & _
                    "US: DEBWIN must be started before Visual Basic", vbOKOnly, "")
        LL.LlSetDebug (LL_DEBUG_CMBTLL)
    Else
        LL.LlSetDebug (0)
    End If
End Sub

Function DefineFields(nRecord As Integer, bSet As Boolean)
    'D:   Hier werden virtuelle Felder definiert.
    '     Wichtig: Normalerweise wuerden Sie hier ihre Datenbankfelder anmelden

    'US:  Define the fields virtually
    '     Important: Normally you use here your database functions

    If Not bSet Then
    
    Dim j
    For j = 0 To (List2.ListCount - 1)
        LL.LlDefineField List2.List(j), List2.List(j)
    Next j
    
    Else
    
        Dim i
        For i = 0 To 8
            If i < 3 Then
                List2.AddItem "FixedField" & (i + 1), i
            Else
                List1.AddItem "FixedField" & (i + 1), i - 3
            End If
                
        Next i
    End If
    
    'D:   Definition eines numerischen Feldes
    'US:  Definition of a numerical field
    
    LL.LlDefineFieldExt "FixedField10", "1", LL_NUMERIC

End Function

Function DefineVariables()
    'D:   Definition von zwei Variablen
    'US:  Definition of two variables
    
    LL.LlDefineVariable "ProjectName", Text1.Text
    LL.LlDefineVariable "Logo", Text2.Text
    
End Function
































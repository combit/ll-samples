VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{2213E283-16BC-101D-AFD4-040224009C1C}#28.0#0"; "cmll28o.ocx"
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "List & Label Subreport Demo"
   ClientHeight    =   2475
   ClientLeft      =   150
   ClientTop       =   810
   ClientWidth     =   7425
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2475
   ScaleWidth      =   7425
   Begin VB.TextBox Text1 
      Height          =   285
      Left            =   2160
      TabIndex        =   6
      Text            =   "3"
      Top             =   1800
      Width           =   675
   End
   Begin ListLabel.ListLabel LL 
      Left            =   60
      Top             =   1620
      _Version        =   65537
      _ExtentX        =   979
      _ExtentY        =   979
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
      IncludeFontDescent=   0   'False
      Dummy6          =   -1  'True
      UseChartFields  =   0   'False
      Dummy7          =   -1  'True
      ProjectPassword =   ""
      LicensingInfo   =   ""
      IncrementalPreview=   -1  'True
      Dummy5          =   -1  'True
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   780
      Top             =   1620
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CheckBox DebugCheckBox 
      Caption         =   "&Debug output"
      Height          =   255
      Left            =   5940
      TabIndex        =   4
      Top             =   1800
      Width           =   1335
   End
   Begin VB.Label Label1 
      Caption         =   "Limit record number to"
      Height          =   255
      Left            =   120
      TabIndex        =   5
      Top             =   1800
      Width           =   1815
   End
   Begin VB.Label Label6 
      AutoSize        =   -1  'True
      Caption         =   "using a custom print loop"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   240
      Left            =   420
      TabIndex        =   3
      Top             =   1260
      Width           =   2400
   End
   Begin VB.Label Label5 
      AutoSize        =   -1  'True
      Caption         =   "US: This example demonstrates printing subreports and multiple tables"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   240
      Left            =   120
      TabIndex        =   2
      Top             =   960
      Width           =   7095
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "und mehreren Tabellen"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   240
      Left            =   420
      TabIndex        =   1
      Top             =   600
      Width           =   4020
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "D:  Dieses Beispiel zeigt den Umgang mit Unterberichten"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   240
      Left            =   120
      TabIndex        =   0
      Top             =   300
      Width           =   6900
   End
   Begin VB.Menu FileMnu 
      Caption         =   "&File"
      Begin VB.Menu Open 
         Caption         =   "&Open Access Database"
      End
      Begin VB.Menu Exit1 
         Caption         =   "&Exit"
      End
   End
   Begin VB.Menu EditMnu 
      Caption         =   "&Edit"
      Begin VB.Menu Report1 
         Caption         =   "&Report"
      End
   End
   Begin VB.Menu PrintMnu 
      Caption         =   "&Print"
      Begin VB.Menu Report2 
         Caption         =   "&Report"
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' Copyright (C) combit GmbH
'--------------------------------------------------------------------------------------
'File:     multifm.frm
'Module : subreport sample
'Descr. : D:  Dieses Beispiel demonstriert den Druck von relational verknüpften Tabellen
'             über eine eigene Druckschleife.
'             Bitte beachten Sie, dass dieses Beispiel den Schwerpunkt auf die Grundlagen
'             von List & Label legt, weshalb nur minimales Error-Handling verwendet wird.
'         US: This example demonstrates the printout of relational tables using a custom
'             print loop.
'             In order to focus on the fundamentals of List & Label and prevent
'             code clutter, minimal error handling is done in the example.

'======================================================================================

Option Explicit

Dim FileName As String
Dim Path$
Dim m_sConnStr As String
Dim CleanUpBmpArr()
Dim nBmpFileCounter
Dim sDBPath As String

Dim nUBoundDataTable As Integer
Dim nUBoundDataRelation As Integer

Private Type RecordSetInformation
    sTableName As String
    sRelationName As String
    sParentTable As String
    sChildTable As String
    sParentCol As String
    sChildCol As String
    sSQL As String

End Type

Dim DataTable() As RecordSetInformation
Dim DataRelation() As RecordSetInformation

Private DBOne As ADODB.Connection
Private DBx As ADODB.Connection
Private DBy As ADODB.Connection
Private DB As ADODB.Connection


Private Sub Form_Load()
    sDBPath = App.Path & "\..\..\nwind.mdb"
    Left = (Screen.Width - Width) / 4: Top = (Screen.Height - Height) / 4
    
    'D:  Wechselt auf Laufwerk & Verzeichnis der Beispiel-Anwendung
    'US: Change to drive & path of example-app
    ChDrive App.Path
    ChDir App.Path
    
    'D: Schreibe in Path$ das übergeordnete Verzeichnis
    'US: Set Path$ to parent-directory
    Path$ = App.Path
    While Mid(Path$, Len(Path$), 1) <> "\"
        Path$ = Left(Path$, Len(Path$) - 1)
    Wend
    
    'D:  Lädt die Access-Datenbank
    'US: Load Access-database
    InitDataBase
    'D:  Setzt die List & Label Sprache auf einen Default Wert
    'US: Set the List & Label language to a default value
    LL.Language = CMBTLANG_DEFAULT

End Sub
Private Sub InitDataBase()
    'D:  Lädt die Access-Datenbank
    'US: Load Access-database
    InitADOConnection
    
    InitConnection DBx
    InitConnection DBOne
    InitConnection DBy
End Sub
Private Sub DebugCheckBox_Click()
    'D:  (De)aktiviert Debug-Ausgaben
    'US: enables or disables debug output
    If DebugCheckBox.Value Then
        Call MsgBox("D:  DEBWIN muss vor Visual Basic gestartet werden" & vbCrLf & _
                    "US: DEBWIN must be started before Visual Basic", vbOKOnly, "")
        LL.LlSetDebug (LL_DEBUG_CMBTLL) 'Or LL_DEBUG_CMBTLL_LOGTOFILE)
    Else
        LL.LlSetDebug (0)
    End If
End Sub
Private Sub Exit1_Click()
    Dim i
    For i = 1 To nBmpFileCounter
        Kill (CleanUpBmpArr(i))
    Next

    Unload Form1
End Sub

Private Sub Form_Unload(Cancel As Integer)
    CleanUpConnection DBx
    CleanUpConnection DBOne
    CleanUpConnection DBy
End Sub

Private Sub Open_Click()
CommonDialog1.FileName = sDBPath
CommonDialog1.Filter = "Database (*.mdb)|*.mdb"
CommonDialog1.ShowOpen
sDBPath = CommonDialog1.FileName
CleanUpConnection DBx
CleanUpConnection DBOne
CleanUpConnection DBy
InitDataBase
End Sub

Private Sub Report1_Click()
    FileName = App.Path & "\subrep.lst"
    
    'D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
    '    gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
    '    sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
    'US: Optional call to file selection dialog. Ommit this call and pass the
    '    required file as FileName if you don't want the dialog to appear. If only
    '    existing files should be selectable, remove the "or"ing with LL_FILE_ALSONEW
     If LL.LlSelectFileDlgTitle(Form1.hWnd, "Choose list file", LL_PROJECT_LIST Or LL_FILE_ALSONEW, FileName) <> LL_ERR_USER_ABORTED Then
        
        'D:  Daten definieren
        'US: Define data
        PassDataStructure
        
        
        'D:  Designer mit dem Titel 'Design report' und der gewählten Datei starten
        'US: Opens the chosen file in the designer, sets designer title to 'Design report'
        Call LL.LlDefineLayout(Form1.hWnd, "Design report", LL_PROJECT_LIST, FileName)

    End If
End Sub
Function DefineCurrentSortOrders(oRS As ADODB.Recordset, sTableName)
    'D:  Diese Prozedur definiert für jedes Feld eine Sortierung in List & Label.
    'US: This procedure defines a sort order for each field in List & Label.
    
    'D:  Wiederholung für alle Felder eines Datensatzes
    'UR: Loop for each field in the current recordset
    Dim oField
    For Each oField In oRS.Fields
        Call LL.LlDbAddTableSortOrder(sTableName, oField.Name & " ASC", oField.Name & " [+]")
        Call LL.LlDbAddTableSortOrder(sTableName, oField.Name & " DESC", oField.Name & " [-]")
    Next

End Function
Function DefineCurrentRecord(bIsSubTable As Boolean, RS As ADODB.Recordset, sPrefix As String, bWithUseCheck As Boolean)
    Dim i As Integer
    Dim FieldType As Long
    Dim nRet As Long
    Dim para As Long
    Dim content

    'D:  Diese Prozedur übergibt den aktuellen Datensatz an List & Label.
    'US: This procedure passes the current record to List & Label.
    
    'D:  Nur wenn Tabelle auch im Layout benutzt wird, Felder übergeben}
    'US: If and only if the table is used in the layout delivery of the fields}
    If bWithUseCheck And Len(sPrefix) > 0 And (Form1.LL.LlPrintIsFieldUsed(Mid(sPrefix, 1, Len(sPrefix) - 1) & "*") = 0) Then
            Exit Function
    End If
    
    'D:  Wiederholung für alle Felder eines Datensatzes
    'UR: Loop for each field in the present recordset
    Dim oField
    For Each oField In RS.Fields
    
        'D:  Zur Druckzeit werden nur die benötigten Felder und Variablen übergeben}
        'US: For print time only the needed fields and variables will be transfered}
        If Not bWithUseCheck Or (Form1.LL.LlPrintIsFieldUsed(sPrefix & oField.Name) <> 0) Then
    
            'D:  Umsetzung der Datenbank-Feldtypen in List & Label Feldtypen
            'US: Transform database field types into List & Label field types
            Select Case oField.Type
            
                'D : Zeichenformat = Text
                'US: Characterformat = Text
                Case adVarWChar, adVarChar, adChar, adLongVarChar, adLongVarWChar, adBSTR:
                    para = LL_TEXT
                    content = oField
                
                'D:  Falls der Datentyp "Datum" ist, Umwandlung in einen numerischen Datumswert
                'US: convert datatype "Date" to a numeric date-value
                Case adDate:
                    para = LL_DATE_MS
                    If Not IsNull(oField) Then
                        content = CStr(CSng(CDate(oField)))
                    End If
                
                'D:  Boolean Feld
                'US: boolean field
                Case adBoolean:
                    para = LL_BOOLEAN
                    If oField Then
                        content = ".T."
                    Else
                        content = ".F."
                    End If
                Case adLongVarBinary:
                   para = LL_DRAWING
                   content = WriteBitmap(oField)
                   nBmpFileCounter = nBmpFileCounter + 1
                   ReDim Preserve CleanUpBmpArr(nBmpFileCounter)
                   CleanUpBmpArr(nBmpFileCounter) = content
                   
                
                'D:  Numerisches Feld
                'US: Numeric field
                Case Else:
                    para = LL_NUMERIC
                    content = oField
            
            End Select
            
            'D:  Feldname, -inhalt und -typ an List & Label übergeben
            'US: Declare fieldname, fieldcontent and fieldtype to List & Label
            If IsNull(content) Or IsNull(oField) Then
                nRet = Form1.LL.LlDefineFieldExt(sPrefix & oField.Name, "(NULL)", para)
            Else
                nRet = Form1.LL.LlDefineFieldExt(sPrefix & oField.Name, content, para)
            End If
        End If
    Next
    

End Function

Private Sub Report2_Click()
    
    Dim FileName As String
    Dim ret As Integer
    FileName = "subrep.lst"
    
    'D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
    '    gewünschten Dateinamen übergeben.
    'US: Optional call to file selection dialog. Ommit this call and pass the
    '    required file as FileName if you don't want the dialog to appear.
    If LL.LlSelectFileDlgTitle(Form1.hWnd, "Choose report file", LL_PROJECT_LIST, FileName) = LL_ERR_USER_ABORTED Then
        Exit Sub
    End If

    'D:  Daten definieren. Die hier übergebenen Daten dienen nur der Syntaxprüfung - die Inhalte
    '    brauchen keine Echtdaten zu enthalten
    'US: Define data. The data passed here is only used for syntax checking and doesn't need
    '    to contain real data
    PassDataStructure

    'D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.
    'US: Start print job. Allow all export formats as target. Meter box with cancel button.
    ret = LL.LlPrintWithBoxStart(LL_PROJECT_LIST, FileName, LL_PRINT_EXPORT, LL_BOXTYPE_STDABORT, Form1.hWnd, "Printing report...")

    'D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).
    'US: Most frequent cause for error code: -23 (Sytax Error).
    If ret <> 0 Then
        Dim errorText As String
        Call LL.LlGetErrortext(ret, errorText)
        MsgBox ("Error during LlPrintWithBoxStart" & vbCrLf & "Error No: " & CStr(ret) & vbCrLf & "Error Text: " & CStr(errorText))
        Exit Sub
    End If

    'D:  Druckoptionsdialog. Aufruf ist optional, es können sonst Ausgabeziel und
    '    Exportdateiname über LlXSetParameter() gesetzt werden bzw. der Drucker und
    '    die Druckoptionen über LlSetPrinterInPrinterFile() vorgegeben werden.
    'US: Optional call to print options dialog. You may also set the print target format
    '    and export file name using LlXSetParameter() or set the printer and print options
    '    using LlSetPrinterInPrinterFile()
    ret = LL.LlPrintOptionsDialog(Form1.hWnd, "Choose printing options")
    If ret = LL_ERR_USER_ABORTED Then
        LL.LlPrintEnd (0)
        Exit Sub
    End If

    'D:  Erste Seite initialisieren; auch hier kann schon durch Objekte vor der Tabelle
    '    ein Seitenumbruch ausgelöst werden
    'US: Initialize first page. A page wrap may occur already caused by objects which are
    '    printed before the table
    While LL.LlPrint = LL_WRN_REPEAT_DATA
    Wend
    
    Dim psTableID As String
    Dim psSortOrderID As String
    Dim nTableRet
    
    Dim nTableIndex As Integer
    Dim RSx As ADODB.Recordset
    
    
    Dim nIndexCurrentTable As Integer
    nIndexCurrentTable = 0
    
    'D:  Eigentliche Druckschleife; Wiederholung, solange Daten vorhanden
    'US: Print loop. Repeat while there is still data to print
    If (LL.LlPrintDbGetRootTableCount <> 0) Then
    
        Do
            'D:  Root-Tabelle bestimmen und solange drucken bis keine mehr vorhanden
            'US: determine root table and print until no one is available
            Call LL.LlPrintDbGetCurrentTable(psTableID, 1)
            Call LL.LlPrintDbGetCurrentTableSortOrder(psSortOrderID)
        
            'InitConnection DBx
            nTableIndex = GetIndexOfTable(psTableID)
            InitRecordSet RSx, DBx, DataTable(nTableIndex).sSQL
            RSx.Sort = psSortOrderID
            
            nTableRet = PrintTable(False, RSx, nTableIndex, psSortOrderID, nIndexCurrentTable)
            
            
            nIndexCurrentTable = nIndexCurrentTable + 1
            
        Loop While nTableRet = LL_WRN_TABLECHANGE
    End If
    'D:  Druck beenden
    'US: Stop printing
    LL.LlPrintEnd (0)
    Call CleanUpRecordSet(RSx, DBx)
End Sub
Function PrintTable(bIsSubTable As Boolean, RS1 As ADODB.Recordset, nTabIndex, psSortOrderID As String, nIndexCurrentTable As Integer)
Dim ret As Integer
Dim nZaehl As Integer

Dim psCurrentTable As String, psCurrentSortOrderID As String, psCurrentRelationID As String
Dim RSOne As ADODB.Recordset
Dim nType As Integer
Dim k As Integer
Dim sPrefixstring As String, sPrefixstring2 As String

Dim nRecordDelimiter As Integer
Dim nMaxPerc As Integer, nPercTotal As Integer, nRecCount As Integer
Dim nRecPos As Double

If RS1.RecordCount > 0 Then

    nRecordDelimiter = 0
    
    RS1.MoveFirst
    Do
        If bIsSubTable Then
            'D:  Daten für Untertabellen definieren
            'US: Define data for sub tables
            Call DefineCurrentRecord(True, RS1, DataRelation(nTabIndex).sChildTable & ".", True)
            
            'D:  Daten für 1:1 Rückrelation definieren
            'US: Define data for 1:1 relations
            For nZaehl = 0 To nUBoundDataRelation
                'D:  Checke für die Kind-Tabelle der aktuellen Relation, ob es auch eine Kind-Tabelle
                '    einer anderen Relation gibt
                'US: Check for each child table of the current relation, if a child table of another
                '    relation exists
                If DataRelation(nTabIndex).sChildTable = DataRelation(nZaehl).sChildTable Then
                    'InitConnection DBOne
                    nType = RS1.Fields.Item((DataRelation(nZaehl).sChildCol)).Type
                    DataRelation(nZaehl).sSQL = "SELECT * FROM [" & DataRelation(nZaehl).sParentTable & _
                        "] WHERE [" & DataRelation(nZaehl).sParentCol & "]=" & GetSepFromType(nType) & CStr(RS1.Fields.Item((DataRelation(nZaehl).sChildCol))) & GetSepFromType(nType)
                    
                    sPrefixstring = DataRelation(nZaehl).sChildTable & "." & DataRelation(nZaehl).sChildCol & "@" & DataRelation(nZaehl).sParentTable & "." & DataRelation(nZaehl).sParentCol & ":"
                    'D:  Nur wenn Tabelle auch im Layout benutzt wird, Felder übergeben}
                    'US: If and only if the table is used in the layout delivery of the fields}
                 
                    If Not (Len(sPrefixstring) > 0 And (Form1.LL.LlPrintIsFieldUsed(Mid(sPrefixstring, 1, Len(sPrefixstring) - 1) & "*") = 0)) Then
                        InitRecordSet RSOne, DBOne, DataRelation(nZaehl).sSQL
                        Call DefineCurrentRecord(False, RSOne, sPrefixstring, True)
                    End If
                    
                    'D:  2-stufige Relationen werden berücksichtigt
                    'US: relation depth for 2 relations
                    For k = 0 To nUBoundDataRelation
                        If DataRelation(nZaehl).sParentTable = DataRelation(k).sChildTable Then
                            sPrefixstring = DataRelation(nZaehl).sChildTable & "." & DataRelation(nZaehl).sChildCol & "@" & DataRelation(nZaehl).sParentTable & "." & DataRelation(nZaehl).sParentCol & ":"
                        
                            sPrefixstring2 = sPrefixstring & DataRelation(k).sChildTable & _
                                        "." & DataRelation(k).sChildCol & "@" & DataRelation(k).sParentTable & "." & DataRelation(k).sParentCol & ":"
                                        
                            'D:  Nur wenn Tabelle auch im Layout benutzt wird, Felder übergeben}
                            'US: If and only if the table is used in the layout delivery of the fields}
                            If Not (Len(sPrefixstring2) > 0 And (Form1.LL.LlPrintIsFieldUsed(Mid(sPrefixstring2, 1, Len(sPrefixstring2) - 1) & "*") = 0)) Then
                                nType = RS1.Fields.Item((DataRelation(nZaehl).sChildCol)).Type
                                        
                                DataRelation(k).sSQL = "SELECT [" & DataRelation(k).sParentTable & "].* FROM [" & _
                                            DataRelation(k).sChildTable & "] inner join [" & DataRelation(k).sParentTable & "] on [" & _
                                            DataRelation(nZaehl).sParentTable & "].[" & DataRelation(k).sChildCol & "] = [" & DataRelation(k).sParentTable & _
                                            "].[" & DataRelation(k).sParentCol & _
                                            "] WHERE [" & _
                                            DataRelation(nZaehl).sParentTable & "].[" & DataRelation(nZaehl).sParentCol & "] = " & _
                                            GetSepFromType(nType) & CStr(RS1.Fields.Item((DataRelation(nZaehl).sChildCol))) & GetSepFromType(nType)
                                InitRecordSet RSOne, DBOne, DataRelation(k).sSQL
                                Call DefineCurrentRecord(False, RSOne, sPrefixstring2, True)
                            End If
                        End If
                    Next
                End If
            Next
        Else
            
            'D:  Aktualisierung der Fortschrittsanzeige wenn Root-Datensatz gedruckt wird
            'US: If a root record is printed update the progress bar
            If CStr(Text1.Text) > RS1.RecordCount Or CStr(Text1.Text) = -1 Then
                nRecCount = RS1.RecordCount
            Else
                nRecCount = CStr(Text1.Text)
            End If
            nMaxPerc = 100 / LL.LlPrintDbGetRootTableCount()
            nRecPos = CDbl(RS1.AbsolutePosition) / CDbl(nRecCount)
            nPercTotal = CInt(nMaxPerc * nIndexCurrentTable + ((nRecPos) * nMaxPerc))
            
            ret = LL.LlPrintSetBoxText("Printing report...", nPercTotal)
        
            'D:  Daten für Haupttabellen definieren
            'US: Define data for root tables
            Call DefineCurrentRecord(False, RS1, DataTable(nTabIndex).sTableName & ".", True)
            
            'D:  Daten für 1:1 Relationen definieren
            'US: Define data for 1:1 relations
            For nZaehl = 0 To nUBoundDataRelation
                If DataTable(nTabIndex).sTableName = DataRelation(nZaehl).sChildTable Then
                    'InitConnection DBOne
                    nType = RS1.Fields.Item((DataRelation(nZaehl).sChildCol)).Type
                    DataRelation(nZaehl).sSQL = "SELECT * FROM [" & DataRelation(nZaehl).sParentTable & _
                            "] WHERE [" & DataRelation(nZaehl).sParentCol & "]=" & GetSepFromType(nType) & CStr(RS1.Fields.Item((DataRelation(nZaehl).sChildCol))) & GetSepFromType(nType)

                    sPrefixstring = DataRelation(nZaehl).sChildTable & "." & DataRelation(nZaehl).sChildCol & "@" & DataRelation(nZaehl).sParentTable & "." & DataRelation(nZaehl).sParentCol & ":"
                    'D:  Nur wenn Tabelle auch im Layout benutzt wird, Felder übergeben}
                    'US: If and only if the table is used in the layout delivery of the fields}
                    If Not (Len(sPrefixstring) > 0 And (Form1.LL.LlPrintIsFieldUsed(Mid(sPrefixstring, 1, Len(sPrefixstring) - 1) & "*") = 0)) Then
                        InitRecordSet RSOne, DBOne, DataRelation(nZaehl).sSQL
                        Call DefineCurrentRecord(False, RSOne, sPrefixstring, True)
                    End If
                    
                    For k = 0 To nUBoundDataRelation
                        If DataRelation(nZaehl).sParentTable = DataRelation(k).sChildTable Then
                            sPrefixstring = DataRelation(nZaehl).sChildTable & "." & DataRelation(nZaehl).sChildCol & "@" & DataRelation(nZaehl).sParentTable & "." & DataRelation(nZaehl).sParentCol & ":"
                        
                            sPrefixstring2 = sPrefixstring & DataRelation(k).sChildTable & _
                                    "." & DataRelation(k).sChildCol & "@" & DataRelation(k).sParentTable & "." & DataRelation(k).sParentCol & ":"
                            nType = RS1.Fields.Item((DataRelation(nZaehl).sChildCol)).Type
                            
                            DataRelation(k).sSQL = "SELECT [" & DataRelation(k).sParentTable & "].* FROM [" & _
                                    DataRelation(k).sChildTable & "] inner join [" & DataRelation(k).sParentTable & "] on [" & _
                                    DataRelation(nZaehl).sParentTable & "].[" & DataRelation(k).sChildCol & "] = [" & DataRelation(k).sParentTable & _
                                    "].[" & DataRelation(k).sParentCol & _
                                    "] WHERE [" & _
                                    DataRelation(nZaehl).sParentTable & "].[" & DataRelation(nZaehl).sParentCol & "] = " & _
                                    GetSepFromType(nType) & CStr(RS1.Fields.Item((DataRelation(nZaehl).sChildCol))) & GetSepFromType(nType)
                            'D:  Nur wenn Tabelle auch im Layout benutzt wird, Felder übergeben}
                            'US: If and only if the table is used in the layout delivery of the fields}
                            If Not (Len(sPrefixstring2) > 0 And (Form1.LL.LlPrintIsFieldUsed(Mid(sPrefixstring2, 1, Len(sPrefixstring2) - 1) & "*") = 0)) Then
                                InitRecordSet RSOne, DBOne, DataRelation(k).sSQL
                                Call DefineCurrentRecord(False, RSOne, sPrefixstring2, True)
                            End If
                        End If
                    Next
                End If
            Next
        End If
        ret = LL.LlPrintFields
        If ret = LL_ERR_USER_ABORTED Then
            'D:  Benutzerabbruch
            'US: User aborted
            LL.LlPrintEnd (0)
            PrintTable = ret
            Call CleanUpRecordSet(RSOne, DBOne)
            Exit Function
        End If
        'D:  Seitenumbruch auslösen, bis Datensatz vollständig gedruckt wurde
        'US: Wrap pages until record was fully printed
        While ret = LL_WRN_REPEAT_DATA
            LL.LlPrint
            ret = LL.LlPrintFields
        Wend
        If ret = LL_ERR_USER_ABORTED Then
            'D:  Benutzerabbruch
            'US: User aborted
            LL.LlPrintEnd (0)
            PrintTable = ret
            Call CleanUpRecordSet(RSOne, DBOne)
            Exit Function
        End If
       
        While ret = LL_WRN_TABLECHANGE
            'D:  Root-Tabelle bestimmen und solange drucken bis keine mehr vorhanden
            'US: determine root table and print until no one is available
            Call LL.LlPrintDbGetCurrentTable(psCurrentTable, 1)
            Call LL.LlPrintDbGetCurrentTableRelation(psCurrentRelationID)
            Call LL.LlPrintDbGetCurrentTableSortOrder(psCurrentSortOrderID)
        
            Dim nRelationIndex As Integer
            Dim RSy As ADODB.Recordset
            nRelationIndex = GetIndexOfRelation(psCurrentRelationID)
            nType = RS1.Fields.Item((DataRelation(nRelationIndex).sParentCol)).Type
                    
            DataRelation(nRelationIndex).sSQL = "SELECT * FROM [" & DataRelation(nRelationIndex).sChildTable & _
                    "] WHERE [" & DataRelation(nRelationIndex).sChildCol & "]=" & GetSepFromType(nType) & CStr(RS1.Fields.Item((DataRelation(nRelationIndex).sParentCol))) & GetSepFromType(nType)
            
            InitRecordSet RSy, DBy, DataRelation(nRelationIndex).sSQL
            RSy.Sort = psCurrentSortOrderID
            ret = PrintTable(True, RSy, nRelationIndex, psCurrentSortOrderID, 0)
            Call CleanUpRecordSet(RSy, DBy)
            If ret = LL_ERR_USER_ABORTED Then
                'D:  Benutzerabbruch
                'US: User aborted
                LL.LlPrintEnd (0)
                PrintTable = ret
                Exit Function
            End If
        Wend
        
        RS1.MoveNext
        nRecordDelimiter = nRecordDelimiter + 1
    Loop Until (RS1.EOF Or ((CStr(Text1.Text) > 0) And (nRecordDelimiter >= CStr(Text1.Text))))
    Call CleanUpRecordSet(RSOne, DBOne)
End If

'D:  Druck der Tabelle beenden, angehängte Objekte drucken
'US: Finish printing the table, print linked objects
ret = LL.LlPrintFieldsEnd
While ret = LL_WRN_REPEAT_DATA
    ret = LL.LlPrintFieldsEnd
Wend

PrintTable = ret


End Function

Sub InitADOConnection()
    m_sConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & sDBPath & ";;"
    FillSchemaInfo
End Sub
Private Sub FillSchemaInfo()
    'D:  Tabellen und Relationsstruktur aus der Datenbank auslesen
    'US: read table and relation structure from database
    
    Set DB = New ADODB.Connection
    DB.CursorLocation = adUseClient
    DB.Provider = "Microsoft.Jet.OLEDB.4.0"
    DB.Open sDBPath
    
    Dim RS As ADODB.Recordset
    Set RS = DB.OpenSchema(adSchemaTables)
    
    Dim i
    i = 0
    nUBoundDataTable = -1
    'D:  Tabellen-Array füllen
    'US: fill table array
    Do Until RS.EOF
        If Not Mid$(RS("TABLE_NAME"), 1, 4) = "MSys" And (RS("TABLE_TYPE") = "TABLE") Then
            ReDim Preserve DataTable(i)
            DataTable(i).sTableName = CStr(RS("TABLE_NAME"))
            DataTable(i).sSQL = "SELECT * FROM [" & RS("TABLE_NAME") & "]"
            nUBoundDataTable = i
            i = i + 1
        End If
        RS.MoveNext
    Loop
    
    'D:  Relationen-Array füllen
    'US: fill relation array
    Set RS = DB.OpenSchema(adSchemaForeignKeys)
    i = 0
    nUBoundDataRelation = -1
    Do Until RS.EOF
        ReDim Preserve DataRelation(i)
        'D:  Kind = Foreign
        'US: child = foreign
        DataRelation(i).sChildTable = CStr(RS("FK_TABLE_NAME"))
        DataRelation(i).sChildCol = CStr(RS("FK_COLUMN_NAME"))
        'D:  Eltern = Primary
        'US: Parent = primary
        DataRelation(i).sParentTable = CStr(RS("PK_TABLE_NAME"))
        DataRelation(i).sParentCol = CStr(RS("PK_COLUMN_NAME"))
        DataRelation(i).sRelationName = DataRelation(i).sParentTable & "2" & DataRelation(i).sChildTable
        DataRelation(i).sSQL = "SELECT * FROM [" & DataRelation(i).sParentTable & "]"
        nUBoundDataRelation = i
        i = i + 1
        
        RS.MoveNext
    Loop
    
    RS.Close
    DB.Close
    Set RS = Nothing
    Set DB = Nothing
End Sub
Function InitRecordSet(oRS As ADODB.Recordset, oDB As ADODB.Connection, s_SQL As String)
    Set oRS = New ADODB.Recordset
    oRS.Open s_SQL, oDB, adOpenStatic, adLockBatchOptimistic, adCmdText
    oRS.MarshalOptions = adMarshalModifiedOnly
    Set oRS.ActiveConnection = Nothing
End Function
Function CleanUpRecordSet(oRS As ADODB.Recordset, oDB As ADODB.Connection)
    Set oRS = Nothing
    'Call CleanUpConnection(oDB)
End Function
Function InitConnection(oDB As ADODB.Connection)
    Set oDB = New ADODB.Connection
    oDB.CursorLocation = adUseClient
    oDB.Open m_sConnStr
End Function
Function CleanUpConnection(oDB As ADODB.Connection)
    Set oDB = Nothing
End Function
Private Sub PassDataStructure()
    Dim i As Integer
    Dim RS As ADODB.Recordset
    
    InitConnection DB
    
    'D:  Durchlaufe Tabellen-Array und mache vorhandene Tabellen und Sortierungen bekannt
    'US: skip through table array and declare existing tables and corresponding sort orders
    Call LL.LlDefineFieldStart
    LL.LlDbAddTable "", ""
    For i = 0 To nUBoundDataTable
        LL.LlDbAddTable DataTable(i).sTableName, ""
        InitRecordSet RS, DB, DataTable(i).sSQL
        Call DefineCurrentRecord(False, RS, DataTable(i).sTableName & ".", False)
        
        'D:  Unterroutine zum Definieren der Sortierungen aufrufen
        'US: call sub routine to define sort orders
        Call DefineCurrentSortOrders(RS, DataTable(i).sTableName)
    Next
    
    Dim k As Integer
    Dim sPrefixstring As String, sPrefixstring2 As String
    
    'D:  Durchlaufe Relations-Array und mache vorhandene Relationen bekannt
    'US: skip through relation array and declare existing relations
    For i = 0 To nUBoundDataRelation
        Call LL.LlDbAddTableRelation(DataRelation(i).sChildTable, DataRelation(i).sParentTable, DataRelation(i).sRelationName, "")
        
        'D:  1:1 Relationen bekannt machen
        'US: Declare 1:1 relations
        InitRecordSet RS, DB, DataRelation(i).sSQL
        
        sPrefixstring = DataRelation(i).sChildTable & "." & DataRelation(i).sChildCol & "@" & DataRelation(i).sParentTable & "." & DataRelation(i).sParentCol & ":"
        Call DefineCurrentRecord(False, RS, sPrefixstring, False)
        
        'D:  Suche in allen anderen Relationen, ob die aktuelle Eltern-Tabelle
        '    Kind einer anderen Relation ist
        'US: search in all other relations if the current parent table is child of
        '    another relation
        For k = 0 To nUBoundDataRelation
            If DataRelation(i).sParentTable = DataRelation(k).sChildTable Then
                sPrefixstring2 = sPrefixstring & DataRelation(k).sChildTable & _
                    "." & DataRelation(k).sChildCol & "@" & DataRelation(k).sParentTable & "." & DataRelation(k).sParentCol & ":"
                InitRecordSet RS, DB, DataRelation(k).sSQL
                Call DefineCurrentRecord(False, RS, sPrefixstring2, False)
            End If
        Next
        
    Next i
    Call CleanUpRecordSet(RS, DB)
End Sub
Function GetIndexOfRelation(sRelationName)
    Dim nZaehl
    GetIndexOfRelation = -1
    For nZaehl = 0 To nUBoundDataRelation
        If DataRelation(nZaehl).sRelationName = sRelationName Then
            GetIndexOfRelation = nZaehl
            Exit Function
        End If
    Next
End Function
Function GetIndexOfTable(sTableName)
    Dim nZaehl
    GetIndexOfTable = -1
    For nZaehl = 0 To nUBoundDataTable
        If DataTable(nZaehl).sTableName = sTableName Then
            GetIndexOfTable = nZaehl
            Exit Function
        End If
    Next
End Function
Function GetSepFromType(nInType As Integer)
If ((nInType = adVarWChar) Or (nInType = adVarChar) Or (nInType = adChar) Or (nInType = adBSTR)) Then
    GetSepFromType = "'"
Else
    GetSepFromType = ""
End If

End Function


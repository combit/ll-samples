VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{2213E283-16BC-101D-AFD4-040224009C1B}#27.0#0"; "cmll27o.ocx"
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "List & Label Localization Sample"
   ClientHeight    =   2535
   ClientLeft      =   150
   ClientTop       =   510
   ClientWidth     =   6345
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2535
   ScaleWidth      =   6345
   Begin ListLabel.ListLabel LL 
      Left            =   4440
      Top             =   1800
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
   Begin VB.CommandButton Command2 
      Caption         =   "&Print..."
      Height          =   375
      Left            =   1920
      TabIndex        =   3
      Top             =   1920
      Width           =   1335
   End
   Begin VB.CommandButton Command1 
      Caption         =   "&Design..."
      Height          =   375
      Left            =   240
      TabIndex        =   2
      Top             =   1920
      Width           =   1355
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   5520
      Top             =   1920
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Label Label4 
      Caption         =   "US:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   240
      TabIndex        =   5
      Top             =   960
      Width           =   495
   End
   Begin VB.Label Label2 
      Caption         =   "D:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   240
      TabIndex        =   4
      Top             =   120
      Width           =   375
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   $"Localizationfrm.frx":0000
      BeginProperty Font 
         Name            =   "Microsoft Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   675
      Left            =   840
      TabIndex        =   1
      Top             =   120
      Width           =   5265
      WordWrap        =   -1  'True
   End
   Begin VB.Label Label5 
      AutoSize        =   -1  'True
      Caption         =   $"Localizationfrm.frx":00B3
      BeginProperty Font 
         Name            =   "Microsoft Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   840
      TabIndex        =   0
      Top             =   960
      Width           =   5205
      WordWrap        =   -1  'True
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' Copyright (C) combit GmbH
'--------------------------------------------------------------------------------------
'File:     Localisationfrm.frm
'Module : localisation sample
'Descr. : D:  Dieses Beispiel zeigt das Designen von mehrsprachigen Reports.
'             Die Reportvorlage ist für alle Sprachen die Gleiche,
'             die Lokalisierung wird über das Dictionary-Objekt erreicht.
'         US: This sample shows how to design multi language reports.
'             The report template is the same for all languages - the
'             localization is done with the Dictionary object.

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
    'LL.LlSetDebug 1
         
    
End Sub

Private Sub InitDataBase()
    'D:  Lädt die Access-Datenbank
    'US: Load Access-database
    InitADOConnection
    
    InitConnection DBx
    InitConnection DBOne
    InitConnection DBy
End Sub

Private Sub Form_Unload(Cancel As Integer)
    CleanUpConnection DBx
    CleanUpConnection DBOne
    CleanUpConnection DBy
End Sub


Private Sub Command1_Click()
    FileName = App.Path & "\localization.lst"
    LL.LlDefineVariableStart
    
    'D: Dictionary gemäß Auswahl füllen
    'US: Fill Dictionary according to choice
    FillDictionary
    
    'D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
    '    gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
    '    sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
    'US: Optional call to file selection dialog. Ommit this call and pass the
    '    required file as FileName if you don't want the dialog to appear. If only
    '    existing files should be selectable, remove the "or"ing with LL_FILE_ALSONEW
     If LL.LlSelectFileDlgTitle(Form1.hWnd, "Choose report file", LL_PROJECT_LIST Or LL_FILE_ALSONEW, FileName) <> LL_ERR_USER_ABORTED Then
        
        'D:  Daten definieren
        'US: Define data
        PassDataStructure
        'AdditionalVariables
        
        'D:  Designer mit dem Titel 'Design report' und der gewählten Datei starten
        'US: Opens the chosen file in the designer, sets designer title to 'Design report'
        Call LL.LlDefineLayout(Form1.hWnd, "Design report", LL_PROJECT_LIST, FileName)

    End If
End Sub
Function DefineCurrentSortOrders(oRS As ADODB.Recordset, sTableName)
    'D:  Diese Prozedur definiert für jedes Feld eine Sortierung in List & Label.
    'US: This procedure defines a sort order for each field in List & Label.
    
    'D:  Wiederholung für alle Felder eines Datensatzen
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
    
    'D:  Wiederholung für alle Felder eines Datensatzen
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

Private Sub Command2_Click()
    
    Dim FileName As String
    Dim ret As Integer
    FileName = App.Path & "\localization.lst"
    
    LL.LlSetDebug LL_DEBUG_CMBTLL
    
    LL.LlDefineVariableStart
    
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
    LL.LlDictionariesClear
    FillStaticTextDictionary
    PassDataStructure
    'AdditionalVariables
    
    
    'D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.
    'US: Start print job. Allow all export formats as target. Meter box with cancel button.
    ret = LL.LlPrintWithBoxStart(LL_PROJECT_LIST, FileName, LL_PRINT_EXPORT, LL_BOXTYPE_NORMALMETER, Form1.hWnd, "Printing report...")

    'D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).
    'US: Most frequent cause for error code: -23 (Sytax Error).
    If ret <> 0 Then
        MsgBox ("Error during LlPrintWithBoxStart" & vbCrLf & "Error No: " & CStr(ret))
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

    'AdditionalVariables
    
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
Dim nMaxPerc As Integer, nPercTotal As Integer


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
                '    relation exist
                If DataRelation(nTabIndex).sChildTable = DataRelation(nZaehl).sChildTable Then
                    'InitConnection DBOne
                    nType = RS1.Fields.Item((DataRelation(nZaehl).sChildCol)).Type
                    DataRelation(nZaehl).sSQL = "SELECT * FROM [" & DataRelation(nZaehl).sParentTable & _
                        "] WHERE [" & DataRelation(nZaehl).sParentCol & "]=" & GetSepFromType(nType) & CStr(RS1.Fields.Item((DataRelation(nZaehl).sChildCol))) & GetSepFromType(nType)
                    
                    InitRecordSet RSOne, DBOne, DataRelation(nZaehl).sSQL
                    sPrefixstring = DataRelation(nZaehl).sChildTable & "." & DataRelation(nZaehl).sChildCol & "@" & DataRelation(nZaehl).sParentTable & "." & DataRelation(nZaehl).sParentCol & ":"
                    'D:  Nur wenn Tabelle auch im Layout benutzt wird, Felder übergeben
                    'US: If and only if the table is used in the layout delivery of the fields
                    
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
            nMaxPerc = 100 / LL.LlPrintDbGetRootTableCount()
            nPercTotal = nMaxPerc * nIndexCurrentTable + ((RS1.AbsolutePosition / RS1.RecordCount) * nMaxPerc)
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
                    
                    InitRecordSet RSOne, DBOne, DataRelation(nZaehl).sSQL
                    sPrefixstring = DataRelation(nZaehl).sChildTable & "." & DataRelation(nZaehl).sChildCol & "@" & DataRelation(nZaehl).sParentTable & "." & DataRelation(nZaehl).sParentCol & ":"
                    Call DefineCurrentRecord(False, RSOne, sPrefixstring, True)
                    
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
                            InitRecordSet RSOne, DBOne, DataRelation(k).sSQL
                            Call DefineCurrentRecord(False, RSOne, sPrefixstring2, True)
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
            nType = RS1.Fields.Item((DataRelation(nRelationIndex).sChildCol)).Type
            
            DataRelation(nRelationIndex).sSQL = "SELECT * FROM [" & DataRelation(nRelationIndex).sChildTable & _
                    "] WHERE [" & DataRelation(nRelationIndex).sParentCol & "]=" & GetSepFromType(nType) & CStr(RS1.Fields.Item((DataRelation(nRelationIndex).sChildCol))) & GetSepFromType(nType)
            
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
    'Loop Until (RS1.EOF)
    Loop Until (RS1.EOF Or (nRecordDelimiter = 100))
    
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
            If CStr(RS("TABLE_NAME")) = "Orders" Or CStr(RS("TABLE_NAME")) = "Order Details" Then
            
                ReDim Preserve DataTable(i)
                DataTable(i).sTableName = CStr(RS("TABLE_NAME"))
                DataTable(i).sSQL = "SELECT * FROM [" & RS("TABLE_NAME") & "]"
                nUBoundDataTable = i
                i = i + 1
            End If
        End If
        RS.MoveNext
    Loop
    
    'D:  Relationen-Array füllen
    'US: fill relation array
    Set RS = DB.OpenSchema(adSchemaForeignKeys)
    i = 0
    nUBoundDataRelation = -1
    
    ReDim Preserve DataRelation(1)
    'D:  Kind = Foreign
    'US: child = foreign
    DataRelation(0).sChildTable = "Order Details"
    DataRelation(0).sChildCol = CStr(RS("FK_COLUMN_NAME"))
    DataRelation(0).sChildCol = "OrderID"
            
    'D:  Eltern = Primary
    'US: Parent = primary
    DataRelation(0).sParentTable = "Orders"
    DataRelation(0).sParentCol = CStr(RS("PK_COLUMN_NAME"))
    DataRelation(0).sParentCol = "OrderID"
    
    DataRelation(0).sRelationName = "Orders2OrderDetails"
    DataRelation(0).sSQL = "SELECT * FROM [" & DataRelation(0).sParentTable & "]"
    nUBoundDataRelation = i
                 
    RS.Close
    DB.Close
    Set RS = Nothing
    Set DB = Nothing
End Sub
Private Sub FillDictionary()
    'D: Dictionary löschen
    'US: Clear dictionary
    LL.LlDictionariesClear
    
    'D: Zur Verfügung stehende Sprachen im Designer hinzufügen. Die zuerst angemeldete Sprache wird als Basissprache verwendet!
    'US: Add available languages for the designer. The first language is the basic language
    LL.LlLocAddDesignLCID 9
    LL.LlLocAddDesignLCID 7
    LL.LlLocAddDesignLCID 12
                            
    'D: Für die Basissprache werden die Originalbezeichner verwendet, nur die anderen Sprachen müssen lokalisiert werden
    'US: We'll use the original names for the basic language. Localize for the other languages
        
    ' D: Deutsche Lokalisierung
    ' US: German localization

    ' D: Tabellennamen lokalisieren
    ' US: Localize table names
    LL.LlLocAddDictionaryEntry 7, "Orders", "Bestellungen", LL_DICTIONARY_TYPE_TABLE
    LL.LlLocAddDictionaryEntry 7, "Order Details", "Bestellposten", LL_DICTIONARY_TYPE_TABLE
       
        ' D: Relationsnamen lokalisieren
        ' US: Localize relation name
        
        LL.LlLocAddDictionaryEntry 7, "Orders2Orderdetails", "Bestellungen/Bestellposten", LL_DICTIONARY_TYPE_RELATION
                
        ' D: Feldnamen lokalisieren
        ' US: Localize field names

        LL.LlLocAddDictionaryEntry 7, "ProductID", "ProduktID", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "ProductName", "Produktname", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "Quantity", "Anzahl", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "UnitPrice", "Einzelpreis", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "Discount", "Rabatt", LL_DICTIONARY_TYPE_IDENTIFIER

        LL.LlLocAddDictionaryEntry 7, "OrderID", "BestellID", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "CustomerID", "KundenID", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "EmployeeID", "MitarbeiterID", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "OrderDate", "Bestelldatum", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "RequiredDate", "Bedarfstermin", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "ShippedDate", "Versanddatum", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "ShipVia", "VersandDurch", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "Freight", "Frachtkosten", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "ShipName", "EmpfängerName", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "ShipAddress", "EmpfängerAdresse", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "ShipCity", "EmpfängerStadt", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "ShipRegion", "Bundesland", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "ShipPostalCode", "PLZ", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 7, "ShipCountry", "EmpfängerLand", LL_DICTIONARY_TYPE_IDENTIFIER
        

        ' D: Französische Lokalisierung
        ' US: French localization

        ' D: Tabellennamen lokalisieren
        ' US: Localize table names
        LL.LlLocAddDictionaryEntry 12, "Orders", "Commandes", LL_DICTIONARY_TYPE_TABLE
        LL.LlLocAddDictionaryEntry 12, "Order Details", "DétailsDesCommandes", LL_DICTIONARY_TYPE_TABLE
        
        ' D: Relationsnamen lokalisieren
        ' US: Localize relation name
        LL.LlLocAddDictionaryEntry 12, "Orders2OrderDetails", "Commandes2DétailsDesCommandes", LL_DICTIONARY_TYPE_RELATION

        ' D: Feldnamen lokalisieren
        ' US: Localize field names
        LL.LlLocAddDictionaryEntry 12, "ProductID", "ProduitID", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "ProductName", "NomDuProduit", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "Quantity", "Quantité", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "UnitPrice", "PrixUnitaire", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "Discount", "Ristourne", LL_DICTIONARY_TYPE_IDENTIFIER

        LL.LlLocAddDictionaryEntry 12, "OrderID", "CommandeID", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "CustomerID", "ClientID", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "EmployeeID", "CoopérateurID", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "OrderDate", "DateDeLaCommande", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "RequiredDate", "BesoinDate", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "ShippedDate", "EnvoiDate", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "ShipVia", "EnvoiPar", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "Freight", "Fret", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "ShipName", "DestinataireNom", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "ShipAddress", "DestinataireAdresse", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "ShipCity", "DestinataireVille", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "ShipRegion", "Région", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "ShipPostalCode", "CodePostal", LL_DICTIONARY_TYPE_IDENTIFIER
        LL.LlLocAddDictionaryEntry 12, "ShipCountry", "DestinatairePays", LL_DICTIONARY_TYPE_IDENTIFIER
            
        'D:   Spezieller Fall für statische Texte, da diese später auch für den Druck benötigt werden
        'US: Handling for static texts, because static texts will be neccessary for later printing
        FillStaticTextDictionary
                        
End Sub

Private Sub FillStaticTextDictionary()
            
       ' D: Zusätzliche statische Texte lokalisieren
        ' US: Localize additional static values
        LL.LlLocAddDictionaryEntry 7, "Language", "Deutsch", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 7, "Summary of Sales by Year", "Verkäufe nach Jahren", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 7, "Quarter", "Quartal", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 7, "Shipped", "Bestellungen", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 7, "Sales", "Umsatz", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 7, "Totals for", "Summen für", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 7, "Sales by Year", "Umsatz nach Jahr", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 7, "Lot by Year", "Stückzahlen nach Jahr", LL_DICTIONARY_TYPE_STATIC
        
        LL.LlLocAddDictionaryEntry 7, "designed & printed with combit® List & Label®", "gestaltet & gedruckt mit combit® List & Label®", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 7, "Page {0} of {1}", "Seite {0} von {1}", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 7, "Printed {0} at {1} on {2}", "Gedruckt am {0} um {1} auf {2}", LL_DICTIONARY_TYPE_STATIC
        ' D: Zusätzliche statische Texte lokalisieren
        ' US: Localize additional static values
        LL.LlLocAddDictionaryEntry 12, "Language", "Français", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 12, "Summary of Sales by Year", "Chiffre d´affaires à année", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 12, "Quarter", "Trimestre", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 12, "Shipped", "Commandes", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 12, "Sales", "Volume d'affaires", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 12, "Totals for", "Bourdonnement pour", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 12, "Sales by Year", "Volume d´affaires à année", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 12, "Lot by Year", "Nombre de pièces à année", LL_DICTIONARY_TYPE_STATIC
        
        LL.LlLocAddDictionaryEntry 12, "designed & printed with combit® List & Label®", "modeler & imprimée avec combit® List & Label®", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 12, "Page {0} of {1}", "Page {0} de {1}", LL_DICTIONARY_TYPE_STATIC
        LL.LlLocAddDictionaryEntry 12, "Printed {0} at {1} on {2}", "Imprimée la {0} à {1} sur {2}", LL_DICTIONARY_TYPE_STATIC
                      
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
    
    'D:  Durchlaufe Tabellen-Array und mache vorhanden Tabellen und Sortierungen bekannt
    'US: skip through table array and declare existing tables and corresponding sort orders
    Call LL.LlDefineFieldStart
    LL.LlDbAddTable "", ""
    For i = 0 To nUBoundDataTable
        LL.LlDbAddTable DataTable(i).sTableName, ""
        InitRecordSet RS, DB, DataTable(i).sSQL
        Call DefineCurrentRecord(False, RS, DataTable(i).sTableName & ".", False)
        
        'D:  Unterroutine zum Definieren der Sortierungen aufrufen
        'US: call sub routing to define sort orders
        Call DefineCurrentSortOrders(RS, DataTable(i).sTableName)
    Next
    
    Dim k As Integer
    Dim sPrefixstring As String, sPrefixstring2 As String
    
    'D:  Durchlaufe Relations-Array und mache vorhanden Relationen bekannt
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



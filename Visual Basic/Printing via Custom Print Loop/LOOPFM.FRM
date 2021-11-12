VERSION 5.00
Object = "{2213E283-16BC-101D-AFD4-040224009C1B}#27.0#0"; "cmll27o.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   Caption         =   "List & Label Print Loop Demo"
   ClientHeight    =   2160
   ClientLeft      =   165
   ClientTop       =   825
   ClientWidth     =   7425
   LinkTopic       =   "Form1"
   ScaleHeight     =   2160
   ScaleWidth      =   7425
   Begin VB.Data Data1 
      BOFAction       =   1  'BOF
      Caption         =   "Data1"
      Connect         =   "Access 2000;"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      EOFAction       =   1  'EOF
      Exclusive       =   -1  'True
      Height          =   345
      Left            =   1380
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   0  'Table
      RecordSource    =   "Article"
      Top             =   1740
      Visible         =   0   'False
      Width           =   1692
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   780
      Top             =   1620
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin ListLabel.ListLabel LL 
      Left            =   60
      Top             =   1620
      _Version        =   65537
      _ExtentX        =   873
      _ExtentY        =   873
      _StockProps     =   64
      Language        =   -1
      DialogMode      =   14
      DialogFrame     =   0
      Dialog3DText    =   1
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
   Begin VB.CheckBox DebugCheckBox 
      Caption         =   "&Debug output"
      Height          =   255
      Left            =   5820
      TabIndex        =   4
      Top             =   1560
      Width           =   1455
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
      Caption         =   "US: This example demonstrates how to design and print labels and reports"
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
      Caption         =   "und Listen über eine eigene Druckschleife"
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
      Caption         =   "D:  Dieses Beispiel demonstriert das Designen und Drucken von Etiketten"
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
      Begin VB.Menu Exit1 
         Caption         =   "&Exit"
      End
   End
   Begin VB.Menu EditMnu 
      Caption         =   "&Edit"
      Begin VB.Menu Label1 
         Caption         =   "&Label"
      End
      Begin VB.Menu Report1 
         Caption         =   "&Report"
      End
   End
   Begin VB.Menu PrintMnu 
      Caption         =   "&Print"
      Begin VB.Menu Label2 
         Caption         =   "&Label"
      End
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
'File:     loopfm.frm
'Module : custom print loop sample
'Descr. : D:  Dieses Beispiel demonstriert den Druck über eine eigene Druckschleife
'         US: This example demonstrates the printout using a custom print loop
'======================================================================================

Option Explicit
Dim FileName As String

Private Sub ExitMenu_Click()

End Sub

Private Sub FileMenu_Click()

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

Private Sub Exit1_Click()
    Unload Form1
End Sub

Private Sub Form_Load()
Left = (Screen.Width - Width) / 4: Top = (Screen.Height - Height) / 4

'D: Wechselt auf Laufwerk & Verzeichnis der Beispiel-Anwendung
'US: Change to drive & path of example-app
ChDrive App.Path
ChDir App.Path

'D: Schreibe in Path$ das übergeordnete Verzeichnis
'US: Set Path$ to parent-directory
Dim Path$
Path$ = App.Path
While Mid(Path$, Len(Path$), 1) <> "\"
    Path$ = Left(Path$, Len(Path$) - 1)
Wend

'D: Lädt die Access-Datenbank
'US: Load Access-database
Data1.DatabaseName = Path$ & "simple.mdb"

'D: Setzt die List & Label Sprache auf einen Default Wert
'US: Set the List & Label language to a default value
LL.Language = CMBTLANG_DEFAULT


End Sub

Private Sub Label1_Click()
    FileName = App.Path & "\simple.lbl"
    Form1.Data1.Recordset.MoveFirst

    'D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
    '    gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
    '    sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
    'US: Optional call to file selection dialog. Ommit this call and pass the
    '    required file as FileName if you don't want the dialog to appear. If only
    '    existing files should be selectable, remove the "or"ing with LL_FILE_ALSONEW
     If LL.LlSelectFileDlgTitle(Form1.hWnd, "Choose label file", LL_PROJECT_LABEL Or LL_FILE_ALSONEW, FileName) <> LL_ERR_USER_ABORTED Then
        'D:  Daten definieren
        'US: Define data
        DefineCurrentRecord (False)

        'D:  Designer mit dem Titel 'Design label' und der gewählten Datei starten
        'US: Opens the chosen file in the designer, sets designer title to 'Design label'
        Dim Ret%
        Ret% = LL.LlDefineLayout(Form1.hWnd, "Design label", LL_PROJECT_LABEL, FileName)
     End If

End Sub

Private Sub Label2_Click()
    Dim FileName As String
    Dim Ret As Integer
    FileName = "simple.lbl"
    Form1.Data1.Recordset.MoveFirst
    'D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
    '    gewünschten Dateinamen übergeben.
    'US: Optional call to file selection dialog. Ommit this call and pass the
    '    required file as FileName if you don't want the dialog to appear.
    If LL.LlSelectFileDlgTitle(Form1.hWnd, "Choose label file", LL_PROJECT_LABEL, FileName) = LL_ERR_USER_ABORTED Then
        Exit Sub
    End If

    'D:  Daten definieren. Die hier übergebenen Daten dienen nur der Syntaxprüfung - die Inhalte
    '    brauchen keine Echtdaten zu enthalten
    'US: Define data. The data passed here is only used for syntax checking and doesn't need
    '    to contain real data
    DefineCurrentRecord (False)

    'D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.
    'US: Start print job. Allow all export formats as target. Meter box with cancel button.
     Ret = LL.LlPrintWithBoxStart(LL_PROJECT_LABEL, FileName, LL_PRINT_EXPORT, LL_BOXTYPE_STDABORT, Form1.hWnd, "Printing label...")

    'D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).
    'US: Most frequent cause for error code: -23 (Sytax Error).
    If Ret <> 0 Then
        MsgBox ("Error during LlPrintWithBoxStart")
        Exit Sub
    End If

    'D:  Druckoptionsdialog. Aufruf ist optional, es können sonst Ausgabeziel und
    '    Exportdateiname über LlXSetParameter() gesetzt werden bzw. der Drucker und
    '    die Druckoptionen über LlSetPrinterInPrinterFile() vorgegeben werden.
    'US: Optional call to print options dialog. You may also set the print target format
    '    and export file name using LlXSetParameter() or set the printer and print options
    '    using LlSetPrinterInPrinterFile()
    Ret = LL.LlPrintOptionsDialog(Form1.hWnd, "Choose printing options")
    If Ret = LL_ERR_USER_ABORTED Then
        LL.LlPrintEnd (0)
        Exit Sub
    End If

    'D:  Eigentliche Druckschleife; Wiederholung, solange Daten vorhanden
    'US: Print loop. Repeat while there is still data to print
     While (Not Form1.Data1.Recordset.EOF)
        'D:  Jetzt Echtdaten für aktuellen Datensatz übergeben
        'US: pass data for current record
        DefineCurrentRecord (False)

        'D:  Ein Etikett ausdrucken
        'US: Print one label
        Ret = LL.LlPrint
        While Ret = LL_WRN_REPEAT_DATA
            Ret = LL.LlPrint
		wend
		
        If (Ret = LL_ERR_USER_ABORTED) Then
            LL.LlPrintEnd (0)
            Exit Sub
        End If

        'D:  Fortschrittsanzeige aktualisieren
        'US: Refresh progress meter
        Call LL.LlPrintSetBoxText("Printing label...", Form1.Data1.Recordset.PercentPosition)

        'D:  Zum nächsten Datensatz wechseln
        'US: Skip to next record
        Form1.Data1.Recordset.MoveNext
    Wend

    'D:  Druck beenden
    'US: Stop printing
     LL.LlPrintEnd (0)
End Sub

Private Sub Report1_Click()
    FileName = App.Path & "\simple.lst"
    Form1.Data1.Recordset.MoveFirst
    'D:  Dateiauswahldialog. Aufruf ist optional, sonst einfach in FileName den
    '    gewünschten Dateinamen übergeben. Wenn nur bestehende Dateien auswählbar
    '    sein sollen, muss die Veroderung mit LL_FILE_ALSONEW weggelassen werden
    'US: Optional call to file selection dialog. Ommit this call and pass the
    '    required file as FileName if you don't want the dialog to appear. If only
    '    existing files should be selectable, remove the "or"ing with LL_FILE_ALSONEW
     If LL.LlSelectFileDlgTitle(Form1.hWnd, "Choose list file", LL_PROJECT_LIST Or LL_FILE_ALSONEW, FileName) <> LL_ERR_USER_ABORTED Then
        
        'D:  Daten definieren
        'US: Define data
        DefineCurrentRecord (True)
        
        'D:  Designer mit dem Titel 'Design report' und der gewählten Datei starten
        'US: Opens the chosen file in the designer, sets designer title to 'Design report'
        Dim Ret%
        Ret% = LL.LlDefineLayout(Form1.hWnd, "Design report", LL_PROJECT_LIST, FileName)

    End If
End Sub

Function DefineCurrentRecord(bAsField As Boolean)
    Dim i As Integer
    Dim FieldType As Long
    Dim nRet As Long
    Dim para As Long
    Dim content$
    Dim a!

    'D:  Diese Prozedur übergibt den aktuellen Datensatz an List & Label.
    '    Hier können Sie ansetzen, um ganz andere Datenquellen zu verwenden
    'US: This procedure passes the current record to List & Label. Customize
    '    it in order to pass completely different data


    
    'D: Wiederholung für alle Felder eines Datensatzes
    'UR: Loop for each field in the present recordset
    For i = 0 To Form1.Data1.Recordset.Fields.Count - 1
        
        'D: Wiederholung für alle Felder eines Datensatzen
        'UR: Loop for each field in the present recordset
        Select Case Form1.Data1.Recordset.Fields(i).Type
                                            
            'D: Numerisches Feld
            'US: Numeric field
            Case 3, 4, 6, 7:     para = LL_NUMERIC:      content$ = Form1.Data1.Recordset.Fields(i)
            
            'D: Falls der Datentyp "Datum" ist, Umwandlung in einen numerischen Datumswert
            'US: If datatype is "Date" convert to numeric date-value
            Case 8:             para = LL_DATE_MS:      a! = CDate(Form1.Data1.Recordset.Fields(i)): content$ = a!:
            
            'D: Entscheidungsfeld (Ja/Nein), Boolean
            'US: True/False field, Boolean
            Case 1:            para = LL_BOOLEAN:      content$ = Form1.Data1.Recordset.Fields(i)
            
            'D: Zeichenformat = Text
            'US: Characterformat = Text
            Case Else:          para = LL_TEXT:         content$ = Form1.Data1.Recordset.Fields(i)
        
        End Select
        'D:  Feldname, -inhalt und -typ an List & Label übergeben
        'US: Declare fieldname, fieldcontent and fieldtype to List & Label
        If bAsField Then
            nRet = Form1.LL.LlDefineFieldExt(Form1.Data1.Recordset.Fields(i).Name, _
                                                      content$, para)
        Else
            nRet = Form1.LL.LlDefineVariableExt(Form1.Data1.Recordset.Fields(i).Name, _
                                                      content$, para)
        End If
    Next i

End Function

Private Sub Report2_Click()
    Dim FileName As String
    Dim Ret As Integer
    FileName = "simple.lst"
    Form1.Data1.Recordset.MoveFirst
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
    DefineCurrentRecord (True)

    'D:  Druckjob starten. Als Druckziel alle Exportformate erlauben. Fortschrittsbox mit Abbruchbutton.
    'US: Start print job. Allow all export formats as target. Meter box with cancel button.
    Ret = LL.LlPrintWithBoxStart(LL_PROJECT_LIST, FileName, LL_PRINT_EXPORT, LL_BOXTYPE_STDABORT, Form1.hWnd, "Printing report...")

    'D:  Häufigste Ursache für Fehlercode: -23 (Syntax Error).
    'US: Most frequent cause for error code: -23 (Sytax Error).
    If Ret <> 0 Then
        MsgBox ("Error during LlPrintWithBoxStart")
        Exit Sub
    End If

    'D:  Druckoptionsdialog. Aufruf ist optional, es können sonst Ausgabeziel und
    '    Exportdateiname über LlXSetParameter() gesetzt werden bzw. der Drucker und
    '    die Druckoptionen über LlSetPrinterInPrinterFile() vorgegeben werden.
    'US: Optional call to print options dialog. You may also set the print target format
    '    and export file name using LlXSetParameter() or set the printer and print options
    '    using LlSetPrinterInPrinterFile()
    Ret = LL.LlPrintOptionsDialog(Form1.hWnd, "Choose printing options")
    If Ret = LL_ERR_USER_ABORTED Then
        LL.LlPrintEnd (0)
        Exit Sub
    End If

    'D:  Erste Seite initialisieren; auch hier kann schon durch Objekte vor der Tabelle
    '    ein Seitenumbruch ausgelöst werden
    'US: Initialize first page. A page wrap may occur already caused by objects which are
    '    printed before the table
    While LL.LlPrint = LL_WRN_REPEAT_DATA
    Wend
    
    'D:  Eigentliche Druckschleife; Wiederholung, solange Daten vorhanden
    'US: Print loop. Repeat while there is still data to print
    While (Not Form1.Data1.Recordset.EOF)
        'D:  Jetzt Echtdaten für aktuellen Datensatz übergeben
        'US: pass data for current record
        DefineCurrentRecord (True)

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
        Call LL.LlPrintSetBoxText("Printing report...", Form1.Data1.Recordset.PercentPosition)
        Form1.Data1.Recordset.MoveNext
    Wend

    'D:  Druck der Tabelle beenden, angehängte Objekte drucken
    'US: Finish printing the table, print linked objects
    While LL.LlPrintFieldsEnd = LL_WRN_REPEAT_DATA
    Wend
    'D:  Druck beenden
    'US: Stop printing
    LL.LlPrintEnd (0)

End Sub

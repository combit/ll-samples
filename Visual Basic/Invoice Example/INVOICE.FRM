VERSION 5.00
Object = "{2213E283-16BC-101D-AFD4-040224009C1B}#27.0#0"; "cmll27o.ocx"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "List & Label - Advanced Bill Sample"
   ClientHeight    =   3570
   ClientLeft      =   2265
   ClientTop       =   4110
   ClientWidth     =   6855
   Icon            =   "invoice.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   3570
   ScaleWidth      =   6855
   ShowInTaskbar   =   0   'False
   Begin ListLabel.ListLabel ListLabel1 
      Left            =   5880
      Top             =   840
      _Version        =   65537
      _ExtentX        =   1296
      _ExtentY        =   873
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
   Begin VB.ListBox List1 
      Height          =   1425
      Left            =   600
      TabIndex        =   0
      Top             =   1320
      Width           =   6015
   End
   Begin VB.Data Data2 
      BOFAction       =   1  'BOF
      Caption         =   "Data2"
      Connect         =   "Access 2000;"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      EOFAction       =   1  'EOF
      Exclusive       =   -1  'True
      Height          =   300
      Left            =   5040
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   0  'Table
      RecordSource    =   "items"
      Top             =   120
      Visible         =   0   'False
      Width           =   1695
   End
   Begin VB.CheckBox Check1 
      Caption         =   "D&ebug Output"
      Height          =   375
      Left            =   4560
      TabIndex        =   4
      Top             =   3000
      Width           =   1335
   End
   Begin VB.CommandButton ButtonDesign 
      Caption         =   "&Design..."
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   3000
      Width           =   1335
   End
   Begin VB.CommandButton ButtonPreview 
      Caption         =   "Pre&view..."
      Height          =   375
      Left            =   1560
      TabIndex        =   2
      Top             =   3000
      Width           =   1335
   End
   Begin VB.CommandButton ButtonPrint 
      Caption         =   "&Print..."
      Height          =   375
      Left            =   3000
      TabIndex        =   3
      Top             =   3000
      Width           =   1335
   End
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
      Left            =   5040
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   0  'Table
      RecordSource    =   "invoice"
      Top             =   480
      Visible         =   0   'False
      Width           =   1695
   End
   Begin VB.Label Label5 
      Caption         =   "Inv.:"
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
      TabIndex        =   9
      Top             =   1320
      Width           =   450
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
      TabIndex        =   8
      Top             =   120
      Width           =   435
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
      TabIndex        =   7
      Top             =   720
      Width           =   405
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Dieses Beispiel demonstriert das Designen und Drucken von Rechnungen"
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
      Top             =   120
      Width           =   6165
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "This example demonstrates how to design and print invoices"
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
      Top             =   720
      Width           =   4800
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

'======================================================
Private Sub DefineFields()
'======================================================
    
    'D:   Posten-Daten aus dem aktuellen Datensatz
    '    lesen und als List & Label Feld definieren
    'US: Read item-data from the current recordset and
    '    define as List & Label field
    
    For i = 0 To Form1.Data2.Recordset.Fields.Count - 1
        
        'D:   Wiederholung für alle Felder eines Datensatzen
        'UR: Loop for each field in the present recordset
        Select Case Form1.Data2.Recordset.Fields(i).Type
                                            
            'D:   Numerisches Feld
            'US: Numeric field
            Case 3, 4, 6, 7:     para = LL_NUMERIC:      content$ = Form1.Data2.Recordset.Fields(i)
            
            'D:   Falls der Datentyp "Datum" ist, Umwandlung in einen numerischen Datumswert
            'US: If datatype "Date" convert to numeric date-value
            Case 8:             para = LL_DATE_MS:      a! = CDate(Form1.Data2.Recordset.Fields(i)): content$ = a!:
            
            'D:   Entscheidungsfeld (Ja/Nein), Boolean
            'US: True/False field, boolean
            Case 1:            para = LL_BOOLEAN:      content$ = Form1.Data2.Recordset.Fields(i)
            
            'D:   Zeichenformat = Text
            'US: Characterformat = Text
            Case Else:          para = LL_TEXT:         content$ = Form1.Data2.Recordset.Fields(i)
        
        End Select
        
        nRet = Form1.ListLabel1.LlDefineFieldExt(Form1.Data2.Recordset.Fields(i).Name, _
                                                      content$, para)
                                                      
    Next i
End Sub

'======================================================
Private Sub DefineVars()
'======================================================
    
    'D:   Rechnungs-Daten aus dem aktuellen Datensatz
    '    lesen und als List & Label Variablen definieren
    'US: Read invoice-data from the current recordset and
    '    define as List & Label variable
        
    For i = 0 To Form1.Data1.Recordset.Fields.Count - 1
        
        'D:   Umsetzung der Datenbank-Feldtypen in List & Label Typen, s. Funktion VarType() in der VB-Hilfe
        'US: Transfer database-fieldtypes to List & Label types, s. function VarType() in VB Help
        Select Case VarType(Form1.Data1.Recordset.Fields(i))
            
            'D:   Numerisches Feld
            'US: Numeric field
            Case 2, 3, 4, 5:    para = LL_NUMERIC:      content$ = Form1.Data1.Recordset.Fields(i)
            
            'D:   Falls der Datentyp "Datum" ist, Umwandlung in einen numerischen Datumswert
            'US: If datatype "Date" convert to numeric date-value
            Case 7:             para = LL_DATE_MS:      a! = CDate(Form1.Data1.Recordset.Fields(i)): content$ = a!:
            
            'D:   Entscheidungsfeld (Ja/Nein), Boolean
            'US: True/False field, boolean
            Case 11:            para = LL_BOOLEAN:      content$ = Form1.Data1.Recordset.Fields(i)
            
            'D:   Zeichenformat = Text
            'US: Characterformat = Text
            Case Else:          para = LL_TEXT:         content$ = Form1.Data1.Recordset.Fields(i)
        
        End Select
        
        nRet = Form1.ListLabel1.LlDefineVariableExt(Form1.Data1.Recordset.Fields(i).Name, _
                                                      content$, para)
                                                      
    Next i
    
End Sub

'======================================================
Sub GetInvoiceNo()
'======================================================
    
    'D:   Rechnungs-Nr. aus der Datenbank einlesen und in
    '    Tabelle schreiben
    'US: Read invoice-numbers from database and add to list
        
    'D:   Alle Listen-Einträge löschen
    'US: Delete all list-items
    List1.Clear
    
    'D:   Gehe zum ersten Datensatz in der Rechnungs-Tabelle
    'US: Move to first record in invoice-table
    Data1.Recordset.MoveFirst
    
    'D:   Solange das Ende der Rechnungs-Tabelle nicht erreicht ist...
    'US: Loop until reaching end of invoice-table
    While Not Data1.Recordset.EOF
        
        'D:   Füge der Liste Rechnungs-Nr. hinzu
        'US: Add invoice-no to list
        List1.AddItem "No. " & Data1.Recordset.Fields(0) & " from " & Data1.Recordset.Fields(1) & ", " & Data1.Recordset.Fields(2)
        
        'D:   Gehe zum nächsten Datensatz
        'US: Move to next record
        Data1.Recordset.MoveNext
    Wend
    
    'D:   Setze Standard-Eintrag
    'US: Set default-item
    List1.ListIndex = 0
End Sub

'======================================================
Private Sub PrintInvoice(PrintMode As Integer)
'======================================================
    
    'D:   Ausgewählte Rechnung drucken
    'US: Print selected invoice
        
    'D:   Gehe zum ersten Datensatz
    'US: Move to first record
    Data1.Recordset.MoveFirst
    Data2.Recordset.MoveFirst
    
    'D:   Variablen und Felder zurücksetzen
    'US: Reset variables and fields
    ListLabel1.LlDefineVariableStart
    ListLabel1.LlDefineFieldStart
    
    'D:   Variablen und Felder mit Dummy-Daten definieren
    'US: Define variables and fields with dummy-data
    DefineVars
    DefineFields
    
    'D:   Auswahl der Projekt-Datei über Datei-Auswahl-Dialog
    'US: Select project-file via File-Select dialog
    buf$ = "invoice.lst"
    ret% = ListLabel1.LlSelectFileDlg(hWnd, LL_PROJECT_LIST, buf$)
    
    'D:   Wenn der Benutzer auf "Abbrechen" klickt, Druckjob abbrechen
    'US: If user hits "Cancel" terminate printjob
    If ret% = LL_ERR_USER_ABORTED Then Exit Sub
    
    'D:   Druck starten
    'US: Start printing
    ret% = ListLabel1.LlPrintWithBoxStart(LL_PROJECT_LIST, buf$, PrintMode, LL_BOXTYPE_STDWAIT, hWnd, "Printing invoice")
    
    'D:   Dialog für Drucker-Einstellungen anzeigen
    'US: Show dialog for printer-configuration
    ret% = ListLabel1.LlPrintOptionsDialog(Form1.hWnd, "Configurate printing-parameters")
    
    'D:   Wenn der Benutzer auf "Abbrechen" klickt, Druckjob abbrechen
    'US: If user hits "Cancel" terminate printjob
    If ret% = LL_ERR_USER_ABORTED Then
      ListLabel1.LlPrintEnd 0
      Exit Sub
    End If
    
    
    'D:   Gehe zum ersten Datensatz
    'US: Move to first record
    Data1.Recordset.MoveFirst
    Data2.Recordset.MoveFirst
    
    'D:   Gehe zur ausgewählten Rechnung (list1)
    'US: Move to selected invoice (list1)
    Data1.Recordset.Move List1.ListIndex
    
    'D:   Variablen mit "Echtdaten" füllen
    'US: Fill variables with real-data
    DefineVars
    
    'D:   Variablen drucken
    'US: Print variables
    ListLabel1.LlPrint
    
    'D:   Solange das Ende der Posten-Tabelle nicht erreicht ist...
    'US: Loop until reaching end of item-table
    While Not Data2.Recordset.EOF
        
        'D:   Prozentbalken setzen
        'US: Set percent-bar
        ret% = ListLabel1.LlPrintSetBoxText("Printing invoice", Data2.Recordset.PercentPosition)
        
        'D:   Wenn die Rechnungs-Nr. übereinstimmt
        'US: If invoice-no fits to selected
        If Data2.Recordset.Fields(0) = Data1.Recordset.Fields(0) Then
            
            'D:   Felder mit "Echtdaten" aus aktuellem Datensatz füllen
            'US: Fill fields with real-data from current record
            DefineFields
            
            'D:   Felder drucken und wenn Seitenumbruch erfolgt ist,
            '    Variablen und Felder erneut drucken
            'US: Print fields and if pagebreak re-print variables and fields
            While ListLabel1.LlPrintFields = LL_WRN_REPEAT_DATA
                ret% = ListLabel1.LlPrint
            Wend
        
        End If
        
        'D:   Gehe zum nächsten Datensatz
        'US: Move to next record
        Data2.Recordset.MoveNext
    
    'D:   Ende der Schleife, gehe zum Anfang
    'US: Loop
    Wend
    
    'D:   Drucke Fußzeilen-Druck
    'US: Print footlines
    

    'D:   Tabellen-Ausdruck beenden
    'US: End table-printing
    Do
        ret% = ListLabel1.LlPrintFieldsEnd()
    Loop Until ret% <> LL_WRN_REPEAT_DATA

    'D:   Wenn der Benutzer abbricht
    'US: If user hits cancel
    If ret% = LL_ERR_USER_ABORTED Then
        ListLabel1.LlPrintEnd (0)
        Exit Sub
    End If
   
    'D:   Druck beenden
    'US: Ends printjob
    ret% = ListLabel1.LlPrintEnd(0)
End Sub

'======================================================
Private Sub ButtonDesign_Click()
'======================================================
        
    'D:   Variablen und Felder zurücksetzen
    'US: Reset variables and fields
    ListLabel1.LlDefineVariableStart
    ListLabel1.LlDefineFieldStart
        
    'D:   Gehe zum ersten Datensatz
    'US: Move to first record
    Data1.Recordset.MoveFirst
    Data2.Recordset.MoveFirst
    
    'D:   Definition der Rechnungs-Variablen
    'US: Definition of invoice-variables
    DefineVars
    
    'D:   Definition der Posten-Felder
    'US: Definition of item-fields
    DefineFields
    
    'D:   Datei-Auswahl-Dialog anzeigen und Designer starten
    'US: Show Select-File dialog und start designer
    buf$ = "invoice.lst"
    ret% = ListLabel1.LlSelectFileDlg(hWnd, LL_PROJECT_LIST, buf$)
    ret% = ListLabel1.LlDefineLayout(hWnd, "Design invoice", OBJECT_LIST, buf$)
    
End Sub
'======================================================
Private Sub ButtonPreview_Click()
'======================================================
    
    'D:   Druckt aktuelle Rechnung als Vorschau
    'US: Prints current invoice to preview
    PrintInvoice LL_PRINT_PREVIEW
    
End Sub


'======================================================
Private Sub ButtonPrint_Click()
'======================================================
    
    'D:   Druckt aktuelle Rechnung auf den Drucker
    'US: Prints current invoice to printer
    PrintInvoice (LL_PRINT_EXPORT)

End Sub





'======================================================
Private Sub Form_KeyPress(KeyAscii As Integer)
'======================================================
            
    'D:   Anwendung mit ESC (=ASCII-Wert 27) beenden
    'US: Terminate application with ESC (=ASCII-value 27)
    If KeyAscii = 27 Then Unload Form1

End Sub


Private Sub Form_Load()
'======================================================================================
'
' Copyright (C) combit GmbH
'
'--------------------------------------------------------------------------------------
' File   : invoice.vbp, invoice.frm, cmll27.bas
' Module : advanced invoice sample
' Descr. : D:   Dieses Beispiel demonstriert das Designen und Drucken von Rechnungen
'          US: This example demonstrates how to design and print invoices
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

'D:   Lädt die Access-Datenbank simple.mdb, Tabelle "INVOICE"
'US: Load Access-database simple.mdb, table "INVOICE"
Data1.DatabaseName = Path$ & "simple.mdb"

'D:   Lädt die Access-Datenbank simple.mdb, Tabelle "ITEMS"
'US: Load Access-databases simple.mdb, table "ITEMS"
Data2.DatabaseName = Path$ & "simple.mdb"

'D:   Data-Controls aktualisieren
'US: Refresh data-controls
Data1.Refresh
Data2.Refresh

'D:   Rechnungs-Nummern auslesen
'US: Read invoice-numbers
GetInvoiceNo

'D:   Setzt die List & Label Sprache auf einen Default Wert
'US: Set the List & Label language to a default value
ListLabel1.Language = CMBTLANG_DEFAULT

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
Private Sub List1_DblClick()
'======================================================
    
    'D:   Doppelklick auf die Liste druckt aktuelle
    '    Rechnung als Vorschau
    'US: Doubleclick on the list prints current
    '    invoice to preview
    PrintInvoice LL_PRINT_PREVIEW


End Sub



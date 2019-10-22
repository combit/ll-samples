VERSION 5.00
Object = "{2213E283-16BC-101D-AFD4-040224009C19}#25.0#0"; "cmll25o.ocx"
Begin VB.Form BaseForm 
   Appearance      =   0  'Flat
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "List & Label Example Program"
   ClientHeight    =   2400
   ClientLeft      =   2505
   ClientTop       =   3570
   ClientWidth     =   6810
   BeginProperty Font 
      Name            =   "MS Sans Serif"
      Size            =   8.25
      Charset         =   0
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   Icon            =   "main.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   2400
   ScaleWidth      =   6810
   ShowInTaskbar   =   0   'False
   Begin VB.CheckBox Check1 
      Caption         =   "D&ebug Output"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   5160
      TabIndex        =   4
      Top             =   1320
      Width           =   1455
   End
   Begin ListLabel.ListLabel LL 
      Left            =   0
      Top             =   1320
      _Version        =   65537
      _ExtentX        =   1085
      _ExtentY        =   873
      _StockProps     =   64
      Language        =   0
      DialogMode      =   14
      DialogFrame     =   0
      Dialog3DText    =   1
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
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Dieses Beispiel demonstriert das Designen und Drucken von Etiketten, Listen und User-Objekten"
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
      TabIndex        =   2
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
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "This example demonstrates how to design and print labels, reports and user-objects"
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
      TabIndex        =   3
      Top             =   720
      Width           =   6165
   End
   Begin VB.Menu File 
      Caption         =   "&File"
      Begin VB.Menu FileExit 
         Caption         =   "&Exit"
      End
   End
   Begin VB.Menu Edit 
      Caption         =   "&Edit"
      Begin VB.Menu EditLabel 
         Caption         =   "&Label"
      End
      Begin VB.Menu EditTable 
         Caption         =   "&Report"
      End
   End
   Begin VB.Menu Print 
      Caption         =   "Print"
      Begin VB.Menu PrintLabel 
         Caption         =   "&Label"
      End
      Begin VB.Menu PrintTable 
         Caption         =   "&Report"
      End
      Begin VB.Menu PrintPreviewLabel 
         Caption         =   "Preview Label"
      End
      Begin VB.Menu PrintPreviewTable 
         Caption         =   "Preview Report"
      End
   End
   Begin VB.Menu Options 
      Caption         =   "&Options"
      Begin VB.Menu UseCB 
         Caption         =   "&Use Callbacks for Table Coloring"
      End
   End
   Begin VB.Menu About 
      Caption         =   "&About"
   End
End
Attribute VB_Name = "BaseForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
    
'D:   Deklarationen
'US: Declarations
    
    'D:   Variablen nur benutzen, wenn diese deklariert wurden
    'US: Use variables only if they are declared
    Option Explicit
    
    'D:   Datenbank-Objekt definieren
    'US: Define database-object
    Dim DbObj As Database
    
    'D:   Rückgabe-Variable definieren
    'US: Define return-variable
    Dim ret As Long
    
'======================================================
Private Sub About_Click()
'======================================================

    'D:   Copyright-Fenster anzeigen
    'US: Show copyright-box
    MsgBox "Copyright (C) combit GmbH", , "List & Label Example Program"

End Sub

'======================================================
Private Sub DefineFields(DBSet As Snapshot, bDefine As Boolean)
'======================================================
    
'D:   Felder definieren
'US: Define fields
    
    'D:   Deklarationen
    'US: Declarations
    Dim ct As String
    Dim i As Integer
    Dim j As Integer
    Dim t As Integer
    Dim c As String
    Dim nm As String

    'D:   sunny-Grafik als Feld definieren
    'US: Define sunny-picture as field
    ret = LL.LlDefineFieldExt("Signet", "sunny.wmf", LL_DRAWING)
    
    'D:   Felder definieren
    'US: Define fields
    For j = 0 To DBSet.Fields.Count - 1
        nm = DBSet(j).Name
                        
        'D:   Echtdaten aus Datenbank laden
        'US: Load real-data from database
        If (Not bDefine) Or (LL.LlPrintIsFieldUsed(nm) <> 0) Then
            
            'D:   Feld-Typ aus der Datenbank feststellen und Feld definieren
            'US: Get field-type from database and define field
            t = DBSet(j).Type
            
            'D:   Boolean (wahr/falsch)
            'US: Boolean (true/false)
            If t = DB_BOOLEAN Then
                If DBSet(j).Value Then ct = "T" Else ct = "F"
                ret = LL.LlDefineFieldExt(nm, ct, LL_BOOLEAN)
            
            'D:   Double, Integer, Long, Single, Currency, Byte (Numerischer Wert)
            'US: Double, Integer, Long, Single, Currency, Byte (numeric value)
            ElseIf t = DB_DOUBLE Or t = DB_INTEGER Or t = DB_LONG Or t = DB_SINGLE Or t = DB_CURRENCY Or t = DB_BYTE Then
                ct = Str$(DBSet(j).Value)
                ret = LL.LlDefineFieldExt(nm, ct, LL_NUMERIC)
            
            'D:   Alles andere: normaler Text
            'US: Anything else: normal text
            Else
                If DBSet(j).Value <> "" Then
                    ct = DBSet(j).Value
                Else
                    ct = ""
                End If
                ret = LL.LlDefineFieldExt(nm, ct, LL_TEXT)
        
                'D:   Text aus ISBN-Feld löschen
                'US: Delete text from ISBN-field
                If nm = "ISBN" Then
                    i = 1
                    While i <= Len(ct)
                        c = Mid$(ct, i, 1)
                        If c = "-" Then
                            ct = left$(ct, i - 1) + Mid$(ct, i + 1)
                        ElseIf (c < "0" Or c > "9") And c <> "X" Then
                            ct = left$(ct, i - 1)
                        Else
                            i = i + 1
                        End If
                    Wend
                    If Len(ct) <> 10 Then
                        ct = ""
                    Else
                        ct = "*" + ct + "*"
                    End If

                    'D:   ISBN-Nummer als Barcode definieren
                    'US: Define ISBN-no as barcode
                    ret = LL.LlDefineFieldExt(nm + "_3OF9", ct, LL_BARCODE_3OF9)
                    
                End If '(ISBN)
                
            End If '(variable-type)
            
        End If '(real-data?)
        
    Next

End Sub

'======================================================
Private Sub Check1_Click()
'======================================================
    
    'D:   (De)Aktiviert Debug-Ausgaben
    'US: enables or disables debug-print
    If Check1.Value = 1 Then
        MsgBox ("D:   DEBWIN muss vor Visual Basic gestartet werden" & Chr(13) & Chr(10) & "US: DEBWIN must be started before Visual Basic")
        LL.LlSetDebug 1
    Else
        LL.LlSetDebug 0
    End If

End Sub

'======================================================
Private Sub EditLabel_Click()
'======================================================
    
'D:   Etiketten-Designer aufrufen
'US: Start label-designer
    
    'D:   Deklarationen
    'US: Declarations
    Dim sFilename As String
    Dim DBSet As Snapshot
    Dim SQL As String
    
    'D:   Projekt-Datei auswählen
    'US: Select project-file
    ret = LL.LlSelectFileDlgTitle(hWnd, "Select project-file", LL_PROJECT_LABEL Or LL_FILE_ALSONEW, sFilename)
    
    If (ret = 0) Then
        
        'D:   Über einen SQL-Ausdruck werden die Beispiel-Daten extrahiert
        'US: Extrakt sample-data via SQL-statement
        SQL = "SELECT *"
        SQL = SQL & " FROM Authors,Titles,Publishers"
        SQL = SQL & " WHERE Titles.Au_ID=Authors.Au_ID"
        SQL = SQL & "   AND Titles.PubID=Publishers.PubID"
        SQL = SQL & " ORDER BY Authors.Author"
        Screen.MousePointer = 11
        Set DBSet = DbObj.CreateSnapshot(SQL, DB_READONLY Or DB_CONSISTENT)
        Screen.MousePointer = 1

        'D:   Gehe zum ersten Datensatz
        'US: Goto first record
        DBSet.MoveFirst

        'D:   Variablen definieren
        'US: Define variables
        DefineVariables DBSet, True

        'D:   Datenbank (-Snapshot) schließen
        'D:   Close database (-snapshot)
        DBSet.Close

        'D:   User-Objekte definieren
        'US: Define user-objects
        ret = LL.LlDefineVariableExt("SalesStatistics", "", LL_DRAWING_USEROBJ)
        ret = LL.LlDefineVariableExt("SalesStatisticsColored", "", LL_DRAWING_USEROBJ_DLG)

        'D:   Designer starten
        'US: Start the designer
        ret = LL.LlDefineLayout(BaseForm.hWnd, "Design", LL_PROJECT_LABEL, sFilename)

    End If
    
End Sub

'======================================================
Private Sub EditTable_Click()
'======================================================
    
'D:   Listen-Designer aufrufen
'US: Start report-designer
    
    'D:   Deklarationen
    'US: Declarations
    Dim sFilename As String
    Dim DBSet As Snapshot
    Dim SQL As String
    
    'D:   Projekt-Datei auswählen
    'US: Select project-file
    ret = LL.LlSelectFileDlgTitle(BaseForm.hWnd, "Select File", LL_PROJECT_LIST Or LL_FILE_ALSONEW, sFilename)
    
    If (ret = 0) Then

        'D:   Über einen SQL-Ausdruck werden die Beispiel-Daten extrahiert
        'US: Extrakt sample-data via SQL-statement
        SQL = "SELECT *"
        SQL = SQL & " FROM Authors,Titles,Publishers"
        SQL = SQL & " WHERE Titles.Au_ID=Authors.Au_ID"
        SQL = SQL & "   AND Titles.PubID=Publishers.PubID"
        Screen.MousePointer = 11
        Set DBSet = DbObj.CreateSnapshot(SQL, DB_READONLY Or DB_CONSISTENT)
        Screen.MousePointer = 1

        'D:   Gehe zum ersten Datensatz
        'US: Goto first record
        DBSet.MoveFirst

        'D:   Felder definieren
        'US: Define Fields
        Call DefineFields(DBSet, True)

        'D:   Datenbank-unabhängige Variablen definieren
        'US: Define database-indepedent variables
        ret = LL.LlDefineVariableExt("AUTHOR_FIRST", "Anthony", LL_TEXT)
        ret = LL.LlDefineVariableExt("AUTHOR_LAST", "Zachary", LL_TEXT)

        'D:   Datenbank (-Snapshot) schließen
        'D:   Close database (-snapshot)
        DBSet.Close
        
        'D:   Callback für Tabellen-Farbe aktiviert?
        'US: Table coloring callback enabled?
        If bUseCallbacks <> 0 Then
            ret = LL.LlSetOption(LL_OPTION_TABLE_COLORING, LL_COLORING_PROGRAM)
        Else
            ret = LL.LlSetOption(LL_OPTION_TABLE_COLORING, LL_COLORING_LL)
        End If
        
        'D:   Grafik als Feld definieren
        'US: Define Pic as field
        ret = LL.LlDefineFieldExt("Signet", "sunny.wmf", LL_DRAWING)

        'D:   Definition eines Callback-Objektes
        'US: Define callback-object
        ret = LL.LlDefineFieldExt("SalesStatistics", "", LL_DRAWING_USEROBJ)

        'D:   Designer starten
        'US: Start the designer
        ret = LL.LlDefineLayout(BaseForm.hWnd, "List", LL_PROJECT_LIST, sFilename)

    End If

End Sub

'======================================================
Private Sub FileExit_Click()
'======================================================
    
    'D:   Beendet das Programm
    'US: Exit program
    Unload BaseForm
    
End Sub

'======================================================
Private Sub Form_KeyPress(KeyAscii As Integer)
'======================================================
    
    'D:   Anwendung mit ESC beenden
    'US: Terminate application with ESC
    If KeyAscii = 27 Then Unload BaseForm
    
End Sub

Private Sub Form_Load()
'======================================================================================
'
' Copyright (C) combit GmbH
'
'--------------------------------------------------------------------------------------
' File   : main.frm, Paradlg.frm
' Module : cmll25.bas, constant.txt, datacons.txt gdiapi.txt, userapi.txt
' Descr. : D:   Dieses Beispiel demonstriert das Designen und Drucken von
'              Etiketten, Listen und User-Objekten
'          US: This example demonstrates how to design and print
'              labels, reports and user-objects
'======================================================================================

'D:   Zentriert die Form auf dem Desktop
'US: Center form to desktop
left = (Screen.Width - Width) / 2: top = (Screen.Height - Height) / 2

'D:   Callbacks nicht benutzen (Voreinstellung)
'US: Do not use callbacks (default)
bUseCallbacks = 0

'D:   Setzt die List & Label Sprache auf einen Default Wert
'US: Set the List & Label language to a default value
LL.Language = CMBTLANG_DEFAULT

'D:  Callback LL_CMND_TABLELINE aktivieren
'US: Enable Callback LL_CMND_TABLELINE
LL.LlSetOption LL_OPTION_CALLBACKMASK, LL_CB_TABLELINE
LL.LlSetOption LL_OPTION_TABLE_COLORING, LL_COLORING_DONTCARE

'D:   In das Applikations-Verzeichnis wechseln
'US: Change to app-path
ChDir App.Path
ChDrive left$(App.Path, 1)
Dim datavar$
datavar$ = App.Path + "\testdb.mdb"

'D:   Datenbank laden
'US: Load database
Set DbObj = OpenDatabase(datavar$)

'D:   Informationen in das Debug-Fenster drucken
'US: Print info to debug-window
Debug.Print "datavar:    "; datavar$
Debug.Print "Name:    "; DbObj.Name
Debug.Print "Connect: "; DbObj.Connect

End Sub

'======================================================
Private Sub Form_Unload(Cancel As Integer)
'======================================================
    
    'D:   Datenbank schließen
    'US: Close database
    DbObj.Close
    
End Sub

'======================================================
Private Sub DefineVariables(DBSet As Snapshot, bDefine As Boolean)
'======================================================
    
'D:   Variablen definieren
'US: Define variables
    
    'D:   Deklarationen
    'US: Declarations
    Dim ct As String
    Dim i As Integer
    Dim j As Integer
    Dim t As Integer
    Dim c As String
    Dim nm As String

    'D:   Variablen definieren
    'US: Define variables
    For j = 0 To DBSet.Fields.Count - 1
        nm = DBSet(j).Name

        'D:   Echtdaten aus Datenbank laden
        'US: Load real-data from database
        If (Not bDefine) Or LL.LlPrintIsVariableUsed(nm) <> 0 Then
            
            'D:   Variablen-Typ aus der Datenbank feststellen und Variable definieren
            'US: Get variable-type from database and define field
            t = DBSet(j).Type
            
            'D:   Boolean (wahr/falsch)
            'US: Boolean (true/false)
            If t = DB_BOOLEAN Then
                If DBSet(j).Value Then ct = "T" Else ct = "F"
                ret = LL.LlDefineVariableExt(nm, ct, LL_BOOLEAN)
            
            'D:   Double, Integer, Long, Single, Currency, Byte (Numerischer Wert)
            'US: Double, Integer, Long, Single, Currency, Byte (numeric value)
            ElseIf t = DB_DOUBLE Or t = DB_INTEGER Or t = DB_LONG Or t = DB_SINGLE Or t = DB_CURRENCY Or t = DB_BYTE Then
                ct = Str$(DBSet(j).Value)
                ret = LL.LlDefineVariableExt(nm, ct, LL_NUMERIC)
            
            'D:   Alles andere: normaler Text
            'US: Anything else: normal text
            Else
                If DBSet(j).Value <> "" Then
                    ct = DBSet(j).Value
                Else
                    ct = ""
                End If
                ret = LL.LlDefineVariableExt(nm, ct, LL_TEXT)
    
                'D:   Text aus ISBN-Variable löschen
                'US: Delete text from ISBN-variable
                If nm = "ISBN" Then
                    i = 1
                    While i <= Len(ct)
                        c = Mid$(ct, i, 1)
                        If c = "-" Then ' ignore
                            ct = left$(ct, i - 1) + Mid$(ct, i + 1)
                          Else
                            If (c < "0" Or c > "9") And c <> "X" Then ' end
                                ct = left$(ct, i - 1)
                              Else
                                i = i + 1   ' next character
                                End If
                            End If
                        Wend
                    If Len(ct) <> 10 Then
                        ct = ""
                    Else
                        ct = "*" + ct + "*"
                    End If
                    
                    'D:   ISBN-Nummer als Barcode definieren
                    'US: Define ISBN-no as barcode
                    ret = LL.LlDefineVariableExt(nm + "_3OF9", ct, LL_BARCODE_3OF9)
                
                End If '(ISBN)
            
            End If '(variable-type)
        
        End If '(real-data?)
    
    Next

End Sub

'======================================================
Private Sub LL_CmndDrawUserobj(ByVal sName As String, ByVal sContents As String, ByVal lPara As Long, ByVal lpPtr As Long, ByVal hPara As Long, ByVal bIsotropic As Long, ByVal sParameters As String, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal left As Long, ByVal top As Long, ByVal right As Long, ByVal bottom As Long, ByVal nPaintMode As Long)
'======================================================
    
Debug.Print "LL_CmndDrawUserobj"
Debug.Print sName
Debug.Print sContents

'D:   User-Objekt drucken
'US: Print user-Object
    
    'D:   Deklarationen
    'US: Declarations
    #If Win16 Then
        Dim hPen As Integer
        Dim hBrush As Integer
        Dim i As Integer
        Dim x As Integer
        Dim y As Integer
        Dim rc As RECT
        Dim nColor As Long
        Dim rcPaint As RECT
    #Else
        Dim hPen As Long
        Dim hBrush As Long
        Dim i As Long
        Dim x As Long
        Dim y As Long
        Dim rc As RECT
        Dim nColor As Long
        Dim rcPaint As RECT
    #End If
    
    #If Win32 Then
        Dim p As POINTAPI
    #End If

    'D:   Callback-Variable "SalesStatistic"
    'US: Callback-variable "SalesStatistic"
    If sName = "SalesStatistics" Then

        hPen = SelectObject(hPaintDC, GetStockObject(BLACK_PEN))
        rcPaint.left = left
        rcPaint.top = top
        rcPaint.right = right
        rcPaint.bottom = bottom
        rc = rcPaint
        
        rc.top = rc.top + 10
        rc.bottom = rc.bottom - 10
        
        #If Win16 Then
            ret = MoveTo(hPaintDC, rc.left, rc.top)
        #Else
            ret = MoveToEx(hPaintDC, rc.left, rc.top, p)
        #End If
        ret = LineTo(hPaintDC, rc.right, rc.top)
        ret = LineTo(hPaintDC, rc.right, rc.bottom)
        ret = LineTo(hPaintDC, rc.left, rc.bottom)
        ret = LineTo(hPaintDC, rc.left, rc.top)

        'D:   Zufallsdaten für Grafik ermitteln
        'US: Get Random-Data for chart
        Randomize
        For i = 0 To 10
            x = rc.left + MulDiv(rc.right - rc.left, i, 10)
                        y = rc.top + (rc.bottom - rc.top) * Rnd(1)
            If (i = 0) Then
                #If Win16 Then
                    ret = MoveTo(hPaintDC, x, y)
                #Else
                    ret = MoveToEx(hPaintDC, x, y, p)
                #End If
            Else
                ret = LineTo(hPaintDC, x, y)
            End If
        Next i
        ret = SelectObject(hPaintDC, hPen)
        
    ElseIf sName = "SalesStatisticsColored" Then
    
        If sParameters = "R" Or sParameters = "" Then
            nColor = RGB(255, 0, 0)
        ElseIf sParameters = "G" Then
            nColor = RGB(0, 255, 0)
        ElseIf sParameters = "B" Then
            nColor = RGB(0, 0, 255)
        End If
        
        rcPaint.left = left
        rcPaint.top = top
        rcPaint.right = right
        rcPaint.bottom = bottom

        rc = rcPaint

        rc.top = rc.top + 10
        rc.bottom = rc.bottom - 10

        hPen = SelectObject(hPaintDC, GetStockObject(BLACK_PEN))
        #If Win16 Then
            ret = MoveTo(hPaintDC, rc.left, rc.top)
        #Else
            ret = MoveToEx(hPaintDC, rc.left, rc.top, p)
        #End If
        ret = LineTo(hPaintDC, rc.right, rc.top)
        ret = LineTo(hPaintDC, rc.right, rc.bottom)
        ret = LineTo(hPaintDC, rc.left, rc.bottom)
        ret = LineTo(hPaintDC, rc.left, rc.top)

        hBrush = SelectObject(hPaintDC, CreateSolidBrush(nColor))
        ret = Rectangle(hPaintDC, rc.left, rc.top, rc.right, rc.bottom)

        For i = 0 To 10
            x = rc.left + MulDiv(rc.right - rc.left, i, 10)
            y = rc.top + (rc.bottom - rc.top) * (0.8 * Rnd(1))
            If (i = 0) Then
                #If Win16 Then
                    ret = MoveTo(hPaintDC, x, y)
                #Else
                    ret = MoveToEx(hPaintDC, x, y, p)
                #End If
            Else
                ret = LineTo(hPaintDC, x, y)
            End If
        Next i
        
        ret = DeleteObject(SelectObject(hPaintDC, hBrush))
        ret = SelectObject(hPaintDC, hPen)
        
    End If

End Sub


'======================================================
Private Sub LL_CmndTableField(ByVal nType As ListLabel.LlTableFieldTypeConstants, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal rcPaint_left As Long, ByVal rcPaint_top As Long, ByVal rcPaint_right As Long, ByVal rcPaint_bottom As Long, ByVal nLineDef As Long, ByVal nIndex As Long, ByVal rcSpacing_left As Long, ByVal rcSpacing_top As Long, ByVal rcSpacing_right As Long, ByVal rcSpacing_bottom As Long, ByVal sContent As String)
'======================================================

'D:   Dieser Callback wird für jedes Feld einer Tabelle aufgerufen,
'    nachdem LL_CmndTableLine für jede Zeile aufgerufen wurde
'US: This callback is called for each field of a table
'    after the LL_CmndTableLine callback for the whole line

    'D:   Deklarationen
    'US: Declarations
    #If Win16 Then
        Dim hBrush As Integer
        Dim hPen As Integer
    #Else
        Dim hBrush As Long
        Dim hPen As Long
    #End If

    'D:   Jedes zweite Feld mit rotem Hintergrund füllen
    'US: Fill every second field of the body with a red background
    If (nType = LL_TABLE_FIELD_BODY And nIndex = 1 And bUseCallbacks = 1) Then
        hBrush = SelectObject(hPaintDC, CreateSolidBrush(RGB(255, 0, 0)))
        hPen = SelectObject(hPaintDC, GetStockObject(NULL_PEN))
        dummy = Rectangle(hPaintDC, rcPaint_left, rcPaint_top, rcPaint_right, rcPaint_bottom)
        dummy = DeleteObject(SelectObject(hPaintDC, hBrush))
        dummy = DeleteObject(SelectObject(hPaintDC, hPen))
    End If

End Sub



'======================================================
Private Sub LL_CmndEditUserobj(ByVal sName As String, ByVal lPara As Long, ByVal lpPtr As Long, ByVal hPara As Long, ByVal bIsotropic As Long, ByVal hWnd As Long, psParameters As String)
'======================================================
    
'D:   Benutzer hat auf "Bearbeiten..." geklickt
'US: User hit "Edit..."
    
    #If Win32 Then
        Dim dummy As Long
    #Else
        Dim dummy As Integer
    #End If

    'D:   Parameter in globale Variable setzen
    'US: Set global parameter-variable
    ObjParameters = psParameters
    
    'D:   Parameter-Dialog anzeigen
    'US: Show parameter-dialog
    ParaDlg.Show (1)

    'D:   Wenn "OK", dann Parameter ändern
    'US: If "OK" change parameter
    If psParameters <> "" Then
        psParameters = ObjParameters
    End If

End Sub


'======================================================
Private Sub LL_CmndHelp(nType As Integer, nContextID As Integer)
'======================================================
    
    'D:   Informationen in das Debug-Fenster drucken
    'US: Print info to debug-window
    Debug.Print "Help... Type="; nType; ", ID="; nContextID
  
End Sub


'======================================================
Private Sub LL_CmndObject(ByVal sName As String, ByVal nType As Long, ByVal bPreDraw As Long, ByVal hRefDC As Long, ByVal hPaintDC As Long, left As Long, top As Long, right As Long, bottom As Long)
'======================================================
    
    'D:   Informationen in das Debug-Fenster drucken
    'US: Print info to debug-window
    Debug.Print "Object"

End Sub




'======================================================
Private Sub LL_CmndProject(ByVal bDesignerPreview As Long, ByVal bPreDraw As Long, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal left As Long, ByVal top As Long, ByVal right As Long, ByVal bottom As Long)
'======================================================
    
    'D:   Informationen in das Debug-Fenster drucken
    'US: Print info to debug-window
    Debug.Print "Project"
    
End Sub





'======================================================
Private Sub LL_CmndTableLine(ByVal nType As Long, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal rcPaint_left As Long, ByVal rcPaint_top As Long, ByVal rcPaint_right As Long, ByVal rcPaint_bottom As Long, ByVal nPageLine As Long, ByVal nLine As Long, ByVal nLineDef As Long, ByVal bZebra As Long, ByVal rcSpacing_left As Long, ByVal rcSpacing_top As Long, ByVal rcSpacing_right As Long, ByVal rcSpacing_bottom As Long)
'======================================================

'D:   Dieser Callback wird für jede Zeile einer Tabelle aufgerufen
'US: This callback is called for each line of a table

    'D:   Deklarationen
    'US: Declarations
    #If Win16 Then
        Dim hBrush As Integer
        Dim hPen As Integer
    #Else
        Dim hBrush As Long
        Dim hPen As Long
    #End If

    'D:   Jede zweite Datenzeile mit Hintergrundfarbe Cyan füllen
    'US: Fill every second body line with a cyan background
    If (nType = LL_TABLE_FIELD_BODY) And (nPageLine Mod 2) = 0 And bUseCallbacks = 1 Then
        hBrush = SelectObject(hPaintDC, CreateSolidBrush(RGB(0, 255, 255)))
        hPen = SelectObject(hPaintDC, GetStockObject(NULL_PEN))
        dummy = Rectangle(hPaintDC, rcPaint_left, rcPaint_top, rcPaint_right, rcPaint_bottom)
        dummy = DeleteObject(SelectObject(hPaintDC, hBrush))
        dummy = DeleteObject(SelectObject(hPaintDC, hPen))
    End If
    
End Sub

'======================================================
Private Sub LL_CmndVarHelptext(ByVal sName As String, psHelptext As String)
'======================================================
    
    'D:   Definiert Beschreibungs-Texte für die Variablen
    'US: Defines description-text for each variable
    If sName = "AUTHOR_LAST" Then
        psHelptext = "Last Author"
    ElseIf sName = "AUTHOR_FIRST" Then
        psHelptext = "First Author"
    Else
        psHelptext = "Helptext not defined -> see LL_CmndVarHelptext!"
    End If
    
End Sub

'======================================================
Private Sub PrintLabel_Click()
'======================================================
    
    'D:   Etiketten auf Drucker drucken
    'US: Print labels to printer
    PrintLabelGeneric (0)
    
End Sub

'======================================================
Private Sub PrintLabelGeneric(nPreview As Integer)
'======================================================

'D:   Etiketten auf Basis der Datenbank im DbObj ausdrucken
'US: Print labels with data from database in DbObj
    
    'D:   Deklarationen
    'US: Declarations
    Dim fcount As Integer
    Dim DBSet As Snapshot
    Dim SQL As String
    Dim sFilename As String
    Dim sPrinter As String
    Dim sPort As String
    Dim errorflag As Integer
    Dim nRecNo As Long
    Dim nRecCount As Long
    Dim nRecsRemaining As Long
    Dim c As String
    Dim sText As String
    
    'D:   Datei-Auswahl-Dialog
    'US: Select-File-dialog
    ret = LL.LlSelectFileDlgTitle(hWnd, "Select Label to Print", LL_PROJECT_LABEL, sFilename)
    
    If ret = 0 Then

        'D:   Über einen SQL-Ausdruck werden die Beispiel-Daten extrahiert
        'US: Create extract sample-data via SQL-statement
        SQL = ""
        SQL = SQL & "SELECT *"
        SQL = SQL & " FROM Authors,Titles,Publishers"
        SQL = SQL & " WHERE Titles.Au_ID=Authors.Au_ID"
        SQL = SQL & "   AND Titles.PubID=Publishers.PubID"
        SQL = SQL & " ORDER BY Authors.Author"
        Screen.MousePointer = 11
        Set DBSet = DbObj.CreateSnapshot(SQL, DB_READONLY Or DB_CONSISTENT)
        Screen.MousePointer = 1

        'D:   Gehe zum ersten Datensatz
        'US: Go to first record
        DBSet.MoveFirst

        'D:   Anzahl der Datensätze für Prozentbalken auslesen
        'US: Get recordcount for percentbar
        nRecsRemaining = DBSet.RecordCount

        'D:   Variablen definieren
        'US: Define variables
        DefineVariables DBSet, True


        'D:   Callback-Objekte definieren
        'US: Define callback-objects
        ret = LL.LlDefineVariableExt("SalesStatistics", "", LL_DRAWING_USEROBJ)
        ret = LL.LlDefineVariableExt("SalesStatisticsColored", "", LL_DRAWING_USEROBJ_DLG)

        If nPreview <> 0 Then
            'D:   Druck auf Vorschau
            'US: Print to preview
            ret = LL.LlPrintWithBoxStart(LL_PROJECT_LABEL, sFilename, LL_PRINT_PREVIEW, LL_BOXTYPE_STDABORT, BaseForm.hWnd, "Printing...")
            ret = LL.LlPreviewSetTempPath("")
        Else
            'D:   Druck auf Drucker
            'US: Print to printer
            ret = LL.LlPrintWithBoxStart(LL_PROJECT_LABEL, sFilename, LL_PRINT_EXPORT, LL_BOXTYPE_STDABORT, BaseForm.hWnd, "Printing...")
            ret = LL.LlPrintSetOption(LL_OPTION_JOBPAGES, 2)
        End If
        
        If (ret = 0) Then
            'D:   Kopien-Auswahl verstecken
            'US: Hide "copies"
            ret = LL.LlPrintSetOption(LL_OPTION_COPIES, LL_COPIES_HIDE)
            
            'D:   Anzeige des Drucker-Dialogs
            'US: Show printer-dialog
            If (nPreview <> 0) Then sText = "Printing to Preview" + Chr$(13)
            sText = sText + "About" + Str$(CInt(DBSet.RecordCount / LL.LlPrintGetItemsPerPage())) + " Pages"
            ret = LL.LlPrintOptionsDialog(BaseForm.hWnd, sText)
            
            If (ret = 0) Then
        
                'D:   Anzahl der zu druckenden Elemente (Firstpage/Lastpage)
                'US: Count of records to print (Firstpage/Lastpage)
                nRecCount = LL.LlPrintGetOption(LL_OPTION_LASTPAGE)
                If nRecCount = 2147483647 Then
                    nRecCount = nRecsRemaining
                Else
                    nRecCount = (nRecCount - LL.LlPrintGetOption(LL_OPTION_PAGE) + 1) * LL.LlPrintGetItemsPerPage()
                End If

                nRecNo = 1
                errorflag = 0

                'D:   Printer-Infos auslesen
                'US: Get printer-info
                ret = LL.LlPrintGetPrinterInfo(sPrinter, sPort)

                'D:   Datensätze drucken bis das Ende der Datenbank erreicht
                'US: Print records until reaching end of database
                While (Not DBSet.EOF) And nRecNo <= nRecCount And errorflag = 0

                    'D:   Variablen definieren
                    'US: Define variables
                    Call DefineVariables(DBSet, False)
                    
                    'D:   Prozentbalken
                    'US: Percentbar
                    ret = LL.LlPrintSetBoxText(sText, ((100& * nRecNo) / nRecCount))

                    'D:   Variablen drucken
                    'US: Print variables
                    ret = LL.LlPrint()
                    
                    If ret < 0 Then
                        errorflag = 1
                    Else
                        'D:   Gehe zum nächsten Datensatz
                        'US: Go to next record
                        DBSet.MoveNext
                        nRecNo = nRecNo + 1
                    End If
                    
                Wend
    
                'D:   Druck beenden
                'US: End print
                ret = LL.LlPrintEnd(0)
            Else
                'D:   Druck beenden
                'US: End print
                ret = LL.LlPrintEnd(0)
            End If
            
        Else  ' LlPrintWithBoxStart
            
            'D:   Druck beenden
            'US: End print
            ret = LL.LlPrintEnd(0)
            MsgBox "Error", MB_OK
        
        End If
        
        'D:   Datenbank-Auszug schließen
        'US: Close database snapshot
        DBSet.Close

    End If

End Sub

'======================================================
Private Sub PrintPreviewLabel_Click()
'======================================================
    
    'D:   Etiketten auf Vorschau drucken
    'US: Print labels to preview
    PrintLabelGeneric (1)
    
End Sub

'======================================================
Private Sub PrintPreviewTable_Click()
'======================================================
    
    'D:   Tabelle auf Vorschau drucken
    'US: Print report to preview
    PrintTableGeneric (1)
    
End Sub

'======================================================
Private Sub PrintTable_Click()
'======================================================
    
    'D:   Tabelle auf Drucker drucken
    'US: Print report to printer
    PrintTableGeneric (0)
    
End Sub

'======================================================
Private Sub PrintTableGeneric(nPreview As Integer)
'======================================================
    
'D:   Tabelle auf Basis der Datenbank im DbObj ausdrucken
'US: Print report with data from database in DbObj
    
    Dim DBSet As Snapshot
    Dim SQL As String
    Dim sFilename As String
    Dim sPrinter As String
    Dim sPort As String
    Dim errorflag As Integer
    Dim nRecNo As Long
    Dim nRecCount As Long
    Dim nRecsRemaining As Long
    Dim c As String
    Dim sError As String
    Dim sLastAuthor As String
    Dim bMatches As Integer
    
    'D:   Datei-Auswahl-Dialog
    'US: Select-File-dialog
    ret = LL.LlSelectFileDlgTitle(hWnd, "Select Table to Print", LL_PROJECT_LIST, sFilename)
    
    If ret = 0 Then

        'D:   Über einen SQL-Ausdruck werden die Beispiel-Daten extrahiert
        'US: Create extract sample-data via SQL-statement
        SQL = ""
        SQL = SQL & "SELECT *"
        SQL = SQL & " FROM Authors,Titles,Publishers"
        SQL = SQL & " WHERE Titles.Au_ID=Authors.Au_ID"
        SQL = SQL & "   AND Titles.PubID=Publishers.PubID"
        Screen.MousePointer = 11
        Set DBSet = DbObj.CreateSnapshot(SQL, DB_READONLY Or DB_CONSISTENT)
        Screen.MousePointer = 1

        'D:   Variablen definieren
        'US: Define variables
        Call DefineFields(DBSet, True)

        'D:   Callback-Objekt definieren
        'US: Define callback-object
        ret = LL.LlDefineFieldExt("SalesStatistics", "", LL_DRAWING_USEROBJ)

        'D:   Datenbank-unabhängige Variablen definieren
        'US: Define database-independent variables
        ret = LL.LlDefineVariableExt("AUTHOR_FIRST", "", LL_TEXT)
        ret = LL.LlDefineVariableExt("AUTHOR_LAST", "", LL_TEXT)

        
        If nPreview <> 0 Then
            'D:   Druck auf Vorschau
            'US: Print to preview
            ret = LL.LlPrintWithBoxStart(LL_PROJECT_LIST, sFilename, LL_PRINT_PREVIEW, LL_BOXTYPE_STDABORT, BaseForm.hWnd, "Printing...")
            ret = LL.LlPreviewSetTempPath("")
        Else
            'D:   Druck auf Drucker
            'US: Print to printer
            ret = LL.LlPrintWithBoxStart(LL_PROJECT_LIST, sFilename, LL_PRINT_EXPORT, LL_BOXTYPE_STDABORT, BaseForm.hWnd, "Printing...")
        End If

        If (ret = 0) Then
            'D:   Kopien-Auswahl verstecken
            'US: Hide "copies"
            ret = LL.LlPrintSetOption(LL_OPTION_COPIES, LL_COPIES_HIDE)

            'D:   Anzeige des Drucker-Dialogs
            'US: Show printer-dialog
            ret = LL.LlPrintOptionsDialog(BaseForm.hWnd, "Print")
            
            'D:   Sortierung
            'US: Sortorder
            If (ret = 0) Then
                DBSet.Close
                SQL = ""
                SQL = SQL & "SELECT *"
                SQL = SQL & " FROM Authors,Titles,Publishers"
                SQL = SQL & " WHERE Titles.Au_ID=Authors.Au_ID"
                SQL = SQL & "   AND Titles.PubID=Publishers.PubID"
                SQL = SQL & " ORDER BY Titles.Title"
                Screen.MousePointer = 11
                Set DBSet = DbObj.CreateSnapshot(SQL, DB_READONLY Or DB_CONSISTENT)
                Screen.MousePointer = 1
            Else
                If ret = LL_ERR_USER_ABORTED Then
                    LL.LlPrintEnd (0)
                    
                    Exit Sub
                End If
            End If

            'D:   Gehe zum ersten Datensatz
            'US: Go to first record
            DBSet.MoveFirst

            'D:   Anzahl der zu druckenden Elemente (Firstpage/Lastpage)
            'US: Count of records to print (Firstpage/Lastpage)
            nRecsRemaining = DBSet.RecordCount

            'D:   Aktueller Datensatz --> 1, [...]
            'US: Current record --> 1, [...]
            nRecNo = 1
            errorflag = 0
            sLastAuthor = ""

            'D:   Seite für Seite...
            'US: Page per page...
            While (Not DBSet.EOF) And errorflag = 0 And ret = 0 And LL.LlPrintGetCurrentPage() <= LL.LlPrintGetOption(LL_OPTION_LASTPAGE)

                'D:   Variablen definieren und Ausdrucken
                'US: Define and print variables
                LL.LlDefineVariableExt "AUTHOR_FIRST", DBSet("Author").Value, LL_TEXT
                ret = LL.LlPrint()
                    
                'D:   Datensatz für Datensatz...
                'US: Recordset per recordset
                While (Not DBSet.EOF) And errorflag = 0 And ret = 0 And LL.LlPrintGetCurrentPage() <= LL.LlPrintGetOption(LL_OPTION_LASTPAGE)

                    'D:   Felder definieren
                    'US: Define fields
                    Call DefineFields(DBSet, False)

                    'D:   Prozentbalken
                    'US: Percentbar
                    ret = LL.LlPrintSetBoxText("Printing report", ((100& * nRecNo) / nRecsRemaining))
                    
                    'D:   Felder drucken
                    'US: Print fields
                    ret = LL.LlPrintFields()

                    If ret = 0 Then
                        If LL.LlPrintDidMatchFilter() = 1 Then sLastAuthor = DBSet("Author").Value

                        'D:   Variable "AUTHOR_LAST" setzen
                        'US: Define variable "AUTHOR_LAST"
                         LL.LlDefineVariableExt "AUTHOR_LAST", sLastAuthor, LL_TEXT

                        'D:   Gehe zum nächsten Datensatz
                        'US: Go to next recordset
                        DBSet.MoveNext
                        nRecNo = nRecNo + 1
                        
                    End If
                Wend
                    
                'D:   Solange Rückgabe = LL_WRN_REPEAT_DATA ...
                'US: While return = LL_WRN_REPEAT_DATA ...
                 LL.LlDefineFieldExt "Author", "Test", LL_TEXT
                While ret = LL_WRN_REPEAT_DATA
                    LL.LlPrint
                    ret = LL.LlPrintFields()
                Wend
                
            Wend
    
    
            'D:   Tabellen-Ausdruck beenden
            'US: End table-printing
            Do
                ret = LL.LlPrintFieldsEnd()
            Loop Until ret <> LL_WRN_REPEAT_DATA

            'D:   Wenn der Benutzer abbricht
            'US: If user hits cancel
            If ret = LL_ERR_USER_ABORTED Then
                LL.LlPrintEnd (0)
                Exit Sub
            End If

            'D:   Druck beenden
            'US: End print
            ret = LL.LlPrintEnd(0)
        Else

            'D:   Druck beenden
            'US: End printing
            ret = LL.LlPrintEnd(0)
            sError = LL.LlVBExprError()

#If Win32 Then
             sError = StrConv(sError, vbFromUnicode)
#End If

            MsgBox "Error: " & sError, MB_OK
            
        End If
        
        'D:   Datenbank schließen
        'US: Close database
        DBSet.Close

    End If

End Sub

'======================================================
Private Sub UseCB_Click()
'======================================================
    
    'D:   (De)Aktiviert Callbacks
    'US: enables or disables callbacks
    If bUseCallbacks <> 0 Then
        bUseCallbacks = 0
      Else
        bUseCallbacks = 1
    End If
    
    'D:   Menü-Häkchen setzen oder löschen
    'US: enables or disables menu-check
    UseCB.Checked = bUseCallbacks
End Sub


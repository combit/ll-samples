VERSION 5.00
Object = "{2213E283-16BC-101D-AFD4-040224009C1E}#30.0#0"; "cmll30o.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   Caption         =   "List & Label Quiet Export Sample"
   ClientHeight    =   2985
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7620
   LinkTopic       =   "Form1"
   ScaleHeight     =   2985
   ScaleWidth      =   7620
   StartUpPosition =   3  'Windows-Standard
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   6060
      Top             =   2400
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin ListLabel.ListLabel ListLabel1 
      Left            =   6900
      Top             =   2400
      _Version        =   65537
      _ExtentX        =   979
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
   Begin VB.Data Data1 
      BOFAction       =   1  'BOF
      Caption         =   "Data1"
      Connect         =   "Access 2000;"
      DatabaseName    =   ""
      DefaultCursorType=   0  'Standard-Cursor
      DefaultType     =   2  'ODBC verwenden
      EOFAction       =   1  'EOF
      Exclusive       =   -1  'True
      Height          =   345
      Left            =   5880
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   0  'Tabelle
      RecordSource    =   "Article"
      Top             =   2040
      Visible         =   0   'False
      Width           =   1692
   End
   Begin VB.CommandButton FileSelectBtn 
      Caption         =   "Choose..."
      Height          =   375
      Left            =   6000
      TabIndex        =   8
      Top             =   1620
      Width           =   1155
   End
   Begin VB.CheckBox CheckShowFile 
      Caption         =   "Show File after Creation"
      Height          =   255
      Left            =   2220
      TabIndex        =   7
      Top             =   2340
      Width           =   2355
   End
   Begin VB.CommandButton GoBtn 
      Caption         =   "Create File"
      Height          =   375
      Left            =   180
      TabIndex        =   6
      Top             =   2340
      Width           =   1155
   End
   Begin VB.TextBox Edit1 
      Height          =   315
      Left            =   1140
      TabIndex        =   5
      Text            =   "Text1"
      Top             =   1620
      Width           =   4635
   End
   Begin VB.ComboBox FormatCombo 
      Height          =   315
      ItemData        =   "EXPFM.frx":0000
      Left            =   1140
      List            =   "EXPFM.frx":0019
      Style           =   2  'Dropdown-Liste
      TabIndex        =   4
      Top             =   1140
      Width           =   4635
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "Filename:"
      Height          =   195
      Left            =   180
      TabIndex        =   3
      Top             =   1680
      Width           =   675
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "Format:"
      Height          =   195
      Left            =   180
      TabIndex        =   2
      Top             =   1140
      Width           =   525
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "US: This example demonstrates an export without user interaction"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   240
      Left            =   180
      TabIndex        =   1
      Top             =   600
      Width           =   6750
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "D: Dieses Beispiel zeigt den Export ohne weitere Benutzerinteraktion"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   240
      Left            =   180
      TabIndex        =   0
      Top             =   180
      Width           =   7095
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim FileFilter As String
Dim FileName As String
Dim FilePath As String
Dim ExporterName As String

Private Sub Edit1_Change()
FileName = Edit1.Text
End Sub

Private Sub FileSelectBtn_Click()
CommonDialog1.FileName = Edit1.Text
CommonDialog1.ShowSave
Edit1.Text = CommonDialog1.FileName
FileName = Edit1.Text

End Sub

Private Sub Form_Load()
'======================================================================================
'
' Copyright (C) combit GmbH
'
'--------------------------------------------------------------------------------------
' File   : export.vbp, expfm.frm, cmll30.bas
' Module : export sample
' Descr. : D: Dieses Beispiel demonstriert den Export ohne Benutzerinteraktion.
'          US: This example demonstrates an export without user interaction.
'======================================================================================

'D:  Zentriert die Form auf dem Desktop
'US: Center form to desktop
Left = (Screen.Width - Width) / 2: Top = (Screen.Height - Height) / 2

'D:  Wechselt auf Laufwerk & Verzeichnis der Beispiel-Anwendung
'US: Change to drive & path of example-app
ChDrive App.Path
ChDir App.Path

'D:  Schreibe in Path$ das übergeordnete Verzeichnis
'US: Set Path$ to parent-directory
Dim Path$
Path$ = App.Path
While Mid(Path$, Len(Path$), 1) <> "\"
    Path$ = Left(Path$, Len(Path$) - 1)
Wend

'D:  Lädt die Access-Datenbank
'US: Load Access-database
Data1.DatabaseName = Path$ & "simple.mdb"

'D:  Setzt die List & Label Sprache auf einen Default Wert
'US: Set the List & Label language to a default value
ListLabel1.Language = CMBTLANG_DEFAULT

FormatCombo.ListIndex = 0

End Sub

Private Sub FormatCombo_Click()
'D:  Default-Dateinamen, Filter und Exporternamen setzen
'US: Set default file name, path and exporter name

Select Case FormatCombo.ListIndex
Case 0:
          FileFilter = "*.PDF"
          FileName = "export.pdf"
          ExporterName = "PDF"
Case 1:
          FileFilter = "*.MHT"
          FileName = "export.mht"
          ExporterName = "MHTML"
        
Case 2:
          FileFilter = "*.RTF"
          FileName = "export.rtf"
          ExporterName = "RTF"
        
Case 3:
          FileFilter = "*.XML"
          FileName = "export.xml"
          ExporterName = "XML"
        
Case 4:
          FileFilter = "*.TIF"
          FileName = "export.tif"
          ExporterName = "PICTURE_MULTITIFF"
        
Case 5:
          FileFilter = "*.TXT"
          FileName = "export.txt"
          ExporterName = "TXT"
        
Case 6:
          FileFilter = "*.XLS"
          FileName = "export.xls"
          ExporterName = "XLS"
        
End Select
FileName = App.Path & "\" & FileName
Edit1.Text = FileName

End Sub

Private Sub GoBtn_Click()
'D:  Druck starten. Die Exporteroptionen werden in LLSetPrintOptions übergeben.
'    Wichtig: hier keinen Dateiauswahl- und keinen Druckoptionsdialog anzeigen
'US: Start printing. The exporter options are passed in LLSetPrintOptions.
'    Important: no file selection dialog and no print options dialog is displayed.
    Dim ret%
    Form1.Data1.Recordset.MoveFirst
    ret% = ListLabel1.Print(0, LL_PROJECT_LIST, App.Path & "\simple.lst", 0, LL_PRINT_EXPORT, _
                            LL_BOXTYPE_STDWAIT, hWnd, "Print list...", False, Environ$("temp"))
    

End Sub

Function ExtractFilePath(sFile As String)
    ExtractFilePath = Mid(sFile, 1, InStrRev(sFile, "\"))
End Function

Function ExtractFileName(sFile As String)
    ExtractFileName = Mid(sFile, InStrRev(sFile, "\") + 1)
End Function

Private Sub ListLabel1_CmndDefineFields(ByVal nUserData As Long, ByVal bDummy As Long, pnProgressInPerc As Long, pbLastRecord As Long)

'D:  Dieser Event wird von den List & Label Befehlen Print und Design ausgelöst
'    Er wird für jeden Datensatz aufgerufen um die Variablen und deren Inhalt
'    an List & Label zu übergeben.
'US: This event is called by the List & Label methods Print and Design
'    It will be called for each record to define the variables and their
'    contents
    
    Dim i As Integer
    Dim para As Long
    Dim content$
    Dim a!
    
    'D:  Wiederholung für alle Felder eines Datensatzes
    'UR: Loop for each field in the present recordset
    For i = 0 To Form1.Data1.Recordset.Fields.Count - 1
        
        'D:  Wiederholung für alle Felder eines Datensatzes
        'UR: Loop for each field in the present recordset
        Select Case Form1.Data1.Recordset.Fields(i).Type
                                            
            'D:  Numerisches Feld
            'US: Numeric field
            Case 3, 4, 6, 7:     para = LL_NUMERIC:      content$ = Form1.Data1.Recordset.Fields(i)
            
            'D:  Falls der Datentyp "Datum" ist, Umwandlung in einen numerischen Datumswert
            'US: If datatyp "Date" convert to numeric date-value
            Case 8:             para = LL_DATE_MS:      a! = CDate(Form1.Data1.Recordset.Fields(i)): content$ = a!:
            
            'D:  Entscheidungsfeld (Ja/Nein), Boolean
            'US: True/False field, boolean
            Case 1:            para = LL_BOOLEAN:      content$ = Form1.Data1.Recordset.Fields(i)
            
            'D:  Zeichenformat = Text
            'US: Characterformat = Text
            Case Else:          para = LL_TEXT:         content$ = Form1.Data1.Recordset.Fields(i)
        
        End Select
        Dim nRet As Integer
        nRet = Form1.ListLabel1.LlDefineVariableExt(Form1.Data1.Recordset.Fields(i).Name, _
                                                      content$, para)
    
    Next i

    'D:  Werden Echt-Daten benötigt? (nicht bei Designer-Aufruf)
    'US: Is real data needed? (not when method Design has been called)
    If bDummy = 0 Then

        'D:  Gehe zum nächsten Datensatz
        'US: Jump to next record
        pnProgressInPerc = Form1.Data1.Recordset.PercentPosition
        Form1.Data1.Recordset.MoveNext

        'D:  Wenn kein weiterer Datensatz mehr folgt, dann wird der Druck beendet
        'US: If there is no more recordset printing will be finished
        If Form1.Data1.Recordset.EOF = True Then pbLastRecord = 1
        
    End If


End Sub

Private Sub ListLabel1_CmndSetPrintOptions(ByVal nUserData As Long, pnPrintMethodOptionFlags As ListLabel.LlCmndSetPrintOptionsConstants)
    'D:  Exportoptionen setzen
    'US: Set export options

    'D:  Exportformat festlegen
    'US: Set export format
    Dim ret%
     ret% = ListLabel1.LlPrintSetOptionString(LL_PRNOPTSTR_EXPORT, ExporterName)

    'D:  Pfad
    'US: Path
     ret% = ListLabel1.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, "Export.Path", ExtractFilePath(FileName))

    'D:  Dateiname
    'US: Filename
     ret% = ListLabel1.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, "Export.File", ExtractFileName(FileName))

    'D:  Modus ohne Interaktion
    'US: Quiet mode
     ret% = ListLabel1.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, "Export.Quiet", "1")

    'D:  Je nach Benutzerauswahl: Anzeige des Ergebnisses
    'US: Depending on user's choice: show result
    If CheckShowFile.Value Then
        ret% = ListLabel1.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, "Export.ShowResult", "1")
    End If
    'D:  Um jetzt noch zusätzlich das Exportergebnis per Mail zu versenden, würden die unten
    '    stehenden Codezeilen benötigt. Damit wird eine Mail an llmailtest@combit.net gesendet.
    '    Als Exportformat ist in diesem Beispiel HTML notwendig, so dass das Ergebnis des HTML-
    '    Exportes direkt als HTML Body der Mail versendet würde. Ausserdem muß über die Export.Mail.SMTP
    '    Optionen ein gültiger SMTP-Server angegeben werden.

    'US: To additionally send the result as eMail, you'd need the following code lines. This
    '    will send an email to llmailtest@combit.net. Set the export format to HTML, as this sample
    '    will send the result as HTML body of the mail. You need to set a valid SMTP server
    '    using the "Export.Mail.SMTP..." options..

    'comment in:    ret% = ListLabel1.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, "Export.SendAsMail", "1")
    'comment in:    ret% = ListLabel1.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, "Export.Mail.To", "combit GmbH <SMTP:llmailtest@combit.net>")
    'comment in:    ret% = ListLabel1.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, "Export.Mail.Subject", "combit List & Label mail test")
    'comment in:    ret% = ListLabel1.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, "Export.Mail.ShowDialog", "1")
    'comment in:    ret% = ListLabel1.LlXSetParameter(LL_LLX_EXTENSIONTYPE_EXPORT, ExporterName, "Export.Mail.SendResultAs", "text/html")
   

End Sub

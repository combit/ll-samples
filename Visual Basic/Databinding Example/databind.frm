VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "List & Label  -  Databinding Sample"
   ClientHeight    =   4020
   ClientLeft      =   3195
   ClientTop       =   6645
   ClientWidth     =   7530
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4020
   ScaleWidth      =   7530
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin Project1.ListLabelVB ListLabelVB4 
      Left            =   6960
      Top             =   2640
      _ExtentX        =   873
      _ExtentY        =   873
      AutoDesignerFile=   "label.lbl"
      AutoDestination =   2048
      AutoProjectType =   1
      AutoShowSelectFile=   0   'False
      AutoDatasource  =   "Data1"
      Dialog3DText    =   0
      DialogButtons   =   0
      DialogMode      =   14
      Language        =   -1
      OfnDialogExplorer=   -1  'True
      SupportPageBreak=   -1  'True
   End
   Begin Project1.ListLabelVB ListLabelVB3 
      Left            =   3240
      Top             =   2640
      _ExtentX        =   873
      _ExtentY        =   873
      AutoDesignerFile=   "inv_merg.lst"
      AutoDestination =   2048
      AutoMasterMode  =   2
      AutoShowSelectFile=   0   'False
      AutoDatasource  =   "Data2"
      AutoMasterSource=   "Data1"
      Dialog3DText    =   0
      DialogButtons   =   0
      DialogMode      =   14
      Language        =   -1
      OfnDialogExplorer=   -1  'True
      SupportPageBreak=   -1  'True
   End
   Begin Project1.ListLabelVB ListLabelVB2 
      Left            =   6960
      Top             =   1440
      _ExtentX        =   873
      _ExtentY        =   873
      AutoDesignerFile=   "inv_lst2.lst"
      AutoDestination =   2048
      AutoMasterMode  =   1
      AutoShowSelectFile=   0   'False
      AutoDatasource  =   "Data2"
      AutoMasterSource=   "Data1"
      Dialog3DText    =   0
      DialogButtons   =   0
      DialogMode      =   14
      Language        =   -1
      MultipleTableLines=   -1  'True
      OfnDialogExplorer=   -1  'True
      SupportPageBreak=   -1  'True
   End
   Begin Project1.ListLabelVB ListLabelVB1 
      Left            =   3240
      Top             =   1440
      _ExtentX        =   873
      _ExtentY        =   873
      AutoDesignerFile=   "inv_lst.lst"
      AutoDestination =   2048
      AutoShowSelectFile=   0   'False
      AutoDatasource  =   "Data1"
      Dialog3DText    =   0
      DialogButtons   =   0
      DialogMode      =   14
      Language        =   -1
      OfnDialogExplorer=   -1  'True
      SupportPageBreak=   -1  'True
   End
   Begin VB.Frame Frame4 
      Caption         =   "Package labels"
      Height          =   975
      Left            =   3840
      TabIndex        =   13
      Top             =   2760
      Width           =   3495
      Begin VB.CommandButton Command8 
         Caption         =   "Print..."
         Height          =   375
         Left            =   1800
         TabIndex        =   15
         Top             =   360
         Width           =   1335
      End
      Begin VB.CommandButton Command7 
         Caption         =   "Design..."
         Height          =   375
         Left            =   240
         TabIndex        =   14
         Top             =   360
         Width           =   1335
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "Invoice merge"
      Height          =   975
      Left            =   120
      TabIndex        =   10
      Top             =   2760
      Width           =   3495
      Begin VB.CommandButton Command6 
         Caption         =   "Design..."
         Height          =   375
         Left            =   240
         TabIndex        =   12
         Top             =   360
         Width           =   1335
      End
      Begin VB.CommandButton Command5 
         Caption         =   "Print..."
         Height          =   375
         Left            =   1800
         TabIndex        =   11
         Top             =   360
         Width           =   1335
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "Invoice and items list"
      Height          =   975
      Left            =   3840
      TabIndex        =   7
      Top             =   1560
      Width           =   3495
      Begin VB.CommandButton Command4 
         Caption         =   "Design..."
         Height          =   375
         Left            =   240
         TabIndex        =   9
         Top             =   360
         Width           =   1335
      End
      Begin VB.CommandButton Command3 
         Caption         =   "Print..."
         Height          =   375
         Left            =   1800
         TabIndex        =   8
         Top             =   360
         Width           =   1335
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Invoice list"
      Height          =   975
      Left            =   120
      TabIndex        =   4
      Top             =   1560
      Width           =   3495
      Begin VB.CommandButton Command2 
         Caption         =   "Print..."
         Height          =   375
         Left            =   1800
         TabIndex        =   6
         Top             =   360
         Width           =   1335
      End
      Begin VB.CommandButton Command1 
         Caption         =   "Design..."
         Height          =   375
         Left            =   240
         TabIndex        =   5
         Top             =   360
         Width           =   1335
      End
   End
   Begin VB.Data Data2 
      BOFAction       =   1  'BOF
      Caption         =   "Data2"
      Connect         =   "Access 2000;"
      DatabaseName    =   "..\simple.mdb"
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      EOFAction       =   1  'EOF
      Exclusive       =   -1  'True
      Height          =   345
      Left            =   5520
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   1  'Dynaset
      RecordSource    =   "items"
      Top             =   960
      Visible         =   0   'False
      Width           =   1575
   End
   Begin VB.Data Data1 
      BOFAction       =   1  'BOF
      Caption         =   "Data1"
      Connect         =   "Access 2000;"
      DatabaseName    =   "..\simple.mdb"
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      EOFAction       =   1  'EOF
      Exclusive       =   -1  'True
      Height          =   345
      Left            =   5520
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   1  'Dynaset
      RecordSource    =   "invoice"
      Top             =   480
      Visible         =   0   'False
      Width           =   1575
   End
   Begin VB.Label Label4 
      Caption         =   "This example demonstrates how to use the List && Label data binding user control"
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
      Width           =   4245
   End
   Begin VB.Label Label3 
      Caption         =   "Dieses Beispiel demonstriert die Verwendung des List && Label DataBinding UserControls"
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
      Width           =   4245
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
Private Sub Command1_Click()
    ListLabelVB1.AutoDesign "Designer"
End Sub

Private Sub Command2_Click()
    ListLabelVB1.AutoPrint "Print", ""
End Sub

Private Sub Command3_Click()
    ListLabelVB2.AutoPrint "Print", ""
End Sub

Private Sub Command4_Click()
    ListLabelVB2.AutoDesign "Designer"
End Sub

Private Sub Command5_Click()
    ListLabelVB3.AutoPrint "Print", ""
End Sub

Private Sub Command6_Click()
    ListLabelVB3.AutoDesign "Designer"
End Sub

Private Sub Command7_Click()
    ListLabelVB4.AutoDesign "Designer"
End Sub

Private Sub Command8_Click()
    ListLabelVB4.AutoPrint "Print", ""
End Sub

Private Sub Form_Load()
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
    Data1.DatabaseName = Path$ & "simple.mdb"
    Data2.DatabaseName = Path$ & "simple.mdb"
End Sub

Private Sub ListLabelVB2_AutoUpdateDataSource(ByVal DesignMode As Boolean, RecordsetObj As DAO.Recordset)
    Data2.RecordSource = "SELECT * FROM Items WHERE BillNo='" & Data1.Recordset("BILLNO") & "';"
    Data2.Refresh
    Set RecordsetObj = Data2.Recordset
End Sub

Private Sub ListLabelVB3_AutoUpdateDataSource(ByVal DesignMode As Boolean, RecordsetObj As DAO.Recordset)
    Data2.RecordSource = "SELECT * FROM Items WHERE BillNo='" & Data1.Recordset("BILLNO") & "';"
    Data2.Refresh
    Set RecordsetObj = Data2.Recordset
End Sub


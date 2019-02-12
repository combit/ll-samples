VERSION 5.00
Begin VB.Form ParaDlg 
   Appearance      =   0  'Flat
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Properties"
   ClientHeight    =   2280
   ClientLeft      =   3975
   ClientTop       =   4065
   ClientWidth     =   2565
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
   Icon            =   "PARADLG.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   2280
   ScaleWidth      =   2565
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton BtnOk 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Caption         =   "Ok"
      Default         =   -1  'True
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
      Left            =   120
      TabIndex        =   2
      Top             =   1800
      Width           =   1095
   End
   Begin VB.CommandButton BtnCancel 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Cancel          =   -1  'True
      Caption         =   "Cancel"
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
      Left            =   1320
      TabIndex        =   1
      Top             =   1800
      Width           =   1095
   End
   Begin VB.Frame Frame1 
      Caption         =   "Fill Color"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1455
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   2295
      Begin VB.OptionButton Option1 
         Caption         =   "Red Fill"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   240
         TabIndex        =   5
         Top             =   360
         Width           =   1500
      End
      Begin VB.OptionButton Option2 
         Caption         =   "Green Fill"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   240
         TabIndex        =   4
         TabStop         =   0   'False
         Top             =   720
         Width           =   1500
      End
      Begin VB.OptionButton Option3 
         Caption         =   "Blue Fill"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   240
         TabIndex        =   3
         TabStop         =   0   'False
         Top             =   1080
         Width           =   1500
      End
   End
End
Attribute VB_Name = "ParaDlg"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

'======================================================
Private Sub BtnCancel_Click()
'======================================================
    
    'D:   Auswahl abbrechen
    'US: Cancel selection
    ObjParameters = ""
    Unload ParaDlg

End Sub

'======================================================
Private Sub BtnOk_Click()
'======================================================
    
    'D:   "OK"
    'US: "OK"
    Unload ParaDlg
    
End Sub

'======================================================
Private Sub Form_Load()
'======================================================

    'D:   Welche Farbe war selektiert
    'US: Which color was selected
    If ObjParameters = "R" Or ObjParameters = "" Then
        Option1.Value = 1
    ElseIf ObjParameters = "G" Then
        Option2.Value = 1
    ElseIf ObjParameters = "B" Then
        Option3.Value = 1
    End If
    
End Sub

'======================================================
Private Sub Option1_Click()
'======================================================
    
    'D:   Farbe ausgewählt
    'US: Color selected
    ObjParameters = "R"
    
End Sub

'======================================================
Private Sub Option2_Click()
'======================================================
    
    'D:   Farbe ausgewählt
    'US: Color selected
    ObjParameters = "G"

End Sub

'======================================================
Private Sub Option3_Click()
'======================================================
    
    'D:   Farbe ausgewhählt
    'US: Color selected
    ObjParameters = "B"

End Sub


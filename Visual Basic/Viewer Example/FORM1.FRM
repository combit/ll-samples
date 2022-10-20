VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{28EBE202-E7C7-11D0-B183-0040E994B593}#1.0#0"; "cmll28v.ocx"
Begin VB.Form Form1 
   Caption         =   "List & Label Viewer Sample Application"
   ClientHeight    =   7155
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   7605
   Icon            =   "FORM1.frx":0000
   LinkTopic       =   "Form1"
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   7155
   ScaleWidth      =   7605
   Begin CMLL28VLibCtl.LlViewCtrl LlView 
      Height          =   2895
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3495
      _cx             =   6165
      _cy             =   5106
      _cx             =   6165
      _cy             =   5106
      ToolbarEnabled  =   -1  'True
      SaveAsFilePath  =   ""
      FileURL         =   ""
      BackColor       =   14215660
      Enabled         =   -1  'True
      AsyncDownload   =   -1  'True
      ShowExitButton  =   -1  'True
      ShowThumbnails  =   -1  'True
      Language        =   -1
      SlideshowMode   =   0   'False
      ShowUnprintableArea=   0   'False
   End
   Begin MSComDlg.CommonDialog OpenDialog 
      Left            =   0
      Top             =   3000
      _ExtentX        =   688
      _ExtentY        =   688
      _Version        =   393216
      CancelError     =   -1  'True
      DefaultExt      =   "LL"
      DialogTitle     =   "Open Preview File"
      Filter          =   "List & Label Files (*.LL)|*.LL"
   End
   Begin VB.Menu IDM_FILE 
      Caption         =   "&File"
      Begin VB.Menu IDM_OPEN 
         Caption         =   "&Open..."
      End
      Begin VB.Menu mnu_save 
         Caption         =   "Save &as..."
      End
      Begin VB.Menu mnu_sep1 
         Caption         =   "-"
      End
      Begin VB.Menu IDM_EXIT 
         Caption         =   "&Exit"
      End
   End
   Begin VB.Menu mnu_view 
      Caption         =   "&View"
      Begin VB.Menu mnu_move 
         Caption         =   "&First Page"
         Index           =   1
      End
      Begin VB.Menu mnu_move 
         Caption         =   "&Previous Page"
         Index           =   2
      End
      Begin VB.Menu mnu_move 
         Caption         =   "&Next Page"
         Index           =   3
      End
      Begin VB.Menu mnu_move 
         Caption         =   "&Last Page"
         Index           =   4
      End
      Begin VB.Menu mnu_move 
         Caption         =   "-"
         Index           =   5
      End
      Begin VB.Menu mnu_zoom 
         Caption         =   "Zoom &in"
         Index           =   1
      End
      Begin VB.Menu mnu_zoom 
         Caption         =   "Zoom &out"
         Index           =   2
      End
      Begin VB.Menu mnu_zoom 
         Caption         =   "Fit to P&age"
         Index           =   3
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


'======================================================================================
Private Sub Form_Resize()
'======================================================================================
    
    'D:   Größe des Viewers an das Fenster anpassen
    'US: Fit viewer to window
    LlView.Height = ScaleHeight
    LlView.Width = ScaleWidth

End Sub

'======================================================================================
Private Sub Form_Load()
'======================================================================================
'
' Copyright (C) combit GmbH
'
'--------------------------------------------------------------------------------------
' File   : viewer.vbp, form1.frm, cmll28.bas
' Module : viewer sample
' Descr. : D:   Dieses Beispiel demonstriert die Verwendung des Viewer-OCX
'          US: This example demonstrates how to use the viewer-ocx
'======================================================================================

'D:   Zentriert die Form auf dem Desktop
'US: Center form to desktop
Left = (Screen.Width - Width) / 2: Top = (Screen.Height - Height) / 2

'D:   In das Applikations-Verzeichnis wechseln
'US: Change to app-path
ChDir App.Path
ChDrive Left$(App.Path, 1)

'D:   Exit-Button verstecken
'US: Hide Exit-Button
Dim oToolbar As ToolbarButtons
Set oToolbar = LlView.ToolbarButtons
oToolbar.SetButtonState TLB_PRV_FILEEXIT, TLBS_PRV_HIDE
Set oToolbar = Nothing

'D:   Form anzeigen
'US: Show form
Show

'D:   Datei-Öffnen Dialog anzeigen
'US: Show File-Open dialog
OpenDialog.InitDir = "..\"
OpenDialog.FileName = "invoice.ll"
IDM_OPEN_Click

End Sub

'======================================================================================
Private Sub Form_Unload(Cancel As Integer)
'======================================================================================
    If Not LlView.CanClose Then
        Cancel = True
    End If
End Sub

'======================================================================================
Private Sub IDM_EXIT_Click()
'======================================================================================

    'D:   Programm beenden
    'US: End program
    Unload Form1
    
End Sub

'======================================================================================
Private Sub IDM_OPEN_Click()
'======================================================================================
    
    'D:   Datei-Öffnen Dialog
    'US: File-Open dialog
    OpenDialog.Flags = &H1000
    On Error GoTo cancel_error
    OpenDialog.ShowOpen
    
    'D:   LL-Datei in Viewer laden
    'US: Load LL-file to viewer
    LlView.FileURL = OpenDialog.FileName

    'D:   Abbruch durch Benutzer / Fehler
    'US. User-cancel / error
cancel_error:
    Exit Sub

End Sub


'======================================================================================
Private Sub mnu_move_Click(Index As Integer)
'======================================================================================
    
    'D:   Eintrag im Move-Menü ausgewählt
    'US: Item from move-menu selected
    Select Case Index
        
        'D:   Gehe zur ersten Seite
        'US: Move to first page
        Case 1: LlView.GotoFirst
        
        'D:   Gehe zur vorherigen Seite
        'US: Move to previous page
        Case 2: LlView.GotoPrev
        
        'D:   Gehe zur nächsten Seite
        'US: Move to next page
        Case 3: LlView.GotoNext
        
        'D:   Gehe zur letzten Seite
        'US: Move to last page
        Case 4: LlView.GotoLast
    
    End Select
    
End Sub


'======================================================================================
Private Sub mnu_save_Click()
'======================================================================================
    
    'D:   LL-Datei unter neuem Namen speichern ("Speichern als...")
    'US: Save LL-file with new name ("Save as...")
    LlView.SaveAs
    
End Sub

'======================================================================================
Private Sub mnu_zoom_Click(Index As Integer)
'======================================================================================
    
    'D:   Eintrag im Zoom-Menü ausgewählt
    'US: Item from zoom-menu selected
    Select Case Index
    
        'D:   Zoom um den Faktor 2
        'US: Zoom with factor 2
        Case 1: LlView.ZoomTimes2
        
        'D:   Vorherige Zoom-Stufe
        'US: Last zoom
        Case 2: LlView.ZoomRevert
        
        'D:   Zoom zurücksetzen
        'US: Reset zoom
        Case 3: LlView.ZoomReset
        
    End Select

End Sub



Attribute VB_Name = "DevModeModule"
Declare Function CreateDC Lib "gdi32" Alias "CreateDCA" (ByVal lpDriverName As String, ByVal lpDeviceName As String, ByVal lpOutput As String, lpInitData As DEVMODEA) As Long
Declare Function GetDeviceCaps Lib "gdi32" (ByVal hDC As Long, ByVal nIndex As Long) As Long
Declare Function DeleteDC Lib "gdi32" (ByVal hDC As Long) As Long
Public Const HORZSIZE = 4           '  Horizontal size in millimeters
Public Const VERTSIZE = 6           '  Vertical size in millimeters

'D:   Standard-DevMode für Drucker auslesen
'US: Read standard-DevMode
Private Declare Function DocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesA" (ByVal hwnd As Long, ByVal hPrinter As Long, ByVal pDeviceName As String, pDevModeOutput As Any, pDevModeInput As Any, ByVal fMode As Long) As Long
Private Const DM_MODIFY = 8
Private Const DM_IN_BUFFER = DM_MODIFY
Private Const DM_COPY = 2
Private Const DM_OUT_BUFFER = DM_COPY

'D:   Drucker öffnen
'US: Open Printer
Private Declare Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterA" (ByVal pPrinterName As String, phPrinter As Long, ByVal pDefault As Long) As Long

'D:   Drucker schließen
'US: Close Printer
Private Declare Function ClosePrinter Lib "winspool.drv" (ByVal hPrinter As Long) As Long

'D:   Speicher kopieren
'US: Copy Memory
Private Declare Sub CopyMemory Lib "KERNEL32" Alias "RtlMoveMemory" (hpvDest As Any, hpvSource As Any, ByVal cbCopy As Long)

'D:   DevMode-Deklarationen
'US: DevMode-Declarations

    Private Const DM_SPECVERSION = &H320
    
    'Fields
    Public Const DM_ORIENTATION = &H1&
    Public Const DM_PAPERSIZE = &H2&
    Public Const DM_PAPERLENGTH = &H4&
    Public Const DM_PAPERWIDTH = &H8&
    Public Const DM_SCALE = &H10&
    Public Const DM_COPIES = &H100&
    Public Const DM_DEFAULTSOURCE = &H200&
    Public Const DM_PRINTQUALITY = &H400&
    Public Const DM_COLOR = &H800&
    Public Const DM_DUPLEX = &H1000&
    Public Const DM_YRESOLUTION = &H2000&
    Public Const DM_TTOPTION = &H4000&
    Public Const DM_COLLATE As Long = &H8000
    Public Const DM_FORMNAME As Long = &H10000
    
    'orientation selections
    Private Const DMORIENT_PORTRAIT = 1
    Private Const DMORIENT_LANDSCAPE = 2
    
    'paper selections
    Private Const DMPAPER_LETTER = 1
    Private Const DMPAPER_FIRST = DMPAPER_LETTER     '  Letter 8 1/2 x 11 in
    Private Const DMPAPER_LETTERSMALL = 2            '  Letter Small 8 1/2 x 11 in
    Private Const DMPAPER_TABLOID = 3                '  Tabloid 11 x 17 in
    Private Const DMPAPER_LEDGER = 4                 '  Ledger 17 x 11 in
    Private Const DMPAPER_LEGAL = 5                  '  Legal 8 1/2 x 14 in
    Private Const DMPAPER_STATEMENT = 6              '  Statement 5 1/2 x 8 1/2 in
    Private Const DMPAPER_EXECUTIVE = 7              '  Executive 7 1/4 x 10 1/2 in
    Private Const DMPAPER_A3 = 8                     '  A3 297 x 420 mm
    Private Const DMPAPER_A4 = 9                     '  A4 210 x 297 mm
    Private Const DMPAPER_A4SMALL = 10               '  A4 Small 210 x 297 mm
    Private Const DMPAPER_A5 = 11                    '  A5 148 x 210 mm
    Private Const DMPAPER_B4 = 12                    '  B4 250 x 354
    Private Const DMPAPER_B5 = 13                    '  B5 182 x 257 mm
    Private Const DMPAPER_FOLIO = 14                 '  Folio 8 1/2 x 13 in
    Private Const DMPAPER_QUARTO = 15                '  Quarto 215 x 275 mm
    Private Const DMPAPER_10X14 = 16                 '  10x14 in
    Private Const DMPAPER_11X17 = 17                 '  11x17 in
    Private Const DMPAPER_NOTE = 18                  '  Note 8 1/2 x 11 in
    Private Const DMPAPER_ENV_9 = 19                 '  Envelope #9 3 7/8 x 8 7/8
    Private Const DMPAPER_ENV_10 = 20                '  Envelope #10 4 1/8 x 9 1/2
    Private Const DMPAPER_ENV_11 = 21                '  Envelope #11 4 1/2 x 10 3/8
    Private Const DMPAPER_ENV_12 = 22                '  Envelope #12 4 \276 x 11
    Private Const DMPAPER_ENV_14 = 23                '  Envelope #14 5 x 11 1/2
    Private Const DMPAPER_CSHEET = 24                '  C size sheet
    Private Const DMPAPER_DSHEET = 25                '  D size sheet
    Private Const DMPAPER_ESHEET = 26                '  E size sheet
    Private Const DMPAPER_ENV_DL = 27                '  Envelope DL 110 x 220mm
    Private Const DMPAPER_ENV_C5 = 28                '  Envelope C5 162 x 229 mm
    Private Const DMPAPER_ENV_C3 = 29                '  Envelope C3  324 x 458 mm
    Private Const DMPAPER_ENV_C4 = 30                '  Envelope C4  229 x 324 mm
    Private Const DMPAPER_ENV_C6 = 31                '  Envelope C6  114 x 162 mm
    Private Const DMPAPER_ENV_C65 = 32               '  Envelope C65 114 x 229 mm
    Private Const DMPAPER_ENV_B4 = 33                '  Envelope B4  250 x 353 mm
    Private Const DMPAPER_ENV_B5 = 34                '  Envelope B5  176 x 250 mm
    Private Const DMPAPER_ENV_B6 = 35                '  Envelope B6  176 x 125 mm
    Private Const DMPAPER_ENV_ITALY = 36             '  Envelope 110 x 230 mm
    Private Const DMPAPER_ENV_MONARCH = 37           '  Envelope Monarch 3.875 x 7.5 in
    Private Const DMPAPER_ENV_PERSONAL = 38          '  6 3/4 Envelope 3 5/8 x 6 1/2 in
    Private Const DMPAPER_FANFOLD_US = 39            '  US Std Fanfold 14 7/8 x 11 in
    Private Const DMPAPER_FANFOLD_STD_GERMAN = 40    '  German Std Fanfold 8 1/2 x 12 in
    Private Const DMPAPER_FANFOLD_LGL_GERMAN = 41    '  German Legal Fanfold 8 1/2 x 13 in
    
    Private Const DMPAPER_LAST = DMPAPER_FANFOLD_LGL_GERMAN
    
    Private Const DMPAPER_USER = 256
    
    'bin selections
    Private Const DMBIN_UPPER = 1
    Private Const DMBIN_FIRST = DMBIN_UPPER
    
    Private Const DMBIN_ONLYONE = 1
    Private Const DMBIN_LOWER = 2
    Private Const DMBIN_MIDDLE = 3
    Private Const DMBIN_MANUAL = 4
    Private Const DMBIN_ENVELOPE = 5
    Private Const DMBIN_ENVMANUAL = 6
    Private Const DMBIN_AUTO = 7
    Private Const DMBIN_TRACTOR = 8
    Private Const DMBIN_SMALLFMT = 9
    Private Const DMBIN_LARGEFMT = 10
    Private Const DMBIN_LARGECAPACITY = 11
    Private Const DMBIN_CASSETTE = 14
    Private Const DMBIN_LAST = DMBIN_CASSETTE
    
    Private Const DMBIN_USER = 256    'device specific bins start here
    
    'print qualities
    Private Const DMRES_DRAFT = (-1)
    Private Const DMRES_LOW = (-2)
    Private Const DMRES_MEDIUM = (-3)
    Private Const DMRES_HIGH = (-4)
    
    'color enable/disable for color printers
    Private Const DMCOLOR_MONOCHROME = 1
    Private Const DMCOLOR_COLOR = 2
    
    'duplex enable
    Private Const DMDUP_SIMPLEX = 1
    Private Const DMDUP_VERTICAL = 2
    Private Const DMDUP_HORIZONTAL = 3
    
    'TrueType options
    Private Const DMTT_BITMAP = 1    'print TT fonts as graphics
    Private Const DMTT_DOWNLOAD = 2  'download TT fonts as soft fonts
    Private Const DMTT_SUBDEV = 3    'substitute device fonts for TT fonts
    
    'Collation selections
    Private Const DMCOLLATE_FALSE = 0
    Private Const DMCOLLATE_TRUE = 1
    
    'dmDisplayFlags flags
    Private Const DM_GRAYSCALE = &H1
    Private Const DM_INTERLACED = &H2

'======================================================
Public Sub ReadDevMode(PrinterName As String, ByRef xdev As DEVMODEA)
'======================================================

    Dim nSize As Long          ' Size of DEVMODE
    Dim PrinterHandle As Long  ' handle to printer
    Dim aDevMode() As Byte     ' temporary DEVMODE
    
    'D:   Drucker-Handle ermitteln
    'US: Get Printer-Handle
    If OpenPrinter(PrinterName, PrinterHandle, 0&) Then
        
        'D:   Größe der DevMode-Struktur ermitteln
        'US: Get size of DevMode-structure
        nSize = DocumentProperties(Form1.hwnd, PrinterHandle, PrinterName, 0&, 0&, 0)
        
        'D:   Speicher reservieren
        'US: Reserve memory
        ReDim aDevMode(1 To nSize)
    
        'D:   DevMode-Struktur in temporäre Variable schreiben
        'US: Write DevMode-structure to temporary variable
        nSize = DocumentProperties(Form1.hwnd, PrinterHandle, PrinterName, aDevMode(1), 0&, DM_OUT_BUFFER)
        
        'D:   Temporäre Variable in DevMode-Struktur kopieren
        'US: Copy temporary variable to DevMode-structure
        Call CopyMemory(xdev, aDevMode(1), Len(xdev))
        xdev.dmDriverExtra = 0
        'D:   Drucker schließen
        'US: Close Printer
        ClosePrinter (PrinterHandle)
     
     End If

End Sub

'======================================================
Public Sub ChangeDevMode(ByRef xdev As DEVMODEA)
'======================================================

    'D:   Gegebene DevMode-Struktur ändern
    'US: Change given DevMode-structure
    With Form1
        xdev.dmPaperSize = IIf(.Combo2.ListIndex = 41, 256, .Combo2.ListIndex + 1)
        xdev.dmPaperWidth = Val(.Text1.Text) * 10
        xdev.dmPaperLength = Val(.Text2.Text) * 10
        xdev.dmPrintQuality = Val(.Combo3.Text)
        xdev.dmCopies = 2
        xdev.dmFields = xdev.dmFields Or DM_PAPERSIZE Or DM_PRINTQUALITY Or DM_PAPERLENGTH Or DM_PAPERWIDTH Or DM_COPIES
    End With

    Dim myhDC&
    myhDC = CreateDC("", xdev.dmDeviceName, "", xdev)
    Debug.Print myhDC&
    Debug.Print GetDeviceCaps(myhDC&, HORZSIZE)
    Debug.Print GetDeviceCaps(myhDC&, VERTSIZE)
    Debug.Print DeleteDC(myhDC&)

End Sub



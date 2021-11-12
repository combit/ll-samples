VERSION 5.00
Object = "{2213E283-16BC-101D-AFD4-040224009C11}#27.0#0"; "cmll27o.ocx"
Begin VB.UserControl ListLabelVB 
   CanGetFocus     =   0   'False
   ClientHeight    =   1680
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4215
   ClipBehavior    =   0  'None
   ClipControls    =   0   'False
   DataBindingBehavior=   2  'vbComplexBound
   FillStyle       =   0  'Solid
   HitBehavior     =   0  'None
   InvisibleAtRuntime=   -1  'True
   ScaleHeight     =   1680
   ScaleWidth      =   4215
   Begin ListLabel.ListLabel ListLabel1 
      Left            =   120
      Top             =   1080
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
      AddVarsToFields =   -1  'True
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
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "D: Hilfe siehe cmll27o.hlp"
      Height          =   195
      Left            =   960
      TabIndex        =   3
      Top             =   960
      Visible         =   0   'False
      Width           =   1800
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "US: For help see cmll27o.hlp"
      Height          =   195
      Left            =   960
      TabIndex        =   2
      Top             =   1200
      Visible         =   0   'False
      Width           =   2040
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "US: For data binding needed standard List && Label OCX:"
      Height          =   195
      Left            =   120
      TabIndex        =   1
      Top             =   600
      Visible         =   0   'False
      Width           =   3975
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "D: Für Anbindung benötigtes List && Label Standard OCX:"
      Height          =   195
      Left            =   120
      TabIndex        =   0
      Top             =   360
      Visible         =   0   'False
      Width           =   3990
   End
   Begin VB.Image Image1 
      Height          =   225
      Left            =   0
      Stretch         =   -1  'True
      Top             =   0
      Width           =   240
   End
End
Attribute VB_Name = "ListLabelVB"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
'=========================================================================
' Product:      List & Label 27
' Component:    Visual Basic Data Binding Control for List & Label
' Description:  Enhances List & Label with data binding possibilities
' Author:       combit GmbH
' Copyright:    Copyright (C) combit GmbH
' Licence:      Read licence agreement carefully before using this control
'=========================================================================


'=========================================================================
' Declaration
'=========================================================================

Option Explicit

'-------------------------------------------------------------------------
' Default Property Values
'-------------------------------------------------------------------------
Const m_def_AutoDefine = True
Const m_def_AutoDesignerFile = ""
Const m_def_AutoDestination = LL_PRINT_PREVIEW
Const m_def_AutoMasterMode = 0
Const m_def_AutoMasterPrefix = "Master"
Const m_def_AutoDetailPrefix = "Detail"
Const m_def_AutoProjectType = LL_PROJECT_LIST
Const m_def_AutoShowPrintOptions = True
Const m_def_AutoShowSelectFile = True

'-------------------------------------------------------------------------
' Property Variables
'-------------------------------------------------------------------------
Dim m_AutoDefine As Boolean
Dim m_AutoDesignerFile As String
Dim m_AutoDestination As LlPrintModeConstants
Dim m_AutoMasterMode As enumAutoMasterMode
Dim m_AutoMasterPrefix As String
Dim m_AutoDetailPrefix As String
Dim m_AutoProjectType As LlProjectConstants
Dim m_AutoShowPrintOptions As Boolean
Dim m_AutoShowSelectFile As Boolean
Dim m_AutoDatasource As String
Dim m_AutoDatasourceRecordset As Recordset
Dim m_AutoMasterSource As String
Dim m_AutoMasterSourceRecordset As Recordset

'-------------------------------------------------------------------------
' Events
'-------------------------------------------------------------------------
Event AutoDefineNewPage(ByVal DesignMode As Boolean)
Event AutoDefineNewLine(ByVal DesignMode As Boolean)
Event AutoDefineField(ByVal DesignMode As Boolean, FieldName As String, FieldContent As Variant, FieldType As LlFieldTypeConstants, ByRef handled As Boolean)
Event AutoDefineVariable(ByVal DesignMode As Boolean, ByRef VariableName As String, ByRef VariableContent As Variant, ByRef VariableType As LlFieldTypeConstants, ByRef handled As Boolean)
Event AutoUpdateDataSource(ByVal DesignMode As Boolean, RecordsetObj As Recordset)
Event CmndDefineFields(ByVal nUserData As Long, ByVal bDummy As Long, pnProgressInPerc As Long, pbLastRecord As Long)
Event CmndDefineVariables(ByVal nUserData As Long, ByVal bDummy As Long, pnProgressInPerc As Long, pbLastRecord As Long)
Event CmndDlgexprVarbtn(ByVal nFunction As LlDlgExprVarbtnConstants, ByVal hWndDlg As Long, ByVal sPage As String, psValue As String, ByVal bFields As Long, ByVal nMask As Long)
Event CmndDrawUserobj(ByVal sName As String, ByVal sContents As String, ByVal lPara As Long, ByVal lpPtr As Long, ByVal hPara As Long, ByVal bIsotropic As Long, ByVal sParameters As String, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal left As Long, ByVal top As Long, ByVal right As Long, ByVal bottom As Long, ByVal nPaintMode As Long)
Event CmndEditUserobj(ByVal sName As String, ByVal lPara As Long, ByVal lpPtr As Long, ByVal hPara As Long, ByVal bIsotropic As Long, ByVal hWnd As Long, psParameters As String)
Event CmndEnableMenu(ByVal hMenu As Long)
Event CmndExtFct(ByVal sContents As String, ByVal bEvaluate As Long, psNewVal As String, pbError As Long, psError As String)
Event CmndGetViewerButtonState(ByVal nID As Long, pnState As Long)
Event CmndGroupBegin(Ptr As Long)
Event CmndGroupEnd(Ptr As Long)
Event CmndGroupLine(Ptr As Long)
Event CmndHelp(nType As Integer, nContextID As Integer)
Event CmndHostprinter(ByVal bFirst As LlPrinterCmndConstants, ByVal nCmd As Long, ByVal hWnd As Long, phDC As Long, pnOrientation As Integer, psName As String, ByVal nUniqueNumber As Long, ByVal nUniqueNumberCompare As Long)
Event CmndModifyMenu(ByVal hMenu As Long)
Event CmndNtfyProgress(ByVal hWnd As Long, ByVal nTotal As Long, ByVal nCurrent As Long, ByVal nJob As LlMeterJobConstants)
Event CmndObject(ByVal sName As String, ByVal nType As LlObjTypeConstants, ByVal bPreDraw As Long, ByVal hRefDC As Long, ByVal hPaintDC As Long, left As Long, top As Long, right As Long, bottom As Long)
Event CmndPage(ByVal bDesignerPreview As Long, ByVal bPreDraw As Long, ByVal hRefDC As Long, ByVal hPaintDC As Long)
Event CmndProject(ByVal bDesignerPreview As Long, ByVal bPreDraw As Long, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal left As Long, ByVal top As Long, ByVal right As Long, ByVal bottom As Long)
Event CmndSelectMenu(ByVal nMenuID As Long, pbProcessed As Long)
Event CmndTableField(ByVal nType As LlTableFieldTypeConstants, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal rcPaint_left As Long, ByVal rcPaint_top As Long, ByVal rcPaint_right As Long, ByVal rcPaint_bottom As Long, ByVal nLineDef As Long, ByVal nIndex As Long, ByVal rcSpacing_left As Long, ByVal rcSpacing_top As Long, ByVal rcSpacing_right As Long, ByVal rcSpacing_bottom As Long)
Event CmndTableLine(ByVal nType As LlTableLineTypeConstants, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal rcPaint_left As Long, ByVal rcPaint_top As Long, ByVal rcPaint_right As Long, ByVal rcPaint_bottom As Long, ByVal nPageLine As Long, ByVal nLine As Long, ByVal nLineDef As Long, ByVal bZebra As Long, ByVal rcSpacing_left As Long, ByVal rcSpacing_top As Long, ByVal rcSpacing_right As Long, ByVal rcSpacing_bottom As Long)
Event CmndVarHelptext(ByVal sName As String, psHelptext As String)
Event CmndViewerBtnClicked(ByVal nFunctionID As Long)
Event CmndSetPrintOptions(ByVal nUserData As Long, pnPrintMethodOptionFlags As LlCmndSetPrintOptionsConstants)
Event NtfyFailsFilter()

'-------------------------------------------------------------------------
' Additional Enumerations
'-------------------------------------------------------------------------
Public Enum enumAutoMasterMode
    None
    AsFields
    AsVariables
End Enum

Private Enum enumAutoElementDefineType
    Variable
    Field
End Enum

'-------------------------------------------------------------------------
' Misc Declarations
'-------------------------------------------------------------------------
Dim AutoFirstMasterRecord As Boolean
Dim DebWin2 As Object       'DebWin COM Object Pointer
Dim DummyJob                'Global Job Handle
Const tn_ADO = "Adodc"      'ADO Data Control TypeName
Const tn_Data = "Data"      'DAO Data Control TypeName
Dim m_MasterRecNo As Long
Const n_MasterRecNo = "LL.MasterRecNo"


'=========================================================================
' Implementation
'=========================================================================

'-------------------------------------------------------------------------
' Auto... Properties
'-------------------------------------------------------------------------

Public Property Get AutoDefine() As Boolean
    AutoDefine = m_AutoDefine
End Property

Public Property Let AutoDefine(ByVal New_AutoDefine As Boolean)
    m_AutoDefine = New_AutoDefine
    PropertyChanged "AutoDefine"
End Property

Public Property Get AutoDesignerFile() As String
    AutoDesignerFile = m_AutoDesignerFile
End Property

Public Property Let AutoDesignerFile(ByVal New_AutoDesignerFile As String)
    m_AutoDesignerFile = New_AutoDesignerFile
    PropertyChanged "AutoDesignerFile"
End Property

Public Property Get AutoDestination() As LlPrintModeConstants
    AutoDestination = m_AutoDestination
End Property

Public Property Let AutoDestination(ByVal New_AutoDestination As LlPrintModeConstants)
    m_AutoDestination = New_AutoDestination
    PropertyChanged "AutoDestination"
End Property

Public Property Get AutoMasterMode() As enumAutoMasterMode
    AutoMasterMode = m_AutoMasterMode
End Property

Public Property Let AutoMasterMode(ByVal New_AutoMasterMode As enumAutoMasterMode)
    m_AutoMasterMode = New_AutoMasterMode
    PropertyChanged "AutoMasterMode"
End Property

Public Property Get AutoMasterPrefix() As String
    AutoMasterPrefix = m_AutoMasterPrefix
End Property

Public Property Let AutoMasterPrefix(ByVal New_AutoMasterPrefix As String)
    m_AutoMasterPrefix = New_AutoMasterPrefix
    PropertyChanged "AutoMasterPrefix"
End Property

Public Property Get AutoDetailPrefix() As String
    AutoDetailPrefix = m_AutoDetailPrefix
End Property

Public Property Let AutoDetailPrefix(ByVal New_AutoDetailPrefix As String)
    m_AutoDetailPrefix = New_AutoDetailPrefix
    PropertyChanged "AutoDetailPrefix"
End Property

Public Property Get AutoProjectType() As LlProjectConstants
    AutoProjectType = m_AutoProjectType
End Property

Public Property Let AutoProjectType(ByVal New_AutoProjectType As LlProjectConstants)
    m_AutoProjectType = New_AutoProjectType
    PropertyChanged "AutoProjectType"
End Property

Public Property Get AutoShowPrintOptions() As Boolean
    AutoShowPrintOptions = m_AutoShowPrintOptions
End Property

Public Property Let AutoShowPrintOptions(ByVal New_AutoShowPrintOptions As Boolean)
    m_AutoShowPrintOptions = New_AutoShowPrintOptions
    PropertyChanged "AutoShowPrintOptions"
End Property

Public Property Get AutoShowSelectFile() As Boolean
    AutoShowSelectFile = m_AutoShowSelectFile
End Property

Public Property Let AutoShowSelectFile(ByVal New_AutoShowSelectFile As Boolean)
    m_AutoShowSelectFile = New_AutoShowSelectFile
    PropertyChanged "AutoShowSelectFile"
End Property

Public Property Get AutoDatasource() As String
    AutoDatasource = m_AutoDatasource
End Property

Public Property Let AutoDatasource(ByVal New_AutoDatasource As String)
    m_AutoDatasource = New_AutoDatasource
    PropertyChanged "AutoDatasource"
End Property

Public Property Get AutoDatasourceRecordset() As Recordset
    Set AutoDatasourceRecordset = m_AutoDatasourceRecordset
End Property

Public Property Set AutoDatasourceRecordset(ByVal New_AutoDatasourceRecordset As Recordset)
    Set m_AutoDatasourceRecordset = New_AutoDatasourceRecordset
    PropertyChanged "AutoDatasourceRecordset"
End Property

Public Property Get AutoMasterSource() As String
    AutoMasterSource = m_AutoMasterSource
End Property
'
Public Property Let AutoMasterSource(ByVal New_AutoMasterSource As String)
    m_AutoMasterSource = New_AutoMasterSource
    PropertyChanged "AutoMasterSource"
End Property

Public Property Get AutoMasterSourceRecordset() As Recordset
    Set AutoMasterSourceRecordset = m_AutoMasterSourceRecordset
End Property

Public Property Set AutoMasterSourceRecordset(ByVal New_AutoMasterSourceRecordset As Recordset)
    Set m_AutoMasterSourceRecordset = New_AutoMasterSourceRecordset
    PropertyChanged "AutoMasterSourceRecordset"
End Property

'-------------------------------------------------------------------------
' Mapped Properties
'-------------------------------------------------------------------------

Public Property Get InterCharSpacing() As Boolean
    InterCharSpacing = ListLabel1.InterCharSpacing
End Property

Public Property Let InterCharSpacing(ByVal New_InterCharSpacing As Boolean)
    ListLabel1.InterCharSpacing() = New_InterCharSpacing
    PropertyChanged "InterCharSpacing"
End Property

Public Property Get IncludeFontDescent() As Boolean
    IncludeFontDescent = ListLabel1.IncludeFontDescent
End Property

Public Property Let IncludeFontDescent(ByVal New_IncludeFontDescent As Boolean)
    ListLabel1.IncludeFontDescent() = New_IncludeFontDescent
    PropertyChanged "IncludeFontDescent"
End Property

Public Property Get AddVarsToFields() As Boolean
    AddVarsToFields = ListLabel1.AddVarsToFields
End Property

Public Property Let AddVarsToFields(ByVal New_AddVarsToFields As Boolean)
    ListLabel1.AddVarsToFields() = New_AddVarsToFields
    PropertyChanged "AddVarsToFields"
End Property

Public Property Get AutoMultipage() As Boolean
    AutoMultipage = ListLabel1.AutoMultipage
End Property

Public Property Let AutoMultipage(ByVal New_AutoMultipage As Boolean)
    ListLabel1.AutoMultipage() = New_AutoMultipage
    PropertyChanged "AutoMultipage"
End Property

Public Property Get CompressStorage() As Boolean
    CompressStorage = ListLabel1.CompressStorage
End Property

Public Property Let CompressStorage(ByVal New_CompressStorage As Boolean)
    ListLabel1.CompressStorage() = New_CompressStorage
    PropertyChanged "CompressStorage"
End Property

Public Property Get ConvertCRLF() As Boolean
    ConvertCRLF = ListLabel1.ConvertCRLF
End Property

Public Property Let ConvertCRLF(ByVal New_ConvertCRLF As Boolean)
    ListLabel1.ConvertCRLF() = New_ConvertCRLF
    PropertyChanged "ConvertCRLF"
End Property

Public Property Get CreateInfo() As Boolean
    CreateInfo = ListLabel1.CreateInfo
End Property

Public Property Let CreateInfo(ByVal New_CreateInfo As Boolean)
    ListLabel1.CreateInfo() = New_CreateInfo
    PropertyChanged "CreateInfo"
End Property

Public Property Get DelayTableHeader() As Boolean
    DelayTableHeader = ListLabel1.DelayTableHeader
End Property

Public Property Let DelayTableHeader(ByVal New_DelayTableHeader As Boolean)
    ListLabel1.DelayTableHeader() = New_DelayTableHeader
    PropertyChanged "DelayTableHeader"
End Property

Public Property Get Dialog3DText() As LlDialog3DTextConstants
    Dialog3DText = ListLabel1.Dialog3DText
End Property

Public Property Let Dialog3DText(ByVal New_Dialog3DText As LlDialog3DTextConstants)
    ListLabel1.Dialog3DText() = New_Dialog3DText
    PropertyChanged "Dialog3DText"
End Property

Public Property Get DialogButtons() As LlDialogBitmapButtonConstants
    DialogButtons = ListLabel1.DialogButtons
End Property

Public Property Let DialogButtons(ByVal New_DialogButtons As LlDialogBitmapButtonConstants)
    ListLabel1.DialogButtons() = New_DialogButtons
    PropertyChanged "DialogButtons"
End Property

Public Property Get DialogFrame() As LlDialogFrameConstants
    DialogFrame = ListLabel1.DialogFrame
End Property

Public Property Let DialogFrame(ByVal New_DialogFrame As LlDialogFrameConstants)
    ListLabel1.DialogFrame() = New_DialogFrame
    PropertyChanged "DialogFrame"
End Property

Public Property Get DialogMode() As LlDialogModeConstants
    DialogMode = ListLabel1.DialogMode
End Property

Public Property Let DialogMode(ByVal New_DialogMode As LlDialogModeConstants)
    ListLabel1.DialogMode() = New_DialogMode
    PropertyChanged "DialogMode"
End Property

Public Property Get EMFResolution() As Long
    EMFResolution = ListLabel1.EMFResolution
End Property

Public Property Let EMFResolution(ByVal New_EMFResolution As Long)
    ListLabel1.EMFResolution() = New_EMFResolution
    PropertyChanged "EMFResolution"
End Property

Public Property Get EnableHelpCallback() As Boolean
    EnableHelpCallback = ListLabel1.EnableHelpCallback
End Property

Public Property Let EnableHelpCallback(ByVal New_EnableHelpCallback As Boolean)
    ListLabel1.EnableHelpCallback() = New_EnableHelpCallback
    PropertyChanged "EnableHelpCallback"
End Property

Public Property Get EnableObjectCallback() As Boolean
    EnableObjectCallback = ListLabel1.EnableObjectCallback
End Property

Public Property Let EnableObjectCallback(ByVal New_EnableObjectCallback As Boolean)
    ListLabel1.EnableObjectCallback() = New_EnableObjectCallback
    PropertyChanged "EnableObjectCallback"
End Property

Public Property Get EnablePageCallback() As Boolean
    EnablePageCallback = ListLabel1.EnablePageCallback
End Property

Public Property Let EnablePageCallback(ByVal New_EnablePageCallback As Boolean)
    ListLabel1.EnablePageCallback() = New_EnablePageCallback
    PropertyChanged "EnablePageCallback"
End Property

Public Property Get EnableProjectCallback() As Boolean
    EnableProjectCallback = ListLabel1.EnableProjectCallback
End Property

Public Property Let EnableProjectCallback(ByVal New_EnableProjectCallback As Boolean)
    ListLabel1.EnableProjectCallback() = New_EnableProjectCallback
    PropertyChanged "EnableProjectCallback"
End Property

Public Property Get HelpAvailable() As Boolean
    HelpAvailable = ListLabel1.HelpAvailable
End Property

Public Property Let HelpAvailable(ByVal New_HelpAvailable As Boolean)
    ListLabel1.HelpAvailable() = New_HelpAvailable
    PropertyChanged "HelpAvailable"
End Property

Public Property Get Language() As LlLanguageConstants
    Language = ListLabel1.Language
End Property

Public Property Let Language(ByVal New_Language As LlLanguageConstants)
    ListLabel1.Language() = New_Language
    PropertyChanged "Language"
End Property

Public Property Get MaxRTFVersion() As Integer
    MaxRTFVersion = ListLabel1.MaxRTFVersion
End Property

Public Property Let MaxRTFVersion(ByVal New_MaxRTFVersion As Integer)
    ListLabel1.MaxRTFVersion() = New_MaxRTFVersion
    PropertyChanged "MaxRTFVersion"
End Property

Public Property Get Metric() As LlMetricConstants
    Metric = ListLabel1.Metric
End Property

Public Property Let Metric(ByVal New_Metric As LlMetricConstants)
    ListLabel1.Metric() = New_Metric
    PropertyChanged "Metric"
End Property

Public Property Get MultipleTableLines() As Boolean
    MultipleTableLines = ListLabel1.MultipleTableLines
End Property

Public Property Let MultipleTableLines(ByVal New_MultipleTableLines As Boolean)
    ListLabel1.MultipleTableLines() = New_MultipleTableLines
    PropertyChanged "MultipleTableLines"
End Property

Public Property Get NoNoTableCheck() As Boolean
    NoNoTableCheck = ListLabel1.NoNoTableCheck
End Property

Public Property Let NoNoTableCheck(ByVal New_NoNoTableCheck As Boolean)
    ListLabel1.NoNoTableCheck() = New_NoNoTableCheck
    PropertyChanged "NoNoTableCheck"
End Property

Public Property Get NoParameterCheck() As Boolean
    NoParameterCheck = ListLabel1.NoParameterCheck
End Property

Public Property Let NoParameterCheck(ByVal New_NoParameterCheck As Boolean)
    ListLabel1.NoParameterCheck() = New_NoParameterCheck
    PropertyChanged "NoParameterCheck"
End Property

Public Property Get OfnDialogExplorer() As Boolean
    OfnDialogExplorer = ListLabel1.OfnDialogExplorer
End Property

Public Property Let OfnDialogExplorer(ByVal New_OfnDialogExplorer As Boolean)
    ListLabel1.OfnDialogExplorer() = New_OfnDialogExplorer
    PropertyChanged "OfnDialogExplorer"
End Property

Public Property Get OnlyOneTable() As Boolean
    OnlyOneTable = ListLabel1.OnlyOneTable
End Property

Public Property Let OnlyOneTable(ByVal New_OnlyOneTable As Boolean)
    ListLabel1.OnlyOneTable() = New_OnlyOneTable
    PropertyChanged "OnlyOneTable"
End Property

Public Property Get PreviewRectHeight() As Long
    PreviewRectHeight = ListLabel1.PreviewRectHeight
End Property

Public Property Let PreviewRectHeight(ByVal New_PreviewRectHeight As Long)
    ListLabel1.PreviewRectHeight() = New_PreviewRectHeight
    PropertyChanged "PreviewRectHeight"
End Property

Public Property Get PreviewRectLeft() As Long
    PreviewRectLeft = ListLabel1.PreviewRectLeft
End Property

Public Property Let PreviewRectLeft(ByVal New_PreviewRectLeft As Long)
    ListLabel1.PreviewRectLeft() = New_PreviewRectLeft
    PropertyChanged "PreviewRectLeft"
End Property

Public Property Get PreviewRectTop() As Long
    PreviewRectTop = ListLabel1.PreviewRectTop
End Property

Public Property Let PreviewRectTop(ByVal New_PreviewRectTop As Long)
    ListLabel1.PreviewRectTop() = New_PreviewRectTop
    PropertyChanged "PreviewRectTop"
End Property

Public Property Get PreviewRectWidth() As Long
    PreviewRectWidth = ListLabel1.PreviewRectWidth
End Property

Public Property Let PreviewRectWidth(ByVal New_PreviewRectWidth As Long)
    ListLabel1.PreviewRectWidth() = New_PreviewRectWidth
    PropertyChanged "PreviewRectWidth"
End Property

Public Property Get PreviewZoomPerc() As Long
    PreviewZoomPerc = ListLabel1.PreviewZoomPerc
End Property

Public Property Let PreviewZoomPerc(ByVal New_PreviewZoomPerc As Long)
    ListLabel1.PreviewZoomPerc() = New_PreviewZoomPerc
    PropertyChanged "PreviewZoomPerc"
End Property

Public Property Get RealTime() As Boolean
    RealTime = ListLabel1.RealTime
End Property

Public Property Let RealTime(ByVal New_RealTime As Boolean)
    ListLabel1.RealTime() = New_RealTime
    PropertyChanged "RealTime"
End Property

Public Property Get RetRepresentationCode() As Integer
    RetRepresentationCode = ListLabel1.RetRepresentationCode
End Property

Public Property Let RetRepresentationCode(ByVal New_RetRepresentationCode As Integer)
    ListLabel1.RetRepresentationCode() = New_RetRepresentationCode
    PropertyChanged "RetRepresentationCode"
End Property

Public Property Get ShowPredefVars() As Boolean
    ShowPredefVars = ListLabel1.ShowPredefVars
End Property

Public Property Let ShowPredefVars(ByVal New_ShowPredefVars As Boolean)
    ListLabel1.ShowPredefVars() = New_ShowPredefVars
    PropertyChanged "ShowPredefVars"
End Property

Public Property Get SortVariables() As Boolean
    SortVariables = ListLabel1.SortVariables
End Property

Public Property Let SortVariables(ByVal New_SortVariables As Boolean)
    ListLabel1.SortVariables() = New_SortVariables
    PropertyChanged "SortVariables"
End Property

Public Property Get SpaceOptimization() As Boolean
    SpaceOptimization = ListLabel1.SpaceOptimization
End Property

Public Property Let SpaceOptimization(ByVal New_SpaceOptimization As Boolean)
    ListLabel1.SpaceOptimization() = New_SpaceOptimization
    PropertyChanged "SpaceOptimization"
End Property

Public Property Get StorageSystem() As LlStorageSystemConstants
    StorageSystem = ListLabel1.StorageSystem
End Property

Public Property Let StorageSystem(ByVal New_StorageSystem As LlStorageSystemConstants)
    ListLabel1.StorageSystem() = New_StorageSystem
    PropertyChanged "StorageSystem"
End Property

Public Property Get SupportPageBreak() As Boolean
    SupportPageBreak = ListLabel1.SupportPageBreak
End Property

Public Property Let SupportPageBreak(ByVal New_SupportPageBreak As Boolean)
    ListLabel1.SupportPageBreak() = New_SupportPageBreak
    PropertyChanged "SupportPageBreak"
End Property

Public Property Get TableColoring() As LlTableColoringConstants
    TableColoring = ListLabel1.TableColoring
End Property

Public Property Let TableColoring(ByVal New_TableColoring As LlTableColoringConstants)
    ListLabel1.TableColoring() = New_TableColoring
    PropertyChanged "TableColoring"
End Property

Public Property Get TabRepresentationCode() As Integer
    TabRepresentationCode = ListLabel1.TabRepresentationCode
End Property

Public Property Let TabRepresentationCode(ByVal New_TabRepresentationCode As Integer)
    ListLabel1.TabRepresentationCode() = New_TabRepresentationCode
    PropertyChanged "TabRepresentationCode"
End Property

Public Property Get TabStops() As LlTabStopConstants
    TabStops = ListLabel1.TabStops
End Property

Public Property Let TabStops(ByVal New_TabStops As LlTabStopConstants)
    ListLabel1.TabStops() = New_TabStops
    PropertyChanged "TabStops"
End Property

Public Property Get UseBarcodeSizes() As Boolean
    UseBarcodeSizes = ListLabel1.UseBarcodeSizes
End Property

Public Property Let UseBarcodeSizes(ByVal New_UseBarcodeSizes As Boolean)
    ListLabel1.UseBarcodeSizes() = New_UseBarcodeSizes
    PropertyChanged "UseBarcodeSizes"
End Property

Public Property Get UseHostprinter() As Boolean
    UseHostprinter = ListLabel1.UseHostprinter
End Property

Public Property Let UseHostprinter(ByVal New_UseHostprinter As Boolean)
    ListLabel1.UseHostprinter() = New_UseHostprinter
    PropertyChanged "UseHostprinter"
End Property

Public Property Get VarsCaseSensitive() As Boolean
    VarsCaseSensitive = ListLabel1.VarsCaseSensitive
End Property

Public Property Let VarsCaseSensitive(ByVal New_VarsCaseSensitive As Boolean)
    ListLabel1.VarsCaseSensitive() = New_VarsCaseSensitive
    PropertyChanged "VarsCaseSensitive"
End Property

Public Property Get WizFileNew() As Boolean
    WizFileNew = ListLabel1.WizFileNew
End Property

Public Property Let WizFileNew(ByVal New_WizFileNew As Boolean)
    ListLabel1.WizFileNew() = New_WizFileNew
    PropertyChanged "WizFileNew"
End Property

Public Property Get XlatVarNames() As Boolean
    XlatVarNames = ListLabel1.XlatVarNames
End Property

Public Property Let XlatVarNames(ByVal New_XlatVarNames As Boolean)
    ListLabel1.XlatVarNames() = New_XlatVarNames
    PropertyChanged "XlatVarNames"
End Property

Public Property Get hJob() As Long
    hJob = ListLabel1.hJob
End Property

Public Property Get NewExpressions() As LlNewExpressionsConstants
    NewExpressions = ListLabel1.NewExpressions
End Property

Public Property Let NewExpressions(ByVal New_NewExpressions As LlNewExpressionsConstants)
    ListLabel1.NewExpressions() = New_NewExpressions
    PropertyChanged "NewExpressions"
End Property

Public Property Get PhantomSpaceRepresentationCode() As Integer
    PhantomSpaceRepresentationCode = ListLabel1.PhantomSpaceRepresentationCode
End Property

Public Property Let PhantomSpaceRepresentationCode(ByVal New_PhantomSpaceRepresentationCode As Integer)
    ListLabel1.PhantomSpaceRepresentationCode() = New_PhantomSpaceRepresentationCode
    PropertyChanged "PhantomSpaceRepresentationCode"
End Property

Public Property Get LockNextCharRepresentationCode() As Integer
    LockNextCharRepresentationCode = ListLabel1.LockNextCharRepresentationCode
End Property

Public Property Let LockNextCharRepresentationCode(ByVal New_LockNextCharRepresentationCode As Integer)
    ListLabel1.LockNextCharRepresentationCode() = New_LockNextCharRepresentationCode
    PropertyChanged "LockNextCharRepresentationCode"
End Property

Public Property Get ExprSepRepresentationCode() As Integer
    ExprSepRepresentationCode = ListLabel1.ExprSepRepresentationCode
End Property

Public Property Let ExprSepRepresentationCode(ByVal New_ExprSepRepresentationCode As Integer)
    ListLabel1.ExprSepRepresentationCode() = New_ExprSepRepresentationCode
    PropertyChanged "ExprSepRepresentationCode"
End Property

Public Property Get TextQuoteRepresentationCode() As Integer
    TextQuoteRepresentationCode = ListLabel1.TextQuoteRepresentationCode
End Property

Public Property Let TextQuoteRepresentationCode(ByVal New_TextQuoteRepresentationCode As Integer)
    ListLabel1.TextQuoteRepresentationCode() = New_TextQuoteRepresentationCode
    PropertyChanged "TextQuoteRepresentationCode"
End Property



Public Property Let XPStyleUI(ByVal New_XPStyleUI As Boolean)
    ListLabel1.XPStyleUI() = New_XPStyleUI
    PropertyChanged "XPStyleUI"
End Property

Public Property Get ProjectPassword() As String
    ProjectPassword = ListLabel1.ProjectPassword
End Property

Public Property Let ProjectPassword(ByVal New_ProjectPassword As String)
    ListLabel1.ProjectPassword() = New_ProjectPassword
    PropertyChanged "ProjectPassword"
End Property

Public Property Get LicensingInfo() As String
    LicensingInfo = ListLabel1.LicensingInfo
End Property

Public Property Let LicensingInfo(ByVal New_LicensingInfo As String)
    ListLabel1.LicensingInfo() = New_LicensingInfo
    PropertyChanged "LicensingInfo"
End Property

'-------------------------------------------------------------------------
' Special Auto... Handler
'-------------------------------------------------------------------------

'Define Fields
Private Sub ListLabel1_CmndDefineFields(ByVal nUserData As Long, ByVal bDummy As Long, pnProgressInPerc As Long, pbLastRecord As Long)
    
    On Error Resume Next
    
    If m_AutoDefine Then
        
        RaiseEvent AutoDefineNewLine(bDummy = 1)
        
        Select Case m_AutoMasterMode
            
            Case None
                Call DefineRecordset(bDummy = 1, m_AutoDatasourceRecordset, Field)
                If Not (bDummy = 1) Then
                    pnProgressInPerc = 100 / m_AutoDatasourceRecordset.RecordCount * m_AutoDatasourceRecordset.AbsolutePosition
                    m_AutoDatasourceRecordset.MoveNext
                    pbLastRecord = IIf(m_AutoDatasourceRecordset.EOF, 1, 0)
                End If
    
            Case AsFields
                If bDummy = 1 Then
                    Call DefineRecordset(bDummy = 1, m_AutoMasterSourceRecordset, Field, m_AutoMasterPrefix)
                    Call DefineRecordset(bDummy = 1, m_AutoDatasourceRecordset, Field, m_AutoDetailPrefix)
                    Call DefineElement(bDummy = 1, n_MasterRecNo, m_MasterRecNo, Field)

                Else
                    pnProgressInPerc = 100 / m_AutoMasterSourceRecordset.RecordCount * m_AutoMasterSourceRecordset.AbsolutePosition
                    If Not m_AutoDatasourceRecordset.EOF Then
                        Call DefineRecordset(bDummy = 1, m_AutoMasterSourceRecordset, Field, m_AutoMasterPrefix)
                        Call DefineRecordset(bDummy = 1, m_AutoDatasourceRecordset, Field, m_AutoDetailPrefix)
                        Call DefineElement(bDummy = 1, n_MasterRecNo, m_MasterRecNo, Field)
                        m_AutoDatasourceRecordset.MoveNext
                    End If

                    If (Not m_AutoMasterSourceRecordset.EOF) And (m_AutoDatasourceRecordset.EOF) Then
                        m_AutoMasterSourceRecordset.MoveNext
                        m_MasterRecNo = m_MasterRecNo + 1
                        If Not m_AutoMasterSourceRecordset.EOF Then
                            RaiseEvent AutoUpdateDataSource(bDummy = 1, m_AutoDatasourceRecordset)
                            m_AutoDatasourceRecordset.MoveFirst
                        Else
                            pbLastRecord = 1
                        End If
                    
                    ElseIf m_AutoMasterSourceRecordset.EOF And m_AutoDatasourceRecordset.EOF Then
                        pbLastRecord = 1
                    End If
                                    
                End If
            
            Case AsVariables
                If bDummy = 1 Then
                    Call DefineRecordset(bDummy = 1, m_AutoDatasourceRecordset, Field)
                Else
                    pnProgressInPerc = 100 / m_AutoMasterSourceRecordset.RecordCount * m_AutoMasterSourceRecordset.AbsolutePosition

                    If AutoFirstMasterRecord Then
                        AutoFirstMasterRecord = False
                        RaiseEvent AutoUpdateDataSource(bDummy = 1, m_AutoDatasourceRecordset)
                        m_AutoDatasourceRecordset.MoveFirst
                    End If

                    If Not m_AutoDatasourceRecordset.EOF Then
                        Call DefineRecordset(bDummy = 1, m_AutoDatasourceRecordset, Field)
                        m_AutoDatasourceRecordset.MoveNext
                    End If

                    If (Not m_AutoMasterSourceRecordset.EOF) And (m_AutoDatasourceRecordset.EOF) Then
                        m_AutoMasterSourceRecordset.MoveNext
                        m_MasterRecNo = m_MasterRecNo + 1
                        If Not m_AutoMasterSourceRecordset.EOF Then
                            'Reset Page State
                            While ListLabel1.LlPrintFields = LL_WRN_REPEAT_DATA
                                ListLabel1.LlPrint
                            Wend
                            While ListLabel1.LlPrintFieldsEnd = LL_WRN_REPEAT_DATA
                                RaiseEvent AutoDefineNewPage(False)
                            Wend
                            Call ListLabel1.LlPrintResetProjectState
                            Call ListLabel1_CmndDefineVariables(0, 0, 0, 0)
                            ListLabel1.LlPrint
                            RaiseEvent AutoUpdateDataSource(bDummy = 1, m_AutoDatasourceRecordset)
                            m_AutoDatasourceRecordset.MoveFirst
                            Call ListLabel1_CmndDefineFields(0, 0, 0, pbLastRecord)
                        Else
                            pbLastRecord = 1
                        End If

                    ElseIf m_AutoMasterSourceRecordset.EOF And m_AutoDatasourceRecordset.EOF Then
                        pbLastRecord = 1
                    End If
                    
                End If
            
        End Select
    
    Else
        RaiseEvent CmndDefineFields(nUserData, bDummy, pnProgressInPerc, pbLastRecord)
    
    End If

End Sub

'Define Variables
Private Sub ListLabel1_CmndDefineVariables(ByVal nUserData As Long, ByVal bDummy As Long, pnProgressInPerc As Long, pbLastRecord As Long)
    
    On Error Resume Next
    
    If m_AutoDefine Then
        RaiseEvent AutoDefineNewPage(bDummy = 1)
        
        If m_AutoProjectType = LL_PROJECT_CARD Or m_AutoProjectType = LL_PROJECT_LABEL Then
            Call DefineRecordset(bDummy = 1, m_AutoDatasourceRecordset, Variable)
            If Not (bDummy = 1) Then
                pnProgressInPerc = 100 / m_AutoDatasourceRecordset.RecordCount * m_AutoDatasourceRecordset.AbsolutePosition
                m_AutoDatasourceRecordset.MoveNext
                pbLastRecord = IIf(m_AutoDatasourceRecordset.EOF, 1, 0)
            End If
        
        ElseIf (m_AutoMasterMode = AsVariables) Then
            If (Not m_AutoMasterSourceRecordset.EOF) Then
                Call DefineRecordset(bDummy = 1, m_AutoMasterSourceRecordset, Variable)
                Call DefineElement(bDummy = 1, n_MasterRecNo, m_AutoMasterSourceRecordset.AbsolutePosition, Variable)
                Call DefineElement(bDummy = 1, n_MasterRecNo, m_MasterRecNo, Variable)
            End If
        End If
    
    Else
        RaiseEvent CmndDefineVariables(nUserData, bDummy, pnProgressInPerc, pbLastRecord)
    
    End If

End Sub

'-------------------------------------------------------------------------
' Mapped Events
'-------------------------------------------------------------------------

Private Sub ListLabel1_CmndDlgexprVarbtn(ByVal nFunction As LlDlgExprVarbtnConstants, ByVal hWndDlg As Long, ByVal sPage As String, psValue As String, ByVal bFields As Long, ByVal nMask As Long)
    RaiseEvent CmndDlgexprVarbtn(nFunction, hWndDlg, sPage, psValue, bFields, nMask)
End Sub

Private Sub ListLabel1_CmndDrawUserobj(ByVal sName As String, ByVal sContents As String, ByVal lPara As Long, ByVal lpPtr As Long, ByVal hPara As Long, ByVal bIsotropic As Long, ByVal sParameters As String, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal left As Long, ByVal top As Long, ByVal right As Long, ByVal bottom As Long, ByVal nPaintMode As Long)
    RaiseEvent CmndDrawUserobj(sName, sContents, lPara, lpPtr, hPara, bIsotropic, sParameters, hRefDC, hPaintDC, left, top, right, bottom, nPaintMode)
End Sub

Private Sub ListLabel1_CmndEditUserobj(ByVal sName As String, ByVal lPara As Long, ByVal lpPtr As Long, ByVal hPara As Long, ByVal bIsotropic As Long, ByVal hWnd As Long, psParameters As String)
    RaiseEvent CmndEditUserobj(sName, lPara, lpPtr, hPara, bIsotropic, hWnd, psParameters)
End Sub

Private Sub ListLabel1_CmndEnableMenu(ByVal hMenu As Long)
    RaiseEvent CmndEnableMenu(hMenu)
End Sub

Private Sub ListLabel1_CmndExtFct(ByVal sContents As String, ByVal bEvaluate As Long, psNewVal As String, pbError As Long, psError As String)
    RaiseEvent CmndExtFct(sContents, bEvaluate, psNewVal, pbError, psError)
End Sub

Private Sub ListLabel1_CmndGetViewerButtonState(ByVal nID As Long, pnState As Long)
    RaiseEvent CmndGetViewerButtonState(nID, pnState)
End Sub

Private Sub ListLabel1_CmndGroupBegin(Ptr As Long)
    RaiseEvent CmndGroupBegin(Ptr)
End Sub

Private Sub ListLabel1_CmndGroupEnd(Ptr As Long)
    RaiseEvent CmndGroupEnd(Ptr)
End Sub

Private Sub ListLabel1_CmndGroupLine(Ptr As Long)
    RaiseEvent CmndGroupLine(Ptr)
End Sub

Private Sub ListLabel1_CmndHelp(nType As Integer, nContextID As Integer)
    RaiseEvent CmndHelp(nType, nContextID)
End Sub

Private Sub ListLabel1_CmndHostprinter(ByVal bFirst As LlPrinterCmndConstants, ByVal nCmd As Long, ByVal hWnd As Long, phDC As Long, pnOrientation As Integer, psName As String, ByVal nUniqueNumber As Long, ByVal nUniqueNumberCompare As Long)
    RaiseEvent CmndHostprinter(bFirst, nCmd, hWnd, phDC, pnOrientation, psName, nUniqueNumber, nUniqueNumberCompare)
End Sub

Private Sub ListLabel1_CmndModifyMenu(ByVal hMenu As Long)
    RaiseEvent CmndModifyMenu(hMenu)
End Sub

Private Sub ListLabel1_CmndNtfyProgress(ByVal hWnd As Long, ByVal nTotal As Long, ByVal nCurrent As Long, ByVal nJob As LlMeterJobConstants)
    RaiseEvent CmndNtfyProgress(hWnd, nTotal, nCurrent, nJob)
End Sub

Private Sub ListLabel1_CmndObject(ByVal sName As String, ByVal nType As LlObjTypeConstants, ByVal bPreDraw As Long, ByVal hRefDC As Long, ByVal hPaintDC As Long, left As Long, top As Long, right As Long, bottom As Long)
    RaiseEvent CmndObject(sName, nType, bPreDraw, hRefDC, hPaintDC, left, top, right, bottom)
End Sub

Private Sub ListLabel1_CmndPage(ByVal bDesignerPreview As Long, ByVal bPreDraw As Long, ByVal hRefDC As Long, ByVal hPaintDC As Long)
    RaiseEvent CmndPage(bDesignerPreview, bPreDraw, hRefDC, hPaintDC)
End Sub

Private Sub ListLabel1_CmndProject(ByVal bDesignerPreview As Long, ByVal bPreDraw As Long, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal left As Long, ByVal top As Long, ByVal right As Long, ByVal bottom As Long)
    RaiseEvent CmndProject(bDesignerPreview, bPreDraw, hRefDC, hPaintDC, left, top, right, bottom)
End Sub

Private Sub ListLabel1_CmndSelectMenu(ByVal nMenuID As Long, pbProcessed As Long)
    RaiseEvent CmndSelectMenu(nMenuID, pbProcessed)
End Sub

'Private Sub ListLabel1_CmndTableField(ByVal nType As LlTableFieldTypeConstants, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal rcPaint_left As Long, ByVal rcPaint_top As Long, ByVal rcPaint_right As Long, ByVal rcPaint_bottom As Long, ByVal nLineDef As Long, ByVal nIndex As Long, ByVal rcSpacing_left As Long, ByVal rcSpacing_top As Long, ByVal rcSpacing_right As Long, ByVal rcSpacing_bottom As Long)
    'RaiseEvent CmndTableField(nType, hRefDC, hPaintDC, rcPaint_left, rcPaint_top, rcPaint_right, rcPaint_bottom, nLineDef, nIndex, rcSpacing_left, rcSpacing_top, rcSpacing_right, rcSpacing_bottom)
'End Sub

Private Sub ListLabel1_CmndTableLine(ByVal nType As LlTableLineTypeConstants, ByVal hRefDC As Long, ByVal hPaintDC As Long, ByVal rcPaint_left As Long, ByVal rcPaint_top As Long, ByVal rcPaint_right As Long, ByVal rcPaint_bottom As Long, ByVal nPageLine As Long, ByVal nLine As Long, ByVal nLineDef As Long, ByVal bZebra As Long, ByVal rcSpacing_left As Long, ByVal rcSpacing_top As Long, ByVal rcSpacing_right As Long, ByVal rcSpacing_bottom As Long)
    RaiseEvent CmndTableLine(nType, hRefDC, hPaintDC, rcPaint_left, rcPaint_top, rcPaint_right, rcPaint_bottom, nPageLine, nLine, nLineDef, bZebra, rcSpacing_left, rcSpacing_top, rcSpacing_right, rcSpacing_bottom)
End Sub

Private Sub ListLabel1_CmndVarHelptext(ByVal sName As String, psHelptext As String)
    RaiseEvent CmndVarHelptext(sName, psHelptext)
End Sub

Private Sub ListLabel1_CmndViewerBtnClicked(ByVal nFunctionID As Long)
    RaiseEvent CmndViewerBtnClicked(nFunctionID)
End Sub

Private Sub ListLabel1_NtfyFailsFilter()
    RaiseEvent NtfyFailsFilter
End Sub

Private Sub ListLabel1_CmndSetPrintOptions(ByVal nUserData As Long, pnPrintMethodOptionFlags As LlCmndSetPrintOptionsConstants)
    RaiseEvent CmndSetPrintOptions(nUserData, pnPrintMethodOptionFlags)
End Sub

'-------------------------------------------------------------------------
' UserControl Events
'-------------------------------------------------------------------------

'Stretch Ctl Icon to Ctl Size
Private Sub UserControl_Resize()
    Image1.Move 0, 0, UserControl.ScaleWidth, UserControl.ScaleHeight
End Sub

'Initialize Properties
Private Sub UserControl_InitProperties()
    m_AutoDefine = m_def_AutoDefine
    m_AutoDesignerFile = m_def_AutoDesignerFile
    m_AutoDestination = m_def_AutoDestination
    m_AutoMasterMode = m_def_AutoMasterMode
    m_AutoMasterPrefix = m_def_AutoMasterPrefix
    m_AutoDetailPrefix = m_def_AutoDetailPrefix
    m_AutoProjectType = m_def_AutoProjectType
    m_AutoShowPrintOptions = m_def_AutoShowPrintOptions
    m_AutoShowSelectFile = m_def_AutoShowSelectFile
    Set m_AutoDatasourceRecordset = Nothing
    Set m_AutoMasterSourceRecordset = Nothing

    Dim Ctl As Control
    For Each Ctl In Extender.Parent.Controls
        If TypeName(Ctl) = tn_ADO Or TypeName(Ctl) = tn_Data Then
            AutoDatasource = Ctl.Name
            Exit For
        End If
    Next

End Sub

'Load Properties
Private Sub UserControl_ReadProperties(PropBag As PropertyBag)

    m_AutoDefine = PropBag.ReadProperty("AutoDefine", m_def_AutoDefine)
    m_AutoDesignerFile = PropBag.ReadProperty("AutoDesignerFile", m_def_AutoDesignerFile)
    m_AutoDestination = PropBag.ReadProperty("AutoDestination", m_def_AutoDestination)
    m_AutoMasterMode = PropBag.ReadProperty("AutoMasterMode", m_def_AutoMasterMode)
    m_AutoMasterPrefix = PropBag.ReadProperty("AutoMasterPrefix", m_def_AutoMasterPrefix)
    m_AutoDetailPrefix = PropBag.ReadProperty("AutoDetailPrefix", m_def_AutoDetailPrefix)
    m_AutoProjectType = PropBag.ReadProperty("AutoProjectType", m_def_AutoProjectType)
    m_AutoShowPrintOptions = PropBag.ReadProperty("AutoShowPrintOptions", m_def_AutoShowPrintOptions)
    m_AutoShowSelectFile = PropBag.ReadProperty("AutoShowSelectFile", m_def_AutoShowSelectFile)
    m_AutoDatasource = PropBag.ReadProperty("AutoDatasource", "")
    m_AutoMasterSource = PropBag.ReadProperty("AutoMasterSource", "")
    ListLabel1.InterCharSpacing = PropBag.ReadProperty("InterCharSpacing", False)
    ListLabel1.IncludeFontDescent = PropBag.ReadProperty("IncludeFontDescent", False)
    ListLabel1.AddVarsToFields = PropBag.ReadProperty("AddVarsToFields", False)
    ListLabel1.AutoMultipage = PropBag.ReadProperty("AutoMultipage", True)
    ListLabel1.CompressStorage = PropBag.ReadProperty("CompressStorage", False)
    ListLabel1.ConvertCRLF = PropBag.ReadProperty("ConvertCRLF", False)
    ListLabel1.CreateInfo = PropBag.ReadProperty("CreateInfo", True)
    ListLabel1.DelayTableHeader = PropBag.ReadProperty("DelayTableHeader", False)
    ListLabel1.Dialog3DText = PropBag.ReadProperty("Dialog3DText", 0)
    ListLabel1.DialogButtons = PropBag.ReadProperty("DialogButtons", 0)
    ListLabel1.DialogFrame = PropBag.ReadProperty("DialogFrame", 0)
    ListLabel1.DialogMode = PropBag.ReadProperty("DialogMode", 10)
    ListLabel1.EMFResolution = PropBag.ReadProperty("EMFResolution", 0)
    ListLabel1.EnableHelpCallback = PropBag.ReadProperty("EnableHelpCallback", True)
    ListLabel1.EnableObjectCallback = PropBag.ReadProperty("EnableObjectCallback", True)
    ListLabel1.EnablePageCallback = PropBag.ReadProperty("EnablePageCallback", True)
    ListLabel1.EnableProjectCallback = PropBag.ReadProperty("EnableProjectCallback", True)
    ListLabel1.HelpAvailable = PropBag.ReadProperty("HelpAvailable", True)
    ListLabel1.Language = PropBag.ReadProperty("Language", -1)
    ListLabel1.MaxRTFVersion = PropBag.ReadProperty("MaxRTFVersion", 256)
    ListLabel1.Metric = PropBag.ReadProperty("Metric", 1)
    ListLabel1.MultipleTableLines = PropBag.ReadProperty("MultipleTableLines", False)
    ListLabel1.NoNoTableCheck = PropBag.ReadProperty("NoNoTableCheck", False)
    ListLabel1.NoParameterCheck = PropBag.ReadProperty("NoParameterCheck", False)
    ListLabel1.OfnDialogExplorer = PropBag.ReadProperty("OfnDialogExplorer", False)
    ListLabel1.OnlyOneTable = PropBag.ReadProperty("OnlyOneTable", False)
    ListLabel1.PreviewRectHeight = PropBag.ReadProperty("PreviewRectHeight", 0)
    ListLabel1.PreviewRectLeft = PropBag.ReadProperty("PreviewRectLeft", 0)
    ListLabel1.PreviewRectTop = PropBag.ReadProperty("PreviewRectTop", 0)
    ListLabel1.PreviewRectWidth = PropBag.ReadProperty("PreviewRectWidth", 0)
    ListLabel1.PreviewZoomPerc = PropBag.ReadProperty("PreviewZoomPerc", 100)
    ListLabel1.RealTime = PropBag.ReadProperty("RealTime", False)
    ListLabel1.RetRepresentationCode = PropBag.ReadProperty("RetRepresentationCode", 182)
    ListLabel1.ShowPredefVars = PropBag.ReadProperty("ShowPredefVars", True)
    ListLabel1.SortVariables = PropBag.ReadProperty("SortVariables", True)
    ListLabel1.SpaceOptimization = PropBag.ReadProperty("SpaceOptimization", True)
    ListLabel1.StorageSystem = PropBag.ReadProperty("StorageSystem", 1)
    ListLabel1.SupportPageBreak = PropBag.ReadProperty("SupportPageBreak", False)
    ListLabel1.TableColoring = PropBag.ReadProperty("TableColoring", 0)
    ListLabel1.TabRepresentationCode = PropBag.ReadProperty("TabRepresentationCode", 247)
    ListLabel1.TabStops = PropBag.ReadProperty("TabStops", 0)
    ListLabel1.UseBarcodeSizes = PropBag.ReadProperty("UseBarcodeSizes", False)
    ListLabel1.UseHostprinter = PropBag.ReadProperty("UseHostprinter", False)
    ListLabel1.VarsCaseSensitive = PropBag.ReadProperty("VarsCaseSensitive", True)
    ListLabel1.WizFileNew = PropBag.ReadProperty("WizFileNew", False)
    ListLabel1.XlatVarNames = PropBag.ReadProperty("XlatVarNames", True)
    ListLabel1.NewExpressions = PropBag.ReadProperty("NewExpressions", 1)
    ListLabel1.PhantomSpaceRepresentationCode = PropBag.ReadProperty("PhantomSpaceRepresentationCode", 183)
    ListLabel1.LockNextCharRepresentationCode = PropBag.ReadProperty("LockNextCharRepresentationCode", 172)
    ListLabel1.ExprSepRepresentationCode = PropBag.ReadProperty("ExprSepRepresentationCode", 164)
    ListLabel1.TextQuoteRepresentationCode = PropBag.ReadProperty("TextQuoteRepresentationCode", 168)
    ListLabel1.ProjectPassword = PropBag.ReadProperty("ProjectPassword", "")
    ListLabel1.LicensingInfo = PropBag.ReadProperty("LicensingInfo", "")
    ListLabel1.UseChartFields = PropBag.ReadProperty("UseChartFields", False)
    
End Sub

'Save Properties
Private Sub UserControl_WriteProperties(PropBag As PropertyBag)

    Call PropBag.WriteProperty("AutoDefine", m_AutoDefine, m_def_AutoDefine)
    Call PropBag.WriteProperty("AutoDesignerFile", m_AutoDesignerFile, m_def_AutoDesignerFile)
    Call PropBag.WriteProperty("AutoDestination", m_AutoDestination, m_def_AutoDestination)
    Call PropBag.WriteProperty("AutoMasterMode", m_AutoMasterMode, m_def_AutoMasterMode)
    Call PropBag.WriteProperty("AutoMasterPrefix", m_AutoMasterPrefix, m_def_AutoMasterPrefix)
    Call PropBag.WriteProperty("AutoDetailPrefix", m_AutoDetailPrefix, m_def_AutoDetailPrefix)
    Call PropBag.WriteProperty("AutoProjectType", m_AutoProjectType, m_def_AutoProjectType)
    Call PropBag.WriteProperty("AutoShowPrintOptions", m_AutoShowPrintOptions, m_def_AutoShowPrintOptions)
    Call PropBag.WriteProperty("AutoShowSelectFile", m_AutoShowSelectFile, m_def_AutoShowSelectFile)
    Call PropBag.WriteProperty("AutoDatasource", m_AutoDatasource, "")
    Call PropBag.WriteProperty("AutoMasterSource", m_AutoMasterSource, "")
    Call PropBag.WriteProperty("InterCharSpacing", ListLabel1.InterCharSpacing, False)
    Call PropBag.WriteProperty("IncludeFontDescent", ListLabel1.IncludeFontDescent, False)
    Call PropBag.WriteProperty("AddVarsToFields", ListLabel1.AddVarsToFields, False)
    Call PropBag.WriteProperty("AutoMultipage", ListLabel1.AutoMultipage, True)
    Call PropBag.WriteProperty("CompressStorage", ListLabel1.CompressStorage, False)
    Call PropBag.WriteProperty("ConvertCRLF", ListLabel1.ConvertCRLF, False)
    Call PropBag.WriteProperty("CreateInfo", ListLabel1.CreateInfo, True)
    Call PropBag.WriteProperty("DelayTableHeader", ListLabel1.DelayTableHeader, False)
    Call PropBag.WriteProperty("Dialog3DText", ListLabel1.Dialog3DText, 1)
    Call PropBag.WriteProperty("DialogButtons", ListLabel1.DialogButtons, 1)
    Call PropBag.WriteProperty("DialogFrame", ListLabel1.DialogFrame, 0)
    Call PropBag.WriteProperty("DialogMode", ListLabel1.DialogMode, 10)
    Call PropBag.WriteProperty("EMFResolution", ListLabel1.EMFResolution, 0)
    Call PropBag.WriteProperty("EnableHelpCallback", ListLabel1.EnableHelpCallback, True)
    Call PropBag.WriteProperty("EnableObjectCallback", ListLabel1.EnableObjectCallback, True)
    Call PropBag.WriteProperty("EnablePageCallback", ListLabel1.EnablePageCallback, True)
    Call PropBag.WriteProperty("EnableProjectCallback", ListLabel1.EnableProjectCallback, True)
    Call PropBag.WriteProperty("HelpAvailable", ListLabel1.HelpAvailable, True)
    Call PropBag.WriteProperty("Language", ListLabel1.Language, 0)
    Call PropBag.WriteProperty("MaxRTFVersion", ListLabel1.MaxRTFVersion, 256)
    Call PropBag.WriteProperty("Metric", ListLabel1.Metric, 1)
    Call PropBag.WriteProperty("MultipleTableLines", ListLabel1.MultipleTableLines, False)
    Call PropBag.WriteProperty("NoNoTableCheck", ListLabel1.NoNoTableCheck, False)
    Call PropBag.WriteProperty("NoParameterCheck", ListLabel1.NoParameterCheck, False)
    Call PropBag.WriteProperty("OfnDialogExplorer", ListLabel1.OfnDialogExplorer, False)
    Call PropBag.WriteProperty("OnlyOneTable", ListLabel1.OnlyOneTable, False)
    Call PropBag.WriteProperty("PreviewRectHeight", ListLabel1.PreviewRectHeight, 0)
    Call PropBag.WriteProperty("PreviewRectLeft", ListLabel1.PreviewRectLeft, 0)
    Call PropBag.WriteProperty("PreviewRectTop", ListLabel1.PreviewRectTop, 0)
    Call PropBag.WriteProperty("PreviewRectWidth", ListLabel1.PreviewRectWidth, 0)
    Call PropBag.WriteProperty("PreviewZoomPerc", ListLabel1.PreviewZoomPerc, 100)
    Call PropBag.WriteProperty("RealTime", ListLabel1.RealTime, False)
    Call PropBag.WriteProperty("RetRepresentationCode", ListLabel1.RetRepresentationCode, 182)
    Call PropBag.WriteProperty("ShowPredefVars", ListLabel1.ShowPredefVars, True)
    Call PropBag.WriteProperty("SortVariables", ListLabel1.SortVariables, True)
    Call PropBag.WriteProperty("SpaceOptimization", ListLabel1.SpaceOptimization, True)
    Call PropBag.WriteProperty("StorageSystem", ListLabel1.StorageSystem, 1)
    Call PropBag.WriteProperty("SupportPageBreak", ListLabel1.SupportPageBreak, False)
    Call PropBag.WriteProperty("TableColoring", ListLabel1.TableColoring, 0)
    Call PropBag.WriteProperty("TabRepresentationCode", ListLabel1.TabRepresentationCode, 247)
    Call PropBag.WriteProperty("TabStops", ListLabel1.TabStops, 0)
    Call PropBag.WriteProperty("UseBarcodeSizes", ListLabel1.UseBarcodeSizes, False)
    Call PropBag.WriteProperty("UseHostprinter", ListLabel1.UseHostprinter, False)
    Call PropBag.WriteProperty("VarsCaseSensitive", ListLabel1.VarsCaseSensitive, True)
    Call PropBag.WriteProperty("WizFileNew", ListLabel1.WizFileNew, False)
    Call PropBag.WriteProperty("XlatVarNames", ListLabel1.XlatVarNames, True)
    Call PropBag.WriteProperty("NewExpressions", ListLabel1.NewExpressions, 1)
    Call PropBag.WriteProperty("PhantomSpaceRepresentationCode", ListLabel1.PhantomSpaceRepresentationCode, 183)
    Call PropBag.WriteProperty("LockNextCharRepresentationCode", ListLabel1.LockNextCharRepresentationCode, 172)
    Call PropBag.WriteProperty("ExprSepRepresentationCode", ListLabel1.ExprSepRepresentationCode, 164)
    Call PropBag.WriteProperty("TextQuoteRepresentationCode", ListLabel1.TextQuoteRepresentationCode, 168)
    Call PropBag.WriteProperty("ProjectPassword", ListLabel1.ProjectPassword, "")
    Call PropBag.WriteProperty("LicensingInfo", ListLabel1.LicensingInfo, "")
    Call PropBag.WriteProperty("UseChartFields", ListLabel1.UseChartFields, False)
End Sub

'-------------------------------------------------------------------------
' Auto... Methods
'-------------------------------------------------------------------------

'Calls SimpleDesign using Auto... properties
Public Function AutoDesign(Title As String) As Variant
    AutoDesign = SimpleDesign(0, Extender.Parent.hWnd, Title, m_AutoProjectType, m_AutoDesignerFile, m_AutoShowSelectFile)
End Function

'Calls SimplePrint using Auto... properties
Public Function AutoPrint(Title As String, TempPath As String) As Variant
    AutoPrint = SimplePrint(0, m_AutoProjectType, m_AutoDesignerFile, m_AutoShowSelectFile, m_AutoDestination, LL_BOXTYPE_STDABORT, Extender.Parent.hWnd, Title, m_AutoShowPrintOptions, TempPath)
End Function

'-------------------------------------------------------------------------
' Mapped Methods
'-------------------------------------------------------------------------

Public Function LlDesignerProhibitFunction(sFunctionName As String) As Long
    LlDesignerProhibitFunction = ListLabel1.LlDesignerProhibitFunction(sFunctionName)
End Function

Public Function LlDefineChartFieldExt(sVarName As String, sContents As String, nFieldType As LlFieldTypeConstants) As Long
    LlDefineChartFieldExt = ListLabel1.LlDefineChartFieldExt(sVarName, sContents, nFieldType)
End Function

Public Function LlDefineChartFieldStart() As Long
    LlDefineChartFieldStart = ListLabel1.LlDefineChartFieldStart
End Function

Public Function LlPrintDeclareChartRow(nFlags As LlPrintDeclareChartRowConstants) As Long
    LlPrintDeclareChartRow = ListLabel1.LlPrintDeclareChartRow(nFlags)
End Function

Public Function LlPrintGetChartObjectCount(nFlags As LlPrintGetChartObjectCountConstants) As Long
    LlPrintGetChartObjectCount = ListLabel1.LlPrintGetChartObjectCount(nFlags)
End Function

Public Function LlPrintIsChartFieldUsed(sFieldName As String) As Long
    LlPrintIsChartFieldUsed = ListLabel1.LlPrintIsChartFieldUsed(sFieldName)
End Function

Public Function LlGetChartFieldContents(sName As String, psBuffer As String) As Long
    LlGetChartFieldContents = ListLabel1.LlGetChartFieldContents(sName, psBuffer)
End Function

Public Function LlEnumGetFirstChartField(nFlags As LlFieldTypeConstants) As Long
    LlEnumGetFirstChartField = ListLabel1.LlEnumGetFirstChartField(nFlags)
End Function

Public Sub AboutBox()
    ListLabel1.AboutBox
End Sub

Public Function LlAddCtlSupport(ByVal hWnd As Long, ByVal nFlags As LlCtlOptionConstants, ByVal sIniFile As String) As Long
    LlAddCtlSupport = ListLabel1.LlAddCtlSupport(hWnd, nFlags, sIniFile)
End Function

Public Function LlCreateSketch(ByVal nObjType As LlProjectConstants, ByVal sObjName As String) As Long
    LlCreateSketch = ListLabel1.LlCreateSketch(nObjType, sObjName)
End Function

Public Sub LlDebugOutput(ByVal nIdent As Long, ByVal sText As String)
    ListLabel1.LlDebugOutput nIdent, sText
End Sub

Public Function LlDefineField(ByVal sVarName As String, ByVal sContent As String) As Long
    LlDefineField = ListLabel1.LlDefineField(sVarName, sContent)
End Function

Public Function LlDefineFieldExt(ByVal sVarName As String, ByVal sContent As String, ByVal nFieldType As LlFieldTypeConstants) As Long
    LlDefineFieldExt = ListLabel1.LlDefineFieldExt(sVarName, sContent, nFieldType)
End Function

Public Function LlDefineFieldExtHandle(ByVal sVarName As String, ByVal hContent As Long, ByVal nFieldType As LlFieldTypeConstants) As Long
    LlDefineFieldExtHandle = ListLabel1.LlDefineFieldExtHandle(sVarName, hContent, nFieldType)
End Function

Public Sub LlDefineFieldStart()
    ListLabel1.LlDefineFieldStart
End Sub

Public Function LlDefineGrouping(ByVal sSortorder As String, ByVal sIdentifier As String, ByVal sText As String) As Long
    LlDefineGrouping = ListLabel1.LlDefineGrouping(sSortorder, sIdentifier, sText)
End Function

Public Function LlDefineLayout(ByVal hWnd As Long, ByVal sTitle As String, ByVal nObjType As LlProjectConstants, ByVal sObjName As String) As Long
    LlDefineLayout = ListLabel1.LlDefineLayout(hWnd, sTitle, nObjType, sObjName)
End Function

Public Function LlDefineSortOrder(ByVal sIdentifier As String, ByVal sText As String) As Long
    LlDefineSortOrder = ListLabel1.LlDefineSortOrder(sIdentifier, sText)
End Function

Public Function LlDefineSortOrderStart() As Long
    LlDefineSortOrderStart = ListLabel1.LlDefineSortOrderStart()
End Function

Public Function LlDefineSumVariable(ByVal sVarName As String, ByVal sContent As String) As Long
    LlDefineSumVariable = ListLabel1.LlDefineSumVariable(sVarName, sContent)
End Function

Public Function LlDefineVariable(ByVal sVarName As String, ByVal sContent As String) As Long
    LlDefineVariable = ListLabel1.LlDefineVariable(sVarName, sContent)
End Function

Public Function LlDefineVariableExt(ByVal sVarName As String, ByVal sContent As String, ByVal nFieldType As LlFieldTypeConstants) As Long
    LlDefineVariableExt = ListLabel1.LlDefineVariableExt(sVarName, sContent, nFieldType)
End Function

Public Function LlDefineVariableExtHandle(ByVal sVarName As String, ByVal hContent As Long, ByVal nFieldType As LlFieldTypeConstants) As Long
    LlDefineVariableExtHandle = ListLabel1.LlDefineVariableExtHandle(sVarName, hContent, nFieldType)
End Function

Public Sub LlDefineVariableStart()
    ListLabel1.LlDefineVariableStart
End Sub

Public Function LlDesignerProhibitAction(ByVal nMenuID As Long) As Long
    LlDesignerProhibitAction = ListLabel1.LlDesignerProhibitAction(nMenuID)
End Function

Public Function LlEnumGetEntry(ByVal nPos As Long, psName As String, psContents As String, pHandle As Long, pnType As LlFieldTypeConstants) As Long
    LlEnumGetEntry = ListLabel1.LlEnumGetEntry(nPos, psName, psContents, pHandle, pnType)
End Function

Public Function LlEnumGetFirstField(ByVal nFlags As LlFieldTypeConstants) As Long
    LlEnumGetFirstField = ListLabel1.LlEnumGetFirstField(nFlags)
End Function

Public Function LlEnumGetFirstVar(ByVal nFlags As LlFieldTypeConstants) As Long
    LlEnumGetFirstVar = ListLabel1.LlEnumGetFirstVar(nFlags)
End Function

Public Function LlEnumGetNextEntry(ByVal nPos As Long, ByVal nFlags As LlFieldTypeConstants) As Long
    LlEnumGetNextEntry = ListLabel1.LlEnumGetNextEntry(nPos, nFlags)
End Function

Public Sub LlExprError(psBuffer As String)
    ListLabel1.LlExprError psBuffer
End Sub

Public Function LlExprEvaluate(ByVal nptrExpr As Long, psBuffer As String) As Long
    LlExprEvaluate = ListLabel1.LlExprEvaluate(nptrExpr, psBuffer)
End Function

Public Sub LlExprFree(ByVal nptrExpr As Long)
    ListLabel1.LlExprFree nptrExpr
End Sub

Public Function LlExprParse(ByVal sExprText As String, ByVal bTablefields As Long) As Long
    LlExprParse = ListLabel1.LlExprParse(sExprText, bTablefields)
End Function

Public Function LlExprType(ByVal nptrExpr As Long) As Long
    LlExprType = ListLabel1.LlExprType(nptrExpr)
End Function

Public Function LlGetFieldContents(ByVal sName As String, psBuffer As String) As Long
    LlGetFieldContents = ListLabel1.LlGetFieldContents(sName, psBuffer)
End Function

Public Function LlGetFieldType(ByVal sName As String) As Long
    LlGetFieldType = ListLabel1.LlGetFieldType(sName)
End Function

Public Function LlGetOption(ByVal nMode As LlOptionConstants) As Long
    LlGetOption = ListLabel1.LlGetOption(nMode)
End Function

Public Function LlGetOptionString(ByVal nIndex As LlOptionStringConstants, psBuffer As String) As Long
    LlGetOptionString = ListLabel1.LlGetOptionString(nIndex, psBuffer)
End Function

Public Function LlGetSumVariableContents(ByVal sName As String, psBuffer As String) As Long
    LlGetSumVariableContents = ListLabel1.LlGetSumVariableContents(sName, psBuffer)
End Function

Public Function LlGetUserVariableContents(ByVal sName As String, psBuffer As String) As Long
    LlGetUserVariableContents = ListLabel1.LlGetUserVariableContents(sName, psBuffer)
End Function

Public Function LlGetVariableContents(ByVal sName As String, psBuffer As String) As Long
    LlGetVariableContents = ListLabel1.LlGetVariableContents(sName, psBuffer)
End Function

Public Function LlGetVariableType(ByVal sName As String) As Long
    LlGetVariableType = ListLabel1.LlGetVariableType(sName)
End Function

Public Function LlGetVersion(ByVal nCmd As LlVersionConstants) As Long
    LlGetVersion = ListLabel1.LlGetVersion(nCmd)
End Function

Public Function LlPreviewDeleteFiles(ByVal sObjName As String, ByVal sPath As String) As Long
    LlPreviewDeleteFiles = ListLabel1.LlPreviewDeleteFiles(sObjName, sPath)
End Function

Public Function LlPreviewDisplay(ByVal sObjName As String, ByVal sPath As String, ByVal hWnd As Long) As Long
    LlPreviewDisplay = ListLabel1.LlPreviewDisplay(sObjName, sPath, hWnd)
End Function

Public Function LlPreviewDisplayEx(ByVal sObjName As String, ByVal sPath As String, ByVal hWnd As Long, ByVal nOptions As Long) As Long
    LlPreviewDisplayEx = ListLabel1.LlPreviewDisplayEx(sObjName, sPath, hWnd, nOptions)
End Function

Public Function LlPreviewSetTempPath(ByVal sPath As String) As Long
    LlPreviewSetTempPath = ListLabel1.LlPreviewSetTempPath(sPath)
End Function

Public Function LlPrint() As Long
    LlPrint = ListLabel1.LlPrint()
End Function

Public Function LlPrintAbort() As Long
    LlPrintAbort = ListLabel1.LlPrintAbort()
End Function

Public Function LlPrintCheckLineFit() As Boolean
    LlPrintCheckLineFit = ListLabel1.LlPrintCheckLineFit()
End Function

Public Function LlPrintCopyPrinterConfiguration(ByVal sFileName As String, ByVal nFunction As LlPrinterConfigurationConstants) As Long
    LlPrintCopyPrinterConfiguration = ListLabel1.LlPrintCopyPrinterConfiguration(sFileName, nFunction)
End Function

Public Function LlPrintDidMatchFilter() As Long
    LlPrintDidMatchFilter = ListLabel1.LlPrintDidMatchFilter()
End Function

Public Function LlPrintEnableObject(ByVal sObjName As String, ByVal bEnable As Long) As Long
    LlPrintEnableObject = ListLabel1.LlPrintEnableObject(sObjName, bEnable)
End Function

Public Function LlPrintEnd(ByVal nPages As Long) As Long
    LlPrintEnd = ListLabel1.LlPrintEnd(nPages)
End Function

Public Function LlPrinterSetup(ByVal hWnd As Long, ByVal nObjType As LlProjectConstants, ByVal sObjName As String) As Long
    LlPrinterSetup = ListLabel1.LlPrinterSetup(hWnd, nObjType, sObjName)
End Function

Public Function LlPrintFields() As Long
    LlPrintFields = ListLabel1.LlPrintFields()
End Function

Public Function LlPrintFieldsEnd() As Long
    LlPrintFieldsEnd = ListLabel1.LlPrintFieldsEnd()
End Function

Public Function LlPrintGetCurrentPage() As Long
    LlPrintGetCurrentPage = ListLabel1.LlPrintGetCurrentPage()
End Function

Public Function LlPrintGetFilterExpression(psBuffer As String) As Long
    LlPrintGetFilterExpression = ListLabel1.LlPrintGetFilterExpression(psBuffer)
End Function

Public Function LlPrintGetGrouping(psBuffer As String) As Long
    LlPrintGetGrouping = ListLabel1.LlPrintGetGrouping(psBuffer)
End Function

Public Function LlPrintGetItemsPerPage() As Long
    LlPrintGetItemsPerPage = ListLabel1.LlPrintGetItemsPerPage()
End Function

Public Function LlPrintGetItemsPerTable() As Long
    LlPrintGetItemsPerTable = ListLabel1.LlPrintGetItemsPerTable()
End Function

Public Function LlPrintGetOption(ByVal nIndex As LlPrintOptionConstants) As Long
    LlPrintGetOption = ListLabel1.LlPrintGetOption(nIndex)
End Function

Public Function LlPrintGetOptionString(ByVal nIndex As LlPrintOptionStringConstants, psBuffer As String) As Long
    LlPrintGetOptionString = ListLabel1.LlPrintGetOptionString(nIndex, psBuffer)
End Function

Public Function LlPrintGetPrinterInfo(psPrn As String, psPort As String) As Long
    LlPrintGetPrinterInfo = ListLabel1.LlPrintGetPrinterInfo(psPrn, psPort)
End Function

Public Function LlPrintGetRemItemsPerTable(ByVal sField As String) As Long
    LlPrintGetRemItemsPerTable = ListLabel1.LlPrintGetRemItemsPerTable(sField)
End Function

Public Function LlPrintGetSortOrder(psBuffer As String) As Long
    LlPrintGetSortOrder = ListLabel1.LlPrintGetSortOrder(psBuffer)
End Function

Public Function LlPrintIsFieldUsed(ByVal sFieldName As String) As Long
    LlPrintIsFieldUsed = ListLabel1.LlPrintIsFieldUsed(sFieldName)
End Function

Public Function LlPrintIsVariableUsed(ByVal sVarName As String) As Long
    LlPrintIsVariableUsed = ListLabel1.LlPrintIsVariableUsed(sVarName)
End Function

Public Function LlPrintOptionsDialog(ByVal hWnd As Long, ByVal sText As String) As Long
    LlPrintOptionsDialog = ListLabel1.LlPrintOptionsDialog(hWnd, sText)
End Function

Public Function LlPrintOptionsDialogTitle(ByVal hWnd As Long, ByVal sTitle As String, ByVal sText As String) As Long
    LlPrintOptionsDialogTitle = ListLabel1.LlPrintOptionsDialogTitle(hWnd, sTitle, sText)
End Function

Public Function LlPrintSelectOffset(ByVal hWnd As Long) As Long
    LlPrintSelectOffset = ListLabel1.LlPrintSelectOffset(hWnd)
End Function

Public Function LlPrintSetBoxText(ByVal sText As String, ByVal nPercentage As Long) As Long
    LlPrintSetBoxText = ListLabel1.LlPrintSetBoxText(sText, nPercentage)
End Function

Public Function LlPrintSetOption(ByVal nIndex As LlPrintOptionConstants, ByVal nValue As Long) As Long
    LlPrintSetOption = ListLabel1.LlPrintSetOption(nIndex, nValue)
End Function

Public Function LlPrintSetOptionString(ByVal nIndex As LlPrintOptionStringConstants, ByVal sBuffer As String) As Long
    LlPrintSetOptionString = ListLabel1.LlPrintSetOptionString(nIndex, sBuffer)
End Function

Public Function LlPrintStart(ByVal nObjType As LlProjectConstants, ByVal sObjName As String, ByVal nPrintOptions As Long) As Long
    LlPrintStart = ListLabel1.LlPrintStart(nObjType, sObjName, nPrintOptions)
End Function

Public Function LlPrintWillMatchFilter() As Long
    LlPrintWillMatchFilter = ListLabel1.LlPrintWillMatchFilter()
End Function

Public Function LlPrintWithBoxStart(ByVal nObjType As LlProjectConstants, ByVal sObjName As String, ByVal nPrintOptions As LlPrintModeConstants, ByVal nBoxType As LlBoxTypeConstants, ByVal hWnd As Long, ByVal sTitle As String) As Long
    LlPrintWithBoxStart = ListLabel1.LlPrintWithBoxStart(nObjType, sObjName, nPrintOptions, nBoxType, hWnd, sTitle)
End Function

Public Function LlSelectFileDlg(ByVal hWnd As Long, ByVal nObjType As LlProjectConstants, psObjName As String) As Long
    LlSelectFileDlg = ListLabel1.LlSelectFileDlg(hWnd, nObjType, psObjName)
End Function

Public Function LlSelectFileDlgTitle(ByVal hWnd As Long, ByVal sTitle As String, ByVal nObjType As LlProjectConstants, psObjName As String) As Long
    LlSelectFileDlgTitle = ListLabel1.LlSelectFileDlgTitle(hWnd, sTitle, nObjType, psObjName)
End Function

Public Sub LlSetDebug(ByVal nOnOff As LlDebugConstants)
    ListLabel1.LlSetDebug nOnOff
End Sub

Public Function LlSetDecimalChar(ByVal cDecPoint As Long) As Long
    LlSetDecimalChar = ListLabel1.LlSetDecimalChar(cDecPoint)
End Function

Public Function LlSetFileExtensions(ByVal nObjType As LlProjectConstants, ByVal sObjectExt As String, ByVal sPrinterExt As String, ByVal sSketchExt As String) As Long
    LlSetFileExtensions = ListLabel1.LlSetFileExtensions(nObjType, sObjectExt, sPrinterExt, sSketchExt)
End Function

Public Function LlSetOption(ByVal nMode As LlOptionConstants, ByVal nValue As Long) As Long
    LlSetOption = ListLabel1.LlSetOption(nMode, nValue)
End Function

Public Function LlSetOptionString(ByVal nIndex As LlOptionStringConstants, ByVal sBuffer As String) As Long
    LlSetOptionString = ListLabel1.LlSetOptionString(nIndex, sBuffer)
End Function

Public Function LlSetPrinterDefaultsDir(ByVal sDir As String) As Long
    LlSetPrinterDefaultsDir = ListLabel1.LlSetPrinterDefaultsDir(sDir)
End Function

Public Function LlSetPrinterToDefault(ByVal nObjType As LlProjectConstants, ByVal sObjName As String) As Long
    LlSetPrinterToDefault = ListLabel1.LlSetPrinterToDefault(nObjType, sObjName)
End Function

Public Function LlSetPrinterInPrinterFile(ByVal nObjType As Long, ByVal sObjName As String, ByVal nPrinter As Long, ByVal sPrinter As String) As Long
    LlSetPrinterInPrinterFile = ListLabel1.LlSetPrinterInPrinterFile(nObjType, sObjName, nPrinter, sPrinter, 0)
End Function


Public Function LlStgsysAppend(ByVal hStg As Long, ByVal hStgToAppend As Long) As Long
    LlStgsysAppend = ListLabel1.LlStgsysAppend(hStg, hStgToAppend)
End Function

Public Function LlStgsysDeleteFiles(ByVal hStg As Long) As Long
    LlStgsysDeleteFiles = ListLabel1.LlStgsysDeleteFiles(hStg)
End Function

Public Function LlStgsysDestroyMetafile(ByVal hMF As Long) As Long
    LlStgsysDestroyMetafile = ListLabel1.LlStgsysDestroyMetafile(hMF)
End Function

Public Function LlStgsysDrawPage(ByVal hStg As Long, ByVal hDC As Long, ByVal hPrnDC As Long, ByVal bAskPrinter As Long, ByVal left As Long, ByVal top As Long, ByVal right As Long, ByVal bottom As Long, ByVal nPageIndex As Long, ByVal bFit As Long) As Long
    LlStgsysDrawPage = ListLabel1.LlStgsysDrawPage(hStg, hDC, hPrnDC, bAskPrinter, left, top, right, bottom, nPageIndex, bFit)
End Function

Public Function LlStgsysGetAPIVersion(ByVal hStg As Long) As Long
    LlStgsysGetAPIVersion = ListLabel1.LlStgsysGetAPIVersion(hStg)
End Function

Public Function LlStgsysGetFilename(ByVal hStg As Long, ByVal nJob As Long, ByVal nFile As Long, psBuffer As String) As Long
    LlStgsysGetFilename = ListLabel1.LlStgsysGetFilename(hStg, nJob, nFile, psBuffer)
End Function

Public Function LlStgsysGetFileVersion(ByVal hStg As Long) As Long
    LlStgsysGetFileVersion = ListLabel1.LlStgsysGetFileVersion(hStg)
End Function

Public Function LlStgsysGetJobCount(ByVal hStg As Long) As Long
    LlStgsysGetJobCount = ListLabel1.LlStgsysGetJobCount(hStg)
End Function

Public Function LlStgsysGetJobOptionValue(ByVal hStg As Long, ByVal nOption As LlStgsysOptionConstants) As Long
    LlStgsysGetJobOptionValue = ListLabel1.LlStgsysGetJobOptionValue(hStg, nOption)
End Function

Public Function LlStgsysGetLastError(ByVal hStg As Long) As Long
    LlStgsysGetLastError = ListLabel1.LlStgsysGetLastError(hStg)
End Function

Public Function LlStgsysGetPageCount(ByVal hStg As Long) As Long
    LlStgsysGetPageCount = ListLabel1.LlStgsysGetPageCount(hStg)
End Function

Public Function LlStgsysGetPageMetafile(ByVal hStg As Long, ByVal nPageIndex As Long) As Long
    LlStgsysGetPageMetafile = ListLabel1.LlStgsysGetPageMetafile(hStg, nPageIndex)
End Function

Public Function LlStgsysGetPageMetafile16(ByVal hStg As Long, ByVal nPageIndex As Long) As Long
    LlStgsysGetPageMetafile16 = ListLabel1.LlStgsysGetPageMetafile16(hStg, nPageIndex)
End Function

Public Function LlStgsysGetPageOptionString(ByVal hStg As Long, ByVal nPageIndex As Long, ByVal nOption As LlStgsysOptionConstants, psBuffer As String) As Long
    LlStgsysGetPageOptionString = ListLabel1.LlStgsysGetPageOptionString(hStg, nPageIndex, nOption, psBuffer)
End Function

Public Function LlStgsysGetPageOptionValue(ByVal hStg As Long, ByVal nPageIndex As Long, ByVal nOption As LlStgsysOptionConstants) As Long
    LlStgsysGetPageOptionValue = ListLabel1.LlStgsysGetPageOptionValue(hStg, nPageIndex, nOption)
End Function

Public Function LlStgsysSetJob(ByVal hStg As Long, ByVal nJob As Long) As Long
    LlStgsysSetJob = ListLabel1.LlStgsysSetJob(hStg, nJob)
End Function

Public Function LlStgsysSetPageOptionString(ByVal hStg As Long, ByVal nPageIndex As Long, ByVal nOption As LlStgsysOptionConstants, ByVal sBuffer As String) As Long
    LlStgsysSetPageOptionString = ListLabel1.LlStgsysSetPageOptionString(hStg, nPageIndex, nOption, sBuffer)
End Function

Public Sub LlStgsysStorageClose(ByVal hStg As Long)
    ListLabel1.LlStgsysStorageClose hStg
End Sub

Public Function LlStgsysStorageOpen(ByVal sFileName As String, ByVal sTempPath As String, ByVal bReadOnly As Long, ByVal bOneJobTranslation As Long) As Long
    LlStgsysStorageOpen = ListLabel1.LlStgsysStorageOpen(sFileName, sTempPath, bReadOnly, bOneJobTranslation)
End Function

Public Function LlViewerProhibitAction(ByVal nMenuID As Long) As Long
    LlViewerProhibitAction = ListLabel1.LlViewerProhibitAction(nMenuID)
End Function

Public Function LlXGetParameter(nExtensionType As LlExtensionTypeConstants, ByVal sExtensionName As String, ByVal sKey As String, psBuffer As String) As Long
    LlXGetParameter = ListLabel1.LlXGetParameter(nExtensionType, sExtensionName, sKey, psBuffer)
End Function

Public Function LlXSetParameter(nExtensionType As LlExtensionTypeConstants, ByVal sExtensionName As String, ByVal sKey As String, ByVal sValue As String) As Long
    LlXSetParameter = ListLabel1.LlXSetParameter(nExtensionType, sExtensionName, sKey, sValue)
End Function

Public Function LlPrintResetObjectStates() As Long
    LlPrintResetObjectStates = ListLabel1.LlPrintResetObjectStates()
End Function

Public Function LlStgsysPrint(ByVal hStg As Long, ByVal sPrinterName1 As String, ByVal sPrinterName2 As String, ByVal nStartPageIndex As Long, ByVal nEndPageIndex As Long, ByVal nCopies As Long, nFlags As LlStgsysPrintFlagConstants, ByVal sMessage As String, ByVal hWnd As Long) As Long
    LlStgsysPrint = ListLabel1.LlStgsysPrint(hStg, sPrinterName1, sPrinterName2, nStartPageIndex, nEndPageIndex, nCopies, nFlags, sMessage, hWnd)
End Function

Public Function LlStgsysStoragePrint(ByVal sFileName As String, ByVal sTempPath As String, ByVal sPrinterName1 As String, ByVal sPrinterName2 As String, ByVal nStartPageIndex As Long, ByVal nEndPageIndex As Long, ByVal nCopies As Long, nFlags As LlStgsysPrintFlagConstants, ByVal sMessage As String, ByVal hWnd As Long) As Long
    LlStgsysStoragePrint = ListLabel1.LlStgsysStoragePrint(sFileName, sTempPath, sPrinterName1, sPrinterName2, nStartPageIndex, nEndPageIndex, nCopies, nFlags, sMessage, hWnd)
End Function

Public Function LlPrintResetProjectState() As Long
    LlPrintResetProjectState = ListLabel1.LlPrintResetProjectState()
End Function

Public Function LlRTFCreateObject() As Long
    LlRTFCreateObject = ListLabel1.LlRTFCreateObject()
End Function

Public Function LlRTFDeleteObject(ByVal hRTFObj As Long) As Long
    LlRTFDeleteObject = ListLabel1.LlRTFDeleteObject(hRTFObj)
End Function

Public Function LlRTFSetText(ByVal hRTFObj As Long, ByVal sText As String) As Long
    LlRTFSetText = ListLabel1.LlRTFSetText(hRTFObj, sText)
End Function

Public Function LlRTFGetTextLength(ByVal hRTFObj As Long, ByVal nFlags As LlRTFTextModeConstants) As Long
    LlRTFGetTextLength = ListLabel1.LlRTFGetTextLength(hRTFObj, nFlags)
End Function

Public Function LlRTFGetText(ByVal hRTFObj As Long, ByVal nFlags As LlRTFTextModeConstants, psText As String) As Long
    LlRTFGetText = ListLabel1.LlRTFGetText(hRTFObj, nFlags, psText)
End Function

Public Function LlRTFEditObject(ByVal hRTFObj As Long, ByVal hWnd As Long, ByVal hPrnDC As Long, ByVal nProjectType As LlProjectConstants, bModal As Long) As Long
    LlRTFEditObject = ListLabel1.LlRTFEditObject(hRTFObj, hWnd, hPrnDC, nProjectType, bModal)
End Function

Public Function LlRTFCopyToClipboard(ByVal hRTFObj As Long) As Long
    LlRTFCopyToClipboard = ListLabel1.LlRTFCopyToClipboard(hRTFObj)
End Function

Public Function LlRTFDisplay(ByVal hRTFObj As Long, ByVal hDC As Long, left As Long, top As Long, right As Long, bottom As Long, ByVal bRestart As Long, pnState As Long) As Long
    LlRTFDisplay = ListLabel1.LlRTFDisplay(hRTFObj, hDC, left, top, right, bottom, bRestart, pnState)
End Function

Public Function LlPrintGetRemainingSpacePerTable(ByVal sField As String, ByVal nDimension As LlGripDimConstants) As Long
    LlPrintGetRemainingSpacePerTable = ListLabel1.LlPrintGetRemainingSpacePerTable(sField, nDimension)
End Function



'-------------------------------------------------------------------------
' Special Handled Print & Design Method
'-------------------------------------------------------------------------

'Design Report
Public Function SimpleDesign(ByVal nUserData As Long, ByVal hWnd As Long, ByVal sTitle As String, ByVal nObjType As LlProjectConstants, ByVal sObjName As String, ByVal bWithFileSelect As Long) As Long
    
    If m_AutoDefine Then
        InitDataBinding
        If m_AutoMasterMode = AsFields Or m_AutoMasterMode = AsVariables Then
            RaiseEvent AutoUpdateDataSource(True, m_AutoDatasourceRecordset)
        End If
    End If
    SimpleDesign = ListLabel1.Design(nUserData, hWnd, sTitle, nObjType Or LL_FILE_ALSONEW, sObjName, bWithFileSelect)

End Function

'Print Report
Public Function SimplePrint(ByVal nUserData As Long, ByVal nObjType As LlProjectConstants, ByVal sObjName As String, ByVal bWithFileSelect As Long, ByVal nPrintOptions As Long, ByVal nBoxType As Long, ByVal hWnd As Long, ByVal sTitle As String, ByVal bShowPrintOptionsDlg As Long, ByVal sTempPath As String) As Long
    
    If m_AutoDefine Then
        InitDataBinding
        If m_AutoMasterMode = AsFields Or m_AutoMasterMode = AsVariables Then
            RaiseEvent AutoUpdateDataSource(True, m_AutoDatasourceRecordset)
            AutoFirstMasterRecord = True
        End If
    End If
    SimplePrint = ListLabel1.Print(nUserData, nObjType, sObjName, bWithFileSelect, nPrintOptions, nBoxType, hWnd, sTitle, bShowPrintOptionsDlg, sTempPath)

End Function

'-------------------------------------------------------------------------
' Additional Functions
'-------------------------------------------------------------------------

'Init DataBinding
Private Function InitDataBinding()
    
    'Set Recordset by Ctl Name if not yet defined
    If m_AutoDatasourceRecordset Is Nothing Then
        SetRSByName m_AutoDatasource, m_AutoDatasourceRecordset
    End If
    If (m_AutoMasterMode <> None) And (m_AutoMasterSourceRecordset Is Nothing) Then
        SetRSByName m_AutoMasterSource, m_AutoMasterSourceRecordset
    End If
    
    'Move to first Recordset
    If Not m_AutoDatasourceRecordset Is Nothing Then
        m_AutoDatasourceRecordset.MoveFirst
    End If
    'Move to first Recordset
    If Not m_AutoMasterSourceRecordset Is Nothing Then
        m_AutoMasterSourceRecordset.MoveFirst
    End If

    'Init RecNo Counter
    m_MasterRecNo = 1

End Function

'Set Recordset by Ctl Name
Private Function SetRSByName(CtlName As String, ByRef DestinationRS As Object)
    Dim Ctl As Control
    CtlName = LCase(CtlName)
    
    If Len(Trim(CtlName)) > 0 Then
        For Each Ctl In Extender.Parent.Controls
            If TypeName(Ctl) = tn_ADO Or TypeName(Ctl) = tn_Data Then
                If LCase(Ctl.Name) = CtlName Then
                    Set DestinationRS = Ctl.Recordset
                    Exit For
                End If
            End If
        Next
    End If
End Function

'Define Recordset as Variables or Fields
Private Function DefineRecordset(ByVal DesignMode As Boolean, RecordsetObj As Object, DefineType As enumAutoElementDefineType, Optional Prefix As String)
    
    Dim Fld As Object
    Dim FldName As String
    For Each Fld In RecordsetObj.Fields
        FldName = IIf(Len(Prefix) > 0, Prefix & ".", "") & Fld.Name
        If Not IsNull(Fld.Value) Then
            Call DefineElement(DesignMode, FldName, Fld.Value, DefineType)
        Else
            Call DefineElement(DesignMode, FldName, "", DefineType)
        End If
    Next
    
End Function

'Define Element as Variable or Field
Private Function DefineElement(ByVal DesignMode As Boolean, ByVal ElmName As String, ByVal ElmContent As Variant, DefineType As enumAutoElementDefineType)
        
        Dim ElmType As LlFieldTypeConstants
        Dim handled As Boolean
        
        Select Case VarType(ElmContent)
            'Numeric field
            Case 2, 3, 4, 5, 6
                ElmType = LL_NUMERIC
            'Date
            Case 7
                ElmType = LL_DATE_MS
                ElmContent = CDbl(ElmContent)
            'Boolean
            Case 11
                ElmType = LL_BOOLEAN
                ElmContent = IIf(ElmContent, "1", "0")
            'Anything else: Define as Text
            Case Else
                ElmType = LL_TEXT
        End Select
        
        Select Case DefineType
            Case Variable
                RaiseEvent AutoDefineVariable(DesignMode, ElmName, ElmContent, ElmType, handled)
                If Not handled Then DefineElement = ListLabel1.LlDefineVariableExt(ElmName, ElmContent, ElmType)
            Case Field
                RaiseEvent AutoDefineField(DesignMode, ElmName, ElmContent, ElmType, handled)
                If Not handled Then DefineElement = ListLabel1.LlDefineFieldExt(ElmName, ElmContent, ElmType)
        End Select
            
End Function

'Log Text to DebWin II Debugger
Public Sub Deb(ByVal Out As String)
    If DebWin2 Is Nothing Then
        Set DebWin2 = CreateObject("DEBWIN2.Automation")
    End If
    If Not DebWin2 Is Nothing Then
        DebWin2.WriteLine "cmll27VB: " & Out
    End If
End Sub



object DesExtForm: TDesExtForm
  Left = 302
  Top = 137
  Caption = 'Designer Extension Sample '
  ClientHeight = 151
  ClientWidth = 402
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 48
    Top = 53
    Width = 313
    Height = 20
    AutoSize = False
    Caption = 'This sample demonstrates how to extend the designer.'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label2: TLabel
    Left = 49
    Top = 21
    Width = 352
    Height = 20
    AutoSize = False
    Caption = 'Dieses Beispiel demonstriert die Erweiterung des Designers.'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label3: TLabel
    Left = 16
    Top = 53
    Width = 25
    Height = 20
    AutoSize = False
    Caption = 'US:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label4: TLabel
    Left = 16
    Top = 21
    Width = 25
    Height = 20
    AutoSize = False
    Caption = 'D:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object DesignButton: TButton
    Left = 16
    Top = 120
    Width = 105
    Height = 25
    Caption = '&Design'
    TabOrder = 0
    OnClick = DesignButtonClick
  end
  object chckBxDebug: TCheckBox
    Left = 272
    Top = 128
    Width = 129
    Height = 17
    Caption = 'Enable Debug Output'
    TabOrder = 1
    OnClick = chckBxDebugClick
  end
  object GradientFillObject: TLL27XObject
    Description = 'GradientFill'
    ParentComponent = LL
    PopupMenu = PopupMenu1
    Icon.Data = {
      000001000100100F000001001800340300001600000028000000100000001E00
      000001001800000000000C030000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      000000002424243636364848485A5A5A6C6C6C7F7F7F7F7F7F919191A3A3A3B5
      B5B5C8C8C8DADADA0000000000000000000000002424243636364848485A5A5A
      6C6C6C7F7F7F7F7F7F919191A3A3A3B5B5B5C8C8C8DADADA0000000000000000
      000000002424243636364848485A5A5A6C6C6C7F7F7F7F7F7F919191A3A3A3B5
      B5B5C8C8C8DADADA0000000000000000000000002424243636364848485A5A5A
      6C6C6C7F7F7F7F7F7F919191A3A3A3B5B5B5C8C8C8DADADA0000000000000000
      000000002424243636364848485A5A5A6C6C6C7F7F7F7F7F7F919191A3A3A3B5
      B5B5C8C8C8DADADA0000000000000000000000002424243636364848485A5A5A
      6C6C6C7F7F7F7F7F7F919191A3A3A3B5B5B5C8C8C8DADADA0000000000000000
      000000002424243636364848485A5A5A6C6C6C7F7F7F7F7F7F919191A3A3A3B5
      B5B5C8C8C8DADADA0000000000000000000000002424243636364848485A5A5A
      6C6C6C7F7F7F7F7F7F919191A3A3A3B5B5B5C8C8C8DADADA0000000000000000
      000000002424243636364848485A5A5A6C6C6C7F7F7F7F7F7F919191A3A3A3B5
      B5B5C8C8C8DADADA0000000000000000000000002424243636364848485A5A5A
      6C6C6C7F7F7F7F7F7F919191A3A3A3B5B5B5C8C8C8DADADA0000000000000000
      000000002424243636364848485A5A5A6C6C6C7F7F7F7F7F7F919191A3A3A3B5
      B5B5C8C8C8DADADA000000000000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      0000000000000000000000000000FFFFFFFF8001FFFF8001FFFF8001FFFF8001
      FFFF8001FFFF8001FFFF8001FFFF8001FFFF8001FFFF8001FFFF8001FFFF8001
      FFFF8001FFFFFFFFFFFF}
    ObjectName = 'GradientFill'
    SupportsMultipage = False
    OnEdit = GradientFillObjectEdit
    OnInitialCreation = GradientFillObjectInitialCreation
    OnDraw = GradientFillObjectDraw
    Left = 120
    Top = 88
  end
  object PopupMenu1: TPopupMenu
    Left = 16
    Top = 88
    object EditColor11: TMenuItem
      Caption = 'Edit Color 1'
      OnClick = EditColor1Click
    end
    object EditColor21: TMenuItem
      Caption = 'Edit Color 2'
      OnClick = EditColor2Click
    end
  end
  object ColorDialog1: TColorDialog
    Left = 48
    Top = 88
  end
  object RomanNumber: TLL27XFunction
    MinimumParameters = 1
    MaximumParameters = 1
    ResultType = ptString
    Parameter1.ParameterType = ptDouble
    Parameter1.ParameterDescription = 'Number to convert'
    Parameter2.ParameterType = ptAll
    Parameter3.ParameterType = ptAll
    Parameter4.ParameterType = ptAll
    ParentComponent = LL
    FunctionName = 'RomanNumber'
    Description = 'Returns the roman equivalent for a number'
    GroupName = 'Sample functions'
    Visible = True
    OnEvaluateFunction = RomanNumberEvaluateFunction
    OnParameterAutoComplete = RomanNumberParameterAutoComplete
    Left = 152
    Top = 88
  end
  object LL27XAction1: TLL27XAction
    AddToToolbar = True
    IconId = 642
    InsertionType = itAppend
    MenuHierachy = '1.1'
    MenuText = 'Find object'
    ParentComponent = LL
    ShortCut = 16454
    TooltipText = 'Find object'
    OnExecuteAction = LL27XAction1ExecuteAction
    Left = 184
    Top = 88
  end
  object ADOConnection1: TADOConnection
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 288
    Top = 16
  end
  object Orders: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'CustomerID'
    MasterFields = 'CustomerID'
    MasterSource = dsCustomers
    TableName = 'Orders'
    Left = 320
    Top = 48
  end
  object OrderDetails: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'OrderID'
    MasterFields = 'OrderID'
    MasterSource = dsOrders
    TableName = 'Order Details'
    Left = 320
    Top = 80
  end
  object dsCustomers: TDataSource
    DataSet = Customers
    Left = 352
    Top = 16
  end
  object dsOrders: TDataSource
    DataSet = Orders
    Left = 352
    Top = 48
  end
  object LL: TDBL27_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    AutoShowPrintOptions = No
    AutoShowSelectFile = No
    AutoDefine = Yes
    AutoDesignerPreview = Yes
    DataSource = dsCustomers
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsFields
    AutoBoxType = btStandardAbort
    Left = 88
    Top = 88
  end
  object LL27XAction3: TLL27XAction
    AddToToolbar = True
    IconId = 185
    InsertionType = itAppend
    MenuHierachy = '2'
    MenuText = 'Templates.Customer list'
    ParentComponent = LL
    ShortCut = 16457
    TooltipText = 'Generates an customer list template'
    OnExecuteAction = LL27XAction3ExecuteAction
    Left = 216
    Top = 88
  end
  object Customers: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'Customers'
    Left = 320
    Top = 16
    object CustomersCustomerID: TWideStringField
      FieldName = 'CustomerID'
      Size = 5
    end
    object CustomersContactName: TWideStringField
      FieldName = 'ContactName'
      Size = 30
    end
    object CustomersAddress: TWideStringField
      FieldName = 'Address'
      Size = 60
    end
    object CustomersCity: TWideStringField
      FieldName = 'City'
      Size = 15
    end
    object CustomersPhone: TWideStringField
      FieldName = 'Phone'
      Size = 24
    end
  end
  object LL27XAction4: TLL27XAction
    AddToToolbar = True
    IconId = 186
    InsertionType = itAppend
    MenuHierachy = '2'
    MenuText = 'Templates.Statistic'
    ParentComponent = LL
    ShortCut = 16467
    TooltipText = 'Generates a statistic template'
    OnExecuteAction = LL27XAction4ExecuteAction
    Left = 248
    Top = 88
  end
end

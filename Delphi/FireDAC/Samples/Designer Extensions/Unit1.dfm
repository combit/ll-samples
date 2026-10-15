object Form1: TForm1
  Left = 0
  Top = 0
  BorderStyle = bsDialog
  Caption = 'List & Label - VCL Designer Extension Sample'
  ClientHeight = 160
  ClientWidth = 438
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OnCreate = FormCreate
  TextHeight = 13
  object lblGermanDescription: TLabel
    Left = 63
    Top = 24
    Width = 474
    Height = 33
    AutoSize = False
    Caption = 'Dieses Beispiel demonstriert die Erweiterung des Designers.'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object lblEnglishDescription: TLabel
    Left = 63
    Top = 63
    Width = 474
    Height = 33
    AutoSize = False
    Caption = 'This sample demonstrates how to extend the designer.'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object lblGerman: TLabel
    Left = 16
    Top = 24
    Width = 25
    Height = 17
    AutoSize = False
    Caption = 'D: '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object lblEnglish: TLabel
    Left = 16
    Top = 63
    Width = 25
    Height = 17
    AutoSize = False
    Caption = 'US: '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object DesignButton: TButton
    Left = 16
    Top = 127
    Width = 105
    Height = 25
    Caption = '&Design'
    TabOrder = 0
    OnClick = DesignButtonClick
  end
  object FDConnectionNorthwind: TFDConnection
    Params.Strings = (
      'DriverID=MSAcc')
    FetchOptions.AssignedValues = [evCursorKind]
    FetchOptions.CursorKind = ckStatic
    LoginPrompt = False
    Left = 240
    Top = 96
  end
  object FDQueryOrders: TFDQuery
    MasterFields = 'OrderID'
    Connection = FDConnectionNorthwind
    FetchOptions.AssignedValues = [evCache, evUnidirectional, evCursorKind]
    FetchOptions.CursorKind = ckStatic
    FetchOptions.Cache = [fiBlobs, fiMeta]
    SQL.Strings = (
      'Select * From Orders Where (OrderID > 11040)')
    Left = 272
    Top = 96
  end
  object DataSourceOrders: TDataSource
    DataSet = FDQueryOrders
    Left = 368
    Top = 96
  end
  object FDQueryOrderDetails: TFDQuery
    MasterSource = DataSourceOrders
    MasterFields = 'OrderID'
    DetailFields = 'OrderID'
    Connection = FDConnectionNorthwind
    FetchOptions.AssignedValues = [evCache, evUnidirectional, evCursorKind]
    FetchOptions.CursorKind = ckStatic
    FetchOptions.Cache = [fiBlobs, fiMeta]
    SQL.Strings = (
      
        'SELECT [Order Details].OrderID, [Order Details].Quantity, [Order' +
        ' Details].UnitPrice, [Order Details].ProductID, Products.Product' +
        'ID AS ProductsProductID, Products.CategoryID, Products.Discontin' +
        'ued, Products.ProductName, Products.QuantityPerUnit, Products.Re' +
        'orderLevel, Products.SupplierID, Products.UnitPrice AS ProductsU' +
        'nitPrice, Products.UnitsInStock, Products.UnitsOnOrder FROM [Ord' +
        'er Details] INNER JOIN Products ON [Order Details].ProductID = P' +
        'roducts.ProductID WHERE ([Order Details].OrderID = :OrderID)')
    Left = 304
    Top = 96
    ParamData = <
      item
        Name = 'ORDERID'
        DataType = ftString
        ParamType = ptInput
        Size = 8
        Value = '11041'
      end>
  end
  object DataSourceOrderDetails: TDataSource
    DataSet = FDQueryOrderDetails
    Left = 336
    Top = 96
  end
  object ListLabel: TListLabel32
    Debug = []
    DataController.DataSource = DataSourceOrders
    DataController.DetailSources = <
      item
        Name = 'Orders'
        DataSource = DataSourceOrders
        PrimaryKeyField = 'OrderID'
        InternalOwnItems = <
          item
            Name = 'Order Details'
            DataSource = DataSourceOrderDetails
            PrimaryKeyField = 'OrderID'
            DetailKeyField = 'OrderID'
            MasterKeyField = 'OrderID'
          end>
      end>
    Left = 64
    Top = 96
  end
  object RomanNumber: TLlDesignerFunction32
    MinimumParameters = 1
    MaximumParameters = 1
    ResultType = ptString
    Parameter1.ParameterType = ptDouble
    Parameter1.ParameterDescription = 'Number to convert'
    Parameter2.ParameterType = ptAll
    Parameter3.ParameterType = ptAll
    Parameter4.ParameterType = ptAll
    ParentComponent = ListLabel
    FunctionName = 'RomanNumber'
    Description = 'Returns the roman equivalent for a number'
    GroupName = 'Sample functions'
    Visible = True
    OnEvaluateFunction = RomanNumberEvaluateFunction
    Left = 32
    Top = 96
  end
  object FindObjectAction: TLDesignerAction32
    AddToToolbar = False
    IconId = 642
    InsertionType = itAppend
    MenuHierachy = '1.1'
    MenuText = 'Find object'
    ParentComponent = ListLabel
    ShortCut = 16454
    OnExecuteAction = FindObjectActionExecuteAction
    Left = 96
    Top = 96
  end
  object GradientFillObject: TLlDesignerObject32
    Description = 'GradientFill'
    ParentComponent = ListLabel
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
    OnDraw = GradientFillObjectDraw
    Left = 128
    Top = 96
  end
end

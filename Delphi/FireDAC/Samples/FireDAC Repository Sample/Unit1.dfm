object Form1: TForm1
  Left = 0
  Top = 0
  BorderStyle = bsDialog
  Caption = 'List & Label - VCL DataSet Sample Repository'
  ClientHeight = 200
  ClientWidth = 580
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
    Top = 8
    Width = 474
    Height = 57
    AutoSize = False
    Caption = 
      'Das Beispiel zeigt die Verwendung von List && Label im Repositor' +
      'y-Modus. Beim Klick auf '#39'Design'#39' w'#228'hlen Sie den zu '#246'ffnenden Ber' +
      'icht direkt aus der Datenbank der Elementsammlung. Die darin ent' +
      'haltenen Elemente wie Berichtsvorlagen etc. k'#246'nnen anschlie'#223'end ' +
      'im Designer '#252'ber '#39'Datei > Elementsammlung bearbeiten'#39' verwaltet ' +
      'werden.'
    WordWrap = True
  end
  object lblEnglishDescription: TLabel
    Left = 63
    Top = 71
    Width = 474
    Height = 50
    AutoSize = False
    Caption = 
      'The example shows the use of List && Label in repository mode. C' +
      'lick on '#39'Design'#39' to select the report to be opened directly from' +
      ' the repository database. The items it contains, such as report ' +
      'templates etc., can then be managed in the Designer via '#39'File > ' +
      'Edit Repository'#39'.'
    WordWrap = True
  end
  object lblGerman: TLabel
    Left = 16
    Top = 8
    Width = 25
    Height = 17
    AutoSize = False
    Caption = 'D: '
  end
  object lblEnglish: TLabel
    Left = 16
    Top = 71
    Width = 25
    Height = 17
    AutoSize = False
    Caption = 'US: '
  end
  object btnDesignInvoiceAndItemsList: TButton
    Left = 462
    Top = 151
    Width = 75
    Height = 25
    Caption = 'Design...'
    TabOrder = 0
    OnClick = btnDesignInvoiceAndItemsListClick
  end
  object FDConnectionNorthwind: TFDConnection
    Params.Strings = (
      'DriverID=MSAcc')
    FetchOptions.AssignedValues = [evCursorKind]
    FetchOptions.CursorKind = ckStatic
    LoginPrompt = False
    Left = 48
    Top = 144
  end
  object FDQueryOrders: TFDQuery
    MasterFields = 'OrderID'
    Connection = FDConnectionNorthwind
    FetchOptions.AssignedValues = [evCache, evUnidirectional, evCursorKind]
    FetchOptions.CursorKind = ckStatic
    FetchOptions.Cache = [fiBlobs, fiMeta]
    SQL.Strings = (
      'Select * From Orders Where (OrderID > 11040)')
    Left = 80
    Top = 144
  end
  object DataSourceOrders: TDataSource
    DataSet = FDQueryOrders
    Left = 144
    Top = 144
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
    Left = 112
    Top = 144
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
    Left = 184
    Top = 144
  end
  object ListLabel: TListLabel31
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
    Left = 8
    Top = 144
  end
  object DataSourceRepository: TDataSource
    DataSet = FDQueryRepository
    Left = 224
    Top = 144
  end
  object FDQueryRepository: TFDQuery
    IndexFieldNames = 'Id;InternalId'
    Connection = FDConnectionRepository
    FetchOptions.AssignedValues = [evCache, evUnidirectional, evCursorKind]
    SQL.Strings = (
      'select * from [LL$Repository]')
    Left = 312
    Top = 144
  end
  object FDConnectionRepository: TFDConnection
    Params.Strings = (
      'DriverID=MSAcc')
    Left = 272
    Top = 144
  end
end

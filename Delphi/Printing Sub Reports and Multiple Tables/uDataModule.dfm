object DataModule1: TDataModule1
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  OnDestroy = DataModuleDestroy
  Left = 452
  Top = 194
  Height = 244
  Width = 272
  object dsProducts: TDataSource
    DataSet = Products
    Left = 208
    Top = 111
  end
  object ADOConnection1: TADOConnection
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\NWIND.MDB;Per' +
      'sist Security Info=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    OnConnectComplete = ADOConnection1ConnectComplete
    Left = 128
    Top = 8
  end
  object Products: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'ProductID'
    MasterFields = 'ProductID'
    MasterSource = dsOrderDetails
    TableName = 'Products'
    Left = 208
    Top = 152
  end
  object OrderDetails: TADOTable
    Connection = ADOConnection1
    IndexFieldNames = 'OrderID'
    MasterFields = 'OrderID'
    MasterSource = dsOrders
    TableName = 'Order Details'
    Left = 144
    Top = 152
    object OrderDetailsOrderID: TIntegerField
      FieldName = 'OrderID'
    end
    object OrderDetailsProductID: TIntegerField
      FieldName = 'ProductID'
    end
    object OrderDetailsUnitPrice: TBCDField
      FieldName = 'UnitPrice'
      Precision = 19
    end
    object OrderDetailsQuantity: TSmallintField
      FieldName = 'Quantity'
    end
    object OrderDetailsDiscount: TFloatField
      FieldName = 'Discount'
    end
    object OrderDetailsProductNameProductsProductIDProductName: TStringField
      FieldKind = fkLookup
      FieldName = 'ProductID@Products.ProductID:ProductName'
      LookupDataSet = Products
      LookupKeyFields = 'ProductID'
      LookupResultField = 'ProductName'
      KeyFields = 'ProductID'
      Lookup = True
    end
  end
  object Orders: TADOTable
    Connection = ADOConnection1
    IndexFieldNames = 'CustomerID'
    MasterFields = 'CustomerID'
    MasterSource = dsCustomers
    TableName = 'Orders'
    Left = 80
    Top = 152
  end
  object Customers: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'Customers'
    Left = 24
    Top = 152
  end
  object dsOrderDetails: TDataSource
    DataSet = OrderDetails
    Left = 144
    Top = 112
  end
  object dsOrders: TDataSource
    DataSet = Orders
    Left = 80
    Top = 112
  end
  object dsCustomers: TDataSource
    DataSet = Customers
    Left = 24
    Top = 112
  end
end

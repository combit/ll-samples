object Form1: TForm1
  Left = 352
  Top = 285
  Width = 501
  Height = 210
  Caption = 'List & Label Databinding Sample'
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
    Left = 16
    Top = 112
    Width = 11
    Height = 15
    Caption = 'D:'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 48
    Top = 112
    Width = 425
    Height = 33
    AutoSize = False
    Caption = 
      'Dieses Beispiel demonstriert die Verwendung des datenbankgebunde' +
      'nen List && Label Controls'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label3: TLabel
    Left = 16
    Top = 144
    Width = 19
    Height = 15
    Caption = 'US:'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label4: TLabel
    Left = 48
    Top = 144
    Width = 425
    Height = 25
    AutoSize = False
    Caption = 
      'This example shows the usage of the database bound List && Label' +
      ' control'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object GroupBox1: TGroupBox
    Left = 16
    Top = 8
    Width = 217
    Height = 73
    Caption = 'Invoice Merge'
    TabOrder = 0
    object DesignIL: TButton
      Left = 16
      Top = 32
      Width = 75
      Height = 25
      Caption = 'Design...'
      TabOrder = 0
      OnClick = DesignILClick
    end
    object PrintIL: TButton
      Left = 120
      Top = 32
      Width = 75
      Height = 25
      Caption = 'Print...'
      TabOrder = 1
      OnClick = PrintILClick
    end
  end
  object GroupBox2: TGroupBox
    Left = 256
    Top = 8
    Width = 217
    Height = 73
    Caption = 'Customer Invoice List'
    TabOrder = 1
    object DesignIIL: TButton
      Left = 16
      Top = 32
      Width = 75
      Height = 25
      Caption = 'Design...'
      TabOrder = 0
      OnClick = DesignIILClick
    end
    object PrintIIL: TButton
      Left = 120
      Top = 32
      Width = 75
      Height = 25
      Caption = 'Print...'
      TabOrder = 1
      OnClick = PrintIILClick
    end
  end
  object DBL29_1: TDBL29_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    AutoShowPrintOptions = No
    AutoShowSelectFile = No
    AutoDefine = Yes
    DataSource = dsCustomers
    AutoDesignerFile = 'inv_var.lst'
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsVariables
    AutoBoxType = btStandardAbort
    Left = 184
    Top = 16
  end
  object DBL29_2: TDBL29_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    AutoShowPrintOptions = No
    AutoShowSelectFile = No
    AutoDefine = Yes
    DataSource = dsCustomers
    AutoDesignerFile = 'inv_fie.lst'
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsFields
    AutoBoxType = btStandardAbort
    Left = 440
    Top = 16
  end
  object dsOrders: TDataSource
    DataSet = Orders
    Left = 280
    Top = 104
  end
  object dsCustomers: TDataSource
    DataSet = Customers
    Left = 248
    Top = 104
  end
  object dsOrderDetails: TDataSource
    DataSet = OrderDetails
    Left = 312
    Top = 104
  end
  object dsProducts: TDataSource
    DataSet = Products
    Left = 344
    Top = 104
  end
  object Customers: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    Filter = 'CustomerID<'#39'D'#39
    Filtered = True
    TableName = 'Customers'
    Left = 248
    Top = 136
  end
  object ADOConnection1: TADOConnection
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=..\..' +
      '\NWIND.MDB;Mode=Share Deny None;Extended Properties="";Persist S' +
      'ecurity Info=False;Jet OLEDB:System database="";Jet OLEDB:Regist' +
      'ry Path="";Jet OLEDB:Database Password="";Jet OLEDB:Engine Type=' +
      '5;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Global Partial Bul' +
      'k Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Datab' +
      'ase Password="";Jet OLEDB:Create System Database=False;Jet OLEDB' +
      ':Encrypt Database=False;Jet OLEDB:Don'#39't Copy Locale on Compact=F' +
      'alse;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SF' +
      'P=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 376
    Top = 120
  end
  object Orders: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    MasterFields = 'CustomerID'
    MasterSource = dsCustomers
    TableName = 'Orders'
    Left = 280
    Top = 136
  end
  object OrderDetails: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    MasterFields = 'OrderID'
    MasterSource = dsOrders
    TableName = 'Order Details'
    Left = 312
    Top = 136
  end
  object Products: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    MasterFields = 'ProductID'
    MasterSource = dsOrderDetails
    TableName = 'Products'
    Left = 344
    Top = 136
  end
end

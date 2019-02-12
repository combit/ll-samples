object Form1: TForm1
  Left = 352
  Top = 285
  Width = 505
  Height = 231
  Caption = 'List & Label Crosstab Sample'
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
    Left = 8
    Top = 24
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
    Left = 40
    Top = 24
    Width = 425
    Height = 49
    AutoSize = False
    Caption = 
      'Dieses Beispiel demonstriert die Verwendung einer Kreuztabelle i' +
      'nnerhalb des Berichtscontainers mit Hilfe des datenbankgebundene' +
      'n List && Label Controls'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label3: TLabel
    Left = 8
    Top = 88
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
    Left = 40
    Top = 88
    Width = 425
    Height = 33
    AutoSize = False
    Caption = 
      'This example shows the usage of a crosstab within the report con' +
      'tainer via the database bound List && Label control'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object btnDesign: TButton
    Left = 89
    Top = 152
    Width = 131
    Height = 25
    Caption = 'Design'
    TabOrder = 0
    OnClick = btnDesignClick
  end
  object btnPrint: TButton
    Left = 265
    Top = 152
    Width = 131
    Height = 25
    Caption = 'Print'
    TabOrder = 1
    OnClick = btnPrintClick
  end
  object LL: TDBL24_
    DebugMode = 1
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    OnExprError = LLExprError
    AutoShowPrintOptions = No
    AutoShowSelectFile = Yes
    AutoDefine = Yes
    DataSource = dsCustomers
    AutoDesignerFile = 'crosstab.lst'
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsFields
    AutoBoxType = btStandardAbort
    Left = 8
    Top = 144
  end
  object dsOrders: TDataSource
    DataSet = Orders
    Left = 392
    Top = 120
  end
  object dsCustomers: TDataSource
    DataSet = Customers
    Left = 360
    Top = 120
  end
  object dsOrderDetails: TDataSource
    DataSet = OrderDetails
    Left = 424
    Top = 120
  end
  object Customers: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    Filter = 'CustomerID<'#39'C'#39
    Filtered = True
    TableName = 'Customers'
    Left = 360
    Top = 152
  end
  object ADOConnection1: TADOConnection
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=..\..' +
      '\NWIND.MDB;Mode=Share Deny None;Extended Properties="";Persist S' +
      'ecurity Info=False;Jet OLEDB:System database="";Jet OLEDB:Regist' +
      'ry Path="";Jet OLEDB:Database Password="";Jet OLEDB:Engine Type=' +
      '4;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Global Partial Bul' +
      'k Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Datab' +
      'ase Password="";Jet OLEDB:Create System Database=False;Jet OLEDB' +
      ':Encrypt Database=False;Jet OLEDB:Don'#39't Copy Locale on Compact=F' +
      'alse;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SF' +
      'P=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 464
    Top = 136
  end
  object Orders: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    MasterFields = 'CustomerID'
    MasterSource = dsCustomers
    TableName = 'Orders'
    Left = 392
    Top = 152
  end
  object OrderDetails: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    MasterFields = 'OrderID'
    MasterSource = dsOrders
    TableName = 'Order Details'
    Left = 424
    Top = 152
  end
end

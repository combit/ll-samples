object frmCrosstab: TfrmCrosstab
  Left = 313
  Top = 278
  Caption = 'List & Label Crosstab Sample'
  ClientHeight = 161
  ClientWidth = 487
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 24
    Width = 11
    Height = 13
    Caption = 'D:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 54
    Top = 24
    Width = 417
    Height = 41
    AutoSize = False
    Caption = 
      'Dieses Beispiel demonstriert die Verwendung einer Kreuztabelle i' +
      'nnerhalb des Berichtscontainers mit Hilfe des datenbankgebundene' +
      'n List && Label Controls'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label3: TLabel
    Left = 54
    Top = 80
    Width = 417
    Height = 25
    AutoSize = False
    Caption = 
      'This example shows the usage of a crosstab within the report con' +
      'tainer via the database bound List && Label control'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label4: TLabel
    Left = 8
    Top = 80
    Width = 18
    Height = 13
    Caption = 'US:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object btnPrintIL: TButton
    Left = 249
    Top = 128
    Width = 130
    Height = 25
    Caption = 'Print...'
    TabOrder = 0
    OnClick = btnPrintILClick
  end
  object btnDesignIL: TButton
    Left = 88
    Top = 128
    Width = 130
    Height = 25
    Caption = 'Design...'
    TabOrder = 1
    OnClick = btnDesignILClick
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
    Left = 384
    Top = 8
  end
  object ADOTblCustomers: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    Filter = 'CustomerID<'#39'D'#39
    Filtered = True
    TableName = 'Customers'
    Left = 384
    Top = 40
  end
  object ADOTblOrders: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'CustomerID'
    MasterFields = 'CustomerID'
    MasterSource = dsCustomers
    TableName = 'Orders'
    Left = 416
    Top = 40
  end
  object ADOTblOrderDetails: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'OrderID'
    MasterFields = 'OrderID'
    MasterSource = dsOrders
    TableName = 'Order Details'
    Left = 448
    Top = 40
  end
  object dsCustomers: TDataSource
    DataSet = ADOTblCustomers
    Left = 384
    Top = 72
  end
  object dsOrders: TDataSource
    DataSet = ADOTblOrders
    Left = 416
    Top = 72
  end
  object DBl27_1: TDBl27_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    AutoShowPrintOptions = No
    AutoShowSelectFile = No
    AutoDefine = Yes
    DataSource = dsCustomers
    AutoDesignerFile = 'crosstab.lst'
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsFields
    AutoBoxType = btStandardAbort
    Left = 344
    Top = 8
  end
end

object frmDatbind: TfrmDatbind
  Left = 269
  Top = 216
  Caption = 'List & Label Databinding Sample'
  ClientHeight = 209
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
    Top = 112
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
    Top = 112
    Width = 417
    Height = 25
    AutoSize = False
    Caption = 
      'Dieses Beispiel demonstriert die Verwendung des datenbankgebunde' +
      'nen List && Label Controls'
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
    Top = 152
    Width = 417
    Height = 25
    AutoSize = False
    Caption = 
      'This example shows the usage of the database bound List && Label' +
      ' control'
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
    Top = 152
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
  object GroupBox1: TGroupBox
    Left = 8
    Top = 24
    Width = 209
    Height = 65
    Caption = 'Invoice Merge'
    TabOrder = 0
    object btnDesignIL: TButton
      Left = 16
      Top = 24
      Width = 75
      Height = 25
      Caption = 'Design...'
      TabOrder = 0
      OnClick = btnDesignILClick
    end
    object btnPrintIL: TButton
      Left = 113
      Top = 24
      Width = 75
      Height = 25
      Caption = 'Print...'
      TabOrder = 1
      OnClick = btnPrintILClick
    end
  end
  object GroupBox2: TGroupBox
    Left = 243
    Top = 24
    Width = 220
    Height = 65
    Caption = 'Customer Invoice List'
    TabOrder = 1
    object btnDesignIIL: TButton
      Left = 24
      Top = 24
      Width = 75
      Height = 25
      Caption = 'Design...'
      TabOrder = 0
      OnClick = btnDesignIILClick
    end
    object btnPrintIIL: TButton
      Left = 120
      Top = 24
      Width = 75
      Height = 25
      Caption = 'Print...'
      TabOrder = 1
      OnClick = btnPrintIILClick
    end
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
    Left = 216
    Top = 104
  end
  object ADOTblCustomers: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    Filter = 'CustomerID<'#39'D'#39
    Filtered = True
    TableName = 'Customers'
    Left = 216
    Top = 136
  end
  object ADOTblOrders: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'CustomerID'
    MasterFields = 'CustomerID'
    MasterSource = dsCustomers
    TableName = 'Orders'
    Left = 248
    Top = 136
  end
  object ADOTblOrderDetails: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'OrderID'
    MasterFields = 'OrderID'
    MasterSource = dsOrders
    TableName = 'Order Details'
    Left = 280
    Top = 136
  end
  object ADOTblProducts: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'ProductID'
    MasterFields = 'ProductID'
    MasterSource = dsOrderDetails
    TableName = 'Products'
    Left = 312
    Top = 136
  end
  object dsCustomers: TDataSource
    DataSet = ADOTblCustomers
    Left = 216
    Top = 168
  end
  object dsOrders: TDataSource
    DataSet = ADOTblOrders
    Left = 248
    Top = 168
  end
  object dsOrderDetails: TDataSource
    DataSet = ADOTblOrderDetails
    Left = 280
    Top = 168
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
    AutoDesignerFile = 'inv_var.lst'
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsVariables
    AutoBoxType = btStandardAbort
    Left = 160
    Top = 16
  end
  object DBl27_2: TDBl27_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
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
    Left = 408
    Top = 16
  end
end

object frmDesignerPreview: TfrmDesignerPreview
  Left = 148
  Top = 82
  Caption = 'List & Label Designer Preview Sample'
  ClientHeight = 118
  ClientWidth = 465
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
    Top = 16
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
    Top = 16
    Width = 369
    Height = 25
    AutoSize = False
    Caption = 'Dieses Beispiel demonstriert den Echtdatendruck im Designer.'
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
    Top = 48
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
    Top = 48
    Width = 409
    Height = 25
    AutoSize = False
    Caption = 
      'This example demonstrate the real data preview  within the desig' +
      'ner.'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object DesignIL: TButton
    Left = 56
    Top = 88
    Width = 75
    Height = 25
    Caption = 'Design...'
    TabOrder = 0
    OnClick = DesignILClick
  end
  object dsCustomers: TDataSource
    DataSet = Customers
    Left = 320
    Top = 8
  end
  object Customers: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    Filter = 'CustomerID<'#39'T'#39
    Filtered = True
    TableName = 'Customers'
    Left = 320
    Top = 40
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
    Left = 368
    Top = 24
  end
  object LLDesign: TL30_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    OnDesignerPrintJob = LLDesignDesignerPrintJob
    Left = 248
    Top = 8
  end
  object LLDesignerPrint: TL30_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    Left = 248
    Top = 40
  end
end

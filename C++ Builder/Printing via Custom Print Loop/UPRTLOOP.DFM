object frmPrtloop: TfrmPrtloop
  Left = 375
  Top = 279
  Caption = 'List & Label Print Loop Demo'
  ClientHeight = 132
  ClientWidth = 501
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 16
    Top = 8
    Width = 14
    Height = 13
    Caption = 'D:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 16
    Top = 56
    Width = 22
    Height = 13
    Caption = 'US:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label3: TLabel
    Left = 48
    Top = 8
    Width = 427
    Height = 26
    Caption = 
      'Dieses Beispiel demonstriert das Designen und Drucken von Etiket' +
      'ten und Listen  '#252'ber eine eigen Druckschleife'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label4: TLabel
    Left = 48
    Top = 56
    Width = 400
    Height = 26
    Caption = 
      'This example demonstrates how to design and print lables and rep' +
      'orts using a custom print loop'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object DebugCheckBox: TCheckBox
    Left = 376
    Top = 104
    Width = 97
    Height = 17
    Caption = '&Debug output'
    TabOrder = 0
    OnClick = DebugCheckBoxClick
  end
  object MainMenu1: TMainMenu
    Left = 120
    Top = 88
    object File1: TMenuItem
      Caption = '&File'
      object Exit1: TMenuItem
        Caption = 'Exit'
        OnClick = Exit1Click
      end
    end
    object Edit1: TMenuItem
      Caption = '&Edit'
      object Label5: TMenuItem
        Caption = 'Label...'
        OnClick = Label5Click
      end
      object Report1: TMenuItem
        Caption = 'Report...'
        OnClick = Report1Click
      end
    end
    object Print1: TMenuItem
      Caption = '&Print'
      object Label6: TMenuItem
        Caption = 'Label...'
        OnClick = Label6Click
      end
      object Report2: TMenuItem
        Caption = 'Report...'
        OnClick = Report2Click
      end
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
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 56
    Top = 88
  end
  object ADOTblCustomers: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'Customers'
    Left = 88
    Top = 88
  end
  object LL: Tl24_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    Left = 24
    Top = 88
  end
end

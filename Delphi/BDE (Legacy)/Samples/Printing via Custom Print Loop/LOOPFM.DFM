object Form1: TForm1
  Left = 204
  Top = 108
  Caption = 'List & Label Print Loop Demo'
  ClientHeight = 122
  ClientWidth = 431
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = True
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label6: TLabel
    Left = 31
    Top = 72
    Width = 143
    Height = 15
    Caption = 'using a custom print loop'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label5: TLabel
    Left = 8
    Top = 56
    Width = 422
    Height = 15
    Caption = 
      'US: This example demonstrates how to design and print labels and' +
      ' reports'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label4: TLabel
    Left = 31
    Top = 32
    Width = 238
    Height = 15
    Caption = 'und Listen '#252'ber eine eigene Druckschleife'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label3: TLabel
    Left = 8
    Top = 16
    Width = 412
    Height = 15
    Caption = 
      'D:  Dieses Beispiel demonstriert das Designen und Drucken von Et' +
      'iketten'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object DebugCheckBox: TCheckBox
    Left = 344
    Top = 104
    Width = 89
    Height = 18
    Caption = '&Debug output'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    OnClick = DebugCheckBoxClick
  end
  object LL: TL26_
    SortVariables = Yes
    UnitSystem = usHiInch
    CompressStorage = Yes
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    Left = 32
    Top = 88
  end
  object MainMenu1: TMainMenu
    Top = 88
    object File1: TMenuItem
      Caption = '&File'
      object Exit1: TMenuItem
        Caption = '&Exit'
        OnClick = Exit1Click
      end
    end
    object Edit1: TMenuItem
      Caption = '&Edit'
      object Label1: TMenuItem
        Caption = '&Label...'
        OnClick = Label1Click
      end
      object Report1: TMenuItem
        Caption = '&Report...'
        OnClick = Report1Click
      end
    end
    object Print1: TMenuItem
      Caption = '&Print'
      object Label2: TMenuItem
        Caption = '&Label...'
        OnClick = Label2Click
      end
      object Report2: TMenuItem
        Caption = '&Report...'
        OnClick = Report2Click
      end
    end
  end
  object ADOTableArticle: TADOTable
    Connection = ADOConnection1
    Left = 64
    Top = 88
  end
  object ADOConnection1: TADOConnection
    Left = 96
    Top = 88
  end
end

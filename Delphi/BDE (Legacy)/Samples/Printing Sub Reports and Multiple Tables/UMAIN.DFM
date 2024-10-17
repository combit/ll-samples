object frmMultipleTables: TfrmMultipleTables
  Left = 494
  Top = 382
  Caption = 'List & Label Subreport Demo'
  ClientHeight = 127
  ClientWidth = 418
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnClose = FormClose
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label5: TLabel
    Left = 8
    Top = 56
    Width = 403
    Height = 15
    Caption = 
      'US: This example demonstrates printing subreports und multiple t' +
      'ables'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label4: TLabel
    Left = 27
    Top = 32
    Width = 48
    Height = 15
    Caption = 'Tabellen'
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
    Width = 396
    Height = 15
    Caption = 
      'D:  Dieses Beispiel zeigt den Umgang mit Unterberichten und mehre' +
      'ren'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object DebugCheckBox: TCheckBox
    Left = 320
    Top = 80
    Width = 89
    Height = 17
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
  object MainMenu1: TMainMenu
    Left = 232
    Top = 72
    object File1: TMenuItem
      Caption = '&File'
      object Exit1: TMenuItem
        Caption = '&Exit'
        OnClick = Exit1Click
      end
    end
    object Edit1: TMenuItem
      Caption = '&Edit'
      object Report1: TMenuItem
        Caption = '&Report...'
        OnClick = Report1Click
      end
    end
    object Print1: TMenuItem
      Caption = '&Print'
      object Report2: TMenuItem
        Caption = '&Report...'
        OnClick = Report2Click
      end
    end
  end
  object LL: TL30_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    Left = 264
    Top = 72
  end
end

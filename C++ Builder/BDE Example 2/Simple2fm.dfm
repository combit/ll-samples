object Form1: TForm1
  Left = 254
  Top = 192
  Width = 495
  Height = 183
  Caption = 'List & Label - Simple List Sample'
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
    Top = 32
    Width = 449
    Height = 16
    Caption = 
      'D:   Dieses Beispiel demonstriert das Designen und Drucken von Li' +
      'sten'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -13
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 10
    Top = 72
    Width = 383
    Height = 16
    Caption = 'US: This example demonstrates how to design and print lists'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -13
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object DesignButton: TButton
    Left = 8
    Top = 120
    Width = 89
    Height = 25
    Caption = '&Design...'
    TabOrder = 0
    OnClick = DesignButtonClick
  end
  object PreviewButton: TButton
    Left = 104
    Top = 120
    Width = 89
    Height = 25
    Caption = 'Pre&view...'
    TabOrder = 1
    OnClick = PreviewButtonClick
  end
  object PrintButton: TButton
    Left = 200
    Top = 120
    Width = 89
    Height = 25
    Caption = '&Print...'
    TabOrder = 2
    OnClick = PrintButtonClick
  end
  object DebugCheckBox: TCheckBox
    Left = 368
    Top = 123
    Width = 97
    Height = 17
    Caption = 'D&ebug output'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    OnClick = DebugCheckBoxClick
  end
  object DataSource: TTable
    Left = 408
  end
  object LL: Tl25_
    SortVariables = Yes
    UnitSystem = usHiInch
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    OnDefineFields = LLDefineFields
    Left = 440
  end
end

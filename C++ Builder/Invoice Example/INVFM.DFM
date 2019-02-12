object Form1: TForm1
  Left = 304
  Top = 187
  Width = 465
  Height = 267
  Caption = 'List & Label - Advanced Invoice Sample'
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
    Top = 8
    Width = 438
    Height = 15
    Caption = 
      'D:   Dieses Beispiel demonstriert das Designen und Drucken von Re' +
      'chnungen'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 8
    Top = 32
    Width = 366
    Height = 15
    Caption = 'US: This example demonstrates how to design and print invoices'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label3: TLabel
    Left = 8
    Top = 80
    Width = 43
    Height = 15
    Caption = 'Invoice:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object InvoiceList: TListBox
    Left = 56
    Top = 80
    Width = 385
    Height = 105
    ItemHeight = 13
    TabOrder = 0
  end
  object DesignButton: TButton
    Left = 8
    Top = 200
    Width = 89
    Height = 25
    Caption = '&Design...'
    TabOrder = 1
    OnClick = DesignButtonClick
  end
  object PreviewButton: TButton
    Left = 104
    Top = 200
    Width = 89
    Height = 25
    Caption = 'Pre&view...'
    TabOrder = 2
    OnClick = PreviewButtonClick
  end
  object PrintButton: TButton
    Left = 200
    Top = 200
    Width = 89
    Height = 25
    Caption = '&Print...'
    TabOrder = 3
    OnClick = PrintButtonClick
  end
  object DebugCheckBox: TCheckBox
    Left = 352
    Top = 203
    Width = 89
    Height = 17
    Caption = 'D&ebug output'
    TabOrder = 4
    OnClick = DebugCheckBoxClick
  end
  object InvoiceTable: TTable
    Left = 352
    Top = 48
  end
  object ItemsTable: TTable
    Left = 384
    Top = 48
  end
  object LL: Tl24_
    SortVariables = Yes
    UnitSystem = usHiInch
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    Left = 416
    Top = 48
  end
end

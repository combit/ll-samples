object Form1: TForm1
  Left = 1356
  Top = 109
  Caption = 'List & Label Quiet Export Sample'
  ClientHeight = 166
  ClientWidth = 447
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = True
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 10
    Top = 7
    Width = 438
    Height = 16
    Caption = 
      'D: Dieses Beispiel zeigt den Export ohne weitere Benutzerinterak' +
      'tion'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -13
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 10
    Top = 35
    Width = 420
    Height = 16
    Caption = 'US: This example demonstrates an export without user interaction'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -13
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label3: TLabel
    Left = 12
    Top = 67
    Width = 35
    Height = 13
    Caption = 'Format:'
  end
  object Label4: TLabel
    Left = 12
    Top = 98
    Width = 45
    Height = 13
    Caption = 'Filename:'
  end
  object FormatCombo: TComboBox
    Left = 76
    Top = 67
    Width = 285
    Height = 21
    Style = csDropDownList
    TabOrder = 0
    OnChange = FormatComboChange
    Items.Strings = (
      'PDF'
      'MHTML'
      'RTF'
      'XML'
      'Multi-TIFF'
      'Text'
      'XLS'
      'PRV')
  end
  object Edit1: TEdit
    Left = 76
    Top = 99
    Width = 285
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object FileSelectBtn: TButton
    Left = 367
    Top = 97
    Width = 72
    Height = 23
    Caption = 'Choose...'
    TabOrder = 2
    OnClick = FileSelectBtnClick
  end
  object GoBtn: TButton
    Left = 12
    Top = 139
    Width = 81
    Height = 25
    Caption = 'Create File'
    TabOrder = 3
    OnClick = GoBtnClick
  end
  object CheckShowFile: TCheckBox
    Left = 108
    Top = 139
    Width = 141
    Height = 25
    Caption = 'Show File after Creation'
    TabOrder = 4
  end
  object LL: TL30_
    SortVariables = Yes
    UnitSystem = usHiInch
    CompressStorage = Yes
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    OnDefineFields = LLDefineFields
    OnSetPrintOptions = LLSetPrintOptions
    Left = 389
    Top = 139
  end
  object SaveDialog1: TSaveDialog
    Left = 325
    Top = 139
  end
  object ADOConnection1: TADOConnection
    Left = 360
    Top = 144
  end
  object ADOTableArticle: TADOTable
    Connection = ADOConnection1
    Left = 288
    Top = 136
  end
end

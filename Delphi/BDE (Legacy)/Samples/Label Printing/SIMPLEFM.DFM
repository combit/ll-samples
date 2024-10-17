object Form1: TForm1
  Left = 255
  Top = 145
  BorderStyle = bsDialog
  Caption = 'List & Label - Simple Label Sample'
  ClientHeight = 166
  ClientWidth = 480
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = True
  Position = poScreenCenter
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 32
    Width = 460
    Height = 16
    Caption = 
      'D:  Dieses Beispiel demonstriert das Designen und Drucken von Et' +
      'iketten'
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
    Width = 397
    Height = 16
    Caption = 'US: This example demonstrates how to design and print labels'
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
    Left = 376
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
  object LL: TDBL30_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    AutoShowPrintOptions = Yes
    AutoShowSelectFile = Yes
    AutoDefine = Yes
    AutoDesignerPreview = Yes
    AutoProjectType = ptLabelProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsVariables
    AutoBoxType = btStandardAbort
    Left = 304
  end
  object ADOConnection1: TADOConnection
    Left = 336
  end
  object ADOTableArticle: TADOTable
    Connection = ADOConnection1
    Left = 368
  end
  object dsProducts: TDataSource
    DataSet = ADOTableArticle
    Left = 264
    Top = 8
  end
end

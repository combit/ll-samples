object Form1: TForm1
  Left = 210
  Top = 112
  BorderStyle = bsSingle
  Caption = 'List & Label RTF Demo'
  ClientHeight = 461
  ClientWidth = 638
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
    Left = 32
    Top = 408
    Width = 485
    Height = 16
    Caption = 
      'D:   Dieses Beispiel demonstriert die Verwendung des Inplace-RTF' +
      '-Designers'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -13
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 32
    Top = 432
    Width = 400
    Height = 16
    Caption = 'US: This example shows the usage of the inplace RTF designer'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -13
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object LoadButton: TButton
    Left = 8
    Top = 360
    Width = 75
    Height = 27
    Caption = '&Load...'
    TabOrder = 0
    OnClick = LoadButtonClick
  end
  object DesignButton: TButton
    Left = 128
    Top = 360
    Width = 75
    Height = 27
    Caption = '&Design...'
    Enabled = False
    TabOrder = 1
    OnClick = DesignButtonClick
  end
  object PreviewButton: TButton
    Left = 248
    Top = 360
    Width = 75
    Height = 27
    Caption = 'Pre&view...'
    Enabled = False
    TabOrder = 2
    OnClick = PreviewButtonClick
  end
  object PrintButton: TButton
    Left = 368
    Top = 360
    Width = 75
    Height = 27
    Caption = '&Print...'
    Enabled = False
    TabOrder = 3
    OnClick = PrintButtonClick
  end
  object RTF: TLL30RTFObject
    Left = 8
    Top = 8
    Width = 617
    Height = 337
    TabOrder = 4
    ParentComponent = LL
    TextMode = tmRTF
    ContentMode = cmEvaluated
  end
  object OpenDialog1: TOpenDialog
    DefaultExt = 'rtf'
    FileName = '*.rtf'
    Filter = 'RTF-Files|(*.rtf)'
    Title = 'Select File...'
    Left = 600
    Top = 360
  end
  object LL: TL30_
    SortVariables = Yes
    UnitSystem = usHiInch
    CompressStorage = Yes
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    OnDefineVariables = LLDefineVariables
    Left = 568
    Top = 360
  end
end

object ColorSelectForm: TColorSelectForm
  Left = 411
  Top = 207
  Width = 190
  Height = 131
  Caption = 'Select Colors'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 169
    Height = 57
    Caption = 'Color Selection'
    TabOrder = 0
    object Button1: TButton
      Left = 8
      Top = 16
      Width = 73
      Height = 25
      Caption = 'Color 1'
      TabOrder = 0
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 88
      Top = 16
      Width = 73
      Height = 25
      Caption = 'Color 2'
      TabOrder = 1
      OnClick = Button2Click
    end
  end
  object Button3: TButton
    Left = 8
    Top = 72
    Width = 81
    Height = 25
    Caption = 'OK'
    ModalResult = 1
    TabOrder = 1
  end
  object Button4: TButton
    Left = 96
    Top = 72
    Width = 81
    Height = 25
    Caption = 'Cancel'
    ModalResult = 2
    TabOrder = 2
  end
  object ColorDialog1: TColorDialog
    Ctl3D = True
  end
  object ColorDialog2: TColorDialog
    Ctl3D = True
    Left = 24
  end
end

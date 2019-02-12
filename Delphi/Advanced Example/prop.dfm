object SelectColorForm: TSelectColorForm
  Left = 342
  Top = 197
  BorderIcons = []
  BorderStyle = bsDialog
  Caption = 'Properties'
  ClientHeight = 165
  ClientWidth = 249
  Font.Color = clBlack
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = [fsBold]
  PixelsPerInch = 96
  Position = poScreenCenter
  TextHeight = 13
  object OKButton: TButton
    Left = 24
    Top = 128
    Width = 89
    Height = 25
    Caption = '&OK'
    TabOrder = 0
    OnClick = OKButtonClick
  end
  object CancelButton: TButton
    Left = 136
    Top = 128
    Width = 89
    Height = 25
    Caption = '&Cancel'
    ModalResult = 2
    TabOrder = 1
  end
  object ColorGroup: TRadioGroup
    Left = 24
    Top = 8
    Width = 201
    Height = 113
    Caption = 'Select Fill Color'
    ItemIndex = 0
    Items.Strings = (
      'Red'
      'Green'
      'Blue')
    TabOrder = 2
  end
end

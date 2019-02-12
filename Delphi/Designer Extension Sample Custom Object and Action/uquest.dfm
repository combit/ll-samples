object frmquest: Tfrmquest
  Left = 413
  Top = 239
  BorderStyle = bsDialog
  Caption = 'Find Object'
  ClientHeight = 69
  ClientWidth = 216
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 16
    Width = 159
    Height = 13
    Caption = 'Which object are you looking for?'
  end
  object dtObjectName: TEdit
    Left = 8
    Top = 32
    Width = 161
    Height = 21
    TabOrder = 0
  end
  object btnOK: TButton
    Left = 176
    Top = 32
    Width = 25
    Height = 25
    Caption = '&OK'
    ModalResult = 1
    TabOrder = 1
    OnClick = btnOKClick
  end
end

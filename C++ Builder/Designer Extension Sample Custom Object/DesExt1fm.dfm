object Form1: TForm1
  Left = 315
  Top = 228
  Width = 344
  Height = 173
  Caption = 'Designer Extension Example 1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 16
    Top = 53
    Width = 313
    Height = 33
    AutoSize = False
    Caption = 
      'This sample demonstrates how to extend the designer with an addi' +
      'tional object.'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label2: TLabel
    Left = 17
    Top = 13
    Width = 313
    Height = 33
    AutoSize = False
    Caption = 
      'Dieses Beispiel demonstriert die Erweiterung des Designers mit z' +
      'usätzlichen Objekten.'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object DesignButton: TButton
    Left = 16
    Top = 109
    Width = 65
    Height = 25
    Caption = '&Design'
    TabOrder = 0
    OnClick = DesignButtonClick
  end
  object PrintButton: TButton
    Left = 96
    Top = 109
    Width = 65
    Height = 25
    Caption = '&Print'
    TabOrder = 1
    OnClick = PrintButtonClick
  end
  object SplitColorRect: TLl26XObject
    Description = 'SplitColorRect'
    ParentComponent = LL
    PopupMenu = PopupMenu1
    Icon.Data = {
      000001000100100F000000000000340300001600000028000000100000001E00
      000001001800000000000C030000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      00000000FF0000FF0000FF0000FF0000FF0000FF00000000FF0000FF0000FF00
      00FF0000FF0000FF000000000000000000000000FF0000FF0000FF0000FF0000
      FF0000FF00000000FF0000FF0000FF0000FF0000FF0000FF0000000000000000
      00000000FF0000FF0000FF0000FF0000FF0000FF00000000FF0000FF0000FF00
      00FF0000FF0000FF000000000000000000000000FF0000FF0000FF0000FF0000
      FF0000FF00000000FF0000FF0000FF0000FF0000FF0000FF0000000000000000
      00000000FF0000FF0000FF0000FF0000FF0000FF00000000FF0000FF0000FF00
      00FF0000FF0000FF000000000000000000000000FF0000FF0000FF0000FF0000
      FF0000FF00000000FF0000FF0000FF0000FF0000FF0000FF0000000000000000
      00000000FF0000FF0000FF0000FF0000FF0000FF00000000FF0000FF0000FF00
      00FF0000FF0000FF000000000000000000000000FF0000FF0000FF0000FF0000
      FF0000FF00000000FF0000FF0000FF0000FF0000FF0000FF0000000000000000
      00000000FF0000FF0000FF0000FF0000FF0000FF00000000FF0000FF0000FF00
      00FF0000FF0000FF000000000000000000000000FF0000FF0000FF0000FF0000
      FF0000FF00000000FF0000FF0000FF0000FF0000FF0000FF0000000000000000
      00000000FF0000FF0000FF0000FF0000FF0000FF00000000FF0000FF0000FF00
      00FF0000FF0000FF000000000000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      0000000000000000000000000000FFFF00008001000080010000800100008001
      0000800100008001000080010000800100008001000080010000800100008001
      000080010000FFFF0000}
    ObjectName = 'SplitColorRect'
    SupportsMultipage = False
    OnEdit = SplitColorRectEdit
    OnInitialCreation = SplitColorRectInitialCreation
    OnDraw = SplitColorRectDraw
    Left = 272
    Top = 117
  end
  object PopupMenu1: TPopupMenu
    Left = 216
    Top = 117
    object EditColor1: TMenuItem
      Caption = 'Edit Color 1'
      OnClick = EditColor1Click
    end
    object EditColor21: TMenuItem
      Caption = 'Edit Color 2'
      OnClick = EditColor21Click
    end
  end
  object ColorDialog1: TColorDialog
    Ctl3D = True
    Left = 240
    Top = 117
  end
  object LL: Tl26_
    SortVariables = Yes
    UnitSystem = usHiInch
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    OnDefineVariables = LLDefineVariables
    Left = 304
    Top = 117
  end
end

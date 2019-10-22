object Form1: TForm1
  Left = 329
  Top = 223
  Caption = 'Designer Extension Sample 2'
  ClientHeight = 135
  ClientWidth = 332
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
    Top = 50
    Width = 313
    Height = 33
    AutoSize = False
    Caption = 
      'This sample demonstrates how to extend the designer with an addi' +
      'tional function.'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    WordWrap = True
  end
  object Label2: TLabel
    Left = 18
    Top = 9
    Width = 313
    Height = 33
    AutoSize = False
    Caption = 
      'Dieses Beispiel demonstriert die Erweiterung des Designers mit z' +
      'us'#228'tzlichen Funktionen'
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
    Top = 99
    Width = 65
    Height = 25
    Caption = '&Design'
    TabOrder = 0
    OnClick = DesignButtonClick
  end
  object PrintButton: TButton
    Left = 96
    Top = 99
    Width = 65
    Height = 25
    Caption = '&Print'
    TabOrder = 1
    OnClick = PrintButtonClick
  end
  object AddNumber: TLL25XFunction
    MinimumParameters = 2
    MaximumParameters = 2
    ResultType = ptDouble
    Parameter1.ParameterType = ptDouble
    Parameter1.ParameterDescription = 'First number'
    Parameter2.ParameterType = ptDouble
    Parameter2.ParameterDescription = 'Second number'
    Parameter3.ParameterType = ptAll
    Parameter4.ParameterType = ptAll
    ParentComponent = LL
    FunctionName = 'AddNumber'
    Description = 'Return sum of two numbers'
    GroupName = 'Sample Functions'
    Visible = True
    OnEvaluateFunction = AddNumberEvaluateFunction
    OnParameterAutoComplete = AddNumberParameterAutoComplete
    Left = 272
    Top = 107
  end
  object LL: Tl25_
    SortVariables = Yes
    UnitSystem = usHiInch
    CompressStorage = Yes
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    OnDefineVariables = LLDefineVariables
    Left = 304
    Top = 107
  end
end

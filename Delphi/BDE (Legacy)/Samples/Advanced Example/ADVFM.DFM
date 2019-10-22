object Form1: TForm1
  Left = 385
  Top = 200
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = 'List & Label advanced sample program'
  ClientHeight = 126
  ClientWidth = 439
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -13
  Font.Name = 'System'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = True
  Position = poScreenCenter
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 16
  object Label3: TLabel
    Left = 8
    Top = 16
    Width = 415
    Height = 15
    Caption = 
      'D:  Dieses Beispiel demonstriert das Designen und Drucken von Et' +
      'iketten,'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label4: TLabel
    Left = 31
    Top = 32
    Width = 144
    Height = 15
    Caption = 'Listen und User-Objekten'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label5: TLabel
    Left = 8
    Top = 56
    Width = 425
    Height = 15
    Caption = 
      'US: This example demonstrates how to design and print labels, re' +
      'ports and'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label6: TLabel
    Left = 31
    Top = 72
    Width = 72
    Height = 15
    Caption = 'user-objects'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -12
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object DebugCheckBox: TCheckBox
    Left = 344
    Top = 104
    Width = 89
    Height = 17
    Caption = '&Debug output'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    OnClick = DebugCheckBoxClick
  end
  object MainMenu1: TMainMenu
    Top = 88
    object File1: TMenuItem
      Caption = '&File'
      object Exit1: TMenuItem
        Caption = '&Exit'
        OnClick = Exit1Click
      end
    end
    object Edit1: TMenuItem
      Caption = '&Edit'
      object Label1: TMenuItem
        Caption = '&Label...'
        OnClick = Label1Click
      end
      object Report1: TMenuItem
        Caption = '&Report...'
        OnClick = Report1Click
      end
    end
    object Print1: TMenuItem
      Caption = '&Print'
      object Label2: TMenuItem
        Caption = '&Label...'
        OnClick = PrintLabelClick
      end
      object Report2: TMenuItem
        Caption = '&Report...'
        OnClick = PrintListClick
      end
    end
    object Options1: TMenuItem
      Caption = '&Options'
      object Usecallbacksfortablecoloring1: TMenuItem
        Caption = '&Use callbacks for table coloring'
        OnClick = Usecallbacksfortablecoloring1Click
      end
    end
  end
  object LL: TL25_
    EMFResolution = 100
    PhantomspaceRepresentationCode = #11
    LocknextcharRepresentationCode = '`'
    MaxRTFVersion = 65280
    SortVariables = Yes
    UnitSystem = usHiInch
    CompressStorage = Yes
    Buttons3D = Yes
    ButtonsWithBitmaps = No
    OnTableField = LLTableField
    OnTableLine = LLTableLine
    OnVarHelpText = LLVarHelpText
    OnDefineVariables = LLDefineVariables
    OnDefineFields = LLDefineFields
    Left = 32
    Top = 88
  end
  object ADOConnection1: TADOConnection
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 64
    Top = 88
  end
  object ADOTableArticle: TADOTable
    Connection = ADOConnection1
    Left = 96
    Top = 88
  end
end

object PictureForm: TPictureForm
  Left = 507
  Top = 162
  BorderStyle = bsDialog
  Caption = 'List & Label Picture Box Demo'
  ClientHeight = 453
  ClientWidth = 439
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
  object Bevel1: TBevel
    Left = 8
    Top = 400
    Width = 425
    Height = 49
  end
  object Image1: TImage
    Left = 48
    Top = 8
    Width = 113
    Height = 121
    Stretch = True
  end
  object Label2: TLabel
    Left = 35
    Top = 144
    Width = 26
    Height = 13
    Caption = 'EMF'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label4: TLabel
    Left = 16
    Top = 408
    Width = 401
    Height = 13
    Caption = 
      'D:  Diese Demo zeigt die '#220'bergabe von Grafikobjekten an List && ' +
      'Label'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object BufferImage: TImage
    Left = 224
    Top = 281
    Width = 9
    Height = 7
    AutoSize = True
    Visible = False
  end
  object Label3: TLabel
    Left = 17
    Top = 424
    Width = 380
    Height = 13
    Caption = 
      'US: This demo shows how to define graphic objects to List && Lab' +
      'el'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Image2: TImage
    Left = 286
    Top = 8
    Width = 113
    Height = 121
    Stretch = True
  end
  object Label6: TLabel
    Left = 264
    Top = 144
    Width = 39
    Height = 13
    Caption = 'Bitmap'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label5: TLabel
    Left = 168
    Top = 192
    Width = 96
    Height = 24
    Caption = 'List && Label'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object EMFButton: TButton
    Left = 72
    Top = 138
    Width = 89
    Height = 25
    Hint = 'Print EMF to label'
    Caption = 'Print to label'
    ParentShowHint = False
    ShowHint = True
    TabOrder = 0
    OnClick = EMFButtonClick
  end
  object BitmapButton: TButton
    Left = 312
    Top = 138
    Width = 89
    Height = 25
    Hint = 'Print bitmap to label'
    Caption = 'Print to label'
    ParentShowHint = False
    ShowHint = True
    TabOrder = 1
    OnClick = BitmapButtonClick
  end
  object Button1: TButton
    Left = 176
    Top = 312
    Width = 83
    Height = 25
    Caption = 'Design Label...'
    TabOrder = 2
    OnClick = DesignButtonClick
  end
  object LL: TL24_
    EMFResolution = 100
    PhantomspaceRepresentationCode = #11
    LocknextcharRepresentationCode = '`'
    MaxRTFVersion = 65280
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    OnDefineVariables = LLDefineVariables
    Left = 48
    Top = 272
  end
end

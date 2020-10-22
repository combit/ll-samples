object frmMain: TfrmMain
  Left = 332
  Top = 154
  Caption = 'List & Label DOM Simple Delphi Sample'
  ClientHeight = 546
  ClientWidth = 505
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 24
    Top = 32
    Width = 14
    Height = 13
    Caption = 'D:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 24
    Top = 53
    Width = 22
    Height = 13
    Caption = 'US:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label3: TLabel
    Left = 53
    Top = 32
    Width = 390
    Height = 13
    Caption = 
      'Dieses Beispiel demonstriert  die dynamische Erzeugung von List ' +
      '&& Label Projekten'
  end
  object Label4: TLabel
    Left = 53
    Top = 53
    Width = 299
    Height = 13
    Caption = 'This sample shows the dynamic creation of List && Label projects'
  end
  object btnDesign: TButton
    Left = 296
    Top = 512
    Width = 75
    Height = 25
    Caption = '&Design...'
    TabOrder = 0
    OnClick = btnDesignClick
  end
  object GroupBox1: TGroupBox
    Left = 24
    Top = 80
    Width = 433
    Height = 425
    Caption = 'Project-Layout'
    TabOrder = 1
    object Label5: TLabel
      Left = 24
      Top = 40
      Width = 30
      Height = 13
      Caption = 'Table:'
    end
    object Label6: TLabel
      Left = 24
      Top = 112
      Width = 76
      Height = 13
      Caption = 'Available Fields:'
    end
    object Label7: TLabel
      Left = 256
      Top = 112
      Width = 75
      Height = 13
      Caption = 'Selected Fields:'
    end
    object Label8: TLabel
      Left = 24
      Top = 328
      Width = 23
      Height = 13
      Caption = 'Title:'
    end
    object Label9: TLabel
      Left = 24
      Top = 376
      Width = 27
      Height = 13
      Caption = 'Logo:'
    end
    object CmBxTables: TComboBox
      Left = 24
      Top = 64
      Width = 388
      Height = 21
      TabOrder = 0
      OnClick = CmBxTablesClick
    end
    object LstBxAvFields: TListBox
      Left = 24
      Top = 136
      Width = 177
      Height = 161
      ItemHeight = 13
      MultiSelect = True
      Sorted = True
      TabOrder = 1
      OnDblClick = LstBxAvFieldsDblClick
    end
    object LstBxSelFields: TListBox
      Left = 233
      Top = 136
      Width = 177
      Height = 161
      ItemHeight = 13
      MultiSelect = True
      Sorted = True
      TabOrder = 2
      OnDblClick = LstBxSelFieldsDblClick
    end
    object BtnSelect: TButton
      Left = 205
      Top = 185
      Width = 25
      Height = 25
      Caption = '>>'
      TabOrder = 3
      OnClick = BtnSelectClick
    end
    object BtnUnSelect: TButton
      Left = 205
      Top = 216
      Width = 25
      Height = 25
      Caption = '<<'
      TabOrder = 4
      OnClick = BtnUnSelectClick
    end
    object dtTitle: TEdit
      Left = 24
      Top = 344
      Width = 361
      Height = 21
      TabOrder = 5
      Text = 'Dynamically created Project'
    end
    object dtLogo: TEdit
      Left = 24
      Top = 392
      Width = 361
      Height = 21
      TabOrder = 6
    end
    object btnLogo: TButton
      Left = 384
      Top = 392
      Width = 25
      Height = 25
      Caption = '...'
      TabOrder = 7
      OnClick = btnLogoClick
    end
  end
  object BtnPreview: TButton
    Left = 382
    Top = 512
    Width = 75
    Height = 25
    Caption = '&Preview...'
    TabOrder = 2
    OnClick = BtnPreviewClick
  end
  object ADOConnection1: TADOConnection
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 56
    Top = 504
  end
  object LL: TDBL26_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    AutoShowPrintOptions = No
    AutoShowSelectFile = No
    AutoDefine = Yes
    AutoDesignerPreview = Yes
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmNone
    AutoBoxType = btStandardAbort
    Left = 24
    Top = 504
  end
  object OpenDialog1: TOpenDialog
    Filter = 
      'All Picture Files (*.bmp;*.jpg;*.png;*.wmf)|*.bmp;*.jpg;*.png;*.' +
      'wmf'
    Left = 440
    Top = 472
  end
  object DataSource1: TDataSource
    DataSet = ADOTable1
    Left = 88
    Top = 504
  end
  object ADOTable1: TADOTable
    Connection = ADOConnection1
    Left = 120
    Top = 504
  end
end

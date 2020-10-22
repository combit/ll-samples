object frmMain: TfrmMain
  Left = 343
  Top = 154
  Caption = 'List & Label DOM Simple Delphi Sample'
  ClientHeight = 447
  ClientWidth = 448
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesigned
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 8
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
    Left = 8
    Top = 29
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
    Left = 51
    Top = 8
    Width = 390
    Height = 13
    Caption = 
      'Dieses Beispiel demonstriert die dynamische Erzeugung von List &' +
      '& Label Projekten.'
  end
  object Label4: TLabel
    Left = 51
    Top = 29
    Width = 302
    Height = 13
    Caption = 
      'This sample shows the dynamic creation of List && Label projects' +
      '.'
  end
  object btnDesign: TButton
    Left = 280
    Top = 415
    Width = 75
    Height = 25
    Caption = '&Design...'
    TabOrder = 0
    OnClick = btnDesignClick
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 51
    Width = 433
    Height = 358
    Caption = 'Project Layout'
    TabOrder = 1
    object Label5: TLabel
      Left = 14
      Top = 24
      Width = 30
      Height = 18
      Caption = 'Table:'
    end
    object Label6: TLabel
      Left = 13
      Top = 70
      Width = 76
      Height = 13
      Caption = 'Available Fields:'
    end
    object Label7: TLabel
      Left = 240
      Top = 70
      Width = 75
      Height = 13
      Caption = 'Selected Fields:'
    end
    object Label8: TLabel
      Left = 14
      Top = 256
      Width = 23
      Height = 13
      Caption = 'Title:'
    end
    object Label9: TLabel
      Left = 14
      Top = 302
      Width = 27
      Height = 13
      Caption = 'Logo:'
    end
    object CmBxTables: TComboBox
      Left = 14
      Top = 43
      Width = 405
      Height = 21
      TabOrder = 0
      OnClick = CmBxTablesClick
    end
    object LstBxAvFields: TListBox
      Left = 13
      Top = 88
      Width = 190
      Height = 161
      ItemHeight = 13
      MultiSelect = True
      Sorted = True
      TabOrder = 1
      OnDblClick = LstBxAvFieldsDblClick
    end
    object LstBxSelFields: TListBox
      Left = 240
      Top = 89
      Width = 179
      Height = 161
      ItemHeight = 13
      MultiSelect = True
      Sorted = True
      TabOrder = 2
      OnDblClick = LstBxSelFieldsDblClick
    end
    object BtnSelect: TButton
      Left = 209
      Top = 137
      Width = 25
      Height = 25
      Caption = '>'
      TabOrder = 3
      OnClick = BtnSelectClick
    end
    object BtnUnSelect: TButton
      Left = 209
      Top = 168
      Width = 25
      Height = 25
      Caption = '<'
      TabOrder = 4
      OnClick = BtnUnSelectClick
    end
    object dtTitle: TEdit
      Left = 14
      Top = 275
      Width = 405
      Height = 21
      TabOrder = 5
      Text = 'Dynamically created Project'
    end
    object dtLogo: TEdit
      Left = 14
      Top = 321
      Width = 371
      Height = 21
      TabOrder = 6
    end
    object btnLogo: TButton
      Left = 389
      Top = 320
      Width = 30
      Height = 21
      Caption = '...'
      TabOrder = 7
      OnClick = btnLogoClick
    end
  end
  object BtnPreview: TButton
    Left = 366
    Top = 415
    Width = 75
    Height = 25
    Caption = '&Preview...'
    TabOrder = 2
    OnClick = BtnPreviewClick
  end
  object OpenDialog1: TOpenDialog
    Filter = 
      'All Picture Files (*.bmp;*.jpg;*.png;*.wmf;*.gif)|*.bmp;*.jpg;*.' +
      'png;*.wmf;*.gif'
    Left = 234
    Top = 397
  end
  object LL: TListLabel26
    Debug = []
    DataController.DataSource = DataSource1
    DataController.DetailSources = <>
    DataController.AutoMasterMode = mmNone
    Left = 178
    Top = 397
  end
  object FDConnectionNorthwind: TFDConnection
    Params.Strings = (
      'DriverID=MSAcc')
    FetchOptions.AssignedValues = [evCursorKind]
    FetchOptions.CursorKind = ckStatic
    LoginPrompt = False
    Left = 10
    Top = 397
  end
  object DataSource1: TDataSource
    Enabled = False
    Left = 122
    Top = 397
  end
  object FDTable: TFDTable
    Connection = FDConnectionNorthwind
    Left = 66
    Top = 397
  end
end

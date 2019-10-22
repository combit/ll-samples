object frmDOMSimple: TfrmDOMSimple
  Left = 269
  Top = 216
  Width = 479
  Height = 496
  Caption = 'List & Label DOM Simple'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label5: TLabel
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
  object Label6: TLabel
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
  object Label7: TLabel
    Left = 37
    Top = 8
    Width = 393
    Height = 13
    Caption = 
      'Dieses Beispiel demonstriert  die dynamische Erzeugung von List ' +
      '&& Label Projekten'
  end
  object Label8: TLabel
    Left = 37
    Top = 29
    Width = 303
    Height = 13
    Caption = 'This sample shows the dynamic creation of List && Label projects'
  end
  object GroupBox3: TGroupBox
    Left = 8
    Top = 48
    Width = 439
    Height = 377
    Caption = 'Project-Layout'
    TabOrder = 0
    object Label1: TLabel
      Left = 29
      Top = 21
      Width = 30
      Height = 13
      Caption = 'Table:'
    end
    object Label2: TLabel
      Left = 30
      Top = 80
      Width = 77
      Height = 13
      Caption = 'Available Fields:'
    end
    object Label3: TLabel
      Left = 256
      Top = 80
      Width = 75
      Height = 13
      Caption = 'Selected Fields:'
    end
    object Label4: TLabel
      Left = 30
      Top = 256
      Width = 24
      Height = 13
      Caption = 'Title:'
    end
    object Label9: TLabel
      Left = 27
      Top = 312
      Width = 27
      Height = 13
      Caption = 'Logo:'
    end
    object CmBxTables: TComboBox
      Left = 30
      Top = 40
      Width = 371
      Height = 21
      ItemHeight = 13
      TabOrder = 0
      OnClick = CmBxTablesClick
    end
    object LstBxAvFields: TListBox
      Left = 30
      Top = 99
      Width = 179
      Height = 137
      ItemHeight = 13
      TabOrder = 1
      OnDblClick = LstBxAvFieldsDblClick
    end
    object LstBxSelFields: TListBox
      Left = 240
      Top = 99
      Width = 179
      Height = 137
      ItemHeight = 13
      TabOrder = 2
      OnDblClick = LstBxSelFieldsDblClick
    end
    object dtTitle: TEdit
      Left = 29
      Top = 275
      Width = 390
      Height = 21
      TabOrder = 3
      Text = 'Dynamically created Project'
    end
    object dtLogo: TEdit
      Left = 30
      Top = 331
      Width = 366
      Height = 21
      TabOrder = 4
    end
    object btnLogo: TButton
      Left = 402
      Top = 328
      Width = 17
      Height = 25
      Caption = '...'
      TabOrder = 5
      OnClick = btnLogoClick
    end
    object BtnSelect: TButton
      Left = 215
      Top = 144
      Width = 19
      Height = 22
      Caption = '>>'
      TabOrder = 6
      OnClick = BtnSelectClick
    end
    object BtnUnSelect: TButton
      Left = 215
      Top = 175
      Width = 19
      Height = 21
      Caption = '<<'
      TabOrder = 7
      OnClick = BtnUnSelectClick
    end
  end
  object btnDesign: TButton
    Left = 280
    Top = 431
    Width = 75
    Height = 25
    Caption = '&Design'
    TabOrder = 1
    OnClick = btnDesignClick
  end
  object btnPreview: TButton
    Left = 372
    Top = 431
    Width = 75
    Height = 25
    Caption = '&Preview'
    TabOrder = 2
    OnClick = btnPreviewClick
  end
  object ADOConnection1: TADOConnection
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=..\..' +
      '\NWIND.MDB;Mode=Share Deny None;Extended Properties="";Persist S' +
      'ecurity Info=False;Jet OLEDB:System database="";Jet OLEDB:Regist' +
      'ry Path="";Jet OLEDB:Database Password="";Jet OLEDB:Engine Type=' +
      '4;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Global Partial Bul' +
      'k Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Datab' +
      'ase Password="";Jet OLEDB:Create System Database=False;Jet OLEDB' +
      ':Encrypt Database=False;Jet OLEDB:Don'#39't Copy Locale on Compact=F' +
      'alse;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SF' +
      'P=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 48
    Top = 432
  end
  object ADOTable1: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    Left = 120
    Top = 432
  end
  object DataSource1: TDataSource
    DataSet = ADOTable1
    Left = 80
    Top = 432
  end
  object LL: TDBl25_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    AutoShowPrintOptions = No
    AutoShowSelectFile = No
    AutoDefine = Yes
    DataSource = DataSource1
    AutoDesignerFile = 'inv_var.lst'
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsVariables
    AutoBoxType = btStandardAbort
    Left = 16
    Top = 432
  end
  object OpenDialog1: TOpenDialog
    Filter = 
      'All Picture Files (*.bmp;*.jpg;*.png;*.wmf)|*.bmp;*.jpg;*.png;*.' +
      'wmf'
    Left = 408
    Top = 344
  end
end

object Form1: TForm1
  Left = 0
  Top = 0
  BorderStyle = bsSingle
  Caption = 'List & Label Export Sample'
  ClientHeight = 205
  ClientWidth = 540
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Position = poScreenCenter
  OnCreate = FormCreate
  TextHeight = 13
  object lblGerman: TLabel
    Left = 23
    Top = 19
    Width = 18
    Height = 16
    AutoSize = False
    Caption = 'D:'
  end
  object lblGermanDescription: TLabel
    Left = 47
    Top = 19
    Width = 462
    Height = 24
    AutoSize = False
    Caption = 
      'Dieses Beispiel zeigt den Export ohne weitere Benutzerinteraktio' +
      'n.'
  end
  object lblEnglish: TLabel
    Left = 23
    Top = 43
    Width = 24
    Height = 16
    AutoSize = False
    Caption = 'US:'
  end
  object lblEnglishDescription: TLabel
    Left = 47
    Top = 43
    Width = 462
    Height = 24
    AutoSize = False
    Caption = 'This sample shows an export without user interaction.'
  end
  object groupExport: TGroupBox
    Left = 27
    Top = 70
    Width = 488
    Height = 117
    TabOrder = 0
    object lblFormat: TLabel
      Left = 6
      Top = 23
      Width = 48
      Height = 16
      AutoSize = False
      Caption = 'Format:'
    end
    object lblFilename: TLabel
      Left = 6
      Top = 52
      Width = 57
      Height = 16
      AutoSize = False
      Caption = 'Filename:'
    end
    object formatCb: TComboBox
      Left = 69
      Top = 19
      Width = 327
      Height = 21
      Style = csDropDownList
      DropDownCount = 11
      TabOrder = 0
      OnChange = formatCbChange
      Items.Strings = (
        'PDF'
        'MHTML'
        'RTF'
        'XML'
        'Multi-TIFF'
        'Text'
        'XLS'
        'XLSX'
        'XHTML'
        'Preview'
        'DOCX')
    end
    object fileNameEd: TEdit
      Left = 69
      Top = 50
      Width = 327
      Height = 21
      TabOrder = 1
    end
    object selectButton: TButton
      Left = 402
      Top = 50
      Width = 80
      Height = 24
      Caption = 'Select...'
      TabOrder = 2
      OnClick = selectButtonClick
    end
    object showFileCheck: TCheckBox
      Left = 248
      Top = 80
      Width = 148
      Height = 24
      Caption = 'Show file after creation'
      TabOrder = 3
    end
    object createButton: TButton
      Left = 402
      Top = 80
      Width = 80
      Height = 24
      Caption = 'Create...'
      TabOrder = 4
      OnClick = createButtonClick
    end
  end
  object FDConnectionNorthwind: TFDConnection
    Params.Strings = (
      'DriverID=MSAcc')
    FetchOptions.AssignedValues = [evCursorKind]
    FetchOptions.CursorKind = ckStatic
    LoginPrompt = False
    Left = 120
    Top = 176
  end
  object FDQueryOrders: TFDQuery
    MasterFields = 'OrderID'
    Connection = FDConnectionNorthwind
    FetchOptions.AssignedValues = [evCache, evCursorKind]
    FetchOptions.CursorKind = ckStatic
    FetchOptions.Cache = [fiBlobs, fiMeta]
    SQL.Strings = (
      'Select * From Orders Where (OrderID > 11040)'
      '')
    Left = 160
    Top = 176
  end
  object DataSourceProducts: TDataSource
    DataSet = FDQueryOrders
    Left = 200
    Top = 176
  end
  object ListLabel: TListLabel32
    Debug = []
    DataController.DataSource = DataSourceProducts
    DataController.DetailSources = <
      item
        Name = 'Orders'
        DataSource = DataSourceProducts
        PrimaryKeyField = 'OrderID'
      end>
    Left = 240
    Top = 176
  end
  object SaveDialog: TSaveDialog
    Left = 80
    Top = 176
  end
end

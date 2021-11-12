object frmMain: TfrmMain
  Left = 163
  Top = 178
  Width = 515
  Height = 217
  Caption = 'List & Label Localization Sample'
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
  object Label2: TLabel
    Left = 24
    Top = 15
    Width = 26
    Height = 29
    Caption = 'D:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -24
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label3: TLabel
    Left = 24
    Top = 79
    Width = 43
    Height = 29
    Caption = 'US:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -24
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label4: TLabel
    Left = 82
    Top = 18
    Width = 329
    Height = 39
    Caption = 
      'Dieses Beispiel zeigt das Designen von mehrsprachigen Reports. D' +
      'ie Reportvorlage ist f'#252'r alle Sprachen die Gleiche, die Lokalisi' +
      'erung wird '#252'ber das Dictionary-Objekt erreicht.'
    WordWrap = True
  end
  object Label5: TLabel
    Left = 80
    Top = 79
    Width = 335
    Height = 39
    Caption = 
      'This sample shows how to design multi language reports. The repo' +
      'rt template is the same for all languages - the localization is ' +
      'done with the Dictionary object.'
    WordWrap = True
  end
  object btnDesign: TButton
    Left = 16
    Top = 136
    Width = 117
    Height = 25
    Caption = '&Design'
    TabOrder = 0
    OnClick = btnDesignClick
  end
  object btnPrint: TButton
    Left = 152
    Top = 136
    Width = 117
    Height = 25
    Caption = '&Print'
    TabOrder = 1
    OnClick = btnPrintClick
  end
  object dsOrders: TDataSource
    DataSet = Orders
    Left = 344
    Top = 128
  end
  object ADOConnection1: TADOConnection
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\NWIND.MDB;Per' +
      'sist Security Info=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 392
    Top = 128
  end
  object LL: TDBL27_
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    AutoShowPrintOptions = No
    AutoShowSelectFile = Yes
    AutoDefine = Yes
    AutoDesignerPreview = Yes
    DataSource = dsOrders
    AutoDesignerFile = 'localization.lst'
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsFields
    AutoBoxType = btStandardAbort
    Left = 304
    Top = 128
  end
  object Orders: TADODataSet
    Connection = ADOConnection1
    CursorType = ctStatic
    CommandText = 'select * from Orders where (OrderID mod 5) = 0'
    Parameters = <>
    Left = 424
    Top = 128
  end
  object Order_Details: TADODataSet
    Connection = ADOConnection1
    CursorType = ctStatic
    CommandText = 'Order Details'
    CommandType = cmdTable
    DataSource = dsOrders
    IndexFieldNames = 'OrderID'
    MasterFields = 'OrderID'
    Parameters = <>
    Left = 464
    Top = 128
  end
end

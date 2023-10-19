object frmMain: TfrmMain
  Left = 196
  Top = 208
  Caption = 'List & Label DOM Advanced Delphi Sample'
  ClientHeight = 424
  ClientWidth = 670
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
    Left = 20
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
    Left = 20
    Top = 27
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
    Left = 56
    Top = 8
    Width = 347
    Height = 13
    Caption = 
      'Dieses Beispiel zeigt die dynamische Erstellung von List && Labe' +
      'l Projekten'
  end
  object Label4: TLabel
    Left = 56
    Top = 27
    Width = 299
    Height = 13
    Caption = 'This sample shows the dynamic creation of List && Label projects'
  end
  object PageControl1: TPageControl
    Left = 20
    Top = 62
    Width = 621
    Height = 353
    ActivePage = TbShtFinish
    Style = tsFlatButtons
    TabOrder = 0
    object TbShtCrosstabData: TTabSheet
      Caption = '1. Data'
      object Label5: TLabel
        Left = 40
        Top = 18
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
      object Label6: TLabel
        Left = 40
        Top = 37
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
      object Label7: TLabel
        Left = 89
        Top = 77
        Width = 23
        Height = 13
        Caption = 'Title:'
      end
      object Label9: TLabel
        Left = 89
        Top = 37
        Width = 260
        Height = 13
        Caption = 'Report employee turnover per country within a crosstab'
      end
      object Label8: TLabel
        Left = 89
        Top = 15
        Width = 307
        Height = 13
        Caption = 'Auswertung der Verk'#228'ufe nach Land innerhalb einer Kreuztabelle'
      end
      object Label10: TLabel
        Left = 48
        Top = 112
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
      object Label11: TLabel
        Left = 48
        Top = 131
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
      object Label12: TLabel
        Left = 97
        Top = 131
        Width = 261
        Height = 13
        Caption = 'Report employee turnover per country within a pie chart'
      end
      object Label13: TLabel
        Left = 97
        Top = 109
        Width = 332
        Height = 13
        Caption = 
          'Auswertung der Verk'#228'ufe nach Land innerhalb eines Tortendiagramm' +
          's'
      end
      object Label14: TLabel
        Left = 97
        Top = 171
        Width = 23
        Height = 13
        Caption = 'Title:'
      end
      object Label19: TLabel
        Left = 48
        Top = 205
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
      object Label20: TLabel
        Left = 48
        Top = 224
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
      object Label29: TLabel
        Left = 97
        Top = 202
        Width = 334
        Height = 13
        Caption = 
          'Auswertung der Verk'#228'ufe nach Land innerhalb eines Balkendiagramm' +
          's'
      end
      object Label30: TLabel
        Left = 97
        Top = 224
        Width = 262
        Height = 13
        Caption = 'Report employee turnover per country within a bar chart'
      end
      object Label31: TLabel
        Left = 97
        Top = 264
        Width = 23
        Height = 13
        Caption = 'Title:'
      end
      object dtTitle1: TEdit
        Left = 154
        Top = 74
        Width = 337
        Height = 21
        TabOrder = 1
        Text = 'Employee turnover per country'
      end
      object btnNext1: TButton
        Left = 535
        Top = 280
        Width = 75
        Height = 25
        Action = ctnNextTab
        TabOrder = 0
      end
      object rdbtnCrosstab: TRadioButton
        Left = 12
        Top = 14
        Width = 18
        Height = 17
        TabOrder = 2
      end
      object rdbtnPieChart: TRadioButton
        Left = 12
        Top = 111
        Width = 18
        Height = 17
        TabOrder = 3
      end
      object dtTitle2: TEdit
        Left = 162
        Top = 168
        Width = 337
        Height = 21
        TabOrder = 4
        Text = 'Employee turnover per country'
      end
      object rdbtnBarChart: TRadioButton
        Left = 12
        Top = 204
        Width = 18
        Height = 17
        TabOrder = 5
      end
      object dtTitle3: TEdit
        Left = 162
        Top = 261
        Width = 337
        Height = 21
        TabOrder = 6
        Text = 'Employee turnover per country'
      end
    end
    object TbShtCorsstabProperties: TTabSheet
      Caption = '2. Crosstab properties'
      ImageIndex = 1
      object btnPrev2: TButton
        Left = 454
        Top = 280
        Width = 75
        Height = 25
        Action = ctnPreviosTab
        TabOrder = 0
      end
      object btnNext2: TButton
        Left = 535
        Top = 280
        Width = 75
        Height = 25
        Action = ctnNextTab
        TabOrder = 1
      end
      object GroupBox1: TGroupBox
        Left = 3
        Top = 3
        Width = 585
        Height = 113
        Caption = 'Cell-Properties'
        TabOrder = 2
        object Label15: TLabel
          Left = 24
          Top = 32
          Width = 84
          Height = 13
          Caption = '1. Cell-BackColor:'
        end
        object Label16: TLabel
          Left = 24
          Top = 72
          Width = 84
          Height = 13
          Caption = '2. Cell-BackColor:'
        end
        object lblColorCell1: TLabel
          Left = 128
          Top = 24
          Width = 105
          Height = 25
          AutoSize = False
          Color = clBtnHighlight
          ParentColor = False
        end
        object lblColorCell2: TLabel
          Left = 128
          Top = 64
          Width = 105
          Height = 25
          AutoSize = False
          Color = clCream
          ParentColor = False
        end
        object btnColorCell1: TButton
          Left = 246
          Top = 25
          Width = 19
          Height = 25
          Caption = '...'
          TabOrder = 0
          OnClick = btnColorCell1Click
        end
        object btnColorCell2: TButton
          Left = 246
          Top = 64
          Width = 19
          Height = 25
          Caption = '...'
          TabOrder = 1
          OnClick = btnColorCell2Click
        end
        object RdGrpCellSortOrder: TRadioGroup
          Left = 336
          Top = 19
          Width = 217
          Height = 78
          Caption = 'Sort order:'
          ItemIndex = 0
          Items.Strings = (
            'Ascending (A > Z)'
            'Descending (Z > A)')
          TabOrder = 2
        end
      end
      object GroupBox2: TGroupBox
        Left = 3
        Top = 131
        Width = 585
        Height = 113
        Caption = 'Row-Properties'
        TabOrder = 3
        object Label17: TLabel
          Left = 24
          Top = 32
          Width = 89
          Height = 13
          Caption = '1. Row-BackColor:'
        end
        object Label18: TLabel
          Left = 24
          Top = 72
          Width = 89
          Height = 13
          Caption = '2. Row-BackColor:'
        end
        object lblColorRow1: TLabel
          Left = 128
          Top = 17
          Width = 105
          Height = 25
          AutoSize = False
          Color = clCream
          ParentColor = False
        end
        object lblColorRow2: TLabel
          Left = 128
          Top = 64
          Width = 105
          Height = 25
          AutoSize = False
          Color = clCream
          ParentColor = False
        end
        object btnColorRow1: TButton
          Left = 246
          Top = 17
          Width = 19
          Height = 25
          Caption = '...'
          TabOrder = 0
          OnClick = btnColorRow1Click
        end
        object btnColorRow2: TButton
          Left = 246
          Top = 64
          Width = 19
          Height = 25
          Caption = '...'
          TabOrder = 1
          OnClick = btnColorRow2Click
        end
        object RdGrpRowSortOrder: TRadioGroup
          Left = 336
          Top = 19
          Width = 217
          Height = 78
          Caption = 'Sort order:'
          ItemIndex = 0
          Items.Strings = (
            'Ascending (A > Z)'
            'Descending (Z > A)')
          TabOrder = 2
        end
      end
    end
    object TbShtGeneralSettings: TTabSheet
      Caption = '3. General Settings'
      ImageIndex = 2
      object Label21: TLabel
        Left = 3
        Top = 3
        Width = 54
        Height = 13
        Caption = 'Report title:'
      end
      object btnPrev3: TButton
        Left = 454
        Top = 280
        Width = 75
        Height = 25
        Action = ctnPreviosTab
        TabOrder = 0
      end
      object btnNext: TButton
        Left = 535
        Top = 280
        Width = 75
        Height = 25
        Action = ctnNextTab
        TabOrder = 1
      end
      object GroupBox3: TGroupBox
        Left = 3
        Top = 59
        Width = 593
        Height = 97
        Caption = 'Default Font'
        TabOrder = 2
        object btnDefaultFont: TButton
          Left = 496
          Top = 40
          Width = 25
          Height = 25
          Caption = '...'
          TabOrder = 0
          OnClick = btnDefaultFontClick
        end
        object Panel1: TPanel
          Left = 16
          Top = 24
          Width = 467
          Height = 57
          BevelInner = bvRaised
          BevelOuter = bvLowered
          TabOrder = 1
          object lblSampleText: TLabel
            Left = 40
            Top = 16
            Width = 369
            Height = 25
            Alignment = taCenter
            AutoSize = False
            Caption = 'Sample text'
            Layout = tlCenter
          end
        end
      end
      object GroupBox4: TGroupBox
        Left = 3
        Top = 179
        Width = 593
        Height = 73
        Caption = 'Page format'
        TabOrder = 3
        object CmbxPageFormat: TComboBox
          Left = 16
          Top = 32
          Width = 145
          Height = 21
          ItemHeight = 13
          ItemIndex = 1
          TabOrder = 0
          Text = 'Landscape'
          Items.Strings = (
            'Portrait'
            'Landscape')
        end
      end
      object dtReportTitle: TEdit
        Left = 19
        Top = 22
        Width = 577
        Height = 21
        TabOrder = 4
        Text = 'This sample shows advanced dynamic project creation.'
      end
    end
    object TbShtFinish: TTabSheet
      Caption = '4. Finish'
      ImageIndex = 3
      OnShow = TbShtFinishShow
      object btnDesign: TButton
        Left = 454
        Top = 280
        Width = 75
        Height = 25
        Caption = '&Design...'
        TabOrder = 0
        OnClick = btnDesignClick
      end
      object btnPreview: TButton
        Left = 535
        Top = 280
        Width = 75
        Height = 25
        Caption = '&Preview...'
        TabOrder = 1
        OnClick = btnPreviewClick
      end
      object Panel2: TPanel
        Left = 3
        Top = 3
        Width = 603
        Height = 261
        BevelOuter = bvNone
        Color = clInfoBk
        TabOrder = 2
        object Label22: TLabel
          Left = 92
          Top = 32
          Width = 375
          Height = 13
          Caption = 
            'The List && Label project will be created with the following opt' +
            'ions:'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          WordWrap = True
        end
        object Image1: TImage
          Left = 21
          Top = 17
          Width = 49
          Height = 49
          Picture.Data = {
            07544269746D6170361B0000424D361B00000000000036000000280000003000
            0000300000000100180000000000001B0000120B0000120B0000000000000000
            0000FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4C2A6A4C2A6A4C2A6A4
            C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6
            A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2
            A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFE
            FEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFE
            FEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFE
            FEFEFEFEFEFEFEFEFEFEFEFEFEC2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEFEFEFEFEFEFEFEFE
            FEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFE
            FEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFE
            FEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEFEC2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFE
            FEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFD
            FEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFEFDFEFE
            FDFEFEFDFEFEFDFEFEFDFEFEFDC2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEFDFCFEFDFCFEFDFC
            FEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFD
            FCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFE
            FDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCFEFDFCC2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEFCFBFEFCFBFEFCFBFEFCFBFEFCFB99330099330099330099
            3300993300993300993300993300993300993300993300993300993300993300
            993300993300993300993300993300993300993300993300993300FEFCFBFEFC
            FBFEFCFBFEFCFBFEFCFBFEFCFBC2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEFCFAFEFCFAFEFCFA
            FEFCFAFEFCFA9933009933009933009933009933009933009933009933009933
            0099330099330099330099330099330099330099330099330099330099330099
            3300993300993300993300FEFCFAFEFCFAFEFCFAFEFCFAFEFCFAFEFCFAC2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEFBF8FEFBF8FEFBF8FEFBF8FEFBF8993300993300FFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFDFE6FE6281FD
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF993300993300FEFBF8FEFB
            F8FEFBF8FEFBF8FEFBF8FEFBF8C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEFBF7FEFBF7FEFBF7
            FEFBF7FEFBF7993300993300FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFFFFFFB0C0FE1342FB0335FBD0D9FEFFFFFFFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFF993300993300FEFBF7FEFBF7FEFBF7FEFBF7FEFBF7FEFBF7C2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEFAF6FEFAF6FEFAF6FEFAF6FEFAF6993300993300FFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF819AFD0335FB0335FB0335FB
            6281FDFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF993300993300FEFAF6FEFA
            F6FEFAF6FEFAF6FEFAF6FEFAF6C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEF9F5FEF9F5FEF9F5
            FEF9F5FEF9F5993300993300FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFF2
            FF5274FC0335FB0335FB0335FB0335FB1342FBFFFFFFFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFF993300993300FEF9F5FEF9F5FEF9F5FEF9F5FEF9F5FEF9F5C2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEF9F4FEF9F4FEF9F4FEF9F4FEF9F4993300993300FFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFD0D9FE234EFC0335FB0335FB0335FB0335FB0335FB
            0335FBA0B3FDFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF993300993300FEF9F4FEF9
            F4FEF9F4FEF9F4FEF9F4FEF9F4C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEF8F2FEF8F2FEF8F2
            FEF8F2FEF8F2993300993300FFFFFFFFFFFFFFFFFFFFFFFFA0B3FD1342FB0335
            FB0335FB0335FB0335FB0335FB0335FB0335FB325BFCFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFF993300993300FEF8F2FEF8F2FEF8F2FEF8F2FEF8F2FEF8F2C2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEF8F1FEF8F1FEF8F1FEF8F1FEF8F1993300993300FFFFFFFF
            FFFFFFFFFF728EFD0335FB0335FB0335FB0335FB0335FB234EFC0335FB0335FB
            0335FB0335FBC0CCFEFFFFFFFFFFFFFFFFFFFFFFFF993300993300FEF8F1FEF8
            F1FEF8F1FEF8F1FEF8F1FEF8F1C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEF7F0FEF7F0FEF7F0
            FEF7F0FEF7F0993300993300FFFFFFEFF2FF325BFC0335FB0335FB0335FB0335
            FB0335FB5274FCEFF2FF4268FC0335FB0335FB0335FB4268FCFFFFFFFFFFFFFF
            FFFFFFFFFF993300993300FEF7F0FEF7F0FEF7F0FEF7F0FEF7F0FEF7F0C2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEF6EFFEF6EFFEF6EFFEF6EFFEF6EF993300993300D0D9FE13
            42FB0335FB0335FB0335FB0335FB0335FB819AFDFFFFFFFFFFFFC0CCFE0335FB
            0335FB0335FB0335FBB0C0FEFFFFFFFFFFFFFFFFFF993300993300FEF6EFFEF6
            EFFEF6EFFEF6EFFEF6EFFEF6EFC2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEF6EEFEF6EEFEF6EE
            FEF6EEFEF6EE9933009933001342FB0335FB0335FB0335FB0335FB1342FBB0C0
            FEFFFFFFFFFFFFFFFFFFFFFFFF4268FC0335FB0335FB0335FB234EFCFFFFFFFF
            FFFFFFFFFF993300993300FEF6EEFEF6EEFEF6EEFEF6EEFEF6EEFEF6EEC2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEF5EDFEF5EDFEF5EDFEF5EDFEF5ED993300993300D0D9FE03
            35FB0335FB0335FB325BFCDFE6FEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC0CCFE
            0335FB0335FB0335FB0335FB819AFDFFFFFFFFFFFF993300993300FEF5EDFEF5
            EDFEF5EDFEF5EDFEF5EDFEF5EDC2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEF4EBFEF4EBFEF4EB
            FEF4EBFEF4EB993300993300FFFFFFA0B3FD0335FB6281FDEFF2FFFFFFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF4268FC0335FB0335FB0335FB1342FBDF
            E6FEFFFFFF993300993300FEF4EBFEF4EBFEF4EBFEF4EBFEF4EBFEF4EBC2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEF4EAFEF4EAFEF4EAFEF4EAFEF4EA993300993300FFFFFFFF
            FFFFB0C0FEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
            DFE6FE0335FB0335FB0335FB0335FB4268FCFFFFFF993300993300FEF4EAFEF4
            EAFEF4EAFEF4EAFEF4EAFEF4EAC2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FEF3E9FEF3E9FEF3E9
            FEF3E9FEF3E9993300993300FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF819AFD0335FB0335FB0335FB03
            35FB90A6FD993300993300FEF3E9FEF3E9FEF3E9FEF3E9FEF3E9FEF3E9C2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FEF3E8FEF3E8FEF3E8FEF3E8FEF3E8993300993300FFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFFFF325BFC0335FB0335FB0335FB0335FB7D332F993300FEF3E8FEF3
            E8FEF3E8FEF3E8FEF3E8FEF3E8C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFF2E6FFF2E6FFF2E6
            FFF2E6FFF2E6993300993300FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFD0D9FE0335FB0335FB03
            35FB0335FB0C35EB903310FFF2E6FFF2E6FFF2E6FFF2E6FFF2E6FFF2E6C2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFF1E5FFF1E5FFF1E5FFF1E5FFF1E5993300993300FFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFFFFFFFFFF90A6FD0335FB0335FB0335FB0335FB1F35CCEFE5E6FFF1
            E5FFF1E5FFF1E5FFF1E5FFF1E5C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFF1E4FFF1E4FFF1E4
            FFF1E4FFF1E4993300993300FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF6281FD03
            35FB0335FB0335FB0335FB3258F7EFE5E5FFF1E4FFF1E4FFF1E4FFF1E4C2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFF0E3FFF0E3FFF0E3FFF0E3FFF0E3993300993300FFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
            FFFFFFFFFFFFFFFFFFFFFFFFEFF2FF325BFC0335FB0335FB0335FB0335FB3258
            F6DFD9E6FFF0E3FFF0E3FFF0E3C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFF0E2FFF0E2FFF0E2
            FFF0E2FFF0E29933009933009933009933009933009933009933009933009933
            0099330099330099330099330099330099330099330099330099330099330090
            33101F35CC0335FB0335FB0335FB0335FB1341F9C0C1E8FFF0E2FFF0E2C2A6A4
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFEFE0FFEFE0FFEFE0FFEFE0FFEFE099330099330099330099
            3300993300993300993300993300993300993300993300993300993300993300
            9933009933009933009933009933009933009033101F35CC0335FB0335FB0335
            FB0335FB0335FB7287EFEFE3E2C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFEEDFFFEEDFFFEEDF
            FFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEE
            DFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFFEEDFFF
            EEDFFFEEDFEFE2E13258F60335FB0335FB0335FB0335FB0335FB234CF77A7BC5
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFEEDEFFEEDEFFEEDEFFEEDEFFEEDEFFEEDEFFEEDEFFEEDEFF
            EEDEFFEEDEFFEEDEFFEEDEFFEEDEFFEEDEFFEEDEFFEEDEFFEEDEFFEEDEFFEEDE
            FFEEDEFFEEDEFFEEDEFEEDDEFCEBDBFBEADBFAE9DAF9E8D9F9E8D85F78EE0335
            FB0335FB0335FB0335FB0335FB0335FB0335FB0335FBFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFEDDDFFEDDDFFEDDD
            FFEDDDFFEDDDFFEDDDFFEDDDFFEDDDFFEDDDFFEDDDFFEDDDFFEDDDFFEDDDFFED
            DDFFEDDDFFEDDDFFEDDDFFEDDDFFEDDDFFEDDDFFEDDDFDECDBF7E5D6F4E2D3E9
            D8C8E6D5C6E3D2C3E0D0C1DDCDBE979BCF103EF70335FB0335FB0335FB0335FB
            0335FB0335FB0335FB0335FBFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFECDCFFECDCFFECDCFFECDCFFECDCFFECDCFFECDCFFECDCFF
            ECDCFFECDCFFECDCFFECDCFFECDCFFECDCFFECDCFFECDCFFECDCFFECDCFFECDC
            FFECDCFFECDCFBE8D8E7D6C6E3D1C2DECDBED9C8B9D4C4B5CFBFB1C9BAACC4B5
            A8B4AAAA566BD50335FB0335FB0335FB0335FB0335FB0335FB0335FBFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFECDAFFECDAFFECDA
            FFECDAFFECDAFFECDAFFECDAFFECDAFFECDAFFECDAFFECDAFFECDAFFECDAFFEC
            DAFFECDAFFECDAFFECDAFFECDAFFECDAFFECDAFFECDAFEEBD9DFCEBED8C8B8D2
            C1B2CBBBACC3B4A6BCAEA0B5A699ADA093A99C90A99C90A9A3B1566DE50F3CF6
            0335FB0335FB0335FB0335FBFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9FF
            EBD9FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9FFEBD9
            FFEBD9FFEBD9FFEBD9E0CEBECDBDAEC4B5A6BBAC9FB2A397A99B8E9F92869589
            7EB3A89DDBCEC2E8D3C9C2A6A4FF00FFFF00FF0335FB0335FB0335FBFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFEBD8FFEBD8FFEBD8
            FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8FFEB
            D8FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8FFEBD8F9ECE1FEFEFEF6
            F5F3EDE9E6EAE7E4E7E4E1EBE6E1FEF6EFFEF2E7E8D4CAC2A6A4FF00FFFF00FF
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7FF
            EAD7FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7FFEAD7
            FFEAD7FFEAD7FFEAD7F4E1D0FEFEFEFEFEFEFEFEFEFEFEFEFEFBF9FEF7F0FEF3
            E8F4E1D6C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFE9D6FFE9D6FFE9D6
            FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9
            D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6FFE9D6F0DBC9EEEAE6FE
            FEFEFEFEFEFEFCFAFEF8F1FEF3E9F4E2D6C2A6A4FF00FFFF00FFFF00FFFF00FF
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5FF
            E9D5FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5FFE9D5
            FFE9D5FFE9D5FFE9D5EFDAC7E1D9D3FEFEFEFEFCFBFEF8F3FEF4EAF4E3D7C2A6
            A4FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFE8D3FFE8D3FFE8D3
            FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8
            D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3FFE8D3EED9C5DBD3CBFE
            FDFCFEF9F4FEF5ECF4E3D8C2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2FF
            E8D2FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2FFE8D2
            FFE8D2FFE8D2FFE8D2EED8C4D9D0C8FEF9F5FEF5EDF4E4D9C2A6A4FF00FFFF00
            FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFE7D1FFE7D1FFE7D1
            FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7
            D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1FFE7D1DCC7B4E7DED6FE
            F6EEF4E4DAC2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0FF
            E6D0FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0FFE6D0
            FFE6D0FFE6D0FFE6D0CEB9A7F9F1E9FAEDE3C2A6A4FF00FFFF00FFFF00FFFF00
            FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFE6CFFFE6CFFFE6CF
            FFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6
            CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFBE2CCCEBFB1FAEEE4C2
            A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4FFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFF
            E6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CF
            FFE6CFFFE6CFDEC8B4E8DACFC2A6A4FF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFC2A6A4FFE6CFFFE6CFFFE6CF
            FFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6
            CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFFE6CFFBE3CCDBCBBCC2A6A4FF00FFFF
            00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF
            FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFC2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2
            A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4C2A6A4
            C2A6A4C2A6A4C0A4A2FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00
            FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF
            00FF}
          Transparent = True
        end
        object Label24: TLabel
          Left = 56
          Top = 111
          Width = 87
          Height = 13
          Caption = '- Crosstab title:'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label23: TLabel
          Left = 56
          Top = 84
          Width = 58
          Height = 13
          Caption = '- Schema:'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label25: TLabel
          Left = 56
          Top = 138
          Width = 34
          Height = 13
          Caption = '- Cell:'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label26: TLabel
          Left = 56
          Top = 165
          Width = 38
          Height = 13
          Caption = '- Row:'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label27: TLabel
          Left = 56
          Top = 192
          Width = 78
          Height = 13
          Caption = '- Project title:'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object Label28: TLabel
          Left = 56
          Top = 219
          Width = 80
          Height = 13
          Caption = '- Default font:'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
        end
        object lbl_Schema: TLabel
          Left = 192
          Top = 84
          Width = 3
          Height = 13
        end
        object lbl_title: TLabel
          Left = 192
          Top = 111
          Width = 3
          Height = 13
        end
        object lbl_Cell: TLabel
          Left = 192
          Top = 138
          Width = 3
          Height = 13
        end
        object lbl_Row: TLabel
          Left = 192
          Top = 165
          Width = 3
          Height = 13
        end
        object lbl_Project: TLabel
          Left = 192
          Top = 192
          Width = 3
          Height = 13
        end
        object lbl_Font: TLabel
          Left = 192
          Top = 219
          Width = 3
          Height = 13
        end
      end
    end
  end
  object FontDialog1: TFontDialog
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    Left = 448
    Top = 8
  end
  object ColorDialog1: TColorDialog
    Left = 408
    Top = 8
  end
  object ADOConnection1: TADOConnection
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 520
    Top = 22
  end
  object LL: TDBL29_
    OnlyOneTable = True
    SortVariables = Yes
    CompressStorage = Yes
    Buttons3D = No
    ButtonsWithBitmaps = No
    AutoShowPrintOptions = Yes
    AutoShowSelectFile = Yes
    AutoDefine = Yes
    DataSource = dsCustomers
    AutoProjectType = ptListProject
    AutoDestination = adPreview
    AutoMasterMode = mmAsFields
    AutoBoxType = btStandardAbort
    Left = 408
    Top = 40
  end
  object ActionList1: TActionList
    Left = 488
    Top = 8
    object ctnNextTab: TAction
      Caption = '&Next >'
      OnExecute = ctnNextTabExecute
    end
    object ctnPreviosTab: TAction
      Caption = '< &Previous'
      OnExecute = ctnPreviosTabExecute
    end
  end
  object dsCustomers: TDataSource
    DataSet = TblCustomers
    Left = 552
    Top = 6
  end
  object dsOrders: TDataSource
    DataSet = TblOrders
    Left = 584
    Top = 6
  end
  object TblCustomers: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'Customers'
    Left = 552
    Top = 38
  end
  object TblOrders: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'CustomerID'
    MasterFields = 'CustomerID'
    MasterSource = dsCustomers
    TableName = 'Orders'
    Left = 584
    Top = 38
  end
  object TblOrderDetails: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'OrderID'
    MasterFields = 'OrderID'
    MasterSource = dsOrders
    TableName = 'Order Details'
    Left = 616
    Top = 38
  end
end

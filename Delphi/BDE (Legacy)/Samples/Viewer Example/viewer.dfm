object ViewForm: TViewForm
  Left = 373
  Top = 218
  Width = 546
  Height = 463
  Caption = 'List & Label Delphi Demo - Viewer Application'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = MainMenu
  OldCreateOrder = True
  Position = poScreenCenter
  OnCreate = FormCreate
  OnResize = FormResize
  PixelsPerInch = 96
  TextHeight = 13
  object LlViewer: TLL29PreviewControl
    Left = 0
    Top = 0
    Width = 538
    Height = 409
    Align = alClient
    TabOrder = 0
    ShowToolbar = True
    ShowThumbnails = True
    ToolbarButtons.GotoFirst = bsDefault
    ToolbarButtons.GotoPrev = bsDefault
    ToolbarButtons.GotoNext = bsDefault
    ToolbarButtons.GotoLast = bsDefault
    ToolbarButtons.ZoomTimes2 = bsDefault
    ToolbarButtons.ZoomRevert = bsDefault
    ToolbarButtons.ZoomReset = bsDefault
    ToolbarButtons.PrintCurrentPage = bsDefault
    ToolbarButtons.PrintAllPages = bsDefault
    ToolbarButtons.PrintToFax = bsDefault
    ToolbarButtons.SendTo = bsDefault
    ToolbarButtons.SaveAs = bsDefault
    ToolbarButtons.Exit = bsDefault
    ToolbarButtons.PageCombo = bsDefault
    ToolbarButtons.ZoomCombo = bsDefault
	ToolbarButtons.Exit = bsInvisible
    Language = ltDefaultLang
    CloseMode = cmKeepFile
  end
  object OpenDialog: TOpenDialog
    DefaultExt = 'll'
    Filter = 'List & Label (*.LL)|*.ll'
    Left = 320
    Top = 344
  end
  object MainMenu: TMainMenu
    Left = 344
    Top = 344
    object File1: TMenuItem
      Caption = '&File'
      object Open1: TMenuItem
        Caption = '&Open...'
        OnClick = Open1Click
      end
      object Saveas1: TMenuItem
        Caption = '&Save as...'
        OnClick = Saveas1Click
      end
      object Print1: TMenuItem
        Caption = 'Print'
        object CurrentPage1: TMenuItem
          Caption = '&Current Page...'
          OnClick = CurrentPage1Click
        end
        object MultiplePages1: TMenuItem
          Caption = '&Multiple Pages...'
          OnClick = MultiplePages1Click
        end
      end
      object N2: TMenuItem
        Caption = '-'
      end
      object Exit1: TMenuItem
        Caption = 'E&xit'
        OnClick = Exit1Click
      end
    end
    object View1: TMenuItem
      Caption = '&View'
      object FirstPage1: TMenuItem
        Caption = '&First Page'
        Enabled = False
        ShortCut = 16420
        OnClick = FirstPage1Click
      end
      object PreviousPage1: TMenuItem
        Caption = '&Previous Page'
        Enabled = False
        ShortCut = 16417
        OnClick = PreviousPage1Click
      end
      object NextPage1: TMenuItem
        Caption = '&Next Page'
        ShortCut = 16418
        OnClick = NextPage1Click
      end
      object LastPage1: TMenuItem
        Caption = '&Last Page'
        ShortCut = 16419
        OnClick = LastPage1Click
      end
      object N1: TMenuItem
        Caption = '-'
      end
      object Zoomin1: TMenuItem
        Caption = 'Zoom &in'
        OnClick = Zoomin1Click
      end
      object Zoomout1: TMenuItem
        Caption = 'Zoom &out'
        OnClick = Zoomout1Click
      end
      object FittoPage1: TMenuItem
        Caption = 'Fit to &Screen'
        OnClick = FittoPage1Click
      end
    end
  end
end

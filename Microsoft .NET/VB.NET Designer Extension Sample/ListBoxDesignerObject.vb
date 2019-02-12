
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports combit.ListLabel24
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Imaging

'Namespace VBSample.DesignerExtensionsSample

Class ListBoxDesignerObject
    Inherits DesignerObject
    Private _lstListBoxItems As New Dictionary(Of Integer, ListBoxItem)()
    Private _lstListBoxItemsToPrint As New Dictionary(Of Integer, ListBoxItem)()

    Private _listBox As ListBox
    Private _graphics As Graphics
    Private _handle As IntPtr

    Private _currentPrintingLineIndex As Integer = -1
    Private _lastPage As Boolean = False

    Private _parentListLabel As ListLabel = Nothing
    Private _ownsParent As Boolean = False

    ' this constructor should not be called
    Private Sub New()
    End Sub

    ' 
    Public Sub New(ByVal objectName__1 As [String], ByVal objectDescription As [String], ByVal designerIcon As Icon, ByVal lstListBoxItems As Dictionary(Of Integer, ListBoxItem), ByVal listBox As ListBox)
        System.Diagnostics.Debug.Assert(Not [String].IsNullOrEmpty(objectName__1), "'objectName' can't be null nor empty")
        System.Diagnostics.Debug.Assert(Not [String].IsNullOrEmpty(objectDescription), "'objectDescription' can't be null nor empty")

        ' copy owner drawn listbox items
        _lstListBoxItems = lstListBoxItems

        ' create a local copy of the listbox
        _listBox = New ListBox()
        _listBox.CreateControl()
        For Each item As Object In listBox.Items
            _listBox.Items.Add(item)
        Next

        '
        _handle = listBox.Handle
        _graphics = Graphics.FromHwnd(_handle)

        ' very important to get multiple pages printed
        AllowPageBreak = True

        ' set the name of the designer object
        ObjectName = objectName__1

        ' set the description of the designer object
        Description = objectDescription

        ' set the icon of the designer object
        Icon = New Icon(designerIcon, 32, 32)
    End Sub

    Public Property Parent() As ListLabel

        Get
            If (_parentListLabel Is Nothing) Then
                _parentListLabel = New ListLabel(JobHandle)
                _ownsParent = True
            End If
            Return _parentListLabel
        End Get

        Set(ByVal Value As ListLabel)
            _parentListLabel = Value
        End Set

    End Property

    Public ReadOnly Property IsPrinting() As Boolean

        Get
            Return (If(Parent.Core.LlGetOption(337) = 1, True, False)) ' 337 = LL_OPTION_IS_PRINTING
        End Get

    End Property

#Region "DesignerObject"

    ' 
    Protected Overrides Sub OnResetPrintState(ByVal e As EventArgs)
        ' reset datasource to work with
        _currentPrintingLineIndex = -1
        _lastPage = False
        _lstListBoxItemsToPrint.Clear()
    End Sub

    ' 
    Protected Overrides Sub OnPostCloneDesignerObject(ByVal e As PostCloneDesignerObjectEventArgs)
        ' cloning the designer object
        Dim clone As ListBoxDesignerObject = DirectCast(e.Clone, ListBoxDesignerObject)

        clone._currentPrintingLineIndex = _currentPrintingLineIndex
        clone._lastPage = _lastPage
        clone._lstListBoxItems = _lstListBoxItems
        clone._handle = _handle
        clone._graphics = Graphics.FromHwnd(_handle)

        clone._listBox = New ListBox()
        clone._listBox.CreateControl()
        For Each item As Object In _listBox.Items
            clone._listBox.Items.Add(item)
        Next
    End Sub

    ' 
    Protected Overrides Sub OnGetFieldHeightInformation(ByVal e As GetFieldHeightInformationEventArgs)
        Dim heightToDraw As Integer = 0
        Dim sumHeights As Integer = 0
        Dim itemHeight As Integer = 0
        Dim lstItemCount As Integer = _lstListBoxItems.Count
        ' the count is pending on the drawn (visible) listbox items!
        _currentPrintingLineIndex += 1
        For index As Integer = _currentPrintingLineIndex To lstItemCount - 1
            ' get listbox item
            Dim listBoxItem As ListBoxItem = _lstListBoxItems(index)

            ' get the height of the listbox item
            itemHeight = Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics))
            ' hint: itemHeigth are pixel; but have to be LL units!
            ' add the item height to the previous height
            sumHeights += itemHeight

            ' last page?
            If index = lstItemCount - 1 Then
                _lastPage = True
            End If

            ' verify the new height fits into the available height
            If sumHeights <= e.AvailableSpace.Height Then
                ' current item of the listbox fits to the available space
                _currentPrintingLineIndex = index
                _lstListBoxItemsToPrint(_currentPrintingLineIndex) = listBoxItem
                heightToDraw = sumHeights
            Else
                Exit For
                ' leave loop
            End If
        Next

        ' set the result values for list & label
        ' hint: have to be in LL units!
        e.MinimalHeight = Convert.ToInt32(CoordinateHelper.ConvertUnit(_lstListBoxItems(_currentPrintingLineIndex).Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics))
        e.IdealHeight = heightToDraw
    End Sub

    ' 
    Protected Overrides Sub OnDrawDesignerObject(ByVal e As DrawDesignerObjectEventArgs)
        ' only layout-mode or printing?
        If e.IsDesignMode Then
            e.PrintFinished = True
        Else
            e.PrintFinished = _lastPage
        End If
        ' last page?
        ' 
        Dim topPositionToDraw As Integer = e.ClipRectangle.Top
        If IsInTableCell Then
            For Each listBoxItem As ListBoxItem In _lstListBoxItemsToPrint.Values
                ' Printing strings using the .NET component's event
                ' http://www.combit.net/de/support/kb/search.asp?article=KBTE000580
                Dim font As New Font(listBoxItem.Font.Name, CSng(CoordinateHelper.ConvertUnit(listBoxItem.Font.Size, CoordinateHelper.ConversionUnit.Point, UnitSystem, _graphics)))

                ' calc the rect for drawing
                Dim rectToDraw As New Rectangle(e.ClipRectangle.Left, topPositionToDraw, Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Width, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)), Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)))
                topPositionToDraw += rectToDraw.Height

                ' draw the string
                e.Graphics.DrawString(listBoxItem.Text, font, listBoxItem.Brush, rectToDraw)
            Next

            ' cleanup printed listbox items
            _lstListBoxItemsToPrint.Clear()
        Else
            Dim heightToDraw As Integer = 0
            Dim sumHeights As Integer = 0
            Dim itemHeight As Integer = 0
            Dim lstItemCount As Integer = _lstListBoxItems.Count
            ' the count is pending on the drawn (visible) listbox items!
            _currentPrintingLineIndex += 1
            For index As Integer = _currentPrintingLineIndex To lstItemCount - 1
                ' get listbox item
                Dim listBoxItem As ListBoxItem = _lstListBoxItems(index)

                ' get the height of the listbox item
                itemHeight = Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics))
                ' hint: itemHeigth are pixel; but have to be LL units!
                ' add the item height to the previous height
                sumHeights += itemHeight

                ' last page?
                If index = lstItemCount - 1 Then
                    e.PrintFinished = InlineAssignHelper(_lastPage, True)
                End If

                ' verify the new height fits into the available height
                If sumHeights <= e.ClipRectangle.Height Then
                    ' current item of the listbox fits to the available space
                    _currentPrintingLineIndex = index

                    ' Printing strings using the .NET component's event
                    ' http://www.combit.net/de/support/kb/search.asp?article=KBTE000580
                    Dim font As New Font(listBoxItem.Font.Name, CSng(CoordinateHelper.ConvertUnit(listBoxItem.Font.Size, CoordinateHelper.ConversionUnit.Point, UnitSystem, _graphics)))

                    ' calc the rect for drawing
                    Dim rectToDraw As New Rectangle(e.ClipRectangle.Left, topPositionToDraw, Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Width, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)), Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)))
                    topPositionToDraw += rectToDraw.Height

                    ' draw the string
                    e.Graphics.DrawString(listBoxItem.Text, font, listBoxItem.Brush, rectToDraw)
                    heightToDraw = sumHeights
                Else
                    Exit For
                    ' leave loop
                End If
            Next

            ' 
            e.ClipRectangle = New Rectangle(e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width, heightToDraw)
        End If

        ' While unfinished printing And we know what we are doing (no endless recursion!), we active reset the idle iteration counter for the object if property MaximumIdleIterationsPerObject was set
        If ((Not e.PrintFinished) And IsPrinting And (Not e.IsDesignMode)) Then
            ResetIdleIterationCounter()
        End If

    End Sub

#End Region

#Region "IDisposable"
    Private Shadows disposed As Boolean = False
    ' to detect redundant calls
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not disposed AndAlso disposing Then
            ' dispose-only, i.e. non-finalizable logic
            _graphics.Dispose()

            ' shared cleanup logic
            disposed = True
        End If
    End Sub

#End Region

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function
End Class

Class ListBoxItem
    Private _text As [String]
    Private _font As Font
    Private _brush As SolidBrush
    Private _rect As Rectangle

    Private Sub New()
    End Sub

    Public Sub New(ByVal text__1 As [String], ByVal font__2 As Font, ByVal brush__3 As SolidBrush, ByVal rect__4 As Rectangle)
        Text = text__1
        Font = font__2
        Brush = brush__3
        Rect = rect__4
    End Sub

    Public Property Text() As [String]
        Get
            Return _text
        End Get
        Set(ByVal value As [String])
            _text = value
        End Set
    End Property

    Public Property Font() As Font
        Get
            Return _font
        End Get
        Set(ByVal value As Font)
            _font = value
        End Set
    End Property

    Public Property Brush() As SolidBrush
        Get
            Return _brush
        End Get
        Set(ByVal value As SolidBrush)
            _brush = value
        End Set
    End Property

    Public Property Rect() As Rectangle
        Get
            Return _rect
        End Get
        Set(ByVal value As Rectangle)
            _rect = value
        End Set
    End Property
End Class


'End Namespace

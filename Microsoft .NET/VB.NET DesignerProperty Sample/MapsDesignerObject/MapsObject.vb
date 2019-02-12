
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports combit.ListLabel24
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Threading
Imports System.ComponentModel
Imports GMap.NET.WindowsForms.Markers
Imports combit.ListLabel24.DesignerExtensions
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Resources



Namespace combit.ListLabel.DesignerExtensions
    Public Class MapsObject
        Inherits DesignerObject
        Private _map As GMapControl

        ' D: Breitengrad 
        'US: Latitude
        Public Property Latitude() As Double
            Get
                Return Convert.ToDouble(DesignerProperties("Latitude").Value)
            End Get
            Set(value As Double)
                DesignerProperties("Latitude").Formula = value
            End Set
        End Property

        ' D: Längengrad
        'US: Longitude
        Public Property Longitude() As Double
            Get
                Return Convert.ToDouble(DesignerProperties("Longitude").Value)
            End Get
            Set(value As Double)
                DesignerProperties("Longitude").Formula = value
            End Set
        End Property

        ' D: Zoom-Stufe
        'US: Zoom level
        Public Property Zoom() As Integer
            Get
                Return Convert.ToInt32(DesignerProperties("Zoom").Value)
            End Get
            Set(value As Integer)
                DesignerProperties("Zoom").Formula = value
            End Set
        End Property

        ' D: Auflösung
        'US: Resolution
        Public Property Resolution() As Integer
            Get
                Return Convert.ToInt32(DesignerProperties("Resolution").Value)
            End Get
            Set(value As Integer)
                DesignerProperties("Resolution").Formula = value
            End Set
        End Property

        ' D: Text für Tooltipp
        'US: Tooltip text
        Public Property TooltipText() As String
            Get
                Return DesignerProperties("TooltipText").Value.ToString()
            End Get
            Set(value As String)
                DesignerProperties("TooltipText").Formula = value
            End Set
        End Property

        ' D: Auswertung der Koordinaten
        'US: Evaluation of coordinates
        Public Enum CoordinateEvaluation
            GeoCoder
            Coordinates
        End Enum

        ' D: Auswertungstyp für Koordinaten
        'US: Evaluation type for coordinates
        Public Property CoordinateEvaluationType() As CoordinateEvaluation
            Get
                Return CType([Enum].ToObject(GetType(CoordinateEvaluation), Convert.ToInt32(DesignerProperties("CoordinateEvaluationType").Value)), CoordinateEvaluation)
            End Get
            Set(value As CoordinateEvaluation)
                DesignerProperties("CoordinateEvaluationType").Formula = value
            End Set
        End Property

        ' D: Schriftart für Tooltipp
        'US: Tooltip font
        Public ReadOnly Property TooltipFont() As Font
            Get
                Return TryCast(DesignerProperties("TooltipFont"), FontDesignerProperty).Font
            End Get
        End Property

        ' D: Hintergrundfarbe für Tooltipp
        'US: Tooltip background color
        Public ReadOnly Property TooltipBackgroundColor() As Color
            Get
                Return TryCast(DesignerProperties("TooltipBackgroundColor"), ColorDesignerProperty).Value
            End Get
        End Property

        ' D: Anzeige des Tooltipp
        'US: Show tooltip
        Public Property ShowTooltip() As Boolean
            Get
                Return Convert.ToBoolean(DesignerProperties("ShowTooltip").Value)
            End Get
            Set(value As Boolean)
                DesignerProperties("ShowTooltip").Formula = value
            End Set
        End Property

        Public Property City() As String
            Get
                Return DesignerProperties("City").Value.ToString()
            End Get
            Set(value As String)
                DesignerProperties("City").Formula = value
            End Set
        End Property

        ' D: Initialisierung des Maps-Objektes
        'US: Initialize maps object
        Public Sub New()
            SupportsContentDialog = False
            AddHandler InitializationFinished, New EventHandler(Of EventArgs)(AddressOf MapsObject_InitializationFinished)

            _map = New GMapControl()
            _map.MarkersEnabled = True

            ' D: Art der Koordinatenberechnung
            'US: Coordinate evaluation type
            Dim MapProperty As New DictionaryDesignerProperty("CoordinateEvaluationType", CoordinateEvaluation.GeoCoder)
            MapProperty.DisplayName = My.Resources.CoordinateEvaluationType
            MapProperty.Description = My.Resources.CoordinateEvaluationTypeDescr
            MapProperty.AllowFormula = False
            MapProperty.Dictionary.Add(CoordinateEvaluation.GeoCoder, "Geocoding")
            MapProperty.Dictionary.Add(CoordinateEvaluation.Coordinates, "Koordinaten")
            AddHandler MapProperty.ValueChanged, New EventHandler(Of EventArgs)(AddressOf MapProperty_ValueChanged)
            DesignerProperties.Add(MapProperty)

            ' D: DesignerProperty "Stadt"
            'US: DesignerProperty "City"
            Dim CityProperty As New TextDesignerProperty("City", """Konstanz""")
            CityProperty.DisplayName = My.Resources.City
            CityProperty.Description = My.Resources.CityDescr
            DesignerProperties.Add(CityProperty)

            ' D: DesignerProperty "Breitengrad"
            'US: DesignerProperty "Latitude"
            Dim NumericProperty As New NumericDesignerProperty("Latitude", 47.662473)
            NumericProperty.DisplayName = My.Resources.Latitude
            NumericProperty.Description = My.Resources.LatitudeDescr
            NumericProperty.Signed = False
            DesignerProperties.Add(NumericProperty)

            ' D: DesignerProperty "Längengrad"
            'US: DesignerProperty "Longitude"
            NumericProperty = New NumericDesignerProperty("Longitude", 9.172054)
            NumericProperty.DisplayName = My.Resources.Longitude
            NumericProperty.Description = My.Resources.LongitudeDescr
            NumericProperty.Signed = False
            DesignerProperties.Add(NumericProperty)

            ' D: DesignerProperty "Zoomstufe"
            'US: DesignerProperty "Zoom level"
            NumericProperty = New NumericDesignerProperty("Zoom", 15)
            NumericProperty.DisplayName = My.Resources.Zoom
            NumericProperty.Description = My.Resources.ZoomDescr
            NumericProperty.Signed = False
            DesignerProperties.Add(NumericProperty)

            ' D: DesignerProperty "Auflösung"
            'US: DesignerProperty "Resolution"
            NumericProperty = New NumericDesignerProperty("Resolution", 96)
            NumericProperty.DisplayName = My.Resources.Resolution
            NumericProperty.Description = My.Resources.ResolutionDescr
            NumericProperty.Signed = False
            DesignerProperties.Add(NumericProperty)

            ' D: DesignerProperty "Tooltipp anzeigen"
            'US: DesignerProperty "Show tooltip"
            Dim TooltipProperty As New BoolDesignerProperty("ShowTooltip", True)
            TooltipProperty.DisplayName = My.Resources.ShowToolTip
            TooltipProperty.Description = My.Resources.ShowToolTipDescr
            TooltipProperty.BoolType = BoolDesignerPropertyType.YesNo
            DesignerProperties.Add(TooltipProperty)

            ' D: DesignerProperty "Schriftart"
            'US: DesignerProperty "Font type"
            Dim FontProperty As New FontDesignerProperty("TooltipFont", [String].Empty)
            FontProperty.DisplayName = My.Resources.ToolTipFont
            FontProperty.Description = My.Resources.ToolTipFontDescr
            DesignerProperties.Add(FontProperty)

            ' D: DesignerProperty "Tooltipp Hintergrund"
            'US: DesignerProperty "Tooltip background" 
            Dim BgcolorProperty As New ColorDesignerProperty("TooltipBackgroundColor", Color.White)
            BgcolorProperty.DisplayName = My.Resources.ToolTipBg
            BgcolorProperty.Description = My.Resources.ToolTipBgDescr
            DesignerProperties.Add(BgcolorProperty)

            ' D: DesignerProperty "Tooltipp Text" 
            'US: DesignerProperty "Tooltip text"
            Dim TextProperty As New TextDesignerProperty("TooltipText", """You are here!""")
            TextProperty.DisplayName = My.Resources.ToolTipText
            TextProperty.Description = My.Resources.ToolTipTextDescr

            DesignerProperties.Add(TextProperty)
        End Sub

        Private Sub MapsObject_InitializationFinished(sender As Object, e As EventArgs)
            UpdatePropertyStates(TryCast(sender, MapsObject))
        End Sub

        Private Sub MapProperty_ValueChanged(sender As Object, e As EventArgs)
            UpdatePropertyStates(TryCast(sender, MapsObject))
        End Sub


        Private _resetEvent As New ManualResetEvent(False)
        Private _image As Image = Nothing

        Public Function RenderToImageSynchronous(size As Size) As Image
            ' D: Da die Ausgabe in der Vorschau oder auf dem Drucker wiedergegeben wird, kann es nicht asynchron verarbeitet werden.
            '    Dazu erzeugen wir den eigentlichen Rendering-Prozess und warten, bis er mit Hilfe eines AutoResetEvent 
            '    der Thread-Synchronisation beendet wird. Schließlich liefern wir das Bild als Rückgabewert.
            'US: As the output is to be rendered to preview or printer, it cannot be processed asynchronously.
            '    This, we spawn the actual rendering process and wait for it to finish by using an AutoResetEvent
            '    for thread synchronization. Finally, we yield the image as return value.
            _map.MaxZoom = 18
            _map.MinZoom = 0
            _map.Zoom = Zoom
            _map.Size = size
            _map.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerOnly


            ' D: Ereignis, welches ausgelöst wird, sobald der Download abgeschlossen ist.
            'US: Event that is triggered once download has finished.
            AddHandler _map.OnTileLoadComplete, New TileLoadComplete(AddressOf Map_OnTileLoadComplete)


            Dim position As System.Nullable(Of PointLatLng) = Nothing

            ' D: Ermittlung der gewünschten Koordinate
            'US: Determine required position
            If CoordinateEvaluationType = CoordinateEvaluation.GeoCoder Then
                If Not [String].IsNullOrEmpty(City) Then
                    Dim status As GeoCoderStatusCode
                    position = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetPoint(City, status)
                    If position Is Nothing OrElse status <> GeoCoderStatusCode.G_GEO_SUCCESS Then
                        Return Nothing
                    End If
                End If
            Else
                position = New PointLatLng(Latitude, Longitude)
            End If
            _map.Position = position.Value
            _resetEvent.Reset()

            ' D: Auslösen der Renderung
            'US: Trigger rendering
            _map.ToImage()

            ' D: Warten auf Beendigung des Renderns
            'US: Wait for rendering to finish
            _resetEvent.WaitOne(New TimeSpan(0,0,0,0,1000))

            ' D: Verwendung der Grafik
            'US: Grab image
            _image = _map.ToImage()

            ' D: Hinzufügen von Überlagerungen falls erforderlich (-> Tooltip, Marker)
            'US: Add overlays if required (->tooltip, marker)
            Dim bmp As New Bitmap(_map.Size.Width, _map.Size.Height)
            Dim overlay As GMapOverlay = Nothing
            _map.Overlays.Clear()
            If ShowTooltip Then
                overlay = New GMapOverlay("Marker")
                Dim marker As GMapMarker = New GMarkerGoogle(New PointLatLng(position.Value.Lat, position.Value.Lng), GMarkerGoogleType.red)
                marker.ToolTipText = TooltipText
                marker.ToolTipMode = MarkerTooltipMode.Always
                marker.ToolTip.Font = New Font(TooltipFont.FontFamily, TooltipFont.Size * Resolution / 96, TooltipFont.Style, TooltipFont.Unit, TooltipFont.GdiCharSet)
                marker.ToolTip.Fill = New SolidBrush(TooltipBackgroundColor)
                overlay.Markers.Add(marker)
            End If

            If overlay IsNot Nothing Then
                _map.Overlays.Add(overlay)
            End If
            _map.DrawToBitmap(bmp, New Rectangle(0, 0, _map.Size.Width, _map.Size.Height))

            _image = bmp
            Return _image
        End Function


        Public Sub Map_OnTileLoadComplete(ElapsedMilliseconds As Long)
            _resetEvent.[Set]()
        End Sub

        Private _lastRenderSize As Size = New Size(0, 0)

        Private _lastHashCode As Integer = 0

        Private _lastImage As Image = Nothing

        Protected Overrides Sub OnDrawDesignerObject(ByVal e As DrawDesignerObjectEventArgs)
            Dim renderSize As Size = New Size(Convert.ToInt32(CoordinateHelper.ConvertToPixel(e.ClipRectangle.Width, UnitSystem, Resolution)), Convert.ToInt32(CoordinateHelper.ConvertToPixel(e.ClipRectangle.Height, UnitSystem, Resolution)))
            Dim objectChanged As Boolean = DesignerProperties.GetHashCode() <> _lastHashCode
            Dim sizeChanged As Boolean = (renderSize <> _lastRenderSize)
            If sizeChanged OrElse objectChanged Then
                _lastImage = RenderToImageSynchronous(renderSize)
                If sizeChanged Then _lastRenderSize = renderSize
                If objectChanged Then _lastHashCode = DesignerProperties.GetHashCode()
            End If

            If _lastImage IsNot Nothing Then
                e.Graphics.DrawImage(_lastImage, e.ClipRectangle)
            End If
        End Sub

        Protected Overrides Sub OnPostCloneDesignerObject(e As PostCloneDesignerObjectEventArgs)
            Dim clone As MapsObject = DirectCast(e.Clone, MapsObject)
            clone._map = New GMapControl()

            For Each overlay As GMapOverlay In _map.Overlays
                clone._map.Overlays.Add(overlay)
            Next
            MyBase.OnPostCloneDesignerObject(e)
        End Sub

        Private Sub UpdatePropertyStates(obj As MapsObject)
            Select Case obj.CoordinateEvaluationType
                Case CoordinateEvaluation.Coordinates
                    If True Then
                        obj.DesignerProperties("City").Enabled = False
                        obj.DesignerProperties("Latitude").Enabled = True
                        obj.DesignerProperties("Longitude").Enabled = True
                    End If
                    Exit Select
                Case CoordinateEvaluation.GeoCoder
                    If True Then
                        obj.DesignerProperties("City").Enabled = True
                        obj.DesignerProperties("Latitude").Enabled = False
                        obj.DesignerProperties("Longitude").Enabled = False
                    End If
                    Exit Select
                Case Else
                    Exit Select
            End Select
        End Sub
    End Class
End Namespace

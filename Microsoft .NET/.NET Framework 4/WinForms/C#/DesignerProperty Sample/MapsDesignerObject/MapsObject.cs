using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using combit.ListLabel25;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using GMap.NET.WindowsForms.Markers;
using combit.ListLabel25.DesignerExtensions;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Runtime.Serialization;
using System.Resources;
using combit.ListLabel.MapsObject.Properties;
using System.Net;

namespace combit.ListLabel.DesignerExtensions
{
    public class MapsObject : DesignerObject
    {
        private GMapControl _map;

        // D: Breitengrad 
        //US: Latitude
        public double Latitude
        {
            get
            {
                return Convert.ToDouble(DesignerProperties["Latitude"].Value);
            }
            set
            {
                DesignerProperties["Latitude"].Formula = value;
            }
        }

        // D: Längengrad
        //US: Longitude
        public double Longitude
        {
            get
            {
                return Convert.ToDouble(DesignerProperties["Longitude"].Value);
            }
            set
            {
                DesignerProperties["Longitude"].Formula = value;
            }
        }

        // D: Zoom-Stufe
        //US: Zoom level
        public int Zoom
        {
            get
            {
                return Convert.ToInt32(DesignerProperties["Zoom"].Value);
            }
            set
            {
                DesignerProperties["Zoom"].Formula = value;               
            }
        }

        // D: Auflösung
        //US: Resolution
        public int Resolution
        {
            get
            {
                return Convert.ToInt32(DesignerProperties["Resolution"].Value);
            }
            set
            {
                DesignerProperties["Resolution"].Formula = value;
            }
        }

        // D: Text für Tooltipp
        //US: Tooltip text
        public string TooltipText
        {
            get
            {
                return DesignerProperties["TooltipText"].Value.ToString();
            }
            set
            {
                DesignerProperties["TooltipText"].Formula = value;
            }
        }

        // D: Auswertung der Koordinaten
        //US: Evaluation of coordinates
        public enum CoordinateEvaluation
        {
            GeoCoder,
            Coordinates
        }

        // D: Auswertungstyp für Koordinaten
        //US: Evaluation type for coordinates
        public CoordinateEvaluation CoordinateEvaluationType
        {
            get
            {
                return (CoordinateEvaluation)Enum.ToObject(typeof(CoordinateEvaluation), Convert.ToInt32(DesignerProperties["CoordinateEvaluationType"].Value));
            }
            set
            {
                DesignerProperties["CoordinateEvaluationType"].Formula = value;
            }
        }
        
        // D: Schriftart für Tooltipp
        //US: Tooltip font
        public Font TooltipFont
        {
            get
            {
                return (DesignerProperties["TooltipFont"] as FontDesignerProperty).Font;
            }
        }

        // D: Hintergrundfarbe für Tooltipp
        //US: Tooltip background color
        public Color TooltipBackgroundColor
        {
            get
            {
                return (DesignerProperties["TooltipBackgroundColor"] as ColorDesignerProperty).Value;
            }
        }

        // D: Anzeige des Tooltipp
        //US: Show tooltip
        public bool ShowTooltip
        {
            get
            {
                return Convert.ToBoolean(DesignerProperties["ShowTooltip"].Value);
            }
            set
            {
                DesignerProperties["ShowTooltip"].Formula = value;
            }
        }
        
        public string City
        {
            get
            {
                return DesignerProperties["City"].Value.ToString();
            }
            set
            {
                DesignerProperties["City"].Formula = value;
            }
        }

        // D: Initialisierung des Maps-Objektes
        //US: Initialize maps object
        public MapsObject(string ObjectName, string Description, Icon Icon)
        {
            this.ObjectName = ObjectName;
            this.Description = Description;
            this.Icon = Icon;
            SupportsContentDialog = false;
            InitializationFinished += new EventHandler<EventArgs>(MapsObject_InitializationFinished);
            _map = new GMapControl();
            _map.MarkersEnabled = true;

            // D: Art der Koordinatenberechnung
            //US: Coordinate evaluation type
            DictionaryDesignerProperty MapProperty = new DictionaryDesignerProperty("CoordinateEvaluationType", CoordinateEvaluation.GeoCoder);
            MapProperty.DisplayName = Resources.CoordinateEvaluationType;
            MapProperty.Description = Resources.CoordinateEvaluationTypeDescr;
            MapProperty.AllowFormula = false;
            MapProperty.Dictionary.Add(CoordinateEvaluation.GeoCoder, "Geocoding");
            MapProperty.Dictionary.Add(CoordinateEvaluation.Coordinates, "Koordinaten");
            MapProperty.ValueChanged += new EventHandler<EventArgs>(MapProperty_ValueChanged);
            DesignerProperties.Add(MapProperty);

            // D: DesignerProperty "Stadt"
            //US: DesignerProperty "City"
            TextDesignerProperty CityProperty = new TextDesignerProperty("City", "\"Konstanz\"");
            CityProperty.DisplayName = Resources.City ;
            CityProperty.Description = Resources.CityDescr ;
            DesignerProperties.Add(CityProperty);

            // D: DesignerProperty "Breitengrad"
            //US: DesignerProperty "Latitude"
            NumericDesignerProperty NumericProperty = new NumericDesignerProperty("Latitude", 47.662473);
            NumericProperty.DisplayName = Resources.Latitude ;
            NumericProperty.Description = Resources.LatitudeDescr;
            NumericProperty.Signed = false;
            DesignerProperties.Add(NumericProperty);

            // D: DesignerProperty "Längengrad"
            //US: DesignerProperty "Longitude"
            NumericProperty = new NumericDesignerProperty("Longitude", 9.172054);
            NumericProperty.DisplayName = Resources.Longitude ;
            NumericProperty.Description = Resources.LongitudeDescr;
            NumericProperty.Signed = false;
            DesignerProperties.Add(NumericProperty);

            // D: DesignerProperty "Zoomstufe"
            //US: DesignerProperty "Zoom level"
            NumericProperty = new NumericDesignerProperty("Zoom", 15);
            NumericProperty.DisplayName = Resources.Zoom ;
            NumericProperty.Description = Resources.ZoomDescr;
            NumericProperty.Signed = false;
            DesignerProperties.Add(NumericProperty);

            // D: DesignerProperty "Auflösung"
            //US: DesignerProperty "Resolution"
            NumericProperty = new NumericDesignerProperty("Resolution", 96);
            NumericProperty.DisplayName = Resources.Resolution ;
            NumericProperty.Description = Resources.ResolutionDescr ;
            NumericProperty.Signed = false;
            DesignerProperties.Add(NumericProperty);

            // D: DesignerProperty "Tooltipp anzeigen"
            //US: DesignerProperty "Show tooltip"
            BoolDesignerProperty TooltipProperty = new BoolDesignerProperty("ShowTooltip", true);
            TooltipProperty.DisplayName = Resources.ShowToolTip ;
            TooltipProperty.Description = Resources.ShowToolTipDescr;
            TooltipProperty.BoolType = BoolDesignerPropertyType.YesNo;
            DesignerProperties.Add(TooltipProperty);

            // D: DesignerProperty "Schriftart"
            //US: DesignerProperty "Font type"
            FontDesignerProperty FontProperty = new FontDesignerProperty("TooltipFont", String.Empty);
            FontProperty.DisplayName = Resources.ToolTipFont;
            FontProperty.Description = Resources.ToolTipFontDescr;
            DesignerProperties.Add(FontProperty);

            // D: DesignerProperty "Tooltipp Hintergrund"
            //US: DesignerProperty "Tooltip background" 
            ColorDesignerProperty BgcolorProperty = new ColorDesignerProperty("TooltipBackgroundColor", Color.White);
            BgcolorProperty.DisplayName = Resources.ToolTipBg ;
            BgcolorProperty.Description = Resources.ToolTipBgDescr ;
            DesignerProperties.Add(BgcolorProperty);

            // D: DesignerProperty "Tooltipp Text" 
            //US: DesignerProperty "Tooltip text"
            TextDesignerProperty TextProperty = new TextDesignerProperty("TooltipText", "\"You are here!\"");
            TextProperty.DisplayName = Resources.ToolTipText ;
            TextProperty.Description = Resources.ToolTipTextDescr ;
            DesignerProperties.Add(TextProperty);
                        
        }

        void MapsObject_InitializationFinished(object sender, EventArgs e)
        {
            UpdatePropertyStates(sender as MapsObject);
        }

        void MapProperty_ValueChanged(object sender, EventArgs e)
        {
            UpdatePropertyStates(sender as MapsObject);
        }


        private ManualResetEvent _resetEvent = new ManualResetEvent(false);
        private Image _image = null;

        public Image RenderToImageSynchronous(Size size)
        {
            // D: Da die Ausgabe in der Vorschau oder auf dem Drucker wiedergegeben wird, kann es nicht asynchron verarbeitet werden.
            //    Dazu erzeugen wir den eigentlichen Rendering-Prozess und warten, bis er mit Hilfe eines AutoResetEvent 
            //    der Thread-Synchronisation beendet wird. Schließlich liefern wir das Bild als Rückgabewert.
            //US: As the output is to be rendered to preview or printer, it cannot be processed asynchronously.
            //    This, we spawn the actual rendering process and wait for it to finish by using an AutoResetEvent
            //    for thread synchronization. Finally, we yield the image as return value.
            _map.MaxZoom = 18;
            _map.MinZoom = 0;
            _map.Zoom = Zoom;
            _map.Size = size;

            _map.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerOnly;


            // D: Ereignis, welches ausgelöst wird, sobald der Download abgeschlossen ist.
            //US: Event that is triggered once download has finished.
            _map.OnTileLoadComplete += new TileLoadComplete(Map_OnTileLoadComplete);

            PointLatLng? position = null;

            // D: Ermittlung der gewünschten Koordinate
            //US: Determine required position
            if (CoordinateEvaluationType == CoordinateEvaluation.GeoCoder)
            {
                if (!String.IsNullOrEmpty(City))
                {
                    GeoCoderStatusCode status;
                    position = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetPoint(City, out status);
                    if (position == null || status != GeoCoderStatusCode.OK)
                    {
                        return null;
                    }
                }
            }
            else
            {
                position = new PointLatLng(Latitude, Longitude);
            }
            _map.Position = position.Value;            
            _resetEvent.Reset();

            // D: Auslösen der Renderung
            //US: Trigger rendering
            _map.ToImage();

            // D: Warten auf Beendigung des Renderns
            //US: Wait for rendering to finish
            _resetEvent.WaitOne(new TimeSpan(0,0,0,0,1000));

            // D: Verwendung der Grafik
            //US: Grab image
            _image = _map.ToImage();

            // D: Hinzufügen von Überlagerungen falls erforderlich (-> Tooltip, Marker)
            //US: Add overlays if required (->tooltip, marker)
            Bitmap bmp = new Bitmap(_map.Size.Width, _map.Size.Height);
            GMapOverlay overlay = null; 
            _map.Overlays.Clear();
            if (ShowTooltip)
            {
                overlay = new GMapOverlay("Marker");
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(position.Value.Lat, position.Value.Lng), GMarkerGoogleType.red);
                marker.ToolTipText = TooltipText;
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTip.Font = new Font(TooltipFont.FontFamily, TooltipFont.Size * Resolution / 96, TooltipFont.Style, TooltipFont.Unit, TooltipFont.GdiCharSet);
                marker.ToolTip.Fill = new SolidBrush(TooltipBackgroundColor);
                overlay.Markers.Add(marker);
            }

            if (overlay != null)
            {
                _map.Overlays.Add(overlay);
            }
            _map.DrawToBitmap(bmp, new Rectangle(0, 0, _map.Size.Width, _map.Size.Height));

            _image = bmp;
            return _image;
        }


        public void Map_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            _resetEvent.Set();
        }

        private Size _lastRenderSize = new Size(0, 0);
        private int _lastHashCode = 0;
        private Image _lastImage = null;

        protected override void OnDrawDesignerObject(DrawDesignerObjectEventArgs e)
        {
            Size renderSize = new Size(Convert.ToInt32(CoordinateHelper.ConvertToPixel(e.ClipRectangle.Width, UnitSystem, Resolution)),
                                     Convert.ToInt32(CoordinateHelper.ConvertToPixel(e.ClipRectangle.Height, UnitSystem, Resolution)));

            bool objectChanged = DesignerProperties.GetHashCode() != _lastHashCode;
            bool sizeChanged = (renderSize != _lastRenderSize);
            if (sizeChanged || objectChanged)
            {
                _lastImage = RenderToImageSynchronous(renderSize);

                if (sizeChanged)
                    _lastRenderSize = renderSize;

                if(objectChanged)
                    _lastHashCode = DesignerProperties.GetHashCode();
            }

            if (_lastImage != null)
            {
                e.Graphics.DrawImage(_lastImage, e.ClipRectangle);
            }
        }
        
        protected override void OnPostCloneDesignerObject(PostCloneDesignerObjectEventArgs e)
        {
            MapsObject clone = (MapsObject)e.Clone;
            clone._map = new GMapControl();

            foreach (GMapOverlay overlay in _map.Overlays)
            {
                clone._map.Overlays.Add(overlay);
            }
            base.OnPostCloneDesignerObject(e);
        }

        private void UpdatePropertyStates(MapsObject obj)
        {
            switch (obj.CoordinateEvaluationType)
            {
                case CoordinateEvaluation.Coordinates:
                    {
                        obj.DesignerProperties["City"].Enabled = false;
                        obj.DesignerProperties["Latitude"].Enabled = true;
                        obj.DesignerProperties["Longitude"].Enabled = true;
                    }
                    break;
                case CoordinateEvaluation.GeoCoder:
                    {
                        obj.DesignerProperties["City"].Enabled = true;
                        obj.DesignerProperties["Latitude"].Enabled = false;
                        obj.DesignerProperties["Longitude"].Enabled = false;
                    }
                    break;
                default:
                    break;
            } 
        }
    }
}

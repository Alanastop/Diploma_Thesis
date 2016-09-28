using Android.App;
using Android.OS;
using Android.Widget;
using OsmSharp.Android.UI;
using OsmSharp.UI.Map;
using OsmSharp.UI.Map.Layers;
using OsmSharp.Math.Geo;
using OsmSharp.Android.UI.Controls;

using System;

namespace Droid.Demo

{
    [Activity(Label = "Experiment Activity")]
    public class Experiment : Activity
    {
        /// <summary>
        /// Holds the mapview.
        /// </summary>
        private MapView _mapView;

        private MapMarker _centerMarker;
        private Map myMap;
        private bool mBTilesButton_Clicked;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // hide title bar.
            this.RequestWindowFeature(global::Android.Views.WindowFeatures.NoTitle);

            mBTilesButton_Clicked = false;



            // initialize map.
            var map = new Map();

            // add tile Layer.
            // WARNING: Always look at usage policies!
            // WARNING: Don't use my tiles, it's a free account and will shutdown when overused!

            map.AddLayer(new LayerTile("http://192.168.1.101:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/ENC_ROOT/US1AK90M/1s57.map&&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=DEPARE&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=256&HEIGHT=256&FORMAT=image/png", 160));
            map.AddLayer(new LayerTile("http://192.168.1.101:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/ENC_ROOT/US1AK90M/1s57.map&&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=REPARE&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=256&HEIGHT=256&FORMAT=image/png", 160));
            map.AddLayer(new LayerTile("http://192.168.1.101:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/ENC_ROOT/US1AK90M/1s57.map&&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=TEPARE&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=256&HEIGHT=256&FORMAT=image/png", 160));
            map.AddLayer(new LayerTile("http://192.168.1.101:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/ENC_ROOT/US1AK90M/1s57.map&&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=NEPARE&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=256&HEIGHT=256&FORMAT=image/png", 160));
            map.AddLayer(new LayerTile("http://192.168.1.101:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/ENC_ROOT/US1AK90M/1s57.map&&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=MEPARE&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=256&HEIGHT=256&FORMAT=image/png", 160));
            map.AddLayer(new LayerTile("http://192.168.1.101:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/ENC_ROOT/US1AK90M/1s57.map&&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=LEPARE&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=256&HEIGHT=256&FORMAT=image/png", 160));
            map.AddLayer(new LayerTile("http://192.168.1.101:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/ENC_ROOT/US1AK90M/1s57.map&&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=KEPARE&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=256&HEIGHT=256&FORMAT=image/png", 160));
            // define the mapview.
            var mapViewSurface = new MapViewSurface(this);
            mapViewSurface.MapScaleFactor = 2;
            _mapView = new MapView(this, mapViewSurface);
            // _mapView.MapTapEvent += _mapView_MapTapEvent;
            _mapView.Map = map;
            _mapView.MapMaxZoomLevel = 17; // limit min/max zoom because MBTiles sample only contains a small portion of a map.
            _mapView.MapMinZoomLevel = 0;
            _mapView.MapTilt = 0;
            _mapView.MapCenter = new GeoCoordinate(69.123, -157.00);
            _mapView.MapZoom = 12;
            _mapView.MapAllowTilt = false;
            myMap = map;


            //AddMarkers();
            AddControls();




            // add the mapview to the linear layout.

            var layout = new RelativeLayout(this);
            var mBTilesButton = new Button(this);

            mBTilesButton.Text = "Offline Tiles Demo";

            mBTilesButton.Click += (sender, e) =>
            {
                if (mBTilesButton_Clicked == false)
                {
                    map.AddLayer(new LayerTile("http://192.168.1.101:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/ENC_ROOT/US1AK90M/1s57.map&&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=REPARE,airports&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=256&HEIGHT=256&FORMAT=image/png", 160));
                    mBTilesButton_Clicked = true;
                }
                else
                    map.AddLayer(new LayerTile("http://192.168.1.101:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/ENC_ROOT/US1AK90M/1s57.map&&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=REPARE&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=256&HEIGHT=256&FORMAT=image/png", 160));
                mBTilesButton_Clicked = false;
            };
            layout.AddView(mBTilesButton);

            layout.AddView(_mapView);
            // _centerMarker = _mapView.AddMarker(_mapView.MapCenter);

            // set the map view as the default content view.
            SetContentView(layout);








            // var imageResource = Resource.Drawable.marker;
            // var image = BitmapFactory.DecodeResource(this.Resources, imageResource);
            //var view =_mapView; //some subclass of view
            //var control = new MapControl<MapView>(view, new GeoCoordinate(21.58, 0.00), MapControlAlignmentType.Center, image.Width, image.Height);
            //view.SetBackgroundResource(imageResource);
            //_mapView.AddControl(control);
        }
        void AddControls()
        {
            var button = new Button(this.ApplicationContext);
            button.Text = "Some text here.";
            button.TextSize = 10;
            button.SetTextColor(global::Android.Graphics.Color.Black);

            var control = new MapControl<Button>(button, new GeoCoordinate(69.123, -157.00), MapControlAlignmentType.CenterBottom,
                100, 200);
            _mapView.AddControl(control);
        }


        private void _mapView_MapInitialized(OsmSharp.UI.IMapView mapView, float newZoom, OsmSharp.Units.Angle.Degree newTilt, GeoCoordinate newCenter)
        {
            // make sure the center marker stays in place from now on.
            _centerMarker.MoveWithMap = false;
        }

        void AddMarkers()
        {
            var from = new GeoCoordinate(69.123, -157.00);
            var to = new GeoCoordinate(70.267797, -160.801362);

            var box = new GeoCoordinateBox(from, to);

            _mapView.ClearMarkers();

            MapMarker marker;
            for (int idx = 0; idx < 20; idx++)
            {
                var pos = box.GenerateRandomIn();

                marker = new MapMarker(this, pos, MapControlAlignmentType.CenterBottom, this.Resources, Resource.Drawable.marker);
                var popupView = marker.AddNewPopup(100, 100);
                var textView = new TextView(this.ApplicationContext);
                textView.Text = "Some popup text here.";
                textView.TextSize = 10;
                textView.SetTextColor(global::Android.Graphics.Color.Black);
                popupView.AddView(textView);
                _mapView.AddMarker(marker);
            }
        }
        void View_Click(object sender, EventArgs e)
        {
            var marker = (sender as MapMarker);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            OsmSharp.Logging.Log.TraceEvent("MyTilesActivity", OsmSharp.Logging.TraceEventType.Information, _mapView.CurrentView.ToString());

            // dispose of all resources.
            // the mapview is completely destroyed in this sample, read about the Android Activity Lifecycle here:
            // http://docs.xamarin.com/guides/android/application_fundamentals/activity_lifecycle/
            _mapView.Map.Close();

            _mapView.Close();
            _mapView.Dispose();
        }

    }
}
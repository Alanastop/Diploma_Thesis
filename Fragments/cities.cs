using Android.OS;
using OsmSharp.Android.UI;
using OsmSharp.UI.Map;
using OsmSharp.UI.Map.Layers;
using OsmSharp.Math.Geo;
using Android.Widget;
using Android.Views;

namespace Droid.Demo.Fragments
{
    public class cities : Android.Support.V4.App.Fragment
    {
        private MapView _mapView;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);



            var layout = new RelativeLayout(Activity);


            // initialize map.
            var map = new Map();

            // add tile Layer.
            // WARNING: Always look at usage policies!
            // WARNING: Don't use my tiles, it's a free account and will shutdown when overused!

            map.AddLayer(new LayerTile("http://192.168.1.3:100/fcgi-bin/mapserv.exe?map=C:/ms4w/apps/CA_ENCs/ENC_ROOT/Cal.map&SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS=AEPARE,BEPARE,CEPARE,DEPARE,EEPARE,FEPARE,cities&STYLES=&CRS=EPSG:4326&BBOX=-90.0,-180.0,90.0,180.0&WIDTH=2048&HEIGHT=2048&FORMAT=image/jpeg", 160));

            // define the mapview.
            var mapViewSurface = new MapViewSurface(Activity);
            mapViewSurface.MapScaleFactor = 2;
            _mapView = new MapView(Activity, mapViewSurface);
            // _mapView.MapTapEvent += _mapView_MapTapEvent;
            _mapView.Map = map;
            _mapView.MapMaxZoomLevel = 17; // limit min/max zoom because MBTiles sample only contains a small portion of a map.
            _mapView.MapMinZoomLevel = 0;
            _mapView.MapTilt = 0;
            _mapView.MapCenter = new GeoCoordinate(69.123, -157.00);
            _mapView.MapZoom = 0;
            _mapView.MapAllowTilt = false;


          
            layout.AddView(_mapView);
            // _centerMarker = _mapView.AddMarker(_mapView.MapCenter);
         

            return layout;
        }
    }
    }


using Android.App;
using Android.OS;
using Android.Gms.Maps;

namespace Droid.Demo
{
    [Activity(Label = "Gmaps")]
    public class Gmaps : Activity, IOnMapReadyCallback
    {
        private GoogleMap gMap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.gMaps);
            SetupMap();
           
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            gMap = googleMap;
        }

        private void SetupMap()
        {
            if (gMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }
    }
    }

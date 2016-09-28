
using Android.App;
using Android.Widget;
using Android.OS;
using OsmSharp.Android.UI;

namespace Droid.Demo
{
    [Activity(Label = "MAPS")]
    public class MyActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // initialize OsmSharp native hooks.
            Native.Initialize();

            // enable the logging.
            OsmSharp.Logging.Log.Enable();
            OsmSharp.Logging.Log.RegisterListener(new OsmSharp.Android.UI.Log.LogTraceListener());

            base.OnCreate(bundle);

            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

             

        

            var paradigm = new Button(this);
            paradigm.Text = "s57 map";
            paradigm.Click += (sender, e) =>
            {
                StartActivity(typeof(Fragments.MyTilesActivity));
            };
            layout.AddView(paradigm);


          
            var MyGMAp = new Button(this);
            MyGMAp.Text = "Gmap";
            MyGMAp.Click += (sender, e) =>
            {
                StartActivity(typeof(Gmaps));
            };
            layout.AddView(MyGMAp);

            SetContentView(layout);
        }
    }
}



using Android.App;
using Android.OS;
using Android.Widget;

using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace Droid.Demo
{
    [Activity(Label = "BaseTiles", Theme = "@style/CustomActionBarTheme")]
    public abstract class BaseTiles : AppCompatActivity
    {
        public Android.Support.V7.Widget.Toolbar Toolbar
        {
            get;
            set;
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(LayoutResource);
            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
               
            }
        }

        protected abstract int LayoutResource
        {
            get;
        }

        protected int ActionBarIcon
        {
            set { Toolbar.SetNavigationIcon(value); }
        }
    }


}
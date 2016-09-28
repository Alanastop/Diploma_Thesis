using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Gms.Maps;

namespace Droid.Demo.Fragments
{
    [Activity(Label = "MyTilesActivity", Theme = "@style/CustomActionBarTheme")]
    public class MyTilesActivity : BaseTiles
    {

        NavigationView navigationView;
        DrawerLayout mDrawerLayout;



        protected override int LayoutResource
        {
            get
            {

                return Resource.Layout.layout;

            }
        }

        protected override void OnCreate(Bundle savedInstance)
        {
            base.OnCreate(savedInstance);




            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.myDrawer);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            





            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.myMap:
                        ListItemClicked(0);
                        break;
                    case Resource.Id.airports:
                        ListItemClicked(1);
                        break;
                    case Resource.Id.cities:
                        ListItemClicked(2);
                        break;
                    case Resource.Id.allInfo:
                        ListItemClicked(3);
                        break;
                    case Resource.Id.restFul:
                        ListItemClicked(4);
                        break;
                    case Resource.Id.restFulCity:
                        ListItemClicked(5);
                        break;
                }
                mDrawerLayout.CloseDrawers();
            };





            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetTitle(Resource.String.california);

            if (savedInstance == null)
            {

                ListItemClicked(0);
            }

        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);

                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }





        private void ListItemClicked(int position)
        {
            Android.Support.V4.App.Fragment fragment = null;

            switch (position)
            {
                case 0:
                    fragment = new MyMap();
                    SupportActionBar.SetTitle(Resource.String.california);
                    break;
                case 1:
                    fragment = new airports();
                    SupportActionBar.SetTitle(Resource.String.california_airports);
                    break;
                case 2:
                    fragment = new cities();
                    SupportActionBar.SetTitle(Resource.String.california_cities);
                    break;
                case 3:
                    fragment = new allInfo();
                    SupportActionBar.SetTitle(Resource.String.california);
                    break;
                case 4:
                    fragment = new Restful();
                    SupportActionBar.SetTitle(Resource.String.airport);
                    break;
                case 5:
                    fragment = new RestfulCities();
                    SupportActionBar.SetTitle(Resource.String.city);
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                   .Replace(Resource.Id.fragmentContainer, fragment)
                   .Commit();


        }

    }

}

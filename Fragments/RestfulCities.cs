using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Droid.Demo.Fragments
{
    public class RestfulCities : Android.Support.V4.App.Fragment
    {
        Button viewCities;
        Button insertCity;
        Button deleteCity;



        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {



            Android.Support.V4.App.Fragment fragment = null;
            var view = inflater.Inflate(Resource.Layout.RestfulCities, container, false);
            viewCities = view.FindViewById<Button>(Resource.Id.btn1);
            insertCity = view.FindViewById<Button>(Resource.Id.btn2);
            deleteCity = view.FindViewById<Button>(Resource.Id.btn3);

            viewCities.Click += (sender, e) =>
            {
                fragment = new ViewCities();
                var trans = ChildFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.fragmentContainer1, fragment);
                trans.Commit();


            };

            insertCity.Click += (sender, e) =>
            {
                fragment = new InsertCity();
                var trans = ChildFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.fragmentContainer1, fragment);
                trans.Commit();


            };

            deleteCity.Click += (sender, e) =>
            {
                fragment = new DeleteCity();
                var trans = ChildFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.fragmentContainer1, fragment);
                trans.Commit();


            };


            return view;







        }
    }
}
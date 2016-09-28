using Android.OS;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using Droid.Demo.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Droid.Demo.Fragments
{
    public class Restful : Android.Support.V4.App.Fragment
    {
        Button ViewAirports;
        Button InsertAirport;
        Button DeleteAirport;

        

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {



            Android.Support.V4.App.Fragment fragment = null;
            var view = inflater.Inflate(Resource.Layout.RestfulLayout, container, false);
            ViewAirports = view.FindViewById<Button>(Resource.Id.button1);
            InsertAirport = view.FindViewById<Button>(Resource.Id.button2);
            DeleteAirport = view.FindViewById<Button>(Resource.Id.button3);


            ViewAirports.Click += (sender, e) =>
            {
                fragment = new ViewAirports();
                var trans = ChildFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.fragmentContainer, fragment);
                trans.Commit();


            };

            InsertAirport.Click += (sender, e) =>
            {
                 fragment = new InsertAirport();
                 var trans = ChildFragmentManager.BeginTransaction();
                 trans.Replace(Resource.Id.fragmentContainer, fragment);
                 trans.Commit();


            };

           DeleteAirport.Click += (sender, e) =>
            {
                fragment = new DeleteAirport();
                var trans = ChildFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.fragmentContainer, fragment);
                trans.Commit();


            };


            return view;
          






        }
      
    }
}
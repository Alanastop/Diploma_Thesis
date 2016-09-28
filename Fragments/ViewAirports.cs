using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using Droid.Demo.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Droid.Demo.Fragments
{
    public class ViewAirports : Android.Support.V4.App.Fragment
    {
        private ListView listView;
        private List<String> list;
        private Button button;
       
        public async Task<List<Entry>> TopEntriesAsync()
        {
            var client = new HttpClient();

            var result = await client.GetStringAsync("http://192.168.1.3//api/AirportAPI/GetAllAirport");
            Console.Out.WriteLine(result);
            return JsonConvert.DeserializeObject<List<Entry>>(result);
           
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.viewAirports, container, false);
            listView = view.FindViewById<ListView>(Resource.Id.listView1);
            button = view.FindViewById<Button>(Resource.Id.button1);


            button.Click += async (sender, e) => {
               
                IEnumerable<Entry> airport = await TopEntriesAsync();
                list = airport.Select(x =>  x.name).ToList();
                
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItem1, list);
                listView.Adapter = adapter;
                Console.Out.WriteLine(airport);
             
            };
            

            return view;
        }

       
    }

}
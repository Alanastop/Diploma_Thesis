using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Droid.Demo.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace Droid.Demo.Fragments
{

    public class DeleteAirport : Android.Support.V4.App.Fragment
    {
        private List<string> list;
        private EditText textName;
        private Button confirmButton;
        
     public async Task<string> TopEntriesAsync(string Id)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("http://192.168.1.3//api/AirportAPI/DeleteAirport/"+ Id);
            Console.Out.WriteLine(result);
            return JsonConvert.DeserializeObject<string>(result);

        }

        public async Task<List<Entry>> TopEntriesAsync1()
        {
            var client = new HttpClient();

            var result = await client.GetStringAsync("http://192.168.1.3//api/AirportAPI/GetAllAirport");
            Console.Out.WriteLine(result);
            return JsonConvert.DeserializeObject<List<Entry>>(result);

        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.deleteAirport, container, false);
            textName = view.FindViewById<EditText>(Resource.Id.txtName1);
            confirmButton = view.FindViewById<Button>(Resource.Id.btnConfirm1);

            

            confirmButton.Click += async (sender, e) => {

                textName.Text.ToString();
                IEnumerable<Entry> airport =  await TopEntriesAsync1();
                list = airport.Where(x => x.name == textName.Text).Select(x => x.Id).ToList();
                int count = list.Count;
                if (count == 1)
                {
                    foreach (string element in list)
                        await TopEntriesAsync(element);
                    Toast.MakeText(Activity, "Airport: " + textName.Text + " deleted successfully!", ToastLength.Long).Show();
                    return;
                }
                else
                {
                   Toast.MakeText(Activity, "Airport: " + textName.Text +" doesn't exist!", ToastLength.Long).Show();
                    return;
                }



            };

            return view;
        }
        
    }
}
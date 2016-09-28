using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace Droid.Demo.Models
{
    class Page
    {
        public int Next { get; set; }
        public IEnumerable<Entry> Items { get; set; }
    }
}
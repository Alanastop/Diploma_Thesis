using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace WebApiForAndroid.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public DbGeometry ogr_geometry { get; set; }
        public string name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
       
    }
}
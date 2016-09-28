using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiForAndroid.Models;

namespace WebApiForAndroid.DBA
{
    public class ApiDbContext :DbContext
    {
        public ApiDbContext() : base("Connection")
        {
          
        }

        public virtual DbSet<Airport> Airports { get; set; }

        public virtual DbSet<City> Cities { get; set; }
    }
}
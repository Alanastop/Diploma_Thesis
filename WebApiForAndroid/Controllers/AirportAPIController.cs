using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiForAndroid.DBA;
using WebApiForAndroid.Models;
using Microsoft.SqlServer.Types;
using System.Data.Entity.Spatial;

namespace WebApiForAndroid.Controllers
{
    public class AirportAPIController : ApiController
    {
        ApiDbContext dbContext = null;
        public AirportAPIController()
        {
            dbContext = new ApiDbContext();
        }

        [HttpPost]
        public IHttpActionResult InsertAirport(Airport airport)
        {


            var SPAT_REF_ID = 4326;
            var s = new SqlChars(new SqlString(string.Format("POINT({0} {1})", airport.lon, airport.lat)));
            var geo = SqlGeometry.STPointFromText(s, SPAT_REF_ID);
            airport.ogr_geometry = DbGeometry.FromBinary(geo.STAsBinary().Buffer, 4326);
            dbContext.Airports.Add(airport);
            dbContext.SaveChangesAsync();

            return Ok(airport.Id);
        }

        public IEnumerable<Columns> GetAllAirport()
        {

            var dataset2 =
           (from recordset in dbContext.Airports

            select new Columns
            {
                Id = recordset.Id,
                name = recordset.name,


            }).ToList();

            var list = dataset2;
            return list;
        }

        [HttpGet]
        public IHttpActionResult DeleteAirport(int id)
        {
            var airport = dbContext.Airports.Find(id);

            dbContext.Airports.Remove(airport);

            dbContext.SaveChangesAsync();

            return Ok(airport.name + " is deleted successfully.");

        }

        [HttpGet]
        public IHttpActionResult ViewAirport(int id)
        {
            var airport = dbContext.Airports.Find(id);
            return Ok(airport);
        }


        [HttpPost]
        public IHttpActionResult UpdateAirport(Airport airport)
        {

            var SPAT_REF_ID = 4326;
            var s = new SqlChars(new SqlString(string.Format("POINT({0} {1})", airport.lon, airport.lat)));
            var geo = SqlGeometry.STPointFromText(s, SPAT_REF_ID);
            airport.ogr_geometry = DbGeometry.FromBinary(geo.STAsBinary().Buffer, 4326);

            var arpt = dbContext.Airports.Find(airport.Id);

            arpt.ogr_geometry = airport.ogr_geometry;
            arpt.name = airport.name;
            arpt.lat = airport.lat;
            arpt.lon = airport.lon;

            dbContext.Entry(arpt).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult InsertCity(City city)
        {
            var SPAT_REF_ID = 4326;
            var s = new SqlChars(new SqlString(string.Format("POINT({0} {1})", city.lon, city.lat)));
            var geo = SqlGeometry.STPointFromText(s, SPAT_REF_ID);
            city.ogr_geometry = DbGeometry.FromBinary(geo.STAsBinary().Buffer, 4326);

            dbContext.Cities.Add(city);
            dbContext.SaveChangesAsync();

            return Ok(city.Id);
        }

        public IEnumerable<Columns> GetAllCity()
        {

            var dataset2 =
           (from recordset in dbContext.Cities

            select new Columns
            {
                Id = recordset.Id,
                name = recordset.name,


            }).ToList();

            var list = dataset2;
            return list;
        }

        [HttpGet]
        public IHttpActionResult DeleteCity(int id)
        {
            var city = dbContext.Cities.Find(id);

            dbContext.Cities.Remove(city);

            dbContext.SaveChangesAsync();

            return Ok(city.name + " is deleted successfully.");

        }

        [HttpGet]
        public IHttpActionResult ViewCity(int id)
        {
            var city = dbContext.Cities.Find(id);
            return Ok(city);
        }


        [HttpPost]
        public IHttpActionResult UpdateCity(Airport city)
        {

            var SPAT_REF_ID = 4326;
            var s = new SqlChars(new SqlString(string.Format("POINT({0} {1})", city.lon, city.lat)));
            var geo = SqlGeometry.STPointFromText(s, SPAT_REF_ID);
            city.ogr_geometry = DbGeometry.FromBinary(geo.STAsBinary().Buffer, 4326);

            var arpt = dbContext.Cities.Find(city.Id);

            arpt.ogr_geometry = city.ogr_geometry;
            arpt.name = city.name;
            arpt.lat = city.lat;
            arpt.lon = city.lon;

            dbContext.Entry(arpt).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
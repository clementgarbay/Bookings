using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using Newtonsoft.Json;
using Bookings;
using System.ComponentModel;

namespace WebServices.Controllers
{
    public class TripsController: ApiController
    {
        // GET api/trips
        public IEnumerable<string> Get()
        {
            return new string[] { "trip1", "trip2" };
        }

        // POST api/trips
        public void Post([FromBody]dynamic value)
        {
            Console.WriteLine(value);
            BookingsData data = new BookingsData();

            // flight
            data.departure_city = get(data, "departure_city");
            data.departure_date = value.GetType().GetProperty("departure_date").GetValue(value, null);
            data.arrival_city = get(data, "arrival_city");
            data.company = get(data, "company");

            // hotel
            data.city = get(data, "city");
            data.name = get(data, "name");
            data.rating = get(data, "rating");

            // user
            data.rib = get(data, "rib");
            data.email = get(data, "email");
            data.first_name = get(data, "first_name");
            data.last_name = get(data, "last_name");


            BookingsManager b = new BookingsManager();
            b.Reserve(data);


            //DataTable dt = ConvertToDataTable(value);
            //Console.WriteLine(dt);
            /* JObject json = JObject.Parse(value);
             Console.WriteLine("receive post");
             DataTable dt = JsonConvert.DeserializeObject<DataTable>(json.ToString());
             BookingsManager b = new BookingsManager();
             b.Reserve(dt);*/
        }

        private string get(dynamic value, string identifier)
        {
            return value.GetType().GetProperty(identifier).GetValue(value, null);
        }
        
    }
}

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
        public void Post([FromBody] BookingsData data)
        {
            Console.WriteLine(data);
            /*BookingsData data = new BookingsData();

            // flight
            data.departure_city = get(value, "departure_city");
            data.departure_date = value.GetType().GetProperty("departure_date").GetValue(value, null);
            data.arrival_city = get(value, "arrival_city");
            data.company = get(value, "company");

            // hotel
            data.city = get(value, "city");
            data.name = get(value, "name");
            data.rating = get(value, "rating");

            // user
            data.rib = get(value, "rib");
            data.email = get(value, "email");
            data.first_name = get(value, "first_name");
            data.last_name = get(value, "last_name");
            */

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

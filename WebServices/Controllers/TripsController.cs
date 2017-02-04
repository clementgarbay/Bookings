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
            BookingsManager b = new BookingsManager();
            b.Reserve(data);
        }
    }
}

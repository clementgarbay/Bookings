using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebServices.Controllers
{
    public class FlightsController : ApiController
    {
        [System.Web.Http.Route("api/flights/{departureCity}/{arrivalCity}")]
        public IEnumerable<string> Get(string departureCity, string arrivalCity)
        {
            return new string[] { "flight1", "flight2" };
        }

        [System.Web.Http.Route("api/flights/{departureCity}")]
        public IEnumerable<string> GetArrivalCities(string departureCity)
        {
            return new string[] { "arrivalCity1", "arrivalCity2" };
        }

        public IEnumerable<string> GetDepartureCities()
        {
            return new string[] {"departureCityOne", "departureCityTwo"};
        }
    }
}

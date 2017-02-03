using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace WebServices.Controllers
{
    public class FlightsController : ApiController
    {
        private Flights.Flights flightsManager = new Flights.Flights();

        [Route("api/flights/{departureCity}/{arrivalCity}")]
        public IEnumerable<string> Get(string departureCity, string arrivalCity)
        {
            DataSet res = flightsManager.Get(departureCity, arrivalCity);
            return new string[] { "flight1", "flight2" };
        }

        [Route("api/flights/{departureCity}")]
        public IEnumerable<string> GetArrivalCities(string departureCity)
        {
            return new string[] { "arrivalCity1", "arrivalCity2" };
        }

        // GET api/flights -> departure cities
        public IEnumerable<string> GetDepartureCities()
        {
            return new string[] {"departureCityOne", "departureCityTwo"};
        }
    }
}

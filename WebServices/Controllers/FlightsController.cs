using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebServices.Controllers
{
    public class FlightsController : ApiController
    {
        private readonly Flights.Flights flightsManager = new Flights.Flights();

        [System.Web.Http.Route("api/flights/{departureCity}/{arrivalCity}")]
        public HttpResponseMessage Get(string departureCity, string arrivalCity)
        {
            return ConformJsonResponse(flightsManager.Get(departureCity, arrivalCity));
        }

        [System.Web.Http.Route("api/flights/{departureCity}")]
        public HttpResponseMessage GetArrivalCities(string departureCity)
        {
            return ConformJsonResponse(flightsManager.GetArrivalCities(departureCity));
        }

        // GET api/flights -> departure cities
        public HttpResponseMessage GetDepartureCities()
        {
            return ConformJsonResponse(flightsManager.GetDepartureCities());
        }

        protected HttpResponseMessage ConformJsonResponse(DataSet dataSet)
        {
            string result = JsonConvert.SerializeObject(dataSet.Tables[0]);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json");

            return response;
        }
    }
}

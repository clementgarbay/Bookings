
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hotels;
using Newtonsoft.Json;

namespace WebServices.Controllers
{
    public class HotelsController : ApiController
    {
        Hotels.Hotels hotelsManager = new Hotels.Hotels();

        [Route("api/hotels/{city}")]
        public HttpResponseMessage Get(string city)
        {
            return ConformJsonResponse(hotelsManager.Get(city));
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

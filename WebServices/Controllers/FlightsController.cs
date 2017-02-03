using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebServices.Controllers
{
    public class FlightsController : ApiController
    {
        // GET api/flights
        public IEnumerable<string> Get()
        {
            return new string[] { "flight1", "flight2" };
        }
    }
}

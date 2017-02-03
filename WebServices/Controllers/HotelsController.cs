
using System.Collections.Generic;
using System.Web.Http;

namespace WebServices.Controllers
{
    public class HotelsController : ApiController
    {
        [Route("api/hotels/{city}")]
        public IEnumerable<string> Get(string city)
        {
            return new string[] { "hotel1", "hotel2" };
        }
    }
}

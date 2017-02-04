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
using BookingsManager;

namespace WebServices.Controllers
{
    public class QueueController: ApiController
    {
        // GET api/queue
        public IEnumerable<string> Get()
        {
            Console.WriteLine("Bonjour");
            QueueConsumer consumer = new QueueConsumer();
            consumer.consume();
            return new string[] { };
        }
    }
}

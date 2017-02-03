using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    public class BookingsManager
    {

        private const string QUEUE_NAME = "bankings";

        public BookingsManager()
        {

        }

        public void Reserve(BookingsData data)
        {
            Console.WriteLine("Reserving : " + data);
            MessageAppender appender = new MessageAppender(QUEUE_NAME);
            appender.append(data);
        }

    }


    public class MessageAppender
    {

        private string queueName;

        public MessageAppender(string queue)
        {
            queueName = queue;
        }

        public void append(BookingsData bookingData)
        {
            MessageQueue MyMQ = new MessageQueue(@".\private$\" + queueName);
            MyMQ.Send(bookingData, "Transfert");
            MyMQ.Close();
        }
    }


    public class BookingsData
    {
        // flight
        public string departure_city { get; set; }
        public DateTime departure_date { get; set; }
        public string arrival_city { get; set; }
        public string company { get; set; }

        // hotel
        public string city { get; set; }
        public string name { get; set; }
        public string rating { get; set; }

        // user
        public string rib { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

}

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
        public string departure_city;
        public DateTime departure_date;
        public string arrival_city;
        public string company;

        // hotel
        public string city;
        public string name;
        public string rating;

        // user
        public string rib;
        public string email;
        public string first_name;
        public string last_name;
    }

}

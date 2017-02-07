using BookingFlights;
using BookingHotels;
using Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BookingsManager
{
    public class Bookings
    {
        public bool book(BookingsData data)
        {
            bool addSuccess = false;

            Flights flights = new Flights();
            Hotels hotels = new Hotels();
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    flights.add(data);
                    hotels.add(data);
                    addSuccess = true;
                    transaction.Complete();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error when BookingManager.book " + e);
                    //throw e;
                }
            }
            return addSuccess;
        }
    }


    public class QueueConsumer
    {

        private const string QUEUE_NAME = "bankings";


        public void consume()
        {
            //ouverture de la file MSMQ
            MessageQueue MyMQ = new MessageQueue(@".\private$\" + QUEUE_NAME);
            //récupération sans vider la file d'un message, de type TransfertInfo
            MyMQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(BookingsData) });

            var message = (BookingsData)MyMQ.Peek().Body;

            Bookings bookings = new Bookings();

            //Tranfert en mode transactionnel
            bool ResT = bookings.book(message);
            //Transaction OK
            if (ResT == true)
            {
                //txtTransfert.AppendText("Transfert de " + message.Montant + " du compte " + message.CD + " vers " + message.CC + "\n");
                //Zone critique : le Receive devrait être sous forme de composant lui aussi dans le serveur d'application
                MyMQ.Receive();
            }
            //Transaction KO
            else
            {
                //txtTransfert.AppendText("Impossible de transférer " + message.Montant + " du compte " + message.CD + " vers " + message.CC + "\n");
            }
            MyMQ.Close();
        }
    }
}

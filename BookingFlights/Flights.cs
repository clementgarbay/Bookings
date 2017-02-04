using Bookings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights
{
    public class Flights
    {

        public void add(BookingsData data)
        {

            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=BOOKINGS_FLIGHTS;Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("CMD_ADD", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters.Add("@departure_city", SqlDbType.Text);
            MyCom.Parameters["@departure_city"].Value = data.departure_city;
            MyCom.Parameters.Add("@departure_date", SqlDbType.DateTime);
            MyCom.Parameters["@departure_date"].Value = data.departure_date;
            MyCom.Parameters.Add("@arrival_city", SqlDbType.Text);
            MyCom.Parameters["@arrival_city"].Value = data.arrival_city;
            MyCom.Parameters.Add("@company", SqlDbType.Text);
            MyCom.Parameters["@company"].Value = data.company;
            MyCom.Parameters.Add("@city", SqlDbType.Text);
            MyCom.Parameters.Add("@email", SqlDbType.Text);
            MyCom.Parameters["@email"].Value = data.email;
            MyCom.Parameters.Add("@first_name", SqlDbType.Text);
            MyCom.Parameters["@first_name"].Value = data.first_name;
            MyCom.Parameters.Add("@last_name", SqlDbType.Text);
            MyCom.Parameters["@last_name"].Value = data.last_name;
            MyCom.ExecuteScalar();
            //int Res = Convert.ToInt32(MyCom.ExecuteScalar());
            MyCom.Dispose();
            MyC.Close();
            //return Res;
        }

    }
}

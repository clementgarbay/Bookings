using Bookings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotels
{
    public class Hotels
    {
        public void add(BookingsData data)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local);Initial Catalog=BOOKINGS_HOTELS;Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("CMD_ADD", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters["@city"].Value = data.city;
            MyCom.Parameters.Add("@name", SqlDbType.Text);
            MyCom.Parameters["@name"].Value = data.name;
            MyCom.Parameters.Add("@rating", SqlDbType.Text);
            MyCom.Parameters["@rating"].Value = data.rating;
            MyCom.Parameters.Add("@rib", SqlDbType.Text);
            MyCom.Parameters["@rib"].Value = data.rib;
            MyCom.Parameters.Add("@email", SqlDbType.Text);
            MyCom.Parameters["@email"].Value = data.email;
            MyCom.Parameters.Add("@first_name", SqlDbType.Text);
            MyCom.Parameters["@first_name"].Value = data.first_name;
            MyCom.Parameters.Add("@last_name", SqlDbType.Text);
            MyCom.Parameters["@last_name"].Value = data.last_name;
            //int Res = Convert.ToInt32(MyCom.ExecuteScalar());
            MyCom.ExecuteScalar();
            MyCom.Dispose();
            MyC.Close();
            //return Res;
        }
    }
}

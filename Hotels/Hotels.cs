using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    public class Hotels
    {
        public DataSet getHotels()
        {
//            SqlConnection connection = new SqlConnection();
//            connection.ConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=BOOKINGS_FLIGHTS_READ_ONLY;Integrated Security=True";
//            connection.Open();
//
//            SqlCommand command = new SqlCommand("sp_credit", connection);
//            command.CommandType = CommandType.StoredProcedure;
//
//            command.Parameters.Add("@NC", SqlDbType.Int, sizeof(int));
//            command.Parameters["@NC"].Value = Num;
//
//            command.Parameters.Add("@M", SqlDbType.Int, sizeof(int));
//            command.Parameters["@M"].Value = Montant;
//
//            int res = Convert.ToInt16(command.ExecuteScalar());
//
//            connection.Close();
//            return res;

            return new DataSet();
        }
    }
}

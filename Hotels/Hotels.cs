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
        SqlConnection connection = new SqlConnection();

        public Hotels()
        {
            connection.ConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=BOOKINGS_HOTELS_READ_ONLY;Integrated Security=True";

        }

        public DataSet Get(string city)
        {
            return GetPreparedCommand("CMD_GET_HOTELS",
                new Dictionary<string, Tuple<SqlDbType, String>>()
                {
                    {"@city",  Tuple.Create(SqlDbType.VarChar, city) },
                }
            );
        }

        protected DataSet GetPreparedCommand(String storedProcedureName, Dictionary<String, Tuple<SqlDbType, String>> parameters)
        {
            connection.Open();
            DataSet ds = new DataSet(storedProcedureName);

            SqlCommand command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            foreach (var keyValuePair in parameters)
            {
                command.Parameters.Add(keyValuePair.Key, keyValuePair.Value.Item1);
                command.Parameters[keyValuePair.Key].Value = keyValuePair.Value.Item2;
            }

            SqlDataAdapter da = new SqlDataAdapter { SelectCommand = command };

            da.Fill(ds);
            connection.Close();

            return ds;
        }
    }
}

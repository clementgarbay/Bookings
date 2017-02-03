using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Flights
{
    public class Flights
    {
        SqlConnection connection = new SqlConnection();

        public Flights()
        {
            connection.ConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=BOOKINGS_FLIGHTS_READ_ONLY;Integrated Security=True";

        }

        public DataSet Get(string departureCity, string arrivalCity)
        {
            return GetPreparedCommand("CMD_GET_ARRIVAL_CITY",
                new Dictionary<string, Tuple<SqlDbType, String>>()
                {
                    {"@departure_city",  Tuple.Create(SqlDbType.VarChar, departureCity) },
                    { "@arrival_city", Tuple.Create(SqlDbType.VarChar, arrivalCity)}
                } 
            );
        }

        public DataSet GetArrivalCities(string departureCity)
        {
            return GetPreparedCommand("CMD_GET_FLIGHTS",
                new Dictionary<string, Tuple<SqlDbType, String>>()
                {
                    {"@departure_city",  Tuple.Create(SqlDbType.VarChar, departureCity) }
                }
            );
        }

        public DataSet GetDepartureCities()
        {
            return GetPreparedCommand("CMD_GET_DEPARTURE_CITY", new Dictionary<string, Tuple<SqlDbType, string>>());
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

            SqlDataAdapter da = new SqlDataAdapter {SelectCommand = command};

            da.Fill(ds);
            connection.Close();

            return ds;
        }
    }
}

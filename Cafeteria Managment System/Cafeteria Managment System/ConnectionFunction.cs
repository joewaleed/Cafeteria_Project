using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;

namespace Cafeteria_Managment_System {
    class ConnectionFunction {
        private SqlConnection connection;
        private SqlCommand command;
        private DataTable table;
        private SqlDataAdapter adapter;
        private string connectionSTR;

        public ConnectionFunction() { 
            connectionSTR = @"Server=localhost;Database=CafeteriaDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
            connection = new SqlConnection(connectionSTR);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public DataTable GetData(string Query) {
            table = new DataTable();
            adapter = new SqlDataAdapter(Query,connectionSTR);
            adapter.Fill(table);
            return table;
        }

        public int SetData(string Query) {
            int counter = 0;
            if(connection.State == ConnectionState.Closed) connection.Open();
            command.CommandText = Query;
            counter = command.ExecuteNonQuery();
            connection.Close();
            return counter;
        }
    }
}

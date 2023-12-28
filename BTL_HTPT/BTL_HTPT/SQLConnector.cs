using System;
using System.Data;
using System.Data.SqlClient;


namespace BTL_HTPT
{
    class SQLConnector
    {
        private string connectionString;

        public SQLConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public DataTable GetTable(string query)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(table);
                    }
                }
            }
            return table;
        }

        public bool ExecuteStoredProcedure(string storedProcedureName, SqlParameter[] parameters)
        {
            bool isSuccess = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        isSuccess = true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error executing stored procedure: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error executing stored procedure: {ex.Message}");
                    }
                }
            }
            return isSuccess;
        }


    }
}

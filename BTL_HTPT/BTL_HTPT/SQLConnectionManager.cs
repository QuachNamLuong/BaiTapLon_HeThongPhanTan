using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace BTL_HTPT
{
    class SQLConnectionManager
    {
        private SqlConnection connection;
        private SqlConnectionStringBuilder connectionStringBuilder;
        public SqlConnection Connection => connection;
        public SqlConnectionStringBuilder ConnectionStringBuilder => connectionStringBuilder;

        public SQLConnectionManager(string connectionString)
        {
            connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            connection = new SqlConnection(connectionString);
            try
            {
                if (connection == null)
                {
                    throw new ArgumentNullException();
                }
                connection.Open();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public DataTable GetTable(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            try
            {
                if (cmd == null)
                {
                   throw new ArgumentNullException(nameof(cmd), "SqlCommand cannot be null.");
                }

                if (Connection == null)
                {
                    throw new InvalidOperationException("Connection is not initialized.");
                }

                cmd.Connection = Connection;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTable: {ex.Message}");
            }

            return table;
        }

        public bool ExecuteQuery(SqlCommand cmd)
        {
            bool isSucess = false;
            try
            {
                if (cmd == null)
                {
                    throw new ArgumentNullException(nameof(cmd), "SqlCommand cannot be null.");
                }

                if (Connection == null)
                {
                    throw new InvalidOperationException("Connection is not initialized.");
                }

                Connection.Open();
                cmd.Connection = Connection;
                cmd.ExecuteNonQuery();
                isSucess = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Server Error: {ex.Number}, Message: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
            return isSucess;
        }
    }
}

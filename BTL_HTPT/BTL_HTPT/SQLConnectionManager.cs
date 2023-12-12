using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_HTPT
{
    class SQLConnectionManager
    {
        private string serverName = "", databaseName = "", userID = "", password = "";

        private SqlConnection connection;

        public SqlConnection Connection => connection;

        public string ConnectionString => connection.ConnectionString;

        public string ServerName
        {
            get => serverName;

            set
            {
                if (value != null)
                {
                    serverName = value;
                }
            }
        }

        public string DatabaseName
        {
            get => databaseName;

            set
            {
                if (value != null)
                {
                    databaseName = value;
                }
            }
        }

        public string UserID
        {
            get => userID;

            set
            {
                userID = value;
            }
        }

        public string Password
        {
            get => password;

            set
            {
                if (value != null)
                {
                    password = value;
                }
            }
        }

        public bool Login()
        {
            bool check = true;
            try
            {
                if (connection != null)
                {
                    connection.Dispose();
                    connection = null;
                }
                connection = new SqlConnection
                {
                    ConnectionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userID};Password={password};"
                };
                connection.Open();
                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Class CSConnectSQL error: " + e.Message);
                check = false;
            }
            return check;
        }

        public bool Login(string serverName, string databaseName, string userID, string password)
        {
            bool check = true;
            try
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
                connection = new SqlConnection
                {
                    ConnectionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userID};Password={password};"
                };
                connection.Open();
                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Class CSConnectSQL error: " + e.Message);
                check = false;
            }
            return check;
        }

        public bool Open()
        {
            bool check = true;
            if (Connection != null && connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Class CSConnectSQL error: " + e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                }
            }
            else
            {
                check = false;
            }
            return check;
        }

        public bool Close()
        {
            bool check = true;
            if (connection != null && connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Class CSConnectSQL error: " + e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                }
            }
            return check;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            if (connection != null)
            {
                try
                {
                    Open();
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Class CSConnectSQL error: " + e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataTable;
        }

        public DataTable ExecuteQuery(SqlCommand cmd)
        {
            DataTable dataTable = new DataTable();
            if (connection != null)
            {
                try
                {
                    Open();
                    cmd.Connection = connection;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                    Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Class CSConnectSQL error: " + e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataTable;
        }



        public bool ExecuteNonQuery(string sql)
        {
            bool check = true;
            try
            {
                Open();
                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    command.ExecuteNonQuery();
                }
                Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Class CSConnectSQL error: " + e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = false;
            }
            return check;
        }

        public bool ExecuteNonQuery(SqlCommand cmd)
        {
            bool check = true;
            try
            {
                Open();
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Class CSConnectSQL error: " + e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = false;
            }
            return check;
        }

        public object ExecuteScalar(string sql)
        {
            object res = null;
            try
            {
                Open();
                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    res = command.ExecuteScalar();
                }
                Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Class CSConnectSQL error: " + e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }
        public object ExecuteScalar2(string storedProcedureName, SqlParameter[] parameters)
        {
            object res = null;
            try
            {
                Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    res = command.ExecuteScalar();
                }
                Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Class CSConnectSQL error: " + e.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res;
        }


        public object ExecuteScalar(SqlCommand cmd)
        {
            object res = null;
            try
            {
                Open();
                res = cmd.ExecuteScalar();
                Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Class CSConnectSQL error: " + e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                res = new object();
            }
            return res;
        }
    }
}

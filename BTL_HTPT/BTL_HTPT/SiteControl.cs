using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dotmim.Sync.SqlServer;
using Dotmim.Sync;

namespace BTL_HTPT
{
    public partial class SiteControl : UserControl
    {
        private SQLConnectionManager connection;
        private string connectionStringNextSite;

        public SiteControl(string SelfconnectionString, string connectionStringNextSite)
        {
            connection = new SQLConnectionManager(SelfconnectionString);
            this.connectionStringNextSite = connectionStringNextSite;
            InitializeComponent();
            FirstLoad();

        }

        public string SelfConnectionString => SelfConnectionString;
        public string ConnectionStringNextSite => connectionStringNextSite;

        private void SetEnableButton(bool flag)
        {
            btnDeleteEmployyee.Enabled = flag;
            btnEditEployeeInfo.Enabled = flag;
        }

        private void SetEnableInput(bool flag)
        {
            txtEmployeeID.ReadOnly = flag;
            txtFullName.ReadOnly = flag;
            txtPhoneNo.ReadOnly = flag;
            txtSalary.ReadOnly = flag;
            dtpBirthday.Enabled = !flag;
        }

        private void FirstLoad()
        {
            LoadEmployeeTable();
            bool isTableHavaData = dataGridView1.RowCount > 0;
            SetEnableButton(isTableHavaData);
        }

        private void TxtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void LoadEmployeeTable()
        {
            string query = "SELECT * FROM V_Employee";
            dataGridView1.DataSource = connection.ExecuteQuery(query);
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            SetEnableInput(false);
            using (SqlCommand command = new SqlCommand("SP_AddEmployee"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = txtEmployeeID.Text;
                command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = txtFullName.Text;
                command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = txtPhoneNo.Text;
                command.Parameters.Add("@Birthday", SqlDbType.Date).Value = dtpBirthday.Value;
                command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = txtSalary.Text;
                if (connection.ExecuteNonQuery(command))
                {
                    MessageBox.Show("Can not add Employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnEditEployeeInfo_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("SP_UpdateEmployee"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = txtFullName.Text;
                command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = txtPhoneNo.Text;
                command.Parameters.Add("@Birthday", SqlDbType.Date).Value = dtpBirthday.Value;
                command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = txtSalary.Text;
                if (connection.ExecuteNonQuery(command))
                {
                    MessageBox.Show("Can not update Employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDeleteEmployyee_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("SP_DeleteEmployee"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = txtEmployeeID.Text;
                if (connection.ExecuteNonQuery(command))
                {
                    MessageBox.Show("Can not delete Employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnReloadEmployeeTable_Click(object sender, EventArgs e)
        {
            LoadEmployeeTable();
        }

        private async Task Propagation()
        {
            try
            {
                // Sql Server provider, the "server" or "hub".
                SqlSyncProvider serverProvider = new SqlSyncProvider(SelfConnectionString);

                // Sqlite Client provider acting as the "client"
                SqlSyncProvider clientProvider = new SqlSyncProvider(connectionStringNextSite);

                // Tables involved in the sync process:
                var setup = new SyncSetup("Employee");

                // Sync agent
                SyncAgent agent = new SyncAgent(clientProvider, serverProvider);


                var result = await agent.SynchronizeAsync(setup);
                textBox6.Text = result.ToString();
            }
            catch (ApplyChangesException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SyncException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPropagation_Click(object sender, EventArgs e)
        {
            _ = Propagation();
        }
    }
}

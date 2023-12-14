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
        private readonly SQLConnectionManager connection;
        private string connectionStringNextSite;
        private enum SaveEmployeeType { ADD, EDIT, DELETE, NONE};
        private SaveEmployeeType saveEmployeeType = SaveEmployeeType.NONE;
        private int seletecRowIndex = -1;


        public SiteControl(string SelfconnectionString, string connectionStringNextSite)
        {
            try
            {
                connection = new SQLConnectionManager(SelfconnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            this.connectionStringNextSite = connectionStringNextSite;
            InitializeComponent();
            FirstLoad();

        }

        public SiteControl()
        {
            InitializeComponent();

        }

        private string selfConnectionString;
        public string SelfConnectionString => selfConnectionString;
        public string ConnectionStringNextSite => connectionStringNextSite;

        private void SetEnableButton(bool flag)
        {
            btnDeleteEmployyee.Enabled = flag;
            btnEditEployeeInfo.Enabled = flag;
            btnAddEmployee.Enabled = flag;
            btnPropagation.Enabled = flag;
            btnReloadEmployeeTable.Enabled = flag;
        }

        private void SetEnableInput(bool flag)
        {
            txtFullName.ReadOnly = !flag;
            txtPhoneNo.ReadOnly = !flag;
            txtSalary.ReadOnly = !flag;
            dtpBirthday.Enabled = flag;
        }

        private void ClearInput()
        {
            txtEmployeeID.Clear();
            txtFullName.Clear();
            txtPhoneNo.Clear();
            txtSalary.Clear();
            dtpBirthday.ResetText();
        }

        private void FirstLoad()
        {
            LoadEmployeeTable();
            bool isTableHavaData = dataGridView1.RowCount > 0;
            SetEnableButton(isTableHavaData);
        }

        private void TxtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void TxtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void TxtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void LoadDataRow(int index)
        {
            txtEmployeeID.Text = dataGridView1[0, index].Value.ToString();
            txtFullName.Text = dataGridView1[1, index].Value.ToString();
            txtPhoneNo.Text = dataGridView1[2, index].Value.ToString().Trim();
            dtpBirthday.Value = DateTime.Parse(dataGridView1[3, index].Value.ToString());
            txtSalary.Text = dataGridView1[4, index].Value.ToString();
        }

        public void LoadEmployeeTable()
        {
            string query = "SELECT * FROM V_Employee";
            using (SqlCommand command = new SqlCommand(query))
            {
                dataGridView1.DataSource = connection.GetTable(command);
                if (dataGridView1.RowCount > 1)
                {
                    seletecRowIndex = 0;
                    LoadDataRow(seletecRowIndex);
                }
            }
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            saveEmployeeType = SaveEmployeeType.ADD;
            ClearInput();
            txtEmployeeID.ReadOnly = false;
            SetEnableInput(true);
            btnSave.Enabled = true;
            SetEnableButton(false);
            btnCancel.Enabled = true;
        }

        private void BtnEditEployeeInfo_Click(object sender, EventArgs e)
        {
            saveEmployeeType = SaveEmployeeType.EDIT;
            SetEnableInput(true);
            SetEnableButton(false);
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void BtnDeleteEmployyee_Click(object sender, EventArgs e)
        {
            saveEmployeeType = SaveEmployeeType.DELETE;
            btnSave.Enabled = true;
            dataGridView1.Rows.RemoveAt(seletecRowIndex);
            SetEnableButton(false);
            btnCancel.Enabled = true;
        }

        private void BtnReloadEmployeeTable_Click(object sender, EventArgs e)
        {
            SetEnableButton(false);
            LoadEmployeeTable();
            SetEnableButton(true);
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
            SetEnableButton(false);
            _ = Propagation();
            SetEnableButton(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (saveEmployeeType)
            {
                case SaveEmployeeType.ADD:
                    txtEmployeeID.ReadOnly = true;
                    using (SqlCommand command = new SqlCommand("SP_AddEmployee"))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = txtEmployeeID.Text;
                        command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = txtFullName.Text;
                        command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = txtPhoneNo.Text;
                        command.Parameters.Add("@Birthday", SqlDbType.Date).Value = dtpBirthday.Value;
                        command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = txtSalary.Text;
                        try
                        {   
                            if (command == null)
                            {
                                throw new ArgumentNullException();
                            }
                            if (connection.ExecuteQuery(command))
                            {
                                MessageBox.Show("Employee added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to add Employee. Check the input values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error adding Employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case SaveEmployeeType.DELETE:
                    using (SqlCommand command = new SqlCommand("SP_DeleteEmployee"))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = txtEmployeeID.Text;
                        try
                        {
                            if (connection.ExecuteQuery(command))
                            {
                                MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete Employee. Check the input values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting Employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case SaveEmployeeType.EDIT:
                    using (SqlCommand command = new SqlCommand("SP_UpdateEmployee"))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = txtEmployeeID.Text;
                        command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = txtFullName.Text;
                        command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = txtPhoneNo.Text;
                        command.Parameters.Add("@Birthday", SqlDbType.Date).Value = dtpBirthday.Value;
                        command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = txtSalary.Text;
                        try
                        {
                            if (connection.ExecuteQuery(command))
                            {
                                MessageBox.Show("Employee updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to update Employee. Check the input values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating Employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case SaveEmployeeType.NONE:
                    break;
                default:
                    break;
            }
            SetEnableButton(true);
            SetEnableInput(false);
            LoadEmployeeTable();
            saveEmployeeType = SaveEmployeeType.NONE;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            ClearInput();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            seletecRowIndex = e.RowIndex;
            if (e.RowIndex != -1 && e.RowIndex != dataGridView1.RowCount - 1)
            {
                btnDeleteEmployyee.Enabled = true;
                btnEditEployeeInfo.Enabled = true;
                LoadDataRow(seletecRowIndex);
            }
            else
            {
                btnDeleteEmployyee.Enabled = false;
                btnEditEployeeInfo.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            saveEmployeeType = SaveEmployeeType.NONE;
            LoadEmployeeTable();
            SetEnableButton(true);
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
    }
}

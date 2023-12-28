using System;
using System.Windows.Forms;

namespace BTL_HTPT
{
    public partial class EmployeeControl : UserControl
    {
        private Employee employee;
        private EmployeeDAO employeeDAO;
        private enum SaveEmployeeType { INSERT, UPDATE, DELETE, NONE };
        private SaveEmployeeType saveEmployeeType = SaveEmployeeType.NONE;
        private int seletecRowIndex = -1;

        public EmployeeControl(string connectionString)
        {
            employeeDAO = new EmployeeDAO(connectionString);
            InitializeComponent();
            FirstLoad();
        }

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
            txtSalary.ReadOnly = !flag;
            dtpBirthday.Enabled = flag;
        }

        private void ClearInput()
        {
            txtEmployeeID.Clear();
            txtFullName.Clear();
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
            dtpBirthday.Value = DateTime.Parse(dataGridView1[3, index].Value.ToString());
            txtSalary.Text = dataGridView1[4, index].Value.ToString();

            employee.EmployeeID = int.Parse(txtEmployeeID.Text);
            employee.FullName = txtFullName.Text;
            employee.HireDate = dtpBirthday.Value;
            employee.Salary = double.Parse(txtSalary.Text);
            employee.IsActive = false;
        }

        public void LoadEmployeeTable()
        {
            dataGridView1.DataSource = employeeDAO.GetEmployeeTable();
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            saveEmployeeType = SaveEmployeeType.INSERT;
            ClearInput();
            txtEmployeeID.ReadOnly = false;
            SetEnableInput(true);
            btnSave.Enabled = true;
            SetEnableButton(false);
            btnCancel.Enabled = true;
        }

        private void BtnEditEployeeInfo_Click(object sender, EventArgs e)
        {
            saveEmployeeType = SaveEmployeeType.UPDATE;
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



        private void BtnPropagation_Click(object sender, EventArgs e)
        {
            SetEnableButton(false);

            SetEnableButton(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (saveEmployeeType)
            {
                case SaveEmployeeType.INSERT:
                    txtEmployeeID.ReadOnly = true;
                    employeeDAO.InsertEmployee(employee);
                    break;
                case SaveEmployeeType.UPDATE:
                    employeeDAO.UpdateEmployee(employee);
                    break;
                case SaveEmployeeType.DELETE:
                    employeeDAO.DeleteEmployee(employee);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                seletecRowIndex = e.RowIndex;
                LoadDataRow(e.RowIndex);
            }
        }
    }
}

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
            employee = new Employee();
            employeeDAO = new EmployeeDAO(connectionString);
            InitializeComponent();
            FirstLoad();
        }

        public EmployeeControl()
        {
            InitializeComponent();
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
            dtpHireDay.Enabled = flag;
            chkIsActivated.Enabled = flag;
        }

        private void ClearInput()
        {
            txtEmployeeID.Clear();
            txtFullName.Clear();
            txtSalary.Clear();
            dtpHireDay.ResetText();
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
            DateTime.TryParse(dataGridView1[3, index].Value.ToString(), out DateTime dt);
            dtpHireDay.Value = dt.Date;
            txtSalary.Text = dataGridView1[2, index].Value.ToString();
            bool.TryParse(dataGridView1[4, index].Value.ToString(), out bool check);
            chkIsActivated.Checked = check;

            GetDataInput();
        }

        private void GetDataInput()
        {
            int.TryParse(txtEmployeeID.Text, out int id);
            employee.EmployeeID = id;
            employee.FullName = txtFullName.Text;
            employee.HireDate = dtpHireDay.Value;
            double.TryParse(txtSalary.Text, out double s);
            employee.Salary = s;
            employee.IsActive = chkIsActivated.Checked;
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
            if (dataGridView1.Rows.Count > 1)
            {
                saveEmployeeType = SaveEmployeeType.UPDATE;
                SetEnableInput(true);
                SetEnableButton(false);
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
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
            GetDataInput();

            switch (saveEmployeeType)
            {
                
                case SaveEmployeeType.INSERT:
                    bool check = false;
                    if (txtEmployeeID.Text.Length != 0)
                    {
                        check = true;
                    }
                    else
                    {
                        MessageBox.Show("Employee ID is empty!");
                    }
                    if (txtFullName.Text.Length != 0)
                    {
                        check = true;
                    }
                    else
                    {
                        MessageBox.Show("Full name is empty!");
                    }
                    if (txtSalary.Text.Length != 0)
                    {
                        check = true;
                    }
                    else
                    {
                        MessageBox.Show("Salary is empty!");
                    }
                    if (check)
                    {
                        employeeDAO.InsertEmployee(employee);
                    }
                    break;
                case SaveEmployeeType.UPDATE:
                    check = false;
                    if (txtFullName.Text.Length != 0)
                    {
                        check = true;
                    }
                    else
                    {
                        MessageBox.Show("Full name is empty!");
                    }
                    if (txtSalary.Text.Length != 0)
                    {
                        check = true;
                    }
                    else
                    {
                        MessageBox.Show("Salary is empty!");
                    }
                    if (check)
                    {
                        txtEmployeeID.ReadOnly = true;
                        employeeDAO.InsertEmployee(employee);
                    }
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
            txtEmployeeID.ReadOnly = true;
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
            SetEnableInput(false);
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

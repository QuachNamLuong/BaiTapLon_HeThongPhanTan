using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTPT_CHD
{
    public partial class Form1 : Form
    {
        //private const string connectionString = "Data Source=CHD\\MAYCHU;Initial Catalog=EmployeeManagement;User ID=sa;Password=dienchau45;";
        private ControlManager controlManager;
        DataTable sharedDataTable = new DataTable();
        private bool isDataLoaded = false;
        private bool hasRefreshedData = false;

        public Form1()
        {
            InitializeComponent();

            // Khởi tạo ControlManager và gán các controls tương ứng
            controlManager = new ControlManager
            {
                ButtonThem = btn_them,
                ButtonXoa = btn_xoa,
                ButtonSua = btn_sua,
                ButtonLamMoi = btn_lam_moi,
                TextBoxEmployeeId = txt_id,
                TextBoxFullName = txt_fullname,
                TextBoxPhoneNo = txt_phoneNo,
                TextBoxAddress = txt_address,
                DateTimePickerBirthday = date_birthday,
                DataGridView = dataGridView1
            };

            // Đăng ký sự kiện Click cho nút xoá
            btn_xoa.Click += btn_xoa_Click;
            // Đăng ký sự kiện Click cho nút sửa
            btn_sua.Click += btn_sua_Click;
        }

       

        private void LoadData(string storedProcedureName, DataGridView dataGridView)
        {
            try
            {
                if (SQLConnectionManager.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, SQLConnectionManager.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            sharedDataTable.Clear();
                            adapter.Fill(sharedDataTable);
                        }
                    }

                    dataGridView.DataSource = sharedDataTable;
                    isDataLoaded = true;
                    hasRefreshedData = false;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "Load data");
            }
            finally
            {
                SQLConnectionManager.CloseConnection();
            }
        }

        private void PushDataDown()
        {
            try
            {
                if (!hasRefreshedData)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        DataTable clonedTable = sharedDataTable.Clone();
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            DataRow newRow = clonedTable.NewRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                newRow[cell.ColumnIndex] = cell.Value;
                            }
                            clonedTable.Rows.Add(newRow);
                        }

                        dataGridView2.DataSource = clonedTable;
                        hasRefreshedData = true;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để đẩy xuống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu đã được đẩy xuống trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "Push data down");
            }
        }
        private void HandleError(Exception ex, string action)
        {
            MessageBox.Show($"Error occurred while {action}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_day_du_lieu_Click(object sender, EventArgs e)
        {
            PushDataDown();
        }

        private void btn_lam_moi1_Click_1(object sender, EventArgs e)
        {
            LoadData("SP_HienThiDanhSachNhanVien", dataGridView1);
        }

        private void btn_lam_moi2_Click(object sender, EventArgs e)
        {
            LoadData("SP_HienThiDanhSachNhanVien", dataGridView2);
        }

        // xử lý cho sự kiện reset
        private void Reset()
        {
            controlManager.TextBoxEmployeeId.Text = "";
            controlManager.TextBoxFullName.Text = "";
            controlManager.TextBoxPhoneNo.Text = "";
            controlManager.TextBoxAddress.Text = "";
            controlManager.DateTimePickerBirthday.Value = DateTime.Now;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        // xử lý cho sự kiện thêm
        public bool KTThongTin()
        {
            if (controlManager.TextBoxEmployeeId.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                controlManager.TextBoxEmployeeId.Focus();
                return false;
            }
            if (controlManager.TextBoxFullName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                controlManager.TextBoxFullName.Focus();
                return false;
            }
            if (controlManager.TextBoxPhoneNo.Text == "")
            {
                MessageBox.Show("Vui lòng nhập SĐT nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                controlManager.TextBoxPhoneNo.Focus();
                return false;
            }
            if (controlManager.TextBoxAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                controlManager.TextBoxAddress.Focus();
                return false;
            }
            // Kiểm tra thêm điều kiện nếu cần thiết
            return true;
        }

        public void them(object sender, EventArgs e)
        {
            if (KTThongTin())
            {
                try
                {
                    // Kiểm tra và mở kết nối
                    if (SQLConnectionManager.OpenConnection())
                    {
                        using (SqlCommand command = new SqlCommand("SP_ThemMoiNhanVien", SQLConnectionManager.Connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = controlManager.TextBoxEmployeeId.Text;
                            command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = controlManager.TextBoxFullName.Text;
                            command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = controlManager.TextBoxPhoneNo.Text;
                            command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = controlManager.TextBoxAddress.Text;
                            command.Parameters.Add("@Birthday", SqlDbType.Date).Value = controlManager.DateTimePickerBirthday.Value;

                            command.ExecuteNonQuery();
                        }

                        // LoadData();
                        Reset();
                        MessageBox.Show("Đã thêm mới nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Luôn đảm bảo đóng kết nối
                    SQLConnectionManager.CloseConnection();
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            controlManager.TextBoxEmployeeId = txt_id;
            controlManager.TextBoxFullName = txt_fullname;
            controlManager.TextBoxPhoneNo = txt_phoneNo;
            controlManager.TextBoxAddress = txt_address;
            controlManager.DateTimePickerBirthday = date_birthday;
            them(sender,e);
            Reset();
        }
        /*private void btn_them_Click(object sender, EventArgs e)
        {
            controlManager.TextBoxEmployeeId = txt_id;
            controlManager.TextBoxFullName = txt_fullname;
            controlManager.TextBoxPhoneNo = txt_phoneNo;
            controlManager.TextBoxAddress = txt_address;
            controlManager.DateTimePickerBirthday = date_birthday;
            them(sender, e);
            Reset();
        }*/


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có hàng được chọn hay không
            if (controlManager.DataGridView.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên trong danh sách các hàng được chọn
                DataGridViewRow selectedRow = controlManager.DataGridView.SelectedRows[0];

                // Lấy giá trị từ các ô cột tương ứng trong hàng được chọn
                string employeeId = selectedRow.Cells["EmployeeID"].Value.ToString();
                string fullName = selectedRow.Cells["FullName"].Value.ToString();
                string phoneNo = selectedRow.Cells["PhoneNo"].Value.ToString();
                string address = selectedRow.Cells["Adress"].Value.ToString();
                DateTime birthday = Convert.ToDateTime(selectedRow.Cells["Birthday"].Value);

                // Hiển thị giá trị lên các TextBox tương ứng
                controlManager.TextBoxEmployeeId.Text = employeeId;
                controlManager.TextBoxFullName.Text = fullName;
                controlManager.TextBoxPhoneNo.Text = phoneNo;
                controlManager.TextBoxAddress.Text = address;
                controlManager.DateTimePickerBirthday.Value = birthday;
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (KTThongTin() && controlManager.DataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    // Lấy EmployeeID từ hàng được chọn trong dataGridView1
                    string employeeId = controlManager.DataGridView.SelectedRows[0].Cells["EmployeeID"].Value.ToString();

                    // Kiểm tra và mở kết nối
                    if (SQLConnectionManager.OpenConnection())
                    {
                        using (SqlCommand command = new SqlCommand("SP_SuaThongTinNhanVien", SQLConnectionManager.Connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = employeeId;
                            command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = controlManager.TextBoxFullName.Text;
                            command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = controlManager.TextBoxPhoneNo.Text;
                            command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = controlManager.TextBoxAddress.Text;
                            command.Parameters.Add("@Birthday", SqlDbType.Date).Value = controlManager.DateTimePickerBirthday.Value;

                            command.ExecuteNonQuery();
                        }

                        // LoadData();
                        Reset();
                        MessageBox.Show("Đã cập nhật thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Luôn đảm bảo đóng kết nối
                    SQLConnectionManager.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên và kiểm tra thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (controlManager.DataGridView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên này?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string employeeId = controlManager.DataGridView.SelectedRows[0].Cells["EmployeeID"].Value.ToString();

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(SQLConnectionManager.ConnectionString))
                        using (SqlCommand command = new SqlCommand("SP_XoaNhanVien", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = employeeId;

                            connection.Open();
                            command.ExecuteNonQuery();
                        }

                        // LoadData();
                        Reset();
                        MessageBox.Show("Đã xoá nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Sự kiện khi tab được chọn
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    LoadData("SP_HienThiDanhSachNhanVien", controlManager.DataGridView);
                    break;
                case 1:
                    LoadData("SP_HienThiDanhSachNhanVien", dataGridView2);
                    break;
                case 2:
                    LoadData("SP_HienThiDanhSachNhanVien", dataGridView3);
                    break;
                case 3:
                    LoadData("SP_HienThiDanhSachNhanVien", dataGridView4);
                    break;
                case 4:
                    LoadData("SP_HienThiDanhSachNhanVien", dataGridView5);
                    break;
                default:
                    break;
            }
        }


        //private const string connectionString = "Data Source=CHD\\MAYCHU;Initial Catalog=EmployeeManagement;User ID=sa;Password=dienchau45;";

        // Cập nhật sự kiện tabPage1_Click và các tabPage khác tương tự
        private void tabPage1_Click(object sender, EventArgs e)
        {
            SQLConnectionManager.ServerName = "CHD\\MAYCHU";
            SQLConnectionManager.DatabaseName = "EmployeeManagement";
            SQLConnectionManager.UserID = "sa";
            SQLConnectionManager.Password = "dienchau45";
            LoadData("SP_HienThiDanhSachNhanVien", dataGridView1);
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            SQLConnectionManager.ServerName = "CHD\\MAYCHU";
            SQLConnectionManager.DatabaseName = "EmployeeManagement";
            SQLConnectionManager.UserID = "sa";
            SQLConnectionManager.Password = "dienchau45";
            LoadData("SP_HienThiDanhSachNhanVien", dataGridView2);
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            SQLConnectionManager.ServerName = "CHD\\MAYCHU";
            SQLConnectionManager.DatabaseName = "EmployeeManagement";
            SQLConnectionManager.UserID = "sa";
            SQLConnectionManager.Password = "dienchau45";


            LoadData("SP_HienThiDanhSachNhanVien", dataGridView3);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            SQLConnectionManager.ServerName = "CHD\\MAYCHU";
            SQLConnectionManager.DatabaseName = "EmployeeManagement";
            SQLConnectionManager.UserID = "sa";
            SQLConnectionManager.Password = "dienchau45";


            LoadData("SP_HienThiDanhSachNhanVien", dataGridView4);
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            SQLConnectionManager.ServerName = "CHD\\MAYCHU";
            SQLConnectionManager.DatabaseName = "EmployeeManagement";
            SQLConnectionManager.UserID = "sa";
            SQLConnectionManager.Password = "dienchau45";


            LoadData("SP_HienThiDanhSachNhanVien", dataGridView5);
        }

    }
}

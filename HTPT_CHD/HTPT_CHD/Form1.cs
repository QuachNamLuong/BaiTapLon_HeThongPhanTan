using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTPT_CHD
{
    public partial class Form1 : Form
    {
        private const string connectionString = "Data Source=CHD\\MAYCHU;Initial Catalog=EmployeeManagement;User ID=sa;Password=dienchau45;";

        DataTable sharedDataTable = new DataTable();
        private bool isDataLoaded = false;
        private bool hasRefreshedData = false;

        public Form1()
        {
            InitializeComponent();

            // Đăng ký sự kiện Click cho nút xoá
            btn_xoa.Click += btn_xoa_Click;
            // Đăng ký sự kiện Click cho nút sửa
            btn_sua.Click += btn_sua_Click;


        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy dữ liệu từ stored procedure
                    using (SqlCommand command = new SqlCommand("SP_HienThiDanhSachNhanVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        // Xóa dữ liệu cũ trước khi tải dữ liệu mới
                        sharedDataTable.Clear();
                        adapter.Fill(sharedDataTable);
                    }

                    // Gán dữ liệu cho dataGridView1
                    dataGridView1.DataSource = sharedDataTable;
                }
                // Đặt cờ là đã thực hiện nút "Làm mới"
                isDataLoaded = true;
                // Đặt cờ là chưa làm mới dữ liệu
                hasRefreshedData = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PushDataDown()
        {
            try
            {
                // Kiểm tra xem dữ liệu đã được làm mới chưa
                if (!hasRefreshedData)
                {
                    // Kiểm tra xem dataGridView1 có dữ liệu không
                    if (dataGridView1.Rows.Count > 0)
                    {
                        // Clone DataTable từ dataGridView1
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

                        // Gán dữ liệu cho dataGridView2
                        dataGridView2.DataSource = clonedTable;
                        // Đặt cờ là đã làm mới dữ liệu
                        hasRefreshedData = true;
                    }
                    else
                    {
                        // Nếu không có dữ liệu trong dataGridView1, có thể thông báo hoặc thực hiện xử lý khác
                        MessageBox.Show("Không có dữ liệu để đẩy xuống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Nếu dữ liệu đã được làm mới, có thể thông báo hoặc thực hiện xử lý khác
                    MessageBox.Show("Dữ liệu đã được đẩy xuống trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đẩy dữ liệu xuống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_day_du_lieu_Click(object sender, EventArgs e)
        {
            PushDataDown();
        }

        private void btn_lam_moi1_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_lam_moi2_Click(object sender, EventArgs e)
        {

        }

        //xử lý cho sự kiện reset
        private void Reset()
        {
            txt_employeeId.Text = "";
            txt_fullname.Text = "";
            txt_phoneNo.Text = "";
            txt_address.Text = "";
            date_birthday.Value = DateTime.Now;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        //xử lý cho sự kiện thêm
        public bool KTThongTin()
        {
            if (txt_employeeId.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_employeeId.Focus();
                return false;
            }
            if (txt_fullname.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_fullname.Focus();
                return false;
            }
            if (txt_phoneNo.Text == "")
            {
                MessageBox.Show("Vui lòng nhập SĐT nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_phoneNo.Focus();
                return false;
            }
            if (txt_address.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_address.Focus();
                return false;
            }
            // Kiểm tra thêm điều kiện nếu cần thiết
            return true;
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (KTThongTin())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand("SP_ThemMoiNhanVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = txt_employeeId.Text;
                        command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = txt_fullname.Text;
                        command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = txt_phoneNo.Text;
                        command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txt_address.Text;
                        command.Parameters.Add("@Birthday", SqlDbType.Date).Value = date_birthday.Value;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    LoadData();
                    Reset();
                    MessageBox.Show("Đã thêm mới nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có hàng được chọn hay không
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên trong danh sách các hàng được chọn
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Lấy giá trị từ các ô cột tương ứng trong hàng được chọn
                string employeeId = selectedRow.Cells["EmployeeID"].Value.ToString();
                string fullName = selectedRow.Cells["FullName"].Value.ToString();
                string phoneNo = selectedRow.Cells["PhoneNo"].Value.ToString();
                string address = selectedRow.Cells["Adress"].Value.ToString();
                DateTime birthday = Convert.ToDateTime(selectedRow.Cells["Birthday"].Value);

                // Hiển thị giá trị lên các TextBox tương ứng
                txt_employeeId.Text = employeeId;
                txt_fullname.Text = fullName;
                txt_phoneNo.Text = phoneNo;
                txt_address.Text = address;
                date_birthday.Value = birthday;
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (KTThongTin() && dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string employeeId = dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value.ToString();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand("SP_SuaThongTinNhanVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = employeeId;
                        command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = txt_fullname.Text;
                        command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = txt_phoneNo.Text;
                        command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txt_address.Text;
                        command.Parameters.Add("@Birthday", SqlDbType.Date).Value = date_birthday.Value;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    LoadData();
                    Reset();
                    MessageBox.Show("Đã cập nhật thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên và kiểm tra thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên này?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string employeeId = dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value.ToString();

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        using (SqlCommand command = new SqlCommand("SP_XoaNhanVien", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = employeeId;

                            connection.Open();
                            command.ExecuteNonQuery();
                        }

                        LoadData();
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

    }
}

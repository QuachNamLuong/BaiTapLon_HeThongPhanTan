using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTPT_CHD
{
    public partial class Form2 : Form
    {
        private readonly string[] connectionStrings = {
            "Data Source=CHD\\MAYCHU;Initial Catalog=EmployeeManagement;User ID=sa;Password=dienchau45",
            "Data Source=CHD\\TRAM1;Initial Catalog=EmployeeManagement;User ID=sa;Password=dienchau45",
            "Data Source=CHD\\TRAM2;Initial Catalog=EmployeeManagement;User ID=sa;Password=dienchau45",
            "Your_Connection_String_4",
            "Your_Connection_String_5"
        };

        private DataTable sharedDataTable = new DataTable();
        private bool isDataLoaded = false;
        private bool hasRefreshedData = false;

        public Form2()
        {
            InitializeComponent();

            // Đăng ký sự kiện Click cho nút xoá
            btn_xoa.Click += btn_xoa_Click;
            // Đăng ký sự kiện Click cho nút sửa
            btn_sua.Click += btn_sua_Click;

            // Đăng ký sự kiện CheckedChanged cho các radio buttons
            rbtn_demo1.CheckedChanged += rbtn_demo_CheckedChanged;
            rbtn_demo2.CheckedChanged += rbtn_demo_CheckedChanged;
            rbtn_demo3.CheckedChanged += rbtn_demo_CheckedChanged;
            rbtn_demo4.CheckedChanged += rbtn_demo_CheckedChanged;
            rbtn_demo5.CheckedChanged += rbtn_demo_CheckedChanged;

        }

        private void rbtn_demo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                int selectedIndex;
                if (int.TryParse(radioButton.Tag?.ToString(), out selectedIndex))
                {
                    LoadDataForSelectedDatabase(connectionStrings[selectedIndex]);
                }
                else
                {
                    // Xử lý trường hợp Tag không phải là số nguyên
                    // Hoặc có thể hiển thị một thông báo lỗi
                }
            }

        }

        private void LoadDataForSelectedDatabase(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SP_HienThiDanhSachNhanVien", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    sharedDataTable.Clear();
                    adapter.Fill(sharedDataTable);
                }

                // Gán dữ liệu cho dataGridView1 hoặc các controls khác trên form tùy thuộc vào yêu cầu của bạn
                dataGridView1.DataSource = sharedDataTable;
            }
            catch (Exception ex)
            {
                HandleError(ex, "loading data");
            }
        }

        private void HandleError(Exception ex, string action)
        {
            MessageBox.Show($"Error occurred while {action}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (KTThongTin())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionStrings[0]))
                    using (SqlCommand command = new SqlCommand("SP_ThemMoiNhanVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = txt_id.Text;
                        command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = txt_fullname.Text;
                        command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = txt_phoneNo.Text;
                        command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txt_address.Text;
                        command.Parameters.Add("@Birthday", SqlDbType.Date).Value = date_birthday.Value;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    // Sau khi thêm dữ liệu, làm mới dữ liệu để hiển thị
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

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn hàng nào trong DataGridView chưa
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận xoá
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên này?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Lấy EmployeeID của hàng được chọn
                    string employeeId = dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value.ToString();

                    // Thực hiện xoá nhân viên trong cơ sở dữ liệu
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionStrings[0]))
                        using (SqlCommand command = new SqlCommand("SP_XoaNhanVien", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = employeeId;

                            connection.Open();
                            command.ExecuteNonQuery();
                        }

                        // Sau khi xoá dữ liệu, làm mới dữ liệu để hiển thị
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

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (KTThongTin() && dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string employeeId = dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value.ToString();

                    using (SqlConnection connection = new SqlConnection(connectionStrings[0]))
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

        private bool KTThongTin()
        {
            if (string.IsNullOrEmpty(txt_id.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_id.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_fullname.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_fullname.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_phoneNo.Text))
            {
                MessageBox.Show("Vui lòng nhập SĐT nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_phoneNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_address.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_address.Focus();
                return false;
            }
            // Kiểm tra thêm điều kiện nếu cần thiết
            return true;
        }

        private void Reset()
        {
            txt_id.Text = "";
            txt_fullname.Text = "";
            txt_phoneNo.Text = "";
            txt_address.Text = "";
            date_birthday.Value = DateTime.Now;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStrings[0]))
                using (SqlCommand command = new SqlCommand("SP_HienThiDanhSachNhanVien", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    sharedDataTable.Clear();
                    adapter.Fill(sharedDataTable);
                }

                dataGridView1.DataSource = sharedDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isDataLoaded = true;
            hasRefreshedData = false;
        }

        private void btn_lam_moi_Click(object sender, EventArgs e)
        {
            if (rbtn_demo1.Checked)
            {
                LoadDataForSelectedDatabase(connectionStrings[0]);
            }
            else if (rbtn_demo2.Checked)
            {
                LoadDataForSelectedDatabase(connectionStrings[1]);
            }
            else if (rbtn_demo3.Checked)
            {
                LoadDataForSelectedDatabase(connectionStrings[2]);
            }
            else if (rbtn_demo4.Checked)
            {
                LoadDataForSelectedDatabase(connectionStrings[3]);
            }
            else if (rbtn_demo5.Checked)
            {
                LoadDataForSelectedDatabase(connectionStrings[4]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cơ sở dữ liệu trước khi làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //LoadData();
        }

        private void btn_day_du_lieu_Click(object sender, EventArgs e)
        {
            PushDataDown();
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

                        dataGridView1.DataSource = clonedTable;
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
                MessageBox.Show($"Lỗi khi đẩy dữ liệu xuống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

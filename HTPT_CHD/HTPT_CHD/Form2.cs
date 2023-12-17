using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        private String Conn = "";
        private int selectedDemo = 0; // You can assign a default value based on your logic
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
            // Đăng ký sự kiện CellClick cho DataGridView
            dataGridView1.CellClick += dataGridView1_CellContentClick;

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
                    // Kiểm tra trùng lặp ID
                    if (IsIdExists(txt_id.Text))
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng chọn một mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (SqlConnection connection = new SqlConnection(Conn))
                    using (SqlCommand command = new SqlCommand("SP_ThemMoiNhanVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = txt_id.Text;
                        command.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = txt_fullname.Text;
                        command.Parameters.Add("@PhoneNo", SqlDbType.Char).Value = txt_phoneNo.Text;
                        command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txt_address.Text;
                        command.Parameters.Add("@Birthday", SqlDbType.Date).Value = date_birthday.Value;

                        // Truyền giá trị của Demo tương ứng
                        //command.Parameters.Add("@Demo", SqlDbType.Int).Value = selectedIndex;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                    // Thêm mới nhân viên vào cuối DataTable
                    DataRow newRow = sharedDataTable.NewRow();
                    newRow["EmployeeID"] = txt_id.Text;
                    newRow["FullName"] = txt_fullname.Text;
                    newRow["PhoneNo"] = txt_phoneNo.Text;
                    newRow["Adress"] = txt_address.Text;
                    newRow["Birthday"] = date_birthday.Value;

                    // Thêm vào vị trí dựa vào thứ tự ID trong cơ sở dữ liệu
                    int rowIndex = FindRowIndexByID(txt_id.Text);
                    if (rowIndex >= 0)
                    {
                        sharedDataTable.Rows.InsertAt(newRow, rowIndex);
                    }
                    else
                    {
                        sharedDataTable.Rows.Add(newRow);
                    }

                    // Làm mới dữ liệu trong DataGridView
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = sharedDataTable;

                    Reset();
                    MessageBox.Show("Đã thêm mới nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm kiểm tra trùng lặp ID
        private bool IsIdExists(string employeeId)
        {
            return sharedDataTable.AsEnumerable().Any(row => row.Field<string>("EmployeeID") == employeeId);
        }

        // Hàm tìm vị trí dựa vào ID trong DataTable
        private int FindRowIndexByID(string employeeId)
        {
            for (int i = 0; i < sharedDataTable.Rows.Count; i++)
            {
                if (string.Compare(sharedDataTable.Rows[i]["EmployeeID"].ToString(), employeeId, StringComparison.OrdinalIgnoreCase) > 0)
                {
                    return i;
                }
            }
            return -1; // Trả về -1 nếu không tìm thấy
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
                        using (SqlConnection connection = new SqlConnection(Conn))
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

                    using (SqlConnection connection = new SqlConnection(Conn))
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
                using (SqlConnection connection = new SqlConnection(Conn))
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
                Conn = connectionStrings[0];
            }
            else if (rbtn_demo2.Checked)
            {
                LoadDataForSelectedDatabase(connectionStrings[1]);
                Conn = connectionStrings[1];
            }
            else if (rbtn_demo3.Checked)
            {
                LoadDataForSelectedDatabase(connectionStrings[2]);
                Conn = connectionStrings[2];
            }
            else if (rbtn_demo4.Checked)
            {
                LoadDataForSelectedDatabase(connectionStrings[3]);
                Conn = connectionStrings[3];
            }
            else if (rbtn_demo5.Checked)
            {
                LoadDataForSelectedDatabase(connectionStrings[4]);
                Conn = connectionStrings[4];
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cơ sở dữ liệu trước khi làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //LoadData();
        }

        private void btn_day_du_lieu_Click(object sender, EventArgs e)
        {
            if (rbtn_demo1.Checked)
            {
                PushDataDownAndMerge(connectionStrings[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn demo 1 để đẩy dữ liệu xuống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                                if (cell.Value != null)
                                {
                                    if (cell.OwningColumn.Name == "Birthday" && cell.Value.GetType() == typeof(DateTime))
                                    {
                                        newRow[cell.ColumnIndex] = cell.Value;
                                    }
                                    else
                                    {
                                        newRow[cell.ColumnIndex] = cell.Value;
                                    }
                                }
                                else
                                {
                                    newRow[cell.ColumnIndex] = DBNull.Value;
                                }
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


        private void PushDataDownAndMerge(string sourceConnectionString)
        {
            try
            {
                using (SqlConnection sourceConnection = new SqlConnection(sourceConnectionString))
                using (SqlCommand sourceCommand = new SqlCommand("SP_HienThiDanhSachNhanVien", sourceConnection))
                {
                    sourceCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sourceAdapter = new SqlDataAdapter(sourceCommand);
                    DataTable sourceDataTable = new DataTable();
                    sourceAdapter.Fill(sourceDataTable);

                    // Đặt kết nối và lệnh cho các cơ sở dữ liệu đích (demo 2, 3, 4, 5)
                    for (int i = 1; i <= 4; i++)
                    {
                        string destinationConnectionString = connectionStrings[i];
                        using (SqlConnection destinationConnection = new SqlConnection(destinationConnectionString))
                        using (SqlCommand destinationCommand = new SqlCommand("SP_HienThiDanhSachNhanVien", destinationConnection))
                        {
                            destinationCommand.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter destinationAdapter = new SqlDataAdapter(destinationCommand);
                            DataTable destinationDataTable = new DataTable();
                            destinationAdapter.Fill(destinationDataTable);

                            // Gộp dữ liệu từ nguồn vào đích
                            MergeData(sourceDataTable, destinationDataTable);

                            // Lưu dữ liệu gộp vào cơ sở dữ liệu đích
                            SaveData(destinationConnection, destinationCommand, destinationAdapter, destinationDataTable);
                        }
                    }
                }

                MessageBox.Show("Đã đẩy và gộp dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đẩy và gộp dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MergeData(DataTable sourceDataTable, DataTable destinationDataTable)
        {
            // Kiểm tra nếu có dữ liệu từ nguồn
            if (sourceDataTable.Rows.Count > 0)
            {
                // Tìm max ID hiện tại trong cơ sở dữ liệu đích
                int maxId = destinationDataTable.AsEnumerable()
                    .Max(row => int.TryParse(row.Field<string>("EmployeeID"), out int id) ? id : 0);

                // Gán maxId+1 cho các dòng dữ liệu từ nguồn
                foreach (DataRow row in sourceDataTable.Rows)
                {
                    maxId++;
                    row["EmployeeID"] = maxId.ToString();
                }

                // Gộp dữ liệu từ nguồn vào đích
                destinationDataTable.Merge(sourceDataTable, true, MissingSchemaAction.Add);
            }
        }

        private void SaveData(SqlConnection connection, SqlCommand command, SqlDataAdapter adapter, DataTable dataTable)
        {
            // Xóa dữ liệu cũ trong cơ sở dữ liệu đích
            command.CommandText = "DELETE FROM Employee"; // Thay thế "TableName" bằng tên bảng của bạn
            connection.Open();
            command.ExecuteNonQuery();

            // Thêm dữ liệu mới vào cơ sở dữ liệu đích
            command.CommandText = "INSERT INTO Employee(EmployeeID, FullName, PhoneNo, Address, Birthday) VALUES (@Id, @Ten, @PhoneNo, @Address, @Birthday)";
            adapter.InsertCommand = command;
            adapter.Update(dataTable);
            connection.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn vào một ô không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị của ô được chọn
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Hiển thị giá trị của ô lên các TextBox tương ứng
                if (cellValue != null)
                {
                    // Dùng các TextBox tương ứng của bạn (ở đây mình giả sử bạn có TextBox txt_fullname, txt_phoneNo, ...)
                    txt_fullname.Text = dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                    txt_phoneNo.Text = dataGridView1.Rows[e.RowIndex].Cells["PhoneNo"].Value.ToString();
                    txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString();
                    date_birthday.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Birthday"].Value);
                    txt_address.Text = dataGridView1.Rows[e.RowIndex].Cells["Adress"].Value.ToString();
                }
            }
        }

    }
}

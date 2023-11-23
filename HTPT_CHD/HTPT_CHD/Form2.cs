using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTPT_CHD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void CheckConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=CHD\\MAYCHU;Initial Catalog=HTPT;User ID=sa;Password=dienchau45;"))
                {
                    connection.Open();
                    Console.WriteLine("Kết nối thành công!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
            }
        }

        private void LoadDanhSachSinhVien()
        {
            DataTable sinhVienTable = GetSinhVienData();

            dataGridView1.DataSource = sinhVienTable;
        }

        private DataTable GetSinhVienData()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection("Data Source=CHD\\MAYCHU;Initial Catalog=HTPT;User ID=sa;Password=dienchau45;"))
            {
                connection.Open();

                string query = "SELECT * FROM SinhVien";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckConnection(); // Kiểm tra kết nối trước khi load dữ liệu
            LoadDanhSachSinhVien();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

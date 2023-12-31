using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Dotmim.Sync.SqlServer;
using Dotmim.Sync;

namespace BTL_HTPT
{
    public partial class ProductControl : UserControl
    {
        private Product product;
        private ProductDAO productDAO;
        private enum SaveType {INSERT, UPDATE, DELETE, NONE};
        private SaveType saveType;
        private int selectedRow;
        private string connectionStringNext;

        public string ConnectionString
        {
            get => productDAO.ConnectionString;

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    productDAO = new ProductDAO(value);
                }
            }
        }

        public string ConnectionStringNext
        {
            get => connectionStringNext;

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    connectionStringNext = value;
                }
            }
        }

        public ProductControl()
        {
            InitializeComponent();
            product = new Product();
            saveType = SaveType.NONE;
            selectedRow = -1;
        }

        public void SetVisibleButton(bool flag)
        {
            insertButton.Visible = flag;
            updateButton.Visible = flag;
            deleteButton.Visible = flag;
            saveButton.Visible = flag;
            cancelButton.Visible = flag;
            
        }

        public void SetVisivlePropagateButton(bool flag)
        {
            propagateButton.Visible = flag;
        }

        public void LoadData()
        {
            DataTable tableProduct = productDAO.GetProductTable();
            if (tableProduct.Rows.Count > 0)
            {
                tableProduct.Columns[0].ColumnName = "Mã sản phẩm";
                tableProduct.Columns[1].ColumnName = "Tên sản phẩm";
                tableProduct.Columns[2].ColumnName = "Giá";
                tableProduct.Columns[3].ColumnName = "Ngày sản xuất";
                tableProduct.Columns[4].ColumnName = "Đang còn hàng";
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = tableProduct;
                selectedRow = 0;
                GetInfoInput(selectedRow);
                GetInfoProduct();
                updateButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            else
            {
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }

        private void GetInfoProduct()
        {
            int.TryParse(productIDTextBox.Text, out int productID);
            product.ProductID = productID;
            product.ProductName = productNameTextBox.Text;
            decimal.TryParse(priceTextBox.Text, out decimal price);
            product.Price = price;
            product.ManufactureDate = manufactureDateDateTimePicker.Value;
            product.IsAvailable = isAvailableCheckBox.Checked;
        }

        private void GetInfoInput(int index)
        {
            if (index < dataGridView1.Rows.Count && index >= 0)
            {
                productIDTextBox.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                productNameTextBox.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                priceTextBox.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                DateTime.TryParse(dataGridView1.Rows[index].Cells[3].Value.ToString(), out DateTime manufactureDate);
                manufactureDateDateTimePicker.Value = manufactureDate;
                bool.TryParse(dataGridView1.Rows[index].Cells[4].Value.ToString(), out bool isAvailabel);
                isAvailableCheckBox.Checked = isAvailabel;
            }
        }

        private void ClearInput()
        {
            productIDTextBox.Clear();
            productNameTextBox.Clear();
            priceTextBox.Clear();
            manufactureDateDateTimePicker.Value = DateTime.Now;
            isAvailableCheckBox.Checked = false;
        }

        
        private void productIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void productNameTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void priceTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void manufactureDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void isAvailableCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool CheckInput()
        {
            if (productIDTextBox.Text.Length == 0)
            {
                return false;
            }
            if (productIDTextBox.Text.Length == 0)
            {
                return false;
            }
            if (productIDTextBox.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GetInfoProduct();
            
            switch (saveType)
            {
                case SaveType.INSERT:
                    if (CheckInput())
                    {
                        MessageBox.Show("Bạn chưa nhập đầy đủ thông tin");
                    }
                    else if (productDAO.InsertProduct(product))
                    {
                        MessageBox.Show("Không thể thêm sản phẩm");
                    }
                    else
                    {
                        notifyTextBox.Text = "Thêm sản phẩm thành công\n";
                    }
                    break;
                case SaveType.UPDATE:
                    if (productDAO.UpdateProduct(product))
                    {
                        MessageBox.Show("Không thể cập nhật sản phẩm");
                    }
                    else
                    {
                        notifyTextBox.Text = "Cập nhật sản phẩm thành công\n";
                    }
                    break;
                case SaveType.DELETE:
                    if (dataGridView1.Rows.Count == 0)
                    {
                        ClearInput();
                    }
                    if (productDAO.DeleteProduct(product))
                    {
                        MessageBox.Show("Không thể xóa nhật sản phẩm");
                    }
                    else
                    {
                        notifyTextBox.Text = "Xóa sản phẩm thành công\n";
                    }
                    break;
            }
            saveType = SaveType.NONE;
            SetEnableEditButton(false);
            SetEnableInput(false);
            LoadData();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ClearInput();
            if (selectedRow >= 0)
            {
                GetInfoInput(selectedRow);
            }
            SetEnableEditButton(false);
            SetEnableInput(false);
            LoadData();
            
        }

        private void SetEnableInput(bool flag)
        {
            productIDTextBox.ReadOnly = !flag;
            productNameTextBox.ReadOnly = !flag;
            priceTextBox.ReadOnly = !flag;
            manufactureDateDateTimePicker.Enabled = flag;
            isAvailableCheckBox.Enabled = flag;
        }

        private void SetEnableEditButton(bool flag)
        {
            saveButton.Enabled = flag;
            cancelButton.Enabled = flag;
            propagateButton.Enabled = !flag;
            reloadButton.Enabled = !flag;
            insertButton.Enabled = !flag;
            updateButton.Enabled = !flag;
            deleteButton.Enabled = !flag;
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            ClearInput();
            SetEnableInput(true);
            saveType = SaveType.INSERT;
            SetEnableEditButton(true);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            SetEnableInput(true);
            productIDTextBox.ReadOnly = true;
            saveType = SaveType.UPDATE;
            SetEnableEditButton(true);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                saveType = SaveType.DELETE;
                SetEnableEditButton(true);
            }
        }

        private async Task PushDataDownAsync(string serverConnectionString, string clientConnectionString)
        {
            try
            {
                // Create providers for server and client
                SqlSyncProvider serverProvider = new SqlSyncProvider(serverConnectionString);
                SqlSyncProvider clientProvider = new SqlSyncProvider(clientConnectionString);

                // Specify tables to synchronize
                var setup = new SyncSetup("Product");  // Add more tables if needed

                // Create sync agent
                SyncAgent agent = new SyncAgent(clientProvider, serverProvider);

                // Perform synchronization repeatedly until it's done or stop is requested

                var result = await agent.SynchronizeAsync(setup);
                notifyTextBox.Text = result.ToString();

                // Check if stop is requested

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PushDataDown method: {ex.Message}");
                // Consider logging the exception for analysis
            }
        }

        private void propagateButton_Click(object sender, EventArgs e)
        {
            _ = PushDataDownAsync(ConnectionString, ConnectionStringNext);
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GetInfoInput(e.RowIndex);
            GetInfoProduct();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            GetInfoInput(0);
            GetInfoProduct();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedRow = e.RowIndex;
            GetInfoInput(e.RowIndex);
            GetInfoProduct();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                updateButton.Enabled = false;
            }
        }

        private void tableProductLabel_Click(object sender, EventArgs e)
        {

        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((priceTextBox.Text.Length == 0) && (e.KeyChar == '.')) {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (priceTextBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void productIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonClearNotify_Click(object sender, EventArgs e)
        {
            notifyTextBox.Clear();
        }
    }
}

using Dotmim.Sync;
using Dotmim.Sync.SqlServer;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HTPT
{
    public partial class ControlProduct : UserControl
    {
        private readonly Product product;
        private ProductDAO productDAO;
        private enum SaveType { INSERT, UPDATE, DELETE, NONE };
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

        public ControlProduct()
        {
            InitializeComponent();
            product = new Product();
            saveType = SaveType.NONE;
            selectedRow = -1;
        }

        public void SetVisibleButton(bool flag)
        {
            buttonInsert.Visible = flag;
            buttonUpdate.Visible = flag;
            buttonDelete.Visible = flag;
            buttonSave.Visible = flag;
            buttonCancel.Visible = flag;

        }

        public void SetVisivlePropagateButton(bool flag)
        {
            buttonPropagate.Visible = flag;
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
                dataGridViewProduct.Columns.Clear();
                dataGridViewProduct.DataSource = tableProduct;
                selectedRow = 0;
                GetInfoInput(selectedRow);
                GetInfoProduct();
                buttonUpdate.Enabled = true;
                buttonDelete.Enabled = true;
            }
            else
            {
                buttonUpdate.Enabled = false;
                buttonDelete.Enabled = false;
            }
        }

        private void GetInfoProduct()
        {
            int.TryParse(textBoxProductID.Text, out int productID);
            product.ProductID = productID;
            product.ProductName = textBoxProductName.Text;
            decimal.TryParse(textBoxPrice.Text, out decimal price);
            product.Price = price;
            product.ManufactureDate = dateTimePickerManufactureDate.Value;
            product.IsAvailable = checkBoxIsAvailable.Checked;
        }

        private void GetInfoInput(int index)
        {
            if (index < dataGridViewProduct.Rows.Count && index >= 0)
            {
                textBoxProductID.Text = dataGridViewProduct.Rows[index].Cells[0].Value.ToString();
                textBoxProductName.Text = dataGridViewProduct.Rows[index].Cells[1].Value.ToString();
                textBoxPrice.Text = dataGridViewProduct.Rows[index].Cells[2].Value.ToString();
                DateTime.TryParse(dataGridViewProduct.Rows[index].Cells[3].Value.ToString(), out DateTime manufactureDate);
                dateTimePickerManufactureDate.Value = manufactureDate;
                bool.TryParse(dataGridViewProduct.Rows[index].Cells[4].Value.ToString(), out bool isAvailabel);
                checkBoxIsAvailable.Checked = isAvailabel;
            }
        }

        private void ClearInput()
        {
            textBoxProductID.Clear();
            textBoxProductName.Clear();
            textBoxPrice.Clear();
            dateTimePickerManufactureDate.Value = DateTime.Now;
            checkBoxIsAvailable.Checked = false;
        }

        private bool CheckInput()
        {
            if (textBoxProductID.Text.Length == 0)
            {
                return false;
            }
            if (textBoxProductID.Text.Length == 0)
            {
                return false;
            }
            if (textBoxProductID.Text.Length == 0)
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
                        textBoxNotify.Text = "Thêm sản phẩm thành công\n";
                    }
                    break;
                case SaveType.UPDATE:
                    if (productDAO.UpdateProduct(product))
                    {
                        MessageBox.Show("Không thể cập nhật sản phẩm");
                    }
                    else
                    {
                        textBoxNotify.Text = "Cập nhật sản phẩm thành công\n";
                    }
                    break;
                case SaveType.DELETE:
                    if (dataGridViewProduct.Rows.Count == 0)
                    {
                        ClearInput();
                    }
                    if (productDAO.DeleteProduct(product))
                    {
                        MessageBox.Show("Không thể xóa nhật sản phẩm");
                    }
                    else
                    {
                        textBoxNotify.Text = "Xóa sản phẩm thành công\n";
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
            textBoxProductID.ReadOnly = !flag;
            textBoxProductName.ReadOnly = !flag;
            textBoxPrice.ReadOnly = !flag;
            dateTimePickerManufactureDate.Enabled = flag;
            checkBoxIsAvailable.Enabled = flag;
        }

        private void SetEnableEditButton(bool flag)
        {
            buttonSave.Enabled = flag;
            buttonCancel.Enabled = flag;
            buttonPropagate.Enabled = !flag;
            buttonReload.Enabled = !flag;
            buttonInsert.Enabled = !flag;
            buttonUpdate.Enabled = !flag;
            buttonDelete.Enabled = !flag;
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
            textBoxProductID.ReadOnly = true;
            saveType = SaveType.UPDATE;
            SetEnableEditButton(true);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.Rows.Count > 0)
            {
                dataGridViewProduct.Rows.Remove(dataGridViewProduct.SelectedRows[0]);
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
                textBoxNotify.Text = result.ToString();

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
            if (dataGridViewProduct.Rows.Count == 0)
            {
                buttonUpdate.Enabled = false;
            }
        }

        private void tableProductLabel_Click(object sender, EventArgs e)
        {

        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((textBoxPrice.Text.Length == 0) && (e.KeyChar == '.'))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (textBoxPrice.Text.IndexOf('.') > -1))
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
            textBoxNotify.Clear();
        }
    }
}

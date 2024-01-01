using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HTPT
{
    public partial class FormDemo3 : Form
    {
        public FormDemo3()
        {
            InitializeComponent();
            productControl1.SetVisibleButton(false);
            productControl1.SetVisivlePropagateButton(false);

        }

        private void DemoForm3_Load(object sender, EventArgs e)
        {
            productControl1.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            productControl1.LoadData();
        }
    }
}

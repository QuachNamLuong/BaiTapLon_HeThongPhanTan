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
    public partial class MainForm : Form
    {
        private string connectionString1, connectionString2, connectionString3, connectionString4, connectionString5;
        
        public MainForm()
        {
            connectionString5 = connectionString4 = connectionString3 = connectionString2 = connectionString1 = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=BTL;User ID=sa;Password=123;";
            InitializeComponent();
        }
    }
}

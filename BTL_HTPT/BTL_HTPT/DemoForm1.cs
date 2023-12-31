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
    public partial class DemoForm1 : Form
    {
        public DemoForm1()
        {
            InitializeComponent();
            productControl2.SetVisibleButton(false);
            productControl2.SetVisivlePropagateButton(false);
        }

        private void DemoForm2_Load(object sender, EventArgs e)
        {
            productControl1.ConnectionString = "asd";
            productControl2.ConnectionString = "asds";
            productControl1.ConnectionStringNext = productControl2.ConnectionString;
            productControl1.LoadData();
        }
    }
}

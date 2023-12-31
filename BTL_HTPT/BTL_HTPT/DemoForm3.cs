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
    public partial class DemoForm3 : Form
    {
        public DemoForm3()
        {
            InitializeComponent();
            productControl1.SetVisibleButton(false);
            productControl1.SetVisivlePropagateButton(false);

        }

        private void DemoForm3_Load(object sender, EventArgs e)
        {
            productControl1.ConnectionString = "sdas";
            productControl1.LoadData();
        }
    }
}

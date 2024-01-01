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
    public partial class FormDemoOwnerAndCopy : Form
    {
        public FormDemoOwnerAndCopy()
        {
            InitializeComponent();
            controlProductCopy.SetVisibleButton(false);
            controlProductCopy.SetVisivlePropagateButton(false);
        }

        private void DemoForm2_Load(object sender, EventArgs e)
        {
            controlProductOwner.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            controlProductCopy.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            controlProductOwner.ConnectionStringNext = controlProductCopy.ConnectionString;
            controlProductOwner.LoadData();
        }
    }
}

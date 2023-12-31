using System;
using System.Windows.Forms;

namespace BTL_HTPT
{
    public partial class Demo6SiteForm : Form
    {
        public Demo6SiteForm()
        {
            InitializeComponent();
            productControl2.SetVisibleButton(false);
            productControl3.SetVisibleButton(false);
            productControl4.SetVisibleButton(false);
            productControl5.SetVisibleButton(false);
            productControl6.SetVisibleButton(false);
            productControl6.SetVisivlePropagateButton(false);
        }

        private void DemoForm1_Load(object sender, EventArgs e)
        {
            productControl1.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            productControl2.ConnectionString = "Data Source=DESKTOP-7B6MP5S\\MSSQLSERVER1;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            productControl1.ConnectionStringNext = productControl2.ConnectionString;
            productControl3.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            productControl2.ConnectionStringNext = productControl3.ConnectionString;
            productControl4.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            productControl3.ConnectionStringNext = productControl4.ConnectionString;
            productControl5.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            productControl4.ConnectionStringNext = productControl5.ConnectionString;
            productControl6.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            productControl5.ConnectionStringNext = productControl6.ConnectionString;
            productControl1.LoadData();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageMain)
            {
                productControl1.LoadData();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                productControl2.LoadData();
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                productControl3.LoadData();
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                productControl4.LoadData();
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                productControl5.LoadData();
            }
        }
    }
}

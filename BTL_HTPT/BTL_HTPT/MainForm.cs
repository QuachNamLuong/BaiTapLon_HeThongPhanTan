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
        
        private SiteControl site1, site2, site3, site4, site5;
        public MainForm()
        {
            connectionString1 = "Data Source=DESKTOP-E3L30RU;Initial Catalog=EmployeeManagement;User ID=sa;Password=123;Integrated Security=True;";
            connectionString2 = "Data Source=DESKTOP-E3L30RU\\SERVER1;Initial Catalog=EmployeeManagement;User ID=sa;Password=123;Integrated Security=True;";//DESKTOP-E3L30RU\SERVER1
            /*connectionString2 = connectionString1;
            connectionString3 = connectionString1;
            connectionString4 = connectionString1;
            connectionString5 = connectionString1;
            site1 = new SiteControl(connectionString1, connectionString2);
            site2 = new SiteControl(connectionString2, connectionString3);
            site3 = new SiteControl(connectionString3, connectionString4);
            site4 = new SiteControl(connectionString4, connectionString5);
            site5 = new SiteControl(connectionString5, connectionString1);*/
            InitializeComponent();
            site1 = new SiteControl(connectionString1, connectionString2);
            tabPage1.Controls.Add(site1);
            site2 = new SiteControl(connectionString2, connectionString1);
            tabPage2.Controls.Add(site2);
        }
    }
}

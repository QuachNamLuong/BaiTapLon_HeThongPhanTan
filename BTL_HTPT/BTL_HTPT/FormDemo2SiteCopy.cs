using System;
using System.Windows.Forms;

namespace BTL_HTPT
{
    public partial class FormDemo2SiteCopy : Form
    {
        public FormDemo2SiteCopy()
        {
            InitializeComponent();
            controlProductSiteCopyFirst.SetVisibleButton(false);
            controlProductSiteCopyNext.SetVisibleButton(false);
            controlProductSiteCopyNext.SetVisivlePropagateButton(false);
        }

        private void DemoForm2SiteCopy_Load(object sender, EventArgs e)
        {
            controlProductSiteCopyFirst.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            controlProductSiteCopyNext.ConnectionString = "Data Source=DESKTOP-7B6MP5S;Initial Catalog=ProductManagementDB;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;";
            controlProductSiteCopyFirst.ConnectionStringNext = controlProductSiteCopyNext.ConnectionString;
            controlProductSiteCopyFirst.LoadData();
        }

        private void tabControlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlSite.SelectedTab == tabPageSiteFirst)
            {
                controlProductSiteCopyFirst.LoadData();
            }
            else if (tabControlSite.SelectedTab == tabPageSiteNext)
            {
                controlProductSiteCopyNext.LoadData();
            }
        }
    }
}

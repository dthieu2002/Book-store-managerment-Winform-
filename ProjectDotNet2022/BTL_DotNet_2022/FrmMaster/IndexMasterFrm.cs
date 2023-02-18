using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_DotNet_2022.Models;

namespace BTL_DotNet_2022.FrmMaster
{
    public partial class IndexMasterFrm : Form
    {
        private User userLogin;
        private MainMaster mainMaster;

        public IndexMasterFrm(User userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;

            // Hide three button if role of user login is "staff"
            if (userLogin.getRole().Equals("staff"))
            {
                btnCustomerManager.Hide();
                btnStaffManager.Hide();
                btnRevenueStatistic.Hide();

                label1.Text = "Welcome to staff mode:";
            }

        }
        private void IndexMasterFrm_Load(object sender, EventArgs e)
        {
            this.mainMaster = (MainMaster)this.MdiParent;
        }

        private void btnInfoAccount_Click(object sender, EventArgs e)
        {
            this.mainMaster.infoToolStripMenuItem_Click(sender, e);
        }

        private void btnBookManager_Click(object sender, EventArgs e)
        {
            this.mainMaster.bookToolStripMenuItem_Click(sender, e);
        }

        private void btnCheckOrders_Click(object sender, EventArgs e)
        {
            this.mainMaster.orderToolStripMenuItem_Click(sender, e);
        }
        private void btnStaffManager_Click(object sender, EventArgs e)
        {
            this.mainMaster.staffToolStripMenuItem_Click(sender, e);
        }

        private void btnCustomerManager_Click(object sender, EventArgs e)
        {
            this.mainMaster.customerToolStripMenuItem_Click(sender, e);
        }

        private void btnRevenueStatistic_Click(object sender, EventArgs e)
        {
            this.mainMaster.tsmiRevenue_Click(sender, e);
        }
    }
}

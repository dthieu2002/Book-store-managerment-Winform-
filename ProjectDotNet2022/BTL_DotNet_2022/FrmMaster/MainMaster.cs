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
    public partial class MainMaster : Form
    {
        private User userLogin = new User();
        private Form? currentMdiChildForm = null;
        public MainMaster(User userLogin)
        {
            InitializeComponent();

            // set userLogin
            this.userLogin = userLogin;

            // set window state of MainMaster
            this.WindowState = FormWindowState.Maximized;

            // set default MdiChild form is IndexMasterFrm
            this.setMdiChildFrom(new IndexMasterFrm(this.userLogin));
        }

        public void setMdiChildFrom(Form form)
        {
            if(this.currentMdiChildForm != null)
            {
                this.currentMdiChildForm.Close();
                this.currentMdiChildForm.Dispose();
            }
            
            form.FormBorderStyle = FormBorderStyle.None;
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
            
            this.currentMdiChildForm = form; // Set again properties ( to use after)
        }

        public void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.setMdiChildFrom(new IndexMasterFrm(this.userLogin));
        }

        public void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.setMdiChildFrom(new AccountInfoFrm(this.userLogin));
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // show message box
            DialogResult result = MessageBox.Show("Are you sure want to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();

                // open login form
                LoginFrm loginFrm = new LoginFrm();
                loginFrm.Show();
            }
        }

        public void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // view info of customer
            this.setMdiChildFrom(new ManagermentFrm("customer"));
        }

        public void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // view info of staff
            this.setMdiChildFrom(new ManagermentFrm("staff"));
        }


        // use to set tssl from child form
        public void setToolStripStatusLable(string status)
        {
            this.tsslStatus.Text = status;
        }

        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure want exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(rs == DialogResult.Yes)
            {
                Application.Exit();
            } 
        }

        public void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.setMdiChildFrom(new BooksFrm());
        }

        public void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.setMdiChildFrom(new OrdersFrm(this.userLogin));
        }

        private void MainMaster_Load(object sender, EventArgs e)
        {
            // Hide some if role of user is staff
            if (userLogin.getRole().Equals("staff"))
            {
                userToolStripMenuItem.Visible = false;
                statisticalToolStripMenuItem.Visible = false;
            }
        }

        public void setUserLogin(User userLogin)
        {
            this.userLogin = userLogin;
        }

        public void tsmiBook_Click(object sender, EventArgs e)
        {
            // Thong ke sach ...
            this.setMdiChildFrom(new BookStatisticFrm());
        }

        public void tsmiRevenue_Click(object sender, EventArgs e)
        {
            // Thong ke doanh thu ...
            this.setMdiChildFrom(new RevenueStatisticFrm());
        }
    }
}

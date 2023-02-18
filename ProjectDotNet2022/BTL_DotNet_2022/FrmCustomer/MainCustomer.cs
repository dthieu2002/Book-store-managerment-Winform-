using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_DotNet_2022.FrmMaster;
using BTL_DotNet_2022.Models;

namespace BTL_DotNet_2022.FrmCustomer
{
    public partial class MainCustomer : Form
    {
        //=== Properties
        private Orders orders = new Orders();
        private User userLogin;
        private Form? childForm;

        
        // === Method
        public MainCustomer(User userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;

            // Status mode
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void MainCustomer_Load(object sender, EventArgs e)
        {
            // Set message
            lblMessage.Text = "Hello " + this.userLogin.getFullName()+
                              "\nWelcome to DTHieu Book store!";

            addMdiChild(new HomeCustomer(this.orders));
        }

        public void addMdiChild(Form form)
        {
            if(this.childForm != null)
            {
                this.childForm.Close();
                this.childForm.Dispose();
            }
            this.childForm = form;
            this.childForm.MdiParent = this;
            
            this.childForm.FormBorderStyle = FormBorderStyle.None;
            this.childForm.Dock = DockStyle.Fill;
            this.childForm.Show();

        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.addMdiChild(new AccountInfoFrm(this.userLogin));
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.MainCustomer_Load(sender, e);
        }

        public void btnCart_Click(object sender, EventArgs e)
        {
            this.addMdiChild(new CartFrm(this.orders, this.userLogin));
        }

        public void btnHistory_Click(object sender, EventArgs e)
        {
            string query = "Select OrdersId,OrdersDate as 'Orders date', OrdersStatus as 'Orders status' From tblOrders " +
                           "Where Username = '"+this.userLogin.getUsername()+"' And OrdersStatus != 'deleted' " +
                           "Order by OrdersDate DESC";
            this.addMdiChild(new OrdersFrm(this.userLogin, query));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                                                "Are you sure to exit?",
                                                "Exit",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning
                                             );
            if(rs == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();

                // Open login screen
                LoginFrm login = new LoginFrm();
                login.Show();
            }
        }

        private void btnStoreInfo_Click(object sender, EventArgs e)
        {
            this.addMdiChild(new StoreInfoFrm());
        }

        public void setUserLogin(User userLogin)
        {
            this.userLogin = userLogin;
        }
    }
}

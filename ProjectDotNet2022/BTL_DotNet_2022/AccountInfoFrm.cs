using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_DotNet_2022.FrmCustomer;
using BTL_DotNet_2022.FrmMaster;
using BTL_DotNet_2022.Models;

namespace BTL_DotNet_2022
{
    public partial class AccountInfoFrm : Form
    {
        // === Properties: 
        private User userLogin;

        // === Method: 
        public AccountInfoFrm(User userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;
        }

        private void AccountInfoFrm_Load(object sender, EventArgs e)
        {
            this.loadListView();
        }

        public void loadListView()
        {
            lstvAcountInfo.Items.Clear();
            lstvAcountInfo.FullRowSelect = true;

            // create new item of list view
            ListViewItem item = new ListViewItem("Username: ");
            item.SubItems.Add(userLogin.getUsername());
            lstvAcountInfo.Items.Add(item);

            item = new ListViewItem("Password: ");
            item.SubItems.Add(userLogin.getPassword());
            lstvAcountInfo.Items.Add(item);

            item = new ListViewItem("Full name: ");
            item.SubItems.Add(userLogin.getFullName());
            lstvAcountInfo.Items.Add(item);

            item = new ListViewItem("CCCD: ");
            item.SubItems.Add(userLogin.getCCCD());
            lstvAcountInfo.Items.Add(item);

            item = new ListViewItem("Address: ");
            item.SubItems.Add(userLogin.getAddress());
            lstvAcountInfo.Items.Add(item);

            item = new ListViewItem("Phone: ");
            item.SubItems.Add(userLogin.getPhone());
            lstvAcountInfo.Items.Add(item);

            item = new ListViewItem("Role: ");
            item.SubItems.Add(userLogin.getRole());
            lstvAcountInfo.Items.Add(item);
        }

        private void btnEditAccountInfo_Click(object sender, EventArgs e)
        {
            EditAccountInfoFrm edit = new EditAccountInfoFrm(this.userLogin, this);
            edit.ShowDialog();
        }

        public void resetUserLogin(User userLogin)
        {
            this.userLogin = userLogin;

            // Update user login in form master main
            if (this.MdiParent != null)
            {
                if (!this.userLogin.getRole().Equals("customer"))
                {
                    MainMaster main = (MainMaster)this.MdiParent;
                    main.setUserLogin(userLogin);
                }
                else // is customer
                {
                    MainCustomer main = (MainCustomer)this.MdiParent;
                    main.setUserLogin(userLogin);
                }  
            }

            this.loadListView();
        }



        /* OLD
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Note: get obj MdiParent From before command : this.Close();
            MainMaster main = (MainMaster)this.MdiParent;
            this.Close();

            // open indexMasterFrm when user exit AccountInfoFrm
            main.setMdiChildFrom(new IndexMasterFrm());
        }*/


    }
}

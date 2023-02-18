using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_DotNet_2022.Models;

namespace BTL_DotNet_2022
{
    public partial class MainFrm : Form
    {
        // === Properties ===
        private User userLogin;
        private Form currentChildForm = new Form(); // current form in pnlPrimary
        


        // === Method === 
        public MainFrm(User userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;

            // set background color code for pnlMenu
            pnlMenu.BackColor = ColorTranslator.FromHtml("#012e6b");
            

            // set defalt is login form
            this.setChildForm(new LoginFrm());

            // set lblUsername and lblFullName
            lblUsername.Text = "Username: "+userLogin.getUsername();
            lblFullName.Text = "Fullname: "+userLogin.getFullName();
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            timer1.Start(); 
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("T");
        }

        private void setChildForm(Form childForm)
        {
            if(this.currentChildForm != null)
            {
                this.currentChildForm.Close();
            }

            // set child form
            this.currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; // hide control box
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }


        public void setUserLogin(User userLogin) {
            this.userLogin = userLogin;
        }
        public User getUserLogin() { return this.userLogin; }

        private void pbxLogo_Click(object sender, EventArgs e)
        {
            // set current child form is LoginScreen
            this.setChildForm(new LoginFrm());
            this.Text = "Login";
        }

        private void btnHomeScreen_Click(object sender, EventArgs e)
        {
            // set current child form is LoginScreen
            this.setChildForm(new LoginFrm());
            this.Text = "Login";
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            // set current child form is AccountFrm
            this.setChildForm(new AccountInfoFrm(userLogin));
            this.Text = "Account infor";
        }

        
    }
}

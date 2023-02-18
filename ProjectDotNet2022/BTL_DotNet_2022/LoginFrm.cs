using BTL_DotNet_2022.Models;
using BTL_DotNet_2022.FrmMaster;
using BTL_DotNet_2022.FrmCustomer;
using System.Security.Permissions;

namespace BTL_DotNet_2022
{
    public partial class LoginFrm : Form
    {
        private UserMng userMng = new UserMng();

        public LoginFrm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;

            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            lblHeader.BackColor = System.Drawing.Color.Transparent;

            // Disallow user zoom in form
            MaximizeBox = false;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // check blank
            if (this.textFieldIsBlank())
            {
                return;
            }

            // check username - password
            if(!this.userMng.accountExists(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Username or password is wrong!",
                                "Login fail!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // hide LoginFrm
            this.Hide();

            // get current userLogin
            User userLogin = userMng.getUserObj(txtUsername.Text);

            // go to main follow the role of user
            switch (userLogin.getRole())
            {
                case "master":
                case "staff":
                    MainMaster mainMaster = new MainMaster(userLogin);
                    mainMaster.Show();
                    break;
                case "customer":
                    // is customer => go to MainCustomer
                    MainCustomer mainCustomer = new MainCustomer(userLogin);
                    mainCustomer.Show();
                    break;
                
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // OPEN Register Form
            this.Hide();
            RegisterFrm register = new RegisterFrm();
            register.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private bool textFieldIsBlank()
        {
            errorProvider1.Clear();

            bool isBlank = false;
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                errorProvider1.SetError(txtUsername, "Do not leave username blank!");
                txtUsername.Focus();
                isBlank = true;
            }

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {  
                errorProvider1.SetError(txtPassword, "Do not leave password blank!");
                if(!isBlank) txtPassword.Focus();
                isBlank = true;
            }

            return isBlank;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            // reset txtPassword each time user click
            txtPassword.Text = string.Empty;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, e);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, e);
            }
        }
    }
}
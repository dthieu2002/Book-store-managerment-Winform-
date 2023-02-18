using BTL_DotNet_2022.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_DotNet_2022
{
    public partial class RegisterFrm : Form
    {
        private UserMng userMng = new UserMng();

        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void gotoLoginScreen()
        {
            this.Hide();
            LoginFrm login = new LoginFrm();
            login.Show();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Do you really want exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(rs == DialogResult.Yes)
            {
                this.gotoLoginScreen();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // check blank
            if (this.textFieldIsBlank()) return;

            // check username exists ? 
            if (this.userMng.getUserObj(txtUsername.Text) != null)
            {
                errorProvider1.SetError(txtUsername, "Username has enterd is already exists! Please enter another username!");
                MessageBox.Show("Username has enterd is already exists! Please enter another username!"
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            // Add user (customer) into database
            if (userMng.addUser(new User(
                txtUsername.Text,
                txtPassword.Text,
                txtFullName.Text,
                txtCCCD.Text,
                txtAddress.Text,
                txtPhone.Text,
                "customer" // register form always add user with role = 'customer'
            ))){
                DialogResult rs = MessageBox.Show("Register successful! You want go to login screen?",
                    "Go to login screen", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(rs == DialogResult.Yes)
                {
                    this.gotoLoginScreen();
                }
            }
        }

        private bool textFieldIsBlank()
        {
            errorProvider1.Clear();

            bool isBlank = false;
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {  
                errorProvider1.SetError(txtUsername, "Don't leave blank!");
                txtUsername.Focus();
                isBlank = true;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "Don't leave blank!");
                if (!isBlank)
                {
                    isBlank = true;
                    txtPassword.Focus();
                }
            }
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                errorProvider1.SetError(txtFullName, "Don't leave blank!");
                if (!isBlank)
                {
                    isBlank = true;
                    txtFullName.Focus();
                }
            }
            if (string.IsNullOrEmpty(txtCCCD.Text.Trim()))
            {
                errorProvider1.SetError(txtCCCD, "Don't leave blank!");
                if (!isBlank)
                {
                    isBlank = true;
                    txtCCCD.Focus();
                }
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                errorProvider1.SetError(txtAddress, "Don't leave blank!");
                if (!isBlank)
                {
                    isBlank = true;
                    txtAddress.Focus();
                }
            }
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                errorProvider1.SetError(txtPhone, "Don't leave blank!");
                if (!isBlank)
                {
                    isBlank = true;
                    txtPhone.Focus();
                }
            }

            return isBlank;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnRegister_Click(sender, e);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnRegister_Click(sender, e);
            }
        }

        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnRegister_Click(sender, e);
            }
        }

        private void txtCCCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnRegister_Click(sender, e);
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnRegister_Click(sender, e);
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnRegister_Click(sender, e);
            }
        }
    }
}

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

namespace BTL_DotNet_2022
{
    public partial class EditAccountInfoFrm : Form
    {
        // === Properties :
        private User userLogin;

        private AccountInfoFrm accountInfoFrm;

        // === Method :
        public EditAccountInfoFrm(User userLogin, AccountInfoFrm accountInfoFrm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.userLogin = userLogin;
            this.accountInfoFrm = accountInfoFrm;

            // Set text
            lblUsername.Text = "Username: " + userLogin.getUsername();
            txtPassword.Text = userLogin.getPassword();
            txtFullName.Text = userLogin.getFullName();
            txtCCCD.Text = userLogin.getCCCD();
            txtAddress.Text = userLogin.getAddress();
            txtPhone.Text = userLogin.getPhone();
            this.accountInfoFrm = accountInfoFrm;
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            // Step 1: Check blank
            if (this.textBoxIsBlank()) return;

            // Step 2: Edit success
            UserMng mng = new UserMng();
            User userNew = new User(
                            this.userLogin.getUsername(), // Not change
                            txtPassword.Text,
                            txtFullName.Text,
                            txtCCCD.Text,
                            txtAddress.Text,
                            txtPhone.Text,
                            this.userLogin.getRole()      // Not change
            );

            bool rs = mng.updateUser(userNew);

            if (rs)
            {
                // Update successful
                this.Close();

                accountInfoFrm.resetUserLogin(userNew);

                MessageBox.Show("Save change successful!");
            }
            else
            {
                // Update fail
                MessageBox.Show("Save change failed!", "Edit fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool textBoxIsBlank()
        {
            errorProvider1.Clear();

            bool check = false;

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "Don't blank!");
                txtPassword.Focus();
                check = true;
            }

            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                errorProvider1.SetError(txtFullName, "Don't blank!");
                if (!check)
                {
                    txtFullName.Focus();
                    check = true;
                }
            }

            if (string.IsNullOrEmpty(txtCCCD.Text.Trim()))
            {
                errorProvider1.SetError(txtCCCD, "Don't blank!");
                if (!check)
                {
                    txtCCCD.Focus();
                    check = true;
                }
            }

            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                errorProvider1.SetError(txtAddress, "Don't blank!");
                if (!check)
                {
                    txtAddress.Focus();
                    check = true;
                }
            }

            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                errorProvider1.SetError(txtPhone, "Don't blank!");
                if (!check)
                {
                    txtPhone.Focus();
                    check = true;
                }
            }

            return check;
        }
    }
}

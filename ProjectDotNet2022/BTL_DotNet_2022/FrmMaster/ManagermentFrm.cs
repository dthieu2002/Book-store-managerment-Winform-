using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_DotNet_2022.Models;

namespace BTL_DotNet_2022.FrmMaster
{
    public partial class ManagermentFrm : Form
    {
        private string userType = "";  // customer or staff
        private MainMaster? mainMaster;
        private UserMng userMng = new UserMng();
        private string currentMode = "Ready";

        public ManagermentFrm(string userType)
        {
            InitializeComponent();

            this.userType = userType;

            // === Step 1: Set header text and btn text
            lblHeader.Text = "Manager " + userType+" : ";
            btnAdd.Text = "Add new " + userType;
            btnEdit.Text = "Edit " + userType;
            btnDelete.Text = "Delete " + userType;

            // === Step 2: configuration properties of dgv
            // get data of customer and display in dgvData
            this.resetDGVData();
            dgvData.Refresh();

            // fit width of cells
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // don't allow user add row
            dgvData.AllowUserToAddRows = false;

            // set header for column on dgvData
            dgvData.Columns[2].HeaderText = "Full name";
            dgvData.Columns[7].HeaderText = "Register date";

            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvData.MultiSelect = false;

        }
        private void CustomerManagermentFrm_Load(object sender, EventArgs e)
        {
            dgvData.ClearSelection();
            this.clearTextBox();

            // set current mode
            this.mainMaster = (MainMaster)this.MdiParent;
            this.setMode(this.currentMode); 
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvData.SelectedRows.Count > 0)
            {
                // display data row selected of dgvData on the Detail: ( right panel ) 
                txtUsername.Text = dgvData.SelectedRows[0].Cells[0].Value.ToString();
                txtPassword.Text = dgvData.SelectedRows[0].Cells[1].Value.ToString();
                txtFullName.Text = dgvData.SelectedRows[0].Cells[2].Value.ToString();
                txtCCCD.Text = dgvData.SelectedRows[0].Cells[3].Value.ToString();
                txtAddress.Text = dgvData.SelectedRows[0].Cells[4].Value.ToString();
                txtPhone.Text = dgvData.SelectedRows[0].Cells[5].Value.ToString();
                
                // if row of dgvData if selected than enabled btnEdit and btnDelete
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            
        }

        private void setEnabledOfAllTextBox(bool value)
        {
            txtUsername.Enabled = value;
            txtPassword.Enabled = value;
            txtFullName.Enabled = value;
            txtCCCD.Enabled = value;
            txtAddress.Enabled = value;
            txtPhone.Enabled = value;
        }

        private void clearTextBox()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // change mode
            this.setMode("Add");
        }

        private void btnExitMode_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Do you realy want to exit "+this.currentMode+" mode? ",
                            "Exit "+this.currentMode+" mode",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if(rs == DialogResult.Yes)
            {
                // goto ready mode
                this.setMode("Ready");
            }

        }

        private void dgvCustomer_EnabledChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (!dgv.Enabled)
            {
                dgv.DefaultCellStyle.BackColor = SystemColors.Control;
                dgv.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.CurrentCell = null;
                dgv.ReadOnly = true;
                dgv.EnableHeadersVisualStyles = false;
            }
            else
            {
                dgv.DefaultCellStyle.BackColor = SystemColors.Window;
                dgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.ReadOnly = false;
                dgv.EnableHeadersVisualStyles = true;
            }
        }

        private bool textBoxIsBlank()
        {
            errorProvider1.Clear();

            bool isBlank = false;
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Do not blank!");
                isBlank = true;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                if (!isBlank)
                {
                    txtPassword.Focus();
                    isBlank = true;
                }
                errorProvider1.SetError(txtPassword, "Do not blank!");  
            }
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                if (!isBlank)
                {
                    txtFullName.Focus();
                    isBlank = true;
                }
                errorProvider1.SetError(txtFullName, "Do not blank!");
            }
            if (string.IsNullOrEmpty(txtCCCD.Text.Trim()))
            {
                if (!isBlank)
                {
                    txtCCCD.Focus();
                    isBlank = true;
                }
                errorProvider1.SetError(txtCCCD, "Do not blank!");
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                if (!isBlank)
                {
                    txtAddress.Focus();
                    isBlank = true;
                }
                errorProvider1.SetError(txtAddress, "Do not blank!");
            }
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                if (!isBlank)
                {
                    txtPhone.Focus();
                    isBlank = true;
                }
                errorProvider1.SetError(txtPhone, "Do not blank!");
            }

            return isBlank;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // That mean: program in "add mode" or "update mode"
            if (btnSave.Enabled)
            {
                // Step 1: check blank
                if (this.textBoxIsBlank())
                {
                    MessageBox.Show("Don't leave text blank!", "Save fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Execute job dependend of "current mode"
                User newUser = new User(
                                txtUsername.Text,
                                txtPassword.Text,
                                txtFullName.Text,
                                txtCCCD.Text,
                                txtAddress.Text,
                                txtPhone.Text,
                                this.userType);  // important
                                // Don't need add value of "Register Date" because it is automatic set - Default(GETDATE()) -
                switch (this.currentMode)
                {
                    case "Add":
                        // 2.1: check if username was already exists
                        if (this.userMng.getUserObj(txtUsername.Text) != null)
                        {
                            txtUsername.Focus();
                            errorProvider1.SetError(txtUsername, "Username is already exists!");
                            MessageBox.Show("Username has enter is already exists! \nPlease enter another username!",
                                "Add " + this.userType + " fail",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        // 2.2: execute add user into database 
                        this.userMng.addUser(newUser);
                        // 2.3: Show message
                        MessageBox.Show("Add new " + this.userType + " successful!", 
                                        "Add new " + this.userType, 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Information);
                        break;

                    case "Edit":
                        DialogResult rs = MessageBox.Show("Are you sure want save change?",
                                                     "Save change data",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);
                        if(rs == DialogResult.Yes)
                        {
                            // 2.1: Update the new data into database
                            this.userMng.updateUser(newUser);
                            // 2.2: Show message
                            MessageBox.Show("Update data of " + this.userType + " successful!",
                                            "Update data",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            return; // Keep going in Edit mode
                        }
                        break;
                }

                // Step 3: rest data on dgvData
                this.resetDGVData();
                
                // Last step: go to ready mode
                this.setMode("Ready");
            }
           
        }

        private void setMode(string mode)
        {
            // alway clear errorProvider while change mode
            errorProvider1.Clear();

            // set current mode properties
            this.currentMode = mode;

            // Step 1: set status of MdiParent
            this.mainMaster.setToolStripStatusLable(mode+" mode: ");

            switch(mode)
            {
                case "Ready":
                    // Step 2: enabled dgvData
                    this.dgvData.Enabled = true;
                
                    // Step 3: disallowed btnEdit, btnDelete, btnSave, btnExitMode
                    this.btnEdit.Enabled = false;
                    this.btnDelete.Enabled = false;
                    this.btnSave.Enabled = false;
                    this.btnExitMode.Enabled = false;
                    this.btnAdd.Enabled = true;             // enabled btnAdd
                
                    // Step 4:clear and disallowed all text box
                    this.clearTextBox();
                    this.setEnabledOfAllTextBox(false);

                    // Step 5: Clear selection
                    dgvData.ClearSelection();
                    break;

                case "Add":
                    // Step 2: disallowed dgvData
                    dgvData.Enabled = false;

                    // Step 3: button: enabled btnExitMode, btnSave
                    btnSave.Enabled = true;
                    btnExitMode.Enabled = true;
                    btnExitMode.Text = "Exit add mode";
                    // Disallowed btnAdd, btnEdit , btnDelete
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;

                    // Step 4: Clear and enabled all text box
                    this.clearTextBox();
                    this.setEnabledOfAllTextBox(true);   // allow user enter data

                    // Step 5: clear selection in dgv
                    dgvData.ClearSelection();
                    txtUsername.Focus();

                    // Step 6: show message box
                    MessageBox.Show("Add mode on:\nPlease enter info of new user in the right panel!", "Add mode on", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "Edit":
                    // Step 2: Dissallowed dgv
                    dgvData.Enabled = false;

                    // Step 3: Button
                    //Enabled btnSave, btnExitMode
                    btnSave.Enabled = true;
                    btnExitMode.Enabled = true;
                    //Disallowed btnAdd, btnEdit, btnDelete
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;

                    // Step 4: Enabled all text box except txtUsername
                    this.setEnabledOfAllTextBox(true);
                    txtUsername.Enabled = false; // don't allow edit Username

                    // Step 5: Clear selection in dgv
                    dgvData.ClearSelection();

                    // Step 6: Show message
                    MessageBox.Show("Edit mode on.\nYou can replace what data you want change:",
                                    "Edit mode on",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    break;
            }


        }

        private void btnExitMode_EnabledChanged(object sender, EventArgs e)
        {
            if (btnExitMode.Enabled)
            {
                btnExitMode.Show();
            }
            else
            {
                btnExitMode.Hide();
            }
        }

        private void btnSave_EnabledChanged(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                btnSave.Show();
            }
            else
            {
                btnSave.Hide();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Step 1: Show message
            DialogResult rs = MessageBox.Show("Are you sure want to Delete the " + this.userType + " ?",
                                              "Delete "+this.userType,
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);
            if(rs == DialogResult.Yes)
            {
                // Step 2: Delete user has selected
                this.userMng.deleteUser(dgvData.CurrentRow.Cells[0].Value.ToString());

                
                // Step 3: Show message
                MessageBox.Show("Delete " + this.userType + " successful!",
                                "Delele"+this.userType+" successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Step 4: Reset dgvData
                this.resetDGVData();

                // Last step : Go to Ready mode
                this.setMode("Ready");
            }

        }

        private void resetDGVData()
        {
            dgvData.DataSource = DB.getDataTableWithClause(
                    "SELECT * From tblUser " +
                    "WHERE Role='" + userType + "'" +
                    "ORDER BY RegisterDate"
                );
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.setMode("Edit");
        }

        private void txtFullNameFilter_TextChanged(object sender, EventArgs e)
        {
            string query = "Select * From tblUser " +
                           "Where Role='"+this.userType+"' and FullName like N'%" +txtFullNameFilter.Text+ "%'" +
                           "Order by RegisterDate";

            dgvData.DataSource = DB.getDataTableWithClause(query);
            dgvData.Refresh();
            dgvData.ClearSelection();
            dgvData.CurrentCell = null;
            this.clearTextBox();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullNameFilter.Text = String.Empty;
        }

        private void ManagermentFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.mainMaster != null)
            {
                this.mainMaster.setToolStripStatusLable("Ready");

            }
        }
    }
}

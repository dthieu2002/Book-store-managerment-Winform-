using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_DotNet_2022.Models;

namespace BTL_DotNet_2022.FrmMaster
{
    public partial class BookDetailFrm : Form
    {
        // === Properties ===
        private string mode = string.Empty; // Add || Edit || Detail
        private Book bookSelected;

        private BookMng bookMng = new BookMng();
        private MainMaster? mainMaster; // Alway need to set status of MdiParent
        private BooksFrm? booksFrm; // Need for Add and Edit mode

        // === Method ===
        public BookDetailFrm(Book bookSelected, string mode)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            pbxBookImage.SizeMode = PictureBoxSizeMode.Zoom;
            dtpReleaseDate.Format = DateTimePickerFormat.Short;

            // Asign book selected 
            this.bookSelected = bookSelected;

            // Set mode
            this.setMode(mode);

        }


        private void setMode(string mode)
        {
            this.mode = mode;

            // Step 1: Set header
            lblHeader.Text = mode + " book:";

            // Step 2: Set button text
            btnPrimary.Text = this.mode;

            switch (this.mode)
            {
                case "Add":
                    // Step 3: Primary button
                    btnPrimary.Text = "Add book";

                    // Step 4: book id label
                    lblBookId.Text = String.Empty;

                    break;
                case "Edit":
                    // Step 3: Primary button
                    btnPrimary.Text = "Save edit";

                    // Step 4: book id label
                    lblBookId.Text = "Book id: "+this.bookSelected.getBookId().ToString();

                    // Set image
                    if (!string.IsNullOrEmpty(this.bookSelected.getBookImage()))
                    {
                        pbxBookImage.Image = new Bitmap(this.bookSelected.getBookImage());
                        pbxBookImage.Tag = this.bookSelected.getBookImage(); // Useful for some case
                    }

                    // Fill data of book selected
                    this.fillDataOfBookToTextBox();

                    // Only btnChangeImage whill show
                    btnAddImage.Hide();
                    btnDeleteImage.Hide();

                    break;

                case "Detail":
                    // Step 3: Primary button
                    btnPrimary.Hide();

                    // Step 4: book id label
                    lblBookId.Text = "Book id: " + this.bookSelected.getBookId().ToString();

                    // Set image
                    if (!string.IsNullOrEmpty(this.bookSelected.getBookImage()))
                    {
                        pbxBookImage.Image = new Bitmap(this.bookSelected.getBookImage());
                        pbxBookImage.Tag = this.bookSelected.getBookImage(); // Useful for some case
                    }

                    // Fill data of book selected
                    this.fillDataOfBookToTextBox();

                    // Set all text is read only, dateTimePicker is disallowed
                    this.setReadOnlyAllTextBox(true);
                    dtpReleaseDate.Enabled = false;

                    // Can't CRUD image in detail mode
                    btnAddImage.Hide();
                    btnChangeImage.Hide();
                    btnDeleteImage.Hide();

                    break;
            }
        }

        private void fillDataOfBookToTextBox()
        {
            txtName.Text = this.bookSelected.getBookName();
            txtGenre.Text = this.bookSelected.getBookGenre();
            txtAuthor.Text = this.bookSelected.getBookAuthor();
            txtPrice.Text = this.bookSelected.getBookPrice().ToString();

            dtpReleaseDate.Value = this.bookSelected.getReleaseDate();

            txtInventoryQuantity.Text = this.bookSelected.getInventoryQuantity().ToString();
        }
        private void setReadOnlyAllTextBox(bool enabled)
        {
            txtName.ReadOnly = enabled;
            txtGenre.ReadOnly = enabled;
            txtAuthor.ReadOnly = enabled;
            txtPrice.ReadOnly = enabled;
            txtInventoryQuantity.ReadOnly = enabled;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure want to exit? ",
                            "Exit",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if(rs == DialogResult.Yes)
            {
                this.Close();
            }
        }



        private void BookDetailFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // change status of mdiParent
            if (this.mainMaster != null)
            {
                this.mainMaster.setToolStripStatusLable("Ready");
            }
        }

        private void btnPrimary_Click(object sender, EventArgs e)
        {
            // Step 1: Check blank
            if (this.textBoxIsBlank())
            {
                this.showError("Do not leave text blank!");
                return;
            }

            // Step 2: Validation price and inventory quantity ( must be numeric )
            double temp;
            if(!Double.TryParse(txtPrice.Text.Trim(),out temp))
            {
                errorProvider1.SetError(txtPrice, "Price must be numeric!");
                txtPrice.Focus();
                this.showError("Price must be numeric!");
                return;
            }
            else
            {
                if (temp < 0)
                {
                    errorProvider1.SetError(txtPrice, "Price must be greater or equal 0!");
                    txtPrice.Focus();
                    this.showError("Price must be greater or equal 0!");
                    return;
                }
            }
            
            if(!Double.TryParse(txtInventoryQuantity.Text.Trim(), out temp))
            {
                errorProvider1.SetError(txtInventoryQuantity, "Inventory quantity must be numeric!");
                txtInventoryQuantity.Focus();
                this.showError("Inventory quantity must be numeric!");
                return;
            }
            else
            {
                if (temp < 0)
                {
                    errorProvider1.SetError(txtInventoryQuantity, "Inventory quantity must be greater or equal 0!");
                    txtInventoryQuantity.Focus();
                    this.showError("Inventory quantity must be greater or equal 0!");
                    return;
                }
            }

            // Step 3: Check image 
            if(pbxBookImage.Image == null)
            {
                errorProvider1.SetError(pbxBookImage, "Don't leave book image blank!");
                this.showError("Don't leave book image blank!");
                return;
            }

            // Step 3: Execute
            switch (this.mode)
            {
                case "Add":
                    bool rs = this.bookMng.addBook
                    (
                        new Book
                        (
                            0, // book id is Indentity int
                            txtName.Text, 
                            txtGenre.Text,
                            txtAuthor.Text,
                            Decimal.Parse(txtPrice.Text),
                            dtpReleaseDate.Value,
                            pbxBookImage.Tag.ToString(),
                            Convert.ToInt32(txtInventoryQuantity.Text)
                        )    
                    );

                    if (rs)
                    {
                        this.Close();
                        MessageBox.Show("Add new book successful!", "Add success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresh data in bookFrm form
                        if(this.booksFrm!= null)
                        {
                            this.booksFrm.BooksFrm_Load(sender, e);
                        }
                        
                    }
                    else
                    {
                        this.showError("Add fail!");
                    }

                    break;
                case "Edit":
                    // Edit book
                    bool result = this.bookMng.editBook
                    (
                        new Book
                        (
                            this.bookSelected.getBookId(), // Old id
                            txtName.Text,
                            txtGenre.Text,
                            txtAuthor.Text,
                            Convert.ToDecimal(txtPrice.Text),
                            dtpReleaseDate.Value,
                            pbxBookImage.Tag.ToString(),
                            Convert.ToInt32(txtInventoryQuantity.Text)
                        )
                    );

                    if (result)
                    {
                        this.Close();
                        // Show message
                        MessageBox.Show("Edit book successful!",
                                        "Edit book successful",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        // Refresh data in bookFrm form
                        if (this.booksFrm != null)
                        {
                            this.booksFrm.BooksFrm_Load(sender, e);
                        }
                    }
                    else
                    {
                        this.showError("Update fail!");
                    }

                    break;
            }
        }

        public bool textBoxIsBlank()
        {
            errorProvider1.Clear();
            bool isBlank = false;

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.Focus();
                isBlank = true;
                errorProvider1.SetError(txtName, "Don't blank!");
            }

            if (string.IsNullOrEmpty(txtGenre.Text.Trim()))
            {
                if (!isBlank)
                {
                    isBlank = true;
                    txtGenre.Focus();
                }
                errorProvider1.SetError(txtGenre, "Don't blank!");
            }

            if (string.IsNullOrEmpty(txtAuthor.Text.Trim()))
            {
                if (!isBlank)
                {
                    isBlank = true;
                    txtAuthor.Focus();
                }
                errorProvider1.SetError(txtAuthor, "Don't blank!");
            }

            if (string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                if (!isBlank)
                {
                    isBlank = true;
                    txtPrice.Focus();
                }
                errorProvider1.SetError(txtPrice, "Don't blank!");
            }

            if (string.IsNullOrEmpty(txtInventoryQuantity.Text.Trim()))
            {
                if (!isBlank)
                {
                    isBlank = true;
                    txtInventoryQuantity.Focus();
                }
                errorProvider1.SetError(txtInventoryQuantity, "Don't blank!");
            }

            return isBlank;
        }

        public void showError(string message)
        {
            MessageBox.Show(message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            // Execute add image while image of pbx = null
            if(pbxBookImage.Image == null)
            {
                this.addImageToPictureBox();
            }
            else
            {
                this.showError("You can't add while image not empty! (Recomment: Click change image)");
            }
        }

        private void addImageToPictureBox()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.InitialDirectory = @"C:\Users\Admin\source\repos\ProjectDotNet2022\BTL_DotNet_2022\Public\Images";
            openFileDialog.Title = "Chosse book image";
            openFileDialog.Filter = "Jpg file|*.jpg|Pnj file|*.pnj|Icon file|*.ico|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbxBookImage.Image = new Bitmap(openFileDialog.FileName);
                pbxBookImage.Tag = openFileDialog.FileName; // store Url of image => to add into properties of book ( book image)
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtGenre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtAuthor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtInventoryQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpReleaseDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }


        public void setBooksFrm(BooksFrm booksFrm)
        {
            this.booksFrm = booksFrm;
        }

        public void setMainMaster(MainMaster mainMaster)
        {
            this.mainMaster = mainMaster;
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            if(pbxBookImage.Image != null)
            {
                this.addImageToPictureBox();
            }
            else
            {
                this.showError("You must add book image first!");
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if(pbxBookImage.Image != null)
            {
                this.pbxBookImage.Image = null;
                this.pbxBookImage.Tag = string.Empty;

                MessageBox.Show("Delete successful!");
            }
            else
            {
                this.showError("The image is empty! Can't delete!");
            }
        }
    }


}

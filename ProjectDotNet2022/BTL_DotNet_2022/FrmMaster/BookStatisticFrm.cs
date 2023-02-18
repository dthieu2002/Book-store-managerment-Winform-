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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace BTL_DotNet_2022.FrmMaster
{
    public partial class BookStatisticFrm : Form
    {
        // Const use in class
        private const string select1 = "Sold-out book";
        private const string select2 = "Best seller book";

        private BookMng bookMng = new BookMng();

        public BookStatisticFrm()
        {
            InitializeComponent();
        }

        private void BookStatisticFrm_Load(object sender, EventArgs e)
        {
            dgvBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBook.MultiSelect = false;
            dgvBook.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvBook.AllowUserToAddRows = false;

            cbxStatisticFollow.DropDownStyle = ComboBoxStyle.DropDownList;

            // Initial combobox
            cbxStatisticFollow.Items.Add(select1);
            cbxStatisticFollow.Items.Add(select2);

            // Pbx
            pbxBookImage.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void cbxStatisticFollow_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pbxBookImage.Image = null;
            this.lblDetailBook.Text = String.Empty;

            if (cbxStatisticFollow.SelectedItem.ToString().Equals(select1))
            {
                string clause = "Select BookId as 'Book id', BookName as 'Book name' From tblBook where InventoryQuantity = 0";
                this.dgvBook.DataSource = DB.getDataTableWithClause(clause);
                this.dgvBook.Refresh();
            }
            else // Select 2 : BestSeller book
            {
                string clause = "Select  BookId as 'Book id' ,Sum(Amount) as 'Amount sold' From tblOrders_Detail " +
                            "Where Exists(  Select * From tblOrders " +
                                            "Where tblOrders.OrdersId = tblOrders_Detail.OrdersId " +
                                            "And tblOrders.OrdersStatus = 'accept'" +
                                        ")" +
                            "Group by BookId " +
                            "Order By Sum(Amount) DESC";
                this.dgvBook.DataSource = DB.getDataTableWithClause(clause);
                this.dgvBook.Refresh();
            }
        }

        private void dgvBook_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvBook.SelectedRows.Count > 0)
            {
                // Get book in current row selected
                Book bookSelected = this.bookMng.getBook((int)dgvBook.CurrentRow.Cells[0].Value);

                if(bookSelected != null)
                {
                    // Set lbl
                    lblDetailBook.Text = "Id: " + bookSelected.getBookId().ToString() +
                                         "\nName: " + bookSelected.getBookName() +
                                         "\nGenre: " + bookSelected.getBookGenre() +
                                         "\nAuthor: " + bookSelected.getBookAuthor() +
                                         "\nPrice: " + bookSelected.getBookPrice().ToString() +
                                         "\nRelease date: " + bookSelected.getReleaseDate().ToString("dd-MM-yyyy");

                    // Set image
                    Bitmap imageBook = new Bitmap(bookSelected.getBookImage());
                    pbxBookImage.Image = (Image)imageBook;
                }
            }
        }
    }
}

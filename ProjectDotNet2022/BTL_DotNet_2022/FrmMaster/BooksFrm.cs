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

namespace BTL_DotNet_2022.FrmMaster
{
    public partial class BooksFrm : Form
    {
        private BookMng? bookMng;
        private MainMaster mainMaster;

        public BooksFrm()
        {
            InitializeComponent();
            pnlContent.AutoScroll = true;
            pnlContent.Width = 1150;

        }

        public void BooksFrm_Load(object sender, EventArgs e)
        {
            // Set main master properties
            this.mainMaster = (MainMaster)this.MdiParent;

            // Set status 
            this.mainMaster.setToolStripStatusLable("Ready");

            // Render book
            this.renderBook();
            
            // Render top 3 book best seller
            this.renderTop3BookSeller();
        }

        public void renderBook(string query="")
        {
            // Clear all controls in pnlContent
            this.pnlContent.Controls.Clear();

            // Get list book
            this.bookMng = new BookMng(); 

            List<Book> books;
            if (string.IsNullOrEmpty(query)) books = this.bookMng.getListBook();
            else books = this.bookMng.getListBookWithClause(query);
            
            // Render book
            foreach (Book book in books)
            {
                FlowLayoutPanel pnl = new FlowLayoutPanel();
                pnlContent.Controls.Add(pnl);
                pnl.Dock = DockStyle.Top;
                pnl.Height = 300;
                pnl.BorderStyle = BorderStyle.FixedSingle;

                PictureBox pictureBox = new PictureBox();
                Bitmap image = new Bitmap(book.getBookImage());
                pictureBox.Image = image;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Height = 300;
                pictureBox.Width = 200;
                pnl.Controls.Add(pictureBox);

                ListView lsv = new ListView();
                lsv.Columns.Add(new ColumnHeader());
                lsv.Columns.Add(new ColumnHeader());
                lsv.Columns[0].Width = 150;
                lsv.Columns[1].Width = 350;
                lsv.HeaderStyle = ColumnHeaderStyle.None;
                lsv.Scrollable = false;
                lsv.FullRowSelect = true;
                lsv.View = View.Details;
                lsv.Dock = DockStyle.Fill;
                lsv.Width = 500;

                pnl.Controls.Add(lsv);

                ListViewItem item = new ListViewItem("Id: ");
                item.SubItems.Add(book.getBookId().ToString());
                lsv.Items.Add(item);

                item = new ListViewItem("Name: ");
                item.SubItems.Add(book.getBookName().ToString());
                lsv.Items.Add(item);

                item = new ListViewItem("Genre: ");
                item.SubItems.Add(book.getBookGenre().ToString());
                lsv.Items.Add(item);

                item = new ListViewItem("Author: ");
                item.SubItems.Add(book.getBookAuthor().ToString());
                lsv.Items.Add(item);

                item = new ListViewItem("Price: ");
                item.SubItems.Add(book.getBookPrice().ToString());
                lsv.Items.Add(item);

                item = new ListViewItem("Release date: ");
                item.SubItems.Add(book.getReleaseDate().ToString("dd-MM-yyyy"));
                lsv.Items.Add(item);

                item = new ListViewItem("Inventory quantity: ");
                item.SubItems.Add(book.getInventoryQuantity().ToString());
                lsv.Items.Add(item);

                Button btnEdit = new Button();
                pnl.Controls.Add(btnEdit);
                btnEdit.Text = "Edit";
                btnEdit.Dock = DockStyle.Fill;
                btnEdit.Padding = new Padding(5);
                btnEdit.Width = 120;
                // Write event onclick for button
                btnEdit.Click += (sender, args) =>
                {
                    // set status
                    this.mainMaster.setToolStripStatusLable("Edit mode");

                    // open form detailt of book
                    BookDetailFrm bookDetailFrm = new BookDetailFrm(book, "Edit");
                    bookDetailFrm.setBooksFrm(this);
                    bookDetailFrm.setMainMaster(this.mainMaster); // Support to change status in mdi parent
                    bookDetailFrm.ShowDialog();
                };

                Button btnDelete = new Button();
                pnl.Controls.Add(btnDelete);
                btnDelete.Text = "Delete";
                btnDelete.Dock = DockStyle.Fill;
                btnDelete.Padding = new Padding(5);
                btnDelete.Tag = book.getBookId();
                btnDelete.Width = 120;
                // Write event for btn delete
                btnDelete.Click += (sender, agrs) =>
                {
                    DialogResult rs = MessageBox.Show("Are you really want to delete this book?",
                                    "Delete book",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);
                    if(rs == DialogResult.Yes)
                    {
                        if (this.bookMng.deleteBook(book)) // Delete successful
                        {
                            MessageBox.Show("Delete successful!",
                                            "Delete successful",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            // render book list and top 3 book best seller
                            this.renderBook();
                            this.renderTop3BookSeller();
                        }
                        else // delete fail
                        {
                            MessageBox.Show("Delete book fail!",
                                            "Delete book fail",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                };

                Button btnDetail = new Button();
                pnl.Controls.Add(btnDetail);
                btnDetail.Text = "Detail";
                btnDetail.Dock = DockStyle.Fill;
                btnDetail.Padding = new Padding(5);
                btnDetail.Tag = book.getBookId();
                btnDetail.Width = 120;
                // Write event for btn detail
                btnDetail.Click += (sender, agrs) =>
                {
                    // set status
                    this.mainMaster.setToolStripStatusLable("Detail mode");

                    // Go to BookDetail
                    BookDetailFrm bookDetailFrm = new BookDetailFrm(book, "Detail");
                    bookDetailFrm.setMainMaster(this.mainMaster);
                    bookDetailFrm.ShowDialog();
                };

            }
        }
        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            // change status label
            MainMaster mainMaster = (MainMaster)MdiParent;
            mainMaster.setToolStripStatusLable("Add mode");

            BookDetailFrm bookDetailFrm = new BookDetailFrm(new Book(), "Add");
            bookDetailFrm.setMainMaster(mainMaster);
            bookDetailFrm.setBooksFrm(this);
            bookDetailFrm.ShowDialog();
        }

        public void renderTop3BookSeller()
        {
            // Clean panel
            flpBestSeller.Controls.Clear();

            int count = 1;
            if (this.bookMng == null) this.bookMng = new BookMng();
            List<Book> books = this.bookMng.getBookSeller("Top 5", "DESC");

            foreach(Book book in books)
            {
                Panel pnl = new Panel();
                flpBestSeller.Controls.Add(pnl);
                pnl.Dock = DockStyle.Top;
                pnl.Height = 200;
                pnl.Width = 550;
                pnl.BackColor = Color.Black;

                PictureBox pbx = new PictureBox();
                pnl.Controls.Add(pbx);
                pbx.Dock = DockStyle.Left;
                pbx.Height = 200;
                pbx.Width = 150;
                pbx.SizeMode = PictureBoxSizeMode.Zoom;
                pbx.Image = new Bitmap(book.getBookImage());

                // Event of picture box
                pbx.MouseHover += (sender, args) =>
                {
                    pbx.BackColor = Color.Green;
                };

                pbx.MouseLeave += (sender, args) =>
                {
                    pbx.BackColor = Color.Black;
                };

                pbx.Click += (sender, args) =>
                {
                    // Set status
                    this.mainMaster.setToolStripStatusLable("Detail mode:");

                    // Open detail
                    BookDetailFrm bookDetailFrm = new BookDetailFrm(book, "Detail");
                    bookDetailFrm.setMainMaster(this.mainMaster);
                    bookDetailFrm.ShowDialog();
                };
                
                ListView lsv = new ListView();
                lsv.View = View.Tile;
                pnl.Controls.Add(lsv);
                lsv.Dock = DockStyle.Right;
                lsv.Width = 400;
                
                ListViewItem item = new ListViewItem(" Top " + count++ +" ");
                item.ForeColor = Color.Yellow;
                item.BackColor = Color.Black;
                lsv.Items.Add(item);

                item = new ListViewItem("Name: "+ book.getBookName());
                lsv.Items.Add(item);

                item = new ListViewItem("Amount sold: "+ book.getAmountSold().ToString());
                lsv.Items.Add(item);

            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string query = "Select * From tblBook " +
                           "Where BookName like N'%" + txtFilter.Text + "%'";
            this.renderBook(query);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFilter.Text = String.Empty;
            this.BooksFrm_Load(sender, e);
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnFilter_Click(sender, e);
            }
        }
    }
}

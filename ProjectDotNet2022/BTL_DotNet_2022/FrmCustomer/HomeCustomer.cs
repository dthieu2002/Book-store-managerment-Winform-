using BTL_DotNet_2022.FrmMaster;
using BTL_DotNet_2022.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BTL_DotNet_2022.FrmCustomer
{
    public partial class HomeCustomer : Form
    {
        private Orders orders;
        private BookMng bookMng = new BookMng();

        public HomeCustomer(Orders orders)
        {
            InitializeComponent();
            pnlContent.AutoScroll = true;
            this.orders = orders;

            // Set combobox sort is read only
            cbbSort.SelectedItem = cbbSort.Items[0];
            cbbSort.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void HomeCustomer_Load(object sender, EventArgs e)
        {
            this.renderBookList();
        }

        public void renderBookList(List<Book>? books=null)
        {
            if (books == null)
            {
                books = this.bookMng.getListBook();
            }
            
            foreach(Book book in books)
            {
                FlowLayoutPanel pnl = new FlowLayoutPanel()
                {
                    Height = 400,
                    Width = 600,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.Fixed3D,
                    BackColor = Color.White,
                    FlowDirection = FlowDirection.LeftToRight
                };
                pnlContent.Controls.Add(pnl);

                Panel pnlImage = new Panel()
                {
                    Height = pnl.Height,
                    Width = 250
                };
                pnl.Controls.Add(pnlImage);

                PictureBox pbx = new PictureBox()
                {
                    Image = new Bitmap(book.getBookImage()),
                    Height = pnl.Height,
                    Width = pnlImage.Width,
                    SizeMode = PictureBoxSizeMode.CenterImage
                };
                pnlImage.Controls.Add(pbx);
                //Event pbx click
                pbx.Click += (sender, e) =>
                {
                    BookDetailFrm bookDetailFrm = new BookDetailFrm(book, "Detail");
                    bookDetailFrm.ShowDialog();
                };
                
                FlowLayoutPanel pnlIntro = new FlowLayoutPanel()
                {
                    Height = pnl.Height,
                    Width = pnl.Width - pnlImage.Width - 20
                };
                pnl.Controls.Add(pnlIntro);

                Label lbl = new Label()
                {
                    Text = "Id : " + book.getBookId().ToString() +
                           "\n\nName: " + book.getBookName() +
                           "\n\nGenre: " + book.getBookGenre() +
                           "\n\nPrice: "+book.getBookPrice()+" $"+
                           "\n\nRelease date: " + book.getReleaseDate().ToString("dd-MM-yyyy"),
                    TextAlign = ContentAlignment.TopLeft,
                    Height = pnl.Height - 150,
                    Width = pnlIntro.Width,
                    Margin = new Padding(0, 0, 0, 5)
                    //Dock = DockStyle.Right
                    
                };
                pnlIntro.Controls.Add(lbl);
                
                NumericUpDown nud = new NumericUpDown()
                {
                    Value = 1,
                    Increment = 1,
                    Minimum = 1,
                    Maximum = 2000,
                    Height = 60,
                    Width = 100,
                    //Dock = DockStyle.Bottom,
                    TextAlign = HorizontalAlignment.Center
                };
                pnlIntro.Controls.Add(nud);

                Button btn = new Button()
                {
                    Text = "Add to cart",
                    //Dock = DockStyle.Bottom,
                    Height = 100,
                    Width = 150,
                    BackColor = Color.DarkBlue,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White
                    
                };
                pnlIntro.Controls.Add(btn);

                // Event click btn
                btn.Click += (sender, args) =>
                {
                    // Add new orders detail to Cart (Orders)
                    orders.addOrdersDetail(book, (int)nud.Value);
                    MessageBox.Show("Add book into cart successful!");
                };

                
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // Not work if txtBookName is empty and cbbSort is defaul selected
            if(string.IsNullOrEmpty(txtBookName.Text.Trim()) && cbbSort.SelectedIndex == 0)
            {
                return;
            }

            // Work: First -> clear all controls of pnlContent
            pnlContent.Controls.Clear();

            // Book name
            string bookName = txtBookName.Text.Trim();

            // Sort
            string query = "";
            if(cbbSort.SelectedIndex == 1)// Price
            {
                // Get query
                query = "Select * From tblBook "+
                               "Where BookName like N'%"+bookName+"%' "+
                               "Order by BookPrice ";
                if (rbnDescending.Checked) query += "DESC";
            }
            else // Not sort
            {
                query = "Select * From tblBook Where BookName like N'%" + bookName + "%'";
            }

            this.renderBookList(this.bookMng.getListBookWithClause(query));

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBookName.Text = string.Empty;
            pnlContent.Controls.Clear();

            cbbSort.SelectedItem = cbbSort.Items[0];
            rbnAscending.Checked = true;

            this.renderBookList(); // Render all book
        }

    }
}

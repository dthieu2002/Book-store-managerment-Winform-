using BTL_DotNet_2022.FrmMaster;
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

namespace BTL_DotNet_2022.FrmCustomer
{
    public partial class CartFrm : Form
    {
        private Orders orders;
        private User userLogin;
        private ListView lsv;

        public CartFrm(Orders orders, User userLogin)
        {
            InitializeComponent();
            this.orders = orders;
            this.userLogin = userLogin;
            pnlHeaderTable.Height = 40;
            pnlContent.Height = 550;
            
        }

        private void CartFrm_Load(object sender, EventArgs e)
        {
            this.resetPanle();

            // Show header table
            this.showHeaderTable();

            // Show book has buy
            this.showOrders();

            // Show total price 
            this.showTotalPrice();

            // Btn order
            if (orders.getTotalPrice() > 0) btnOrder.Show();
            else btnOrder.Hide();
        }

        public void resetPanle()
        {
            pnlHeaderTable.Controls.Clear();
            pnlContent.Controls.Clear();
            foreach(Control item in pnlBottom.Controls)
            {
                if(item is Label)
                {
                    pnlBottom.Controls.Remove(item);
                }
            }
        }


        public void showOrders()
        {
            int stt = 1;
            foreach(OrdersDetail item in this.orders.getOrdersDetailList())
            {
                Book bookNow = item.getBook();

                FlowLayoutPanel pnlParent = new FlowLayoutPanel()
                {
                    Width = pnlContent.Width,
                    Height = 250,
                    BorderStyle = BorderStyle.FixedSingle
                };
                pnlContent.Controls.Add(pnlParent);


                // Add STT
                Panel temp = new Panel()
                {
                    Height = pnlParent.Height,
                    Width = this.lsv.Columns[0].Width - 10
                };
                pnlParent.Controls.Add(temp);
                Label lbl = new Label()
                {
                    Text = stt++.ToString(),
                    Height = pnlParent.Height,
                    Width = this.lsv.Columns[0].Width,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                temp.Controls.Add(lbl);

                // Add image
                temp = new Panel()
                {
                    Height = pnlParent.Height,
                    Width = this.lsv.Columns[1].Width
                };
                pnlParent.Controls.Add(temp);
                PictureBox pbx = new PictureBox()
                {
                    Height = pnlParent.Height,
                    Width = this.lsv.Columns[1].Width,
                    Image = new Bitmap(bookNow.getBookImage()),
                    SizeMode = PictureBoxSizeMode.CenterImage
                };
                temp.Controls.Add(pbx);
                pbx.Click += (sender, e) =>
                {
                    BookDetailFrm bookDetailFrm = new BookDetailFrm(bookNow, "Detail");
                    bookDetailFrm.Show();
                };

                // Add name of book
                this.addLabelIntoPanel(pnlParent, bookNow.getBookName(), 2);

                // Add amount
                this.addLabelIntoPanel(pnlParent, item.getAmount().ToString(), 3);

                // Add book price
                this.addLabelIntoPanel(pnlParent, bookNow.getBookPrice().ToString(), 4);

                // Add total price 
                decimal totalPrice = bookNow.getBookPrice() * item.getAmount();
                this.addLabelIntoPanel(pnlParent, totalPrice.ToString(), 5);

                // Add btn delete
                Button btnDelte = new Button()
                {
                    Text = "Delete book",
                    BackColor = Color.Red,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Top,
                    Height = pnlParent.Height,
                    ForeColor = Color.White
                };
                pnlParent.Controls.Add(btnDelte);
                btnDelte.Click += (sender, e) =>
                {
                    DialogResult rs = MessageBox.Show
                    (
                        "Are you sure want to delete this book?",
                        "Delete book",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (rs == DialogResult.Yes)
                    {
                        // Remove orders detail has click delete button
                        this.orders.removeOrdersDetail(item);

                        // Refresh
                        MainCustomer main = (MainCustomer)this.MdiParent;
                        this.Close();
                        this.Dispose();
                        main.addMdiChild(new CartFrm(this.orders, this.userLogin));
                    }
                };

            }

        }

        public void addLabelIntoPanel(Panel pnl, string text, int col)
        {
            Panel temp = new Panel()
            {
                Height = pnl.Height,
                Width = this.lsv.Columns[col].Width
            };
            pnl.Controls.Add(temp);
            Label lbl = new Label()
            {
                Height = pnl.Height,
                Width = this.lsv.Columns[col].Width,
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
            temp.Controls.Add(lbl);
        }
        public void showHeaderTable()
        {
            ListView lsv = new ListView()
            {
                Height = 50,
                View = View.Details,
                Dock = DockStyle.Fill,
                Font = new Font(FontFamily.GenericSerif , 15, FontStyle.Bold)
            };

            lsv.Columns.Add(new ColumnHeader()); //STT
            lsv.Columns.Add(new ColumnHeader()); //Image
            lsv.Columns.Add(new ColumnHeader()); //Name
            lsv.Columns.Add(new ColumnHeader()); //Amount
            lsv.Columns.Add(new ColumnHeader()); //Price
            lsv.Columns.Add(new ColumnHeader()); //Total price
            lsv.Columns.Add(new ColumnHeader()); //Remove btn

            lsv.Columns[0].Width = 100;
            lsv.Columns[1].Width = 200;
            lsv.Columns[2].Width = 355;
            lsv.Columns[3].Width = 200;
            lsv.Columns[4].Width = 200;
            lsv.Columns[5].Width = 300;
            lsv.Columns[6].Width = 200;

            lsv.Columns[0].Text = "STT";
            lsv.Columns[1].Text = "Image";
            lsv.Columns[2].Text = "Name";
            lsv.Columns[3].Text = "Amount";
            lsv.Columns[4].Text = "Price";
            lsv.Columns[5].Text = "Total price";
            lsv.Columns[6].Text = "...";

            foreach (ColumnHeader col in lsv.Columns)
            {
                col.TextAlign = HorizontalAlignment.Center;
            }

            // Don't allow user change width of column
            lsv.ColumnWidthChanging += (sender, e) =>
            {
                e.NewWidth = lsv.Columns[e.ColumnIndex].Width;
                e.Cancel = true;
            };

            pnlHeaderTable.Controls.Add(lsv);
            this.lsv = lsv;
        }

        public void showTotalPrice()
        {
            Label lbl = new Label()
            {
                Width = this.lsv.Columns[5].Width+100,
                Dock = DockStyle.Right,
                Text = "=> Total price: " + this.orders.getTotalPrice(),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold)
            };
            pnlBottom.Controls.Add(lbl);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //Show message
            MessageBox.Show("Thank you for your purchase!\n ( Look your order in - History - )!");

            // Add order into db
            DB.addOrders(this.userLogin.getUsername(), orders);

            // Refresh cart
            this.orders.resetOrders(); // Clear all element ( orders detail )

            // Load cart frm
            this.CartFrm_Load(sender, e);
        }
    }
}

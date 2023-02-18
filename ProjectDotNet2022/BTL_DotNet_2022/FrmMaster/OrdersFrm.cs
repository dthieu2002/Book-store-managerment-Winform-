using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_DotNet_2022.FrmCustomer;
using BTL_DotNet_2022.Models;
using System.Data.SqlClient;
using System.CodeDom;
using System.Collections;

// Library use to work with excel
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Web;
//using System.Runtime.InteropServices;

namespace BTL_DotNet_2022.FrmMaster
{
    public partial class OrdersFrm : Form
    {
        private const int Width01 = 875;//Const
        private User userLogin;


        public OrdersFrm(User userLogin, string query="")
        {
            InitializeComponent();
            pnlLeft.Width = 1000;
            pnlOrdersDetail.Height = 500;
            pnlOrdersDetail.Width = Width01;

            this.userLogin = userLogin;
            dgvOrders.Height = 400;
            dgvOrders.Width = 1000;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;

            // Fill data for data grid view
            if (string.IsNullOrEmpty(query))
            {
                dgvOrders.DataSource = DB.getDataTable("tblOrders");
            }
            else
            {
                // Set header label
                lblHeader.Text = "Purchase history: ";

                // Fill Data into table with clause
                dgvOrders.DataSource = DB.getDataTableWithClause(query);

                // Hide some controls 
                cbxUsername.Hide();
                txtUsernameFilter.Hide();
                txtUsername.Hide();
                lblUsername.Hide();

                // Set width
                pnlLeft.Width = 700;
                dgvOrders.Width = 700;

                // Set height
                pnlOrdersDetail.Height = 400;

                btnDonotAccept.Text = "Delete order";

            }
            
            dgvOrders.Refresh();

            dtpOrdersDate.Format = DateTimePickerFormat.Short;
        }

        private void OrderFrm_Load(object sender, EventArgs e)
        {
            
            dgvOrders.ClearSelection();
            dgvOrders.CurrentCell = null;

            // Set all detail text is read only
            this.setReadOnlyAllTextBox(true);
            this.resetTextBox();
            pnlOrdersDetail.Controls.Clear();

            // Hide btn accept and btn donotAccept, btn print
            btnAccept.Hide();
            btnDonotAccept.Hide();
            btnPrintOrders.Hide();

            // Hide lbl processing
            lblProcessing.Hide();
        }

        private void cbxUsername_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUsername.Checked)
            {
                cbxUsername.ForeColor = Color.Green;
            }
            else
            {
                cbxUsername.ForeColor = Color.Black;
            }
        }

        private void cbxOrdersDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxOrdersDate.Checked)
            {
                cbxOrdersDate.ForeColor = Color.Green;
            }
            else
            {
                cbxOrdersDate.ForeColor = Color.Black;
            }
        }



        //=======
        private void setReadOnlyAllTextBox(bool readOnly) 
        {
            txtOrdersId.ReadOnly = readOnly;
            txtUsername.ReadOnly = readOnly;
            txtOrdersDate.ReadOnly = readOnly;
        }

        private void resetTextBox()
        {
            txtOrdersId.Text = String.Empty;
            txtUsername.Text = String.Empty;
            txtOrdersDate.Text = String.Empty;
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvOrders.SelectedRows.Count > 0 && dgvOrders.CurrentRow != null)
            {
                // Step 1: Set txtOrdersId
                txtOrdersId.Text = dgvOrders.CurrentRow.Cells[0].Value.ToString();

                // Step 2: Set txtUsername and ...
                if (!this.userLogin.getRole().Equals("customer")) // is "master" or "staff"
                {
                    txtUsername.Text = dgvOrders.CurrentRow.Cells[1].Value.ToString();
                    txtOrdersDate.Text = dgvOrders.CurrentRow.Cells[2].Value.ToString();
                }
                else
                {
                    txtOrdersDate.Text = dgvOrders.CurrentRow.Cells[1].Value.ToString();
                }

                // Step 3 : Check if the orders has processing?
                this.renderProcessingLabel();

                // Step 4: Render order
                renderOrders(Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value));

                // Step 5: Active button (accept, don't accept ) if the status orders of current row is 'waiting'
                // Show button
                if (!this.userLogin.getRole().Equals("customer"))
                {
                    if (dgvOrders.CurrentRow.Cells[3].Value.ToString().Equals("waiting"))
                    {
                        btnAccept.Show();
                        btnDonotAccept.Show();
                        
                        btnPrintOrders.Hide();
                    }
                    else
                    {
                        btnAccept.Hide();
                        btnDonotAccept.Hide();

                        if (dgvOrders.CurrentRow.Cells[3].Value.ToString().Equals("accept"))
                        {
                            btnPrintOrders.Show();
                        } 
                        else btnPrintOrders.Hide();
                    }
                }
                else
                {
                    if (dgvOrders.CurrentRow.Cells[2].Value.ToString().Equals("waiting"))
                    {
                        btnDonotAccept.Show();
                       
                    }
                    else btnDonotAccept.Hide();
                }
            }
            else
            {
                this.resetTextBox();
                pnlOrdersDetail.Controls.Clear();
                btnAccept.Hide();
                btnDonotAccept.Hide();
                btnPrintOrders.Hide();
                lblProcessing.Hide();
            }
        }


        private void renderProcessingLabel()
        {
            int ordersId = (int)dgvOrders.CurrentRow.Cells[0].Value;
            
            string username= "";
            if (this.userLogin.getRole().Equals("customer"))
            {
                username = this.userLogin.getUsername();
            }
            else
            {
                username = dgvOrders.CurrentRow.Cells[1].Value.ToString();
            }

            string ordersStatus = "";
            if (this.userLogin.getRole().Equals("customer"))
            {
                // Because when render tblOrders with user , we not display Username column
                // then ordersStatus column have index = 2 ( first column is 0)
                ordersStatus = dgvOrders.CurrentRow.Cells[2].Value.ToString();
            }
            else ordersStatus = dgvOrders.CurrentRow.Cells[3].Value.ToString();

            if (!ordersStatus.Equals("waiting")) // orders has been processed
            {
                lblProcessing.Show();

                DB.connection();
                string query = "Select * From tblProcessing_Orders " +
                               "Where OrdersId = " + ordersId.ToString();

                SqlCommand cmd = new SqlCommand(query, DB.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    reader.Read();
                    String processingDate = reader.GetDateTime(1).ToString();
                    username = reader.GetString(2);

                    
                    // Set label text
                    lblProcessing.Text = "Processing: "+ordersStatus + " by " + username +
                                         "\n            In : " + processingDate;
                    
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    DB.disconnection();
                    reader.Close();
                }

            }
            else lblProcessing.Hide();
        }
        private void renderOrders(int ordersId) // Render all book of orders
        {
            pnlOrdersDetail.Controls.Clear();

            Orders orders = DB.getOrders(ordersId);
            List<OrdersDetail> ordersDetailList = orders.getOrdersDetailList();

            ListView lsv = new ListView();
            pnlOrdersDetail.Controls.Add(lsv);
            lsv.Font = new Font(FontFamily.GenericSansSerif, 10,FontStyle.Regular );
            lsv.View = View.Details;
            lsv.Height = 50;
            lsv.Width = Width01;

            lsv.Columns.Add(new ColumnHeader("STT"));
            lsv.Columns.Add(new ColumnHeader("Image"));
            lsv.Columns.Add(new ColumnHeader("Name"));
            lsv.Columns.Add(new ColumnHeader("Amount"));
            lsv.Columns.Add(new ColumnHeader("TotalPrice"));

            lsv.Columns[0].Text = "STT";
            lsv.Columns[1].Text = "Image";
            lsv.Columns[2].Text = "Name";
            lsv.Columns[3].Text = "Amount";
            lsv.Columns[4].Text = "Total Price";

            lsv.Columns[0].Width = 70;
            lsv.Columns[1].Width = 200;
            lsv.Columns[2].Width = 325;
            lsv.Columns[3].Width = 130;
            lsv.Columns[4].Width = 140;

            lsv.Columns[0].TextAlign = HorizontalAlignment.Center;
            lsv.Columns[1].TextAlign = HorizontalAlignment.Center;
            lsv.Columns[2].TextAlign = HorizontalAlignment.Center;
            lsv.Columns[3].TextAlign = HorizontalAlignment.Center;
            lsv.Columns[4].TextAlign = HorizontalAlignment.Center;

            int stt = 1;
            foreach (OrdersDetail item in ordersDetailList)
            {
                Panel pnlParent = new Panel();
                pnlParent.BorderStyle = BorderStyle.Fixed3D;
                pnlOrdersDetail.Controls.Add(pnlParent);
                pnlParent.Height = 200;
                pnlParent.Width = Width01;

                // Pnl stt
                Panel pnlSTT = new Panel();
                pnlParent.Controls.Add(pnlSTT);
                pnlSTT.Width = 70;
                pnlSTT.Height = 200;
                pnlSTT.Dock = DockStyle.Right;//
                Label lbl = this.getCenterLabel(stt++.ToString());
                pnlSTT.Controls.Add(lbl);
                lbl.AutoSize = false;
                lbl.Width = 70;
                lbl.Height = 200;
                //lbl.Dock = DockStyle.Fill;

                // Pnl Image
                Panel pnlImage = new Panel();
                pnlParent.Controls.Add(pnlImage);
                pnlImage.Height = 200;
                pnlImage.Width = 200;
                pnlImage.Dock = DockStyle.Right;//

                PictureBox pbx = new PictureBox();
                pnlImage.Controls.Add(pbx);
                pbx.Image = new Bitmap(item.getBook().getBookImage());
                pbx.SizeMode = PictureBoxSizeMode.Zoom;
                pbx.Height = 200;
                pbx.Width = 200;
                pbx.Click += (sender, args) =>
                {
                    BookDetailFrm bookDetailFrm = new BookDetailFrm(item.getBook(), "Detail");
                    // Set status if not is customer
                    if (!this.userLogin.getRole().Equals("customer"))
                    {
                        MainMaster mainMaster = (MainMaster)this.MdiParent;
                        mainMaster.setToolStripStatusLable("Detail mode:");
                        bookDetailFrm.setMainMaster(mainMaster);
                    }
                    bookDetailFrm.ShowDialog();

                };

                // Pnl name
                Panel pnlName = new Panel();
                pnlName.Height = 200;
                pnlName.Width = 325;
                pnlParent.Controls.Add(pnlName);
                pnlName.Dock = DockStyle.Right;//
                Label lbl2 = this.getCenterLabel(item.getBook().getBookName());
                pnlName.Controls.Add(lbl2);
                lbl2.AutoSize = false;
                lbl2.Width = 325;
                lbl2.Height = 200;

                // Pnl amount
                Panel pnlAmount = new Panel();
                pnlAmount.Height = 200;
                pnlAmount.Width = 130;
                pnlParent.Controls.Add(pnlAmount);
                pnlAmount.Dock = DockStyle.Right;//
                Label lbl3 = this.getCenterLabel(item.getAmount().ToString());
                pnlAmount.Controls.Add(lbl3);
                lbl3.AutoSize = false;
                lbl3.Width = 130;
                lbl3.Height = 200;

                // PnlTotalPrice
                Panel pnlTotalPrice = new Panel();
                pnlTotalPrice.Height = 200;
                pnlTotalPrice.Width = 145;
                pnlParent.Controls.Add(pnlTotalPrice);
                pnlTotalPrice.Dock = DockStyle.Right;//

                decimal sum = item.getBook().getBookPrice() * item.getAmount();
                Label lbl4 = this.getCenterLabel(sum.ToString());
                pnlTotalPrice.Controls.Add(lbl4);
                lbl4.AutoSize = false;
                lbl4.Width = 145;
                lbl4.Height = 200;
            }

            Panel pnlTotal = new Panel();
            pnlTotal.Height = 200;
            pnlTotal.Width = Width01;
            pnlOrdersDetail.Controls.Add(pnlTotal);
            Label lblTotal = new Label()
            {
                AutoSize = false,
                Text = "=> Total price: "+orders.getTotalPrice().ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 200,
                Width = 275,
                Dock = DockStyle.Right
            };
            pnlTotal.Controls.Add(lblTotal);
        }

        public Label getCenterLabel(string text)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            //lbl.Dock = DockStyle.Fill;
            return lbl;
        }

        private void btnDonotAccept_Click(object sender, EventArgs e)
        {
            if (!this.userLogin.getRole().Equals("customer")) // View of master or staff
            {
                DB.changeOrdersStatus(
                    (int)dgvOrders.CurrentRow.Cells[0].Value,
                    "donot accept"
                );

                // Insert one record into tblProcessing_Orders to save processing date
                this.addProcessing_Orders();

                // Load form
                MainMaster mainMaster = (MainMaster)this.MdiParent;
                this.Close();
                mainMaster.orderToolStripMenuItem_Click(sender, e);
            }
            else // View of customer
            {
                DialogResult rs = MessageBox.Show("Are you sure want to delete order? ",
                                "Delete order",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                if(rs == DialogResult.Yes)
                {
                    DB.changeOrdersStatus
                    (
                        (int)dgvOrders.CurrentRow.Cells[0].Value,
                        "deleted"
                    );

                    // Insert one record into tblProcessing_Orders to save processing date
                    this.addProcessing_Orders();

                    // Load form
                    MainCustomer main = (MainCustomer)this.MdiParent;
                    this.Close();
                    main.btnHistory_Click(sender, e);
                }
                
            }

            
        }

        public void addProcessing_Orders()
        {
            if(dgvOrders.CurrentRow != null)
            {
                DB.addProcessing_Orders(
                        (int)dgvOrders.CurrentRow.Cells[0].Value,
                        this.userLogin.getUsername()
                );
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //=== Only 'master' and 'staff' can see, click this button ===

            // Fistly: Get the current orders in data grid view
            Orders currentOrders = DB.getOrders((int)dgvOrders.CurrentRow.Cells[0].Value);

            // Step 1: Check amount buy of user with inventory quantity
            string error = String.Empty;
            int count = 1;
            foreach(OrdersDetail item in currentOrders.getOrdersDetailList())
            {
                if (item.getAmount() > item.getBook().getInventoryQuantity())
                {
                    int missingAmount = item.getAmount() - item.getBook().getInventoryQuantity();
                    error += "Error " + count++.ToString() + ": " + item.getBook().getBookName() +
                             "\n\tOrder: " + item.getAmount().ToString() +
                             "\n\tInventory quantity: " + item.getBook().getInventoryQuantity().ToString()+" book"+
                             "\n\tAmount of book missing: "+missingAmount.ToString()+"\n\n";
                }
            }

            if(!string.IsNullOrEmpty(error)) // Accept fail
            {
                MessageBox.Show(error,
                                "Not enough books to sell",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else // Accept successful  : Need completed
            {
                BookMng bookMng = new BookMng();

                // Update inventory quantity of book has sell
                foreach(OrdersDetail item in currentOrders.getOrdersDetailList())
                {
                    int newInventoryQuantity = item.getBook().getInventoryQuantity() - item.getAmount();
                    item.getBook().setInventoryQuantity(newInventoryQuantity);

                    // Update in database
                    bookMng.editBook(item.getBook());
                }
                
                // Change orders status of current orders has selected
                DB.changeOrdersStatus
                    (
                        (int)dgvOrders.CurrentRow.Cells[0].Value,
                        "accept"
                    );

                // Insert one record into tblProcessing_Orders to save processing date
                this.addProcessing_Orders();

                // Load form ( master frm )
                MainMaster main = (MainMaster)this.MdiParent;
                this.Close();
                main.orderToolStripMenuItem_Click(sender, e);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string query = "Select * From tblOrders ";
            bool usernameClause = false;

            if (this.userLogin.getRole().Equals("customer")) // Case if is view of customer ( not display username col, 
                // and only display orders of user has login 
            {
                query = "Select OrdersId, OrdersDate, OrdersStatus From tblOrders "+
                        "Where Username = '"+this.userLogin.getUsername()+"' And OrdersStatus!='deleted' ";
                usernameClause = true;
            }
            else if (cbxUsername.Checked)
            {
                if (!string.IsNullOrEmpty(txtUsernameFilter.Text.Trim()))
                {
                    query += "Where Username like '%" + txtUsernameFilter.Text + "%' ";
                    usernameClause = true;
                }
            }

            if (cbxOrdersDate.Checked)
            {
                if (usernameClause)
                {
                    query += "And CAST(OrdersDate as date) = '" + dtpOrdersDate.Text + "'";
                }
                else
                {
                    query += "Where CAST(OrdersDate as date) = '" + dtpOrdersDate.Text + "'";
                }
            }

            dgvOrders.DataSource = DB.getDataTableWithClause(query);
            dgvOrders.ClearSelection();
            dgvOrders.CurrentCell = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbxUsername.Checked = false;
            txtUsernameFilter.Text = String.Empty;

            cbxOrdersDate.Checked = false;
            dtpOrdersDate.Value = DateTime.Now;

            // Get all record in table tblOrders
            if (this.userLogin.getRole().Equals("customer"))
            {
                string query = "Select OrdersId, OrdersDate, OrdersStatus From tblOrders " +
                               "Where Username = '" + this.userLogin.getUsername() + "' And OrdersStatus != 'deleted'";
                dgvOrders.DataSource = DB.getDataTableWithClause(query);
            }
            else
            {
                dgvOrders.DataSource = DB.getDataTable("tblOrders");
            }

            dgvOrders.ClearSelection();
            dgvOrders.CurrentCell = null;
        }

        private void btnPrintOrders_Click(object sender, EventArgs e)
        {
            // Step 1: Create some object to work with excel
            Excel.Application app;
            Excel._Workbook wb;
            Excel._Worksheet ws;
            Excel.Range range;

            try
            {
                app = new Excel.Application();
                app.Visible = true;

                wb = app.Workbooks.Add(Missing.Value);
                ws = (Excel._Worksheet)app.ActiveSheet;

                

                //=== Set header ===
                range = ws.get_Range("B2", "M2");
                range.Merge();

                range.Font.Bold = true;
                range.Font.Size = 20;
                range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                ws.Cells[2, 2] = "... Book Store of ThuanHieu ...";
                range.EntireColumn.AutoFit();
                range.Font.Color = Color.White;
                range.Interior.Color = Color.Green;
                range.RowHeight = 60;
                
                // === Address text
                range = ws.get_Range("E3", "J3");
                range.Merge();
                range.RowHeight = 20;
                range.Font.Bold = true;
                range.Font.Size = 10;
                range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                ws.Cells[3, 5] = "Address: Trâu Quỳ - Học viện NNVN";

                // Get some data from tbl_processing
                string sellerName;
                string? ordersId = dgvOrders.CurrentRow.Cells[0].Value.ToString();
                string processingDate;
                DB.connection();

                string query = "Select * From tblProcessing_Orders Where OrdersId = " + ordersId;
                SqlCommand cmd = new SqlCommand(query, DB.conn);
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                sellerName = reader.GetString(2);
                processingDate = reader.GetDateTime(1).ToString();
                reader.Close();
                

                // === Seller : 
                range = ws.get_Range("B4", "E4");
                range.Merge();
                ws.Cells[4, 2] = "Seller: "+sellerName;

                // === Seller : 
                range = ws.get_Range("B5", "E5");
                range.Merge();
                ws.Cells[5, 2] = "Time: "+processingDate;

                // === Customer name : 
                string? username = dgvOrders.CurrentRow.Cells[1].Value.ToString();
                query = "Select * From tblUser Where Username='"+username+"'";
                cmd = new SqlCommand(query, DB.conn);
                reader = cmd.ExecuteReader();
                reader.Read();
                string fullname = reader.GetString(2); // Fullname of customer
                reader.Close();

                range = ws.get_Range("B7", "E7");
                range.Merge();
                ws.Cells[7, 2] = "Customer name: "+fullname;

                //====== Set table orders detail ======
                ws.Cells[9, 3] = "STT";

                range = ws.get_Range("D9", "H9");
                range.Merge();
                ws.Cells[9, 4] = "Book name";

                ws.Cells[9, 9] = "Amount";

                ws.Cells[9, 10] = "Price";
                
                range = ws.get_Range("K9", "L9");
                range.Merge();
                ws.Cells[9, 11] = "Total";

                DB.disconnection();

                int x = 10; // Row will next add detail of order ( 1 book 1 row )
                // Get all book in orders and show
                Orders orders = DB.getOrders((int)dgvOrders.CurrentRow.Cells[0].Value);
                List<OrdersDetail> ordersDetail = orders.getOrdersDetailList();
                
                foreach(OrdersDetail detail in ordersDetail)
                {
                    Book item = detail.getBook();

                    //====== Set table orders detail ======
                    ws.Cells[x, 3] = x-9; // 1: STT

                    range = ws.get_Range("D"+x.ToString(), "H" + x.ToString());
                    range.Merge();
                    ws.Cells[x, 4] = item.getBookName(); // 2: Book name

                    ws.Cells[x, 9] = detail.getAmount().ToString(); // 3: Amount ( of orders detail ) 

                    ws.Cells[x, 10] = item.getBookPrice().ToString(); // 4: Price of book

                    range = ws.get_Range("K" + x.ToString(), "L" + x.ToString());
                    range.Merge();
                    ws.Cells[x, 11] = Convert.ToString(item.getBookPrice() * detail.getAmount());  // 5: Total of one row
                    range.RowHeight = 20;
                    

                    // Increase x
                    x++;
                }

                range = ws.get_Range("K" + x.ToString(), "L" + x.ToString());
                range.Merge();

                // Total price of orders
                ws.Cells[x + 1, 10] = "Total:";

                ws.Cells[x + 1, 11] = orders.getTotalPrice().ToString();
                range = ws.get_Range("K" + (x + 1).ToString(), "L" + (x + 1).ToString());
                range.Merge();
                range.Font.Bold = true;

                range = ws.get_Range("B9", "L30");
                range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                // Format column ( set border for column )
                range = ws.get_Range("C9", "L9");
                range.Font.Bold = true;
                range.RowHeight = 25;
                this.setBorderAround(range);

                range = ws.get_Range("C9", "C" + (x - 1).ToString());
                this.setBorderAround(range);
                range = ws.get_Range("D9", "H" + (x - 1).ToString());
                this.setBorderAround(range);
                range = ws.get_Range("I9", "I" + (x - 1).ToString());
                this.setBorderAround(range);
                range = ws.get_Range("J9", "J" + (x - 1).ToString());
                this.setBorderAround(range);
                range = ws.get_Range("K9", "L" + (x - 1).ToString());
                this.setBorderAround(range);


                //=== Set thankiu customer ===
                range = ws.get_Range("C"+(x+4).ToString(), "L" + (x + 4).ToString());
                range.Merge();
                range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                ws.Cells[x + 4, 3] = "--- Thankiu for support we - Have you a good day! ---";

                //=== Set border of bill ===
                range = ws.get_Range("B2", "M"+(x+5).ToString());
                this.setBorderAround(range);
                /*
                // set header 
                ws.Cells[1, 1] = "Last name";
                ws.Cells[1, 2] = "Middle name";
                ws.Cells[1, 3] = "First name";
                ws.Cells[1, 4] = "Full name";
                ws.Cells[1, 5] = "Salary";

                // set A1:E1 font = bold and text align = center
                range = ws.get_Range("A1", "E1");
                range.Font.Bold = true;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;

                // initialize array contain data
                string[,] arr = new string[3, 3];
                arr[0, 0] = "Dam"; arr[0, 1] = "Thuan"; arr[0, 2] = "Hieu";
                arr[1, 0] = "Vu"; arr[1, 1] = "Thu"; arr[1, 2] = "Thao";
                arr[2, 0] = "Nguyen"; arr[2, 1] = "Tien"; arr[2, 2] = "Dat";

                // fill A2:C4
                ws.get_Range("A2", "C4").Value2 = arr;

                // fill D2:D4 with formula =A2 & " " & B2 & " " & C2
                ws.get_Range("D2", "D4").Formula = "=A2 & \" \" & B2 & \" \" & C2";

                // fill E2:E4 with formula = RAND * 100000
                range = ws.get_Range("E2", "E4");
                range.Formula = "=RAND() * 100000";
                range.NumberFormat = "$0.00";


                range = ws.get_Range("A1", "E4");
                range.EntireColumn.AutoFit();
                */
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {
            }

        }
     
        
        private void setBorderAround(Excel.Range range)
        {
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;

            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;

            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Color = Color.Black;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
        }
    }
}

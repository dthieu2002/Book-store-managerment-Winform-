namespace BTL_DotNet_2022.FrmMaster
{
    partial class OrdersFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.cbxOrdersDate = new System.Windows.Forms.CheckBox();
            this.cbxUsername = new System.Windows.Forms.CheckBox();
            this.dtpOrdersDate = new System.Windows.Forms.DateTimePicker();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsernameFilter = new System.Windows.Forms.TextBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrintOrders = new System.Windows.Forms.Button();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.btnDonotAccept = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.pnlOrdersDetail = new System.Windows.Forms.FlowLayoutPanel();
            this.txtOrdersDate = new System.Windows.Forms.TextBox();
            this.lblOrdersDate = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtOrdersId = new System.Windows.Forms.TextBox();
            this.lblOrdersId = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1559, 85);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.Black;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.Color.Gold;
            this.lblHeader.Location = new System.Drawing.Point(12, 13);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(5);
            this.lblHeader.Size = new System.Drawing.Size(398, 58);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Orders managerment:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.cbxOrdersDate);
            this.pnlLeft.Controls.Add(this.cbxUsername);
            this.pnlLeft.Controls.Add(this.dtpOrdersDate);
            this.pnlLeft.Controls.Add(this.btnReset);
            this.pnlLeft.Controls.Add(this.btnFilter);
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Controls.Add(this.txtUsernameFilter);
            this.pnlLeft.Controls.Add(this.dgvOrders);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 85);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(664, 478);
            this.pnlLeft.TabIndex = 1;
            // 
            // cbxOrdersDate
            // 
            this.cbxOrdersDate.AutoSize = true;
            this.cbxOrdersDate.Location = new System.Drawing.Point(32, 110);
            this.cbxOrdersDate.Name = "cbxOrdersDate";
            this.cbxOrdersDate.Size = new System.Drawing.Size(136, 29);
            this.cbxOrdersDate.TabIndex = 4;
            this.cbxOrdersDate.Text = "Orders date:";
            this.cbxOrdersDate.UseVisualStyleBackColor = true;
            this.cbxOrdersDate.CheckedChanged += new System.EventHandler(this.cbxOrdersDate_CheckedChanged);
            // 
            // cbxUsername
            // 
            this.cbxUsername.AutoSize = true;
            this.cbxUsername.Location = new System.Drawing.Point(32, 63);
            this.cbxUsername.Name = "cbxUsername";
            this.cbxUsername.Size = new System.Drawing.Size(121, 29);
            this.cbxUsername.TabIndex = 1;
            this.cbxUsername.Text = "Username:";
            this.cbxUsername.UseVisualStyleBackColor = true;
            this.cbxUsername.CheckedChanged += new System.EventHandler(this.cbxUsername_CheckedChanged);
            // 
            // dtpOrdersDate
            // 
            this.dtpOrdersDate.Location = new System.Drawing.Point(194, 110);
            this.dtpOrdersDate.Name = "dtpOrdersDate";
            this.dtpOrdersDate.Size = new System.Drawing.Size(320, 31);
            this.dtpOrdersDate.TabIndex = 5;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(540, 110);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 34);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(540, 63);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(112, 34);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filter:";
            // 
            // txtUsernameFilter
            // 
            this.txtUsernameFilter.Location = new System.Drawing.Point(194, 63);
            this.txtUsernameFilter.Name = "txtUsernameFilter";
            this.txtUsernameFilter.Size = new System.Drawing.Size(320, 31);
            this.txtUsernameFilter.TabIndex = 2;
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(0, 197);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.RowTemplate.Height = 33;
            this.dgvOrders.Size = new System.Drawing.Size(685, 207);
            this.dgvOrders.TabIndex = 7;
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.groupBox1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(664, 85);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(895, 478);
            this.pnlRight.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.btnPrintOrders);
            this.groupBox1.Controls.Add(this.lblProcessing);
            this.groupBox1.Controls.Add(this.btnDonotAccept);
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Controls.Add(this.pnlOrdersDetail);
            this.groupBox1.Controls.Add(this.txtOrdersDate);
            this.groupBox1.Controls.Add(this.lblOrdersDate);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Controls.Add(this.txtOrdersId);
            this.groupBox1.Controls.Add(this.lblOrdersId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(895, 478);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orders Detail:";
            // 
            // btnPrintOrders
            // 
            this.btnPrintOrders.Image = global::BTL_DotNet_2022.Properties.Resources.icons8_send_to_printer_64;
            this.btnPrintOrders.Location = new System.Drawing.Point(492, 0);
            this.btnPrintOrders.Name = "btnPrintOrders";
            this.btnPrintOrders.Size = new System.Drawing.Size(64, 64);
            this.btnPrintOrders.TabIndex = 8;
            this.btnPrintOrders.UseVisualStyleBackColor = true;
            this.btnPrintOrders.Click += new System.EventHandler(this.btnPrintOrders_Click);
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProcessing.ForeColor = System.Drawing.Color.Purple;
            this.lblProcessing.Location = new System.Drawing.Point(63, 221);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(147, 32);
            this.lblProcessing.TabIndex = 9;
            this.lblProcessing.Text = "Processing...";
            // 
            // btnDonotAccept
            // 
            this.btnDonotAccept.Image = global::BTL_DotNet_2022.Properties.Resources.icons8_cancel_96;
            this.btnDonotAccept.Location = new System.Drawing.Point(589, 130);
            this.btnDonotAccept.Name = "btnDonotAccept";
            this.btnDonotAccept.Size = new System.Drawing.Size(294, 109);
            this.btnDonotAccept.TabIndex = 8;
            this.btnDonotAccept.Text = "Don\'t accept";
            this.btnDonotAccept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonotAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDonotAccept.UseVisualStyleBackColor = true;
            this.btnDonotAccept.Click += new System.EventHandler(this.btnDonotAccept_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Image = global::BTL_DotNet_2022.Properties.Resources.icons8_accept_96;
            this.btnAccept.Location = new System.Drawing.Point(589, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(294, 109);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // pnlOrdersDetail
            // 
            this.pnlOrdersDetail.AutoScroll = true;
            this.pnlOrdersDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOrdersDetail.Location = new System.Drawing.Point(3, 275);
            this.pnlOrdersDetail.Name = "pnlOrdersDetail";
            this.pnlOrdersDetail.Size = new System.Drawing.Size(889, 200);
            this.pnlOrdersDetail.TabIndex = 6;
            // 
            // txtOrdersDate
            // 
            this.txtOrdersDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOrdersDate.Location = new System.Drawing.Point(226, 165);
            this.txtOrdersDate.Name = "txtOrdersDate";
            this.txtOrdersDate.Size = new System.Drawing.Size(333, 37);
            this.txtOrdersDate.TabIndex = 5;
            // 
            // lblOrdersDate
            // 
            this.lblOrdersDate.AutoSize = true;
            this.lblOrdersDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrdersDate.ForeColor = System.Drawing.Color.Purple;
            this.lblOrdersDate.Location = new System.Drawing.Point(63, 168);
            this.lblOrdersDate.Name = "lblOrdersDate";
            this.lblOrdersDate.Size = new System.Drawing.Size(149, 32);
            this.lblOrdersDate.TabIndex = 4;
            this.lblOrdersDate.Text = "Orders date:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.Location = new System.Drawing.Point(226, 110);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(333, 37);
            this.txtUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.ForeColor = System.Drawing.Color.Purple;
            this.lblUsername.Location = new System.Drawing.Point(82, 113);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(130, 32);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // txtOrdersId
            // 
            this.txtOrdersId.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOrdersId.Location = new System.Drawing.Point(226, 59);
            this.txtOrdersId.Name = "txtOrdersId";
            this.txtOrdersId.Size = new System.Drawing.Size(333, 37);
            this.txtOrdersId.TabIndex = 1;
            // 
            // lblOrdersId
            // 
            this.lblOrdersId.AutoSize = true;
            this.lblOrdersId.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrdersId.ForeColor = System.Drawing.Color.Purple;
            this.lblOrdersId.Location = new System.Drawing.Point(92, 62);
            this.lblOrdersId.Name = "lblOrdersId";
            this.lblOrdersId.Size = new System.Drawing.Size(120, 32);
            this.lblOrdersId.TabIndex = 0;
            this.lblOrdersId.Text = "Orders id:";
            // 
            // OrdersFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1559, 563);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Name = "OrdersFrm";
            this.Text = "OrdersFrm";
            this.Load += new System.EventHandler(this.OrderFrm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlLeft;
        private Panel pnlRight;
        private Label lblHeader;
        private DataGridView dgvOrders;
        private TextBox txtUsernameFilter;
        private Label label2;
        private Button btnFilter;
        private Button btnReset;
        private DateTimePicker dtpOrdersDate;
        private CheckBox cbxOrdersDate;
        private CheckBox cbxUsername;
        private GroupBox groupBox1;
        private TextBox txtOrdersDate;
        private Label lblOrdersDate;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtOrdersId;
        private Label lblOrdersId;
        private FlowLayoutPanel pnlOrdersDetail;
        private Button btnAccept;
        private Button btnDonotAccept;
        private Label lblProcessing;
        private Button btnPrintOrders;
    }
}
namespace BTL_DotNet_2022.FrmCustomer
{
    partial class HomeCustomer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.rbnDescending = new System.Windows.Forms.RadioButton();
            this.btnFind = new System.Windows.Forms.Button();
            this.rbnAscending = new System.Windows.Forms.RadioButton();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbSort = new System.Windows.Forms.ComboBox();
            this.pnlContent = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1208, 150);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.rbnDescending);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.rbnAscending);
            this.groupBox1.Controls.Add(this.txtBookName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbSort);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1102, 150);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter and sort:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(33, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sort follow:";
            // 
            // btnReset
            // 
            this.btnReset.Image = global::BTL_DotNet_2022.Properties.Resources.icons8_reset_96;
            this.btnReset.Location = new System.Drawing.Point(966, 37);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 96);
            this.btnReset.TabIndex = 3;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rbnDescending
            // 
            this.rbnDescending.AutoSize = true;
            this.rbnDescending.Location = new System.Drawing.Point(673, 99);
            this.rbnDescending.Name = "rbnDescending";
            this.rbnDescending.Size = new System.Drawing.Size(130, 29);
            this.rbnDescending.TabIndex = 2;
            this.rbnDescending.TabStop = true;
            this.rbnDescending.Text = "Descending";
            this.rbnDescending.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Image = global::BTL_DotNet_2022.Properties.Resources.icons8_find_96;
            this.btnFind.Location = new System.Drawing.Point(824, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(96, 96);
            this.btnFind.TabIndex = 2;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // rbnAscending
            // 
            this.rbnAscending.AutoSize = true;
            this.rbnAscending.Checked = true;
            this.rbnAscending.Location = new System.Drawing.Point(532, 99);
            this.rbnAscending.Name = "rbnAscending";
            this.rbnAscending.Size = new System.Drawing.Size(120, 29);
            this.rbnAscending.TabIndex = 1;
            this.rbnAscending.TabStop = true;
            this.rbnAscending.Text = "Ascending";
            this.rbnAscending.UseVisualStyleBackColor = true;
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(156, 37);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(355, 31);
            this.txtBookName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book name:";
            // 
            // cbbSort
            // 
            this.cbbSort.FormattingEnabled = true;
            this.cbbSort.Items.AddRange(new object[] {
            "...",
            "Price"});
            this.cbbSort.Location = new System.Drawing.Point(156, 98);
            this.cbbSort.Name = "cbbSort";
            this.cbbSort.Size = new System.Drawing.Size(355, 33);
            this.cbbSort.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 150);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1208, 357);
            this.pnlContent.TabIndex = 1;
            // 
            // HomeCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 507);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Name = "HomeCustomer";
            this.Text = "HomeCustomer";
            this.Load += new System.EventHandler(this.HomeCustomer_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnFind;
        private TextBox txtBookName;
        private Label label1;
        private FlowLayoutPanel pnlContent;
        private Button btnReset;
        private GroupBox groupBox1;
        private ComboBox cbbSort;
        private RadioButton rbnDescending;
        private RadioButton rbnAscending;
        private Label label2;
    }
}
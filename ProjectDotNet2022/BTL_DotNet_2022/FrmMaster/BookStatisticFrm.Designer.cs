namespace BTL_DotNet_2022.FrmMaster
{
    partial class BookStatisticFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbxStatisticFollow = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDetailBook = new System.Windows.Forms.Label();
            this.pbxBookImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBookImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxStatisticFollow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1231, 158);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(147, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Statistic follow:";
            // 
            // cbxStatisticFollow
            // 
            this.cbxStatisticFollow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxStatisticFollow.FormattingEnabled = true;
            this.cbxStatisticFollow.Location = new System.Drawing.Point(325, 100);
            this.cbxStatisticFollow.Name = "cbxStatisticFollow";
            this.cbxStatisticFollow.Size = new System.Drawing.Size(581, 33);
            this.cbxStatisticFollow.TabIndex = 1;
            this.cbxStatisticFollow.SelectedIndexChanged += new System.EventHandler(this.cbxStatisticFollow_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(433, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "=== Book statistic ===";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBook);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(0, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 544);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data:";
            // 
            // dgvBook
            // 
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBook.Location = new System.Drawing.Point(3, 33);
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.RowHeadersWidth = 62;
            this.dgvBook.RowTemplate.Height = 33;
            this.dgvBook.Size = new System.Drawing.Size(994, 508);
            this.dgvBook.TabIndex = 0;
            this.dgvBook.SelectionChanged += new System.EventHandler(this.dgvBook_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDetailBook);
            this.groupBox2.Controls.Add(this.pbxBookImage);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.Green;
            this.groupBox2.Location = new System.Drawing.Point(1000, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 544);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail of book:";
            // 
            // lblDetailBook
            // 
            this.lblDetailBook.AutoSize = true;
            this.lblDetailBook.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDetailBook.ForeColor = System.Drawing.Color.Purple;
            this.lblDetailBook.Location = new System.Drawing.Point(15, 304);
            this.lblDetailBook.Name = "lblDetailBook";
            this.lblDetailBook.Size = new System.Drawing.Size(0, 30);
            this.lblDetailBook.TabIndex = 1;
            // 
            // pbxBookImage
            // 
            this.pbxBookImage.Location = new System.Drawing.Point(15, 27);
            this.pbxBookImage.Name = "pbxBookImage";
            this.pbxBookImage.Size = new System.Drawing.Size(200, 250);
            this.pbxBookImage.TabIndex = 0;
            this.pbxBookImage.TabStop = false;
            // 
            // BookStatisticFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 702);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "BookStatisticFrm";
            this.Text = "BookStatisticFrm";
            this.Load += new System.EventHandler(this.BookStatisticFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBookImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Label label1;
        private ComboBox cbxStatisticFollow;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private PictureBox pbxBookImage;
        private Label lblDetailBook;
        private DataGridView dgvBook;
    }
}
namespace BTL_DotNet_2022.FrmMaster
{
    partial class BookDetailFrm
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
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pbxBookImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBookId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInventoryQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrimary = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnChangeImage = new System.Windows.Forms.Button();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDeleteImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBookImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(50, 48);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "...";
            // 
            // pbxBookImage
            // 
            this.pbxBookImage.Location = new System.Drawing.Point(12, 82);
            this.pbxBookImage.Name = "pbxBookImage";
            this.pbxBookImage.Size = new System.Drawing.Size(275, 313);
            this.pbxBookImage.TabIndex = 1;
            this.pbxBookImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(518, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(625, 100);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(383, 31);
            this.txtName.TabIndex = 3;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(625, 164);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(383, 31);
            this.txtGenre.TabIndex = 5;
            this.txtGenre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGenre_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(518, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Genre:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(625, 228);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(383, 31);
            this.txtAuthor.TabIndex = 7;
            this.txtAuthor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAuthor_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Indigo;
            this.label4.Location = new System.Drawing.Point(509, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Author:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(625, 292);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(383, 31);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(527, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "Price:";
            // 
            // lblBookId
            // 
            this.lblBookId.AutoSize = true;
            this.lblBookId.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBookId.ForeColor = System.Drawing.Color.Indigo;
            this.lblBookId.Location = new System.Drawing.Point(505, 36);
            this.lblBookId.Name = "lblBookId";
            this.lblBookId.Size = new System.Drawing.Size(94, 30);
            this.lblBookId.TabIndex = 1;
            this.lblBookId.Text = "Book id:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Indigo;
            this.label7.Location = new System.Drawing.Point(456, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 28);
            this.label7.TabIndex = 10;
            this.label7.Text = "Release date :";
            // 
            // txtInventoryQuantity
            // 
            this.txtInventoryQuantity.Location = new System.Drawing.Point(625, 420);
            this.txtInventoryQuantity.Name = "txtInventoryQuantity";
            this.txtInventoryQuantity.Size = new System.Drawing.Size(383, 31);
            this.txtInventoryQuantity.TabIndex = 13;
            this.txtInventoryQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInventoryQuantity_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Indigo;
            this.label8.Location = new System.Drawing.Point(405, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 28);
            this.label8.TabIndex = 12;
            this.label8.Text = "Inventory quantity:";
            // 
            // btnPrimary
            // 
            this.btnPrimary.Location = new System.Drawing.Point(625, 491);
            this.btnPrimary.Name = "btnPrimary";
            this.btnPrimary.Size = new System.Drawing.Size(383, 44);
            this.btnPrimary.TabIndex = 14;
            this.btnPrimary.Text = "Btn was set in runcode";
            this.btnPrimary.UseVisualStyleBackColor = true;
            this.btnPrimary.Click += new System.EventHandler(this.btnPrimary_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1043, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 92);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(293, 82);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(145, 34);
            this.btnAddImage.TabIndex = 15;
            this.btnAddImage.Text = "Add image";
            this.btnAddImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnChangeImage
            // 
            this.btnChangeImage.Location = new System.Drawing.Point(293, 143);
            this.btnChangeImage.Name = "btnChangeImage";
            this.btnChangeImage.Size = new System.Drawing.Size(145, 34);
            this.btnChangeImage.TabIndex = 16;
            this.btnChangeImage.Text = "Change image";
            this.btnChangeImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeImage.UseVisualStyleBackColor = true;
            this.btnChangeImage.Click += new System.EventHandler(this.btnChangeImage_Click);
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(625, 356);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(383, 31);
            this.dtpReleaseDate.TabIndex = 11;
            this.dtpReleaseDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpReleaseDate_KeyDown);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Location = new System.Drawing.Point(293, 204);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(145, 34);
            this.btnDeleteImage.TabIndex = 18;
            this.btnDeleteImage.Text = "Delete image";
            this.btnDeleteImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // BookDetailFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 571);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.btnChangeImage);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrimary);
            this.Controls.Add(this.txtInventoryQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblBookId);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbxBookImage);
            this.Controls.Add(this.lblHeader);
            this.Name = "BookDetailFrm";
            this.Text = "BookDetailFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BookDetailFrm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBookImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblHeader;
        private PictureBox pbxBookImage;
        private Label label2;
        private TextBox txtName;
        private TextBox txtGenre;
        private Label label3;
        private TextBox txtAuthor;
        private Label label4;
        private TextBox txtPrice;
        private Label label5;
        private Label lblBookId;
        private Label label7;
        private TextBox txtInventoryQuantity;
        private Label label8;
        private Button btnPrimary;
        private Button btnExit;
        private Button btnAddImage;
        private Button btnChangeImage;
        private DateTimePicker dtpReleaseDate;
        private ErrorProvider errorProvider1;
        private Button btnDeleteImage;
    }
}
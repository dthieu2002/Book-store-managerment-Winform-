namespace BTL_DotNet_2022
{
    partial class AccountInfoFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEditAccountInfo = new System.Windows.Forms.Button();
            this.lstvAcountInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 117);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(93, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 117);
            this.label1.TabIndex = 0;
            this.label1.Text = "Infor of acount:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lstvAcountInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 538);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.btnEditAccountInfo);
            this.panel3.Location = new System.Drawing.Point(0, 370);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(617, 168);
            this.panel3.TabIndex = 2;
            // 
            // btnEditAccountInfo
            // 
            this.btnEditAccountInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditAccountInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnEditAccountInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditAccountInfo.ForeColor = System.Drawing.Color.White;
            this.btnEditAccountInfo.Location = new System.Drawing.Point(134, 36);
            this.btnEditAccountInfo.Name = "btnEditAccountInfo";
            this.btnEditAccountInfo.Size = new System.Drawing.Size(349, 96);
            this.btnEditAccountInfo.TabIndex = 0;
            this.btnEditAccountInfo.Text = "Edit account info";
            this.btnEditAccountInfo.UseVisualStyleBackColor = false;
            this.btnEditAccountInfo.Click += new System.EventHandler(this.btnEditAccountInfo_Click);
            // 
            // lstvAcountInfo
            // 
            this.lstvAcountInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstvAcountInfo.BackColor = System.Drawing.Color.White;
            this.lstvAcountInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstvAcountInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstvAcountInfo.ForeColor = System.Drawing.Color.Black;
            this.lstvAcountInfo.GridLines = true;
            this.lstvAcountInfo.Location = new System.Drawing.Point(0, 0);
            this.lstvAcountInfo.Name = "lstvAcountInfo";
            this.lstvAcountInfo.Size = new System.Drawing.Size(617, 370);
            this.lstvAcountInfo.TabIndex = 0;
            this.lstvAcountInfo.UseCompatibleStateImageBehavior = false;
            this.lstvAcountInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 212;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 400;
            // 
            // AccountInfoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 655);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AccountInfoFrm";
            this.Text = "AcountInfoForm";
            this.Load += new System.EventHandler(this.AccountInfoFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private ListView lstvAcountInfo;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Panel panel3;
        private Button btnEditAccountInfo;
    }
}
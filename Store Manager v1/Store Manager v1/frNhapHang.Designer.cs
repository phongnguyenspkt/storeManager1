namespace Store_Manager_v1
{
    partial class frNhapHang
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
            this.btnhuongdan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtmahd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.txtnam = new System.Windows.Forms.TextBox();
            this.txtthang = new System.Windows.Forms.TextBox();
            this.txtngay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdoitac = new System.Windows.Forms.TextBox();
            this.txtnhanvien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnhuongdan
            // 
            this.btnhuongdan.ForeColor = System.Drawing.Color.Crimson;
            this.btnhuongdan.Location = new System.Drawing.Point(23, 234);
            this.btnhuongdan.Name = "btnhuongdan";
            this.btnhuongdan.Size = new System.Drawing.Size(180, 24);
            this.btnhuongdan.TabIndex = 14;
            this.btnhuongdan.Text = "Đọc hướng dẫn";
            this.btnhuongdan.UseVisualStyleBackColor = true;
            this.btnhuongdan.Click += new System.EventHandler(this.btnhuongdan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.txtmahd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnhuy);
            this.groupBox1.Controls.Add(this.btnnext);
            this.groupBox1.Controls.Add(this.txtnam);
            this.groupBox1.Controls.Add(this.txtthang);
            this.groupBox1.Controls.Add(this.txtngay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtdoitac);
            this.groupBox1.Controls.Add(this.txtnhanvien);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.Cornsilk;
            this.groupBox1.Location = new System.Drawing.Point(55, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 206);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hoá đơn";
            // 
            // txtmahd
            // 
            this.txtmahd.Location = new System.Drawing.Point(143, 21);
            this.txtmahd.Name = "txtmahd";
            this.txtmahd.ReadOnly = true;
            this.txtmahd.Size = new System.Drawing.Size(214, 20);
            this.txtmahd.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mã hoá đơn";
            // 
            // btnhuy
            // 
            this.btnhuy.ForeColor = System.Drawing.Color.Crimson;
            this.btnhuy.Location = new System.Drawing.Point(113, 167);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(90, 33);
            this.btnhuy.TabIndex = 9;
            this.btnhuy.Text = "Huỷ";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnnext
            // 
            this.btnnext.ForeColor = System.Drawing.Color.Crimson;
            this.btnnext.Location = new System.Drawing.Point(323, 167);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(90, 33);
            this.btnnext.TabIndex = 8;
            this.btnnext.Text = "Tiếp tục";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // txtnam
            // 
            this.txtnam.Location = new System.Drawing.Point(335, 127);
            this.txtnam.Name = "txtnam";
            this.txtnam.Size = new System.Drawing.Size(61, 20);
            this.txtnam.TabIndex = 7;
            // 
            // txtthang
            // 
            this.txtthang.Location = new System.Drawing.Point(237, 124);
            this.txtthang.Name = "txtthang";
            this.txtthang.Size = new System.Drawing.Size(62, 20);
            this.txtthang.TabIndex = 6;
            // 
            // txtngay
            // 
            this.txtngay.Location = new System.Drawing.Point(143, 124);
            this.txtngay.Name = "txtngay";
            this.txtngay.Size = new System.Drawing.Size(60, 20);
            this.txtngay.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày tạo hoá đơn";
            // 
            // txtdoitac
            // 
            this.txtdoitac.Location = new System.Drawing.Point(143, 90);
            this.txtdoitac.Name = "txtdoitac";
            this.txtdoitac.Size = new System.Drawing.Size(214, 20);
            this.txtdoitac.TabIndex = 3;
            // 
            // txtnhanvien
            // 
            this.txtnhanvien.Location = new System.Drawing.Point(143, 53);
            this.txtnhanvien.Name = "txtnhanvien";
            this.txtnhanvien.ReadOnly = true;
            this.txtnhanvien.Size = new System.Drawing.Size(214, 20);
            this.txtnhanvien.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đối tác";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân Viên ";
            // 
            // frNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Store_Manager_v1.Properties.Resources.nendep;
            this.ClientSize = new System.Drawing.Size(538, 261);
            this.Controls.Add(this.btnhuongdan);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frNhapHang";
            this.Load += new System.EventHandler(this.frNhapHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnhuongdan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmahd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.TextBox txtnam;
        private System.Windows.Forms.TextBox txtthang;
        private System.Windows.Forms.TextBox txtngay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdoitac;
        private System.Windows.Forms.TextBox txtnhanvien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
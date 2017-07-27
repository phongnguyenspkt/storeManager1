namespace Store_Manager_v1
{
    partial class frChiTietHDNHAP
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
            this.lbdoitac = new System.Windows.Forms.Label();
            this.lbnhanvien = new System.Windows.Forms.Label();
            this.lbhoadon = new System.Windows.Forms.Label();
            this.lbtongtien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listnhap = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbdoitac
            // 
            this.lbdoitac.AutoSize = true;
            this.lbdoitac.BackColor = System.Drawing.Color.Transparent;
            this.lbdoitac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbdoitac.ForeColor = System.Drawing.Color.Cyan;
            this.lbdoitac.Location = new System.Drawing.Point(145, 67);
            this.lbdoitac.Name = "lbdoitac";
            this.lbdoitac.Size = new System.Drawing.Size(43, 17);
            this.lbdoitac.TabIndex = 19;
            this.lbdoitac.Text = "lable";
            // 
            // lbnhanvien
            // 
            this.lbnhanvien.AutoSize = true;
            this.lbnhanvien.BackColor = System.Drawing.Color.Transparent;
            this.lbnhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbnhanvien.ForeColor = System.Drawing.Color.Cyan;
            this.lbnhanvien.Location = new System.Drawing.Point(145, 42);
            this.lbnhanvien.Name = "lbnhanvien";
            this.lbnhanvien.Size = new System.Drawing.Size(43, 17);
            this.lbnhanvien.TabIndex = 18;
            this.lbnhanvien.Text = "lable";
            // 
            // lbhoadon
            // 
            this.lbhoadon.AutoSize = true;
            this.lbhoadon.BackColor = System.Drawing.Color.Transparent;
            this.lbhoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbhoadon.ForeColor = System.Drawing.Color.Cyan;
            this.lbhoadon.Location = new System.Drawing.Point(145, 16);
            this.lbhoadon.Name = "lbhoadon";
            this.lbhoadon.Size = new System.Drawing.Size(43, 17);
            this.lbhoadon.TabIndex = 17;
            this.lbhoadon.Text = "lable";
            // 
            // lbtongtien
            // 
            this.lbtongtien.AutoSize = true;
            this.lbtongtien.BackColor = System.Drawing.Color.Transparent;
            this.lbtongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbtongtien.ForeColor = System.Drawing.Color.Maroon;
            this.lbtongtien.Location = new System.Drawing.Point(160, 335);
            this.lbtongtien.Name = "lbtongtien";
            this.lbtongtien.Size = new System.Drawing.Size(19, 20);
            this.lbtongtien.TabIndex = 16;
            this.lbtongtien.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.Cyan;
            this.label5.Location = new System.Drawing.Point(37, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mã hoá đơn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(60, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tổng tiền";
            // 
            // listnhap
            // 
            this.listnhap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader5});
            this.listnhap.Location = new System.Drawing.Point(40, 123);
            this.listnhap.Name = "listnhap";
            this.listnhap.Size = new System.Drawing.Size(556, 205);
            this.listnhap.TabIndex = 13;
            this.listnhap.UseCompatibleStateImageBehavior = false;
            this.listnhap.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã Hàng";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên hàng";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng nhập";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tổng cộng";
            this.columnHeader5.Width = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(244, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mặt hàng vừa nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(37, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đối tác";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nhân viên";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(524, 335);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(115, 34);
            this.btnIn.TabIndex = 20;
            this.btnIn.Text = "In Hoá đơn";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frChiTietHDNHAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Store_Manager_v1.Properties.Resources.nennen;
            this.ClientSize = new System.Drawing.Size(638, 369);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.lbdoitac);
            this.Controls.Add(this.lbnhanvien);
            this.Controls.Add(this.lbhoadon);
            this.Controls.Add(this.lbtongtien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listnhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frChiTietHDNHAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hoá đơn nhập";
            this.Load += new System.EventHandler(this.frChiTietHDNHAP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbdoitac;
        private System.Windows.Forms.Label lbnhanvien;
        private System.Windows.Forms.Label lbhoadon;
        private System.Windows.Forms.Label lbtongtien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listnhap;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIn;
    }
}
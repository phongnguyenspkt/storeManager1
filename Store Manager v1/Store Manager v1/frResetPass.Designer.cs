namespace Store_Manager_v1
{
    partial class frResetPass
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
            this.lbname = new System.Windows.Forms.Label();
            this.lbpascu = new System.Windows.Forms.Label();
            this.lbpassmoi = new System.Windows.Forms.Label();
            this.txt_old = new System.Windows.Forms.TextBox();
            this.txtnew1 = new System.Windows.Forms.TextBox();
            this.btnchange = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_renew = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbname.ForeColor = System.Drawing.Color.White;
            this.lbname.Location = new System.Drawing.Point(5, 34);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(73, 13);
            this.lbname.TabIndex = 0;
            this.lbname.Text = "User Name:";
            // 
            // lbpascu
            // 
            this.lbpascu.AutoSize = true;
            this.lbpascu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbpascu.ForeColor = System.Drawing.Color.White;
            this.lbpascu.Location = new System.Drawing.Point(5, 89);
            this.lbpascu.Name = "lbpascu";
            this.lbpascu.Size = new System.Drawing.Size(84, 13);
            this.lbpascu.TabIndex = 1;
            this.lbpascu.Text = "Old Password";
            // 
            // lbpassmoi
            // 
            this.lbpassmoi.AutoSize = true;
            this.lbpassmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbpassmoi.ForeColor = System.Drawing.Color.White;
            this.lbpassmoi.Location = new System.Drawing.Point(5, 129);
            this.lbpassmoi.Name = "lbpassmoi";
            this.lbpassmoi.Size = new System.Drawing.Size(93, 13);
            this.lbpassmoi.TabIndex = 2;
            this.lbpassmoi.Text = "NewPass Word";
            // 
            // txt_old
            // 
            this.txt_old.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_old.ForeColor = System.Drawing.Color.Maroon;
            this.txt_old.Location = new System.Drawing.Point(104, 86);
            this.txt_old.Name = "txt_old";
            this.txt_old.Size = new System.Drawing.Size(269, 20);
            this.txt_old.TabIndex = 3;
            this.txt_old.UseSystemPasswordChar = true;
            this.txt_old.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_old_KeyPress);
            // 
            // txtnew1
            // 
            this.txtnew1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtnew1.ForeColor = System.Drawing.Color.Maroon;
            this.txtnew1.Location = new System.Drawing.Point(104, 126);
            this.txtnew1.Name = "txtnew1";
            this.txtnew1.Size = new System.Drawing.Size(269, 20);
            this.txtnew1.TabIndex = 4;
            this.txtnew1.UseSystemPasswordChar = true;
            this.txtnew1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnew1_KeyPress);
            // 
            // btnchange
            // 
            this.btnchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnchange.ForeColor = System.Drawing.Color.Maroon;
            this.btnchange.Location = new System.Drawing.Point(104, 181);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(75, 23);
            this.btnchange.TabIndex = 5;
            this.btnchange.Text = "Change";
            this.btnchange.UseVisualStyleBackColor = true;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.btncancel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_renew);
            this.groupBox1.Controls.Add(this.btnchange);
            this.groupBox1.Controls.Add(this.lbname);
            this.groupBox1.Controls.Add(this.txtnew1);
            this.groupBox1.Controls.Add(this.lbpascu);
            this.groupBox1.Controls.Add(this.txt_old);
            this.groupBox1.Controls.Add(this.lbpassmoi);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(42, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 228);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin mới";
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btncancel.ForeColor = System.Drawing.Color.Maroon;
            this.btncancel.Location = new System.Drawing.Point(285, 181);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 8;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nhập lại";
            // 
            // txt_renew
            // 
            this.txt_renew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_renew.ForeColor = System.Drawing.Color.Maroon;
            this.txt_renew.Location = new System.Drawing.Point(104, 155);
            this.txt_renew.Name = "txt_renew";
            this.txt_renew.Size = new System.Drawing.Size(269, 20);
            this.txt_renew.TabIndex = 6;
            this.txt_renew.UseSystemPasswordChar = true;
            // 
            // frResetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Store_Manager_v1.Properties.Resources.nen;
            this.ClientSize = new System.Drawing.Size(483, 262);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frResetPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frResetPass_FormClosed);
            this.Load += new System.EventHandler(this.frResetPass_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Label lbpascu;
        private System.Windows.Forms.Label lbpassmoi;
        private System.Windows.Forms.TextBox txt_old;
        private System.Windows.Forms.TextBox txtnew1;
        private System.Windows.Forms.Button btnchange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_renew;
        private System.Windows.Forms.Button btncancel;
    }
}
namespace Store_Manager_v1
{
    partial class frLoggin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frLoggin));
            this.lbname = new System.Windows.Forms.Label();
            this.lbpass = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.picrang = new System.Windows.Forms.PictureBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.quangcao = new System.Windows.Forms.Timer(this.components);
            this.banhxe = new System.Windows.Forms.Timer(this.components);
            this.lbQuangcao = new System.Windows.Forms.Label();
            this.lbstore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picrang)).BeginInit();
            this.SuspendLayout();
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.BackColor = System.Drawing.Color.Transparent;
            this.lbname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbname.ForeColor = System.Drawing.Color.White;
            this.lbname.Location = new System.Drawing.Point(47, 65);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(83, 17);
            this.lbname.TabIndex = 0;
            this.lbname.Text = "UserName";
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.BackColor = System.Drawing.Color.Transparent;
            this.lbpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbpass.ForeColor = System.Drawing.Color.White;
            this.lbpass.Location = new System.Drawing.Point(50, 106);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(77, 17);
            this.lbpass.TabIndex = 1;
            this.lbpass.Text = "Password";
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.Cornsilk;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLog.Location = new System.Drawing.Point(96, 164);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(98, 26);
            this.btnLog.TabIndex = 2;
            this.btnLog.Text = "Đăng nhập";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // picrang
            // 
            this.picrang.Image = global::Store_Manager_v1.Properties.Resources.banhxe1;
            this.picrang.Location = new System.Drawing.Point(430, 2);
            this.picrang.Name = "picrang";
            this.picrang.Size = new System.Drawing.Size(136, 188);
            this.picrang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picrang.TabIndex = 3;
            this.picrang.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Cornsilk;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThoat.Location = new System.Drawing.Point(276, 164);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 26);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(131, 63);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(293, 20);
            this.txtname.TabIndex = 5;
            this.txtname.TextChanged += new System.EventHandler(this.txtname_TextChanged);
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(131, 104);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(293, 20);
            this.txtpass.TabIndex = 6;
            this.txtpass.UseSystemPasswordChar = true;
            this.txtpass.Visible = false;
            this.txtpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpass_KeyPress);
            // 
            // quangcao
            // 
            this.quangcao.Enabled = true;
            this.quangcao.Tick += new System.EventHandler(this.quangcao_Tick);
            // 
            // banhxe
            // 
            this.banhxe.Enabled = true;
            this.banhxe.Interval = 50;
            this.banhxe.Tick += new System.EventHandler(this.banhxe_Tick);
            // 
            // lbQuangcao
            // 
            this.lbQuangcao.AutoSize = true;
            this.lbQuangcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbQuangcao.ForeColor = System.Drawing.Color.White;
            this.lbQuangcao.Location = new System.Drawing.Point(56, 148);
            this.lbQuangcao.Name = "lbQuangcao";
            this.lbQuangcao.Size = new System.Drawing.Size(0, 17);
            this.lbQuangcao.TabIndex = 7;
            // 
            // lbstore
            // 
            this.lbstore.AutoSize = true;
            this.lbstore.BackColor = System.Drawing.Color.Navy;
            this.lbstore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbstore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbstore.ForeColor = System.Drawing.Color.Lime;
            this.lbstore.Location = new System.Drawing.Point(135, 5);
            this.lbstore.Name = "lbstore";
            this.lbstore.Size = new System.Drawing.Size(230, 33);
            this.lbstore.TabIndex = 8;
            this.lbstore.Text = "Store Manager v1";
            // 
            // frLoggin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Store_Manager_v1.Properties.Resources.manhinhchao;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(569, 192);
            this.Controls.Add(this.lbstore);
            this.Controls.Add(this.lbQuangcao);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.picrang);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.lbpass);
            this.Controls.Add(this.lbname);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frLoggin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frLoggin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picrang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Label lbpass;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.PictureBox picrang;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Timer quangcao;
        private System.Windows.Forms.Timer banhxe;
        private System.Windows.Forms.Label lbQuangcao;
        private System.Windows.Forms.Label lbstore;
    }
}


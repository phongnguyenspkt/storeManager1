using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Store_Manager_v1
{
    public partial class frLoggin : Form
    {
        public frLoggin()
        {
            InitializeComponent();
        }
        #region
        // kết nối

        string strConnectionString = "";
        // Đối tượng kết nối
        SqlConnection conn = null;
        SqlDataAdapter daAccount = null;
        DataTable tbAccount = null;
        // biến dùng trả về dữ liệu

        //
        string id = "";
        bool quyen = false;
        #endregion
        int xe = 0;
        private void banhxe_Tick(object sender, EventArgs e)
        {
            if (xe % 3 == 0)
            {
                this.picrang.Image = global::Store_Manager_v1.Properties.Resources.banhxe3;
            }
            else
                if (xe % 2 == 0)
                {
                    this.picrang.Image = global::Store_Manager_v1.Properties.Resources.banhxe2;
                }
                else if (xe % 1 == 0)
                {
                    this.picrang.Image = global::Store_Manager_v1.Properties.Resources.banhxe1;
                }

            if (xe == 3) xe = 1;
            else
                xe++;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        string s = "---Design by Phonghk---";
        int i = 0;
        private void quangcao_Tick(object sender, EventArgs e)
        {
            if (i != s.Length)
            {
                lbQuangcao.Text = lbQuangcao.Text + s[i];
                i++;
            }
            else
            {
                lbQuangcao.ResetText();
                i = 0;
            }
        }

        private void frLoggin_Load(object sender, EventArgs e)
        {
            Get_database database = new Get_database();
            strConnectionString = database.ketnoi();
            picrang.BackColor = Color.Transparent;
           
            lbQuangcao.BackColor = Color.Transparent;
          
            txtname.Select();
            
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                string truyvan = "select *from Account where idUser='"+txtname.Text+"'";
                daAccount = new SqlDataAdapter(truyvan,conn);
                
                tbAccount = new DataTable();
                tbAccount.Clear();
                daAccount.Fill(tbAccount);
                
                // kiểm tra password bằng md5
                MD5 ma = MD5.Create();
                string masosanh = new Support().GetMd5Hash(ma,txtpass.Text);
                if (masosanh == tbAccount.Rows[0][1].ToString())
                {
                    id = txtname.Text.ToString();
                    quyen = bool.Parse(tbAccount.Rows[0][2].ToString());
                    dangnhapthanhcong();
                }
                else
                {
                    dangnhapthatbai();
                }

            }
            catch
            {
                MessageBox.Show("khong the ket noi!");
            }
        }
        public void dangnhapthanhcong()
        {
            frMain main = new frMain(id, quyen);
            main.Show();
            this.Hide();
        }
        public void dangnhapthatbai()
        {
            MessageBox.Show("Bạn có chắc là mình đã nhập đúng thông tin không?","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Question);
            txtname.ResetText();
            txtpass.ResetText();
            txtpass.Visible = false;
            txtname.Focus();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            string name = txtname.Text;
            if (name != "")
            {
                txtpass.Visible = true;
            }
            else
                txtpass.Visible = false;
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtpass.Focus();
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                try
                {
                    conn = new SqlConnection(strConnectionString);
                    string truyvan = "select *from Account where idUser='" + txtname.Text + "'";
                    daAccount = new SqlDataAdapter(truyvan, conn);
                    tbAccount = new DataTable();
                    tbAccount.Clear();
                    daAccount.Fill(tbAccount);
                    // kiểm tra password bằng md5
                    MD5 ma = MD5.Create();
                    string masosanh = new Support().GetMd5Hash(ma, txtpass.Text);
                    if (masosanh == tbAccount.Rows[0][1].ToString())
                    {
                        id = txtname.Text;
                        quyen = bool.Parse(tbAccount.Rows[0][2].ToString());
                        dangnhapthanhcong();
                    }
                    else
                    {
                        dangnhapthatbai();
                    }

                }
                catch
                {
                    dangnhapthatbai();
                }
            }
        }
    }
}

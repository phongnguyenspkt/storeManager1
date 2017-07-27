using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Store_Manager_v1
{
    public partial class frResetPass : Form
    {
        string id="";
        Form main;
        // chuỗi kết nối
        #region
        string strConnectionString = "";
        SqlConnection conn = null;
        SqlDataAdapter daAccount = null;
        DataTable tabAccount = null;
        #endregion
        public frResetPass(Form _main,string _id)
        {
            main = _main;
            id = _id;
            InitializeComponent();
        }

        private void frResetPass_Load(object sender, EventArgs e)
        {
            Get_database database = new Get_database();
            strConnectionString = database.ketnoi();
            groupBox1.BackColor = Color.Transparent;
            lbname.Text = "User name: "+id;
        }

        private void frResetPass_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConnectionString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            // kiểm tra password có giống không

            string truyvan = "select Account.password from Account where Account.idUser='"+id+"'";
            daAccount = new SqlDataAdapter(truyvan,conn);
            tabAccount = new DataTable();
            tabAccount.Clear();
            daAccount.Fill(tabAccount);
            string csdl = tabAccount.Rows[0][0].ToString();

            MD5 ma = MD5.Create();
            string sosanh = new Support().GetMd5Hash(ma,txt_old.Text);
            if(sosanh!=csdl)
            {
                MessageBox.Show("Password bạn đã nhập không chính xác!Hãy nhập lại!","Thông báo!");
                txt_old.ResetText();
                txt_old.Focus();
                return;
            }
            // kiểm tra password nhập lần 2 có giống không
            if(txt_renew.Text!=txtnew1.Text)
            {
                MessageBox.Show("Password mới đã nhập không khớp! hãy đảm bảo 2 dòng nhập giống nhau!","Thông báo!");
                txt_renew.ResetText();
                txtnew1.ResetText();
                txtnew1.Focus();
                return;
            }


            // lưu password mới
            string passluu = "";
            passluu = new Support().GetMd5Hash(ma,txtnew1.Text);

            save_pass(passluu);
            MessageBox.Show("change pass thành công!");
            if (conn.State == ConnectionState.Open) conn.Close();
            this.Close();
        }
        // save pass xuống csdl
        public void save_pass(string pass)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Account set password='"+pass+"' where idUser='"+id+"'";
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_old_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtnew1.Focus();
            }
        }

        private void txtnew1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txt_renew.Focus();
            }
        }
    }
}

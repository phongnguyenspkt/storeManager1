using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Store_Manager_v1
{
    public partial class frBanHang : Form
    {
        SqlConnection conn=null;
        String ketnoi = "";
        // biến từ from ban đầu
        string nguoiban;
        public bool ban = false;
        public string khachhang = "";
        public string ngaytao = "";
        public string mahd = "";
        public frBanHang(string _nguoiban)
        {
            nguoiban = _nguoiban;
     
            InitializeComponent();
        }
        //-- các hàm xử lí cho nhiệm vụ bán hàng
        #region
        private void frBanHang_Load(object sender, EventArgs e)
        {
            Get_database database = new Get_database();
            ketnoi = database.ketnoi();
            txtnhanvien.Text = nguoiban;
            txtmahd.Text = nexthoadon();
            Get_Date day = new Get_Date();
            txtngay.Text = day.Get_Day();
            txtthang.Text = day.Get_Month();
            txtnam.Text = day.Get_Year();
            txtkhachhang.Select();
        }
        public string nexthoadon()
        {
            try
            {
                conn = new SqlConnection(ketnoi);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string truyvan = "select HoaDon.idHoaDon from HoaDon order by HoaDon.idHoaDon DESC";
                SqlDataAdapter daget = new SqlDataAdapter(truyvan, conn);
                DataTable tbget = new DataTable();
                tbget.Clear();
                daget.Fill(tbget);
                int chiso = int.Parse(tbget.Rows[0][0].ToString());
                chiso++;
                if (conn.State == ConnectionState.Open) conn.Close();
                return chiso.ToString();
            }
            catch
            {
                return "1";
            }
        }
        public void taohoadon()
        {

                if(txtkhachhang.Text=="")
                {
                    MessageBox.Show("Bạn đã bỏ lỡ tên khách hàng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Question);
                    return;
                }
                conn = new SqlConnection(ketnoi);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                ngaytao = txtngay.Text + "/" + txtthang.Text + "/" + txtnam.Text;
                string ngaynhap = txtthang.Text + "/" + txtngay.Text + "/" + txtnam.Text;
                cmd.CommandText = "Insert into HoaDon (idHoaDon,idNhanvien,TenKH,NgayBan) values(N'"+txtmahd.Text+"',N'"+txtnhanvien.Text+"',N'"+txtkhachhang.Text+"',N'"+ngaynhap+"')";
                
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) conn.Close();
             

        }
        #endregion
        private void btnhuongdan_Click(object sender, EventArgs e)
        {
            string s1 = "\n+ Đầu tiền bạn cần tạo 1 hoá đơn bán hàng!";
            string s2 = "\n+ Mỗi nhân viên chịu phần trách nhiệm cho hoá đơn của mình \n và thế bạn không được phép nhập hoá đơn từ 1 nhân viên khác";
            string s3 = "\n+ Sau khi ghi đầy đủ chi tiết cho 1 hoá đơn, bạn nhấn /<Next/> để tiếp tục giao dịch ";
            MessageBox.Show("Để tạo một chi tiết bán hàng"+s1+s2+s3,"Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                taohoadon();
                if (txtkhachhang.Text == "")
                {
                    return;
                }
                ban = true;
                khachhang = txtkhachhang.Text;
                mahd = txtmahd.Text;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xuất hiện lỗi:"+ex.Message);
                return;
            }
        }
    }
}

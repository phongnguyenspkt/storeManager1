using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Store_Manager_v1
{
    public partial class frNhapHang : Form
    {
        SqlConnection conn = null;
        String ketnoi = "";

        string id = "";
        public bool nhaphang = false;
        public string doitac = "";
        public string ngaytao = "";
        public string mahd;
        public frNhapHang(string _id)
        {
            id = _id;
            InitializeComponent();
        }

        private void frNhapHang_Load(object sender, EventArgs e)
        {
            Get_database database = new Get_database();
            ketnoi = database.ketnoi();
            txtnhanvien.Text =id ;
            txtmahd.Text = nenxt_hoadonnhap();
            Get_Date day = new Get_Date();
            txtngay.Text = day.Get_Day();
            txtthang.Text = day.Get_Month();
            txtnam.Text = day.Get_Year();
            txtdoitac.Select();
        }
        //hàm xử lí
        #region
        public string nenxt_hoadonnhap()
        {
            try
            {
                conn = new SqlConnection(ketnoi);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string truyvan = "select idHoaDon from HoaDonNhap order by idHoaDon DESC";
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
        // hàm xử lí tạo hoá đơn
        public void taohoadon()
        {

            if (txtdoitac.Text == "")
            {
                MessageBox.Show("Bạn đã bỏ lỡ tên đối tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            cmd.CommandText = "insert into HoaDonNhap (idHoaDon,idNhanvien,TenDT,NgayMua) values(N'" + txtmahd.Text + "',N'" + txtnhanvien.Text + "',N'" + txtdoitac.Text + "',N'" + ngaynhap + "')";
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open) conn.Close();


        }
        #endregion

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                taohoadon();
                if (txtdoitac.Text == "")
                {
                    return;
                }
                nhaphang = true;
                doitac = txtdoitac.Text;
                mahd = txtmahd.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất hiện lỗi:" + ex.Message);
                return;
            }
        }

        private void btnhuongdan_Click(object sender, EventArgs e)
        {
            string s1 = "\n+ Đầu tiên bạn cần tạo hoá đơn nhập hàng!";
            string s2 = "\n+ Mỗi nhân viên chịu phần trách nhiệm cho hoá đơn của mình \n và thế bạn không được phép nhập hoá đơn từ 1 nhân viên khác";
            string s3 = "\n+ Sau khi ghi đầy đủ chi tiết cho 1 hoá đơn, bạn nhấn /<Next/> để tiếp tục giao dịch ";
            MessageBox.Show("Để tạo một chi tiết bán hàng" + s1 + s2 + s3, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

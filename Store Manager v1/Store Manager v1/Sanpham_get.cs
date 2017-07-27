using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Store_Manager_v1
{
    class Sanpham_get
    {
        String ketnoi = "";
        Get_database database = new Get_database();
        
       public  string masp = "";
        public string tensp = "";
        public string dongia = "";
        public string soluong = "";
        public Sanpham_get()
        {

        }
        public void laydata(string ma)
        {
            try
            {
                ketnoi = database.ketnoi();
                SqlConnection conn = null;
                conn=new SqlConnection(ketnoi);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                //
                string tryvan = "select Sanpham.idSp,Name,GiaBan,SoLuong from Sanpham where idSp=N'"+ma+"'";
                SqlDataAdapter dasap = new SqlDataAdapter(tryvan,conn);
                DataTable tbsp = new DataTable();
                tbsp.Clear();
                dasap.Fill(tbsp);
                //-- LẤY DATA
                masp = tbsp.Rows[0][0].ToString();
                tensp = tbsp.Rows[0][1].ToString();
                dongia = tbsp.Rows[0][2].ToString();
                soluong = tbsp.Rows[0][3].ToString();
                //
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                     
               
            }
            catch
            {
                masp = "";
                tensp = "";
                soluong = "";
                dongia = "";
            }
        }
        // lấy data nhập
        public void laydata_nhap(string ma)
        {
            try
            {
                ketnoi = database.ketnoi();
                SqlConnection conn = null;
                conn = new SqlConnection(ketnoi);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                //
                string tryvan = "select Sanpham.idSp,Name,GiaNhap,SoLuong from Sanpham where idSp=N'" + ma + "'";
                SqlDataAdapter dasap = new SqlDataAdapter(tryvan, conn);
                DataTable tbsp = new DataTable();
                tbsp.Clear();
                dasap.Fill(tbsp);
                //-- LẤY DATA
                masp = tbsp.Rows[0][0].ToString();
                tensp = tbsp.Rows[0][1].ToString();
                dongia = tbsp.Rows[0][2].ToString();
                soluong = tbsp.Rows[0][3].ToString();
                //
                if (conn.State == ConnectionState.Open)
                    conn.Close();


            }
            catch
            {
                masp = "";
                tensp = "";
                soluong = "";
                dongia = "";
            }
        }
        // update lại số lượng sản phẩm trong kho
        public void save_data(string masp,string soluong)
        {
            ketnoi = database.ketnoi();
                SqlConnection conn = null;
                conn = new SqlConnection(ketnoi);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
              // tiến hành update
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Sanpham set SoLuong=N'"+soluong+"' where idSp=N'"+masp+"'";
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            
          
        }
      
        public void save_ct(string mhd,string msp,string soluong)
        {
            ketnoi = database.ketnoi();
            SqlConnection conn = null;
            conn = new SqlConnection(ketnoi);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            // tiến hành update
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into ChiTietHoaDon(idMaHD,idSp,SoLuong) values(N'"+mhd+"',N'"+msp+"',N'"+soluong+"')";
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        // save chi tiết nhập
        public void save_ctNhap(string mhd, string msp, string soluong)
        {
            ketnoi = database.ketnoi();
            SqlConnection conn = null;
            conn = new SqlConnection(ketnoi);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            // tiến hành update
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into ChiTietNhap(idHoaDon,idSp,SoLuong) values(N'"+mhd+"',N'"+msp+"',N'"+soluong+"')";
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

    }
}

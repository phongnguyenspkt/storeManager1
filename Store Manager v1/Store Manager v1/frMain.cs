using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;
// thư viện cho bitmap
using System.Drawing;
using System.Drawing.Imaging;
namespace Store_Manager_v1
{
    public partial class frMain : Form
    {
        #region
        // biến cho biến người đang đang nhập
        String id = "";
        bool quyen = false;// ko có toàn quyền

        // data dùng toàn cục
        Get_database a = new Get_database();
        
        String ketnoi = "";
        
        SqlConnection conn = null;
        // data adapter
        SqlDataAdapter daSanpham = null;
        SqlDataAdapter daDanhmuc = null;
        SqlDataAdapter daHoaDon = null;
        SqlDataAdapter daCTHoaDon = null;
        SqlDataAdapter daHoaDonNhap = null;
        SqlDataAdapter daCTHoaDonNhap = null;
        SqlDataAdapter daloaiSanpham = null;
        // datatable
        DataTable tbSanpham = null;
        DataTable tbDanhMuc = null;
        DataTable tbHoaDon = null;
        DataTable tbCTHoaDon = null;
        DataTable tbHoaDonNhap = null;
        DataTable tbCTHoaDonNhap = null;
        DataTable tbloaiSanPham = null;
        // flag dùng kiểm tra trạng thai

        string flag_danhmuc = "";
        string flag_loaisp = "";
        string flag_hoadon = "";
        string flag_hoadon_nhap = "";
        // flag dùng khoá tab
        bool khoa_hoadonban = false;
        bool khoa_hoadonnhap = false;

        #endregion
        public frMain(string _id,bool _quyen)
        {
            id = _id;
            quyen = _quyen;
            InitializeComponent();
            picrang.BackColor = Color.Transparent;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát không? ahjj","Hỏi ngắn",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        // đoạn code chống giật nhưng đồng thời làm tăng thời gian load
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }

        }
        private void frMain_Load(object sender, EventArgs e)
        {
            Get_database database = new Get_database();
            ketnoi = database.ketnoi();
            this.TAbMain.Controls.Remove(tabbanhangk);
            this.TAbMain.Controls.Remove(tabnhaphangve);
            if (quyen == false)
            {
                lbquyen.Text = "Bạn vừa đăng nhập quyền nhân viên";
                khoaquyen();
            }
            else lbquyen.Text = "Bạn vừa đăng nhập quyền chủ cửa hàng";

            // tạo kết nối
            conn = new SqlConnection(ketnoi);
            // load tất cả các sản phẩm
            load_sp();
            // load tất cả danh mục
            load_danhmuc();
            // load tất cả các hoá đơn
            load_hoadon();
            // load tất cả các chi tiết hoá đơn
            load_chitietban();
            // load hoá đơn nhập
            load_hoadonnhap();
            // load chi tiết hoá đơn nhập
            load_chitietban_n();
            // load tất cả sản phẩm trong loại sản phẩm
            load_loaisp();
            // load doanh thu ước tính
            load_doanhthu();
            label28.BackColor = Color.Transparent;
            label30.BackColor = Color.Transparent;
        }
        int xe = 0;
        private void chayrang_Tick(object sender, EventArgs e)
        {
            if (xe % 3 == 0)
            {
                this.picrang.Image = global::Store_Manager_v1.Properties.Resources.banhxe3;
                this.picrang2.Image = global::Store_Manager_v1.Properties.Resources.banhxe3;
                this.pic4.Image = global::Store_Manager_v1.Properties.Resources.banhxe3;
            }
            else
                if (xe % 2 == 0)
                {
                    this.picrang.Image = global::Store_Manager_v1.Properties.Resources.banhxe2;
                    this.picrang2.Image = global::Store_Manager_v1.Properties.Resources.banhxe2;
                    this.pic4.Image = global::Store_Manager_v1.Properties.Resources.banhxe2;
                }
                else if (xe % 1 == 0)
                {
                    this.picrang.Image = global::Store_Manager_v1.Properties.Resources.banhxe1;
                    this.picrang2.Image = global::Store_Manager_v1.Properties.Resources.banhxe1;
                    this.pic4.Image = global::Store_Manager_v1.Properties.Resources.banhxe1;
                }

            if (xe == 3) xe = 1;
            else
                xe++;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        // các phương thức
        // load sản phẩm
        #region
        // Sản phẩm
        public void load_sp()
        {
            try
            {
               
                if (conn.State == ConnectionState.Closed) conn.Open();
                // load combobox lên trước
                string getcn = "select*from DanhMuc";
                SqlDataAdapter dag_cb = new SqlDataAdapter(getcn,conn);
                DataTable tbcb_danhmuc = new DataTable();
                tbcb_danhmuc.Clear();
                dag_cb.Fill(tbcb_danhmuc);
               
                (dtg_sanpham.Columns["IdDanhMuc"] as DataGridViewComboBoxColumn).DataSource = tbcb_danhmuc;
                cbsp_danhmuc.DataSource = tbcb_danhmuc;
                (dtg_sanpham.Columns["IdDanhMuc"] as DataGridViewComboBoxColumn).DisplayMember = "TenDM";
                cbsp_danhmuc.DisplayMember = "TenDM";
                (dtg_sanpham.Columns["IdDanhMuc"] as DataGridViewComboBoxColumn).ValueMember = "idDM";
                cbsp_danhmuc.ValueMember = "idDM";
                // load data sản phẩm
                 string truyvan = "select* from Sanpham";
                daSanpham = new SqlDataAdapter(truyvan,conn);
                tbSanpham = new DataTable();
                tbSanpham.Clear();
                daSanpham.Fill(tbSanpham);
               // dtg_sanpham.DataSource = "";-> cho dòng này vào thì toàn bộ combobox , header sẽ bị xoá hết
                dtg_sanpham.DataSource = tbSanpham;
                
                if(quyen==false)
                dtg_sanpham.Columns["GiaNhap"].Visible = false;// hạn chế quyền cho user ko phải chủ cửa hàng
                if(conn.State==ConnectionState.Open)
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // lấy sản phẩm theo mã sản Phầm
  
        public void tim_sp()
        {
            try
            {
               

                if (conn.State == ConnectionState.Closed) conn.Open();
                string truyvan = "select *from Sanpham where ";
                if(cbDM.Checked==true)
                {
                   truyvan+="IdDanhMuc='" + cbsp_danhmuc.SelectedValue.ToString()+"'";
                }

                //
                if(cbTen.Checked==true)
                {

                        truyvan += "Sanpham.name LIKE '%" + txtsp_sten.Text + "%'";

                }

                if(cbSoLuong.Checked==true)
                {
                    truyvan += " soLuong<"+txtsp_ssoluong.Text;

                    if (txtsp_ssoluong.Text == "")
                    {
                        MessageBox.Show("Bạn không được bỏ trống số lượng, vì bạn đã chọn tìm từ nó!");
                        return;
                    }

                }
  
                // load combobox lên trước
                string getcn = "select*from DanhMuc";
                SqlDataAdapter dag_cb = new SqlDataAdapter(getcn, conn);
                DataTable tbcb_danhmuc = new DataTable();
                tbcb_danhmuc.Clear();
                dag_cb.Fill(tbcb_danhmuc);

                (dtg_sanpham.Columns["IdDanhMuc"] as DataGridViewComboBoxColumn).DataSource = tbcb_danhmuc;
                (dtg_sanpham.Columns["IdDanhMuc"] as DataGridViewComboBoxColumn).DisplayMember = "TenDM";
                (dtg_sanpham.Columns["IdDanhMuc"] as DataGridViewComboBoxColumn).ValueMember = "idDM";
            
                //
                daSanpham = new SqlDataAdapter(truyvan, conn);
                tbSanpham = new DataTable();
                tbSanpham.Clear();
                daSanpham.Fill(tbSanpham);
                dtg_sanpham.DataSource = tbSanpham;
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối từ data!Không thể lấy sản phẩm lên được!", "Vui lòng thực hiện cấu hình đúng", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        public void tinhtien_ngankho()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string truyvan = "select SUM(Sanpham.gianhap*Sanpham.soLuong) as Tongtien from Sanpham";
                SqlDataAdapter daTongTien = new SqlDataAdapter(truyvan,conn);
                DataTable dbTongtien = new DataTable();
                dbTongtien.Clear();
                daTongTien.Fill(dbTongtien);
                string tien = dbTongtien.Rows[0][0].ToString();
                float convertt = float.Parse(tien);
                tien = string.Format("{0:0,0}", convertt); 
                lbsotien.Text = "Tổng số tiền vốn hiện tại:"+tien;
                conn.Close();

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối từ data!", "Vui lòng thực hiện cấu hình đúng", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
        }
        //
        public void tinhsanpham_ngankho()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string truyvan = "select COUNT(Sanpham.idSp) as sosp FROM Sanpham";
                SqlDataAdapter datongsp = new SqlDataAdapter(truyvan,conn);
                DataTable tbtongsanpham = new DataTable();
                tbtongsanpham.Clear();
                datongsp.Fill(tbtongsanpham);
                string sosp = tbtongsanpham.Rows[0][0].ToString();
                float convertt = float.Parse(sosp);
                sosp = string.Format("{0:0,0}", convertt);
                lbsanphamtrongkho.Text = "Số loại sản phẩm trong kho:"+sosp;
                //

               
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối từ data!", "Vui lòng thực hiện cấu hình đúng", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
        }
        //
        public void sanphamconit()
        {

        }

        private void tabSanPham_Click(object sender, EventArgs e)
        {

        }
        // danhmuc
        public void load_danhmuc()
        {
            try
            {
                CTR_loaddanhmuc();
                if (conn.State == ConnectionState.Closed) conn.Open();

               
                // load hoá đơn lên
                string truyvan = "select * from DanhMuc";
                daDanhmuc = new SqlDataAdapter(truyvan,conn);
                tbDanhMuc = new DataTable();
                tbDanhMuc.Clear();
                daDanhmuc.Fill(tbDanhMuc);
                dtg_danhmuc.DataSource=tbDanhMuc;
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối từ data!Không lấy danh mục được", "Vui lòng thực hiện cấu hình đúng", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
        }
        // khoá quyền trong đăng nhập
        public void  khoaquyen()
        {
            lbspDoanhThu.Visible = false;
            grkho.Visible = false;
        }
        #endregion
       

        // load hoá đơn
        #region
        // hoá đơn và chi tiết hoá đơn
        //--------------- Hoá đơn------------------------
        public void load_hoadon()
        {
            try
            {
                ctr_loadhd();
                if (conn.State == ConnectionState.Closed) conn.Open();
                string truyvan = "select idHoaDon,idNhanvien,TenKH,NgayBan,(YEAR(NgayBan)*365+MONTH(NgayBan)*30+DAY(NgayBan)) ngaygiaodich  from HoaDon order by ngaygiaodich desc,idHoaDon desc";
                daHoaDon = new SqlDataAdapter(truyvan, conn);
                tbHoaDon = new DataTable();
                tbHoaDon.Clear();
                daHoaDon.Fill(tbHoaDon);
                dtg_hoadon.DataSource = tbHoaDon;
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // tìm kiếm hoá đơn bán
        public void load_searhHD()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                lbketquas.ResetText();
                string truyvan = "select* from HoaDon where YEAR(NgayBan)=";
                if(txt_s_year.Text!="")
                {
                    truyvan += txt_s_year.Text;
                    lbketquas.Text += "Kết quả tìm cho hoá đơn năm:" + txt_s_year.Text;
                    if(txt_s_moth.Text!="")
                    {
                        lbketquas.Text = "Kết quả tìm cho hoá đơn tháng:"+txt_s_moth.Text+" năm:" + txt_s_year.Text;
                        truyvan += "and MONTH(NgayBan)="+txt_s_moth.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn nên chọn năm-> sau đó là chọn tháng (không nhất thiết phải chọn tháng)! Thanks!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                daHoaDon = new SqlDataAdapter(truyvan, conn);
                tbHoaDon = new DataTable();
                tbHoaDon.Clear();
                daHoaDon.Fill(tbHoaDon);
                dtg_hoadon.DataSource = tbHoaDon;
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // tìm chi tiet hoadon
        public void timchitiet_hoadon(string mahd)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string truyvan = "select Sanpham.Name,ChiTietHoaDon.SoLuong,Sanpham.GiaBan*ChiTietHoaDon.SoLuong as Tien from Sanpham,ChiTietHoaDon where ChiTietHoaDon.idSp=Sanpham.idSp and ChiTietHoaDon.idMaHD='"+mahd+"'";
                SqlDataAdapter dact_hd = new SqlDataAdapter(truyvan,conn);
                DataTable tbct_hd = new DataTable();
                tbct_hd.Clear();
                dact_hd.Fill(tbct_hd);
                dtg_ct_hd.DataSource = tbct_hd;
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch(Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
        }
        // tính tổng tiền mua của một chi tiết hoá đơn
        public void tinhtongtien_1chitiet(string mahd)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string truyvan = "select SUM(Sanpham.GiaBan*ChiTietHoaDon.SoLuong )as Tien,SUM(Sanpham.GiaNhap*ChiTietHoaDon.SoLuong )as Nhap from Sanpham,ChiTietHoaDon where ChiTietHoaDon.idSp=Sanpham.idSp and ChiTietHoaDon.idMaHD='"+mahd+"'";
                SqlDataAdapter datchitiett = new SqlDataAdapter(truyvan,conn);
                DataTable tbdoanhthu = new DataTable();
                tbdoanhthu.Clear();
                datchitiett.Fill(tbdoanhthu);
                lbtongmua.Text = tbdoanhthu.Rows[0][0].ToString();
                long tong = long.Parse(lbtongmua.Text);
                long von = long.Parse( tbdoanhthu.Rows[0][1].ToString());
                lbloithuduoc.Text = (tong - von).ToString();
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message+"- Có thể vị khách này chưa mua mặt hàng nào!");
                lbtongmua.Text = "Hoá đơn này trống";
                lbloithuduoc.Text = "Chưa có dữ liệu thống kê";
            }
        }
        // load chi tiết bán lên
        public void load_chitietban()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                // load combobox len truoc
                string laysp = "select * from Sanpham";
                SqlDataAdapter dalay = new SqlDataAdapter(laysp,conn);
                DataTable tablay = new DataTable();
                tablay.Clear();
                dalay.Fill(tablay);

                (dtg_chitietHD.Columns["cl_tenSP"] as DataGridViewComboBoxColumn).DataSource = tablay;
                cbctb_tensanpham.DataSource = tablay;
                (dtg_chitietHD.Columns["cl_tenSP"] as DataGridViewComboBoxColumn).DisplayMember = "Name";
                cbctb_tensanpham.DisplayMember = "Name";

                (dtg_chitietHD.Columns["cl_tenSP"] as DataGridViewComboBoxColumn).ValueMember = "idSp";
                cbctb_tensanpham.ValueMember = "idSp";




                string truyvan = "select ChiTietHoaDon.idMaHD, ChiTietHoaDon.idSp,ChiTietHoaDon.SoLuong,Sanpham.GiaBan as GiaBan,Sanpham.GiaBan*ChiTietHoaDon.SoLuong as tien from ChiTietHoaDon,Sanpham where ChiTietHoaDon.idSp=Sanpham.idSp";
                daCTHoaDon = new SqlDataAdapter(truyvan,conn);
                tbCTHoaDon = new DataTable();
                tbCTHoaDon.Clear();
                daCTHoaDon.Fill(tbCTHoaDon);
                dtg_chitietHD.DataSource = tbCTHoaDon;
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        // load hoá đơn nhập
        #region
        public void load_hoadonnhap()// load hoá đơn nhập
        {
            try
            {
                ctr_loadhd_nhap();
                if (conn.State == ConnectionState.Closed) conn.Open();
                string truyvan = "select *from HoaDonNhap order by idHoaDon desc ";
                daHoaDonNhap = new SqlDataAdapter(truyvan,conn);
                tbHoaDonNhap = new DataTable();
                tbHoaDonNhap.Clear();
                daHoaDonNhap.Fill(tbHoaDonNhap);
                dtg_HoaDonNhap.DataSource = tbHoaDonNhap;
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // tìm kiếm hoá đơn nhập
        public void load_searhHDNhap()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                lbketquas.ResetText();
                string truyvan = "select* from HoaDonNhap where YEAR(NgayMua)=";
                if (txt_s_year_n.Text != "")
                {
                    truyvan += txt_s_year_n.Text;
                   // lbketquas.Text += "Kết quả tìm cho hoá đơn năm:" + txt_s_year.Text;
                    if (txt_s_moth_n.Text != "")
                    {
                     //   lbketquas.Text = "Kết quả tìm cho hoá đơn tháng:" + txt_s_moth.Text + " năm:" + txt_s_year.Text;
                        truyvan += "and MONTH(NgayMua)=" + txt_s_moth_n.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn nên chọn năm-> sau đó là chọn tháng (không nhất thiết phải chọn tháng)! Thanks!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                daHoaDonNhap = new SqlDataAdapter(truyvan, conn);
                tbHoaDonNhap = new DataTable();
                tbHoaDonNhap.Clear();
                daHoaDonNhap.Fill(tbHoaDonNhap);
                dtg_HoaDonNhap.DataSource = tbHoaDonNhap;
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // tìm kiếm chi tiết hoá đơn nhập
        public void timchitiet_hoadonnhap(string mahd)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string truyvan = "select Sanpham.Name,ChiTietNhap.SoLuong,Sanpham.GiaNhap*ChiTietNhap.SoLuong as Tien from Sanpham,ChiTietNhap where ChiTietNhap.idSp=Sanpham.idSp and ChiTietNhap.idHoaDon='" + mahd + "'";
                SqlDataAdapter dact_hd = new SqlDataAdapter(truyvan, conn);
                DataTable tbct_hd = new DataTable();
                tbct_hd.Clear();
                dact_hd.Fill(tbct_hd);
                dtg_ct_hdn.DataSource = tbct_hd;
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                lbtiennhapve.Text = "Chưa có dữ liệu thống kê!";
            }
        }
        // tính tổng một chi tiết nhập
        public void tinhtongtien_1chitiet_n(string mahd)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string truyvan = "select SUM(Sanpham.GiaNhap*ChiTietNhap.SoLuong )as Nhap from Sanpham,ChiTietNhap where ChiTietNhap.idSp=Sanpham.idSp and ChiTietNhap.idHoaDon='" + mahd + "'";
                SqlDataAdapter datchitiett = new SqlDataAdapter(truyvan, conn);
                DataTable tbdoanhthu = new DataTable();
                tbdoanhthu.Clear();
                datchitiett.Fill(tbdoanhthu);

                lbtiennhapve.Text = tbdoanhthu.Rows[0][0].ToString();
               
            }
            catch (Exception ex)
            {
                lbtiennhapve.Text = "Chưa có dữ liệu nhập hàng!";
            }
        }
        // load chi tiết nhập lên
        public void load_chitietban_n()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                // load combobox len truoc
                string laysp = "select * from Sanpham";
                SqlDataAdapter dalay = new SqlDataAdapter(laysp, conn);
                DataTable tablay = new DataTable();
                tablay.Clear();
                dalay.Fill(tablay);

                (dtg_chitietHD_n.Columns["clsanpham"] as DataGridViewComboBoxColumn).DataSource = tablay;
                cbctm_tensp.DataSource = tablay;

                (dtg_chitietHD_n.Columns["clsanpham"] as DataGridViewComboBoxColumn).DisplayMember = "Name";
                cbctm_tensp.DisplayMember = "Name";
                (dtg_chitietHD_n.Columns["clsanpham"] as DataGridViewComboBoxColumn).ValueMember = "idSp";
                cbctm_tensp.ValueMember = "idSp";



                string truyvan = "select ChiTietNhap.idHoaDon,ChiTietNhap.idSp,ChiTietNhap.SoLuong,Sanpham.GiaNhap as GiaNhap,ChiTietNhap.SoLuong*Sanpham.GiaNhap as tien from ChiTietNhap,Sanpham where ChiTietNhap.idSp=Sanpham.idSp";
                daCTHoaDonNhap = new SqlDataAdapter(truyvan, conn);
                tbCTHoaDonNhap = new DataTable();
                tbCTHoaDonNhap.Clear();
                daCTHoaDonNhap.Fill(tbCTHoaDonNhap);
                dtg_chitietHD_n.DataSource = tbCTHoaDonNhap;
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        // xử lí cho loại sản phẩm
        #region
        public void load_loaisp()
        {
            try
            {
                ctr_loadloai();
                if (conn.State == ConnectionState.Closed) conn.Open();
                // load combobox lên trước
                string getcn = "select*from DanhMuc";
                SqlDataAdapter dag_cb = new SqlDataAdapter(getcn, conn);
                DataTable tbcb_danhmuc = new DataTable();
                tbcb_danhmuc.Clear();
                dag_cb.Fill(tbcb_danhmuc);

                (dtg_loaisanpham.Columns["clloai_dm"] as DataGridViewComboBoxColumn).DataSource = tbcb_danhmuc;
                cbloai_dm.DataSource = tbcb_danhmuc;

                (dtg_loaisanpham.Columns["clloai_dm"] as DataGridViewComboBoxColumn).DisplayMember = "TenDM";
                cbloai_dm.DisplayMember = "TenDM";
                (dtg_loaisanpham.Columns["clloai_dm"] as DataGridViewComboBoxColumn).ValueMember = "idDM";
                cbloai_dm.ValueMember = "idDM";
                // load data sản phẩm
                string truyvan = "select* from Sanpham";
                daloaiSanpham = new SqlDataAdapter(truyvan, conn);

                tbloaiSanPham = new DataTable();
                tbloaiSanPham.Clear();
                daloaiSanpham.Fill(tbloaiSanPham);
                // dtg_sanpham.DataSource = "";-> cho dòng này vào thì toàn bộ combobox , header sẽ bị xoá hết
                dtg_loaisanpham.DataSource = tbloaiSanPham;

                if (quyen == false)
                    dtg_loaisanpham.Columns["clloai_gianhap"].Visible = false;// hạn chế quyền cho user ko phải chủ cửa hàng
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // xử lí khi click vào 1 dòng trong bảng
        public void click_one(int vitri)
        {
            try
            {
                txtloai_ma.Text = dtg_loaisanpham.Rows[vitri].Cells["clloai_ma"].Value.ToString();
                txtloai_ten.Text = dtg_loaisanpham.Rows[vitri].Cells["clloai_ten"].Value.ToString();
                txtloai_nhasx.Text = dtg_loaisanpham.Rows[vitri].Cells["clloai_nhasanxuat"].Value.ToString();
                txtloai_baohanh.Text = dtg_loaisanpham.Rows[vitri].Cells["clloai_baohanh"].Value.ToString();
                txtloai_dvtinh.Text = dtg_loaisanpham.Rows[vitri].Cells["clloai_donvi"].Value.ToString();
                txtloai_gianhap.Text = dtg_loaisanpham.Rows[vitri].Cells["clloai_gianhap"].Value.ToString();
                txtloai_giaban.Text = dtg_loaisanpham.Rows[vitri].Cells["clloai_giaban"].Value.ToString();
                cbloai_dm.SelectedValue = dtg_loaisanpham.Rows[vitri].Cells["clloai_dm"].Value.ToString();
                txtloai_soluong.Text = dtg_loaisanpham.Rows[vitri].Cells["clloai_soluong"].Value.ToString();
            }
            catch
            {

            }
        }
        #endregion
        #region
        // save doanh thu
      
        public void load_doanhthu()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string truyvan = "select HoaDon.idHoaDon,HoaDon.idNhanvien,SUM(GiaBan*ChiTietHoaDon.SoLuong) as tienban,SUM(GiaNhap*ChiTietHoaDon.SoLuong) as tienvon,HoaDon.NgayBan  FROM ChiTietHoaDon,HoaDon,Sanpham where ChiTietHoaDon.idSp=Sanpham.idSp and  HoaDon.idHoaDon=ChiTietHoaDon.idMaHD   group by HoaDon.idHoaDon,HoaDon.idNhanvien,HoaDon.NgayBan order by HoaDon.idHoaDon desc";
                SqlDataAdapter dadoanhthu = new SqlDataAdapter(truyvan,conn);
                DataTable tabdoanhthu = new DataTable();
                tabdoanhthu.Clear();
                dadoanhthu.Fill(tabdoanhthu);
                dtg_doanhthu.DataSource = tabdoanhthu;
                if (conn.State == ConnectionState.Open) conn.Close();
                uoctinh_doanhthu();
            }
            catch
            {
                MessageBox.Show("Lỗi ! Không thể tiến hành load doanh thu được!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        // tính doanh thu trong bảng
        public void uoctinh_doanhthu()
        {
            try
            {
                int tienvon = 0;
                int tienban = 0;
                
                for (int i = 0; i < dtg_doanhthu.RowCount-1; i++)
                {
                    tienvon += int.Parse(dtg_doanhthu.Rows[i].Cells["cl3_tienvon"].Value.ToString());
                    tienban += int.Parse(dtg_doanhthu.Rows[i].Cells["cl3_tienban"].Value.ToString());
                }
                string von = tienvon.ToString();
                string ban = tienban.ToString();
                string lai = (tienban - tienvon).ToString();
                float convert = float.Parse(von);// vốn
                von = string.Format("{0:0,0}",convert);
                convert = float.Parse(ban);//bán
                ban = string.Format("{0:0,0}",convert);
                convert = float.Parse(lai);
                lai = string.Format("{0:0,0}",convert);

                txt3_vonbora.Text = von;
                txt3_tientongban.Text = ban;
                txt3doanhthuve.Text = lai;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                txt3_vonbora.Text = "Chưa có dữ liệu!";
                txt3_tientongban.Text = "Chưa có dữ liệu!";
                txt3doanhthuve.Text = "Chưa có dữ liệu";
            }
        }
        #endregion
        private void btncheckSP_Click(object sender, EventArgs e)
        {
            tinhtien_ngankho();
            tinhsanpham_ngankho();
        }

        private void btnSp_Click(object sender, EventArgs e)
        {
          
            load_sp();
        }

        private void btnDM_Click(object sender, EventArgs e)
        {
            load_danhmuc();
        }

        private void btnsp_s_Click(object sender, EventArgs e)
        {
            tim_sp();
            
        }

        private void picrang2_Click(object sender, EventArgs e)
        {
            picrang2.Visible = false;
        }

        private void btnsp_reload_Click(object sender, EventArgs e)
        {
            load_sp();
        }

        private void cbDM_CheckedChanged(object sender, EventArgs e)
        {
            if(cbDM.Checked==true)
            {
                cbsp_danhmuc.Visible = true;
            }
            else
                cbsp_danhmuc.Visible = false;
        }

        private void cbTen_CheckedChanged(object sender, EventArgs e)
        {
            if(cbTen.Checked==true)
            {
                txtsp_sten.Visible = true;
            }
            else txtsp_sten.Visible = false;

        }

        private void cbSoLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSoLuong.Checked == true) txtsp_ssoluong.Visible = true;
            else txtsp_ssoluong.Visible = false;
        }

        private void dtg_danhmuc_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch
            {

            }
        }

        private void dtg_danhmuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int vitri = e.RowIndex;
                txtdm_madm.Text = dtg_danhmuc.Rows[vitri].Cells["idDM"].Value.ToString();
                txtdm_tendm.Text = dtg_danhmuc.Rows[vitri].Cells["TenDM"].Value.ToString();

            }

            catch { }
        }

        private void dtg_danhmuc_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void btnNhaphatrien_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/crayman.54");
        }

        private void btnmatkhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            frResetPass a = new frResetPass(this,id);
            a.Show();
        }

        private void btnbh_reload_Click(object sender, EventArgs e)
        {
            load_hoadon();
        }

        private void txt_s_year_TextChanged(object sender, EventArgs e)
        {
            string xet = this.txt_s_year.Text;
            if (xet != "") txt_s_moth.Visible = true;
            else txt_s_moth.Visible = false;
                
        }

        private void btnhd_search_Click(object sender, EventArgs e)
        {
            load_searhHD();
        }

        private void dtg_hoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lbtongmua.ResetText();
                lbloithuduoc.ResetText();
                int vitri = e.RowIndex;
                lbtenkh.Text =  dtg_hoadon.Rows[vitri].Cells["clKhachhang"].Value.ToString();
                txtbh_khachhang.Text = lbtenkh.Text;
                lbnguoiban.Text = dtg_hoadon.Rows[vitri].Cells["clnhanvien"].Value.ToString();
                txtbh_nhanvien.Text = lbnguoiban.Text;
                string chitiet = dtg_hoadon.Rows[vitri].Cells["idHoaDon"].Value.ToString();
                txtbh_mahd.Text = chitiet;
                txtbh_ngay.Text = dtg_hoadon.Rows[vitri].Cells["clngayban"].Value.ToString();
                DateTime dt = Convert.ToDateTime(txtbh_ngay.Text);
                txtbh_ngay.Text = dt.ToString("dd/MM/yyyy");
                timchitiet_hoadon(chitiet);
                tinhtongtien_1chitiet(chitiet);
            }
            catch
            {

            }
        }

        private void lbloithuduoc_Click(object sender, EventArgs e)
        {

        }

        private void btnctb_reload_Click(object sender, EventArgs e)
        {
            load_chitietban();
        }

        private void btnhdn_reload_Click(object sender, EventArgs e)
        {
           
            load_hoadonnhap();
        }

        private void btns_nhap_Click(object sender, EventArgs e)
        {
            load_searhHDNhap();
        }

        private void txt_s_year_n_TextChanged(object sender, EventArgs e)
        {
            string xet = this.txt_s_year_n.Text;
            if(xet!="")
            {
                txt_s_moth_n.Visible = true;
            }
            else
                txt_s_moth_n.Visible = false;


        }

        private void dtg_HoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int vitri = e.RowIndex;
                lbdoitac.Text = dtg_HoaDonNhap.Rows[vitri].Cells["cldoitac"].Value.ToString();
                txtnh_doitac.Text = lbdoitac.Text;
                lbnguoinhap.Text = dtg_HoaDonNhap.Rows[vitri].Cells["cltennhanvien"].Value.ToString();
                txtnh_nhanvien.Text = lbnguoinhap.Text;
                string chitiet = dtg_HoaDonNhap.Rows[vitri].Cells["clmahoadon"].Value.ToString();
                txtnh_mahd.Text = chitiet;
                //
                txtnh_ngay.Text = dtg_HoaDonNhap.Rows[vitri].Cells["clNgayNhap"].Value.ToString();
                DateTime dt = Convert.ToDateTime(txtnh_ngay.Text);
                txtbh_ngay.Text = dt.ToString("dd/MM/yyyy");
                //
                timchitiet_hoadonnhap(chitiet);
                tinhtongtien_1chitiet_n(chitiet);

            }
            catch
            {
                
            }
          
        }

        private void btnThuNho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnct_nhapReload_Click(object sender, EventArgs e)
        {
            load_chitietban_n();
        }

        private void dtg_chitietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int vitri = e.RowIndex;
                txtctb_mahd.Text = dtg_chitietHD.Rows[vitri].Cells["cl_mahd"].Value.ToString();
                txtctb_soluong.Text = dtg_chitietHD.Rows[vitri].Cells["cl_soluong"].Value.ToString();
                cbctb_tensanpham.SelectedValue = dtg_chitietHD.Rows[vitri].Cells["cl_tensp"].Value.ToString();
            }
            catch
            {

            }
        }

        private void dtg_chitietHD_n_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int vitri = e.RowIndex;
                txtctm_mahd.Text = dtg_chitietHD_n.Rows[vitri].Cells["clma"].Value.ToString();
                txtctm_soluong.Text = dtg_chitietHD_n.Rows[vitri].Cells["clsoluong"].Value.ToString();
                cbctm_tensp.SelectedValue = dtg_chitietHD_n.Rows[vitri].Cells["clsanpham"].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                // Bước 1: tạo biến để lưu thư mục cần tạo, tên thư mục cần tạo là "StoredFiles"
                string directoryPath = "D:\\data_cuahang";
                // Bước 2: kiểm tra nếu thư mục "StoredFiles" chưa tồn tại thì tạo mới
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                    cmd.CommandText = "backup database data_cuahang to disk = '" + directoryPath + "\\QLBH.bak'";
                }
                else
                {
                    cmd.CommandText = "backup database data_cuahang to disk = '" + directoryPath + "\\QLBH.bak with differential'";
                }
                
             
           
           
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Backup thành công. File lưu trữ trong folder:   "+directoryPath,"Thông báo!");
            if (conn.State == ConnectionState.Open) conn.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }



        }
        // các control cho button danh mục
        #region
        // điều khiển button -> hoạt động danh mục
        public void CTR_loaddanhmuc()
        {
            //hoạt động reset text và thêm 1 id cho danh mục

            btndm_them.Enabled = true;
            btndm_sua.Enabled = true;
            btndm_xoa.Enabled = true;
            btndm_luu.Enabled = false;
            btndm_huy.Enabled = false;
        }
        public void CTR_themdanhmuc()
        {
            //reset các text và tiến hành hoạt động thêm
            txtdm_madm.ResetText();
            txtdm_tendm.ResetText();
            dtg_danhmuc.Enabled = false;
            // ẩn button thêm,sửa,xoá chừa lại button huỷ
            btndm_them.Enabled = false;
            btndm_sua.Enabled = false;
            btndm_xoa.Enabled = false;
            btndm_luu.Enabled = true;
            btndm_huy.Enabled = true;
        }
        public void CTR_suadanhmuc()
        {
            btndm_them.Enabled = false;
            btndm_sua.Enabled = false;
            btndm_xoa.Enabled = false;
            btndm_luu.Enabled = true;
            btndm_huy.Enabled = true;
            dtg_danhmuc.Enabled = false;

        }
        public void CTR_xoadanhmuc()
        {
            btndm_them.Enabled = false;
            btndm_sua.Enabled = false;
            btndm_xoa.Enabled = false;
            btndm_luu.Enabled = true;
            btndm_huy.Enabled = true;
            dtg_danhmuc.Enabled = false;

        }
        public void CTR_huydanhmuc()
        {
            //load lại danhmuc
            //load_danhmuc();--> ko cần oad lại vì đã có reject channge
            btndm_them.Enabled = true;
            btndm_sua.Enabled = true;
            btndm_xoa.Enabled = true;
            btndm_luu.Enabled = false;
            btndm_huy.Enabled = false;
            dtg_danhmuc.Enabled = true;

        }
        #endregion
        // các control cho button sản phẩm ở mục sản phẩm
        #region

        public void xoaspsp()
        {

        }
        public void huythaotacsp()
        {

        }
        public void luuspsp()
        {

        }
        #endregion
        // các control tại loại sản phẩm-> nơi quy định các button và ngăn chặn click trong khi nhập dữ liệu
        #region
        public void ctr_loadloai()
        {
            dtg_loaisanpham.Enabled = true;
            btnloai_them.Enabled = true;
            btnloai_sua.Enabled = true;
            btnloai_xoa.Enabled = true;
            btnloai_luu.Enabled = false;
            btnloai_huy.Enabled = false;
        }
        public void ctr_themloai()
        {
            txtloai_ma.Text = nextsp();
            txtloai_ten.ResetText();
            txtloai_nhasx.ResetText();
            txtloai_baohanh.ResetText();
            txtloai_dvtinh.ResetText();
            txtloai_gianhap.ResetText();
            txtloai_giaban.ResetText();
            txtloai_soluong.ResetText();
            dtg_loaisanpham.Enabled = false;
            btnloai_them.Enabled = false;
            btnloai_sua.Enabled = false;
            btnloai_xoa.Enabled = false;
            btnloai_luu.Enabled = true;
            btnloai_huy.Enabled = true;
        }
        public void ctr_sualoai()
        {
            if(txtloai_ma.Text=="")
            {
                MessageBox.Show("Bạn phải chọn 1 loại sản phẩm để sửa nó!", "Thông báo!");
                return;
            }
            dtg_loaisanpham.Enabled = false;
            btnloai_them.Enabled = false;
            btnloai_sua.Enabled = false;
            btnloai_xoa.Enabled = false;
            btnloai_luu.Enabled = true;
            btnloai_huy.Enabled = true;
        }
       public void ctr_xoaloai()
        {
            if (txtloai_ma.Text == "")
            {
                MessageBox.Show("Bạn phải chọn 1 loại sản phẩm để xoá nó!", "Thông báo!");
                return;
            }
            dtg_loaisanpham.Enabled = false;
            btnloai_them.Enabled = false;
            btnloai_sua.Enabled = false;
            btnloai_xoa.Enabled = false;
            btnloai_luu.Enabled = true;
            btnloai_huy.Enabled = true;
        }
        public void ctr_huyl()
       {
           dtg_loaisanpham.Enabled = true;
           btnloai_them.Enabled = true;
           btnloai_sua.Enabled = true;
           btnloai_xoa.Enabled = true;
           btnloai_luu.Enabled = false;
           btnloai_huy.Enabled = false;
       }
        #endregion
        //-> các control cho hoá đơn
        public void  ctr_loadhd()
        {
            dtg_hoadon.Enabled = true;
            btnbh_huy.Enabled = false;
            btnbh_luu.Enabled = false;
            btnbh_sua.Enabled = true;
            btnbh_xoa.Enabled = true;
        }
        public void ctr_loadhd_nhap()
        {
            dtg_HoaDonNhap.Enabled = true;
            btnnh_huy.Enabled = false;
            btnnh_luu.Enabled = false;
            btnnh_sua.Enabled = true;
            btnnh_xoa.Enabled = true;
        }
        public void ctr_suanhd()
        {
            dtg_hoadon.Enabled = false;
            btnbh_huy.Enabled = true;
            btnbh_luu.Enabled = true;
            btnbh_sua.Enabled = false;
            btnbh_xoa.Enabled = false;
        }
        public void ctr_suanhd_nhap()
        {
            dtg_HoaDonNhap.Enabled = false;
            btnnh_huy.Enabled = true;
            btnnh_luu.Enabled = true;
            btnnh_sua.Enabled = false;
            btnnh_xoa.Enabled = false;
        }
        public void ctr_xoahd()
        {
            dtg_hoadon.Enabled = false;
            btnbh_huy.Enabled = true;
            btnbh_luu.Enabled = true;
            btnbh_sua.Enabled = false;
            btnbh_xoa.Enabled = false;
        }
        public void ctr_xoahd_nhap()
        {
            dtg_HoaDonNhap.Enabled = false;
            btnnh_huy.Enabled = true;
            btnnh_luu.Enabled = true;
            btnnh_sua.Enabled = false;
            btnnh_xoa.Enabled = false;
        }
        public void ctr_huyhd()
        {
            dtg_hoadon.Enabled = true;
            btnbh_huy.Enabled = false;
            btnbh_luu.Enabled = false;
            btnbh_sua.Enabled = true;
            btnbh_xoa.Enabled = true;
        }
        public void ctr_huyhd_nhap()
        {
            dtg_HoaDonNhap.Enabled = true;
            btnnh_huy.Enabled = false;
            btnnh_luu.Enabled = false;
            btnnh_sua.Enabled = true;
            btnnh_xoa.Enabled = true;
        }
        #region
        #endregion
        private void btndm_them_Click(object sender, EventArgs e)
        {
            flag_danhmuc = "them";
            CTR_themdanhmuc();
            txtdm_madm.Text = nextdm();
            txtdm_tendm.Focus();
        }

        private void btndm_sua_Click(object sender, EventArgs e)
        {
            flag_danhmuc = "sua";
            if(txtdm_madm.Text=="")
            {
                MessageBox.Show("Hãy chọn 1 danh mục để sửa!");
                return;
            }
            CTR_suadanhmuc();

        }

        private void btndm_xoa_Click(object sender, EventArgs e)
        {
            flag_danhmuc = "xoa";
            try
            {
                if (txtdm_madm.Text == "")
                {
                    MessageBox.Show("Hãy chọn 1 danh mục để xoá!");
                    return;
                }
                int vitri = dtg_danhmuc.CurrentCell.RowIndex;
                dtg_danhmuc.Rows.RemoveAt(vitri);


                // dtg_danhmuc.Rows.Remove();
                CTR_xoadanhmuc();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndm_luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // lấy data từ winform
                string ma = txtdm_madm.Text;
                string ten = txtdm_tendm.Text;
                //
                if(flag_danhmuc=="them")
                {

                    cmd.CommandText = "Insert into DanhMuc(idDM,TenDM) values('"+ma+"',N'"+ten+"')";

                }
                if(flag_danhmuc=="sua")
                {
                    cmd.CommandText = "Update DanhMuc SET TenDM=N'"+ten+"' WHERE idDM='"+ma+"'";

                }
                if(flag_danhmuc=="xoa")
                {
                    cmd.CommandText = "Delete DanhMuc where idDM=N'"+ma+"'";

                }

                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) conn.Close();

                dtg_danhmuc.Enabled = true;
                load_danhmuc();
                CTR_loaddanhmuc();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btndm_huy_Click(object sender, EventArgs e)
        {
            tbDanhMuc.RejectChanges();
            CTR_huydanhmuc();
            dtg_danhmuc.Enabled = true;

        }

        private void groupBox23_Enter(object sender, EventArgs e)
        {

        }

        private void dtg_loaisanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int v = e.RowIndex;
                click_one(v);
            }
            catch
            {

            }
        }
        // các hàm dụng để xử lí việc thêm mã 
        #region
        public string nextdm()
        {
            // lấy danh mục cuối và cộng thêm 1 cho nó-> có thể sẽ không cần kiểm tra kết nối
            try
            {
                string truyvan = "select DanhMuc.idDM from DanhMuc order by DanhMuc.idDM desc";
                SqlDataAdapter daget = new SqlDataAdapter(truyvan, conn);
                DataTable tbget = new DataTable();
                tbget.Clear();
                daget.Fill(tbget);
                int chiso = int.Parse(tbget.Rows[0][0].ToString());
                chiso++;
                return chiso.ToString();
            }
            catch
            {
                return "1";
            }

        }
        public string nextsp()
        {
            // lấy ap cuối cộng thêm 1
            try
            {

                string truyvan = "select Sanpham.idSp from Sanpham order by Sanpham.idSp desc";
                SqlDataAdapter daget = new SqlDataAdapter(truyvan, conn);
                DataTable tbget = new DataTable();
                tbget.Clear();
                daget.Fill(tbget);
                string get_sql = tbget.Rows[0][0].ToString();
                int chiso = int.Parse(get_sql);
                chiso++;
                return chiso.ToString();
            }
            catch
            {
                return "1";
            }
        }
        public string nexthoadon()
        {
            try {
                string truyvan = "select HoaDon.idHoaDon from HoaDon order by HoaDon.idHoaDon DESC";
                SqlDataAdapter daget = new SqlDataAdapter(truyvan, conn);
                DataTable tbget = new DataTable();
                tbget.Clear();
                daget.Fill(tbget);
                int chiso = int.Parse(tbget.Rows[0][0].ToString());
                chiso++;
                return chiso.ToString();
            }
            catch
            {
                return "1";
            }
        }
        // hoá đơn tiếp theo
        public string nexthoadonnhap()
        {
            string truyvan = "select HoaDonNhap.idHoaDon from HoaDonNhap order by HoaDonNhap.idHoaDon  DESC";
            SqlDataAdapter daget = new SqlDataAdapter(truyvan, conn);
            DataTable tbget = new DataTable();
            tbget.Clear();
            daget.Fill(tbget);
            int chiso = int.Parse(tbget.Rows[0][0].ToString());
            chiso++;
            return chiso.ToString();
        }
        // kiểm kê và tính tiền
        public void kiemke()
        {
            try
            {
                lb1_hangban.Text = "Số lượng hàng trong vỏ: " + listdsban.Items.Count.ToString();
                int tongtien = 0;
                for (int i = 0; i < listdsban.Items.Count; i++)
                {
                    int tien_each = int.Parse(listdsban.Items[i].SubItems[4].Text);
                    tongtien += tien_each;
                }

                string tongtienban = tongtien.ToString();
                float convert = float.Parse(tongtienban);
                tongtienban = String.Format("{0:0,0}",convert);
                lb1_tongtien.Text = "Tổng tiền bán: " + tongtienban;
                

            }
            catch
            {
                lb1_hangban.Text = "Vỏ hàng trống";
                lb1_tongtien.Text = "Chưa thể tính được tống tiền";
            }
        }
        // kiểm kê khi nhập hàng
        public void kiemke_nhap()
        {
            try
            {
                lb2_hangnhap.Text = "Số lượng hàng trong vỏ: " + listdsnhap.Items.Count.ToString();
                int tongtien = 0;
                for (int i = 0; i < listdsnhap.Items.Count; i++)
                {
                    int tien_each = int.Parse(listdsnhap.Items[i].SubItems[4].Text);
                    tongtien += tien_each;
                }
                string tongtiennhap = tongtien.ToString();
                float convert = float.Parse(tongtiennhap.ToString());
                tongtiennhap = string.Format("{0:0,0}",convert);
                lb2_tongtien.Text = "Tổng tiền nhập: " + tongtiennhap;

            }
            catch
            {
                lb2_hangnhap.Text = "Vỏ hàng trống";
                lb2_tongtien.Text = "Chưa thể tính được tống tiền";
            }
        }
        // kiểm tra mặt hàng trùng và xoá khỏi võ
        public void kiemtra_trung(string masp)
        {
            ListViewItem item = new ListViewItem();
            for(int i=0;i<listdsban.Items.Count;i++)
            {
                item = listdsban.Items[i];
                if(item.SubItems[0].Text==masp)
                {
                    listdsban.Items.RemoveAt(i);
                    MessageBox.Show("Bạn vừa cập nhật lại sản phẩm có mã là: " + masp, "Thông báo");
                    break;
                }
            }
           
        }
        // 
        // kiểm tra mặt hàng trùng và xoá khỏi kho dự định
        public void kiemtra_trung_nhap(string masp)
        {
            ListViewItem item = new ListViewItem();
            for (int i = 0; i < listdsnhap.Items.Count; i++)
            {
                item = listdsnhap.Items[i];
                if (item.SubItems[0].Text == masp)
                {
                    listdsnhap.Items.RemoveAt(i);
                    MessageBox.Show("Bạn vừa cập nhật lại sản phẩm có mã là: " + masp, "Thông báo");
                    break;
                }
            }

        }
        #endregion
        // tìm số lượng sản phẩm trong kho
        #region
        public void getSP_MA()
        {

        }
        #endregion
        private void btnloai_huy_Click(object sender, EventArgs e)
        {
            tbloaiSanPham.RejectChanges();
            ctr_huyl();
        }

        private void btnloai_them_Click(object sender, EventArgs e)
        {
            ctr_themloai();
            flag_loaisp = "them";

        }

        private void btnloai_sua_Click(object sender, EventArgs e)
        {
            ctr_sualoai();
            flag_loaisp = "sua";

        }

        private void btnloai_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                ctr_xoaloai();
                flag_loaisp = "xoa";
                int vitri = dtg_loaisanpham.CurrentCell.RowIndex;
                dtg_loaisanpham.Rows.RemoveAt(vitri);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnloai_luu_Click(object sender, EventArgs e)
        {
            try
            {
                string idsp = txtloai_ma.Text;
                string tensp = txtloai_ten.Text;
                string nhasx = txtloai_nhasx.Text;
                string bh = txtloai_baohanh.Text;
                string dvt = txtloai_dvtinh.Text;
                string gianhap = txtloai_gianhap.Text;
                string giaban = txtloai_giaban.Text;
                string danhmucsp = cbloai_dm.SelectedValue.ToString();
                string soluongsp = txtloai_soluong.Text;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                if(flag_loaisp=="them")
                {
                    cmd.CommandText = "Insert into Sanpham (idSp,Name,Nhasx,TimeBH,DonVi,GiaNhap,GiaBan,IdDanhMuc,SoLuong) values (N'"+idsp+"',N'"+tensp+"',N'"+nhasx+"',N'"+bh+"',N'"+dvt+"',N'"+gianhap+"',N'"+giaban+"',N'"+danhmucsp+"',N'"+soluongsp+"')";

                }
                if (flag_loaisp == "sua")
                {
                    cmd.CommandText = "Update Sanpham Set Name=N'"+tensp+"',Nhasx=N'"+nhasx+"',TimeBH=N'"+bh+"',DonVi=N'"+dvt+"',GiaNhap=N'"+gianhap+"',GiaBan=N'"+giaban+"',IdDanhMuc=N'"+danhmucsp+"',SoLuong=N'"+soluongsp+"' where idSp=N'"+idsp+"'";

                }
                if (flag_loaisp == "xoa")
                {
                    cmd.CommandText = "Delete Sanpham where idSp=N'"+idsp+"'";

                }
                cmd.ExecuteNonQuery();

                if (conn.State == ConnectionState.Open) conn.Close();
                ctr_loadloai();
                load_loaisp();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnloai_load_Click(object sender, EventArgs e)
        {
            load_loaisp();
        }

        private void txt1_masp_TextChanged(object sender, EventArgs e)
        {
            Sanpham_get sp = new Sanpham_get();
            sp.laydata(txt1_search.Text);
            txt1_masp.Text = sp.masp;
            txt1_tensp.Text = sp.tensp;
            string giaban = sp.dongia;
            txt1_giaban.Text = giaban;
            txt1_soluong.Text = sp.soluong;
        }

        private void btn1_themhang_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt1_masp.Text == "")
                {
                    MessageBox.Show("Sản phẩm định bán không tồn tại! Vui lòng kiểm tra lại!", "Thông báo");
                    return;
                }
              
                if(txtsoluongban.Text=="")
                {
                    MessageBox.Show("Bạn hãy nhập số lượng hàng mà bạn muốn bán!","Thông báo");
                    return;
             
                }
                int dinhban = int.Parse(txtsoluongban.Text);
                int kho = int.Parse(txt1_soluong.Text);
                if (dinhban <= 0)
                {
                    MessageBox.Show("Số lượng hàng mà bạn muốn bán phải lớn hơn 0!", "Thông báo!");
                    return;
                }
                if (dinhban > kho)
                {
                    MessageBox.Show("Số lượng hàng trong kho ít hơn số lượng mà bạn muốn bán! Vui lòng kiểm tra lại!", "Thông báo!");
                    return;
                }
                kiemtra_trung(txt1_masp.Text);
                // bắt hết tất cả cac sự kiện lỗi 
                ListViewItem item = new ListViewItem();
                item.Text = txt1_masp.Text;
                listdsban.Items.Add(item);
                item.SubItems.Add(txt1_tensp.Text);
                item.SubItems.Add(txt1_giaban.Text);
                item.SubItems.Add(txtsoluongban.Text);
                int tien = int.Parse(txt1_giaban.Text) * int.Parse(txtsoluongban.Text);
                item.SubItems.Add(tien.ToString());
                txt1_search.Text = "";
                txtsoluongban.Text = "";
                // kiểm kê tính tiền
                kiemke();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi nhập:"+ex.Message);
            }
        }

        private void txtsoluongban_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int kho = int.Parse(txt1_soluong.Text);
                int ban = int.Parse(txtsoluongban.Text);
                if (ban > kho)
                {
                    MessageBox.Show("Bạn không thể bán quá số lượng mà kho có!");
                    txtsoluongban.Text = kho.ToString();
                    return;
                }
            }
            catch
            {

            }
        }

        private void btnHuyGiaoDich_Click(object sender, EventArgs e)
        {
            try
            {
                listdsban.Items.Clear();
                lb1_tongtien.ResetText();
                lb1_hangban.ResetText();
                khoa_hoadonban = false;
                TAbMain.Controls.Remove(tabbanhangk);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnhd_Taohd_Click(object sender, EventArgs e)
        {
            bool tao = false;
            frBanHang banhang = new frBanHang(id);
            banhang.ShowDialog();
           // this.TAbMain.Controls.Clear();        
            //
            tao = banhang.ban;
            load_hoadon();
            if(tao==true)
            {
                this.TAbMain.Controls.Add(this.tabbanhangk);
                this.TAbMain.SelectedTab = this.tabbanhangk;
                txt1_nguoiban.Text = id;
                txt1_khachhang.Text = banhang.khachhang;
                txt1_ngaytao.Text = banhang.ngaytao;
                txt1_mahd.Text = banhang.mahd;
                khoa_hoadonban = true;
               
            }
        }

        private void btn1_xoa_Click(object sender, EventArgs e)
        {
            try
            {

                int vitri = listdsban.SelectedIndices[0];
                ListViewItem item = listdsban.Items[vitri];// vị trí select
                listdsban.Items.Remove(item);
                kiemke();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá:"+"Đảm bảo bạn đã chọn mặt hàng xoá\n hoặc vỏ hàng của bạn không trống!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
        }

        private void btnGiaodich_Click(object sender, EventArgs e)
        {
            try
            {
                List<ChitietHD> ct = new List<ChitietHD>();

                for (int i = 0; i < listdsban.Items.Count;i++ )
                {
                    ListViewItem item = new ListViewItem();
                    item = listdsban.Items[i];
                    ct.Add(new ChitietHD(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text));
                }
                    khoa_hoadonban = false;
               
                frChiTietHD cthd = new frChiTietHD(txt1_mahd.Text,txt1_nguoiban.Text,txt1_khachhang.Text,ct);
                // lưu số lượng sản phẩm xuống csdl
                Sanpham_get laysp = new Sanpham_get();
                int spkho = 0;
                int spban = 0;
                int conlai = 0;

                for (int i = 0; i < listdsban.Items.Count; i++)
                {

                   laysp.laydata(listdsban.Items[i].SubItems[0].Text);
                    spkho = int.Parse(laysp.soluong);
                    spban = int.Parse(listdsban.Items[i].SubItems[3].Text);
                    conlai = spkho - spban;
                    laysp.save_data(listdsban.Items[i].SubItems[0].Text, conlai.ToString());
                }
                // lưu chi tiết hoá đơn xuống csdl mhd,msp,sl
                for (int i = 0; i < listdsban.Items.Count; i++)
                {
                    laysp.save_ct(txt1_mahd.Text, listdsban.Items[i].SubItems[0].Text, listdsban.Items[i].SubItems[3].Text);
                    
                }
                cthd.ShowDialog();
                this.TAbMain.Controls.Remove(this.tabbanhangk);
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TAbMain_TabIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void tabbanhangk_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void TAbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (khoa_hoadonban == true&&this.TAbMain.SelectedTab!=tabbanhangk)
            {
                this.TAbMain.SelectedTab = this.tabbanhangk;
                MessageBox.Show("Bạn chưa thực hiện hành động giao dịch??");
                return;
            }
             */
        }

        private void btnbh_sua_Click(object sender, EventArgs e)
        {
            if(txtbh_mahd.Text=="")
            {
                MessageBox.Show("Hãy chọn một hoá đơn để tiến hành sửa!");
                return;
            }
            flag_hoadon = "sua";
            ctr_suanhd();

        }

        private void btnbh_xoa_Click(object sender, EventArgs e)
        {
            if(txtbh_mahd.Text=="")
            {
                MessageBox.Show("Hãy chọn một hoá đơn để tiến hành xoá!");
                return;
            }
            int vitri = dtg_hoadon.CurrentCell.RowIndex;
            dtg_hoadon.Rows.RemoveAt(vitri);
            flag_hoadon = "xoa";
            ctr_xoahd();
        }

        private void btnbh_huy_Click(object sender, EventArgs e)
        {
            ctr_huyhd();
            tbHoaDon.RejectChanges();
        }

        private void btnbh_luu_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                string mahd = txtbh_mahd.Text;
                string tenkhach = txtbh_khachhang.Text;
                string ngay = txtbh_ngay.Text;
                string []dates = ngay.Split('/');
                string dayluu = dates[1] +"/"+ dates[0] + "/"+dates[2];
                if(flag_hoadon=="sua")
                {
                    cmd.CommandText = "update HoaDon Set TenKH=N'"+tenkhach+"',NgayBan=N'"+dayluu+"' WHERE idHoaDon=N'"+mahd+"'";
                }
                if(flag_hoadon=="xoa")
                {
                    cmd.CommandText = "delete HoaDon WHERE idHoaDon=N'"+mahd+"'";
                }
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) conn.Close();
                //
                ctr_loadhd();
                load_hoadon();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnnh_luu_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                string mahd = txtnh_mahd.Text;
                string doitac = txtnh_doitac.Text;
                string ngay = txtbh_ngay.Text;
                string[] dates = ngay.Split('/');
                string dayluu = dates[1] + "/" + dates[0] + "/" + dates[2];
                if (flag_hoadon_nhap == "sua")
                {
                    cmd.CommandText = "update HoaDonNhap set TenDT =N" + doitac + "',NgayMua=N'" + dayluu + "'  WHERE idHoaDon=N'" + mahd + "'";
                }
                if (flag_hoadon_nhap == "xoa")
                {
                    cmd.CommandText = "delete HoaDonNhap where idHoaDon=N'" + mahd + "'";
                }
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) conn.Close();
                //
                ctr_loadhd_nhap();
                this.load_hoadonnhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnnh_taohoadon_Click(object sender, EventArgs e)
        {
            
            bool tao = false;
            frBanHang banhang = new frBanHang(id);//---
            frNhapHang nhaphang = new frNhapHang(id);//
            nhaphang.ShowDialog();       
            tao = nhaphang.nhaphang;
            load_hoadonnhap();
            if (tao == true)
            {
                this.TAbMain.Controls.Add(this.tabnhaphangve);
                this.TAbMain.SelectedTab = this.tabnhaphangve;
                //txt1_nguoiban.Text = id;
                txt2_nhanvien.Text = id;
               // txt1_khachhang.Text = banhang.khachhang;
                txt2_doitac.Text = nhaphang.doitac;
              //  txt1_ngaytao.Text = banhang.ngaytao;
                txt2_ngaytao.Text = nhaphang.ngaytao;
               // txt1_mahd.Text = banhang.mahd;
                txt2_mahd.Text = nhaphang.mahd;
               // khoa_hoadonban = true;

            }
        }

        private void txt2_mahang_TextChanged(object sender, EventArgs e)
        {
            Sanpham_get sp = new Sanpham_get();
            sp.laydata_nhap(txt2_search.Text);
            txt2_masp.Text = sp.masp;
            txt2_tensp.Text = sp.tensp;
            txt2_gianhap.Text = sp.dongia;
            txt2_soluong.Text = sp.soluong;
              
        }

        private void txt2_soluongnhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txt2_soluongnhap.Text=="")
                {
                    return;
                }
                int soluong = int.Parse(txt2_soluongnhap.Text);
                if(soluong<=0)
                {
                    MessageBox.Show("Bạn nên nhập số lượng sản phẩm nhiều hơn 0!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txt2_soluongnhap.ResetText();
                    txt2_soluongnhap.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi nhập :Hãy đảm bảo bạn đã nhập số- "+ex.Message);
                txt2_soluongnhap.ResetText();
            }
        }

        private void btn2_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt2_masp.Text == "")
                {
                    MessageBox.Show("Sản phẩm định bán không tồn tại! Vui lòng kiểm tra lại!", "Thông báo");
                    return;
                }

                if (txt2_soluongnhap.Text == "")
                {
                    MessageBox.Show("Bạn hãy nhập số lượng hàng mà bạn muốn nhập!", "Thông báo");
                    return;

                }
                int dinhnhap = int.Parse(txt2_soluongnhap.Text);
                int kho = int.Parse(txt2_soluong.Text);
                
               
                kiemtra_trung_nhap(txt2_masp.Text);
                // bắt hết tất cả cac sự kiện lỗi 
                ListViewItem item = new ListViewItem();
                item.Text = txt2_masp.Text;
                listdsnhap.Items.Add(item);
                item.SubItems.Add(txt2_tensp.Text);
                item.SubItems.Add(txt2_gianhap.Text);
                item.SubItems.Add(txt2_soluongnhap.Text);
                int tien = int.Parse(txt2_gianhap.Text) * int.Parse(txt2_soluongnhap.Text);
                item.SubItems.Add(tien.ToString());
                txt2_search.Text = "";
                txt2_soluongnhap.Text = "";
                // kiểm kê tính tiền
                kiemke_nhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập:" + ex.Message);
            }
        }

        private void btn2_xoa_Click(object sender, EventArgs e)
        {
            try
            {

                int vitri = listdsnhap.SelectedIndices[0];
                ListViewItem item = listdsnhap.Items[vitri];// vị trí select
                listdsnhap.Items.Remove(item);
                kiemke_nhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá:" + "Đảm bảo bạn đã chọn mặt hàng xoá\n hoặc vỏ hàng của bạn không trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btn2_giaodich_Click(object sender, EventArgs e)
        {
            try
            {
                listdsnhap.Items.Clear();
                lb2_tongtien.ResetText();
                lb2_hangnhap.ResetText();
               // khoa_hoadonban = false;
                TAbMain.Controls.Remove(tabnhaphangve);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn2_huygiaodich_Click(object sender, EventArgs e)
        {
            
            try
            {
                List<ChitietHD> ct = new List<ChitietHD>();

                for (int i = 0; i < listdsnhap.Items.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item = listdsnhap.Items[i];
                    ct.Add(new ChitietHD(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text));
                }
                //khoa_hoadonban = false;

               frChiTietHDNHAP cthd = new frChiTietHDNHAP(txt2_mahd.Text, txt2_nhanvien.Text, txt2_doitac.Text, ct);
                // lưu số lượng sản phẩm xuống csdl
                Sanpham_get laysp = new Sanpham_get();
                int spkho = 0;
                int spnhap = 0;
                int vaokho = 0;

                for (int i = 0; i < listdsnhap.Items.Count; i++)
                {

                    laysp.laydata_nhap(listdsnhap.Items[i].SubItems[0].Text);
                    spkho = int.Parse(laysp.soluong);
                    spnhap = int.Parse(listdsnhap.Items[i].SubItems[3].Text);
                      vaokho = spkho +spnhap;
                    laysp.save_data(listdsnhap.Items[i].SubItems[0].Text, vaokho.ToString());
                }
                // lưu chi tiết hoá đơn xuống csdl mhd,msp,sl
                for (int i = 0; i < listdsnhap.Items.Count; i++)
                {
                    laysp.save_ctNhap(txt2_mahd.Text, listdsnhap.Items[i].SubItems[0].Text, listdsnhap.Items[i].SubItems[3].Text);

                }
                 cthd.ShowDialog();
                this.TAbMain.Controls.Remove(this.tabnhaphangve);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        private void btnnh_sua_Click(object sender, EventArgs e)
        {
            if (txtnh_mahd.Text == "")
            {
                MessageBox.Show("Hãy chọn một hoá đơn để tiến hành sửa!");
                return;
            }
            flag_hoadon_nhap = "sua";
            ctr_suanhd_nhap();
        }

        private void btnnh_xoa_Click(object sender, EventArgs e)
        {
            if (txtnh_mahd.Text == "")
            {
                MessageBox.Show("Hãy chọn một hoá đơn để tiến hành xoá!");
                return;
            }
            int vitri = dtg_HoaDonNhap.CurrentCell.RowIndex;
            dtg_HoaDonNhap.Rows.RemoveAt(vitri);
            flag_hoadon_nhap = "xoa";
            ctr_xoahd_nhap();
        }

        private void btnnh_huy_Click(object sender, EventArgs e)
        {
            ctr_huyhd();
            this.tbHoaDonNhap.RejectChanges();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btn3_reload_Click(object sender, EventArgs e)
        {
            load_doanhthu();

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn3_search_Click(object sender, EventArgs e)
        {
            try
            {

                //tiền hành xử lí các truy vấn
                string nam = "";
                string thang = "";
                string nhanvien = "";
                string subtruyvan="";
                string sub1 = "";
                string sub2 = "";
                string sub3 = "";
                if(txt3_nam.Text!="")
                {
                    nam = txt3_nam.Text;
                    sub1 = "and YEAR(NgayBan)='" + nam + "'";     
                }
               
                if(txt3_thang.Text!="")
                {
                    thang = txt3_thang.Text;
                    sub2 = " and MONTH(NgayBan)='" + thang + "'";
                }
               
                if(cb3_locnhanvien.Checked==true)
                {
                    nhanvien = txt3_nhanvien.Text;
                    sub3 = "and idNhanvien=N'"+nhanvien+"'";
                }
               
                //
                if (conn.State == ConnectionState.Closed)
                    conn.Open();


                subtruyvan = sub1 + sub2 + sub3;
                string truyvan = "select HoaDon.idHoaDon,HoaDon.idNhanvien,SUM(GiaBan*ChiTietHoaDon.SoLuong) as tienban,SUM(GiaNhap*ChiTietHoaDon.SoLuong) as tienvon,HoaDon.NgayBan  FROM ChiTietHoaDon,HoaDon,Sanpham where ChiTietHoaDon.idSp=Sanpham.idSp and  HoaDon.idHoaDon=ChiTietHoaDon.idMaHD  "+subtruyvan+" group by HoaDon.idHoaDon,HoaDon.idNhanvien,HoaDon.NgayBan order by HoaDon.idHoaDon desc";
                SqlDataAdapter dadoanhthu = new SqlDataAdapter(truyvan, conn);
                DataTable tabdoanhthu = new DataTable();
                tabdoanhthu.Clear();
                dadoanhthu.Fill(tabdoanhthu);
                dtg_doanhthu.DataSource = tabdoanhthu;
                if (conn.State == ConnectionState.Open) conn.Close();
                uoctinh_doanhthu();
            }
            catch
            {
                MessageBox.Show("Lỗi ! Không tìm thấy doanh thu mà bạn yêu cầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt3_nam_TextChanged(object sender, EventArgs e)
        {
            if (txt3_nam.Text != "")
            {
                txt3_thang.Visible = true;
            }
            else
                txt3_thang.Visible = false;
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            this.pic4.Visible = false;
        }

        private void btndm_rgc1_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog _PrintDialog = new PrintDialog();
                PrintDocument _PrintDocument = new PrintDocument();

                _PrintDialog.Document = _PrintDocument; //add the document to the dialog box

               // _PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(_CreateReceipt); //add an event handler that will do the printing
                //on a till you will not want to ask the user where to print but this is fine for the test envoironment.
                DialogResult result = _PrintDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _PrintDocument.Print();
                }
            }
            catch (Exception)
            {

            }
        }



    }
}

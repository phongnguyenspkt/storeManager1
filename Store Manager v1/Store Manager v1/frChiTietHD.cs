using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;




namespace Store_Manager_v1
{
    public partial class frChiTietHD : Form
    {
        string nhanvien = "";
        string khachhang = "";
        string mahd = "";
        List<ChitietHD> ct = new List<ChitietHD>();
        public frChiTietHD(string _mahd, string _nv, string _kh, List<ChitietHD> _ct)
        {
            mahd = _mahd;
            nhanvien = _nv;
            khachhang = _kh;
            ct = _ct;
            InitializeComponent();
        }
        //string _mahd,string _nv,string _kh,List<ChitietHD> _ct
        private void frChiTietHD_Load(object sender, EventArgs e)
        {
            lbhoadon.Text = mahd;
            lbnhanvien.Text = nhanvien;
            lbkhachhang.Text = khachhang;
            int tongtien = 0;
            for(int i=0;i<ct.Count;i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ct[i].mah;
                lisban.Items.Add(item);
                item.SubItems.Add(ct[i].tenh);
                item.SubItems.Add(ct[i].dongia);
                item.SubItems.Add(ct[i].soluong);
                item.SubItems.Add(ct[i].tongcong);
                tongtien += int.Parse(ct[i].soluong) * int.Parse(ct[i].dongia);
                 
            }
            string final_monney = tongtien.ToString();
            float convert = float.Parse(final_monney);
            final_monney = string.Format("{0:0,0}",convert);
            lbtongtien.Text = final_monney;

         
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

            try
            {
                PrintDialog _PrintDialog = new PrintDialog();
                PrintDocument _PrintDocument = new PrintDocument();

                _PrintDialog.Document = _PrintDocument; //add the document to the dialog box

                _PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(_CreateReceipt); //add an event handler that will do the printing
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

        
        // in
      private void _CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            Font font = new Font("Courier New", 12);
            float FontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int offset = 40;
            MessageBox.Show("show");
            graphic.DrawImage(global::Store_Manager_v1.Properties.Resources.qt, 0, 0);
            graphic.DrawString("----VI TÍNH QUỐC TOÀN----"+"", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            string top = "Tên Sản Phẩm".PadRight(24) + "Thành Tiền";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight; //make the spacing consistent
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight + 5; //make the spacing consistent

            foreach (ListViewItem item in lisban.Items)
            {
                ListViewItem _item = new ListViewItem();
                _item = item;
                graphic.DrawString(item.SubItems[1].Text, font, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString(item.SubItems[4].Text, font, new SolidBrush(Color.Black), startX + 250, startY + offset);
                offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            }

            offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("TỔNG TIỀN TRẢ ", new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString(lbtongtien.Text, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 250, startY + offset);

            offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            graphic.DrawString("TIỀN MẶT ", font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString(lbtongtien.Text, font, new SolidBrush(Color.Black), startX + 250, startY + offset);

            offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            graphic.DrawString("TIỀN TRẢ ", font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString(lbtongtien.Text, font, new SolidBrush(Color.Black), startX + 250, startY + offset);

            offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            graphic.DrawString(" CẢM ƠN BẠN ĐÃ GHÉ THĂM!,", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            graphic.DrawString("HI VỌNG BẠN SẼ GHÉ THĂM LẠI!", font, new SolidBrush(Color.Black), startX, startY + offset);
           offset = offset + (int)FontHeight + 5; //make the spacing consistent      
            graphic.DrawString(@"Đc: 90 nguyễn thị sáu, p. Thạnh lộc", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight + 5; //make the spacing consistent      
            graphic.DrawString(@"       Q. 12 Đt: 0937432071 - 098 8271338", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight + 5; //make the spacing consistent      
            graphic.DrawString(@"Mã hoá đơn:" + lbhoadon.Text, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
        }

    }
}

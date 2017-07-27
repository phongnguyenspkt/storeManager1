using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store_Manager_v1
{
    public class ChitietHD
    {
        public string mah;
        public string tenh;
        public string soluong;
        public string dongia;
        public string tongcong;
        public ChitietHD(string ma,string ten,string dongia,string soluong,string tongcong)
        {
            this.mah = ma;
            this.tenh = ten;
            this.soluong = soluong;
            this.dongia = dongia;
            this.tongcong = tongcong;
        }
    }
}

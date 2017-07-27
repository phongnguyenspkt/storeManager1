using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Store_Manager_v1
{
    public class Get_database
    {
        public string ketnoi()
        {
            StreamReader sr = new StreamReader("c:\\database.rrc");
            string a;
            a = sr.ReadLine();//dòng 1 số các tiến trình
            return a;
        }
    }
    

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store_Manager_v1
{
    class Get_Date
    {
        public Get_Date()
        {

        }
        public string Get_Day()
        {
            string str = DateTime.Now.ToString().Trim();
            str = str.Substring(0, 2);
            return str;
        }
        public string Get_Month()
        {
            string str = DateTime.Now.ToString().Trim();
            str = str.Substring(3, 2);
            return str;
        }
        public string Get_Year()
        {
            string str = DateTime.Now.ToString().Trim();
            str = str.Substring(6, 4);
            return str;
        }
    }
}

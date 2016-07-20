using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall.Models
{
    public class AdminUser
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public BitArray Permission { set; get; }
    }
    public class Permission
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Control { set; get; }
        public string Action { set; get; }
        public int Power { set; get; }
        public bool IsEnabled { set; get; }
    }
}

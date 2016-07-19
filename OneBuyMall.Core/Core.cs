using OneBuyMall.DAL;
using OneBuyMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall
{
    public partial class Core
    {
        private static Configs SiteConfig;
        public Core(string conn)
        {
            DBHelper._connStr = conn; 
        }
    }
}

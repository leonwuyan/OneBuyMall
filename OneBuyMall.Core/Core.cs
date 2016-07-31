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
        private static Random Rnd;
        public static List<Permission> AdminPermissions;
        public Core(string conn)
        {
            DBHelper._connStr = conn;
            Rnd = new Random();
            AdminPermissions = GetAllPermission();
        }
    }
}

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
        public List<AdminUser> GetAdminUsers()
        {
            return new List<AdminUser>();
        }
        public AdminUser GetAdminUser(int ID)
        {
            return new AdminUser();
        }
        public List<KeyValuePair<string,bool>> PermissionParse(int p)
        {

            return new List<KeyValuePair<string, bool>>();
        }
        public List<Permission> GetAllPermission()
        {
            var data = new List<Permission> { 
                new Permission{ ID=1, Name="站点管理", Control="admin", Action="configs", Power=1, IsEnabled=false },
                new Permission{ ID=2, Name="站点管理1", Control="admin", Action="configs", Power=2, IsEnabled=false },
                new Permission{ ID=3, Name="站点管理2", Control="admin", Action="configs", Power=4, IsEnabled=false },
                new Permission{ ID=4, Name="站点管理3", Control="admin", Action="configs", Power=8, IsEnabled=false },
                new Permission{ ID=5, Name="站点管理4", Control="admin", Action="configs", Power=16, IsEnabled=false }
            };
            return data;
        }
    }
}

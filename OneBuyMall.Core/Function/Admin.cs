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
        public List<AdminUser> GetAdminUsers()
        {
            var ret = new List<AdminUser>();
            var admins = db_onebuymall.tb_admin.Select();
            foreach(var admin in admins)
            {
                ret.Add(new AdminUser {
                    ID = admin.id,
                    Name = admin.name,
                    Permission = admin.permission.toBitArray()
                });
            }
            return ret;
        }
        public AdminUser GetAdminUser(int ID)
        {
            var admin = db_onebuymall.tb_admin.Select(
                new db_onebuymall.tb_admin { id=ID },
                null,
                new db_onebuymall.e_tb_admin[]{db_onebuymall.e_tb_admin.id}
                ).FirstOrDefault();
            if (admin != null)
            {
                return new AdminUser
                {
                    ID= admin.id,
                    Name = admin.name,
                    Permission = admin.permission.toBitArray()
                };
            }
            return null;
        }
        public List<KeyValuePair<string,bool>> PermissionParse(int p)
        {
            var userPerm = new List<KeyValuePair<string, bool>>();
            for( int i =0; i< AdminPermissions.Count;++i)
            {
                var tmp = p.toBitArray();
                userPerm.Add(new KeyValuePair<string, bool>(AdminPermissions[i].Name, tmp[i]));
            }
            return new List<KeyValuePair<string, bool>>();
        }
        public List<Permission> GetAllPermission()
        {
            var adminps = new List<Permission>();
            var ps = db_onebuymall.tb_admin_permission.Select();
            foreach(var p in ps)
            {
                adminps.Add(new Permission
                {
                    ID = p.id,
                    Name = p.name,
                    Control = p.control,
                    Action = p.action,
                    Power = p.permission,
                    IsEnabled = p.isenabled
                });
            }
            return adminps;
        }
    }
}

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
        public Helper GetHelperContent(int gid,int id)
        {
            var data = db_onebuymall.tb_help.Select(new db_onebuymall.tb_help { groupid = gid, id = id }, null, new db_onebuymall.e_tb_help[] { db_onebuymall.e_tb_help.groupid, db_onebuymall.e_tb_help.id }).FirstOrDefault();
            if(data != null)
            {
                return new Helper { 
                    ID = data.id,
                    Title = data.title,
                    Content = data.content
                };
            }
            return null;
        }
    }
}

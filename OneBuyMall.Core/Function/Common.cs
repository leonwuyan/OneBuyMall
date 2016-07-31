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
        public Configs LoadConfigs()
        {
            if (SiteConfig == null)
            {
                var dbconfig = db_onebuymall.tb_config.Select().FirstOrDefault();
                if (dbconfig != null)
                {
                    SiteConfig = new Configs { ID = dbconfig.id, SiteName = dbconfig.sitename, Keywords = dbconfig.keywords, Desc = dbconfig.desc };
                }
            }
            return SiteConfig;
        }
        public HRESULT UpdateConfigs(Configs config)
        {
            var dbconfig = new db_onebuymall.tb_config
            {
                id= config.ID,
                desc = config.Desc,
                keywords = config.Keywords,
                sitename = config.SiteName
            };
            var ret = db_onebuymall.tb_config.Update(dbconfig);
            if(ret == 1)
            {
                SiteConfig = config;
                return HRESULT.Success;
            }
            return HRESULT.Fail;
        }
        public void CartMerge(List<CartItemBase> l1, List<CartItemBase> l2)
        {
            foreach(var i1 in l1)
            {
                foreach(var i2 in l2 )
                {
                    if(i1.Store == i2.Store && i1.GoodsID == i2.GoodsID)
                    {
                        i1.Count += i2.Count;
                        //更新数据库
                        break;
                    }
                }
            }
        }
    }
}

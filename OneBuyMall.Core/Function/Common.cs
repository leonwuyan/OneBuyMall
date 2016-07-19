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
                var dbconfig = db_tb_config.Select().FirstOrDefault();
                if (dbconfig != null)
                {
                    SiteConfig = new Configs { ID = dbconfig.id, SiteName = dbconfig.sitename, Keywords = dbconfig.keywords, Desc = dbconfig.desc };
                }
            }
            return SiteConfig;
        }
        public HRESULT UpdateConfigs(Configs config)
        {
            var dbconfig = new db_tb_config.tb_config
            {
                id= config.ID,
                desc = config.Desc,
                keywords = config.Keywords,
                sitename = config.SiteName
            };
            var ret = db_tb_config.Update(dbconfig);
            if(ret == 1)
            {
                SiteConfig = config;
                return HRESULT.Success;
            }
            return HRESULT.Fail;
        }
    }
}

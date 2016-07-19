using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall.Models
{
    public class Configs
    {
        public int ID { set; get; }
        public string SiteName { set; get; }
        public string Keywords { set; get; }
        public string Desc { set; get; }
    }
    public class Result
    {
        public string msg { set; get; }
        public int status { set; get; }
        public string url { set; get; }
    }
}

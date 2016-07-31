using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall.Models
{
    public class GoodsGroup
    {
        public int ID { set; get; }
        public string Name { set; get; }
    }
    public class Goods
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int Price { set; get; }
        public string Desc { set; get; }
        public string Intro { set; get; }
        public List<string> Images { set; get; }
    }
    public class OneStoreItem : Goods
    {
        public string Issue { set; get; }
        public int Total { set; get; }
        public int Sold { set; get; }
        public List<IndianaLog> IndianaLog { set; get; }
        public List<ShareDetail> Share { set; get; }
        public List<GoodsIssue> LastIssue { set; get; }
    }
}

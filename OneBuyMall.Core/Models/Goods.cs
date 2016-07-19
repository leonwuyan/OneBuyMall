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
}

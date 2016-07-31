using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall.Models
{
    public class HelperBase
    {
        public int ID{set;get;}
        public string Title { set; get; }
    }
    public class Helper : HelperBase
    {
        public string Content { set; get; }
    }
    public class HelperGroup
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public List<HelperBase> Children { set; get; }
    }
}

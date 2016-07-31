using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneBuyMall.Models
{
    public class CartItemBase
    {
        public Core.eStore Store { set; get; }
        public int GoodsID { set; get; }
        public int Count { set; get; }
    }
    public class CartItem : CartItemBase
    {
        public string Icon { set; get; }
        public string Name { set; get; }
        public int Price { set; get; }
        public int Unit { set; get; }
    }
}

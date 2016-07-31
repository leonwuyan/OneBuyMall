using OneBuyMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneBuyMall.WebSite.Models
{
    public class Customer
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string HeaderImg { set; get; }
        public List<CartItemBase> Cart { set; get; }
    }
}
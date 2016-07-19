using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneBuyMall.Models;

namespace OneBuyMall.WebSite.Models
{
    public class GoodsBuyLog
    {
        public DateTime Buytime { set; get; }
        public int Userid { set; get; }
        public string Username { set; get; }
        public string Addr { set; get; }
        public string IP { set; get; }
        public string BuyNums { set; get; }
    }
    public class GoodsShow
    {
        public Customer Customer { set; get; }
        public string Title { set; get; }
        public DateTime Notetime { set; get; }
        public string Content { set; get; }
    }
    public class LastIssue
    {
        public int ID { set; get; }
        public string Issue { set; get; }
        public Customer LukyCustomer { set; get; }
        public string LukyNumber { set; get; }
        public DateTime EndTime { set; get; }
        public DateTime LotteryTime { set; get; }
    }
    public class GoodsPageData
    {
        public Goods goods { set; get; }
        public List<GoodsBuyLog> Buylogs { set; get; }
        public List<GoodsShow> GoodsShows { set; get; }

    }
}
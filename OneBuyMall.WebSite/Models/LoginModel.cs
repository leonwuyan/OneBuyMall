using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneBuyMall.WebSite.Models
{
    public class PostBackModel
    {
        public int status { set; get; }
        public string msg { set; get; }
    }
    public class LoginModel : PostBackModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string CheckCode { set; get; }
    }
}
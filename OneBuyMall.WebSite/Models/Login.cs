using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneBuyMall.WebSite.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "用户名")]
        [Remote("CheckUserName","Home")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }


        [Display(Name = "下次自动登陆")]
        public bool RememberMe { get; set; }
    }  
}
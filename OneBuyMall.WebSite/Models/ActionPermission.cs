using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneBuyMall.WebSite
{
    public class ActionPermission
    {
        public string ActionName { set; get; }
        public string ControllerName { set; get; }
        public string Description { set; get; }
    }
}
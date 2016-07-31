using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneBuyMall.WebSite.Controllers
{
    public class HelperController : Controller
    {
        public ActionResult Index(int gid, int id)
        {
            var _gid = gid;
            var _id = id;
            var data = MvcApplication.core.GetHelperContent(gid, id);
            return View(data);
        }

    }
}

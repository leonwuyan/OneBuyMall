using OneBuyMall.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneBuyMall.WebSite.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var list = Common.GetAllActionByAssembly();
            MvcApplication.core.LoadConfigs();
            return View();
        }
        public ActionResult Login(LoginModel user = null)
        {
            //if (user == null)
            //{
            //    return View();
            //}
            //if (MvcApplication.core.Login(user.Username, user.Password) == Core.HRESULT.Success)
            //{
            //    if (string.IsNullOrEmpty(Request["url"]))
            //    {
            //        return View("Index");
            //    }
            //    else
            //    {
            //        Response.Redirect(Request["url"]);
            //        return null;
            //    }
            //}
            //else
            //{
            //    return View(user);
            //}
            return View();
        }
        public JsonResult CheckUserName(string UserName)
        {
            bool result = true;
            if (UserName == "admin")
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Register()
        {
            ViewData["channel"] = Request["c"];

            return View();
        }
        public ActionResult List(int group=0)
        {
            return View();
        }
        public ActionResult Detail(int issue=0)
        { 
            var item = MvcApplication.core.GetOneStoreItem(issue);

            return View(); 
        }
    }
}

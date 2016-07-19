using OneBuyMall.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneBuyMall.WebSite.Controllers
{
    public class HomeController : Controller
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
            if (user == null)
            {
                return View();
            }
            if (MvcApplication.core.Login(user.Username, user.Password) == Core.HRESULT.Success)
            {
                return View("Home");
            }
            else
            {
                return View(user);
            }
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}

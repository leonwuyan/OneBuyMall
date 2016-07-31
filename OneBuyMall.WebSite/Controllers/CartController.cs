using OneBuyMall.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneBuyMall.WebSite.Controllers
{
    public class CartController : BaseController
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            Session.Clear();
            if(Session["customer"] == null)
            {
                Response.Redirect("~/Login.shtml?url=cart/index.shtml");
                return null;
            }
            //var customer = (Customer)Session["customer"];
            //var cartlist = MvcApplication.core.GetCardItems(customer.ID);
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
    }
}

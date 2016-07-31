using OneBuyMall.Models;
using OneBuyMall.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneBuyMall.WebSite.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            //设置Cookie
            //HttpCookie cookie = new HttpCookie("isCookie");
            HttpCookie cart = new HttpCookie("cart");
            //cookie.Value = "yes";
            cart.Value = (new List<CartItemBase> { new CartItemBase { GoodsID = 1, Count = 1, Store = Core.eStore.One }, new CartItemBase { GoodsID = 1, Count = 1, Store = Core.eStore.Exchange } }).ToJson();
            //requestContext.HttpContext.Response.AppendCookie(cookie);
            requestContext.HttpContext.Response.AppendCookie(cart);
            requestContext.HttpContext.Session["customer"] = new OneBuyMall.WebSite.Models.Customer
            {
                ID = 1,
                Name = "leonwuyan",
                HeaderImg = "1.jpg",
                Cart = new List<CartItemBase> {
                    new CartItemBase{
                         GoodsID=1, Count=1, Store= Core.eStore.One
                    },
                    new CartItemBase{
                         GoodsID=1, Count=1, Store= Core.eStore.Exchange
                    }
                }
            };
            base.Initialize(requestContext);
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {

            //if (filterContext.HttpContext.Session["admin"] == null)
            //{
            //    filterContext.HttpContext.Response.Redirect(Server.MapPath("~/admin/login"));
            //    filterContext.HttpContext.Response.End();
            //}
            //else
            //{
            //    // 提示权限不够，也可以跳转到其他页面
            //    filterContext.HttpContext.Response.Write("没有权限访问该页面");
            //    filterContext.HttpContext.Response.End();
            //}
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Request.Browser.Cookies)
            {
                return;
            }
            if (filterContext.HttpContext.Session["customer"] != null)
            {
                var customer = (Customer)filterContext.HttpContext.Session["customer"];
                var cartjson = Request.Cookies["cart"].Value;
                if (!string.IsNullOrEmpty(cartjson))
                {
                    var store = Request.Cookies["cart"].Value.ToObject<List<CartItemBase>>();
                    MvcApplication.core.CartMerge(customer.Cart, store);
                    Response.Cookies["cart"].Value = customer.Cart.ToJson();
                }
            }
            else
            {

            }
            base.OnActionExecuting(filterContext);
        }
    }
}

using OneBuyMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneBuyMall.WebSite.Controllers
{
    public class BaseController : Controller
    {
        public static Result ErrorID = new Result { status = 1, msg = "无效的ID", url = "history.back()" };
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneBuyMall.Models;
using System.EnterpriseServices;
using System.Net;
using System.Collections;

namespace OneBuyMall.WebSite.Controllers
{
    public class AdminController : BaseController
    {
        public ActionResult ShowResult(Result result)
        {
            return View(result);
        }
        [Description("管理员登陆")]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        #region 站点配置
        public ActionResult Configs()
        {
            var c = MvcApplication.core.LoadConfigs();
            return View(c);
        }
        [HttpPost]
        public ActionResult SaveConfigs()
        {
            var id = int.Parse(Request.Form["id"]);
            var sitename = Request.Form["sitename"];
            var keywords = Request.Form["keywords"];
            var desc = Request.Form["description"];
            Configs config = new OneBuyMall.Models.Configs { 
                ID = id,
                SiteName = sitename,
                Keywords = keywords,
                Desc = desc
            };
            Result result = new Result();
            if( MvcApplication.core.UpdateConfigs(config) == Core.HRESULT.Success)
            {
                result.status = 0;
                result.msg = "保存成功";
                result.url = "/admin/configs";
            }
            else
            {
                result.status = 0;
                result.msg = "保存失败，请与管理员联系";
                result.url = "/admin/configs";
            }
            return RedirectToAction("ShowResult", result);
        }
        #endregion
        #region 管理员管理
        public ActionResult AdminUsers()
        {
            var data = MvcApplication.core.GetAdminUsers();
            return View(data);
        }
        public ActionResult AdminUser(int? ID)
        {
            var data = new AdminUser();
            data.Permission = new System.Collections.BitArray(32,true);
            return View(data);
        }
        [HttpPost]
        public ActionResult SaveUsers()
        {
            Result result = new Result();
            return RedirectToAction("ShowResult", result);
        }
        public ActionResult Permission(BitArray p)
        {
            var data = MvcApplication.core.GetAllPermission();
            return View(data);
        }
        #endregion
        #region 分类管理
        public ActionResult GoodsGroups()
        {
            var c = MvcApplication.core.GetGoodsGroups();
            return View(c);
        }
        public ActionResult GoodsGroup(int? ID = 0)
        {
            if (ID > 0)
            {
                var c = MvcApplication.core.GetGoodsGroup((int)ID);
                if (c != null)
                    return View(c);
                return RedirectToAction("ShowResult", ErrorID);
            }
            else
            {
                return View(new GoodsGroup { ID = 0 });
            }
        }
        [HttpPost]
        public ActionResult SaveGoodsGroup()
        {
            var id = int.Parse(Request.Form["id"]);
            var name = Request.Form["name"];
            if(id == 0)
            {
                MvcApplication.core.AddGoodsGroup(name);
            }
            else
            {
                MvcApplication.core.EditGoodsGroup(id, name);
            }
            Result result = new Result();
            return RedirectToAction("ShowResult", result);
        }
        [HttpPost]
        public JsonResult DeleteGoodsGroup(int? ID = 0)
        {
            if (MvcApplication.core.DelGoodsGroup((int)ID) == Core.HRESULT.Success)
            {
                return Json(new Models.JsonRet { status = 0, msg = "" });
            }
            return Json(new Models.JsonRet { status = 1, msg = "删除失败" });
        }
        #endregion
        #region 用户管理

        #endregion
        public ActionResult Goods()
        {
            ViewData["data"] = new List<Goods> { new Goods{ ID=1, Name="testestet"} };
            return View();
        }

    }
}

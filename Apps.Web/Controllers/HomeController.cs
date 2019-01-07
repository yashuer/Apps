using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.IBLL;
using Apps.Models;
using Apps.Models.Sys;

namespace Apps.Web.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IHomeBLL homeBLL { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            Session["Account"] = new AccountModel { Id = "admin", TrueName = "admin" };
            return View();
        }
        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <param name="id">所属</param>
        /// <returns>树</returns>
        public JsonResult GetTree(string id)
        {            
            AccountModel account = (AccountModel)Session["Account"];
            List<SysModule> menus = homeBLL.GetMenuByPersonId(account.Id,id);
            var jsonData = (
                    from m in menus
                    select new
                    {
                        id = m.Id,
                        text = m.Name,
                        value = m.Url,
                        showcheck = false,
                        complete = false,
                        isexpand = false,
                        checkstate = 0,
                        hasChildren = m.IsLast ? false : true,
                        Icon = m.Iconic
                    }
                ).ToArray();
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
    }
}
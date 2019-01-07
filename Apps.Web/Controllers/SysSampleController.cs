using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.BLL;
using Apps.IBLL;
using Apps.Models;
using Apps.Models.Sys;
using Microsoft.Practices.Unity;
using Apps.Common;
using Apps.Locale;

namespace Apps.Web.Controllers
{
    public class SysSampleController : BaseController
    {
        ValidationErrors errors = new ValidationErrors();
        /// <summary>
        /// 业务层注入
        /// </summary>
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }

        // GET: /SysSample/
        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter(ActionName = "Index")]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysSampleModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysSampleModel()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime,
                        }).ToArray()

            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #region 创建
        [SupportFilter]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(SysSampleModel model)
        {
            if (m_BLL.Create(ref errors, model))
            {
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, Resource.Success, Resource.Create, "样例程序");
                return Json(JsonHandler.CreateMessage(1, Resource.Insert+Resource.Success), JsonRequestBehavior.AllowGet);
            }
            else
            {
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, Resource.Fail, Resource.Create, "样例程序");
                return Json(JsonHandler.CreateMessage(0, Resource.Insert + Resource.Fail), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {

            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(SysSampleModel model)
        {

            //Convert.ToInt16("dddd");
            if (m_BLL.Edit(ref errors, model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 详细
        [SupportFilter]
        public ActionResult Details(string id)
        {
            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    return Json(new { type = 1, message = Resource.Success }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { type = 0, message = Resource.Fail }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { type = 0, message = Resource.Fail }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
using Apps.Common;
using Apps.IBLL;
using Apps.Models;
using Apps.Models.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apps.Web.Controllers
{
    public class SysLogController : Controller
    {
        [Dependency]
        public ISysLogBLL logBLL { get; set; }
        // GET: SysLog
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysLogModel> list = logBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysLogModel()
                        {

                            Id = r.Id,
                            Operator = r.Operator,
                            Message = r.Message,
                            Result = r.Result,
                            Type = r.Type,
                            Module = r.Module,
                            CreateTime = r.CreateTime

                        }).ToArray()

            };

            return Json(json);
        }


        #region 详细

        public ActionResult Details(string id)
        {
            SysLogModel entity = logBLL.GetById(id);
            //SysLogModel info = new SysLogModel()
            //{
            //    Id = entity.Id,
            //    Operator = entity.Operator,
            //    Message = entity.Message,
            //    Result = entity.Result,
            //    Type = entity.Type,
            //    Module = entity.Module,
            //    CreateTime = entity.CreateTime
            //};
            return View(entity);
        }

        #endregion
    }
}
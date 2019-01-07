﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//       生成时间 2018-10-14 16:03:11 by CodingHeart
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

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

namespace Apps.Web.Controllers
{
    public class SysRoleController : BaseController
    {
        ValidationErrors errors = new ValidationErrors();
        //
        // GET: /SysRole/
        /// <summary>
        /// 业务层注入
        /// </summary>
        [Dependency]
        public ISysRoleBLL m_BLL { get; set; }

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns>视图</returns>
        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">分页</param>
        /// <param name="queryStr">查询条件</param>
        /// <returns></returns>
        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysRoleModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysRoleModel()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Description = r.Description,
                            CreateTime = r.CreateTime,
                            CreatePerson = r.CreatePerson,

                        }).ToArray()

            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #region 创建
        [SupportFilter]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(SysRoleModel model)
        {
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            model.CreatePerson = GetUserId();
            if (m_BLL.Create(ref errors, model))
            {
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, "成功", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, "失败", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            SysRoleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(SysRoleModel model)
        {
            if (m_BLL.Edit(ref errors, model))
            {
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name, "成功", "修改", "系统菜单");
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, "失败", "修改", "系统菜单");
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 设置角色用户
        [SupportFilter(ActionName = "Allot")]
        public ActionResult GetUserByRole(string roleId)
        {
            ViewBag.RoleId = roleId;
            ViewBag.Perm = GetPermission();
            return View();
        }

        [SupportFilter(ActionName = "Allot")]
        public JsonResult GetUserListByRole(GridPager pager, string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId))
                return Json(0);
            var userList = m_BLL.GetUserByRoleId(ref pager, roleId);

            var jsonData = new
            {
                total = pager.totalRows,
                rows = (
                    from r in userList
                    select new SysUserModel()
                    {
                        Id = r.Id,
                        UserName = r.UserName,
                        TrueName = r.TrueName,
                        Flag = r.flag == "0" ? "0" : "1",
                    }
                ).ToArray()
            };
            return Json(jsonData);
        }
        #endregion

        [SupportFilter(ActionName = "Save")]
        public JsonResult UpdateUserRoleByRoleId(string roleId, string userIds)
        {
            string[] arr = userIds.Split(',');

            if (m_BLL.UpdateSysRoleSysUser(roleId, arr))
            {
                LogHandler.WriteServiceLog(GetUserId(), "Ids:" + arr, "成功", "分配用户", "角色设置");
                return Json(JsonHandler.CreateMessage(1, Suggestion.SetSucceed), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Ids:" + arr, "失败", "分配用户", "角色设置");
                return Json(JsonHandler.CreateMessage(0, Suggestion.SetFail), JsonRequestBehavior.AllowGet);
            }
        }

        #region 详细
        public ActionResult Details(string id)
        {
            SysRoleModel entity = m_BLL.GetById(id);
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
                    LogHandler.WriteServiceLog(GetUserId(), "Ids:" + id, "成功", "删除", "模块设置");
                    return Json(new { type = 1, message = "成功" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id + "," + errors.Error, "失败", "删除", "模块设置");
                    return Json(new { type = 0, message = "失败" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { type = 0, message = "失败" }, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion

    }
}

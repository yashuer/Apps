﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//       生成时间 2018-10-15 22:45:11 by CodingHeart
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
using Apps.Locale;

namespace Apps.Web.Controllers
{
    public class SysUserController : BaseController
    {
        ValidationErrors errors = new ValidationErrors();

        /// <summary>
        /// 业务层注入
        /// </summary>
        [Dependency]
        public ISysUserBLL m_BLL { get; set; }

        // GET: /SysUser/
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
        [HttpPost]
        [SupportFilter(ActionName = "Index")]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysUserModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysUserModel()
                        {
                            Id = r.Id,
                            UserName = r.UserName,
                            Password = r.Password,
                            TrueName = r.TrueName,
                            Card = r.Card,
                            MobileNumber = r.MobileNumber,
                            PhoneNumber = r.PhoneNumber,
                            QQ = r.QQ,
                            EmailAddress = r.EmailAddress,
                            OtherContact = r.OtherContact,
                            Province = r.Province,
                            City = r.City,
                            Village = r.Village,
                            Address = r.Address,
                            State = r.State,
                            CreateTime = r.CreateTime,
                            CreatePerson = r.CreatePerson,
                            Sex = r.Sex,
                            Birthday = r.Birthday,
                            JoinDate = r.JoinDate,
                            Marital = r.Marital,
                            Political = r.Political,
                            Nationality = r.Nationality,
                            Native = r.Native,
                            School = r.School,
                            Professional = r.Professional,
                            Degree = r.Degree,
                            DepId = r.DepId,
                            PosId = r.PosId,
                            Expertise = r.Expertise,
                            JobState = r.JobState,
                            Photo = r.Photo,
                            Attach = r.Attach,

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
        public JsonResult Create(SysUserModel model)
        {
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            model.CreatePerson = GetUserId();
            if (m_BLL.Create(ref errors, model))
            {
                LogHandler.WriteServiceLog(GetUserTrueName(), "Id:" + model.Id + ",Name:" + model.Name, Resource.Success, Resource.Create, "SysUser");
                return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserTrueName(), "Id:" + model.Id + ",Name:" + model.Name, Resource.Fail, Resource.Create, "SysUser");
                return Json(JsonHandler.CreateMessage(0, Resource.Create + Resource.Fail + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            SysUserModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(SysUserModel model)
        {
            if (m_BLL.Edit(ref errors, model))
            {
                LogHandler.WriteServiceLog(GetUserTrueName(), "Id" + model.Id + ",Name" + model.Name, Resource.Success, Resource.Edit, "SysUser");
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserTrueName(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, Resource.Fail, Resource.Create, "SysUser");
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 设置用户角色
        [SupportFilter(ActionName = "Allot")]
        public ActionResult GetRoleByUser(string userId)
        {
            ViewBag.UserId = userId;
            ViewBag.Perm = GetPermission();
            return View();
        }

        [SupportFilter(ActionName = "Allot")]
        public JsonResult GetRoleListByUser(GridPager pager, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return Json(0);
            var userList = m_BLL.GetRoleByUserId(ref pager, userId);
            var jsonData = new
            {
                total = pager.totalRows,
                rows = (
                    from r in userList
                    select new SysRoleModel()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Description = r.Description,
                        Flag = r.flag == "0" ? "0" : "1",
                    }
                ).ToArray()
            };
            return Json(jsonData);
        }
        #endregion
        [SupportFilter(ActionName = "Save")]
        public JsonResult UpdateUserRoleByUserId(string userId, string roleIds)
        {
            string[] arr = roleIds.Split(',');


            if (m_BLL.UpdateSysRoleSysUser(userId, arr))
            {
                LogHandler.WriteServiceLog(GetUserId(), "Ids:" + roleIds, "成功", "分配角色", "用户设置");
                return Json(JsonHandler.CreateMessage(1, Suggestion.SetSucceed), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog(GetUserId(), "Ids:" + roleIds, "失败", "分配角色", "用户设置");
                return Json(JsonHandler.CreateMessage(0, Suggestion.SetFail), JsonRequestBehavior.AllowGet);
            }

        }

        #region 详细
        [SupportFilter]
        public ActionResult Details(string id)
        {
            SysUserModel entity = m_BLL.GetById(id);
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
                    LogHandler.WriteServiceLog(GetUserTrueName(), "Ids:" + id, Resource.Success, Resource.Create, "SysUser");
                    return Json(new { type = 1, message = Resource.Delete + Resource.Success }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    LogHandler.WriteServiceLog(GetUserTrueName(), "Id:" + id + "," + errors.Error, Resource.Fail, Resource.Create, "SysUser");
                    return Json(new { type = 0, message = Resource.Delete + Resource.Fail }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { type = 0, message = Resource.Delete + Resource.Fail }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}

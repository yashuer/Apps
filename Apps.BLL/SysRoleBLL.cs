using Apps.BLL.Core;
using Apps.Common;
using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BLL
{
    public partial class SysRoleBLL
    {
        /// <summary>
        /// 获取角色对应的所有用户
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        public string GetRefSysUser(string roleId)
        {
            string UserName = "";
            var userList = m_Rep.GetRefSysUser(roleId);
            if (userList != null)
            {
                foreach (var user in userList)
                {
                    UserName += "[" + user.UserName + "] ";
                }
            }
            return UserName;
        }

        public IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(ref GridPager pager, string roleId)
        {
            IQueryable<P_Sys_GetUserByRoleId_Result> queryData = m_Rep.GetUserByRoleId(roleId);//第一次查询记录数
            pager.totalRows = queryData.Count();
            queryData = m_Rep.GetUserByRoleId(roleId);//第二次查询数据
            return queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
        }
        public bool UpdateSysRoleSysUser(string roleId, string[] userIds)
        {
            try
            {
                m_Rep.UpdateSysRoleSysUser(roleId, userIds);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
    }
}

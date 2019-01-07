using Apps.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Common;
using Apps.Models;

namespace Apps.IBLL
{
    public partial interface ISysUserBLL : IDisposable
    {
        //List<permModel> GetPermission(string accountid, string controller);
        bool UpdateSysRoleSysUser(string userId, string[] arr);
        IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(ref GridPager pager, string userId);
    }
}

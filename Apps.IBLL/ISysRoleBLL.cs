using Apps.Common;
using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.IBLL
{
    public partial interface ISysRoleBLL
    {
        bool UpdateSysRoleSysUser(string roleId, string[] arr);
        IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(ref GridPager pager, string roleId);
    }
}

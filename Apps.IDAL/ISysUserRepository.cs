using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.IDAL
{
    public partial interface ISysUserRepository
    {
        IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(string userId);
        void UpdateSysRoleSysUser(string userId, string[] roleIds);
    }
}

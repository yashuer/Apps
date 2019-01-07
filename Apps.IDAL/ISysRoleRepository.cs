using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.IDAL
{
    public partial interface ISysRoleRepository
    {
        IQueryable<SysUser> GetRefSysUser(string roleId);
        IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(string roleId);
        void UpdateSysRoleSysUser(string roleId, string[] userIds);
    }
}

using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DAL
{
    public partial class SysUserRepository
    {
        public IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(string userId)
        {
            return db.P_Sys_GetRoleByUserId(userId).AsQueryable();
        }

        public void UpdateSysRoleSysUser(string userId, string[] roleIds)
        {
            using (db)//DBContainer db = new DBContainer()  ??
            {
                db.P_Sys_DeleteSysRoleSysUserByUserId(userId);
                foreach (string roleid in roleIds)
                {
                    if (!string.IsNullOrWhiteSpace(roleid))
                    {
                        db.P_Sys_UpdateSysRoleSysUser(roleid, userId);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}

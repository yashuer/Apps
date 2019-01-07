using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DAL
{
    public partial class SysRoleRepository
    {
        public IQueryable<SysUser> GetRefSysUser(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return from m in db.SysRole
                       from f in m.SysUser
                       where m.Id == id
                       select f;
            }
            return null;
        }

        public IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(string roleId)
        {
            return db.P_Sys_GetUserByRoleId(roleId).AsQueryable();
        }

        public void UpdateSysRoleSysUser(string roleId, string[] userIds)
        {
            using (DBContainer db = new DBContainer())
            {
                db.P_Sys_DeleteSysRoleSysUserByRoleId(roleId);
                foreach (string userid in userIds)
                {
                    if (!string.IsNullOrWhiteSpace(userid))
                    {
                        db.P_Sys_UpdateSysRoleSysUser(roleId, userid);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}

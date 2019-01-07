using Apps.Models;
using Apps.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BLL
{
    public partial class SysRightBLL
    {
        public List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            return m_Rep.GetRightByRoleAndModule(roleId, moduleId);
        }
        public int UpdateRight(SysRightOperateModel model)
        {
            return m_Rep.UpdateRight(model);
        }
    }
}

using Apps.IBLL;
using Apps.Models;
using Apps.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BLL
{
    public partial class SysModuleBLL
    {
        public List<SysModuleModel> GetList(string parentId)
        {
            IQueryable<SysModule> queryData = null;
            queryData = m_Rep.GetList().Where(a => a.ParentId == parentId && a.Id != "0").OrderBy(a => a.Sort);//// 
            return CreateModelList(ref queryData);
        }


        public List<SysModule> GetModuleBySystem(string parentId)
        {
            return m_Rep.GetModuleBySystem(parentId).ToList();
        }
    }
}

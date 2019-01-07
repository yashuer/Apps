using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DAL
{
    public partial class SysModuleRepository:CommonRepository<SysModule>
    {
        public IQueryable<SysModule> GetModuleBySystem(string parentId)
        {
            return db.SysModule.Where(a => a.ParentId == parentId).AsQueryable();
        }
    }
}

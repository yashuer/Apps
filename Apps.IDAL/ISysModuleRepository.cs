using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.IDAL
{
    public partial interface ISysModuleRepository
    {
        IQueryable<SysModule> GetModuleBySystem(string parentId);
    }
}

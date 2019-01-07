using Apps.IBLL;
using Apps.IDAL;
using Apps.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BLL
{
    public class HomeBLL : IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }
        public List<SysModule> GetMenuByPersonId(string personId, string moduleId)
        {
            return HomeRepository.GetMenuByPersonId(personId, moduleId);
        }
    }
}

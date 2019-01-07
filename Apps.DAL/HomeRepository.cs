﻿using Apps.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Models;

namespace Apps.DAL
{
    public partial class HomeRepository : IHomeRepository, IDisposable
    {

        public List<SysModule> GetMenuByPersonId(string personId, string moduleId)
        {
            using (DBContainer db = new DBContainer())
            {
                var menus =
                (
                    from m in db.SysModule
                    join rl in db.SysRight
                    on m.Id equals rl.ModuleId
                    join r in
                        (from r in db.SysRole
                         from u in r.SysUser
                         where u.Id == personId
                         select r)
                    on rl.RoleId equals r.Id
                    where rl.Rightflag == true
                    where m.ParentId == moduleId
                    where m.Id != "0"
                    select m
                          //from m in db.SysModule
                          //where m.ParentId == moduleId
                          //where m.Id != "0"
                          //select m
                          ).Distinct().OrderBy(a => a.Sort).ToList();
                return menus;
            }
        }


        public void Dispose()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using Apps.Models;

namespace Apps.BLL
{
    public class BaseBLL:IDisposable
    {
        public DBContainer db = new DBContainer();

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
        //用base类去做统一的实例化
        //private Entities _entity = new Entities();
        //public Entities entity
        //{
        //    get { return _entity; }
        //}
    }
}

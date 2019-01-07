using Apps.IDAL;
using Apps.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DAL
{
    public abstract class CommonRepository<T> : IDisposable,ICommonRepository<T> where T : class
    {
        public DBContainer db;
        public CommonRepository(DBContainer context)
        {
            db = context;
        }
        public CommonRepository()
        {
            //db = new DBContainer();
        }
        public DBContainer Context
        {
            get { return db; }
        }

        public virtual bool Create(T model)
        {
            db.Set<T>().Add(model);
            return db.SaveChanges() > 0;
        }

        public virtual bool Edit(T model)
        {
            if (db.Entry(model).State == EntityState.Modified)
            {
                return db.SaveChanges() > 0;
            }
            else if (db.Entry(model).State == EntityState.Detached)
            {
                try
                {
                    db.Set<T>().Attach(model);
                    db.Entry(model).State = EntityState.Modified;
                }
                catch (InvalidOperationException)
                {
                    //T old = Find(model._ID);
                    //db.Entry<old>.CurrentValues.SetValues(model);
                }
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public virtual bool Delete(T model)
        {
            db.Set<T>().Remove(model);
            return db.SaveChanges() > 0;
        }

        public virtual int Delete(params object[] keyValues)
        {
            T model = GetById(keyValues);
            if (model != null)
            {
                db.Set<T>().Remove(model);
                return db.SaveChanges();
            }
            return -1;
        }
        public virtual T GetById(params object[] keyValues)
        {
            return db.Set<T>().Find(keyValues);
        }

        public virtual IQueryable<T> GetList()
        {
            return db.Set<T>();
        }

        public virtual IQueryable<T> GetList(Func<T, bool> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).AsQueryable();
        }
        public virtual bool IsExist(string id)
        {
            return GetById(id) != null;
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {

        }

        ////供显式调用的Dispose方法
        //public void Dispose()
        //{
        //    //调用带参数的Dispose方法，释放托管和非托管资源
        //    Dispose(true);
        //    //手动调用了Dispose释放资源，那么析构函数就是不必要的了，这里阻止GC调用析构函数
        //    GC.SuppressFinalize(this);
        //}

        ////protected的Dispose方法，保证不会被外部调用。
        ////传入bool值disposing以确定是否释放托管资源
        //protected void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        ///TODO:在这里加入清理"托管资源"的代码，应该是xxx.Dispose();
        //    }
        //    ///TODO:在这里加入清理"非托管资源"的代码
        //    db.Dispose();
        //}

        ////供GC调用的析构函数
        //~CommonRepository()
        //{
        //    Dispose(false);//释放非托管资源
        //}
    }
}

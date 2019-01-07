//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Apps.Models;
using Apps.Common;
using Microsoft.Practices.Unity;
using System.Transactions;
using Apps.IBLL;
using Apps.IDAL;
using Apps.BLL.Core;
using Apps.Locale;
using Apps.Models.Sys;
namespace Apps.BLL
{
    public class Virtual_SysExceptionBLL
    {
        [Dependency]
        public ISysExceptionRepository m_Rep { get; set; }

        public virtual List<SysExceptionModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<SysException> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
                                a=>a.Id.Contains(queryStr)
                                || a.HelpLink.Contains(queryStr)
                                || a.Message.Contains(queryStr)
                                || a.Source.Contains(queryStr)
                                || a.StackTrace.Contains(queryStr)
                                || a.TargetSite.Contains(queryStr)
                                || a.Data.Contains(queryStr)
                                
                                );
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            //排序
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        public virtual List<SysExceptionModel> CreateModelList(ref IQueryable<SysException> queryData)
        {
            List<SysExceptionModel> modelList = (from r in queryData
                                              select new SysExceptionModel
                                              {
											      Id = r.Id,
											      HelpLink = r.HelpLink,
											      Message = r.Message,
											      Source = r.Source,
											      StackTrace = r.StackTrace,
											      TargetSite = r.TargetSite,
											      Data = r.Data,
											      CreateTime = r.CreateTime,
          
                                              }).ToList();
            return modelList;
        }

        public virtual bool Create(ref ValidationErrors errors, SysExceptionModel model)
        {
            try
            {
                SysException entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Resource.PrimaryRepeat);
                    return false;
                }
                entity = new SysException();
                               entity.Id = model.Id;
                entity.HelpLink = model.HelpLink;
                entity.Message = model.Message;
                entity.Source = model.Source;
                entity.StackTrace = model.StackTrace;
                entity.TargetSite = model.TargetSite;
                entity.Data = model.Data;
                entity.CreateTime = model.CreateTime;
  
                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Resource.Insert + Resource.Fail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

         public virtual bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public virtual bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        if (m_Rep.Delete(deleteCollection) == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public virtual bool Edit(ref ValidationErrors errors, SysExceptionModel model)
        {
            try
            {
                SysException entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Resource.Disable);
                    return false;
                }
                                              entity.Id = model.Id;
                entity.HelpLink = model.HelpLink;
                entity.Message = model.Message;
                entity.Source = model.Source;
                entity.StackTrace = model.StackTrace;
                entity.TargetSite = model.TargetSite;
                entity.Data = model.Data;
                entity.CreateTime = model.CreateTime;
 
                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add("没有数据改变");
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public virtual SysExceptionModel GetById(string id)
        {
            if (IsExists(id))
            {
                SysException entity = m_Rep.GetById(id);
                SysExceptionModel model = new SysExceptionModel();
                model.Id = entity.Id;
                model.HelpLink = entity.HelpLink;
                model.Message = entity.Message;
                model.Source = entity.Source;
                model.StackTrace = entity.StackTrace;
                model.TargetSite = entity.TargetSite;
                model.Data = entity.Data;
                model.CreateTime = entity.CreateTime;
 
                return model;
            }
            else
            {
                return null;
            }
        }

        public virtual bool IsExists(string id)
        {
            return m_Rep.IsExist(id);
        }

        public void Dispose()
        { 
            
        }
    }
}

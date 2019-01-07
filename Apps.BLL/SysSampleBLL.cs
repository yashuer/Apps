using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using Apps.Models;
using Apps.Common;
using Apps.Models.Sys;
using Apps.IBLL;
using Apps.IDAL;
using Apps.BLL.Core;

namespace Apps.BLL
{
    public partial class SysSampleBLL : ISysSampleBLL
    {

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public override bool Create(ref ValidationErrors errors, SysSampleModel model)
        {
            try
            {
                SysSample entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add("主键重复");
                    return false;
                }
                entity = new SysSample();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                entity.CreateTime = model.CreateTime;

                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add("插入失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add("插入失败");
                ExceptionHander.WriteException(ex);
                return false;
            }
        }           
    }
}
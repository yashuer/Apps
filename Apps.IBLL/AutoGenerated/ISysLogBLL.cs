//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Apps.Common;
using System.Collections.Generic;
using Apps.Models.Sys;
namespace Apps.IBLL
{
    public partial interface ISysLogBLL
    {
        List<SysLogModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysLogModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, SysLogModel model);
        SysLogModel GetById(string id);
        bool IsExists(string id);
    }
}

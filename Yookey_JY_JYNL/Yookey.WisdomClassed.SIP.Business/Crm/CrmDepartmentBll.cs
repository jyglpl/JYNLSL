//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmDepartmentBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/6 20:36:42
//  功能描述：CrmDepartment业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// 部门 业务逻辑
    /// </summary>
    public class CrmDepartmentBll : BaseBll<CrmDepartmentEntity>
    {
        public CrmDepartmentBll()
        {
            BaseDal = new CrmDepartmentDal();
        }

        private static readonly CrmDepartmentDal Dal = new CrmDepartmentDal();

        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmDepartmentEntity> GetAllDepartment(CrmDepartmentEntity search)
        {
            return Dal.GetAllDepartment(search);
        }

        /// <summary>
        /// 部门查询
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public JqDataGrid<CrmDepartmentEntity> GetSearchResult(CrmDepartmentEntity search)
        {
            int totalRecords;
            var data = Dal.GetSearchResult(search, out totalRecords);
            return CommonMethod.ConvertToJqDataGrid(search.PageIndex, search.PageSize, totalRecords, data);
        }

        /// <summary>
        /// 批量删除单位
        /// </summary>
        /// <param name="ids">单位Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return Dal.BatchDelete(ids);
        }
    }
}

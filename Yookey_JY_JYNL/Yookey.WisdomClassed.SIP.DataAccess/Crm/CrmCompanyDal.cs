//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmCompanyDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/1 13:56:10
//  功能描述：CrmCompany数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// 数据访问操作
    /// </summary>
    public class CrmCompanyDal : DalImp.BaseDal<CrmCompanyEntity>
    {
        public CrmCompanyDal()
        {
            Model = new CrmCompanyEntity();
        }

        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmCompanyEntity> GetAllCompany()
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmCompanyEntity.Parm_CrmCompany_RowStatus, "1");
            queryCondition.AddOrderBy(CrmCompanyEntity.Parm_CrmCompany_SortCode, true);
            return Query(queryCondition) as List<CrmCompanyEntity>;
        }

        /// <summary>
        /// 查询所有执法单位
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmCompanyEntity> GetAllCompany(CrmCompanyEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmCompanyEntity.Parm_CrmCompany_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ParentId))
            {
                queryCondition.AddEqual(CrmCompanyEntity.Parm_CrmCompany_ParentId, search.ParentId);
            }
            if (!string.IsNullOrEmpty(search.Id))
            {
                queryCondition.AddEqual(CrmCompanyEntity.Parm_CrmCompany_Id, search.Id);
            }
            if (search.Enforcement > 0)
            {
                queryCondition.AddEqual(CrmCompanyEntity.Parm_CrmCompany_Enforcement, search.Enforcement.ToString());
            }


            //排序
            queryCondition.AddOrderBy(CrmCompanyEntity.Parm_CrmCompany_SortCode, true);
            return Query(queryCondition) as List<CrmCompanyEntity>;
        }

        /// <summary>
        /// 批量删除单位
        /// </summary>
        /// <param name="ids">单位Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE [CrmCompany] SET [RowStatus] =0 WHERE [Id] IN ('{0}')", string.Join(",'", ids));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }
    }
}


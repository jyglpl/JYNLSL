//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmDepartmentDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/6 20:36:42
//  功能描述：CrmDepartment数据访问类
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
    /// CrmDepartment数据访问操作
    /// </summary>
    public class CrmDepartmentDal : DalImp.BaseDal<CrmDepartmentEntity>
    {
        public CrmDepartmentDal()
        {
            Model = new CrmDepartmentEntity();
        }

        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmDepartmentEntity> GetAllDepartment(CrmDepartmentEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmDepartmentEntity.Parm_CrmDepartment_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.Id))
            {
                queryCondition.AddEqual(CrmDepartmentEntity.Parm_CrmDepartment_Id, search.Id);
            }
            if (!string.IsNullOrEmpty(search.CompanyId))
            {
                queryCondition.AddEqual(CrmDepartmentEntity.Parm_CrmDepartment_CompanyId, search.CompanyId);
            }
            queryCondition.AddOrderBy(CrmDepartmentEntity.Parm_CrmDepartment_SortCode, true);
            return Query(queryCondition) as List<CrmDepartmentEntity>;
        }

        /// <summary>
        /// 部门查询
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public List<CrmDepartmentEntity> GetSearchResult(CrmDepartmentEntity search, out int totalRecords)
        {
            var sbSql = new StringBuilder();
            sbSql.Append(@"SELECT CR.*,CC.FullName AS CompanyName FROM CrmDepartment CR
INNER JOIN CrmCompany CC ON CR.CompanyId=CC.Id WHERE CR.RowStatus=1 AND CC.RowStatus=1 ");

            if (!string.IsNullOrEmpty(search.CompanyId))
            {
                sbSql.AppendFormat(@"AND CR.CompanyId='{0}'", search.CompanyId);
            }
            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, sbSql.ToString(), "*", "", "SortCode", "ASC", search.PageIndex, search.PageSize, out totalRecords);
            return DataTableToList(data);
        }

        /// <summary>
        /// 批量删除部门
        /// </summary>
        /// <param name="ids">部门Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE CrmDepartment SET RowStatus =0 WHERE Id IN ('{0}')", string.Join(",'", ids));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }
    }
}


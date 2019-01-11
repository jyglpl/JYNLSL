//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmRoleDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/6 20:52:52
//  功能描述：CrmRole数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// 角色 数据访问操作
    /// </summary>
    public class CrmRoleDal : DalImp.BaseDal<CrmRoleEntity>
    {
        public CrmRoleDal()
        {
            Model = new CrmRoleEntity();
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmRoleEntity> GetAllRoles()
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(CrmRoleEntity.Parm_CrmRole_RowStatus, "1");
                queryCondition.AddOrderBy(CrmRoleEntity.Parm_CrmRole_SortCode, true);
                return Query(queryCondition) as List<CrmRoleEntity>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 角色查询
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <param name="totalRecords">总记录条数</param>
        /// <returns></returns>
        public List<CrmRoleEntity> GetSearchResult(CrmRoleEntity search, out int totalRecords)
        {
            var sbSql = new StringBuilder();
            sbSql.Append(@"SELECT CR.*,CC.FullName AS CompanyName,
(SELECT COUNT(*) FROM CrmUserRole LEFT JOIN CrmUser ON CrmUserRole.UserId=CrmUser.Id WHERE CrmUser.RowStatus=1 AND RoleId=CR.Id) AS Membercount FROM CrmRole CR
JOIN CrmCompany CC ON CR.CompanyId=CC.Id WHERE CR.RowStatus=1 ");

            if (!string.IsNullOrEmpty(search.CompanyId))
            {
                sbSql.AppendFormat(@"AND CR.CompanyId='{0}' ", search.CompanyId);
            }
            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, sbSql.ToString(), "*", "", "SortCode", "ASC", search.PageIndex, search.PageSize, out totalRecords);
            return DataTableToList(data);
        }

        /// <summary>
        /// 批量删除角色
        /// </summary>
        /// <param name="ids">角色Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE CrmRole SET RowStatus =0 WHERE Id IN ('{0}')", string.Join(",'", ids));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }

        /// <summary>
        /// 判断用户是否是中队长（副中队长）
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsSquadronLeader(string userId)
        {
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(@"
                                SELECT COUNT(*)
                            FROM CrmUser  CU with(nolock)
                            INNER JOIN  CrmUserRole CUR with(nolock)
                            ON CU.Id=CUR.UserId
                            INNER JOIN CrmRole CR with(nolock)
                            ON cr.Id=Cur.RoleId

                            WHERE CU.Id='{0}'  AND (CR.FullName like '%中队长%' or CR.FullName like '%副中队长%') ", userId);

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            if (list != null && list.Tables.Count > 0)
            {
                if (int.Parse(list.Tables[0].Rows[0][0].ToString()) >= 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}


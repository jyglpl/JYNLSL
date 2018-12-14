//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmUserRoleDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:36:05
//  功能描述：CrmUserRole数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.DataAccess.DalImp;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// CrmUserRole数据访问操作
    /// </summary>
    public class CrmUserRoleDal : BaseDal<CrmUserRoleEntity>
    {
        public CrmUserRoleDal()
        {
            Model = new CrmUserRoleEntity();
        }
        
        /// <summary>
        /// 获取所有用户与角色对应的数据
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmUserRoleEntity> GetAllUsers()
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(CrmUserRoleEntity.Parm_CrmUserRole_RowStatus, "1");
                return Query(queryCondition) as List<CrmUserRoleEntity>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询用户与角色对应的数据
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmUserRoleEntity> GetSearchResult(CrmUserRoleEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmUserRoleEntity.Parm_CrmUserRole_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.RoleId))
            {
                queryCondition.AddEqual(CrmUserRoleEntity.Parm_CrmUserRole_RoleId, search.RoleId);
            }
            if (!string.IsNullOrEmpty(search.UserId))
            {
                queryCondition.AddEqual(CrmUserRoleEntity.Parm_CrmUserRole_UserId, search.UserId);
            }
            return Query(queryCondition) as List<CrmUserRoleEntity>;
        }


        /// <summary>
        /// 保存用户与角色对应
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="list">对应关系数据集</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public bool SaveUserRole(List<CrmUserRoleEntity> list, string roleId)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveUserRole");
            try
            {

                var sbSql = new StringBuilder();
                sbSql.AppendFormat(@"DELETE FROM CrmUserRole WHERE RoleId='{0}'", roleId);

                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());

                foreach (var entity in list)
                {
                    Add(entity);
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }
    }
}

//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmUserMenuDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:36:05
//  功能描述：CrmUserMenu数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Linq;
using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.DataAccess.DalImp;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// CrmUserMenu数据访问操作
    /// </summary>
    public class CrmUserMenuDal : BaseDal<CrmUserMenuEntity>
    {
        public CrmUserMenuDal()
        {
            Model = new CrmUserMenuEntity();
        }


        /// <summary>
        /// 根据菜单编号获取用户信息
        /// 添加人：张晖   
        /// 添加时间：2014-04-08
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>     
        /// <param name="menuId">菜单编号</param>
        /// <returns>用户列表</returns>
        public List<CrmUserEntity> GetUserByMenu(string menuId)
        {
            if (string.IsNullOrEmpty(menuId)) return null;
            var sbWhere = new StringBuilder("SELECT * FROM CrmUserMenu ");
            sbWhere.AppendFormat("WHERE RowStatus=1 AND MenuId={0}", menuId);
            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbWhere.ToString()).Tables[0];
            return (from DataRow item in dt.Rows select new CrmUserDal().Get(item["UserId"].ToString())).ToList();
        }


        /// <summary>
        /// 更新用户菜单
        /// 添加人：周 鹏 
        /// 添加时间：2014-04-10
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户Id</param>
        /// <param name="menuIds">菜单Id集合</param>
        /// <returns></returns>
        public bool UpdateUserMenu(string userId, string menuIds)
        {
            try
            {
                var sbSql = new StringBuilder();
                if (string.IsNullOrEmpty(menuIds) || menuIds.Trim(',').Length.Equals(0))
                {
                    sbSql.AppendFormat(@"DELETE FROM CrmUserMenu WHERE [UserId]='{0}' AND MenuId IN (SELECT Id FROM ComMenu)", userId);
                }
                else
                {
                    sbSql.AppendFormat(
                        @"DELETE FROM CrmUserMenu WHERE [UserId]='{0}' AND [MenuId] IN (SELECT Id FROM ComMenu );
                        INSERT INTO CrmUserMenu (UserId,MenuId) SELECT '{0}',Id FROM [ComMenu] WITH(NOLOCK) WHERE Id IN ({1})",
                        userId, ("'" + menuIds.Trim(',') + "'").Replace(",", "','"));
                }
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 验证用户指定功能（菜单）权限
        /// 添加人：周 鹏
        /// 添加时间：2015-07-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool GetUserMenu(string userId, string menuId)
        {
            try
            {
                var sbSql = new StringBuilder();
                sbSql.AppendFormat("SELECT COUNT(*) FROM dbo.CrmUserMenu WHERE UserId='{0}' AND MenuId='{1}'", userId, menuId);
                var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
                return obj != null && int.Parse(obj.ToString()) >= 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// add by lpl
        /// 获取拥有指定权限的所有用户
        /// 2018-12-29
        /// </summary>
        /// <param name="Controller"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        public List<CrmUserMenuEntity> GetAuthorization(string Controller, string Action)
        {
            var sbSql = new StringBuilder("");
            sbSql.AppendFormat(@"SELECT * FROM dbo.CrmUserMenu
            WHERE MenuId IN(SELECT Id FROM dbo.ComMenu
            WHERE Controller = '{0}' AND Action = '{1}')
            ORDER BY CreateOn DESC", Controller, Action);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<CrmUserMenuEntity>();
        }


        /// <summary>
        /// add by lpl
        /// 2018-12-29
        /// 根据用户id来判断是否拥有权限
        /// </summary>
        /// <param name="Controller"></param>
        /// <param name="Action"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool GetAuthorizationByUserId(string Controller, string Action, string userid)
        {
            var sbSql = new StringBuilder("");
            sbSql.AppendFormat(@"SELECT * FROM dbo.CrmUserMenu
            WHERE MenuId IN(SELECT Id FROM dbo.ComMenu
            WHERE Controller = '{0}' AND Action = '{1}')
            AND UserId = '{2}'
            ORDER BY CreateOn DESC", Controller, Action, userid);
            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString())
                .Tables[0];

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

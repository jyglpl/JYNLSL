//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComMenuDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:51:48
//  功能描述：ComMenu数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.DataAccess.DalImp;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComMenu数据访问操作
    /// </summary>
    public class ComMenuDal : BaseDal<ComMenuEntity>
    {
        public ComMenuDal()
        {
            Model = new ComMenuEntity();
        }

        /// <summary>
        /// 获取用户菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userid">用户Id</param>
        /// <returns></returns>
        public List<ComMenuEntity> GetUserMenus(string userid)
        {
            var sbSql = new StringBuilder("");
            sbSql.AppendFormat(
                              @"SELECT * FROM (SELECT CM.* FROM ComMenu AS CM WITH(NOLOCK) JOIN [CrmUserMenu] AS CUM WITH(NOLOCK) ON (CM.Id=CUM.MenuId)
                                WHERE CM.RowStatus=1 AND CUM.RowStatus=1 AND CUM.UserId='{0}'
                                UNION
                                SELECT CM.* FROM ComMenu AS CM WITH(NOLOCK) JOIN CrmRoleMenu AS CRM WITH(NOLOCK) ON (CM.Id=CRM.MenuId) JOIN CrmUserRole AS CUR WITH(NOLOCK) ON (CRM.RoleId=CUR.RoleId)
                                WHERE CM.RowStatus=1 AND CRM.RowStatus=1 AND CUR.RowStatus=1 AND CUR.UserId='{0}'
                                UNION
                                SELECT CM.* FROM ComMenu AS CM WITH(NOLOCK) JOIN CrmUserMenu AS CUM WITH(NOLOCK) ON (CM.Id=CUM.MenuId)
                                WHERE CM.RowStatus=1 AND CUM.RowStatus=1 AND CUM.UserId='{0}') AS T ORDER BY MenuLevel,SortCode,Id ", userid);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<ComMenuEntity>();
        }

        /// <summary>
        /// 获取用户所有菜单，以,分隔，字符格式为,Controller_Action_1,
        /// 用于页面权限判断
        /// 添加人：周 鹏
        /// 添加时间：2013-01-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="currentUserId">当前用户Id</param>
        /// <param name="controllername">Controller Name</param>
        /// <returns></returns>
        public string GetUserMenus(string currentUserId, string controllername)
        {
            var sbSql = new StringBuilder();
            sbSql.Append("DECLARE @STR NVARCHAR(MAX);set @STR=','; ");
            sbSql.Append("SELECT @STR=@STR+[Controller]+'_'+[Action]+'_'+(CASE WHEN CAST( ISNULL(UM.MenuId,0) AS NUMERIC(18,0))>0 THEN '1'  ELSE '0' END) +',' ");
            sbSql.Append("FROM [ComMenu] AS CM WITH(NOLOCK) LEFT JOIN  ");
            sbSql.Append("( ");
            sbSql.Append("SELECT [MenuId] FROM [CrmRoleMenu] WITH(NOLOCK) ");
            sbSql.AppendFormat("WHERE [RowStatus]=1 AND [RoleId] IN (SELECT [RoleId] FROM [CrmUserRole] WITH(NOLOCK) WHERE [RowStatus]=1 AND [UserId]='{0}') ", currentUserId);
            sbSql.Append("UNION SELECT [MenuId] FROM [CrmUserMenu] WITH(NOLOCK) ");
            sbSql.AppendFormat("WHERE [RowStatus] =1 AND [UserId]='{0}' ", currentUserId);
            sbSql.Append(") AS UM ON (CM.Id=UM.MenuId ) ");
            sbSql.AppendFormat("WHERE [RowStatus]=1 AND [MenuLevel]=3 ");
            if (!string.IsNullOrEmpty(controllername))
            {
                sbSql.AppendFormat(" AND [Controller] IN ({0}) ", controllername.Trim(','));
            }
            sbSql.Append("SELECT @STR AS ACTIONS ");
            return SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()).ToString();
        }

        /// <summary>
        /// 获取角色菜单
        /// 添加人：周 鹏 
        /// 添加时间：2013-01-03
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public List<ComMenuEntity> GetRoleMenus(string roleId)
        {
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(
                @"SELECT CM.* FROM [ComMenu] AS CM WITH(NOLOCK) JOIN [CrmRoleMenu] AS CRM WITH(NOLOCK) ON (CM.Id=CRM.MenuId)
                  WHERE CM.RowStatus=1 AND CRM.RowStatus=1 AND CRM.RoleId='{0}'",
                roleId);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<ComMenuEntity>();
        }

        /// <summary>
        /// 批量删除菜单
        /// 添加人：周 鹏
        /// 添加时间：2013-01-03
        /// </summary>
        /// <param name="menuIds">菜单Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDeleteMenu(string menuIds)
        {
            if (string.IsNullOrEmpty(menuIds) || menuIds.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE [ComMenu] SET [RowStatus] =0 WHERE [Id]  IN ({0})", menuIds.Trim(','));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }

        /// <summary>
        /// 获取菜单最大编号
        /// 添加人：周 鹏
        /// 添加时间：2014-03-28
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public string GetMenuMaxId(string parentId)
        {
            var sbSql = string.Format("SELECT MAX(Id) AS ID FROM ComMenu WHERE ParentMenuId='{0}'", parentId);
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql);
            string maxId;
            if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
            {
                var id = obj.ToString();
                var num = Convert.ToInt64(id.Substring(id.Length - parentId.Length)) + 1;
                maxId = (parentId.Equals("0000") ? "" : parentId) + num.ToString(CultureInfo.InvariantCulture).PadLeft(4, '0');
            }
            else
            {
                maxId = parentId + "0001";
            }
            return maxId;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">编号</param>
        public void Delete(string id)
        {
            var model = Get(id);
            if (model == null) return;
            model.RowStatus = (int)RowStatus.Delete;
            Update(model);
        }
    }
}

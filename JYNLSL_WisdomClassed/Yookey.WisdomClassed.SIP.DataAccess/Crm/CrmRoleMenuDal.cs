//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmRoleMenuDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:36:05
//  功能描述：CrmRoleMenu数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.DataAccess.DalImp;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// CrmRoleMenu数据访问操作
    /// </summary>
    public class CrmRoleMenuDal : BaseDal<CrmRoleMenuEntity>
    {
        public CrmRoleMenuDal()
        {
            Model = new CrmRoleMenuEntity();
        }


        /// <summary>
        /// 更新角色菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="menuIds">菜单Id集合</param>
        /// <returns></returns>
        public bool UpdateRoleMenu(string roleId, string menuIds)
        {
            try
            {
                var sbSql = new StringBuilder();
                if (string.IsNullOrEmpty(menuIds) || menuIds.Trim(',').Length.Equals(0))
                {
                    sbSql.AppendFormat(@"DELETE FROM CrmRoleMenu WHERE RoleId='{0}' AND MenuId IN (SELECT Id FROM ComMenu)", roleId);
                }
                else
                {
                    sbSql.AppendFormat(
                        @"DELETE FROM CrmRoleMenu WHERE RoleId='{0}' AND MenuId IN (SELECT Id FROM ComMenu);
                        INSERT INTO CrmRoleMenu (RoleId,MenuId,RowStatus,CreatorId,CreateBy,CreateOn,UpdateId,UpdateBy,UpdateOn) 
SELECT '{0}',Id,1,0,'',GETDATE(),0,'',GETDATE() FROM ComMenu WHERE Id IN ({1});",
                        roleId, ("'" + menuIds.Trim(',') + "'").Replace(",", "','"));
                }
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

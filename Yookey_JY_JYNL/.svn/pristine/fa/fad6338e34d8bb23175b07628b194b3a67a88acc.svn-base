//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementStandardDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:36
//  功能描述：TeamManagementStandard数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.TeamManagement;

namespace Yookey.WisdomClassed.SIP.DataAccess.TeamManagement
{
    /// <summary>
    /// TeamManagementStandard数据访问操作
    /// </summary>
    public class TeamManagementStandardDal : DalImp.BaseDal<TeamManagementStandardEntity>
    {
        public TeamManagementStandardDal()
        {           
            Model = new TeamManagementStandardEntity();
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="ids">数据Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE TeamManagementStandard SET RowStatus =0 WHERE Id  IN ({0})", ids.Trim(','));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }
    }
}
                                                                                                                                         

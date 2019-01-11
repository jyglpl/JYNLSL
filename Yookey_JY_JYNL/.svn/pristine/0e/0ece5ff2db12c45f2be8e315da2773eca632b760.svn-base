//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_DepartmentDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:45
//  功能描述：Base_Department数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using DBHelper;
using System.Collections.Generic;
using System.Data;
using Yookey;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.DataAccess.Base
{
    /// <summary>
    /// Base_Department数据访问操作
    /// </summary>
    public class BaseDepartmentDal
    {
        /// <summary>
        /// 查询所有部门
        /// 添加人：周 鹏
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<BaseDepartmentEntity> GetAllDepartments(string CompanyId = "")
        {

            var strSql = string.Format("SELECT * FROM CrmDepartment WHERE Enabled=1 ");
            if (!string.IsNullOrEmpty(CompanyId))
            {
                strSql += string.Format("  AND CompanyId='{0}' ", CompanyId);
            }
            strSql += " ORDER BY SortCode";
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
            return list != null && list.Rows.Count > 0
                          ? ConvertListHelper<BaseDepartmentEntity>.ConvertToList(list)
                          : new List<BaseDepartmentEntity>();
        }

        /// <summary>
        /// 查询数据实体
        /// 添加人：周 鹏
        /// 添加时间：2015-02-26
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public BaseDepartmentEntity Get(string id)
        {
            var strSql = string.Format("SELECT * FROM CrmDepartment WHERE Id='{0}'", id);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
            return list != null && list.Rows.Count > 0
                       ? ConvertListHelper<BaseDepartmentEntity>.ConvertToList(list)[0]
                       : new BaseDepartmentEntity();
        }

        /// <summary>
        /// 查询部分部门
        /// 添加人;叶念
        /// 添加时间：2015-07-14
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<BaseDepartmentEntity> GetAllDetachments(string type = "lochus")
        {
            var strSql = string.Format("SELECT Id AS DepartmentId,* FROM CrmDepartment WHERE Enabled=1  ");

            //if (type.Equals("lochus"))
            //{
            //    strSql += " AND FullName LIKE '%中队'";
            //}
            strSql += "ORDER BY SortCode";

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
            return list != null && list.Rows.Count > 0 ? ConvertListHelper<BaseDepartmentEntity>.ConvertToList(list)
                          : new List<BaseDepartmentEntity>();
        }

        /// <summary>
        /// 查询所有执法大队下面的部门
        /// 添加人：周 鹏
        /// 添加时间：2015-02-27
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2015-04-20 周 鹏 细化查询条件
        /// </history>
        /// <param name="type">查询类型：lochus->只查中队,all->大队下所有部门</param>
        /// <returns></returns>
        public List<BaseDepartmentEntity> GetAllDetachment(string id)
        {
            var strSql = string.Format("SELECT * FROM CrmDepartment WHERE Enabled=1 ");
            if (!string.IsNullOrEmpty(id))
            {
                strSql += string.Format(" AND   ID ='{0}'", id);
            }

            strSql += "ORDER BY SortCode";

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
            return list != null && list.Rows.Count > 0
                          ? ConvertListHelper<BaseDepartmentEntity>.ConvertToList(list)
                          : new List<BaseDepartmentEntity>();
        }

        /// <summary>
        /// 所有执法大队
        /// </summary>
        /// <returns></returns>
        public List<BaseDepartmentEntity> GetAllsDetachments()
        {
            var strSql = string.Format("SELECT * FROM CrmDepartment WHERE Enabled=1 AND CompanyId='c1ef0d6f-4ba6-4acb-8c98-cc5a87f3954f'");
            strSql += "ORDER BY SortCode";

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
            return list != null && list.Rows.Count > 0
                          ? ConvertListHelper<BaseDepartmentEntity>.ConvertToList(list)
                          : new List<BaseDepartmentEntity>();
        }
    }
}


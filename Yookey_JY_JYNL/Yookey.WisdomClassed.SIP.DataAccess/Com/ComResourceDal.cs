//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComResourceDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：ComResource数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.DataAccess.DalImp;
using Yookey.WisdomClassed.SIP.Model.Com;
using System.Collections.Generic;
using System.Data.SqlClient;
using Yookey.WisdomClassed.SIP.Enumerate;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComResource数据访问操作
    /// </summary>
    public class ComResourceDal : BaseDal<ComResourceEntity>
    {
        public ComResourceDal()
        {
            Model = new ComResourceEntity();
        }



        /// <summary>
        /// 根据父编号查询最大的编号
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history>
        ///  修改描述：时间+作者+描述
        /// </history>
        /// <param name="parentId">父编号</param>
        /// <returns></returns>
        public string GetMaxId(string parentId)
        {
            var sbSql = string.Format("SELECT MAX(Id) AS ID FROM ComResource WHERE ParentId='{0}' AND RowStatus=1 ", parentId);
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql);
            string maxId;
            if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
            {
                var id = obj.ToString();
                var num = Convert.ToInt32(id.Substring(id.Length - parentId.Length)) + 1;
                maxId = parentId + num.ToString(CultureInfo.InvariantCulture).PadLeft(4, '0');
            }
            else
            {
                maxId = parentId + "0001";
            }
            return maxId;
        }

        /// <summary>
        /// 获取Resources 查询Resources 根据父编号
        /// 添加人：叶 念
        /// 添加时间：2014-04-03
        /// </summary>
        /// <param name="parentid">父编号</param>
        /// <returns></returns>
        public DataTable GetResources(string parentid)
        {
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(
                @"SELECT * FROM ComResource WHERE ParentId='{0}'",
                parentid);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? list.Tables[0] : new DataTable();
        }

        /// <summary>
        /// 查询所有的子系统账号 根据用户ID
        /// 添加人：叶 念
        /// 添加时间：2014-04-04
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetResourcesByUserid(string userid)
        {
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(
                @"SELECT * FROM CrmUserMap WHERE UserId='{0}'", userid);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? list.Tables[0] : new DataTable();
        }


        /// <summary>
        /// 根据ID模糊查询字典信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ComResourceEntity> GetResourceLikeId(string id)
        {
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(
                @"SELECT * FROM ComResource WHERE Id LIKE '{0}%'", id);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0
                       ? DataTableToList(list.Tables[0])
                       : new List<ComResourceEntity>();
        }

        /// <summary>
        /// 获取Resources 查询Resources 根据父编号
        /// 添加人：周 鹏
        /// 添加时间：2015-01-26
        /// </summary>
        /// <history>
        ///  修改描述：时间+作者+描述
        /// </history>
        /// <param name="parentid">父编号</param>
        /// <returns></returns>
        public List<ComResourceEntity> GetResourcesByParentId(string parentid)
        {
            var sbSql = @"SELECT * FROM ComResource WHERE ParentId Like @ParentId AND RowStatus=1  ORDER BY OrderNo";

            var paramerList = new List<SqlParameter>();
            paramerList.Add(new SqlParameter("@ParentId", "%" + parentid + "%"));

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString(), paramerList.ToArray());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<ComResourceEntity>();
        }

        /// <summary>
        /// 批量删除数据
        /// 添加人：周 鹏
        /// 添加时间：2015-01-26
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
            sbSql.AppendFormat("UPDATE [ComResource] SET [RowStatus] =0 WHERE [Id]  IN ({0})", ids.Trim(','));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }


        /// <summary>
        /// 根据ParentId获取字典列表
        /// 添加人：zhoulj
        /// 添加时间：2018-08-21
        /// 变更人：xj 2018-08-22
        /// </summary></summary>
        public List<ComResourceEntity> GetListBy(string parentId, string PK_ID)
        {
            var sbWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(parentId))
            {
                sbWhere.AppendFormat(@" AND ParentId = '{0}'", parentId);
            }
            if (!string.IsNullOrEmpty(PK_ID))
            {
                sbWhere.AppendFormat(@" AND Id = '{0}'", PK_ID);
            }
            var sbSql = string.Format(@"SELECT * FROM ComResource WHERE RowStatus={0} {1} ORDER BY OrderNo", (int)RowStatus.Normal, sbWhere);

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<ComResourceEntity>();
        }


        /// <summary>
        /// 模糊查询获取字典列表
        /// 添加人：zhoulj
        /// 添加时间：2018-09-21
        /// </summary>
        public List<ComResourceEntity> GetListLikePk_Id(string PK_ID)
        {
            var sbWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(PK_ID))
            {
                sbWhere.AppendFormat(@" AND like '{0}%'", PK_ID);
            }
            var sbSql = string.Format(@"SELECT * FROM ComResource WHERE RowStatus={0} {1} ORDER BY OrderNo", (int)RowStatus.Normal, sbWhere);

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<ComResourceEntity>();
        }

        /// <summary>
        /// 获取数据列表
        /// 添加人：machao
        /// 添加时间：2018-09-11
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<ComResourceEntity> GetSearchResult(ComResourceEntity search)
        {
            var sbWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(search.ParentId))
            {
                sbWhere.AppendFormat(@" AND ParentId = '{0}'", search.ParentId);
            }
            if (!string.IsNullOrEmpty(search.RsKey))
            {
                sbWhere.AppendFormat(@" AND RsKey = '{0}'", search.RsKey);
            }
            if (!string.IsNullOrEmpty(search.Id))
            {
                sbWhere.AppendFormat(@" AND Id = '{0}'", search.Id);
            }
            var sbSql = string.Format(@"SELECT * FROM ComResource WHERE RowStatus={0} {1} ORDER BY OrderNo", (int)RowStatus.Normal, sbWhere);

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<ComResourceEntity>();
        }


        /// <summary>
        /// 根据ParentId获取字典列表
        /// </summary>
        public List<ComResourceEntity> GetListByParentId(string parentId)
        {
            var sbWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(parentId))
            {
                sbWhere.AppendFormat(@" AND ParentId = '{0}'", parentId);
            }
            var sbSql = string.Format(@"SELECT * FROM ComResource WHERE RowStatus={0} {1} ORDER BY OrderNo", (int)RowStatus.Normal, sbWhere);

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<ComResourceEntity>();
        }
    }
}

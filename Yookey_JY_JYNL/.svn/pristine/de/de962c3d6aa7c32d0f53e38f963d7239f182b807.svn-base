//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="InfPunishDocumentDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/1/7 11:04:12
//  功能描述：INF_PUNISH_DOCUMENT数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Data;
using Yookey;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// 文书数据访问操作
    /// </summary>
    public class InfPunishDocumentDal : DalImp.BaseDal<InfPunishDocumentEntity>
    {
        public InfPunishDocumentDal()
        {
            Model = new InfPunishDocumentEntity();
        }

        /// <summary>
        /// 执行存储过程,获取文书数据 
        /// 添加人：周 鹏
        /// 添加时间：2015-01-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="procedureName">存储过程</param>
        /// <param name="resourceId">办件编号</param>
        /// <returns>DataTable.</returns>
        public DataTable GetDataSource(string procedureName, string resourceId)
        {
            var strSql = string.Format(procedureName, resourceId);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 删除已生成的文书
        /// 添加人：叶念
        /// 添加时间：2015-03-05
        /// </summary>
        /// <param name="modelIdentify">类型</param>
        /// <param name="caseinfoId">案件编号</param>
        /// <returns></returns>
        public bool DeleteDocument(string modelIdentify, string caseinfoId)
        {
            var strSql = string.Format("DELETE INF_PUNISH_DOCUMENT WHERE ModelIdentify='{0}' AND CaseInfoId='{1}'", modelIdentify, caseinfoId);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 删除已生成的文书
        /// </summary>
        /// <param name="caseinfoId">案件编号</param>
        /// <returns></returns>
        public bool DeleteDocument(string caseinfoId)
        {
            var strSql = string.Format("DELETE INF_PUNISH_DOCUMENT WHERE CaseInfoId='{0}'", caseinfoId);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 删除已生成的文书
        /// 添加人：叶念
        /// 添加时间：2015-03-05
        /// </summary>
        /// <param name="modelIdentify">类型</param>
        /// <param name="caseinfoId">案件编号</param>
        /// <returns></returns>
        public bool DeleteDocumentLicense(string modelIdentify, string caseinfoId)
        {
            if (string.IsNullOrEmpty(caseinfoId))
                return false;
            var strSql = string.Format("DELETE INF_PUNISH_DOCUMENT WHERE  CaseInfoId='{0}'",caseinfoId);
            if (!string.IsNullOrEmpty(modelIdentify))
            {
               strSql += string.Format(" AND ModelIdentify='{0}'", modelIdentify);
            }
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 模板是否使用
        /// </summary>
        /// <returns></returns>
        public int IsUse()
        {
            var strSql = string.Format("SELECT IsUse FROM ComFileIsUse");
            var data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            if (data != null && data.Rows.Count > 0)
            {
                return int.Parse(data.Rows[0]["IsUse"].ToString());
            }
            return 0;
        }

        /// <summary>
        /// 模板是否使用
        /// </summary>
        /// <returns></returns>
        public void UpdateUse(int use)
        {
            var strSql = string.Format("UPDATE ComFileIsUse SET IsUse={0}", use);
            SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql);
        }
    }
}


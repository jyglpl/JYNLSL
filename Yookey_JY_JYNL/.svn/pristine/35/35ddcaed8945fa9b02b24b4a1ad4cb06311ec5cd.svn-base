//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="PunishmentDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2017/11/30 13:27:37
//  功能描述：Punishment数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// Punishment数据访问操作
    /// </summary>
    public class PunishmentDal : DalImp.BaseDal<PunishmentEntity>
    {
        public PunishmentDal()
        {
            Model = new PunishmentEntity();
        }

        /// <summary>
        /// 处罚公示数据查询
        /// </summary>
        /// <history>
        /// </history>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable QueryPunishmentlist(string keyword, int pageSize,
                                       int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT Id,CF_WSH,CF_AJMC,CF_XDR_MC,CF_JDRQ,WhetherPublic,IsPush,CreateOn FROM Punishment");

                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(" WHERE CF_AJMC LIKE '%{0}%' OR CF_XDR_MC LIKE '%{0}%' OR CF_WSH LIKE '%{0}%'", keyword);
                }

                var sortField = "CreateOn"; //排序字段
                var sortType = "DESC"; //排序类型

                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField,
                                                sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 批量保存处罚公示数据
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public bool TransactionSavePunishment(List<PunishmentEntity> lists)
        {
            var transaction = new TransactionLoader().BeginTransaction("TransactionSavePunishment");
            try
            {
                foreach (PunishmentEntity entity in lists)
                {
                    Add(entity, transaction);

                    //更新同步标识
                    var sbSql = new StringBuilder("");
                    sbSql.AppendFormat("UPDATE INF_PUNISH_CASEINFO SET IsPublic=1 WHERE Id='{0}'", entity.CASEINFOID);
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 获取未推送的处罚信息
        /// </summary>
        /// <returns></returns>
        public List<PunishmentEntity> GetUnPushPunishments()
        {
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(@"SELECT * FROM Punishment WHERE WhetherPublic=1 AND RowStatus=1 AND IsPush=0");
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<PunishmentEntity>();
        }

        /// <summary>
        /// 批量向前置数据库推送
        /// </summary>
        /// <returns></returns>
        public bool TransactionPushPunishment(List<PunishmentEntity> lists)
        {
            var pushTransaction = new TransactionLoader().BeginTransaction("TransactionPushPunishment", SqlHelper.CreditSqlConnStringWrite);
            var transaction = new TransactionLoader().BeginTransaction("TransactionUpdataPunishment");

            try
            {
                foreach (var entity in lists)
                {
                    var pushSql = new StringBuilder("");
                    pushSql.AppendFormat(@"INSERT INTO [Punishment]([Id],[CF_WSH],[CF_AJMC],[CF_BM],[CF_CFLB1],
[CF_CFLB2],[CF_SY],[CF_YJ],[CF_XDR_MC],[CF_XDR_SHXYM],[CF_XDR_ZDM],[CF_XDR_GSDJ],[CF_XDR_SWDJ],[CF_XDR_SFZ],
[CF_FR],[CF_JG],[CF_JDRQ],[CF_XZJG],[CF_ZT],[DFBM],[SJC],[BZ],[CF_SYFW],[CF_SXYZCD],[CF_GSJZQ],[CreateOn],[UpdateOn]) VALUES 
('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',
'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}',
'{21}','{22}','{23}','{24}','{25}','{26}')",
entity.Id, entity.CF_WSH, entity.CF_AJMC, entity.CF_BM, entity.CF_CFLB1, entity.CF_CFLB2, entity.CF_SY, entity.CF_YJ,
entity.CF_XDR_MC, entity.CF_XDR_SHXYM, entity.CF_XDR_ZDM, entity.CF_XDR_GSDJ, entity.CF_XDR_SWDJ, entity.CF_XDR_SFZ,
entity.CF_FR, entity.CF_JG, entity.CF_JDRQ.ToString("yyyy/MM/dd"), entity.CF_XZJG, entity.CF_ZT, entity.DFBM, entity.SJC, entity.BZ, entity.CF_SYFW,
entity.CF_SXYZCD, entity.CF_JDRQ.AddYears(3).ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    SqlHelper.ExecuteNonQuery(pushTransaction, CommandType.Text, pushSql.ToString());

                    var upSql = new StringBuilder("");
                    upSql.AppendFormat("UPDATE Punishment SET IsPush=1 WHERE Id='{0}'", entity.Id);

                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, upSql.ToString());
                }
            }
            catch (Exception ex)
            {
                pushTransaction.Rollback();
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }
            pushTransaction.Commit();
            transaction.Commit();
            return true;
        }
    }
}


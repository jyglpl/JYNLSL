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
using Yookey.WisdomClassed.SIP.Model.License;
using Yookey.WisdomClassed.SIP.Common;
using System.Linq;

namespace Yookey.WisdomClassed.SIP.DataAccess.License
{
    /// <summary>
    /// Punishment数据访问操作
    /// </summary>
    public class LicensePulicityDal : DalImp.BaseDal<LicensePulicityEntity>
    {
        public LicensePulicityDal()
        {
            Model = new LicensePulicityEntity();
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
        public DataTable QueryLicensePulicitylist(string keyword, int pageSize,
                                       int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT ID,XK_WSH,XK_XMMC,XK_XDR,XK_JDRQ,WHETHERPUBLIC,ISPUSH,CREATEON FROM [DBO].[LICENSEPULICITY]");

                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(" WHERE XK_XMMC LIKE '%{0}%' OR XK_XDR LIKE '%{0}%' OR XK_WSH LIKE '%{0}%'", keyword);
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
        public bool TransactionSaveLicensePulicity(List<LicensePulicityEntity> lists)
        {
            var transaction = new TransactionLoader().BeginTransaction("TransactionSaveLicensePulicity");
            try
            {
                foreach (LicensePulicityEntity entity in lists)
                {
                    Add(entity, transaction);

                    //更新同步标识
                    var sbSql = new StringBuilder("");
                    sbSql.AppendFormat("UPDATE LICENSEMAIN SET IsPublic=1 WHERE Id='{0}'", entity.LicenseId);
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
        public DataTable GetUnPushPunishments()
        {
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(@"SELECT * FROM LICENSEPULICITY WHERE WhetherPublic=1 AND RowStatus=1 AND IsPush=0");
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? list.Tables[0] : new DataTable();
        }

        /// <summary>
        /// 批量向前置数据库推送
        /// </summary>
        /// <returns></returns>
        public bool TransactionPushPunishment(DataTable lists)
        {
            if (lists == null || lists.Rows.Count <= 0)
                return false;
            try
            {
                lists.Columns.Remove("LicenseId");
                lists.Columns.Remove("IsPush");
                lists.Columns.Remove("WhetherPublic");
                CollectionHelper.SqlBulkCopyByDatatable(SqlHelper.CreditSqlConnStringWrite, LicensePulicityEntity.TB_LicensePulicity,lists);
                UpIsUp(string.Join("','",lists.Select().Select(i=>i["Id"].ToString())));//更新已经上传
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public bool UpIsUp(string ids)
        {
            try
            {
                if (string.IsNullOrEmpty(ids))
                    return false;
                var upSql = new StringBuilder("");
                upSql.AppendFormat("UPDATE LicensePulicity SET IsPush=1 WHERE Id in ('{0}')", ids);
                SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, upSql.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}


using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty
{
    public class PunishCaseDal
    {
        /// <summary>
        /// 请求执法案件信息列表
        /// </summary>
        /// <param name="caseName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable QueryPunishCaseList(string caseNo, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM VIEW_ZFAJ WHERE 1 = 1");
                if (!string.IsNullOrEmpty(caseNo))
                {
                    strSql.AppendFormat(" AND 案件编号 LIKE '%{0}%'", caseNo);
                }
                var sortField = "案件编号";
                var sortType = "DESC";
                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询执法案件列表
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPunishCaseList()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM VIEW_ZFAJ WHERE 1 = 1");

                return SqlHelper.QueryBySql(SqlHelper.SqlConnStringRead, strSql.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取案件详情
        /// </summary>
        /// <param name="CaseNo"></param>
        /// <returns></returns>
        public DataTable GetPunishCaseDetail(string CaseNo)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM VIEW_ZFAJ WHERE 1=1 AND 案件编号 = '{0}'", CaseNo);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty
{
    public class LawpersonnelDal
    {
        /// <summary>
        /// 请求执法人员信息列表
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable QueryLawpersonnelList(string userName, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM VIEW_ZFRY WHERE 1 = 1");
                if (!string.IsNullOrEmpty(userName))
                {
                    strSql.AppendFormat(" AND 姓名 LIKE '%{0}%'", userName);
                }
                var sortField = "姓名";
                var sortType = "ASC";
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
        /// 获取执法人员数
        /// </summary>
        /// <returns></returns>
        public DataTable QueryLawpersonnelList()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM VIEW_ZFRY WHERE 1=1  ");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取执法人员详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetLawpersonnelDetail(string userName)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM VIEW_ZFRY WHERE 1=1 AND 姓名 = '{0}' ", userName);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

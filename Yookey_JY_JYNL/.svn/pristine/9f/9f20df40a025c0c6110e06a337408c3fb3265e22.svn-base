using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty
{
    public class InspectionDal
    {
        /// <summary>
        /// 请求现场检查列表
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable QueryInspectionList(string companyName, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM VIEW_ZFJC WHERE 1 = 1");
                if (!string.IsNullOrEmpty(companyName))
                {
                    strSql.AppendFormat(" AND 企业名称 LIKE '%{0}%'", companyName);
                }
                var sortField = "检查开始时间";
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
        /// 查询现场检查列表
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInspectionList(string date)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM VIEW_ZFJC WHERE 1 = 1");
                if (!string.IsNullOrEmpty(date))
                {
                    DateTime dt = Convert.ToDateTime(date);
                    string StartDate = dt.AddDays(1 - dt.Day).ToString("yyyy-MM-dd");
                    string EndDate = dt.AddDays(1 - dt.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                    strSql.Append("and 检查开始时间 >= '" + StartDate + "' and 检查开始时间 <= '" + EndDate + "'");
                }

                return SqlHelper.QueryBySql(SqlHelper.SqlConnStringRead, strSql.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取现场检查记录详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetInspectionDetail(string Id)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM VIEW_ZFJC WHERE 1=1 AND 现检ID = '{0}'", Id);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据时间段查询现场检查条数按日期返回
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInspectionListForDateTime(string DateTime)
        {
            try
            {
                string sql = "";
                if (!string.IsNullOrEmpty(DateTime))
                {
                    DateTime dt = Convert.ToDateTime(DateTime);
                    string StartDate = dt.AddDays(1 - dt.Day).ToString("yyyy-MM-dd");
                    string EndDate = dt.AddDays(1 - dt.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                    sql = "and 检查开始时间 >= '" + StartDate + "' and 检查开始时间 <= '" + EndDate + "'";
                }

                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"select Convert(varchar(100),检查开始时间,23) date,count(检查开始时间) ct from [dbo].[VIEW_ZFJC]
where 所属区镇 is not null
{0}
group by Convert(varchar(100),检查开始时间,23)
order by Convert(varchar(100),检查开始时间,23)", sql);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

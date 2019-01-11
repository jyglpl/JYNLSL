using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty
{
   public class CorrectiveReviewDal
    {
        /// <summary>
        /// 请求执法依据信息列表
        /// </summary>
        /// <param name="lawName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
       public DataTable QueryCorrectiveReviewList(string lawName, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM VIEW_ZGFC WHERE 1 = 1");
                if (!string.IsNullOrEmpty(lawName))
                {
                    strSql.AppendFormat(" AND 检查场所 LIKE '%{0}%'", lawName);
                }
                var sortField = "检查时间";
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
       /// 查询整改复查列表
       /// </summary>
       /// <returns></returns>
       public DataTable QueryCorrectiveReviewList(string date)
       {
           try
           {
               var strSql = new StringBuilder("");
               strSql.Append(@"SELECT * FROM VIEW_ZGFC WHERE 1 = 1");
               if (!string.IsNullOrEmpty(date))
               {
                   DateTime dt = Convert.ToDateTime(date);
                   string StartDate = dt.AddDays(1 - dt.Day).ToString("yyyy-MM-dd");
                   string EndDate = dt.AddDays(1 - dt.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                   strSql.Append("and 检查时间 >= '" + StartDate + "' and 检查时间 <= '" + EndDate + "'");
               }

               return SqlHelper.QueryBySql(SqlHelper.SqlConnStringRead, strSql.ToString());
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message, ex);
           }
       }

       /// <summary>
       /// 获取整改复查详情
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public DataTable GetCorrectiveReviewDetail(string Id)
       {
           try
           {
               var strSql = new StringBuilder("");
               strSql.AppendFormat("SELECT * FROM VIEW_ZGFC WHERE 1=1 AND 复查ID = '{0}'", Id);
               return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message, ex);
           }
       }
    }
}

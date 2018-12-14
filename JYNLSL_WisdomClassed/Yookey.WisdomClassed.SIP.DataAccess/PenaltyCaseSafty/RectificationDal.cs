using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty
{
  public class RectificationDal
    {
        /// <summary>
        /// 请求责令整改信息列表
        /// </summary>
        /// <param name="lawName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
      public DataTable QueryRectificationList(string lawName, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM VIEW_ZLZG WHERE 1 = 1");
                if (!string.IsNullOrEmpty(lawName))
                {
                    strSql.AppendFormat(" AND 执法人员 LIKE '%{0}%'", lawName);
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
      /// 查询责令整改列表
      /// </summary>
      /// <returns></returns>
      public DataTable QueryRectificationList(string date)
      {
          try
          {
              var strSql = new StringBuilder("");
              strSql.Append(@"SELECT * FROM VIEW_ZLZG WHERE 1 = 1");
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
      /// 获取责令整改详情
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
      public DataTable GetRectificationDetail(string Id)
      {
          try
          {
              var strSql = new StringBuilder("");
              strSql.AppendFormat("SELECT * FROM VIEW_ZLZG WHERE 1=1 AND 责改ID = '{0}'", Id);
              return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
          }
          catch (Exception ex)
          {
              throw new Exception(ex.Message, ex);
          }
      }
    }
}

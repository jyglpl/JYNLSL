using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty
{
  public  class LawbasisDal
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
      public DataTable QueryLawbasisList(string lawName, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
      {
          try
          {
              var strSql = new StringBuilder("");
              strSql.Append(@"SELECT * FROM VIEW_ZFYJ WHERE 1 = 1");
              if (!string.IsNullOrEmpty(lawName))
              {
                  strSql.AppendFormat(" AND 法律法规名称 LIKE '%{0}%'", lawName);
              }
              var sortField = "法律法规名称";
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
      /// 获取执法依据详情
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
      public DataTable GetLawbasisDetail(string lawName, string lawterm)
      {
          try
          {
              var strSql = new StringBuilder("");
              strSql.AppendFormat("SELECT * FROM VIEW_ZFYJ WHERE 1=1 AND 法律法规名称 = '{0}' AND 法律法规条款='{1}'", lawName, lawterm);
              return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
          }
          catch (Exception ex)
          {
              throw new Exception(ex.Message, ex);
          }
      }
    }
}

using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty
{
   public class CheckrectificationDal
    {
       /// <summary>
       /// 请求整改复查信息列表
       /// </summary>
       /// <param name="peopleName"></param>
       /// <param name="pageSize"></param>
       /// <param name="pageIndex"></param>
       /// <param name="sidx"></param>
       /// <param name="sord"></param>
       /// <param name="totalRecords"></param>
       /// <returns></returns>
       public DataTable QuerycheckList(string peopleName, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
       {
           try
           {
               var strSql = new StringBuilder("");
               strSql.Append(@"SELECT * FROM VIEW_ZGFC WHERE 1 = 1");
               if (!string.IsNullOrEmpty(peopleName))
               {
                   strSql.AppendFormat(" AND 检查人员 LIKE '%{0}%'", peopleName);
               }
               var sortField = "检查人员";
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
    }
}

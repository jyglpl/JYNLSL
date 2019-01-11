using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty;
using Yookey.WisdomClassed.SIP.Model;

namespace Yookey.WisdomClassed.SIP.Business.PenaltyCaseSafty
{
  public  class LawbasisBll
    {
      private readonly LawbasisDal _dal = new LawbasisDal();

      /// <summary>
      /// 请求执法依据信息列表
      /// </summary>
      /// <param name="lawName"></param>
      /// <param name="sidx"></param>
      /// <param name="sord"></param>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <returns></returns>
      public PageJqDatagrid<DataTable> QueryLawbasisList(string lawName, string sidx, string sord, int pageSize = 15, int pageIndex = 1)
      {
          //计时
          var stopwatch = new Stopwatch();
          stopwatch.Start();
          int totalRecords;

          var data = _dal.QueryLawbasisList(lawName, pageSize, pageIndex, sidx, sord, out  totalRecords);

          data.TableName = "LawbasisDT";
          stopwatch.Stop();
          int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
          return new PageJqDatagrid<DataTable>
          {
              page = pageIndex,
              rows = data,
              total = totalPage,
              records = totalRecords,
              costtime = stopwatch.ElapsedMilliseconds.ToString()
          };
      }

      /// <summary>
      /// 获取执法依据详情
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
      public DataTable GetLawbasisDetail(string lawName, string lawterm)
      {
          return _dal.GetLawbasisDetail(lawName, lawterm);
      }
    }
}

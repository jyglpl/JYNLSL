using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty;

namespace Yookey.WisdomClassed.SIP.Business.PenaltyCaseSafty
{
  public  class CheckrectificationBll
    {
      private readonly CheckrectificationDal _dal = new CheckrectificationDal();


      public PageJqDatagrid<DataTable> QueryLawcheckList(string peopleName, string sidx, string sord, int pageSize = 15, int pageIndex = 1)
      {
          //计时
          var stopwatch = new Stopwatch();
          stopwatch.Start();
          int totalRecords;

          var data = _dal.QuerycheckList(peopleName, pageSize, pageIndex, sidx, sord, out  totalRecords);

          data.TableName = "EnterpriseDT";
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
    }
}

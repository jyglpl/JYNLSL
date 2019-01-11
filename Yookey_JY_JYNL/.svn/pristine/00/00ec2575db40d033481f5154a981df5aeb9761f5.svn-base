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
   public  class RectificationBll
    {
       private readonly RectificationDal _dal = new RectificationDal();

       /// <summary>
       /// 请求责令整改信息列表
       /// </summary>
       /// <param name="lawName"></param>
       /// <param name="sidx"></param>
       /// <param name="sord"></param>
       /// <param name="pageSize"></param>
       /// <param name="pageIndex"></param>
       /// <returns></returns>
       public PageJqDatagrid<DataTable> QueryRectificationList(string lawName, string sidx, string sord, int pageSize = 15, int pageIndex = 1)
       {
           //计时
           var stopwatch = new Stopwatch();
           stopwatch.Start();
           int totalRecords;

           var data = _dal.QueryRectificationList(lawName, pageSize, pageIndex, sidx, sord, out  totalRecords);

           data.TableName = "RectificationDT";
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
       /// 查询责令整改所有信息
       /// </summary>
       /// <returns></returns>
       public DataTable QueryRectificationList(string date)
       {
           return _dal.QueryRectificationList(date);
       }

       /// <summary>
       /// 获取责令整改详情
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public DataTable GetRectificationDetail(string Id)
       {
           return _dal.GetRectificationDetail(Id);
       }
    }
}

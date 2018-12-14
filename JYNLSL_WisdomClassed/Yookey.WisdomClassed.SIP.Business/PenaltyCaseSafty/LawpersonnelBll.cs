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
   public class LawpersonnelBll
    {
       private readonly LawpersonnelDal _dal = new LawpersonnelDal();

       /// <summary>
       /// 请求执法人员信息列表
       /// </summary>
       /// <param name="userName"></param>
       /// <param name="sidx"></param>
       /// <param name="sord"></param>
       /// <param name="pageSize"></param>
       /// <param name="pageIndex"></param>
       /// <returns></returns>
       public PageJqDatagrid<DataTable> QueryLawpersonnelList(string userName, string sidx, string sord, int pageSize = 15, int pageIndex = 1)
       {
           //计时
           var stopwatch = new Stopwatch();
           stopwatch.Start();
           int totalRecords;

           var data = _dal.QueryLawpersonnelList(userName, pageSize, pageIndex, sidx, sord, out  totalRecords);

           data.TableName = "LawpersonnelDT";
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
       /// 获取执法人员数
       /// </summary>
       /// <returns></returns>
       public DataTable QueryLawpersonnelList()
       {
           return _dal.QueryLawpersonnelList();
       }


       /// <summary>
       /// 获取执法人员详情
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public DataTable GetLawpersonnelDetail(string userName)
       {
           return _dal.GetLawpersonnelDetail(userName);
       }
    }
}

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
    public class InspectionBll
    {
        private readonly InspectionDal _dal = new InspectionDal();

        /// <summary>
        /// 请求现场检查列表
        /// </summary>
        /// <param name="enterpriseName"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryInspectionList(string companyName, string sidx, string sord, int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = _dal.QueryInspectionList(companyName, pageSize, pageIndex, sidx, sord, out  totalRecords);

            data.TableName = "InspectionDT";
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
        /// 查询现场检查所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInspectionList(string date)
        {
            return _dal.QueryInspectionList(date);
        }

        /// <summary>
        /// 获取现场检查记录详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetInspectionDetail(string Id)
        {
            return _dal.GetInspectionDetail(Id);
        }

        /// <summary>
        /// 根据时间段查询现场检查条数按日期返回
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInspectionListForDateTime(string DateTime)
        {
            return _dal.QueryInspectionListForDateTime(DateTime);
        }
    }
}

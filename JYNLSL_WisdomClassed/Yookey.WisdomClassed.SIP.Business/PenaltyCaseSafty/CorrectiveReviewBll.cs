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
    public class CorrectiveReviewBll
    {
        private readonly CorrectiveReviewDal _dal = new CorrectiveReviewDal();

        /// <summary>
        /// 请求整改复查信息列表
        /// </summary>
        /// <param name="lawName"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryCorrectiveReviewList(string lawName, string sidx, string sord, int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = _dal.QueryCorrectiveReviewList(lawName, pageSize, pageIndex, sidx, sord, out  totalRecords);

            data.TableName = "CorrectiveReviewDT";
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
        /// 查询整改复查所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCorrectiveReviewList(string date)
        {
            return _dal.QueryCorrectiveReviewList(date);
        }

        /// <summary>
        /// 获取整改复查详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetCorrectiveReviewDetail(string Id)
        {
            return _dal.GetCorrectiveReviewDetail(Id);
        }
    }
}

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
    public class PunishCaseBll
    {
        private readonly PunishCaseDal _dal = new PunishCaseDal();

        /// <summary>
        /// 请求执法案件信息列表
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryPunishCaseList(string caseNo, string sidx, string sord, int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = _dal.QueryPunishCaseList(caseNo, pageSize, pageIndex, sidx, sord, out  totalRecords);

            data.TableName = "PunishCaseDT";
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
        /// 查询执法案件信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPunishCaseList()
        {
            return _dal.QueryPunishCaseList();
        }

        /// <summary>
        /// 获取案件详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetPunishCaseDetail(string CaseNo)
        {
            return _dal.GetPunishCaseDetail(CaseNo);
        }
    }
}

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
    public class EnterpriseBll
    {
        private readonly EnterpriseDal _dal = new EnterpriseDal();

        /// <summary>
        /// 请求企业信息列表
        /// </summary>
        /// <param name="companyName">企业名称</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryEnterpriseList(string companyName, string sidx, string sord, int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = _dal.QueryEnterpriseList(companyName, pageSize, pageIndex, sidx, sord, out  totalRecords);

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

        /// <summary>
        /// 查询所有企业信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryEnterpriseList()
        {
            return _dal.QueryEnterpriseList();
        }

        /// <summary>
        /// 获取企业详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetEnterpriseDetail(string CompanyName)
        {
            return _dal.GetEnterpriseDetail(CompanyName);
        }



        #region 统计分析数据

        /// <summary>
        /// 查询所属区镇企业数
        /// </summary>
        /// <returns></returns>
        public DataTable QueryEnterpriseListForAnalysis()
        {
            return _dal.QueryEnterpriseListForAnalysis();
        }


        #endregion
    }
}

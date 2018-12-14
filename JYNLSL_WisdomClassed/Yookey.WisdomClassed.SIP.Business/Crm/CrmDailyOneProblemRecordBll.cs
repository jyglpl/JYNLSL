
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// 每日一题 答题记录 业务逻辑
    /// </summary>
    public class CrmDailyOneProblemRecordBll : BaseBll<CrmDailyOneProblemRecordEntity>
    {
        CrmDailyOneProblemRecordDal _crmDailyOneProblemRecordDal = new CrmDailyOneProblemRecordDal();
        public CrmDailyOneProblemRecordBll()
        {
            BaseDal = new CrmDailyOneProblemRecordDal();
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetSearchResult(string companyId, string deptId, string userId, string question, int pageIndex, int pageSize, string starttime, string endtime)
        {
            int totalRecords;

            DataTable dt = _crmDailyOneProblemRecordDal.GetSearchResult(companyId, deptId, userId, question, pageIndex, pageSize, starttime, endtime, out totalRecords);

            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new Model.PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = dt,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 是否已答过题
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsExistDailyOneProblemBy(string userId, string dTime)
        {
            return _crmDailyOneProblemRecordDal.IsExistDailyOneProblemBy(userId, dTime);
        }

        /// <summary>
        /// 正确率Top10
        /// </summary>
        /// <returns></returns>
        public DataTable GetCorrectRateTopTen(int topNum = 10)
        {
            return _crmDailyOneProblemRecordDal.GetCorrectRateTopTen(topNum);
        }


        /// <summary>
        /// 获取答题率
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="deptId"></param>
        /// <param name="keywords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetCorrectRate(string companyId, string deptId, string keywords, int pageIndex, int pageSize)
        {
            int totalRecords;

            DataTable dt = _crmDailyOneProblemRecordDal.GetCorrectRate(companyId, deptId, keywords, pageIndex, pageSize, out totalRecords);

            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new Model.PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = dt,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }
    }
}


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// 每日一题 业务逻辑
    /// </summary>
    public class CrmDailyOneProblemBll : BaseBll<CrmDailyOneProblemEntity>
    {
        CrmDailyOneProblemDal _Dal = new CrmDailyOneProblemDal();
        public CrmDailyOneProblemBll()
        {
            BaseDal = new CrmDailyOneProblemDal();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public JqDataGrid<CrmDailyOneProblemEntity> GetSearchResult(CrmDailyOneProblemEntity search, string starttime, string endtime)
        {
            int totalRecords;
            List<CrmDailyOneProblemEntity> data = _Dal.GetSearchResult(search, starttime, endtime, out totalRecords);

            return CommonMethod.ConvertToJqDataGrid(search.PageIndex, search.PageSize, totalRecords, data);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return _Dal.BatchDelete(ids);
        }

        /// <summary>
        /// 取指定日期的每日一题
        /// </summary>
        /// <param name="appointedDay"></param>
        /// <returns></returns>
        public CrmDailyOneProblemEntity GetPublicDayQuestionByAppointedDay()
        {
            return _Dal.GetPublicDayQuestionByAppointedDay();
        }
    }
}

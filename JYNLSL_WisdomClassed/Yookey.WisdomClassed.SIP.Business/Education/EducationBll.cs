using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Education;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Education;

namespace Yookey.WisdomClassed.SIP.Business.Education
{
    /// <summary>
    /// Education业务逻辑
    /// </summary>
    public class EducationBll : BaseBll<EducationEntity>
    {
        public EducationBll()
        {
            BaseDal = new EducationDal();
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="companyId">查询单位ID</param>
        /// <param name="departmentId">查询部门ID</param>
        /// <param name="caseType">案件类型</param>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">截止日期</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页请求条数</param>
        /// <returns></returns>
        public PageJqDatagrid<EducationEntity> GetSearchResult(string companyId, string departmentId, string caseType, string beginDate, string endDate, string keyword, int pageSize, int pageIndex)
        {
            int totalRecords;
            var data = new EducationDal().GetSearchResult(companyId, departmentId, caseType, beginDate, endDate, keyword, pageSize, pageIndex, out totalRecords);
            var totalPage = (totalRecords + pageSize - 1) / pageSize;
            return new PageJqDatagrid<EducationEntity>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords
            };
        }
        /// <summary>
        /// 获取教育纠处详情
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public DataTable GetEducationDetails(string id)
        {
            try
            {
                var data = new EducationDal().GetEducationDetails(id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

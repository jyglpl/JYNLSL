using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Education;

namespace Yookey.WisdomClassed.SIP.DataAccess.Education
{
    /// <summary>
    /// Education数据访问操作
    /// </summary>
    public class EducationDal : DalImp.BaseDal<EducationEntity>
    {
        public EducationDal()
        {
            Model = new EducationEntity();
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
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable GetSearchResult(string companyId, string departmentId, string caseType, string beginDate, string endDate, string keyword, int pageSize, int pageIndex, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.Append(@"SELECT EC.Id,EC.TargetName,FirstUserName,SecondUserName,CC.Id AS CompanyId,CC.FullName AS CompanyName,
CD.Id AS DepartmentId,CD.FullName AS DepartmentName,LG.ClassNo,LG.ClassName, EC.ItemName,convert(varchar(10),EC.EducationTime,120) AS EducationTime,EC.EducationAddress 
FROM Education AS EC WITH(NOLOCK)
JOIN CrmDepartment AS CD WITH(NOLOCK) ON CD.Id=EC.DepartmentId
JOIN CrmCompany AS CC WITH(NOLOCK) ON CD.CompanyId=CC.Id
JOIN Legislation AS LG WITH(NOLOCK) ON EC.LegislationId=LG.Id
WHERE EC.RowStatus=1");

            if (!companyId.Equals("all"))
            {
                strSql.AppendFormat(" AND CC.Id='{0}'", companyId);
            }
            if (!string.IsNullOrEmpty(departmentId) && !departmentId.Equals("all"))
            {
                strSql.AppendFormat(" AND CD.Id='{0}'", departmentId);
            }
            if (!string.IsNullOrEmpty(caseType))
            {
                strSql.AppendFormat(" AND LG.ClassNo='{0}' ", caseType);
            }
            if (!string.IsNullOrEmpty(beginDate))
            {
                strSql.AppendFormat(" AND EC.EducationTime>='{0}'", beginDate);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                strSql.AppendFormat(" AND EC.EducationTime<='{0} 23:59:59'", endDate);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                strSql.AppendFormat(" AND (EC.DepartmentName LIKE '%{0}%' OR EC.FirstUserName LIKE '%{0}%' OR EC.SecondUserName LIKE '%{0}%' OR EC.EducationAddress LIKE '%{0}%')", keyword);
            }

            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "EducationTime", "Desc", pageIndex, pageSize, out totalRecords);
        }


        /// <summary>
        /// 查询纠处详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetEducationDetails(string id)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM dbo.Education WHERE id = '{0}'", id);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

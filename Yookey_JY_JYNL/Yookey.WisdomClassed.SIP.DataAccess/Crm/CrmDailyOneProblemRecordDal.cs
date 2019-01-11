using DBHelper;
using System;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// 每日一题 答题记录 数据访问操作
    /// </summary>
    public class CrmDailyOneProblemRecordDal : DalImp.BaseDal<CrmDailyOneProblemRecordEntity>
    {
        public CrmDailyOneProblemRecordDal()
        {
            Model = new CrmDailyOneProblemRecordEntity();
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public DataTable GetSearchResult(string companyId, string deptId, string userId, string question, int pageIndex, int pageSize, string starttime, string endtime, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT record.Id,record.ProblemId,record.UserId,record.UserName,record.RightAnswer,record.UserAnswers,
record.IsCorrect,record.CreateOn,problem.QuestionsTypeName,problem.Question,problem.OptionA,problem.OptionB,
problem.OptionC,problem.OptionD,problem.OptionE,problem.OptionF,problem.OptionG,problem.Answer
FROM CrmDailyOneProblemRecord record WITH(NOLOCK)
INNER JOIN CrmDailyOneProblem problem WITH(NOLOCK) ON record.ProblemId=problem.Id
INNER JOIN CrmUser crmuser WITH(NOLOCK) ON record.UserId=crmuser.Id
WHERE record.RowStatus=1 ");

            if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
            {
                strSql.AppendFormat(" AND crmuser.CompanyId='{0}'", companyId);
            }
            if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
            {
                strSql.AppendFormat(" AND crmuser.DepartmentId='{0}'", deptId);
            }

            if (!string.IsNullOrEmpty(question))
            {
                strSql.AppendFormat(" AND problem.Question LIKE '%{0}%'", question);
            }

            if (!string.IsNullOrEmpty(userId))
            {
                strSql.AppendFormat(" AND record.UserId = '{0}' ", userId);
            }

            if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
            {
                strSql.AppendFormat(" AND record.CreateOn BETWEEN '{0}' AND '{1} 23:59:59'", starttime, endtime);
            }

            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSize, out totalRecords);
            return data;
        }


        /// <summary>
        /// 是否已答过题
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsExistDailyOneProblemBy(string userId, string dTime)
        {
            try
            {
                var sbSql = new StringBuilder();

                sbSql.AppendFormat("SELECT COUNT(*) FROM CrmDailyOneProblemRecord WHERE UserId='{0}' AND CONVERT(VARCHAR(10), CreateOn, 23)='{1}'", userId, dTime);
                var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
                //今日答题次数
                var todayRecord = obj != null ? int.Parse(obj.ToString()) : 0;
                if (todayRecord >= 2)
                {
                    return true;
                }
                else
                {
                    sbSql = new StringBuilder();
                    sbSql.AppendFormat(" SELECT COUNT(*) FROM CrmDailyOneProblemRecord WHERE IsCorrect=1 AND UserId='{0}' AND CONVERT(VARCHAR(10), CreateOn, 23)='{1}' ", userId, dTime);
                    obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
                    return obj != null && int.Parse(obj.ToString()) >= 1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 正确率Top10
        /// </summary>
        /// <returns></returns>
        public DataTable GetCorrectRateTopTen(int topNum = 10)
        {
            try
            {
                string sql = string.Format(@"SELECT Top {0} UserId,UserName,
SUM(CASE WHEN IsCorrect=1 THEN 1 ELSE 0 END) CorrectSum,
COUNT(*) ProblemSum,
Round((CONVERT(FLOAT,SUM(CASE WHEN IsCorrect=1 THEN 1 ELSE 0 END))/CONVERT(FLOAT,COUNT(*)))*100 ,2) CorrectRate
FROM dbo.CrmDailyOneProblemRecord
GROUP BY UserId,UserName
ORDER BY CorrectRate desc", topNum);

                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sql).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取答题率
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="deptId"></param>
        /// <param name="keywords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable GetCorrectRate(string companyId, string deptId, string keywords, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT UserId,UserName,
SUM(CASE WHEN IsCorrect=1 THEN 1 ELSE 0 END) CorrectSum,
COUNT(*) ProblemSum,
Round((CONVERT(FLOAT,SUM(CASE WHEN IsCorrect=1 THEN 1 ELSE 0 END))/CONVERT(FLOAT,COUNT(*)))*100 ,2) CorrectRate
FROM dbo.CrmDailyOneProblemRecord AS record
INNER JOIN CrmUser crmuser WITH(NOLOCK) ON record.UserId=crmuser.Id WHERE 1=1 ");


                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat(" AND crmuser.CompanyId='{0}'", companyId);
                }
                if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
                {
                    strSql.AppendFormat(" AND crmuser.DepartmentId='{0}'", deptId);
                }
                if (!string.IsNullOrEmpty(keywords))
                {
                    strSql.AppendFormat(" AND crmuser.RealName LIKE '%{0}%'", keywords);
                }

                strSql.Append(" GROUP BY UserId,UserName ");

                var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CorrectRate", "DESC", pageIndex, pageSize, out totalRecords);
                return data;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}


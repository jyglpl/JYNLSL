using DBHelper;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// 每日一题 数据访问操作
    /// </summary>
    public class CrmDailyOneProblemDal : DalImp.BaseDal<CrmDailyOneProblemEntity>
    {
        public CrmDailyOneProblemDal()
        {
            Model = new CrmDailyOneProblemEntity();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<CrmDailyOneProblemEntity> GetSearchResult(CrmDailyOneProblemEntity search, string starttime, string endtime, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT Id,QuestionBankType,QuestionsTypeId,QuestionsTypeName,Question,OptionA,OptionB
      ,OptionC,OptionD,OptionE,OptionF,OptionG,Answer,Time,AppointedDay
      ,RowStatus,CreatorId,CreateBy,CreateOn,UpdateId,UpdateBy,UpdateOn
FROM CrmDailyOneProblem WHERE 1 = 1");
            if (search.RowStatus == 1)
            {
                strSql.AppendFormat(" AND RowStatus ={0} ", search.RowStatus);
            }
            if (!string.IsNullOrEmpty(search.Question))
            {
                strSql.AppendFormat(" AND Question LIKE '%{0}%'", search.Question);
            }
            if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
            {
                strSql.AppendFormat(" AND CreateOn BETWEEN '{0}' AND '{1}'", starttime, endtime);
            }

            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "DESC", search.PageIndex, search.PageSize, out totalRecords);
            return DataTableToList(data);
        }


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE Public_DayQuestion SET RowStatus =0 WHERE Id  IN ({0})", ids.Trim(','));

            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }

        /// <summary>
        ///随机的每日一题
        /// </summary>
        /// <param name="appointedDay"></param>
        /// <returns></returns>
        public CrmDailyOneProblemEntity GetPublicDayQuestionByAppointedDay()
        {
            string sql = "SELECT Top 1 * FROM [CrmDailyOneProblem] WITH(NOLOCK) WHERE RowStatus =1 ORDER BY NEWID() ";

            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sql).Tables[0];
            List<CrmDailyOneProblemEntity> list = DataTableToList(dt);
            return list.FirstOrDefault();
        }
    }
}


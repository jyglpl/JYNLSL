using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.DataAccess.Approval
{
    public class TmMatterApplyMajorDal : BaseDal<TmMatterApplyMajorEntity>
    {
        public List<TmMatterApplyMajorEntity> GetSearchResult(TmMatterApplyMajorEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TM_MATTER_APPLY_MAJOR WHERE DELETED = 0 AND ACCEPT_TIME IS NOT NULL AND APPLY_STATUS NOT IN ('SAVE', 'UN_ACCEPTED')");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(@" AND ID='{0}'", search.ID);
            }
            if (!string.IsNullOrEmpty(search.ACCEPT_TIME))
            {
                strSql.AppendFormat(@" AND ACCEPT_TIME >='{0}' AND ACCEPT_TIME <='{1}'", search.ACCEPT_TIME + " 00:00:00", search.ACCEPT_TIME + " 23:59:59");
            }
            return WriteDatabase.Query<TmMatterApplyMajorEntity>(strSql.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 获取审批事项
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable GetApplyMajorList(string keywords, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT * FROM TM_MATTER_APPLY_MAJOR WHERE DELETED = 0 AND ACCEPT_TIME IS NOT NULL AND APPLY_STATUS NOT IN ('SAVE', 'UN_ACCEPTED')");
                if (!string.IsNullOrEmpty(keywords))
                {
                    strSql.AppendFormat(@" AND MATTER_ID IN ({0})", keywords);
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CREATE_TIME", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}

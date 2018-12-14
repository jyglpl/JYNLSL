using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.DataAccess.Approval
{
    public class TmMatterApplyZTYSDal : BaseDal<TmMatterApplyZTYSEntity>
    {
        public List<TmMatterApplyZTYSEntity> GetSearchResult(TmMatterApplyZTYSEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TM_MATTER_APPLY_ZTYS WHERE DELETED = 0");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(@" AND ID='{0}'", search.ID);
            }
            if (!string.IsNullOrEmpty(search.MAJOR_ID))
            {
                strSql.AppendFormat(@" AND MAJOR_ID='{0}'", search.MAJOR_ID);
            }
            return WriteDatabase.Query<TmMatterApplyZTYSEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}

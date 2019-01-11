using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.DataAccess.Approval
{
    public class TmMatterApplyHWGGDal : BaseDal<TmMatterApplyHWGGEntity>
    {
        public List<TmMatterApplyHWGGEntity> GetSearchResult(TmMatterApplyHWGGEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TM_MATTER_APPLY_HWGG WHERE DELETED = 0");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(@" AND ID='{0}'", search.ID);
            }
            if (!string.IsNullOrEmpty(search.MAJOR_ID))
            {
                strSql.AppendFormat(@" AND MAJOR_ID='{0}'", search.MAJOR_ID);
            }
            return WriteDatabase.Query<TmMatterApplyHWGGEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
